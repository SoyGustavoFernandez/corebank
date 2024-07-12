#region Referencias
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
using CRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

using ADM.CapaNegocio;
#endregion

namespace CRE.Presentacion
{
    public partial class frmRPTSolicitudEstados : frmBase
    {
        #region Variables Globales
        string nPerfilReporte = "";
        int nPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        public string cEstSolicitud = "cEstadosSolicitud";
        #endregion

        public frmRPTSolicitudEstados()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmRPTSeguimientoSeguroMultiriesgo_Load(object sender, EventArgs e)
        {
            obtenerPerfilUsuario();
            obtenerZonaByEstab();
            poblarEstadosCredito();
            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idZonaSeleccionado = 0;
                if (clsVarGlobal.nIdAgencia != 1)
                {  
                    idZonaSeleccionado = Convert.ToInt32(cboZona.SelectedValue);                
                }

                clsCNMantenimiento ListadoAgencia = new clsCNMantenimiento();
                DataTable dtAgencia = ListadoAgencia.CNObtenerAgenciaZona(idZonaSeleccionado);

                cboAgencia.ValueMember = dtAgencia.Columns["idAgencia"].ColumnName;
                cboAgencia.DisplayMember = dtAgencia.Columns["cNombreAge"].ColumnName;
                if (nPerfilReporte == "Establecimiento")//REPRESENTANTE DE SERVICIO AL CLIENTE
                {
                    DataTable dtFiltrado = dtAgencia.AsEnumerable().Where(r => r.Field<int>("idAgencia") == clsVarGlobal.nIdAgencia).CopyToDataTable();
                    cboAgencia.DataSource = dtFiltrado;
                }
                if (nPerfilReporte == "Agencia")//SUPERVISOR DE OPERACIONES
                {
                    DataRow row = dtAgencia.NewRow();
                    row["idAgencia"] = 0;
                    row["cNombreAge"] = "**TODOS**";
                    dtAgencia.Rows.InsertAt(row, 0);
                    cboAgencia.DataSource = dtAgencia;
                }
                if (nPerfilReporte == "Region")//EJECUTIVO CORPORATIVO
                {
                    DataRow row = dtAgencia.NewRow();
                    row["idAgencia"] = 0;
                    row["cNombreAge"] = "**TODOS**";
                    dtAgencia.Rows.InsertAt(row, 0);
                    cboAgencia.DataSource = dtAgencia;
                }
                if (nPerfilReporte == "AgenEstab")//COORDINADOR DE OPERACIONES
                {
                    DataTable dtAgencia_COP = ListadoAgencia.CNObtenerAgenciaZona(0);
                    DataTable dtFiltrado = dtAgencia_COP.AsEnumerable().Where(r => r.Field<int>("idAgencia") == clsVarGlobal.nIdAgencia).CopyToDataTable();
                    cboAgencia.DataSource = dtFiltrado;
                }
            }
            catch { }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                int idAgenciaSeleccionado = Convert.ToInt32(cboAgencia.SelectedValue);

                clsCNMantenimiento ListadEstablecimiento = new clsCNMantenimiento();
                DataTable dtEstablecimiento = ListadEstablecimiento.CNObtenerEstabAgencia(idAgenciaSeleccionado);

