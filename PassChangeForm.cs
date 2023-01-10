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
    public partial class PassChangeForm : Form
    {
        public PassChangeForm()
        {
            InitializeComponent();
        }

        private void passOld_Enter(object sender, EventArgs e)
        {
            if (passOld.Text == "Старый пароль")
            {
                passOld.Text = "";
                passOld.ForeColor = Color.Black;
                passOld.UseSystemPasswordChar = true;
            }
        }

        private void passOld_Leave(object sender, EventArgs e)
        {
            if (passOld.Text == "")
            {
                passOld.ForeColor = Color.Gray;
                passOld.Text = "Старый пароль";
                passOld.UseSystemPasswordChar = false;
            }
        }

        private void passNew1_Enter(object sender, EventArgs e)
        {
            if (passNew1.Text == "Новый пароль")
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
                passNew1.Text = "Новый пароль";
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

        private void buttonChange_Click(object sender, EventArgs e)
        {
            ScoreDB db = new ScoreDB();

            MySqlCommand command0 = new MySqlCommand("SELECT `password` FROM `users` WHERE `login` = @log", db.GetConnection());
            command0.Parameters.Add("@log", MySqlDbType.VarChar).Value = SessionData.user_login;
            MySqlCommand command1 = new MySqlCommand("SELECT `salt` FROM `users` WHERE `login` = @log", db.GetConnection());
            command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = SessionData.user_login;
            MySqlCommand command2 = new MySqlCommand("SELECT `iv` FROM `users` WHERE `login` = @log", db.GetConnection());
            command2.Parameters.Add("@log", MySqlDbType.VarChar).Value = SessionData.user_login;
            MySqlCommand command3 = new MySqlCommand("SELECT `keyBytes` FROM `users` WHERE `login` = @log", db.GetConnection());
            command3.Parameters.Add("@log", MySqlDbType.VarChar).Value = SessionData.user_login;

            db.OpenConnection();

            byte[] pass = Encoding.Default.GetBytes(command0.ExecuteScalar().ToString());
            byte[] salt = Encoding.Default.GetBytes(command1.ExecuteScalar().ToString());
            byte[] iv = Encoding.Default.GetBytes(command2.ExecuteScalar().ToString());
            string key = command3.ExecuteScalar().ToString();

            db.CloseConnection();

            string decrypted = Encoding.Default.GetString(PasswordUtils.Decrypt(pass, key, salt, iv));

            if (decrypted == passOld.Text)
            {
                if (passNew1.Text == passNew2.Text)
                {
                    string password = passNew1.Text;
                    RandomNumberGenerator rnd = RandomNumberGenerator.Create();

                    byte[] salt1 = new byte[16];
                    byte[] iv1 = new byte[16];
                    byte[] keyByte = new byte[16];
                    rnd.GetBytes(salt1);
                    rnd.GetBytes(iv1);
                    rnd.GetBytes(keyByte);
                    string key1 = Encoding.Default.GetString(keyByte);
                    byte[] pass1 = Encoding.UTF8.GetBytes(password);

                    var encrypted = PasswordUtils.Encrypt(pass1, key1, salt1, iv1);

                    MySqlCommand command = new MySqlCommand("UPDATE `users` SET `password` = @pass, `salt` = @salt, `iv` = @iv, `keyBytes` = @key WHERE `login` = @login;", db.GetConnection());

                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = SessionData.user_login;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Encoding.Default.GetString(encrypted);
                    command.Parameters.Add("@salt", MySqlDbType.VarChar).Value = Encoding.Default.GetString(salt1);
                    command.Parameters.Add("@iv", MySqlDbType.VarChar).Value = Encoding.Default.GetString(iv1);
                    command.Parameters.Add("@key", MySqlDbType.VarChar).Value = key1;

                    db.OpenConnection();
                    command.ExecuteNonQuery();
                    db.CloseConnection();

                    SessionData.user_pass = passNew1.Text;
                    this.Close();
                    MenuForm menuForm = new MenuForm();
                    menuForm.Show();
                }
                else MessageBox.Show("Новые пароли не совпадают");
            }
            else
            {
                MessageBox.Show("Нынешний пароль указан неверно");
            }
        }
    }
}
