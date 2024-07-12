using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
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
    public partial class frmReporteReimpresionUsuario : frmBase
    {
        clsRPTCNCredito objReporte = new clsRPTCNCredito();
        public DataTable dtListaAgencias;
        public clsCNRegionZona listOficina = new clsCNRegionZona();
        string nPerfilReporte = "";
        int nPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
        public frmReporteReimpresionUsuario()
        {
            InitializeComponent();
        }

        private void frmReporteReimpresionUsuario_Load(object sender, EventArgs e)
        {
            obtenerPerfilUsuario();
            dFechIni.Value = clsVarGlobal.dFecSystem;
            dFechFin.Value = clsVarGlobal.dFecSystem;
            obtenerRegion();
        }
        private void obtenerRegion()
        {
            clsCNMantenimiento ListadoZona = new clsCNMantenimiento();
            if (nPerfilReporte == "RegionAgen")
            {

                DataTable dtZona = ListadoZona.CNObtenerZonasAgenciaGeneral(clsVarGlobal.nIdAgencia);
                cboZona1.ValueMember = dtZona.Columns["idZona"].ColumnName;
                cboZona1.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
                cboZona1.DataSource = dtZona;
            }
            else if (nPerfilReporte == "Region")
            {
                DataTable dtZona = clsFiles.ListarZonaVigentes();
                DataRow row = dtZona.NewRow();
                row["idZona"] = 0;
                row["cDesZona"] = "**TODOS**";
                dtZona.Rows.InsertAt(row, 0);
                cboZona1.ValueMember = dtZona.Columns["idZona"].ColumnName;
                cboZona1.DisplayMember = dtZona.Columns["cDesZona"].ColumnName;
                cboZona1.DataSource = dtZona;
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dtpDesde = dFechIni.Value;
            DateTime dtpHasta = dFechFin.Value;
            if (!bValidaFecha(dtpDesde, dtpHasta))
            {
                return;
            }
            DataTable dtRecupera = objReporte.CNDatosReimpresionVoucherPersonal(dtpDesde.ToString("yyyy-MM-dd"), dtpHasta.ToString("yyyy-MM-dd"), Convert.ToInt32(cboZona1.SelectedValue), Convert.ToInt32(cboAgencia.SelectedValue));

            if (dtRecupera.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("DsReimpresionV", dtRecupera));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaIni", dtpDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", dtpHasta.ToString("dd/MM/yyyy"), false));

            string reportpath = "RptReimpresionUsuario.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        private bool bValidaFecha(DateTime dtpDesde, DateTime dtpHasta)
        {
            bool lValor = true;
            if (dtpDesde > dtpHasta)
            {
                lValor = false;
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValor;

            }
            TimeSpan difFecha = dtpHasta - dtpDesde;
            int nDias = difFecha.Days;
            if (nDias > 30)
            {
                lValor = false;
                MessageBox.Show("La consulta no puede ser mayor a 1 Mes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lValor;

            }
            return lValor;
        }
        private List<EPerfil> obtenerListaPerfil()
        {
            List<EPerfil> listaPefil = new List<EPerfil>();
            DataTable dtPerfil = new DataTable();

            clsCNMantenimiento obtenerPerfil = new clsCNMantenimiento();

            dtPerfil = obtenerPerfil.CNObtenerPerfilReporteExtorno("cReporteReimpresionVPersonal");

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

                foreach (string idPerfil in nIdPerfil)
                {
                    if (idPerfil == Convert.ToString(nPerfil))
                    {
                        nPerfilReporte = item.desRol;
                    }
                }
            }
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZonaSeleccionado = Convert.ToInt32(cboZona1.SelectedValue);
            this.dtListaAgencias = listOficina.CNListarOficinaByZona(idZonaSeleccionado);

            this.cboAgencia.ValueMember = dtListaAgencias.Columns[0].ToString();
            this.cboAgencia.DisplayMember = dtListaAgencias.Columns[1].ToString();
            if (nPerfilReporte == "RegionAgen")
            {
                DataTable dtFiltrado = dtListaAgencias.AsEnumerable().Where(r => r.Field<int>("idAgencia") == clsVarGlobal.nIdAgencia).CopyToDataTable();
                cboAgencia.DataSource = dtFiltrado;
            }

            if (nPerfilReporte == "Region")
            {
                DataRow row = dtListaAgencias.NewRow();
                row["idAgencia"] = 0;
                row["cNombreAge"] = "**TODOS**";
                dtListaAgencias.Rows.InsertAt(row, 0);
                cboAgencia.DataSource = dtListaAgencias;
            }
        }
      
    }
}
