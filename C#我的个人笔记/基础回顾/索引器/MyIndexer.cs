using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 索引器
{
    class MyIndexer
    {
        List<string> list = new List<string>();

        public MyIndexer()
        {
        }

        public string this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list.Add(value); 
            }
        }
    }
}
