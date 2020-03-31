﻿using Activity3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity3.Services.Business.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog
            = Test; Integrated Security = True; Connect Timeout = 30;
        Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover = False";

        public bool FindByUser(UserModel user)
        {
            // start by assuming nothing found in this query
            bool success = false;

            // provide the query string with a parameter placeholder.
            string queryString = "Select * from dbo.users where username = @username and password = @password";

            // create and open the connection in a using block. This ensures that all resources will be closed and disposed when the code exits.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                //Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    
                        success = true;
                        reader.Close();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return success;

        }
    }
}