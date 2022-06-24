using RelationsApp.Models;
using System.Collections.Generic;

namespace RelationsApp.ViewModels
{
    public class HomeMV
    {
        public List<Book> Books { get; set; }
        public List<Genre> Genres { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<User> Users { get; set; }
        public List<SocialAccount> SocialAccounts { get; set; }
        public List<Group> Groups { get; set; }
        public List<Student> Students { get; set; }

    }
}
