using API.Data;
using APITemplate.Repository.Implementation;
using APITemplate.Repository.Interface;
using APITemplate.Service.Implementation;
using APITemplate.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APITemplate
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseInMemoryDatabase("InMemoryData");
            });

            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper();
            //Enables OData Funictionality.
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //Enable Odata Query on existing Api endpoints.
            app.UseMvc(routeBuilder => 
            {
                routeBuilder.EnableDependencyInjection();
                //Following Query Functionality is added on existing URL. append wit $sign.
                //Like: https://localhost:44397/api/Applications?$select=appName
                routeBuilder.Expand().Select().Filter().MaxTop(10).OrderBy();
            });
        }
    }
}
