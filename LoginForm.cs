using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaTap
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Purple;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.MediumPurple;
        }

        Point lastPoint;
        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;

            ScoreDB db = new ScoreDB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @log", db.GetConnection());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;

            db.OpenConnection();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MySqlCommand command0 = new MySqlCommand("SELECT `password` FROM `users` WHERE `login` = @log", db.GetConnection());
                command0.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
                MySqlCommand command1 = new MySqlCommand("SELECT `salt` FROM `users` WHERE `login` = @log", db.GetConnection());
                command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
                MySqlCommand command2 = new MySqlCommand("SELECT `iv` FROM `users` WHERE `login` = @log", db.GetConnection());
                command2.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
                MySqlCommand command3 = new MySqlCommand("SELECT `keyBytes` FROM `users` WHERE `login` = @log", db.GetConnection());
                command3.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;

                byte[] pass = Encoding.Default.GetBytes(command0.ExecuteScalar().ToString());
                byte[] salt = Encoding.Default.GetBytes(command1.ExecuteScalar().ToString());
                byte[] iv = Encoding.Default.GetBytes(command2.ExecuteScalar().ToString());
                string key = command3.ExecuteScalar().ToString();

                string decrypted = Encoding.Default.GetString(PasswordUtils.Decrypt(pass, key, salt, iv));

                if(decrypted == passField.Text)
                {
                    MySqlCommand command4 = new MySqlCommand("SELECT `mail` FROM `users` WHERE `login` = @log", db.GetConnection());
                    command4.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
                    MySqlCommand command5 = new MySqlCommand("SELECT `max_score` FROM `users` WHERE `login` = @log", db.GetConnection());
                    command5.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;

                    SessionData.user_login = loginField.Text;
                    SessionData.user_pass = passField.Text;
                    SessionData.user_mail = command4.ExecuteScalar().ToString();
                    SessionData.user_score = command5.ExecuteScalar().ToString();

                    this.Hide();
                    MenuForm menuForm = new MenuForm();
                    menuForm.Show();
                }
                else
                {
                    MessageBox.Show("Пароль указан неверно");
                }
            } else
            {
                MessageBox.Show("Пользователя с таким логином не существует");
            }
            db.CloseConnection();
        }

        private void labelRegister_MouseEnter(object sender, EventArgs e)
        {
            labelRegister.ForeColor = Color.Gray;
        }

        private void labelRegister_MouseLeave(object sender, EventArgs e)
        {
            labelRegister.ForeColor = Color.White;
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Логин")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.ForeColor = Color.Gray;
                loginField.Text = "Логин";
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Пароль")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
                passField.UseSystemPasswordChar = true;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.UseSystemPasswordChar = false;
                passField.ForeColor = Color.Gray;
                passField.Text = "Пароль";
            }
        }
    }
}
