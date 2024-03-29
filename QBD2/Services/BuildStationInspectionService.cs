﻿using Microsoft.EntityFrameworkCore;
using QBD2.Data;

namespace QBD2.Services
{
    public class BuildStationInspectionService
    {
        private readonly ApplicationDbContext _context;

        public BuildStationInspectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.BuildStationInspectionModel> GetInspectionByWorkOrderIdAndPartId(int workOrderId, int partId, int buildStationId)
        {
            var inspectionModel = new Models.BuildStationInspectionModel();

            var inspection = await _context.BuildStationInspections.FirstOrDefaultAsync(x => x.WorkOrderId == workOrderId && x.PartId == partId && x.BuildStationId == buildStationId);
            if (inspection != null)
                inspectionModel = await GetBuildStationInspectionsById(inspection.BuildStationInspectionId);

            if (inspectionModel == null)
                inspectionModel = new Models.BuildStationInspectionModel();

            //if (inspectionModel.BuildStationInspectionFailedList != null && inspectionModel.BuildStationInspectionFailedList.Count > 0)
            //{
            //    inspectionModel.BuildStationInspectionFailed = inspectionModel.BuildStationInspectionFailedList[0];
            //}
            //else
            //{
            inspectionModel.BuildStationInspectionFailed = new Models.BuildStationInspectionFailed();
            //}

            return inspectionModel;
        }

        public async Task<Models.BuildStationInspectionModel> GetBuildStationInspectionsById(int inspectionId)
        {
            var inspection = new Models.BuildStationInspectionModel();
            try
            {
                inspection = await (from ps in _context.Parts
                                    join i in _context.BuildStationInspections
                                    on ps.PartId equals i.PartId
                                    where i.BuildStationInspectionId == inspectionId
                                    select new Models.BuildStationInspectionModel
                                    {
                                        PartId = i.PartId,
                                        GeneralComments = i.GeneralComments,
                                        Pass = i.Pass,
                                        WorkOrderId = i.WorkOrderId,
                                        BuildStationInspectionId = i.BuildStationInspectionId,
                                        BuildStationId = i.BuildStationId,
                                        IsCompleteBuildStation = i.IsCompleteBuildStation
                                    }).FirstOrDefaultAsync();

                if (inspection != null)
                {
                    inspection.BuildStationInspectionFailedList = await (from f in _context.BuildStationInspectionFailures
                                                                         join i in _context.BuildStationInspections on f.BuildStationInspectionId equals i.BuildStationInspectionId

                                                                         join t in _context.FailureTypes on new { FailureTypeId = f.FailureTypeId }
                                                             equals new { FailureTypeId = (int?)t.FailureTypeId } into t_join
                                                                         from t in t_join.DefaultIfEmpty()

                                                                         join p in _context.FailureTypePrimaries on new { FailureTypePrimaryId = t.FailureTypePrimaryId }
                                                                         equals new { FailureTypePrimaryId = p.FailureTypePrimaryId } into p_join
                                                                         from p in p_join.DefaultIfEmpty()


                                                                         where f.BuildStationInspectionId == inspection.BuildStationInspectionId
                                                                         select new Models.BuildStationInspectionFailed
                                                                         {
                                                                             BuildStationInspectionFailureId = f.BuildStationInspectionFailureId,
                                                                             FailureTypeId = f.FailureTypeId,
                                                                             Comment = f.Comment,
                                                                             FailureName = t.Name,
                                                                             FailurePrimaryName = p.Name,
                                                                             FailurePrimaryTypeId = p.FailureTypePrimaryId
                                                                         }).ToListAsync();
                }
            }
            catch (Exception e)
            {
            }
            return inspection;
        }

