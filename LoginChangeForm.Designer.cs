namespace AlphaTap
{
    partial class LoginChangeForm
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
            this.buttonChange = new System.Windows.Forms.Button();
            this.passNew1 = new System.Windows.Forms.TextBox();
            this.loginNew = new System.Windows.Forms.TextBox();
            this.Header = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.passNew2 = new System.Windows.Forms.TextBox();
            this.Header.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.White;
            this.buttonChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChange.ForeColor = System.Drawing.Color.MediumPurple;
            this.buttonChange.Location = new System.Drawing.Point(618, 392);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(170, 46);
            this.buttonChange.TabIndex = 6;
            this.buttonChange.Text = "ПРИМЕНИТЬ";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // passNew1
            // 
            this.passNew1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passNew1.ForeColor = System.Drawing.Color.Gray;
            this.passNew1.Location = new System.Drawing.Point(150, 180);
            this.passNew1.Name = "passNew1";
            this.passNew1.Size = new System.Drawing.Size(500, 46);
            this.passNew1.TabIndex = 4;
            this.passNew1.Text = "Пароль";
            this.passNew1.Enter += new System.EventHandler(this.passNew1_Enter);
            this.passNew1.Leave += new System.EventHandler(this.passNew1_Leave);
            // 
            // loginNew
            // 
            this.loginNew.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginNew.ForeColor = System.Drawing.Color.Gray;
            this.loginNew.Location = new System.Drawing.Point(150, 120);
            this.loginNew.Name = "loginNew";
            this.loginNew.Size = new System.Drawing.Size(500, 46);
            this.loginNew.TabIndex = 2;
            this.loginNew.Text = "Новый логин";
            this.loginNew.Enter += new System.EventHandler(this.loginNew_Enter);
            this.loginNew.Leave += new System.EventHandler(this.loginNew_Leave);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.MediumTurquoise;
            this.Header.Controls.Add(this.closeButton);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(800, 41);
            this.Header.TabIndex = 0;
            this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
            this.Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(774, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 27);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Х";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.buttonCancel);
            this.mainPanel.Controls.Add(this.passNew2);
            this.mainPanel.Controls.Add(this.buttonChange);
            this.mainPanel.Controls.Add(this.passNew1);
            this.mainPanel.Controls.Add(this.loginNew);
            this.mainPanel.Controls.Add(this.Header);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.White;
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.MediumPurple;
            this.buttonCancel.Location = new System.Drawing.Point(12, 392);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(170, 46);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "НАЗАД";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // passNew2
            // 
            this.passNew2.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passNew2.ForeColor = System.Drawing.Color.Gray;
            this.passNew2.Location = new System.Drawing.Point(150, 240);
            this.passNew2.Name = "passNew2";
            this.passNew2.Size = new System.Drawing.Size(500, 46);
            this.passNew2.TabIndex = 7;
            this.passNew2.Text = "Повторите пароль";
            this.passNew2.Enter += new System.EventHandler(this.passNew2_Enter);
            this.passNew2.Leave += new System.EventHandler(this.passNew2_Leave);
            // 
            // LoginChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PassChangeForm";
            this.Header.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.TextBox passNew1;
        private System.Windows.Forms.TextBox loginNew;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox passNew2;
    }
}