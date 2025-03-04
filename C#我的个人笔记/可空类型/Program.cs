using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 可空类型
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = null;
            //string str = null;

            //可空类型Nullable
            //C#中值类型是不能赋值null的，如果需要为值类型赋值null，则需要在值类型后面加上"?"
            //使其类型变为Nullable类型才可以赋值null

            //尝试为int赋值null
            //尝试使用可空类型赋值null
            //int? i = null;
            //double? d = null;
            //string str = null;
            //题目：请问int a与int? b的默认值各是什么？
            //int? b;

            //题目：int?类型是可空类型，如果想获取里面的整数赋值给另一个变量int i应该怎么操作呢？
            //int? a = 18;
            //int i1 = (int)a;
            //int i2 = a.Value;
            //int i3 = a.GetValueOrDefault();
            //int i4 = a ?? 0;

            //int? b = null;
            //int i5 = b ?? 0;

            ////string s = null;
            //string s = "123abc";
            //string res = s ?? "abc";
        }
    }
}
