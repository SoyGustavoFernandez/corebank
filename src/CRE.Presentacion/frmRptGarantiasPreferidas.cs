using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CRE.CapaNegocio;

using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmRptGarantiasPreferidas : frmBase
    {

#region variables Globales
        int idAgenciaCbo = 0;
        int idRegionGlobal = -1; 
        int idAgenciaGlobal = 0;
        int idTipoGarantiaGlobal = 0;
        string cTituloMsje = "Reporte Garantías Preferidas/Contradepósitos";

#endregion




        public frmRptGarantiasPreferidas()
        {
            InitializeComponent();
            dtpFechaHasta.Value = clsVarGlobal.dFecSystem;
            
            this.checkBox1.Checked = true;
            this.cboAgencias1.Enabled = false;
         
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (idRegionGlobal == -1)
            {
                MessageBox.Show("Debe de Seleccionar una región.", cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            
            if (rptPreferidas.Checked)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramlist.Add(new ReportParameter("x_idAgencia", "5", false));
                paramlist.Add(new ReportParameter("x_idClaseGarantia", Convert.ToString(cboClaseGarantia.SelectedValue), false));
                paramlist.Add(new ReportParameter("x_dFecha", dtpFechaHasta.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_claseGarantia", cboClaseGarantia.Text, false));
                paramlist.Add(new ReportParameter("idRegion", Convert.ToString(idRegionGlobal), false));
                paramlist.Add(new ReportParameter("idAgencia", Convert.ToString(idAgenciaGlobal), false));
                paramlist.Add(new ReportParameter("idTipoGarantia", Convert.ToString(idTipoGarantiaGlobal), false));
                

                //DataTable dtRes = conListAgencias.obtenerAgenciasSeleccionados();
                //DataSet dsRes = new DataSet("dsAgencia");

                //dsRes.Tables.Add(dtRes);
                //string cXmlAgencias = dsRes.GetXml();

                //MessageBox.Show(cXmlAgencias);


                //DataTable contradepositos = new clsCNGarantia().CNRptContradepositos( cboAgencias.SelectedValue, cboClaseGarantia.SelectedValue , dtpFecha.Value);
                DataTable garantiasPreferidas = new clsCNGarantia().CNRptGarantiasPreferidas(Convert.ToInt32(cboClaseGarantia.SelectedValue), dtpFechaHasta.Value, idRegionGlobal, idAgenciaGlobal,idTipoGarantiaGlobal);
                dtslist.Add(new ReportDataSource("dataGarantiasPreferidas", garantiasPreferidas));

                string reportpath = "rptGarantiasPreferidas.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramlist.Add(new ReportParameter("x_idAgencia", "5", false));
                paramlist.Add(new ReportParameter("x_idClaseGarantia", Convert.ToString(cboClaseGarantia.SelectedValue), false));
                paramlist.Add(new ReportParameter("x_dFecha", (dtpFechaHasta.Value).ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_claseGarantia", cboClaseGarantia.Text, false));
                paramlist.Add(new ReportParameter("idRegion", Convert.ToString(idRegionGlobal), false));
                paramlist.Add(new ReportParameter("idAgencia", Convert.ToString(idAgenciaGlobal), false));
                paramlist.Add(new ReportParameter("idTipoGarantia", Convert.ToString(idTipoGarantiaGlobal), false));
                
                //DataTable dtRes = conListAgencias.obtenerAgenciasSeleccionados();
                //DataSet dsRes = new DataSet("dsAgencia");

                //dsRes.Tables.Add(dtRes);
                //string cXmlAgencias = dsRes.GetXml();

                DataTable contradepositos = new clsCNGarantia().CNRptContradepositosGar(Convert.ToInt32(cboClaseGarantia.SelectedValue), dtpFechaHasta.Value, idRegionGlobal, idAgenciaGlobal, idTipoGarantiaGlobal);
                dtslist.Add(new ReportDataSource("dataContradepositos", contradepositos));

                string reportpath = "rptContradepositosGar.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
        
        public static DateTime UltimoDiaDelMes(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }

        private void frmRptGarantiasPreferidas_Load(object sender, EventArgs e)
        {
            cboClaseGarantia.cargarClaseByGrupo(1, true);
        }

        private void cboZona2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboAgencias1.Enabled = true;
            
            int nIdZona = Convert.ToInt32(this.cboZona2.SelectedValue);
            idRegionGlobal = nIdZona;
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);

            cboAgencias1.SelectedValue = idAgenciaCbo;  
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.cboZona2.Enabled = false;
                this.cboZona2.SelectedValue = -1;

                this.cboAgencias1.Enabled = false;
                this.cboAgencias1.SelectedValue = -1;

                idRegionGlobal = 0;
                idAgenciaGlobal = 0;


            }
            else
            {
                this.cboZona2.Enabled = true;
                this.cboZona2.SelectedValue = -1;

                this.cboAgencias1.Enabled = false;
                this.cboAgencias1.SelectedValue = -1;

                idRegionGlobal = -1;
                idAgenciaGlobal = 0;
            }
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdAgencia = Convert.ToInt32(this.cboAgencias1.SelectedValue);
            idAgenciaGlobal = nIdAgencia;

        }

       
    }
}
