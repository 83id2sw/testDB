using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDB
{
    public partial class MenuPage : Form
    {
        public MenuPage()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            
            if(selectedState == "client")
            {
                MainPage mainPage = new MainPage();
                this.Hide();
                mainPage.ShowDialog();
                this.Show();
            } 
            else if (selectedState == "orders")
            {
                OrdersPage ordPage = new OrdersPage();
                this.Hide();
                ordPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "department")
            {
                DepartmentPage depPage = new DepartmentPage();
                this.Hide();
                depPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "warehouse")
            {
                WarehousePage whPage = new WarehousePage();
                this.Hide();
                whPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "product")
            {
                ProductPage prPage = new ProductPage();
                this.Hide();
                prPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "equipment")
            {
                EquipmentPage eqPage = new EquipmentPage();
                this.Hide();
                eqPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "employee")
            {
                EmployeePage emPage = new EmployeePage();
                this.Hide();
                emPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "provider")
            {
                ProviderPage prPage = new ProviderPage();
                this.Hide();
                prPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "raw")
            {
                RawPage rawPage = new RawPage();
                this.Hide();
                rawPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "orders and products")
            {
                OrdersAndProducts opPage = new OrdersAndProducts();
                this.Hide();
                opPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "equipment and department")
            {
                EquipmentAndDepartment eqDepPage = new EquipmentAndDepartment();
                this.Hide();
                eqDepPage.ShowDialog();
                this.Show();
            }
            else if (selectedState == "raw and department")
            {
                RawAndDepartment rawDepPage = new RawAndDepartment();
                this.Hide();
                rawDepPage.ShowDialog();
                this.Show();
            }

        }

        private void MenuPage_Load(object sender, EventArgs e)
        {

        }
    }
}
