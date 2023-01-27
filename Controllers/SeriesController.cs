using Microsoft.AspNetCore.Mvc;
using MvcSeriesPersonajesCRP.Models;
using MvcSeriesPersonajesCRP.Repositories;

namespace MvcSeriesPersonajesCRP.Controllers
{
    public class SeriesController : Controller
    {
        RepositorySeries r;
        public SeriesController(RepositorySeries r)
        {
            this.r = r;
        }
        public IActionResult Index()
        {
            List<Serie> series = r.GetSeries();
            return View(series);
        }
        public IActionResult Details(int idserie)
        {
            Serie series = r.GetSerie(idserie);
            return View(series);
        }
        public IActionResult Personajes(int idserie) 
        {
            List<Personaje> personajes = r.GetPersonajes(idserie);
            return View(personajes);
        }
        public IActionResult AddSeries()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSeries(int idserie, string nombre, string imagen, int anyo)
        {
            r.AddSeries(idserie,nombre, imagen, anyo);
            return View();
        }
    }
}
