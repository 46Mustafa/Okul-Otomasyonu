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
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        FrmOgretmenler frm1;
        FrmOgrenciler frm2;
        FRMVELILER frm3;
        FrmAyarlar frm4;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed) { 
            frm1 = new FrmOgretmenler();
            frm1.MdiParent = this;  
            frm1.Show();
            }
        }

        
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new FrmOgrenciler();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void btnveliler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new FRMVELILER();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new FrmAyarlar();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    } 
}
