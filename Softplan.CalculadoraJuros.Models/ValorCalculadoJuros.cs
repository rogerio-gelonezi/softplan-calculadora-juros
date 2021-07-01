using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.CalculadoraJuros.Models
{
    public class ValorCalculadoJuros
    {
        public double ValorFinal { get; set; }
        public double ValorInicial { get; set; }
        public TaxaJuros TaxaJuros { get; set; }
        public int Meses { get; set; }

        public ValorCalculadoJuros(double valorFinal, double valorInicial, TaxaJuros taxaJuros, int meses)
        {
            ValorFinal = valorFinal;
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
            Meses = meses;
        }
    }
}
