using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateCalendarWinForms.Models
{
    class AddNewEventToDB : DBQuery
    {
        Event @event;
        public bool done = false;

        public void Add(Event @event)
        {
            this.@event = @event;
            Execute();
        }

        public override void ExecuteCommand()
        {
            command.CommandText = "INSERT INTO events (description, userId, date, time, type) VALUES (@description, @userId, @date, @time, @type)";
            command.Parameters.AddWithValue("@description", @event.Description);
            command.Parameters.AddWithValue("@userId", @event.UserId);
            command.Parameters.AddWithValue("@date", @event.Date);
            command.Parameters.AddWithValue("@time", @event.Time);
            command.Parameters.AddWithValue("@type", @event.Type.ToString());
            command.ExecuteNonQuery();
            done = true;
        }
    }
}
