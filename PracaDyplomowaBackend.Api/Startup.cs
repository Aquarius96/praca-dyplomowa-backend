using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.Models.Common.Book;
using PracaDyplomowaBackend.Models.Models.Common.User;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Book;
using PracaDyplomowaBackend.Models.ModelsDto.User;
using PracaDyplomowaBackend.Repo;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Repo.Repositories;
using PracaDyplomowaBackend.Service.Interfaces;
using PracaDyplomowaBackend.Service.Services;
using PracaDyplomowaBackend.Utilities.Extensions;
using System;

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
         
            #region Repositories            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            #endregion

            #region Services            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
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

            #region Mappers
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterModel, User>().AfterMap((src, dest) =>
                {
                    dest.Added = DateTime.UtcNow;
                    dest.Confirmed = false;
                });
                cfg.CreateMap<User, UserDto>();

                cfg.CreateMap<AddAuthorModel, Author>();
                cfg.CreateMap<Author, AuthorDto>();

                cfg.CreateMap<AddBookModel, Book>();
                cfg.CreateMap<Book, BookDto>();
            });
            #endregion

            app.UseMvc();
        }
    }
}
