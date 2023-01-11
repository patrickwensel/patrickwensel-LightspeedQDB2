using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class AlertService
    {
        private readonly ApplicationDbContext _context;

        public AlertService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PartAlert>> GetPartAlertByAlertId(int alertId)
        {
            return await _context.PartAlerts.Include(p => p.Part).Where(x => x.AlertId == alertId).ToListAsync();
        }

        public async Task<List<Alert>> ReadAlerts()
        {
            var x = await _context.Alerts.Include(a => a.MasterPart).Include(x => x.PartAlerts).ThenInclude(b => b.Part).ToListAsync();
            return x;
        }

        public async Task<List<PartAlert>> ReadPartAlert()
        {
            return await _context.PartAlerts.ToListAsync();
        }

        public async Task<Alert> CreateAlertAsync(Alert itemToInsert)
        {
            if (itemToInsert.AlertId > 0)
            {
                var objAlert = _context.Alerts.Where(d => d.AlertId == itemToInsert.AlertId).FirstOrDefault();
                objAlert.MasterPartId = itemToInsert.MasterPartId;
                objAlert.Title = itemToInsert.Title;
                objAlert.ExpirationDate = itemToInsert.ExpirationDate;
                objAlert.ReasonforManufacturingDeviation = itemToInsert.ReasonforManufacturingDeviation;
                _context.Entry(objAlert).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                itemToInsert.DateCreated = DateTime.UtcNow;
                _context.Alerts.Add(itemToInsert);
                await _context.SaveChangesAsync();
            }

            if (itemToInsert.AlertId > 0)
            {
                var partAlerts = await _context.PartAlerts.Where(x => x.AlertId == itemToInsert.AlertId).ToListAsync();
                if (partAlerts.Any())
                {
                    var removeDatas = partAlerts.Where(x => itemToInsert.PartAlerts == null || !itemToInsert.PartAlerts.Any(y => y.PartId == x.PartId)).ToList();
                    _context.PartAlerts.RemoveRange(removeDatas);
                }

                if (itemToInsert.PartAlerts != null && itemToInsert.PartAlerts.Any())
                {
                    var insertDatas = itemToInsert.PartAlerts.Where(x => !partAlerts.Any(y => y.PartId == x.PartId)).ToList();
                    if (insertDatas.Any())
                    {
                        List<PartAlert> insertDataList = new List<PartAlert>();
                        foreach (var insertData in insertDatas)
                        {
                            insertDataList.Add(new PartAlert() { AlertId = itemToInsert.AlertId, PartId = insertData.PartId });
                        }
                        _context.PartAlerts.AddRange(insertDataList);
                    }
                }

                await _context.SaveChangesAsync();
            }

            return itemToInsert;
        }

        public Alert CreateAlert(Alert itemToInsert)
        {
            _context.Alerts.Add(itemToInsert);
            _context.SaveChanges();
            return itemToInsert;
        }

        public static async Task CreatePartAlert(PartAlert itemToInsert)
        {

        }

        public static async Task UpdatePartAlert(PartAlert itemToUpdate)
        {

        }

        public static async Task DeletePartAlert(PartAlert itemToDelete)
        {

        }
    }
}