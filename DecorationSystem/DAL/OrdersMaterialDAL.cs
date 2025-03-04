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
    public class OrdersMaterialDAL : BaseDAL<OrdersMaterial>, IOrdersMaterialDAL
    {
        MyDbContext _myDbContext;

        public OrdersMaterialDAL(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
           var   employee = _myDbContext.OrdersMaterial.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _myDbContext.OrdersMaterial.Remove(employee);
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
            else
            {
                return false;
            }
        }

    }
}
