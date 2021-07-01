using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softplan.CalculadoraJuros.CalculadoraApi.Filters;
using Softplan.CalculadoraJuros.CalculadoraApi.HttpClients;
using Softplan.CalculadoraJuros.CalculadoraApi.Models;
using Softplan.CalculadoraJuros.Handlers.Commands;
using Softplan.CalculadoraJuros.Handlers.Handlers;
using Softplan.CalculadoraJuros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.CalculadoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        IApiClient<TaxaJuros> _taxaJurosClient;


        public CalculaJurosController(IApiClient<TaxaJuros> taxaJurosClient)
        {
            _taxaJurosClient = taxaJurosClient;
        }

        /// <summary>
        /// Calcula o valor final com o juros aplicado em um valor sobre os meses
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Error</response>
        [HttpGet]
        public async Task<IActionResult> CalculaJurosGet(
            [FromQuery] double valorInicial,
            [FromQuery] int meses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.FromModelState(ModelState));
            }

            var taxaJuros = await _taxaJurosClient.GetAsync();

            var taxaJurosCommand = new TaxaJurosCommand(taxaJuros.ValorMultiplicadorJuros);
            var calcularJurosCommand = new CalcularJurosCommand(valorInicial, taxaJurosCommand, meses);
            var handler = new CalcularJurosHandler();

            var resultado = handler.Execute(calcularJurosCommand);

            return Ok(resultado.ValorFinal);
        }
    }
}
