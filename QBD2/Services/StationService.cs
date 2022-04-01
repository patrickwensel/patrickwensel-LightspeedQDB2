using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class StationService
    {
        private readonly ApplicationDbContext _context;

        public StationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Station>> GetAllStations()
        {
            return await _context.Stations.ToListAsync();
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
