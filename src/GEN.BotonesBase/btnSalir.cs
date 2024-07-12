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
    public partial class btnSalir : Boton
    {
        public bool lEventoDesactivado = false;
        public btnSalir()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnSalir;
            this.Click += new System.EventHandler(this.btnSalir_Click);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Salir";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(this, "Desea cerrar, este formulario", "INFORMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    this.Parent.Dispose();
            //}
            if (!lEventoDesactivado) {
                if (this.Parent is Form)
                {
                    this.Parent.Dispose();
                }
                else if(this.Parent.Parent is Form)
                {
                    this.Parent.Parent.Dispose();      
                }
            }
        }
    }
}
