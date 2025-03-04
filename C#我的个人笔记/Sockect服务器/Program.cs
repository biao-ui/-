using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sockect服务器
{
    class Program
    {

        static void Main(string[] args)
        {
            //网络：
            //可以从服务器中获取数据
            //可以把数据上传到服务器

            //内网：局域网
            //外网：广域网、公网、互联网
            //画图讲解内网与外网的区别

            //IP：网络地址
            //如：192.168.1.11 （ipv4）
            //用于确定设备在网络中的地址

            //端口号：0-65535
            //一般来说1000一下的端口号是系统使用的端口号
            //用户确定电脑中是哪个软件

            //Socket  -- 套接字 插座
            //Socket又称套接字，它是处于应用层和传输层之间的一个抽象接口。
            //它封装了TCP/UDP等的底层协议，通过它我们就可以实现应用程序或者进程之间（它们可以处在网络上的不同位置）的通信。
            //TCP:长连接，连接之前进行三次握手。特点可靠
            //UDP:无连接，特点快速，但是不安全

            #region 代码
            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            ////开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //Socket acceptSocket = socketServer.Accept();


            //byte[] datas = new byte[1024];
            ////读取客户端发送过来的内容
            //int readCount = acceptSocket.Receive(datas);

            //string r_msg = Encoding.UTF8.GetString(datas, 0, readCount);
            //Console.WriteLine(r_msg);

            ////给客户端发消息
            //string s_msg = "我是服务器，我接受到消息了";
            //acceptSocket.Send(Encoding.UTF8.GetBytes(s_msg));

            //Console.WriteLine("--------------连接完成，程序走到最后面了------------");

            ////使用完socket要关闭资源
            //acceptSocket.Close();
            //socketServer.Close();
            #endregion



            //题目1：做一个客户端，用户输入什么消息就发送给服务器端，服务器端接受到了并打印客户端的消息。（客户端可以多次发送消息，服务器端也可以多次接受消息）
            #region 题目1
            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            ////开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //Socket acceptSocket = socketServer.Accept();

            //byte[] datas = new byte[1024];

            //while (true)
            //{
            //    //接收客户端发来的消息
            //    int readCount = acceptSocket.Receive(datas);
            //    if (readCount == 0)
            //    {
            //        break;
            //    }

            //    string msg = Encoding.UTF8.GetString(datas, 0, readCount);
            //    Console.WriteLine(msg);
            //}

            //acceptSocket.Close();
            //socketServer.Close();
            #endregion
            //题目2：使用多个客户端连接服务器端，客户端每隔2秒发送一个句话给服务器端，服务器端就打印客户端说的话，并且服务器端也回一句“服务器收到消息了”给客户端。
            #region 题目2
            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            //while (true)
            //{
            //    //开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //    Socket acceptSocket = socketServer.Accept();

            //    //开任务（开启线程）
            //    Task.Run(() =>
            //    {
            //        byte[] datas = new byte[1024];

            //        while (true)
            //        {
            //            //接收客户端发来的消息
            //            int readCount = acceptSocket.Receive(datas);
            //            if (readCount == 0)
            //            {
            //                break;
            //            }

            //            string msg = Encoding.UTF8.GetString(datas, 0, readCount);
            //            Console.WriteLine(msg);

            //            //发回给客户端
            //            acceptSocket.Send(Encoding.UTF8.GetBytes("服务器收到消息了"));
            //        }

            //        acceptSocket.Close();
            //        //socketServer.Close();

            //    });
            //}


            #endregion
            //题目3：客户端与服务器连接后，客户端自动发送一个图片给服务器端，并保存服务器端项目的运行文件夹中。
            #region 题目3
            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            ////开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //Socket acceptSocket = socketServer.Accept();

            //byte[] datas = new byte[1024 * 10];
            ////接收客户端发来的消息
            //int readCount = acceptSocket.Receive(datas);

            ////获取当前项目运行的文件夹
            //string currentPath = Directory.GetCurrentDirectory();
            //string fileName = "touxiang.png";
            //string filePath = Path.Combine(currentPath, fileName);

            ////创建文件流
            //FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            //fileStream.Write(datas, 0, readCount);

            //fileStream.Close();
            //#endregion
            //Console.ReadKey();
            #endregion

            #region 拷贝文件功能  --- 服务器（共享文件夹）


            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.1.221");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            ////开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //Socket acceptSocket = socketServer.Accept();


            //while (true)
            //{
            //    byte[] buffer = new byte[1024];
            //    //等待客户端发送文件信息并读取文件信息
            //    int readCount = acceptSocket.Receive(buffer);
            //    string jsonStr = Encoding.UTF8.GetString(buffer, 0, readCount);

            //    //反序列化得到文件信息对象
            //    List<CustomFileInfo> infos = JsonConvert.DeserializeObject<List<CustomFileInfo>>(jsonStr);




            //    ////获取文件夹信息
            //    DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\测试拷贝功能\服务器共享文件夹");
            //    //获取文件夹下面有什么文件
            //    FileInfo[] fileInfos = directoryInfo.GetFiles();

            //    foreach (var item in infos)
            //    {
            //        //判断自己的共享文件夹下有没有当前遍历的这个文件
            //        bool isHad = fileInfos.Any(f => f.Name == item.FileName);
            //        if (!isHad)
            //        {
            //            //改这个字段为true,说白就是告诉客户端我没有这个文件，等下你发过来
            //            item.IsSend = true;
            //        }
            //    };

            //    //把处理好的文件信息再发送回客户端，通知他要发什么文件过来
            //    string sendJsonStr = JsonConvert.SerializeObject(infos);

            //    byte[] sendDatas = Encoding.UTF8.GetBytes(sendJsonStr);

            //    //发送服务器想要的文件信息数据给客户端
            //    acceptSocket.Send(sendDatas);

            //    buffer = new byte[1024 * 1024 * 1024]; //1GB
            //                                           //接收客户端发来的文件信息（包含了文件的名字与文件的数据）
            //    readCount = acceptSocket.Receive(buffer);

            //    jsonStr = Encoding.UTF8.GetString(buffer, 0, readCount);

            //    List<CustomFileInfo> infos2 = JsonConvert.DeserializeObject<List<CustomFileInfo>>(jsonStr);
            //    foreach (var item in infos2)
            //    {
            //        if (item.IsSend)
            //        {
            //            string filePath = Path.Combine(@"D:\测试拷贝功能\服务器共享文件夹", item.FileName);
            //            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            //            {
            //                fs.Write(item.Datas, 0, item.Datas.Length);
            //            }
            //        }
            //    }

            //    //发数据通知客户端，拷贝完成。你客户端可以重新等待接收我想要的信息数据。
            //    Thread.Sleep(1000 * 30);
            //    string str = "弄完了，可以重新了等我数据。";
            //    acceptSocket.Send(Encoding.UTF8.GetBytes(str));
            //}



            #endregion

            #region 指定规则
            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.4.141");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            ////开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //Socket acceptSocket = socketServer.Accept();

            ////接收文件信息  wjxx
            //ReceiveDatas(acceptSocket, "wjxx");

            #endregion

            #region 大文件处理

            ////创建socket对象
            //Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.4.141");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////为socket对象绑定ip地址与端口号
            //socketServer.Bind(iPEndPoint);
            ////设置socket的瞬时排队数量
            //socketServer.Listen(3);

            ////开始监听连接,如果有人连接到了,会得到连接者的socket对象
            //Socket acceptSocket = socketServer.Accept();

            //using (FileStream fs = new FileStream(@"D:\测试拷贝功能\服务器共享文件夹\test.mp4", FileMode.Create, FileAccess.Write))
            //{
            //    while (true)
            //    {
            //        //开始接收文件数据（分包）
            //        byte[] buffer = new byte[1024 * 1024 * 10];  //10MB
            //        int readCount = acceptSocket.Receive(buffer);

            //        //当客户端发送一个命令 “end” 就证明文件发完了
            //        string command = Encoding.UTF8.GetString(buffer, 0, 3);
            //        if (command == "end")
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            acceptSocket.Send(Encoding.UTF8.GetBytes("ok"));
            //        }

            //        //写文件到硬盘里
            //        fs.Write(buffer, 0, readCount);
            //    }
            //}


            #endregion

            #region 拷贝文件功能---升级版


            //创建socket对象
            Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //创建ip地址对象
            IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            //创建终端（端口号）
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            //为socket对象绑定ip地址与端口号
            socketServer.Bind(iPEndPoint);
            //设置socket的瞬时排队数量
            socketServer.Listen(3);

            //开始监听连接,如果有人连接到了,会得到连接者的socket对象
            Socket acceptSocket = socketServer.Accept();


            while (true)
            {
                //接收传过来的数据和命令
                CommandEnum command;
                byte[] datas = ReceiveDatasAndCommand(acceptSocket, out command);

                //客户端发文件信息过来了，服务器就看看哪些文件没有，通知客户端发这个过来
                if (command == CommandEnum.文件信息)
                {
                    //json对象字符串
                    string jsonStr = Encoding.UTF8.GetString(datas);
                    List<CustomFileInfo> receiveFileInfos = JsonConvert.DeserializeObject<List<CustomFileInfo>>(jsonStr);

                    ////获取文件夹信息
                    DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\测试拷贝功能\服务器共享文件夹");
                    //获取文件夹下面有什么文件
                    FileInfo[] fileInfos = directoryInfo.GetFiles();

                    foreach (var item in receiveFileInfos)  //demo.txt
                    {
                        //有没有这个文件
                        bool isHad = false;
                        //服务器文件的最后修改时间
                        DateTime servertLastWriteTime = default(DateTime);
                        //遍历自己的文件下的文件信息
                        foreach (var fileInfo in fileInfos)
                        {
                            if (item.FileName == fileInfo.Name)
                            {
                                isHad = true;
                                //服务器文件的最后修改时间
                                servertLastWriteTime = fileInfo.LastWriteTime;
                                break;
                            }
                        }

                        //没有这个文件的情况是要要的
                        if (!isHad)
                        {
                            //改这个字段为true,说白就是告诉客户端我没有这个文件，等下你发过来
                            item.IsSend = true;
                        }
                        else
                        {
                            //如果有这个文件，但是要判断，服务器文件的最后修改时间小于客户端发来文件的修改时间，那就要
                            if (item.LastWriteTime > servertLastWriteTime)
                            {
                                item.IsSend = true;
                            }
                        }
                        ////判断自己的共享文件夹下有没有当前遍历的这个文件
                        //bool isHad = fileInfos.Any(f => f.Name == item.FileName);
                        //if (!isHad)
                        //{
                        //    //改这个字段为true,说白就是告诉客户端我没有这个文件，等下你发过来
                        //    item.IsSend = true;
                        //}
                    };

                    //发信息给客户端你要什么文件
                    jsonStr = JsonConvert.SerializeObject(receiveFileInfos);
                    byte[] buffer = Encoding.UTF8.GetBytes(jsonStr);
                    //发数据给客户端
                    SendDatas(acceptSocket, buffer, CommandEnum.文件信息);
                }
                else if (command == CommandEnum.文件名字)  //客户端发文件名字过来
                {
                    //获取文件名字
                    string fileName = Encoding.UTF8.GetString(datas);
                    string filePath = Path.Combine(@"D:\测试拷贝功能\服务器共享文件夹", fileName);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        while (true)
                        {
                            //接有没有发文件数据
                            datas = ReceiveDatasAndCommand(acceptSocket, out command);
                            if (command == CommandEnum.文件数据)
                            {
                                fs.Write(datas, 0, datas.Length);
                            }
                            else if (command == CommandEnum.文件发送结束)
                            {
                                break;
                            }
                            else
                            {
                                //命令不对，删除文件
                                fs.Close();
                                File.Delete(filePath);
                                break;
                            }
                        }
                    }
                }
            }


            #endregion
        }

        public static bool SendDatas(Socket socket, byte[] datas, CommandEnum command, int sendCount = 0)
        {
            //要枚举的值 那个数字
            byte value = (byte)command;
            //规则数组
            byte[] roleArr = new byte[] { value };
            if (roleArr.Length != 1)
            {
                return false;
            }

            //拼接好命令和数据的数组
            byte[] sendDatas = roleArr.Concat(datas).ToArray();

            //传了要发的数量
            if (sendCount != 0)
            {
                //发信息
                socket.Send(sendDatas, 0, sendCount + 1, SocketFlags.None);
                Console.WriteLine($"服务器发完消息,命令：{command.ToString()},发了{sendCount + 1}个字节");
            }
            else
            {
                //发信息
                socket.Send(sendDatas, 0, sendDatas.Length, SocketFlags.None);
                Console.WriteLine($"服务器发完消息,命令：{command.ToString()},发了{sendDatas.Length}个字节");
            }

            //收回复命令只需要一个长度的数组够了
            byte[] buffer = new byte[1];
            //收回复
            int readCount = socket.Receive(buffer);
            Console.WriteLine($"服务器收到的回答，读取到了{readCount}个字节");

            //取数组前1个元素就是命令
            byte commandByte = buffer[0];
            //命令的字符串
            //string commandStr = Encoding.UTF8.GetString(commandArr);
            if (commandByte != (byte)command)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 接收数据的方法
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static byte[] ReceiveDatasAndCommand(Socket socket, out CommandEnum command)
        {
            byte[] buffer = new byte[1024 * 1024 * 10 + 1];
            Console.WriteLine("服务器准备接收到数据");
            //接收数据
            int readCount = socket.Receive(buffer);
            Console.WriteLine($"服务器接收到数据，接收到了{readCount}个字节");

            //验证前1位的命令
            byte commandByte = buffer[0];
            //赋值out参数，把命令赋值并带出方法
            command = (CommandEnum)commandByte;

            //把命令发回去通知已经收到消息
            socket.Send(new byte[] { commandByte });
            Console.WriteLine($"通知收到了数据，回复命令{command.ToString()}");

            //Thread.Sleep(1);
            byte[] tempArr = new byte[readCount - 1];
            for (int i = 1; i < readCount; i++)
            {
                tempArr[i - 1] = buffer[i];
            }
            return tempArr;
        }

        /// <summary>
        /// 接收数据的方法
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static byte[] ReceiveDatas(Socket socket, string command)
        {
            byte[] buffer = new byte[1024];
            int readCount = socket.Receive(buffer);

            //验证前4位的命令
            byte[] commandArr = buffer.Take(4).ToArray();
            string commandStr = Encoding.UTF8.GetString(commandArr);
            if (commandStr != command)
            {
                socket.Send(new byte[] { 0, 0, 0, 0 });
            }
            else
            {
                socket.Send(commandArr);
            }

            byte[] tempArr = new byte[readCount - 4];
            for (int i = 4; i < readCount; i++)
            {
                tempArr[i - 4] = buffer[i];
            }
            return tempArr;
        }
    }
}
