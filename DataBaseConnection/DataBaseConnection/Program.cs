using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connStr = new SqlConnectionStringBuilder
            {
                DataSource = "192.168.1.220, 1433",
                InitialCatalog = "PublicLibrary",
                UserID = "User1",
                Password = "User1",
                Pooling = true
            };

            //Console.Write("Book Title: ");
            //string title = Console.ReadLine();

            //Console.Write("Writer Name: ");
            //string name = Console.ReadLine();

            //Console.Write("Writer LastName: ");
            //string lastName = Console.ReadLine();

            //Console.Write("Writer MiddleName: ");
            //string middleName = Console.ReadLine();

            //Console.Write("Country: ");
            //string country = Console.ReadLine();


            //using (var db = new DataBaseAccessor(connStr.ConnectionString))
            //{
            //long bookId = db.AddBook(title, name, lastName, middleName, country);

            //db.AddExtraWriter(44, "David", "Copperfield", null, "Ukraine");

            //db.ModifyBookCopy(1, "New Name");

            //int rowsAffected = db.DeleteBook(79);
            //Console.WriteLine(rowsAffected);

            //Console.WriteLine("The book was added successfully!\nBookId = {0}", bookId);
            //}

            IAccess db = new DataBaseAccessor(connStr.ConnectionString);

            try
            {
                //long bookId = db.AddBook(title, name, lastName, middleName, country);

                //db.AddExtraWriter(44, "David", "Copperfield", null, "Ukraine");

                //db.ModifyBookCopy(1, "New Name");

                //int rowsAffected = db.DeleteBook(78);
                //Console.WriteLine(rowsAffected);

                //Console.WriteLine("The book was added successfully!\nBookId = {0}", bookId);


                foreach (var book in db.GetData())
                {
                    Console.WriteLine(book);
                }
            }
            finally
            {
                db.Dispose();
            }



            Console.ReadKey();
        }
    }
}
