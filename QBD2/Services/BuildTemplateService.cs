using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class BuildTemplateService
    {
        private readonly ApplicationDbContext _context;

        public BuildTemplateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(BuildTemplate itemToInsert)
        {
            _context.BuildTemplates.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BuildTemplate>> Read()
        {
            return await _context.BuildTemplates.Include(a=>a.MasterPart).ToListAsync();
        }

        public async Task Update(BuildTemplate itemToUpdate)
        {
            if (itemToUpdate.BuildTemplateId > 0 && itemToUpdate.MasterPartId > 0)
            {
                var buildTemplate = _context.BuildTemplates.Where(d => d.BuildTemplateId == itemToUpdate.BuildTemplateId).FirstOrDefault();
                buildTemplate.Name = itemToUpdate.Name;
                buildTemplate.MasterPartId = itemToUpdate.MasterPartId;
                _context.Entry(buildTemplate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(BuildTemplate itemToDelete)
        {
            var buildTemplate = _context.BuildTemplates.Where(d => d.BuildTemplateId == itemToDelete.BuildTemplateId).FirstOrDefault();
            _context.BuildTemplates.Remove(buildTemplate);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.BuildTemplates.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.BuildTemplateId }).ToList();
        }
    }
}