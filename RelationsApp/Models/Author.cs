using System.Collections.Generic;

namespace RelationsApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