                cboEstablecimiento.ValueMember = dtEstablecimiento.Columns["idEstablecimiento"].ColumnName;
                cboEstablecimiento.DisplayMember = dtEstablecimiento.Columns["cNombreEstab"].ColumnName;
                if (nPerfilReporte == "Establecimiento")//REPRESENTANTE DE SERVICIO AL CLIENTE
                {
                    DataTable dtFiltrado = dtEstablecimiento.AsEnumerable().Where(r => r.Field<int>("idEstablecimiento") == clsVarGlobal.User.idEstablecimiento).CopyToDataTable();
                    cboEstablecimiento.DataSource = dtFiltrado;
                }
                if (nPerfilReporte == "Agencia")//SUPERVISOR DE OPERACIONES
                {
                    DataRow row = dtEstablecimiento.NewRow();
                    row["idEstablecimiento"] = 0;
                    row["cNombreEstab"] = "**TODOS**";
                    dtEstablecimiento.Rows.InsertAt(row, 0);
                    cboEstablecimiento.DataSource = dtEstablecimiento;
                }
                if (nPerfilReporte == "AgenEstab")//COORDINADOR DE OPERACIONES
                {
                    DataRow row = dtEstablecimiento.NewRow();
                    row["idEstablecimiento"] = 0;
                    row["cNombreEstab"] = "**TODOS**";
                    dtEstablecimiento.Rows.InsertAt(row, 0);
                    cboEstablecimiento.DataSource = dtEstablecimiento;
                }
                if (nPerfilReporte == "Region")//EJECUTIVO CORPORATIVO
                {
                    DataRow row = dtEstablecimiento.NewRow();
                    row["idEstablecimiento"] = 0;
                    row["cNombreEstab"] = "**TODOS**";
                    dtEstablecimiento.Rows.InsertAt(row, 0);
                    cboEstablecimiento.DataSource = dtEstablecimiento;
                }
            }
            catch
            { 
         
            }
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;
            int idZona = cboZona.SelectedValue == null ? -1 : Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = cboAgencia.SelectedValue == null ? -1 : Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstablecimiento = cboEstablecimiento.SelectedValue == null ? -1 : Convert.ToInt32(cboEstablecimiento.SelectedValue);
            clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            DataTable dtDatosReporte = objCNCreditoCargaSeguro.CNObtenerDatosRPTSolicitudes(dFechaDesde, dFechaHasta, idZona, idAgencia, idEstablecimiento, cboEstadoSolicitud.SelectedValue.ToString());

            if (dtDatosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsSolicitudes", dtDatosReporte));

            string reportpath = "rptReporteSolicitudes.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.Normal);
            frmReporte.ShowDialog();
        }

        #endregion

        #region Metodos
        private bool validar()
        {
            bool lValor = true;
            if (dtpDesde.Value > dtpHasta.Value)
            {
                lValor = false;
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValor;

            }
            return lValor;
        }

        private void obtenerEstabById()
        {
            clsCNMantenimiento Listadoestablecimiento = new clsCNMantenimiento();
            DataTable dtEstablecimiento = Listadoestablecimiento.CNObtenerEstablecimiento(clsVarGlobal.User.idEstablecimiento);
            DataRow row = dtEstablecimiento.NewRow();
            row["idEstablecimiento"] = 0;
            row["cNombreEstab"] = "**TODOS**";
            dtEstablecimiento.Rows.InsertAt(row, 0);
            cboEstablecimiento.ValueMember = dtEstablecimiento.Columns["idEstablecimiento"].ColumnName;
            cboEstablecimiento.DisplayMember = dtEstablecimiento.Columns["cNombreEstab"].ColumnName;

            cboEstablecimiento.DataSource = dtEstablecimiento;
            cboEstablecimiento.SelectedValue = clsVarGlobal.User.idEstablecimiento;
        }

        private void obtenerZonaByAgencia()
        {
            clsCNMantenimiento ListadoZona = new clsCNMantenimiento();
            DataTable dtZona = ListadoZona.CNObtenerZonaAgencia(clsVarGlobal.nIdAgencia);
            DataRow row = dtZona.NewRow();
            row["idZona"] = 0;
            row["cDesZona"] = "**TODOS**";
            dtZona.Rows.InsertAt(row, 0);
            cboZona.ValueMember = dtZona.Columns["idZona"].ColumnName;
            cboZona.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
            cboZona.DataSource = dtZona;
        }

