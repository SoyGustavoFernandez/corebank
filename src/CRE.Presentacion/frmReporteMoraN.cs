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
using GEN.Funciones;
using EntityLayer;
using Microsoft.Reporting.WinForms;

using clsUsuario = GEN.CapaNegocio.clsCNUsuario;

namespace CRE.Presentacion
{
    public partial class frmReporteMoraN : frmBase
    {
        clsCNCredito cnCredito = new clsCNCredito();
        int idPerfil = -1;
        string cPerfil = null;
        int idAgencia = -1;
        int idUsuario = -1;
        int idZona = -1;
        Dictionary<string, object> dConfig = null;

        private void prepareAsesor()
        {
            this.Height = 225;
            this.groupBoxAsesor.Visible = true;
        }

        private void prepareJefeOficina()
        {
            this.cboPersonalCreditosJefeOficina.ListarPersonalCompleto(this.idAgencia, true);
            this.Height = 265;
            this.groupBoxJefeOficina.Location = new Point(12, 71);
            this.groupBoxJefeOficina.Visible = true;
        }

        private void prepareGerenteRegional()
        {
            DataTable dtZonaUsuario = new clsUsuario().ObtenerZonasUsuario(this.idUsuario);
            if (dtZonaUsuario.Rows.Count != 0)
            {
                foreach (DataRow row in dtZonaUsuario.Rows)
                {
                    this.idZona = Convert.ToInt32(row["idZona"]);
                    break;
                }
            }
            this.cboAgenciasGerenteRegional.FiltrarPorZona(this.idZona, true, false);
            this.cboPersonalCreditosGerenteRegional.clearDisable();
            this.Height = 300;
            this.groupBoxGerenteRegional.Location = new Point(12, 71);
            this.groupBoxGerenteRegional.Visible = true;
        }

        private void prepareAdministrador()
        {
            this.cboZonaAdministrador.cargarZona(true, false);
            this.cboAgenciasAdministrador.clearDisable();
            this.cboPersonalCreditosAdministrador.clearDisable();
            this.Height = 330;
            this.groupBoxAdministrador.Location = new Point(12, 71);
            this.groupBoxAdministrador.Visible = true;
        }

