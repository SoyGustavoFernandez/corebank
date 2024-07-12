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
    public partial class frmSeguimientoCarteraCR : frmBase
    {
        #region Variables Globales
      
        int idAgenciaCbo = 0;
        int idZonaGlobal = 0, idAgenciaGlobal = 0;
        int nCheck = 0;
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        Dictionary<string, object> dConfig = null;
        clsCNMantenimiento clsCNMantenimiento = new clsCNMantenimiento();

        string cNomUser = clsVarGlobal.User.cNomUsu;
        string cTituloMsjes = "Seguimiento de Cartera Clasificación de Riesgo del Crédito.";
        DateTime dFechaSistema = clsVarGlobal.dFecSystem;
        clsCNCro cnRptRsg = new clsCNCro();
        int cIdUser = clsVarGlobal.User.idUsuario;
        int idAgencia = clsVarGlobal.nIdAgencia;
        int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        int idZona = 0;
        #endregion

        public frmSeguimientoCarteraCR()
        {
            InitializeComponent();
            this.datePicker1.Value = dFechaSistema;
            this.datePicker1.Enabled = false;
            LlenarCombo();
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

        private void LlenarCombo()
        {
            cboBase.Items.Clear();

            cboBase.Items.Add("CPP");
            cboBase.Items.Add("DEFICIENTE");
            cboBase.Items.Add("DUDOSO");
            cboBase.Items.Add("PERDIDA");
        }

        public bool validar()
        {
            int idCalificativo = Convert.ToInt32(this.cboBase.SelectedIndex) + 1;
            int idZona = Convert.ToInt32(this.cboZona.SelectedIndex) + 1;

            if (idZona == 0)
            {
                MessageBox.Show("Debe de seleccionar la Zona.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idCalificativo == 0)
            {
                MessageBox.Show("Seleccione algún tipo de Clasificación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           
            return true;
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string dFecOpe = Convert.ToString(dFechaSistema);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            int idUsuario = Convert.ToInt32(cIdUser);
            int idCalificativo = Convert.ToInt32(this.cboBase.SelectedIndex) + 1;
            int idZona= Convert.ToInt32(this.cboZona.SelectedIndex) + 1;
            DateTime diaPrueba1 = Convert.ToDateTime(dFecOpe);
            string cCalificativo = Convert.ToString(this.cboBase.SelectedItem);
            DateTime diaPrueba = diaPrueba1.AddDays(-1);
            DateTime dFechaCambio = Convert.ToDateTime(this.datePicker1.Value);

            if (validar())
            {
                DataTable dtData = cnRptRsg.SeguimientoCarteraCR(diaPrueba1, 
                                                            Convert.ToInt32(cboZona.SelectedValue), 
                                                            Convert.ToInt32(cboAgencias.SelectedValue), 
                                                            Convert.ToInt32(cboPersonalCreditos.SelectedValue),
                                                            idCalificativo,
                                                            nCheck,
                                                            dFechaCambio
                                                            );
                if (dtData.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsSegCarteraRiesgo", dtData));

                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("nCalificativo", idCalificativo.ToString(), false));
                    paramlist.Add(new ReportParameter("nCodeUsuario", cIdUser.ToString(), false));
                    paramlist.Add(new ReportParameter("cAsesor", cNomUser.ToString(), false));
                    paramlist.Add(new ReportParameter("cClasificacion", cCalificativo.ToString(), false));
                    paramlist.Add(new ReportParameter("dFecOpe", dFechaSistema.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaConsulta", diaPrueba.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

                    string reportPath = "rptSeguimientoCarteraCR.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos para esta fecha. ", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void frmSeguimientoCarteraCR_Load(object sender, EventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.datePicker1.Enabled = true;
                nCheck = 1;
            }
            else
            {
                this.datePicker1.Enabled = false;
                nCheck = 0;
            }
        }

    }
}
