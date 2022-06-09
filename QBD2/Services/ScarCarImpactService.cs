using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarImpactService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarImpactService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ScarCarImpact itemToInsert)
        {
            _context.ScarCarImpacts.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScarCarImpact>> Read()
        {
            return await _context.ScarCarImpacts.ToListAsync();
        }

        public async Task Update(ScarCarImpact itemToUpdate)
        {
            var scarCarImpact = _context.ScarCarImpacts.Where(d => d.ScarCarImpactId == itemToUpdate.ScarCarImpactId).FirstOrDefault();
            scarCarImpact.Name = itemToUpdate.Name;
            _context.Entry(scarCarImpact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ScarCarImpact itemToDelete)
        {
            var scarCarImpact = _context.ScarCarImpacts.Where(d => d.ScarCarImpactId == itemToDelete.ScarCarImpactId).FirstOrDefault();
            _context.ScarCarImpacts.Remove(scarCarImpact);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.ScarCarImpacts.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.ScarCarImpactId }).ToList();
        }
    }
}