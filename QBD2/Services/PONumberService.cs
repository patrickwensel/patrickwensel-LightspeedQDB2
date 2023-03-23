using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Models;
using System.Data;

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
            var dataPo = await _sage300Context.Porcph1s.Where(x => string.IsNullOrWhiteSpace(x.Ponumber) == false)
                .Select(i => new DropDownBindString
                {
                    DropText = i.Ponumber.Trim(),
                    DropValue = i.Ponumber.Trim()
                })
                .Distinct().ToListAsync();

            var dataAssembly = await _sage300Context.Icasens.Where(x => string.IsNullOrWhiteSpace(x.Docnum) == false)
               .Select(i => new DropDownBindString
               {
                   DropText = i.Docnum.Trim(),
                   DropValue = i.Docnum.Trim()
               })
               .Distinct().ToListAsync();

            dataPo = dataPo.OrderBy(x => x.DropText).ToList();
            dataAssembly = dataAssembly.OrderBy(x => x.DropText).ToList();

            List<DropDownBindString> data = new List<DropDownBindString>(dataPo);
            data.AddRange(dataAssembly);
            data = data.GroupBy(i => i.DropText).Select(i => i.FirstOrDefault()).ToList();

            return data;
        }

        public async Task<List<DropDownBindString>> GetSerialNumberList()
        {
            var dataPo = await _sage300Context.Porcplss.Where(x => string.IsNullOrWhiteSpace(x.Serialnumf) == false)
                .Select(i => new DropDownBindString
                {
                    DropText = i.Serialnumf.Trim(),
                    DropValue= i.Serialnumf.Trim()
                })
                .Distinct().ToListAsync();

            var dataAssembly = await _sage300Context.Icasenss.Where(x => string.IsNullOrWhiteSpace(x.Serialnumf) == false)
                .Select(i => new DropDownBindString
                {
                    DropText = i.Serialnumf.Trim(),
                    DropValue = i.Serialnumf.Trim()
                })
                .Distinct().ToListAsync();

            dataPo = dataPo.OrderBy(x => x.DropText).ToList();
            dataAssembly = dataAssembly.OrderBy(x => x.DropText).ToList();

            List<DropDownBindString> data = new List<DropDownBindString>(dataPo);
            data.AddRange(dataAssembly);
            data = data.GroupBy(i => i.DropText).Select(i => i.FirstOrDefault()).ToList();

            return data;

        }

        public async Task<string?> GetPONumberOrAssemblyNumberBySerialNumber(string serialNumber)
        {
            string? poNumber = string.Empty;
            if (!string.IsNullOrWhiteSpace(serialNumber))
            {
                poNumber = await (from Porcph1s in _sage300Context.Porcph1s
                                  join Porcpls in _sage300Context.Porcpls on Porcph1s.Rcphseq equals Porcpls.Rcphseq
                                  join Porcplss in _sage300Context.Porcplss on Porcph1s.Rcphseq equals Porcplss.Rcphseq
                                  where Porcplss.Serialnumf.Trim() == serialNumber.Trim()
                                  select Porcph1s.Ponumber).FirstOrDefaultAsync();

                if (string.IsNullOrWhiteSpace(poNumber))
                {
                    poNumber = await (from Icasenss in _sage300Context.Icasenss
                                                join Icasens in _sage300Context.Icasens on Icasenss.Assmenseq equals Icasens.Assmenseq
                                                where Icasenss.Serialnumf.Trim() == serialNumber.Trim()
                                                select Icasens.Docnum).FirstOrDefaultAsync();
                }
            }

            return poNumber;
        }
    }
}
