using Moq;
using RDP.ARB.Hunter.Application.Models;
using RDP.ARB.Hunter.Application.Services;
using RDP.ARB.Hunter.Infra.MicroServices.Interfaces;
using RDP.ARB.Hunter.UnitTest.DataFactory;
using System;
using System.Linq;
using Xunit;

namespace RDP.ARB.Hunter.UnitTest.ApplicationTest.Services
{
    public class OrdensServiceTest
    {
        private IOrdensService _ordensService;
        private Mock<IHttpClientCorretoraFactory> _httpClientCorretoraFactory;
        private Mock<IHttpClientCorretora> _mockCorretora;


        public OrdensServiceTest()
        {
            _mockCorretora = new Mock<IHttpClientCorretora>();
            _mockCorretora.Setup(x => x.CarregaOrdensAsync(It.IsAny<string>())).ReturnsAsync(OrdemDataFactory.Ordens());

            _httpClientCorretoraFactory = new Mock<IHttpClientCorretoraFactory>();
            _httpClientCorretoraFactory.Setup(x => x.ObtemHttpClientPorCorretora(It.IsAny<string>())).Returns(_mockCorretora.Object);

            _ordensService = new OrdensService(_httpClientCorretoraFactory.Object);
        }

        [Fact]
        public void NumeroDeOrdensEsperadoDaCorretora()
        {
            var request = new OrdensPorMoedaRequest() { Moeda = "XRP" };
            request.Corretoras.Add("MercadoBitCoin");
            request.Corretoras.Add("BitCoinTrade");

            var resultado = _ordensService.ObtemOrdensPorMoeda(request);

            Assert.True(resultado.OrdensPorCorretora.Count > 0);
            Assert.Equal(OrdemDataFactory.Ordens().Count(), resultado.OrdensPorCorretora.FirstOrDefault(c => c.Corretora == "MercadoBitCoin").Ordens.Count());
            Assert.Equal(OrdemDataFactory.Ordens().Count(), resultado.OrdensPorCorretora.FirstOrDefault(c => c.Corretora == "BitCoinTrade").Ordens.Count());
        }
    }
}
