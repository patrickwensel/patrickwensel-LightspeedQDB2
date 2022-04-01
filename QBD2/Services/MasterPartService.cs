using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class MasterPartService
    {
        private readonly ApplicationDbContext _context;

        public MasterPartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public static async Task Create(MasterPart itemToInsert)
        {

        }

        public async Task<List<MasterPart>> Read()
        {
            return await _context.MasterParts.ToListAsync();
        }

        public static async Task Update(MasterPart itemToUpdate)
        {

        }

        public static async Task Delete(MasterPart itemToDelete)
        {

        }
    }
}
