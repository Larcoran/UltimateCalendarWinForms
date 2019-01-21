﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UltimateCalendarWinForms.Models;
using UltimateCalendarWinForms.ViewModels;

namespace UltimateCalendarWinForms.Models
{
    class GetNextEventFromDB
    {
        DataBaseConnection DBConnection = new DataBaseConnection();
        MySqlCommand command = new MySqlCommand();
        MySqlConnection connection = new MySqlConnection();
        MySqlDataReader reader = null;
        EventBuilder builder = null;
        User loggedInUser;
        public bool endOfData = false;

        public GetNextEventFromDB(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
            builder = new EventBuilder();
            connection = DBConnection.GetMySqlConnection();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM events WHERE date = @date AND userId = @userId ;";
        }

        public void SetSQLCommand(DateTime date)
        {
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@userId", loggedInUser.UserID);
            connection.OpenAsync();
            reader = command.ExecuteReader();
        }

        public async Task<Event> GetEvent(DateTime date)
        {
            Event eventToReturn = null;
            await Task.Run(() =>
            {
                if (reader.ReadAsync().Result)
                {
                    eventToReturn = builder.BuildEvent(reader);
                }
                else
                {
                    endOfData = true;
                }
            });
            return eventToReturn;
        }

        public void DisposeConnection()
        {
            reader.Dispose();
            connection.Dispose();
        }


    }
}
