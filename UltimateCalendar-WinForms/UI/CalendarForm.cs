using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltimateCalendarWinForms.Models;

namespace UltimateCalendar_WinForms.UI
{
    public partial class CalendarForm : Form
    {
        User loggedUser;

        public CalendarForm()
        {
            InitializeComponent();
            populateEventsLB();
        }

        private IDataHandler dataHandler;
        public CalendarForm(IDataHandler dataHandler,User loggedUser)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
            this.loggedUser = loggedUser;
            populateEventsLB();
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            populateEventsLB();
        }

        private void addEventBTN_Click(object sender, EventArgs e)
        {
            NewEventForm newEvent = new NewEventForm(new SQLDataHandler(),loggedUser);
            newEvent.ShowDialog();
        }

        private void populateEventsLB()
        {
            eventsLB.Items.Clear();
            List<Event> events = dataHandler.GetEvents(calendar.SelectionStart, loggedUser);
            foreach (Event @event in events)
            {
                eventsLB.Items.Add(@event.ToString());
            }
        }
    }
}
