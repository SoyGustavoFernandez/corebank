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
using GRH.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmDeclaracionParentesco : frmBase
    {
        Int32 nidClienteCol = 0;
        public frmDeclaracionParentesco()
        {
            InitializeComponent();
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            nidClienteCol = 0;
            if (conBusCol1.txtCod.Text.Trim() == "")
            {
                this.CleanData();
                MessageBox.Show("No se encontró registro", "Declaración Jurada de Parentesco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCol1.txtCod.Focus();
                return;
            }

            Int32 nidCliente = Convert.ToInt32(this.conBusCol1.idCliPer);
            nidClienteCol = nidCliente;
            //this.BuscaPersonal(nidCliente);
            conBusCol1.btnConsultar.Enabled = true;
            conBusCol1.txtCod.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hola" + nidClienteCol.ToString());

            /*if (nidClienteCol != 0)
            {
                
            }*/

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];


            DataTable dtRptDataTrabajador = new clsCNDeclaracionJurada().CNDatosTrabajador(nidClienteCol);

            if (dtRptDataTrabajador.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.idUsuario.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                DataTable dtRptDataPariente = new clsCNDeclaracionJurada().CNDatosPariente(nidClienteCol);
                DataTable dtRptDataFamiliares = new clsCNDeclaracionJurada().CNDatosFamiliares(nidClienteCol);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("DataSetPrincipal", dtRptDataTrabajador));
                dtslist.Add(new ReportDataSource("DataSetParientes", dtRptDataPariente));
                dtslist.Add(new ReportDataSource("DataSetFamiliares", dtRptDataFamiliares));

                string reportpath = "rptDeclaracionJuradaParentesco.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Declaración Jurada de Parentesco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanData();
            
            this.conBusCol1.txtCod.Clear();
            this.conBusCol1.txtNom.Clear();
            this.conBusCol1.txtCargo.Clear();

            this.conBusCol1.txtCod.Enabled = true;
            this.conBusCol1.txtCod.Focus();
            this.conBusCol1.btnConsultar.Enabled = true;
                        
            this.btnCancelar.Enabled = false;
            //this.btnGrabar.Enabled = false;
        }

        private void CleanData()
        {
            /*this.cboTipoHorario1.SelectedIndex = -1;
            this.dtpFecInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.CBIndicarFecha.Checked = false;*/
        }
    }
}
