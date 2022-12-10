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
    enum RowStateEmp
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class EmployeePage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public EmployeePage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("exp", "Expierence");
            dataGridView1.Columns.Add("spec", "Speciality");
            dataGridView1.Columns.Add("idDep", "ID Department");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetInt32(4), RowStateEmp.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from employee";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void EmployeePage_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_name.Text = row.Cells[1].Value.ToString();
                textBox_exp.Text = row.Cells[2].Value.ToString();
                textBox_spec.Text = row.Cells[3].Value.ToString();
                textBox_idDep.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormEmployee addFormEmp = new AddFormEmployee();
            addFormEmp.Show();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowStateEmp.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[5].Value = RowStateEmp.Deleted;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowStateEmp)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowStateEmp.Existed)
                {
                    continue;
                }

                if (rowState == RowStateEmp.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from employee where idEmployee = {id}";

                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateEmp.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var exp = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var spec = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var idDep = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var changeQuery = $"update employee set Name = '{name}', Expierence = '{exp}', Speciality = '{spec}', Department_idDepartment = '{idDep}' where idEmployee = '{id}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from employee where concat (idEmployee, Name, Expierence, Speciality, Department_idDepartment) like '%" + textBox_search.Text + "%'";
            MySqlCommand command = new MySqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }

            reader.Close();

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            update();
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

        private void Edit()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var name = textBox_name.Text;
            int exp;
            var spec = textBox_spec.Text;
            var idDep = textBox_idDep.Text;

            if(checkDep())
            {
                return;
            }

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_exp.Text, out exp))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, name, exp, spec, idDep);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowStateEmp.Modified;
                }
                else
                {
                    MessageBox.Show("Invalid format of expierence!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button_edit_Click_1(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
