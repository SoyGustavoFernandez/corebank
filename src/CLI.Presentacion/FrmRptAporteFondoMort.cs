using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
namespace CLI.Presentacion
{
    public partial class FrmRptAporteFondoMort : frmBase
    {
        clsCNSocio cnsocio = new clsCNSocio();
        clsSocio objsocio = null;
        DataTable dtDetAporte;
        DataTable dtDetAporteKardex;
        DataTable dtDetFondoMort;
        DataTable dtDetFondoMortKardex;
        public FrmRptAporteFondoMort()
        {
            InitializeComponent();
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {

            if (conBusCli1.idCli == 0)
            {
                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.txtCodCli.Focus();
                dtgAportes.DataSource = null;
                dtgDetalleFondo.DataSource = null;
                return;
            }
            objsocio = cnsocio.retornardatossocio(conBusCli1.idCli);
            if (objsocio == null)
            {

                 MessageBox.Show("Persona seleccionada no es un socio activo", "Validación Socio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 conBusCli1.txtCodCli.Enabled = true;
                 conBusCli1.txtCodCli.Focus();
                 dtgAportes.DataSource = null;
                 dtgDetalleFondo.DataSource = null;
                 dtgAportesKardx.DataSource = null;
                 dtgDetalleFondoKardx.DataSource = null;
                 return;
             }
             else
             {
                dtgAportes.DataSource = null;
                dtDetAporte = cnsocio.retornarAportesXSocio(conBusCli1.idCli);
                dtgAportes.DataSource = dtDetAporte;
                dtgAportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
                
                dtgAportesKardx.DataSource = null;
                dtDetAporteKardex = cnsocio.retornarAportesXSocioKardex(conBusCli1.idCli);
                dtgAportesKardx.DataSource = dtDetAporteKardex;
                dtgAportesKardx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
               
                dtgDetalleFondo.DataSource = null;
                dtDetFondoMort= cnsocio.retornarFondoMortXSocio(conBusCli1.idCli);
                dtgDetalleFondo.DataSource = dtDetFondoMort;
                dtgDetalleFondo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

                dtgDetalleFondoKardx.DataSource = null;
                dtDetFondoMortKardex = cnsocio.retornarFondoMortXSocioKardex(conBusCli1.idCli);
                dtgDetalleFondoKardx.DataSource = dtDetFondoMortKardex;
                dtgDetalleFondoKardx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
                formatoGridAprt();
             }
           
        }

        private void formatoGridAprt()
        {
            dtgAportes.Columns["idDetAporte"].Visible = false;          
            dtgAportes.Columns["cPeriodo"].HeaderText = "Periodo";
            dtgAportes.Columns["dFecVenApo"].HeaderText = "Fech. Vence";
            dtgAportes.Columns["nMonApoPac"].HeaderText = "Por Pagar";
            dtgAportes.Columns["nMonApoPag"].HeaderText = "Monto Pago";
            dtgAportes.Columns["dFecPago"].HeaderText = "Fech. Pag";  
            dtgAportes.Columns["cTipoAPorte"].HeaderText = "Tip. Aporte";

            dtgAportesKardx.Columns["orden"].HeaderText = "Nº";
            dtgAportesKardx.Columns["fechOpe"].HeaderText = "Fech. Ope";
            dtgAportesKardx.Columns["montOpe"].HeaderText = "Mont. Ope";

            dtgDetalleFondo.Columns["idDetFondo"].Visible = false;
            dtgDetalleFondo.Columns["cTipoFondoSeguro"].HeaderText = "Tip. Seguro";
            dtgDetalleFondo.Columns["dFecPago"].HeaderText = "Fech. Pag";
            dtgDetalleFondo.Columns["cPeriodo"].HeaderText = "Periodo";
            dtgDetalleFondo.Columns["dFecVenApo"].HeaderText = "Fech. Vence";
            dtgDetalleFondo.Columns["nMontoPac"].HeaderText = "Por Pagar";
            dtgDetalleFondo.Columns["nMontoPag"].HeaderText = "Monto Pago";

            dtgDetalleFondoKardx.Columns["orden"].HeaderText = "Nº";
            dtgDetalleFondoKardx.Columns["fechOpe"].HeaderText = "Fech. Ope";
            dtgDetalleFondoKardx.Columns["montOpe"].HeaderText = "Mont. Ope";
            
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));       
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("cNombreVariable", "cRutaLogo", false));
            paramlist.Add(new ReportParameter("cNroDocumento", conBusCli1.txtNroDoc.Text, false));
            paramlist.Add(new ReportParameter("cSocio", conBusCli1.txtNombre.Text, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsFondoMort",dtDetFondoMort));
            dtslist.Add(new ReportDataSource("dsFondoMortKardex", dtDetFondoMortKardex));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            string reportpath = "rptApFondoMortSociosKadex.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("cNombreVariable", "cRutaLogo", false));
            paramlist.Add(new ReportParameter("cNroDocumento", conBusCli1.txtNroDoc.Text, false));
            paramlist.Add(new ReportParameter("cSocio", conBusCli1.txtNombre.Text, false));
            
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsAportesXSocio", dtDetAporte));
            dtslist.Add(new ReportDataSource("dsAportesXSocioKardex", dtDetAporteKardex));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            string reportpath = "rptAportesSociosKadex.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
