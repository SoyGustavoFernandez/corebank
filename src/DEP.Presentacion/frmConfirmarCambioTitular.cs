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
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmConfirmarCambioTitular : frmBase
    {
        int p_idCta = 0, p_idSol = 0;
        clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();

        public frmConfirmarCambioTitular()
        {
            InitializeComponent();
        }

        private void frmAplicarCambioTitular_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 12;  //--Ope Cancelación, Igual Lista todas las cuentas vigentes
            cboMotivos.CargarMotivos(5);
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.HabDeshabilitarCtrl(false) ;
            conBusCtaAho.btnBusCliente.Enabled = false;
            btnSolAprobadas.Focus();
        }

        private void btnSolAprobadas_Click(object sender, EventArgs e)
        {
            limpiarcontroles();
            conBusCtaAho.LimpiarControles();
            btnAceptar.Enabled = false;
            frmSolAprobTitular frmSolApr = new frmSolAprobTitular();
            frmSolApr.ShowDialog();
            if (frmSolApr.pidCta>0)
            {
                DataTable dtDatSol = solicitud.ListarDatosSolCta(frmSolApr.pidCta, frmSolApr.pidSolicitud);
                if (dtDatSol.Rows.Count>0)
                {
                    p_idCta = frmSolApr.pidCta;
                    p_idSol = frmSolApr.pidSolicitud;
                    conBusCtaAho.txtCodAge.Text = (frmSolApr.pcNroCuenta).ToString().Substring(3, 3);
                    conBusCtaAho.txtCodMod.Text = (frmSolApr.pcNroCuenta).ToString().Substring(6, 3);
                    conBusCtaAho.txtCodMon.Text = (frmSolApr.pcNroCuenta).ToString().Substring(9, 1);
                    conBusCtaAho.txtNroCta.Text = (frmSolApr.pcNroCuenta).ToString().Substring(10, 12);
                    conBusCtaAho.txtCodCli.Text = dtDatSol.Rows[0]["idCli"].ToString();
                    conBusCtaAho.txtNroDoc.Text = dtDatSol.Rows[0]["cDocumentoID"].ToString();
                    conBusCtaAho.txtNombre.Text = dtDatSol.Rows[0]["cNombre"].ToString();

                    txtProducto.Text = dtDatSol.Rows[0]["cProducto"].ToString();
                    cboMoneda.SelectedValue = Convert.ToInt16(dtDatSol.Rows[0]["idMoneda"].ToString());
                    txtTipoPersona.Text = dtDatSol.Rows[0]["cTipoPersona"].ToString();
                    dtFecApertura.Value = Convert.ToDateTime(dtDatSol.Rows[0]["dFechaApertura"].ToString());
                    cboTipoCuenta.SelectedValue = Convert.ToInt16(dtDatSol.Rows[0]["idTipoCuenta"].ToString());
                    txtNroFirmas.Text = dtDatSol.Rows[0]["nNumeroFirmas"].ToString();
                    chcITF.Checked = Convert.ToBoolean(dtDatSol.Rows[0]["lIsAfectoITF"].ToString());

                    cboMotivos.SelectedValue = Convert.ToInt16(dtDatSol.Rows[0]["idMotivo"].ToString());
                    txtFirmasNue.Text = dtDatSol.Rows[0]["nNorFirmas"].ToString();
                    txtMotCambio.Text = dtDatSol.Rows[0]["cMotivoCambio"].ToString();
                    txtDocRef.Text = dtDatSol.Rows[0]["cDocReferencia"].ToString();
                    txtCorreo.Text = dtDatSol.Rows[0]["cCorreo"].ToString();
                    txtNroTelf.Text = dtDatSol.Rows[0]["cNroContacto"].ToString();
                    dtpFechaDoc.Value = Convert.ToDateTime(dtDatSol.Rows[0]["dFechaDoc"].ToString());

                    //===============================================================================
                    //---Listar Intervinientes a Cambiar
                    //===============================================================================
                    DataTable dtInterv = solicitud.ListarCambioIntervinientes(frmSolApr.pidCta, frmSolApr.pidSolicitud);
                    dtgIntervinientes.DataSource = dtInterv;
                    FormatoGrid();
                    ColorDetalleOP();

                    btnAceptar.Enabled = true;
                }
            }
        }

        private void FormatoGrid()
        {
            this.dtgIntervinientes.Columns["idDetalle"].Visible = false;
            this.dtgIntervinientes.Columns["idCli"].Visible = false;
            this.dtgIntervinientes.Columns["idTipoInterv"].Visible = false;
            this.dtgIntervinientes.Columns["idTipoSolic"].Visible = false;

            this.dtgIntervinientes.Columns["idSolCambio"].HeaderText = "Cuenta";
            this.dtgIntervinientes.Columns["idSolCambio"].Width = 60;
            this.dtgIntervinientes.Columns["cDocumentoID"].HeaderText = "Nro. Documento";
            this.dtgIntervinientes.Columns["cDocumentoID"].Width = 60;
            this.dtgIntervinientes.Columns["cNombre"].HeaderText = "Nombre del Cliente";
            this.dtgIntervinientes.Columns["cNombre"].Width = 150;
            this.dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Interviniente";
            this.dtgIntervinientes.Columns["cTipoIntervencion"].Width = 70;
            this.dtgIntervinientes.Columns["cDescripcion"].HeaderText = "Tipo Solicitud";
            this.dtgIntervinientes.Columns["cDescripcion"].Width = 150;
        }

        private void limpiarcontroles()
        {
            //---Datos de la Cuenta
            txtProducto.Clear();
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            txtTipoPersona.Clear();
            dtFecApertura.Value = clsVarGlobal.dFecSystem;
            txtNroFirmas.Clear();
            chcITF.Checked = false;

            //---Datos de los Grid
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();
                       
            //---Datos de la Solicitud
            cboMotivos.SelectedValue = 1;
            txtMotCambio.Clear();
            txtFirmasNue.Clear();
            txtDocRef.Clear();
            dtpFechaDoc.Value = clsVarGlobal.dFecSystem;
            txtCorreo.Clear();
            txtNroTelf.Clear();
        }

        private void ColorDetalleOP()
        {
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoSolic"].Value) == 2)
                {
                    dtgIntervinientes.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dtgIntervinientes.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p_idCta = 0;
            p_idSol = 0;
            conBusCtaAho.LimpiarControles();
            limpiarcontroles();
            btnAceptar.Enabled = false;
            btnSolAprobadas.Enabled = true;
            btnSolAprobadas.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count<=0)
            {
                MessageBox.Show("No hay detalle de intervinientes a Cambiar...Verificar", "Cambio de Titulares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;                
            }

            int x_idSolCambio = Convert.ToInt32(dtgIntervinientes.Rows[dtgIntervinientes.SelectedCells[0].RowIndex].Cells["idSolCambio"].Value.ToString());

            DataTable dtCambTit = solicitud.ConfirmarCambioTitulares(p_idCta, p_idSol, x_idSolCambio, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(dtCambTit.Rows[0]["idRpta"])==0)
            {
                MessageBox.Show(dtCambTit.Rows[0]["cMensaje"].ToString(), "Cambio de Titulares", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtCambTit.Rows[0]["cMensaje"].ToString(), "Cambio de Titulares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnAceptar.Enabled = false;
        }

    }
}
