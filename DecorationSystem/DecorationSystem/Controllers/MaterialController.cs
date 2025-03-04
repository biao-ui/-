using Commo;
using IBLL;
using Microsoft.AspNetCore.Mvc;

namespace DecorationSystem.Controllers
{
    public class MaterialController : Controller
    {
        IMaterialBLL _materialBLL;
        public MaterialController(IMaterialBLL material)
        {
            _materialBLL = material;
        }


        /// <summary>
        /// 材料管理页面
        /// </summary>
        /// <returns></returns>
        public IActionResult MaterialListView() { return View(); }

        /// <summary>
        /// 材料添加页面
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateMaterialView() { return View(); }

        /// <summary>
        /// 材料修改页面
        ///  </summary>
        /// </summary>
        public IActionResult UpMaterialView() { return View(); }

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="password"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel CreateMaterial(string name, string unit, double price, double priceMain, double priceArtificial, string? remark)
        {
            if (string.IsNullOrEmpty(name))
            {
                return APIResultModel.GetErrorResult("请输入材料名称");
            }

            if (string.IsNullOrEmpty(unit))
            {
                return APIResultModel.GetErrorResult("请输入材料单位");
            }

            //if (price != priceMain + priceArtificial)
            //{
            //    return APIResultModel.GetErrorResult("请输入正确的总价格（材料价格 + 人工价格）");
            //}

            if (priceMain <= 0)
            {
                return APIResultModel.GetErrorResult("请输入材料价格");
            }

            if (priceArtificial <= 0)
            {
                return APIResultModel.GetErrorResult("请输入人工价格");
            }
            price = priceMain + priceArtificial;

            return _materialBLL.CreateMaterial(name, unit, price, priceMain, priceArtificial, remark);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public APIResultModel GetMaterial(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }

            return APIResultModel.GetErrorResult("成功",_materialBLL.GetMaterial(id));

        }

        /// <summary>
        /// 多条查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public APIResultModel GetListMaterials(int page, int limit, string name)
        {
            if (page <= 0)
            {
                return APIResultModel.GetErrorResult("page不能小于1");
            }

            if (limit <= 0)
            {
                return APIResultModel.GetErrorResult("limit不能小于1");
            }

            return _materialBLL.GetListMaterials(page, limit, name);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phon"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel UpDataMaterials(string id, string name, string unit, double price, double priceMain, double priceArtificial, string? remark)
        {
            if (String.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("Id不能为空");
            }

            if (String.IsNullOrEmpty(name))
            {
                return APIResultModel.GetErrorResult("材料名称不能为空");
            }

            if (price != priceMain + priceArtificial)
            {
                return APIResultModel.GetErrorResult("请输入正确的总价格（材料价格 + 人工价格）");
            }

            if (priceMain <= 0)
            {
                return APIResultModel.GetErrorResult("请输入材料价格");
            }

            if (priceArtificial <= 0)
            {
                return APIResultModel.GetErrorResult("请输入人工价格");
            }

            return _materialBLL.UpDataMaterials(id, name, unit, price, priceMain, priceArtificial, remark);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel DeleteMaterial(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }
            return _materialBLL.DeleteMaterial(id);
        }

        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel BatchDeleteMaterial(List<string> ids)
        {
            if (ids == null || ids.Count <= 0)
            {
                return APIResultModel.GetErrorResult("ids不能为空");
            }
            return _materialBLL.BatchDeleteMaterial(ids);
        }

        /// <summary>
        /// 获取下拉项数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public APIResultModel GetOPtionList(string ordersId)
        {
            return _materialBLL.GetOPtionList(ordersId);
        }

    }
}
