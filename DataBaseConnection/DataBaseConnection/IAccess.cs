using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    internal interface IAccess
    {
        long AddBook(string title, string authorName, string authorLastName,
            string authorMiddleName, string country);

        void AddExtraWriter(long bookId, string authorName, string authorLastName,
            string authorMiddleName, string country);

        void ModifyBookCopy(long copyId, string title = null, string authorName = null,
            string authorLastName = null, string authorMiddleName = null, string country = null);

        int DeleteBook(long copyId);

        IEnumerable<Book> GetData();

        void Dispose();
    }
}
