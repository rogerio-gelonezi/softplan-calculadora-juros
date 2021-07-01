using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Softplan.CalculadoraJuros.CalculadoraApi.Filters;
using Softplan.CalculadoraJuros.CalculadoraApi.HttpClients;
using Softplan.CalculadoraJuros.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Net;
using Softplan.CalculadoraJuros.CalculadoraApi.Models;
using System.Net.Sockets;

namespace Softplan.CalculadoraJuros.CalculadoraApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Softplan CalculadoraJuros CalcularApi",
                    Description = "by Rogerio Gelonezi, Twitter @roger_eumesmo",
                    Version = "v1"
                });

                c.DocumentFilter<TagDescriptionsDocumentFilter>();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<IApiClient<TaxaJuros>, TaxaJurosApiClient>();

            var endpointApiTaxaJuros = Configuration.GetSection("EndpointApiTaxaJuros");
            var endpointPublicacaoDocker = Configuration.GetSection("EndpointPublicacaoDocker"); ;
            services.AddHttpClient<HttpClientContext>(client =>
            {
                // client.BaseAddress = new Uri(endpointApiTaxaJuros.Value);
                client.BaseAddress = new Uri(endpointApiTaxaJuros.Value);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler()
                {
                    // bypass para trava em trusted ssl, forçando sempre true
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorResponseFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Softplan.CalculadoraJuros.CalculadoraApi v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
