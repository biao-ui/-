
using BLL;
using Commo;
using Entity;
using IBLL;
using Microsoft.AspNetCore.Mvc;

namespace DecorationSystem.Controllers
{
    public class LogInController : Controller
    {
        ILogInBLL _logInBLL;
        public LogInController(ILogInBLL logInBLL)
        {
            _logInBLL = logInBLL;
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录效果
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public APIResultModel Login(string account, string password)
        {
            if (string.IsNullOrEmpty(account))
            {
                return APIResultModel.GetErrorResult("账号不能为空");
            }
            if (string.IsNullOrEmpty(password))
            {
                return APIResultModel.GetErrorResult("密码不能为空");
            }
            string employeeName = null;
            string employeeId = null;
           APIResultModel res =  _logInBLL.Login(account, password,out employeeName,out employeeId);
            if (res.Code == 0)
            {
                HttpContext.Session.SetString("isLogin", employeeName);
                HttpContext.Session.SetString("currentEmployee", employeeId);
            }

            return res;
             
            //MyDbContext dbContext = new MyDbContext();
            //var arr = dbContext.Employee.FirstOrDefault(x => x.Account == account);
            //string newpassword = MD5Helper.GetMD5(password);
            //if (arr.Password != newpassword)
            //{
            //    return APIResultModel.GetErrorResult("密码错误");


            //}
           ;
            //return APIResultModel.GetErrorResult("登录成功", new
            //{
            //    arr.Name,
            //    arr.Id
            //});

        }

        public APIResultModel Logtu()
        {
            HttpContext.Session.Remove("isLogin");
            return APIResultModel.GetSuccessResult("退出登录成功");
        }
    }
}
