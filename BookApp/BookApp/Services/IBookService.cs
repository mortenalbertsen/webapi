using System;
using System.Collections.Generic;
using BookApp.Models.DomainModels;
using BookApp.Models.ExtendedModels;

namespace BookApp.Services {
    public interface IBookService {
        Book GetBookById(Guid bookId);
        IEnumerable<BookExtended> GetBooksByUserId(Guid userId);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(Book book);
    }
}
