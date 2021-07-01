using Microsoft.AspNetCore.Mvc;
using Softplan.CalculadoraJuros.CalculadoraApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.CalculadoraJuros.Testes
{
    public class ShowMeTheCodeControllerUrlRepositorioGitHubGet
    {
        [Fact]
        public void DadoAcessoAoEndpointRetornarStatusOk200()
        {
            // Arrange
            var controlador = new ShowMeTheCodeController();

            // act
            var retorno = controlador.UrlRepositorioGitHubGet();

            // assert
            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void DadoAcessoAoEndpointRetornarUrlGitHub()
        {
            // Arrange
            var controlador = new ShowMeTheCodeController();
            var valorEsperado = "https://github.com/RogerGelonezi/Softplan.CalculadoraJuros";
            var retorno = controlador.UrlRepositorioGitHubGet();
            var retornoOk = retorno as OkObjectResult;

            // act
            var valorRetornado = retornoOk.Value as string;

            // assert
            Assert.Equal(valorEsperado, valorRetornado);
        }
    }
}
