using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracaDyplomowaBackend.Api.AutoMapperProfiles;
using PracaDyplomowaBackend.Api.Helpers.Extensions;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Repo.Repositories;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Service.Services;
using PracaDyplomowaBackend.Utilities.Providers;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;

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
            services.ConfigureDatabase(Configuration);          
            services.ConfigureSwagger();
            services.ConfigureAuthentication(Configuration);

            #region Repositories            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            #endregion

            #region Services            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

            #region Helpers
            services.AddScoped<IStringProvider, StringProvider>();
            services.AddScoped<ITokenProvider, TokenProvider>();
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

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PracaDyplomowa")
            );
            #endregion

            #region MapperProfiles
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<AuthorProfile>();
                cfg.AddProfile<GenreProfile>();
                cfg.AddProfile<CommentProfile>();
                cfg.AddProfile<RoleProfile>();
            });
            #endregion

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
