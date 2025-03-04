using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IMenulnfoDAL:IBaseDAL<MenuInfo>
    {
        public bool Delete1(string id);
    }
}
