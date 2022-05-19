using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class SerialNumberService
    {
        private readonly Sage300Context _sage300Context;
        private readonly IOptions<ApplicationSettings> _appSettings;

        public SerialNumberService(Sage300Context sage300Context, IOptions<ApplicationSettings> appSettings)
        {
            _sage300Context = sage300Context;
            _appSettings = appSettings;
        }

        public async Task<SerialNumberSearchResult> GetSerialNumberFromSage(string itemId, int serialNumber)
        {
            SerialNumberSearchResult serialNumberSearchResult = new SerialNumberSearchResult
            {
                ItemId = itemId,
                SerialNumber = serialNumber.ToString()
            };

            var serialNumberResult = await _sage300Context.Icxsers
                .Where(x => x.Itemnum == serialNumberSearchResult.ItemId && x.Serialnum == serialNumberSearchResult.SerialNumber)
                .FirstOrDefaultAsync();
            if (serialNumberResult != null)
                serialNumberSearchResult.IsInSage = true;
            else
                serialNumberSearchResult.IsInSage = false;

            return serialNumberSearchResult;
        }

        public async Task<List<SerialNumberSearchResult>> GetSerialNumbersFromSage(string itemId, int startSerialNumber, int endSerialNumber)
        {
            List<SerialNumberSearchResult> serialNumberSearchResults = new List<SerialNumberSearchResult>();

            for (int i = startSerialNumber; i < endSerialNumber + 1;)
            {
                SerialNumberSearchResult serialNumberSearch = new SerialNumberSearchResult
                {
                    SerialNumber = i.ToString(),
                    ItemId = itemId
                };

                serialNumberSearchResults.Add(serialNumberSearch);

                i++;
            }

            foreach (SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                var serialNumber = await _sage300Context.Icxsers
                    .Where(x => x.Itemnum == serialNumberSearchResult.ItemId
                    && x.Serialnum == serialNumberSearchResult.SerialNumber)
                    .FirstOrDefaultAsync();
                if (serialNumber != null)
                    serialNumberSearchResult.IsInSage = true;
                else
                    serialNumberSearchResult.IsInSage = false;
            }

            return serialNumberSearchResults;
        }

        public async Task<List<SerialNumberSearchResult>> GetSerialNumbersFromSageFromList(string itemId, List<string> serialNumbers)
        {
            List<SerialNumberSearchResult> serialNumberSearchResults = new List<SerialNumberSearchResult>();

            foreach (string serialNumber in serialNumbers)
            {
                SerialNumberSearchResult serialNumberSearch = new SerialNumberSearchResult
                {
                    SerialNumber = serialNumber,
                    ItemId = itemId
                };

                serialNumberSearchResults.Add(serialNumberSearch);
            }

            foreach (SerialNumberSearchResult serialNumberSearchResult in serialNumberSearchResults)
            {
                var serialNumber = await _sage300Context.Icxsers
                    .Where(x => x.Itemnum == serialNumberSearchResult.ItemId
                    && x.Serialnum == serialNumberSearchResult.SerialNumber)
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
