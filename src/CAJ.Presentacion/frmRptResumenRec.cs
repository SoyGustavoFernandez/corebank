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
    public partial class frmRptResumenRec : frmBase
    {
        public frmRptResumenRec()
        {
            InitializeComponent();
            cboAgencias.AgenciasYTodos();
        }

        private void frmRptResumenRec_Load(object sender, EventArgs e)
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
            if (this.cboAgencias.SelectedIndex >= 0)
            {
                
                this.cboAgencias.SelectedValue = 1;
                this.cboAgencias.Select();
            }
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
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
            DataTable tbConcep = LisConcep.ListaConceptos(nTipRec,"");
            this.chklbConcep.DataSource = tbConcep;
            this.chklbConcep.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            this.chklbConcep.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
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
                MessageBox.Show("Seleccione el(los) Concepto(s) a visualizar", "Detalle de recibos por agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string dFecIni = this.dtpFecIni.Value.ToShortDateString();
            string dFecFin = this.dtpFecFin.Value.ToShortDateString();
            string idAge = this.cboAgencias.SelectedValue.ToString();
            int idMon =Convert.ToInt32(cboMoneda.SelectedValue);
            string cTipRec = this.cboTipRec.SelectedValue.ToString();
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            DataTable dtResumenRec = new clsRPTCNCaja().CNRptResumenRec(Convert.ToInt32(idAge), Convert.ToDateTime(dFecIni), Convert.ToDateTime(dFecFin), Convert.ToInt32(cTipRec), idConcep,idMon);
            if (dtResumenRec.Rows.Count<=0)
            {
                MessageBox.Show("No se encontraron registros con los parametros \n especificados para el reporte.", "Detalle de recibos por agencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("idAge", idAge, false));
                paramlist.Add(new ReportParameter("dFecIni", dFecIni, false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin, false));
                paramlist.Add(new ReportParameter("idConcep", idConcep, false));
                paramlist.Add(new ReportParameter("cTipRec", cTipRec, false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsConRecibos", dtResumenRec));
                string reportpath = "RptResumenRec.rdlc";
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
