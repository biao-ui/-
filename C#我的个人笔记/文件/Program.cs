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
            //注意：使用\符号的时候要注意，一个\代表转译，两个\\才是代表一个\的字符串。或者使用@符号，代表@符号后面的字符串不要转译
            DirectoryInfo directory = new DirectoryInfo(@"d:\test");
            
            //1、常用方法
            #region 常用方法
            //创建文件夹
            //directory.Create();
            //Directory.CreateDirectory(@"d:\test");
            //删除文件夹，当文件夹里还有东西不能删除
            //directory.Delete();

            //文件夹剪切或重命名
            //directory.MoveTo(@"d:\test2");
            //获取文件夹下的子文件夹
            //DirectoryInfo[] directoryInfos = directory.GetDirectories();
            //获取文件夹下的文件
            //FileInfo[] fileInfos = directory.GetFiles();


            //静态方法
            //获取当前项目运行的文件夹路径
            //string path = Directory.GetCurrentDirectory();

            //练习：再当前项目运行的文件夹中创建一个test的文件夹
            //DirectoryInfo directory = new DirectoryInfo(path + "\\test");
            //directory.Create();

            //判断文件夹是否存在
            //bool exist = Directory.Exists(@"C:\Users\Administrator\Desktop\基础回顾\文件\bin\Debug");


            #endregion

            //2、常用属性
            #region 常用属性
            //DirectoryInfo directory = new DirectoryInfo(@"d:\test\test2");
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
            ////使用静态方法创建文件夹
            //DirectoryInfo directoryInfo = Directory.CreateDirectory("./demo2");

            ////合并两个字符串路径
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
            FileInfo fileInfo = new FileInfo(@".\newFile.txt");



            //1、常用方法
            #region 常用方法
            //创建文件
            //fileInfo.Create();
            //删除文件
            //fileInfo.Delete();
            //文件剪切
            //fileInfo.MoveTo(@"./demo/newFile.txt");
            //文件复制
            //fileInfo.CopyTo(@".\newFile2.txt");
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
            //DeleteDirectory(@"D:\test");

            //DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\test");
            //DeleteDirectory(directoryInfo);
            #endregion

            #region 测试写故事的方法
            //WriteGS("gs.txt","鹅鹅鹅",@"d:\");
            #endregion
            //题目2：封装一个方法，移动一个文件夹下的所有文件。
            //MoveDirectory(@"D:\Test", @"D:\Demo\Test");

            //四、流
            //流可以看成把一个文件分成块水流，给他接一个水管一点点的去传输搬运，一般可以处理大文件。
            //读取流：从外部传输到程序中(从硬盘到程序)
            //写入流：从程序中传输到外部(从程序到硬盘)

            #region 练习
            //1、文件流 FileStream
            //如何创建一个文件读取流
            //(string path, FileMode mode, FileAccess access)
            //FileStream fileStream =  new FileStream(@"d:\Test.txt", FileMode.Create,FileAccess.ReadWrite);

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
            FileStream readStream = new FileStream(@"D:\touxiang.png", FileMode.Open, FileAccess.Read);
            FileStream writeStream = new FileStream(@"D:\touxiang2.png", FileMode.Create, FileAccess.Write);

            //(byte[] array, int offset, int count);
            byte[] buffer = new byte[1024];  //1024字节 1kb
            //读取

            while (true)
            {
                int readCount = readStream.Read(buffer, 0, buffer.Length);
                if (readCount == 0)
                {
                    break;
                }
                writeStream.Write(buffer, 0, readCount);
            }

            writeStream.Close();
            readStream.Close();
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

            #region 测试
            //创建文件夹
            //1、
            //DirectoryInfo directoryInfo = Directory.CreateDirectory("古诗");

            //创建古诗文件
            //2、
            //WriteGS("古诗1.txt", "哈哈哈哈哈，呵呵呵呵呵", directoryInfo.FullName);
            //WriteGS("古诗2.txt", "哈哈哈哈哈，呵呵呵呵呵", directoryInfo.FullName);

            //3、
            //在D盘根目录创建一个文件夹
            //DirectoryInfo directoryInfo2 = Directory.CreateDirectory(@"d:\古诗");

            ////获取要复制的文件夹下有什么文件
            //FileInfo[] files = directoryInfo.GetFiles();
            //foreach (FileInfo item in files)
            //{
            //    //拼接一个文件的名字
            //    string filePath = Path.Combine(directoryInfo2.FullName, item.Name);
            //    item.CopyTo(filePath);
            //}

            //4、
            //foreach (FileInfo item in files)
            //{
            //    item.Delete();
            //}


            #endregion

            //题目二：
            //随便找一个大文件（大概十几MB的文件），使用文件流的方式完成拷贝的功能。
            //要求当文件拷贝10MB大小后，然后每间隔一秒中才继续拷贝1KB的数据。提示用户：“你是试用时间已经结束，并在控制台打印出“拷贝完成了1kB的数据”。

            ////读取流
            //FileStream readStream = new FileStream(@"E:\工作\讲课\学校（柳职）\20届\RepositorySys.rar", FileMode.Open,FileAccess.Read);

            ////写入流
            //FileStream writeStream = new FileStream(@"E:\工作\讲课\学校（柳职）\20届\RepositorySys2.rar", FileMode.Create, FileAccess.Write);

            //int length = 1024;
            //byte[] buffer = new byte[length * 1024 * 40];  //10MB数组

            ////从文件中读取数据到byte数组中
            //int readCount = readStream.Read(buffer,0, buffer.Length);

            ////写数据，用写入文件流
            //writeStream.Write(buffer, 0, readCount);

            //Console.WriteLine("你是试用时间已经结束");

            //byte[] buffer2 = new byte[length];  //1kb数组
            //while (true)
            //{
            //    //Thread.Sleep(10);
            //    //从文件中读取数据到byte数组中
            //    readCount = readStream.Read(buffer2, 0, buffer2.Length);
            //    if (readCount == 0)
            //    {
            //        break;
            //    }
            //    //写数据，用写入文件流
            //    writeStream.Write(buffer2, 0, readCount);
            //    Console.WriteLine("你是试用时间已经结束，并在控制台打印出“拷贝完成了1kB的数据");
            //}

            //writeStream.Close();
            //readStream.Close();
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            //1、删除文件夹里面的文件
            //1.1、获取文件夹下有哪些文件
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            //1.2、遍历文件的数组，一个个的删除文件
            foreach (FileInfo item in fileInfos)
            {
                item.Delete();
            }

            //2、删除当前文件夹下的子文件夹
            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            //2.2、遍历文件夹的数组，一个个文件夹都要清空
            foreach (DirectoryInfo directoryInfoItem in directories)
            {
                //调用自己的方法
                DeleteDirectory(directoryInfoItem.FullName);
            }

            //删除当前文件夹
            directoryInfo.Delete();
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteDirectory(DirectoryInfo directoryInfo)
        {
            //1、删除文件夹里面的文件
            //1.1、获取文件夹下有哪些文件
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            //1.2、遍历文件的数组，一个个的删除文件
            foreach (FileInfo item in fileInfos)
            {
                item.Delete();
            }

            //2、删除当前文件夹下的子文件夹
            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            //2.2、遍历文件夹的数组，一个个文件夹都要清空
            foreach (DirectoryInfo directoryInfoItem in directories)
            {
                //调用自己的方法
                DeleteDirectory(directoryInfoItem);
            }

            //删除当前文件夹
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

        /// <summary>
        /// 写古诗的方法
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="context"></param>
        public static void WriteGS(string fileName, string context, string path)
        {

            //拼接文件路径
            string filePath = Path.Combine(path, fileName);
            //先删除文件
            //File.Delete(filePath);
            //给文件追加文字，没有文件创建文件
            File.AppendAllText(filePath, context);
        }
    }
}
