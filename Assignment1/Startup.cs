
using Assignment1.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
       .ReadFrom.Configuration(configuration)
       .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategory, Categoryrepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment1", Version = "v1" });
            });
            services.AddSingleton<IConfiguration>(Configuration);
            //var connectionstring = Configuration.GetSection("").GetConnectionString("Connection");
            var connectionstring = Configuration.GetSection("ConnectionStrings").GetConnectionString("Connection");
            //// var connection = new SqlConnection("Data Source=MyDb;User Id=User;Password=TopSecret");
            //var compiler = new SqlServerCompiler();
            ////var connectionstring = iconfiguration.GetConnectionString("Connection").ToString();
            //var connection = new SqlConnection(Configuration.GetConnectionString("Connection").ToString());
            //var db = new QueryFactory(connection, compiler);
            ////var db = new QueryFactory(connectionstring , compiler);
            services.AddScoped(factory =>
            {
                return new QueryFactory
                {
                    Compiler = new SqlServerCompiler(),
                    Connection = new SqlConnection(connectionstring)
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment1");
            }
                );

        }
    }
}
