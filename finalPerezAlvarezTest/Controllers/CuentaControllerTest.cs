using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using finalPerezAlvarez.Web.Controllers;
using finalPerezAlvarez.Web.DB;
using finalPerezAlvarez.Web.Models;
using finalPerezAlvarez.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FinancialApp.Tests.Controllers;

public class CuentaControllerTest
{
    [Test]
    public void CreateViewCase01()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());
        
        var controller = new CuentaController(mockTipoRepositorio.Object, null, null);
        var view = controller.Create();
        
        Assert.IsNotNull(view);
    }
    
   

    
}