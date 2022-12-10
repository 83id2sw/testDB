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
    enum RowStateDep
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class DepartmentPage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public DepartmentPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("address", "Address");
            dataGridView1.Columns.Add("tel_num", "Telephone number");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowStateDep.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from department";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void DepartmentPage_Load(object sender, EventArgs e)
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
                textBox_address.Text = row.Cells[1].Value.ToString();
                textBox_telNum.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormDepartment addDep = new AddFormDepartment();
            addDep.Show();
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
                dataGridView1.Rows[index].Cells[3].Value = RowStateDep.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[3].Value = RowStateDep.Deleted;
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
                var rowState = (RowStateDep)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowStateDep.Existed)
                {
                    continue;
                }

                if (rowState == RowStateDep.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQueryE = $"delete from employee where Department_idDepartment = {id}";
                    var deleteQueryR = $"delete from raw_has_department where Department_idDepartment = {id}";
                    var deleteQueryQ = $"delete from equipment_has_department where Department_idDepartment = {id}";
                    var deleteQueryP = $"delete from product where Department_idDepartment = {id}";
                    var deleteQuery = $"delete from department where idDepartment = {id}";

                    var commandE = new MySqlCommand(deleteQueryE, dataBase.getConnection());
                    var commandR = new MySqlCommand(deleteQueryQ, dataBase.getConnection());
                    var commandQ = new MySqlCommand(deleteQueryR, dataBase.getConnection());
                    var commandP = new MySqlCommand(deleteQueryP, dataBase.getConnection());
                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    commandE.ExecuteNonQuery();
                    commandR.ExecuteNonQuery();
                    commandQ.ExecuteNonQuery();
                    commandP.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateDep.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var address = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var telNum = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var changeQuery = $"update department set Address = '{address}', Telephone_number = '{telNum}' where idDepartment = '{id}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from department where concat (idDepartment, Address, Telephone_number) like '%" + textBox_search.Text + "%'";
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

        private void Edit()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var address = textBox_address.Text;
            var telNum = textBox_telNum.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, address, telNum);
                dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowStateDep.Modified;
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
