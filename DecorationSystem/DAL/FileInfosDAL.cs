using Entity;
using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileInfosDAL:BaseDAL<Entity.FileInfo>,IFileInfosDAL
    {
        MyDbContext _myDbContext;

        public FileInfosDAL(MyDbContext myDbContext):base(myDbContext)
        {
            _myDbContext = myDbContext;
        }
     

        /// <summary>
        /// 根据ID查
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Employee DeleteEmployee(string id)
        //{
        //    var arr = _myDbContext.Employee.FirstOrDefault(x => x.Id == id);
        //    return arr;
        //}


        ///// <summary>
        ///// 根据账号查
        ///// </summary>
        ///// <param name="account"></param>
        ///// <returns></returns>
        public Employee Employeev(string account)
        {
            var arr = _myDbContext.Employee.FirstOrDefault(x => x.Account == account);
            return arr;
        }

        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        //public bool AddEmployeev(Employee employee)
        //{
        //    _myDbContext.Add(employee);
        //    int set = _myDbContext.SaveChanges();
        //    if (set > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="employee"></param>
        //public bool UpdataEmployee(Employee employee)
        //{
        //    _myDbContext.Update(employee);
        //    int set = _myDbContext.SaveChanges();
        //    if (set > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool SetDeleteEmployee(string id)
        {
            var arr = _myDbContext.Employee.FirstOrDefault(x => x.Account == id);
            if (arr != null)
            {
                _myDbContext.Employee.Remove(arr);
                int set = _myDbContext.SaveChanges();
                if (set > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        //public DbSet<Employee> GetDbSet()
        //{
        // return  _myDbContext.Employee;
        //}
    }
}
