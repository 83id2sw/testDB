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
    enum RowStateOrdProd
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class OrdersAndProducts : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public OrdersAndProducts()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idProduct", "ID Product");
            dataGridView1.Columns.Add("idOrder", "ID Order");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), RowStateOrdProd.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from product_has_orders";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void OrdersAndProducts_Load(object sender, EventArgs e)
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
                textBox_idProduct.Text = row.Cells[0].Value.ToString();
                textBox_idOrder.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormOrdersProducts addFormOP = new AddFormOrdersProducts();
            addFormOP.Show();
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
                dataGridView1.Rows[index].Cells[2].Value = RowStateOrdProd.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[2].Value = RowStateOrdProd.Deleted;
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
                var rowState = (RowStateOrdProd)dataGridView1.Rows[index].Cells[2].Value;

                if (rowState == RowStateOrdProd.Existed)
                {
                    continue;
                }

                if (rowState == RowStateOrdProd.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from product_has_orders where Product_idProduct = {id}";

                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateOrdProd.Modified)
                {
                    var idOrder = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var idProduct = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var changeQuery = $"update product_has_orders set Product_idProduct = '{idProduct}', Orders_idOrder = '{idOrder}' where Orders_idOrder = '{idOrder}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from product_has_orders where concat (Product_idProduct, Orders_idOrder) like '%" + textBox_search.Text + "%'";
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

            var idOrder = textBox_idOrder.Text;
            var idProduct = textBox_idProduct.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(idProduct, idOrder);
                dataGridView1.Rows[selectedRowIndex].Cells[2].Value = RowStateOrdProd.Modified;
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
