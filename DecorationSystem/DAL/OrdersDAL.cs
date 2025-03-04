using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdersDAL : BaseDAL<Orders>, IOrdersDAL
    {
        MyDbContext _myDbContext;

        public OrdersDAL(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

    }
}
