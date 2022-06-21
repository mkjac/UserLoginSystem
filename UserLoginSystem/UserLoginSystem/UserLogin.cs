using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLoginSystem
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = PasswordTextBox.PasswordChar = '\0';
        }

        private void EmailTextbox_FocusEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmailTextBox.Text) || EmailTextBox.Text == "Email")
            {
                EmailTextBox.Text = "";
            }
            EmailTextBox.ForeColor = Color.Black;
        }

        private void PasswordTextbox_FocusEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordTextBox.Text) || PasswordTextBox.Text == "Password")
            {
                PasswordTextBox.Text = "";
            }
            PasswordTextBox.ForeColor = Color.Black;
            PasswordTextBox.PasswordChar = '*';
        }

        private void EmailTextbox_FocusLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                EmailTextBox.Text = "Email";
                EmailTextBox.ForeColor = Color.Silver;
            }
        }

        private void PasswordTextbox_FocusLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "Password";
                PasswordTextBox.ForeColor = Color.Silver;
                PasswordTextBox.PasswordChar = '\0';
            }
        }
    }
}
