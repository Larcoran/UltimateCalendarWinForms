using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace UltimateCalendar_WinForms.Models
{
    class JsonToEventConverter
    {
        public Event Convert(string json)
        {
            Event @event = new JavaScriptSerializer().Deserialize<Event>(json);
            return @event;
        }
    }
}
