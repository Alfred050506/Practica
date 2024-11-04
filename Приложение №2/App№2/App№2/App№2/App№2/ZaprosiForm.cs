using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_2
{
    public partial class ZaprosiForm : Form
    {
        public ZaprosiForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form fReg = new MainForm();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(ZaprosiForm_FormClosed);
            this.Hide();
        }

        private void ZaprosiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ZaprosiForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fReg = new Zaprosi1Form();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(ZaprosiForm_FormClosed);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fReg = new Zaprosi2Form();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(ZaprosiForm_FormClosed);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fReg = new Zaprosi3Form();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(ZaprosiForm_FormClosed);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form fReg = new Zaprosi4Form();
            fReg.Show();
            fReg.FormClosed += new FormClosedEventHandler(ZaprosiForm_FormClosed);
            this.Hide();
        }
    }
}
