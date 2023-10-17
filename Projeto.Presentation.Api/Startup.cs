using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("ProjetoAPI");

            services.AddTransient(map => new ClienteRepository(connectionString));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "API para Controle de Clientes",
                    Version = "v1",
                    Description = "Projeto desenvolvido em NET CORE API com Dapper",
                Contact = new OpenApiContact
                {
                    Name = "GitHub",
                    Url = new Uri("https://github.com/talvaneramos"),                    
                    Email = "talvanesilvaramos@gmail.com"
                }
                });
            });

            
            services.AddCors(
            s => s.AddPolicy("DefaultPolicy",
            builder => {
                builder.AllowAnyOrigin()
                
                .AllowAnyMethod()                
                .AllowAnyHeader();                
            }));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            
            app.UseCors("DefaultPolicy");

            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint
            ("/swagger/v1/swagger.json", "Projeto");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
