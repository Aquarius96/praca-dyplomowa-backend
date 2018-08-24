using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        public AuthorRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }
    }
}
