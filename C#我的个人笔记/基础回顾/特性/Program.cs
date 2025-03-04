using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    class Program
    {
        static void Main(string[] args)
        {
            //特性
            //特性其实是一个Class(类)，声明的时候，默认以Attribute结尾，直接或者是间接继承在Attribute抽象类
            //特性可以作用在类的多个地方
            //如何为特性有参构造方法传入参数
            //如何为特性的字段或属性赋值
            //特性是一个类，那特性什么时候创建对象

            //Student student = new Student();

            #region 练习，特性何时创建对象，从而调用特性中的方法。
            //想创建特性对象（实例）必须配合反射使用，特性写在哪，首先要使用反射获取到对应的反射信息。
            //Type studentType = typeof(Student);
            //判断一个类型是否定义了某个特性IsDefined()
            //bool b = studentType.IsDefined(typeof(CustomAttribute), false);
            //if (b)
            //{
            //    //GetCustomAttribute<特性类型>()
            //    CustomAttribute customAttribute = studentType.GetCustomAttribute<CustomAttribute>();
            //    //customAttribute._name = "zs";
            //    customAttribute.Hi();
            //}

            #region 获取属性上的特性

            //先获取属性信息
            //PropertyInfo[] propertyInfos =   studentType.GetProperties();
            //foreach (PropertyInfo item in propertyInfos)
            //{
            //    if (item.IsDefined(typeof(CustomAttribute)))
            //    {
            //        //获取属性上的特性
            //        CustomAttribute customAttribute = item.GetCustomAttribute<CustomAttribute>();
            //        customAttribute.Hi();
            //    }
            //}
            #endregion

            #endregion

            #region 题目，通过特性在控制台上打印出下面学生对象的信息，如：Name = "zs" ，就要输入 “姓名（Name）：zs,年龄（Age）：18”

            //Student student = new Student();
            //student.Name = "zs";
            //student.Id = 1;
            //student.BirthDay = DateTime.Now;
            //student.Address = "南宁";
            //student.Age = 18;

            ////名字：zs
            ////主键：1
            ////姓名（Name）：zs

            ////1、获取学生的Type类型
            //Type studentType = student.GetType();
            ////2、获取学到全部属性
            //PropertyInfo[] propertyInfos = studentType.GetProperties();
            //foreach (PropertyInfo item in propertyInfos)
            //{
            //    //2.1、先判断属性头是否有忽略特性IgnoreAttribute，有的话就不用输出了
            //    bool b = item.IsDefined(typeof(IgnoreAttribute));
            //    if (!b)
            //    {
            //        //3、获取属性头上的特性
            //        Custom2Attribute customAttribute = item.GetCustomAttribute<Custom2Attribute>();
            //        //4、获取特性中name值
            //        string dispalyName = customAttribute.Name;
            //        //5、获取属性的名字
            //        string propertyName = item.Name;
            //        //6、获取属性里的值
            //        object value = item.GetValue(student);

            //        string res = dispalyName + "(" + propertyName + "):" + value;
            //        Console.WriteLine(res);
            //    }
            //}

            #endregion


            //任务：写一个学生类，通过这个类，生sql语句 create table 表名字(字段名字 数据类型, 字段名字 数据类型)。
            //要求1：可以在学生类的属性上加特性[Column(TypeName = "varchar(18)")]，表示生成这个属性到数据库时，数据库的数据类型为varchar(18)。
            //要求2：可以在学生类的属性上加特性[IgnoreAttribute]，表示这个属性不需要生成到数据库中。
            //提示：可以参考今天上课的特性内容来做。
            #region 
            Type studentType = typeof(Student);
            //表名字
            string tableName = studentType.Name;
            //获取所有属性
            PropertyInfo[] propertyInfos = studentType.GetProperties();

            string sql = "create table " + tableName + " (";

            foreach (PropertyInfo item in propertyInfos)
            {
                //先判断属性头上有没有ignore这个特性，有点话这个属性就不用生成sql
                bool isHas1 = item.IsDefined(typeof(IgnoreAttribute));
                if (isHas1)
                {
                    //有就跳过这个循环
                    continue;
                }
                //数据库的数据类型
                string sqlTypeName = null;

                //属性的名字
                string propertyName = item.Name;
                //获取属性的数据类型
                string typeName = item.PropertyType.Name;

                sql += propertyName;

                //判断当前遍历的属性头上是否有定义Column特性，如果有证明想修改数据库数据类型
                bool isHas2 = item.IsDefined(typeof(ColumnAttribute));
                if (isHas2)
                {
                    //创建特性的实例对象
                    ColumnAttribute columnAttribute = item.GetCustomAttribute<ColumnAttribute>();
                    //读取特性里TypeName的值
                    sqlTypeName = columnAttribute.TypeName;
                }
                else
                {
                    switch (typeName)
                    {
                        case "Int32":
                            sqlTypeName = "int";
                            break;
                        case "String":
                            sqlTypeName = "varchar(50)";
                            break;
                        case "Boolean":
                            sqlTypeName = "bit";
                            break;
                        case "DateTime":
                            sqlTypeName = "datatime2";
                            break;
                        default:
                            return;
                    }
                }

                sql += " " + sqlTypeName + ",";
            }

            sql = sql.TrimEnd(',');
            sql += ")";

            Console.WriteLine(sql);
            #endregion

        }
    }
}
