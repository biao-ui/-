using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            //反射
            //可以动态获取程序集中类、属性、字段、方法等信息，并可以创建实例调用他们。
            //程序集
            //程序编译后会在debug文件夹中生成出编译后的文件，其中文件后缀名为 exe 与 dll 的文件则是编译后得到的程序集文件。

            //优点：
            //1、反射提高了程序的灵活性和扩展性。
            //2、降低耦合性，提高自适应能力。
            //3、它允许程序创建和控制任何类的对象，无需提前硬编码目标类。

            //缺点：
            //1、会比硬编码的效率低。
            //2、反射代码逻辑复杂不清晰，不好直观分析代码与需求



            //获取程序集信息
            //通过绝对路径获取程序集 Assembly.LoadFile
            //Assembly assembly = Assembly.LoadFile(@"C:\Users\Administrator\Desktop\基础回顾\反射\bin\Debug\反射.exe");

            //通过程序集名字直接获取程序集Assembly.LoadFrom
            //Assembly assembly2 = Assembly.LoadFrom("Dal.dll");

            //获取程序集中的“类”信息，并打印类的信息。GetTypes
            //Type[] types = assembly.GetTypes();
            //foreach (Type item in types)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.FullName);
            //    Console.WriteLine(item.IsClass);
            //}

            //获取指定类Student的成员信息，并打印成员的信息。GetMembers
            //Type studentType = assembly.GetType("反射.Student");
            //MemberInfo[] memberInfos = studentType.GetMembers();
            //foreach (MemberInfo item in memberInfos)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("====================================================");

            //获取指定类Student的属性信息，并打印属性的信息。GetProperties
            //PropertyInfo[] propertyInfos = studentType.GetProperties();
            //foreach (PropertyInfo item in propertyInfos)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //获取指定类Student的字段信息，并打印字段的信息。GetFields
            //FieldInfo[] fieldInfos = studentType.GetFields();
            //foreach (FieldInfo item in fieldInfos)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //获取公开方法与非公开方法
            //BindingFlags flags = BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;
            //BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

            //MethodInfo[] methodInfos = studentType.GetMethods(flag);
            //foreach (MethodInfo item in methodInfos)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //Console.WriteLine("====================================================");


            //在当前程序集中，获取Type的三种方式
            //1、静态方法：Type.GetType
            //Type studentType = Type.GetType("反射.Student");
            //Type class1Type = Type.GetType("Dal.Class1");
            //2、typeof关键字
            //Type studentType = typeof(Student);
            //3、object中的GetType方法
            //Student student1 = new Student();
            //Type studentType = student1.GetType();

            //反射创建对象
            //使用静态方法Activator.CreateInstance
            //Type studentType = typeof(Student);
            //object instance = (Student)Activator.CreateInstance(studentType);
            //Student instance2 = Activator.CreateInstance<Student>();

            //instance.Sing();



            //使用反射执行方法
            //执行没有参数没有返回值的方法
            //MethodInfo methodInfo = studentType.GetMethod("Sing");
            //methodInfo.Invoke(instance, new object[] { });
            //执行有参数有返回值的方法 Calculate
            //MethodInfo methodInfo2 = studentType.GetMethod("Calculate");
            //object res = methodInfo2.Invoke(instance, new object[] { 1, 2 });
            //执行私有方法
            //BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            //MethodInfo methodInfo3 = studentType.GetMethod("PrivateMethod", flag);
            //object res2 = methodInfo3.Invoke(instance, new object[] { });

            //题目：使用反射创建学生类实例，并且为学生信息的姓名属性赋值。调用实例方法SayHi方法
            //获取type类型实例
            #region 测试
            //Type studentType = typeof(Student);
            ////创建学生实例对象
            //object instance = Activator.CreateInstance(studentType);
            ////获取Name属性
            //PropertyInfo propertyInfo = studentType.GetProperty("Name");
            //propertyInfo.SetValue(instance, "zs");
            ////去name属性的值
            //object name = propertyInfo.GetValue(instance);

            ////通过type获取方法信息对象
            //BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            //MethodInfo methodInfo = studentType.GetMethod("SayHi", flag);
            //methodInfo.Invoke(instance, new object[] { "hello world" });
            #endregion

            //反射的应用
            //题目：模拟通过配置创建对象实例（类似IOC）
            #region 测试
            // 配置IPeople    Student
            //IPeople people;

            //Type studentType = typeof(Student);
            //Student student =  (Student)Activator.CreateInstance(studentType);

            //people = student;


            ////判断Student是不是IPeople的子类
            //bool b2 = typeof(Student).IsSubclassOf(typeof(Teacher));
            //bool b3 = typeof(Teacher).IsSubclassOf(typeof(Object));

            //bool b4 = typeof(IPeople).IsAssignableFrom(typeof(Student));
            #endregion


            #region 题目，做个控制器效果实现

            string inputString = Console.ReadLine();
            //     /Home/Index
            string[] strArr = inputString.Split('/');

            if (strArr.Length != 3)
            {
                Console.WriteLine("地址有误");
                Console.ReadKey();
                return;
            }

            //取出控制器的名字
            string controllerName = strArr[1] + "Controller";
            //转小写
            controllerName = controllerName.ToLower();

            //取出方法的名字
            string methodName = strArr[2].ToLower();

            if (string.IsNullOrEmpty(controllerName) || string.IsNullOrEmpty(methodName))
            {
                Console.WriteLine("控制器或方法有误");
                Console.ReadKey();
                return;
            }

            //获取当前项目运行的程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            //获取程序集中所有的type类型
            Type[] types = assembly.GetTypes();

            foreach (Type classItem in types)
            {
                //判断当前这个控制器的类型是否继承了Controller父类
                bool b = classItem.IsSubclassOf(typeof(Controller));
                //判断是否是Controller的子类，并且控制器的名字是否是用户输入的名字
                if (b && classItem.Name.ToLower() == controllerName)
                {
                    //创建实例
                    object instance = Activator.CreateInstance(classItem);

                    //获取方法信息的数组
                    MethodInfo[] methodInfos = classItem.GetMethods();
                    foreach (var methodItem in methodInfos)
                    {
                        if (methodItem.Name.ToLower() == methodName)
                        {
                            //调用方法
                            methodItem.Invoke(instance, new object[] { });
                            break;
                        }
                    }

                    break;
                }
            }
            #endregion

        }
    }
}
