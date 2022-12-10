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
    enum RowStateOrders
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class OrdersPage : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public OrdersPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("idOrder", "ID Order");
            dataGridView1.Columns.Add("title", "Title");
            dataGridView1.Columns.Add("price", "Price");
            dataGridView1.Columns.Add("idClient", "ID Client");
            dataGridView1.Columns.Add("IsNew", string.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), RowStateOrders.ModifiedNew);

        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"select * from orders";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void DepPage_Load(object sender, EventArgs e)
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
                textBox_idOrder.Text = row.Cells[0].Value.ToString();
                textBox_title.Text = row.Cells[1].Value.ToString();
                textBox_price.Text = row.Cells[2].Value.ToString();
                textBox_idClient.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button_newNote_Click(object sender, EventArgs e)
        {
            AddFormOrders addFormOrders = new AddFormOrders();
            addFormOrders.Show();
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
                dataGridView1.Rows[index].Cells[4].Value = RowStateOrders.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[4].Value = RowStateOrders.Deleted;
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
                var rowState = (RowStateOrders)dataGridView1.Rows[index].Cells[4].Value;

                if (rowState == RowStateOrders.Existed)
                {
                    continue;
                }

                if (rowState == RowStateOrders.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    
                    var deleteQueryF = $"delete from product_has_orders where Orders_idOrder = {id}";
                    var deleteQuery = $"delete from orders where idOrder = {id}";

                    var commandF = new MySqlCommand(deleteQueryF, dataBase.getConnection());
                    var command = new MySqlCommand(deleteQuery, dataBase.getConnection());
                    commandF.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }

                if (rowState == RowStateOrders.Modified)
                {
                    var idOrder = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var idClient = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var title = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var changeQuery = $"update orders set Client_idClient = '{idClient}', Title = '{title}', Price = '{price}' where idOrder = '{idOrder}'";

                    var command = new MySqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from orders where concat (idOrder, Title, Price, Client_idClient) like '%" + textBox_search.Text + "%'";
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

        private Boolean checkUser()
        {
            var idClient = textBox_idClient.Text;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            string queryString = $"SELECT idClient, Name, Telephone_number FROM client WHERE idClient = '{idClient}'";

            MySqlCommand command = new MySqlCommand(queryString, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Client doesn't exist!", "Failed!");
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

            var idOrder = textBox_idOrder.Text;
            var title = textBox_title.Text;
            int price;
            var idClient = textBox_idClient.Text;

            if(checkUser())
            {
                return;
            }

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if(int.TryParse(textBox_price.Text, out price))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(idOrder, title, price, idClient);
                    dataGridView1.Rows[selectedRowIndex].Cells[4].Value = RowStateOrders.Modified;
                }
                else
                {
                    MessageBox.Show("Invalid format of price!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
    }
}
