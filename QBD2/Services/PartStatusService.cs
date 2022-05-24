using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class PartStatusService
    {
        private readonly ApplicationDbContext _context;

        public PartStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(PartStatus itemToInsert)
        {
            _context.PartStatuses.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PartStatus>> Read()
        {
            return await _context.PartStatuses.ToListAsync();
        }

        public async Task Update(PartStatus itemToUpdate)
        {
            var partStatus = _context.PartStatuses.Where(d => d.PartStatusId == itemToUpdate.PartStatusId).FirstOrDefault();
            partStatus.Name = itemToUpdate.Name;
            _context.Entry(partStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PartStatus itemToDelete)
        {
            var partStatus = _context.PartStatuses.Where(d => d.PartStatusId == itemToDelete.PartStatusId).FirstOrDefault();
            _context.PartStatuses.Remove(partStatus);
            await _context.SaveChangesAsync();
        }
    }
}