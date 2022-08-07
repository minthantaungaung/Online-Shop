using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class Shops
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Latitiude { get; set; }
        public string Longitude { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNo { get; set; }
        public string ShopName { get; set; }
        public string ShopCode { get; set; }
        public string ShopType { get; set; }
        public string StateDivision { get; set; }
        public string Township { get; set; }
        public string Ward { get; set; }
        public string Website { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
