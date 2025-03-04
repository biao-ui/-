using BLL;
using Commo;
using Entity;
using Entity.DTO;
using IBLL;
using Microsoft.AspNetCore.Mvc;

namespace DecorationSystem.Controllers
{
    public class MenuInfoController : Controller
    {
        IMenulnfoBLL _menulnfoBLl;
        public MenuInfoController(IMenulnfoBLL menulnfoBLl)
        {
            _menulnfoBLl = menulnfoBLl;
        }


        /// <summary>
        /// 菜单的视图页
        /// </summary>
        /// <returns></returns>
        public IActionResult TableMenuInfoIndex()
        {
            return View();
        }
        /// <summary>
        /// 添加页
        /// </summary>
        /// <returns></returns>
        public IActionResult AddIndex()
        {
            return View();
        }
        /// <summary>
        /// 修改页
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateMenuInfoView()
        {
            return View();
        }

        public IActionResult DeateView()
        {
            return View();
        }
  
        /// <summary>
        /// 菜单视图渲染
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public APIResultModel TableMenuInfo(int page, int limit, string title)
        {
            if (page <= 0)
            {
                return APIResultModel.GetErrorResult("页面不能小于0");
            }
            if (limit <= 0)
            {
                return APIResultModel.GetErrorResult("显示数据不能小于0");
            }
            //MyDbContext dbContext = new MyDbContext();

            //IQueryable<MenuInfo> list = dbContext.MenuInfo.Where(x => x.IsDelete == false);
            //if (!string.IsNullOrEmpty(title))
            //{
            //    list = dbContext.MenuInfo.Where(x => x.Title.Contains(title));
            //}

            //List<MenuInfoModel> res = list.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit).Take(limit).Select(e => new MenuInfoModel()
            //{

            //    CreateTime = e.CreateTime.ToString("yyyy-mm-dd HH:mm:ss"),
            //    Id = e.Id,
            //    Sort = e.Sort,
            //    Level = e.Level,
            //    Description = e.Description,
            //    Href = e.Href,
            //    Icon = e.Icon,
            //    ParentId = e.ParentId,
            //    Target = e.Target,
            //    Title = e.Title,

            //}).ToList();
            //int count = dbContext.MenuInfo.Count();
            //return APIResultModel.GetSuccessResultForLayui("成功", count, res);
            return _menulnfoBLl.TableMenuInfo(page, limit, title);
        }

        /// <summary>
        /// 下拉框获取
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetLsitMenuInfo(string numId)
        {
            return _menulnfoBLl.GetLsitMenuInfo(numId);
        }

        /// <summary>
        /// 找出添加的下拉数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel AddGetLsitMenuInfo()
        {
            return _menulnfoBLl.AddGetLsitMenuInfo();
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="level"></param>
        /// <param name="sort"></param>
        /// <param name="href"></param>
        /// <param name="parentId"></param>
        /// <param name="icon"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel AddIndex(string title, string description, int level, int sort, string href, string parentId, string icon, string target)
        {

            if (string.IsNullOrWhiteSpace(title))
            {
                return APIResultModel.GetErrorResult("标题不能为空");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return APIResultModel.GetErrorResult("我是标题不能为空");
            }
            if (level <= 0)
            {
                return APIResultModel.GetErrorResult("等级不能小于0或者等于0");
            }
            if (sort <= 0)
            {
                return APIResultModel.GetErrorResult("排序不能小于0或者等于0");
            }
          
            if (string.IsNullOrWhiteSpace(icon))
            {
             return   APIResultModel.GetErrorResult("图标样式不能为空");
            }
            if (string.IsNullOrWhiteSpace(target))
            {
                return APIResultModel.GetErrorResult("目标样式不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //MenuInfo employee = dbContext.MenuInfo.FirstOrDefault(e => e.Title == title);
            //if (employee != null)
            //{

            //    return APIResultModel.GetErrorResult("此标题已存在");
            //}
            //MenuInfo enti = new MenuInfo();
            //enti.Id = Guid.NewGuid().ToString();
            //enti.Description = description;
            //enti.Level = level;
            //enti.Sort = sort;
            //enti.Href = href;
            //enti.ParentId = Guid.NewGuid().ToString();
            //enti.Title = title;
            //enti.Target = target;
            //enti.CreateTime = DateTime.Now;
            //enti.Icon = icon;
            //dbContext.MenuInfo.Add(enti);
            //dbContext.SaveChanges();
            //return APIResultModel.GetSuccessResult("添加成功");
            return _menulnfoBLl.AddIndex(title, description, level, sort, href, parentId, icon, target);

        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel DeleteMenuInfo(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //MenuInfo employee = dbContext.MenuInfo.FirstOrDefault(e => e.Id == id);
            //if (employee != null)
            //{
            //    employee.IsDelete = true;
            //    employee.DeleteTime = DateTime.Now;
            //    dbContext.SaveChanges();
            //    return APIResultModel.GetSuccessResult("删除成功");
            //}
            //else
            //{
            //    return APIResultModel.GetErrorResult("删除失败");
            //}
            return _menulnfoBLl.DeleteMenuInfo(id);

        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel BatchDeleteMenuInfo(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return APIResultModel.GetErrorResult("编号不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //foreach (var id in ids)
            //{
            //    MenuInfo employee = dbContext.MenuInfo.FirstOrDefault(e => e.Id == id);
            //    if (employee != null)
            //    {
            //        employee.IsDelete = true;
            //        employee.DeleteTime = DateTime.Now;

            //    }
            //}
            //int index = dbContext.SaveChanges();
            //return APIResultModel.GetSuccessResult("删除成功");
            return _menulnfoBLl.BatchDeleteMenuInfo(ids);
        }

        public APIResultModel UpdatGet(string id)
        {
            //MyDbContext dbContext = new MyDbContext();
            //MenuInfo employee = dbContext.MenuInfo.FirstOrDefault(x => x.Id == id);
            //return APIResultModel.GetErrorResult("成功", employee);
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("编号不能为空");
            }
            return _menulnfoBLl.UpdatGet(id);
        }
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="level"></param>
        /// <param name="sort"></param>
        /// <param name="href"></param>
        /// <param name="icon"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel UpdatRoleInfo(string id, string title, string description, int level, int sort, string href, string icon, string target , string parentId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return APIResultModel.GetErrorResult("标题不能为空");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return APIResultModel.GetErrorResult("我是标题不能为空");
            }
            if (level <= 0)
            {
                return APIResultModel.GetErrorResult("等级不能小于0或者等于0");
            }
            if (sort <= 0)
            {
                return APIResultModel.GetErrorResult("排序不能小于0或者等于0");
            }
          
            if (string.IsNullOrWhiteSpace(icon))
            {
                return APIResultModel.GetErrorResult("图标样式不能为空");
            }
            if (string.IsNullOrWhiteSpace(target))
            {
                return APIResultModel.GetErrorResult("目标样式不能为空");
            }

            return _menulnfoBLl.UpdatRoleInfo(id, title, description, level, sort, href, icon, target, parentId);
        }

        /// <summary>
        /// 菜单表
        /// </summary>
        /// <returns></returns>
        public object GetHomeMenuList()
        {
          string employeeId =HttpContext.Session.GetString("currentEmployee");
            if (string.IsNullOrEmpty(employeeId))
            {
                return null;
            }
            return  _menulnfoBLl.GetHomeMenuList(employeeId);
       }



    }
}
