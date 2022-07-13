using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class MasterPartService
    {
        private readonly ApplicationDbContext _context;
        private readonly Sage300Context _sage300Context;

        public MasterPartService(ApplicationDbContext context, Sage300Context sage300Context)
        {
            _context = context;
            _sage300Context = sage300Context;
        }

        public static async Task Create(MasterPart itemToInsert)
        {

        }

        public async Task<List<MasterPart>> Read()
        {
            return await _context.MasterParts.ToListAsync();
        }

        public static async Task Update(MasterPart itemToUpdate)
        {

        }

        public static async Task Delete(MasterPart itemToDelete)
        {

        }

        public List<MasterPart> GetAllMasterParts()
        {
            var x = _context.MasterParts.ToList();
            return x;
        }

        public List<Models.DropDownBind> DropDownData()
        {
            return _context.MasterParts.Select(p => new Models.DropDownBind { DropText = p.PartNumber, DropValue = p.MasterPartId }).ToList();
        }

        public List<Models.DropDownBind> GetBuildTemplateMasterPartDropDownData()
        {
            return (from mt in _context.MasterParts
                    join bt in _context.BuildTemplates on mt.MasterPartId equals bt.MasterPartId
                    select new Models.DropDownBind
                    {
                        DropText =  bt.Name + " " + mt.PartNumber,
                        DropValue = bt.BuildTemplateId
                    }).Distinct().ToList();
        }
    }
}
