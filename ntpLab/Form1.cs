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


namespace ntpLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "hPuCH8B6f3VDnkBdt4G1fnBkUUafm0ogA9h9Eejy",
            BasePath = "https://register-286d3-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient Client;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(Config);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }


        private async void CreateUser()
        {
            var Info = new userInfo{
                emailV = textBoxEmail.Text,
                passwordV = textBoxPassword.Text
            };
            FirebaseResponse response = await Client.SetAsync("Users/"+textBoxUsername.Text,Info);
            MessageBox.Show("User Registered");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            var result = Client.Get("Users/" + textBoxUsername.Text);
            userInfo user = result.ResultAs<userInfo>();

            if (textBoxPassword.Text == user.passwordV && textBoxEmail.Text == user.emailV)
            {
                MessageBox.Show("Welcome, " + textBoxUsername.Text);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
