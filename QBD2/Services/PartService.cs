using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class PartService
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Part>> Read()
        {
            var x = await _context.Parts
                .Include(x => x.MasterPart)
                .Include(x => x.ParentPart)
                .ToListAsync();
            return x;
        }
    }
}
