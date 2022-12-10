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
    enum RowStateEqDep
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class EquipmentAndDepartment : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public EquipmentAndDepartment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idEq", "ID Equipment");
            dataGridView1.Columns.Add("idDep", "ID Department");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), RowStateEqDep.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from equipment_has_department";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void EquipmentAndDepartment_Load(object sender, EventArgs e)
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
                textBox_idEquipment.Text = row.Cells[0].Value.ToString();
                textBox_idDepartment.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormEquipmentDepartment addEqDep = new AddFormEquipmentDepartment();
            addEqDep.Show();
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
                dataGridView1.Rows[index].Cells[2].Value = RowStateEqDep.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[2].Value = RowStateEqDep.Deleted;
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
                var rowState = (RowStateEqDep)dataGridView1.Rows[index].Cells[2].Value;

                if (rowState == RowStateEqDep.Existed)
                {
                    continue;
                }

                if (rowState == RowStateEqDep.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from equipment_has_department where Equipment_idEquipment = {id}";

                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateEqDep.Modified)
                {
                    var idEquipment = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var idDepartment = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var changeQuery = $"update equipment_has_department set Equipment_idEquipment = '{idEquipment}', Department_idDepartment = '{idDepartment}' where Equipment_idEquipment = '{idEquipment}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from equipment_has_department where concat (Equipment_idEquipment, Department_idDepartment) like '%" + textBox_search.Text + "%'";
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

            var idEq = textBox_idEquipment.Text;
            var idDep = textBox_idDepartment.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(idEq, idDep);
                dataGridView1.Rows[selectedRowIndex].Cells[2].Value = RowStateEqDep.Modified;
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
