using Autofac;
using Autofac.Extensions.DependencyInjection;
using DefinexService.BL.Interfaces;
using DefinexService.BL.Service;
using DefinexService.DAL.Context;
using DefinexService.DAL.GenericRepository;
using DefinexService.DAL.UOW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace DefinexService
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

            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));

            }, ServiceLifetime.Transient);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFactoryClient, FactoryClient>();            
            services.AddScoped<ICreditApplicationService, CreditApplicationService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
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
        }
    }
}
