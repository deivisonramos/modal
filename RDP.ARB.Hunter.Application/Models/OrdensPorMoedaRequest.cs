using System.Collections.Generic;

namespace RDP.ARB.Hunter.Application.Models
{
    public class OrdensPorMoedaRequest
    {
        public string Moeda { get; set; }
        public ICollection<string> Corretoras { get; private set; }

        public OrdensPorMoedaRequest()
        {
            Corretoras = new List<string>();
        }
    }
}