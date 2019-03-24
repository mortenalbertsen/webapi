﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookApp.Models.DomainModels;
using BookApp.Models.ExtendedModels;
using Unity;

namespace BookApp.Repository {
    public class UserRepository : BaseRepository<User>, IUserRepository {
        public UserRepository(IUnityContainer container) : base(container) {
        }

        protected override IDbSet<User> DbSet => MasterDB.Users;

        public IEnumerable<BookExtended> GetMoreUserBooks(Guid userId, Guid bookId) {
            var user = GetAll().FirstOrDefault(u => u.Id == userId);
            return user.Books.Where(b => b.Id != bookId).Select(b =>
            new BookExtended() {
                Author = b.Author,
                Content = b.Content,
                CreatedDatetime = b.CreatedDatetime,
                Id = b.Id,
                Title = b.Title,
                UserId = b.UserId,
                UserName = b.User.FirstName + " " + b.User.LastName
            }
                );
        }

        public User GetUserById(Guid userId) {
            return GetAll().FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByName(string name) {
            return GetAll().FirstOrDefault(u => u.LastName == name);
        }
    }
}
