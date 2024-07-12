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
    public partial class frmSaldoProvisiones : frmBase
    {
        #region Variables Globales

        int idAgenciaCbo = 0;
        int idZonaGlobal = 0, idAgenciaGlobal = 0;
        string cNomUser = clsVarGlobal.User.cNomUsu;
        string cTituloMsjes = "Saldo Provisiones";
        DateTime dFechaSistema = clsVarGlobal.dFecSystem;
        clsCNCro cnRptRsg = new clsCNCro();
        int cIdUser = clsVarGlobal.User.idUsuario;
        int idZona = 0;

        #endregion

        public frmSaldoProvisiones()
        {
            InitializeComponent();
            Zona();
            this.datePicker1.Value = dFechaSistema;
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

            DateTime dFechaConsul = Convert.ToDateTime(this.datePicker1.Value);
            if (dFechaSistema < dFechaConsul)
            {
                MessageBox.Show("La fecha no puede ser mayor a la fecha de sistema.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string dFechaConsulta = dFechaConsul.ToString("yyyy/MM/dd");

            if (validar())
            {

                DataTable dtData = cnRptRsg.GeneraSaldoProvision(dFechaConsul,
                                                                Convert.ToInt32(cboZona.SelectedValue),
                                                                Convert.ToInt32(cboAgencias.SelectedValue)
                                                                    );
                if (dtData.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsData", dtData));

                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("nCodeUser", cIdUser.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomUser", cNomUser.ToString(), false));
                    paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaC", dFechaConsulta.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

                    paramlist.Add(new ReportParameter("cZona", cboZona.Text, false));
                    paramlist.Add(new ReportParameter("cAgencia", cboAgencias.Text, false));

                    string reportPath = "rptGeneraSaldoProvision.rdlc";
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

        private void Inicializar()
        {
            cboZona.SelectedValue = -1;
            cboZona.Enabled = false;
            cboAgencias.SelectedValue = -1;
            cboAgencias.Enabled = false;

        }

        private void borrarDatos()
        {
            cboZona.SelectedValue = -1;
            cboAgencias.SelectedValue = -1;
            
            cboZona.Enabled = true;
            cboAgencias.Enabled = true;
            
        }

        private void frmSaldoProvisiones_Load(object sender, EventArgs e)
        {
            cboZona.AgregarTodos();
            cboZona.SelectedValue = 0;
            Inicializar();
            borrarDatos();
        }
    }
}
