using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;

namespace CAJ.Presentacion
{
    public partial class frmReprocesarFlujoCajaBco : frmBase
    {
        public frmReprocesarFlujoCajaBco()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFechaFinal.Value.ToShortDateString()) < Convert.ToDateTime(dtpFechaInicial.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no puede ser mayor que la Fecha Final", "Reprocesar Flujo de Caja y Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFechaInicio = dtpFechaInicial.Value;
            DateTime dFechaFinal = dtpFechaFinal.Value;

            DataTable dtReprocesarFlujo = new clsCNFlujoCajaBco().CNReprocesarFlujoCajaBco(dFechaInicio, dFechaFinal);

            MessageBox.Show(dtReprocesarFlujo.Rows[0]["cMensaje"].ToString(), "Reprocesar Flujo de Caja y Bancos", MessageBoxButtons.OK, ((int)dtReprocesarFlujo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }
    }
}
