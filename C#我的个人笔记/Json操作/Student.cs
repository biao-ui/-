using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json操作
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsAdmin { get; set; }
        public string[] Friends { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        
    }
}
