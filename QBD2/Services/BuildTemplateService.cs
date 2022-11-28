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

        public async Task<List<Models.BuildTemplateModel>> Read()
        {
            List<Models.BuildTemplateModel> buildTemplateModelList = new List<Models.BuildTemplateModel>();
            buildTemplateModelList = await (from bt in _context.BuildTemplates
                                            join mp in _context.MasterParts on bt.MasterPartId equals mp.MasterPartId
                                            //join b in _context.BuildStations on bt.BuildStationId equals b.BuildStationId
                                            select new Models.BuildTemplateModel
                                            {
                                                BuildTemplateId = bt.BuildTemplateId,
                                                Name = bt.Name,
                                                MasterPartId = bt.MasterPartId,
                                                MasterPart = mp,
                                               // BuildStation = b,
                                               // BuildStationId = bt.BuildStationId,
                                                BuildTemplateStationList = (from bts in _context.BuildTemplateStations
                                                                            join b3 in _context.BuildStations on bts.BuildStationId equals b3.BuildStationId
                                                                            where bts.BuildTemplateId == bt.BuildTemplateId
                                                                            select new BuildTemplateStation
                                                                            {
                                                                                BuildTemplateStationId = bts.BuildTemplateStationId,
                                                                                BuildTemplateId = bts.BuildTemplateId,
                                                                                BuildStationId = bts.BuildStationId,
                                                                                OrderNumber = bts.OrderNumber,
                                                                                BuildStation = b3,
                                                                            }).ToList(),
                                                BuildTemplatePartList = (from btp in _context.BuildTemplateParts
                                                                         join mp2 in _context.MasterParts on btp.MasterPartId equals mp2.MasterPartId
                                                                         join b2 in _context.BuildStations on btp.BuildStationId equals b2.BuildStationId
                                                                         where btp.BuildTemplateId == bt.BuildTemplateId
                                                                         select new BuildTemplatePart
                                                                         {
                                                                             BuildTemplatePartId = btp.BuildTemplatePartId,
                                                                             BuildTemplateId = btp.BuildTemplateId,
                                                                             MasterPartId = btp.MasterPartId,
                                                                             MasterPart = mp2,
                                                                             BuildStationId = btp.BuildStationId,
                                                                             BuildStation = b2,
                                                                             SerialNumberRequired = btp.SerialNumberRequired,
                                                                         }).ToList()
                                            }).ToListAsync();
            return buildTemplateModelList;
        }

        public async Task<Models.ApiResponse> Save(Models.AddEditBuildTemplateModel model)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();
            try
            {
                var buildTemplate = new Entities.BuildTemplate();
                buildTemplate.Name = model.Name;
                buildTemplate.MasterPartId = model.MasterPartId;
               // buildTemplate.BuildStationId = model.BuildStationId.Value;
                _context.BuildTemplates.Add(buildTemplate);
                await _context.SaveChangesAsync();

                if (model.AddEditBuildTemplateStationModels != null)
                {
                    foreach (var item in model.AddEditBuildTemplateStationModels)
                    {
                        var buildTemplateStation = new Entities.BuildTemplateStation();
                        buildTemplateStation.BuildTemplateId = buildTemplate.BuildTemplateId;
                        buildTemplateStation.BuildStationId = item.BuildStationId.Value;
                        buildTemplateStation.OrderNumber = item.OrderNumber.Value;
                        _context.BuildTemplateStations.Add(buildTemplateStation);
                    }

                    await _context.SaveChangesAsync();
                }

                if (model.AddEditBuildTemplatePartModels != null)
                {
                    foreach (var item in model.AddEditBuildTemplatePartModels)
                    {
                        var buildTemplatePart = new Entities.BuildTemplatePart();
                        buildTemplatePart.BuildTemplateId = buildTemplate.BuildTemplateId;
                        buildTemplatePart.MasterPartId = item.MasterPartId;
                        buildTemplatePart.BuildStationId = item.BuildStationId.Value;
                        buildTemplatePart.SerialNumberRequired = item.SerialNumberRequired;
                        _context.BuildTemplateParts.Add(buildTemplatePart);
                    }

                    await _context.SaveChangesAsync();
                }

                apiResponse.Success = true;
                apiResponse.Message = "Record Saved Successfully.";
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Record Not Saved ! Something Worng.";
                return apiResponse;
            }
        }
    }
}