using Softplan.CalculadoraJuros.Handlers.Commands;
using Softplan.CalculadoraJuros.Handlers.Handlers;
using System;
using Xunit;

namespace Softplan.CalculadoraJuros.Testes
{
    public class CalcularJurosHandlerExecute
    {
        [Theory]
        [InlineData(105.10, 100, 0.01, 5)]
        [InlineData(110.46, 100, 0.01, 10)]
        [InlineData(110.40, 100, 0.02, 5)]
        [InlineData(121.89, 100, 0.02, 10)]
        public void RetornaCalculoCertoDadoInformacoesValidas(
            double resultadoEsperado, 
            double varlorInicial, 
            double valorMultiplicadorJuros, 
            int meses)
        {
            // arrange
            var handler = new CalcularJurosHandler();
            var taxaJuros = new TaxaJurosCommand(valorMultiplicadorJuros);

            var comando = new CalcularJurosCommand(varlorInicial, taxaJuros, meses);
            
            // act
            var valorCalculadoJuros = handler.Execute(comando);

            // assert
            Assert.Equal(resultadoEsperado, valorCalculadoJuros.ValorFinal);
        }

        [Fact]
        public void RetornaArgumentExceptionDadoValorInicialNegativo()
        {
            // arrange
            double varlorInicial = -100;
            double valorMultiplicadorJuros = 0.01;
            int meses = 5;
            var handler = new CalcularJurosHandler();
            var taxaJuros = new TaxaJurosCommand(valorMultiplicadorJuros);

            var comando = new CalcularJurosCommand(varlorInicial, taxaJuros, meses);

            // Assert
            Assert.Throws<ArgumentException>(
                // Act
                () => handler.Execute(comando)
            );
        }

        [Fact]
        public void RetornaArgumentExceptionDadoValorMultiplicadorJurosNegativo()
        {
            // arrange
            double varlorInicial = 100;
            double valorMultiplicadorJuros = -0.01;
            int meses = 5;
            var handler = new CalcularJurosHandler();
            var taxaJuros = new TaxaJurosCommand(valorMultiplicadorJuros);

            var comando = new CalcularJurosCommand(varlorInicial, taxaJuros, meses);

            // Assert
            Assert.Throws<ArgumentException>(
                // Act
                () => handler.Execute(comando)
            );
        }

        [Fact]
        public void RetornaArgumentExceptionDadoNumeroDeMesesNegativo()
        {
            // arrange
            double varlorInicial = 100;
            double valorMultiplicadorJuros = -0.01;
            int meses = 5;
            var handler = new CalcularJurosHandler();
            var taxaJuros = new TaxaJurosCommand(valorMultiplicadorJuros);

            var comando = new CalcularJurosCommand(varlorInicial, taxaJuros, meses);

            // Assert
            Assert.Throws<ArgumentException>(
                // Act
                () => handler.Execute(comando)
            );
        }
    }
}
