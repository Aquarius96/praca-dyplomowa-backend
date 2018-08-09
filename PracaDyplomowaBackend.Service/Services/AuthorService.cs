using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Models.Models.Common.Author;
using PracaDyplomowaBackend.Models.ModelsDto.Author;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowaBackend.Service.Services
{
    public class AuthorService : ServiceBase<Author,AddAuthorModel, AuthorDto, int>, IAuthorService
    {
        public AuthorService(IAuthorRepository repository) : base(repository)
        {
        }        
    }
}
