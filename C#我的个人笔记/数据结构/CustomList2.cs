using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    /// <summary>
    /// 自定义单链表集合
    /// </summary>
    class CustomList2<T> : ICustomList<T>,IEnumerable<T>
    {
        public Node<T> Head { get; set; }


        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    return default(T);
                }

                //找index遍历次数的那个元素
                Node<T> temp = Head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }

                //返回找到node节点中的data值
                return temp.Data;
            }
            set
            {
                if (index < 0)
                {
                    return;
                }

                //找index遍历次数的那个元素
                Node<T> temp = Head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }

                //修改找到节点中的data值
                temp.Data = value;
            }
        }

        /// <summary>
        /// 获取集合长度
        /// </summary>
        public int Count
        {

            get
            {
                if (Head == null)
                {
                    return 0;
                }
                else
                {
                    int index = 1;
                    //一直找集合中有多少个元素
                    Node<T> temp = Head;
                    while (true)
                    {
                        if (temp.Next == null)
                        {
                            return index;
                        }
                        else
                        {
                            //找下一个节点
                            temp = temp.Next;
                            index++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            //第一次为链表加数据
            if (Head == null)
            {
                //为头元素赋值
                Head = new Node<T>()
                {
                    Data = item
                };
            }
            else
            {
                //新添加元素node对象
                Node<T> newNode = new Node<T>()
                {
                    Data = item
                };

                Node<T> temp = Head;
                while (true)
                {
                    if (temp.Next == null)
                    {
                        temp.Next = newNode;
                        break;
                    }
                    else
                    {
                        //找下一个节点
                        temp = temp.Next;
                    }
                }

                //Head.Next = newNode;
            }
        }

        /// <summary>
        /// 清楚集合中的所有元素
        /// </summary>
        public void Clear()
        {
            Head = null;
        }

        /// <summary>
        /// 通过一个值找到这个值在集合中的下标
        /// </summary>
        /// <param name="item">值</param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            if (Head == null)
            {
                return -1;
            }

            int index = 0;
            Node<T> temp = Head;
            while (true)
            {
                //如果当前找到的node节点中data值等于你传进来的item值
                if (temp.Data.Equals(item))
                {
                    return index;
                }

                if (temp.Next != null)
                {
                    //找下一个节点
                    temp = temp.Next;
                    index++;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 按照索引插入数据到集合中
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {

            //temp里面就是index的前一个元素
            Node<T> before = Head;

            for (int i = 0; i < index - 1; i++)
            {
                //找index索引的前一个元素
                before = before.Next;
            }

            //index的后一个元素
            Node<T> after = before.Next;

            //要插入的元素node
            Node<T> newNode = new Node<T>()
            {
                Data = item
            };

            before.Next = newNode;
            newNode.Next = after;
        }

        /// <summary>
        /// 通过索引删除数据
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                return;
            }

            if (index == 0)
            {
                //头的下一个
                Node<T> NextNode = Head.Next;
                Head = NextNode;
            }
            else
            {
                //temp里面就是index的前一个元素
                Node<T> before = Head;

                for (int i = 0; i < index - 1; i++)
                {
                    //找index索引的前一个元素
                    before = before.Next;
                }

                //index的后一个元素
                Node<T> after = before.Next.Next;

                before.Next = after;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
