using System;
using System.Collections.Generic;
using System.Net;
using UltimateCalendar_WinForms.Models;

namespace UltimateCalendar_WinForms
{
    public class InMemoryDataHandler : IDataHandler
    {
        List<Event> events = new List<Event>();

        public InMemoryDataHandler()
        {
            //WebClient wc = new WebClient();
            //string message = wc.DownloadString("http://localhost:51821/api/values");

            //wc.UploadString()
            //MessageBox.Show(message);
            
        }

        public void AddEvent(Event @event)
        {
            events.Add(@event);
        }

        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
                WebClient wc = new WebClient();
                string message = wc.DownloadString("http://localhost:51821/UltimateCalendarDefault/GetUser?email=larcoran18@gmail.com&password=Roflmao2204");
                JsonToUserConverter converter = new JsonToUserConverter();
                loggedInUser = converter.Convert(message);
                return true;
        }

        public List<Event> GetEvents(DateTime dateForEvents, User userForEvents)
        {
            return events;
        }

        public string RegisterUser(User user)
        {
            return "test";
        }
    }
}
