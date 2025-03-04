using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    class Node<T>
    {
        ///// <summary>
        ///// 之前的节点
        ///// </summary>
        //public Node<T> pre { get; set; }

        /// <summary>
        /// 下个的节点的引用
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// 节点中的数据
        /// </summary>
        public T Data { get; set; }
    }
}
