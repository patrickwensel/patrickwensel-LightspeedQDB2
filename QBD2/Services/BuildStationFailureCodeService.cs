using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
namespace QBD2.Services
{
    public class BuildStationFailureCodeService
    {
        private readonly ApplicationDbContext _context;

        public BuildStationFailureCodeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(BuildStationFailureCode itemToInsert)
        {
            _context.BuildStationFailureCodes.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BuildStationFailureCode>> Read(int buildStationId)
        {
            return await _context.BuildStationFailureCodes.Where(x => x.BuildStationId == buildStationId).ToListAsync();
        }

        public async Task Update(BuildStationFailureCode itemToUpdate)
        {
            var buildStationFailureCode = _context.BuildStationFailureCodes.Where(d => d.BuildStationFailureCodeId == itemToUpdate.BuildStationFailureCodeId).FirstOrDefault();
            buildStationFailureCode.Name = itemToUpdate.Name;
            _context.Entry(buildStationFailureCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(BuildStationFailureCode itemToDelete)
        {
            var buildStationFailureCode = _context.BuildStationFailureCodes.Where(d => d.BuildStationFailureCodeId == itemToDelete.BuildStationFailureCodeId).FirstOrDefault();
            _context.BuildStationFailureCodes.Remove(buildStationFailureCode);
            await _context.SaveChangesAsync();
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.BuildStationFailureCodes.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.BuildStationFailureCodeId }).ToList();
        }
    }
}
