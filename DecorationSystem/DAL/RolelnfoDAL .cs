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
    public class RolelnfoDAL : BaseDAL<RoleInfo>, IRolelnfoDAL
    {
        MyDbContext _myDbContext;
        public RolelnfoDAL(MyDbContext myDbContext):base(myDbContext)
        {
            _myDbContext = myDbContext;
        }


        ///// <summary>
        ///// 根据ID查
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Employee DeleteRolelnfo(string id)
        //{
        //    var arr = _myDbContext.Employee.FirstOrDefault(x => x.Id == id);
        //    return arr;
        //}


 
     

        ///// <summary>
        ///// 添加功能
        ///// </summary>
        ///// <param name="employee"></param>
        ///// <returns></returns>
        //public bool AddRolelnfo(RoleInfo roleInfo )
        //{
        //    _myDbContext.Add(roleInfo);
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
        //public bool UpdataRolelnfo(Employee employee)
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

        //public bool SetDeleteRolelnfo(string id)
        //{
        //    var arr = _myDbContext.Employee.FirstOrDefault(x => x.Account == id);
        //    if (arr != null)
        //    {
        //        _myDbContext.Employee.Remove(arr);
        //        int set = _myDbContext.SaveChanges();
        //        if (set > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //public DbSet<RoleInfo> GetDbSet()
        //{
        //    return _myDbContext.RoleInfo;
        //}

      
    }
}
