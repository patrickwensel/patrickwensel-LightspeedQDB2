using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;
using QBD2.Models;

namespace QBD2.Services
{
    public class WorkOrderService
    {
        private readonly ApplicationDbContext _context;

        public WorkOrderService(ApplicationDbContext context)
        {
            _context = context;
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
                    partItems.ChildParts =   await (from p in _context.Parts
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
            workOrderModel =  await (from wo in _context.WorkOrders
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
                var workOrderParts = await _context.WorkOrderParts.Where(x => x.WorkOrderId == workOrderModel.WorkOrderId).Select(x => x.PartId).ToListAsync();
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
                        Quantity = addEditWorkOrderModel.Quantity.Value
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
                workOrder = _context.WorkOrders.Any(x => x.WorkOrderTypeId == WorkOrderTypeId && x.WorkOrderStatusId == WorkOrderStatusId && x.WorkOrderPriorityID == WorkOrderPriorityID  && x.BuildTemplateId == BuildTemplateId && x.Quantity == Quantity   && x.WorkOrderId != WorkOrderId);
            else
                workOrder = _context.WorkOrders.Any(x => x.WorkOrderTypeId == WorkOrderTypeId && x.WorkOrderStatusId == WorkOrderStatusId && x.WorkOrderPriorityID == WorkOrderPriorityID && x.BuildTemplateId == BuildTemplateId && x.Quantity == Quantity);

            return workOrder;
        }
    }
}