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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AlphaTap
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            loginField.Text = "Введите логин";
            mailField.Text = "Введите почту";
            passField.Text = "Введите пароль";
            passField2.Text = "Повторите пароль";
        }

        bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
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
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if(loginField.Text == "Введите логин")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if(loginField.Text == "")
            {
                loginField.ForeColor = Color.Gray;
                loginField.Text = "Введите логин";
            }
                
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if(passField.Text == "Введите пароль")
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
                passField.Text = "Введите пароль";
            }
        }

        private void mailField_Enter(object sender, EventArgs e)
        {
            mailField.ForeColor = Color.Black;
            if (mailField.Text == "Введите почту")
            {
                mailField.Text = "";
            }
        }

        private void mailField_Leave(object sender, EventArgs e)
        {
            if (mailField.Text == "")
            {
                mailField.ForeColor = Color.Gray;
                mailField.Text = "Введите почту";
            }
            else
            {
                if (!isValid(mailField.Text))
                {
                    mailField.ForeColor = Color.Red;
                }
            }
        }

        private void passField2_Enter(object sender, EventArgs e)
        {
            if (passField2.Text == "Повторите пароль")
            {
                passField2.Text = "";
                passField2.ForeColor = Color.Black;
                passField2.UseSystemPasswordChar = true;
            }
        }

        private void passField2_Leave(object sender, EventArgs e)
        {
            if (passField2.Text == "")
            {
                passField2.UseSystemPasswordChar = false;
                passField2.ForeColor = Color.Gray;
                passField2.Text = "Повторите пароль";
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (passField.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            if (mailField.Text == "Введите почту")
            {
                MessageBox.Show("Введите почту!");
                return;
            }

            if (!isValid(mailField.Text))
            {
                MessageBox.Show("Некорректная почта!");
                return;
            }

            if (passField2.Text == "Повторите пароль")
            {
                MessageBox.Show("Повторите пароль!");
                return;
            }

            if(passField.Text != passField2.Text)
            {
                MessageBox.Show("Пароли не совпадают! Проверьте правильность введённых данных!");
                return;
            }

            if (isUserExist())
                return;

            string password = passField.Text;
            RandomNumberGenerator rnd = RandomNumberGenerator.Create();

            byte[] salt = new byte[16];
            byte[] iv = new byte[16];
            byte[] keyByte = new byte[16];
            rnd.GetBytes(salt);
            rnd.GetBytes(iv);
            rnd.GetBytes(keyByte);
            string key = Encoding.Default.GetString(keyByte);
            byte[] pass = Encoding.UTF8.GetBytes(password);

            var encrypted = PasswordUtils.Encrypt(pass, key, salt, iv);

            ScoreDB db = new ScoreDB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `salt`, `iv`, `keyBytes`, `mail`, `max_score`) VALUES (@login, @pass, @salt, @iv, @key, @mail, 0);", db.GetConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Encoding.Default.GetString(encrypted);
            command.Parameters.Add("@salt", MySqlDbType.VarChar).Value = Encoding.Default.GetString(salt);
            command.Parameters.Add("@iv", MySqlDbType.VarChar).Value = Encoding.Default.GetString(iv);
            command.Parameters.Add("@key", MySqlDbType.VarChar).Value = key;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mailField.Text;

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Вы успешно зарегистрированы!");
            else
                MessageBox.Show("Ошибка регистрации...");

            db.CloseConnection();

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private Boolean isUserExist()
        {
            ScoreDB db = new ScoreDB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @log", db.GetConnection());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //loginField.ForeColor = Color.Red;
                MessageBox.Show("Пользователь с таким логином уже существует, введите другой.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void labelLogin_MouseEnter(object sender, EventArgs e)
        {
            labelLogin.ForeColor = Color.Gray;
        }

        private void labelLogin_MouseLeave(object sender, EventArgs e)
        {
            labelLogin.ForeColor = Color.White;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

    }
}
