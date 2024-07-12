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
using EntityLayer;
using CRE.Presentacion;
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmAprobacionNiveles : frmBase
    {
        #region Variables Globales

        clsGestionaNivelAprobacion oNivelAproba = new clsGestionaNivelAprobacion();
        clsSolicitudAprobacion oSolicitudSel;
        string cTituloMsg;
        #endregion

        public frmAprobacionNiveles()
        {
            InitializeComponent();
        }

        private void frmAprobacionNiveles_Load(object sender, EventArgs e)
        {
            this.cboTipoOperacion.ListadoTipoOpe();
            this.cboProducto.CargarProductoModNivel(1, 4);
            this.cboModulo.ListarSoloModulos();
            this.cargarListaAprobaciones();
            
            this.cTituloMsg = "Aprobacion por niveles";
        }

        #region Public

        #endregion

        #region Privada

        private void cargarListaAprobaciones()
        {
            List<clsSolicitudAprobacion> listaSolAproba = oNivelAproba.obtenerSolicitudesParaAprobar(clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia);
            dtgSolParaAprobar.DataSource = listaSolAproba;
            this.formatoGrid();
            this.habilitarFormulario(false);
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgSolParaAprobar.Columns)
            {
                item.Visible = false;
            }

            dtgSolParaAprobar.Columns["idDocumento"].Visible = true;
            dtgSolParaAprobar.Columns["cModulo"].Visible = true;
            dtgSolParaAprobar.Columns["cTipoOperacion"].Visible = true;
            dtgSolParaAprobar.Columns["cWinUser"].Visible = true;
            dtgSolParaAprobar.Columns["cNombre"].Visible = true;

            dtgSolParaAprobar.Columns["idDocumento"].HeaderText = "Nro. Documento";
            dtgSolParaAprobar.Columns["cModulo"].HeaderText = "Modulo";
            dtgSolParaAprobar.Columns["cTipoOperacion"].HeaderText = "Tip. Oper.";
            dtgSolParaAprobar.Columns["cWinUser"].HeaderText = "Usuario Sol.";
            dtgSolParaAprobar.Columns["cNombre"].HeaderText = "Cliente";

        }

        private void cargarResumen(clsSolicitudAprobacion item)
        {
            limpiarFormularioResumen();
            oSolicitudSel = item;
            cboModulo.SelectedValue = item.idModulo;
            cboTipoOperacion.SelectedValue = item.idTipoOperacion;
            txtNroDocumento.Text = item.idDocumento.ToString();
            txtUsuSol.Text = item.cWinUser;
            txtNombreCli.Text = item.cNombre;
            dtpFechaSol.Value = item.dFechaReg;
            cboAgencia.SelectedValue = item.idAgencia;
            cboProducto.SelectedValue = item.idProducto;
            txtSustento.Text = item.cSustento;
        }

        private void limpiarFormularioResumen()
        {
            cboModulo.SelectedIndex = -1;
            cboTipoOperacion.SelectedIndex = -1;
            txtNroDocumento.Clear();
            txtUsuSol.Clear();
            txtNombreCli.Clear();
            dtpFechaSol.Value = clsVarGlobal.dFecSystem;
            cboAgencia.SelectedIndex = -1;
            cboProducto.SelectedIndex = -1;
            txtSustento.Clear();
            oSolicitudSel = null;
            txtComentario.Text = "";
        }

        private void habilitarFormulario(bool lBol)
        {
            cboModulo.Enabled = lBol;
            cboTipoOperacion.Enabled = lBol;
            txtNroDocumento.Enabled = lBol;
            txtUsuSol.Enabled = lBol;
            txtNombreCli.Enabled = lBol;
            dtpFechaSol.Enabled = lBol;
            cboAgencia.Enabled = lBol;
            cboProducto.Enabled = lBol;
            txtSustento.Enabled = lBol;
        }

        private bool validar(bool lDetalle = false)
        {
            if (oSolicitudSel == null)
            {
                MessageBox.Show("No hay ninguna solicitud seleccionada", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtComentario.Text) && !lDetalle)
            {
                MessageBox.Show("Ingrese el comentario de la aprobación", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void registrarDesicion(int idEstadoAproba)
        {
            Control control = btnAprobar1;
            if (EstadoAprobacion.Aprobado != idEstadoAproba)
                control = btnDenegar1;
            int idCli = oSolicitudSel.idCli;
            int idCuenta = oSolicitudSel.idDocumento;

            this.registrarRastreo(idCli, idCuenta, "Inicio - Aprobación/Denegación de Condonación", control);
            
            DataTable dtRes = oNivelAproba.registrarDesicion(oSolicitudSel.idNivelAprobaSol, oSolicitudSel.idSolicitudAproba, clsVarGlobal.dFecSystem, idEstadoAproba, clsVarGlobal.User.idUsuario, txtComentario.Text);
            if (dtRes.Rows.Count != 0)
            {
                this.registrarRastreo(idCli, idCuenta, "Fin - Aprobación/Denegación de Condonación", control);
                if (Convert.ToInt32(dtRes.Rows[0]["nResultado"]) == 1 )
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (oSolicitudSel.idTipoOperacion == 7)
                        imprimirPropuestaNegociacion(oSolicitudSel.idSolicitudAproba);
                    limpiarFormularioResumen();
                    this.cargarListaAprobaciones();
                }                
            }
            else
            {
                MessageBox.Show("Hubo un error en la conexion con la base de datos, consulte con sus", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void imprimirPropuestaNegociacion(int idSolAproba)
        {
            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            DataTable datos = oNivelAproba.dtsPropuestaNegociacion(idSolAproba);
            dtsList.Add(new ReportDataSource("dtsRpt", datos));


            paramList.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cWinUser, false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            string reportPath = "rptPropuestaNegociacion.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        #endregion

        #region Eventos

        private void dtgSolParaAprobar_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgSolParaAprobar.RowCount == 0)
                return;

            clsSolicitudAprobacion item =(clsSolicitudAprobacion) dtgSolParaAprobar.CurrentRow.DataBoundItem;
            this.cargarResumen(item);
        }

        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            if (!this.validar(true))
                return;
            if (this.oSolicitudSel.idTipoOperacion == 7)
            {
                frmVoBoJefeOficinaRecuperaciones frmVoBo = new frmVoBoJefeOficinaRecuperaciones(this.oSolicitudSel.idDocumento);
                frmVoBo.ShowDialog();
            }
            else
            {
                frmCobAfectaciones frmCob = new frmCobAfectaciones(true, this.oSolicitudSel.idDocumento);
                frmCob.ShowDialog();
            }
        }

        private void btnBuenaPro1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            registrarDesicion(EstadoAprobacion.Aprobado);
        }

        private void btnMiniActualizar1_Click(object sender, EventArgs e)
        {
            this.cargarListaAprobaciones();
        }

        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            registrarDesicion(EstadoAprobacion.Denegado);
        }

        #endregion
    }
}
