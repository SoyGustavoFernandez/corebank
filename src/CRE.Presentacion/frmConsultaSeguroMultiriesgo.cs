using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmConsultaSeguroMultiriesgo : frmBase
    {
        private DateTime dFechaSistema;
        private readonly string TituloForm = "Consulta Seguro Multiriesgo";
        private clsCNCreditoCargaSeguro _cnCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        public frmConsultaSeguroMultiriesgo()
        {
            InitializeComponent();
        }

        private void frmConsultaSeguroMultiriesgo_Load(object sender, EventArgs e)
        {
            dFechaSistema = clsVarGlobal.dFecSystem;
            cboZona.AgregarTodos();
            cboEstadoSeguroMultiriesgo.AgregarTodos();
            LimpiarTodo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void LimpiarTodo()
        {
            dtpFechaDesde.Value = dFechaSistema.Date;
            dtpFechaHasta.Value = dFechaSistema.Date;

            cboZona.SelectedIndexChanged -= cboZona_SelectedIndexChanged;
            cboAgencias.SelectedIndexChanged -= cboAgencias_SelectedIndexChanged;

            cboZona.SelectedIndex = -1;
            cboAgencias.SelectedIndex = -1;
            cboAsesor.SelectedIndex = -1;

            cboAgencias.Enabled = false;
            cboAsesor.Enabled = false;

            cboZona.SelectedIndexChanged += cboZona_SelectedIndexChanged;
            cboAgencias.SelectedIndexChanged += cboAgencias_SelectedIndexChanged;

            cboEstadoSeguroMultiriesgo.SelectedIndex = -1;
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idZona = Convert.ToInt32(cboZona.SelectedValue);

            cboAgencias.SelectedIndexChanged -= cboAgencias_SelectedIndexChanged;
            cboAgencias.FiltrarPorZonaTodos(idZona);
            cboAgencias.SelectedIndex = -1;
            cboAgencias.Enabled = true;
            cboAgencias.SelectedIndexChanged += cboAgencias_SelectedIndexChanged;

            cboAsesor.Enabled = false;
            cboAsesor.SelectedIndex = -1;
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            cboAsesor.ListarPersonalCompleto(idAgencia, true);
            cboAsesor.Enabled = true;
        }

        private void Imprimir()
        {
            if (!ValidarParaImprimir())
                return;

            DateTime dFechaDesde = dtpFechaDesde.Value.Date;
            DateTime dFechaHasta = dtpFechaHasta.Value.Date;
            int idZona = Convert.ToInt32(cboZona.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idAsesor = Convert.ToInt32(cboAsesor.SelectedValue);
            int idEstadoSeguroMultiriesgo = Convert.ToInt32(cboEstadoSeguroMultiriesgo.SelectedValue);

            DataTable dtInformacion = _cnCreditoCargaSeguro.CNConsultaSeguroMultiriesgo(dFechaDesde, dFechaHasta, idZona, idAgencia, idAsesor, idEstadoSeguroMultiriesgo);

            if (dtInformacion.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para la busqueda.", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Imprimir

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false));

            dtslist.Add(new ReportDataSource("dtsInformacion", dtInformacion));

            string reportpath = "rptConsultaSeguroMultiriesgo.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.ShowDialog();
        }

        private bool ValidarParaImprimir()
        {
            DateTime dFechaDesde = dtpFechaDesde.Value.Date;
            DateTime dFechaHasta = dtpFechaHasta.Value.Date;
            int idZona = Convert.ToInt32(cboZona.SelectedIndex);
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedIndex);
            int idAsesor = Convert.ToInt32(cboAsesor.SelectedIndex);
            int idEstadoSeguroMultiriesgo = Convert.ToInt32(cboEstadoSeguroMultiriesgo.SelectedIndex);

            if (dFechaDesde > dFechaHasta)
            {
                MessageBox.Show("Ingrese un rango de fechas correcto", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (idZona < 0)
            {
                MessageBox.Show("Seleccione una zona", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (idAgencia < 0)
            {
                MessageBox.Show("Seleccione una agencia", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (idAsesor < 0)
            {
                MessageBox.Show("Seleccione un asesor", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (idEstadoSeguroMultiriesgo < 0)
            {
                MessageBox.Show("Seleccione un estado", TituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        

    }
}
