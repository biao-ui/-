using DAL;
using Entity;
using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenulnfoDAL:BaseDAL<MenuInfo>,IMenulnfoDAL
    {
        MyDbContext _myDbContext;

        public MenulnfoDAL(MyDbContext myDbContext) : base(myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public bool Delete1(string id)
        {
            var employee = _myDbContext.MenuInfo.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _myDbContext.MenuInfo.Remove(employee);
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
