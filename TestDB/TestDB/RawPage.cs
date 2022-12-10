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
    enum RowStateRaw
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class RawPage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public RawPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("quant", "Quantity");
            dataGridView1.Columns.Add("title", "Title");
            dataGridView1.Columns.Add("price", "Price");
            dataGridView1.Columns.Add("idProvider", "ID Provider");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), RowStateRaw.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from raw";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void RawPage_Load(object sender, EventArgs e)
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
                textBox_quantity.Text = row.Cells[1].Value.ToString();
                textBox_title.Text = row.Cells[2].Value.ToString();
                textBox_price.Text = row.Cells[3].Value.ToString();
                textBox_idProvider.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormRaw addFormRaw = new AddFormRaw();
            addFormRaw.Show();
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
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
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
                var rowState = (RowStateRaw)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowStateRaw.Existed)
                {
                    continue;
                }

                if (rowState == RowStateRaw.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQueryO = $"delete from raw_has_department where Raw_idRaw = {id}";
                    var deleteQuery = $"delete from raw where idRaw = {id}";

                    var commandO = new MySqlCommand(deleteQueryO, dataBase.getConnection());
                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    commandO.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateRaw.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var quantity = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var title = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var idProvider = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var changeQuery = $"update raw set Quantity = '{quantity}', Title = '{title}', Price = '{price}', Provider_idProvider = '{idProvider}' where idRaw = '{id}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from raw where concat (idRaw, Quantity, Title, Price, Provider_idProvider) like '%" + textBox_search.Text + "%'";
            MySqlCommand command = new MySqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }

            reader.Close();

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            update();
        }

        private Boolean checkProvider()
        {
            var idProvider = textBox_idProvider.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string queryStringD = $"SELECT idProvider FROM provider WHERE idProvider = '{idProvider}'";

            MySqlCommand commandD = new MySqlCommand(queryStringD, dataBase.getConnection());
            adapter.SelectCommand = commandD;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Provider doesn't exist!", "Failed!");
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
            int quantity;
            var title = textBox_title.Text;
            int price;
            var idProvider = textBox_idProvider.Text;

            if(checkProvider())
            {
                return;
            }

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_price.Text, out price) && int.TryParse(textBox_quantity.Text, out quantity))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, quantity, title, price, idProvider);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowStateRaw.Modified;
                }
                else
                {
                    MessageBox.Show("Invalid format of price or quantity!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void textBox_search_TextChanged_1(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
    }
}
