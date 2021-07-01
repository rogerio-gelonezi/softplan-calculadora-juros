using Microsoft.AspNetCore.Mvc;
using Softplan.CalculadoraJuros.TaxaApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.CalculadoraJuros.Testes
{
    public class TaxaJurosControllerEndpointGet
    {
        [Fact]
        public void DadoAcessoAoEndpointRetornarStatusOk200()
        {
            // Arrange
            var controlador = new TaxaJurosController();
            
            // act
            var retorno = controlador.RetornaTaxaJuros();

            // assert
            Assert.IsType<OkObjectResult>(retorno);
        }

        [Fact]
        public void DadoAcessoAoEndpointLerValor0_01()
        {
            // Arrange
            var controlador = new TaxaJurosController();
            var valorEsperado = 0.01;
            var retorno = controlador.RetornaTaxaJuros();
            var retornoOk = retorno as OkObjectResult;

            // act
            var valorRetornado = retornoOk.Value as double?;

            // assert
            Assert.Equal(valorEsperado, valorRetornado);
        }
    }
}
