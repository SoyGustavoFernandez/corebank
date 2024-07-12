using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmVerificarCierreAge : frmBase
    {
        public frmVerificarCierreAge()
        {
            InitializeComponent();
        }

        private void frmVerificarCierreAge_Load(object sender, EventArgs e)
        {
            this.dtpFechaSis.Value = clsVarGlobal.dFecSystem;
        }

        private void FormatoGrid()
        {
            this.dtgEstCie.Columns["idUsuario"].Visible = false;
            this.dtgEstCie.Columns["cNombreAge"].Width = 200;
            this.dtgEstCie.Columns["cNombreAge"].HeaderText = "AGENCIAS";
            this.dtgEstCie.Columns["Estado"].Width = 150;
            this.dtgEstCie.Columns["Estado"].HeaderText = "ESTADO DE CIERRE";
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string msg = "";
            DateTime dfecpro = Convert.ToDateTime(this.dtpFechaSis.Value.ToShortDateString());
            clsCNControlOpe VerEstCie = new clsCNControlOpe();
            DataTable tbEstCie = VerEstCie.VerificarEstadoCierre(dfecpro, ref msg);
            if (msg=="OK")
            {
                this.dtgEstCie.DataSource = tbEstCie;
                FormatoGrid();
                this.dtgEstCie.Columns["cNombreAge"].Width = 200;
            }
            else
            {
                MessageBox.Show(msg, "Verificar Estado Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



       
    }
}
