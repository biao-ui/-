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
            //string str = new String(new char[] { '你', '好' });
            //string str2 = "hello";


            //题目：字符串的默认值是什么？
            //int i;
            //double d;
            //char c;
            //string str3;

            //题目:  string str = "";与string str = null;有什么区别？
            //空字符串""已经开辟内存空间，null则空引用没有开辟内存。

            //题目:  string str = "";与string str = " ";有什么区别？
            //一个是空字符串""，一个是空格字符串。

            //************************************
            //字符串常用的一些方法
            //字符串替换得到新的字符串
            //string name = "z!S!l!s";
            //string res1 = name.Replace('!', '~');
            //string res2 = name.Replace("!", "!@#");

            //string content = "你好啊！";
            //string res3 = content.Replace("你好", "***");

            //Format根据字符串中的格式来处理字符串，一般都会有一些占位符来帮助处理
            //string name = "李四";
            //string name2 = "张三";
            //string res = string.Format("你好啊，{0}，我是{1}", name, name2);
            //字符串拼接的方式
            //string res2 = "你好啊，" + name + "，我是" + name2;

            //把一些字符串全部拼接在一起
            //string res1 = string.Concat("000", "1111", "2222");

            //************************************
            //按照指定的字符串分隔并合并成新的字符串，比如结果为：zs,ls,ww
            //string[] strArr = new string[] { "zs", "ls", "ww" };
            //string res = string.Join(",", strArr);

            //string tempStr = "";
            //foreach (string item in strArr)
            //{
            //    Console.WriteLine(item);
            //    tempStr += item;
            //    tempStr += ",";
            //}

            //Join方法的功能，我们用for循环也实现了一遍
            //for (int i = 0; i < strArr.Length; i++)
            //{
            //    Console.WriteLine(strArr[i]);
            //    tempStr += strArr[i];

            //    //判断是否是循环的最后一次
            //    if (i != strArr.Length - 1)
            //    {
            //        tempStr += ",";
            //    }
            //}

            //Console.WriteLine(tempStr);

            //判断字符串是否为空字符串或null
            //string str = null;
            //if (str == null)
            //{
            //    Console.WriteLine("str为赋值");
            //}

            //string str = "";
            //if (str == "")
            //{
            //    Console.WriteLine("str为空字符串");
            //}

            //string str = "";
            //if (str == "" || str == null)
            //{
            //    Console.WriteLine("请输入正确的内容");
            //}

            //if (string.IsNullOrEmpty(str))
            //{
            //    Console.WriteLine("请输入正确的内容");
            //}

            #region 判断对象是否相等和equals方法
            //Student s1 = new Student();
            //s1.Name = "zs";

            //Student s2 = new Student();
            //s2.Name = "zs";

            //Student s3 = s1;
            //s3.Name = "ls";

            //Console.WriteLine(s1.Name);


            //if (s3 == s1)
            //{
            //    Console.WriteLine("相等了");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}


            //if (s1 == s2)
            //{
            //    Console.WriteLine("相等了");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            //if (s1.Equals(s2))
            //{
            //    Console.WriteLine("相等了");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            #endregion

            //判断字符串是否相同
            //C#里字符串==与默认的equals方法都是判断字符串的内容相等，但是两个字符串其实是两个独立的对象，他们在内存都有自己的对象地址
            //string str1 = new String(new char[] { 'h', 'i' });
            //string str2 = new String(new char[] { 'h', 'i' });

            //string str1 = "hello";
            //string str2 = "hello";
            //if (str1 == str2)
            //{
            //    Console.WriteLine("相等了");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            //bool b2 = string.Equals(str1, str2);
            //if (b2)
            //{
            //    Console.WriteLine("相等了");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            ////判断内存地址是否相等
            //bool b3 = string.ReferenceEquals(str1, str2);
            //if (b2)
            //{
            //    Console.WriteLine("相等了");
            //}
            //else
            //{
            //    Console.WriteLine("不相等");
            //}

            //Length属性是获取字符串字符的个数
            //string str = "zs,li,ww";
            //Console.WriteLine(str.Length);

            //************************************
            //根据某个字符拆分成字符串数组
            //string str = "zs,li,ww";
            //string[] strArr = str.Split(',');

            //判断字符串中是否有哪个字符，有就返回true，没有就返回false
            //string str = "abc";
            //bool b3 = str.Any((char item) => { return item == 'd'; });

            //转大小写
            //string str1 = "aBCD";
            //string res1 = str1.ToUpper();
            //string res2 = str1.ToLower();

            //去空格
            //string str1 = "            abc          cdef    ";
            //string res1 = str1.Trim();
            //string res2 = str1.TrimStart();
            //string res3 = str1.TrimEnd();

            //如果全部的空格都要去掉，我能可以使用前面学的方法
            //string res4 = str1.Replace(" ","");

            //************************************
            //获取字符串中是否包含某些字符串，并返回他的下标索引
            //string str = "abca!efg!gijk!";
            //int i = str.IndexOf("!");
            //int i2 = str.IndexOf("!@");

            //int i3 = str.LastIndexOf("!");
            ////获取第二个感叹号的索引是多少
            //int i4 = str.IndexOf("!", i + 1);

            //************************************
            //字符串截取
            //string str = "abddddddddddeeeeeeeeeeeeeqqqqqqqqqqq";
            ////从指定的索引开始截取字符串，截取到字符串的结尾
            //string res =  str.Substring(2);
            //string res2 = str.Substring(0,10);
            ////从d的最后一开始截取，并且不要这个最后的d，到字符串的结尾
            //int lastIndex = str.LastIndexOf("d");
            //string res3 = str.Substring(lastIndex+1);

            //************************************
            //字符串中是否包含某个字符串
            //string str = "abcdefg";
            //bool b1 = str.Contains('g');
            //bool b2 = str.Contains("fg");
            //bool b3 = "abcdefg".Contains("ce");

            //在字符串中的指定的位置插入一个字符串
            //string str = "abcdefg";
            //string res = str.Insert(2,"!!!!!!!!");


            //作业1：
            //请用户输入一段信息，输入的内容为用户的姓名，用户的地址，用户的电话。每段信息以“ , ”符号分割（注意英文符号）。
            //例如：张三,广西南宁市创新路21号中关村,13377188888
            //最后在控制台中输出3行内容，分别为用户的姓名，用户的地址，用户的电话

            //string readContent = Console.ReadLine();
            ////string readContent = "张三,广西南宁市创新路21号中关村,13377188888";

            //int index = readContent.IndexOf(",");
            //if (index == -1)
            //{
            //    Console.WriteLine("请输入第一分割符号(,)");
            //}

            //int index2 = readContent.IndexOf(",", index + 1);
            //if (index2 == -1)
            //{
            //    Console.WriteLine("请输入第二分割符号(,)");
            //}

            //int index3 = readContent.IndexOf("，");
            //if (index3 >= 0)
            //{
            //    Console.WriteLine("请输入英文的逗号");
            //}

            //if (index != -1 && index2 != -1)
            //{
            //    string[] arr = readContent.Split(',');

            //    foreach (string item in arr)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}



            //作业2：
            //string str = "我是张三 我今年18岁了 我准备要去读大学了 哈哈哈。";
            //2.1、处理str字符串，把这段话的空格换成逗号，打印到控制台中。
            //如：我是张三,我今年18岁了,我准备要去读大学了,哈哈哈。
            //2.2、把str中每一小段内容分别打印一行在控制台中。
            //如：“我是张三”，“我今年18岁了”，“我准备要去读大学了”。
            //2.3、截取str字符串，规则是从第二个“我”字开始截取，截取到第二个“了”字结束。然后打印到控制台。
            //如：我今年18岁了 我准备要去读大学了
            string str = "我是张三 我今年18岁了 我准备要去读大学了 哈哈哈。";

            string res = str.Replace(" ", ",");
            Console.WriteLine(res);

            string[] arr =  str.Split(' ');
            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }

            //第一个我字的索引
            int index = str.IndexOf("我");
            //第二个我字的索引
            int index2 = str.IndexOf("我", index + 1);
            //第一个了字的索引
            int index3 = str.IndexOf("了");
            //第二个了字的索引
            int index4 = str.IndexOf("了", index3 + 1);

            string res2 = str.Substring(index2, index4 - index2 + 1);
            Console.WriteLine(res2);


        }
    }
}
