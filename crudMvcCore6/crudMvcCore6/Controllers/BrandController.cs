using crudMvcCore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace crudMvcCore6.Controllers
{
    public class BrandController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly PubContext _context;

        //inyeccion de dependencias
        public BrandController(PubContext context) {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //para hacer un listado de la tabla brand

        public async Task<IActionResult> Index()
        {
           
            var datos = await _context.Brands.ToListAsync();
            var datos2 = _context.Brands.Include(b => b.Beers);
            return View(await _context.Brands.ToListAsync());
             
        }
    }
}
