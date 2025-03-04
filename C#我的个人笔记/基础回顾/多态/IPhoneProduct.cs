using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public interface IPhoneProduct
    {
        void Call();

        void SendMsg();

        void Start();

        void Shut();
    }
}
