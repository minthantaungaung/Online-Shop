using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Detail { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Rating { get; set; }
        public string Seller { get; set; }
        public string ShopCode { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
