using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 索引器
{
    public class MyIndexer
    {
        List<string> list = new List<string>();

        public MyIndexer()
        {
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list.Insert(index, value); 
            }
        }
    }
}
