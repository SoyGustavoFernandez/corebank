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
    public partial class Boton : Button
    {
        public Boton()
        {
            InitializeComponent();
            this.MouseLeave += new System.EventHandler(this.Boton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Boton_MouseHover);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Size = new System.Drawing.Size(60, 50);
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        }

        public void Boton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        public void Boton_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        /// <summary>
        /// Valida la fecha del sistema en ejecucion con la fecha de la base de datos
        /// </summary>
        /// <returns></returns>
        public bool validarFechaSisBD()
        {
            bool lValido = false;

            DataTable dt = new DataTable();
            dt = new SolIntEls.GEN.Helper.clsGENEjeSP().EjecSP("Gen_RetVariable_Sp", "dFechaAct", clsVarGlobal.nIdAgencia);

            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            DateTime dFechaBD = Convert.ToDateTime(dt.Rows[0][0]);
            if (dFechaSis == dFechaBD)
            {
                lValido = true;
            }

            return lValido;
        }
    }
}
