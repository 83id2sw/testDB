
namespace TestDB
{
    partial class OrdersPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersPage));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_write = new System.Windows.Forms.PictureBox();
            this.label_write = new System.Windows.Forms.Label();
            this.panel_manage = new System.Windows.Forms.Panel();
            this.button_save = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_newNote = new System.Windows.Forms.Button();
            this.panel_write = new System.Windows.Forms.Panel();
            this.label_idClient = new System.Windows.Forms.Label();
            this.textBox_idClient = new System.Windows.Forms.TextBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.textBox_idOrder = new System.Windows.Forms.TextBox();
            this.label_price = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_idOrder = new System.Windows.Forms.Label();
            this.label_manage = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_write)).BeginInit();
            this.panel_manage.SuspendLayout();
            this.panel_write.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 561);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.pictureBox_write);
            this.tabPage1.Controls.Add(this.label_write);
            this.tabPage1.Controls.Add(this.panel_manage);
            this.tabPage1.Controls.Add(this.panel_write);
            this.tabPage1.Controls.Add(this.label_manage);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "orders";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::TestDB.Properties.Resources.icons8_edit_database_22;
            this.pictureBox2.Location = new System.Drawing.Point(512, 321);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox_write
            // 
            this.pictureBox_write.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_write.Image = global::TestDB.Properties.Resources.icons8_write_22;
            this.pictureBox_write.Location = new System.Drawing.Point(8, 321);
            this.pictureBox_write.Name = "pictureBox_write";
            this.pictureBox_write.Size = new System.Drawing.Size(22, 22);
            this.pictureBox_write.TabIndex = 8;
            this.pictureBox_write.TabStop = false;
            // 
            // label_write
            // 
            this.label_write.AutoSize = true;
            this.label_write.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_write.Location = new System.Drawing.Point(36, 321);
            this.label_write.Name = "label_write";
            this.label_write.Size = new System.Drawing.Size(62, 25);
            this.label_write.TabIndex = 7;
            this.label_write.Text = "Write";
            // 
            // panel_manage
            // 
            this.panel_manage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_manage.Controls.Add(this.button_save);
            this.panel_manage.Controls.Add(this.button_edit);
            this.panel_manage.Controls.Add(this.button_delete);
            this.panel_manage.Controls.Add(this.button_newNote);
            this.panel_manage.Location = new System.Drawing.Point(512, 346);
            this.panel_manage.Name = "panel_manage";
            this.panel_manage.Size = new System.Drawing.Size(227, 181);
            this.panel_manage.TabIndex = 6;
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.Location = new System.Drawing.Point(3, 126);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(220, 35);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_edit.Location = new System.Drawing.Point(3, 85);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(220, 35);
            this.button_edit.TabIndex = 2;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_delete
            // 
            this.button_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.Location = new System.Drawing.Point(3, 44);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(220, 35);
            this.button_delete.TabIndex = 1;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_newNote
            // 
            this.button_newNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_newNote.Location = new System.Drawing.Point(3, 3);
            this.button_newNote.Name = "button_newNote";
            this.button_newNote.Size = new System.Drawing.Size(220, 35);
            this.button_newNote.TabIndex = 0;
            this.button_newNote.Text = "New Note";
            this.button_newNote.UseVisualStyleBackColor = true;
            this.button_newNote.Click += new System.EventHandler(this.button_newNote_Click);
            // 
            // panel_write
            // 
            this.panel_write.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_write.Controls.Add(this.label_idClient);
            this.panel_write.Controls.Add(this.textBox_idClient);
            this.panel_write.Controls.Add(this.textBox_price);
            this.panel_write.Controls.Add(this.textBox_title);
            this.panel_write.Controls.Add(this.textBox_idOrder);
            this.panel_write.Controls.Add(this.label_price);
            this.panel_write.Controls.Add(this.label_title);
            this.panel_write.Controls.Add(this.label_idOrder);
            this.panel_write.Location = new System.Drawing.Point(8, 346);
            this.panel_write.Name = "panel_write";
            this.panel_write.Size = new System.Drawing.Size(488, 181);
            this.panel_write.TabIndex = 5;
            // 
            // label_idClient
            // 
            this.label_idClient.AutoSize = true;
            this.label_idClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_idClient.Location = new System.Drawing.Point(29, 44);
            this.label_idClient.Name = "label_idClient";
            this.label_idClient.Size = new System.Drawing.Size(74, 20);
            this.label_idClient.TabIndex = 7;
            this.label_idClient.Text = "ID Client:";
            // 
            // textBox_idClient
            // 
            this.textBox_idClient.Location = new System.Drawing.Point(200, 44);
            this.textBox_idClient.Name = "textBox_idClient";
            this.textBox_idClient.Size = new System.Drawing.Size(220, 20);
            this.textBox_idClient.TabIndex = 6;
            // 
            // textBox_price
            // 
            this.textBox_price.Location = new System.Drawing.Point(200, 96);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(220, 20);
            this.textBox_price.TabIndex = 5;
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(200, 70);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(220, 20);
            this.textBox_title.TabIndex = 4;
            // 
            // textBox_idOrder
            // 
            this.textBox_idOrder.Location = new System.Drawing.Point(200, 18);
            this.textBox_idOrder.Name = "textBox_idOrder";
            this.textBox_idOrder.Size = new System.Drawing.Size(220, 20);
            this.textBox_idOrder.TabIndex = 3;
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_price.Location = new System.Drawing.Point(29, 96);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(48, 20);
            this.label_price.TabIndex = 2;
            this.label_price.Text = "Price:";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(29, 70);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(42, 20);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "Title:";
            // 
            // label_idOrder
            // 
            this.label_idOrder.AutoSize = true;
            this.label_idOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_idOrder.Location = new System.Drawing.Point(29, 18);
            this.label_idOrder.Name = "label_idOrder";
            this.label_idOrder.Size = new System.Drawing.Size(74, 20);
            this.label_idOrder.TabIndex = 0;
            this.label_idOrder.Text = "ID Order:";
            // 
            // label_manage
            // 
            this.label_manage.AutoSize = true;
            this.label_manage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_manage.Location = new System.Drawing.Point(540, 320);
            this.label_manage.Name = "label_manage";
            this.label_manage.Size = new System.Drawing.Size(90, 25);
            this.label_manage.TabIndex = 4;
            this.label_manage.Text = "Manage";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(860, 253);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button_refresh);
            this.panel1.Controls.Add(this.button_search);
            this.panel1.Controls.Add(this.textBox_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 50);
            this.panel1.TabIndex = 0;
            // 
            // button_refresh
            // 
            this.button_refresh.BackgroundImage = global::TestDB.Properties.Resources.icons8_update_left_rotation_20;
            this.button_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_refresh.Location = new System.Drawing.Point(648, 15);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(20, 20);
            this.button_refresh.TabIndex = 4;
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_search
            // 
            this.button_search.BackgroundImage = global::TestDB.Properties.Resources.icons8_search_20;
            this.button_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_search.Location = new System.Drawing.Point(674, 15);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(20, 20);
            this.button_search.TabIndex = 3;
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // textBox_search
            // 
            this.textBox_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_search.Location = new System.Drawing.Point(700, 15);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(135, 20);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // OrdersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdersPage";
            this.Text = "Orders Page";
            this.Load += new System.EventHandler(this.DepPage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_write)).EndInit();
            this.panel_manage.ResumeLayout(false);
            this.panel_write.ResumeLayout(false);
            this.panel_write.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox_write;
        private System.Windows.Forms.Label label_write;
        private System.Windows.Forms.Panel panel_manage;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_newNote;
        private System.Windows.Forms.Panel panel_write;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.TextBox textBox_idOrder;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_idOrder;
        private System.Windows.Forms.Label label_manage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Label label_idClient;
        private System.Windows.Forms.TextBox textBox_idClient;
    }
}