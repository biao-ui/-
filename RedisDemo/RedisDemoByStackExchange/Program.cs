using RedisDemo;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemoByStackExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建redis帮助类
            RedisHelper redisHelper = new RedisHelper("127.0.0.1:6379");

            //保存字符串的值到redis中
            bool r1 = redisHelper.SetString("name", "zhangsan");
            //取redis中的字符串
            string value = redisHelper.GetString("name");
            //重新赋值相同的key
            //string oldValue = redisHelper.SetAndGetString("name", "lisi");
            //string newValue = redisHelper.GetString("name");

            //删除redis中的字符串
            //bool r3 = redisHelper.DeleteKey("name");
            //string uncacheValue = redisHelper.GetString("name");
            var a = new DateTime(2022, 8, 17, 15, 27, 1) - new DateTime(2022, 8, 17, 15, 27, 0);
            var b = new DateTime(1970, 1, 1, 0, 0, 1);
            //设置过期时间
            redisHelper.SetString("age", "18", new TimeSpan(0,0,10));

            Task.Run(() => { 
               for (int i = 0; i < 100; i++)
                {
                    Task.Delay(1000).Wait();
                    redisHelper.SetRightList("biao", "包子" + i);
                    Console.WriteLine("包子" + i + "生成出来了");
                    }
            });
            Console.ReadLine();

        }
    }
}
