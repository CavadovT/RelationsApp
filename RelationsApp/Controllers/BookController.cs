using FrontToBack.Extentions;
using FrontToBack.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelationsApp.DAL;
using RelationsApp.Models;
using RelationsApp.ViewModels;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Index action method for Home Page book
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            BookVM bookVM = new BookVM();
            bookVM.Books = await _context.Books.ToListAsync();
            bookVM.BookAuthors = await _context.BookAuthors.Include(ba=>ba.Author).ToListAsync();
            bookVM.BookGenres = await _context.BookGenres.Include(bg=>bg.Genre).ToListAsync();
            bookVM.BookImgs = await _context.BookImgs.ToListAsync();

           
        
            return View(bookVM);
        }

        /// <summary>
        /// Create book get method
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create() 
        {
            BookVM bookVM=new BookVM();
            bookVM.Books = await _context.Books.ToListAsync();

            ViewBag.Authors = new SelectList(await _context.Authors.ToListAsync(),"Id","FullName");
            ViewBag.Genres =new SelectList (await _context.Genres.ToListAsync(),"Id","Name");

            return View();
        }
        /// <summary>
        /// Create book Post Method
        /// </summary>
        /// <param name="bookVM"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookVM bookVM) 
        {
            ViewBag.Authors = new SelectList(await _context.Authors.ToListAsync(), "Id", "FullName");
            ViewBag.Genres = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name");

            List<BookImg>images=new List<BookImg>();

            foreach (var img in bookVM.Photos)
            {
                if (img == null)
                {
                    ModelState.AddModelError("Photo", "don't leave it blank!!!");
                    return View();
                }
                if (!img.IsImage())
                {
                    ModelState.AddModelError("Photo", "Choose the photo");
                    return View();
                }
                if (img.ValidSize(200))
                {
                    ModelState.AddModelError("Photo", "oversize");
                    return View();
                }
                BookImg image=new BookImg();
                image.Img = img.SaveImage(_env, "img");
                images.Add(image);
            }

            if (!ModelState.IsValid) return View();

            Book book = new Book()
            {
                Name = bookVM.Name,
                Price = bookVM.Price,
                Title=bookVM.Title,
                BookImgs=images,

            };

            List<BookAuthor>bookAuthors=new List<BookAuthor>();
            foreach (var authorId in bookVM.AuthorIds)
            {
                BookAuthor bookAuthor = new BookAuthor();
                bookAuthor.AuthorId = authorId;
                bookAuthor.BookId = bookVM.Id;
                bookAuthors.Add(bookAuthor);
            }
            book.BookAuthors=bookAuthors;

            List<BookGenre>bookGenres  = new List<BookGenre>();
            foreach (var genreId in bookVM.GenreIds)
            {
                BookGenre bookGenre = new BookGenre();
                bookGenre.GenreId= genreId;
                bookGenre.BookId = bookVM.Id;
                bookGenres.Add(bookGenre);
            }
            book.BookGenres = bookGenres;

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        /// <summary>
        /// Detail Method for Book
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int? Id) 
        {
            BookVM bookVM = new BookVM();
            bookVM.Book =await _context.Books.FindAsync(Id);
            bookVM.BookGenres=_context.BookGenres.Include(bg=>bg.Genre).Where(x => x.BookId == Id).ToList();
            bookVM.BookAuthors = _context.BookAuthors.Include(ba=>ba.Author).Where(x => x.BookId == Id).ToList();
            bookVM.BookImgs=_context.BookImgs.Where(x => x.BookId == Id).ToList();
            return View(bookVM);
        }

        /// <summary>
        /// Delete Method for Book
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? Id) 
        {
            if (Id == null) return NotFound();
            Book dbBook = await _context.Books.FirstOrDefaultAsync(b=>b.Id==Id);
            if (dbBook == null) return NotFound();

            foreach (var img in await _context.BookImgs.Where(i=>i.BookId==Id).ToListAsync())
            {
                string path = Path.Combine(_env.WebRootPath, "img", img.ToString());

                Helper.DeleteImage(path);
            }
            foreach (var author in await _context.BookAuthors.Where(a=>a.BookId==Id).ToListAsync())
            {
                _context.BookAuthors.Remove(author);
            }
            foreach (var genre in await _context.BookGenres.Where(g=>g.BookId==Id).ToListAsync())
            {
                _context.BookGenres.Remove(genre);
            }
            

            _context.Books.Remove(dbBook);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        /// <summary>
        /// Update Method for Book
        /// </summary>
        /// <returns></returns>
        public IActionResult Update()
        {
            return RedirectToAction("index");
        }
    }
}
