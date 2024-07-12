using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    [Designer(typeof(CirculoSemaforoDesigner))]
    public partial class ConCirculoSemaforo : UserControl
    {
        private Color _color;
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                Invalidate();
            }
        }

        public ConCirculoSemaforo()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Brush myBrush = new LinearGradientBrush(this.DisplayRectangle,_color,Color.White, LinearGradientMode.Horizontal);
            e.Graphics.FillEllipse(myBrush, 0, 0, this.Width - 5 / 2, this.Width - 5 / 2);
        }
    }

    public class CirculoSemaforoDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
            ConCirculoSemaforo circuloSemaforo = (ConCirculoSemaforo) Control;
            
            //Brush myBrush = new SolidBrush(circuloSemaforo.Color);
            Brush myBrush = new LinearGradientBrush(Control.DisplayRectangle, circuloSemaforo.Color, Color.White, LinearGradientMode.Horizontal);
            pe.Graphics.FillEllipse(myBrush, 0, 0, circuloSemaforo.Width - 5 / 2, circuloSemaforo.Width - 5 / 2);
        }
    }
}
