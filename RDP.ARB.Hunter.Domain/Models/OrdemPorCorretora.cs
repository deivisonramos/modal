using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDP.ARB.Hunter.Domain.Models
{
    public class OrdemPorCorretora
    {
        public string Corretora { get; private set; }
        public IReadOnlyCollection<Ordem> Ordens { get; private set; }

        public OrdemPorCorretora(string corretora, IEnumerable<Ordem> ordens)
        {
            Corretora = corretora;
            Ordens = ordens?.ToList() ?? new List<Ordem>();
        }

        public OrdemPorCorretora(string corretora, Ordem ordem)
        {
            Corretora = corretora;
            Ordens = ordem == null ? new List<Ordem>() : new List<Ordem>() { ordem };
        }


    }
}
