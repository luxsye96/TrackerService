using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TrackingService.Interface;
using TrackingService.Repository;
using TrackingService.Service;

namespace TrackingService
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

             string dbconn = Environment.GetEnvironmentVariable("DBConnection");
            //string dbconn = "Server=localhost;user=root;password=admin;database=tracking_service;";
            services.AddMvc();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IIncomeService, IncomeService>();

            services.AddDbContext<TrackerContext>(options =>
            {
                options.UseSqlServer(dbconn);
            });
            services.AddSwaggerDocument();
            services.AddControllers();

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

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
