using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.CalculadoraApi.HttpClients
{
    public class HttpClientContext
    {
        public HttpClient HttpClient { get; set; }
        public HttpClientContext(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}
