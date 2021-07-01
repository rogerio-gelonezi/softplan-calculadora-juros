using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.CalculadoraApi.HttpClients
{
    public interface IApiClient<T>
    {
        Task<T> GetAsync();
    }
}
