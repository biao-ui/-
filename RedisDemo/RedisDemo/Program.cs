using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ////创建redis
            RedisHelper redisHelper = new RedisHelper("127.0.0.1:6379");
            #region 操作字符
            ////保存字符串的值到redis中
            //bool b = redisHelper.SetString("name", "老旧");
            ////取redis中的字符
            //string valeu = redisHelper.GetString("name");
            ////重新赋值相同的key
            //b = redisHelper.SetString("name", "list");
            //string newva = redisHelper.GetString("name");
            ////删除redis 
            //bool r3 = redisHelper.DeleteKey("name");
            //string uncacheva = redisHelper.GetString("name");
            ////设置过期时间
            //redisHelper.SetString("address", "nn", TimeSpan.FromSeconds(1010));
            ////设置过期时间点
            //redisHelper.SetString("phnne", "221312222", new DateTime(2024, 11, 10, 15, 23, 00));

            //List<string> list = new List<string> { "zs", "li" };
            //redisHelper.SetObject("names", list);
            //List<string> list2 = redisHelper.GetObject<List<string>>("name");

            ////保存对象
            //Student student = new Student()
            //{
            //    Id = 1,
            //    Name ="zs",
            //    FirstName = "nn"
            //};
            //redisHelper.SetObject("Student", student);
            //Student student2 = redisHelper.GetObject<Student>("student");

            //自增 原子性（不可在分）
            //long numder = redisHelper.Increment("index");
            //string str = redisHelper.GetString("index");
            //numder = redisHelper.Increment("index");
            ////自减
            //redisHelper.Decrement("index");
            Student student = new Student()
            {
                Id = 1,
                Name = "zs",
                FirstName = "nn"
            };
            redisHelper.SetObject("student", student);
            redisHelper.ExpireKey("Userrfor1", TimeSpan.FromSeconds(10));
            //redisHelper.ExpireKey("UserInfo", DateTime.Now.AddMilliseconds(1));
            #endregion
            #region Hash相关操作 一般处理对象时使用
            ////使用hash来存用户信息
            //redisHelper.SetHash("UserInfo", "Name", "zhangsan");
            //redisHelper.SetHash("UserInfo", "Age", 18);
            //redisHelper.SetHash("UserInfo", "Address", "nn");

            /////获取hash里用户的信息
            //string userName = redisHelper.GetHash("UserInfo", "Name");
            //string userAge = redisHelper.GetHash("UserInfo", "Age");
            //string userAddress = redisHelper.GetHash("UserInfo", "Address");
            ////修改hash里的用户地址
            //redisHelper.SetHash("UserInfo", "Address", "nns");
            #endregion
            #region list 有顺序
            List<string> list = new List<string>()
            {
                "zs",
                "ls"
            };
            var list2 = list.Select(s => { return new RedisValue(s); });
            RedisValue[] arr = list2.ToArray();
            long l = redisHelper.SetLeftList("list", arr);
            long l2 = redisHelper.SetLeftList("list", "list1");
            long l3 = redisHelper.SetLeftList("list", "list2");
            long l4 = redisHelper.SetLeftList("list", "list3");
            long l5 = redisHelper.SetRightList("list", "zhaoliu");
            redisHelper.PopListRight("list");
            redisHelper.ExpireKey("list", TimeSpan.FromMinutes(1));
            #endregion
            #region SortedSer 不重复，没顺序
            redisHelper.SetSet("set", "zhangsan1");

            #endregion

            #region SortedSer 不重复，有顺序
            redisHelper.SetSortedSet("Names", "zhangsan1", 0);
            redisHelper.SetSortedSet("Names", "3asd", 1);
            redisHelper.SetSortedSet("Names", "123", 3);
            redisHelper.SetSortedSet("Names", "123", 3);
            redisHelper.SetSortedSet("Names", "sad123", 6);
            //取排名前三的信息
            var sset = redisHelper.GetRangeSSet("Names", 0, 1);
            var sset2 = redisHelper.GetRangeSsetEntry("Names", 0, 2, Order.Descending);
            var score = redisHelper.GetSsetScore("Names", "sad123").Value;
            redisHelper.SetSortedSet("Names", "sad123", score + 100);
            #endregion

            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Task.Delay(100).Wait();
            //        var value = redisHelper.PopListLeft("biao");
            //        Console.WriteLine(value.ToString());
            //    }
            //});

            Console.ReadLine();
        }
    }
}
