using System;
using System.Linq;
using BookApp.Models.DomainModels;
using BookApp.Models.ExtendedModels;

namespace BookApp.Repository {
    public interface IBookRepository : IBaseRepository<Book, long> {
        IQueryable<BookExtended> GetBooksByUserId(Guid userId);
        Book GetBookByID(Guid bookId);

    }
}
