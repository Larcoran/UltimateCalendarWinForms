using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCalendarWinForms.Models;
using UltimateCalendarWinForms.ViewModels;

namespace UltimateCalendarWinForms.Models
{
    public class SQLDataHandler : IDataHandler
    {

        public void AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
            GetUserFromDB getUser = new GetUserFromDB();
            loggedInUser = getUser.GetUser(password, email);
            if(email!=loggedInUser.Email)
            {
                return false;
            }
            if(password!=loggedInUser.Password)
            {
                return false;
            }
            return true;
        }

        public List<Event> GetEvents(DateTime dateForEvents, User userForEvents)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
