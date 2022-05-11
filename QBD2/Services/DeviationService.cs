using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class DeviationService
    {
        private readonly ApplicationDbContext _context;

        public DeviationService(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<List<PartDeviation>> GetPartDeviationByDeviationId(int deviationId)
        {
            return await _context.PartDeviations.Include(p => p.Part).Where(x=>x.DeviationId == deviationId).ToListAsync();
        }

        public async Task<List<Deviation>> ReadDeviations()
        {
            var x = await _context.Deviations.ToListAsync();
            return x;
        }

        public async Task<List<PartDeviation>> ReadPartDeviation()
        {
            return await _context.PartDeviations.ToListAsync();
        }

        public async Task<Deviation> CreateDeviationAsync(Deviation itemToInsert)
        {
            _context.Deviations.Add(itemToInsert);
            await _context.SaveChangesAsync();
            return itemToInsert;
        }

        public Deviation CreateDeviation(Deviation itemToInsert)
        {
            _context.Deviations.Add(itemToInsert);
            _context.SaveChanges();
            return itemToInsert;
        }

        public static async Task CreatePartDeviation(PartDeviation itemToInsert)
        {

        }

        public static async Task UpdatePartDeviation(PartDeviation itemToUpdate)
        {

        }

        public static async Task DeletePartDeviation(PartDeviation itemToDelete)
        {

        }
    }
}
