using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orders:BaseEntity
    {

        [Column(TypeName = "nvarchar(32)")]
        public string CustomerName { get; set; }


        [Column(TypeName = "varchar(32)")]
        public string CustomPhone { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string Address { get; set; }

        [Column(TypeName = "decimal")]
        public double Ares { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Column(TypeName = "varchar(36)")]
        public string DesignerId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDelete { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
