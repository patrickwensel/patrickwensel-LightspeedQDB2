using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class SerialNumberService
    {
        private readonly Sage300Context _sage300Context;

        public SerialNumberService(Sage300Context sage300Context)
        {
            _sage300Context = sage300Context;
        }

        public async Task<List<SerialNumberSearchResult>> GetSerialNumbersFromSage(string itemId, int startSerialNumber, int endSerialNumber)
        {
            List<SerialNumberSearchResult> serialNumberSearchResults = new List<SerialNumberSearchResult>();

            for(int i = startSerialNumber; i < endSerialNumber + 1; )
            {
                SerialNumberSearchResult serialNumberSearch = new SerialNumberSearchResult
                {
                    SerialNumber = i,
                    ItemId = itemId
                };

                serialNumberSearchResults.Add(serialNumberSearch);

                i++;
            }

            foreach(SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                var serialNumber = await _sage300Context.Icxsers
                    .Where(x=>x.Itemnum == serialNumberSearchResult.ItemId 
                    && x.Serialnum == serialNumberSearchResult.SerialNumber.ToString())
                    .FirstOrDefaultAsync();
                if (serialNumber != null)
                    serialNumberSearchResult.IsInSage = true;
                else
                    serialNumberSearchResult.IsInSage = false;
            }

            return serialNumberSearchResults;
        }
    }
}
