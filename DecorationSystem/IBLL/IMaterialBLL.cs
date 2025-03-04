using Commo;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IMaterialBLL
    {
        /// <summary>
        /// 添加注册材料
        /// </summary>
        /// <param name="password"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel CreateMaterial(string name, string unit, double price, double priceMain, double priceArtificial, string? remark);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Material GetMaterial(string id);

        /// <summary>
        /// 多条查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel GetListMaterials(int page, int limit, string name);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phon"></param>
        /// <returns></returns>
        public APIResultModel UpDataMaterials(string id, string name, string unit, double price, double priceMain, double priceArtificial, string? remark);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteMaterial(string id);

        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteMaterial(List<string> ids);

        /// <summary>
        /// 获取下拉项数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOPtionList(string ordersId);

    }
}
