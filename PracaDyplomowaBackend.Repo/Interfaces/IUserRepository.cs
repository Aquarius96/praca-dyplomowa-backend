using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using System;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        void AddFavoriteBook(FavoriteBook favoriteBook);

        void DeleteFavoriteBook(FavoriteBook favoriteBook);

        FavoriteBook GetFavoriteBook(string userEmailAddress, int bookId);
        User Get(string emailAddress);
    }
}
