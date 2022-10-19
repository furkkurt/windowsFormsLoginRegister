using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ntpLab
{
    public partial class forgotPasswordForm : Form
    {
        public forgotPasswordForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if(Int16.Parse(textBoxPasscode.Text) == loginForm.passwordCode)
            {
                MessageBox.Show("Your password is " + loginForm.password);
                loginForm toLoginForm = new loginForm();
                toLoginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The code you entered doesn't match the one that's been sent to your email.");
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void forgotPasswordForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(loginForm.passwordCode);
        }
        
    }
}
