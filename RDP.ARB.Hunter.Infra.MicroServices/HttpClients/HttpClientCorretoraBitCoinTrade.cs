using Newtonsoft.Json;
using RDP.ARB.Hunter.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;



namespace RDP.ARB.Hunter.Infra.MicroServices.HttpClients
{
    public class HttpClientCorretoraBitCoinTrade : HttpClientCorretoraBase
    {
        public override async Task<IEnumerable<Ordem>> CarregaOrdensAsync(string moeda)
        {
            string url = "https://api.bitcointrade.com.br/v2/public/BRLxrp/orders";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);
            var resultJson = await response.Content.ReadAsStringAsync();

            var dynamicResult = JsonConvert.DeserializeObject<dynamic>(resultJson);
            List<Ordem> ordens = new List<Ordem>();

            foreach (dynamic bid in dynamicResult.data.bids)
            {
                ordens.Add(new Ordem(Convert.ToDecimal(bid.unit_price), Convert.ToDecimal(bid.amount)));
            }

            return ordens;
        }
    }
}
