using System.Configuration;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Interfaces.Services;
using FundosInvestimento.Infra.Data.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace FundosInvestimento.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FundosInvestimentoContext>(x => x.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            //Registra o gerador Swagger definindo um ou mais documentos Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FundosInvestimento", Version = "v1" });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IFundosAppService, FundosAppService>();
            //services.AddTransient<IFundosAppService, AuthMessageSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days.You may want to change this for
                // production scenarios, see https://aka.ms/aspnetcore-hsts.
               app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //Habilita o middleware para servir o Swagger gerado com um endpoint JSON
            app.UseSwagger();
            //Habilita o middleware para servir o swagger-ui(HTML, JS, CSS, etc)
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FundosInvestimento V1");
            });
        }
    }
}
