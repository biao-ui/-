using Commo;
using Entity.DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using BLL;
using IBLL;

namespace DecorationSystem.Controllers
{
    public class RoleInfoController : Controller
    {

        IRolelnfoBLL _rolelnfoBLL;
        public RoleInfoController(IRolelnfoBLL rolelnfoBLL)
        {
            _rolelnfoBLL = rolelnfoBLL;
        }

        /// <summary>
        /// 角色视图渲染页
        /// </summary>
        /// <returns></returns>
        public IActionResult TableRoleInfoIndex()
        {
            return View();
        }
        /// <summary>
        /// 添加视图
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
        public IActionResult UpdateRoleInfoView()
        {
            return View();
        }
        /// <summary>
        /// 绑定员工页
        /// </summary>
        /// <returns></returns>
        public IActionResult BindEmployeeView()
        {
            return View();
        }

        /// <summary>
        ///菜单绑定页
        /// </summary>
        /// <returns></returns>
        public IActionResult BinMenuInfoView()
        {
            return View();
        }
        /// <summary>
        ///角色视图渲染
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel TableRoleInfo(int page, int limit, string name)
        {

            if (page <= 0)
            {
                return APIResultModel.GetErrorResult("页数有误");
            }
            if (limit <= 0)
            {
                return APIResultModel.GetErrorResult("显示数据不能小于0");
            }
            return _rolelnfoBLL.TableRoleInfo(page, limit, name);

        }

        [HttpPost]
        public APIResultModel AddIndex(string name, string remark)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                APIResultModel.GetErrorResult("名字不能为空");
            }
            // MyDbContext dbContext = new MyDbContext();
            // RoleInfo employee = dbContext.RoleInfo.FirstOrDefault(e => e.Name == name);
            // if (employee != null)
            // {

            //     APIResultModel.GetErrorResult("账号已存在");
            // }
            // RoleInfo enti = new RoleInfo();
            // enti.Id = Guid.NewGuid().ToString();
            //enti.Remark = remark;
            // enti.Name = name;
            // enti.CreateTime = DateTime.Now;
            // dbContext.RoleInfo.Add(enti);
            // dbContext.SaveChanges();
            // return APIResultModel.GetSuccessResult("添加成功");
            return _rolelnfoBLL.AddIndex(name, remark);

        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel DeleteRoleInfo(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                APIResultModel.GetErrorResult("id不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //RoleInfo employee = dbContext.RoleInfo.FirstOrDefault(e => e.Id == id);
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
            return _rolelnfoBLL.DeleteRoleInfo(id);

        }
        /// <summary>
        /// 批量删除功能
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel BatchDeleteRoleInfo(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return APIResultModel.GetErrorResult("ids不给空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //foreach (var id in ids)
            //{
            //    RoleInfo employee = dbContext.RoleInfo.FirstOrDefault(e => e.Id == id);
            //    if (employee != null)
            //    {
            //        employee.IsDelete = true;
            //        employee.DeleteTime = DateTime.Now;

            //    }
            //}
            //int index = dbContext.SaveChanges();
            //return APIResultModel.GetSuccessResult("删除成功");
            return _rolelnfoBLL.BatchDeleteRoleInfo(ids);

        }
        /// <summary>
        /// 修改页的渲染数据功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("ids不给空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //RoleInfo employee = dbContext.RoleInfo.FirstOrDefault(x => x.Id == id);
            //return APIResultModel.GetErrorResult("成功", employee);
            return _rolelnfoBLL.UpdatGet(id);
        }
        /// <summary>
        /// 角色修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel UpdatRoleInfo(string id, string name, string remark)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id不能为空");
            }
            return _rolelnfoBLL.UpdatRoleInfo(id, name, remark);
            //MyDbContext dbContext = new MyDbContext();
            //RoleInfo RoleInfo = dbContext.RoleInfo.FirstOrDefault(x => x.Id == id);
            //if (RoleInfo != null)
            //{
            //    RoleInfo.Name = name;
            //    RoleInfo.Remark = remark;

            //    dbContext.SaveChanges();
            //    return APIResultModel.GetSuccessResult("修改成功");

            //}
            //else
            //{
            //    return APIResultModel.GetErrorResult("修改失败");
            //}
        }

        /// <summary>
        /// 穿梭框的获取
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetTransferOptionList(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                return APIResultModel.GetErrorResult("角色id有误");
            }
            //MyDbContext dbContext = new MyDbContext();
            //var list = dbContext.Employee .Where(x => (x.lsDelete == false &&x.RoleId == null)||(x.lsDelete==false && x.RoleId == roleId )).Select(x => new
            //{
            //    Value =  x.Id,
            //    Title=  x.Name
            //}).ToList();
            ////已绑定用户id
            //List<string> employeeIds = dbContext.Employee.Where(e => e.lsDelete == false && e.RoleId == roleId).Select(e => e.Id).ToList();


            //return APIResultModel.GetErrorResult("成功", new
            //{
            //    list,
            //    employeeIds
            //} );
            return _rolelnfoBLL.GetTransferOptionList(roleId);
        }
        /// <summary>
        /// 绑定员工
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel BindEmployee(int index, string roleId, List<string> employeeIds)
        {
            if (index < 0 || index > 1)
            {
                return APIResultModel.GetErrorResult("无法识别到绑定还是解绑");
            }
            return _rolelnfoBLL.BindEmployee(index, roleId, employeeIds);
            //MyDbContext dbContext = new MyDbContext();
            //List<Employee> employees = dbContext.Employee.Where(x => employeeIds.Contains(x.Id)).ToList();
            ////index:0是绑定,1是解绑
            //if (index == 0)
            //{
            //    foreach (Employee employee in employees)
            //    {
            //        employee.RoleId = roleId;
            //    }
            //}else if (index == 1)
            //{
            //    foreach (Employee employee in employees)
            //    {
            //        employee.RoleId = null;
            //    }
            //}else
            //{
            //    return APIResultModel.GetErrorResult("参数有误");
            //}

            //dbContext.SaveChanges();

            //return APIResultModel.GetSuccessResult("添加成功");

        }
        public APIResultModel GetMenulnfoOptionList(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                return APIResultModel.GetErrorResult("角色id有误");
            }
            return _rolelnfoBLL.GetMenulnfoOptionList(roleId);
        }

        public APIResultModel BinMenulnfo(int index, string roleId, List<string>? menuIds)
        {
            if (index <0)
            {
                return APIResultModel.GetErrorResult("不是绑定操作");
            }
            return _rolelnfoBLL.BinMenulnfo(index, roleId, menuIds);
        }

    }

}
