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
            Console.Write("Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Writer Name: ");
            string name = Console.ReadLine();

            Console.Write("Writer LastName: ");
            string lastName = Console.ReadLine();

            Console.Write("Writer MiddleName: ");
            string middleName = Console.ReadLine();

            Console.Write("Country: ");
            string country = Console.ReadLine();

            long bookId = AddBook(title, name, lastName, middleName, country);

            Console.WriteLine("Added successfully! BookId = {0}", bookId);
            Console.ReadKey();
        }

        static long AddBook(string title, string authorName, string authorLastName, string authorMiddleName, string country)
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "192.168.1.220, 1433",
                InitialCatalog = "PublicLibrary",
                UserID = "User1",
                Password = "User1",
                Pooling = true
            };

            string sqlExpression = "AddBook";
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                var titleParameter = new SqlParameter()
                {
                    ParameterName = "@title",
                    Value = title
                };

                var nameParameter = new SqlParameter()
                {
                    ParameterName = "@authorName",
                    Value = authorName
                };

                var lastNameParameter = new SqlParameter()
                {
                    ParameterName = "@authorLastName",
                    Value = authorLastName
                };

                var middleNameParameter = new SqlParameter()
                {
                    ParameterName = "@authorMiddleName",
                    Value = authorMiddleName
                };

                var countryParameter = new SqlParameter()
                {
                    ParameterName = "@country",
                    Value = country
                };

                var idParameter = new SqlParameter()
                {
                    ParameterName = "@BookId",
                    SqlDbType = SqlDbType.BigInt,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(titleParameter);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(lastNameParameter);
                command.Parameters.Add(middleNameParameter);
                command.Parameters.Add(countryParameter);
                command.Parameters.Add(idParameter);
                command.ExecuteNonQuery();

                return (long)idParameter.Value;
            }
        }
    }
}
