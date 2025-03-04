using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrdersMaterial:BaseEntity
    {
        [Column(TypeName = "varchar(36)")]
        public string Materialld { get; set; }

        [Column(TypeName = "varchar(36)")]
        public string OrdersId { get; set; }

        public int Num { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
