using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组
{
    class Program
    {
        static void Main(string[] args)
        {

            //数组（Array）
            //数组是一个存储相同类型元素的固定大小的顺序集合
            //声明并初始化数组：数据类型[] 变量名 = new 数据类型[数组长度数];
            string[] strArr = new string[10];
            string[] strArr2 = new string[2] { "zs", "ls" };
            //如何为数组中的元素赋值
            //数组的下标是从0开始
            strArr[0] = "1";
            //如何取出数组中的某个元素的值
            string str = strArr2[1];
            //如何获取数组中元素的个数
            int length = strArr2.Length;

            //题目：定义一个string类型数组，数组中有"张三","李四","王五","赵六","田七"，把他们名字以此打印到控制台中。
            #region 测试
            //string[] names = new string[] { "张三", "李四", "王五", "赵六", "田七" };
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            //foreach (var item in names)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion


            //题目：有一个int类型数组，数组中有11，22，33，44，55，66这几个元素，请把为奇数的元素找出来得到一个数组。
            #region 测试
            //int[] nums = new int[] { 11, 22, 33, 44, 55, 66 };

            //int[] nums2 = new int[10];
            //int index = 0;
            //foreach (int item in nums)
            //{
            //    int res = item % 2;
            //    if (res == 1)
            //    {
            //        nums2[index] = item;
            //        index++;
            //    }
            //}

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int res = nums[i] % 2;
            //    if (res == 1)
            //    {
            //        nums2[i] = nums[i];
            //    }
            //}
            #endregion


        }
    }
}
