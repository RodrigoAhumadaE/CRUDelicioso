using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicioso.Models;

namespace CRUDelicioso.Controllers;

public class HomeController : Controller{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index(){
        List<Plato> ListaPlatos = _context.Platos.ToList();
        return View("Index", ListaPlatos);
    }

    [HttpGet("plato/nuevo")]
    public IActionResult NuevoPlato(){
        return View("NuevoPlato");
    }

    [HttpGet("Plato/{PlatoId}")]
    public IActionResult DetallePlato(int platoId){
        Plato? plato = _context.Platos.FirstOrDefault(p => p.PlatoId == platoId);
        if(plato != null){
            return View("DetallePlato", plato);
        }
        return View("Index");
    }

    [HttpGet("plato/editar/{PlatoId}")]
    public IActionResult EditarPlato(int platoId){
        Plato? platoEdit = _context.Platos.FirstOrDefault(p => p.PlatoId == platoId);
        if(platoEdit != null){
            return View("EditarPlato", platoEdit);
        }
        return View("DetallePlato", platoId);
    }

    // POST

    [HttpPost("plato/agregar")]
    public IActionResult AgregarPlato(Plato plato){
        if(ModelState.IsValid){
            _context.Platos.Add(plato);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("NuevoPlato");
    }

    [HttpGet("palto/borrar/{PlatoId}")]
    public IActionResult EliminarPlato(int platoId){
        Plato? platoDel = _context.Platos.SingleOrDefault(p => p.PlatoId == platoId);
        if(platoDel != null){
            _context.Platos.Remove(platoDel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("DetallePlato", platoId);
    }

    [HttpPost("plato/actualizar/{PlatoId}")]
    public IActionResult ActualizarPlato(Plato plato, int platoId){
        Plato? platoPrev = _context.Platos.FirstOrDefault(p => p.PlatoId == platoId);
        if(ModelState.IsValid && platoPrev != null){
            platoPrev.Nombre = plato.Nombre;
            platoPrev.Chef = plato.Chef;
            platoPrev.Sabor = plato.Sabor;
            platoPrev.Calorias = plato.Calorias;
            platoPrev.Descripcion = plato.Descripcion;
            platoPrev.FechaActualizacion = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("DetallePlato", platoPrev);
        }
        return View("EditarPlato", platoId);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
