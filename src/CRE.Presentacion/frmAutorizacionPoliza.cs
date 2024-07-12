using CRE.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmAutorizacionPoliza : frmBase
    {
        private clsCNSolCre clsCNSolCre = new clsCNSolCre();
        private DataTable dtPendientes= new DataTable();        

        public frmAutorizacionPoliza()
        {
            InitializeComponent();
        }

        private void frmAprobacionPoliza_Load(object sender, EventArgs e)
        {
            obtenerAutorizacionPendientes();
        }

        private void setDecision(int idSolicitud)
        {
            if (idSolicitud > 0)
            {
                this.label2.Text = "Desición - Solicitud " + idSolicitud;
                this.tbSustento.Enabled = true;
                this.btnAprobar1.Enabled = true;
                this.btnDenegar2.Enabled = true;
                this.linkExpediente.Visible = true;
                this.linkExpediente.Enabled = true;
            }
            else
            {
                this.label2.Text = "Desición (Seleccione una Solicitud de Crédito)";
                this.tbSustento.Enabled = false;
                this.btnAprobar1.Enabled = false;
                this.btnDenegar2.Enabled = false;
                this.linkExpediente.Visible = false;
                this.linkExpediente.Enabled = false;
            }
        }

        private void obtenerAutorizacionPendientes()
        {
            this.dtPendientes = this.clsCNSolCre.CNObtenerAutorizacionPolizaPendientes();
            this.dgvPendientes.DataSource = dtPendientes;
            this.tbSustento.Text = "";
            if (dtPendientes.Rows.Count == 0)
            {
                setDecision(0);
            }
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvPendientes.CurrentCell != null)
            {
                int indexRow = this.dgvPendientes.CurrentCell.RowIndex;
                int idSolicitud = Convert.ToInt32(this.dgvPendientes.Rows[indexRow].Cells["idSolicitud"].Value.ToString());
                this.setDecision(idSolicitud);
            }
            else
            {
                this.setDecision(0);
            }
        }

        private bool validarDecision()
        {
            if (this.dgvPendientes.CurrentCell == null)
            {
                MessageBox.Show("No se tiene seleccionado una solicitud.", "Error - Decisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.tbSustento.Text))
            {
                this.tbSustento.Focus();
                MessageBox.Show("Debe ingresar el sustento de la decisión", "Error - Decisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void registrarDecision(bool lAprobado)
        {
            int indexRow = this.dgvPendientes.CurrentCell.RowIndex;
            int idSolicitud = Convert.ToInt32(this.dgvPendientes.Rows[indexRow].Cells["idSolicitud"].Value.ToString());
            string cSustento = this.tbSustento.Text;
            int idPerfilDecision = EntityLayer.clsVarGlobal.PerfilUsu.idPerfil;
            int idUsuarioDecision = EntityLayer.clsVarGlobal.PerfilUsu.idUsuario;
            try
            {
                DataTable dtRes = this.clsCNSolCre.CNRegistrarDecisionAutorizacionPoliza(idSolicitud, cSustento, lAprobado, idPerfilDecision, idUsuarioDecision);
                MessageBox.Show("La decisión se registró correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falló el registro de la decisión: " + e.Message, "Error - Registro Decisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            obtenerAutorizacionPendientes();
        }

        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (!this.validarDecision())
                return;
            this.registrarDecision(true);
        }

        private void btnDenegar2_Click(object sender, EventArgs e)
        {
            if (!this.validarDecision())
                return;
            this.registrarDecision(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.dgvPendientes.CurrentCell == null)
            {
                MessageBox.Show("No se tiene seleccionado una solicitud.", "Expediente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indexRow = this.dgvPendientes.CurrentCell.RowIndex;
            int idSolicitud = Convert.ToInt32(this.dgvPendientes.Rows[indexRow].Cells["idSolicitud"].Value.ToString());
            int idCliente = Convert.ToInt32(this.dgvPendientes.Rows[indexRow].Cells["idCli"].Value.ToString());
            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(idSolicitud, idCliente, "individual");
            frmExpLinea.ShowDialog();
        }
    }
}
