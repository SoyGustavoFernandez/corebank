using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEN.Funciones
{
    public class clsCodigoBarra
    {
        public Byte[] Convert(string Text)
        {
            System.Drawing.Image b;
            BarcodeLib.Barcode bar = new BarcodeLib.Barcode(); 
            bar.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            bar.IncludeLabel = false;
            bar.RotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone;
           int nLongitud= Text.Length ;

           int withCodeBar = System.Convert.ToInt32(400 * nLongitud / 28);
           b = bar.Encode(BarcodeLib.TYPE.CODE39Extended, Text, withCodeBar, 30);
            Byte[] bitmapData = null;
            using(System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                bitmapData = ms.ToArray();
            }
            return bitmapData;
        }

        public Byte[] Convert(string Text, int nWidth = 400, int nHeigth = 100)
        {
            System.Drawing.Image b;
            BarcodeLib.Barcode bar = new BarcodeLib.Barcode();
            bar.Alignment = BarcodeLib.AlignmentPositions.LEFT;
            bar.IncludeLabel = false;
            bar.RotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            int nLongitud = Text.Length;

            int withCodeBar = System.Convert.ToInt32(nWidth);
            b = bar.Encode(BarcodeLib.TYPE.CODE39Extended, Text, withCodeBar, nHeigth);
            Byte[] bitmapData = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                bitmapData = ms.ToArray();
            }
            return bitmapData;
        }
    }
}
