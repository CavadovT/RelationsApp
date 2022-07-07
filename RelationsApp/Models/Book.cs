using System.Collections.Generic;

namespace RelationsApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public List<BookGenre> BookGenres { get; set; }
        public List<BookImg> BookImgs { get; set; }

    }
}
