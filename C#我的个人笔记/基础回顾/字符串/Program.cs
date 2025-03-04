using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            //字符串（String）
            //字符串是可以保存一个或多个字符的数据类型，他是有些特殊的引用类型。
            //题目：字符串如何创建对象？
            //string str = new String(new char[] { '你','好' });
            //string str2 = "hello";

            //题目：字符串的默认值是什么？
            //string str3;

            //题目:  string str = "";与string str = null;有什么区别？
            //空字符串""已经开辟内存空间，null则空引用没有开辟内存。

            //题目:  string str = "";与string str = " ";有什么区别？
            //一个是空字符串""，一个是空格字符串。

            //字符串常用的一些方法
            string name = "z!S!l!s";
            string res = string.Format("你好，我叫{0}", name);

            string res1 = string.Concat("000", "1111", "2222");

            string[] strArr = new string[] { "zs", "ls", "ww" };
            //按照指定的字符串分隔并合并成新的字符串
            string res2 = string.Join(",", strArr);

            //判断字符串是否为空字符串或null
            bool b = string.IsNullOrEmpty("");

            string str1 = "hello";
            string str2 = "hello";
            //判断字符串是否相同
            bool b2 = string.Equals(str1, str2);

            //根据某个字符拆分成字符串数组
            string[] strArr2 = name.Split('!');

            //判断字符串中是否有哪个字符，有就返回true，没有就返回false
            bool b3 = "abc".Any(s => s == 'b');

            //转大小写
            string str3 = name.ToUpper();
            string str4 = str3.ToLower();

            //字符串替换得到新的字符串
            string str5 = name.Replace("!", ",~!@");

            //去空格
            string str6 = "             abc          cdef    ".Trim();

            //获取字符串中是否包含某些字符串，并返回他的下标索引
            int i = name.IndexOf("!s");
            int i2 = name.IndexOf("!@");

            int i3 = name.LastIndexOf("!");
            int i4 = name.IndexOf("!", 2);

            string str7 = "abcdefg".Substring(4);
            string str8 = "abcdefg".Substring(4,2);

            bool b4 = "abcdefg".Contains("g");
            bool b5 = "abcdefg".Contains("fg");
            bool b6 = "abcdefg".Contains("ce");

            string str9 = "abcdefg".Insert(2,"!!!!!!!!");

        }
    }
}
