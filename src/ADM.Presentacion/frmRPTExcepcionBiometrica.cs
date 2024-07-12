#region
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
using ADM.CapaNegocio;
using Microsoft.Reporting.WinForms;
#endregion


namespace ADM.Presentacion
{
    public partial class frmRPTExcepcionBiometrica : frmBase

    {
        #region Variables Globales
        private clsCNBiometriaExcepcion objCNArpobacion { get; set; }
        List<clsBiometriaExcep> lstBiometriaExcepcion { get; set; }
        BindingSource bsBiometriaExcepcion { get; set; }

        #endregion 

        #region Constructores
        public frmRPTExcepcionBiometrica()
        {
            InitializeComponent();
            cargarComponentes();
        }
        #endregion

        #region Eventos
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;
            int idEstado = Convert.ToInt32(cboEstadoSolicitud.SelectedValue);

            List<clsBiometriaExcep> lstConsultaExcepciones = objCNArpobacion.CNObtenerRPTSolicitudBiometrica(idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta, idEstado);
            lstBiometriaExcepcion.Clear();
            lstBiometriaExcepcion.AddRange(lstConsultaExcepciones);
            bsBiometriaExcepcion.ResetBindings(false);
            formatearGridExcepcionBiometrico();
            identificarEstadoExcepcion();
            dtgExcepcionBiometrica.Refresh();
            dtgExcepcionBiometrica.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);
            int idEstado = Convert.ToInt32(cboEstadoSolicitud.SelectedValue);
            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtMetasCreditos = objCNArpobacion.CNObtenerRPTSolicitudBiometricaCompleto(idZona, idAgencia, idEstablecimiento, dFechaDesde, dFechaHasta, idEstado);

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaDesde", Convert.ToString(dFechaDesde), false));
            paramlist.Add(new ReportParameter("dFechaHasta", Convert.ToString(dFechaHasta), false));

            dtslist.Add(new ReportDataSource("dsSolExcepBiometrico", dtMetasCreditos));

            string reportpath = "rptSolicitudExcepcionBiometrica.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private void frmRPTExcepcionBiometrica_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboZona.SelectedIndex != -1)
            {
                int idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);
                this.cboAgencia.FiltrarPorZonaTodos(idZonaSeleccionado);
                this.cboEstablecimiento.CargarEstablecimientos(0);

