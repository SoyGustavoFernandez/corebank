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
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;

using clsUsuario = GEN.CapaNegocio.clsCNUsuario;

namespace RCP.Presentacion
{
    public partial class frmRptRecuperacionPrestamo : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();

        int idAgenciaCbo = 0;

        public frmRptRecuperacionPrestamo()
        {
            InitializeComponent();
            dtpFechaIni.ValueChanged -= dtpFechaIni_ValueChanged;
            dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            cboAgencias1.SelectedValueChanged -= cboAgencias1_SelectedValueChanged;
        }

        private void frmRptRecuperacionPrestamo_Load(object sender, EventArgs e)
        {
            

            dtpFecha.MaxDate = Convert.ToDateTime(clsVarGlobal.dFecSystem);
            dtpFechaIni.MaxDate = Convert.ToDateTime(clsVarGlobal.dFecSystem);
            //dtpFecha.MinDate = Convert.ToDateTime("01-" + clsVarGlobal.dFecSystem.Month + "-" + clsVarGlobal.dFecSystem.Year);

            dtpFechaIni.Value = Convert.ToDateTime("01-" + clsVarGlobal.dFecSystem.Month + "-" + clsVarGlobal.dFecSystem.Year);

            cboZona1.cargarZona(true, false);
            cboPersonalCreditosJefeOficina.DropDownWidth = 250;

            if (clsVarGlobal.PerfilUsu.idPerfil == 75)//Gerente Regional
            {
                DataTable zona = new clsUsuario().ObtenerZonasUsuario(clsVarGlobal.PerfilUsu.idUsuario);
                cboZona1.SelectedValue = Convert.ToInt32(zona.Rows[0]["idZona"]);
                cboZona1.Enabled = false;
                actualizarUsuariosConCartera();
            }
            else if (clsVarGlobal.PerfilUsu.idPerfil == 85)//Jefe de Oficina
            {
                lblZona.Visible = false;
                cboZona1.Visible = false;
                cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencias1.Enabled = false;
                actualizarUsuariosConCartera();
            }
            else if (clsVarGlobal.PerfilUsu.idPerfil == 34)//Asesor de Negocios
            {
                lblZona.Visible = false;
                cboZona1.Visible = false;
                cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencias1.Enabled = false;
                actualizarUsuariosConCartera();
                cboPersonalCreditosJefeOficina.SelectedValue = clsVarGlobal.User.idUsuario;
                cboPersonalCreditosJefeOficina.Enabled = false;
            }
            else
            {
                actualizarUsuariosConCartera();
            }

            dtpFechaIni.ValueChanged += dtpFechaIni_ValueChanged;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            cboAgencias1.SelectedValueChanged += cboAgencias1_SelectedValueChanged;
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
            this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);
            cboAgencias1.SelectedValue = idAgenciaCbo;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if( dtpFechaIni.Value.Day > dtpFecha.Value.Day || dtpFechaIni.Value.Month != dtpFecha.Value.Month || dtpFechaIni.Value.Year != dtpFecha.Value.Year )
            {
                MessageBox.Show("El rango de Fechas No es Válida..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                actualizarFechasEvento();
                actualizarUsuariosConCartera();
                return;
            }

            DataTable dts = cnReportes.rptRecuperacionesPrestamos(
                Convert.ToDateTime(dtpFechaIni.Text),
                Convert.ToDateTime(dtpFecha.Text),
                Convert.ToInt32(cboZona1.SelectedValue),
                Convert.ToInt32(cboAgencias1.SelectedValue),
                Convert.ToInt32(cboPersonalCreditosJefeOficina.SelectedValue)
                );

            if (dts.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomUser", cboPersonalCreditosJefeOficina.Text, false));
                paramlist.Add(new ReportParameter("cAgencia", cboAgencias1.Text, false));
                paramlist.Add(new ReportParameter("dFechaIni", dtpFechaIni.Text, false));
                paramlist.Add(new ReportParameter("dFecha", dtpFecha.Text, false));
                
                dtslist.Add(new ReportDataSource("dts", dts));

                string reportpath = "rptRecuperacionPrestamo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el reporte", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void actualizarFechasEvento()
        {
            int nDias = System.DateTime.DaysInMonth(Convert.ToDateTime(dtpFechaIni.Value).Year, Convert.ToDateTime(dtpFechaIni.Value).Month);
            DateTime max = Convert.ToDateTime(dtpFechaIni.Value.Year + "-" + dtpFechaIni.Value.Month + "-" + nDias);

            if (clsVarGlobal.dFecSystem.Month == dtpFechaIni.Value.Month && clsVarGlobal.dFecSystem.Year == dtpFechaIni.Value.Year)
                max = Convert.ToDateTime(clsVarGlobal.dFecSystem);

            if (max < dtpFecha.MaxDate)
            {
                dtpFecha.MinDate = Convert.ToDateTime(dtpFechaIni.Value);
                dtpFecha.MaxDate = Convert.ToDateTime(max);
            }
            else
            {
                dtpFecha.MaxDate = Convert.ToDateTime(max);
                dtpFecha.MinDate = Convert.ToDateTime(dtpFechaIni.Value);
            }
            dtpFecha.Value = max;
        }

        private void actualizarUsuariosConCartera()
        {
            if (clsVarGlobal.PerfilUsu.idPerfil != 34)
                this.cboPersonalCreditosJefeOficina.ListarUsuarioConCartera(
                    dtpFechaIni.Value,
                    dtpFecha.Value,
                    Convert.ToInt32(cboZona1.SelectedValue),
                    Convert.ToInt32(cboAgencias1.SelectedValue), true);
        }

        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            actualizarUsuariosConCartera();
            actualizarFechasEvento();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            actualizarUsuariosConCartera();
        }

        private void cboAgencias1_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarUsuariosConCartera();
        }

    }
}
