using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Ward { get; set; }
        public string Township { get; set; }
        public string StateDivision { get; set; }
        public bool? IsDeleted { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
