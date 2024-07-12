using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmOpeInusuales : frmBase
    {
        #region Variables Globales
        String cTitulo = "Operaciones inusuales";
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        DataTable dtListaCli = new DataTable();
        #endregion

        public frmOpeInusuales()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmOpeInusuales_Load(object sender, EventArgs e)
        {                        
            cargarCboOperaciones();
            cargarCboPerfilCli();
            habilitarControles(false);
            this.conBusUbig1.cargar();
            this.conBusUbig1.cboPais.SelectedValue = 173;
        }
        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (!validarProceso())
            {
                return;
            }
            llenarGrilla();
            habilitarControles(false);
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            this.dtListaCli.Clear();
            this.btnProcesar1.Focus();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            limpiarControles();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        #endregion
        #region Metodos
        private void llenarGrilla()
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime dFechaDesde = Convert.ToDateTime("01/" + this.conFechaAñoMesDesde.cPeriodo);
            DateTime dFechaHasta = Convert.ToDateTime(DateTime.DaysInMonth(this.conFechaAñoMesHasta.anio, this.conFechaAñoMesHasta.idMes) + "/" + this.conFechaAñoMesHasta.cPeriodo);
            int idPerfil = Convert.ToInt32(this.cboPerfiles.SelectedValue);
            dtListaCli = cnmapeoriesgoyopeinusual.procesaClientesOpeInusual(Convert.ToInt32(this.cboOperaciones.SelectedValue), this.conBusUbig1.nIdNodo, dFechaDesde, dFechaHasta, idPerfil, clsVarGlobal.dFecSystem);
            Cursor.Current = Cursors.Default;

            if (dtListaCli.Rows.Count == 0)
            {
                MessageBox.Show("No existen resultados para los filtros", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            else {
                this.dtgLista.DataSource = dtListaCli;
                formatoGrilla();
                pintarAlertaRiesgos();
            }            
        }
        private void formatoGrilla()
        {
            foreach (DataGridViewColumn item in this.dtgLista.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            this.dtgLista.Columns["Z"].Visible = true;
            this.dtgLista.Columns["P"].Visible = true;  
            this.dtgLista.Columns["cPerfilCliOpeInusual"].Visible = true;  
            this.dtgLista.Columns["idCli"].Visible = true;
            this.dtgLista.Columns["TipoDoc"].Visible = true;
            this.dtgLista.Columns["cNroDoc"].Visible = true;
            this.dtgLista.Columns["cNombresCli"].Visible = true;
            this.dtgLista.Columns["nEdad"].Visible = true;
            this.dtgLista.Columns["cDireccion"].Visible = true;
            this.dtgLista.Columns["cNumeroTelefono"].Visible = true;
            this.dtgLista.Columns["cActividad"].Visible = true;
            this.dtgLista.Columns["Pais"].Visible = true;
            this.dtgLista.Columns["Departamento"].Visible = true;
            this.dtgLista.Columns["Provincia"].Visible = true;
            this.dtgLista.Columns["Distrito"].Visible = true;
            this.dtgLista.Columns["nPuntaje"].Visible = true;
            this.dtgLista.Columns["cCalificRiesgo"].Visible = true;
            this.dtgLista.Columns["nNroCuenta"].Visible = true;
            this.dtgLista.Columns["cAgenciaRegistro"].Visible = true;
            this.dtgLista.Columns["Asesor"].Visible = true;
            this.dtgLista.Columns["nMontoApert"].Visible = true;
            this.dtgLista.Columns["MonedaApertura"].Visible = true;
            this.dtgLista.Columns["Plazo"].Visible = true;
            this.dtgLista.Columns["Tasa"].Visible = true;
            this.dtgLista.Columns["FechaApertura"].Visible = true;
            this.dtgLista.Columns["FechaVencto"].Visible = true;
            this.dtgLista.Columns["cProducto"].Visible = true;
            this.dtgLista.Columns["PtjProd"].Visible = true;
            this.dtgLista.Columns["RiesgoProd"].Visible = true;
            this.dtgLista.Columns["cTipoOperacion"].Visible = true;
            this.dtgLista.Columns["cMotivoOperacion"].Visible = true;
            this.dtgLista.Columns["cTipIngreEgreso"].Visible = true;
            this.dtgLista.Columns["UsuarioOpe"].Visible = true;
            this.dtgLista.Columns["cAgenciaOpe"].Visible = true;
            this.dtgLista.Columns["dFechaOpe"].Visible = true;
            this.dtgLista.Columns["idKardex"].Visible = true;
            this.dtgLista.Columns["cMoneda"].Visible = true;
            this.dtgLista.Columns["nMontoOperacion"].Visible = true;
            this.dtgLista.Columns["nMontoDolares"].Visible = true;
            this.dtgLista.Columns["nUmbralAgencia"].Visible = true;
            this.dtgLista.Columns["nTotalGenerado"].Visible = true;
            this.dtgLista.Columns["nPromedio"].Visible = true;
            this.dtgLista.Columns["nDesviacionE"].Visible = true;
            this.dtgLista.Columns["nMontoMayor"].Visible = true;
            this.dtgLista.Columns["nMontoMenor"].Visible = true;
            this.dtgLista.Columns["lInusual"].Visible = true;
            this.dtgLista.Columns["nRepetInusual"].Visible = true;
            this.dtgLista.Columns["cDescripRep"].Visible = true;
            this.dtgLista.Columns["nCantidadOpe"].Visible = true;
                      

            this.dtgLista.Columns["Z"].DefaultCellStyle.Font = new Font(this.dtgLista.Font, FontStyle.Bold);
            this.dtgLista.Columns["Z"].DefaultCellStyle.ForeColor = Color.LightGray;
            this.dtgLista.Columns["P"].DefaultCellStyle.Font = new Font(this.dtgLista.Font, FontStyle.Bold);
            this.dtgLista.Columns["P"].DefaultCellStyle.ForeColor = Color.LightGray;

            this.dtgLista.Columns["cPerfilCliOpeInusual"].HeaderText = "Perfil cliente";
            this.dtgLista.Columns["idCli"].HeaderText = "Cod.Cli.";
            this.dtgLista.Columns["TipoDoc"].HeaderText = "Tipo Doc.";
            this.dtgLista.Columns["cNroDoc"].HeaderText = "Nº Doc";
            this.dtgLista.Columns["cNombresCli"].HeaderText = "Nombres";
            this.dtgLista.Columns["nEdad"].HeaderText = "Edad";
            this.dtgLista.Columns["cDireccion"].HeaderText = "Dirección";
            this.dtgLista.Columns["cNumeroTelefono"].HeaderText = "Teléfonos";
            this.dtgLista.Columns["cActividad"].HeaderText = "Actividad";
            this.dtgLista.Columns["Pais"].HeaderText = "País";
            this.dtgLista.Columns["nPuntaje"].HeaderText = "Ptj.Riesgo Zona";
            this.dtgLista.Columns["cCalificRiesgo"].HeaderText = "Calific.Riesgo Zona";
            this.dtgLista.Columns["nNroCuenta"].HeaderText = "Nº Cuenta";
            this.dtgLista.Columns["cAgenciaRegistro"].HeaderText = "Agencia Reg.Cuenta";
            this.dtgLista.Columns["Asesor"].HeaderText = "Asesor";
            this.dtgLista.Columns["nMontoApert"].HeaderText = "Monto apertura";
            this.dtgLista.Columns["MonedaApertura"].HeaderText = "Moneda apertura";
            this.dtgLista.Columns["Plazo"].HeaderText = "Plazo";
            this.dtgLista.Columns["Tasa"].HeaderText = "Tasa";
            this.dtgLista.Columns["FechaApertura"].HeaderText = "Fecha apertura";
            this.dtgLista.Columns["FechaVencto"].HeaderText = "Fecha Vencto.";
            this.dtgLista.Columns["cProducto"].HeaderText = "Producto";
            this.dtgLista.Columns["PtjProd"].HeaderText = "Ptj.Riesgo Prod.";
            this.dtgLista.Columns["RiesgoProd"].HeaderText = "Calific.Riesgo Prod.";
            this.dtgLista.Columns["cTipoOperacion"].HeaderText = "Tipo operación";
            this.dtgLista.Columns["cMotivoOperacion"].HeaderText = "Motivo operación";
            this.dtgLista.Columns["cTipIngreEgreso"].HeaderText = "Ingreso/Egreso";
            this.dtgLista.Columns["UsuarioOpe"].HeaderText = "Usuario Ope.";
            this.dtgLista.Columns["cAgenciaOpe"].HeaderText = "Agencia Ope.";
            this.dtgLista.Columns["dFechaOpe"].HeaderText = "Fecha Ope.";
            this.dtgLista.Columns["idKardex"].HeaderText = "Nº Kardex";
            this.dtgLista.Columns["cMoneda"].HeaderText = "Moneda Ope.";
            this.dtgLista.Columns["nMontoOperacion"].HeaderText = "Monto Ope.";
            this.dtgLista.Columns["nMontoDolares"].HeaderText = "Monto dolares Ope.";
            this.dtgLista.Columns["nUmbralAgencia"].HeaderText = "Umbral agencia";
            this.dtgLista.Columns["nTotalGenerado"].HeaderText = "Total generado";
            this.dtgLista.Columns["nPromedio"].HeaderText = "Promedio";
            this.dtgLista.Columns["nDesviacionE"].HeaderText = "Desviacion estandar.";
            this.dtgLista.Columns["nMontoMayor"].HeaderText = "Monto mayor";
            this.dtgLista.Columns["nMontoMenor"].HeaderText = "Monto menor";
            this.dtgLista.Columns["lInusual"].HeaderText = "Es inusual";
            this.dtgLista.Columns["nRepetInusual"].HeaderText = "Cant.Repeti.Inusual";
            this.dtgLista.Columns["cDescripRep"].HeaderText = "Calificación inusual";
            this.dtgLista.Columns["nCantidadOpe"].HeaderText = "Cantidad Ope.";
        }
        private void cargarCboOperaciones()
        {
            DataTable dtOpe = new DataTable();
            dtOpe.Columns.Add("idOpe", typeof(int));
            dtOpe.Columns.Add("cOpe", typeof(String));
            //DataRow drOpe = dtOpe.NewRow();
            //drOpe["idOpe"] = 0;
            //drOpe["cOpe"] = "INUSUALES";
            //dtOpe.Rows.Add(drOpe);
            DataRow drOpe1 = dtOpe.NewRow();
            drOpe1["idOpe"] = 1;
            drOpe1["cOpe"] = "CREDITOS";
            dtOpe.Rows.Add(drOpe1);
            DataRow drOpe2 = dtOpe.NewRow();
            drOpe2["idOpe"] = 2;
            drOpe2["cOpe"] = "AHORROS";
            dtOpe.Rows.Add(drOpe2);

            this.cboOperaciones.DataSource = dtOpe;
            this.cboOperaciones.DisplayMember = "cOpe";
            this.cboOperaciones.ValueMember = "idOpe";
        }
        private void cargarCboPerfilCli()
        {
            DataTable dtPerfiles = cnmapeoriesgoyopeinusual.listaPerfilCli(0);
            dtPerfiles.DefaultView.RowFilter = "lVigente = 1";

            this.cboPerfiles.DataSource = dtPerfiles;
            this.cboPerfiles.DisplayMember = "cPerfilCliOpeInusual";
            this.cboPerfiles.ValueMember = "idPerfilCliOpeInusual";
        }
        private void habilitarControles(Boolean Val)
        {
            this.cboOperaciones.Enabled = Val;
            this.cboPerfiles.Enabled = Val;
            this.conFechaAñoMesDesde.Enabled = Val;
            this.conFechaAñoMesHasta.Enabled = Val;
            this.conBusUbig1.Enabled = Val;
            this.btnProcesar1.Enabled = Val;

            this.btnNuevo1.Enabled = !Val;            
            this.btnCancelar1.Enabled = Val;           
        }
        private void pintarAlertaRiesgos()
        {            
            foreach (DataGridViewRow item in this.dtgLista.Rows)
            {
                item.Cells["Z"].Style.ForeColor = Color.FromName(Convert.ToString(item.Cells["ColorRiesgoZona"].Value));
                item.Cells["P"].Style.ForeColor = Color.FromName(Convert.ToString(item.Cells["ColorRiesgoProd"].Value));                
            }
        }
        private void limpiarControles()
        {
            this.cboOperaciones.SelectedIndex = -1;
            this.cboPerfiles.SelectedIndex = -1;
            this.dtListaCli.Clear();
        }
        private Boolean validarProceso()
        {
            if (this.cboOperaciones.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione operación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboOperaciones.Focus();
                return false;
            }
            if (this.cboPerfiles.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione perfil", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboPerfiles.Focus();
                return false;
            }
            if ((Convert.ToDateTime(this.conFechaAñoMesDesde.cPeriodo) > Convert.ToDateTime(this.conFechaAñoMesHasta.cPeriodo)))
            {
                MessageBox.Show("La fecha fin no puede ser menor que la fecha inicio", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.conFechaAñoMesHasta.Focus();
                return false;
            }
            //if (this.conBusUbig1.cboProvincia.SelectedIndex <= 0)
            //{
            //    MessageBox.Show("Seleccione provincia", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.conBusUbig1.cboProvincia.Focus();
            //    return false;
            //}
            return true;
        }
        private void imprimir()
        {
            if (Convert.ToInt32(this.dtgLista.Rows.Count) == 0)
            {
                MessageBox.Show("No existen registros para imprimir", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime dFechaDesde = Convert.ToDateTime("01/" + this.conFechaAñoMesDesde.cPeriodo);
            DateTime dFechaHasta = Convert.ToDateTime(DateTime.DaysInMonth(this.conFechaAñoMesHasta.anio, this.conFechaAñoMesHasta.idMes) + "/" + this.conFechaAñoMesHasta.cPeriodo);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            String cModulo = Convert.ToString(((DataRowView)this.cboOperaciones.SelectedItem)["cOpe"]);

            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idModulo", this.cboOperaciones.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToShortDateString().ToString(), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToShortDateString().ToString(), false));
            paramlist.Add(new ReportParameter("cModulo", cModulo, false));
            paramlist.Add(new ReportParameter("idUbigeo", this.conBusUbig1.nIdNodo.ToString(), false));

            string reportpath = "rptOpeInusuales.rdlc";
            dtslist.Add(new ReportDataSource("DataSet1", this.dtListaCli));
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion                    
    }
}
