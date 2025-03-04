using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据类型
{
    public class IntConvert
    {
        /// <summary>
        /// out参数方法，out 在出去方法之前必须要带参数出去（给out必须赋值）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool TryParse(string str,out int i)
        {
            try
            {
                //类型转换
                i = Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                i = 0;
                return false;
            }
        }

        /// <summary>
        /// ref也可以做值类型数字传出去方法的操作，ref在出去方法之前可以不用赋值。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool TryParse2(string str, ref int i)
        {
            try
            {
                //类型转换
                i = Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                //i = 0;
                return false;
            }
        }
    }
}
