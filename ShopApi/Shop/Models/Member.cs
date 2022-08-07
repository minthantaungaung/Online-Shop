using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string StateDivision { get; set; }
        public string Township { get; set; }
        public string Ward { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
