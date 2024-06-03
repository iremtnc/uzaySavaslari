using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uzaySavaslari
{
    public partial class Form1 : Form
    {
        int formYukseklik = 700, formGenislik = 500;
        //Oyuncu gemisinin koordinatları(duracağı yer) 
        int Oyuncu_X = 200, Oyuncu_Y = 400;
        int OyuncuHiz_yatay = 0, OyuncuHizDusey = 0;
        int puan;
        List<PictureBox> mermiler = new List<PictureBox>();
        int MermiHiz = 10;
        List<PictureBox> Dusmanlar = new List<PictureBox>();
        int DusmanHiz = 2; 

        Random rnd= new Random();   


        public Form1()
        {
            InitializeComponent();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timerOyuncu_Tick(object sender, EventArgs e)
        {
            Oyuncu_X += OyuncuHiz_yatay;
            Oyuncu_Y += OyuncuHizDusey;
            // Form sınırlarını kontrol edin
            if (Oyuncu_X < 0)
                Oyuncu_X = 0;
            else if (Oyuncu_X + pictureBoxOyuncuGemi.Width > formGenislik)
                Oyuncu_X = formGenislik - pictureBoxOyuncuGemi.Width;

            if (Oyuncu_Y < 0)
                Oyuncu_Y = 0;
            else if (Oyuncu_Y + pictureBoxOyuncuGemi.Height > formYukseklik)
                Oyuncu_Y = formYukseklik - pictureBoxOyuncuGemi.Height;

            // Yeni konumu pictureBox'a atayın
            pictureBoxOyuncuGemi.Location = new Point(Oyuncu_X, Oyuncu_Y); 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = formYukseklik;
            this.Width = formGenislik;

            //Objelerimizi galaksinin içine alıyoruz 
            
            pictureBoxOyuncuGemi.Parent = pictureBoxGalaksi; 
            labelPuan.Parent=pictureBoxGalaksi;
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int hiz = 5;
             switch (e.KeyCode)
            {
                case Keys.Left: OyuncuHiz_yatay -= hiz; break;
                case Keys.Right: OyuncuHiz_yatay += hiz; break;
                case Keys.Up: OyuncuHizDusey -= hiz; break;
                case Keys.Down: OyuncuHizDusey += hiz; break;
                case Keys.Enter:
                    puan = 0;
                    timerOyuncu.Start();
                    timerMermiFirlat.Start();
                    timerDusmanOlustur.Start();
                    timerDusmanVur.Start();
                    timerMermiKontrol.Start();  
                    break;
                case Keys.Space:
                    MermiOlustur();
                    break; 
            }
        }

        private void timerMermiFirlat_Tick(object sender, EventArgs e)
        {
            MermileriFırlat();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: OyuncuHiz_yatay = 0; break;
                case Keys.Right: OyuncuHiz_yatay = 0; break;
                case Keys.Up: OyuncuHizDusey = 0; break;
                case Keys.Down: OyuncuHizDusey = 0; break;
            }
        }
        public void MermiOlustur()
        {
            PictureBox Mermi = new PictureBox
            {
                Size = new Size(15, 15),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image=Properties.Resources.Laser_08,
                BackColor=Color.Transparent
            };
            int mermilocX = pictureBoxOyuncuGemi.Location.X + pictureBoxOyuncuGemi.Width / 2 - 5;
            int mermilocY = pictureBoxOyuncuGemi.Top - 1;

            Mermi.Location=new Point(mermilocX, mermilocY);
            Controls.Add(Mermi);
            Mermi.Parent=pictureBoxGalaksi;
            Mermi.BringToFront();  //galaxy resminin üstüne çıkartıyoruz 
            mermiler.Add(Mermi);
        }

        private void timerDusmanVur_Tick(object sender, EventArgs e)
        {
           DusmanVur();
        }

        private void timerDusmanOlustur_Tick(object sender, EventArgs e)
        {
            DusmanOlustur();
        }

        private void timerMermiKontrol_Tick(object sender, EventArgs e)
        {
            for (int m=0; m<mermiler.Count; m++)
            {
                for (int d = 0; d < Dusmanlar.Count; d++)
                {
                    try
                    {
                        //Mermi ile düşman gemisi çarpıştı mı? 
                        if (mermiler[m].Bounds.IntersectsWith(Dusmanlar[d].Bounds))
                        {
                            puan += 1;
                            labelPuan.Text = "Puan=" + puan.ToString();

                            pictureBoxGalaksi.Controls.Remove(mermiler[m]);
                            mermiler.Remove(mermiler[m]);

                            pictureBoxGalaksi.Controls.Remove(Dusmanlar[d]);
                            Dusmanlar.Remove(Dusmanlar[d]);

                            //RAM hafıza temizleme 

                            GC.Collect(); //çöp toplayıcı 
                            GC.WaitForPendingFinalizers(); //çöpleri yok et 
                        }
                    } 
                    //picturebox listesinden eleman silindiği için 
                    //aynı indis tekrar kontrol edildiği zaman 
                    //ilk aşamada null değer olduğu için 
                    //return ile görmezden geliyoruz 

                    catch (ArgumentOutOfRangeException)
                    {
                        return;
                    }

                }
            }
        }

        public void MermileriFırlat()
        {
            for(int i=0; i<mermiler.Count; i++)
            {
                mermiler[i].Top -= MermiHiz; 
            }
        }

        public void DusmanOlustur()
        {
            int yer = rnd.Next(0, formGenislik - 50);
            PictureBox Dusman = new PictureBox
            {
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.Gemi_03,
                BackColor = Color.Transparent,
                Location = new Point(yer, 0),
                Visible = true
            };
            Controls.Add(Dusman);  //forma ekledik 
            Dusman.Parent= pictureBoxGalaksi;   //galaksi içine aldık 
            Dusman.BringToFront(); //öne getirdik 
            Dusmanlar.Add(Dusman); 
        }

        public void DusmanVur()
        {
            for(int i=0; i<Dusmanlar.Count; i++)
            {
                Dusmanlar[i].Top += DusmanHiz;
                //Düşman gemisi formun dışına çıkarsa veya oyuncunun gemisine çarparsa 

                if (Dusmanlar[i].Top>=formYukseklik-10 ||
                    Dusmanlar[i].Bounds.IntersectsWith(pictureBoxOyuncuGemi.Bounds))  
                {
                    //Oyun bitti 
                    OyunBitir();
                }
               
 
            }
        } 

        public void OyunBitir()
        {
            timerOyuncu.Stop();
            timerMermiFirlat.Stop();
            timerMermiKontrol.Stop();
            timerDusmanOlustur.Stop();
            timerDusmanVur.Stop();

            MessageBox.Show("Oyun bitti!");
            
        }
    }
}

