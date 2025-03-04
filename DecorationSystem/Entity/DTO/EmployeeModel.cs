using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string? RoleId { get; set; }

        public string Name { get; set; }

        public string? Phone { get; set; }

        public string Account { get; set; }
        public string CreateTime { get; set; }
    }
}
