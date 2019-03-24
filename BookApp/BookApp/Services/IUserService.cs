using System;
using BookApp.Models.DomainModels;

namespace BookApp.Services {
    public interface IUserService {
        User GetUserById(Guid userId);
        User GetUserByName(string name);
        User AddUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
