using LibraryData;
using LibraryData.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class LibraryItemService : ILibraryItem
    {
        private LibraryDbContext _context;
        public LibraryItemService(LibraryDbContext context)
        {
            _context = context;
        }
        public void Add(LibraryItem newItem)
        {
            _context.Add(newItem);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryItem> GetAll()
        {//when we pull back LibraryItems include the status of the item and its location
            return _context.LibraryItems
                .Include(item => item.Status);
                
        }

        
        public LibraryItem GetById(int id)
        {
            return _context.LibraryItems
                .Include(item => item.Status)
                .FirstOrDefault(item => item.Id == id);
        }
      



        public string GetDeweyNr(int id)
        {   //just for books
            //Discriminator
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(book => book.Id == id).DeweyNr;
            }
            else return "";
        }

        public string GetISBN(int id)
        {   //just for books
            if (_context.Books.Any(b => b.Id == id))
            {
                return _context.Books.FirstOrDefault(b => b.Id == id).ISBN;
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryItems.FirstOrDefault(ILibraryItem => ILibraryItem.Id == id).Title;
        }

        public string GetType(int id)
        {   //type= book or movie
            var book = _context.LibraryItems.OfType<Book>().Where(book => book.Id == id);
            return book.Any() ? "Book" : "Movie";
        }
        public string GetAOD(int id)
        {   //get author or director
            var isBook = _context.LibraryItems.OfType<Book>().Where(item => item.Id == id).Any();
            var isMovie = _context.LibraryItems.OfType<Movie>().Where(item => item.Id == id).Any();
            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Movies.FirstOrDefault(movie => movie.Id == id).Director;
                
        }

        public string GetGenre(int id)
        {
            return _context.LibraryItems
          .FirstOrDefault(item => item.Id == id).Genre;
        }
        public string GetDuration(int id)
        {
            return _context.LibraryItems
          .FirstOrDefault(item => item.Id == id).Duration;
        }

        public string GetDescription(int id)
        {
            return _context.LibraryItems
         .FirstOrDefault(item => item.Id == id).Description;
        }

        [Obsolete]
        public Task<IEnumerable<LibraryItem>> SearchItemsAsync(string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return Task.FromResult(Enumerable.Empty<LibraryItem>());
            }

            var results = _context.Query<LibraryItem>()
                .Where(c => c.Title.Contains(searchTerm))
                .ToArray() as IEnumerable<LibraryItem>;

            return Task.FromResult(results);
        }

      
    }
}
