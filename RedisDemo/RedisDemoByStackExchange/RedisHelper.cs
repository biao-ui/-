
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class RedisHelper
    {
        //redis对象
        private ConnectionMultiplexer redis { get; set; }
        //相当数据库上下文
        private IDatabase db { get; set; }
        public RedisHelper(string connection)
        {
            redis = ConnectionMultiplexer.Connect(connection);
            db = redis.GetDatabase();
        }

        /// <summary>
        /// 判断键值是否已存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return db.KeyExists(key);
        }

        /// <summary>
        /// 设置key的过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ExpireKey(string key, TimeSpan timeSpan)
        {
            return db.KeyExpire(key, timeSpan);
        }

        /// <summary>
        /// 设置key的过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ExpireKey(string key, DateTime dateTime)
        {
            return db.KeyExpire(key, dateTime);
        }


        /// <summary>
        /// 增加/修改字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetString(string key, string value)
        {
            return db.StringSet(key, value);
        }

        /// <summary>
        ///  增加/修改字符串 设置多久过期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public bool SetString(string key, string value, TimeSpan timeSpan)
        {
            return db.StringSet(key, value, timeSpan, When.Always);
        }

        /// <summary>
        /// 增加/修改字符串 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool SetString(string key, string value, DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
            {
                return false;
            }

            //计算还剩多少时间
            var timeSpan = dateTime - DateTime.Now;

            return db.StringSet(key, value, timeSpan, When.Always);
        }



        /// <summary>
        /// 获取旧值，赋值新值 字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetSetString(string key, string value)
        {
            return db.StringGetSet(key, value);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetString(string key)
        {
            return db.StringGet(key);
        }

        /// <summary>
        /// 获取存储在键上的字符串的子字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public string StringGet(string key, int start, int end)
        {
            return db.StringGetRange(key, start, end);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteKey(string key)
        {
            return db.KeyDelete(key);
        }

        /// <summary>
        /// 实现递增
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Increment(string key)
        {
            return db.StringIncrement(key, flags: CommandFlags.FireAndForget);
        }

        /// <summary>
        /// 实现递减
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Decrement(string key)
        {
            return db.StringDecrement(key, flags: CommandFlags.FireAndForget);
        }


        /// <summary>
        /// 增加/修改 对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SetObject(string key, object obj)
        {
            string jsonStr = JsonConvert.SerializeObject(obj);
            return db.StringSet(key, jsonStr);
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetObject<T>(string key) where T : class
        {
            string jsonStr = db.StringGet(key);
            try
            {
                T data = JsonConvert.DeserializeObject<T>(jsonStr);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// 添加hash值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetHash(string key, RedisValue hashField, RedisValue value)
        {
            return db.HashSet(key, hashField, value);
        }


        /// <summary>
        /// 获取hash值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public RedisValue GetHash(string key, RedisValue hashField)
        {
            return db.HashGet(key, hashField);
        }

        /// <summary>
        /// 删除hash中某个字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public RedisValue DeleteHash(string key, RedisValue hashField)
        {
            return db.HashDelete(key, hashField);
        }


        /// <summary>
        /// 从左边存list值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long SetLeftList(RedisKey key, params RedisValue[] value)
        {

            long l = db.ListLeftPush(key, value);
            return l;
        }

        /// <summary>
        /// 从右边存list值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long SetRightList(RedisKey key, params RedisValue[] value)
        {
            return db.ListRightPush(key, value);
        }


        /// <summary>
        /// 从左边取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public RedisValue PopListLeft(RedisKey key)
        {
            return db.ListLeftPop(key);
        }

        /// <summary>
        /// 从右边取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public RedisValue PopListRight(RedisKey key)
        {
            return db.ListRightPop(key);
        }

        /// <summary>
        /// 获取list集合的长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long GetListLength(RedisKey key)
        {
            return db.ListLength(key);
        }

        /// <summary>
        ///  按范围取list
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public RedisValue[] GetListRange(RedisKey key, long start, long end)
        {
            return db.ListRange(key, start, end);
        }

        /// <summary>
        /// 获取list中某个元素的索引
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long GeListPosition(RedisKey key, RedisValue value)
        {
            return db.ListPosition(key, value);
        }

        /// <summary>
        /// 根据索引获取list中的元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public RedisValue GetListByIndex(RedisKey key, long index)
        {
            return db.ListGetByIndex(key, index);
        }

        /// <summary>
        /// 按索引修改list中元素的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetListByIndex(RedisKey key, long index, RedisValue value)
        {
            db.ListSetByIndex(key, index, value);
        }

        /// <summary>
        /// 删除list中的指定元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long RemoveList(RedisKey key, RedisValue value)
        {
            return db.ListRemove(key, value);
        }

        /// <summary>
        /// 为set集合添加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long SetSet(RedisKey key, params RedisValue[] value)
        {
            return db.SetAdd(key, value);
        }

        /// <summary>
        /// 随机从set取一个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RedisValue PopSet(RedisKey key)
        {
            return db.SetPop(key);
        }

        /// <summary>
        /// 获取set集合中的全部元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RedisValue[] GetSetMembers(RedisKey key)
        {
            return db.SetMembers(key);
        }

        /// <summary>
        /// 为SortedSet集合添加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool SetSortedSet(RedisKey key, RedisValue value, double score)
        {
            return db.SortedSetAdd(key, value, score);
        }

        /// <summary>
        /// 取SortedSet集合中指定value的分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>  UserName  zhangsan  100
        public double? GetSsetScore(RedisKey key, RedisValue value)
        {
            return db.SortedSetScore(key, value);
        }

        /// <summary>
        ///  按范围取SortedSet集合的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public RedisValue[] GetRangeSSet(RedisKey key, long start, long end, Order order = Order.Ascending)
        {
            return db.SortedSetRangeByRank(key, start, end, order);
        }

        /// <summary>
        /// 按范围取SortedSet集合的值与分数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public SortedSetEntry[] GetRangeSsetEntry(RedisKey key, long start, long end, Order order = Order.Ascending)
        {
            return db.SortedSetRangeByRankWithScores(key, start, end, order);
        }

    }
}
