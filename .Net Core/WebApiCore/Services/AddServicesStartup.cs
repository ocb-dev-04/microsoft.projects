using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelCore.Data;
using ModelCore.Interfaces;
using ModelCore.Repositories;

namespace WebApiCore.Services
{
    public static class AddServicesStartup
    {

        public static void AddAppRandI(this IServiceCollection services)
        {
            services.AddScoped<
                ICategoriesRepository,
                CategoriesRepository>();

            services.AddScoped<
                IProductsRepository,
                ProductsRepository>();
        }

        public static void AddDBInfo(this IServiceCollection services, IConfiguration Configuration)
        {/*
            services.AddDbContext<AppContext>(
                optrions => optrions.UseInMemoryDatabase("ApiCore_ExampleDB"));
        */
            var connection = @"Server=.;Database=API_Core_TestDB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<AppContext>
                (options => options.UseSqlServer(connection));

        }

    }
}
