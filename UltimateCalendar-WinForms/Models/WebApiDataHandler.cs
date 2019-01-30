using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace UltimateCalendar_WinForms
{
    public class WebApiDataHandler : IDataHandler
    {
        List<Event> events = new List<Event>();
        WebClient wc = new WebClient();

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        
        public WebApiDataHandler()
        {
            wc.BaseAddress = "http://localhost:51821/UltimateCalendarDefault/";
        }


        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
            string message = wc.DownloadString($"{wc.BaseAddress}GetUser?email={email}&password={password}");
            loggedInUser = serializer.Deserialize<User>(message);
            return true;
        }

        public List<Event> GetEvents(DateTime dateForEvents, User loggedInUser)
        {
            string message = wc.DownloadString($"{wc.BaseAddress}GetEventsForUser?date={dateForEvents}&userId={loggedInUser.UserID}");
            events.Clear();
            events = serializer.Deserialize<List<Event>>(message);
            return events;
        }

        public string RegisterUser(User user)
        {

            wc.Headers.Add("Content-Type", "application/json");
            wc.Headers.Add("Data-Type", "application/json");
            string userJson = serializer.Serialize(user);
            try
            {
                return wc.UploadString(wc.BaseAddress + "RegisterUser", "Post", userJson);
            }
            catch (Exception ex)
            {
                return "Couldn't register user. " + ex.Message;
            }
        }

        public string AddEvent(Event eventToPost)
        {

            wc.Headers.Add("Content-Type", "application/json");
            wc.Headers.Add("Data-Type", "application/json");
            string eventJson = serializer.Serialize(eventToPost);
            try
            {
                return wc.UploadString(wc.BaseAddress + "PostEvent", "Post", eventJson);
            }
            catch (Exception ex)
            {
                return "Couldn't add the event. " + ex.Message;
            }
        }
    }
}
