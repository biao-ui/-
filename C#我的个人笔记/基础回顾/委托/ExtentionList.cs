using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    //*************************************拓展方法*******************************
    //可以不修改源码的情况下，给你需要加方法的类加自定义方法。类必须是静态类，拓展方法必须是静态方法，而且第一个参数前面加上this关键字
    //参数的类型是你要拓展类型
    public static class ExtentionList
    {

        public static T MyFirst<T>(this List<T> list, Func<T, bool> func)  //zs
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
    }
}
