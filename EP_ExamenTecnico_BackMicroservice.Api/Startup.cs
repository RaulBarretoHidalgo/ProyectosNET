using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Util;


namespace EP_Planning_BackMicroservice.Api
{
    /// <summary>
    /// Clase de configuracion de la aplicacion : Startup 
    /// </summary>
    public class Startup
{
    /// <summary>
    /// Inicializa la aplicacion
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configuracion de la aplicaci�n
    /// </summary>
    public IConfiguration Configuration { get; }


    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
         
        DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
        //Class to map the key values from config json
        TrackerConfig._configuration = Configuration;
        services.AddCors();

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "EP_Planning_Back API",
                Version = "v1",
                Description = "Api para consulta del portal de  EP_Planning_Back",
                Contact = new OpenApiContact()
                {
                    Name = "dev",
                    Email = "dev@ucv.edu.pe"
                }
            });

        });
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options =>
            {
                //options.WithOrigins("https://sysadm.uss.edu.pe:4430");
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                
            }
            );
            
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "EP_Planning_Back API V1");
        });

        app.UseCors("MyPolicy");
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync(" Microservice " + "EP_Planning_Back  is running .... ");
        });

           
    }
}
}
