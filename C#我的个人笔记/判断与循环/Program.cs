using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 判断与循环
{
    class Program
    {
        static void Main(string[] args)
        {
            //一、判断
            //if
            //if else
            //switch

            //题目：分别使用if 与 switch case default写一段代码，需求当int i等于1时输出“sing”, i等于2时输出“dance”,i等于其他时输出“say”
            #region 测试
            //if (true)
            //{
            //    if (true)
            //    {

            //    }
            //}
            //else if(true)
            //{

            //}
            //else if (true)
            //{

            //}

            //int i = 0;
            //switch (i)
            //{
            //    case 1:
            //        //....
            //        break;
            //    default:
            //        //.....
            //        break;
            //}

            #endregion

            //二、循环
            //循环类型 描述
            //while 循环    当给定条件为真时，重复语句或语句组。它会在执行循环主体之前测试条件。
            //for/foreach 循环 多次执行一个语句序列，简化管理循环变量的代码。
            //do ...while 循环   除了它是先执行一次，其他与 while 语句类似。

            //把这3个循环都测试一次。
            #region 测试

            //while (true)
            //{
            //    //......
            //}

            //do
            //{

            //} while (true);

            //for (int i = 0; i < 10; i++)
            //{
            //}

            //foreach (var item in collection)
            //{

            //}
            #endregion

            //三、循环控制
            //break 语句 跳出循环
            //continue 语句 跳到下一次循环

            //测试这两种循环的用法
            #region 测试
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    //break;//跳出循环
                    //continue;跳到下一次循环
                    //return;//跳出方法
                }

                //........
            }

            //.....
            #endregion
        }
    }
}
