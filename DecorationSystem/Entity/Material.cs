using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Material : BaseEntity
    {



        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Unit { get; set; }

        [Column(TypeName = "decimal")]
        public double Price { get; set; }

        [Column(TypeName = "decimal")]
        public double PriceMain { get; set; }

        [Column(TypeName = "decimal")]
        public double PriceArtificial { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string? Remark { get; set; }
        public DateTime CreateTime { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDelete { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}

