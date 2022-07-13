using Microsoft.EntityFrameworkCore;
using QBD2.Data;

namespace QBD2.Services
{
    public class BuildTemplatePartService
    {
        private readonly ApplicationDbContext _context;

        public BuildTemplatePartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.BuildTemplatePartModel>> ReadBuildTemplatePart()
        {
            List<Models.BuildTemplatePartModel> buildTemplatePartModelList = new List<Models.BuildTemplatePartModel>();
            buildTemplatePartModelList = await (from btp in _context.BuildTemplateParts
                                        join bs in _context.BuildStations on btp.BuildStationId equals bs.BuildStationId
                                        join bt in _context.BuildTemplates on btp.BuildTemplateId equals bt.BuildTemplateId
                                        join mp in _context.MasterParts on btp.MasterPartId equals mp.MasterPartId
                                        select new Models.BuildTemplatePartModel
                                        {
                                            BuildTemplatePartId = btp.BuildTemplatePartId,
                                            BuildStationId = btp.BuildStationId,
                                            BuildStation = bs,
                                            BuildTemplateId = btp.BuildTemplateId,
                                            BuildTemplate = bt,
                                            MasterPartId = btp.MasterPartId,
                                            MasterPart = mp,
                                            SerialNumberRequired = btp.SerialNumberRequired
                                        }).ToListAsync();
            return buildTemplatePartModelList;
        }

        public async Task<Models.ApiResponse> Save(Models.AddEditBuildTemplatePartModel addEditBuildTemplatePartModel)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();

            try
            {
                if (CheckDuplicate(addEditBuildTemplatePartModel.BuildTemplatePartId, addEditBuildTemplatePartModel.BuildTemplateId.Value, addEditBuildTemplatePartModel.MasterPartId.Value, addEditBuildTemplatePartModel.BuildStationId.Value))
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Duplicate record.";
                    return apiResponse;
                }

                var objBuildTemplatePart = new Entities.BuildTemplatePart();
                if (addEditBuildTemplatePartModel.BuildTemplatePartId > 0)
                {
                    objBuildTemplatePart = _context.BuildTemplateParts.Where(d => d.BuildTemplateId == addEditBuildTemplatePartModel.BuildTemplateId).FirstOrDefault();
                    if (objBuildTemplatePart != null)
                    {
                        objBuildTemplatePart.BuildTemplateId = addEditBuildTemplatePartModel.BuildTemplateId.Value;
                        objBuildTemplatePart.MasterPartId = addEditBuildTemplatePartModel.MasterPartId.Value;
                        objBuildTemplatePart.BuildStationId = addEditBuildTemplatePartModel.BuildStationId.Value;
                        objBuildTemplatePart.SerialNumberRequired = addEditBuildTemplatePartModel.SerialNumberRequired;
                        _context.Entry(objBuildTemplatePart).State = EntityState.Modified;
                    }
                }
                else
                {
                    objBuildTemplatePart = new Entities.BuildTemplatePart()
                    {
                        BuildTemplateId = addEditBuildTemplatePartModel.BuildTemplateId.Value,
                        MasterPartId = addEditBuildTemplatePartModel.MasterPartId.Value,
                        BuildStationId = addEditBuildTemplatePartModel.BuildStationId.Value,
                        SerialNumberRequired = addEditBuildTemplatePartModel.SerialNumberRequired
                };
                    _context.BuildTemplateParts.Add(objBuildTemplatePart);
                }

                await _context.SaveChangesAsync();

                apiResponse.Success = true;
                apiResponse.Message = "Record Saved Successfully.";
                return apiResponse;
            }
            catch
            {
                apiResponse.Success = false;
                apiResponse.Message = "Record Not Saved ! Something Worng.";
                return apiResponse;
            }
        }

        public async Task Delete(Models.BuildTemplatePartModel itemToDelete)
        {
            var buildTemplatePart = _context.BuildTemplateParts.Where(d => d.BuildTemplatePartId == itemToDelete.BuildTemplatePartId).FirstOrDefault();
            if (buildTemplatePart != null)
            {
                _context.BuildTemplateParts.Remove(buildTemplatePart);
                await _context.SaveChangesAsync();
            }
        }

        public bool CheckDuplicate(int? BuildTemplatePartId, int BuildTemplateId, int MasterPartId, int BuildStationId)
        {
            var buildTemplatePart = false;
            if (BuildTemplatePartId > 0)
                buildTemplatePart = _context.BuildTemplateParts.Any(x => x.BuildTemplateId == BuildTemplateId && x.MasterPartId == MasterPartId && x.BuildStationId == BuildStationId && x.BuildTemplatePartId != BuildTemplatePartId);
            else
                buildTemplatePart = _context.BuildTemplateParts.Any(x => x.BuildTemplateId == BuildTemplateId && x.MasterPartId == MasterPartId && x.BuildStationId == BuildStationId);

            return buildTemplatePart;
        }
    }
}