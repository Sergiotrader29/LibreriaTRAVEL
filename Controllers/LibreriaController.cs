using Library.Models;
using Library.Servicios;

using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers
{
    public class LibreriaController : Controller
    {
       
        private readonly IrepositorioLibreria repositorioLibreria;

        public LibreriaController(IrepositorioLibreria repositorioLibreria)
        {
            
            this.repositorioLibreria = repositorioLibreria;
        }


        public IActionResult AñadirLibro()
        {
            return View();
        }



        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var autores = await repositorioLibreria.Buscar();
            return View(autores);
        }


        [HttpPost]
        public async Task<IActionResult> AñadirLibro(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            

            await repositorioLibreria.AñadirLibro(libro) ;

            return View();
        }
    }
}
