using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class WorkOrderPriorityService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderPriorityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(WorkOrderPriority itemToInsert)
        {
            _context.WorkOrderPriorities.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WorkOrderPriority>> Read()
        {
            return await _context.WorkOrderPriorities.ToListAsync();
        }

        public async Task Update(WorkOrderPriority itemToUpdate)
        {
            var workOrderPriorities = _context.WorkOrderPriorities.Where(d => d.WorkOrderPriorityId == itemToUpdate.WorkOrderPriorityId).FirstOrDefault();
            workOrderPriorities.Name = itemToUpdate.Name;
            _context.Entry(workOrderPriorities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(WorkOrderPriority itemToDelete)
        {
            var workOrderPriorities = _context.WorkOrderPriorities.Where(d => d.WorkOrderPriorityId == itemToDelete.WorkOrderPriorityId).FirstOrDefault();
            _context.WorkOrderPriorities.Remove(workOrderPriorities);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.WorkOrderPriorities.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.WorkOrderPriorityId }).ToList();
        }
    }
}