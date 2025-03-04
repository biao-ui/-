using Commo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface ILogInBLL
    {
        public APIResultModel Login(string account, string password, out string employeeName,out string employeeId);
    }
}
