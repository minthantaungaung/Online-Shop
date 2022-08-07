using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TimerLog
    {
        public int Id { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string MemberEmail { get; set; }
        public DateTime? Accesstime { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
