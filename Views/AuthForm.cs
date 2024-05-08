using HotelSelect.DataAccessObject.Services;
using HotelSelect.Entity;
using System;
using System.Windows.Forms;

namespace HotelSelect
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            RegistrForm registrationForm = new RegistrForm();
            registrationForm.Hide();

            if (registrationForm.ShowDialog() == DialogResult.Cancel) { this.Show(); }
        }

        private void authBtn_Click(object sender, EventArgs e)
        {
            if (!UniversalMethodsCheckIsEmptyAndSelected.CheckStringsIsNullOfEmpty(login.Text, password.Text)) {
                return;
            }

            User user = new User { Login = login.Text, Password = password.Text };

            VerificationUserForAuth verificationUserForAuth = new VerificationUserForAuth();

            if (verificationUserForAuth.CheckExistUser(user)) {
                MessageBox.Show("This user does't exist");
                return;
            }


            Security.Security sec = new Security.Security();

            if (sec.AuthUser(user)) {
                PersonalAccount personalAccount = new PersonalAccount();
                personalAccount.ShowDialog();
            }
        }

        private void login_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(login.Text)) {
                label1.Visible = true;
            }
            else {
                label1.Visible = false;
            }   
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text)) {
                label2.Visible = true;
            }
            else {
                label2.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(password.PasswordChar == '\0') {
                button3.BringToFront();
                password.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*') {
                button2.BringToFront();
                password.PasswordChar = '\0';
            }
        }
    }
}
