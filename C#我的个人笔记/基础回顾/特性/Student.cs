using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    //[Custom("zs",Age = 18)]
    public class Student
    {
        [Custom2(Name = "主键")]
        [IgnoreAttribute]
        public int Id { get; set; }

        //[Custom("zs", Age = 18)]
        [Custom2(Name = "名字")]
        public string Name { get; set; }

        [Custom2(Name = "年龄")]
      
        public int Age { get; set; }

        [Column(TypeName = "nvarchar(18)")]
        [Custom2(Name = "地址")]
        public string Address { get; set; }

        [Custom2(Name = "生日")]
        public DateTime BirthDay { get; set; }

        [Ignore]
        [Custom2(Name = "性别")]
        public bool Sex { get; set; }

        //[Custom(Id = 1, _name = "ls")]
        public void Eat()
        {
            Console.WriteLine("吃....");
        }
    }
}
