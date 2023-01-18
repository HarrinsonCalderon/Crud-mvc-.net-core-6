using System;
using System.Collections.Generic;

namespace crudMvcCore6.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Beers = new HashSet<Beer>();
        }

        public int Brandld { get; set; }
        public string? NameB { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
