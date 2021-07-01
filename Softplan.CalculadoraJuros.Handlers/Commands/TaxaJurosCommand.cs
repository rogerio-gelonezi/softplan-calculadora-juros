namespace Softplan.CalculadoraJuros.Handlers.Commands
{
    public class TaxaJurosCommand
    {
        public double ValorMultiplicadorJuros {get;}
        public TaxaJurosCommand(double valorMultiplicadorJuros)
        {
            ValorMultiplicadorJuros = valorMultiplicadorJuros;
        }
    }
}