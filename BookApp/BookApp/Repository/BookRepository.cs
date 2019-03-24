using System;
using System.Data.Entity;
using System.Linq;
using BookApp.Models.DomainModels;
using BookApp.Models.ExtendedModels;
using Unity;

namespace BookApp.Repository {
    public class BookRepository : BaseRepository<Book>, IBookRepository {
        public BookRepository(IUnityContainer container) : base(container) {
        }
        protected override IDbSet<Book> DbSet => MasterDB.Books;

        public Book GetBookByID(Guid bookId) {
            return GetAll().Where(b => b.Id == bookId).SingleOrDefault();
        }

        public IQueryable<BookExtended> GetBooksByUserId(Guid userId) {
            return GetAll().Where(b => b.UserId == userId).Select(b =>
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

    }
}
