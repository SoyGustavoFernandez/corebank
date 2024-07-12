using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptRecSobFal : frmBase
    {
        public frmRptRecSobFal()
        {
            InitializeComponent();
            cboAgencias.AgenciasYTodos();
        }

        private void frmRptCobroRec_Load(object sender, EventArgs e)
        {
            //======================================================
            //--Cargar Datos
            //======================================================
            if (this.cboAgencias.SelectedIndex >= 0)
            {
                this.cboAgencias.SelectedValue = 1;
                this.cboAgencias.Select();
                this.cboAgencias_SelectedIndexChanged(sender, e);
            }
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
        }

       
        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            DataTable tbColAge = LisColAge.ListarColabAgencias(idAge);
            DataRow dr = tbColAge.NewRow();
            dr["idUsuario"] = "0";
            dr["cNombre"] = "***TODOS***";
            tbColAge.Rows.InsertAt(dr,0);
            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
            if (tbColAge.Rows.Count > 0)
            {
                this.cboColaborador.Enabled = true;
            }
            else
            {
                this.cboColaborador.Enabled = false;
            }
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nItem;
            nItem = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            ListarColAgencia(nItem);
        }

       
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione una agencia","Reporte de Recibos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            string dFecIni = this.dtpFecIni.Value.ToShortDateString();
            string dFecFin = this.dtpFecFin.Value.ToShortDateString();
            string idUsu = this.cboColaborador.SelectedValue.ToString();
            string idAge = this.cboAgencias.SelectedValue.ToString();
            string idMon = this.cboMoneda.SelectedValue.ToString();
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];

            DataTable dtRecSobFal = new clsRPTCNCaja().CNRptRecSobFal(Convert.ToInt32(idAge),Convert.ToInt32(idUsu),Convert.ToDateTime(dFecIni),Convert.ToDateTime(dFecFin),Convert.ToInt32(idMon));
            if (dtRecSobFal.Rows.Count<=0)
            {
                MessageBox.Show("No se encontraton registros con los \n parametros especificados para el reporte.", "Reporte de Recibos de Sobrantes y Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("idAge", idAge, false));
                paramlist.Add(new ReportParameter("idUsu", idUsu, false));
                paramlist.Add(new ReportParameter("dFecIni", dFecIni, false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin, false));
                paramlist.Add(new ReportParameter("idMon", idMon, false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRecSobFal", dtRecSobFal));
                string reportpath = "RptRecSobFal.rdlc";
                new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            }           
        }       
    }
}
