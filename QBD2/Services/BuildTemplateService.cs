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

        public async Task<List<Models.BuildTemplateModel>> ReadBuildTemplate()
        {
            List<Models.BuildTemplateModel> buildTemplateModelList = new List<Models.BuildTemplateModel>();
            buildTemplateModelList = await (from bt in _context.BuildTemplates
                                                join mp in _context.MasterParts on bt.MasterPartId equals mp.MasterPartId
                                                select new Models.BuildTemplateModel
                                                {
                                                    BuildTemplateId = bt.BuildTemplateId,
                                                    Name = bt.Name,
                                                    MasterPartId = bt.MasterPartId,
                                                    MasterPart = mp,
                                                    BuildTemplatePartList = _context.BuildTemplateParts.Include(a => a.BuildStation).Include(b=>b.BuildTemplate).Include(c=>c.MasterPart).Where(x => x.BuildTemplateId == bt.BuildTemplateId).ToList()
                                                }).ToListAsync();
            return buildTemplateModelList;
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

        public async Task<Models.ApiResponse> Save(Models.AddEditBuildTemplateModel addEditBuildTemplateModel)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();

            try
            {
                var objBuildTemplate = new Entities.BuildTemplate();
                if (addEditBuildTemplateModel.BuildTemplateId > 0)
                {
                    //objBuildTemplatePart = _context.BuildTemplateParts.Where(d => d.BuildTemplateId == addEditBuildTemplatePartModel.BuildTemplateId).FirstOrDefault();
                    //if (objBuildTemplatePart != null)
                    //{
                    //    objBuildTemplatePart.BuildTemplateId = addEditBuildTemplatePartModel.BuildTemplateId.Value;
                    //    objBuildTemplatePart.MasterPartId = addEditBuildTemplatePartModel.MasterPartId.Value;
                    //    objBuildTemplatePart.BuildStationId = addEditBuildTemplatePartModel.BuildStationId.Value;
                    //    objBuildTemplatePart.SerialNumberRequired = addEditBuildTemplatePartModel.SerialNumberRequired;
                    //    _context.Entry(objBuildTemplatePart).State = EntityState.Modified;
                    //}
                }
                else
                {
                    var part = await _context.Parts.Where(x => x.MasterPartId == addEditBuildTemplateModel.MasterPartId.Value && x.ParentPartId == null).FirstOrDefaultAsync();
                    if (part != null)
                    {
                        var childParts = await _context.Parts.Where(x => x.ParentPartId == part.PartId).ToListAsync();
                        objBuildTemplate = new Entities.BuildTemplate()
                        {
                            Name = addEditBuildTemplateModel.Name,
                            MasterPartId = part.MasterPartId
                        };

                        _context.BuildTemplates.Add(objBuildTemplate);
                        await _context.SaveChangesAsync();

                        if (objBuildTemplate != null && objBuildTemplate.BuildTemplateId > 0)
                        {
                            foreach (var item in childParts)
                            {
                                var objBuildTemplatePart = new Entities.BuildTemplatePart();
                                objBuildTemplatePart.BuildTemplateId = objBuildTemplate.BuildTemplateId;
                                objBuildTemplatePart.MasterPartId = item.MasterPartId;
                                objBuildTemplatePart.BuildStationId = addEditBuildTemplateModel.BuildStationId.Value;
                                objBuildTemplatePart.SerialNumberRequired = addEditBuildTemplateModel.SerialNumberRequired;

                                _context.BuildTemplateParts.Add(objBuildTemplatePart);
                                await _context.SaveChangesAsync();
                            }
                        }

                        await _context.SaveChangesAsync();

                        apiResponse.Success = true;
                        apiResponse.Message = "Record Saved Successfully.";
                        return apiResponse;
                    }
                    else
                    {
                        apiResponse.Success = false;
                        apiResponse.Message = "Parent Part detail not found.";
                        return apiResponse;
                    }

                }

                apiResponse.Success = false;
                apiResponse.Message = "Please enter valid data.";
                return apiResponse;
            }
            catch
            {
                apiResponse.Success = false;
                apiResponse.Message = "Record Not Saved ! Something Worng.";
                return apiResponse;
            }
        }
    }
}