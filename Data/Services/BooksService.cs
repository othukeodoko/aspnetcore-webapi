using SimpleProject.Data.Models;
using SimpleProject.Data.ViewModels;

namespace SimpleProject.Data.Services
{
    public class BooksService
    {
        private AppDBContext _context;
        public BooksService(AppDBContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book) 
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author  = book.Author,
                CoverUrl = book.IsRead ? book.CoverUrl : null,  
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List <Book> GetAllBooks()
        {
            var allbooks = _context.Books.ToList();
            return allbooks;
        }
        public Book GetBookById(int BookId)
        {
            var book = _context.Books.FirstOrDefault( n => n.Id == BookId );
            return book;
        }
    }
}
