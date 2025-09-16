using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteMind.BLL.Map;
using NoteMind.BLL.Services;
using NoteMind.BLL.Services.Interfaces;
using NoteMind.DAL;

namespace NoteMind.BLL
{
    public static class DependencyInjection
    {
        public static void GetDIBusinessLogicLayer(this IServiceCollection services,
            IMapperConfigurationExpression mapConfigExpression, IConfiguration configuration)
        {
            mapConfigExpression.AddProfile<MapProfile>();
            services.AddScoped<ITaskService, TaskService>();

            services.GetDIDataBaseLayer(configuration);
        }
    }
}