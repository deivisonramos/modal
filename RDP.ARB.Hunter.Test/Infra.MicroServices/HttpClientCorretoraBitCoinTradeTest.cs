using RDP.ARB.Hunter.Infra.MicroServices.Interfaces;
using Xunit;
using RDP.ARB.Hunter.Infra.MicroServices.HttpClients;
using System.Threading.Tasks;
using System.Linq;

namespace RDP.ARB.Hunter.Test.Integracao.Infra
{
    public class HttpClientCorretoraBitCoinTradeTest
    {
        private IHttpClientCorretora _httpClient;
        public HttpClientCorretoraBitCoinTradeTest()
        {
            _httpClient = new HttpClientCorretoraBitCoinTrade();
        }


        [Fact]
        public async Task CarregaOrdens_XRP()
        {
            var listaOrdens = await _httpClient.CarregaOrdensAsync("xrp");

            Assert.True(listaOrdens.Count() > 0);
        }
    }
}
