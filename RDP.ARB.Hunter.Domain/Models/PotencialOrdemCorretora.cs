using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDP.ARB.Hunter.Domain.Models
{
    public class PotencialOrdemCorretora
    {
        public OrdemPorCorretora Origem;
        public OrdemPorCorretora Destino;

        public decimal QuantidadeMaximaFirst()
        {
            var ordemOrigemFirst = Origem?.Ordens?.FirstOrDefault();
            var ordemDestinoFirst = Destino?.Ordens?.FirstOrDefault();

            decimal quantidadeMaximaOperacao = 0;

            if (ordemOrigemFirst != null && ordemDestinoFirst != null)
            {
                quantidadeMaximaOperacao = Math.Min(
                    ordemOrigemFirst.Quantidade,
                    ordemDestinoFirst.Quantidade
                );
            }

            return quantidadeMaximaOperacao;
        }

        public decimal SpreadFirst()
        {
            var ordemOrigemFirst = Origem?.Ordens?.FirstOrDefault();
            var ordemDestinoFirst = Destino?.Ordens?.FirstOrDefault();
            decimal valorSpread = 0;

            if (ordemOrigemFirst != null && ordemDestinoFirst != null)
            {
                valorSpread = (ordemDestinoFirst.Preco - ordemOrigemFirst.Preco) / ordemOrigemFirst.Preco;
            }

            return valorSpread;
        }
    }
}
