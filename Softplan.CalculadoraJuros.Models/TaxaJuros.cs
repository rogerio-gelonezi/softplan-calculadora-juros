using System;

namespace Softplan.CalculadoraJuros.Models
{
    public class TaxaJuros
    {
        public double ValorMultiplicadorJuros { get; set; }
        public TaxaJuros(double valorMultiplicadorJuros)
        {
            ValorMultiplicadorJuros = valorMultiplicadorJuros;
        }

        public double PercentualJuros
        {
            get
            {
                return ValorMultiplicadorJuros * 100;
            }
        }
    }
}
