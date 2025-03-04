using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Commo
{
    public class MD5Helper
    {
        public static string GetMD5(string strPwd)
        {
            MD5 md5 = MD5.Create();
            byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);//将字符编码为一个字节序列
            byte[] md5data = md5.ComputeHash(data);                     //计算data字节数组的哈希值
            md5.Clear();       //清空MD5对象
            string str = "";   //定义一个变量，用来记录加密后的密码
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }
    }
}
