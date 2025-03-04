using System;
using System.Collections.Generic;
using System.Text;

namespace 反射
{
    public class Student : Teacher, IPeople
    {
        public Student()
        {

        }

        public string _address;

        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

        /// <summary>
        /// 私有属性
        /// </summary>
        private string Mobile { get; set; }

        public void Eat()
        {
            IPeople people;
            Console.WriteLine("吃东西");
        }
        public void Sing()
        {
            IPeople people;
            Console.WriteLine("唱歌");
        }
        public int Calculate(int a, int b)
        {
            IPeople people;
            return a + b;
        }

        private void SayHi(string content)
        {
            Console.WriteLine($"我叫{this.Name},{content}。");
        }

        /// <summary>
        /// 私有方法
        /// </summary>
        /// <returns></returns>
        private string PrivateMethod()
        {
            return "我是一个私有方法";
        }
    }
}
