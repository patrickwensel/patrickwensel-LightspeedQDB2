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

        public async Task<List<ProductFamily>> GetProductFamiliesAsync()
        {
            return await _context.ProductFamilies.ToListAsync();
        }

    }
}
