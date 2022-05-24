using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class FailureCodeService
    {
        private readonly ApplicationDbContext _context;

        public FailureCodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(FailureCode itemToInsert)
        {
            _context.FailureCodes.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FailureCode>> Read()
        {
            return await _context.FailureCodes.ToListAsync();
        }

        public async Task Update(FailureCode itemToUpdate)
        {
            var failureCodes = _context.FailureCodes.Where(d => d.FailureCodeId == itemToUpdate.FailureCodeId).FirstOrDefault();
            failureCodes.Name = itemToUpdate.Name;
            _context.Entry(failureCodes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(FailureCode itemToDelete)
        {
            var failureCodes = _context.FailureCodes.Where(d => d.FailureCodeId == itemToDelete.FailureCodeId).FirstOrDefault();
            _context.FailureCodes.Remove(failureCodes);
            await _context.SaveChangesAsync();
        }
    }
}