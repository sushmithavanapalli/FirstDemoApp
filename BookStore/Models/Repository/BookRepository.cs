using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public class BookRepository
    {
        public List <BookModel > GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int Id)
        {
            return DataSource().Where(x => x.Id == Id).FirstOrDefault();
        }
        public List <BookModel > SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title == title && x.Author == author).ToList();
        }

        private List <BookModel > DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel () {Id = 1, Title = "Dot Net", Author = "Sushmitha"},
                new BookModel () {Id = 2, Title = "Dot Net MVC", Author = "Sushmitha"},
                new BookModel () {Id = 3, Title = "Java", Author = "Sushmitha"},
                new BookModel () {Id = 4, Title = "SQL", Author = "Sushmitha"},
                new BookModel () {Id = 5, Title = "Docker", Author = "Sushmitha"},
            };
        }

    }
}
