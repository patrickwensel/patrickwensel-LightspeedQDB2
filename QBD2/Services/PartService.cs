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

        public async Task<List<AddPartsToDeviationError>> AddPartsToDeviation(int deviationId, string itemId, int startSerialNumber, int endSerialNumber)
        {
            List<AddPartsToDeviationError> addPartsToDeviationErrors = new List<AddPartsToDeviationError>();
            List<SerialNumberSearchResult> serialNumberSearchResults = await _serialNumberService.GetSerialNumbersFromSage(itemId, startSerialNumber, endSerialNumber);

            foreach(SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                if(serialNumberSearchResult.IsInSage == false)
                {
                    AddPartsToDeviationError addPartsToDeviationError = new AddPartsToDeviationError
                    {
                        Error = "Serial Number: " + serialNumberSearchResult.SerialNumber + " was not listed in Stage"
                    };
                    addPartsToDeviationErrors.Add(addPartsToDeviationError);
                }
                else
                {


                    PartDeviation partDeviation = new PartDeviation
                    {
                        DeviationId = deviationId,
                        //PartId 
                    };
                }
            }

            return addPartsToDeviationErrors;
        }


    }
    public class AddPartsToDeviationError
    {
        public string Error { get; set; }
    }
}
