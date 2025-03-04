using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 封装
{
    public class Animal
    {
        //无参数的构造函数
        public Animal()
        {

        }

        public Animal(string body)
        {
            Body = body;
        }


        //field
        private string _head;

        //property
        public string Head
        {
            get
            {
                return _head;
            }
            set
            {
                _head = value;
            }
        }

        public string Eyes { get; set; }

        public string Body { get; set; }

        public void Run()
        {

        }

        public void Run(string content)
        {

        }

        public void Run(int minute)
        {

        }

        public void Run(int minute, string content)
        {

        }

        //public bool Run(int minute, string content)
        //{
        //    return false;
        //}

        //public void Run(int second, string day)
        //{

        //}
    }
}
