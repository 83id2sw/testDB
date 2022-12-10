using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TestDB
{
    public partial class Authorization : Form
    {
        DataBase dataBase = new DataBase();
        public Authorization()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox_login.Text = "Enter login";
            textBox_password.Text = "Enter password";
            textBox_login.ForeColor = Color.Gray;
            textBox_password.ForeColor = Color.Gray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            textBox_password.MaxLength = 32;
            textBox_login.MaxLength = 16;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox_login_Enter(object sender, EventArgs e)
        {
            if (textBox_login.Text == "Enter login")
            {
                textBox_login.Text = "";
                textBox_login.ForeColor = Color.Black;
            }
        }

        private void textBox_login_Leave(object sender, EventArgs e)
        {
            if (textBox_login.Text == "")
            {
                textBox_login.Text = "Enter login";
                textBox_login.ForeColor = Color.Black;
            }
        }

        private void textBox_password_Enter(object sender, EventArgs e)
        {
            if (textBox_password.Text == "Enter password")
            {
                textBox_password.Text = "";
                textBox_password.ForeColor = Color.Black;
            }
        }

        private void textBox_password_Leave(object sender, EventArgs e)
        {
            if (textBox_password.Text == "")
            {
                textBox_password.Text = "Enter password";
                textBox_password.ForeColor = Color.Black;
            }
        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_register_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passwordUser = textBox_password.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"SELECT idUser, username, password FROM user WHERE username = '{loginUser}' AND password = '{passwordUser}'";
            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(table);
            } catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException", ex);
            }

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("The user is logged in!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuPage menuPage = new MenuPage();
                this.Hide();
                menuPage.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("The user doesn't exist!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
