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
    public partial class AddFormClient : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddFormClient_Load(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var name = textBox_name.Text;
            var telNum = textBox_telNum.Text;

            if(name.Length > 70 || telNum.Length > 15)
            {
                MessageBox.Show("Length of Name or Telephone number is too long!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            var addQuerry = $"insert into client (Name, Telephone_number) values ('{name}', '{telNum}')";
            var command = new MySqlCommand(addQuerry, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();

        }
    }
}