        public async Task<bool> SaveBuildStationInspection(Models.BuildStationInspectionModel inspection)
        {
            try
            {
                var buildStationInspectionCount = await _context.BuildStationInspections.CountAsync(x => x.WorkOrderId == inspection.WorkOrderId);
                if (buildStationInspectionCount == 0)
                {
                    var workOrder = await _context.WorkOrders.FirstOrDefaultAsync(x => x.WorkOrderId == inspection.WorkOrderId);
                    if (workOrder != null)
                    {
                        workOrder.WorkOrderStatusId = 2;//InProgress
                        _context.Entry(workOrder).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }

                Entities.BuildStationInspection objInspection = new Entities.BuildStationInspection();
                if (inspection.BuildStationInspectionId > 0)
                {
                    objInspection = await _context.BuildStationInspections.FirstOrDefaultAsync(x => x.BuildStationInspectionId == inspection.BuildStationInspectionId);
                }
                objInspection.Pass = inspection.Pass;
                objInspection.GeneralComments = inspection.GeneralComments;
                objInspection.PartId = inspection.PartId;
                objInspection.WorkOrderId = inspection.WorkOrderId;
                objInspection.BuildStationId = inspection.BuildStationId;
                objInspection.IsCompleteBuildStation = inspection.IsCompleteBuildStation;
                objInspection.UpdateDate = DateTime.Now;
                if (inspection.BuildStationInspectionId > 0)
                {
                    _context.Entry(objInspection).State = EntityState.Modified;
                }
                else
                {
                    _context.BuildStationInspections.Add(objInspection);
                    await _context.SaveChangesAsync();
                }

                inspection.BuildStationInspectionId = objInspection.BuildStationInspectionId;

                if (inspection.Pass)
                {
                    var buildStationInspectionFailures = await _context.BuildStationInspectionFailures.Where(x => x.BuildStationInspectionId == inspection.BuildStationInspectionId).ToListAsync();
                    if (buildStationInspectionFailures.Count > 0)
                    {
                        _context.BuildStationInspectionFailures.RemoveRange(buildStationInspectionFailures);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    var buildStationInspectionFailures = await _context.BuildStationInspectionFailures.Where(x => x.BuildStationInspectionId == inspection.BuildStationInspectionId).ToListAsync();
                    if (inspection.BuildStationInspectionFailedList != null && inspection.BuildStationInspectionFailedList.Count > 0)
                    {
                        foreach (var BuildInspectionFailed in inspection.BuildStationInspectionFailedList)
                        {
                            Entities.BuildStationInspectionFailure objInspectionFailure = new Entities.BuildStationInspectionFailure();
                            if (BuildInspectionFailed.BuildStationInspectionFailureId > 0)
                            {
                                objInspectionFailure = await _context.BuildStationInspectionFailures.FirstOrDefaultAsync(x => x.BuildStationInspectionFailureId == BuildInspectionFailed.BuildStationInspectionFailureId);
                            }

                            objInspectionFailure.Comment = BuildInspectionFailed.Comment;
                            objInspectionFailure.BuildStationInspectionId = inspection.BuildStationInspectionId;

                            objInspectionFailure.FailureTypeId = BuildInspectionFailed.FailureTypeId;
                            if (BuildInspectionFailed.BuildStationInspectionFailureId > 0)
                            {
                                _context.Entry(objInspectionFailure).State = EntityState.Modified;
                            }
                            else
                            {
                                _context.BuildStationInspectionFailures.Add(objInspectionFailure);
                            }
                            await _context.SaveChangesAsync();
                            BuildInspectionFailed.BuildStationInspectionFailureId = objInspectionFailure.BuildStationInspectionFailureId;
                        }

                        var deleteBuildStationInspectionFailures = buildStationInspectionFailures.Where(x => inspection.BuildStationInspectionFailedList.Any(y => y.BuildStationInspectionFailureId == x.BuildStationInspectionFailureId) == false).ToList();
                        if (deleteBuildStationInspectionFailures.Count > 0)
                        {
                            _context.BuildStationInspectionFailures.RemoveRange(deleteBuildStationInspectionFailures);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        _context.BuildStationInspectionFailures.RemoveRange(buildStationInspectionFailures);
                        await _context.SaveChangesAsync();
                    }
                }
                await _context.SaveChangesAsync();


                Entities.BuildStationInspectionHistory buildStationInspectionHistory = new Entities.BuildStationInspectionHistory();
                buildStationInspectionHistory.Pass = inspection.Pass;
                buildStationInspectionHistory.GeneralComments = inspection.GeneralComments;
                buildStationInspectionHistory.PartId = inspection.PartId;
                buildStationInspectionHistory.BuildStationId = inspection.BuildStationId;
                buildStationInspectionHistory.WorkOrderId = inspection.WorkOrderId;
                buildStationInspectionHistory.UpdateDate = DateTime.Now;
                buildStationInspectionHistory.IsCompleteBuildStation = inspection.IsCompleteBuildStation;
                _context.BuildStationInspectionHistories.Add(buildStationInspectionHistory);
                await _context.SaveChangesAsync();

                if (!inspection.Pass)
                {
                    if (inspection.BuildStationInspectionFailedList != null && inspection.BuildStationInspectionFailedList.Count > 0)
                    {
                        foreach (var BuildInspectionFailed in inspection.BuildStationInspectionFailedList)
                        {
                            Entities.BuildStationInspectionFailureHistory buildStationInspectionFailureHistory = new Entities.BuildStationInspectionFailureHistory();
                            buildStationInspectionFailureHistory.Comment = BuildInspectionFailed.Comment;
                            buildStationInspectionFailureHistory.BuildStationInspectionHistoryId = buildStationInspectionHistory.BuildStationInspectionHistoryId;
                            buildStationInspectionFailureHistory.FailureTypeId = BuildInspectionFailed.FailureTypeId;
                            _context.BuildStationInspectionFailureHistories.Add(buildStationInspectionFailureHistory);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<string> CompleteInspection(Models.BuildStationInspectionModel inspection)
        {
            string message = "Some error on complete inspection.";
            try
            {
                Entities.BuildStationInspection objInspection = new Entities.BuildStationInspection();

                if (inspection.BuildStationInspectionId > 0)
                {
                    objInspection = await _context.BuildStationInspections.FirstOrDefaultAsync(x => x.BuildStationInspectionId == inspection.BuildStationInspectionId);
                }

                if (objInspection.BuildStationInspectionId > 0)
                {
                    if (objInspection.Pass == true)
                    {
                        objInspection.IsCompleteBuildStation = true;
                        _context.Entry(objInspection).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return string.Empty;
                    }
                    else
                    {
                        return "station not passed.";
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                return message;
            }
        }
    }
}
