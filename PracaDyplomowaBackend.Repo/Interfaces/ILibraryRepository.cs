using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Interfaces
{
    public interface ILibraryRepository : IRepositoryBase<User, Guid>
    {
        void AddFavoriteBook(FavoriteBook favoriteBook);
        void AddWantedBook(WantedBook wantedBook);
        void AddCurrentlyReadBook(CurrentlyReadBook currentlyReadBook);
        void AddReadBook(ReadBook readBook);
        void AddFavoriteAuthor(FavoriteAuthor favoriteAuthor);

        void DeleteFavoriteBook(FavoriteBook favoriteBook);
        void DeleteWantedBook(WantedBook wantedBook);
        void DeleteCurrentlyReadBook(CurrentlyReadBook currentlyReadBook);
        void DeleteReadbook(ReadBook readBook);
        void DeleteFavoriteAuthor(FavoriteAuthor favoriteAuthor);

        FavoriteBook GetFavoriteBook(string userEmailAddress, int bookId);
        WantedBook GetWantedBook(string userEmailAddress, int bookId);
        CurrentlyReadBook GetCurrentlyReadBook(string userEmailAddress, int bookId);
        ReadBook GetReadBook(string userEmailAddress, int bookId);
        FavoriteAuthor GetFavoriteAuthor(string userEmailAddress, int authorId);

        IEnumerable<LibraryBookDto> GetUserCurrentlyReadBooks(string userEmailAddress);
        IEnumerable<LibraryBookDto> GetUserFavoriteBooks(string userEmailAddress);
        IEnumerable<ReadBookDto> GetUserReadBooks(string userEmailAddress);
        IEnumerable<LibraryBookDto> GetUserWantedBooks(string userEmailAddress);
        IEnumerable<BookAuthorDto> GetUserFavoriteAuthors(string userEmailAddress);
        IEnumerable<BookRateDto> GetUserBookRates(string userEmailAddress);
        IEnumerable<AuthorRateDto> GetUserAuthorRates(string userEmailAddress);
        IEnumerable<ReviewRateDto> GetUserReviewRates(string userEmailAddress);
    }
}
