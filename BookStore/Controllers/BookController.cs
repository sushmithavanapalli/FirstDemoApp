using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        
        public BookController(BookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }
        [Route("Book/GetAllBooks", Name = "ListBooks")]
        public async Task<ViewResult>  GetAllBooks()
        {
            //ViewData["data"] = bookRepository.GetAllBooks();
            var data = await bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult>  GetBook(int id)
        {
            var data = await bookRepository.GetBookById(id);
            return View(data);
        }
        public List <BookModel> SearchBookbyTitle(string title, string author)
        {
            return bookRepository.SearchBook(title, author);
        }
        public ViewResult AddBook(bool Msg)
        {
            if(Msg == true)
            {
                ViewBag.AddBookMsg = "Congratulations!!...Book has been Inserted Successfully";
            }
            else
            {
                ViewBag.AddBookMsg = String.Empty;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                await bookRepository.AddNewBook(bookModel);
                return RedirectToAction("AddBook", "Book", new { Msg = true });
            }

            ModelState.AddModelError("", "This is custom Error");

            return View();
            
        }
    }
}
