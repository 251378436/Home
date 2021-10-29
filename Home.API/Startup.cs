using Home.API.Filters;
using Home.Common.DAL;
using Home.Common.Factory;
using Home.Common.Grains;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Home.API
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
            // Register services
            services.AddSingleton(typeof(IDAL), typeof(DAL));
            services.AddSingleton(typeof(ISalesOrdersGrain), typeof(SalesOrdersGrain));
            services.AddSingleton(typeof(ISalesOrderItemsGrain), typeof(SalesOrderItemsGrain));
            services.AddSingleton(typeof(DBFactory));

            // Register Filters
            services.AddSingleton<ControllerActionFilter>();
            services.AddSingleton<ActionActionFilter>();

            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilter));
                config.Filters.Add(new ValidationActionFilter());
                config.Filters.Add(new GLobalActionFilter());
                config.Filters.Add(new GLobalAsyncActionFilter());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Home.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Home.API v1"));
            }

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