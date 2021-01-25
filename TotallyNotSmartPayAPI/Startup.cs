using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using TotallyNotSmartPayDbContext;

using TotallyNotSmartPayServices;
using TotallyNotSmartPayServices.Interfaces;

namespace TotallyNotSmartPayAPI
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

            services.AddTransient<ITotallyNotSmartPayRepo, TotallyNotSmartPayRepo>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                   new Microsoft.OpenApi.Models.OpenApiInfo
                   {
                       Title = "TotallyNotSmartPayAPI",
                       Description = "API that is totally not for SmartPay. Of any kind.",
                       Version = "v1"
                   });
                options.ResolveConflictingActions(c => c.First());
            });

            services.AddDbContext<MyDbContext>(options =>
            {
                //options.UseSqlServer(@"Server=localhost\\SQLEXPRESS01;Database=TotallyNotSmartPayDB;Trusted_Connection=True;");
                options.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=TotallyNotSmartPayDB;Trusted_Connection=True;");//work
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

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Totally Not SmartPay API");
            });
        }
    }
}
