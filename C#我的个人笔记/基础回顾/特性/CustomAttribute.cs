using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    /// <summary>
    /// 自定义的特性类
    /// </summary>
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {

        }


        public CustomAttribute(string name)
        {
            _name = name;
        }


        public int Id { get; set; }
        public int Age { get; set; }

        public string _name;

        public void Hi()
        {
            Console.WriteLine($"{_name}:你好,我今年{Age}岁");
        }
    }
}
