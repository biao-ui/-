using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构
{
    class Program
    {
        static void Main(string[] args)
        {
            //一、线性表
            //线性表是最简单、最基本、最常用的数据结构。
            //特点是里面的元素之间是一对一的线性关系。
            //除了第一个元素之外，每个元素之前都有一个元素。
            //除了最后一个元素之外，每个元素之后都有一个元素。
            //简单来说就是每个元素都会有先后位置的关系，一个接着一个排列。

            //线性表又可以分为几种实现形式。顺序表、单链表、双链表等
            //1、顺序表：不仅逻辑上的位置相邻，内存的位置也相邻。都是一个元素接着一个元素按顺序保存。
            //特点是读取速度快，但是添加与删除相对慢。C#中数组就是这种结构 

            //练习：使用数组实现一个顺序表的集合
            #region 顺序表
            //int[] arr = new int[10];

            //List<int> list = new List<int>() { 11, 22, 33 };
            //list.Add(1);
            //list.Add(2);
            //list.Count
            //int index = list.IndexOf(2);
            //list.Insert
            //list.RemoveAt
            //list.Insert(100,100);
            //list.RemoveAt(index);

            //创建自定义的集合
            //CustomList<int> customList = new CustomList<int>() { 11, 22, 33 };

            //customList.Add(22);
            //customList.Add(33);
            //customList.Add(44);
            //customList.Add(55);
            //customList.Add(66);
            //customList.Add(77);
            //customList.Add(88);
            //customList.Insert(1,100);
            //int index2 = customList.IndexOf(33);

            //使用索引器get
            //int res = customList[2];
            //使用索引器set
            //customList[2] = 100;

            //customList.RemoveAt(2);
            //List<int> list = new List<int>();

            #region 数组里装的是引用类型是数据
            //CustomList<Student> customList = new CustomList<Student>();
            //customList.Add(new Student()
            //{
            //    Age = 18,
            //    Name = "zs"
            //});
            //customList.Add(new Student()
            //{
            //    Age = 19,
            //    Name = "ls"
            //});
            //customList.Add(new Student()
            //{
            //    Age = 20,
            //    Name = "ww"
            //});

            //customList.RemoveAtValue(new Student()
            //{
            //    Age = 19,
            //    Name = "ls"
            //});

            //customList.Clear();

            //Student student = new Student()
            //{
            //    Age = 18,
            //    Name = "zs"
            //};

            //Student student2 = new Student()
            //{
            //    Age = 18,
            //    Name = "zs"
            //};

            #endregion
            #endregion


            //线性表的另外一种存储结构
            //2、链式存储
            //链表要求逻辑相邻，但是物理存储（内存）可以不相邻。因此，对链表插入与删除时不需要移动数据元素，但也失去了连续读取的优势。
            //单链表：开始有一个头元素，结尾有个尾元素。只能有一个顺序往下走。
            //练习：实现一个单链表的集合

            #region 单链表
            //CustomList2<int> customList2 = new CustomList2<int>();
            //customList2.Add(11);
            //customList2.Add(22);
            //customList2.Add(33);
            //customList2.Add(44);
            //customList2.Add(55);
            ////customList2.Clear();
            //int count = customList2.Count;
            //int index1 = customList2.IndexOf(11);
            //int index2 = customList2.IndexOf(22);
            //int index3 = customList2.IndexOf(33);
            //int index4 = customList2.IndexOf(44);

            ////customList2.Insert(2,100);

            ////customList2.RemoveAt(0);
            ////customList2.RemoveAt(3);

            //int value1 = customList2[0];
            //int value2 = customList2[4];

            //customList2[0] = 1;
            //customList2[4] = 100;


            #endregion

            //问题:1、c#中集合为什么能foreach遍历。
            //因为实现了IEnumerable这个接口
            //问题:2、为什么又可以初始化集合的时候，直接赋值元素到集中。
            //因为实现了add方法

            //二、栈和队列
            //线性表、栈和队列这三种数据结构的数据元素以及数据元素间的逻辑关系完全相同，差别是线性表的操作不受限制，而栈和队列的操作受到限制。
            //栈的操作只能在表的一端进出元素。队列的插入操作在表的一端进行，取出操作在表的另一端进行，所以，把栈和队列称为操作受限的线性表。
            //1、栈
            //栈结构的特点是先进去的元素，最后才能取出来。最后进去的元素，可以最先取出来。简单来说就是“先进后出,后进先出”。
            //c#中提供了栈的数据类型--> Stack<>
            //常用方法
            //Push()入栈（添加数据）
            //Pop()出栈（删除数据，返回被删除的数据）
            //Peek()取得栈顶的数据，不删除
            //Clear()清空所有数据
            //Count取得栈中数据的个数

            #region 测试常用方法

            //Stack<int> stack = new Stack<int>();

            //stack.Push(11);
            //stack.Push(22);
            //stack.Push(33);
            //stack.Push(44);
            //stack.Push(55);

            //Console.WriteLine($"栈中有{stack.Count()}个元素");

            //int i1 = stack.Pop();
            //Console.WriteLine(i1);
            //Console.WriteLine($"栈中有{stack.Count()}个元素");


            //int i2 = stack.Peek();
            //Console.WriteLine(i2);
            //Console.WriteLine($"栈中有{stack.Count()}个元素");

            //stack.Clear();
            //Console.WriteLine($"栈中有{stack.Count()}个元素");

            List<int> list = new List<int>() { 11, 22, 33, 44, 55 };
            //55 44 33 22 11 
            List<int> newList = new List<int>();

            //栈 先进后出
            Stack<int> stack = new Stack<int>();
            foreach (var item in list)
            {
                stack.Push(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
                newList.Add(item);
            }

            #endregion

            //2、队列
            //队列结构的特点是先进去的元素，最先取出来。最后进去的元素，最后才可以取出来。简单来说就是“先进先出，后进后出”
            //c#中提供了队列的数据类型--> Queue<>
            //Enqueue()入队(放在队尾)
            //Dequeue()出队(移除队首元素，并返回被移除的元素)
            //Peek()取得队首的元素，不移除
            //Clear()清空元素 属性
            //Count获取队列中元素的个数
            #region 测试常用方法
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue("11");
            //queue.Enqueue("22");
            //queue.Enqueue("33");
            //queue.Enqueue("44");
            //queue.Enqueue("55");

            //Console.WriteLine($"栈中有{queue.Count()}个元素");
            //string s1 = queue.Dequeue();
            //Console.WriteLine(s1);
            //Console.WriteLine($"栈中有{queue.Count()}个元素");

            //string s2 = queue.Peek();
            //Console.WriteLine(s2);
            //Console.WriteLine($"栈中有{queue.Count()}个元素");

            //queue.Clear();
            //Console.WriteLine($"栈中有{queue.Count()}个元素");
            #endregion


            //三、串
            //在应用程序中使用最频繁的类型是字符串。字符串简称串，是一种特殊的线性表，其特殊性在于串中的数据元素是一个个的字符。char
            //在 C#中，一个 String 表示一个恒定不变的"字符"序列集合。
            //String 类型是封闭类型，所以，它不能被其它类继承，而它直接继承自 object。因此， String 是引用类型，不是值类型
            //练习：使用数组实现一个字符串
            #region 练习
            //string str = "abcabcabc";
            //string newStr = str.Replace('c','f');
            //newStr = string.Join(",", new string[] { "aa", "bb", "cc" });

            //CustomString customString =  new CustomString(new char[] { 'a','b','c','a','b','c','a','b','c' });
            //string newStr2 = customString.Replace('c', 'f');

            //newStr2 = CustomString.Join(",", new string[] { "aa", "bb", "cc" });
            #endregion


            //四、数组
            //数组是一种常用的数据结构，可以看作是线性表的推广。数组可以看成是一种数据类型的合集，可以存放不同的数据类型，甚至还可以是数组。
            //多维数组：数组中的元素还是数组。
            //int[] arr1 = new int[] { 11, 22, 33 };
            //int[] arr2 = new int[] { 44, 55, 66 };

            //二维数组
            //int[][] bArr = new int[][] { arr1, arr2 };
            //int res = bArr[1][2];

            #region 研究数组排序算法
            //冒泡排序
            //int[] arr1 = new int[] { 99, 88, 77, 66 };
            //Ordey2(arr1);
            //插入排序
            //int[] arr2 = new int[] { 66, 3, 24, 7, 44, 2, 10 };
            //Ordey2(arr2);
            #endregion

            //五、字典  Dictionary<>
            //字典表示一种复杂的数据结构，这种数据结构允许按照某个"键"来访问元素。字典也称为映射或散列表。
            //字典的Key——Value映射是利用哈希函数来建立的。
            //什么是哈希函数呢？
            //把一个对象转换成唯一且确定值的函数就叫做哈希函数，也叫做散列函数。
            //这个值就叫做哈希码（hashCode），在C#里一般是一个32位正整数。
            //就好比每一个人都对应一个身份证号码。
            //简单来说字典是通过 key -> value 的形式存取值，字典中保存了很多组的key-value。效率不算高，但是使用起来能方便查找数据。

            #region 测试字典的用法
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("zs", "张三");
            dic.Add("ls", "李四");
            dic.Add("ww", "王五");
            //dic.Add("zs", "赵六");
            //dic["zs"] = "赵六";

            string res;
            dic.TryGetValue("ls", out res);

            //每个对象通过计算hash值都一个唯一值，相同的对象计算出的hash是同一个
            string str1 = "zs";
            string str2 = "ls";

            int hashCode1 = str1.GetHashCode(); //-839403562 
            int hashCode2 = str2.GetHashCode(); //-839403580
            int hashCode3 = str2.GetHashCode(); //-839403580

            Student student1 = new Student() { Age = 18, Name = "zs" };
            Student student2 = new Student() { Age = 19, Name = "ls" };
            int hashCode4 = student1.GetHashCode(); //46104728
            int hashCode5 = student2.GetHashCode(); //12289376

            Dictionary<Student, Student> dic2 = new Dictionary<Student, Student>();
            dic2.Add(student1, student1);
            dic2.Add(student2, student2);

            Student student3;
            //dic2.TryGetValue(student1, out student3);
            Student student4;
            //dic2.TryGetValue(student2, out student4);

            student3 = dic2[student1];
            student4 = dic2[student2];

            dic2[student1] = new Student() { Age = 20, Name = "ww" };
            Student student5 = dic2[student1];


            #endregion
        }



        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        public static void Ordey1(int[] arr)  // 99 88 77 66   lenth = 4
        {
            for (int i = 0; i < arr.Length - 1; i++)  //排序的大回合数      3       1(i=0)        2(i=1)       3(i=2)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)//排序的大回合数  3     4-1-i=3      4-1-i=2       4-1-i=1
                {
                    if (arr[j] > arr[j + 1])
                    {
                        //临时接受对比左边的数据
                        int temp = arr[j];

                        //把右边的值赋值给左边
                        arr[j] = arr[j + 1];
                        //把左边的值赋值到右边
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arr"></param>
        public static void Ordey2(int[] arr)
        {
            for (int i = 1; i <= arr.Length - 1; i++) //大回合数
            {
                //拿出当前大回合比较的数字
                int currentValue = arr[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    int tempValue = arr[j]; //2大回合
                    if (currentValue < tempValue)
                    {

                        arr[j + 1] = tempValue;  //2大回合
                        arr[j] = currentValue;
                    }
                }
            }
        }
    }
}
