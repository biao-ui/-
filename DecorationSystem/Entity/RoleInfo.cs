using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RoleInfo:BaseEntity
    {
      
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string? Remark { get; set; }
       
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DeleteTime { get; set; }

    }
}
