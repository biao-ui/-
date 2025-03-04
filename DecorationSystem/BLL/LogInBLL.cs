using Commo;
using DAL;
using Entity;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogInBLL: ILogInBLL
    {
        IEmployeeDAL _employeeDAL;
        public LogInBLL(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        public APIResultModel Login(string account, string password,out string  employeeName ,out string employeeId)
        {
    
            var arr = _employeeDAL.Employeev(account);
            employeeId = "";
            employeeName = "";
            if (arr == null)
            {
                
                return APIResultModel.GetErrorResult("账号有误");
            }
            string newpassword = MD5Helper.GetMD5(password);
            if (arr.Password != newpassword)
            {
            
                return APIResultModel.GetErrorResult("密码错误");


            }
            //out带一个参数出去
            employeeName = arr.Name;
            employeeId = arr.Id;
            return APIResultModel.GetErrorResult("登录成功", new
            {
                arr.Name,
                arr.Id
            });
        }
        }
}
