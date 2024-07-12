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
using System.Text.RegularExpressions;

namespace CLI.Presentacion
{
    public partial class frmBaseNegativa : frmBase
    {
        clsCNBaseNegativaClientes objBaseNegativa = new clsCNBaseNegativaClientes();
        DataTable dtBaseNegativa;
        int idCli = 0;
        bool lNuevo = false;
        ToolTip buttonToolTip = new ToolTip();

        public frmBaseNegativa()
        {
            InitializeComponent();

            DataTable dtTipoPersona = new DataTable();

            dtTipoPersona.Columns.Add("valor", typeof(int));
            dtTipoPersona.Columns.Add("descripcion", typeof(string));

            dtTipoPersona.Rows.Add(1, "Persona Natural");
            dtTipoPersona.Rows.Add(2, "Persona Jurídica");

            cboTipoPersona.DataSource = dtTipoPersona;
            cboTipoPersona.ValueMember = "valor";
            cboTipoPersona.DisplayMember = "descripcion";

            cboTipoPersona.SelectedValue = -1;
        }

        private void HabilitarControles(bool lEstado)
        {
            chcNoCliente.Enabled = lEstado;
            txtDescripcion.Enabled = lEstado;

            if (lEstado == true)
            {
                if (chcNoCliente.Checked == true)
                {
                    cboModuloEdit.Enabled = true;
                    cboTipoPersona.Enabled = true;
                    cboTipoDocumento.Enabled = true;
                    txtNroDoc.Enabled = true;
                    txtNombre.Enabled = true;
                    txtApPaterno.Enabled = true;
                    txtApMaterno.Enabled = true;
                    txtNomRazonSocial.Enabled = true;
                    cboMotivoBloqueo.Enabled = true;
                    btnBusCliente.Enabled = false;
                }
                else
                {
                    cboModuloEdit.Enabled = false;
                    cboTipoPersona.Enabled = false;
                    cboTipoDocumento.Enabled = false;
                    txtNroDoc.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApPaterno.Enabled = false;
                    txtApMaterno.Enabled = false;
                    txtNomRazonSocial.Enabled = false;
                    cboMotivoBloqueo.Enabled = true;
                    btnBusCliente.Enabled = true;
                }
            }
            else
            {
                cboModuloEdit.Enabled = lEstado;
                cboTipoPersona.Enabled = lEstado;
                cboTipoDocumento.Enabled = lEstado;
                txtNroDoc.Enabled = lEstado;
                txtNombre.Enabled = lEstado;
                txtApPaterno.Enabled = lEstado;
                txtApMaterno.Enabled = lEstado;
                txtNomRazonSocial.Enabled = lEstado;
                cboMotivoBloqueo.Enabled = lEstado;
                btnBusCliente.Enabled = lEstado;
            }
        }

        private void cargarBaseNegativa(int idModulo,int idBaseNegativa)
        {
            dtBaseNegativa = objBaseNegativa.CNListarClientesBaseNegativa(idModulo, idBaseNegativa);
            dtgBaseNegativa.DataSource = dtBaseNegativa;
        }

        private void frmBaseNegativa_Load(object sender, EventArgs e)
        {
            cboModulo.LisModuloBaseNegativa();

            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEliminar.Enabled = true;

            HabilitarControles(false);
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;

            if (cboModulo.Items.Count > 0)
            {
                cboModuloEdit.SelectedValue = (int)cboModulo.SelectedValue;
                cargarBaseNegativa((int)cboModulo.SelectedValue,0);
                HabilitarControles(false);
            }
            else
            {
                dtBaseNegativa.Clear();
                dtgBaseNegativa.DataSource = dtBaseNegativa;
            }
            if (dtgBaseNegativa.Rows.Count>0)
            {
                btnEditar.Enabled = true;
            }
        }

        private void dtgBaseNegativa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int nFilaBaseNegativa = e.RowIndex;

