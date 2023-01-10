using MySqlConnector;
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
    public partial class LoginChangeForm : Form
    {
        public LoginChangeForm()
        {
            InitializeComponent();
        }

        private void passNew1_Enter(object sender, EventArgs e)
        {
            if (passNew1.Text == "Пароль")
            {
                passNew1.Text = "";
                passNew1.ForeColor = Color.Black;
                passNew1.UseSystemPasswordChar = true;
            }
        }

        private void passNew1_Leave(object sender, EventArgs e)
        {
            if (passNew1.Text == "")
            {
                passNew1.ForeColor = Color.Gray;
                passNew1.Text = "Пароль";
                passNew1.UseSystemPasswordChar = false;
            }
        }

        private void passNew2_Enter(object sender, EventArgs e)
        {
            if (passNew2.Text == "Повторите пароль")
            {
                passNew2.Text = "";
                passNew2.ForeColor = Color.Black;
                passNew2.UseSystemPasswordChar = true;
            }
        }

        private void passNew2_Leave(object sender, EventArgs e)
        {
            if (passNew2.Text == "")
            {
                passNew2.ForeColor = Color.Gray;
                passNew2.Text = "Повторите пароль";
                passNew2.UseSystemPasswordChar = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Gray;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void loginNew_Enter(object sender, EventArgs e)
        {
            if (loginNew.Text == "Новый логин")
            {
                loginNew.Text = "";
                loginNew.ForeColor = Color.Black;
            }
        }

        private void loginNew_Leave(object sender, EventArgs e)
        {
            if (loginNew.Text == "")
            {
                loginNew.ForeColor = Color.Gray;
                loginNew.Text = "Новый логин";
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            ScoreDB db = new ScoreDB();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `login` = @new WHERE `login` = @old;", db.GetConnection());
            command.Parameters.Add("@new", MySqlDbType.VarChar).Value = loginNew.Text;
            command.Parameters.Add("@old", MySqlDbType.VarChar).Value = SessionData.user_login;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @log", db.GetConnection());
            command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = loginNew.Text;

            adapter.SelectCommand = command1;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                if (passNew1.Text == SessionData.user_pass || passNew2.Text == SessionData.user_pass)
                {
                    if (passNew1.Text == passNew2.Text)
                    {
                        db.OpenConnection();
                        command.ExecuteNonQuery();
                        db.CloseConnection();
                        SessionData.user_login = loginNew.Text;
                        this.Close();
                        MenuForm menuForm = new MenuForm();
                        menuForm.Show();
                    }
                    else MessageBox.Show("Пароли не совпадают");
                }
                else MessageBox.Show("Неверный пароль");
            }
            else MessageBox.Show("Пользователь с таким логином уже существует");
        }
    }
}
