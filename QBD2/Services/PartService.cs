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
                               PartNumber = mp.PartNumber

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
                                             PartNumber = mp.PartNumber

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
                        Error = "Serial Number: " + serialNumberSearchResult.SerialNumber + " was not listed in Stage"
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
                            SerialNumber = serialNumberSearchResult.SerialNumber

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
                        Error = "Serial Number: " + serialNumberSearchResult.SerialNumber + " was not listed in Stage"
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
                            SerialNumber = serialNumberSearchResult.SerialNumber

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
    }
    public class AddPartsToDeviationError
    {
        public string Error { get; set; }
    }

    public class AddPartsToDeviationModel
    {
        public List<AddPartsToDeviationError> AddPartsToDeviationError { get; set; }
        public List<Part> Parts { get; set; }
    }

    public class AddPartsToAlertError
    {
        public string Error { get; set; }
    }

    public class AddPartsToAlertModel
    {
        public List<AddPartsToAlertError> AddPartsToAlertError { get; set; }
        public List<Part> Parts { get; set; }
    }
}
