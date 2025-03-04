using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class FileInfo : BaseEntity
    {
        [Column(TypeName = "nvarchar(64)")]
        public string OldFileName { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string NewFileName { get; set; }


        public FileTypeEnum FileType { get; set; }


        [Column(TypeName = "nvarchar(128)")]
        public string Path { get; set; }


        [Column(TypeName = "nvarchar(128)")]
        public string HtmlPath { get; set; }


        [Column(TypeName = "nvarchar(36)")]
        public string CreatorId { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public DateTime DeleteTime { get; set; }
    }
}
