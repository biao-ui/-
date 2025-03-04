using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //一、文件夹管理  DirectoryInfo  与 Directory 
            //DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Administrator\Desktop\基础回顾\文件\bin\Debug");

            //1、常用方法
            #region 常用方法
            //创建文件夹
            //directory.Create();
            //删除文件夹，当文件夹里还有东西不能删除
            //directory.Delete();
            //文件夹剪切或重命名
            //directory.MoveTo(@"d:\test2\test");
            //获取文件夹下的子文件夹
            //DirectoryInfo[] directoryInfos = directory.GetDirectories();
            //获取文件夹下的文件
            //FileInfo[] fileInfos = directory.GetFiles();


            //静态方法
            //获取当前项目运行的文件夹路径
            //string path = Directory.GetCurrentDirectory();
            //判断文件是否存在
            //bool exist = Directory.Exists(@"C:\Users\Administrator\Desktop\基础回顾\文件\bin\Debug");

            #endregion

            //2、常用属性
            #region 常用属性
            ////打印文件夹的名字
            //Console.WriteLine(directory.Name);
            ////打印文件夹的全名字
            //Console.WriteLine(directory.FullName);
            ////判断文件夹是否存在
            //Console.WriteLine(directory.Exists);

            #endregion

            //二、路径
            //1、绝对路径：明确到磁盘的上精确位置，如：C:\文件夹\文件。
            //2、相对路径：相对于当前项目运行的文件夹位置来确定的位置。  ./ 当前目录      ../ 当前的上一级
            //3、Path类:处理路径相关信息的帮助类
            #region 常用方法
            //使用静态方法创建文件夹
            //DirectoryInfo directoryInfo = Directory.CreateDirectory("./demo2");

            //合并两个字符串路径
            //string path1 = @"d:\test2";
            //string path2 = @"test\demo";
            //string fileName = @"aaa.bb.cc.txt";
            //string newPath = Path.Combine(path1, path2, fileName);
            ////获取路径中的拓展名
            //string extensionName = Path.GetExtension(newPath);
            ////获取路径文件夹部分
            //string directoryPath = Path.GetDirectoryName(newPath);
            ////获取路径文件部分
            //string filePath = Path.GetFileName(newPath);
            #endregion


            //三、文件管理
            //FileInfo  File
            //FileInfo fileInfo = new FileInfo(@"newFile.txt");

            //1、常用方法
            #region 常用方法
            //创建文件
            //fileInfo.Create();
            //删除文件
            //fileInfo.Delete();
            //文件剪切
            //fileInfo.MoveTo(@"./demo/newFile.txt");
            //文件复制
            //fileInfo.CopyTo(@"C:\Users\Administrator\Desktop\基础回顾\文件\bin\Debug\demo\newFile2.txt");
            #endregion

            //2、常用属性
            #region 常用属性
            ////打印文件的名字
            //Console.WriteLine(fileInfo.Name);
            ////打印文件的全名字
            //Console.WriteLine(fileInfo.FullName);
            ////判断文件是否存在
            //Console.WriteLine(fileInfo.Exists);
            ////获取文件的拓展名
            //Console.WriteLine(fileInfo.Extension);
            ////获取文件的大小 
            //Console.WriteLine(fileInfo.Length);
            #endregion


            //题目1：封装一个方法，删除一个不是空的文件夹。
            #region MyRegion
            //DeleteDirectory(@"D:\test2");
            #endregion
            //题目2：封装一个方法，移动一个文件夹下的所有文件。
            //MoveDirectory(@"D:\Test", @"D:\Demo\Test");

            //四、流
            //流可以看成把一个文件分成块水流，给他接一个水管一点点的去传输搬运，一般可以处理大文件。
            //读取流：从外部传输到程序中
            //写入流：从程序中传输到外部

            #region 练习
            //1、文件流 FileStream
            //如何创建一个文件读取流
            //(string path, FileMode mode, FileAccess access)

            //如何创建一个文件写入流




            //题目1：使用文件流复制文件
            //先读取我要赋值的文件，加载到流中
            #region 一个个字节读取
            //FileStream readStream = new FileStream(@"D:\newFile.txt", FileMode.Open, FileAccess.Read);
            //FileStream writeStream = new FileStream(@"D:\newFile2.txt", FileMode.Create, FileAccess.Write);
            ////读取一个字节
            //int byteNum = 0;
            //while (true)
            //{
            //    byteNum = readStream.ReadByte();
            //    if (byteNum == -1)
            //    {
            //        break;
            //    }
            //    writeStream.WriteByte((byte)byteNum);
            //}
            ////注意：文件流是非托管资源,必须手动关闭资源
            //writeStream.Close();
            //readStream.Close();
            #endregion

            #region 按照数组大小来读取
            //FileStream readStream = new FileStream(@"D:\touxiang.png", FileMode.Open, FileAccess.Read);
            //FileStream writeStream = new FileStream(@"D:\touxiang2.png", FileMode.Create, FileAccess.Write);

            ////(byte[] array, int offset, int count);
            //byte[] buffer = new byte[1024];  //1024字节 1kb
            ////读取

            //while (true)
            //{
            //    int readCount = readStream.Read(buffer, 0, buffer.Length);
            //    if (readCount == 0)
            //    {
            //        break;
            //    }
            //    writeStream.Write(buffer, 0, readCount);
            //}

            //writeStream.Close();
            //readStream.Close();
            #endregion

            #endregion


            //2、文本流 
            #region 练习
            //StreamReader
            //FileStream readStream = new FileStream(@"D:\newFile.txt", FileMode.Open, FileAccess.Read);

            //文本读取流
            //StreamReader streamReader = new StreamReader(readStream);
            //while (true)
            //{
            //    string content = streamReader.ReadLine();
            //    if (content == null)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(content);
            //}

            ////文本写入流
            //FileStream writeStream = new FileStream(@"D:\newFile.txt", FileMode.Append, FileAccess.Write);
            ////StreamWriter
            //StreamWriter streamWriter = new StreamWriter(writeStream);

            //streamWriter.WriteLine("abc");

            //streamWriter.Close();
            //writeStream.Close();

            #endregion

            //题目一：
            //1、在当前项目运行的文件下，创建一个新的文件夹（名为：古诗）。
            //2、使用流的形式把一下的几首古诗，分别写出自己的文件。
            //3、把生成好文件的文件夹一并复制到电脑的D盘目录中。
            //4、把古诗文件夹下的文件全部删除

            //题目二：
            //随便找一个大文件（大概十几MB的文件），使用文件流的方式完成拷贝的功能。
            //要求当文件拷贝10MB大小后，然后每间隔一秒中才继续拷贝1KB的数据。提示用户：“你是试用时间已经结束，并在控制台打印出“拷贝完成了1kB的数据”。


        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(string path)
        {
            //获取要删除的目录
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            //先获取目录下的文件信息
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (FileInfo item in fileInfos)
            {
                //先删除目录下的文件
                item.Delete();
            }

            //获取目录下的所有文件夹
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            foreach (DirectoryInfo item in directoryInfos)
            {
                DeleteDirectory(item.FullName);
            }

            //删除文件夹
            directoryInfo.Delete();
        }

        /// <summary>
        /// 文件移动
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        public static void MoveDirectory(string path1, string path2)
        {
            //获取文件夹信息
            DirectoryInfo directoryInfo = new DirectoryInfo(path1);

            directoryInfo.MoveTo(path2);
        }
    }
}
