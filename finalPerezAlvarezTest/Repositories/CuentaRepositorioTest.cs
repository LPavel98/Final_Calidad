using System.Collections.Generic;
using System.Linq;
using finalPerezAlvarez.Web.DB;
using finalPerezAlvarez.Web.Models;
using finalPerezAlvarez.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Repositories;

public class CuentaRepositorioTest
{
    private IQueryable<Cuenta> data;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Cuenta>
        {
            new() { id = 1, nombre = "Cuenta 01" },
            
        }.AsQueryable();

    }
    
    [Test]
    public void ObtenerTodosTest()
    {
        var mockDbsetCuenta = new Mock<DbSet<Cuenta>>();
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Provider).Returns(data.Provider);
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Expression).Returns(data.Expression);
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.ElementType).Returns(data.ElementType);
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());

        
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Cuentas).Returns(mockDbsetCuenta.Object);
        
        var repo = new CuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();

        Assert.AreEqual(1, result.Count);
    }
}