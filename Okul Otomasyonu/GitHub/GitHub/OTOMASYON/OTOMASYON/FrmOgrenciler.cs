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
using System.IO;

namespace OTOMASYON
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
         
        SqlBaglantisi bgl=new SqlBaglantisi();


        void listele() 
        {
            // 5.sınıf
         DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute OgrenciVeli5", bgl.baglanti());
            da1.Fill(dt1);  
            GrdCtrl5.DataSource = dt1;


            //6.sınıf
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute OgrenciVeli6", bgl.baglanti());
            da2.Fill(dt2);
            GrdCtrl6.DataSource = dt2;
            
            //7.sınıf
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Execute OgrenciVeli7", bgl.baglanti());
            da3.Fill(dt3);
            GrdCtrl7.DataSource = dt3;
            
            //8.sınıf
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Execute OgrenciVeli8", bgl.baglanti());
            da4.Fill(dt4);
            GrdCtrl8.DataSource = dt4;

        }

        void velilistesi() 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select VELIID , (VELIANNE +' | ' +VELIBABA) AS 'VELI ANNE BABA' FROM TBL_VELILER",bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "VELIID";
            lookUpEdit1.Properties.DisplayMember = "VELI ANNE BABA";
            lookUpEdit1.Properties.DataSource = dt;


        }



        void sehirekle() 
        
        {
            SqlCommand komut = new SqlCommand("select * from TBL_İLLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmb1.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();

            

        }
        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTc.Text = "";
            OgrNo.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            DogTrh.Text = "";
            cmbSınıf.Text = "";
            cmb1.Text = "";
            comboBoxEdit2.Text = "";
            RchAdres.Text = "";
            pictureEdit1.Text = "";
             
        }


        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            listele();
            sehirekle();
            temizle();
            velilistesi();
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            comboBoxEdit2.Properties.Items.Clear();
            comboBoxEdit2.Text = "";

            SqlCommand KOMUT = new SqlCommand("select * from TBL_İLCELER where sehirid=@p1", bgl.baglanti());
            KOMUT.Parameters.AddWithValue("@p1", cmb1.SelectedIndex + 1);
            SqlDataReader dr = KOMUT.ExecuteReader();
            while (dr.Read())
            {
                comboBoxEdit2.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();   
            
        }
        public string cinsiyet;

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand KOMUT = new SqlCommand("insert into TBL_OGRENCİLER (OGRAD,OGRSOYAD,OGRNO,OGRSINIF,OGRDOGTAR,OGRCİNSİYET,OGRTC,OGRIL,OGRILCE,OGRADRES,OGRFOTO,OGRVELİID )  values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",bgl.baglanti());

            KOMUT.Parameters.AddWithValue("@p1", TxtAd.Text);
            KOMUT.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            KOMUT.Parameters.AddWithValue("@p3", OgrNo.Text);
            KOMUT.Parameters.AddWithValue("@p4", cmbSınıf.Text);
            KOMUT.Parameters.AddWithValue("@p5", DogTrh.Text);
            if (radioButton1.Checked == true)
            {
                KOMUT.Parameters.AddWithValue("@p6", cinsiyet = "E");
            }
            else 
            
            {
                KOMUT.Parameters.AddWithValue("@p6", cinsiyet="B");
            }
            
            KOMUT.Parameters.AddWithValue("@p7", MskTc.Text);
            KOMUT.Parameters.AddWithValue("@p8", cmb1.Text);
            KOMUT.Parameters.AddWithValue("@p9", comboBoxEdit2.Text);
            KOMUT.Parameters.AddWithValue("@p10", RchAdres.Text);
            KOMUT.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            KOMUT.Parameters.AddWithValue("@p12", lookUpEdit1.EditValue);
            KOMUT.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci EKlendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();

        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) 
            {
                TxtId.Text= dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString() ;
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                OgrNo.Text = dr["OGRNO"].ToString();
                cmbSınıf.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCİNSİYET"].ToString()=="E")
                {
                    radioButton1.Checked = true;
                }
                else 
                {
                    radioButton2.Checked = true;
                
                }
                cmb1.Text = dr["OGRIL"].ToString();
                comboBoxEdit2.Text = dr["OGRILCE"].ToString();
                DogTrh.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                OgrNo.Text = dr["OGRNO"].ToString();
                cmbSınıf.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCİNSİYET"].ToString() == "E")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;

                }
                cmb1.Text = dr["OGRIL"].ToString();
                comboBoxEdit2.Text = dr["OGRILCE"].ToString();
                DogTrh.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                OgrNo.Text = dr["OGRNO"].ToString();
                cmbSınıf.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCİNSİYET"].ToString() == "E")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;

                }
                cmb1.Text = dr["OGRIL"].ToString();
                comboBoxEdit2.Text = dr["OGRILCE"].ToString();
                DogTrh.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView5_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                MskTc.Text = dr["OGRTC"].ToString();
                OgrNo.Text = dr["OGRNO"].ToString();
                cmbSınıf.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCİNSİYET"].ToString() == "E")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;

                }
                cmb1.Text = dr["OGRIL"].ToString();
                comboBoxEdit2.Text = dr["OGRILCE"].ToString();
                DogTrh.Text = dr["OGRDOGTAR"].ToString();
                RchAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + dr["OGRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }
        public string yeniyol;

        private void BtnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog DOSYA = new OpenFileDialog();
            DOSYA.Filter = "Resim Dosyası | *.jpg;*.png;*.nef | Tüm Dosyalar |*.*";
            DOSYA.ShowDialog();
            string dosyayolu = DOSYA.FileName;
            yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
            pictureEdit1.Image = Image.FromFile(yeniyol);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand KOMUT = new SqlCommand("update TBL_OGRENCİLER set OGRAD=@p1, OGRSOYAD=@p2, OGRNO=@p3, OGRSINIF =@p4,OGRDOGTAR=@p5, OGRCİNSİYET=@p6, OGRTC=@p7, OGRIL=@p8, OGRILCE=@p9, OGRADRES=@p10, OGRFOTO=@p11, OGRVELİID=@p13 where OGRID=@P12", bgl.baglanti());
            KOMUT.Parameters.AddWithValue("@p1", TxtAd.Text);
            KOMUT.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            KOMUT.Parameters.AddWithValue("@p3", OgrNo.Text);
            KOMUT.Parameters.AddWithValue("@p4", cmbSınıf.Text);
            KOMUT.Parameters.AddWithValue("@p5", DogTrh.Text);
            if (radioButton1.Checked == true)
            {
                KOMUT.Parameters.AddWithValue("@p6", cinsiyet = "E");
            }
            else

            {
                KOMUT.Parameters.AddWithValue("@p6", cinsiyet = "B");
            }

            KOMUT.Parameters.AddWithValue("@p7", MskTc.Text);
            KOMUT.Parameters.AddWithValue("@p8", cmb1.Text);
            KOMUT.Parameters.AddWithValue("@p9", comboBoxEdit2.Text);
            KOMUT.Parameters.AddWithValue("@p10", RchAdres.Text);
            KOMUT.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            KOMUT.Parameters.AddWithValue("@p12", TxtId.Text);
            KOMUT.Parameters.AddWithValue("@p13",lookUpEdit1.EditValue);
            KOMUT.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci bilgileri güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand KOMUT = new SqlCommand("delete from TBL_OGRENCİLER where OGRID=@p1 ", bgl.baglanti());
            KOMUT.Parameters.AddWithValue("@p1", TxtId.Text);
            KOMUT.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            FrmNufusCuzdani frm = new FrmNufusCuzdani();

            if (dr != null)
            {
                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCİNSİYET"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzanti= "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + dr["OGRFOTO"].ToString(); ;
            }
            frm.Show();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
