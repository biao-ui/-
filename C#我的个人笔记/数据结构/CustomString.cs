using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    /// <summary>
    /// 自定义的字符集合（字符串）
    /// </summary>
    class CustomString
    {
        char[] _arr;

        public CustomString(char[] arr)
        {
            _arr = arr;
        }

        public int Length
        {
            get
            {
                return _arr.Length;
            }
        }

        public string Replace(char oldChar, char newChar)
        {
            char[] temp = new char[_arr.Length];
            //string tempStr = "";

            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] == oldChar)
                {
                    temp[i] = newChar;
                    //tempStr += newChar;
                }
                else
                {
                    temp[i] = _arr[i];
                    //tempStr += _arr[i];
                }
            }
            //return tempStr;
            return new string(temp);
        }

        public static string Join(string options, string[] pArr)  //aa  bb  cc
        {
            string temp = "";
            foreach (var item in pArr)
            {   //             aa     ,
                //      aa,    bb      ,
                temp = temp + item + options;
            }

            //去掉逗号
            //temp.TrimEnd(',');
            return temp.Substring(0, temp.Length - 1);

        }
    }
}
