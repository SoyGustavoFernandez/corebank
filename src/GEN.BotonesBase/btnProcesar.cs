using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.BotonesBase
{
    public partial class btnProcesar : Boton
    {
        public btnProcesar()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnAceptar;
            this.Click += btnProcesar_Click;
        }

        void btnProcesar_Click(object sender, EventArgs e)
        {
            if (clsVarGlobal.lEstLogeado)
            {
                if (!validarFechaSisBD())
                {
                    throw new Exception("Por favor debe cerrar el sistema y volver a ingresar");
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.Text = "&Procesar";
        }
    }
}
