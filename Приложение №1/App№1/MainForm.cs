using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fReg = new Form1();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fReg = new Form2();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fReg = new Form3();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            this.Hide();
        }
    }
}
