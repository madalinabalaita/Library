using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        {
            //Discriminator
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(book => book.Id == id).DeweyNr;
            }
            else return "";
        }

        public string GetISBN(int id)
        {
            if (_context.Books.Any(b => b.Id == id))
            {
                return _context.Books.FirstOrDefault(b => b.Id == id).ISBN;
            }
            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.LibraryItems
                .FirstOrDefault(ILibraryItem => ILibraryItem.Id == id).Title;
        }

        public string GetType(int id)
        {
            var book = _context.LibraryItems.OfType<Book>()
                .Where(book => book.Id == id);
            return book.Any() ? "Book" : "Movie";
        }
        public string GetAOD(int id)
        {
            var isBook = _context.LibraryItems.OfType<Book>()
                   .Where(item => item.Id == id).Any();
            var isMovie = _context.LibraryItems.OfType<Movie>()
                  .Where(item => item.Id == id).Any();
            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Movies.FirstOrDefault(movie => movie.Id == id).Director;
                
        }

    }
}
