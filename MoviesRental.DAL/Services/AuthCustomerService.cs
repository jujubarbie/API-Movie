using ADOLibrary;
using MoviesRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public class AuthCustomerService
    {
        private readonly Connection _connection;

        public AuthCustomerService(Connection connection)
        {
            _connection = connection;
        }

        public void Register(Customer customer)
        {
            Command cmd = new Command("MVSP_RegisterCustomer", true);
            cmd.AddParameter("LastName", customer.LastName);
            cmd.AddParameter("FirstName", customer.FirstName);
            cmd.AddParameter("Email", customer.Email);
            cmd.AddParameter("Passwd", customer.Passwd);

            _connection.ExecuteNonQuery(cmd);
            customer.Passwd = null; // clean password
        }
        public Customer Login(Customer customer)
        {
            Command cmd = new Command("MVSP_CheckCustomer", true);
            cmd.AddParameter("Email", customer.Email);
            cmd.AddParameter("Passwd", customer.Passwd);

            return _connection.ExecuteReader(cmd, converter).SingleOrDefault();
        }

        /* Converter */

        private Customer converter(IDataReader reader) {
            return new Customer()
            {
                // je devrais fonctionner avec
                // FirstName = (reader["FirstName"] is DBNull ? null : (string)reader["FirstName"]) 
                // Id = (reader["CustomerId"] is DBNull ? null : (int)reader["CustomerId"]), // bug

                Id = (int)reader["CustomerId"],
                LastName = (string)reader["LastName"],
                FirstName = (string)reader["FirstName"],
                Email = (string)reader["Email"]

            };
        }
    }
}
