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
using GEN.BotonesBase;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;

using clsUsuario = GEN.CapaNegocio.clsCNUsuario;

namespace RSG.Presentacion
{
    public partial class frmRptRiesgosGral : frmBase
    {
        #region Variables
        clsCNMantenimiento clsCNMantenimiento = new clsCNMantenimiento();

        clsCNCro cnRptRsg = new clsCNCro();
        DataTable dt = new DataTable();
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        int nReporte = 0;
        string cReporte = "";
        Dictionary<string, object> dConfig = null;
        int idAgenciaCbo = 0;
        int idZonaGlobal = 0;
        #endregion
        public frmRptRiesgosGral()
        {
            InitializeComponent();
        }

        private void frmRptRiesgosGral_Load(object sender, EventArgs e)
        {
            cboZona1.AgregarTodos();
            cboZona1.SelectedValue = 0;
            gestionarFiltros();
            formatearDTG();
            this.dFechaIni.Value = dFechaHoy;
            this.dFechaFin.Value = dFechaHoy;
            nReporte = 1;
            mostrarCamposReporte();
            
        }

        private void gestionarFiltros()
        {
            var idperfil = clsVarGlobal.PerfilUsu.idPerfilUsu;
            DataTable dtZonaUsuario = new clsUsuario().ObtenerZonasUsuario(clsVarGlobal.PerfilUsu.idUsuario);
            this.dConfig = parseConfig(clsVarApl.dicVarGen["cMoraNConfiguracionPerfil"]);

            string[] asesor = (string[])dConfig["asesor"];
            string[] jefeOficina = (string[])dConfig["jefeOficina"];
            string[] gerenteRegional = (string[])dConfig["gerenteRegional"];
            string[] administrador = (string[])dConfig["administrador"];

            if (Array.IndexOf(jefeOficina, clsVarGlobal.PerfilUsu.idPerfil.ToString()) != -1)
            {
                prepareJefeOficina();
            }
            else if (Array.IndexOf(gerenteRegional, clsVarGlobal.PerfilUsu.idPerfil.ToString()) != -1)
            {
                prepareGerenteRegional();
                llenarAgencias();
            }
            else
            {
                prepareAdministrador();
            }
        }

        private void prepareJefeOficina()
        {
            DataTable zona = clsCNMantenimiento.obtenerZonaAgencia(clsVarGlobal.nIdAgencia);
            cboZona1.SelectedValue = zona.Rows[0]["idZona"];
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            cboZona1.Enabled = false;
            cboAgencias1.Enabled = false;
        }

        private void prepareGerenteRegional()
        {
            DataTable zona = new clsUsuario().ObtenerZonasUsuario(clsVarGlobal.PerfilUsu.idUsuario);
            cboZona1.SelectedValue = zona.Rows[0]["idZona"];
            cboAgencias1.SelectedValue = 0;
            cboZona1.Enabled = false;
        }

        private void prepareAdministrador()
        {
            cboZona1.SelectedValue = 0;
            cboAgencias1.SelectedValue = 0;
            btnImprimir1.Enabled = true;
        }

        private void formatearDTG()
        {
            
            dt.Columns.Add(new DataColumn("lSelected" , typeof(bool)));
            dt.Columns.Add(new DataColumn("cReporte", typeof(string)));
            dt.Columns.Add(new DataColumn("nReporte", typeof(int)));

            agregarROW(true, "CRÉDITOS DESFAVORABLES DESEMBOLSADOS",1);
            agregarROW(false, "CRÉDITOS CON DESTINO ACTIVO FIJO, LIBRE DISPONIBILIDAD", 2);
            agregarROW(false, "CREDITOS CON MONTO MAYOR", 3);
            agregarROW(false, "CREDITOS SEMESTRALES, ANUALES Y UNICUOTA", 4);
            agregarROW(false, "CREDITOS REFINANCIADOS Y/O REPROGRAMADOS", 5);
            agregarROW(false, "CREDITOS VIGENTES CON MORA PROMEDIO", 6);
            agregarROW(false, "CREDITOS CON ATRASO EN PRIMERA CUOTA", 7);
            agregarROW(false, "CREDITOS VIGENTES CON ATRASO MAYOR A DIAS EN TERCIO DE CRONOGRAMA", 8);

            dtgReportes.DataSource = dt;

            dtgReportes.Columns["nReporte"].Visible = false;
            dtgReportes.Columns["lSelected"].HeaderText = "-";
            dtgReportes.Columns["cReporte"].HeaderText = "REPORTE";

            dtgReportes.Columns["cReporte"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgReportes.Columns["lSelected"].Width = 20;
        }

        private void agregarROW(bool estado, string reporte, int numero)
        {
            DataRow row = dt.NewRow();
            row["lSelected"] = estado;
            row["cReporte"] = reporte;
            row["nReporte"] = numero;
            dt.Rows.Add(row);
        }

        private void dtgReportes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dtgReportes.Rows.Count; i++)
                dtgReportes.Rows[i].Cells["lSelected"].Value = false;
            
