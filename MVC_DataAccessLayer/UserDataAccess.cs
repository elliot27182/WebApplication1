﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MVC_DataAccessLayer
{
    public class UserDataAccess
    {
        private string connectionString = "Data Source=DESKTOP-RQ3BRI1\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=000;Connect Timeout=30";

        public void AddUser(UserViewModel user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Users(Username, Email, Password, ImagePath) VALUES (@Username, @Email, @Password, @ImagePath)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));
                    command.Parameters.Add(new SqlParameter("@Email", user.Email));
                    command.Parameters.Add(new SqlParameter("@Password", user.Password));
                    command.Parameters.Add(new SqlParameter("@ImagePath", user.ImagePath ?? DBNull.Value.ToString()));

                    command.ExecuteNonQuery();
                }
            }
        }

        public UserViewModel GetUserByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Username", username));
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        return new UserViewModel
                        {
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Password = reader.GetString(reader.GetOrdinal("Password")),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString(reader.GetOrdinal("ImagePath")),
                        };
                    }

                    return null;
                }
            }
        }
    }
}