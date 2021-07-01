using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Softplan.CalculadoraJuros.CalculadoraApi.HttpClients;
using Softplan.CalculadoraJuros.Models;
using Softplan.CalculadoraJuros.CalculadoraApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalculadoraJuros.Testes
{
    public class CalculaJurosControllerCalculaJurosGet
    {
        [Fact]
        public async Task DadoEndpointTaxaJurosRespondendoRetornaOk200()
        {
            // arrange
            var taxaMock = new TaxaJuros(0.01);
            
            var mock = new Mock<IApiClient<TaxaJuros>>();
            mock.Setup(t => t.GetAsync()).Returns(Task.FromResult(taxaMock));

            var httpClient = mock.Object;

            var controller = new CalculaJurosController(httpClient);

            // act
            var resposta = await controller.CalculaJurosGet(100, 5);

            // assert            
            Assert.IsType<OkObjectResult>(resposta);
        }

        [Fact]
        public async Task DadoEndpointTaxaJurosForaDoArRetornaException()
        {
            var mock = new Mock<IApiClient<TaxaJuros>>();
            mock.Setup(t => t.GetAsync()).Throws(new Exception("Erro ao se conectar no servidor"));

            var httpClient = mock.Object;

            var controller = new CalculaJurosController(httpClient);

            // Assert
            await Assert.ThrowsAsync<Exception>(
                // Act
                async () => await controller.CalculaJurosGet(100, 5)
            );
        }

        // Teste para tratamento de erro e retorno 500 no Controller não foi implementado pois o Projeto já possui filtro de Exceptions configurado.
    }
}
