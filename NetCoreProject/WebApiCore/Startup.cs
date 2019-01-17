using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelCore.Data;
using ModelCore.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApiCore.Services;

namespace WebApiCore
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Construct

        public Startup(IConfiguration configuration) 
            => Configuration = configuration;

        #endregion

        #region ConfigureServices

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppRandI();
            services.AddDBInfo(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        #endregion

        #region Configure ( app/env )

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            AppContext appContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            if(!appContext.Products.Any())
            {
                appContext.Products.AddRangeAsync(new List<Products>()
                {
                    new Products() {Id = 1, Name = "Desktop chair", Description = "Perfect to bussines", Price = 125, Create = System.DateTime.Now, Stock= 25 },
                    new Products() {Id = 2, Name = "Desktop PC", Description = "Strong desktop computer", Price = 2563, Create = System.DateTime.Now, Stock= 25 }
                });

                appContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}
