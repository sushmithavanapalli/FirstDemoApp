using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository bookRepository = null;
        public BookController()
        {
            bookRepository = new BookRepository();
        }
        public ViewResult  GetAllBooks()
        {
            // bookRepository.GetAllBooks();
            return View();
        }
        public BookModel  GetBook(int id)
        {
            return bookRepository.GetBookById(id);
        }
        public List <BookModel> SearchBookbyTitle(string title, string author)
        {
            return bookRepository.SearchBook(title, author);
        }
    }
}
