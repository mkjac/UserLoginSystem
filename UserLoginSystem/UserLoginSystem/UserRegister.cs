using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserLoginSystem
{
    public partial class UserRegister : Form
    {
        User user = new User(null, null);
        hiddenInfo hidden = new hiddenInfo();

        public UserRegister()
        {
            InitializeComponent();
        }

        private void UserRegister_Load(object sender, EventArgs e)
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
                user.Email = null;
            }
            else
            {
                user.Email = EmailTextBox.Text;
            }
        }

        private void PasswordTextbox_FocusLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "Password";
                PasswordTextBox.ForeColor = Color.Silver;
                PasswordTextBox.PasswordChar = '\0';
                user.Password = null;
            }
            else
            {
                user.Password = PasswordTextBox.Text;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                MessageBox.Show("Please input an email");
            }
            else if (string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Please input password");
            }
            else
            {
                user.Email = EmailTextBox.Text;
                user.Password = PasswordTextBox.Text;

                SqlConnection conn = new SqlConnection(hidden.connectionString);

                SqlCommand cmd = new SqlCommand("INSERT INTO" + hidden.databaseName +
                                                "(Email, Password) " + "VALUES ('" +
                                                user.Email + "', '" + user.Password +
                                                "');", conn);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Registered");
            }
        }
    }
}
