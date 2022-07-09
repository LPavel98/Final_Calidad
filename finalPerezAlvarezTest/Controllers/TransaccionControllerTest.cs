using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using finalPerezAlvarez.Web.Controllers;
using finalPerezAlvarez.Web.Models;
using finalPerezAlvarez.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Tests.Controllers
{
    internal class TransaccionControllerTest
    {
        private readonly ITransaccionRepositorio _cuentaTransaccionRepositorio;

        [Test]
        public void IndexViewCase01()
        {
            var mockListaTransaccion = new Mock<ITransaccionRepositorio>();
            mockListaTransaccion.Setup(o => o.ListaCuentaTransacciones(1)).Returns(new List<Transaccion> { new Transaccion() });

            var controller = new TransaccionController(mockListaTransaccion.Object, null);
            var view = controller.Index(1);

            Assert.IsNotNull(view);
        }

        [Test]
        public void CreateView()
        {
            var controller = new TransaccionController(null, null);
            var createView = controller.Create(1);

            Assert.IsNotNull(createView);
        }

        [Test]
        public void CreateViewPost()
        {
            var controller = new TransaccionController(null, null);
            var createView = controller.Create(1, new Transaccion() { tipo = "Gasto", descripcion = "ssss", monto = 100});

            Assert.IsNotNull(createView);
            Assert.IsInstanceOf<RedirectToActionResult>(createView);
        }
    }
}