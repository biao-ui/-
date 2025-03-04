using Commo;
using DAL;
using Entity;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaterialBLL : BaseDAL<Material>, IMaterialBLL

    {
        //MyDbContext _dbContext = new MyDbContext();
        MyDbContext _dbContext;
        IMaterialDAL _MaterialDAL;
        IOrdersMaterialDAL _OrdersMaterialDAL;
        public MaterialBLL(MyDbContext myDbContext, IMaterialDAL materialDAL, IOrdersMaterialDAL ordersMaterialDAL) : base(myDbContext)
        {
            _dbContext = myDbContext;
            _MaterialDAL = materialDAL;
            _OrdersMaterialDAL = ordersMaterialDAL;
        }

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="password"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel CreateMaterial(string name, string unit, double price, double priceMain, double priceArtificial, string? remark)
        {
            // Material Material = _MaterialDAL.GetDbSet().FirstOrDefault(x => x.Name == name);

            Material entlily = new Material();

            entlily.Name = name;
            entlily.Unit = unit;
            entlily.Id = Guid.NewGuid().ToString();
            entlily.CreateTime = DateTime.Now;
            entlily.Price = price;
            entlily.PriceMain = priceMain;
            entlily.PriceArtificial = priceArtificial;
            entlily.Remark = remark;

            //_dbContext.SaveChanges();

            bool isSucess = _MaterialDAL.Create(entlily);
            if (isSucess)
            {
                return APIResultModel.GetSuccessResult("添加成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("添加失败");
            }

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Material GetMaterial(string id)
        {
            Material material = _MaterialDAL.GetEntityById(id);

            return material;
        }
        /// <summary>
        /// 多条查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel GetListMaterials(int page, int limit, string name)
        {
            int count = _MaterialDAL.GetDbSet().Count();

            IQueryable<Material> query = _MaterialDAL.GetDbSet().Where(e => e.IsDelete == false);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }


            //使用匿名方法处理时间格式
            var resList = query.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit)
                .Take(limit).ToList().Select((Material item) =>
                {
                    return new
                    {
                        CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        item.Name,
                        item.Id,
                        item.Remark,
                        item.Price,
                        item.PriceMain,
                        item.PriceArtificial,
                        item.Unit
                    };
                }).ToList();

            return APIResultModel.GetSuccessResultForLayui("成功",count, resList);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phon"></param>
        /// <returns></returns>
        public APIResultModel UpDataMaterials(string id, string name, string unit, double price, double priceMain, double priceArtificial, string? remark)
        {

            Material Material = _MaterialDAL.GetEntityById(id);

            if (Material != null)
            {
                Material.Name = name;
                Material.Remark = remark;
                Material.Price = price;
                Material.PriceMain = priceMain;
                Material.Unit = unit;
                Material.PriceArtificial = priceArtificial;

                bool isSucess = _MaterialDAL.Update(Material);
                if (isSucess)
                {
                    return APIResultModel.GetSuccessResult("修改成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("修改失败");
                }
            }
            else
            {
                return APIResultModel.GetErrorResult("修改失败");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteMaterial(string id)
        {

            Material Material = _dbContext.Material.FirstOrDefault(e => e.Id == id);
            if (Material != null)
            {
                Material.IsDelete = true;
                Material.DeleteTime = DateTime.Now;
                Material.CreateTime = DateTime.Now;

                bool isSucess = _MaterialDAL.Update(Material);
                //_dbContext.SaveChanges();

                if (isSucess)
                {
                    return APIResultModel.GetSuccessResult("删除成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("删除失败");
                }
            }
            else
            {
                return APIResultModel.GetErrorResult("删除失败");
            }
        }
        /// <summary>
        /// 多条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteMaterial(List<string> ids)
        {
            foreach (string id in ids)
            {
                Material Material = _dbContext.Material.FirstOrDefault(e => e.Id == id);
                if (Material != null)
                {
                    //dbContext.Material.Remove(Material);
                    Material.IsDelete = true;
                    Material.DeleteTime = DateTime.Now;

                    bool isSucess = _MaterialDAL.Update(Material);
                }
            }
            //_dbContext.SaveChanges();
            return APIResultModel.GetSuccessResult("删除成功");
        }
        /// <summary>
        /// 获取下拉项数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOPtionList(string ordersId)
        {
            List<string> materialIds = _OrdersMaterialDAL.GetDbSet().Where(o => o.OrdersId == ordersId).Select(o => o.Materialld).ToList();

            var list = _MaterialDAL.GetDbSet().Where(m => !materialIds.Contains(m.Id) && !m.IsDelete).Select(r => new
            {
                r.Id,
                r.Name
            }).ToList();
            return APIResultModel.GetErrorResult("成功",list);
        }
    }
}
