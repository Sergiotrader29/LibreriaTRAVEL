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

        public IActionResult BusquedaAutor()
        {
            return View();
        }



        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var autoresconlibros = await repositorioLibreria.Buscar();
            return View(autoresconlibros);
        }

        [HttpGet]
        public async Task<ActionResult> BusquedaAutor([FromQuery] Autor autor)
        {
            var busquedalibro = await repositorioLibreria.BuscarAutor(autor);
            return View(busquedalibro);
        }


        [HttpPost]
        public async Task<IActionResult> AñadirLibro(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await repositorioLibreria.AñadirLibro(libro) ;

            return RedirectToAction("Index");
        }
    }
}
