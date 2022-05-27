using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class RepairService
    {
        private readonly ApplicationDbContext _context;

        public RepairService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Repair>> ReadRepairs()
        {
            var x = _context.Repairs.Include(a => a.Part).Include(x => x.GLCode).Include(z => z.FailureCode).ToList();
            return x;
        }

        public async Task<Models.RepairModel> GetDataBySerialNumber(string serialNumber)
        {
            var RepairItem = new Models.RepairModel();
            try
            {
                RepairItem = await (from p in _context.Parts
                                        join mp in _context.MasterParts
                                        on p.MasterPartId equals mp.MasterPartId
                                        join pf in _context.ProductFamilies
                                        on mp.ProductFamilyId equals pf.ProductFamilyId into productFamily
                                        from familyinfo in productFamily.DefaultIfEmpty()
                                        where p.SerialNumber == serialNumber
                                        select new Models.RepairModel
                                        {
                                            SerialNumber = p.SerialNumber,
                                            Description = mp.Description,
                                            Family = familyinfo != null ? familyinfo.Name : "",
                                            PartNumber = mp.PartNumber,
                                            PartId = p.PartId,
                                            MasterPartId = p.MasterPartId
                                        }
                                      ).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

            }
            return RepairItem;
        }

        public async Task Delete(Entities.Repair itemToDelete)
        {
             var repairs = _context.Repairs.Where(d => d.RepairId == itemToDelete.RepairId).FirstOrDefault();
             if (repairs != null)
             {
                 _context.Repairs.Remove(repairs);
                 await _context.SaveChangesAsync();
             }
        }
    }
}