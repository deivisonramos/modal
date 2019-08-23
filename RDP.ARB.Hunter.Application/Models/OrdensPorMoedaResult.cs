using System;
using System.Collections.Generic;
using System.Text;

namespace RDP.ARB.Hunter.Application.Models
{
    public class OrdensPorMoedaResult
    {
        public string Moeda { get; set; }
        public ICollection<OrdensPorCorretora> OrdensPorCorretora { get; private set; }

        public OrdensPorMoedaResult(string moeda)
        {
            Moeda = moeda;
            OrdensPorCorretora = new List<OrdensPorCorretora>();
        }
    }
}
