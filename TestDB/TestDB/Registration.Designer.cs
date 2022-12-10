
namespace TestDB
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_register = new System.Windows.Forms.Label();
            this.textBox_rLogin = new System.Windows.Forms.TextBox();
            this.textBox_rPass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_register);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_register
            // 
            this.label_register.AutoSize = true;
            this.label_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_register.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_register.Location = new System.Drawing.Point(240, 40);
            this.label_register.Name = "label_register";
            this.label_register.Size = new System.Drawing.Size(127, 25);
            this.label_register.TabIndex = 0;
            this.label_register.Text = "Registration";
            this.label_register.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_rLogin
            // 
            this.textBox_rLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_rLogin.Location = new System.Drawing.Point(220, 140);
            this.textBox_rLogin.Name = "textBox_rLogin";
            this.textBox_rLogin.Size = new System.Drawing.Size(165, 20);
            this.textBox_rLogin.TabIndex = 1;
            this.textBox_rLogin.TextChanged += new System.EventHandler(this.textBox_rLogin_TextChanged);
            // 
            // textBox_rPass
            // 
            this.textBox_rPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_rPass.Location = new System.Drawing.Point(220, 170);
            this.textBox_rPass.Name = "textBox_rPass";
            this.textBox_rPass.Size = new System.Drawing.Size(165, 20);
            this.textBox_rPass.TabIndex = 2;
            this.textBox_rPass.TextChanged += new System.EventHandler(this.textBox_rPass_TextChanged);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(250, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(250, 250);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_rPass);
            this.Controls.Add(this.textBox_rLogin);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registration";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_register;
        private System.Windows.Forms.TextBox textBox_rLogin;
        private System.Windows.Forms.TextBox textBox_rPass;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_cancel;
    }
}