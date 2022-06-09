using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarStatusService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ScarCarStatus itemToInsert)
        {
            _context.ScarCarStatuses.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScarCarStatus>> Read()
        {
            return await _context.ScarCarStatuses.ToListAsync();
        }

        public async Task Update(ScarCarStatus itemToUpdate)
        {
            var scarCarStatus = _context.ScarCarStatuses.Where(d => d.ScarCarStatusId == itemToUpdate.ScarCarStatusId).FirstOrDefault();
            scarCarStatus.Name = itemToUpdate.Name;
            _context.Entry(scarCarStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ScarCarStatus itemToDelete)
        {
            var scarCarStatus = _context.ScarCarStatuses.Where(d => d.ScarCarStatusId == itemToDelete.ScarCarStatusId).FirstOrDefault();
            _context.ScarCarStatuses.Remove(scarCarStatus);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.ScarCarStatuses.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.ScarCarStatusId }).ToList();
        }
    }
}