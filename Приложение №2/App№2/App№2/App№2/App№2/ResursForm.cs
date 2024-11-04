using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace App_2
{
    public partial class ResursForm : Form
    {
        private SQLiteConnection sqliteConn;
        public ResursForm()
        {
            InitializeComponent();
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            // Установите соединение с базой данных
            sqliteConn = new SQLiteConnection("Data Source=MainDb.db;Version=3;");
            try
            {
                sqliteConn.Open();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения: " + ex.Message);
            }
        }
        private void LoadData()
        {
            // SQL запрос для выборки данных
            string query = "SELECT * FROM Queue";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, sqliteConn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (sqliteConn != null)
            {
                sqliteConn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form fReg = new MainForm();
           fReg.Show();
           fReg.FormClosed += new FormClosedEventHandler(ResursForm_FormClosed);
           this.Hide();
        }

        private void ResursForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ResursForm_Load(object sender, EventArgs e)
        {

        }
    }
}
