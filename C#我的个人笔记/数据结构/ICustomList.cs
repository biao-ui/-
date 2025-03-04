using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    public interface ICustomList<T>
    {
        //获取集合元素的数量
        int Count { get; }
        //索引器
        T this[int index] { get; set; }
        //添加
        void Add(T item);
        //找出元素在集合中的下标
        int IndexOf(T item);
        //按照索引插入
        void Insert(int index, T item);
        //删除集合中索引处的元素
        void RemoveAt(int index);
        //清空集合中的元素
        void Clear();

    }
}
