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
    public partial class AddFormOrders : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormOrders()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormOrders_Load(object sender, EventArgs e)
        {

        }

        private Boolean checkUser()
        {
            var idClient = textBox_idClient.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"SELECT idClient, Name, Telephone_number FROM client WHERE idClient = '{idClient}'";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Client doesn't exist!", "Failed!");
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var idClient = textBox_idClient.Text;
            var title = textBox_title.Text;
            int price;

            if (title.Length > 15 || checkUser())
            {
                MessageBox.Show("Length of title is too long or Client aren't exist!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(int.TryParse(textBox_price.Text, out price))
            {
                var addQuerry = $"insert into orders (Title, Price, Client_idClient) values ('{title}', '{price}', '{idClient}')";
                var command = new MySqlCommand(addQuerry, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Price error!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
        }
    }
}
