using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRoleMenuDAL:IBaseDAL<RoleMenu>
    {

        public bool DeleteRoleMenu(RoleMenu  roleMenu);


    }
}
