using Microsoft.AspNetCore.Http;
using RelationsApp.Models;
using System.Collections.Generic;

namespace RelationsApp.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public List<IFormFile> Photos { get; set; }

        public List<Book> Books { get; set; }
        public Book Book { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<BookImg> BookImgs { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
       
        public List<int> GenreIds { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> ImgIds { get; set; }

    }
}
