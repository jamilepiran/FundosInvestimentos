using AutoMapper;
using FundosInvestimento.API.Models;
using FundosInvestimento.Application;
using FundosInvestimento.Application.Interface;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Domain.Interfaces.Repositories;
using FundosInvestimento.Domain.Interfaces.Services;
using FundosInvestimento.Domain.Services;
using FundosInvestimento.Infra.Data.Contexto;
using FundosInvestimento.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<FundosInvestimentoContext>(x => x.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            //Dependency Injection
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IFundosAppService, FundosAppService>();
            services.AddScoped<IFundosService, FundosService>();
            services.AddTransient<IFundosRepository, FundosRepository>();

            services.AddScoped<IAplicacaoResgateAppService, AplicacaoResgateAppService>();
            services.AddScoped<IAplicacaoResgateService, AplicacaoResgateService>();
            services.AddTransient<IAplicacaoResgateRepository, AplicacaoResgateRepository>();

            //Registra o gerador Swagger definindo um ou mais documentos Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FundosInvestimento", Version = "v1" });
            });

            services.AddMvcCore()
                    .AddApiExplorer()
                    .AddJsonFormatters()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InsereFundosInvestimentoRequest, Fundos>();
                cfg.CreateMap<InsereFundosInvestimentoResponse, Fundos>();
                cfg.CreateMap<InsereMovimentacaoInvestimentoRequest, AplicacaoResgate>();
                cfg.CreateMap<InsereMovimentacaoInvestimentoResponse, AplicacaoResgate>();
                cfg.CreateMap<ListaFundosInvestimentoResponse, Fundos>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            //AutoMapper
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
              
            app.UseMvcWithDefaultRoute();

            //Habilita o middleware para servir o Swagger gerado com um endpoint JSON
            app.UseSwagger();
            //Habilita o middleware para servir o swagger-ui(HTML, JS, CSS, etc)
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FundosInvestimento V1");
            });
        }
    }
}
