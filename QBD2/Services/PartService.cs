using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class PartService
    {
        private readonly ApplicationDbContext _context;
        private readonly SerialNumberService _serialNumberService;

        public PartService(ApplicationDbContext context, SerialNumberService serialNumberService)
        {
            _context = context;
            _serialNumberService = serialNumberService;
        }

        public List<Part> GetAllParts()
        {
            var x = _context.Parts.ToList();
            return x;
        }

        public async Task<List<Parts>> Read()
        {
            var x = await (from p in _context.Parts
                           join mp in _context.MasterParts
                           on p.MasterPartId equals mp.MasterPartId
                           where p.ParentPartId == null
                           select new Parts
                           {

                               PartId = p.PartId,
                               SerialNumber = p.SerialNumber,
                               Description = mp.Description,
                               MasterPartId = mp.MasterPartId,
                               ParentPartId = p.ParentPartId,
                               PartNumber = mp.PartNumber,
                               PartStatusId = p.PartStatusId,
                               PartStatus = p.PartStatus.Name,
                               BuildStationId = p.BuildStationId,
                               BuildStations = p.BuildStation.Name,
                               SerialNumberRequired = p.SerialNumberRequired
                           }
                           ).ToListAsync();

            foreach (var item in x)
            {
                item.ChildParts = await (from p in _context.Parts
                                         join mp in _context.MasterParts
                                         on p.MasterPartId equals mp.MasterPartId
                                         where p.ParentPartId == item.PartId
                                         select new Parts
                                         {
                                             PartId = p.PartId,
                                             SerialNumber = p.SerialNumber,
                                             Description = mp.Description,
                                             MasterPartId = mp.MasterPartId,
                                             ParentPartId = p.ParentPartId,
                                             PartNumber = mp.PartNumber,
                                             PartStatusId = p.PartStatusId,
                                             PartStatus = p.PartStatus.Name,
                                             BuildStationId = p.BuildStationId,
                                             BuildStations = p.BuildStation.Name,
                                             SerialNumberRequired = p.SerialNumberRequired
                                         }).ToListAsync();
            }
            return x;
        }

        public async Task<AddPartsToDeviationModel> AddPartsToDeviationByList(MasterPart masterPart, List<string> serialNumbers)
        {
            AddPartsToDeviationModel addPartsToDeviationModel = new AddPartsToDeviationModel();
            addPartsToDeviationModel.AddPartsToDeviationError = new List<AddPartsToDeviationError>();
            addPartsToDeviationModel.Parts = new List<Part>();

            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSageFromList(masterPart.Itemno, serialNumbers);

            return await AddPartsToDeviation(masterPart, addPartsToDeviationModel, serialNumberSearchResults);
        }

        public async Task<AddPartsToDeviationModel> AddPartsToDeviationByStartEnd(MasterPart masterPart, long startSerialNumber, long endSerialNumber)
        {
            AddPartsToDeviationModel addPartsToDeviationModel = new AddPartsToDeviationModel();
            addPartsToDeviationModel.AddPartsToDeviationError = new List<AddPartsToDeviationError>();
            addPartsToDeviationModel.Parts = new List<Part>();

            if (startSerialNumber > endSerialNumber)
            {
                AddPartsToDeviationError addPartsToDeviationError = new AddPartsToDeviationError
                {
                    Error = "Start serial number lower than end serial number."
                };
                addPartsToDeviationModel.AddPartsToDeviationError.Add(addPartsToDeviationError);
                return addPartsToDeviationModel;
            }

            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSage(masterPart.Itemno, startSerialNumber, endSerialNumber);

            return await AddPartsToDeviation(masterPart, addPartsToDeviationModel, serialNumberSearchResults);
        }

        private async Task<AddPartsToDeviationModel> AddPartsToDeviation(MasterPart masterPart, AddPartsToDeviationModel addPartsToDeviationModel, List<SerialNumberSearchResult> serialNumberSearchResults)
        {
            foreach (SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                if (serialNumberSearchResult.IsInSage == false)
                {
                    AddPartsToDeviationError addPartsToDeviationError = new AddPartsToDeviationError
                    {
                        Error = "Serial Number: " + serialNumberSearchResult.SerialNumber + " was not listed in Stage",
                        SerialNumber = serialNumberSearchResult.SerialNumber
                    };
                    addPartsToDeviationModel.AddPartsToDeviationError.Add(addPartsToDeviationError);
                }
                else
                {
                    Part part;
                    //Check if serial number is in Parts table
                    part = await GetPartBySerialNumber(serialNumberSearchResult.SerialNumber);


                    if (part == null)
                    {
                        Part newPart = new Part
                        {
                            MasterPartId = masterPart.MasterPartId,
                            SerialNumber = serialNumberSearchResult.SerialNumber,
                            PartStatusId = 1,
                            UpdateDate = DateTime.Now
                        };
                        _context.Parts.Add(newPart);
                        await _context.SaveChangesAsync();
                        part = newPart;
                    }

                    addPartsToDeviationModel.Parts.Add(part);
                }
            }

            return addPartsToDeviationModel;
        }

        public async Task<AddPartsToAlertModel> AddPartsToAlertByList(MasterPart masterPart, List<string> serialNumbers)
        {
            AddPartsToAlertModel addPartsToAlertModel = new AddPartsToAlertModel();
            addPartsToAlertModel.AddPartsToAlertError = new List<AddPartsToAlertError>();
            addPartsToAlertModel.Parts = new List<Part>();

            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSageFromList(masterPart.Itemno, serialNumbers);

            return await AddPartsToAlert(masterPart, addPartsToAlertModel, serialNumberSearchResults);
        }

        public async Task<AddPartsToAlertModel> AddPartsToAlertByStartEnd(MasterPart masterPart, long startSerialNumber, long endSerialNumber)
        {
            AddPartsToAlertModel addPartsToAlertModel = new AddPartsToAlertModel();
            addPartsToAlertModel.AddPartsToAlertError = new List<AddPartsToAlertError>();
            addPartsToAlertModel.Parts = new List<Part>();

            if (startSerialNumber > endSerialNumber)
            {
                AddPartsToAlertError addPartsToAlertError = new AddPartsToAlertError
                {
                    Error = "Start serial number lower than end serial number."
                };
                addPartsToAlertModel.AddPartsToAlertError.Add(addPartsToAlertError);
                return addPartsToAlertModel;
            }

            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSage(masterPart.Itemno, startSerialNumber, endSerialNumber);

            return await AddPartsToAlert(masterPart, addPartsToAlertModel, serialNumberSearchResults);
        }

        private async Task<AddPartsToAlertModel> AddPartsToAlert(MasterPart masterPart, AddPartsToAlertModel addPartsToAlertModel, List<SerialNumberSearchResult> serialNumberSearchResults)
        {
            foreach (SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                if (serialNumberSearchResult.IsInSage == false)
                {
                    AddPartsToAlertError addPartsToAlertError = new AddPartsToAlertError
                    {
                        Error = "Serial Number: " + serialNumberSearchResult.SerialNumber + " was not listed in Stage",
                        SerialNumber = serialNumberSearchResult.SerialNumber
                    };
                    addPartsToAlertModel.AddPartsToAlertError.Add(addPartsToAlertError);
                }
                else
                {
                    Part part;
                    //Check if serial number is in Parts table
                    part = await GetPartBySerialNumber(serialNumberSearchResult.SerialNumber);

                    if (part == null)
                    {
                        Part newPart = new Part
                        {
                            MasterPartId = masterPart.MasterPartId,
                            SerialNumber = serialNumberSearchResult.SerialNumber,
                            PartStatusId = 1,
                            UpdateDate = DateTime.Now
                        };
                        _context.Parts.Add(newPart);
                        await _context.SaveChangesAsync();
                        part = newPart;
                    }

                    addPartsToAlertModel.Parts.Add(part);
                }
            }

            return addPartsToAlertModel;
        }

        public async Task<Part> GetPartBySerialNumberAndMasterPart(string serialNumber, int masterPartId)
        {
            Part part = null;
            var parentPart = await _context.Parts.Where(x => x.MasterPartId == masterPartId).Select(x => x.PartId).ToListAsync();
            var parts = await (from p in _context.Parts
                              join mp in _context.MasterParts
                              on p.MasterPartId equals mp.MasterPartId
                              where 
                              p.MasterPartId == masterPartId || parentPart.Contains(p.ParentPartId.Value)
                              select p).ToListAsync();

            if(parts != null && parts.Count() > 0)
            {
                part = parts.Where(x => x.SerialNumber.Trim() == serialNumber.Trim()).FirstOrDefault();
            }

            return part;
        }

        private async Task<Part> GetPartBySerialNumber(string serialNumber)
        {
            return await _context.Parts.Where(x => x.SerialNumber == serialNumber).FirstOrDefaultAsync();
        }

        public async Task<List<Parts>> GetParentPartByPart(int partId)
        {
            var p1 = await _context.Parts.FindAsync(partId);
            if(p1 != null && p1.ParentPartId == null)
            {
                partId = p1.PartId;
            }
            else if(p1 != null && p1.ParentPartId > 0)
            {
                partId = p1.ParentPartId.Value;
            }

            var x = await (from p in _context.Parts
                           join mp in _context.MasterParts
                           on p.MasterPartId equals mp.MasterPartId

                           join ps in _context.PartStatuses
                           on p.PartStatusId equals ps.PartStatusId

                           //join repairsInfo in _context.Repairs
                           //on p.PartId equals repairsInfo.PartId

                           where p.ParentPartId == partId

                           select new Models.Parts
                           {
                               PartId = p.PartId,
                               SerialNumber = p.SerialNumber,
                               Description = mp.Description,
                               MasterPartId = mp.MasterPartId,
                               ParentPartId = p.ParentPartId,
                               PartNumber = mp.PartNumber,
                               UpdateDate = p.UpdateDate,
                               PartStatusId = p.PartStatusId,
                               PartStatus = ps.Name,
                               //GLCodeId = repairsInfo.GLCodeId,
                               //GLCode = repairsInfo != null && repairsInfo.GLCode != null ? repairsInfo.GLCode.Name : "",
                           }).ToListAsync();

            if (x != null && x.Count() > 0)
            {
                x = x.OrderByDescending(x => x.UpdateDate).ToList();
            }    

            foreach (var item in x)
            {
                item.ChildParts = await (from p in _context.Parts
                                         join mp in _context.MasterParts
                                         on p.MasterPartId equals mp.MasterPartId
                                         where p.ParentPartId == item.PartId
                                         select new Models.Parts
                                         {
                                             PartId = p.PartId,
                                             SerialNumber = p.SerialNumber,
                                             Description = mp.Description,
                                             MasterPartId = mp.MasterPartId,
                                             ParentPartId = p.ParentPartId,
                                             PartNumber = mp.PartNumber
                                         }).ToListAsync();
            }
            return x;
        }

        public async Task<List<Parts>> GetActiveParentPartByPart(int partId)
        {
            var p1 = await _context.Parts.FindAsync(partId);
            if (p1 != null && p1.ParentPartId == null)
            {
                partId = p1.PartId;
            }
            else if (p1 != null && p1.ParentPartId > 0)
            {
                partId = p1.ParentPartId.Value;
            }

            var x = await (from p in _context.Parts
                           join mp in _context.MasterParts
                           on p.MasterPartId equals mp.MasterPartId

                           join ps in _context.PartStatuses
                           on p.PartStatusId equals ps.PartStatusId

                           where p.ParentPartId == partId && p.PartStatusId == 1

                           select new Models.Parts
                           {
                               PartId = p.PartId,
                               SerialNumber = p.SerialNumber,
                               Description = mp.Description,
                               MasterPartId = mp.MasterPartId,
                               ParentPartId = p.ParentPartId,
                               PartNumber = mp.PartNumber,
                               UpdateDate = p.UpdateDate,
                               PartStatusId = p.PartStatusId,
                               PartStatus = ps.Name,
                           }).ToListAsync();

            if (x != null && x.Count() > 0)
            {
                x = x.OrderByDescending(x => x.UpdateDate).ToList();
            }

            foreach (var item in x)
            {
                item.ChildParts = await (from p in _context.Parts
                                         join mp in _context.MasterParts
                                         on p.MasterPartId equals mp.MasterPartId
                                         where p.ParentPartId == item.PartId
                                         && p.PartStatusId == 1
                                         select new Models.Parts
                                         {
                                             PartId = p.PartId,
                                             SerialNumber = p.SerialNumber,
                                             Description = mp.Description,
                                             MasterPartId = mp.MasterPartId,
                                             ParentPartId = p.ParentPartId,
                                             PartNumber = mp.PartNumber
                                         }).ToListAsync();
            }
            return x;
        }

        public async Task<List<Parts>> GetPartReplaceOnRepairParentPartByPart(int partId)
        {
            var p1 = await _context.Parts.FindAsync(partId);
            if (p1 != null && p1.ParentPartId == null)
            {
                partId = p1.PartId;
            }
            else if (p1 != null && p1.ParentPartId > 0)
            {
                partId = p1.ParentPartId.Value;
            }

            var x = await (from p in _context.Parts
                           join mp in _context.MasterParts
                           on p.MasterPartId equals mp.MasterPartId

                           join ps in _context.PartStatuses
                           on p.PartStatusId equals ps.PartStatusId

                           join repairsInfo in _context.Repairs
                           on p.PartId equals repairsInfo.PartId

                           where p.ParentPartId == partId

                           select new Models.Parts
                           {
                               PartId = p.PartId,
                               SerialNumber = p.SerialNumber,
                               Description = mp.Description,
                               MasterPartId = mp.MasterPartId,
                               ParentPartId = p.ParentPartId,
                               PartNumber = mp.PartNumber,
                               UpdateDate = p.UpdateDate,
                               PartStatusId = p.PartStatusId,
                               PartStatus = ps.Name,
                               FailureTypeId = repairsInfo.FailureTypeId,
                               FailureType = repairsInfo != null && repairsInfo.FailureType != null ? repairsInfo.FailureType.Name : "",
                               FailureTypePrimaryId = repairsInfo.FailureTypeId,
                               FailureTypePrimary = repairsInfo != null && repairsInfo.FailureType != null && repairsInfo.FailureType.FailureTypePrimary != null ? repairsInfo.FailureType.FailureTypePrimary.Name : "",
                               GLCodeId = repairsInfo.GLCodeId,
                               GLCode = repairsInfo != null && repairsInfo.GLCode != null ? repairsInfo.GLCode.Name : "",
                               RepairDescription = repairsInfo.Description,
                               RepairId = repairsInfo.RepairId
                           }).ToListAsync();

            if (x != null && x.Count() > 0)
            {
                x = x.OrderByDescending(x => x.UpdateDate).ToList();
            }

            foreach (var item in x)
            {
                item.ChildParts = await (from p in _context.Parts
                                         join mp in _context.MasterParts
                                         on p.MasterPartId equals mp.MasterPartId
                                         where p.ParentPartId == item.PartId
                                         select new Models.Parts
                                         {
                                             PartId = p.PartId,
                                             SerialNumber = p.SerialNumber,
                                             Description = mp.Description,
                                             MasterPartId = mp.MasterPartId,
                                             ParentPartId = p.ParentPartId,
                                             PartNumber = mp.PartNumber
                                         }).ToListAsync();
            }
            return x;
        }

        public async Task<List<Parts>> GetPartByMasterPart(int masterPartId)
        {
            var x = await (from p in _context.Parts
                           join mp in _context.MasterParts
                           on p.MasterPartId equals mp.MasterPartId

                           join ps in _context.PartStatuses
                           on p.PartStatusId equals ps.PartStatusId

                           where p.MasterPartId == masterPartId && p.PartStatusId == 1

                           select new Models.Parts
                           {
                               PartId = p.PartId,
                               SerialNumber = p.SerialNumber,
                               Description = mp.Description,
                               MasterPartId = mp.MasterPartId,
                               ParentPartId = p.ParentPartId,
                               PartNumber = mp.PartNumber,
                               UpdateDate = p.UpdateDate,
                               PartStatusId = p.PartStatusId,
                               PartStatus = ps.Name,
                           }).ToListAsync();

            if (x != null && x.Count() > 0)
            {
                x = x.OrderByDescending(x => x.UpdateDate).ToList();
            }

            return x;
        }

        public async Task<bool> AddPart(AddPartModel itemToInsert)
        {
            try
            {
                var selectedPart = await _context.Parts.FindAsync(itemToInsert.SelectedPartId);
                if (selectedPart != null)
                {
                    MasterPart masterPart = new MasterPart();
                    //masterPart.PartNumber = itemToInsert.PartNumber;
                    //masterPart.Description = "";
                    //_context.MasterParts.Add(masterPart);
                    //await _context.SaveChangesAsync();
                    masterPart = _context.MasterParts.FirstOrDefault(x => x.PartNumber == itemToInsert.PartNumber.Trim());
                    if (masterPart != null)
                    {

                        Part part = new Part();
                        if (selectedPart.ParentPartId > 0)
                        {
                            part.ParentPartId = selectedPart.ParentPartId;
                        }
                        else
                        {
                            part.ParentPartId = itemToInsert.SelectedPartId;
                        }

                        if (!string.IsNullOrWhiteSpace(itemToInsert.SerialNumber))
                        {
                            part.SerialNumber = itemToInsert.SerialNumber;
                        }
                        else
                        {
                            part.SerialNumber = "";
                        }

                        if (itemToInsert.SelectedReplacePartId > 0)
                        {
                            var replacePart = await _context.Parts.Where(a => a.PartId == itemToInsert.SelectedReplacePartId).FirstOrDefaultAsync();
                            if (replacePart != null)
                            {
                                replacePart.PartStatusId = 2;
                                _context.Entry(replacePart).State = EntityState.Modified;
                                await _context.SaveChangesAsync();
                            }
                        }

                        part.MasterPartId = masterPart.MasterPartId;
                        part.UpdateDate = DateTime.Now;
                        part.PartStatusId = 1;
                        _context.Parts.Add(part);
                        _context.SaveChanges();

                        Repair repair = new Repair();
                        repair.Description = itemToInsert.RepairDescription;
                        repair.GLCodeId = itemToInsert.GLCodeId.Value;
                        repair.FailureTypeId = itemToInsert.FailureTypeId.Value;
                        repair.PartId = part.PartId;
                        repair.UpdateDate = DateTime.Now;
                        _context.Repairs.Add(repair);
                        _context.SaveChanges();

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ValidPartNumber(string partNumber)
        {
            return _context.MasterParts.Any(x => x.PartNumber == partNumber.Trim());
        }

        public async Task<bool> UpdatePartStatus(Models.Parts parts)
        {
            try
            {
                var part = _context.Parts.Where(d => d.PartId == parts.PartId).FirstOrDefault();
                if (part != null)
                {
                    part.PartStatusId = parts.PartStatusId;
                    _context.Entry(part).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ApiResponse> UpdatePartSerialNumber(EditPartModel editPartModel)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();
            try
            {
                if (editPartModel != null)
                {
                    var part = await _context.Parts.FindAsync(editPartModel.PartId);
                    if (part != null)
                    {
                        part.SerialNumber = editPartModel.SerialNumber;
                        _context.Entry(part).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        apiResponse.Success = true;
                        apiResponse.Message = "Record updated Successfully.";
                        return apiResponse;
                    }
                    else
                    {
                        apiResponse.Success = false;
                        apiResponse.Message = "Please enter valid data.";
                        return apiResponse;
                    }
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = " Please enter valid data.";
                    return apiResponse;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Record Not Saved ! Something Worng.";
                return apiResponse;
            }
        }
    }

    public class AddPartsToDeviationError
    {
        public string Error { get; set; }
        public string SerialNumber { get; set; }

    }

    public class AddPartsToDeviationModel
    {
        public List<AddPartsToDeviationError> AddPartsToDeviationError { get; set; }
        public List<Part> Parts { get; set; }
    }

    public class AddPartsToAlertError
    {
        public string Error { get; set; }
        public string SerialNumber { get; set; }
    }

    public class AddPartsToAlertModel
    {
        public List<AddPartsToAlertError> AddPartsToAlertError { get; set; }
        public List<Part> Parts { get; set; }
    }
}
