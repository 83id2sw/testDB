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
    public partial class Registration : Form
    {
        DataBase dataBase = new DataBase();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            textBox_rPass.PasswordChar = '*';
            textBox_rPass.MaxLength = 32;
            textBox_rLogin.MaxLength = 16;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rLogin = textBox_rLogin.Text;
            var rPass = textBox_rPass.Text;

            string queryString = $"INSERT INTO user (username, password) values ('{rLogin}', '{rPass}')";
            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            if (checkUser())
            {
                return;
            }

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Account are created!", "Successful!");
                Authorization authorization = new Authorization();
                this.Hide();
                authorization.ShowDialog();
            }
            else
            {
                MessageBox.Show("User aren't created!", "Failed!");
            }
            dataBase.closeConnection();
        }

        private Boolean checkUser()
        {
            var userLogin = textBox_rLogin.Text;
            var userPass = textBox_rPass.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"SELECT idUser, username, password FROM user WHERE username = '{userLogin}' AND password = '{userPass}'";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("User already exists!", "Failed!");
                return true;
            }
            else
            {
                return false;
            }

        }

        private void textBox_rLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_rPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Hide();
            authorization.ShowDialog();
        }
    }
}
