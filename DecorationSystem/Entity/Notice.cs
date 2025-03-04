using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Notice : BaseEntity
    {

        [Column(TypeName = "nvarchar(16)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        [Column(TypeName = "varchar(36)")]
        public string CreatorId { get; set; }
        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public DateTime DeleteTime { get; set; }
    }
}
