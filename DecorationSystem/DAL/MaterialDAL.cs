using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaterialDAL:BaseDAL<Material>, IMaterialDAL
    {
        MyDbContext _myDbContext;

    public MaterialDAL(MyDbContext myDbContext) : base(myDbContext)
    {
        _myDbContext = myDbContext;
    }
    
    }
}
