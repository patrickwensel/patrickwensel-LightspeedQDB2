using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using QBD2.Entities;

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
                                            WorkOrderPartList = _context.WorkOrderParts.Include(b=>b.WorkOrder).Include(a=>a.Part).Include(c=>c.Part.ParentPart).Include(d=>d.Part.PartStatus).Include(d => d.Part.BuildStation).Where(x => x.WorkOrderId == wo.WorkOrderId).ToList()
                                        }).ToListAsync();

            foreach (var item in workOrderModelList)
            {
                var workOrderParts = await _context.WorkOrderParts.Where(x => x.WorkOrderId == item.WorkOrderId).Select(x => x.PartId).ToListAsync();
                item.PartsList = _context.Parts.Include(c => c.ParentPart).Include(d => d.PartStatus).Include(e => e.BuildStation).Include(f=>f.MasterPart).Where(x => workOrderParts.Contains(x.PartId)).ToList();
            }

            return workOrderModelList;
        }

        public async Task<Models.ApiResponse> Save(Models.AddEditWorkOrderModel addEditWorkOrderModel)
        {
            Models.ApiResponse apiResponse = new Models.ApiResponse();

            try
            {
                if (CheckDuplicate(addEditWorkOrderModel.WorkOrderId, addEditWorkOrderModel.WorkOrderTypeId.Value, addEditWorkOrderModel.WorkOrderStatusId.Value, addEditWorkOrderModel.WorkOrderPriorityID.Value, addEditWorkOrderModel.BuildTemplateId.Value, addEditWorkOrderModel.Quantity.Value))
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Duplicate record.";
                    return apiResponse;
                }

                var objWorkOrder = new Entities.WorkOrder();
                if (addEditWorkOrderModel.WorkOrderId > 0)
                {
                    objWorkOrder = _context.WorkOrders.Where(d => d.WorkOrderId == addEditWorkOrderModel.WorkOrderId).FirstOrDefault();
                    if (objWorkOrder != null)
                    {
                        objWorkOrder.WorkOrderTypeId = addEditWorkOrderModel.WorkOrderTypeId.Value;
                        objWorkOrder.WorkOrderStatusId = addEditWorkOrderModel.WorkOrderStatusId.Value;
                        objWorkOrder.WorkOrderPriorityID = addEditWorkOrderModel.WorkOrderPriorityID.Value;
                        objWorkOrder.BuildTemplateId = addEditWorkOrderModel.BuildTemplateId.Value;
                        objWorkOrder.Quantity = addEditWorkOrderModel.Quantity.Value;
                        _context.Entry(objWorkOrder).State = EntityState.Modified;
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
                        var buildTemplatePart = await _context.BuildTemplateParts.Where(x => x.BuildTemplateId == addEditWorkOrderModel.BuildTemplateId.Value).FirstOrDefaultAsync();
                        var parts = await _context.Parts.Where(x => x.MasterPartId == buildTemplatePart.MasterPartId).ToListAsync();

                        for (int i = 1; i <= objWorkOrder.Quantity; i++)
                        {
                            Part part = new Part();
                            part.SerialNumber = "";
                            part.MasterPartId = buildTemplatePart.MasterPartId;
                            part.UpdateDate = DateTime.Now;
                            part.PartStatusId = 1;
                            if (buildTemplatePart != null)
                            {
                                part.BuildStationId = buildTemplatePart.BuildStationId;
                                part.SerialNumberRequired = buildTemplatePart.SerialNumberRequired;
                            }
                           
                            _context.Parts.Add(part);
                            _context.SaveChanges();

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