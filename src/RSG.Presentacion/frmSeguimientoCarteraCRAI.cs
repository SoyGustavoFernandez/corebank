using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSG.Presentacion
{
    public partial class frmSeguimientoCarteraCRAI : frmBase
    {
        #region Variables Globales

        int idAgenciaCbo = 0;
        int idZonaGlobal = 0, idAgenciaGlobal = 0;
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        Dictionary<string, object> dConfig = null;
        clsCNMantenimiento clsCNMantenimiento = new clsCNMantenimiento();

        string cNomUser = clsVarGlobal.User.cNomUsu;
        string cTituloMsjes = "Seguimiento de Cartera Clasificación de Riesgo del Crédito Alineamiento Interno.";
        DateTime dFechaSistema = clsVarGlobal.dFecSystem;
        clsCNCro cnRptRsg = new clsCNCro();
        int cIdUser = clsVarGlobal.User.idUsuario;
        int idAgencia = clsVarGlobal.nIdAgencia;
        int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        int idZona = 0;

        #endregion

        public frmSeguimientoCarteraCRAI()
        {
            InitializeComponent();
            this.datePicker1.Value = dFechaSistema;
            Zona();
        }

        private void Zona()
        {
            DataTable dtData = cnRptRsg.Zona(clsVarGlobal.nIdAgencia);
            if (dtData.Rows.Count > 0)
            {
                idZona = Convert.ToInt32(dtData.Rows[0]["idZona"].ToString());
            }
            else
            {
                idZona = -1;
            }
        }

        public bool validar()
        {
            int idZona = Convert.ToInt32(this.cboZona.SelectedIndex) + 1;

            if (idZona == 0)
            {
                MessageBox.Show("Debe de seleccionar la Zona.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string dFecOpe = Convert.ToString(dFechaSistema); 
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            int idUsuario = Convert.ToInt32(cIdUser);
            DateTime dFechaConsul = Convert.ToDateTime(this.datePicker1.Value);
            dFechaConsul = dFechaConsul.AddDays(-1);
            string dFechaConsulta = dFechaConsul.ToString("yyyy/MM/dd");
            
            if (validar())
            {
                MessageBox.Show("Se realizará el reporte con la fecha: " + dFechaConsulta, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dtData = cnRptRsg.SeguimientoCarteraCRAI(dFechaConsul, 
                                                                Convert.ToInt32(cboZona.SelectedValue), 
                                                                Convert.ToInt32(cboAgencias.SelectedValue), 
                                                                Convert.ToInt32(cboPersonalCreditos.SelectedValue)
                                                                    );
                if (dtData.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsSegCarteraRiesgo", dtData));

                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("nCodeUser", cIdUser.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomUser", cNomUser.ToString(), false));
                    paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaC", dFechaConsulta.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

                    string reportPath = "rptSeguimientoCarteraCRAI.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                    new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos para esta fecha.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona.SelectedValue);
            idZonaGlobal = nIdZona;
            this.cboAgencias.FiltrarPorZonaTodos(nIdZona);

            cboAgencias.SelectedValue = idAgenciaCbo;  
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdAgencia = Convert.ToInt32(this.cboAgencias.SelectedValue);
            idAgenciaGlobal = nIdAgencia;
            this.cboPersonalCreditos.ListarPersonal(nIdAgencia, true); 
        }

        private void frmSeguimientoCarteraCRAI_Load(object sender, EventArgs e)
        {
            cboZona.SelectedValue = 0;
            Inicializar();

            if (clsVarGlobal.PerfilUsu.idPerfil == 85)
            {
                perfilJefeOficina();
            }

            else if (clsVarGlobal.PerfilUsu.idPerfil == 75)
            {
                perfilGerenteRegional();
            }

            else if (clsVarGlobal.PerfilUsu.idPerfil == 34
                || clsVarGlobal.PerfilUsu.idPerfil == 115
                || clsVarGlobal.PerfilUsu.idPerfil == 118
                )
            {
                perfilAsesorNegocios();
            }

            else
            {
                borrarDatos();
            }
        }

        private void perfilAsesorNegocios()
        {
            cboZona.SelectedValue = idZona;
            cboZona.Enabled = false;
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAgencias.Enabled = false;
            cboPersonalCreditos.SelectedValue = clsVarGlobal.PerfilUsu.idUsuario;
            cboPersonalCreditos.Enabled = false;
        }

        private void perfilJefeOficina()
        {
            cboZona.SelectedValue = idZona;
            cboZona.Enabled = false;
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAgencias.Enabled = false;
            cboPersonalCreditos.Enabled = true;
        }

        private void perfilGerenteRegional()
        {
            cboZona.SelectedValue = idZona;
            cboZona.Enabled = false;
            cboAgencias.Enabled = true;
            cboPersonalCreditos.Enabled = true;
        }

        private void borrarDatos()
        {
            cboZona.SelectedValue = -1;
            cboAgencias.SelectedValue = -1;
            cboPersonalCreditos.SelectedValue = -1;

            cboZona.Enabled = true;
            cboAgencias.Enabled = true;
            cboPersonalCreditos.Enabled = true;
        }

        private void Inicializar()
        {
            cboZona.SelectedValue = -1;
            cboZona.Enabled = false;
            cboAgencias.SelectedValue = -1;
            cboAgencias.Enabled = false;
            cboPersonalCreditos.SelectedValue = -1;
            cboPersonalCreditos.Enabled = false;
        }
    }
}
