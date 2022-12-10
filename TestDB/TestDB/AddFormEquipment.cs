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
    public partial class AddFormEquipment : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormEquipment()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var title = textBox_title.Text;
            var condition = textBox_condition.Text;

            if (title.Length > 45 || condition.Length > 15)
            {
                MessageBox.Show("Length of Title or Condition is too long!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var addQuerry = $"insert into equipment (Title, Condition_eq) values ('{title}', '{condition}')";
            var command = new MySqlCommand(addQuerry, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Note are created!", "Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }
    }
}
