using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ScarCarService
    {
        private readonly ApplicationDbContext _context;

        public ScarCarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ScarCar>> Read()
        {
            var scarCarList = await _context.ScarCar
                             .Include(p => p.ScarCarImpact)
                             .Include(p => p.ScarCarResolution)
                             .Include(p => p.ScarCarStatus)
                             .Include(p => p.ScarCarPriority)
                             .Include(p => p.ScarCarCategory)
                             .Include(p => p.ScarCarProject)
                             .Include(p => p.ScarCarNotes)
                             .Include(p => p.ScarCarAttachments)
                             .OrderByDescending(p => p.OpenDate)
                             .ToListAsync();

                             return scarCarList;
        }

        public async Task<List<Models.ScarCarModel>> ReadScarCar()
        {
            List<Models.ScarCarModel> ScarCarDetailModelList = new List<Models.ScarCarModel>();
            ScarCarDetailModelList = await (from s in _context.ScarCar
                                         join sci in _context.ScarCarImpacts on s.ScarCarImpactId equals sci.ScarCarImpactId
                                         join scr in _context.ScarCarResolutions on s.ScarCarResolutionId equals scr.ScarCarResolutionId
                                         join scs in _context.ScarCarStatuses on s.ScarCarStatusId equals scs.ScarCarStatusId
                                         join scp in _context.ScarCarPriorities on s.ScarCarPriorityId equals scp.ScarCarPriorityId
                                         join scc in _context.ScarCarCategories on s.ScarCarCategoryId equals scc.ScarCarCategoryId
                                         join scps in _context.ScarCarProjects on s.ScarCarProjectId equals scps.ScarCarProjectId
                                         select new Models.ScarCarModel
                                         {
                                             ScarCarId = s.ScarCarId,
                                             Title = s.Title,
                                             Description = s.Description,
                                             Containment = s.Containment,
                                             RootCause = s.RootCause,
                                             OpenDate = s.OpenDate,
                                             DueDate = s.DueDate,
                                             ScarCarImpactId = s.ScarCarImpactId,
                                             ScarCarImpact = sci,
                                             ScarCarResolutionId = s.ScarCarResolutionId,
                                             ScarCarResolution = scr,
                                             ScarCarStatusId = s.ScarCarStatusId,
                                             ScarCarStatus = scs,
                                             ScarCarPriorityId = s.ScarCarPriorityId,
                                             ScarCarPriority = scp,
                                             ScarCarCategoryId = s.ScarCarCategoryId,
                                             ScarCarCategory = scc,
                                             ScarCarProjectId = s.ScarCarProjectId,
                                             ScarCarProject = scps,
                                             ApplicationUserId = s.ApplicationUserId,
                                             ScarCarNotes = (from n in _context.ScarCarNotes
                                                             join sc in _context.ScarCar
                                                             on n.ScarCarId equals sc.ScarCarId
                                                             where sc.ScarCarId == s.ScarCarId
                                                             select new Models.ScarCarNote
                                                             {
                                                                 ScarCarNoteId = n.ScarCarProjectId,
                                                                 Note = n.Note,
                                                                 AddedDate = n.AddedDate,
                                                                 ApplicationUserId = n.ApplicationUserId,
                                                                 ScarCarId = n.ScarCarId,
                                                                 ScarCar = sc
                                                             }).ToList()
                                         }).ToListAsync();

            return ScarCarDetailModelList;
        }

        public async Task<bool> Save(Models.AddEditScarCarModel addEditScarCarModel)
        {
            try
            {
                var objScarCar = new Entities.ScarCar();
                if (addEditScarCarModel.ScarCarId > 0)
                {
                    objScarCar = _context.ScarCar.Where(d => d.ScarCarId == addEditScarCarModel.ScarCarId).FirstOrDefault();
                    if (objScarCar != null)
                    {
                        objScarCar.Title = addEditScarCarModel.Title;
                        objScarCar.Description = addEditScarCarModel.Description;
                        objScarCar.Containment = addEditScarCarModel.Containment;
                        objScarCar.RootCause = addEditScarCarModel.RootCause;
                        objScarCar.OpenDate = addEditScarCarModel.OpenDate.Value;
                        objScarCar.DueDate = addEditScarCarModel.DueDate.Value;
                        objScarCar.ScarCarImpactId = addEditScarCarModel.ScarCarImpactId.Value;
                        objScarCar.ScarCarResolutionId = addEditScarCarModel.ScarCarResolutionId.Value;
                        objScarCar.ScarCarStatusId = addEditScarCarModel.ScarCarStatusId.Value;
                        objScarCar.ScarCarPriorityId = addEditScarCarModel.ScarCarPriorityId.Value;
                        objScarCar.ScarCarCategoryId = addEditScarCarModel.ScarCarCategoryId.Value;
                        objScarCar.ScarCarProjectId = addEditScarCarModel.ScarCarProjectId.Value;
                        objScarCar.ApplicationUserId = addEditScarCarModel.ApplicationUserId;
                        _context.Entry(objScarCar).State = EntityState.Modified;
                    }
                }
                else
                {
                    objScarCar = new Entities.ScarCar()
                    {
                        Title = addEditScarCarModel.Title,
                        Description = addEditScarCarModel.Description,
                        Containment = addEditScarCarModel.Containment,
                        RootCause = addEditScarCarModel.RootCause,
                        OpenDate = addEditScarCarModel.OpenDate.Value,
                        DueDate = addEditScarCarModel.DueDate.Value,
                        ScarCarImpactId = addEditScarCarModel.ScarCarImpactId.Value,
                        ScarCarResolutionId = addEditScarCarModel.ScarCarResolutionId.Value,
                        ScarCarStatusId = addEditScarCarModel.ScarCarStatusId.Value,
                        ScarCarPriorityId = addEditScarCarModel.ScarCarPriorityId.Value,
                        ScarCarCategoryId = addEditScarCarModel.ScarCarCategoryId.Value,
                        ScarCarProjectId = addEditScarCarModel.ScarCarProjectId.Value,
                        ApplicationUserId = addEditScarCarModel.ApplicationUserId
                    };
                    _context.ScarCar.Add(objScarCar);
                }

                await _context.SaveChangesAsync();

                if (objScarCar.ScarCarId > 0)
                {
                    var scarCarNotesList = _context.ScarCarNotes.Where(d => d.ScarCarId == objScarCar.ScarCarId).ToList();
                    if (scarCarNotesList.Count > 0)
                    {
                        _context.ScarCarNotes.RemoveRange(scarCarNotesList);
                        await _context.SaveChangesAsync();
                    }

                    List<Entities.ScarCarNote> objList = new List<ScarCarNote>();
                    if (addEditScarCarModel.ScarCarNoteList != null)
                    {
                        foreach (var item in addEditScarCarModel.ScarCarNoteList)
                        {
                            objList.Add(new ScarCarNote
                            {
                                Note = item.Note,
                                AddedDate = item.AddedDate,
                                ApplicationUserId = item.ApplicationUserId,
                                ScarCarId = objScarCar.ScarCarId
                            });
                        }
                        _context.ScarCarNotes.AddRange(objList);
                        await _context.SaveChangesAsync();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task Delete(Models.ScarCarModel itemToDelete)
        {
            var scarCar = _context.ScarCar.Where(d => d.ScarCarId == itemToDelete.ScarCarId).FirstOrDefault();
            if (scarCar != null)
            {
                var scarNotes = _context.ScarCarNotes.Where(x => x.ScarCarId == scarCar.ScarCarId).ToList();
                if (scarNotes != null && scarNotes.Count() > 0)
                {
                    _context.ScarCarNotes.RemoveRange(scarNotes);
                    await _context.SaveChangesAsync();
                }

                var scarCarAttachments = _context.ScarCarAttachments.Where(x => x.ScarCarId == scarCar.ScarCarId).ToList();
                if (scarCarAttachments != null && scarCarAttachments.Count() > 0)
                {
                    _context.ScarCarAttachments.RemoveRange(scarCarAttachments);
                    await _context.SaveChangesAsync();
                }

                _context.ScarCar.Remove(scarCar);
                await _context.SaveChangesAsync();
            }
        }
    }
}