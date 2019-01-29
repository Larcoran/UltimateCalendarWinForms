using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace UltimateCalendar_WinForms.Models
{
    class JsonToUserConverter
    {
        public User Convert(string json)
        {
            User user= new JavaScriptSerializer().Deserialize<User>(json);
            return user;
        }
    }
}