        private void obtenerZonaByEstab()
        {
            clsCNMantenimiento ListadoZona = new clsCNMantenimiento();
            if (nPerfilReporte == "Agencia" || nPerfilReporte == "AgenEstab" || nPerfilReporte == "Establecimiento")//EJECUTIVO CORPORATIVO
            {
                DataTable dtZona = ListadoZona.CNObtenerZonaAgencia(clsVarGlobal.nIdAgencia);
                cboZona.ValueMember = dtZona.Columns["idZona"].ColumnName;
                cboZona.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
                cboZona.DataSource = dtZona;
            }
            else if (nPerfilReporte == "Region")
            {
                DataTable dtZona = ListadoZona.CNListarZonas();
                DataRow row = dtZona.NewRow();
                row["idZona"] = 0;
                row["cDesZona"] = "**TODOS**";
                dtZona.Rows.InsertAt(row, 0);
                cboZona.ValueMember = dtZona.Columns["idZona"].ColumnName;
                cboZona.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
                cboZona.DataSource = dtZona;
            }
        }

        private void poblarEstadosCredito()
        {
            clsCNMantenimiento obtenerEstadosSolicitud = new clsCNMantenimiento();
            DataTable dtEstadosSol=new DataTable();
            dtEstadosSol = obtenerEstadosSolicitud.CNObtenerSolicitudEstados(cEstSolicitud);
            DataRow filaEstados=dtEstadosSol.Rows[0];
            string estadosSolicitud=Convert.ToString(filaEstados["cValVar"]);
            clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            DataTable dtEstados = new DataTable();
            dtEstados=objCNCreditoCargaSeguro.CNListarEstadosSolicitud(estadosSolicitud);
            DataRow row = dtEstados.NewRow();
            row["IdEstado"] = estadosSolicitud;
            row["cEstado"] = "**TODOS**";
            dtEstados.Rows.InsertAt(row, 0);
            cboEstadoSolicitud.ValueMember = dtEstados.Columns["IdEstado"].ColumnName;
            cboEstadoSolicitud.DisplayMember = dtEstados.Columns["cEstado"].ColumnName;
            cboEstadoSolicitud.DataSource = dtEstados;
            
        }

        private List<EPerfil> obtenerListaPerfil()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            DataTable dtPerfil = new DataTable();

            clsCNMantenimiento obtenerPerfil = new clsCNMantenimiento();

            dtPerfil = obtenerPerfil.CNObtenerSolicitudPerfil("cReporteSolicitudPerfil");

            Char[] cSeparadorGrupoPerfil = { ';' };
            Char[] cSeparadorPerfil = { ':' };

            String[] cGrupoPerfil = Convert.ToString(dtPerfil.Rows[0]["cValVar"]).Split(cSeparadorGrupoPerfil);

            for (int i = 0; i < cGrupoPerfil.Length; i++)
            {
                String[] cPerfil = Convert.ToString(cGrupoPerfil[i]).Split(cSeparadorPerfil);
                EPerfil ePerfil = new EPerfil();
                ePerfil.idPerfil = Convert.ToString(cPerfil[1]);
                ePerfil.desRol = Convert.ToString(cPerfil[0]);
                listaPefil.Add(ePerfil);

            }

            return listaPefil;
        }

        private void obtenerPerfilUsuario()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            Char[] cSeparadorIdPerfil = { ',' };
            listaPefil = obtenerListaPerfil();
            foreach (EPerfil item in listaPefil)
            {
                String[] nIdPerfil = Convert.ToString(item.idPerfil).Split(cSeparadorIdPerfil);
                //if(item.idPerfil.Contains(nPerfil.ToString())){
                //nPerfilReporte = item.desRol;
                //MessageBox.Show(item.desRol);
                //}
                foreach (string idPerfil in nIdPerfil)
                {
                    if (idPerfil == Convert.ToString(nPerfil))
                    {
                        nPerfilReporte = item.desRol;
                        //MessageBox.Show(item.desRol);
                    }     
                }      
            }
        }
        #endregion

    }

    public class EPerfil
    {
        public string idPerfil { get; set; }
        public string desRol { get; set; }
    }
}

