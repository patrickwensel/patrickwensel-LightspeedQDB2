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

        public static async Task Create(ProductFamily itemToInsert)
        {

        }

        public async Task<List<ProductFamily>> Read()
        {
            return await _context.ProductFamilies.ToListAsync();
        }

        public static async Task Update(ProductFamily itemToUpdate)
        {

        }

        public static async Task Delete(ProductFamily itemToDelete)
        {

        }

    }
}
