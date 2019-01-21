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
using UltimateCalendarWinForms.UI;

namespace UltimateCalendar_WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LogInForm login = new LogInForm(new SQLDataHandler());
            login.ShowDialog();
        }
    }
}
