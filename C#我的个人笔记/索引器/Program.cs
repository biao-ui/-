using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 索引器
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = new int[] { 1, 22, 33, 44, 55 };
            int i = intArr[0];

            string[] strArr = new string[] { "aa", "bb", "cc" };
            string str = strArr[0];
            strArr[0] = "dd";

            MyIndexer myIndexer = new MyIndexer();

            myIndexer[1] = "bb";
            string s = myIndexer[0];

            //string str2 = myIndexer[0];
            //string str3 = myIndexer[1];

            MyIndexer2 myIndexer2 = new MyIndexer2();
            myIndexer2["zs"] = "张三";
            ////拿值
            //string str4 = myIndexer2["zs"];

            //myIndexer2["ls"] = "李四";
            ////拿值
            //string str5 = myIndexer2["ls"];


            //Dictionary<string,string> dic = new Dictionary<string,string>();
            //dic["zs"] = "张三";
            ////拿值
            //string str6 = dic["zs"];
        }
    }
}
