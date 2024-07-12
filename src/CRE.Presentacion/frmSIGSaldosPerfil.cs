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
using clsUsuario = GEN.CapaNegocio.clsCNUsuario;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmSIGSaldosPerfil : frmBase
    {
        int idAgenciaCbo = 0;
        public frmSIGSaldosPerfil()
        {
            InitializeComponent();
        }

        private void frmSIGSaldosPerfil_Load(object sender, EventArgs e)
        {

            cboZona1.cargarZona(true, false);
            cboPersonalCreditosJefeOficina.DropDownWidth = 250;
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            this.cboAgencias1.FiltrarPorZonaTodos(0);
            cboAgencias1.SelectedValue = idAgenciaCbo;

            int[] nPerilAsesor = new int[3];
            nPerilAsesor[0] = 34;
            nPerilAsesor[1] = 115;
            nPerilAsesor[2] = 118;

            if (clsVarGlobal.PerfilUsu.idPerfil == 75)//Gerente Regional
            {
                DataTable zona = new clsUsuario().ObtenerZonasUsuario(clsVarGlobal.PerfilUsu.idUsuario);
                cboZona1.SelectedValue = Convert.ToInt32(zona.Rows[0]["idZona"]);
                cboZona1.Enabled = false;
            }
            else if (clsVarGlobal.PerfilUsu.idPerfil == 85)//Jefe de Oficina
            {
                lblZona.Visible = false;
                cboZona1.Visible = false;
                cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencias1.Enabled = false;
                this.cboPersonalCreditosJefeOficina.ListarPersonalCompleto(clsVarGlobal.nIdAgencia, true);
            }
            else if (clsVarGlobal.PerfilUsu.idPerfil.In(nPerilAsesor))//Asesor de Negocios
            {
                lblZona.Visible = false;
                cboZona1.Visible = false;
                cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencias1.Enabled = false;
                this.cboPersonalCreditosJefeOficina.ListarPersonalCompleto(clsVarGlobal.nIdAgencia, true);
                cboPersonalCreditosJefeOficina.SelectedValue = clsVarGlobal.User.idUsuario;
                cboPersonalCreditosJefeOficina.Enabled = false;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtRpt;
            clsRPTCNCredito cnCredito = new clsRPTCNCredito();
            DateTime dFechaSel = dtpFecha.Value.Date;
            int idAgencia = 0;
            int idZona = 0;
            int idUsuario = 0;

            if (!validar())
                return;

            idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            idZona = Convert.ToInt32(cboZona1.SelectedValue);
            idUsuario = Convert.ToInt32(cboPersonalCreditosJefeOficina.SelectedValue);

            dtRpt = cnCredito.CNRpt001Hist(dFechaSel, false, idAgencia, idZona, idUsuario);

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            dtsList.Add(new ReportDataSource("dsRpt", dtRpt));
            paramList.Add(new ReportParameter("cNomAgen", cboAgencias1.Text, false));
            paramList.Add(new ReportParameter("dFechaSis", dFechaSel.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("dFechaSel", dFechaSel.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            //paramList.Add(new ReportParameter("cUsuarios", ""));

            string reportPath = "rptSIGSaldoMoraCliente.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();

        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);
            cboAgencias1.SelectedValue = idAgenciaCbo;
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboPersonalCreditosJefeOficina.ListarPersonalCompleto(Convert.ToInt32(cboAgencias1.SelectedValue), true);
        }

        private bool validar()
        {
            if (dtpFecha.Value > (DateTime)clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha seleccionada no puede ser mayor a la fecha del sistema", "Sistema de Información Gerencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}
