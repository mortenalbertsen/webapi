using System;
using System.Collections.Generic;
using BookApp.Models.DomainModels;
using BookApp.Models.ExtendedModels;

namespace BookApp.Repository {
    public interface IUserRepository : IBaseRepository<User, long> {
        User GetUserById(Guid userId);
        User GetUserByName(string name);
        IEnumerable<BookExtended> GetMoreUserBooks(Guid userId, Guid bookId);
    }
}
