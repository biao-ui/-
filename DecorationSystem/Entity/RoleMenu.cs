using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RoleMenu:BaseEntity
    {
       
        [Column(TypeName = "varchar(36)")]
        public string RoleId { get; set; }

        [Column(TypeName = "varchar(36)")]

        public string MenuId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
