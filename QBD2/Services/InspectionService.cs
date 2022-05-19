using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;


namespace QBD2.Services
{
    public class InspectionService
    {
        private readonly ApplicationDbContext _context;

        public InspectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Inspection>> Read()
        {
            var retunList = await _context.Inspections
                             .Include(p => p.Part)
                             .Include(p => p.Station)
                             .Include(p => p.InspectionFailures)
                             .OrderByDescending(p => p.UpdateDate)
                             .ToListAsync();
            return retunList;

        }

        public async Task<List<Models.AlertDeviationDetailModel>> ReadAlertAndDeviationDataByMasterPart(int masterPartId)
        {
            List<Models.AlertDeviationDetailModel> alertDeviationDetailModelList = new List<Models.AlertDeviationDetailModel>();
            var alerDetailtList = await (from a in _context.Alerts
                                  join mp in _context.MasterParts
                                  on a.MasterPartId equals mp.MasterPartId
                                  where a.MasterPartId == masterPartId
                                  select new Models.AlertDeviationDetailModel
                                  {
                                      AlertId = a.AlertId,
                                      Title = a.Title,
                                      Alert = a,
                                      DeviationId = 0,
                                      MasterPartId = a.MasterPartId,
                                      MasterPartNumber = mp.PartNumber,
                                      MasterPartDescription = mp.Description,
                                      PartList = (from pa in  _context.PartAlerts
                                                  join p in _context.Parts on pa.PartId equals p.PartId
                                                  where pa.AlertId == a.AlertId
                                                  select p).ToList()
                                  }).ToListAsync();

            if(alerDetailtList != null && alerDetailtList.Count() > 0)
            {
                alertDeviationDetailModelList.AddRange(alerDetailtList);
            }

            var deviationsDetailtList = await (from d in _context.Deviations
                                         join mp in _context.MasterParts
                                         on d.MasterPartId equals mp.MasterPartId
                                         where d.MasterPartId == masterPartId
                                         select new Models.AlertDeviationDetailModel
                                         {
                                             DeviationId = d.DeviationId,
                                             Title = d.Title,
                                             Deviation = d,
                                             AlertId = 0,
                                             MasterPartId = d.MasterPartId,
                                             MasterPartNumber = mp.PartNumber,
                                             MasterPartDescription = mp.Description,
                                             PartList = (from pd in _context.PartDeviations
                                                         join p in _context.Parts on pd.PartId equals p.PartId
                                                         where pd.DeviationId == d.DeviationId
                                                         select p).ToList()
                                         }
                                  ).ToListAsync();

            if (deviationsDetailtList != null && deviationsDetailtList.Count() > 0)
            {
                alertDeviationDetailModelList.AddRange(deviationsDetailtList);
            }

            return alertDeviationDetailModelList;
        }

