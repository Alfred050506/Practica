using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace App_2
{
    public partial class RegForm : Form
    {
        private readonly string connectionString = "Data Source=MainDB.db;Version=3;";
        public RegForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем логин и пароль из текстовых полей и удаляем пробелы в начале и конце строк
            string Логин = textBox1.Text.Trim();
            string Пароль = textBox2.Text.Trim();
            string ФИО = textBox3.Text.Trim();

            // Проверяем, что поля логина и пароля не пустые
            if (Логин == "" || Пароль == "" || ФИО == "")
            {
                _ = MessageBox.Show("Заполните все поля, пожалуйста!");
                return;
            }

            // Проверка наличия пользователя с таким же email в базе данных
            string checkQuery = $"SELECT COUNT(*) FROM Users WHERE login='{Логин}'";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        _ = MessageBox.Show("Такой пользователь уже зарегестрирован. Пожалуйста, введите другую почту.");
                        return;
                    }
                }
                string insertQuery = "INSERT INTO Users (login, pass, fio) VALUES (@login, @pass, @fio)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, conn))
                {
                    command.Parameters.AddWithValue("@login", Логин);
                    command.Parameters.AddWithValue("@pass", Пароль);
                    command.Parameters.AddWithValue("@fio", ФИО);

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            Form fReg = new AuthoForm();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(RegForm_FormClosed);
            this.Hide();
        }

        private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
