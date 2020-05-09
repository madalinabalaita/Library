using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
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
        IEnumerable<LibraryItem> GetAll();
        LibraryItem GetById(int id);

    }
}
