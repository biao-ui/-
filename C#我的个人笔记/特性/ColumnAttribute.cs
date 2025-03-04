using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    /// <summary>
    /// 为了设置数据库数据类型
    /// </summary>
    public class ColumnAttribute : Attribute
    {
        public string TypeName { get; set; }
    }
}
