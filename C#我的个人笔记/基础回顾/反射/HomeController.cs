using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    public class HomeController : Controller
    {
        public void Index()
        {
            Console.WriteLine("我是Index");
        }

        public void CreateUser()
        {
            Console.WriteLine("我是CreateUser");
        }
    }
}
