using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmSolAprobTitular : frmBase
    {
        public int pidCta = 0,pidSolicitud=0;
        public string pcNroCuenta = "";

        public frmSolAprobTitular()
        {
            InitializeComponent();
        }

        private void frmSolAprobTitular_Load(object sender, EventArgs e)
        {
            ListarSolApr();
        }

        private void ListarSolApr()
        {
            clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();
            DataTable dtSolApr = solicitud.ListarSolicitudesCambioAprobadas();
            dtgSolAprobados.DataSource = dtSolApr;
            //---Formato Grid
            FormatoGrid();

            if (dtSolApr.Rows.Count>0)
            {
                btnAceptar.Enabled = true;
            }
        }

        private void FormatoGrid()
        {
            this.dtgSolAprobados.Columns["cNroCuenta"].Visible = false;
            this.dtgSolAprobados.Columns["idCli"].Visible = false;

            this.dtgSolAprobados.Columns["idCuenta"].HeaderText = "Cuenta";
            this.dtgSolAprobados.Columns["idCuenta"].Width = 80;
            this.dtgSolAprobados.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgSolAprobados.Columns["cNombre"].Width = 170;
            this.dtgSolAprobados.Columns["idSolicitud"].HeaderText = "Nro Solicitud";
            this.dtgSolAprobados.Columns["idSolicitud"].Width = 60;
            this.dtgSolAprobados.Columns["cMotivoExt"].HeaderText = "Motivo Cambio Titular";
            this.dtgSolAprobados.Columns["cMotivoExt"].Width = 200;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pidCta = 0;
            pidSolicitud = 0;
            pcNroCuenta = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgSolAprobados.RowCount > 0)
            {
                pidCta = Convert.ToInt32(dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString());
                pidSolicitud = Convert.ToInt32(dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["idSolicitud"].Value.ToString());
                pcNroCuenta = dtgSolAprobados.Rows[dtgSolAprobados.SelectedCells[0].RowIndex].Cells["cNroCuenta"].Value.ToString();
            }
            else
            {
                pidCta = 0;
                pidSolicitud = 0;
                pcNroCuenta = "";
            }

            this.Dispose();
        }

        private void dtgSolAprobados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void dtgSolAprobados_DoubleClick(object sender, EventArgs e)
        {
            this.btnAceptar.PerformClick();
        }
    }
}
