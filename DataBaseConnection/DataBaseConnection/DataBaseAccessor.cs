using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    internal class DataBaseAccessor : IDisposable, IAccess
    {
        private readonly SqlConnection _connection;
        private bool _disposed = false;

        public DataBaseAccessor(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        ~DataBaseAccessor()
        {
            if (!_disposed)
            {
                _connection?.Dispose();
            }    
        }

        public long AddBook(string title, string authorName, string authorLastName,
                string authorMiddleName, string country)
        {
            string sqlExpression = "AddBook";

            var command = new SqlCommand(sqlExpression, _connection);
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
            command.ExecuteNonQuery();    // TODO: For what?

            return (long)idParameter.Value;
        }

        public void AddExtraWriter(long bookId, string authorName, string authorLastName, 
                string authorMiddleName, string country)
        {
            string sqlExpression = "AddExtraWriter";

            var command = new SqlCommand(sqlExpression, _connection);
            command.CommandType = CommandType.StoredProcedure;

            var bookIdParameter = new SqlParameter()
            {
                ParameterName = "@bookId",
                Value = bookId
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

            command.Parameters.Add(bookIdParameter);
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(lastNameParameter);
            command.Parameters.Add(middleNameParameter);
            command.Parameters.Add(countryParameter);
            command.ExecuteNonQuery();
        }

        public void ModifyBookCopy(long copyId, string title=null, string authorName=null,
                string authorLastName=null, string authorMiddleName=null, string country=null)
        {
            string sqlExpression = "ModifyBookCopy";

            var command = new SqlCommand(sqlExpression, _connection);
            command.CommandType = CommandType.StoredProcedure;

            var copyIdParameter = new SqlParameter()
            {
                ParameterName = "@copyId",
                Value = copyId
            };

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

            command.Parameters.Add(copyIdParameter);
            command.Parameters.Add(titleParameter);
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(lastNameParameter);
            command.Parameters.Add(middleNameParameter);
            command.Parameters.Add(countryParameter);
            command.ExecuteNonQuery();
        }

        public int DeleteBook(long copyId)
        {
            string sqlExpression = "DeleteBook";

            var command = new SqlCommand(sqlExpression, _connection);
            command.CommandType = CommandType.StoredProcedure;

            var copyIdParameter = new SqlParameter()
            {
                ParameterName = "@copyId",
                Value = copyId
            };

            command.Parameters.Add(copyIdParameter);

            return command.ExecuteNonQuery();
        }

        public IEnumerable<Book> GetData()
        {
            string sqlExpression = @"SELECT B.BookId, Title, FirstName, LastName, MiddleName
                                     FROM Books B
                                     LEFT JOIN BooksWriters BW ON B.BookId = BW.BookId
                                     LEFT JOIN Writers W ON BW.AuthorId = W.WriterId";

            var command = new SqlCommand(sqlExpression, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                long bookId = (long) reader["BookId"];
                string title = (string)reader["Title"];
                string name = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];

                string middleName = string.Empty;
                if (reader["MiddleName"] != DBNull.Value)
                {
                    middleName = (string)reader["MiddleName"];
                }

                Book copy = new Book(bookId, title, name, lastName, middleName);

                yield return copy;
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();

            _disposed = true;
        }
    }
}
