using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VektorelMarket.Core.Utility
{
    public class CaptchaGenerator
    {
        private int karakterSayisi;
        private string fontTipi;
        private float fontbuyuklugu;
        private string olusturulanString;

        public CaptchaGenerator(int KarakterSayisi, string FontTipi, float FontBuyuklugu)
        {
            this.karakterSayisi = KarakterSayisi;
            this.fontTipi = FontTipi;
            this.fontbuyuklugu = FontBuyuklugu;
        }


        public string OlusturulanString
        {

            get
            {
                return olusturulanString;
            }

        }

   
        private char KarakterUret()
        {


            char karakter = ' ';
            Random rnd = new Random();

            bool kontrol = false;

            while (!kontrol)
            {
                int sayi = rnd.Next(65, 123);

                if (!(sayi > 90 && sayi < 97))
                {
                    karakter = (char)sayi;
                    kontrol = true;
                }


            }
            return karakter;


        }

        private string KarakterDizisiOlustur()
        {

            string karakterdizisi = "";
            for (int i = 0; i < this.karakterSayisi; i++)
            {
                karakterdizisi += KarakterUret();
                // System.Threading.Sleep
            }
            return karakterdizisi;
        }

        public Bitmap GuvenlikResmiUret()
        {
            this.olusturulanString = KarakterDizisiOlustur();

            Bitmap b = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(b); 


            Bitmap resim = new Bitmap((int)g.MeasureString(olusturulanString, new Font(fontTipi, fontbuyuklugu)).Width, (int)g.MeasureString(olusturulanString, new Font(fontTipi, fontbuyuklugu)).Height);
            

            Graphics graph = Graphics.FromImage(resim);
            
            graph.DrawLine(new Pen(Brushes.Blue), 0, 0, 50, 60);


            HatchBrush firca = new HatchBrush(HatchStyle.NarrowHorizontal, Color.White);

            graph.DrawString(olusturulanString, new Font(fontTipi, fontbuyuklugu), firca, new PointF(0, 0));

            return resim;

        }


    }
}
