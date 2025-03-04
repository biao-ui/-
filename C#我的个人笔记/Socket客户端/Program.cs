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

namespace Socket客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 客户端基础代码
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);

            //string s_msg = "我是客户端，服务器你好";

            ////向服务器发送消息
            //socketClient.Send(Encoding.UTF8.GetBytes(s_msg));

            //byte[] datas = new byte[1024];

            ////接收服务器发来的消息
            //int readCount = socketClient.Receive(datas);

            //string r_msg = Encoding.UTF8.GetString(datas, 0, readCount);
            //Console.WriteLine(r_msg);

            //socketClient.Close();
            //Console.ReadKey();
            #endregion

            #region 题目1
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);

            //while (true)
            //{
            //    string s_msg = Console.ReadLine();

            //    if (s_msg == "exit")
            //    {
            //        break;
            //    }

            //    //向服务器发送消息
            //    socketClient.Send(Encoding.UTF8.GetBytes(s_msg));
            //}

            //socketClient.Close();
            #endregion

            #region 题目2
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);

            //string name = Console.ReadLine();
            //while (true)
            //{
            //    string s_msg = $"我是{name}，我正在发消息";

            //    //向服务器发送消息
            //    socketClient.Send(Encoding.UTF8.GetBytes(s_msg));

            //    //接收服务器的消息
            //    byte[] datas = new byte[1024];
            //    int readCount = socketClient.Receive(datas);

            //    Console.WriteLine(Encoding.UTF8.GetString(datas,0, readCount));

            //    Thread.Sleep(2000);
            //}

            //socketClient.Close();
            #endregion

            #region 题目3
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);


            ////开文件流去读文件
            //FileStream fileStream = new FileStream(@"C:\Users\Administrator\Desktop\touxiang.jpg", FileMode.Open,FileAccess.Read);

            //byte[] datas = new byte[1024*10];
            //int readCount = fileStream.Read(datas,0, datas.Length);

            ////向服务器发送消息
            //socketClient.Send(datas, readCount, SocketFlags.None);

            //fileStream.Close();
            //socketClient.Close();
            #endregion

            #region  拷贝文件功能  --- 客户端

            ////1、把文件信息告诉服务器端，现在有哪些文件（socket）
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.1.221");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);

            //while (true)
            //{
            //    //2、先读取文件夹下有哪些文件
            //    //获取文件夹信息
            //    DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\测试拷贝功能\客户端文件夹");
            //    //获取文件夹下面有什么文件
            //    FileInfo[] fileInfos = directoryInfo.GetFiles();

            //    //文件信息的集合
            //    List<CustomFileInfo> infos = new List<CustomFileInfo>();
            //    foreach (var item in fileInfos)
            //    {
            //        CustomFileInfo customFileInfo = new CustomFileInfo()
            //        {
            //            FileName = item.Name,
            //            length = item.Length
            //        };

            //        infos.Add(customFileInfo);
            //    };

            //    //序列化文件信息，再通过Json字符串的形式发送过去
            //    string jsonStr = JsonConvert.SerializeObject(infos);

            //    byte[] sendDatas = Encoding.UTF8.GetBytes(jsonStr);

            //    //发信息给服务器当前客户端有什么文件信息
            //    socketClient.Send(sendDatas);


            //    //接收服务器发来的文件信息
            //    byte[] buffer = new byte[1024];
            //    int readCount = socketClient.Receive(buffer);

            //    //得到服务器发来的文件信息字符串
            //    jsonStr = Encoding.UTF8.GetString(buffer, 0, readCount);

            //    //反序列化得回文件信息对象集合
            //    List<CustomFileInfo> infos2 = JsonConvert.DeserializeObject<List<CustomFileInfo>>(jsonStr);
            //    foreach (var item in infos2)
            //    {
            //        if (item.IsSend)
            //        {
            //            //文件路径
            //            string filePath = Path.Combine(@"D:\测试拷贝功能\客户端文件夹", item.FileName);
            //            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //            {
            //                byte[] datas = new byte[item.length]; //1kb
            //                readCount = fs.Read(datas, 0, datas.Length);

            //                //byte[] temp = new byte[readCount];
            //                //for (int i = 0; i < temp.Length; i++)
            //                //{
            //                //    temp[i] = datas[i];
            //                //}
            //                item.Datas = datas;
            //            }
            //        }
            //    }

            //    jsonStr = JsonConvert.SerializeObject(infos2);
            //    //发信息给服务器当前客户端有什么文件信息
            //    socketClient.Send(Encoding.UTF8.GetBytes(jsonStr));

            //    while (true)
            //    {
            //        buffer = new byte[1024];
            //        readCount = socketClient.Receive(buffer);
            //        string msg = Encoding.UTF8.GetString(buffer, 0, readCount);
            //        if (msg == "弄完了，可以重新了等我数据。")
            //        {
            //            break;
            //        }

            //        Thread.Sleep(1000);
            //    }

            //    continue;
            //}

            #endregion

            #region 指定规则
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.4.141");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);


            ////数据数组
            //byte[] datasArr = Encoding.UTF8.GetBytes("nihao");



            ////发信息给服务器 并加上命令
            //bool isSuccess = SendDatas(socketClient, datasArr, "wjxx");

            //Console.ReadKey();
            #endregion

            #region 处理大文件
            ////创建socket对象
            //Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////创建ip地址对象
            //IPAddress iPAddress = IPAddress.Parse("192.168.4.141");
            ////创建终端（端口号）
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            ////连接服务器
            //socketClient.Connect(iPEndPoint);

            //using (FileStream fs = new FileStream(@"D:\测试拷贝功能\客户端文件夹\meeting_01.mp4", FileMode.Open, FileAccess.Read))
            //{
            //    while (true)
            //    {
            //        byte[] buffer = new byte[1024 * 1024 * 10]; //10MB
            //        //文件流读数据
            //        int readCount = fs.Read(buffer, 0, buffer.Length);

            //        //读不到数据就要发一个end通知服务器要结束了
            //        if (readCount == 0)
            //        {
            //            socketClient.Send(Encoding.UTF8.GetBytes("end"));
            //            break;
            //        }

            //        //发分包数据给服务器
            //        socketClient.Send(buffer, 0, readCount, SocketFlags.None);
            //        //接收服务器的回应
            //        buffer = new byte[1024 * 1024 * 10]; //10MB
            //        readCount = socketClient.Receive(buffer);

            //        string command =  Encoding.UTF8.GetString(buffer, 0, 2);
            //        if (command != "ok")
            //        {
            //            return;
            //        }
            //    }
            //}

            #endregion

            #region 拷贝文件功能---升级版

            //1、把文件信息告诉服务器端，现在有哪些文件（socket）
            //创建socket对象
            Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //创建ip地址对象
            IPAddress iPAddress = IPAddress.Parse("192.168.0.105");
            //创建终端（端口号）
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 6666);
            //连接服务器
            socketClient.Connect(iPEndPoint);


            while (true)
            {
                //2、先读取文件夹下有哪些文件
                //获取文件夹信息
                DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\测试拷贝功能\客户端文件夹");
                //获取文件夹下面有什么文件
                FileInfo[] fileInfos = directoryInfo.GetFiles();

                //文件信息的集合
                List<CustomFileInfo> infos = new List<CustomFileInfo>();
                foreach (var item in fileInfos)
                {
                    CustomFileInfo customFileInfo = new CustomFileInfo()
                    {
                        FileName = item.Name,
                        length = item.Length,
                        LastWriteTime = item.LastWriteTime
                    };

                    infos.Add(customFileInfo);
                };

                //序列化文件信息，再通过Json字符串的形式发送过去
                string jsonStr = JsonConvert.SerializeObject(infos);

                byte[] sendDatas = Encoding.UTF8.GetBytes(jsonStr);

                //发信息给服务器当前客户端有什么文件信息 wjxx
                //bool isSuccess = SendDatas(socketClient, sendDatas, "wjxx");
                bool isSuccess = SendDatas(socketClient, sendDatas, CommandEnum.文件信息);

                //命令
                CommandEnum command;
                //接收服务器要什么文件的信息
                byte[] datas = ReceiveDatasAndCommand(socketClient, out command);
                if (command == CommandEnum.文件信息)
                {
                    //得到json字符串
                    jsonStr = Encoding.UTF8.GetString(datas);
                    //反序列化得会文件集合对象
                    List<CustomFileInfo> receiveFileInfos = JsonConvert.DeserializeObject<List<CustomFileInfo>>(jsonStr);
                    foreach (var item in receiveFileInfos)
                    {
                        if (item.IsSend)
                        {
                            //文件名字  wjmz
                            //item.FileName
                            isSuccess = SendDatas(socketClient, Encoding.UTF8.GetBytes(item.FileName), CommandEnum.文件名字);

                            //文件路径
                            string filePath = Path.Combine(@"D:\测试拷贝功能\客户端文件夹", item.FileName);
                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                while (true)
                                {
                                    byte[] buffer = new byte[1024 * 1024 * 10]; //10MB
                                    int readCount = fs.Read(buffer, 0, buffer.Length);

                                    if (readCount == 0)
                                    {
                                        //通知服务器已经发完了 end
                                        isSuccess = SendDatas(socketClient, new byte[0], CommandEnum.文件发送结束);
                                        break;
                                    }

                                    //文件数据  wjsj
                                    isSuccess = SendDatas(socketClient, buffer, CommandEnum.文件数据, readCount);
                                }
                            }
                        }
                    }
                }
                //休息10s
                Thread.Sleep(1000 * 2);
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
                Console.WriteLine($"客户端发完消息,命令：{command.ToString()},发了{sendCount + 1}个字节");
            }
            else
            {
                //发信息
                socket.Send(sendDatas, 0, sendDatas.Length, SocketFlags.None);
                Console.WriteLine($"客户端发完消息,命令：{command.ToString()},发了{sendDatas.Length}个字节");
            }


            //收回复命令只需要一个长度的数组够了
            byte[] buffer = new byte[1];
            //收回复
            int readCount = socket.Receive(buffer);
            Console.WriteLine($"客户端收到的回答，读取到了{readCount}个字节");

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
            Console.WriteLine("客户端准备接收到数据");
            //接收数据
            int readCount = socket.Receive(buffer);
            Console.WriteLine($"客户端接收到数据，接收到了{readCount}个字节");

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
