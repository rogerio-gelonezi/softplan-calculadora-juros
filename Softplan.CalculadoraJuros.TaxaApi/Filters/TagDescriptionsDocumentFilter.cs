using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Softplan.CalculadoraJuros.TaxaApi.Filters
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag> {
                new  OpenApiTag { Name = "TaxaJuros", Description = "Retorna a taxa de juros." },
            };
        }
    }
}
