using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace App_2
{
    public partial class AuthoForm : Form
    {
        private readonly string connectionString = "Data Source=MainDB.db;Version=3;";
        public AuthoForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form fReg = new RegForm();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(AuthoForm_FormClosed);
            this.Hide();
        }

        private void AuthoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Vhod_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM Users WHERE login=@login AND pass=@pass";
            string sqlUpdate = "UPDATE Users SET Date = Date('now') WHERE login=@login AND pass=@pass";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand selectCommand = new SQLiteCommand(sqlSelect, connection))
                {
                    selectCommand.Parameters.AddWithValue("@login", textBox1.Text);
                    selectCommand.Parameters.AddWithValue("@pass", textBox2.Text);
                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reader.Close();

                            using (SQLiteCommand updateCommand = new SQLiteCommand(sqlUpdate, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@login", textBox1.Text);
                                updateCommand.Parameters.AddWithValue("@pass", textBox2.Text);
                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Вход в главную форму
                                    Form fMain = new MainForm();
                                    fMain.Show();
                                    fMain.FormClosed += new FormClosedEventHandler(AuthoForm_FormClosed);
                                    this.Hide();
                                }
                                else
                                {
                                    // Не удалось обновить дату последнего входа в систему
                                    MessageBox.Show("Не удалось обновить дату последнего входа в систему. Пожалуйста, попробуйте еще раз.");
                                }
                            }
                        }
                        else
                        {
                            // Неверный логин или пароль
                            MessageBox.Show("Неверный логин или пароль, повторите попытку снова");
                        }
                    }
                }
            }
        }
    }
}