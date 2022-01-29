using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Nexos.Cliente.Domain.Core.Services;
using Nexos.Cliente.Domain.Core.Services.InterfaceRepository;
using Nexos.Cliente.Domain.Core.Services.InterfaceService;
using Nexos.Cliente.Infrastructure.Persistence;
using Nexos.Cliente.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Nexos.Cliente.Core.API
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

            services.AddControllers();

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add Context
            services.AddDbContext<NexosClienteDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionDB"),
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.EnableRetryOnFailure();
                          });
            });
            services.AddScoped(typeof(DbContext), typeof(NexosClienteDBContext));

            services.AddScoped<IWriteableAutorRepository, AutorRepository>();
            services.AddScoped<IReadableAutorRepository, AutorRepository>();
            services.AddScoped<IRemovableAutorRepository, AutorRepository>();
            services.AddScoped<IReadableAutorService, AutorService>();
            services.AddScoped<IWriteableAutorService, AutorService>();
            services.AddScoped<IRemovableAutorService, AutorService>();

            // Register the Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nexos Cliente Core API v1",
                    Version = "1.0"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nexos.Cliente.Core.API v1");
                c.RoutePrefix = string.Empty;
            });

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
