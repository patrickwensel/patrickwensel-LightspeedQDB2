using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ProductFamilyService
    {
        private readonly ApplicationDbContext _context;

        public ProductFamilyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductFamily itemToInsert)
        {
            _context.ProductFamilies.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductFamily>> Read()
        {
            return await _context.ProductFamilies.ToListAsync();
        }

        public async Task Update(ProductFamily itemToUpdate)
        {
            var productFamily = _context.ProductFamilies.Where(d => d.ProductFamilyId == itemToUpdate.ProductFamilyId).FirstOrDefault();
            productFamily = itemToUpdate;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProductFamily itemToDelete)
        {
            var productFamily = _context.ProductFamilies.Where(d=>d.ProductFamilyId == itemToDelete.ProductFamilyId).FirstOrDefault();
            _context.ProductFamilies.Remove(productFamily);
            await _context.SaveChangesAsync();
        }

    }
}
