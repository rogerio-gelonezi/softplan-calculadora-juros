using Microsoft.AspNetCore.Http;
using Softplan.CalculadoraJuros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.CalculadoraApi.HttpClients
{
    public class TaxaJurosApiClient : IApiClient<TaxaJuros>
    {
        private readonly HttpClient _httpClient = null;

        public TaxaJurosApiClient(HttpClientContext httpClient)
        {
            _httpClient = httpClient.HttpClient;
        }

        public async Task<TaxaJuros> GetAsync()
        {
            var resposta = await _httpClient.GetAsync("TaxaJuros");
            resposta.EnsureSuccessStatusCode();

            var valorMultiplicadorJuros = await resposta.Content.ReadAsAsync<double>();

            var taxaJuros = new TaxaJuros(valorMultiplicadorJuros);

            return taxaJuros;
        }
    }
}
