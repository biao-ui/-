using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public class HuaweiPhone : IPhoneProduct
    {
        public void Call()
        {
            Console.WriteLine("华为Call");
        }

        public void SendMsg()
        {
            Console.WriteLine("华为SendMsg");
        }

        public void Shut()
        {
            Console.WriteLine("华为Shut");
        }

        public void Start()
        {
            Console.WriteLine("华为Start");
        }
    }
}
