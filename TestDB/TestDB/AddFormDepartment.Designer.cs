
namespace TestDB
{
    partial class AddFormDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFormDepartment));
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_telNum = new System.Windows.Forms.TextBox();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label_telNum = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.Location = new System.Drawing.Point(220, 298);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(160, 35);
            this.button_save.TabIndex = 18;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_telNum
            // 
            this.textBox_telNum.Location = new System.Drawing.Point(223, 222);
            this.textBox_telNum.Name = "textBox_telNum";
            this.textBox_telNum.Size = new System.Drawing.Size(220, 20);
            this.textBox_telNum.TabIndex = 17;
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(223, 196);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(220, 20);
            this.textBox_address.TabIndex = 16;
            // 
            // label_telNum
            // 
            this.label_telNum.AutoSize = true;
            this.label_telNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_telNum.Location = new System.Drawing.Point(52, 222);
            this.label_telNum.Name = "label_telNum";
            this.label_telNum.Size = new System.Drawing.Size(146, 20);
            this.label_telNum.TabIndex = 15;
            this.label_telNum.Text = "Telephone number:";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_address.Location = new System.Drawing.Point(52, 196);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(72, 20);
            this.label_address.TabIndex = 14;
            this.label_address.Text = "Address:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 80);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TestDB.Properties.Resources.icons8_edit_property_44;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 44);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Note:";
            // 
            // AddFormDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textBox_telNum);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label_telNum);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFormDepartment";
            this.Text = "AddDepartment";
            this.Load += new System.EventHandler(this.AddFormDepartment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_telNum;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label_telNum;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}