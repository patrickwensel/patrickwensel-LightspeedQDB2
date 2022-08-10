using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class BuildStationService
    {
        private readonly ApplicationDbContext _context;

        public BuildStationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(BuildStation itemToInsert)
        {
            _context.BuildStations.Add(itemToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BuildStation>> Read()
        {
            return await _context.BuildStations.ToListAsync();
        }

        public async Task Update(BuildStation itemToUpdate)
        {
            var buildStation = _context.BuildStations.Where(d => d.BuildStationId == itemToUpdate.BuildStationId).FirstOrDefault();
            buildStation.Name = itemToUpdate.Name;
            _context.Entry(buildStation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(BuildStation itemToDelete)
        {
            var buildStation = _context.BuildStations.Where(d => d.BuildStationId == itemToDelete.BuildStationId).FirstOrDefault();
            _context.BuildStations.Remove(buildStation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.DropDownBind>> DropDownData()
        {
            return await _context.BuildStations.OrderBy(x => x.Name).Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.BuildStationId }).ToListAsync();
        }
    }
}