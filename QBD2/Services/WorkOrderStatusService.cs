using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class WorkOrderStatusService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(WorkOrderStatus itemToInsert)
        {
            _context.WorkOrderStatuses.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WorkOrderStatus>> Read()
        {
            return await _context.WorkOrderStatuses.ToListAsync();
        }

        public async Task Update(WorkOrderStatus itemToUpdate)
        {
            var workOrderStatuses = _context.WorkOrderStatuses.Where(d => d.WorkOrderStatusId == itemToUpdate.WorkOrderStatusId).FirstOrDefault();
            workOrderStatuses.Name = itemToUpdate.Name;
            _context.Entry(workOrderStatuses).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(WorkOrderStatus itemToDelete)
        {
            var workOrderStatuses = _context.WorkOrderStatuses.Where(d => d.WorkOrderStatusId == itemToDelete.WorkOrderStatusId).FirstOrDefault();
            _context.WorkOrderStatuses.Remove(workOrderStatuses);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.WorkOrderStatuses.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.WorkOrderStatusId }).ToList();
        }
    }
}