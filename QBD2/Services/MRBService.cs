using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using static QBD2.Models.Enum;

namespace QBD2.Services
{
    public class MRBService
    {
        private readonly ApplicationDbContext _context;

        public MRBService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MRB>> Read(bool isShowCompletedItems)
        {
            return await _context.MRBs.AsNoTracking().Include(x => x.MRBDisposition).Where(x => x.IsComplete == isShowCompletedItems || isShowCompletedItems == true).ToListAsync();
        }

        public async Task<Models.ApiResponse> Create(Models.AddMRBModel model)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();
            try
            {
                MRB mrb = new MRB();
                mrb.IsComplete = false;
                mrb.MRBDispositionId = (int)EnumMRBDispositions.Review;
                mrb.Description = model.Description;
                mrb.BarCode = model.BarCode;
                _context.MRBs.Add(mrb);
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

        public async Task<List<Models.DropDownBind>> MRBDispositionDropDownData()
        {
            return await _context.MRBDispositions.Select(p => new Models.DropDownBind { DropText = p.Name, DropValue = p.MRBDispositionId }).ToListAsync();
        }

        public async Task<Models.ApiResponse> EditStatus(Models.EditMRBStatusModel model)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();
            try
            {
                var mrb = _context.MRBs.Where(d => d.MRBId == model.MRBId).FirstOrDefault();
                mrb.MRBDispositionId = model.MRBDispositionId.Value;
                if (mrb.MRBDispositionId == (int)EnumMRBDispositions.Review || mrb.MRBDispositionId == (int)EnumMRBDispositions.EngEval)
                {
                    mrb.IsComplete = false;
                }
                else
                {
                    mrb.IsComplete = true;
                }
                _context.Entry(mrb).State = EntityState.Modified;
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
    }
}
