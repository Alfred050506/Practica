using System;
using System.Windows.Forms;

namespace App_2
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthoForm());
        }
    }
    static class DataBase
    {
        public static string connectionString = @"Data Source=MainDB.db;Integrated Security=False; MultipleActiveResultSets=True";
    }
}
