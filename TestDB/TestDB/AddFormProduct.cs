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
    public partial class AddFormProduct : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormProduct()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormProduct_Load(object sender, EventArgs e)
        {

        }

        private Boolean checkWareDep()
        {
            var idWare = textBox_idWareh.Text;
            var idDep = textBox_idDepartment.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            DataTable table1 = new DataTable();
            string queryStringW = $"SELECT idWarehouse FROM warehouse WHERE idWarehouse = '{idWare}'";
            string queryStringD = $"SELECT idDepartment FROM department WHERE idDepartment = '{idDep}'";

            MySqlCommand commandW = new MySqlCommand(queryStringW, dataBase.getConnection());
            MySqlCommand commandD = new MySqlCommand(queryStringW, dataBase.getConnection());
            adapter.SelectCommand = commandW;
            adapter1.SelectCommand = commandD;
            adapter.Fill(table);
            adapter1.Fill(table1);

            if (table.Rows.Count == 0 || table1.Rows.Count == 0)
            {
                MessageBox.Show("Department or Warehouse doesn't exist!", "Failed!");
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
            var title = textBox_title.Text;
            var idWareh = textBox_idWareh.Text;
            var idDep = textBox_idDepartment.Text;

            if (title.Length > 15 || checkWareDep())
            {
                MessageBox.Show("Length of Title is too long!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var addQuerry = $"insert into product (Title, Warehouse_idWarehouse, Department_idDepartment) values ('{title}', '{idWareh}', '{idDep}')";
            var command = new MySqlCommand(addQuerry, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }
    }
}
