using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracaDyplomowaBackend.Repo;

namespace PracaDyplomowaBackend.Utilities.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["connectionStrings:pracaDyplomowaDBConnectionString"];
            services.AddDbContext<DataContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("PracaDyplomowaBackend.Repo")));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Praca dyplomowa", Version = "v1" })
            );
        }
    }
}
