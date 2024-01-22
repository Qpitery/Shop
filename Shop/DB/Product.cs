using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shop.DB
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufactureId { get; set; }
        public double? Price { get; set; }
        public double? Sale { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manufacture Manufacture { get; set; }
    }
}
