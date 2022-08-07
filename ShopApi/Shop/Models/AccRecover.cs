using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class AccRecover
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string ConfirmCode { get; set; }
        public DateTime? Accesstime { get; set; }
    }
}
