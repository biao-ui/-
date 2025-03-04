using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class HomeMenuModel
    {
        public object HomeInfo { get; set; }

        public object LogoInfo { get; set; }


        public List<GetMenuInfoModel> MenuInfo { get; set; }
    }
}
