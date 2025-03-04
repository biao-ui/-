using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    /// <summary>
    /// 自定义顺序表实现的List集合类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CustomList<T> : ICustomList<T>, IEnumerable<T>
    {
        //线性表：顺序表 ---> 数组
        //装集合元素的数组
        private T[] _arr = new T[0];
        //计数的索引数
        private int indexNum = 0;

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return _arr[index];
            }
            set
            {
                _arr[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return indexNum;
            }
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (indexNum < _arr.Length)
            {
                _arr[indexNum] = item;

            }
            else
            {
                //扩容_arr数组
                T[] newArr = new T[_arr.Length + 1];
                //复制原来数组的元素进新的数组
                for (int i = 0; i < _arr.Length; i++)
                {
                    newArr[i] = _arr[i];
                }


                //把传进来的数据保存到数组的最后的位置
                newArr[_arr.Length] = item;
                //把新的扩容好的数组复制回_arr字段上面
                _arr = newArr;
            }

            indexNum++;
        }

        /// <summary>
        /// 清空集合
        /// </summary>
        public void Clear()
        {
            indexNum = 0;
            _arr = new T[0];
        }

        /// <summary>
        /// 根据值在集合中找值的索引
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 按照索引插入数据到集合
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            //扩容_arr数组
            T[] newArr = new T[_arr.Length + 1];

            //后面元素的值等于前面元素的值（前面的往后一格移动）

            //for (int i = _arr.Length - 1; i >= index; i--)
            //{
            //    newArr[i + 1] = _arr[i];
            //}

            for (int i = index; i <= _arr.Length - index; i++)
            {
                newArr[i + 1] = _arr[i];
            }

            //赋值你要插入的值
            newArr[index] = item;

            //复制原来数组的元素进新的数组
            for (int i = 0; i < index; i++)
            {
                newArr[i] = _arr[i];
            }

            _arr = newArr;
        }

        /// <summary>
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)  //2
        {
            //减容新数组
            T[] newArr = new T[_arr.Length - 1];

            //遍历数组中要往前移动的元素
            for (int i = index + 1; i < _arr.Length; i++)
            {
                newArr[i - 1] = _arr[i];
            }

            //复制原来数组的元素进新的数组
            for (int i = 0; i < index; i++)
            {
                newArr[i] = _arr[i];
            }

            //把新数组覆盖旧数字
            _arr = newArr;
        }


        /// <summary>
        /// 删除指定位置的元素
        /// </summary>
        /// <param name="value"></param>
        public void RemoveAtValue(T value)
        {
            int index = -1;
            //找到要删除元素的index索引位置
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return;
            }

            //减容新数组
            T[] newArr = new T[_arr.Length - 1];

            //遍历数组中要往前移动的元素
            for (int i = index + 1; i < _arr.Length; i++)
            {
                newArr[i - 1] = _arr[i];
            }

            //复制原来数组的元素进新的数组
            for (int i = 0; i < index; i++)
            {
                newArr[i] = _arr[i];
            }

            //把新数组覆盖旧数字
            _arr = newArr;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomListEnumerator<T>(_arr);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListEnumerator<T>(_arr);
        }
    }

    /// <summary>
    /// 迭代器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CustomListEnumerator<T> : IEnumerator<T>
    {
        //需要遍历数组
        T[] _arry;

        //位置索引
        int _position = -1;

        public CustomListEnumerator(T[] arry)
        {
            _arry = arry;
        }

        public T Current
        {
            get
            {
                return _arry[_position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _arry[_position];
            }
        }

        /// <summary>
        /// 销毁资源方法
        /// </summary>
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 移动到下一个
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            _position++;
            return (_position < _arry.Length);
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }
    }
}
