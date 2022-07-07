namespace RelationsApp.Models
{
    public class BookImg
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
