using Krunker.BL.Services;
using Krunker.Common.API;
using Krunker.Common.Interfaces;
using Krunker.DAL;
using Krunker.DAL.Repositories;
using Krunker.Server.ModelBinders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using static Krunker.Common.Constants.Constants;

namespace Krunker.Server
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
            services.AddCors(options => options.AddPolicy(CORS_POLICY_NAME, builder =>
                builder.WithOrigins("http://localhost:8080", "http://localhost:65220")
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            services.AddDbContext<ShopContext>(opt =>
            {
                string dataSource = DATABASE_NAME;
#if DEBUG
                string relativeDataSource = Path.Combine(Environment.CurrentDirectory ?? "", "..", "Krunker.DAL", dataSource);
                dataSource = Path.GetFullPath(relativeDataSource);
#endif
                opt
                    .UseSqlite($"Data Source={dataSource}")
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(warn => warn.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
            });
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IPurchasesService, PurchaseService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddControllers(o => o.ModelBinderProviders.Insert(0, new ShoppingItemModelBinderProvider())).AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebShopAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebShopAPI v1"));

            app.UseCors(CORS_POLICY_NAME);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
