using RDP.ARB.Hunter.Application.Models;
using RDP.ARB.Hunter.Domain;
using RDP.ARB.Hunter.Domain.Models;
using RDP.ARB.Hunter.Infra.MicroServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RDP.ARB.Hunter.Application.Services
{
    public class OrdensService : IOrdensService
    {
        private IHttpClientCorretoraFactory _httpClientCorretoraFactory;

        public OrdensService(IHttpClientCorretoraFactory httpClientCorretoraFactory)
        {
            _httpClientCorretoraFactory = httpClientCorretoraFactory;
        }

        public OrdensPorMoedaResult ObtemOrdensPorMoeda(OrdensPorMoedaRequest requestModel)
        {
            var resultado = new OrdensPorMoedaResult(requestModel.Moeda);

            foreach (string corretora in requestModel.Corretoras)
            {
                var cliente = _httpClientCorretoraFactory.ObtemHttpClientPorCorretora(corretora);
                var ordens = cliente.CarregaOrdensAsync(requestModel.Moeda).Result;

                var ordensModel = ordens.Select(o => new OrdemCorretora() {
                    Preco = o.Preco,
                    Quantidade = o.Quantidade
                });

                var ordensPorCorretora = new OrdensPorCorretora(ordensModel, corretora);
                resultado.OrdensPorCorretora.Add(ordensPorCorretora);
            }

            return resultado;
        }

        public SpreadPorMoedaResult ObtemSpreadPorMoeda(IEnumerable<OrdensPorCorretora> requestModel)
        {
            var ordensSpread = new Dictionary<string, Ordem>();

            foreach(var ordensCorretora in requestModel)
            {
                var precoTop = ordensCorretora.Ordens.First().Preco;
                var quantidadeTop = ordensCorretora.Ordens.Where(o => o.Preco == precoTop).Sum(o => o.Quantidade);

                Ordem topOrdemCorretora = new Ordem(precoTop, quantidadeTop);
                ordensSpread.Add(ordensCorretora.Corretora, topOrdemCorretora);
            }

            CarregaOportunidades(ordensSpread);

            return new SpreadPorMoedaResult();
        }

        private IEnumerable<OportunidadeSpread> CarregaOportunidades(Dictionary<string, Ordem> topOrdensCorretoras)
        {
            if (!ValidateMinimalAmount(topOrdensCorretoras))
                return null;

            var potenciaisDeOperacao = ObtemPotenciaisOportunidades(topOrdensCorretoras);

            var oportunidadesDeSpread = CalculaOportunidadesSpread(potenciaisDeOperacao);

            return oportunidadesDeSpread;
        }

        private IEnumerable<OportunidadeSpread> CalculaOportunidadesSpread(IEnumerable<PotencialOrdemCorretora> potenciaisDeOperacao)
        {
            var listaSpread = new List<OportunidadeSpread>();

            foreach(var potencial in potenciaisDeOperacao)
            {
                var oportunidade = new OportunidadeSpread();

                oportunidade.QuantidadeLimite = potencial.QuantidadeMaximaFirst();

                //potencial.Origem.Corretora
            }

            return listaSpread;
        }

        private OportunidadeSpread CalculaOportunidade(PotencialOrdemCorretora potencialDeOrdem)
        {
            var oportunidade = new OportunidadeSpread();

            oportunidade.QuantidadeLimite = potencialDeOrdem.QuantidadeMaximaFirst();
            oportunidade.Spread = potencialDeOrdem.SpreadFirst();

            if (oportunidade.EhValida())
            {
                oportunidade.Calcular();
            }

            return oportunidade;
        }


        private bool ValidateMinimalAmount(Dictionary<string, Ordem> topOrdensCorretoras)
        {
            return (topOrdensCorretoras.Count > 1);
        }

        private IEnumerable<PotencialOrdemCorretora> ObtemPotenciaisOportunidades(Dictionary<string, Ordem> topOrdensCorretoras)
        {
            var listaOportunidades = new List<PotencialOrdemCorretora>();

            foreach(var corretoraOrigem in topOrdensCorretoras)
            {
                foreach(var corretoraDestino in topOrdensCorretoras)
                {
                    if (corretoraOrigem.Key == corretoraDestino.Key)
                    {
                        continue;
                    }

                    var potencial = new PotencialOrdemCorretora()
                    {
                        Origem = new OrdemPorCorretora(corretoraOrigem.Key, corretoraOrigem.Value),
                        Destino = new OrdemPorCorretora(corretoraDestino.Key, corretoraDestino.Value)
                    };

                    listaOportunidades.Add(potencial);
                }
            }

            return listaOportunidades;
        }
    }
}
