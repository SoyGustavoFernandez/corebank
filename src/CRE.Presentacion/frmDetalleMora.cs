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
using EntityLayer;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmDetalleMora : frmBase
    {
        
        public frmDetalleMora()
        {
            InitializeComponent();
            txtAtrIni.Text = "-9999";
            txtAtrFin.Text = "9999";
            txtMonIni.Text = "0";
            txtMonFin.Text = "9999";
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                String CodAna = "";

                foreach (DataRowView item in chklAsesores.CheckedItems)
                {
                    CodAna += (item.Row["idUsuario"] + ",");
                }

                if (string.IsNullOrEmpty(CodAna))
                {
                    MessageBox.Show("Debe seleccionar por lo menos un asesor");
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsDetalleMora", new clsRPTCNCredito().CNMora(Convert.ToInt32(txtAtrIni.Text), Convert.ToInt32(txtAtrFin.Text), Convert.ToDecimal(txtMonIni.Text), Convert.ToDecimal(txtMonFin.Text), CodAna)));
                dtslist.Add(new ReportDataSource("dtsInterviniente", new clsRPTCNCredito().CNIntervMora(Convert.ToInt32(txtAtrIni.Text), Convert.ToInt32(txtAtrFin.Text), Convert.ToDecimal(txtMonIni.Text), Convert.ToDecimal(txtMonFin.Text), CodAna)));
            
                paramlist.Add(new ReportParameter("dFecha", clsVarGlobal.dFecSystem.ToString(), false));

                string reportpath = "RptMoraDiaria.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }

        }
        Boolean validar()
        {
            Boolean lProcesa = true;
            if (Convert.ToDecimal(txtMonFin.Text) < Convert.ToDecimal(txtMonIni.Text))
            {
                MessageBox.Show("Monto Final debe ser que Monto Inicial");
                lProcesa = false;
                return lProcesa;
            }

            if (Convert.ToInt32(txtAtrFin.Text) < Convert.ToInt32(txtAtrIni.Text))
            {
                MessageBox.Show("Atraso Final debe ser que Atraso Inicial");
                lProcesa = false;
                return lProcesa;
            }

            return lProcesa;
    }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            Boolean chSelec = true;
            chSelec = chcTodos.Checked;
            for (int i = 0; i < chklAsesores.Items.Count; ++i)
                chklAsesores.SetItemChecked(i, chSelec);
        }
    }
}
