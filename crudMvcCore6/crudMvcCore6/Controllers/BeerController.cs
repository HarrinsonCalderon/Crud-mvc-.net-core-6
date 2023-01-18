
using crudMvcCore6.Models;
using crudMvcCore6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace crudMvcCore6.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;

        public BeerController(PubContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            //var datos2 = _context.Beers.Include(b => b.Brand);
            var datos = await (from a in _context.Brands
                               join b in _context.Beers on a.Brandld equals b.FkBrandld
                               select new BeerViewModel
                               {
                                   NameBeer = b.NameB,
                                   NameBrand = a.NameB,
                                   Beerld = b.Beerld,
                                   FkBrandld = a.Brandld
                               }
                               ).ToListAsync();
            
            return View(datos);
        }
        public IActionResult Create() {

            ViewData["Brands"] = new SelectList(_context.Brands, "Brandld", "NameB");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid) {
                var beer = new Beer()
                {
                    NameB = model.NameBeer,
                    FkBrandld = model.FkBrandld
                };
                _context.Add(beer);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Cerveza guardada correctamente.";
                return RedirectToAction(nameof(Index));
        }
            ViewData["Brands"] = new SelectList(_context.Brands, "Brandld", "NameB",model.FkBrandld);
            return View(model);
        }

        public  IActionResult Update(string Id) {
            int idB = int.Parse(Id);
             
            var  datos =   (from a in _context.Brands
                              join b in _context.Beers on a.Brandld equals b.FkBrandld
                              where b.Beerld==idB
                              select new BeerViewModel
                              {
                                  NameBeer = b.NameB,
                                  NameBrand = a.NameB,
                                  Beerld = b.Beerld,
                                  FkBrandld = a.Brandld
                              }
                              ).FirstOrDefault();
            if(datos!=null)
            ViewData["Brands"] = new SelectList(_context.Brands, "Brandld", "NameB", datos.Beerld);
            return View(datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = _context.Beers.Find(model.Beerld);
                beer.Beerld = model.Beerld;
                beer.NameB = model.NameBeer;
                beer.FkBrandld = model.FkBrandld;
                  
                _context.Update(beer);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Cerveza actualizada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brands"] = new SelectList(_context.Brands, "Brandld", "NameB", model.FkBrandld);
            return View(model);
        }
        
        public   async Task<IActionResult> Delete(int? Id)
        {
            if (Id!=null)
            {
                var beer =  _context.Beers.Find(Id);
                if (beer != null) { 
                   
                   _context.Beers.Remove(beer);
                  await _context.SaveChangesAsync();
                TempData["mensaje"] = "Cerveza eliminada correctamente.";
                }
                else
                    TempData["mensaje"] = "Cerveza no eliminada correctamente.";

            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
