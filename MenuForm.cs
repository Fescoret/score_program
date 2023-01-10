using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaTap
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void buttonUserChange_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            labelLogin.Text = SessionData.user_login;
            labelMail.Text = SessionData.user_mail;
            labelScore.Text = SessionData.user_score + " сим/мин";
            string pass = "";
            for (int i = 0; i < SessionData.user_pass.Length; i++) pass += "*";
            labelPassword.Text = pass;
            buttonLoginChange.Location = new Point(labelLogin.Location.X 
                + labelLogin.Size.Width + 5, labelLogin.Location.Y);
            pictureBox2.Location = new Point(labelMail.Location.X 
                + labelMail.Size.Width + 5, labelMail.Location.Y);
            pictureBox3.Location = new Point(labelPassword.Location.X 
                + labelPassword.Size.Width + 5, labelPassword.Location.Y);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.LightGray;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.White;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.LightGray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.White;
        }

        private void buttonLoginChange_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginChangeForm loginChangeForm = new LoginChangeForm();
            loginChangeForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            MailChangeForm mailChangeForm = new MailChangeForm();
            mailChangeForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            PassChangeForm passChangeForm = new PassChangeForm();
            passChangeForm.Show();
        }

        private void buttonScores_Click(object sender, EventArgs e)
        {
            this.Close();
            ScoreViewForm scoreViewForm = new ScoreViewForm();
            scoreViewForm.Show();
        }
    }
}
