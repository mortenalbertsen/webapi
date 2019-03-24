using System;

namespace BookApp.Models.DomainModels {
    public class Book {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
