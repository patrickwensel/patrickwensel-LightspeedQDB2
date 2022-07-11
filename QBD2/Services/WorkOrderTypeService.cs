using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class WorkOrderTypeService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(WorkOrderType itemToInsert)
        {
            _context.WorkOrderTypes.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WorkOrderType>> Read()
        {
            return await _context.WorkOrderTypes.ToListAsync();
        }

        public async Task Update(WorkOrderType itemToUpdate)
        {
            var workOrderTypes = _context.WorkOrderTypes.Where(d => d.WorkOrderTypeId == itemToUpdate.WorkOrderTypeId).FirstOrDefault();
            workOrderTypes.Name = itemToUpdate.Name;
            _context.Entry(workOrderTypes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(WorkOrderType itemToDelete)
        {
            var workOrderTypes = _context.WorkOrderTypes.Where(d => d.WorkOrderTypeId == itemToDelete.WorkOrderTypeId).FirstOrDefault();
            _context.WorkOrderTypes.Remove(workOrderTypes);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.WorkOrderTypes.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.WorkOrderTypeId }).ToList();
        }
    }
}