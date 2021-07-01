using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Softplan.CalculadoraJuros.CalculadoraApi.Filters
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag> {
                new  OpenApiTag { Name = "CalculaJuros", Description = "Retorna o valor calculado do juros de acordo com os parâmetros fornecidos." },
                new  OpenApiTag { Name = "ShowMeTheCode", Description = "Retorna a url do código fonte deste projeto no Git Hub." },
            };
        }
    }
}
