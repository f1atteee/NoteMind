using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NoteMind.DAL.Interface;

namespace NoteMind.DAL
{
    public static class DependencyInjection
    {
        public static void GetDIDataBaseLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NoteMindDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GeneralConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
