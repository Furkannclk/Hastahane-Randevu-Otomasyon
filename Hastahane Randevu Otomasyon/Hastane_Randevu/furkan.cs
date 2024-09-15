using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Hastane_Randevu
{
    class furkan
    {
        SqlConnection conn = new SqlConnection(@"server = CELOO\SQLEXPRESS; initial catalog = hastanerandevu; integrated security = true");


        public void lbllistele(ListBox lb, string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql,conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            lb.DataSource = tablo;
            lb.ValueMember = tablo.Columns[0].ColumnName;
            lb.DisplayMember = tablo.Columns[1].ColumnName;
        }

        public void randevu_al(string hasta, string tc, string doktorno, string tarih, string saatno)
        {
            string sql = "insert into randevular (hasta,tc,doktorno,tarih,saatno) values ('" + hasta + "','" + tc + "','" + doktorno + "','" + tarih + "','" + saatno + "')";
            SqlCommand komut = new SqlCommand(sql, conn);
            conn.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Randevu kaydedildi");
            conn.Close();
        }

        public void dgvlistele(DataGridView dgv)
        {
            string sql = "select r.randevuno, r.hasta, r.tc, d.doktor, r.tarih, s.saatler from randevular as r,doktorlar as d,saatler as s where d.doktorno=r.doktorno and r.saatno=s.saatno";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dgv.DataSource = tablo;
            dgv.Columns[0].Width = 50;
            dgv.Columns[0].HeaderText = "NO";

        }

    }
}
