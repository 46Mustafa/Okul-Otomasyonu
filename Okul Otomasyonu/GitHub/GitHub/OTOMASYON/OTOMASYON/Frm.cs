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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

     

        //ADO.NET Öğretmen Şifre Bilgileri

        void listele() 
        {
          DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute AyarlarOgretmenler",bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;  
            

        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        dbokulEntities db = new dbokulEntities();

        void ogrlistele()
        {
            gridControl2.DataSource = db.AyarlarOgrenciler();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        //ADO.NET LookUpEdit Aracı Veri Getirme

        void ogretmenlistesi() 
        {
          DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select OGRTID,(OGRTAD +' '+ OGRTSOYAD) as 'OGRTADSOYAD',OGRTBRANS from TBL_OGRETMENLER",bgl.baglanti());
            da2.Fill(dt2);
            lookUpEdit1.Properties.ValueMember = "OGRTID";
            lookUpEdit1.Properties.DisplayMember = "OGRTADSOYAD";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit1.Properties.DataSource = dt2;
            listele();

        }

        void ögrencilistesi()
        {
            var deger = from item in db.TBL_OGRENCİLER

                        select new
                        {
                            OGRID = item.OGRID,
                            OGRADSOYAD = item.OGRAD + " " + item.OGRSOYAD,
                            OGRSINIF = item.OGRSINIF,


                        };

            lookUpEdit2.Properties.ValueMember = "OGRID";
            lookUpEdit2.Properties.DisplayMember = "OGRADSOYAD";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";
            lookUpEdit2.Properties.DataSource = deger.ToList();
                        
                        
        } 
                   

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            ogretmenlistesi();
            ogrlistele();
            ögrencilistesi();
            temizle();
            
        }
        public string yeniyol;
        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null) { 
             TxtOgrtId.Text = dr["AYARLARID"].ToString();
            lookUpEdit1.Text= dr["OGRTADSOYAD"].ToString() ;
                TxtBrans.Text = dr["OGRTBRANS"].ToString();
                MskOgrtTC.Text = dr["OGRTTC"].ToString();
                TxtOgrtSifre.Text = dr["OGRTSIFRE"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
            }
        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtOgrSıfre.Text = "";

            SqlCommand komut = new SqlCommand("select * from TBL_OGRETMENLER where OGRTID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lookUpEdit1.ItemIndex + 1);
            SqlDataReader dr3= komut.ExecuteReader();
            while (dr3.Read()) 
            {
                TxtOgrtId.Text = dr3["OGRTID"].ToString();
                TxtBrans.Text = dr3["OGRTBRANS"].ToString();
                MskOgrtTC.Text = dr3["OGRTTC"].ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + dr3["OGRTFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
            }
            bgl.baglanti().Close();
        }

 


        //ADO.NET Öğretmenler Şifre Kaydet
        private void BtnOgrtKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_AYARLAR(AYARLARID,OGRTSIFRE)values(@p1,@p2)",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtOgrtId.Text);
            komut2.Parameters.AddWithValue("@p2",TxtOgrtSifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Oluşturuldu!","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void BtnOgrtGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update TBL_AYARLAR set OGRTSIFRE=@p1 where AYARLARID=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", TxtOgrtSifre.Text);
            komut3.Parameters.AddWithValue("@p2", TxtOgrtId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre güncellendi!", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        void temizle() 
        {
            TxtOgrtId.Text = "";
            TxtOgrID.Text = "";
            TxtBrans.Text = "";
            TxtOgrSınıf.Text = "";
            TxtOgrSıfre.Text = "";
            TxtOgrtSifre.Text = "";
            MskOgrTC.Text = "";           
            MskOgrtTC.Text = "";
            pictureEdit1.Text = "";
            pictureEdit2.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";








        }

        private void BtnOgrtTemizle_Click(object sender, EventArgs e) 
        {
            temizle();
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            TxtOgrID.Text=gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"AYARLAROGRID").ToString();
            lookUpEdit2.Text=gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"OGRADSOYAD").ToString() ;
            TxtOgrSınıf.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSINIF").ToString();
            MskOgrTC.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRTC").ToString();
           TxtOgrSıfre.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSIFRE").ToString();
            string uzanti = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRFOTO").ToString();
            yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + uzanti;
            pictureEdit2.Image = Image.FromFile(yeniyol);

        }

        //Entity framework lookupedit seçimi Sonrası Verilerin Getirilmesi

        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtOgrSıfre.Text = " ";
             
            using (dbokulEntities db = new dbokulEntities())
            
            {
                TBL_OGRENCİLER sorgu = db.TBL_OGRENCİLER.Find(lookUpEdit2.ItemIndex + 1);
                TxtOgrID.Text=sorgu.OGRID.ToString();
                TxtOgrSınıf.Text=sorgu.OGRSINIF.ToString();
                MskOgrTC.Text=sorgu.OGRTC.ToString();
                yeniyol = "C:\\Users\\MONSTER\\Desktop\\GitHub\\GitHub\\OTOMASYON\\OTOMASYON\\" + "\\resimler\\" + sorgu.OGRFOTO.ToString();
                pictureEdit2.Image= Image.FromFile(yeniyol);


            }
        }

        private void BtnOgrKaydet_Click(object sender, EventArgs e)
        {
            TBL_OGRAYARLAR KOMUT = new TBL_OGRAYARLAR();
            KOMUT.AYARLAROGRID = Convert.ToInt32(TxtOgrID.Text);
            KOMUT.OGRSIFRE = TxtOgrSıfre.Text;
            db.TBL_OGRAYARLAR.Add(KOMUT);
            db.SaveChanges();
            MessageBox.Show("Başarılı Şekilde Kaydedildi !", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();
            
        }

        private void BtnOgrGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID"));
            var item = db.TBL_OGRAYARLAR.FirstOrDefault(X => X.AYARLAROGRID == id);
            item.OGRSIFRE = TxtOgrSıfre.Text;
            db.SaveChanges();
            MessageBox.Show("Şifre Güncellendi !", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();
        }

        private void BtnOgrTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
