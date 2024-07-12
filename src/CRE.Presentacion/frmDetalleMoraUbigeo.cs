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
using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmDetalleMoraUbigeo : frmBase
    {
        
        public frmDetalleMoraUbigeo()
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
                int idTipDir = Convert.ToInt32(cboTipoDireccion.SelectedValue);
                int idUbigeo = Convert.ToInt32(conBusUbig1.cboDistrito.SelectedValue);
                int idTipInter = Convert.ToInt32(cboTipoIntervCre1.SelectedValue);
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dtsDetalleMora", new clsRPTCNCredito().CNMoraUbigeo(Convert.ToInt32(txtAtrIni.Text), Convert.ToInt32(txtAtrFin.Text), Convert.ToDecimal(txtMonIni.Text), Convert.ToDecimal(txtMonFin.Text), CodAna, idTipDir, idUbigeo, idTipInter)));
                dtslist.Add(new ReportDataSource("dtsInterviniente", new clsRPTCNCredito().CNIntervMoraUbigeo(Convert.ToInt32(txtAtrIni.Text), Convert.ToInt32(txtAtrFin.Text), Convert.ToDecimal(txtMonIni.Text), Convert.ToDecimal(txtMonFin.Text), CodAna, idTipDir, idUbigeo, idTipInter)));
            
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

        private void frmDetalleMoraUbigeo_Load(object sender, EventArgs e)
        {
            clsCNTipoDireccion objTipDir = new clsCNTipoDireccion();
            DataTable dtbTipDir = objTipDir.ListaTipDireccion();

            cboTipoDireccion.DataSource = dtbTipDir;
            cboTipoDireccion.DisplayMember = dtbTipDir.Columns["cTipoDir"].ToString();
            cboTipoDireccion.ValueMember = dtbTipDir.Columns["idTipoDireccion"].ToString();
            conBusUbig1.cargar();
            conBusUbig1.cboPais.SelectedValue = 173;
            conBusUbig1.cboDepartamento.SelectedValue = 1632;
            conBusUbig1.cboProvincia.SelectedValue = 1633;
        }
    }
}
