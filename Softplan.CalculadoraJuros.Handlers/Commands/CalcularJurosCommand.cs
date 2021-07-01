using Softplan.CalculadoraJuros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculadoraJuros.Handlers.Commands
{
    public class CalcularJurosCommand
    {
        public double ValorInicial { get; }
        public int Meses { get; }
        public TaxaJurosCommand TaxaJuros { get; }

        public CalcularJurosCommand(double valorInicial, TaxaJurosCommand taxaJuros, int meses)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
            Meses = meses;
        }
    }
}
