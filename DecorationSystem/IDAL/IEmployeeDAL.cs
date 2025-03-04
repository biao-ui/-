using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IEmployeeDAL: IBaseDAL<Employee>
    {

        /// <summary>
        ///根据账号查询
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Employee Employeev(string account);
            

        ///// <summary>
        ///// 添加
        ///// </summary>
        ///// <param name="employee"></param>
        ///// <returns></returns>
        //public bool AddEmployeev(Employee employee);

        ///// <summary>
        ///// 根据id查询
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Employee DeleteEmployee(string id);
        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="employee"></param>
        ///// <returns></returns>
        //public bool UpdataEmployee(Employee employee);



        ///// <summary>
        ///// 真删除
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        ////public bool SetDeleteEmployee(string id);
        //public DbSet<Employee> GetDbSet ();     

    }
}
