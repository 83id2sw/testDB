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
    enum RowStateEq
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class EquipmentPage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public EquipmentPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("title", "Title");
            dataGridView1.Columns.Add("cond", "Condition");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from equipment";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void EquipmentPage_Load(object sender, EventArgs e)
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
                textBox_title.Text = row.Cells[1].Value.ToString();
                textBox_condition.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormEquipment addFormEq = new AddFormEquipment();
            addFormEq.Show();
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
                dataGridView1.Rows[index].Cells[3].Value = RowStateEq.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[3].Value = RowStateEq.Deleted;
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
                var rowState = (RowStateEq)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowStateEq.Existed)
                {
                    continue;
                }

                if (rowState == RowStateEq.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQueryO = $"delete from equipment_has_department where Equipment_idEquipment = {id}";
                    var deleteQuery = $"delete from equipment where idEquipment = {id}";

                    var commandO = new MySqlCommand(deleteQueryO, dataBase.getConnection());
                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    commandO.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateEq.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var title = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var cond = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var changeQuery = $"update equipment set Title = '{title}', Condition_eq = '{cond}' where idEquipment = '{id}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from equipment where concat (idEquipment, Title, Condition_eq) like '%" + textBox_search.Text + "%'";
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
            var title = textBox_title.Text;
            var cond = textBox_condition.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, title, cond);
                dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowStateEq.Modified;
            }

        }

        private void button_edit_Click_1(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
