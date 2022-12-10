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
    public partial class AddFormOrdersProducts : Form
    {
        DataBase dataBase = new DataBase();
        public AddFormOrdersProducts()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private Boolean checkIdPO()
        {
            var idProduct = textBox_idProduct.Text;
            var idOrder = textBox_idOrder.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            string queryString = $"SELECT idProduct FROM product WHERE idProduct = '{idProduct}'";
            string queryString1 = $"SELECT idOrder FROM orders WHERE idOrder = '{idOrder}'";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            MySqlCommand command1 = new MySqlCommand(queryString1, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter1.SelectCommand = command1;
            adapter.Fill(table);
            adapter1.Fill(table1);

            if (table.Rows.Count == 0 || table1.Rows.Count == 0)
            {
                MessageBox.Show("Product or Order doesn't exist!", "Failed!");
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
            var idProduct = textBox_idProduct.Text;
            var idOrder = textBox_idOrder.Text;

            if (checkIdPO())
            {
                return;
            }

            var addQuerry = $"insert into product_has_orders (Product_idProduct, Orders_idOrder) values ('{idProduct}', '{idOrder}')";
            var command = new MySqlCommand(addQuerry, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();

        }
    }
}
