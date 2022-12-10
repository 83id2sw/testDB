namespace TestDB
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_exit = new System.Windows.Forms.Label();
            this.label_authorize = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_enter = new System.Windows.Forms.Button();
            this.button_register = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_exit);
            this.panel1.Controls.Add(this.label_authorize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_exit
            // 
            this.label_exit.AutoSize = true;
            this.label_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_exit.Location = new System.Drawing.Point(575, 5);
            this.label_exit.Name = "label_exit";
            this.label_exit.Size = new System.Drawing.Size(14, 13);
            this.label_exit.TabIndex = 1;
            this.label_exit.Text = "X";
            this.label_exit.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_authorize
            // 
            this.label_authorize.AutoSize = true;
            this.label_authorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label_authorize.ForeColor = System.Drawing.Color.Transparent;
            this.label_authorize.Location = new System.Drawing.Point(250, 40);
            this.label_authorize.Name = "label_authorize";
            this.label_authorize.Size = new System.Drawing.Size(104, 26);
            this.label_authorize.TabIndex = 0;
            this.label_authorize.Text = "Authorize";
            this.label_authorize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_authorize.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_login
            // 
            this.textBox_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_login.Location = new System.Drawing.Point(220, 140);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(165, 20);
            this.textBox_login.TabIndex = 1;
            this.textBox_login.TextChanged += new System.EventHandler(this.textBox_login_TextChanged);
            this.textBox_login.Enter += new System.EventHandler(this.textBox_login_Enter);
            this.textBox_login.Leave += new System.EventHandler(this.textBox_login_Leave);
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Location = new System.Drawing.Point(220, 170);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(165, 20);
            this.textBox_password.TabIndex = 2;
            this.textBox_password.Enter += new System.EventHandler(this.textBox_password_Enter);
            this.textBox_password.Leave += new System.EventHandler(this.textBox_password_Leave);
            // 
            // button_enter
            // 
            this.button_enter.Location = new System.Drawing.Point(250, 250);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(100, 23);
            this.button_enter.TabIndex = 3;
            this.button_enter.Text = "Enter";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click);
            // 
            // button_register
            // 
            this.button_register.Location = new System.Drawing.Point(250, 220);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(100, 23);
            this.button_register.TabIndex = 4;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = true;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_authorize;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Label label_exit;
    }
}

