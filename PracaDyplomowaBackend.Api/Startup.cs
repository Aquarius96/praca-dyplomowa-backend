using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Repo.Repositories;

namespace PracaDyplomowaBackend.Api
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
            #region DataContext
            var connectionString = Configuration["connectionStrings:pracaDyplomowaDBConnectionString"];
            services.AddDbContext<DataContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("PracaDyplomowaBackend.Repo")));
            #endregion

            #region Swagger
            services.AddSwaggerGen(options =>
            options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Praca dyplomowa", Version = "v1" })
            );
            #endregion

            #region Repositories
            //services.AddSingleton(typeof(IRepositoryBase<,>), typeof(UserRepository));
            #endregion

            #region Services
            #endregion
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PracaDyplomowa")
            );

            app.UseMvc();
        }
    }
}
