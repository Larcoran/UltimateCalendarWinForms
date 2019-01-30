using System;
using System.Windows.Forms;

namespace UltimateCalendar_WinForms.UI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        Form parentForm;

        private IDataHandler dataHandler;
        public RegisterForm(IDataHandler dataHandler,Form parentForm)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
            this.parentForm = parentForm;
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void registerBTN_Click(object sender, EventArgs e)
        {
            if (emailTB.Text != email2TB.Text && passwordTB.Text != password2TB.Text)
            {
                MessageBox.Show("Email and password doesn't match.");
                return;
            }
            if (emailTB.Text!=email2TB.Text)
            {
                MessageBox.Show("Email doesn't match.");
                return;
            }
            if (passwordTB.Text != password2TB.Text)
            {
                MessageBox.Show("Password doesn't match.");
                return;
            }
            if(passwordTB.Text.Length<=8)
            {
                MessageBox.Show("Password is to short.");
                return;
            }
            if(!emailTB.Text.Contains("@"))
            {
                MessageBox.Show("Email is incorrect.");
                return;
            }
            
            User newUser = new User();
            newUser.Name = nameTB.Text;
            newUser.Surname = surnameTB.Text;
            newUser.DateOfBirth = dobTP.Value;
            newUser.Email = emailTB.Text;
            newUser.Password = passwordTB.Text;
            
            MessageBox.Show(dataHandler.RegisterUser(newUser));
        }
    }
}
