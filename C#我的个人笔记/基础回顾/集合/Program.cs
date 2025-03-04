using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 集合
{
    class Program
    {
        static void Main(string[] args)
        {

            //泛型集合List<T>
            //泛型集合List<T> 是一个确定数据类型的集合，他可以方便的添加、删除、修改集中的元素。也有很多便于编程的方法。
            //如何创建一个集合
            List<int> list = new List<int>() { 11, 22, 33, 44, 55 };


            //如何打印集合中所有的元素
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }


            //集合中一些常用的方法
            //添加
            //list.Add(66);
            //list.AddRange(new List<int>() { 66, 77, 88 });

            //删除
            //list.Remove(11);
            //list.RemoveAt(1);

            //修改元素
            //list[1] = 99;

            //题目：把集合中是偶数的元素，都在自己的情况下加上100
            //for (int i = 0; i < list.Count; i++)
            //{
            //    int res = list[i] % 2;
            //    if (res == 0)
            //    {
            //        list[i] += 100;
            //    }
            //}


            //集合和数组相互转化
            int[] arr = list.ToArray();
            List<int> list2 = arr.ToList();

            //list.Add(88);
            //var list3 = list.Append(99).ToList();

            //判断集合中有没有元素
            //bool b = list.Any();
            //题目：去找集合中有没有55这个值，有就true，否则false
            //bool b2 = list.Any(item => item == 55);

            //bool b2 = false;
            //foreach (var item in list)
            //{
            //    if (item == 55)
            //    {
            //        b2 = true;
            //        break;
            //    }
            //}

            //判断集合中有没有包含一个值
            bool b3 = list.Contains(55);

            //遍历
            list.ForEach(i =>
            {
                string str = i + 100 + "元";
                Console.WriteLine(str);
            });

            //插入值
            list.Insert(1, 99);

            //取并集
            List<int> list3 = list.Union(new List<int>() { 33, 44, 55, 66 }).ToList();

            //找出一个集合大于30数据，得到新的集合
            List<int> temp = new List<int>();
            foreach (var item in list)
            {
                if (item > 30)
                {
                    temp.Add(item);
                }
            }

            List<int> temp2 = list.Where(item=> item > 30).ToList();

        }
    }
}
