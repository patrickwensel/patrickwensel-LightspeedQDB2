using Microsoft.EntityFrameworkCore;
using QBD2.Data;

namespace QBD2.Services
{
    public class BuildStationInspectionService
    {
        private readonly ApplicationDbContext _context;

        public BuildStationInspectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.BuildStationInspectionModel> GetInspectionByWorkOrderIdAndPartId(int workOrderId, int partId, int buildStationId)
        {
            var inspectionModel = new Models.BuildStationInspectionModel();

            var inspection = await _context.BuildStationInspections.FirstOrDefaultAsync(x => x.WorkOrderId == workOrderId && x.PartId == partId && x.BuildStationId == buildStationId);
            if (inspection != null)
                inspectionModel = await GetBuildStationInspectionsById(inspection.BuildStationInspectionId);

            if (inspectionModel == null)
                inspectionModel = new Models.BuildStationInspectionModel();

            //if (inspectionModel.BuildStationInspectionFailedList != null && inspectionModel.BuildStationInspectionFailedList.Count > 0)
            //{
            //    inspectionModel.BuildStationInspectionFailed = inspectionModel.BuildStationInspectionFailedList[0];
            //}
            //else
            //{
                inspectionModel.BuildStationInspectionFailed = new Models.BuildStationInspectionFailed();
            //}

            return inspectionModel;
        }

        public async Task<Models.BuildStationInspectionModel> GetBuildStationInspectionsById(int inspectionId)
        {
            var inspection = new Models.BuildStationInspectionModel();
            try
            {
                inspection = await (from ps in _context.Parts
                                    join i in _context.BuildStationInspections
                                    on ps.PartId equals i.PartId
                                    where i.BuildStationInspectionId == inspectionId
                                    select new Models.BuildStationInspectionModel
                                    {
                                        PartId = i.PartId,
                                        GeneralComments = i.GeneralComments,
                                        Pass = i.Pass,
                                        WorkOrderId = i.WorkOrderId,
                                        BuildStationInspectionId = i.BuildStationInspectionId,
                                        BuildStationId = i.BuildStationId,
                                        IsCompleteBuildStation = i.IsCompleteBuildStation
                                    }).FirstOrDefaultAsync();

                if (inspection != null)
                {
                    inspection.BuildStationInspectionFailedList = await (from f in _context.BuildStationInspectionFailures
                                                                         join i in _context.BuildStationInspections on f.BuildStationInspectionId equals i.BuildStationInspectionId

                                                                         join t in _context.FailureTypes on new { FailureTypeId = f.FailureTypeId }
                                                             equals new { FailureTypeId = (int?)t.FailureTypeId } into t_join
                                                             from t in t_join.DefaultIfEmpty()

                                                             join p in _context.FailureTypePrimaries on new { FailureTypePrimaryId = t.FailureTypePrimaryId }
                                                             equals new { FailureTypePrimaryId = p.FailureTypePrimaryId } into p_join
                                                             from p in p_join.DefaultIfEmpty()
                                                          

                                                             where f.BuildStationInspectionId == inspection.BuildStationInspectionId
                                                                         select new Models.BuildStationInspectionFailed
                                                                         {
                                                                             BuildStationInspectionFailureId = f.BuildStationInspectionFailureId,
                                                                 FailureTypeId = f.FailureTypeId,
                                                                 Comment = f.Comment,
                                                                 FailureName = t.Name,
                                                                 FailurePrimaryName = p.Name,
                                                                 FailurePrimaryTypeId = p.FailureTypePrimaryId
                                                             }).ToListAsync();
                }
            }
            catch (Exception e)
            {
            }
            return inspection;
        }

        public async Task<bool> SaveBuildStationInspection(Models.BuildStationInspectionModel inspection)
        {
            try
            {
                Entities.BuildStationInspection objInspection = new Entities.BuildStationInspection();
                if (inspection.BuildStationInspectionId > 0)
                {
                    objInspection = await _context.BuildStationInspections.FirstOrDefaultAsync(x => x.BuildStationInspectionId == inspection.BuildStationInspectionId);
                }
                objInspection.Pass = inspection.Pass;
                objInspection.GeneralComments = inspection.GeneralComments;
                objInspection.PartId = inspection.PartId;
                objInspection.WorkOrderId = inspection.WorkOrderId;
                objInspection.BuildStationId = inspection.BuildStationId;
                objInspection.UpdateDate = DateTime.Now;
                if (inspection.BuildStationInspectionId > 0)
                {
                    _context.Entry(objInspection).State = EntityState.Modified;
                }
                else
                {
                    _context.BuildStationInspections.Add(objInspection);
                    await _context.SaveChangesAsync();
                }
               
                inspection.BuildStationInspectionId = objInspection.BuildStationInspectionId;

                Entities.BuildStationInspectionFailure objInspectionFailure = new Entities.BuildStationInspectionFailure();
               


                if (inspection.Pass)
                {
                    //if (objInspectionFailure != null && objInspectionFailure.BuildStationInspectionFailureId > 0)
                    //{
                    //    _context.BuildStationInspectionFailures.Remove(objInspectionFailure);
                    //    await _context.SaveChangesAsync();
                    //    inspection.BuildStationInspectionFailed.BuildStationInspectionFailureId = 0;
                    //}
                }
                else
                {
                    foreach(var BuildInspectionFailed in inspection.BuildStationInspectionFailedList)
                    {
                        if (BuildInspectionFailed.BuildStationInspectionFailureId > 0)
                        {
                            objInspectionFailure = await _context.BuildStationInspectionFailures.FirstOrDefaultAsync(x => x.BuildStationInspectionFailureId == inspection.BuildStationInspectionFailed.BuildStationInspectionFailureId);
                        }

                        objInspectionFailure.Comment = BuildInspectionFailed.Comment;
                        objInspectionFailure.BuildStationInspectionId = inspection.BuildStationInspectionId;

                        objInspectionFailure.FailureTypeId = BuildInspectionFailed.FailureTypeId;
                        if (BuildInspectionFailed.BuildStationInspectionFailureId > 0)
                        {
                            _context.Entry(objInspectionFailure).State = EntityState.Modified;
                        }
                        else
                        {
                            _context.BuildStationInspectionFailures.Add(objInspectionFailure);
                        }
                    }
                   
                    //await _context.SaveChangesAsync();
                    inspection.BuildStationInspectionFailed.BuildStationInspectionFailureId = objInspectionFailure.BuildStationInspectionFailureId;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        public async Task<bool> CompleteInspection(Models.BuildStationInspectionModel inspection)
        {
            try
            {
                Entities.BuildStationInspection objInspection = new Entities.BuildStationInspection();

                if (inspection.BuildStationInspectionId > 0)
                {
                    objInspection = await _context.BuildStationInspections.FirstOrDefaultAsync(x => x.BuildStationInspectionId == inspection.BuildStationInspectionId);
                }

               

                if (objInspection.BuildStationInspectionId > 0)
                {
                    objInspection.IsCompleteBuildStation = true;
                    _context.Entry(objInspection).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
