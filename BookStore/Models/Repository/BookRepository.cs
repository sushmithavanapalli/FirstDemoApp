using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext bookStoreContext)
        {
            _context = bookStoreContext;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                Category = model.Category,
                Description = model.Description,
                Language = model.Language,
                Title = model.Title,
                 TotalPages = model.TotalPages
            };
            await _context.Book.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var booksList = new List<BookModel>();
            var allbooks = await _context.Book.ToListAsync();
            if (allbooks.Count > 0)
            {
                foreach (var bookk in allbooks)
                {
                    booksList.Add(new BookModel()
                    {
                        Id = bookk.Id,
                        Author = bookk.Author,
                        Category = bookk.Category,
                        Description = bookk.Description,
                        Language = bookk.Language,
                        Title = bookk.Title,
                        TotalPages = bookk.TotalPages
                    });
                }
            }
            return booksList;
        }
        public async Task<Book> GetBookById(int Id)
        {
            var allbooks = await _context.Book.ToListAsync();
            return allbooks.Where(x => x.Id == Id).FirstOrDefault(); //DataSource().Where(x => x.Id == Id).FirstOrDefault();
        }
        public List <BookModel > SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title == title && x.Author == author).ToList();
        }

        private List <BookModel > DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel () {Id = 1, Title = "Dot Net", Author = "Sushmitha", Description = "This is description of Dot Net", Category="Action", TotalPages=1067, Language = "English"},
                new BookModel () {Id = 2, Title = "Dot Net MVC", Author = "Sushmitha", Description = "This is description of Dot Net MVC", Category="Drama", TotalPages=1077, Language = "German"},
                new BookModel () {Id = 3, Title = "Java", Author = "Sushmitha", Description = "This is description of Java", Category="Programming", TotalPages=1507, Language = "English"},
                new BookModel () {Id = 4, Title = "SQL", Author = "Sushmitha", Description = "This is description of SQL", Category="Sql Programming", TotalPages=1700, Language = "English"},
                new BookModel () {Id = 5, Title = "Docker", Author = "Sushmitha", Description = "This is description of Docker", Category="Docker Cat", TotalPages=2067, Language = "English"},
            };
        }

    }
}
