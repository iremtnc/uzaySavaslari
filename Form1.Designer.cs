namespace uzaySavaslari
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxGalaksi = new System.Windows.Forms.PictureBox();
            this.pictureBoxOyuncuGemi = new System.Windows.Forms.PictureBox();
            this.labelPuan = new System.Windows.Forms.Label();
            this.timerOyuncu = new System.Windows.Forms.Timer(this.components);
            this.timerMermiFirlat = new System.Windows.Forms.Timer(this.components);
            this.timerDusmanVur = new System.Windows.Forms.Timer(this.components);
            this.timerDusmanOlustur = new System.Windows.Forms.Timer(this.components);
            this.timerMermiKontrol = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalaksi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOyuncuGemi)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGalaksi
            // 
            this.pictureBoxGalaksi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGalaksi.Image = global::uzaySavaslari.Properties.Resources.Evren_04;
            this.pictureBoxGalaksi.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGalaksi.Name = "pictureBoxGalaksi";
            this.pictureBoxGalaksi.Size = new System.Drawing.Size(461, 591);
            this.pictureBoxGalaksi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGalaksi.TabIndex = 0;
            this.pictureBoxGalaksi.TabStop = false;
            // 
            // pictureBoxOyuncuGemi
            // 
            this.pictureBoxOyuncuGemi.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxOyuncuGemi.Image = global::uzaySavaslari.Properties.Resources.Gemi_01;
            this.pictureBoxOyuncuGemi.Location = new System.Drawing.Point(177, 459);
            this.pictureBoxOyuncuGemi.Name = "pictureBoxOyuncuGemi";
            this.pictureBoxOyuncuGemi.Size = new System.Drawing.Size(87, 68);
            this.pictureBoxOyuncuGemi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOyuncuGemi.TabIndex = 1;
            this.pictureBoxOyuncuGemi.TabStop = false;
            this.pictureBoxOyuncuGemi.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelPuan
            // 
            this.labelPuan.AutoSize = true;
            this.labelPuan.BackColor = System.Drawing.Color.Transparent;
            this.labelPuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPuan.ForeColor = System.Drawing.Color.White;
            this.labelPuan.Location = new System.Drawing.Point(12, 18);
            this.labelPuan.Name = "labelPuan";
            this.labelPuan.Size = new System.Drawing.Size(101, 29);
            this.labelPuan.TabIndex = 2;
            this.labelPuan.Text = "Puan=0 ";
            // 
            // timerOyuncu
            // 
            this.timerOyuncu.Interval = 1;
            this.timerOyuncu.Tick += new System.EventHandler(this.timerOyuncu_Tick);
            // 
            // timerMermiFirlat
            // 
            this.timerMermiFirlat.Interval = 10;
            this.timerMermiFirlat.Tick += new System.EventHandler(this.timerMermiFirlat_Tick);
            // 
            // timerDusmanVur
            // 
            this.timerDusmanVur.Interval = 10;
            this.timerDusmanVur.Tick += new System.EventHandler(this.timerDusmanVur_Tick);
            // 
            // timerDusmanOlustur
            // 
            this.timerDusmanOlustur.Interval = 2000;
            this.timerDusmanOlustur.Tick += new System.EventHandler(this.timerDusmanOlustur_Tick);
            // 
            // timerMermiKontrol
            // 
            this.timerMermiKontrol.Tick += new System.EventHandler(this.timerMermiKontrol_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 591);
            this.Controls.Add(this.labelPuan);
            this.Controls.Add(this.pictureBoxOyuncuGemi);
            this.Controls.Add(this.pictureBoxGalaksi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalaksi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOyuncuGemi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGalaksi;
        private System.Windows.Forms.PictureBox pictureBoxOyuncuGemi;
        private System.Windows.Forms.Label labelPuan;
        private System.Windows.Forms.Timer timerOyuncu;
        private System.Windows.Forms.Timer timerMermiFirlat;
        private System.Windows.Forms.Timer timerDusmanVur;
        private System.Windows.Forms.Timer timerDusmanOlustur;
        private System.Windows.Forms.Timer timerMermiKontrol;
    }
}

