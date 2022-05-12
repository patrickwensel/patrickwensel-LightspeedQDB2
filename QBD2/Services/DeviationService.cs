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
            var x = await _context.Deviations.Include(a=>a.MasterPart).ToListAsync();
            return x;
        }

        public async Task<List<PartDeviation>> ReadPartDeviation()
        {
            return await _context.PartDeviations.ToListAsync();
        }

        public async Task<Deviation> CreateDeviationAsync(Deviation itemToInsert)
        {
            if (itemToInsert.DeviationId > 0)
            {
                var objDeviation = _context.Deviations.Where(d => d.DeviationId == itemToInsert.DeviationId).FirstOrDefault();
                objDeviation.MasterPartId = itemToInsert.MasterPartId;
                objDeviation.Originator = itemToInsert.Originator;
                objDeviation.ReasonforManufacturingDeviation = itemToInsert.ReasonforManufacturingDeviation;
                objDeviation.ECORequired = itemToInsert.ECORequired;
                objDeviation.ECONumber = itemToInsert.ECONumber;
                objDeviation.CommentCorrectiveAction = itemToInsert.CommentCorrectiveAction;
                objDeviation.VendorSVPART = itemToInsert.VendorSVPART;
                objDeviation.VendorSEVE = itemToInsert.VendorSEVE;
                objDeviation.Vendor2 = itemToInsert.Vendor2;
                objDeviation.VendorWIP = itemToInsert.VendorWIP;
                objDeviation.Vendor3FGI = itemToInsert.Vendor3FGI;
                objDeviation.LSASVPART = itemToInsert.LSASVPART;
                objDeviation.LSASEVE = itemToInsert.LSASEVE;
                objDeviation.LSA2 = itemToInsert.LSA2;
                objDeviation.LSAWIP = itemToInsert.LSAWIP;
                objDeviation.LSAFGI = itemToInsert.LSAFGI;
                _context.Entry(objDeviation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                itemToInsert.DateCreated = DateTime.UtcNow;
                _context.Deviations.Add(itemToInsert);
                await _context.SaveChangesAsync();
            }

            if (itemToInsert.DeviationId > 0 && itemToInsert.PartDeviations != null && itemToInsert.PartDeviations.Count() > 0)
            {
                foreach (var item in itemToInsert.PartDeviations)
                {
                    if(!_context.PartDeviations.Any(x=>x.PartId == item.PartId && x.DeviationId == itemToInsert.DeviationId))
                    {
                        PartDeviation partDeviation = new PartDeviation
                        {
                            DeviationId = itemToInsert.DeviationId,
                            PartId = item.PartId
                        };
                        _context.PartDeviations.Add(partDeviation);
                        await _context.SaveChangesAsync();
                    }
                }
            }

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
