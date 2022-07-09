using System.Collections.Generic;
using System.Linq;
using FinancialApp.Tests.Helpers;
using finalPerezAlvarez.Web.DB;
using finalPerezAlvarez.Web.Models;
using finalPerezAlvarez.Web.Repositories;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Repositories;

public class TipoCuentasRepositorioTest
{
    private IQueryable<TipoCuenta> data;
    private Mock<DbEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<TipoCuenta>
        {
            new() { id = 1, Nombre = "Credito" },
            new() { id = 2, Nombre = "Debito" }
            
        }.AsQueryable();
        
        var mockDbsetTipoCuenta = new MockDBSet<TipoCuenta>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);

    }
    
    [Test]
    public void ObtenerTodosTest()
    {
        

        var mockDbsetTipoCuenta = (new MockDBSet<TipoCuenta>(data));
        
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);
        
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();

        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void ObtenerPorNombreTest1()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPorNombre("Credito");

        Assert.AreEqual(1, result.Count);
    }
    
    
    [Test]
    public void ObtenerPorNombreTest2()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPorNombre("Efectivo");

        Assert.AreEqual(0, result.Count);
    }
}