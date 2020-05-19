using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
   public interface ILibraryItem
    {
       
        void Add(LibraryItem newItem);
        string GetAOD(int id);
        string GetDeweyNr(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetISBN(int id);
        string GetGenre(int id);
        string GetDuration(int id);
        string GetDescription(int id);
        IEnumerable<LibraryItem> GetAll();
        LibraryItem GetById(int id);
        Task<IEnumerable<LibraryItem>> SearchItemsAsync(string searchTerm);
       
    }
}