        public List<Models.DropDownBind> DropDownData(Models.Enum.DropDownType dropDownType, int? value)
        {
            var dropDownitemsList = new List<Models.DropDownBind>();
            switch (dropDownType)
            {
                case Models.Enum.DropDownType.FailureTypePrimary:
                    dropDownitemsList = _context.FailureTypePrimaries.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.FailureTypePrimaryId }).ToList();
                    break;
                case Models.Enum.DropDownType.FailureType:
                    dropDownitemsList = _context.FailureTypes.Where(p => p.FailureTypePrimaryId == value).Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.FailureTypePrimaryId }).ToList();
                    break;
                case Models.Enum.DropDownType.Station:
                    dropDownitemsList = _context.Stations.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.StationId }).ToList();
                    break;

            }
            return dropDownitemsList;

        }


        public async Task<Models.InspectionModel> GetDataBySerialNumber(string serialNumber)
        {
            var InspectionItem = new Models.InspectionModel();
            try
            {
                InspectionItem = await (from p in _context.Parts
                                        join mp in _context.MasterParts
                                        on p.MasterPartId equals mp.MasterPartId
                                        join pf in _context.ProductFamilies
                                        on mp.ProductFamilyId equals pf.ProductFamilyId into productFamily
                                        from familyinfo in productFamily.DefaultIfEmpty()
                                        where p.SerialNumber == serialNumber
                                        select new Models.InspectionModel
                                        {
                                            SerialNumber = p.SerialNumber,
                                            Description = mp.Description,
                                            Family = familyinfo != null ? familyinfo.Name : "",
                                            PartNumber = mp.PartNumber,
                                            PartId = p.PartId,
                                            MasterPartId = p.MasterPartId
                                        }
                                      ).FirstOrDefaultAsync();

                if (InspectionItem != null)
                {
                    InspectionItem.Inspection = await (from ps in _context.Parts
                                                       join i in _context.Inspections
                                                       on ps.PartId equals i.PartId
                                                       where ps.SerialNumber == serialNumber
                                                       select new Models.Inspection
                                                       {
                                                           PartId = i.PartId,
                                                           GeneralComments = i.GeneralComments,
                                                           Pass = i.Pass,
                                                           StationId = i.StationId,
                                                           InspectionId = i.InspectionId

                                                       }).FirstOrDefaultAsync();



                    if (InspectionItem.Inspection != null)
                    {
                        InspectionItem.InspectionFailedList = await (from f in _context.InspectionFailures
                                                                     join i in _context.Inspections
                                                                     on f.InspectionId equals i.InspectionId
                                                                     join t in _context.FailureTypes
                                                                     on f.FailureTypeId equals t.FailureTypeId
                                                                     join p in _context.FailureTypePrimaries
                                                                     on t.FailureTypePrimaryId equals p.FailureTypePrimaryId
                                                                     select new Models.InspectionFailed
                                                                     {
                                                                         InspectionFailureId = f.InspectionFailureId,
                                                                         FailureTypeId = f.FailureTypeId,
                                                                         Comment = f.Comment,
                                                                         FailureName = t.Name,
                                                                         FailurePrimaryName = p.Name,
                                                                         FailurePrimaryTypeId = p.FailureTypePrimaryId

                                                                     }
                                                                     ).ToListAsync();
                    }

                }

            }
            catch (Exception e)
            {
            }
            return InspectionItem;

        }


        public async Task<bool> Save(Models.InspectionModel inspectionModel)
        {
            try
            {
                var inspection = inspectionModel.Inspection;
                var inspectionFailureItem = inspectionModel.InspectionFailedList;

                var objInspection = new Entities.Inspection();


                if (inspection.InspectionId > 0)
                {
                    objInspection = _context.Inspections.Where(d => d.InspectionId == inspection.InspectionId).FirstOrDefault();
                    objInspection.PartId = inspection.PartId;
                    objInspection.Pass = inspection.Pass;
                    objInspection.StationId = inspection.StationId;
                    objInspection.GeneralComments = inspection.GeneralComments;
                    objInspection.UpdateDate = DateTime.Now;

                    objInspection.InspectionId = inspection.InspectionId;
                    _context.Entry(objInspection).State = EntityState.Modified;
                }
                else
                {
                    objInspection = new Entities.Inspection()
                    {
                        PartId = inspection.PartId,
                        Pass = inspection.Pass,
                        StationId = inspection.StationId,
                        GeneralComments = inspection.GeneralComments,
                        UpdateDate = DateTime.Now
                    };

                    _context.Inspections.Add(objInspection);
                }
                await _context.SaveChangesAsync();

                if (!objInspection.Pass)
                {
                    var inspectionFailuresList = _context.InspectionFailures.Where(d => d.InspectionId == objInspection.InspectionId).ToList();
                    if (inspectionFailuresList.Count > 0)
                    {
                        _context.InspectionFailures.RemoveRange(inspectionFailuresList);
                        await _context.SaveChangesAsync();
                    }
                    List<Entities.InspectionFailure> objList = new List<InspectionFailure>();
                    foreach (var item in inspectionFailureItem)
                    {
                        objList.Add(new InspectionFailure
                        {
                            Comment = item.Comment,
                            FailureTypeId = item.FailureTypeId,
                            InspectionId = objInspection.InspectionId

                        });


                    }
                    _context.InspectionFailures.AddRange(objList);
                    await _context.SaveChangesAsync();
                }


                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
