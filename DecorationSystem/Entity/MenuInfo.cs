using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
     public class MenuInfo : BaseEntity
    {
        

        [Column(TypeName = "nvarchar(16)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }

        public int Level { get; set; }

        public int Sort { get; set; }

        [Column(TypeName = "varchar(128)")]
        public string? Href { get; set; }

        [Column(TypeName = "varchar(36)")]
        public string? ParentId { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Icon { get; set; }

        [Column(TypeName = "varchar(16)")]
        public string Target { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public DateTime DeleteTime { get; set; }
    }
}
