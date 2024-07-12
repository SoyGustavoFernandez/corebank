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
    public partial class frmRptCreditosRiesgoPotencial : frmBase
    {
        #region Variables Globales
        clsCNCro cnRptRsg = new clsCNCro();

        int idAgenciaCbo = 0;
        int idZonaGlobal = 0, idAgenciaGlobal = 0;
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        Dictionary<string, object> dConfig = null;
        clsCNMantenimiento clsCNMantenimiento = new clsCNMantenimiento();
        #endregion
        
        public frmRptCreditosRiesgoPotencial()
        {
            InitializeComponent();
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            idZonaGlobal = nIdZona;
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);

            cboAgencias1.SelectedValue = idAgenciaCbo;  
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdAgencia = Convert.ToInt32(this.cboAgencias1.SelectedValue);
            idAgenciaGlobal = nIdAgencia;
            this.cboPersonalCreditos1.ListarPersonal(nIdAgencia, true); 
        }

        private void frmRptCreditosRiesgoPotencial_Load(object sender, EventArgs e)
        {
            cboZona1.AgregarTodos();
            cboZona1.SelectedValue = 0;
            this.dFechaIni.Value = dFechaHoy;
            borrarDatos();
            gestionarFiltros();
        }

        private void borrarDatos()
        {
            cboZona1.SelectedValue = -1;
            cboAgencias1.SelectedValue = -1;
            cboPersonalCreditos1.SelectedValue = -1;
            this.dFechaIni.Value = dFechaHoy;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            borrarDatos();
            gestionarFiltros();
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

            if (Array.IndexOf(asesor, clsVarGlobal.PerfilUsu.idPerfil.ToString()) != -1)
            {
                prepareAsesor();
            }
            else if (Array.IndexOf(jefeOficina, clsVarGlobal.PerfilUsu.idPerfil.ToString()) != -1)
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

        private void prepareAdministrador()
        {
            cboZona1.SelectedValue = 0;
            cboAgencias1.SelectedValue = 0;
            cboPersonalCreditos1.SelectedValue = 0;
            btnImprimir1.Enabled = true;
        }

        private void prepareNoCorresponde()
        {
            cboZona1.SelectedValue = 0;
            cboAgencias1.SelectedValue = 0;
            cboPersonalCreditos1.SelectedValue = 0;
            cboZona1.Enabled = false;
            cboAgencias1.Enabled = false;
            cboPersonalCreditos1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnImprimir1.Enabled = false;
        }

        private void prepareGerenteRegional()
        {
            DataTable zona = new clsUsuario().ObtenerZonasUsuario(clsVarGlobal.PerfilUsu.idUsuario);
            cboZona1.SelectedValue = zona.Rows[0]["idZona"];
            cboAgencias1.SelectedValue = 0;
            cboPersonalCreditos1.SelectedValue = 0;
            cboZona1.Enabled = false;
        }

        private void prepareJefeOficina()
        {
            DataTable zona = clsCNMantenimiento.obtenerZonaAgencia(clsVarGlobal.nIdAgencia);
            cboZona1.SelectedValue = zona.Rows[0]["idZona"];
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            cboPersonalCreditos1.SelectedValue = 0;
            cboZona1.Enabled = false;
            cboAgencias1.Enabled = false;
        }

        private void prepareAsesor()
        {
            DataTable zona = clsCNMantenimiento.obtenerZonaAgencia(clsVarGlobal.nIdAgencia);
            cboZona1.SelectedValue = zona.Rows[0]["idZona"];
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
            cboPersonalCreditos1.SelectedValue = clsVarGlobal.PerfilUsu.idUsuario;
            cboZona1.Enabled = false;
            cboAgencias1.Enabled = false;
            cboPersonalCreditos1.Enabled = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            DataTable dtData = cnRptRsg.rptCreditosRiesgoPotencial(
                    Convert.ToDateTime(dFechaIni.Value),
                    Convert.ToInt32(cboZona1.SelectedValue), 
                    Convert.ToInt32(cboAgencias1.SelectedValue), 
                    Convert.ToInt32(cboPersonalCreditos1.SelectedValue)
                );

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("datos", dtData));

            string reportpath = "rptCreditosRiesgoPotencial.rdlc";

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
    }
}
