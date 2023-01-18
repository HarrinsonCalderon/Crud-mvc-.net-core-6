using System.ComponentModel.DataAnnotations;
namespace crudMvcCore6.Models.ViewModels
{
    public class BeerViewModel
    {
        public int Beerld { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string? NameBeer { get; set; }
        
        public string? NameBrand { get; set; }
        [Display(Name = "Marca")]
        [Required]
        public int? FkBrandld { get; set; }
    }
}
