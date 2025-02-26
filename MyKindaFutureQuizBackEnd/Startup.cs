using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Shared;
using StarShipService;
using StarShipService.Interfaces;


namespace MyKindaFutureQuizBackEnd
{
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
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000");
                    });
            });
            services.AddControllers();
            services.AddSingleton<IStarShipService, StarShipService.StarShipService>();

            services
                .AddDbContext<StarshipDbContext>(
                    options => options
                        .UseSqlServer(Configuration["sqldb:connectionString"]),
                    ServiceLifetime.Transient,
                    ServiceLifetime.Transient
                );

            services
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IStarshipRepository, StarshipRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
