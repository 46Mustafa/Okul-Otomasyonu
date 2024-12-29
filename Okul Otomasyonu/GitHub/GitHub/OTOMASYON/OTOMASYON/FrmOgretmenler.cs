using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace OTOMASYON
{
    public partial class FrmOgretmenler : Form

    {

        public FrmOgretmenler()
        {
            InitializeComponent();  
        }
  

     
        SqlBaglantisi bgl= new SqlBaglantisi();

        void listele() 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter   da = new SqlDataAdapter("select * from TBL_OGRETMENLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ilekle()
        {
            SqlCommand komut = new SqlCommand("select * from TBL_İLLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmb1.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        void bransgetir() 
        {
            SqlCommand komut = new SqlCommand("select * from TBL_BRANSLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbBrans.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();


            
        }

        void temizle()
        {
            TxtId.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            msktc1.Text = "";
            maskedTextBox2.Text = ""; 
            TxtMail.Text = "";
            cmb1.Text = "";
            comboBoxEdit2.Text = "";
            RchAdres.Text = "";
            CmbBrans.Text = "";
            PcrResim.ImageLocation = "";


        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
           listele();
            ilekle();
            bransgetir();
          
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.Text = "";

            SqlCommand komut = new SqlCommand("select * from TBL_İLCELER where sehirid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmb1.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxEdit2.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_OGRETMENLER(OGRTAD,OGRTSOYAD,OGRTTC,OGRTTEL,OGRTMAIL,OGRTIL,OGRTILCE,OGRTADRES,OGRTBRANS,OGRTFOTO) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@P10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textEdit2.Text);
            komut.Parameters.AddWithValue("@p2", textEdit3.Text);
            komut.Parameters.AddWithValue("@p3", msktc1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmb1.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxEdit2.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres. Text);
            komut.Parameters.AddWithValue("@p9", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p10",Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Eklendi!", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
              TxtId.Text=dr["OGRTID"].ToString();
                textEdit2.Text=dr["OGRTAD"].ToString();
                textEdit3.Text=dr["OGRTSOYAD"].ToString();
                msktc1.Text = dr["OGRTTC"].ToString();
                maskedTextBox2.Text = dr["OGRTTEL"].ToString();
                TxtMail.Text = dr["OGRTMAIL"].ToString();
                cmb1.Text = dr["OGRTIL"].ToString();
                comboBoxEdit2.Text = dr["OGRTILCE"].ToString();
                RchAdres.Text = dr["OGRTADRES"].ToString();
                CmbBrans.Text = dr["OGRTBRANS"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\"+ dr["OGRTFOTO"].ToString();
                PcrResim.ImageLocation = yeniyol;


            }
        }

        public string yeniyol; 
        

        
        private void BtnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası | *.jpg;*png;*nef | Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu= dosya.FileName;
            yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\  " + "\\resimler\\"+ Guid.NewGuid().ToString()+".jpg";
            File.Copy(dosyayolu, yeniyol);
            PcrResim.ImageLocation = yeniyol;
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_OGRETMENLER set OGRTAD=@P1,OGRTSOYAD=@P2, OGRTTC=@P3, OGRTTEL=@P4 , OGRTMAIL=@P5, OGRTIL=@P6, OGRTILCE=@P7, OGRTADRES=@P8, OGRTBRANS=@P9, OGRTFOTO=@P10 where OGRTID=@P11", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", textEdit2.Text);
            komut.Parameters.AddWithValue("@p2", textEdit3.Text);
            komut.Parameters.AddWithValue("@p3", msktc1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmb1.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxEdit2.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p11", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand KOMUT = new SqlCommand("delete from TBL_OGRETMENLER where OGRTID=@P1",bgl.baglanti());
            KOMUT.Parameters.AddWithValue("@p1", TxtId.Text);
            KOMUT.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void PcrResim_Click(object sender, EventArgs e)
        {

        }
    }
}
