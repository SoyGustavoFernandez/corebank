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
using SPL.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace SPL.Presentacion
{
    public partial class frmRegistroFACTA : frmBase
    {
        public int idCli;
        clsCNClienteFACTA cnClienteFacta = new clsCNClienteFACTA();
        public frmRegistroFACTA()
        {
            InitializeComponent();
            btnSalir2.Enabled = false;
            btnImprimir1.Enabled = false;

        }

        private void frmRegistroFACTA_Load(object sender, EventArgs e)
        {
            
        }

        private void rbtnFactaNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnFactaNo.Checked)
            {
                rbtnResiUSSi.Enabled = false;
                rbtnResiUSNo.Enabled = false;
                rbtnResiUSNo.Checked = true;
            }
            else
	        {
                rbtnResiUSSi.Enabled = true;
                rbtnResiUSNo.Enabled = true;
                rbtnResiUSSi.Checked = false;
                rbtnResiUSNo.Checked = false;
	        }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!rbtnFactaNo.Checked && !rbtnFactaSi.Checked)
            {
                MessageBox.Show("Seleccione si el Cliente Afecto al Régimen FACTA", "Registro de Cliente Facta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!rbtnResiUSSi.Checked && !rbtnResiUSNo.Checked)
            {
                MessageBox.Show("Seleccione si el Cliente Declara ser USPERSON", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            DataTable dtResultado = cnClienteFacta.CNActualizarClienteNaturalFacta(idCli, rbtnFactaSi.Checked, rbtnResiUSSi.Checked);
            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grbBase1.Enabled = false;
                grbBase2.Enabled = false;
                btnImprimir1.Enabled = true;
                btnGrabar1.Enabled = false;
            }
            else
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string reportpath = "";
            if (rbtnResiUSSi.Checked)
                reportpath = "rptUSPerson.rdlc";
            else
                reportpath = "rptNonUSPerson.rdlc";

            
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            String AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsPerson", cnClienteFacta.CNObtenerClienteFactaPorIdCli(idCli)));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            btnSalir2.Enabled = true;

        }
    }
}
