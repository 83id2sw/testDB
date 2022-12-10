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
    public partial class AddFormRaw : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormRaw()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormRaw_Load(object sender, EventArgs e)
        {

        }

        private Boolean checkProvider()
        {
            var idProvider = textBox_idProvider.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string queryStringD = $"SELECT idProvider FROM provider WHERE idProvider = '{idProvider}'";

            MySqlCommand commandD = new MySqlCommand(queryStringD, dataBase.getConnection());
            adapter.SelectCommand = commandD;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Provider doesn't exist!", "Failed!");
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
            int quantity;
            var title = textBox_title.Text;
            int price;
            var idProvider = textBox_idProvider.Text;

            if (title.Length > 15 || checkProvider())
            {
                MessageBox.Show("Length of Title is too long or Provider doesn't exist!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (int.TryParse(textBox_price.Text, out price) && int.TryParse(textBox_quantity.Text, out quantity))
            {
                var addQuerry = $"insert into raw (Quantity, Title, Price, Provider_idProvider) values ('{quantity}', '{title}', '{price}', '{idProvider}')";
                var command = new MySqlCommand(addQuerry, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Price's or Quantity's format error!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();
        }
    }
}
