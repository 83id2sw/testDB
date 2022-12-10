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
    public partial class AddFormEmployee : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormEmployee()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormEmployee_Load(object sender, EventArgs e)
        {

        }

        private Boolean checkDep()
        {
            var idDep = textBox_idDep.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string queryStringD = $"SELECT idDepartment FROM department WHERE idDepartment = '{idDep}'";

            MySqlCommand commandD = new MySqlCommand(queryStringD, dataBase.getConnection());
            adapter.SelectCommand = commandD;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Department doesn't exist!", "Failed!");
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
            var name = textBox_name.Text;
            int exp;
            var spec = textBox_spec.Text;
            var idDep = textBox_idDep.Text;

            if (name.Length > 70 || spec.Length > 15 || checkDep())
            {
                MessageBox.Show("Length of Name, Speciality is too long or Department doesn't exist!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (int.TryParse(textBox_exp.Text, out exp))
            {
                var addQuerry = $"insert into employee (Name, Expierence, Speciality, Department_idDepartment) values ('{name}', '{exp}', '{spec}', '{idDep}')";
                var command = new MySqlCommand(addQuerry, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Expierence error!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();
        }
    }
}
