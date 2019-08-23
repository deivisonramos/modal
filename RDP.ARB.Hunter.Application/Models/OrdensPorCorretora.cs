using System.Collections.Generic;
using System.Linq;

namespace RDP.ARB.Hunter.Application.Models
{
    public class OrdensPorCorretora
    {
        
        public string Corretora { get; private set; }
        public IReadOnlyCollection<OrdemCorretora> Ordens { get; private set; }

        public OrdensPorCorretora(IEnumerable<OrdemCorretora> ordens, string corretora)
        {
            Ordens = ordens.ToList();
            Corretora = corretora;
        }
    }
}
