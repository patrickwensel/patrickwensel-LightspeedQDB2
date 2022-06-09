using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarResolutionService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarResolutionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ScarCarResolution itemToInsert)
        {
            _context.ScarCarResolutions.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScarCarResolution>> Read()
        {
            return await _context.ScarCarResolutions.ToListAsync();
        }

        public async Task Update(ScarCarResolution itemToUpdate)
        {
            var scarCarResolution = _context.ScarCarResolutions.Where(d => d.ScarCarResolutionId == itemToUpdate.ScarCarResolutionId).FirstOrDefault();
            scarCarResolution.Name = itemToUpdate.Name;
            _context.Entry(scarCarResolution).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ScarCarResolution itemToDelete)
        {
            var scarCarResolution = _context.ScarCarResolutions.Where(d => d.ScarCarResolutionId == itemToDelete.ScarCarResolutionId).FirstOrDefault();
            _context.ScarCarResolutions.Remove(scarCarResolution);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.ScarCarResolutions.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.ScarCarResolutionId }).ToList();
        }
    }
}