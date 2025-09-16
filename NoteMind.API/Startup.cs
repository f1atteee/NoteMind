using AutoMapper;
using ClientManager.Api.Auth;
using NoteMind.API.MapProfiles;
using NoteMind.API.Swagger;
using NoteMind.BLL;

namespace NoteMind.API
{
    public class Startup
    {
        private const string _swaggerEndpoint = "/swagger/v1/swagger.json";
        private const string _tokenSecurityKey = "TokenSecurityKey";
        private const string _swaggerVersionName = "NoteMind.API v1";

        private readonly IConfiguration _configRoot;

        public Startup(ConfigurationManager configuration)
        {
            _configRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfigurationExpression();
            mapperConfig.AddProfile<MapProfile>();


            services.AddControllers();
            services.AddTokenAuthentication(_configRoot.GetSection(_tokenSecurityKey).Value!);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerOptions();

            services.GetDIBusinessLogicLayer(mapperConfig, _configRoot);

            services.AddSingleton(new MapperConfiguration(mapperConfig).CreateMapper());
            services.AddCors();

        }

        public void Configure(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(_swaggerEndpoint, _swaggerVersionName));

            app.UseRouting();

            app.UseCors(options => options.WithOrigins("*").WithHeaders("*").WithMethods("*"));

            app.MapControllers();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}