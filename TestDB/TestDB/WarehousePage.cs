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
    enum RowStateWH
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class WarehousePage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public WarehousePage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("datetime", "Date");
            dataGridView1.Columns.Add("title_num", "Title");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetDateTime(1), record.GetString(2), RowStateWH.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from warehouse";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void WarehousePage_Load(object sender, EventArgs e)
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
                textBox_date.Text = row.Cells[1].Value.ToString();
                textBox_titleNum.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormWarehouse addFormWH = new AddFormWarehouse();
            addFormWH.Show();
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
                dataGridView1.Rows[index].Cells[3].Value = RowStateWH.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[3].Value = RowStateWH.Deleted;
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
                var rowState = (RowStateWH)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowStateWH.Existed)
                {
                    continue;
                }

                if (rowState == RowStateWH.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from warehouse where idWarehouse = {id}";

                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateWH.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var date = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    DateTime dateValue = DateTime.Parse(date);
                    string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                    var titleNum = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var changeQuery = $"update warehouse set Datetime = '{formatForMySql}', Title_num = '{titleNum}' where idWarehouse = '{id}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from warehouse where concat (idWarehouse, Datetime, Title_num) like '%" + textBox_search.Text + "%'";
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
            DateTime date;
            var titleNum = textBox_titleNum.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (DateTime.TryParse(textBox_date.Text, out date))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, date, titleNum);
                    dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowStateWH.Modified;
                }
                else
                {
                    MessageBox.Show("Invalid format of datetime!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
