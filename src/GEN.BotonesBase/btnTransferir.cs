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
    public partial class btnTransferir : Boton
    {
        public btnTransferir()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.btnTransferir;
            this.Click += btnTransferir_Click;
        }

        void btnTransferir_Click(object sender, EventArgs e)
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
            this.Text = "&Transferir";
        }

    }
}
