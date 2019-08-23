using RDP.ARB.Hunter.Infra.MicroServices.Interfaces;
using Xunit;
using RDP.ARB.Hunter.Infra.MicroServices.HttpClients;
using System.Threading.Tasks;
using System.Linq;

namespace RDP.ARB.Hunter.Test.Infra
{
    public class HttpClientCorretoraMercadoBitcoinTest
    {
        private IHttpClientCorretora _httpClient;
        public HttpClientCorretoraMercadoBitcoinTest()
        {
            _httpClient = new HttpClientCorretoraMercadoBitcoin();
        }


        [Fact]
        public async Task CarregaOrdens_XRP()
        {
            var listaOrdens = await _httpClient.CarregaOrdensAsync("xrp");

            Assert.True(listaOrdens.Count() > 0);
        }
    }
}
