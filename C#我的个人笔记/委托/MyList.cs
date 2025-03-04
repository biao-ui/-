using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    public class MyList
    {
        public static Student MyFirst(List<Student> list, int where)  //zs
        {

            foreach (Student item in list)
            {
                //item.Age == 18            //1、通过年龄直接判断
                if (item.Age == where)
                //bool b = MyMethod2(item); //2、不确定是用年龄还是姓名判断，然后封装了多个方法，调用不同的方法来实现不同的判断
                //bool b = func(item);      //3、要MyFirst方法专注做自己的事情，选择使用委托 Func<Student,bool> func作为方法的参数
                //if (b)
                {
                    return item;
                }
            }

            return null;
            //return default(T);
        }


        public static T MyFirst<T>(List<T> list, Func<T, bool> func)  //zs
        {
            
            foreach (T item in list)
            {
                bool b = func(item);
                //bool b = MyMethod2(item);

                //item.Name == "zs"
                //if (item.Name == name)
                if (b)
                {
                    return item;
                }
            }

            return default(T);
        }

        public static bool MyMethod(Student item)
        {
            return item.Name == "zs";
        }

        public static bool MyMethod2(Student item)
        {
            return item.Name == "ls";
        }

        public static bool MyMethod3(Student item)
        {
            return item.Age == 18;
        }
    }
}
