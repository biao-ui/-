using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket客户端
{
    class CustomFileInfo
    {
        /// <summary>
        /// 文件名字
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long length { get; set; }

        /// <summary>
        /// 文件最后的修改时间
        /// </summary>
        public DateTime LastWriteTime { get; set; }

        /// <summary>
        /// 是否发过去给服务器
        /// </summary>
        public bool IsSend { get; set; }

        /// <summary>
        /// 文件数据
        /// </summary>
        public byte[] Datas { get; set; }
    }
}
