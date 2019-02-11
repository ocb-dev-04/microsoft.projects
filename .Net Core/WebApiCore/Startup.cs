using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelCore.Data;
using ModelCore.Entities;
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

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(ConfigureJson);
        }

        private void ConfigureJson(MvcJsonOptions obj) 
            => obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

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
            

        }

        #endregion
    }
}
