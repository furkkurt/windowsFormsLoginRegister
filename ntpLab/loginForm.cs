using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net.Mail;

namespace ntpLab
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "hPuCH8B6f3VDnkBdt4G1fnBkUUafm0ogA9h9Eejy",
            BasePath = "https://register-286d3-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient Client;

        private void loginForm_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(Config);

        }

        private void buttonToRegister_Click(object sender, EventArgs e)
        {
            registerForm toRegisterForm = new registerForm();
            toRegisterForm.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var result = Client.Get("Users/" + textBoxUsername.Text);
            userInfo user = result.ResultAs<userInfo>();

            if (textBoxPassword.Text == user.passwordV)
            {
                MessageBox.Show("Welcome, " + textBoxUsername.Text);
            }
        }

        public static int passwordCode;
        public static String password;
        private void buttonForgotPassword_Click(object sender, EventArgs e)
        {
            var result = Client.Get("Users/" + textBoxUsername.Text);
            userInfo user = result.ResultAs<userInfo>();

            Random random = new Random();
            passwordCode = random.Next(10000);
            password = user.passwordV;

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(user.emailV, "user"));
            msg.From = new MailAddress("ayiabi42@outlook.com", "furkan");
            msg.Subject = "This is a Test Mail";
            if (user.emailV == user.emailV)
                msg.Body = "Your code is: " + passwordCode;
            else
                MessageBox.Show("Email doesn't match the username.");
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("ayiabi42@outlook.com", "76587934-0");
            client.Port = 25;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                forgotPasswordForm toForgotPasswordForm = new forgotPasswordForm();
                toForgotPasswordForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