        private void prepareNoCorresponde()
        {
            this.Height = 175;
            this.labelNoCorresponde.Location = new Point(83, 12);
            this.labelNoCorresponde.Visible = true;
            this.btnSalirNoCorresponde.Location = new Point(135, 45);
            this.btnSalirNoCorresponde.Visible = true;
            this.groupBoxFecha.Visible = false;
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
        
        public frmReporteMoraN()
        {
            InitializeComponent();

            this.idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            this.cPerfil = clsVarGlobal.PerfilUsu.cPerfil;
            this.dConfig = parseConfig(clsVarApl.dicVarGen["cMoraNConfiguracionPerfil"]);
            this.idAgencia = clsVarGlobal.nIdAgencia;
            this.idUsuario = clsVarGlobal.PerfilUsu.idUsuario;

            string[] asesor = (string[])dConfig["asesor"];
            string[] jefeOficina = (string[])dConfig["jefeOficina"];
            string[] gerenteRegional = (string[])dConfig["gerenteRegional"];
            string[] administrador = (string[])dConfig["administrador"];

            if (Array.IndexOf(asesor, this.idPerfil.ToString()) != -1)
            {
                prepareAsesor();
            }
            else if (Array.IndexOf(jefeOficina, this.idPerfil.ToString()) != -1)
            {
                prepareJefeOficina();
            }
            else if (Array.IndexOf(gerenteRegional, this.idPerfil.ToString()) != -1)
            {
                prepareGerenteRegional();
            }
            else if (Array.IndexOf(administrador, this.idPerfil.ToString()) != -1)
            {
                prepareAdministrador();
            }
            else
            {
                prepareNoCorresponde();
            }
        }

        private void cboAgenciasGerenteRegional_Change(object sender, EventArgs e)
        {
            int idAgenciaLocal = Convert.ToInt32(this.cboAgenciasGerenteRegional.SelectedValue);
            if (idAgenciaLocal == 0)
            {
                this.cboPersonalCreditosGerenteRegional.clearDisable();
                return;
            }
            this.cboPersonalCreditosGerenteRegional.Enabled = true;
            this.cboPersonalCreditosGerenteRegional.ListarPersonalCompleto(idAgenciaLocal, true);
            
        }

        private void cboAgenciasAdministrador_Change(object sender, EventArgs e)
        {
            int idAgenciaLocal = Convert.ToInt32(this.cboAgenciasAdministrador.SelectedValue);
            if (idAgenciaLocal == 0)
            {
                this.cboPersonalCreditosAdministrador.clearDisable();
                return;
            }
            this.cboPersonalCreditosAdministrador.Enabled = true;
            this.cboPersonalCreditosAdministrador.ListarPersonalCompleto(idAgenciaLocal, true);
        }

        private void cboZonaAdministrador_Change(object sender, EventArgs e)
        {
            int idZonaLocal = Convert.ToInt32(this.cboZonaAdministrador.SelectedValue);
            if (idZonaLocal == 0)
            {
                this.cboAgenciasAdministrador.clearDisable();
            }
            else
            {
                this.cboAgenciasAdministrador.FiltrarPorZona(idZonaLocal, true, false);
                this.cboAgenciasAdministrador.Enabled = true;
            }
            this.cboPersonalCreditosAdministrador.clearDisable();   
        }

        private void lanzarReporte(string sSelectedIds)
        {
            DataTable dtCreditosMora = new DataTable();
            int nDesde = Convert.ToInt32(this.nudBaseDesde.Value);
            int nHasta = Convert.ToInt32(this.nudBaseHasta.Value);

            if (chcBaseTodos.Checked)
            {
                nDesde = 1;
                nHasta = 1000000;
            }

            dtCreditosMora = cnCredito.obtenerListaMoraN(sSelectedIds, nDesde, nHasta);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cUsuarios", sSelectedIds, false));
            paramlist.Add(new ReportParameter("nDesde", nDesde.ToString(), false));
            paramlist.Add(new ReportParameter("nHasta", nHasta.ToString(), false));

            if (dtCreditosMora.Rows.Count > 0)
            {
                dtslist.Add(new ReportDataSource("ReporteMora", dtCreditosMora));
                string reportpath = "rptCreditosMoraN.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontró ningún resultado.", "Reporte Mora 1 a N días", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimirAsesor_Click(object sender, EventArgs e)
        {
            this.lanzarReporte(idUsuario.ToString());
        }

        private void btnImprimirOficina_Click(object sender, EventArgs e)
        {
            int nSelected = (int)this.cboPersonalCreditosJefeOficina.SelectedValue;
            if (nSelected == 0)
            {
                this.lanzarReporte(this.cboPersonalCreditosJefeOficina.ObtenerListaPersonal());
            }
            else
            {
                this.lanzarReporte(nSelected.ToString());
            }
        }

        private void btnImprimirGerenteRegional_Click(object sender, EventArgs e)
        {
            if ((int)this.cboAgenciasGerenteRegional.SelectedValue == 0)
            {
                this.lanzarReporte(personalZona(this.idZona));
                return;
            }
            int nSelected = (int)this.cboPersonalCreditosGerenteRegional.SelectedValue;
            if (nSelected == 0)
            {
                this.lanzarReporte(this.cboPersonalCreditosGerenteRegional.ObtenerListaPersonal());
            }
            else
            {
                this.lanzarReporte(nSelected.ToString());
            }
        }

        private void btnImprimirAdministrador_Click(object sender, EventArgs e)
        {
            int idZonaLocal = (int)this.cboZonaAdministrador.SelectedValue;
            if (idZonaLocal == 0)
            {
                this.lanzarReporte(personalZona(0));
                return;
            }
            if ((int)this.cboAgenciasAdministrador.SelectedValue == 0)
            {
                this.lanzarReporte(personalZona(idZonaLocal));
                return;
            }
            int nSelected = (int)this.cboPersonalCreditosAdministrador.SelectedValue;
            if (nSelected == 0)
            {
                this.lanzarReporte(this.cboPersonalCreditosAdministrador.ObtenerListaPersonal());
            }
            else
            {
                this.lanzarReporte(nSelected.ToString());
            }
        }

        private string personalZona(int idZona)
        {
            GEN.CapaNegocio.clsCNPersonalCreditos ListaPersonalCre = new GEN.CapaNegocio.clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarPersonalCompletoZonaCre(idZona);

            List<string> ids = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                ids.Add(row["idUsuario"].ToString());
            }
            return String.Join(",", ids.ToArray());
        }

        private void chcBaseTodos_Changed(object sender, EventArgs e)
        {
            if (chcBaseTodos.Checked)
            {
                this.nudBaseDesde.Enabled = false;
                this.nudBaseHasta.Enabled = false;
            }
            else
            {
                this.nudBaseDesde.Enabled = true;
                this.nudBaseHasta.Enabled = true;
            }
        }
    }
}
