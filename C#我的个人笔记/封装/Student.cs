using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 封装
{
    /// <summary>
    /// 封装一个学生类
    /// </summary>
    public class Student
    {
        private int Age { get; set; }

        protected string Name { get; set; }

        internal int Sex { get; set; }

        public void Learn()
        {
            Age = 18;
            Name = "张三";
        }
    }
}
