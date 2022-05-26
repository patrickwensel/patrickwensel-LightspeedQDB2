using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class GLCodeService
    {
        private readonly ApplicationDbContext _context;

        public GLCodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(GLCode itemToInsert)
        {
            _context.GLCodes.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GLCode>> Read()
        {
            return await _context.GLCodes.ToListAsync();
        }

        public async Task Update(GLCode itemToUpdate)
        {
            var glCode = _context.GLCodes.Where(d => d.GLCodeId == itemToUpdate.GLCodeId).FirstOrDefault();
            glCode.Name = itemToUpdate.Name;
            _context.Entry(glCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(GLCode itemToDelete)
        {
            var glCodes = _context.GLCodes.Where(d => d.GLCodeId == itemToDelete.GLCodeId).FirstOrDefault();
            _context.GLCodes.Remove(glCodes);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.GLCodes.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.GLCodeId }).ToList();
        }
    }
}