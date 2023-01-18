using System;
using System.Collections.Generic;

namespace crudMvcCore6.Models
{
    public partial class Beer
    {
        public int Beerld { get; set; }
        public string? NameB { get; set; }
        public int? FkBrandld { get; set; }

        
        public virtual Brand? FkBrandldNavigation { get; set; }
    }
}
