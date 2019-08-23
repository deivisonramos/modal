using RDP.ARB.Hunter.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RDP.ARB.Hunter.Infra.MicroServices.Interfaces
{
    public interface IHttpClientCorretora
    {
        Task<IEnumerable<Ordem>> CarregaOrdensAsync(string moeda);
    }
}