            chcNoCliente.Checked = ((int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idCli"] == 0 ? true : false);
            cboTipoPersona.SelectedValue = (int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idTipoPersona"];
            cboTipoDocumento.SelectedValue = (int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idTipoDocumento"];
            txtNroDoc.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cDocumentoID"].ToString();
            cboModuloEdit.SelectedValue = (int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idModulo"];

            if ((int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idTipoPersona"] == 1)
            {
                txtNombre.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cNombre"].ToString().Trim();
                txtApPaterno.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cApellidoPaterno"].ToString().Trim();
                txtApMaterno.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cApellidoMaterno"].ToString().Trim();
                txtNomRazonSocial.Text = "";
            }
            else
            {
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtNomRazonSocial.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cNomCompleto"].ToString().Trim();
            }

            cboMotivoBloqueo.SelectedValue = dtBaseNegativa.Rows[nFilaBaseNegativa]["idMotivoBloq"].ToString();
            txtDescripcion.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cMotivo"].ToString();
            if (lNuevo)
            {

            }
            else
            {
                HabilitarControles(false);
                cboTipoPersona.Enabled = false;
                cboTipoDocumento.Enabled = false;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lNuevo = true;
            LimpiarControles();
            cboModuloEdit.SelectedValue = (int)cboModulo.SelectedValue;
            cboTipoPersona.Focus();
            HabilitarControles(true);
            cboModulo.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnEditar.Enabled = false;
            btnBusClienteBN.Enabled = false;
            btnEliminar.Enabled = false;
            cboModuloEdit.Enabled = false;
            dtgBaseNegativa.Enabled = false;

        }

        private void LimpiarControles()
        {
            idCli = 0;
            cboTipoPersona.SelectedValue = -1;
            cboTipoDocumento.SelectedValue = -1;
            txtNroDoc.Text = "";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtNomRazonSocial.Text = "";
            cboMotivoBloqueo.SelectedValue = -1;
            txtDescripcion.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            cboModulo.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = true;
            btnBusClienteBN.Enabled = true;
            HabilitarControles(false);
            lNuevo = false;
            if (dtgBaseNegativa.Rows.Count>0)
            {
                btnEditar.Enabled = true;
            }
            HabilitarControles(false);
            dtgBaseNegativa.Enabled = true;
            dtgBaseNegativa.Focus();
        }

        private bool ValidarDatosGrabar()
        {
            if (cboTipoPersona.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar el tipo de persona", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoPersona.Focus();
                return false;
            }
            if (cboTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de documento", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoDocumento.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNroDoc.Text.Trim()))
            {
                MessageBox.Show((chcNoCliente.Checked == true ? "Ingrese Nro de Documento" : "Ingrese Cliente"), "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNroDoc.Focus();
                return false;
            }

            switch (Convert.ToInt16(cboTipoDocumento.SelectedValue))
            {
                case 1:
                    if (txtNroDoc.Text.Trim().Length != 8)
                    {
                        MessageBox.Show("El DNI debe tener 8 dígitos, Verificar...", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNroDoc.Focus();
                        return false;
                    }
                    break;
                case 11:
                    if (txtNroDoc.Text.Trim().Length != 8)
                    {
                        MessageBox.Show("El DNI del menor debe tener 8 dígitos, Verificar...", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNroDoc.Focus();
                        return false;
                    }
                    break;
                case 4:
                    if (txtNroDoc.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("El RUC debe tener 11 dígitos, Verificar...", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNroDoc.Focus();
                        return false;
                    }
                    break;
                default:
                    break;
            }

            if ((int)cboTipoPersona.SelectedValue == 1)
            {
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar el Nombre del Cliente", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtApPaterno.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar el apellido paterno del Cliente", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtApPaterno.Focus();
                    return false;
                }

                //if (string.IsNullOrEmpty(txtApMaterno.Text.Trim()))
                //{
                //    MessageBox.Show((chcNoCliente.Checked == true ? "Ingrese Apellido Materno" : "Ingrese Cliente"), "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtApMaterno.Focus();
                //    return false;
                //}
            }
            else if ((int)cboTipoPersona.SelectedValue == 2)
            {
                if (string.IsNullOrEmpty(txtNomRazonSocial.Text.Trim()))
                {
                    MessageBox.Show("Ingrese Razón Social", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomRazonSocial.Focus();
                    return false;
                }
            }

            if (cboMotivoBloqueo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Motivo de Bloqueo", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMotivoBloqueo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Ingrese la descripción del motivo", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return false;
            }

            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (lNuevo)
            {
                if (!ValidarDatosGrabar())
                {
                    return;
                }
            }
            else
            {
                if (!ValidarDatosEditar())
                {
                    return;
                }
            }

            //Datos
            int idModulo = (int)cboModulo.SelectedValue;
            int idTipoPersona = (int)cboTipoPersona.SelectedValue;
            int idTipoDocumento = (int)cboTipoDocumento.SelectedValue;
            string cDocumentoID = txtNroDoc.Text.Trim();
            string cNombre = txtNombre.Text.Trim();
            string cApPaterno = txtApPaterno.Text.Trim();
            string cApMaterno = txtApMaterno.Text.Trim();
            string cRazonSocial = txtNomRazonSocial.Text.Trim();
            string cDescripcion = txtDescripcion.Text.Trim();
            int idMotivoBloq = (int)cboMotivoBloqueo.SelectedValue;
            //-----------------------------------------------------------------------------------
            //----Grabar
            //-----------------------------------------------------------------------------------
            if (lNuevo)
            {
                DataTable dtInsertarBaseNegativa = objBaseNegativa.CNInsertarClienteBaseNegativa(idModulo, idCli, idTipoPersona, idTipoDocumento, cDocumentoID, cNombre, cApPaterno, cApMaterno, cRazonSocial, cDescripcion,
                                idMotivoBloq, 0, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario);
                if ((int)dtInsertarBaseNegativa.Rows[0]["idError"] == 0 )
                {
                    MessageBox.Show(dtInsertarBaseNegativa.Rows[0]["cMensaje"].ToString(), "Registrar en la Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtInsertarBaseNegativa.Rows[0]["cMensaje"].ToString(), "Registrar en la Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int idModuloNew = (int)cboModuloEdit.SelectedValue;
                int idBaseNegativa = (int)dtgBaseNegativa.CurrentRow.Cells["dtgtxtIdBaseNegativa"].Value;
                DataTable dtActualizarBaseNegativa = objBaseNegativa.CNActualizarClienteBaseNegativa(idBaseNegativa, cNombre, cApPaterno, cApMaterno, cRazonSocial, cDescripcion, idMotivoBloq, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario, idModuloNew);
                if ((int)dtActualizarBaseNegativa.Rows[0]["idError"] == 0 )
                {
                    MessageBox.Show(dtActualizarBaseNegativa.Rows[0]["cMensaje"].ToString(), "Actualizar Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtActualizarBaseNegativa.Rows[0]["cMensaje"].ToString(), "Actualizar Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            //Deshabilitar controles
            cboModulo.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnBusClienteBN.Enabled = true;
            cargarBaseNegativa(idModulo,0);
            HabilitarControles(false);
            dtgBaseNegativa.Enabled = true;
            lNuevo = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgBaseNegativa.Rows.Count<=0)
            {
                MessageBox.Show("No existen datos para su eliminación...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModulo.Focus();
                return;
            }

            if (this.cboTipoPersona.SelectedIndex != -1 && this.cboTipoDocumento.SelectedIndex != -1 && this.txtNroDoc.Text.Trim() != "")
            {
                int idBaseNegativa = (int)dtgBaseNegativa.CurrentRow.Cells["dtgtxtIdBaseNegativa"].Value;
                clsCNBaseNegativaClientes objBaseNegativa = new clsCNBaseNegativaClientes();
                DataTable dtObtenerEstSolAproPerBN = objBaseNegativa.CNObtenerEstadoSolAproPersonaBN(idBaseNegativa,clsVarGlobal.nIdAgencia,clsVarGlobal.dFecSystem);

                if (dtObtenerEstSolAproPerBN.Rows.Count > 0 && Convert.ToInt32(dtObtenerEstSolAproPerBN.Rows[0]["idEstadoSol"]) > 0)
                {
                    int x_idEstSol = Convert.ToInt32(dtObtenerEstSolAproPerBN.Rows[0]["idEstadoSol"]);
                    int x_idSolApr = Convert.ToInt32(dtObtenerEstSolAproPerBN.Rows[0]["idSolAproba"]);
                    switch (x_idEstSol)
                    {
                        case 1: //--Solicitado
                            MessageBox.Show("Ya tiene una solicitud registrada, Falta ser aprobada...Verificar...", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        case 2: //--Aprobado
                            DialogResult dResultado = MessageBox.Show("Se encontro una solicitud de desbloqueo aprobada. ¿Esta seguro de eliminar a la Persona de la Base Negativa?", "Base Negativa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dResultado == DialogResult.Yes)
                            {
                                DataTable dtEliminarBaseNegativa = objBaseNegativa.CNEliminarClienteBaseNegativa(idBaseNegativa, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario, x_idSolApr);
                                MessageBox.Show(dtEliminarBaseNegativa.Rows[0]["cMensaje"].ToString(), "Base Negativa", MessageBoxButtons.OK, ((int)dtEliminarBaseNegativa.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                                int idModulo = (int)cboModulo.SelectedValue;
                                cargarBaseNegativa(idModulo, 0);
                            }
                            return;
                    }
                }
                else
                {
                    DialogResult dResultado = MessageBox.Show("No se encuentra una solicitud resgitrada para el desbloqueo. ¿Desea enviar una nueva solicitud?", "Base Negativa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dResultado == DialogResult.Yes)
                    {
                        //Solicitud
                        int x_nEsCli = 0;
                        int x_idCli=0;
                        string x_cNombre = "";
                        x_idCli = (int)dtgBaseNegativa.CurrentRow.Cells["dtgtxtIdCli"].Value;
                        if (Convert.ToInt32(this.cboTipoPersona.SelectedValue)==1)
                        {
                            x_cNombre = txtNombre.Text+" "+txtApPaterno.Text+" "+txtApMaterno.Text;
                        }
                        else
                        {
                            x_cNombre = txtNomRazonSocial.Text;
                        }
                        if (!chcNoCliente.Checked)
                        {
                            x_nEsCli = 1;
                        }
                        frmSoliciDesbloqClienteBN objSoliciDesbloqClienteBN = new frmSoliciDesbloqClienteBN();
                        objSoliciDesbloqClienteBN.p_idbasenegativa = idBaseNegativa;
                        objSoliciDesbloqClienteBN.idCli = x_idCli;
                        objSoliciDesbloqClienteBN.p_idTipoPersona = Convert.ToInt32(this.cboTipoPersona.SelectedValue);
                        objSoliciDesbloqClienteBN.p_idTipoDoc = Convert.ToInt32(this.cboTipoDocumento.SelectedValue);
                        objSoliciDesbloqClienteBN.idMotivoBloq = Convert.ToInt32(this.cboMotivoBloqueo.SelectedValue);

                        if (this.cboTipoPersona.SelectedIndex != -1 && this.cboTipoDocumento.SelectedIndex != -1 && this.txtNroDoc.Text.Trim() != "")
                        {
                            objSoliciDesbloqClienteBN.inicializarSoliciDesbloqClienteBN(x_nEsCli, x_idCli, Convert.ToInt32(this.cboTipoPersona.SelectedValue), Convert.ToInt32(this.cboTipoDocumento.SelectedValue), this.txtNroDoc.Text, x_cNombre);
                            objSoliciDesbloqClienteBN.ShowDialog();
                        }

                        //int idModulo = (int)cboModulo.SelectedValue;
                        //cargarBaseNegativa(idModulo, 0);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione a una persona de la base negativa antes de continuar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            int idModuloBuscar = (int)cboModulo.SelectedValue;
            cargarBaseNegativa(idModuloBuscar, 0);
            HabilitarControles(false);
            btnEditar.Enabled = true;
            btnBusClienteBN.Enabled = true;
            dtgBaseNegativa.Enabled = true;
            lNuevo = false;
        }

        private void chcCliRem_CheckedChanged(object sender, EventArgs e)
        {
            if (btnNuevo.Enabled == false && chcNoCliente.Enabled == true)
            {
                HabilitarControles(true);
                idCli = 0;
                cboTipoPersona.SelectedValue = -1;
                cboTipoDocumento.SelectedValue = -1;
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtNomRazonSocial.Text = "";
            }
            cboModuloEdit.Enabled = false;

        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            frmBusCliBN frmbuscarclibn = new frmBusCliBN();
            frmbuscarclibn.ShowDialog();

            if (string.IsNullOrEmpty(frmbuscarclibn.pcCodCli))
            {
                idCli = 0;
                cboTipoPersona.SelectedValue = -1;
                cboTipoDocumento.SelectedIndex = -1;
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtNomRazonSocial.Text = "";
                return;
            }

            if (frmbuscarclibn.pnTipoPersona == 1)
            {
                idCli = Convert.ToInt32(frmbuscarclibn.pcCodCli);
                cboTipoPersona.SelectedValue = 1;
                cboTipoDocumento.SelectedValue = frmbuscarclibn.pnTipoDocumento;
                txtNroDoc.Text = frmbuscarclibn.pcNroDoc;
                txtNombre.Text = frmbuscarclibn.pcNombre;
                txtApPaterno.Text = frmbuscarclibn.pcApellidoPaterno;
                txtApMaterno.Text = frmbuscarclibn.pcApellidoMaterno;
                txtNomRazonSocial.Text = "";
            }
            else if (frmbuscarclibn.pnTipoPersona == 2)
            {
                idCli = Convert.ToInt32(frmbuscarclibn.pcCodCli);
                cboTipoPersona.SelectedValue = 2;
                cboTipoDocumento.SelectedValue = frmbuscarclibn.pnTipoDocumento;
                txtNroDoc.Text = frmbuscarclibn.pcNroDoc;
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtNomRazonSocial.Text = frmbuscarclibn.pcRazonSocial;
            }
            else
            {
                idCli = 0;
                cboTipoPersona.SelectedValue = -1;
                cboTipoDocumento.SelectedIndex = -1;
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txtNomRazonSocial.Text = "";
            }
        }

        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chcNoCliente.Checked == true)
            {
                if (Convert.ToInt32(cboTipoPersona.SelectedValue) == 1)
                {
                    cboTipoPersona.Enabled = true;
                    cboTipoDocumento.Enabled = true;
                    cboTipoDocumento.SelectedValue = 1;
                    txtNroDoc.Enabled = true;
                    txtNombre.Enabled = true;
                    txtApPaterno.Enabled = true;
                    txtApMaterno.Enabled = true;
                    txtNomRazonSocial.Enabled = false;
                }
                else if (Convert.ToInt32(cboTipoPersona.SelectedValue) == 2)
                {
                    cboTipoPersona.Enabled = true;
                    cboTipoDocumento.Enabled = true;
                    cboTipoDocumento.SelectedValue = 4;
                    txtNroDoc.Enabled = true;
                    txtNombre.Enabled = false;
                    txtApPaterno.Enabled = false;
                    txtApMaterno.Enabled = false;
                    txtNomRazonSocial.Enabled = true;
                }

                txtNroDoc.Text = "";
                txtNomRazonSocial.Text = "";
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
            }
            else
            {
                cboTipoPersona.Enabled = false;
                cboTipoDocumento.Enabled = false;
                cboTipoDocumento.SelectedValue = -1;
                txtNroDoc.Enabled = false;
                txtNombre.Enabled = false;
                txtApPaterno.Enabled = false;
                txtApMaterno.Enabled = false;
                txtNomRazonSocial.Enabled = false;
            }
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNroDoc.Clear();
            switch (Convert.ToInt16(cboTipoDocumento.SelectedValue))
            {
                case 1:
                    txtNroDoc.MaxLength = 8;
                    break;
                case 11:
                    txtNroDoc.MaxLength = 8;
                    break;
                case 4:
                    txtNroDoc.MaxLength = 11;
                    break;
                default:
                    txtNroDoc.MaxLength = 15;
                    break;
            }
            txtNroDoc.Focus();
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboTipoDocumento.SelectedIndex==-1)
            {
                MessageBox.Show("Primero debe seleccionar el Tipo de Documento", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroDoc.Clear();
                cboTipoDocumento.Focus();
                return;
            }
            //Solo acepta numeros
            int tipdoc = (int)cboTipoDocumento.SelectedValue;
            if (tipdoc == 1 || tipdoc == 4 || tipdoc == 11) //DNI, RUC, DNI Menor
            {
                if (e.KeyChar == 8)
                    e.Handled = false;
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;

                else
                    e.Handled = true;
            }

            //Acepta numeros y letras

            else
            {
                if (e.KeyChar == 8)
                    e.Handled = false;
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar >= 65 && e.KeyChar <= 90)
                    e.Handled = false;
                else if (e.KeyChar >= 97 && e.KeyChar <= 122)
                    e.Handled = false;

                else
                    e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dtgBaseNegativa.Refresh();
            if (dtgBaseNegativa.Rows.Count<=0)
            {
                MessageBox.Show("No existen datos para modificar...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModulo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNroDoc.Text))
            {
                MessageBox.Show("No existen datos para modificar...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModulo.Focus();
                return;
            }

            lNuevo = false;
            cboTipoPersona.Enabled = false;
            cboTipoDocumento.Enabled = false;
            if ((int)cboTipoPersona.SelectedValue==1)
            {
                cboModuloEdit.Enabled = true;
                if (chcNoCliente.Checked)
                {
                    txtNombre.Enabled = true;
                    txtApPaterno.Enabled = true;
                    txtApMaterno.Enabled = true;
                    txtNomRazonSocial.Enabled = false;
                }
                else
                {
                    txtNombre.Enabled = false;
                    txtApPaterno.Enabled = false;
                    txtApMaterno.Enabled = false;
                    txtNomRazonSocial.Enabled = false;
                }

            }
            else
            {
                cboModuloEdit.Enabled = true;
                txtNombre.Enabled = false;
                txtApPaterno.Enabled = false;
                txtApMaterno.Enabled = false;
                if (chcNoCliente.Checked)
                {
                    txtNomRazonSocial.Enabled = true;
                }
                else
                {
                    txtNomRazonSocial.Enabled = false;
                }

            }
            cboMotivoBloqueo.Enabled = true;
            txtDescripcion.Enabled = true;

            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnEditar.Enabled = false;
            btnBusClienteBN.Enabled = false;
            btnEliminar.Enabled = false;
            dtgBaseNegativa.Enabled = false;
            cboModulo.Enabled = false;
            cboModuloEdit.Focus();
        }

        private bool ValidarDatosEditar()
        {
            if ((int)cboTipoPersona.SelectedValue==1)
            {
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el nombre del Cliente...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return false; ;
                }
                if (string.IsNullOrEmpty(txtApPaterno.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el apellido paterno del Cliente...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApPaterno.Focus();
                    return false; ;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtNomRazonSocial.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar la Razón social...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomRazonSocial.Focus();
                    return false; ;
                }
            }

            if (cboMotivoBloqueo.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar el motivo del bloqueo del Cliente...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMotivoBloqueo.Focus();
                return false; ;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la descripción...Verificar", "Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false; ;
            }
            return true;
        }

        private void btnBusClienteBN_Click(object sender, EventArgs e)
        {
            cboModulo.Enabled = true;
            int idModulo = (int)cboModulo.SelectedValue;
            frmBusCliBN frmbuscarclibn = new frmBusCliBN();
            frmbuscarclibn.nTipoBus = 2;
            frmbuscarclibn.ShowDialog();

            if (frmbuscarclibn.pnidBaseNegativa>0)
            {
                cargarBaseNegativa(idModulo, frmbuscarclibn.pnidBaseNegativa);
                btnNuevo.Enabled = false;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                cboModulo.Enabled = false;
            }
            else
            {
                cboModulo.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            btnCancelar.PerformClick();
        }

        private void dtgBaseNegativa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgBaseNegativa_SelectionChanged(object sender, EventArgs e)
        {
            //int nFilaBaseNegativa = e.RowIndex;
        //    int nFilaBaseNegativa = Convert.ToInt32(dtgBaseNegativa.SelectedCells[2].RowIndex);
        //    if (nFilaBaseNegativa<0)
        //    {
        //        return;
        //    }

        //    chcNoCliente.Checked = ((int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idCli"] == 0 ? true : false);
        //    cboTipoPersona.SelectedValue = (int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idTipoPersona"];
        //    cboTipoDocumento.SelectedValue = (int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idTipoDocumento"];
        //    txtNroDoc.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cDocumentoID"].ToString();
        //    cboModuloEdit.SelectedValue = (int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idModulo"];

        //    if ((int)dtBaseNegativa.Rows[nFilaBaseNegativa]["idTipoPersona"] == 1)
        //    {
        //        txtNombre.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cNombre"].ToString().Trim();
        //        txtApPaterno.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cApellidoPaterno"].ToString().Trim();
        //        txtApMaterno.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cApellidoMaterno"].ToString().Trim();
        //        txtNomRazonSocial.Text = "";
        //    }
        //    else
        //    {
        //        txtNombre.Text = "";
        //        txtApPaterno.Text = "";
        //        txtApMaterno.Text = "";
        //        txtNomRazonSocial.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cNomCompleto"].ToString().Trim();
        //    }

        //    cboMotivoBloqueo.SelectedValue = dtBaseNegativa.Rows[nFilaBaseNegativa]["idMotivoBloq"].ToString();
        //    txtDescripcion.Text = dtBaseNegativa.Rows[nFilaBaseNegativa]["cMotivo"].ToString();
        //    if (lNuevo)
        //    {

        //    }
        //    else
        //    {
        //        HabilitarControles(false);
        //        cboTipoPersona.Enabled = false;
        //        cboTipoDocumento.Enabled = false;
        //    }
        }

        private void cboMotivoBloqueo_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.ToolTipTitle = "Motivo";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 0;

            buttonToolTip.SetToolTip(this.cboMotivoBloqueo, cboMotivoBloqueo.GetItemText(cboMotivoBloqueo.SelectedItem));

        }
    }
}