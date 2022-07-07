using Microsoft.EntityFrameworkCore;
using RelationsApp.Models;

namespace RelationsApp.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }
        public DbSet<BookImg> bookImgs { get; set; }
    }
}
