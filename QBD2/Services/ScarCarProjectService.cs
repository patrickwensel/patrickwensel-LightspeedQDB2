using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarProjectService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ScarCarProject itemToInsert)
        {
            _context.ScarCarProjects.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ScarCarProject>> Read()
        {
            return await _context.ScarCarProjects.ToListAsync();
        }

        public async Task Update(ScarCarProject itemToUpdate)
        {
            var scarCarProject = _context.ScarCarProjects.Where(d => d.ScarCarProjectId == itemToUpdate.ScarCarProjectId).FirstOrDefault();
            scarCarProject.Name = itemToUpdate.Name;
            _context.Entry(scarCarProject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ScarCarProject itemToDelete)
        {
            var scarCarProject = _context.ScarCarProjects.Where(d => d.ScarCarProjectId == itemToDelete.ScarCarProjectId).FirstOrDefault();
            _context.ScarCarProjects.Remove(scarCarProject);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.ScarCarProjects.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.ScarCarProjectId }).ToList();
        }
    }
}