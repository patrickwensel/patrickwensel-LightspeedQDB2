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

        public async Task<List<AddPartsToDeviationError>> AddPartsToDeviationByList(Deviation deviation, List<string> serialNumbers)
        {
            List<AddPartsToDeviationError> addPartsToDeviationErrors = new List<AddPartsToDeviationError>();
            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSageFromList(deviation.MasterPart.Itemno, serialNumbers);

            return await AddPartsToDeviation(deviation, addPartsToDeviationErrors, serialNumberSearchResults);
        }

        public async Task<List<AddPartsToDeviationError>> AddPartsToDeviationByStartEnd(Deviation deviation, int startSerialNumber, int endSerialNumber)
        {
            List<AddPartsToDeviationError> addPartsToDeviationErrors = new List<AddPartsToDeviationError>();
            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSage(deviation.MasterPart.Itemno, startSerialNumber, endSerialNumber);

            return await AddPartsToDeviation(deviation, addPartsToDeviationErrors, serialNumberSearchResults);
        }

        private async Task<List<AddPartsToDeviationError>> AddPartsToDeviation(Deviation deviation, List<AddPartsToDeviationError> addPartsToDeviationErrors, List<SerialNumberSearchResult> serialNumberSearchResults)
        {
            foreach (SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                if (serialNumberSearchResult.IsInSage == false)
                {
                    AddPartsToDeviationError addPartsToDeviationError = new AddPartsToDeviationError
                    {
                        Error = "Serial Number: " + serialNumberSearchResult.SerialNumber + " was not listed in Stage"
                    };
                    addPartsToDeviationErrors.Add(addPartsToDeviationError);
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
                            MasterPartId = deviation.MasterPartId,
                            SerialNumber = serialNumberSearchResult.SerialNumber

                        };
                        _context.Parts.Add(newPart);
                        await _context.SaveChangesAsync();
                        part = newPart;
                    }

                    PartDeviation partDeviation = new PartDeviation
                    {
                        DeviationId = deviation.DeviationId,
                        PartId = part.PartId
                    };

                    _context.PartDeviations.Add(partDeviation);
                    await _context.SaveChangesAsync();
                }
            }

            return addPartsToDeviationErrors;
        }

        public async Task<Part> GetPartBySerialNumberAndMasterPart(string serialNumber, int masterPartId)
        {
            var part = await (from p in _context.Parts
                              join mp in _context.MasterParts
                              on p.MasterPartId equals mp.MasterPartId
                              where p.SerialNumber.Trim() == serialNumber.Trim()
                              && p.MasterPartId == masterPartId
                              select p).FirstOrDefaultAsync();

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
}
