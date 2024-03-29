﻿using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class WorkOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly BuildStationInspectionService _buildStationInspectionService;

        public WorkOrderService(ApplicationDbContext context, BuildStationInspectionService buildStationInspectionService)
        {
            _context = context;
            _buildStationInspectionService = buildStationInspectionService;
        }

        public async Task<List<Models.WorkOrderModel>> ReadWorkOrder()
        {
            List<Models.WorkOrderModel> workOrderModelList = new List<Models.WorkOrderModel>();
            workOrderModelList = await (from wo in _context.WorkOrders
                                        join wot in _context.WorkOrderTypes on wo.WorkOrderTypeId equals wot.WorkOrderTypeId
                                        join wos in _context.WorkOrderStatuses on wo.WorkOrderStatusId equals wos.WorkOrderStatusId
                                        join wop in _context.WorkOrderPriorities on wo.WorkOrderPriorityID equals wop.WorkOrderPriorityId
                                        join bt in _context.BuildTemplates on wo.BuildTemplateId equals bt.BuildTemplateId
                                        select new Models.WorkOrderModel
                                        {
                                            WorkOrderId = wo.WorkOrderId,
                                            CreateDate = wo.CreateDate,
                                            WorkOrderTypeId = wo.WorkOrderTypeId,
                                            WorkOrderType = wot,
                                            WorkOrderStatusId = wo.WorkOrderStatusId,
                                            WorkOrderStatus = wos,
                                            WorkOrderPriorityID = wo.WorkOrderPriorityID,
                                            WorkOrderPriority = wop,
                                            BuildTemplateId = wo.BuildTemplateId,
                                            BuildTemplate = bt,
                                            Quantity = wo.Quantity,
                                            PONumber = wo.PONumber,
                                            BuildTemplateMasterPartName = bt.Name + " " + bt.MasterPart.PartNumber,
                                        }).ToListAsync();

            foreach (var item in workOrderModelList)
            {
                var workOrderParts = await _context.WorkOrderParts.Where(x => x.WorkOrderId == item.WorkOrderId).Select(x => x.PartId).ToListAsync();
                var part = await (from p in _context.Parts
                                  join mp in _context.MasterParts
                                  on p.MasterPartId equals mp.MasterPartId
                                  where p.ParentPartId == null && workOrderParts.Contains(p.PartId)
                                  select new Parts
                                  {
                                      PartId = p.PartId,
                                      SerialNumber = p.SerialNumber,
                                      Description = mp.Description,
                                      MasterPartId = mp.MasterPartId,
                                      ParentPartId = p.ParentPartId,
                                      PartNumber = mp.PartNumber,
                                      PartStatusId = p.PartStatusId,
                                      PartStatus = p.PartStatus.Name,
                                      BuildStationId = p.BuildStationId,
                                      BuildStations = p.BuildStation.Name,
                                      SerialNumberRequired = p.SerialNumberRequired
                                  }).ToListAsync();

                foreach (Parts partItems in part)
                {
                    partItems.ChildParts = await (from p in _context.Parts
                                                  join mp in _context.MasterParts
                                                  on p.MasterPartId equals mp.MasterPartId
                                                  where p.ParentPartId == partItems.PartId
                                                  select new Parts
                                                  {
                                                      PartId = p.PartId,
                                                      SerialNumber = p.SerialNumber,
                                                      Description = mp.Description,
                                                      MasterPartId = mp.MasterPartId,
                                                      ParentPartId = p.ParentPartId,
                                                      PartNumber = mp.PartNumber,
                                                      PartStatusId = p.PartStatusId,
                                                      PartStatus = p.PartStatus.Name,
                                                      BuildStationId = p.BuildStationId,
                                                      BuildStations = p.BuildStation.Name,
                                                      SerialNumberRequired = p.SerialNumberRequired
                                                  }).ToListAsync();
                }
                item.PartsList = part;
            }

            return workOrderModelList;
        }

        public async Task<Models.WorkOrderModel> GetWorkOrderByWorkOrderId(int workOrderId)
        {
            WorkOrderModel workOrderModel = new WorkOrderModel();
            workOrderModel = await (from wo in _context.WorkOrders
                                    join wot in _context.WorkOrderTypes on wo.WorkOrderTypeId equals wot.WorkOrderTypeId
                                    join wos in _context.WorkOrderStatuses on wo.WorkOrderStatusId equals wos.WorkOrderStatusId
                                    join wop in _context.WorkOrderPriorities on wo.WorkOrderPriorityID equals wop.WorkOrderPriorityId
                                    join bt in _context.BuildTemplates on wo.BuildTemplateId equals bt.BuildTemplateId
                                    where wo.WorkOrderId == workOrderId
                                    select new Models.WorkOrderModel
                                    {
                                        WorkOrderId = wo.WorkOrderId,
                                        CreateDate = wo.CreateDate,
                                        WorkOrderTypeId = wo.WorkOrderTypeId,
                                        WorkOrderType = wot,
                                        WorkOrderStatusId = wo.WorkOrderStatusId,
                                        WorkOrderStatus = wos,
                                        WorkOrderPriorityID = wo.WorkOrderPriorityID,
                                        WorkOrderPriority = wop,
                                        BuildTemplateId = wo.BuildTemplateId,
                                        BuildTemplate = bt,
                                        Quantity = wo.Quantity,
                                        BuildTemplateMasterPartName = bt.Name + " " + bt.MasterPart.PartNumber
                                    }).FirstOrDefaultAsync();

            if (workOrderModel != null && workOrderModel.WorkOrderId > 0)
            {
                var workOrderParts = await _context.WorkOrderParts.Where(x => x.WorkOrderId == workOrderModel.WorkOrderId).ToListAsync();
                var buildStations = await _context.BuildTemplateStations.Where(x => x.BuildTemplateId == workOrderModel.BuildTemplateId).Select(x => x.BuildStation)
                    .Select(x => new BuildStationModel { BuildStationId = x.BuildStationId, Name = x.Name }).ToListAsync();

                var part = await (from p in _context.Parts
                                  join mp in _context.MasterParts
                                  on p.MasterPartId equals mp.MasterPartId
                                  join wp in _context.WorkOrderParts on p.PartId equals wp.PartId
                                  join i in _context.Inspections on new { WorkOrderId = (int?)workOrderModel.WorkOrderId, PartId = p.PartId } equals new { WorkOrderId = i.WorkOrderId, PartId = i.PartId } into i_join
                                  from i in i_join.DefaultIfEmpty()
                                  where p.ParentPartId == null && wp.WorkOrderId == workOrderModel.WorkOrderId
                                  select new Parts
                                  {
                                      PartId = p.PartId,
                                      SerialNumber = p.SerialNumber,
                                      Description = mp.Description,
                                      MasterPartId = mp.MasterPartId,
                                      ParentPartId = p.ParentPartId,
                                      PartNumber = mp.PartNumber,
                                      PartStatusId = p.PartStatusId,
                                      PartStatus = p.PartStatus.Name,
                                      BuildStationId = p.BuildStationId,
                                      BuildStations = p.BuildStation.Name,
                                      SerialNumberRequired = p.SerialNumberRequired,
                                      IsCompleteBuildStation = wp.IsCompleteBuildStation,
                                      InspectionStatus = (i.InspectionId > 0 ? (i.Pass ? "Passed" : "Failed") : "Non Inspectioned")
                                  }).ToListAsync();

                foreach (Parts partItems in part)
                {
                    foreach (BuildStationModel buildStation in buildStations)
                    {
                        buildStation.Parts = await (from p in _context.Parts
                                                    join mp in _context.MasterParts
                                                    on p.MasterPartId equals mp.MasterPartId
                                                    join i in _context.Inspections on new { WorkOrderId = (int?)workOrderModel.WorkOrderId, PartId = p.PartId } equals new { WorkOrderId = i.WorkOrderId, PartId = i.PartId } into i_join
                                                    from i in i_join.DefaultIfEmpty()
                                                    where p.BuildStationId == buildStation.BuildStationId
                                                    && p.ParentPartId == partItems.PartId
                                                    select new Parts
                                                    {
                                                        PartId = p.PartId,
                                                        SerialNumber = p.SerialNumber,
                                                        Description = mp.Description,
                                                        MasterPartId = mp.MasterPartId,
                                                        ParentPartId = p.ParentPartId,
                                                        PartNumber = mp.PartNumber,
                                                        PartStatusId = p.PartStatusId,
                                                        PartStatus = p.PartStatus.Name,
                                                        BuildStationId = p.BuildStationId,
                                                        BuildStations = p.BuildStation.Name,
                                                        SerialNumberRequired = p.SerialNumberRequired,
                                                        InspectionStatus = (i.InspectionId > 0 ? (i.Pass ? "Passed" : "Failed") : "Non Inspectioned")
                                                    }).ToListAsync();
                    }
                    partItems.BuildStationsModel = buildStations;
                }

                workOrderModel.PartsList = part;

            }
            return workOrderModel;
        }

        public async Task<Models.ApiResponse> Save(Models.AddEditWorkOrderModel addEditWorkOrderModel)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();

            try
            {
                //if (CheckDuplicate(addEditWorkOrderModel.WorkOrderId, addEditWorkOrderModel.WorkOrderTypeId.Value, addEditWorkOrderModel.WorkOrderStatusId.Value, addEditWorkOrderModel.WorkOrderPriorityID.Value, addEditWorkOrderModel.BuildTemplateId.Value, addEditWorkOrderModel.Quantity.Value))
                //{
                //    apiResponse.Success = false;
                //    apiResponse.Message = "Duplicate record.";
                //    return apiResponse;
                //}



                var objWorkOrder = new Entities.WorkOrder();
                if (addEditWorkOrderModel.WorkOrderId > 0)
                {
                    if (addEditWorkOrderModel.WorkOrderStatusId == 3)
                    {
                        // If Completed status then first check all workorder part need to completed
                        if (_context.WorkOrderParts.Any(x => x.WorkOrderId == addEditWorkOrderModel.WorkOrderId && x.IsCompleteBuildStation == false))
                        {
                            apiResponse.Success = false;
                            apiResponse.Message = "There are still few workorder parts incomplete. so, you can't complete workorder. ";
                            return apiResponse;
                        }
                    }

                    objWorkOrder = _context.WorkOrders.Where(d => d.WorkOrderId == addEditWorkOrderModel.WorkOrderId).FirstOrDefault();
                    if (objWorkOrder != null)
                    {
                        objWorkOrder.WorkOrderTypeId = addEditWorkOrderModel.WorkOrderTypeId.Value;
                        objWorkOrder.WorkOrderStatusId = addEditWorkOrderModel.WorkOrderStatusId.Value;
                        objWorkOrder.WorkOrderPriorityID = addEditWorkOrderModel.WorkOrderPriorityID.Value;
                        //objWorkOrder.BuildTemplateId = addEditWorkOrderModel.BuildTemplateId.Value;
                        //objWorkOrder.Quantity = addEditWorkOrderModel.Quantity.Value;
                        _context.Entry(objWorkOrder).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    objWorkOrder = new Entities.WorkOrder()
                    {
                        CreateDate = DateTime.UtcNow,
                        WorkOrderTypeId = addEditWorkOrderModel.WorkOrderTypeId.Value,
                        WorkOrderStatusId = addEditWorkOrderModel.WorkOrderStatusId.Value,
                        WorkOrderPriorityID = addEditWorkOrderModel.WorkOrderPriorityID.Value,
                        BuildTemplateId = addEditWorkOrderModel.BuildTemplateId.Value,
                        Quantity = addEditWorkOrderModel.Quantity.Value,
                        PONumber = addEditWorkOrderModel.PONumber

                    };
                    _context.WorkOrders.Add(objWorkOrder);

                    await _context.SaveChangesAsync();
                    if (objWorkOrder != null && objWorkOrder.WorkOrderId > 0 && objWorkOrder.Quantity > 0)
                    {
                        var buildTemplate = await _context.BuildTemplates.Where(x => x.BuildTemplateId == objWorkOrder.BuildTemplateId).FirstOrDefaultAsync();
                        var buildTemplateParts = await _context.BuildTemplateParts.Where(x => x.BuildTemplateId == addEditWorkOrderModel.BuildTemplateId.Value).ToListAsync();

                        for (int i = 1; i <= objWorkOrder.Quantity; i++)
                        {
                            Part part = new Part();
                            part.SerialNumber = "";
                            part.MasterPartId = buildTemplate.MasterPartId;
                            part.UpdateDate = DateTime.Now;
                            part.PartStatusId = 1;
                            //  part.BuildStationId = buildTemplate.BuildStationId;
                            part.SerialNumberRequired = true;
                            _context.Parts.Add(part);
                            _context.SaveChanges();

                            foreach (var buildTemplatePart in buildTemplateParts)
                            {
                                Part templatePart = new Part();
                                templatePart.SerialNumber = "";
                                templatePart.MasterPartId = buildTemplatePart.MasterPartId;
                                templatePart.UpdateDate = DateTime.Now;
                                templatePart.PartStatusId = 1;
                                templatePart.BuildStationId = buildTemplatePart.BuildStationId;
                                templatePart.SerialNumberRequired = buildTemplatePart.SerialNumberRequired;
                                templatePart.ParentPartId = part.PartId;

                                _context.Parts.Add(templatePart);
                                _context.SaveChanges();

                                if (!templatePart.SerialNumberRequired)
                                {
                                    templatePart.SerialNumber = $"U-{templatePart.PartId}";
                                    _context.Entry(templatePart).State = EntityState.Modified;
                                    await _context.SaveChangesAsync();
                                }
                            }

                            WorkOrderPart workOrderPart = new WorkOrderPart();
                            workOrderPart.WorkOrderId = objWorkOrder.WorkOrderId;
                            workOrderPart.PartId = part.PartId;
                            _context.WorkOrderParts.Add(workOrderPart);
                            _context.SaveChanges();
                        }
                    }
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

        public async Task Delete(Models.WorkOrderModel itemToDelete)
        {
            var workOrder = _context.WorkOrders.Where(d => d.WorkOrderId == itemToDelete.WorkOrderId).FirstOrDefault();
            if (workOrder != null)
            {
                _context.WorkOrders.Remove(workOrder);
                await _context.SaveChangesAsync();
            }
        }

        public bool CheckDuplicate(int? WorkOrderId, int WorkOrderTypeId, int WorkOrderStatusId, int WorkOrderPriorityID, int BuildTemplateId, int Quantity)
        {
            var workOrder = false;
            if (WorkOrderId > 0)
                workOrder = _context.WorkOrders.Any(x => x.WorkOrderTypeId == WorkOrderTypeId && x.WorkOrderStatusId == WorkOrderStatusId && x.WorkOrderPriorityID == WorkOrderPriorityID && x.BuildTemplateId == BuildTemplateId && x.Quantity == Quantity && x.WorkOrderId != WorkOrderId);
            else
                workOrder = _context.WorkOrders.Any(x => x.WorkOrderTypeId == WorkOrderTypeId && x.WorkOrderStatusId == WorkOrderStatusId && x.WorkOrderPriorityID == WorkOrderPriorityID && x.BuildTemplateId == BuildTemplateId && x.Quantity == Quantity);

            return workOrder;
        }

        public async Task SetWorkOrderToCompletedIfAllStationCompleted(int workOrderId)
        {
            var inCompletedCount = await _context.WorkOrderParts.CountAsync(x => x.WorkOrderId == workOrderId && x.IsCompleteBuildStation != true);
            if (inCompletedCount == 0)
            {
                var workOrder = await _context.WorkOrders.FirstOrDefaultAsync(x => x.WorkOrderId == workOrderId);
                if (workOrder != null)
                {
                    workOrder.WorkOrderStatusId = 3;//Completed
                    _context.Entry(workOrder).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> CompleteBuildInspection(int workOrderId, int partId)
        {
            try
            {
                Entities.WorkOrderPart objWorkOrderPart = await _context.WorkOrderParts.FirstOrDefaultAsync(x => x.WorkOrderId == workOrderId && x.PartId == partId);

                if (objWorkOrderPart != null && objWorkOrderPart.WorkOrderId > 0)
                {
                    objWorkOrderPart.IsCompleteBuildStation = true;
                    _context.Entry(objWorkOrderPart).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CheckAllBuildStationInspectionComplete(int workOrderId, int partId)
        {
            try
            {
                var BuildStations = await (from w in _context.WorkOrders
                                           join wp in _context.WorkOrderParts on w.WorkOrderId equals wp.WorkOrderId
                                           join bs in _context.BuildTemplateStations on w.BuildTemplateId equals bs.BuildTemplateId
                                           join i in _context.BuildStationInspections on new { WorkOrderId = wp.WorkOrderId, PartId = wp.PartId, BuildStationId = bs.BuildStationId } equals new { WorkOrderId = i.WorkOrderId, PartId = i.PartId, BuildStationId = i.BuildStationId } into i_join
                                           from i in i_join.DefaultIfEmpty()
                                           where w.WorkOrderId == workOrderId && wp.PartId == partId
                                           select new
                                           {
                                               IsCompleteBuildStation = (i == null ? false : i.IsCompleteBuildStation)
                                           }).ToListAsync();

                return !BuildStations.Any(x => x.IsCompleteBuildStation == false);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<WorkOrderDropDown>> GetWorkOrderListByPoNumber(string PONumber)
        {
            List<WorkOrderDropDown> workOrderDropDowns = new List<WorkOrderDropDown>();
            if (!string.IsNullOrWhiteSpace(PONumber))
            {
                workOrderDropDowns = await _context.WorkOrders
                    .Where(x => (x.PONumber == PONumber || string.IsNullOrWhiteSpace(x.PONumber)) && x.WorkOrderStatusId != 3)
                    .OrderByDescending(x => x.PONumber)
                    .Select(x => new WorkOrderDropDown()
                    {
                        DisplayName = x.WorkOrderId.ToString(),
                        WorkOrderId = x.WorkOrderId,
                        PONumber = Convert.ToString(x.PONumber).Trim()
                    }).ToListAsync();
            }

            return workOrderDropDowns;
        }

        public async Task<UserWorkOrderDetail> GetUserWorkOrderDetailById(int WorkOrderId, int BuildStationId, int PartId)
        {
            UserWorkOrderDetail userWorkOrderDetail = new UserWorkOrderDetail();
            var workOrder = await _context.WorkOrders.Include(x => x.WorkOrderType).Include(x => x.WorkOrderStatus).Include(x => x.WorkOrderPriority)
                .Where(x => x.WorkOrderId == WorkOrderId)
                .Select(x => x).FirstOrDefaultAsync();
            userWorkOrderDetail.IsAllowSave = false;

            if (workOrder != null)
            {
                userWorkOrderDetail.Type = workOrder.WorkOrderType.Name;
                userWorkOrderDetail.Status = workOrder.WorkOrderStatus.Name;
                userWorkOrderDetail.Priority = workOrder.WorkOrderPriority.Name;
            }

            var buildStation = await _context.BuildStations.FirstOrDefaultAsync(x => x.BuildStationId == BuildStationId);
            if (buildStation != null)
            {
                userWorkOrderDetail.StationName = buildStation.Name;

                userWorkOrderDetail.Parts = await _context.Parts.Include(x => x.MasterPart)
                                .Where(x => x.ParentPartId == PartId && x.BuildStationId == BuildStationId)
                                  .Select(x => new EditPartModel()
                                  {
                                      PartId = x.PartId,
                                      SerialNumber = x.SerialNumber,
                                      MasterPartId = x.MasterPartId,
                                      BuildStationId = x.BuildStationId,
                                      PartNumber = x.MasterPart.PartNumber
                                  }).ToListAsync();

                var buildStationInspection = await _buildStationInspectionService.GetInspectionByWorkOrderIdAndPartId(WorkOrderId, PartId, BuildStationId);
                if (buildStationInspection.BuildStationInspectionId <= 0)
                {
                    userWorkOrderDetail.IsFoundStation = false;
                    userWorkOrderDetail.ErrorMessage = "Sation Data not found.";
                }
                else
                {
                    userWorkOrderDetail.BuildStationInspectionModel = buildStationInspection;
                    userWorkOrderDetail.IsFoundStation = true;
                    if (buildStationInspection.Pass)
                    {
                        userWorkOrderDetail.IsAllowSave = false;
                    }
                    else
                    {
                        userWorkOrderDetail.IsAllowSave = true;
                    }
                }
            }

            return userWorkOrderDetail;
        }

        public async Task<UserWorkOrderDetail> GetUserWorkOrderDetail(int WorkOrderId, string serialNumber)
        {
            UserWorkOrderDetail userWorkOrderDetail = new UserWorkOrderDetail();
            var workOrder = await _context.WorkOrders.Include(x => x.WorkOrderType).Include(x => x.WorkOrderStatus).Include(x => x.WorkOrderPriority)
                .Where(x => x.WorkOrderId == WorkOrderId)
                .Select(x => x).FirstOrDefaultAsync();
            userWorkOrderDetail.IsAllowSave = false;

            if (workOrder != null)
            {
                userWorkOrderDetail.Type = workOrder.WorkOrderType.Name;
                userWorkOrderDetail.Status = workOrder.WorkOrderStatus.Name;
                userWorkOrderDetail.Priority = workOrder.WorkOrderPriority.Name;
            }

            var workOrderParts = await _context.WorkOrderParts.Include(x => x.Part).Where(x => x.WorkOrderId == WorkOrderId).OrderBy(x => x.WorkOrderPartId).ToListAsync();
            if (!workOrderParts.Any())
            {
                userWorkOrderDetail.IsFoundStation = false;
                userWorkOrderDetail.ErrorMessage = "Station not found for this work order.";
            }
            else
            {
                var buildTemplateStations = await _context.BuildTemplateStations.Include(x => x.BuildStation).Where(x => x.BuildTemplateId == workOrder.BuildTemplateId).OrderBy(x => x.OrderNumber).ToListAsync();
                if (!buildTemplateStations.Any())
                {
                    userWorkOrderDetail.IsFoundStation = false;
                    userWorkOrderDetail.ErrorMessage = "Station not found for this work order.";
                }
                else
                {
                    int? LastCompletedPartId = null;
                    int? LastCompletedBuildStationId = null;
                    int? PartId = null;
                    int? BuildStationId = null;
                    var lastBuildTemplateStation = buildTemplateStations.Last();
                    var buildStationInspections = await _context.BuildStationInspections.Where(x => x.WorkOrderId == WorkOrderId).ToListAsync();

                    var workOrderPart = workOrderParts.FirstOrDefault(x => Convert.ToString(x.Part.SerialNumber).Trim() == serialNumber.Trim());
                    if (workOrderPart == null)
                    {
                        workOrderPart = workOrderParts.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.Part.SerialNumber) == true);
                    }

                    if (workOrderPart != null)
                    {
                        //foreach (var workOrderPart in workOrderParts)
                        //{
                        foreach (var buildTemplateStation in buildTemplateStations)
                        {
                            var buildStationInspection = buildStationInspections.FirstOrDefault(x => x.PartId == workOrderPart.PartId && x.BuildStationId == buildTemplateStation.BuildStationId);
                            if (!(buildStationInspection != null && buildStationInspection.IsCompleteBuildStation == true))
                            {
                                PartId = workOrderPart.PartId;
                                BuildStationId = buildTemplateStation.BuildStationId;
                                userWorkOrderDetail.StationName = buildTemplateStation.BuildStation.Name;
                                break;
                            }
                            else if (buildStationInspection != null && buildStationInspection.IsCompleteBuildStation == true)
                            {
                                LastCompletedPartId = workOrderPart.PartId;
                                LastCompletedBuildStationId = buildTemplateStation.BuildStationId;
                                userWorkOrderDetail.StationName = buildTemplateStation.BuildStation.Name;
                            }
                        }

                        if (PartId.HasValue)
                        {
                            userWorkOrderDetail.IsAllowSave = true;
                            //break;
                        }
                        else if (workOrderPart.IsCompleteBuildStation == false)
                        {
                            userWorkOrderDetail.IsAllowSave = true;
                            PartId = workOrderPart.PartId;
                            BuildStationId = lastBuildTemplateStation.BuildStationId;
                            userWorkOrderDetail.StationName = lastBuildTemplateStation.BuildStation.Name;
                            //break;
                        }
                        //}

                        if (!PartId.HasValue && LastCompletedPartId.HasValue)
                        {
                            PartId = LastCompletedPartId;
                            BuildStationId = LastCompletedBuildStationId;
                        }

                        if (PartId.HasValue)
                        {
                            userWorkOrderDetail.Parts = await _context.Parts.Include(x => x.MasterPart)
                                .Where(x => x.ParentPartId == PartId && x.BuildStationId == BuildStationId)
                                  .Select(x => new EditPartModel()
                                  {
                                      PartId = x.PartId,
                                      SerialNumber = x.SerialNumber,
                                      MasterPartId = x.MasterPartId,
                                      BuildStationId = x.BuildStationId,
                                      PartNumber = x.MasterPart.PartNumber
                                  }).ToListAsync();

                            var buildStationInspection = await _buildStationInspectionService.GetInspectionByWorkOrderIdAndPartId(WorkOrderId, PartId!.Value, BuildStationId!.Value);
                            if (buildStationInspection.BuildStationInspectionId <= 0)
                            {
                                buildStationInspection.Pass = true;
                                buildStationInspection.GeneralComments = string.Empty;
                                buildStationInspection.PartId = PartId.Value;

                                buildStationInspection.WorkOrderId = WorkOrderId;
                                buildStationInspection.BuildStationId = BuildStationId.Value;
                                buildStationInspection.BuildStationInspectionFailed = new Models.BuildStationInspectionFailed();
                            }
                            userWorkOrderDetail.BuildStationInspectionModel = buildStationInspection;
                            userWorkOrderDetail.IsFoundStation = true;
                        }
                        else
                        {
                            userWorkOrderDetail.IsFoundStation = false;
                            userWorkOrderDetail.ErrorMessage = "Station not found for this work order.";
                        }
                    }
                    else
                    {
                        userWorkOrderDetail.IsFoundStation = false;
                        userWorkOrderDetail.ErrorMessage = "Part not found for serial number.";
                    }
                }
            }

            return userWorkOrderDetail;
        }

        public async Task UpdateWorkOrderPONumber(int WorkOrderId, string PONumber)
        {
            var workOrder = await _context.WorkOrders.FindAsync(WorkOrderId);
            if (workOrder != null)
            {
                workOrder.PONumber = PONumber;
                _context.Entry(workOrder).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateMasterPartSerialNumber(int partId, string serialNumber)
        {
            var part = await _context.Parts.FindAsync(partId);
            if (part != null)
            {
                part.SerialNumber = serialNumber.Trim();
                _context.Entry(part).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}