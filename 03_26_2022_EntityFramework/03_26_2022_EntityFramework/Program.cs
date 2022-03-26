using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Net.Sockets;

namespace _03_26_2022_EntityFramework
{
    internal class Program
    {
        static void Main()
        {
            using (var db = new DataContext(ConnectDb.GetString()))
            {
                db.Log = Console.Out;

                //var allBooks = db.ExecuteQuery<BookInfo>(@"SELECT B.BookId, BadBook, WriterId, FirstName, LastName, Country 
                //                                                        FROM Books B 
                //                                                        LEFT JOIN BooksWriters BW ON B.BookId = BW.BookId 
                //                                                        LEFT JOIN Writer W ON BW.AuthorId = W.WriterId");

                //var ukBooks = from book in allBooks
                //                                where book.Country == "U.K."
                //                              select book;

                var books = db.GetTable<Book>();
                var booksWriters = db.GetTable<BooksWriters>();
                var writers = db.GetTable<Writer>();

                // Work with tables as collections
                var ukBooks = from book in books
                                                        join bookWriter in booksWriters 
                                                            on book.BookId equals bookWriter.BookId
                                                        join writer in writers 
                                                            on bookWriter.AuthorId equals writer.WriterId
                                                        where writer.Country == "U.K."
                                                     select new {book.Title, writer.FirstName, writer.LastName, writer.Country};

                // View
                var badBooks = db.ExecuteQuery<BadBook>("SELECT CopyId, Title FROM BadCondition");

                // Stored Procedure
                var annualBooks = db.ExecuteQuery<BookAnnualReport>("EXECUTE AnnualReport @Year = 2021");

                var anyBooks = from bookAnnualReport in annualBooks
                                                        where bookAnnualReport.September > 1
                                                     select bookAnnualReport;

                foreach (var book in anyBooks)
                {
                    Console.WriteLine($"{book}");
                }
            }

            Console.ReadKey();
        }
    }
}
