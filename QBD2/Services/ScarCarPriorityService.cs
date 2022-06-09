using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarPriorityService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarPriorityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ScarCarPriority itemToInsert)
        {
            _context.ScarCarPriorities.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScarCarPriority>> Read()
        {
            return await _context.ScarCarPriorities.ToListAsync();
        }

        public async Task Update(ScarCarPriority itemToUpdate)
        {
            var scarCarPriority = _context.ScarCarPriorities.Where(d => d.ScarCarPriorityId == itemToUpdate.ScarCarPriorityId).FirstOrDefault();
            scarCarPriority.Name = itemToUpdate.Name;
            _context.Entry(scarCarPriority).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ScarCarPriority itemToDelete)
        {
            var scarCarPriority = _context.ScarCarPriorities.Where(d => d.ScarCarPriorityId == itemToDelete.ScarCarPriorityId).FirstOrDefault();
            _context.ScarCarPriorities.Remove(scarCarPriority);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.ScarCarPriorities.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.ScarCarPriorityId }).ToList();
        }
    }
}