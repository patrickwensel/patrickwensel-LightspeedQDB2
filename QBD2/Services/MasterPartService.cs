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

        public async Task<List<MasterPart>> GetMasterPartsAsync()
        {
            return await _context.MasterParts.ToListAsync();
        }
    }
}
