using ADOLibrary;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public class CategoryService : BaseService<int, Category>
    {
        public CategoryService(Connection connection) : base(connection)
        {
        }

        public override IEnumerable<Category> GetAll()
        {
            Command cmd = new Command("GetAllCategory", true);
            return Connection.ExecuteReader<Category>(cmd, Converter);
        }

        private Category Converter(SqlDataReader reader)
        {
            return new Category(
                (int)reader["CategoryId"],
                reader["Name"].ToString()
            );
        }
    }
}
