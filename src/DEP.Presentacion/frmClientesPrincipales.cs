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
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace DEP.Presentacion
{
    public partial class frmClientesPrincipales : frmBase
    {
        public frmClientesPrincipales()
        {
            InitializeComponent();
        }

        private void frmClientesPrincipales_Load(object sender, EventArgs e)
        {
            dtpFechaCorte.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //Validaciones            
            if (dtpFechaCorte.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha corte seleccionada no puede ser mayor que la fecha del sistema", "Validación de listado de clientes principales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (string.IsNullOrEmpty(txtCBNumTop.Text))
            {
                MessageBox.Show("Ingrese el valor del número de clientes principales a mostrar","Validación de listado de clientes principales", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(txtCBNumTop.Text)==0)
            {
                MessageBox.Show("El valor del número de clientes principales a mostrar no puede ser cero(0)...", "Validación de listado de clientes principales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (rbtFecha.Checked)
            {
                if (dtpFechaCorte.Value == clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("La información que a continuación se mostrará es referencial, los datos pueden cambiar durante el día", "Validación de listado de clientes principales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }   
            }
            else
            {
                if (dtpFechaCorte.Value == clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("Para sacar datos del histórico, debe seleccionar como máximo el día anterio a la fecha del sistema", "Validación de listado de clientes principales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }            

            //Impresion del reporte
            string cNomAgencia = clsVarApl.dicVarGen["cNomEmpresa"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem;            
            DateTime dFechaCorte = dtpFechaCorte.Value;            
            int nTop = Convert.ToInt32(txtCBNumTop.Text.Trim());
            DataTable dtListado = new clsRPTCNDeposito().CNListadoCliPrin(dFechaCorte, nTop);
            if (dtListado.Rows.Count<=0)
            {
                MessageBox.Show("No existen datos, para la fecha seleccionada", "Validación de listado de clientes principales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("dFechaCorte", dFechaCorte.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("nTop", nTop.ToString(), false));            
            paramlist.Add(new ReportParameter("x_AgenEmision", cNomAgencia, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsTopTen", dtListado));            
            string reportpath = "RptClienteTopTen.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
        }

        private void rbtBase1_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaCorte.Value = clsVarGlobal.dFecSystem;
            dtpFechaCorte.MaxDate = clsVarGlobal.dFecSystem;
            dtpFechaCorte.Enabled = false;
        }

        private void rbtHistorico_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaCorte.Value = clsVarGlobal.dFecSystem.AddDays(-1);
            dtpFechaCorte.MaxDate = clsVarGlobal.dFecSystem;
            dtpFechaCorte.Enabled = true;
            dtpFechaCorte.Focus();
        }
    }
}
