using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class PartService
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
