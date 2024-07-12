using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using RSG.CapaNegocio;

using clsUsuario = GEN.CapaNegocio.clsCNUsuario;


namespace CNT.Presentacion
{
    public partial class frmRptRentabilidadPorOficina : frmBase
    {
        #region Variables
        int idAgenciaCbo = 0;
        int idZonaGlobal = 0, idAgenciaGlobal = 0;
        clsCNMantenimiento clsCNMantenimiento = new clsCNMantenimiento();
        Dictionary<string, object> dConfig = null;
        #endregion

        public frmRptRentabilidadPorOficina()
        {
            InitializeComponent();
        }

        private void frmRptContabilidad4_Load(object sender, EventArgs e)
        {
            //cboZona1.cargarZona(true,false);
            cboZona1.AgregarTodos();
            cboZona1.SelectedValue = 0;

            dtpFecha.MaxDate = Convert.ToDateTime(clsVarGlobal.dFecSystem);
            gestionarFiltros();

            DataTable dt_ = new DataTable();
            DataRow dr_ = null;
            dt_.Columns.Clear();
            dt_.Rows.Clear();
            dt_.Columns.Add(new DataColumn("anio", typeof(string)));

            for (int i = Convert.ToInt32(clsVarGlobal.dFecSystem.Year); i >= 2013; i--)
            {
                dr_ = dt_.NewRow();
                dr_["anio"] = i;
                dt_.Rows.Add(dr_);
            }

            cboAnio.DataSource = dt_;
            cboAnio.DisplayMember = "anio";
            cboAnio.SelectedIndex = 0;

        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            idZonaGlobal = nIdZona;
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);
            cboAgencias1.SelectedValue = idAgenciaCbo;
        }

        private void chcDistri_CheckedChanged(object sender, EventArgs e)
        {
            if (chcDistri.Checked)
            {
                chcOriginal.Checked = false;
            }
            else
            {
                chcOriginal.Checked = true;
            }
        }

        private void chcOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if (chcOriginal.Checked)
            {
                chcDistri.Checked = false;
            }
            else
            {
                chcDistri.Checked = true;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            
            

            string reportpath = "rptRentabilidadOficina.rdlc";

            string cDistribuido = "Original";
            if (chcDistri.Checked)
                cDistribuido = "Distribuido";

            if (rptMensual.Checked)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("x_dFecha", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cZona", cboZona1.Text, false));
                paramlist.Add(new ReportParameter("cAgencia", cboAgencias1.Text, false));
                paramlist.Add(new ReportParameter("dFecha", dtpFecha.Text, false));
                paramlist.Add(new ReportParameter("cDistribuido", cDistribuido, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsRentabilidadOficina", new clsRPTCNContabilidad().CNRptRentabilidadOficina(dtpFecha.Value,
                Convert.ToInt32(cboZona1.SelectedValue), Convert.ToInt32(cboAgencias1.SelectedValue), chcDistri.Checked, Convert.ToInt32(NumDig.Text))));

                dtslist.Add(new ReportDataSource("dtsIndicadores", new clsRPTCNContabilidad().CNRptRentabilidadOficinaIndicadores(dtpFecha.Value,
                Convert.ToInt32(cboZona1.SelectedValue), Convert.ToInt32(cboAgencias1.SelectedValue), chcDistri.Checked)));

                reportpath = "rptRentabilidadOficina.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("nAnio", cboAnio.Text, false));
                paramlist.Add(new ReportParameter("idZona", cboZona1.SelectedValue.ToString(), false));
                paramlist.Add(new ReportParameter("idAgencia", cboAgencias1.SelectedValue.ToString(), false));
                paramlist.Add(new ReportParameter("lDistribuido", chcDistri.Checked.ToString(), false));
                paramlist.Add(new ReportParameter("cZona", cboZona1.Text, false));
                paramlist.Add(new ReportParameter("cAgencia", cboAgencias1.Text, false));
                paramlist.Add(new ReportParameter("cDistribuido", cDistribuido, false));
                
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsDatosHistorico", new clsRPTCNContabilidad().CNRptRentabilidadOficinaHistorico(Convert.ToInt32(cboAnio.Text),
                Convert.ToInt32(cboZona1.SelectedValue), Convert.ToInt32(cboAgencias1.SelectedValue), chcDistri.Checked, Convert.ToInt32(NumDig.Text))));
                reportpath = "rptRentabilidadOficinaHistorico.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            

            
            
        }

        private void tipoReporteClick()
        {
            bool acumulado = true;
            if (rptMensual.Checked)
            {
                cboAnio.Visible = false;
                dtpFecha.Visible = true;
            }

            else
            {
                cboAnio.Visible = true;
                dtpFecha.Visible = false;
            }
        }

        private void rptMensual_CheckedChanged(object sender, EventArgs e)
        {
            tipoReporteClick();
        }

        private void rptHistorico_CheckedChanged(object sender, EventArgs e)
        {
            tipoReporteClick();
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

        private void cboZona1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            idZonaGlobal = nIdZona;
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);

            cboAgencias1.SelectedValue = idAgenciaCbo;  
        }

    }
}
