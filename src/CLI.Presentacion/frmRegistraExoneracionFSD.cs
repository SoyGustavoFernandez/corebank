using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;

namespace CLI.Presentacion
{
    public partial class frmRegistraExoneracionFSD : frmBase
    {
        public frmRegistraExoneracionFSD()
        {
            InitializeComponent();
        }

        private void frmRegistraExoneracionFSD_Load(object sender, EventArgs e)
        {
            chcExoneraFSD.Enabled = false;
            txtMotivoExonera.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            Buscar();
        }

        private void chcExoneraFSD_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivoExonera.Enabled = chcExoneraFSD.Checked;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conBusCli.btnBusCliente.Enabled = false;
            chcExoneraFSD.Enabled = true;
            txtMotivoExonera.Enabled = chcExoneraFSD.Checked;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCli.idCli, this.conBusCli.idCli, "Inicio-Exoneracion FSD", this.btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            int idCliente = Convert.ToInt32(conBusCli.txtCodCli.Text);
            bool lExoneraFSD = chcExoneraFSD.Checked;
            string cMotivoExonera = txtMotivoExonera.Text;
            
            if (lExoneraFSD == true && cMotivoExonera == "")
            {
                MessageBox.Show("Ingresar Motivo de Exoneración de FSD", "Exoneración de FSD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMotivoExonera.Focus();
                return;
            }

            conBusCli.btnBusCliente.Enabled = true;
            chcExoneraFSD.Enabled = false;
            txtMotivoExonera.Enabled = false;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;

            clsCNCliente objCliente = new clsCNCliente();
            DataTable dtRegExoneraFSD = objCliente.CNRegistrarExoneracionFSD(idCliente, lExoneraFSD, clsVarGlobal.dFecSystem, cMotivoExonera);
            MessageBox.Show(dtRegExoneraFSD.Rows[0]["cMensaje"].ToString(), "Exoneración de FSD", MessageBoxButtons.OK, (Convert.ToInt32(dtRegExoneraFSD.Rows[0]["idError"]) == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error));

            Buscar();

            /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(this.conBusCli.idCli, this.conBusCli.idCli, "Fin-Exoneracion FSD", this.btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Enabled == false)
            {
                conBusCli.btnBusCliente.Enabled = true;
                chcExoneraFSD.Enabled = false;
                txtMotivoExonera.Enabled = false;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;

                Buscar();
            }
            else
            {
                conBusCli.txtCodCli.Clear();
                conBusCli.txtNombre.Clear();
                conBusCli.txtNroDoc.Clear();
                conBusCli.txtDireccion.Clear();
                conBusCli.txtCodInst.Clear();
                conBusCli.txtCodAge.Clear();
                chcExoneraFSD.Checked = false;
                txtMotivoExonera.Text = "";

                conBusCli.btnBusCliente.Enabled = true;
                conBusCli.txtCodCli.Enabled = true;
                conBusCli.txtCodCli.Focus();
                btnEditar.Enabled = false;
            }
        }

        private void Buscar()
        {
            if (conBusCli.txtCodCli.Text.Trim() == "")
            {
                chcExoneraFSD.Checked = false;
                txtMotivoExonera.Text = "";
                txtMotivoExonera.Enabled = false;
                btnEditar.Enabled = false;
                
                return;
            }

            int idCliente = Convert.ToInt32(conBusCli.txtCodCli.Text);

            clsCNRetDatosCliente objDatosCliente = new clsCNRetDatosCliente();
            DataTable dtDatosCliente = objDatosCliente.ListarDatosCli(idCliente, "E");

            if (dtDatosCliente.Rows.Count > 0)
            {
                chcExoneraFSD.Checked = (bool)dtDatosCliente.Rows[0]["lExoneraFSD"];
                txtMotivoExonera.Text = dtDatosCliente.Rows[0]["cMotivoExonera"].ToString();
                txtMotivoExonera.Enabled = false;
                btnEditar.Enabled = true;
            }
            else
            {
                chcExoneraFSD.Checked = false;
                txtMotivoExonera.Text = "";
                txtMotivoExonera.Enabled = false;
                btnEditar.Enabled = false;
            }
        }
    }
}
