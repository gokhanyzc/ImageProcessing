using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //bitmap için lib.

namespace goruntu_isleme
{
    class islemler
    {
      //resmin negatifini alma

        public Bitmap negative(Bitmap bitmap)
        {

            //yeni resim döndürebilmek için yeni bi değişken tanımlarız.
            Bitmap sonuc = new Bitmap(bitmap.Width, bitmap.Height);
            Color ilk_renk, ikinci_renk;
            int r, g, b;


            //bu şekilde resimdeki bütün piksellere erişebiliriz.
            for(int i=0; i<bitmap.Width; i++)
            {
                for(int j=0; j<bitmap.Height; j++)
                {
                    //renk kodlarına burada erişim sağlarız.
                    ilk_renk = bitmap.GetPixel(i, j);
                    r = 255 - ilk_renk.R;
                    g = 255 - ilk_renk.G;
                    b = 255 - ilk_renk.B;
                    ikinci_renk = Color.FromArgb(r, g, b);  //FromArgb fonksiyonu renk döndürüyor.
                    sonuc.SetPixel(i, j, ikinci_renk);

                 }
            }

            return sonuc;

        }


        public Bitmap griye_cevir(Bitmap bitmap)
        {
            Bitmap sonuc = new Bitmap(bitmap.Width, bitmap.Height);
            Color ilk_renk, ikinci_renk;
            int ton;

            for(int i=0 ; i<bitmap.Width;i++)
            {
                for(int j=0; j<bitmap.Height;j++)
                {
                    ilk_renk = bitmap.GetPixel(i, j);
                    ton = Convert.ToInt16(0.299 * ilk_renk.R) + Convert.ToInt16(0.587 * ilk_renk.G) + Convert.ToInt16(0.114 * ilk_renk.B);
                    ikinci_renk = Color.FromArgb(ton, ton, ton);
                    sonuc.SetPixel(i, j, ikinci_renk);


                }
            }

            return sonuc;

        }



        public Bitmap SiyahBeyaz(Bitmap bitmap,int esik)
        {
            Bitmap sonuc = new Bitmap(bitmap.Width, bitmap.Height);
            Color ilk_renk, ikinci_renk;
            

            for(int i=0; i<bitmap.Width; i++)
            {
                for(int j=0; j<bitmap.Height; j++)
                {
                    ilk_renk = bitmap.GetPixel(i, j);

                    if(ilk_renk.R >= esik)
                    {

                        ikinci_renk = Color.FromArgb(255, 255, 255);

                    }
                    else
                    {
                        ikinci_renk = Color.FromArgb(0, 0, 0);
                    }

                    sonuc.SetPixel(i, j, ikinci_renk);
                }

            }

            return sonuc;

        }

        public Bitmap parlaklik(Bitmap bitmap , int parlaklik_sayi)
        {
            Bitmap sonuc = new Bitmap(bitmap.Width, bitmap.Height);
            Color ilk_renk, ikinci_renk;
            int r, g, b;

            for(int i=0; i<bitmap.Width; i++)
            {

                for(int j=0; j<bitmap.Height; j++)
                {
                    ilk_renk = bitmap.GetPixel(i, j);

                    if(ilk_renk.R + parlaklik_sayi > 255)
                    {
                        r = 255;

                    }
                    else if (ilk_renk.R + parlaklik_sayi < 0)
                    {
                        r = 0;

                    }
                    else
                    {
                        r = ilk_renk.R + parlaklik_sayi;
                    }

                    if (ilk_renk.G + parlaklik_sayi > 255)
                    {
                        g = 255;

                    }
                    else if (ilk_renk.G + parlaklik_sayi < 0)
                    {
                        g = 0;

                    }
                    else
                    {
                        g = ilk_renk.G + parlaklik_sayi;
                    }

                    if (ilk_renk.B + parlaklik_sayi > 255)
                    {
                        b = 255;       

                    }
                    else if (ilk_renk.B + parlaklik_sayi < 0)
                    {
                        b = 0;

                    }
                    else
                    {
                        b = ilk_renk.B + parlaklik_sayi;
                    }

                    ikinci_renk = Color.FromArgb(r, g, b);
                    sonuc.SetPixel(i, j, ikinci_renk);


                }
            }

            return sonuc;

        }
    }
}
