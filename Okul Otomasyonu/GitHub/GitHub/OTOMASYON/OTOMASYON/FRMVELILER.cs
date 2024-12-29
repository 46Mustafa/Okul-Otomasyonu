using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTOMASYON
{
    public partial class FRMVELILER : Form
    {
        public FRMVELILER()
        {
            InitializeComponent();
        }

        dbokulEntities db = new dbokulEntities();

        void listele()
        {
            var query = from item in db.TBL_VELILER
                        select new { item.VELIID, item.VELIANNE, item.VELIBABA, item.VELITEL1, item.VELITEL2, item.VELIMAIL };

            gridControl1.DataSource = query.ToList();
            //gridView1.Columns[6].Visible = false; 
        }

        void temizle()
        {
            TxtId.Text = "";
            txtanne.Text = "";
            txtbaba.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            TxtMail.Text = "";
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void FRMVELILER_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBL_VELILER veli=new TBL_VELILER();
            veli.VELIANNE=txtanne.Text;
            veli.VELIBABA=txtbaba.Text;
            veli.VELITEL1=msktel1.Text;
            veli.VELITEL2=msktel2.Text;
            veli.VELIMAIL=TxtMail.Text;
            db.TBL_VELILER.Add(veli);
            db.SaveChanges();
            listele();
            temizle();
        }

        private void gridView1_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            TxtId.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VELIID").ToString();
            txtanne.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VELIANNE").ToString();
            txtbaba.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VELIBABA").ToString();
            msktel1.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VELITEL1").ToString();
            msktel2.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VELITEL2").ToString();
            TxtMail.Text=gridView1.GetRowCellValue(gridView1.FocusedRowHandle,"VELIMAIL").ToString();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString());
            //var item = db.TBL_VELILER.Find(id);
            //item.VELIANNE=txtanne.Text;
            //item.VELIBABA=txtbaba.Text;
            //item.VELITEL1 = msktel1.Text;
            //item.VELITEL2 = msktel2.Text;
            //item.VELIMAIL=TxtMail.Text;
            //db.SaveChanges();
            //listele();
            //temizle();
            using (dbokulEntities db = new dbokulEntities())
            {
                var item = db.TBL_VELILER.FirstOrDefault(x => x.VELIID == id);
                item.VELIANNE = txtanne.Text;
                item.VELIBABA = txtbaba.Text;
                item.VELITEL1 = msktel1.Text;
                item.VELITEL2 = msktel2.Text;
                item.VELIMAIL = TxtMail.Text;
                db.SaveChanges();
                listele();
                temizle();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString());
            //var item = db.TBL_VELILER.Find(id);
            //db.TBL_VELILER.Remove(item);
            //db.SaveChanges();
            //listele();
            using (dbokulEntities db = new dbokulEntities())
            {
                var item =db.TBL_VELILER.First(x => x.VELIID == id);
                db.TBL_VELILER.Remove(item);
                db.SaveChanges();
                listele();
                temizle();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
