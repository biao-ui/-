using Commo;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IOrdersBLL
    {
        /// <summary>
        /// 为订单选择材料
        /// </summary>
        /// <param name="ordersId"></param>
        /// <param name="materialId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        APIResultModel ChooseOrdersMaterial(string materialId, string ordersId, int num);

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="password"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel CreateOrders(string customerName, string customPhone, string address, double ares, DateTime startTime, DateTime endTime, string designerId, string? Remark);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Orders GetOrders(string id);

        /// <summary>
        /// 多条查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel GetListOrderss(int page, int limit, string customerName, string customPhone);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phon"></param>
        /// <returns></returns>
        public APIResultModel UpDataOrderss(string id, string customerName, string customPhone, string address, int ares, DateTime startTime, DateTime endTime, string designerId, string? remark);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteOrders(string id);

        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteOrders(List<string> ids);

        /// <summary>
        /// 获取下拉项数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOrdersList();

        /// <summary>
        /// 为订单材料显示
        /// </summary>
        /// /// <returns></returns>
        public APIResultModel GetOrdersMaterialList(int page, int limit, string ordersId, string materialId);

        /// <summary>
        /// 材料删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteMaterialOrders(string id);

        /// <summary>
        /// 多条材料删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteMaterialOrders(List<string> ids);

        /// <summary>
        /// 获取打印页数据
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public APIResultModel GetPrintDatas(string ordersId);
    }
}
