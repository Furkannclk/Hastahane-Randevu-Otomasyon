using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Randevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        furkan clk = new furkan();
        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "select * from poller order by pol";
            clk.lbllistele(lbpolikinlik,sql);
            clk.dgvlistele(dgv);
        }

        private void lblpolikinlik_MouseClick(object sender, MouseEventArgs e)
        {
            string sql = "select * from doktorlar where polno =" + lbpolikinlik.SelectedValue.ToString();
            clk.lbllistele(lbdoktor, sql);
            txtHasta.Text = "";
            txtTc.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (lbdoktor.SelectedIndex >= 0)
            {
                string doktorno, tarih;
                doktorno = lbdoktor.SelectedValue.ToString();
                tarih = dateTimePicker1.Value.ToShortDateString();
                string sql = "select * from saatler where saatno " + "not in (select saatno from randevular " + "where doktorno=" + doktorno + " and " + "tarih='" + tarih + "')";
                clk.lbllistele(lbsaat,sql);
            }

        }

        private void btnRandevu_Click(object sender, EventArgs e)
        {
            clk.randevu_al(txtHasta.Text, txtTc.Text, lbdoktor.SelectedValue.ToString(), dateTimePicker1.Value.ToShortDateString(), lbsaat.SelectedValue.ToString());
            clk.dgvlistele(dgv);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Emin misiniz?", "Program Kapatılıyor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.Yes)
                Application.Exit();
        }
    }
}
