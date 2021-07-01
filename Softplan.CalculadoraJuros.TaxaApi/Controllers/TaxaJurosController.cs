using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softplan.CalculadoraJuros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.TaxaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Retorna o valor multiplicado da taxa de juros aplicada atualmente
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        public IActionResult RetornaTaxaJuros()
        {
            // Obs.: Esta taxa poderia ser configurada através do arquivo appsettings.json e carregada como parâmetro pelo Startup.cs.
            // Porém, seguindo os requisitos, ela deveria ser fixada no código (hard coded)
            var taxaJuros = new TaxaJuros(0.01);

            return Ok(taxaJuros.ValorMultiplicadorJuros);
        }
    }
}
