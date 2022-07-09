using System.Linq;
using System.Security.Claims;
using finalPerezAlvarez.Web.DB;
using finalPerezAlvarez.Web.Models;
using finalPerezAlvarez.Web.Repositories;
using finalPerezAlvarez.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace finalPerezAlvarez.Web.Controllers;

public class CuentaController : Controller
{
    private readonly ITipoCuentaRepositorio _tipoCuentaRepositorio;
    private readonly ICuentaRepositorio _cuentaRepositorio;
    private DbEntities _dbEntities;
    public CuentaController(ITipoCuentaRepositorio tipoCuentaRepositorio, ICuentaRepositorio cuentaRepositorio, DbEntities dbEntities)
    {
        _tipoCuentaRepositorio = tipoCuentaRepositorio;
        _dbEntities = dbEntities;
    }

    [HttpGet]
    public IActionResult Index()
    {

        var cuentas = _cuentaRepositorio.ObtenerTodos();
        ViewBag.Total = cuentas.Any() ? cuentas.Sum(o => o.saldoInicial) : 0; 
        return View(cuentas);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.TipoDeCuentas = _tipoCuentaRepositorio.ObtenerTodos();
        return View(new Cuenta());
    }

    [HttpPost]
    public IActionResult Create(Cuenta cuenta)
    {
       
        
        if (cuenta.tipoCuentaId > 6 || cuenta.tipoCuentaId < 1)
        {
            ModelState.AddModelError("TipoCuentaId", "Tipo de cuenta no exite");
        }

       
        if (!ModelState.IsValid)
        {
            ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
            return View("Create", cuenta);
        }
        
        _dbEntities.Cuentas.Add(cuenta);
        _dbEntities.SaveChanges();
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var cuenta = _dbEntities.Cuentas.First(o => o.id == id); 
        ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
        return View(cuenta);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Cuenta cuenta)
    {
        if (!ModelState.IsValid) {
            ViewBag.TipoDeCuentas = _dbEntities.TipoCuentas.ToList();
            return View("Edit", cuenta);
        }
        
        var cuentaDb = _dbEntities.Cuentas.First(o => o.id == id);
        cuentaDb.nombre = cuenta.nombre;
        _dbEntities.SaveChanges();
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.id == id);
        _dbEntities.Cuentas.Remove(cuentaDb);
        _dbEntities.SaveChanges();

        return RedirectToAction("Index");
    }

    
}