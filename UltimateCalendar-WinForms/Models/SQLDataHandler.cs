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
        PasswordEncrypter encrypter = new PasswordEncrypter();
        PasswordDecrypter decrypter = new PasswordDecrypter();

        public void AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
            GetUserFromDB getUser = new GetUserFromDB();
            loggedInUser = getUser.GetUser(encrypter.encryptPassword(password), email);
            if(email!=loggedInUser.Email)
            {
                return false;
            }
            if(encrypter.encryptPassword(password)!=loggedInUser.Password)
            {
                return false;
            }
            return true;
        }

        public List<Event> GetEvents(DateTime dateForEvents, User userForEvents)
        {
            GetEventsFromDB getEvents = new GetEventsFromDB();
            return getEvents.Get(dateForEvents, userForEvents.UserID);

        }

        public void RegisterUser(User user)
        {
            RegisterUserInDb register = new RegisterUserInDb();
            register.RegisterUserInDB(user.Name, user.Surname, user.DateOfBirth, user.Email, encrypter.encryptPassword(user.Password), DBSelection.MySql);
        }
    }
}
