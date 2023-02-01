using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Models;

namespace QBD2.Services
{
    public class PONumberService
    {
        private readonly Sage300Context _sage300Context;

        public PONumberService(Sage300Context sage300Context)
        {
            _sage300Context = sage300Context;
        }

        public async Task<List<DropDownBindString>> GetPONumberList()
        {
            var data = await _sage300Context.Porcph1s.Where(x => string.IsNullOrWhiteSpace(x.Ponumber) == false)
                .Select(i => new DropDownBindString
                {
                    DropText = i.Ponumber.Trim(),
                    DropValue = i.Ponumber.Trim()
                })
                .Distinct().ToListAsync();

            data = data.OrderBy(x => x.DropText).ToList();

            return data;

        }

        public async Task<List<DropDownBindString>> GetSerialNumberList()
        {
            var data = await _sage300Context.Porcplss.Where(x => string.IsNullOrWhiteSpace(x.Serialnumf) == false)
                .Select(i => new DropDownBindString
                {
                    DropText = i.Serialnumf.Trim(),
                    DropValue= i.Serialnumf.Trim()
                })
                .Distinct().ToListAsync();

            data = data.OrderBy(x => x.DropText).ToList();

            return data;

        }

        public async Task<string?> GetPONumberBySerialNumber(string serialNumber)
        {
            string? poNumber = string.Empty;
            if (!string.IsNullOrWhiteSpace(serialNumber))
            {
                poNumber = await (from Porcph1s in _sage300Context.Porcph1s
                                  join Porcpls in _sage300Context.Porcpls on Porcph1s.Rcphseq equals Porcpls.Rcphseq
                                  join Porcplss in _sage300Context.Porcplss on Porcph1s.Rcphseq equals Porcplss.Rcphseq
                                  where Porcplss.Serialnumf.Trim() == serialNumber.Trim()
                                  select Porcph1s.Ponumber).FirstOrDefaultAsync();
            }

            return poNumber;
        }
    }
}
