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
    public partial class AddFormRawDepartment : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormRawDepartment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormRawDepartment_Load(object sender, EventArgs e)
        {

        }

        private Boolean checkRawProviderDep()
        {
            var idRaw = textBox_idRaw.Text;
            var idProvider = textBox_idProvider.Text;
            var idDepartment = textBox_idDepartment.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            string queryString = $"SELECT idRaw FROM raw WHERE idRaw = '{idRaw}'";
            string queryString1 = $"SELECT idProvider FROM provider WHERE idProvider = '{idProvider}'";
            string queryString2 = $"SELECT idDepartment FROM department WHERE idDepartment = '{idDepartment}'";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            MySqlCommand command1 = new MySqlCommand(queryString1, dataBase.getConnection());
            MySqlCommand command2 = new MySqlCommand(queryString2, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter1.SelectCommand = command1;
            adapter2.SelectCommand = command2;
            adapter.Fill(table);
            adapter1.Fill(table1);
            adapter2.Fill(table2);

            if (table.Rows.Count == 0 || table1.Rows.Count == 0 || table2.Rows.Count == 0)
            {
                MessageBox.Show("Raw, Provider or Department doesn't exist!", "Failed!");
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
            var idRaw = textBox_idRaw.Text;
            var idProvider = textBox_idProvider.Text;
            var idDepartment = textBox_idDepartment.Text;

            if (checkRawProviderDep())
            {
                return;
            }

            var addQuerry = $"insert into raw_has_department (Raw_idRaw, Raw_Provider_idProvider, Department_idDepartment) values ('{idRaw}', '{idProvider}', '{idDepartment}')";
            var command = new MySqlCommand(addQuerry, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }
    }
}
