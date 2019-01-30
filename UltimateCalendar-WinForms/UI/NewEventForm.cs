using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateCalendar_WinForms.UI
{
    public partial class NewEventForm : Form
    {
        public NewEventForm()
        {
            InitializeComponent();
            PopulateEventTypeCB();
        }

        private IDataHandler dataHandler;
        private User loggedUser;
        public NewEventForm(IDataHandler dataHandler,User loggedUser,DateTime dateForNewEvent)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
            this.loggedUser = loggedUser;
            PopulateEventTypeCB();
            eventDatePicker.Value = dateForNewEvent;
        }

        private void addEventBTN_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event();
            newEvent.Date = eventDatePicker.Value;
            newEvent.Time = eventTimePicker.Value;
            newEvent.Description = descriptionTB.Text;
            newEvent.Type = eventTypeCB.Text;
            newEvent.UserId = loggedUser.UserID;
            MessageBox.Show(dataHandler.AddEvent(newEvent));
            Close();
        }

        private void PopulateEventTypeCB()
        {
            foreach (string type in Enum.GetNames(typeof(EventTypes)))
            {
                eventTypeCB.Items.Add(type);
            }
            eventTypeCB.SelectedIndex = 0;
        }
    }
}
