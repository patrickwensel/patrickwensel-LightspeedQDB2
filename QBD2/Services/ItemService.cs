using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly Sage300Context _sage300Context;

        public ItemService(ApplicationDbContext context, Sage300Context sage300Context)
        {
            _context = context;
            _sage300Context = sage300Context;
        }

        public async Task<List<ItemModel>> Read()
        {
            var x =  await _sage300Context.Icitems.Select(i => new ItemModel
            {
                ItemId = i.Itemno,
                ItemNumber = i.Fmtitemno,
                Description = i.Desc
            }).ToListAsync();
            
            return x;

        }

        public async Task UpdateMasterParts()
        {
            List<Icitem> allItems = await _sage300Context.Icitems.ToListAsync();
            List<MasterPart> allMasterParts = await _context.MasterParts.ToListAsync();

            List<ItemModel> allItemsTrimmed = new List<ItemModel>();

            foreach (var item in allItems)
            {
                ItemModel itemModel = new ItemModel
                {
                    ItemId=item.Itemno.Trim(),
                    ItemNumber=item.Fmtitemno.Trim(),
                    Description=item.Desc.Trim()
                };
                allItemsTrimmed.Add(itemModel);
            }

            IEnumerable<ItemModel>? itemsNotInMasterPart = allItemsTrimmed.Where(x => !allMasterParts.Select(i => i.Itemno).Contains(x.ItemId));

            foreach(var item in itemsNotInMasterPart)
            {
                var part = new MasterPart
                {
                    PartNumber = item.ItemNumber,
                    Itemno = item.ItemId,
                    Description = item.Description,

                };
                _context.MasterParts.Add(part);
                _context.SaveChanges();
            }

        }
    }
}
