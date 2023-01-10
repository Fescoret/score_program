using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;
using MySqlConnector;

namespace AlphaTap
{
    public partial class MainForm : Form
    {
        String testString = "Текст, проверяющий приложение. ";
        int startTime = 120;
        int labelTime = 120;
        int totalSymbols = 0;
        StreamReader sr = new StreamReader("\\VSrepos\\AlphaTap\\AlphaTap\\text\\piknik-na-obochine.txt");

        public MainForm()
        {
            InitializeComponent();

            Random random = new Random();
            int rnd = random.Next(0, 500);
            for (int i = 0; i < rnd; i++) sr.ReadLine();
            testString = sr.ReadLine() + " ";
            if (Words(testString) < 3) testString += sr.ReadLine() + " ";
            richTextBox1.Text = testString;
            labelTimer.Text = MakeTime(labelTime);
        }

        List<char> charsRu = new List<char> { 'ф', 'и', 'с', 'в', 'у', 'а',
            'п', 'р', 'ш', 'о', 'л', 'д', 'ь', 'т', 'щ', 'з', 'й', 'к', 'ы',
            'е', 'г', 'м', 'ц', 'ч', 'н', 'я' };
        List<char> charsNum = new List<char> { ')', '!', '"', '№', ';',
            '%', ':', '?', '*', '(' };
        int index = 0;
        Boolean isUpper = false;

        int Words(string s)
        {
            int words = 0;
            string str = s;
            while (str.Length > 0)
            {
                words++;
                str = str.Substring(str.IndexOf(" ")+1);
            }
            return words;
        }

        private void addSymbols(int num)
        {
            totalSymbols += num;
            labelSymbols.Text = totalSymbols.ToString();
        }

        string MakeTime(int num)
        {
            int minutes = num / 60;
            int seconds = num % 60;
            string min;
            string sec;
            if (minutes > 9) min = minutes.ToString();
            else min = "0" + minutes.ToString();
            if (seconds > 9) sec = seconds.ToString();
            else sec = "0" + seconds.ToString();
            string output = min + ":" + sec;
            return output;
        }

        private void CharCheck(char chr)
        {
            if (testString[index] == chr)
            {
                richTextBox1.Select(index, 1);
                richTextBox1.SelectionColor = Color.Green;
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, index)
                    + chr.ToString()
                    + richTextBox1.Text.Substring(index + 1);
                for (int i = 0; i <= index; i++)
                {
                    if (richTextBox1.Text[i] == testString[i])
                    {
                        richTextBox1.Select(i, 1);
                        richTextBox1.SelectionColor = Color.Green;
                    } else
                    {
                        richTextBox1.Select(i, 1);
                        richTextBox1.SelectionColor = Color.Red;
                    }
                }
            }
        }

