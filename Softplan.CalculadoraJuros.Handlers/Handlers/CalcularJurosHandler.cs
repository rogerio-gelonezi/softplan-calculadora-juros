using Microsoft.Extensions.Logging;
using Softplan.CalculadoraJuros.Handlers.Commands;
using Softplan.CalculadoraJuros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculadoraJuros.Handlers.Handlers
{
    public class CalcularJurosHandler
    {

        public ValorCalculadoJuros Execute(CalcularJurosCommand comando)
        {
            var mensagemErro = RetornarErrosDeComando(comando);
            if (!string.IsNullOrEmpty(mensagemErro))
            {
                throw new ArgumentException(mensagemErro);
            }

            var multiplicadorJurosComposto = Math.Pow(1 + comando.TaxaJuros.ValorMultiplicadorJuros, comando.Meses);
            var valorComJuros = comando.ValorInicial * multiplicadorJurosComposto;
            var valorArredondadoDuasCasas = Math.Floor(valorComJuros * 100) / 100;
            
            var taxaJuros = new TaxaJuros(comando.TaxaJuros.ValorMultiplicadorJuros);

            var retorno = new ValorCalculadoJuros(valorArredondadoDuasCasas, comando.ValorInicial, taxaJuros, comando.Meses);

            return retorno;
        }

        private string RetornarErrosDeComando(CalcularJurosCommand comando)
        {
            var mensagemErro = "";

            if (comando.TaxaJuros.ValorMultiplicadorJuros < 0)
            {
                mensagemErro += "Valor do juros deve ser maior ou igual a zero. ";
            }

            if (comando.ValorInicial <= 0)
            {
                mensagemErro += "Valor inicial deve ser maior que zero. ";
            }

            if (comando.Meses <= 0)
            {
                mensagemErro += "O período em meses deve ser maior que zero. ";
            }

            return mensagemErro;
        }
    }
}
