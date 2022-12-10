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
    public partial class AddFormEquipmentDepartment : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormEquipmentDepartment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormEquipmentDepartment_Load(object sender, EventArgs e)
        {

        }

        private Boolean checEqDep()
        {
            var idEquipment = textBox_idEquipment.Text;
            var idDepartment = textBox_idDepartment.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            string queryString = $"SELECT idEquipment FROM equipment WHERE idEquipment = '{idEquipment}'";
            string queryString1 = $"SELECT idDepartment FROM department WHERE idDepartment = '{idDepartment}'";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            MySqlCommand command1 = new MySqlCommand(queryString1, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter1.SelectCommand = command1;
            adapter.Fill(table);
            adapter1.Fill(table1);

            if (table.Rows.Count == 0 || table1.Rows.Count == 0)
            {
                MessageBox.Show("Equipment or Department doesn't exist!", "Failed!");
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
            var idEquipment = textBox_idEquipment.Text;
            var idDepartment = textBox_idDepartment.Text;

            if (checEqDep())
            {
                return;
            }

            var addQuerry = $"insert into equipment_has_department (Equipment_idEquipment, Department_idDepartment) values ('{idEquipment}', '{idDepartment}')";
            var command = new MySqlCommand(addQuerry, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }
    }
}
