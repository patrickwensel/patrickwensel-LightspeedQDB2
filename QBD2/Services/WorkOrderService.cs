using Microsoft.EntityFrameworkCore;
using QBD2.Data;

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
            List<Models.WorkOrderModel> WorkOrderModelList = new List<Models.WorkOrderModel>();
            WorkOrderModelList = await (from wo in _context.WorkOrders
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
                                            BuildTemplateMasterPartName = bt.Name + " " + bt.MasterPart.PartNumber
                                        }).ToListAsync();
            return WorkOrderModelList;
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