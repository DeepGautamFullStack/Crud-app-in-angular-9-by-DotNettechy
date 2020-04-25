using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using A9CrudService.Models;
using Microsoft.OpenApi.Models;

namespace A9CrudService
{
    /// <summary>
    /// // This tutrial is created by DotNettechy YouTube Channel
    ///  Video Link : https://youtu.be/4gYHNA9jkK0
    ///  Channel Link : https://www.youtube.com/channel/UCw_Sh-hhpXtF6lLLelhXIzg/videos
    ///
    /// </summary>
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                                                        "https://dotnettechycruda9.azurewebsites.net/",
                                                        "https://dotnettechya9crud.azurewebsites.net/",
                                                        "https://dotnettechycrud.azurewebsites.net/",
                                                        "https://dotnettechyangular.azurewebsites.net/")
                        .AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
            });
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:4200/",
            //                                            "https://dotnettechycruda9.azurewebsites.net/",
            //                                            "https://dotnettechya9crud.azurewebsites.net/",
            //                                            "https://dotnettechycrud.azurewebsites.net/",
            //                                            "https://dotnettechyangular.azurewebsites.net/");
            //        });
            //});
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:4200/",
            //                                              "https://dotnettechycruda9.azurewebsites.net/",
            //                                              "https://dotnettechya9crud.azurewebsites.net/",
            //                                              "https://dotnettechycrud.azurewebsites.net/",
            //                                              "https://dotnettechyangular.azurewebsites.net/")
            //                          .AllowAnyHeader().AllowAnyMethod();
            //                      });
            //});
            services.AddControllers();

            services.AddDbContext<A9CrudServiceContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("A9CrudServiceContext")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "A9 CRUD API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "A9 CRUD API");
            });

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
