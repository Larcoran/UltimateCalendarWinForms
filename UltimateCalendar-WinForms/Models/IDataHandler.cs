using System;
using System.Collections.Generic;

namespace UltimateCalendar_WinForms
{
    public interface IDataHandler
    {
        List<Event> GetEvents(DateTime dateForEvents, User userForEvents);

        string AddEvent(Event @event);

        string RegisterUser(User user);

        bool CredentialsCheck(string email, string password,out User loggedInUser);
    }
}
