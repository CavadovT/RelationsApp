using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationsApp.DAL;
using RelationsApp.Models;
using RelationsApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RelationsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Book> books = _context.Books
                .Include(b => b.BookGenres)
                .ThenInclude(g=>g.Genre)
                .ToList();
            List<Student>students=_context.Students
                .Include(g=>g.Group)
                .ToList();
            List<SocialAccount> socialAccounts = _context.SocialAccounts
                .Include(sa=>sa.User)
                .Where(u=>u.Id==u.User.Id)
                .ToList();


            HomeMV homeVM=new HomeMV();
            homeVM.Students = students;
            homeVM.Books = books;
            homeVM.SocialAccounts = socialAccounts;
            return View(homeVM);
        }
    }
}
