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
    public partial class frmNotaSalida : frmBase
    {
        
        #region Variables

        private const string cTituloMsjes = "Registro de Nota de Salida";
        private clsCNNotaSalida clsNotaSalida = new clsCNNotaSalida();     
        private clsNotaSalida objNotaSalida;
        private int idArea;
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

        #endregion

        #region Constructores

        public frmNotaSalida()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmNotaSalida_Load(object sender, EventArgs e)
        {            
            cboAgencia.cargarSoloAgencias();

            cboAgencia.SelectedIndex = -1;
            IniForm();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBusNotaSalida frmBusNS = new frmBusNotaSalida();
            frmBusNS.lTodos = false;
            frmBusNS.ShowDialog();

            if (frmBusNS.objNotaSalida == null)
            {
                return;
            }

            BuscarNotaSalida(frmBusNS.objNotaSalida.idNotaSalida);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            objNotaSalida = new clsNotaSalida(0);
            dtpFechaNS.Value = dFechaSis;
            ActivarControles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {                   
            ActivarControles(true);
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

            objNotaSalida.idActividadLog = Convert.ToInt32(cboActividadLog.SelectedValue);
            objNotaSalida.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
            objNotaSalida.idAgenciaReg = clsVarGlobal.nIdAgencia;
            objNotaSalida.idArea = idArea;
            objNotaSalida.idEstadoLog = Convert.ToInt16(EstLog.SOLICITADO);
            objNotaSalida.cSustento = Convert.ToString(txtSustento.Text);

            clsDBResp objDBResp = null;
            if (objNotaSalida.idNotaSalida == 0)
            {
                objDBResp = clsNotaSalida.CNGuardarNotaSalida(objNotaSalida);
            }
            else
            {
                objNotaSalida.idUsuReg = clsVarGlobal.User.idUsuario;
                objNotaSalida.dFechaRegistro = clsVarGlobal.dFecSystem;
                objDBResp = clsNotaSalida.CNActualizarNotaSalida(objNotaSalida);
            }

            if (objDBResp.nMsje == 0)
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarNotaSalida(objDBResp.idGenerado);
            }
            else
            {
                MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumNotaSal.Text.ToString().Trim()))
            {
                int idNotaSalida = Convert.ToInt32(txtNumNotaSal.Text.ToString().Trim());

                clsCNNotaSalida objCargaNotaSalida = new clsCNNotaSalida();
                DataTable dtNotaSalida = objCargaNotaSalida.CNCargaNotaSalida(idNotaSalida);

                List<ReportParameter> paramlist = new List<ReportParameter>();
                DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
                string cNomAgen = clsVarGlobal.cNomAge;
                string cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                paramlist.Add(new ReportParameter("cNomAgencia", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutLogo, false));
                paramlist.Add(new ReportParameter("idNotaSalida", idNotaSalida.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("DSNotaSalida", dtNotaSalida));

                string reportpath = "rptRequerimientoNPAlmacen.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se cargo Nota de salida de almacén", "Registro de Nota de Salida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboAlmacen.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el almacen.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmBusquedaCatalogo frmCatalogo = new frmBusquedaCatalogo();
            frmCatalogo.idAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue);
            frmCatalogo.pidTipoPedido = 0;
            frmCatalogo.nTipBusqueda = 1;
            frmCatalogo.ShowDialog();

            List<clsCatalogo> LstCatalogoSeleccionado = frmCatalogo.LstCatalogoSeleccionado;

            if (LstCatalogoSeleccionado.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningun producto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgDetalleNS.Rows.Count > 0)
            {
                if (((clsDetNotaSalida)dtgDetalleNS.Rows[0].DataBoundItem).objCatalogo.idTipoBien != LstCatalogoSeleccionado[0].idTipoBien)
                {
                    MessageBox.Show("No puede agregar tipos difentes de bienes.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int nRepetidos = 0;
            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                if (objNotaSalida.LstDetNotSalida.Any(x => x.objCatalogo.idCatalogo == objCatalogo.idCatalogo))
                {
                    nRepetidos++;
                }
                else
                {
                    clsDetNotaSalida objDetNotSalida = new clsDetNotaSalida(0);
                    objDetNotSalida.objCatalogo = objCatalogo;
                    objDetNotSalida.idUniMedida = objCatalogo.idUnidadAlmacenaje;
                    objDetNotSalida.cUnidMedida = objCatalogo.cUnidAlmacenaje;

                    objNotaSalida.LstDetNotSalida.Add(objDetNotSalida);

                    dtgDetalleNS.DataSource = objNotaSalida.LstDetNotSalida.Where(x => x.lVigente == true).ToList();
                }
            }

            if (nRepetidos > 0)
            {
                MessageBox.Show("Se encontraron item's repetidos, solo los item's no repetidos fueron agregados.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            FormatoGridView();
            dtgDetalleNS.CurrentCell = dtgDetalleNS.Rows[dtgDetalleNS.Rows.Count - 1].Cells["nCantidadSol"];
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNS.SelectedCells.Count == 0)
            {
                MessageBox.Show("Seleccione el item para quitar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsDetNotaSalida objDetNotSalida = (clsDetNotaSalida)dtgDetalleNS.SelectedCells[0].OwningRow.DataBoundItem;
            if (objDetNotSalida.idDetalleNotaSalida == 0)
            {
                objNotaSalida.LstDetNotSalida.Remove(objDetNotSalida);
            }
            else
            {
                objDetNotSalida.lVigente = false;
            }

            dtgDetalleNS.DataSource = objNotaSalida.LstDetNotSalida.Where(x => x.lVigente == true).ToList();
            FormatoGridView();
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

            int idNotaSalida = Convert.ToInt32(txtNumNotaSal.Text.ToString().Trim());
            if (idNotaSalida == 0)
            {
                MessageBox.Show("Ingrese Valor Diferente de Cero(0)", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarNotaSalida(idNotaSalida);

        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen(Convert.ToInt32(cboAgencia.SelectedValue));
                DataTable dtAlmacen = (DataTable)cboAlmacen.DataSource;
                if (dtAlmacen.Rows.Count > 0)
                {
                    cboAlmacen.SelectedIndex = 0;
                }
                else
                {
                    cboAlmacen.SelectedIndex = -1;
                }
                
            }
        }

        private void dtgDetalleNS_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.MaxLength = 10;
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        
        private void dtgDetalleNS_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgDetalleNS.CurrentRow != null)
            {
                if (string.IsNullOrEmpty(dtgDetalleNS.CurrentRow.Cells["nCantidadSol"].EditedFormattedValue.ToString()))
                {
                    dtgDetalleNS.EditingControl.Text = "0";
                    return;
                }
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (txt.SelectionLength != txt.TextLength)
            {
                if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Metodos

        private void IniForm()
        {
            dtpFechaNS.Value = clsVarGlobal.dFecSystem;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            DatosUsuario(clsVarGlobal.User.idCli);
            cboActividadLog.ListarActividad(clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);
            cboActividadLog.SelectedIndex = -1;
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

        private void BuscarNotaSalida(int idNotaSalida)
        {
            clsCNNotaSalida objCargaNotaSalida = new clsCNNotaSalida();

            objNotaSalida = clsNotaSalida.CNBuscarNotaSalidaById(idNotaSalida);
            if (objNotaSalida == null)
            {
                MessageBox.Show("No se encontró información de nota de salida", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCampos();
                IniForm();
                return;
            }
            ActivarControles(false);
            MapeaEntidadCampos(objNotaSalida);
            txtNumNotaSal.Enabled = false;
            btnEditar.Enabled = objNotaSalida.idEstadoLog == Convert.ToInt16(EstLog.SOLICITADO) ? true : false;
            btnCancelar.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txtNumNotaSal.Clear();
            txtEstadoNotaSal.Clear();
            txtSustento.Clear();
            cboActividadLog.SelectedIndex = -1;

            txtEstadoNotaSal.Text = string.Empty;
            cboAgencia.Text = string.Empty;
            cboAlmacen.Text = string.Empty;
            dtpFechaNS.Value = dFechaSis;
            cboActividadLog.SelectedIndex = -1;
            txtNumNotaSal.Text = string.Empty;
            txtNumNotaSal.Focus();
            dtgDetalleNS.DataSource = null;

            DatosUsuario(clsVarGlobal.User.idCli);
        } 

        private void MapeaEntidadCampos(clsNotaSalida objNotaSalida)
        {
            txtNumNotaSal.Text = objNotaSalida.idNotaSalida.ToString();
            txtEstadoNotaSal.Text = objNotaSalida.cEstLog;
            txtSustento.Text = objNotaSalida.cSustento;
            dtpFechaNS.Value = objNotaSalida.dFechaRegistro;
            cboActividadLog.SelectedValue = objNotaSalida.idActividadLog;
            cboAgencia.SelectedValue = objNotaSalida.idAgenAlmacen;
            cboAlmacen.SelectedValue = objNotaSalida.idAlmacen;
            DatosUsuario(objNotaSalida.idCli);

            dtgDetalleNS.DataSource = objNotaSalida.LstDetNotSalida.Where(x=>x.lVigente).ToList();
            FormatoGridView();
        }

        private void FormatoGridView(bool lSoloLectura = false)
        {
            dtgDetalleNS.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNS.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgDetalleNS.Columns["idCatalogo"].Visible = true;
            dtgDetalleNS.Columns["cProducto"].Visible = true;
            dtgDetalleNS.Columns["cUnidMedida"].Visible = true;
            dtgDetalleNS.Columns["nStock"].Visible = false;
            dtgDetalleNS.Columns["nCantidadSol"].Visible = true;

            dtgDetalleNS.Columns["idCatalogo"].HeaderText = "Cod. Prod."; 
            dtgDetalleNS.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleNS.Columns["cUnidMedida"].HeaderText = "Uni. Medida";
            dtgDetalleNS.Columns["nStock"].HeaderText = "Stock";
            dtgDetalleNS.Columns["nCantidadSol"].HeaderText = "Cantidad";

            dtgDetalleNS.Columns["idCatalogo"].DisplayIndex = 0;
            dtgDetalleNS.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleNS.Columns["cUnidMedida"].DisplayIndex = 2;
            dtgDetalleNS.Columns["nStock"].DisplayIndex = 3;
            dtgDetalleNS.Columns["nCantidadSol"].DisplayIndex = 4;

            dtgDetalleNS.Columns["idCatalogo"].FillWeight = 25;
            dtgDetalleNS.Columns["cProducto"].FillWeight = 150;
            dtgDetalleNS.Columns["cUnidMedida"].FillWeight = 25;
            dtgDetalleNS.Columns["nCantidadSol"].FillWeight = 50; 


            dtgDetalleNS.Columns["nCantidadSol"].ReadOnly = lSoloLectura;
        }

        private bool ValidarCampos()
        {
            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAlmacen.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el almacen.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboActividadLog.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la actividad a la que se destinara el pedido.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtgDetalleNS.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese Items a la Nota de pedido", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtSustento.Text))
            {
                MessageBox.Show("Ingrese un sustento", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            List<clsDetNotaSalida> lista = (List<clsDetNotaSalida>)dtgDetalleNS.DataSource;
            bool lBool = true;
            string cMsg = "";
            foreach (clsDetNotaSalida item in lista)
            {
                if (item.nCantidadSol == 0)
                {
                    lBool = false;
                    cMsg += "- "+ item.cProducto + "\n";
                }
            }

            if (!lBool)
            {
                MessageBox.Show("La cantidad de los siguientes items es 0: \n" + cMsg, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;      
        }

        private void ActivarControles(bool lHab)
        {
            txtNumNotaSal.Enabled = !lHab;

            cboActividadLog.Enabled = lHab;
            cboAgencia.Enabled = lHab;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAlmacen.Enabled = lHab;
            txtSustento.Enabled = lHab;
            btnAgregar.Enabled = lHab;
            btnQuitar.Enabled = lHab;

            btnBusqueda.Enabled = !lHab;
            btnNuevo.Enabled = !lHab;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = lHab;
            btnCancelar.Enabled = lHab; 
        }

        #endregion

        

    }
}
