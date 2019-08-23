using System;
using System.Collections.Generic;
using System.Text;

namespace RDP.ARB.Hunter.Domain.Models
{
    public class OportunidadeSpread
    {
        public decimal TaxaCompra { get; set; }
        public decimal TaxaVenda { get; set; }
        public decimal TaxaOperacao { get; set; }
        public string CorretoraCompra { get; set; }
        public string CorretoraVenda { get; set; }

        public decimal QuantidadeLimite { get; set; }
        public decimal QuantidadeCompra { get; set; }
        public decimal QuantidadeTaxaCompra { get; set; }
        public decimal QuantidadeVenda { get; set; }

        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }

        public decimal FinanceiroCompra { get; set; }
        public decimal FinanceiroVenda { get; set; }

        public decimal LucroOperacao { get; set; }
        public decimal Spread { get; set; }

        public bool EhLucrativa()
        {
            return LucroOperacao > 0;
        }

        public bool EhValida()
        {
            return true;
        }

        public void Calcula(decimal taxaVenda, decimal quantidadeTaxaMineracao)
        {
            QuantidadeCompra = QuantidadeLimite;
            //QuantidadeTaxaVenda = QuantidadeLimite * TaxaVenda;
            //QuantidadeTaxaMineracao = quantidadeTaxaMineracao;
            QuantidadeVenda = QuantidadeLimite - (QuantidadeTaxaCompra);
        }

        private void CarregaQuantidade()
        {
            
        }

        public void Calcular()
        {
            throw new NotImplementedException();
        }
    }
}
