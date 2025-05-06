using Microsoft.AspNetCore.Mvc;
using pruebaGit.Models;
using System.Collections.Generic;
using System.Linq;

public class LibroController : Controller
{
    //private static List<Libro> libros = new List<Libro>();

    // Lista persistente de libros
    private static List<Libro> libros = new List<Libro>
    {
        new Libro
        {
            id = 1,
            titulo = "1984",
            anioPublicacion = 1949,
            autor = new Autor { id = 1, nombre = "George Orwell" },
            autorId = 1
        },
        new Libro
        {
            id = 2,
            titulo = "Fahrenheit 451",
            anioPublicacion = 1953,
            autor = new Autor { id = 2, nombre = "Ray Bradbury" },
            autorId = 2
        }
    };

    private List<Autor> obtenerAutores()
    {
        return new List<Autor>
        {
            new Autor { id = 1, nombre = "George Orwell" },
            new Autor { id = 2, nombre = "Ray Bradbury" }
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

        return RedirectToAction("Detalle", new { id = libro.id });
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
}


    /*  public IActionResult Detalle(int id)
      {
          var libro = libros.FirstOrDefault(l => l.id == id);
          if (libro == null)
              return NotFound();

          return View(libro);
      }*/
