using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 枚举
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }
        

        /// <summary>
        /// 性别  1是男  2是女  3是未知
        /// </summary>
        //public int Sex { get; set; }

        public SexEnum Sex { get; set; }
    }
}
