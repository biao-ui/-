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
    public class OrdersBLL : BaseDAL<Orders>, IOrdersBLL
    {
        //MyDbContext _dbContext = new MyDbContext();
        MyDbContext _dbContext;
        IOrdersDAL _OrdersDAL;
        IEmployeeDAL _EmployeeDAL;
        IOrdersMaterialDAL _OrdersMaterialDAL;
        IMaterialDAL _materialDAL;
        public OrdersBLL(MyDbContext myDbContext, IOrdersDAL ordersDAL, IEmployeeDAL employeeDAL, IOrdersMaterialDAL ordersMaterialDAL, IMaterialDAL materialDAL) : base(myDbContext)
        {
            _dbContext = myDbContext;
            _OrdersDAL = ordersDAL;
            _EmployeeDAL = employeeDAL;
            _OrdersMaterialDAL = ordersMaterialDAL;
            _materialDAL = materialDAL;
        }

        /// <summary>
        /// 为订单选择材料
        /// </summary>
        /// <param name="ordersId"></param>
        /// <param name="materialId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public APIResultModel ChooseOrdersMaterial(string materialId, string ordersId, int num)
        {
            //查询当前订单有哪些材料已经被选择过了(已经被选择过的材料id)
            List<string> materialIds = _OrdersMaterialDAL.GetDbSet().Where(o => o.OrdersId == ordersId).Select(o => o.Materialld).ToList();
            //重复的材料不能绑定
            if (materialIds.Contains(materialId))
            {
                return APIResultModel.GetErrorResult("当前材料已经绑定了，请刷新页后重试");
            }


            OrdersMaterial entlily = new OrdersMaterial();

            entlily.OrdersId = ordersId;
            entlily.Num = num;
            entlily.Materialld = materialId;
            entlily.Id = Guid.NewGuid().ToString();
            entlily.CreateTime = DateTime.Now;

            bool isSucess = _OrdersMaterialDAL.Create(entlily);
            if (isSucess)
            {
                return APIResultModel.GetSuccessResult("成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("添加失败");
            }

        }

        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="password"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel CreateOrders(string customerName, string customPhone, string address, double ares, DateTime startTime, DateTime endTime, string designerId, string remark)
        {

            Orders entlily = new Orders();

            entlily.CustomerName = customerName;
            entlily.CustomPhone = customPhone;
            entlily.Id = Guid.NewGuid().ToString();
            entlily.CreateTime = DateTime.Now;
            entlily.Address = address;
            entlily.Ares = ares;
            entlily.DesignerId = designerId;
            entlily.Remark = remark;
            entlily.StartTime = startTime;
            entlily.EndTime = endTime;

            //_dbContext.SaveChanges();

            bool isSucess = _OrdersDAL.Create(entlily);
            if (isSucess)
            {
                return APIResultModel.GetSuccessResult("成功");
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
        public Orders GetOrders(string id)
        {
            Orders orders = _OrdersDAL.GetEntityById(id);

            return orders;
        }
        /// <summary>
        /// 多条查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel GetListOrderss(int page, int limit, string customerName, string customPhone)
        {
            int count = _OrdersDAL.GetDbSet().Count();

            //IQueryable<Orders> query = _OrdersDAL.GetDbSet().Where(e => e.IsDelete == false);

            //if (!String.IsNullOrEmpty(customerName))
            //{
            //    query = query.Where(e => e.CustomerName.Contains(customerName));
            //}

            var query = from o in _OrdersDAL.GetDbSet().Where(n => !n.IsDelete)
                        join e in _EmployeeDAL.GetDbSet().Where(e => !e.IsDelete)
                        on o.DesignerId equals e.Id
                        into tempE
                        from ee in tempE.DefaultIfEmpty()
                        select new
                        {
                            o.Id,
                            o.Ares,
                            o.Address,
                            o.CustomerName,
                            o.CustomPhone,
                            o.EndTime,
                            o.StartTime,
                            o.CreateTime,
                            o.Remark,
                            Designer = ee.Name
                        };


            //使用匿名方法处理时间格式
            var resList = query.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit)
                .Take(limit).ToList().Select(item =>
                {
                    return new
                    {
                        CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        item.CustomerName,
                        item.Id,
                        item.Remark,
                        item.CustomPhone,
                        item.Address,
                        StartTime = item.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        item.Ares,
                        EndTime = item.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        item.Designer,
                        TotalPrice = 0
                    };
                }).ToList();

            //为当前查询的所有订单找到他的总价格
            var tempDatas = (from o in _OrdersDAL.GetDbSet().Where(o => !o.IsDelete)
                             join om in _OrdersMaterialDAL.GetDbSet()
                             on o.Id equals om.OrdersId
                             join m in _materialDAL.GetDbSet().Where(m => !m.IsDelete)
                             on om.Materialld equals m.Id
                             select new
                             {
                                 o.Id,
                                 o.CustomerName,
                                 m.Name,
                                 om.Num,
                                 m.Price,
                                 toral = m.Price * om.Num
                             }).ToList();

            var groupDatas = tempDatas.GroupBy(o => o.Id).Select(groupData =>
            {
                return new
                {
                    OrdersId = groupData.Key,
                    TotalPrice = groupData.ToList().Sum(item => item.toral)
                };
            }).ToList();

            List<Object> res = new List<Object>();

            foreach (var item in resList)
            {
                var groupData = groupDatas.FirstOrDefault(g => g.OrdersId == item.Id);

                if (groupData == null)
                {
                    res.Add(new
                    {
                        item.CreateTime,
                        item.CustomerName,
                        item.Id,
                        item.Remark,
                        item.CustomPhone,
                        item.Address,
                        item.StartTime,
                        item.Ares,
                        item.EndTime,
                        item.Designer,
                        TotalPrice = 0
                    });
                }
                else
                {
                    res.Add(new
                    {
                        item.CreateTime,
                        item.CustomerName,
                        item.Id,
                        item.Remark,
                        item.CustomPhone,
                        item.Address,
                        item.StartTime,
                        item.Ares,
                        item.EndTime,
                        item.Designer,
                        groupData.TotalPrice
                    });
                }
            }

            return APIResultModel.GetSuccessResultForLayui("成功", count, res);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phon"></param>
        /// <returns></returns>
        public APIResultModel UpDataOrderss(string id, string customerName, string customPhone, string address, int ares, DateTime startTime, DateTime endTime, string designerId, string? remark)
        {

            Orders Orders = _OrdersDAL.GetEntityById(id);

            if (Orders != null)
            {
                Orders.CustomerName = customerName;
                Orders.Remark = remark;
                Orders.CustomPhone = customPhone;
                Orders.Address = address;
                Orders.Ares = ares;
                Orders.StartTime = startTime;
                Orders.EndTime = endTime;
                Orders.DesignerId = designerId;

                bool isSucess = _OrdersDAL.Update(Orders);
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
        public APIResultModel DeleteOrders(string id)
        {

            Orders Orders = _dbContext.Orders.FirstOrDefault(e => e.Id == id);
            if (Orders != null)
            {
                Orders.IsDelete = true;
                Orders.DeleteTime = DateTime.Now;

                bool isSucess = _OrdersDAL.Update(Orders);
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
        public APIResultModel BatchDeleteOrders(List<string> ids)
        {
            foreach (string id in ids)
            {
                Orders Orders = _dbContext.Orders.FirstOrDefault(e => e.Id == id);
                if (Orders != null)
                {
                    //dbContext.Orders.Remove(Orders);
                    Orders.IsDelete = true;
                    Orders.DeleteTime = DateTime.Now;

                    bool isSucess = _OrdersDAL.Update(Orders);
                }
            }
            //_dbContext.SaveChanges();
            return APIResultModel.GetSuccessResult("删除成功");
        }
        ///// <summary>
        /// 获取下拉项数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOrdersList()
        {
            var list = _EmployeeDAL.GetDbSet().Where(r => r.IsDelete == false).Select(r => new
            {
                r.Id,
                r.Name
            }).ToList();
            var lists = list.Where(r => r.Name != "超级管理员").ToList();
            return APIResultModel.GetErrorResult("成功", lists);
        }

        /// <summary>
        /// 为订单材料显示
        /// </summary>
        /// /// <returns></returns>
        public APIResultModel GetOrdersMaterialList(int page, int limit, string ordersId, string materialId)
        {
            int count = _OrdersMaterialDAL.GetDbSet().Count();

            //IQueryable<Orders> query = _OrdersDAL.GetDbSet().Where(e => e.IsDelete == false);

            //if (!String.IsNullOrEmpty(customerName))
            //{
            //    query = query.Where(e => e.CustomerName.Contains(customerName));
            //}

            //材料表数据集
            var materialQuery = _materialDAL.GetDbSet().Where(m => !m.IsDelete);
            if (!string.IsNullOrEmpty(materialId))
            {
                materialQuery = materialQuery.Where(m => m.Id == materialId);
            }

            var query = from o in _OrdersMaterialDAL.GetDbSet().Where(n => n.OrdersId == ordersId)
                        join e in _OrdersDAL.GetDbSet().Where(e => !e.IsDelete)
                        on o.OrdersId equals e.Id

                        join m in materialQuery
                        on o.Materialld equals m.Id
                        select new
                        {
                            o.Id,
                            e.CustomerName,
                            e.CustomPhone,
                            e.Address,
                            MaterialTitle = m.Name,
                            o.Num,
                            m.Price,
                            o.CreateTime,
                            Prices = o.Num * m.Price
                        };


            //使用匿名方法处理时间格式
            var resList = query.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit)
                .Take(limit).ToList().Select(item =>
                {
                    return new
                    {
                        CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        item.CustomerName,
                        item.Id,
                        item.CustomPhone,
                        item.Address,
                        item.MaterialTitle,
                        item.Price,
                        item.Num,
                        item.Prices
                    };
                }).ToList();

            return APIResultModel.GetSuccessResultForLayui("成功",count, resList);
        }

        /// <summary>
        /// 材料删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteMaterialOrders(string id)
        {

            OrdersMaterial entity = _dbContext.OrdersMaterial.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
               

                bool isSucess = _OrdersMaterialDAL.Update(entity);
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
        /// 多条材料删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteMaterialOrders(List<string> ids)
        {
            foreach (string id in ids)
            {
                OrdersMaterial entity = _dbContext.OrdersMaterial.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    //dbContext.Orders.Remove(Orders);
                
                    bool isSucess = _OrdersMaterialDAL.Delete(entity.Id);
                }
            }
            //_dbContext.SaveChanges();
            return APIResultModel.GetSuccessResult("删除成功");
        }

        /// <summary>
        /// 获取打印页数据
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public APIResultModel GetPrintDatas(string ordersId)
        {
            var list = (from om in _OrdersMaterialDAL.GetDbSet().Where(om =>om.OrdersId == ordersId)
                        join m in _materialDAL.GetDbSet().Where(m => !m.IsDelete)
                        on om.Materialld equals m.Id
                        select new
                        {
                            m.Name,
                            m.Unit,
                            om.Num,
                            m.Price,
                            Total = om.Num * m.Price,
                            m.PriceMain,
                            m.PriceArtificial,
                            m.Remark
                        }).ToList();

            return APIResultModel.GetErrorResult("成功",list);
        }
    }
}