            dtgReportes.Rows[e.RowIndex].Cells["lSelected"].Value = true;
            nReporte = Convert.ToInt32(dtgReportes.Rows[e.RowIndex].Cells["nReporte"].Value);
            mostrarCamposReporte();
        }

        private void mostrarCamposReporte()
        {
            lblDias.Visible = false;
            cboDias.Visible = false;
            lblMonto.Visible = false;
            txtMonto.Visible = false;

            switch (nReporte)
            {
                case 6:
                    lblDias.Visible = true;
                    cboDias.Visible = true;
                    break;
                case 3:
                    lblMonto.Visible = true;
                    txtMonto.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            cReporte = dtgReportes.Rows[nReporte - 1].Cells["cReporte"].Value.ToString();

            DateTime dFechaIni_ = Convert.ToDateTime(this.dFechaIni.Value);
            DateTime dFechaFin_ = Convert.ToDateTime(this.dFechaFin.Value);
            int idZona = Convert.ToInt32(cboZona1.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);

            bool lDesfavorable = false, lActFijLibreDisp = false;
            decimal nMontoDesembolso = 0; bool semestralesAnualesUnicuotas = false; bool lRefinanciadoReprogramado = false;
            int nMoraPromedio = 0; bool lAtrasoPriCuota = false;
            bool lTercioCronograma = false;
            switch (nReporte)
            {
                case 1:
                    lDesfavorable = true;
                    break;
                case 2:
                    lActFijLibreDisp = true;
                    break;
                case 3:
                    nMontoDesembolso = Convert.ToDecimal(txtMonto.Text);
                    cReporte += " a " + nMontoDesembolso.ToString();
                    break;
                case 4:
                    semestralesAnualesUnicuotas = true;
                    break;
                case 5:
                    lRefinanciadoReprogramado = true;
                    break;
                case 6:
                    nMoraPromedio = Convert.ToInt32(cboDias.SelectedItem);
                    cReporte += " a " + nMoraPromedio + " DIAS";
                    break;
                case 7:
                    lAtrasoPriCuota = true;
                    break;
                case 8:
                    lTercioCronograma = true;
                    break;
                default:
                    break;
            }

            imprimirReporte(dFechaIni_, dFechaFin_, idZona, idAgencia, lDesfavorable, lActFijLibreDisp, nMontoDesembolso, semestralesAnualesUnicuotas, lRefinanciadoReprogramado, nMoraPromedio, lAtrasoPriCuota, lTercioCronograma);
        }

        private void imprimirReporte(DateTime dFechaIni, DateTime dFechaFin, int idZona,int idAgencia, bool lDesfavorable, bool lActFijLibreDisp,
            decimal nMontoDesembolso, bool semestralesAnualesUnicuotas, bool lRefinanciadoReprogramado, int nMoraPromedio, bool lAtrasoPriCuota, bool lTercioCronograma)
        {
            DataTable dtData = cnRptRsg.rptRiesgosGral(dFechaIni, dFechaFin, idZona,idAgencia, lDesfavorable, lActFijLibreDisp,
                        nMontoDesembolso, semestralesAnualesUnicuotas, lRefinanciadoReprogramado, nMoraPromedio, lAtrasoPriCuota, lTercioCronograma);

            string cNameColumn = "ATRASO MAXIMO";
            if(!lTercioCronograma)
                cNameColumn = "ATRASO PRIM CUOTA";

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("dFechaIni", this.dFechaIni.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", this.dFechaFin.Value.ToString(), false));

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgencia", cboAgencias1.Text, false));
            paramlist.Add(new ReportParameter("cNameReporte", cReporte, false));
            paramlist.Add(new ReportParameter("cNameColumn", cNameColumn, false));

            dtslist.Add(new ReportDataSource("datos", dtData));

            string reportpath = "rptRiesgosGral.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        public Dictionary<string, object> parseConfig(string sConfig)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            string[] configs = sConfig.Split(';');
            for (int i = 0; i < configs.Length; i++)
            {
                string[] parts = configs[i].Split(':');
                if (parts.Length == 2)
                {
                    config.Add(parts[0], parts[1].Split(','));
                }
            }
            return config;
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            idZonaGlobal = nIdZona;
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);

            cboAgencias1.SelectedValue = idAgenciaCbo;  
        }

        public void llenarAgencias()
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            idZonaGlobal = nIdZona;
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);

            cboAgencias1.SelectedValue = idAgenciaCbo;  
        }
    }
}
