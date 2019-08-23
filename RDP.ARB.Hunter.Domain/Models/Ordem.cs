using System;

namespace RDP.ARB.Hunter.Domain
{
    public class Ordem
    {
 

        public decimal Preco { get; private set; }
        public decimal Quantidade { get; private set; }

        public Ordem(decimal preco, decimal quantidade)
        {
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}