        private void CharState(char chr)
        {
            if (isUpper)
                CharCheck(Char.ToUpper(chr));
            else
                CharCheck(chr);
            index += 1;
            addSymbols(1);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                CharState(charsRu[e.KeyValue - 65]);
            } 
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                if (isUpper)
                    CharCheck(charsNum[e.KeyValue - 48]);
                else
                    CharCheck(Convert.ToChar(e.KeyValue));
                index += 1;
                addSymbols(1);
            }
            else if (e.KeyCode == Keys.OemOpenBrackets)
            {
                CharState('х');
            }
            else if (e.KeyCode == Keys.Oem6)
            {
                CharState('ъ');
            }
            else if (e.KeyCode == Keys.Oem1)
            {
                CharState('ж');
            }
            else if (e.KeyCode == Keys.Oem7)
            {
                CharState('э');
            }
            else if (e.KeyCode == Keys.Oemcomma)
            {
                CharState('б');
            }
            else if (e.KeyCode == Keys.OemPeriod)
            {
                CharState('ю');
            }
            else if (e.KeyCode == Keys.OemQuestion)
            {
                richTextBox1.Select(index, 1);
                if (isUpper)
                {
                    CharCheck(',');
                }
                else
                {
                    CharCheck('.');
                }
                index += 1;
                addSymbols(1);
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                richTextBox1.Select(index, 1);
                if (isUpper)
                {
                    CharCheck('_');
                }
                else
                {
                    CharCheck('—');
                }
                index += 1;
                addSymbols(1);
            }
            else if (e.KeyCode == Keys.Oemplus)
            {
                richTextBox1.Select(index, 1);
                if (isUpper)
                {
                    CharCheck('+');
                }
                else
                {
                    CharCheck('=');
                }
                index += 1;
                addSymbols(1);
            }
            else if (e.KeyCode == Keys.Oem5)
            {
                richTextBox1.Select(index, 1);
                if (isUpper)
                {
                    CharCheck('/');
                }
                else
                {
                    CharCheck('\\');
                }
                index += 1;
                addSymbols(1);
            }
            else if (e.KeyCode == Keys.Space)
            {
                int spaceIndex = testString.IndexOf(" ");
                string s1 = testString.Substring(0, spaceIndex);
                string s2 = richTextBox1.Text.Substring(0, spaceIndex);
                if (s1 == s2 && spaceIndex == index)
                {
                    testString = testString.Substring(spaceIndex+1);
                    if (Words(testString) < 3) testString += sr.ReadLine() + " ";
                    richTextBox1.Text = testString;
                    index = 0;
                    addSymbols(1);
                }
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                isUpper = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (index > 0)
                {
                    index -= 1;
                    addSymbols(-2);
                    richTextBox1.Text = richTextBox1.Text.Substring(0, index)
                    + testString[index].ToString()
                    + richTextBox1.Text.Substring(index + 1);
                    for (int i = 0; i < index; i++)
                    {
                        if (richTextBox1.Text[i] == testString[i])
                        {
                            richTextBox1.Select(i, 1);
                            richTextBox1.SelectionColor = Color.Green;
                        }
                        else
                        {
                            richTextBox1.Select(i, 1);
                            richTextBox1.SelectionColor = Color.Red;
                        }
                    }
                }
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
            {
                isUpper = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (labelTime > 0)
            {
                labelTime -= 1;
                labelTimer.Text = MakeTime(labelTime);
                labelPerMin.Text = (totalSymbols / ((startTime - labelTime) / 60.0)).ToString("#.##");
            }
            else
            {
                timer1.Enabled = false;
                this.Hide();

                //double SPM = totalSymbols / (startTime / 60.0); //symbols per minute
                double SPM = Convert.ToDouble(labelPerMin.Text);
                ScoreDB db = new ScoreDB();

                MySqlCommand command1 = new MySqlCommand("SELECT `max_score` FROM `users` WHERE `login` = @login", db.GetConnection());
                command1.Parameters.Add("@login", MySqlDbType.VarChar).Value = SessionData.user_login;

                MySqlCommand command2 = new MySqlCommand("UPDATE `users` SET `max_score` = @score WHERE `login` = @login;", db.GetConnection());
                command2.Parameters.Add("@score", MySqlDbType.VarChar).Value = SPM;
                command2.Parameters.Add("@login", MySqlDbType.VarChar).Value = SessionData.user_login;

                db.OpenConnection();

                double last_score = Convert.ToDouble(command1.ExecuteScalar().ToString());

                if (last_score < SPM)
                {
                    command2.ExecuteNonQuery();
                    SessionData.user_score = SPM.ToString();
                }

                db.CloseConnection();

                MessageBox.Show("Символов: " + totalSymbols.ToString() +
                    "\nСимволов в минуту: " + SPM.ToString() +
                    "\nПрошлый рекорд: " + last_score.ToString());
                MenuForm menuForm = new MenuForm();
                menuForm.Show();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Purple;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.MediumPurple;
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if(!timer1.Enabled) timer1.Enabled = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }
    }
}
