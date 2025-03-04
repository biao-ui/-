using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 索引器
{
    class MyIndexer2
    {
        List<MyModel> list = new List<MyModel>();

        public string this[string index]  //zs
        {
            get
            {
                MyModel model = null;
                foreach (MyModel item in list)
                {
                    if (item.Key == index)
                    {
                        model = item;
                        break;
                    }
                }

                //默认找集合中的第一个元素
                //MyModel model2 = list.FirstOrDefault(); //找不到返回null
                MyModel model2 = list.FirstOrDefault(item => item.Key == index); //找不到返回null
                MyModel model3 = list.First();//找不到直接报错

                if (model != null)
                {
                    return model.Value;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                MyModel model = new MyModel()
                {
                    Key = index,   //"zs" 
                    Value = value  //张三
                };
                list.Add(model);
            }
        }
    }
}
