using Microsoft.AspNetCore.Mvc;
using Moq;
using RDP.ARB.Hunter.Application.Models;
using RDP.ARB.Hunter.Application.Services;
using RDP.ARB.Hunter.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace RDP.ARB.Hunter.UnitTest.ControllerTest
{
    public class OrdensControllerTest
    {
        private Mock<IOrdensService> _mockOrdensService;
        private OrdensController _ordensController;
        public OrdensControllerTest()
        {
            _mockOrdensService = new Mock<IOrdensService>();
            _mockOrdensService.Setup(x => x.ObtemOrdensPorMoeda(It.IsAny<OrdensPorMoedaRequest>())).Returns(new OrdensPorMoedaResult(""));

            _ordensController = new OrdensController(_mockOrdensService.Object); 
        }

        [Fact]
        public void Ordens_OK()
        {
            var requestEsperado = new OrdensPorMoedaRequest();
            var resultado = _ordensController.OrdensPorMoeda("brl", requestEsperado) as OkObjectResult;

            Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal((int)HttpStatusCode.OK, resultado.StatusCode);
            Assert.IsType<OrdensPorMoedaResult>(resultado.Value);
        }
    }
}
