using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class txtObjeto : txtBase
    {
        private readonly Button _button;
        private readonly ToolTip _toolTip;

        public event EventHandler ButtonClick { add { _button.Click += value; } remove { _button.Click -= value; } }

        public int idObjeto { get; set; }
        public string _cNombreObjeto = String.Empty;
        public object oObjeto { get; set; }
        public string cNombreObjecto
        {
            get
            {
                return _cNombreObjeto;
            }
            set
            {
                _cNombreObjeto = value;
                this.Text = value;
                if (lMostrarToolTip)
                {
                    _toolTip.SetToolTip(this, value);
                }
            }
        }

         public bool lMostrarToolTip { get; set; }


        //public bool lBotonObjeto { get; set; }
        //private Button btnObjeto = new Button();
        public txtObjeto()
        {
            InitializeComponent();

            _button = new Button() { Cursor = Cursors.Default };
            _button.SizeChanged += (o, e) => OnResize(e);
            this.Controls.Add(_button);
            addButton();

            this.ReadOnly = true;
            this.Enabled = false;
            this.lMostrarToolTip = false;

            _toolTip = new ToolTip();

            this.GotFocus += TextBoxGotFocus;
            this.MouseHover += txtObjeto_MouseHover;
            this.Cursor = Cursors.Arrow;
        }

        public Button btnObjeto
        {
            get
            {
                return _button;
            }
        }

        public void CargarDatosObjecto(int _idObjecto, string _cNombreObjecto, object _oObjecto = null)
        {
            this.oObjeto = _oObjecto;
            this.idObjeto = _idObjecto;
            this.cNombreObjecto = _cNombreObjecto;
        }

        public txtObjeto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            _button = new Button() { Cursor = Cursors.Default };
            _button.SizeChanged += (o, e) => OnResize(e);
            this.Controls.Add(_button);
            addButton();

            _toolTip = new ToolTip();

            this.GotFocus += TextBoxGotFocus;
            this.MouseHover += txtObjeto_MouseHover;
            this.Cursor = Cursors.Arrow;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            addButton();
        }

        private void addButton()
        {
            _button.Size = new System.Drawing.Size(25, this.ClientSize.Height + 2);
            _button.Location = new System.Drawing.Point(this.ClientSize.Width - _button.Width, -1);
            _button.Image = Properties.Resources.btnDetalle;

            SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(_button.Width << 16));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr HWnd);

        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(this.Handle);
        }

        private void txtObjeto_MouseHover(object sender, EventArgs e)
        {
            if (lMostrarToolTip)
            {
                _toolTip.SetToolTip(this, cNombreObjecto);
            }
        }
    }
}
