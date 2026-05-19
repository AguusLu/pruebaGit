using Microsoft.AspNetCore.Mvc;
using pruebaGit.Models;
using System.Collections.Generic;
using System.Linq;

namespace pruebaGit.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILogger<LibroController> logger)
        {
            _logger = logger;
        }
        //private static List<Libro> libros = new List<Libro>();

        // Lista persistente de libros
        private readonly List<Libro> libros =
    [
        new Libro
        {
            id = 1,
            titulo = "1984",
            anioPublicacion = 1949,
            autor = new Autor { id = 1, nombre = "George Orwell" },
            autorId = 1,
            urlImagen = "data:image/jpeg;base64,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"
        },
        new Libro
        {
            id = 2,
            titulo = "Fahrenheit 451",
            anioPublicacion = 1953,
            autor = new Autor { id = 2, nombre = "Ray Bradbury" },
            autorId = 2,
            urlImagen = "https://upload.wikimedia.org/wikipedia/en/d/db/Fahrenheit_451_1st_ed_cover.jpg"
        }
    ];

        private static List<Autor> obtenerAutores()
        {
            return new List<Autor>
            {
                new() { id = 1, nombre = "George Orwell" },
                //new Autor { id = 2, nombre = "Ray Bradbury"
                new() { id = 2, nombre = "Ray Bradbury" }
            };
        }

        public IActionResult Index(string color = "light")
        {
            ViewBag.Color = color;
            return View(libros);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Autores = obtenerAutores();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Libro libro)
        {
            ModelState.Remove("autor");
            ModelState.Remove("urlImagen");
            if (!ModelState.IsValid)
            {
                ViewBag.Autores = obtenerAutores();
                return View(libro);
            }

            var autorSeleccionado = obtenerAutores().FirstOrDefault(a => a.id == libro.autorId);
            if (autorSeleccionado == null)
            {
                ModelState.AddModelError("autorId", "Autor no válido.");
                ViewBag.Autores = obtenerAutores();
                return View(libro);
            }

            libro.autor = autorSeleccionado;
            libro.id = libros.Any() ? libros.Max(l => l.id) + 1 : 1;
            libros.Add(libro);

            TempData["Mensaje"] = $"✅ Libro '{libro.titulo}' creado correctamente.";

            return RedirectToAction("Detalle", new { libro.id });
        }

        public IActionResult Detalle(int id)
        {
            var libroSeleccionado = libros.FirstOrDefault(l => l.id == id);
            if (libroSeleccionado == null)
            {
                return RedirectToAction("Index");
            }
            return View(libroSeleccionado);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var libro = libros.FirstOrDefault(l => l.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            libro.autorId = libro.autor?.id ?? 0; // cargar autorId para preselección
            ViewBag.Autores = obtenerAutores();
            return View(libro);
        }

        [HttpPost]
        public IActionResult Editar(Libro libro)
        {
            ModelState.Remove("urlImagen");
            ModelState.Remove("autor");
            if (!ModelState.IsValid)
            {
                ViewBag.Autores = obtenerAutores();
                return View(libro);
            }
            var libroExistente = libros.FirstOrDefault(l => l.id == libro.id);
            if (libroExistente == null)
            {
                return NotFound();
            }
            // Actualizar campos
            libroExistente.titulo = libro.titulo;
            libroExistente.anioPublicacion = libro.anioPublicacion;

            var autorSeleccionado = obtenerAutores().FirstOrDefault(a => a.id == libro.autorId);
            if (autorSeleccionado != null)
            {
                libroExistente.autor = autorSeleccionado;
            }

            TempData["Mensaje"] = "Libro editado correctamente";
            return RedirectToAction("Detalle", new { libro.id });
            //return RedirectToAction("Index");
        }
    }
}