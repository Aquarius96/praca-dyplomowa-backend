using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using System;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        void AddFavoriteBook(FavoriteBook favoriteBook);
        void AddWantedBook(WantedBook wantedBook);
        void AddCurrentlyReadBook(CurrentlyReadBook currentlyReadBook);
        void AddReadBook(ReadBook readBook);

        void DeleteFavoriteBook(FavoriteBook favoriteBook);
        void DeleteWantedBook(WantedBook wantedBook);
        void DeleteCurrentlyReadBook(CurrentlyReadBook currentlyReadBook);
        void DeleteReadbook(ReadBook readBook);

        FavoriteBook GetFavoriteBook(string userEmailAddress, int bookId);
        WantedBook GetWantedBook(string userEmailAddress, int bookId);
        CurrentlyReadBook GetCurrentlyReadBook(string userEmailAddress, int bookId);
        ReadBook GetReadBook(string userEmailAddress, int bookId);
        User Get(string emailAddress);
    }
}
