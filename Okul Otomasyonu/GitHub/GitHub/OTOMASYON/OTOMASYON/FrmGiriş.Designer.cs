namespace OTOMASYON
{
    partial class FrmGiriş
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiriş));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtparola = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.msktece = new System.Windows.Forms.MaskedTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnyonetici = new System.Windows.Forms.Button();
            this.btnogretici = new System.Windows.Forms.Button();
            this.btnogrenici = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtparola.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 71);
            this.panel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe Script", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(230, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(432, 51);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Merkez i.ö.o. giriş paneli";
            // 
            // txtparola
            // 
            this.txtparola.Location = new System.Drawing.Point(540, 482);
            this.txtparola.Name = "txtparola";
            this.txtparola.Properties.UseSystemPasswordChar = true;
            this.txtparola.Size = new System.Drawing.Size(157, 20);
            this.txtparola.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Wheat;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(173, 477);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 25);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Kullanıcı";
            // 
            // msktece
            // 
            this.msktece.Location = new System.Drawing.Point(268, 482);
            this.msktece.Mask = "00000000000";
            this.msktece.Name = "msktece";
            this.msktece.Size = new System.Drawing.Size(115, 20);
            this.msktece.TabIndex = 4;
            this.msktece.ValidatingType = typeof(int);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.PapayaWhip;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(486, 477);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 25);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Şifre";
            // 
            // btnyonetici
            // 
            this.btnyonetici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnyonetici.BackgroundImage")));
            this.btnyonetici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnyonetici.Location = new System.Drawing.Point(1, 170);
            this.btnyonetici.Name = "btnyonetici";
            this.btnyonetici.Size = new System.Drawing.Size(134, 112);
            this.btnyonetici.TabIndex = 6;
            this.btnyonetici.UseVisualStyleBackColor = true;
            this.btnyonetici.Click += new System.EventHandler(this.btnyonetici_Click);
            // 
            // btnogretici
            // 
            this.btnogretici.BackgroundImage = global::OTOMASYON.Properties.Resources.indir__1_;
            this.btnogretici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnogretici.Location = new System.Drawing.Point(1, 288);
            this.btnogretici.Name = "btnogretici";
            this.btnogretici.Size = new System.Drawing.Size(134, 116);
            this.btnogretici.TabIndex = 6;
            this.btnogretici.UseVisualStyleBackColor = true;
            this.btnogretici.Click += new System.EventHandler(this.btnogretici_Click);
            // 
            // btnogrenici
            // 
            this.btnogrenici.BackgroundImage = global::OTOMASYON.Properties.Resources.indir;
            this.btnogrenici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnogrenici.Location = new System.Drawing.Point(1, 410);
            this.btnogrenici.Name = "btnogrenici";
            this.btnogrenici.Size = new System.Drawing.Size(134, 92);
            this.btnogrenici.TabIndex = 6;
            this.btnogrenici.UseVisualStyleBackColor = true;
            this.btnogrenici.Click += new System.EventHandler(this.btnogrenici_Click);
            // 
            // FrmGiriş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1002, 561);
            this.Controls.Add(this.btnogrenici);
            this.Controls.Add(this.btnogretici);
            this.Controls.Add(this.btnyonetici);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.msktece);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtparola);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmGiriş";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Giriş Paneli";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtparola.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtparola;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.MaskedTextBox msktece;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Button btnyonetici;
        private System.Windows.Forms.Button btnogretici;
        private System.Windows.Forms.Button btnogrenici;
    }
}