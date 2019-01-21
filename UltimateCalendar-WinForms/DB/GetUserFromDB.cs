using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateCalendarWinForms.Models
{
    class GetUserFromDB : DBQuery
    {
        private User user;
        private PasswordEncrypter encrypter;

        public GetUserFromDB()
        {
            user = new User();
            encrypter = new PasswordEncrypter();
        }

        public User GetUser(string password, string email)
        {
            user.Password = encrypter.encryptPassword(password);
            user.Email = email;
            Execute();
            return user;
        }

        public override void ExecuteCommand()
        {
            PasswordEncrypter encrypter = new PasswordEncrypter();
            command.CommandText = "SELECT * FROM users WHERE Email = @Email AND Password = @Password LIMIT 1;";
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.UserID = (int)reader["ID"];
                    user.Name = (string)reader["FirstName"];
                    user.Surname = (string)reader["LastName"];
                    user.DateOfBirth = (DateTime)reader["DateOfBirth"];
                }
            }
        }
    }
}
