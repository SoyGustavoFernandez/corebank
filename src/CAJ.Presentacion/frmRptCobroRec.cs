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
    public partial class frmRptCobroRec : frmBase
    {
        public frmRptCobroRec()
        {
            InitializeComponent();
        }

        private void frmRptCobroRec_Load(object sender, EventArgs e)
        {
            //======================================================
            //--Cargar Datos
            //======================================================
            CargarTiporecibos();
            if (this.cboTipRec.SelectedIndex < 0)
            {
                CargarConceptos(0);
            }
            else
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue.ToString().Trim()));
            }
            if (cboAgencias.SelectedIndex >= 0)
            {
                cboAgencias.SelectedValue = 1;
                cboAgencias.Select();
                cboAgencias_SelectedIndexChanged(sender, e);
            }
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void CargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 1;
        }

        private void CargarConceptos(int nTipRec)
        {
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            DataTable tbConcep = LisConcep.ListaConceptos(nTipRec, "");
            this.chklbConcep.DataSource = tbConcep;
            this.chklbConcep.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            this.chklbConcep.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
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

        private void cboTipRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            chcSelec.Checked = false;
            if (this.cboTipRec.SelectedValue.ToString() == "1")
            {
                CargarConceptos(1);
            }
            else
            {
                CargarConceptos(2);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            String idConcep = "";
            foreach (DataRowView item in this.chklbConcep.CheckedItems)
            {
                idConcep += (item.Row["idConcepto"] + ",");
            }
            if (string.IsNullOrEmpty(idConcep))
            {
                MessageBox.Show("Deber de Seleccionar el(los) Concepto(s) a visualizar","Reporte de recibos por Conceptos",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
           
            string dFecIni = this.dtpFecIni.Value.ToShortDateString();
            string dFecFin = this.dtpFecFin.Value.ToShortDateString();
            string idUsu = this.cboColaborador.SelectedValue.ToString();
            string idAge = this.cboAgencias.SelectedValue.ToString();
            string idMon = this.cboMoneda.SelectedValue.ToString();
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            DataTable dtCobroRec = new clsRPTCNCaja().CNRptCobroRec(Convert.ToInt32(idAge), Convert.ToInt32(idUsu), Convert.ToDateTime(dFecIni), Convert.ToDateTime(dFecFin), Convert.ToInt32(idMon), idConcep);
            if (dtCobroRec.Rows.Count<=0)
            {
                MessageBox.Show("No se encontraton registros con los parametros especificados para el reporte.", "Reporte de Recibos por Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                paramlist.Add(new ReportParameter("idConcep", idConcep, false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsConRecibos", dtCobroRec));
                string reportpath = "RptCobroRec.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcSelec.Checked)
            {
                for (int i = 0; i < this.chklbConcep.Items.Count; i++)
                {
                    this.chklbConcep.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < this.chklbConcep.Items.Count; i++)
                {
                    this.chklbConcep.SetItemChecked(i, false);
                }
            }
        }
    }
}
