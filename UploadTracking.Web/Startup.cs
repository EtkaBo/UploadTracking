using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UploadTracking.BLL.Implementations;
using UploadTracking.BLL.Interfaces;
using UploadTracking.DataModel.Model;
using UploadTracking.Repository.Interfaces;
using UploadTracking.Repository.Repositories;

namespace UploadTracking.Web
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
            services.AddMvc();

            services.AddScoped<IShopifyBLL, ShopifyBLL>();
            services.AddScoped<IStoreIntegrationRepository, StoreIntegrationRepository>();
            services.AddScoped<IUploadTrackingContext, UploadTrackingContext>();

            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IUserRepository, UserRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
