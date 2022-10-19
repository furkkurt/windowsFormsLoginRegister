using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net.Mail;

namespace ntpLab
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();

        }

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "hPuCH8B6f3VDnkBdt4G1fnBkUUafm0ogA9h9Eejy",
            BasePath = "https://register-286d3-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient Client;

        private void Form1_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(Config);
        }

        private async void CreateUser()
        {
            if (textBoxPassword.Text == textBoxPasswordCheck.Text)
            {
                var Info = new userInfo
                {
                    emailV = textBoxEmail.Text,
                    passwordV = textBoxPassword.Text
                };
                FirebaseResponse response = await Client.SetAsync("Users/" + textBoxUsername.Text, Info);
                MessageBox.Show("User Registered");
            }
            else
            {
                MessageBox.Show("Passwords you entered doesn't match with each other.");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private void buttonToLogin_Click(object sender, EventArgs e)
        {
            loginForm toLoginForm = new loginForm();
            toLoginForm.Show();
            this.Hide();
        }
    }
}
