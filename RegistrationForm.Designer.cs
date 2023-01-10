namespace AlphaTap
{
    partial class RegistrationForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.passField2 = new System.Windows.Forms.TextBox();
            this.mailField = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.passField = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.loginField = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Controls.Add(this.header);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 62);
            this.topPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.MediumPurple;
            this.closeButton.Location = new System.Drawing.Point(780, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Х";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.ForeColor = System.Drawing.Color.MediumPurple;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(800, 62);
            this.header.TabIndex = 0;
            this.header.Text = "РЕГИСТРАЦИЯ";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            this.header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.header_MouseMove);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.MediumTurquoise;
            this.mainPanel.Controls.Add(this.labelLogin);
            this.mainPanel.Controls.Add(this.buttonRegister);
            this.mainPanel.Controls.Add(this.passField2);
            this.mainPanel.Controls.Add(this.mailField);
            this.mainPanel.Controls.Add(this.pictureBox4);
            this.mainPanel.Controls.Add(this.passField);
            this.mainPanel.Controls.Add(this.pictureBox2);
            this.mainPanel.Controls.Add(this.loginField);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(319, 405);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(161, 18);
            this.labelLogin.TabIndex = 8;
            this.labelLogin.Text = "Уже есть аккаунт?";
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            this.labelLogin.MouseEnter += new System.EventHandler(this.labelLogin_MouseEnter);
            this.labelLogin.MouseLeave += new System.EventHandler(this.labelLogin_MouseLeave);
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.White;
            this.buttonRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.Color.MediumPurple;
            this.buttonRegister.Location = new System.Drawing.Point(250, 340);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(300, 46);
            this.buttonRegister.TabIndex = 6;
            this.buttonRegister.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // passField2
            // 
            this.passField2.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passField2.ForeColor = System.Drawing.Color.Gray;
            this.passField2.Location = new System.Drawing.Point(150, 270);
            this.passField2.MaxLength = 24;
            this.passField2.Name = "passField2";
            this.passField2.Size = new System.Drawing.Size(500, 46);
            this.passField2.TabIndex = 5;
            this.passField2.Text = "Повторите пароль";
            this.passField2.Enter += new System.EventHandler(this.passField2_Enter);
            this.passField2.Leave += new System.EventHandler(this.passField2_Leave);
            // 
            // mailField
            // 
            this.mailField.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailField.ForeColor = System.Drawing.Color.Gray;
            this.mailField.Location = new System.Drawing.Point(150, 150);
            this.mailField.MaxLength = 24;
            this.mailField.Name = "mailField";
            this.mailField.Size = new System.Drawing.Size(500, 46);
            this.mailField.TabIndex = 3;
            this.mailField.Text = "Введите почту";
            this.mailField.Enter += new System.EventHandler(this.mailField_Enter);
            this.mailField.Leave += new System.EventHandler(this.mailField_Leave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::AlphaTap.Properties.Resources.mail_icon;
            this.pictureBox4.Location = new System.Drawing.Point(90, 150);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(46, 46);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // passField
            // 
            this.passField.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passField.ForeColor = System.Drawing.Color.Gray;
            this.passField.Location = new System.Drawing.Point(150, 210);
            this.passField.MaxLength = 24;
            this.passField.Name = "passField";
            this.passField.Size = new System.Drawing.Size(500, 46);
            this.passField.TabIndex = 4;
            this.passField.Text = "Введите пароль";
            this.passField.Enter += new System.EventHandler(this.passField_Enter);
            this.passField.Leave += new System.EventHandler(this.passField_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AlphaTap.Properties.Resources.lock_icon;
            this.pictureBox2.Location = new System.Drawing.Point(90, 210);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // loginField
            // 
            this.loginField.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginField.ForeColor = System.Drawing.Color.Gray;
            this.loginField.Location = new System.Drawing.Point(150, 90);
            this.loginField.MaxLength = 24;
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(500, 46);
            this.loginField.TabIndex = 2;
            this.loginField.Text = "Введите логин";
            this.loginField.Enter += new System.EventHandler(this.loginField_Enter);
            this.loginField.Leave += new System.EventHandler(this.loginField_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AlphaTap.Properties.Resources.user_icon;
            this.pictureBox1.Location = new System.Drawing.Point(90, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.topPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox passField2;
        private System.Windows.Forms.TextBox mailField;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labelLogin;
    }
}