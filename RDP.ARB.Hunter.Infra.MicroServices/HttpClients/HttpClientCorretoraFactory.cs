using RDP.ARB.Hunter.Infra.MicroServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDP.ARB.Hunter.Infra.MicroServices.HttpClients
{
    public class HttpClientCorretoraFactory : IHttpClientCorretoraFactory
    {
        public IHttpClientCorretora ObtemHttpClientPorCorretora(string corretora)
        {
            switch (corretora?.ToLowerInvariant())
            {
                case "bitcointrade": return new HttpClientCorretoraBitCoinTrade();
                case "mercadobitcoin": return new HttpClientCorretoraMercadoBitcoin();
                default: throw new ArgumentOutOfRangeException("nome de corretora inválido");
            }
        }
    }
}
