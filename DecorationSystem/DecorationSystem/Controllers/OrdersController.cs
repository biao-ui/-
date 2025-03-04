using Commo;
using IBLL;
using Microsoft.AspNetCore.Mvc;

namespace DecorationSystem.Controllers
{
    public class OrdersController : Controller
    {
        IOrdersBLL _ordersBLL;
        public OrdersController(IOrdersBLL orders)
        {
            _ordersBLL = orders;
        }


        /// <summary>
        /// 订单管理页面
        /// </summary>
        /// <returns></returns>
        public IActionResult OrdersListView() { return View(); }

        /// <summary>
        /// 订单添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateOrdersView() { return View(); }

        /// <summary>
        /// 订单修改页面
        ///  </summary>
        /// </summary>
        public IActionResult UpOrdersView() { return View(); }

        /// <summary>
        /// 订单添加材料页面
        ///  </summary>
        /// </summary>
        public IActionResult OrdersMaterialListView() { return View(); }

        /// <summary>
        /// 为订单选择材料页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ChooseOrdersMaterialView() { return View(); }

        /// <summary>
        /// 打印页面
        /// </summary>
        /// <returns></returns>
        public IActionResult PrintView() { return View(); }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="password"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel CreateOrders(string customerName, string customPhone, string address, double ares, DateTime startTime, DateTime endTime, string designerId, string? remark)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                return APIResultModel.GetErrorResult("请输入客户名称");
            }

            if (string.IsNullOrEmpty(customPhone))
            {
                return APIResultModel.GetErrorResult("请输入客户电话");
            }

            if (string.IsNullOrEmpty(address))
            {
                return APIResultModel.GetErrorResult("请输入地址");
            }

            if (ares <= 0)
            {
                return APIResultModel.GetErrorResult("请输入面积");
            }

            if (string.IsNullOrEmpty(designerId))
            {
                return APIResultModel.GetErrorResult("请输入设计师");
            }

            if (startTime >= endTime)
            {
                return APIResultModel.GetErrorResult("开始时间必须要大于结束时间");
            }

            return _ordersBLL.CreateOrders(customerName, customPhone, address, ares, startTime, endTime, designerId, remark);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public APIResultModel GetOrders(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }

            return APIResultModel.GetErrorResult("成功",_ordersBLL.GetOrders(id));

        }

        /// <summary>
        /// 多条查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public APIResultModel GetListOrderss(int page, int limit, string customerName, string customPhone)
        {
            if (page <= 0)
            {
                return APIResultModel.GetErrorResult("page不能小于1");
            }

            if (limit <= 0)
            {
                return APIResultModel.GetErrorResult("limit不能小于1");
            }

            return _ordersBLL.GetListOrderss(page, limit, customerName, customPhone);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phon"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel UpDataOrderss(string id, string customerName, string customPhone, string address, int ares, DateTime startTime, DateTime endTime, string designerId, string? remark)
        {
            if (String.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("Id不能为空");
            }
            if (String.IsNullOrEmpty(customerName))
            {
                return APIResultModel.GetErrorResult("用户名称不能为空");
            }
            if (String.IsNullOrEmpty(customerName))
            {
                return APIResultModel.GetErrorResult("用户手机不能为空");
            }

            return _ordersBLL.UpDataOrderss(id, customerName, customPhone, address, ares, startTime, endTime, designerId, remark);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel DeleteOrders(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }
            return _ordersBLL.DeleteOrders(id);
        }

        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel BatchDeleteOrders(List<string> ids)
        {
            if (ids == null || ids.Count <= 0)
            {
                return APIResultModel.GetErrorResult("ids不能为空");
            }
            return _ordersBLL.BatchDeleteOrders(ids);
        }

        /// <summary>
        /// 获取下拉项数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public APIResultModel GetOrdersList()
        {
            return _ordersBLL.GetOrdersList();
        }

        ///// <summary>
        ///// 获取穿梭框数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public APIResultModel GetTransferOPtionList(string roleId)
        //{
        //    if (string.IsNullOrEmpty(roleId) == null)
        //    {
        //        return APIResultModel.GetErrorResult("订单id不能为空");
        //    }
        //    return _ordersBLL.GetTransferOPtionList(roleId);
        //}

        ///// <summary>
        ///// 更改穿梭框数据
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public APIResultModel BindEmloyee(int index, string roleId, List<string> employeeIds)
        //{
        //    if (String.IsNullOrEmpty(roleId))
        //    {
        //        return APIResultModel.GetErrorResult("roleId不能为空");
        //    }
        //    if (index < 0 && index > 1)
        //    {
        //        return APIResultModel.GetErrorResult("index参数有误");
        //    }
        //    if (employeeIds == null || employeeIds.Count <= 0)
        //    {
        //        return APIResultModel.GetErrorResult("employeeIds不能为空");
        //    }

        //    return _ordersBLL.BindEmloyee(index, roleId, employeeIds);
        //}

        /// <summary>
        /// 为订单选择材料
        /// </summary>
        /// <param name="ordersId"></param>
        /// <param name="materialId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public APIResultModel ChooseOrdersMaterial(string ordersId, string materialId, int num)
        {
            if (string.IsNullOrEmpty(ordersId))
            {
                return APIResultModel.GetErrorResult("请传入订单id");
            }
            if (string.IsNullOrEmpty(materialId))
            {
                return APIResultModel.GetErrorResult("请传入材料");
            }
            if (num <= 0)
            {
                return APIResultModel.GetErrorResult("请传入数量");
            }

            return _ordersBLL.ChooseOrdersMaterial(materialId, ordersId, num);
        }

        /// <summary>
        /// 为订单材料显示
        /// </summary>
        /// /// <returns></returns>
        public APIResultModel GetOrdersMaterialList(int page, int limit, string ordersId, string materialId)
        {
            if (page <= 0)
            {
                return APIResultModel.GetErrorResult("page不能小于1");
            }

            if (limit <= 0)
            {
                return APIResultModel.GetErrorResult("limit不能小于1");
            }

            return _ordersBLL.GetOrdersMaterialList(page, limit, ordersId, materialId);
        }

        /// <summary>
        /// 材料删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel DeleteMaterialOrders(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }
            return _ordersBLL.DeleteMaterialOrders(id);
        }

        /// <summary>
        /// 材料多条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel BatchDeleteMaterialOrders(List<string> ids)
        {
            if (ids == null || ids.Count <= 0)
            {
                return APIResultModel.GetErrorResult("ids不能为空");
            }
            return _ordersBLL.BatchDeleteMaterialOrders(ids);
        }

        /// <summary>
        /// 获取打印页数据
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public APIResultModel GetPrintDatas(string ordersId)
        {
            if (string.IsNullOrEmpty(ordersId))
            {
                return APIResultModel.GetErrorResult("ordersId不能为空");
            }
            return _ordersBLL.GetPrintDatas(ordersId);
        }
    }
}
