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
    enum RowStateRawDep
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class RawAndDepartment : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public RawAndDepartment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idraw", "ID Raw");
            dataGridView1.Columns.Add("idprovider", "ID Provider");
            dataGridView1.Columns.Add("iddepartment", "ID Department");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), RowStateRawDep.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from raw_has_department";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void RawAndDepartment_Load(object sender, EventArgs e)
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
                textBox_idRaw.Text = row.Cells[0].Value.ToString();
                textBox_idProvider.Text = row.Cells[1].Value.ToString();
                textBox_idDepartment.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormRawDepartment addFormRD = new AddFormRawDepartment();
            addFormRD.Show();
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
                dataGridView1.Rows[index].Cells[3].Value = RowStateRawDep.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[3].Value = RowStateRawDep.Deleted;
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
                var rowState = (RowStateRawDep)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowStateRawDep.Existed)
                {
                    continue;
                }

                if (rowState == RowStateRawDep.Deleted)
                {
                    var idRaw = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from raw_has_department where Raw_idRaw = {idRaw}";

                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateRawDep.Modified)
                {
                    var idRaw = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var idProvider = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var idDepartment = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var changeQuery = $"update raw_has_department set Raw_idRaw = '{idRaw}', Raw_Provider_idProvider = '{idProvider}', Department_idDepartment = '{idDepartment}' where Raw_idRaw = '{idRaw}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from raw_has_department where concat (Raw_idRaw, Raw_Provider_idProvider, Department_idDepartment) like '%" + textBox_search.Text + "%'";
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

            var idRaw = textBox_idRaw.Text;
            var idProvider = textBox_idProvider.Text;
            var idDepartment = textBox_idDepartment.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(idRaw, idProvider, idDepartment);
                dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowStateRawDep.Modified;
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
