using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarCategoryService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ScarCarCategory itemToInsert)
        {
            _context.ScarCarCategories.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScarCarCategory>> Read()
        {
            return await _context.ScarCarCategories.ToListAsync();
        }

        public async Task Update(ScarCarCategory itemToUpdate)
        {
            var scarCarCategory = _context.ScarCarCategories.Where(d => d.ScarCarCategoryId == itemToUpdate.ScarCarCategoryId).FirstOrDefault();
            scarCarCategory.Name = itemToUpdate.Name;
            _context.Entry(scarCarCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ScarCarCategory itemToDelete)
        {
            var scarCarCategory = _context.ScarCarCategories.Where(d => d.ScarCarCategoryId == itemToDelete.ScarCarCategoryId).FirstOrDefault();
            _context.ScarCarCategories.Remove(scarCarCategory);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.ScarCarCategories.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.ScarCarCategoryId }).ToList();
        }
    }
}