using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using LOG.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{

    public partial class frmProcesoAdquisicion : frmBase
    {
        #region Variables
        private clsCNProcesoAdquisicion clsCNProcAdq = new clsCNProcesoAdquisicion();
        private clsSolicitudProcesoAdquisicion objProcAdq;
        private int idArea;
            private const string cTituloMsjes = "Solicitud de Adquisiciones";
            //private clsNotaSalida objProcAdq;
            
        #endregion
        public frmProcesoAdquisicion()
        {
            InitializeComponent();
            IniForm();
            cboMoneda1.CargaDatos();
            cboMoneda1.SelectedIndex = -1;
        }



        private void IniForm()
        {
            dtpFechaNS.Value = clsVarGlobal.dFecSystem;
            
            DatosUsuario(clsVarGlobal.User.idCli);
            
            ActivarControles(false);
            txtNumNotaSal.Text = string.Empty;
            txtNumNotaSal.Focus();
        }

        private void DatosUsuario(int idusuario)
        {
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(idusuario, "F");
            if (DatosCli.Rows.Count > 0)
            {
                txtCBNombre.Text = DatosCli.Rows[0]["cNombre"].ToString();
                txtCBUsuarioSol.Text = DatosCli.Rows[0]["cWinUser"].ToString();
                txtCBAreaSol.Text = DatosCli.Rows[0]["cArea"].ToString();
                txtCBEstUsuSol.Text = DatosCli.Rows[0]["cEstPersonal"].ToString();
                idArea = Convert.ToInt32(DatosCli.Rows[0]["idArea"].ToString());
            }
            else
            {
                txtCBNombre.Text = "";
                txtCBUsuarioSol.Text = "";
                txtCBAreaSol.Text = "";
                txtCBEstUsuSol.Text = "";
            }
        }

        private void ActivarControles(bool lHab, bool lEdit = false)
        {
            txtNumNotaSal.Enabled = !lHab;

            txtSustento.Enabled = lHab;
            btnAgregar.Enabled = lHab;
            btnQuitar.Enabled = lHab;

            btnBusqueda.Enabled = !lHab;
            btnNuevo.Enabled = !lHab;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = lHab;
            btnCancelar.Enabled = lHab;
            cboMoneda1.Enabled = lHab;


            if (lEdit)
            {
                dtgDetalleNS.Columns["cDetalleProducto"].ReadOnly = false;
                dtgDetalleNS.Columns["nCantidad"].ReadOnly = false;
                dtgDetalleNS.Columns["nPrecioRef"].ReadOnly = false;
                dtgDetalleNS.Columns["nDiasRef"].ReadOnly = false;
                dtgDetalleNS.Columns["nLineaCreditoRef"].ReadOnly = false;
            }
            else
            {
                cboMoneda1.SelectedIndex = -1;
            }
        }

        private void LimpiarCampos()
        {
            txtNumNotaSal.Clear();
            txtEstadoNotaSal.Clear();
            txtSustento.Clear();

            txtEstadoNotaSal.Text = string.Empty;

            //dtpFechaNS.Value = dFechaSis;
            
            txtNumNotaSal.Text = string.Empty;
            txtNumNotaSal.Focus();
            dtgDetalleNS.DataSource = null;

            DatosUsuario(clsVarGlobal.User.idCli);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            objProcAdq = new clsSolicitudProcesoAdquisicion(0);
            //dtpFechaNS.Value = dFechaSis;
            ActivarControles(true);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmBusquedaCatalogo frmCatalogo = new frmBusquedaCatalogo();
            frmCatalogo.pidTipoPedido = 0;
            frmCatalogo.nTipBusqueda = 1;
            frmCatalogo.ShowDialog();

            List<clsCatalogo> LstCatalogoSeleccionado = frmCatalogo.LstCatalogoSeleccionado;

            if (LstCatalogoSeleccionado.Count == 0)
            {
                MessageBox.Show("No se selecciono ningun producto del catalogo", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (dtgDetalleNS.Rows.Count > 0)
            {
                if (((clsDetProcesoAdquisicion)dtgDetalleNS.Rows[0].DataBoundItem).objCatalogo.idTipoBien != LstCatalogoSeleccionado[0].idTipoBien)
                {
                    MessageBox.Show("No puede agregar tipos diferentes de bienes.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int nRepetidos = 0;
            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                if (objProcAdq.LstDetProcAdq.Where(x => x.idCatalogo == objCatalogo.idCatalogo).Count() > 0)
                {
                    nRepetidos++;
                }
                else
                {
                    clsDetProcesoAdquisicion objDetProcAdq = new clsDetProcesoAdquisicion(0);
                    objDetProcAdq.objCatalogo = objCatalogo;
                    objDetProcAdq.idUniMedida = objCatalogo.idUnidadAlmacenaje;
                    objDetProcAdq.cUnidMedida = objCatalogo.cUnidAlmacenaje;


                    objProcAdq.LstDetProcAdq.Add(objDetProcAdq);

                    dtgDetalleNS.DataSource = objProcAdq.LstDetProcAdq.Where(x => x.lVigente == true).ToList();
                }
            }

            if (nRepetidos > 0)
            {
                MessageBox.Show("Se encontraron item's repetidos, solo los item's no repetidos fueron agregados.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            FormatoGridView();
            dtgDetalleNS.CurrentCell = dtgDetalleNS.Rows[dtgDetalleNS.Rows.Count - 1].Cells["nCantidad"];
        }

        private void FormatoGridView(bool lSoloLectura = false)
        {
           dtgDetalleNS.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNS.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }
            dtgDetalleNS.Columns["cUnidMedida"].Visible = true;
            dtgDetalleNS.Columns["cProducto"].Visible = true;
            dtgDetalleNS.Columns["cDetalleProducto"].Visible = true;
            dtgDetalleNS.Columns["nCantidad"].Visible = true;
            dtgDetalleNS.Columns["nPrecioRef"].Visible = true;
            dtgDetalleNS.Columns["nDiasRef"].Visible = true;
            dtgDetalleNS.Columns["nLineaCreditoRef"].Visible = true;

            dtgDetalleNS.Columns["cUnidMedida"].HeaderText = "U.M.";
            dtgDetalleNS.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleNS.Columns["cDetalleProducto"].HeaderText = "Detalle del Producto";
            dtgDetalleNS.Columns["nCantidad"].HeaderText = "Cant";
            dtgDetalleNS.Columns["nPrecioRef"].HeaderText = "Prec Ref";
            dtgDetalleNS.Columns["nDiasRef"].HeaderText = "Dias Ref";
            dtgDetalleNS.Columns["nLineaCreditoRef"].HeaderText = "LnCred Ref";

            dtgDetalleNS.Columns["cUnidMedida"].DisplayIndex = 0;
            dtgDetalleNS.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleNS.Columns["cDetalleProducto"].DisplayIndex = 2;
            dtgDetalleNS.Columns["nCantidad"].DisplayIndex = 3;
            dtgDetalleNS.Columns["nPrecioRef"].DisplayIndex = 4;
            dtgDetalleNS.Columns["nDiasRef"].DisplayIndex = 5;
            dtgDetalleNS.Columns["nLineaCreditoref"].DisplayIndex = 6;

            dtgDetalleNS.Columns["cUnidMedida"].FillWeight = 5;
            dtgDetalleNS.Columns["cProducto"].FillWeight = 35;
            dtgDetalleNS.Columns["cDetalleProducto"].FillWeight = 36;
            dtgDetalleNS.Columns["nCantidad"].FillWeight = 5;
            dtgDetalleNS.Columns["nPrecioRef"].FillWeight = 7;
            dtgDetalleNS.Columns["nDiasRef"].FillWeight = 7;
            dtgDetalleNS.Columns["nLineaCreditoRef"].FillWeight = 6;

            dtgDetalleNS.Columns["cDetalleProducto"].ReadOnly = false;
            dtgDetalleNS.Columns["nCantidad"].ReadOnly = false;
            dtgDetalleNS.Columns["nPrecioRef"].ReadOnly = false;
            dtgDetalleNS.Columns["nDiasRef"].ReadOnly = false;
            dtgDetalleNS.Columns["nLineaCreditoRef"].ReadOnly = false;

            dtgDetalleNS.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            for (int i = 0; i < dtgDetalleNS.Rows.Count; i++)
            {
                dtgDetalleNS.Rows[i].Height = 42;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNS.SelectedCells.Count == 0)
            {
                MessageBox.Show("Seleccione el item para quitar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsDetProcesoAdquisicion objDetProcAdq = (clsDetProcesoAdquisicion)dtgDetalleNS.SelectedCells[0].OwningRow.DataBoundItem;
            if (objDetProcAdq.idDetalleProcAdq == 0)
            {
                objProcAdq.LstDetProcAdq.Remove(objDetProcAdq);
            }
            else
            {
                objDetProcAdq.lVigente = false;
            }

            dtgDetalleNS.DataSource = objProcAdq.LstDetProcAdq.Where(x => x.lVigente == true).ToList();
            FormatoGridView();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IniForm();
            LimpiarCampos();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            objProcAdq.idAgenciaReg = clsVarGlobal.nIdAgencia;
            objProcAdq.idArea = idArea;
            objProcAdq.idEstadoLog = Convert.ToInt16(EstLog.SOLICITADO);
            objProcAdq.cSustento = Convert.ToString(txtSustento.Text);
            objProcAdq.idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);

            clsDBResp objDBResp = null;
            //if (objProcAdq.idProcAdq == 0)
            //{
            objDBResp = clsCNProcAdq.CNGuardarProcesoAdquisicion(objProcAdq );
            //}
            /*else
            {
                objProcAdq.idUsuReg = clsVarGlobal.User.idUsuario;
                objProcAdq.dFechaRegistro = clsVarGlobal.dFecSystem;
                objDBResp = clsNotaSalida.CNActualizarNotaSalida(objProcAdq);
            }*/
            
            if (objDBResp.nMsje == 0)
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                BuscarProcesoAdquisicion(objDBResp.idGenerado);
            }
            else
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuscarProcesoAdquisicion(int idProcAdq)
        {
            objProcAdq = null;

            objProcAdq = clsCNProcAdq.CNBuscarProcesoAdquisicion(idProcAdq, 0);
            if (objProcAdq == null)
            {
                MessageBox.Show("No se encontró información de la Solicitud", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCampos();
                IniForm();
                return;
            }
            ActivarControles(false);
            
            MapeaEntidadCampos(objProcAdq);
            txtNumNotaSal.Enabled = false;
            btnEditar.Enabled = objProcAdq.idEstadoLog == Convert.ToInt16(EstLog.SOLICITADO) ? true : false;
            btnCancelar.Enabled = true;
            cboMoneda1.Enabled = false;
        }

        private bool ValidarCampos()
        {
            if (cboMoneda1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Tipo de Moneda", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtgDetalleNS.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese Items a la Solicitud de Proceso de Adquisición", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtSustento.Text))
            {
                MessageBox.Show("Ingrese un sustento", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            List<clsDetProcesoAdquisicion> lista = (List<clsDetProcesoAdquisicion>)dtgDetalleNS.DataSource;
            bool lBool = true;
            string cMsg = "";
            foreach (clsDetProcesoAdquisicion item in lista)
            {
                if (item.nCantidad == 0)
                {
                    lBool = false;
                    cMsg += "- " + item.cProducto + "\n";
                }
            }

            if (!lBool)
            {
                MessageBox.Show("La cantidad de los siguientes items es 0: \n" + cMsg, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            cMsg = "";
            foreach (clsDetProcesoAdquisicion item in lista)
            {
                if (item.nPrecioRef == 0)
                {
                    lBool = false;
                    cMsg += "- " + item.cProducto + "\n";
                }
            }

            if (!lBool)
            {
                MessageBox.Show("El Precio Referencial de los siguientes items es 0: \n" + cMsg, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            cMsg = "";
            foreach (clsDetProcesoAdquisicion item in lista)
            {
                if (item.nDiasRef == 0)
                {
                    lBool = false;
                    cMsg += "- " + item.cProducto + "\n";
                }
            }

            if (!lBool)
            {
                MessageBox.Show("Los Días de Referencia de los siguientes items es 0: \n" + cMsg, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            cMsg = "";
            foreach (clsDetProcesoAdquisicion item in lista)
            {
                if (item.nLineaCreditoRef == 0)
                {
                    lBool = false;
                    cMsg += "- " + item.cProducto + "\n";
                }
            }

            if (!lBool)
            {
                MessageBox.Show("La Linea de Crédito de los siguientes items es 0: \n" + cMsg, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void txtNumNotaSal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            if (string.IsNullOrEmpty(txtNumNotaSal.Text.ToString()))
            {
                MessageBox.Show("Valor de Búsqueda No Válido", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idProcAdq = Convert.ToInt32(txtNumNotaSal.Text.ToString().Trim());
            if (idProcAdq == 0)
            {
                MessageBox.Show("Ingrese Valor Diferente de Cero(0)", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarProcesoAdquisicion(idProcAdq);
        }

        private void MapeaEntidadCampos(clsSolicitudProcesoAdquisicion objProcAdq)
        {
            txtNumNotaSal.Text = objProcAdq.idProcAdq.ToString();
            txtEstadoNotaSal.Text = objProcAdq.cEstLog;
            txtSustento.Text = objProcAdq.cSustento;
            cboMoneda1.SelectedValue = objProcAdq.idMoneda;
            dtpFechaNS.Value = objProcAdq.dFechaRegistro;

            txtCBNombre.Text = objProcAdq.cUsuReg.ToString();
            txtCBAreaSol.Text = objProcAdq.cArea.ToString();
            txtCBUsuarioSol.Text = objProcAdq.cUsuReg.ToString();
            txtCBEstUsuSol.Text = objProcAdq.cEstadoUsu.ToString();


            //dtgDetalleNS.CellValueChanged -= new DataGridViewCellEventHandler(dtgDetalleNS_CellValueChanged);
            dtgDetalleNS.DataSource = null;
            dtgDetalleNS.DataSource = objProcAdq.LstDetProcAdq.Where(x => x.lVigente).ToList();
            FormatoGridView();

            //dtgDetalleNS.CellValueChanged += new DataGridViewCellEventHandler(dtgDetalleNS_CellValueChanged);

            //dtgDetalleNS.ReadOnly = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActivarControles(true, true);
        }

        private void frmProcesoAdquisicion_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimpiarCampos();
        }

        private void dtgDetalleNS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!dtgDetalleNS.IsCurrentCellDirty)
            {
                dtgDetalleNS.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
