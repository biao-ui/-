using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee:BaseEntity
    {


        [Column(TypeName = "varchar(36)")]
        public string? RoleId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string? Phone { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Account { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public DateTime DeleteTime { get; set; }

    }
}
