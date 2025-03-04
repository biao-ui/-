using BLL;
using Commo;
using Entity;
using Entity.DTO;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Numerics;

namespace DecorationSystem.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBLL _employeeBLL;
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }

        /// <summary>
        /// 注册页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 视图页
        /// </summary>
        /// <returns></returns>
        public IActionResult TableEmployeeIndex()
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
        /// 员工修改页
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateEmployeeView()
        {
            return View();
        }
        /// <summary>
        /// 修改密码页
        /// </summary>
        /// <returns></returns>
        public IActionResult EmployeePassword()
        {
            return View();
        }
        /// <summary>
        ///修改基本信息页面
        /// </summary>
        /// <returns></returns>
        public IActionResult EmployeeInfoView()
        {
            return View();
        }
        /// <summary>
        /// 注册功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel Employeev(string account, string password)
        {
            if (string.IsNullOrEmpty(account))
            {
                return APIResultModel.GetErrorResult("账号不能为空");
            }
            if (string.IsNullOrEmpty(password))
            {
                return APIResultModel.GetErrorResult("密码不能为空不能为空");
            }
            //MyDbContext myDbContext = new MyDbContext();

            //var arr = myDbContext.Employee.FirstOrDefault(x => x.Account == account);
            //if (arr != null)
            //{
            //    return APIResultModel.GetErrorResult("此账号已存在");
            //}
            //string newPassword = MD5Helper.GetMD5(password);
            //Employee employee = new Employee();
            //employee.Id = Guid.NewGuid().ToString();
            //employee.Account = account;
            //employee.Password = newPassword;
            //employee.Name = account;
            //employee.CreateTime = DateTime.Now;
            //myDbContext.Add(employee);
            //myDbContext.SaveChanges();



            //return APIResultModel.GetSuccessResult("注册成功");



            return _employeeBLL.Employeev(account, password);
        }


        /// <summary>
        /// 试图的渲染
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel TableEmployee(int page, int limit, string name, string account)
        {
            if (page <= 0)
            {
                APIResultModel.GetErrorResult("页码有误");
            }

            if (limit <= 0)
            {
                APIResultModel.GetErrorResult("数量有误");
            }

            return _employeeBLL.TableEmployee(page, limit, name, account);
            //MyDbContext dbContext = new MyDbContext();

            ////IQueryable<Employee> list = dbContext.Employee.Where(x=>x.lsDelete ==false);
            //var list = from e in dbContext.Employee.Where(x => x.lsDelete == false)
            //           join r in dbContext.RoleInfo.Where(x => x.IsDelete == false)
            //           on e.RoleId equals r.Id
            //           into rempR from rr in rempR.DefaultIfEmpty()
            //           select new
            //           {
            //               e.Id,
            //               e.Name,
            //               e.Account,
            //               e.CreateTime,
            //               e.Phone,
            //               RoleName = rr.Name
            //           };


            //if (!string.IsNullOrEmpty(name))
            //{
            //    list = list.Where(x => x.Name.Contains(name));
            //}
            //if (!string.IsNullOrEmpty(account))
            //{
            //    list = list.Where(x => x.Account.Contains(account));
            //}
            //var res = list.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit).Take(limit).ToList().Select(item =>
            //{
            //    return new
            //    {
            //        CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
            //        item.Name,
            //        item.Account,
            //        item.Id,
            //        item.RoleName,
            //        item.Phone
            //    };

            //}).ToList();
            //int count = dbContext.Employee.Count();
            //return APIResultModel.GetSuccessResultForLayui("成功", count, res);

        }
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel AddIndex(string account, string password, string name, string phone, string roleId)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                APIResultModel.GetErrorResult("账号不能为空");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                APIResultModel.GetErrorResult("密码不能为空");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                APIResultModel.GetErrorResult("名字不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Employee employee = dbContext.Employee.FirstOrDefault(e => e.Account == account);
            //if (employee != null)
            //{

            //    APIResultModel.GetErrorResult("账号已存在");
            //}
            //Employee enti = new Employee();
            //enti.Id = Guid.NewGuid().ToString();
            //enti.Account = account;
            //enti.Password = password;
            //enti.Name = name;
            //enti.Phone = phone;
            //enti.RoleId = roleId;
            //enti.CreateTime = DateTime.Now;
            //dbContext.Employee.Add(enti);
            //dbContext.SaveChanges();
            //return APIResultModel.GetSuccessResult("添加成功");
            return _employeeBLL.AddIndex(account, password, name, phone, roleId);

        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel DeleteEmployee(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id有误");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Employee employee = dbContext.Employee.FirstOrDefault(e => e.Id == id);
            //if (employee != null)
            //{
            //    employee.lsDelete = true;
            //    employee.DeleteTime = DateTime.Now;
            //    dbContext.SaveChanges();
            //    return APIResultModel.GetSuccessResult("删除成功");
            //}
            //else
            //{
            //    return APIResultModel.GetErrorResult("删除失败");
            //}

            return _employeeBLL.DeleteEmployee(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel BatchDeleteEmployee(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return APIResultModel.GetErrorResult("ids参数有误");
            }
            return _employeeBLL.BatchDeleteEmployee(ids);
        }

        /// <summary>
        /// 员工修改页渲染数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id参数有误");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Employee employee = dbContext.Employee.FirstOrDefault(x => x.Id == id);
            //return APIResultModel.GetErrorResult("成功", employee);
            return _employeeBLL.UpdatGet(id);
        }
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel UpdatEmployee(string id, string name, string phone, string roleId)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id参数有误");
            }
            if (string.IsNullOrEmpty(name))
            {
                return APIResultModel.GetErrorResult("名字不能为空");
            }
            return _employeeBLL.UpdatEmployee(id, name, phone, roleId);

            //MyDbContext dbContext = new MyDbContext();
            //Employee Employee = dbContext.Employee.FirstOrDefault(x => x.Id == id);
            //if (Employee != null)
            //{
            //    Employee.Name = name;
            //    Employee.Phone = phone;
            //    Employee.RoleId = roleId;
            //    dbContext.SaveChanges();
            //    return APIResultModel.GetSuccessResult("修改成功");

            //}
            //else
            //{
            //    return APIResultModel.GetErrorResult("修改失败");
            //}
        }

        /// <summary>
        /// 下拉框的获取数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOptionList()
        {
            //MyDbContext dbContext = new MyDbContext();
            //var list = dbContext.RoleInfo.Where(x => x.IsDelete == false).Select(x => new
            //{
            //    x.Id,
            //    x.Name
            //}).ToList();
            //return APIResultModel.GetErrorResult("成功", list);
            return _employeeBLL.GetOptionList();
        }
        /// <summary>
        ///基本信息渲染
        /// </summary>
        /// <returns></returns>
        public APIResultModel EmployeeInfo()
        {

            string employeeId = HttpContext.Session.GetString("currentEmployee");
            if (string.IsNullOrEmpty(employeeId))
            {
                return APIResultModel.GetErrorResult("请重新登录");
            }
            return _employeeBLL.EmployeeInfo(employeeId);
        }
        /// <summary>
        /// 基本信息的添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel EmployeeInfoAdd(string name, string phone)
        {
            if (string.IsNullOrEmpty(name))
            {
                return APIResultModel.GetErrorResult("名字不能为空");
            }
            string employeeId = HttpContext.Session.GetString("currentEmployee");
            if (string.IsNullOrEmpty(employeeId))
            {
                return APIResultModel.GetErrorResult("请重新登录");
            }
            return _employeeBLL.EmployeeInfoAdd(employeeId, name, phone);
        }
        /// <summary>
        /// 获取登录人的头像
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetEmployeePhoto()
        {
            string employeeId = HttpContext.Session.GetString("currentEmployee");
            if (string.IsNullOrEmpty(employeeId))
            {
                return APIResultModel.GetErrorResult("请重新登录");
            }
            return _employeeBLL.GetEmployeePhoto(employeeId);
        }

        /// <summary>
        /// 修改密码功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel EmployeePassword(string id, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetSuccessResult("编号不能为空");
            }
            if (string.IsNullOrEmpty(oldPassword))
            {
                return APIResultModel.GetErrorResult("旧密码不能为空");
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                return APIResultModel.GetErrorResult("新密码不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Employee employee = dbContext.Employee.FirstOrDefault(x => x.Id == id);
            //if (employee == null)
            //{
            //    return APIResultModel.GetErrorResult("此人不存在");
            //}
            //string oldMDPassword = MD5Helper.GetMD5(oldPassword);
            //if (employee.Password != oldMDPassword)
            //{
            //    return APIResultModel.GetErrorResult("与旧密码不一致");
            //}
            //string newMDPassword = MD5Helper.GetMD5(newPassword);
            //employee.Password = newMDPassword;


            APIResultModel rse = _employeeBLL.EmployeePassword(id, oldPassword, newPassword);
            if (rse.Count == 0)
            {
                HttpContext.Session.Remove("isLogin");
            }
            return rse;
            //dbContext.SaveChanges();
            //HttpContext.Session.Remove("isLogin");
            //return APIResultModel.GetSuccessResult("修改成功");
        }

        /// <summary>
        /// 头像上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public APIResultModel Upload(IFormFile file)
        {
            if (!file.FileName.Contains(".png") &&  !file.FileName.Contains(".jpg"))
            {
                return APIResultModel.GetErrorResult("请选择png或jpg格式的图片");
            }
            if (file.Length >= (2*1024*1024) )
            {
                return APIResultModel.GetErrorResult("选择图片必须小于等于2MB");
            }
            string employeeId = HttpContext.Session.GetString("currentEmployee");
            if (string.IsNullOrEmpty(employeeId))
            {
                return APIResultModel.GetErrorResult("请重新登录");
            }
            Stream uploadStream = file.OpenReadStream();
            return _employeeBLL.Upload(uploadStream, file.FileName, employeeId);

        }
        /// <summary>
        /// 头像下载
        /// </summary>
        /// <returns></returns>
        public IActionResult Dowload()
        {
            string employeeId = HttpContext.Session.GetString("currentEmployee");
            if (string.IsNullOrEmpty(employeeId))
            {
                return null;
            }
            string oldFileNaem;
            Stream fileStream = _employeeBLL.Dowload(employeeId,out oldFileNaem);
            if (fileStream == null)
            {
                return null;
            }

            return File(fileStream, "application/octet-stream", oldFileNaem);
        }
        /// <summary>
        /// 名单导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public APIResultModel Import(IFormFile file)
        {
            if (!file.FileName.Contains(".xlsx") && !file.FileName.Contains(".xls"))
            {
                return APIResultModel.GetErrorResult("请选择xlsx或xls格式的表格");
            }
            if (file.Length >= (2 * 1024 * 1024))
            {
                return APIResultModel.GetErrorResult("选择文件必须小于等于2MB");
            }
        
            Stream uploadStream = file.OpenReadStream();

            //return _employeeBLL.Upload(uploadStream, file.FileName, employeeId);
            return _employeeBLL.Import(uploadStream, file.FileName); 
        }
        /// <summary>
        /// excel文件下载
        /// </summary>
        /// <returns></returns>
        public IActionResult Export()
        {
          
      
            Stream fileStream = _employeeBLL.Export();
            if (fileStream ==  null)
            {
                return null;
            }

            return File(fileStream, "application/octet-stream", "导出的名单.xlsx");
        }
    }
}
