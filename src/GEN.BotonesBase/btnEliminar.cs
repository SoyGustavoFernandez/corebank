using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEN.BotonesBase
{
    public partial class btnEliminar : Boton
    {
        public btnEliminar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnEliminar;
            SetButtonText("Eliminar");
        }

        // Método para cambiar el texto del botón
        public void SetButtonText(string text)
        {
            this.Text = text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //this.Text = "&Eliminar";
        }
    }
}
