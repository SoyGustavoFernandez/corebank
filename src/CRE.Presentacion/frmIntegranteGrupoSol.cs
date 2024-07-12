using EntityLayer;
using GEN.CapaNegocio;
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
    public partial class frmIntegranteGrupoSol : frmBase
    {
        private clsGrupoSolidarioIntegrante objGrupoSolIntegrante;
        private int idEvalCredGrupoSol;
        private int idCli;

        public frmIntegranteGrupoSol()
        {
            idEvalCredGrupoSol = 0;
            idCli = 0;

            InitializeComponent();

            conBusCli.BorderStyle = BorderStyle.None;
            this.btnAceptar.Enabled = false;

            HabilitarControles(false);

            objGrupoSolIntegrante = new clsGrupoSolidarioIntegrante();
            //LimpiarControles();
        }

        #region Métodos Públicos
        public clsGrupoSolidarioIntegrante Integrante
        {
            get { return this.objGrupoSolIntegrante; }
            set { this.objGrupoSolIntegrante = value; }
        }
        #endregion

        #region Métodos Privados
        private void LimpiarControles()
        {
            this.conBusCli.limpiarControles();
            this.cboCargo.SelectedIndex = 0;
            this.cboCiclo.SelectedIndex = 0;
            this.dtFechaIntegracion.Value = clsVarGlobal.dFecSystem;
            this.chcDomicilio.Checked = false;
        }

        private void HabilitarControles(bool lHabilitado)
        {
            this.conBusCli.txtCodCli.Enabled = !lHabilitado;
            this.cboCargo.Enabled = lHabilitado;
            this.cboCiclo.Enabled = lHabilitado;
            this.dtFechaIntegracion.Enabled = lHabilitado;
            this.chcDomicilio.Enabled = lHabilitado;
        }
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitarControles(false);

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.conBusCli.txtCodCli.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idCliente = conBusCli.idCli;
            DataTable dt = (new CRE.CapaNegocio.clsCNGrupoSolidario()).FiltrarRepetidosGS(idCliente);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("El cliente ya se encuentra registrado en el Grupo Solidario/Banca Comunal : "
                    + dt.Rows[0]["idGrupoSolidario"].ToString() + " : " + dt.Rows[0]["cNombreGrupo"].ToString(),
                    "Integrante Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAceptar.Enabled = false;

            }
            else
            {

                objGrupoSolIntegrante.cNombreCliente = conBusCli.txtNombre.Text;
                objGrupoSolIntegrante.cNumDocumento = conBusCli.txtNroDoc.Text;
                objGrupoSolIntegrante.idCli = conBusCli.idCli;
                objGrupoSolIntegrante.idGrupoSolidarioCargo = Convert.ToInt32(cboCargo.SelectedValue);
                objGrupoSolIntegrante.idGrupoSolidarioCiclo = Convert.ToInt32(cboCiclo.SelectedValue);
                objGrupoSolIntegrante.cCargo = cboCargo.Text;
                objGrupoSolIntegrante.cCiclo = cboCiclo.Text;
                objGrupoSolIntegrante.dFechaIntegracion = dtFechaIntegracion.Value;
                objGrupoSolIntegrante.lDomicilioGrupo = chcDomicilio.Checked;

                this.Close();
            }
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (this.conBusCli.idCli != 0)
            {
                // falta incluir 
                /*DataTable dt = (new CRE.CapaNegocio.clsCNGrupoSolidario()).ValidarIntegranteGrupoSol(this.idEvalCredGrupoSol, this.conBusCli.idCli);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["idMsje"].Equals("0"))
                    {
                        MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Integrante Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }*/


                if (this.conBusCli.lIndDatosBasicos == true)
                {
                    MessageBox.Show("Debe registrar datos completos del cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnCancelar.Enabled = true;
                    btnCancelar.PerformClick();
                    
                    return;
                }

                HabilitarControles(true);

                this.btnAceptar.Enabled = true;
                this.btnCancelar.Enabled = true;

                cboCargo.Focus();
            }
            else
            {
                btnCancelar.PerformClick();
            }
        }

        private void frmIntegranteGrupoSol_Shown(object sender, EventArgs e)
        {
            LimpiarControles();
            this.conBusCli.txtCodCli.Focus();
            this.cboCargo.SelectedValue = 3;
        }
        #endregion

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCargo.DataSource != null && Convert.ToInt32(this.cboCargo.SelectedValue) == 1)
            {
                this.chcDomicilio.Checked = true;
            }
            else
            {
                this.chcDomicilio.Checked = false;
            }
        }

    }
}
