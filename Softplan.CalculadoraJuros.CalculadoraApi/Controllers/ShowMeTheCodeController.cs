using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.CalculadoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        /// <summary>
        /// Retorna a url do Git Hub
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        public IActionResult UrlRepositorioGitHubGet()
        {
            var caminhoRepositorio = "https://github.com/RogerGelonezi/Softplan.CalculadoraJuros";
            
            return Ok(caminhoRepositorio);
        }
    }
}
