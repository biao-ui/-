using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 异常处理
{
    public class Test
    {

        public static void Method()
        {
            try
            {
                string str = null;
                int i = str.Length;

                //......
            }
            catch (Exception e)
            {
                //throw;
                //throw new Exception("出错了，50块，谢谢") ;
            }
            finally
            {
                Console.WriteLine("finally的代码");
                Console.ReadKey();
            }
        }
    }
}
