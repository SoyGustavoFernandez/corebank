using System.Drawing;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.WhiteSmoke);

            float percent = (float)this.Value / this.Maximum;
            Rectangle progressRect = new Rectangle(0, 0, (int)(this.Width * percent), this.Height);

            using (SolidBrush brush = new SolidBrush(Color.LightGreen))
            {
                e.Graphics.FillRectangle(brush, progressRect);
            }

            string text = $"{percent * 100:F0}%";
            using (Font font = new Font("Arial", 10))
            {
                SizeF textSize = e.Graphics.MeasureString(text, font);
                Point textLocation = new Point((this.Width - (int)textSize.Width) / 2, (this.Height - (int)textSize.Height) / 2);
                e.Graphics.DrawString(text, font, Brushes.Black, textLocation);
            }

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}
