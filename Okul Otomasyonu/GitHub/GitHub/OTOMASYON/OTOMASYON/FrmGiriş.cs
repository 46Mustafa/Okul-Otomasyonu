using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace OTOMASYON
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        dbokulEntities db = new dbokulEntities();

        private void btnyonetici_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select OGRTTC,OGRTSIFRE from TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID= TBL_OGRETMENLER.OGRTID  where OGRTTC=@p1 and  OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktece.Text);
            komut.Parameters.AddWithValue("@p2", txtparola.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) 
            {
               FrmAnaModul frm1 = new FrmAnaModul();
                frm1.Show();
                this.Hide();    

            }
            else
            {
                MessageBox.Show("hatalı bilgiler!!");
                msktece.Text = "";
                txtparola.Text = "";

            }
            bgl.baglanti().Close();
        }

        private void btnogretici_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select OGRTTC,OGRTSIFRE from TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID= TBL_OGRETMENLER.OGRTID  where OGRTTC=@p1 and  OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktece.Text);
            komut.Parameters.AddWithValue("@p2", txtparola.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Frmogretmenanamodul frm2 = new Frmogretmenanamodul();
                frm2.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("hatalı bilgiler!!");
                msktece.Text = "";
                txtparola.Text = "";

            }
            bgl.baglanti().Close();
        }

        private void btnogrenici_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBL_OGRAYARLAR
                        join d2 in db.TBL_OGRENCİLER
                        on d1.AYARLAROGRID equals d2.OGRID
                        where d2.OGRTC==msktece.Text &&
                              d1.OGRSIFRE== txtparola.Text
                              select new { };
            if (sorgu.Any())
            {
                Frmogrencianamodul frm3 = new Frmogrencianamodul();
                frm3.Show();
                this.Hide();

            }
            else 
            {
                MessageBox.Show("hatalı bilgiler!!");
                msktece.Text = ""; 
                txtparola.Text = "";
            }

                        
        }
    }


}
