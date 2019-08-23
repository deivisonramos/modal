using RDP.ARB.Hunter.Domain;
using RDP.ARB.Hunter.Infra.MicroServices.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDP.ARB.Hunter.Infra.MicroServices.HttpClients
{
    public abstract class HttpClientCorretoraBase : HttpClient, IHttpClientCorretora
    {
        public abstract Task<IEnumerable<Ordem>> CarregaOrdensAsync(string moeda);
    }
}
