using RelationsApp.Models;
using System.Collections.Generic;

namespace RelationsApp.ViewModels
{
    public class BookVM
    {
        public List<Book> Books { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<BookImg> BookImgs { get; set; }
      
    }
}
