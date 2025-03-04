using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public class XiaoMiPhone : IPhoneProduct
    {
        public void Call()
        {
            Console.WriteLine("小米Call");
        }

        public void SendMsg()
        {
            Console.WriteLine("小米SendMsg");
        }

        public void Shut()
        {
            Console.WriteLine("小米Shut");
        }

        public void Start()
        {
            Console.WriteLine("小米Start");
        }
    }
}
