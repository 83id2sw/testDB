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
    enum RowStateProd
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class ProductPage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public ProductPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("title", "Title");
            dataGridView1.Columns.Add("idWare", "ID Warehouse");
            dataGridView1.Columns.Add("idDep", "ID Department");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), RowStateProd.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from product";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void ProductPage_Load(object sender, EventArgs e)
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
                textBox_idWarehouse.Text = row.Cells[2].Value.ToString();
                textBox_idDepartment.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormProduct addFormProd = new AddFormProduct();
            addFormProd.Show();
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
                dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
        }

        private void update()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowStateProd)dataGridView1.Rows[index].Cells[4].Value;

                if (rowState == RowStateProd.Existed)
                {
                    continue;
                }

                if (rowState == RowStateProd.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from product where idProduct = {id}";

                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateProd.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var title = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var idWare = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var idDep = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var changeQuery = $"update product set Title = '{title}', Warehouse_idWarehouse = '{idWare}', Department_idDepartment = '{idDep}' where idProduct = '{id}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from product where concat (idProduct, Title, Warehouse_idWarehouse, Department_idDepartment) like '%" + textBox_search.Text + "%'";
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

        private Boolean checkWareDep()
        {
            var idWare = textBox_idWarehouse.Text;
            var idDep = textBox_idDepartment.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            DataTable table1 = new DataTable();
            string queryStringW = $"SELECT idWarehouse FROM warehouse WHERE idWarehouse = '{idWare}'";
            string queryStringD = $"SELECT idDepartment FROM department WHERE idDepartment = '{idDep}'";

            MySqlCommand commandW = new MySqlCommand(queryStringW, dataBase.getConnection());
            MySqlCommand commandD = new MySqlCommand(queryStringW, dataBase.getConnection());
            adapter.SelectCommand = commandW;
            adapter1.SelectCommand = commandD;
            adapter.Fill(table);
            adapter1.Fill(table1);

            if (table.Rows.Count == 0 || table1.Rows.Count == 0)
            {
                MessageBox.Show("Department or Warehouse doesn't exist!", "Failed!");
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
            var title = textBox_title.Text;
            var idWare = textBox_idWarehouse.Text;
            var idDep = textBox_idDepartment.Text;

            if(checkWareDep())
            {
                return;
            }

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, title, idWare, idDep);
                dataGridView1.Rows[selectedRowIndex].Cells[4].Value = RowStateProd.Modified;
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }
    }
}
