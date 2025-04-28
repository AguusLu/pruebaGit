using Microsoft.AspNetCore.Mvc;
using pruebaGit.Models;

namespace pruebaGit.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            var autor1 = new Autor { id = 1, nombre = "George Orwell" };
            var autor2 = new Autor { id = 2, nombre = "Ray Bradbury" };
            var libros = new List<Libro>{

                new Libro { id = 1, titulo = "1984", anioPublicacion = 1949, autor = autor1 },
                new Libro { id = 2, titulo = "Fahrenheit 451", anioPublicacion =1953, autor = autor2 },
                new Libro { id = 3, titulo = "Rebelión en la granja", anioPublicacion = 1945, autor = autor1 }
             };

            return View(libros);
        }

        public IActionResult Detalle(int id)
        {
            var autor1 = new Autor { id = 1, nombre = "George Orwell" };
            var autor2 = new Autor { id = 2, nombre = "Ray Bradbury" };

            var libros = new List<Libro>{
                new Libro { id = 1, titulo = "1984", anioPublicacion = 1949, autor = autor1 },
                new Libro { id = 2, titulo = "Fahrenheit 451", anioPublicacion =1953, autor = autor2 },
                new Libro { id = 3, titulo = "Rebelión en la granja", anioPublicacion = 1945, autor = autor1 }
             };

            var libroSeleccionado = libros.FirstOrDefault(l => l.id == id);

            if (libroSeleccionado == null)
            {
                ViewBag.Mensaje = "El libro solicitado no existe.";
                return View("Error");
            }

            return View(libroSeleccionado);
        }
    }

}
