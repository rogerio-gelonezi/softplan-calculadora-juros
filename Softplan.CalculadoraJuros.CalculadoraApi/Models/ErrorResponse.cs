using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.CalculadoraJuros.CalculadoraApi.Models
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Detalhes { get; set; }

        public static ErrorResponse FromException(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            return new ErrorResponse
            {
                Codigo = ex.HResult,
                Mensagem = ex.Message,
                InnerError = ErrorResponse.FromException(ex.InnerException)
            };
        }

        public static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            return new ErrorResponse
            {
                Codigo = 100,
                Mensagem = "Houve erro(s) no envio da requisição.",
                Detalhes = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }

        public static ErrorResponse FromBadRequest(string message, string detail = null)
        {
            var details = new string[] { detail };

            return new ErrorResponse
            {
                Codigo = 400,
                Mensagem = message,
                Detalhes = details,
            };
        }
    }
}
