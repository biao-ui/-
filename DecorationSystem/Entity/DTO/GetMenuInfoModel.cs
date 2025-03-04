using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class GetMenuInfoModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public string Href { get; set; }

        public string Target { get; set; }

        public string Icon { get; set; }
        public int Level { get; set; }
        public string ParentId { get; set; }

        public List<GetMenuInfoModel> Child { get; set; }

    }
}
