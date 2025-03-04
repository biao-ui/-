using Entity;
using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleMenuDAL:BaseDAL<RoleMenu>,IRoleMenuDAL
    {
        MyDbContext _myDbContext;
        public RoleMenuDAL(MyDbContext myDbContext):base(myDbContext) 
        {
            _myDbContext = myDbContext;
        }

        public bool DeleteRoleMenu(RoleMenu roleMenu)
        {
            _myDbContext.RoleMenu.Remove(roleMenu);
            //更新到数据库
            int index = _myDbContext.SaveChanges();

            if (index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
