using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json操作
{
    class Program
    {
        static void Main(string[] args)
        {
            //Json
            //Json是一个轻量级的文本数据交换格式。
            //Json使用了Javascript的语法来描述数据对象，但是Json支持很多种编程语言使用。
            //以键值对的形式表示数据 如："Name":"张三"
            //数据之间用逗号分隔 如："Name":"张三","Age":18
            //花括号表示对象 {}
            //方括号表示数组 []
            //例：详细查看项目的Json文件

            //序列化与反序列化
            //序列化：把一个对象转换成对象的字符串形式（json格式的字符串）
            //反序列化：把对象的字符串形式（json格式的字符串）转换成对象
            //使用JsonConvert帮助类来完成

            //练习1：序列化学生对象得到Json字符串
            #region 测试
            //学生对象
            Student student = new Student()
            {
                Name = "张三",
                Age = 18,
                IsAdmin = true,
                Email = null,
                Friends = new string[] { "李四", "王五", "赵六" },
                Address = new Address()
                {
                    City = "南宁",
                    Road = "创新路",
                    Number = 23
                }
            };

            //把学生对象转化成Json字符串
            string jsonStr =  JsonConvert.SerializeObject(student);

            Console.WriteLine(jsonStr);

            #endregion

            //练习2:反序列化Json字符串得到学生对象
            object student2 = JsonConvert.DeserializeObject(jsonStr);
            //Student student1 = (Student)student2;
            Student student1 = JsonConvert.DeserializeObject<Student>(jsonStr);
            #region 测试

            #endregion
        }
    }
}
