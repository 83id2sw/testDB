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
    public partial class AddFormWarehouse : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormWarehouse()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormWarehouse_Load(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var date = textBox_date.Text;
            DateTime dateValue = DateTime.Parse(date);
            string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
            var titleNum = textBox_titleNum.Text;

            if (titleNum.Length > 70)
            {
                MessageBox.Show("Length of Title is too long!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DateTime.TryParse(textBox_date.Text, out dateValue))
            {
                var addQuerry = $"insert into warehouse (Datetime, Title_num) values ('{formatForMySql}', '{titleNum}')";
                var command = new MySqlCommand(addQuerry, dataBase.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Datetime's format error!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();
        }
    }
}
