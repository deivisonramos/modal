using RDP.ARB.Hunter.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDP.ARB.Hunter.UnitTest.DataFactory
{
    public static class OrdemDataFactory
    {
        public static IEnumerable<Ordem> Ordens()
        {
            var ordens = new List<Ordem>() { new Ordem(1, 2), new Ordem(1, 3) };

            return ordens;
        }
    }
}
