using Newtonsoft.Json;
using RDP.ARB.Hunter.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;



namespace RDP.ARB.Hunter.Infra.MicroServices.HttpClients
{
    public class HttpClientCorretoraMercadoBitcoin : HttpClientCorretoraBase
    {
        public override async Task<IEnumerable<Ordem>> CarregaOrdensAsync(string moeda)
        {
            string url = "https://www.mercadobitcoin.net/api/xrp/orderbook/";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);
            var resultJson = await response.Content.ReadAsStringAsync();

            var dynamicResult = JsonConvert.DeserializeObject<dynamic>(resultJson);
            List<Ordem> ordens = new List<Ordem>();

            foreach (dynamic bid in dynamicResult.asks)
            {
                ordens.Add(new Ordem(Convert.ToDecimal(bid[0]), Convert.ToDecimal(bid[1])));
            }

            return ordens;
        }
    }
}
