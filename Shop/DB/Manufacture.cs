using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shop.DB
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string NameManufacture { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
