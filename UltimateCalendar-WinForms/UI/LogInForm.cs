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

namespace UltimateCalendarWinForms.UI
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private IDataHandler dataHandler;
        public LogInForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
            dataHandler.CredentialsCheck(emailTB.Text,passwordTB.Text, out user);
        }
    }
}
