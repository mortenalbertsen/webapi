using System;
using System.Collections.Generic;

namespace BookApp.Models.DomainModels {
    public class User {

        public User() {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