                cboAgencia.SelectedIndex = -1;
                cboEstablecimiento.SelectedIndex = -1;
                cboAgencia.Enabled = true;
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAgencia.SelectedIndex != -1)
            {
                int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);
                this.cboEstablecimiento.CargarEstablecimientos(idAgenciaSeleccionado);
                this.cboEstablecimiento.SelectedIndex = -1;

                cboEstablecimiento.Enabled = true;
            }
            else
            {
                this.cboEstablecimiento.SelectedIndex = -1;
                cboEstablecimiento.Enabled = false;
            }
        }

        private void dtgExcepcionBiometrica_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgExcepcionBiometrica.SelectedRows.Count > 0)
            {
                clsBiometriaExcep objBiometriaExcepcion = (clsBiometriaExcep)dtgExcepcionBiometrica.SelectedRows[0].DataBoundItem;
                frmDetalleSolExcepBiometrico frmDetalleExcepcion = new frmDetalleSolExcepBiometrico(objBiometriaExcepcion);
                frmDetalleExcepcion.ShowDialog();
            }
        }

        private void btnDetalleExcepcion_Click(object sender, EventArgs e)
        {
            if(dtgExcepcionBiometrica.SelectedRows.Count > 0)
            {
                clsBiometriaExcep objBiometriaExcepcion = (clsBiometriaExcep)dtgExcepcionBiometrica.SelectedRows[0].DataBoundItem;
                frmDetalleSolExcepBiometrico frmDetalleExcepcion = new frmDetalleSolExcepBiometrico(objBiometriaExcepcion);
                frmDetalleExcepcion.ShowDialog();
            }
        }
        #endregion

        #region Metodos
        private void cargarComponentes()
        {
            objCNArpobacion = new clsCNBiometriaExcepcion();
            lstBiometriaExcepcion = new List<clsBiometriaExcep>();
            bsBiometriaExcepcion = new BindingSource();

            bsBiometriaExcepcion.DataSource = lstBiometriaExcepcion;
            dtgExcepcionBiometrica.DataSource = bsBiometriaExcepcion;

            bsBiometriaExcepcion.ResetBindings(false);

            this.cboZona.cargarZona(true, false);
            this.cboAgencia.FiltrarPorZona(-1, false, false);
            this.cboEstablecimiento.CargarEstablecimiento(0);

            cboEstadoSolicitud.EstadosFiltroTodos("cListaEstadoRPTExcepBiometrica");

        }

        private void cargarDatos()
        {
            this.cboZona.SelectedIndex              = -1;
            this.cboAgencia.SelectedIndex           = -1;
            this.cboEstablecimiento.SelectedIndex   = -1;
            this.cboEstadoSolicitud.SelectedValue   = 0;

            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;

            this.cboZona.Enabled            = true;
            this.cboAgencia.Enabled         = false;
            this.cboEstablecimiento.Enabled = false;

            formatearGridExcepcionBiometrico();
        }

        private void formatearGridExcepcionBiometrico()
        {
            dtgExcepcionBiometrica.ReadOnly = false;
            dtgExcepcionBiometrica.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

            foreach (DataGridViewColumn column in dtgExcepcionBiometrica.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Visible = false;
                column.HeaderText = column.Name;
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            dtgExcepcionBiometrica.Columns["idBiometriaExcep"].Visible          = true;
            dtgExcepcionBiometrica.Columns["cBiometriaExcep"].Visible           = true;
            dtgExcepcionBiometrica.Columns["cDocumentoID"].Visible              = true;
            dtgExcepcionBiometrica.Columns["cNombreArchivo"].Visible            = true;
            dtgExcepcionBiometrica.Columns["dFechaReg"].Visible                 = true;
            dtgExcepcionBiometrica.Columns["idKardexOperacion"].Visible         = true;
            dtgExcepcionBiometrica.Columns["idCliente"].Visible                 = true;
            
            dtgExcepcionBiometrica.Columns["cNombres"].Visible                  = true;
            dtgExcepcionBiometrica.Columns["cMotivoBiometriaExcep"].Visible     = true;
            dtgExcepcionBiometrica.Columns["cWinUserReg"].Visible               = true;
            dtgExcepcionBiometrica.Columns["cTipoArchivo"].Visible              = true;
            dtgExcepcionBiometrica.Columns["cEstadoSolicitud"].Visible          = true;
            dtgExcepcionBiometrica.Columns["cEstadoExcepcion"].Visible          = true;
            dtgExcepcionBiometrica.Columns["cAgencia"].Visible                  = true;
            dtgExcepcionBiometrica.Columns["cEstablecimiento"].Visible          = true;
            
            dtgExcepcionBiometrica.Columns["idSolAproba"].Visible               = true;
            dtgExcepcionBiometrica.Columns["cTipoOperacion"].Visible            = true;
            dtgExcepcionBiometrica.Columns["cProducto"].Visible                 = true;
            dtgExcepcionBiometrica.Columns["nMonto"].Visible                    = true;
            dtgExcepcionBiometrica.Columns["cMoneda"].Visible                   = true;


            dtgExcepcionBiometrica.Columns["idBiometriaExcep"].HeaderText          = "Cod. Excep. Biométrica";
            dtgExcepcionBiometrica.Columns["cBiometriaExcep"].HeaderText           = "Detalle Excepción";
            dtgExcepcionBiometrica.Columns["cDocumentoID"].HeaderText              = "Documento ID";
            dtgExcepcionBiometrica.Columns["cNombreArchivo"].HeaderText            = "Nombre Archivo";
            dtgExcepcionBiometrica.Columns["dFechaReg"].HeaderText                 = "Fecha Registro";
            dtgExcepcionBiometrica.Columns["idKardexOperacion"].HeaderText         = "Nro. Operación";
            dtgExcepcionBiometrica.Columns["idCliente"].HeaderText                 = "Cod. Cliente";

            dtgExcepcionBiometrica.Columns["cNombres"].HeaderText                  = "Nombres";
            dtgExcepcionBiometrica.Columns["cMotivoBiometriaExcep"].HeaderText     = "Motivo Excepción";
            dtgExcepcionBiometrica.Columns["cWinUserReg"].HeaderText               = "Cod. Usuario";
            dtgExcepcionBiometrica.Columns["cTipoArchivo"].HeaderText              = "Tipo Archivo";
            dtgExcepcionBiometrica.Columns["cEstadoSolicitud"].HeaderText          = "Estado Solicitud";
            dtgExcepcionBiometrica.Columns["cEstadoExcepcion"].HeaderText          = "Estado Excepción";
            dtgExcepcionBiometrica.Columns["cAgencia"].HeaderText                  = "Agencia";
            dtgExcepcionBiometrica.Columns["cEstablecimiento"].HeaderText          = "Establecimiento";

            dtgExcepcionBiometrica.Columns["idSolAproba"].HeaderText               = "Cod. Solicitud";
            dtgExcepcionBiometrica.Columns["cTipoOperacion"].HeaderText            = "Tipo de Operación";
            dtgExcepcionBiometrica.Columns["cProducto"].HeaderText                 = "Producto";
            dtgExcepcionBiometrica.Columns["nMonto"].HeaderText                    = "Monto";
            dtgExcepcionBiometrica.Columns["cMoneda"].HeaderText                   = "Moneda";

            dtgExcepcionBiometrica.Columns["idBiometriaExcep"].DefaultCellStyle.Alignment   = DataGridViewContentAlignment.MiddleCenter;
            dtgExcepcionBiometrica.Columns["cDocumentoID"].DefaultCellStyle.Alignment       = DataGridViewContentAlignment.MiddleCenter;
            dtgExcepcionBiometrica.Columns["idCliente"].DefaultCellStyle.Alignment          = DataGridViewContentAlignment.MiddleCenter;
            dtgExcepcionBiometrica.Columns["idCliente"].DefaultCellStyle.Alignment          = DataGridViewContentAlignment.MiddleCenter;

            dtgExcepcionBiometrica.Columns["nMonto"].DefaultCellStyle.Format                = "N2";

            dtgExcepcionBiometrica.Columns["idBiometriaExcep"].DisplayIndex         = 0;
            dtgExcepcionBiometrica.Columns["cAgencia"].DisplayIndex                 = 1;
            dtgExcepcionBiometrica.Columns["cEstablecimiento"].DisplayIndex         = 2;
            dtgExcepcionBiometrica.Columns["cDocumentoID"].DisplayIndex             = 3;
            dtgExcepcionBiometrica.Columns["idCliente"].DisplayIndex                = 4;
            dtgExcepcionBiometrica.Columns["cNombres"].DisplayIndex                 = 5;
            dtgExcepcionBiometrica.Columns["dFechaReg"].DisplayIndex                = 6;
            dtgExcepcionBiometrica.Columns["cMotivoBiometriaExcep"].DisplayIndex    = 7;
            dtgExcepcionBiometrica.Columns["cBiometriaExcep"].DisplayIndex          = 8;
            dtgExcepcionBiometrica.Columns["cEstadoSolicitud"].DisplayIndex         = 9;
            dtgExcepcionBiometrica.Columns["idSolAproba"].DisplayIndex              = 10;
            dtgExcepcionBiometrica.Columns["cEstadoExcepcion"].DisplayIndex         = 11;
            dtgExcepcionBiometrica.Columns["idKardexOperacion"].DisplayIndex        = 12;
            dtgExcepcionBiometrica.Columns["cMoneda"].DisplayIndex                  = 13;
            dtgExcepcionBiometrica.Columns["nMonto"].DisplayIndex                   = 14;
            dtgExcepcionBiometrica.Columns["cTipoOperacion"].DisplayIndex           = 15;
            dtgExcepcionBiometrica.Columns["cProducto"].DisplayIndex                = 16;
            dtgExcepcionBiometrica.Columns["cWinUserReg"].DisplayIndex              = 17;
            dtgExcepcionBiometrica.Columns["cNombreArchivo"].DisplayIndex           = 18;
            dtgExcepcionBiometrica.Columns["cTipoArchivo"].DisplayIndex             = 19;

            dtgExcepcionBiometrica.Columns["idEstadoSolicitud"].DisplayIndex        = 20;
            dtgExcepcionBiometrica.Columns["idMotivoBiometriaExcep"].DisplayIndex   = 21;
            dtgExcepcionBiometrica.Columns["cExtencion"].DisplayIndex               = 22;
            dtgExcepcionBiometrica.Columns["bArchivo"].DisplayIndex                 = 23;
            dtgExcepcionBiometrica.Columns["idUsuReg"].DisplayIndex                 = 24;
            dtgExcepcionBiometrica.Columns["idUsuMod"].DisplayIndex                 = 25;
            dtgExcepcionBiometrica.Columns["dFechaMod"].DisplayIndex                = 26;
            dtgExcepcionBiometrica.Columns["lVigente"].DisplayIndex                 = 27;
            dtgExcepcionBiometrica.Columns["idTipoArchivo"].DisplayIndex            = 28;
            dtgExcepcionBiometrica.Columns["idEstadoExcepcion"].DisplayIndex        = 29;
            dtgExcepcionBiometrica.Columns["idAgencia"].DisplayIndex                = 30;
            dtgExcepcionBiometrica.Columns["idEstablecimiento"].DisplayIndex        = 31;
            dtgExcepcionBiometrica.Columns["idTipoDocumento"].DisplayIndex          = 32;
            dtgExcepcionBiometrica.Columns["idCli"].DisplayIndex                    = 33;
            dtgExcepcionBiometrica.Columns["idTipoOperacion"].DisplayIndex          = 34;
            dtgExcepcionBiometrica.Columns["idProducto"].DisplayIndex               = 35;

            dtgExcepcionBiometrica.Columns["idBiometriaExcep"].Width            = 75;
            dtgExcepcionBiometrica.Columns["cBiometriaExcep"].Width             = 200;
            dtgExcepcionBiometrica.Columns["cDocumentoID"].Width                = 100;
            dtgExcepcionBiometrica.Columns["cNombreArchivo"].Width              = 100;
            dtgExcepcionBiometrica.Columns["dFechaReg"].Width                   = 75;
            dtgExcepcionBiometrica.Columns["idKardexOperacion"].Width           = 100;
            dtgExcepcionBiometrica.Columns["idCliente"].Width                   = 75;

            dtgExcepcionBiometrica.Columns["cNombres"].Width                    = 250;
            dtgExcepcionBiometrica.Columns["cMotivoBiometriaExcep"].Width       = 175;
            dtgExcepcionBiometrica.Columns["cWinUserReg"].Width                 = 100;
            dtgExcepcionBiometrica.Columns["cTipoArchivo"].Width                = 100;
            dtgExcepcionBiometrica.Columns["cEstadoSolicitud"].Width            = 100;
            dtgExcepcionBiometrica.Columns["cEstadoExcepcion"].Width            = 100;
            dtgExcepcionBiometrica.Columns["cAgencia"].Width                    = 125;
            dtgExcepcionBiometrica.Columns["cEstablecimiento"].Width            = 125;

            dtgExcepcionBiometrica.Columns["idSolAproba"].Width                 = 100;
            dtgExcepcionBiometrica.Columns["cTipoOperacion"].Width              = 200;
            dtgExcepcionBiometrica.Columns["cProducto"].Width                   = 175;
            dtgExcepcionBiometrica.Columns["nMonto"].Width                      = 100;
            dtgExcepcionBiometrica.Columns["cMoneda"].Width                     = 100;
        }

        private void identificarEstadoExcepcion()
        {
            foreach(DataGridViewRow drgvRegistro in dtgExcepcionBiometrica.Rows)
            {
                clsBiometriaExcep objBioExcepcion = (clsBiometriaExcep)drgvRegistro.DataBoundItem;
                if (objBioExcepcion.idEstadoExcepcion == 1)
                    drgvRegistro.DefaultCellStyle.BackColor = Color.PowderBlue;
                else if (objBioExcepcion.idEstadoExcepcion == 2)
                    drgvRegistro.DefaultCellStyle.BackColor = Color.PaleGreen;
                else if (objBioExcepcion.idEstadoExcepcion == 4)
                    drgvRegistro.DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        private void habilitarEventHandler(bool lValor)
        {
            if(lValor)
            {
                cboZona.SelectedIndexChanged += new System.EventHandler(cboZona_SelectedIndexChanged);
                cboAgencia.SelectedIndexChanged += new System.EventHandler(cboAgencia_SelectedIndexChanged);
            }
            else
            {
                cboZona.SelectedIndexChanged -= new System.EventHandler(cboZona_SelectedIndexChanged);
                cboAgencia.SelectedIndexChanged -= new System.EventHandler(cboAgencia_SelectedIndexChanged);
            }
        }

        private bool validar()
        {
            if(cboZona.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Zona.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Agencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboEstablecimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Establecimiento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if(dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La Fecha Final no puede ser anterior a la Fecha Inicial.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboEstadoSolicitud.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el estado de las Solicitudes de Excepción.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        #endregion

    }
}
