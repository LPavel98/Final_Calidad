using System.Linq;
using finalPerezAlvarez.Web.DB;
using finalPerezAlvarez.Web.Models;
using Microsoft.EntityFrameworkCore;


namespace finalPerezAlvarez.Web.Repositories;

public interface ICuentaRepositorio
{
    Cuenta ObtenerCuentaPorId(int id);
   
    void GuardarCuenta(Cuenta cuenta);

    Cuenta EditarCuentaPorId(int id);

    Cuenta DeleteCuenta(int id);
    

    List<Cuenta> ObtenerTodos();
}

public class CuentaRepositorio: ICuentaRepositorio
{
    private DbEntities _dbEntities;
    
    public CuentaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }
    
    public Cuenta ObtenerCuentaPorId(int id)
    {
        return _dbEntities.Cuentas.First(o => o.id == id); // lambdas / LINQ
       
    }

    public void GuardarCuenta(Cuenta cuenta)
    {
        
        _dbEntities.Cuentas.Add(cuenta);
        _dbEntities.SaveChanges();
    }

    public List<Cuenta> ObtenerTodos()
    {
        return _dbEntities.Cuentas
            .Include(o => o.TipoCuenta)
            .ToList();
    }
    public Cuenta DeleteCuenta(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.id == id);
        
        return cuentaDb;
    }

    public Cuenta EditarCuentaPorId(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.id == id);

        return cuentaDb;

    }
}