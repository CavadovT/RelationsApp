using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationsApp.DAL;
using RelationsApp.Models;
using RelationsApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationsApp.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BookController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            BookVM bookVM = new BookVM();
            bookVM.Books = await _context.Books.ToListAsync();
            bookVM.BookGenres = await _context.BookGenres.Include(bg=>bg.Genre).ToListAsync();
            bookVM.BookImgs = await _context.bookImgs.ToListAsync();
        
            return View(bookVM);
        }
        public IActionResult Create() 
        {
            return View();
        }
        public IActionResult Detail() 
        {
            return View();
        }
        public IActionResult Delete() 
        {
            return View();
        }
        public IActionResult Update()
        {
            return RedirectToAction("index");
        }
    }
}
