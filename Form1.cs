using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;  //bitmapi kullanabilmek için bu kütüphaneyi kullanabilmemiz gerekiyor.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goruntu_isleme
{
    public partial class Form1 : Form
    {

        islemler islemler = new islemler();// oluşturulan classı kullanabilmek için tanımlama işlemi gerçekleştirdik.
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog(); //Kullanıcı bir resim seçer.

            //eğer seçtiyse
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                //resim yükleme işlemleri yazılır.
                pictureBox1.Image = Image.FromFile(openFile.FileName);  //dosya yolundan pictureboxa resim çekilir.


            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {


            if (pictureBox1.Image != null)
            {

                if (comboBox1.SelectedItem.ToString() == "mouse modu")
                {


                    //mouse ile resim üzerine gelince renk çekme işlemi.
                    Bitmap bitmap = (Bitmap)pictureBox1.Image;
                    

                    //pictureboxın köşesine göre olan mousenın konumu
                    //renk kodunu bitmapin getpixel ile elde edilir.

                   Color color = bitmap.GetPixel(e.X , e.Y);  // resmin x ve y mousenın bulundugu konum
                    pictureBox2.Image = null;
                    pictureBox2.BackColor = color;


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            Bitmap gelen_resim =null;
            Bitmap asil_resim = null;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "negatif":
                    //RESMİN TERSİ
                    gelen_resim = islemler.negative((Bitmap)pictureBox1.Image);
                    pictureBox2.Image = gelen_resim;
                    break;
                case "gri":
                    //RESMİN GRİ HALİ
                    asil_resim = islemler.griye_cevir((Bitmap)pictureBox1.Image);
                    pictureBox2.Image = asil_resim;
                    break;
                case "eşikleme":
                    //RESMİN SİYAH BEYAZ HALİ
                    //fakat önce resim griye çevirilir.
                    asil_resim = islemler.griye_cevir((Bitmap)pictureBox1.Image);
                    gelen_resim = islemler.SiyahBeyaz((Bitmap)asil_resim, 128);
                    pictureBox2.Image = gelen_resim;
                    break;  

                case "parlaklık":

                    gelen_resim = islemler.parlaklik((Bitmap)pictureBox1.Image,trackBar1.Value);  //parlaklık değerini belirlemek için trackbar kullanabiliriz.
                    pictureBox2.Image = gelen_resim;
                    break;

            }
           // pictureBox2.Image = gelen_resim;



          /*  Bitmap resim = null;
           
            if(comboBox1.SelectedItem.ToString() == "negatif")
            {
                //RESMİN TERSİNİ ALMA
                //255 den RGB çıkarılır.

                 resim = islemler.negative((Bitmap)pictureBox1.Image);
              
             }

            if(comboBox1.SelectedItem.ToString() == "gri")
            {

                //GRİYE ÇEVİRME

                 resim = islemler.griye_cevir((Bitmap)pictureBox1.Image);
            }

            if(comboBox1.SelectedItem.ToString() == "esikleme")
            {

                //SİYAH BEYAZ ÇEVİRME 
                //önce griye çevirir sonra siyahbeyaza
                if(pictureBox2.Image== resim)
                {

                    resim = islemler.SiyahBeyaz((Bitmap)resim, 128);
                }

            }

            pictureBox2.Image = resim;  */


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "mouse modu")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;

            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.BackColor = Color.Lavender;
            }




        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

            label1.Text = trackBar1.Value.ToString();  //trackbar değeri label a yazdırılıyor.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();  //trackbar değeri label a yazdırılıyor.
        }
    }
}
