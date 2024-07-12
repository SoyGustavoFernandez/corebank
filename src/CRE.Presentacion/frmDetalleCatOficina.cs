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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmDetalleCatOficina : frmBase
    {
        public frmDetalleCatOficina()
        {
            InitializeComponent();
        }
        #region variables Globales

        clsCNCategoriaOficina cnCategoriaOfi = new clsCNCategoriaOficina();
        clsCNAgencia cnAgencia = new clsCNAgencia();

        DataTable dtAgencias = new DataTable();
        DataTable dtCatOficinas = new DataTable();
        DataTable dtModoCat = new DataTable();
        DataTable dtGrupoOfi = new DataTable();
        DataTable dtCategoria = new DataTable();

        #endregion

        #region Eventos
        private void frmDetalleCatOficina_Load(object sender, EventArgs e)
        {

            this.dtpDesde.Format = DateTimePickerFormat.Custom;
            this.dtpDesde.CustomFormat = "MMMM/yyyy";
            this.dtpDesde.ShowUpDown = true;

            this.dtpHasta.Format = DateTimePickerFormat.Custom;
            this.dtpHasta.CustomFormat = "MMMM/yyyy";
            this.dtpHasta.ShowUpDown = true;

            this.dtModoCat.Columns.Clear();
            this.dtModoCat.Columns.Add("nModo", typeof(int));
            this.dtModoCat.Columns.Add("cNombre", typeof(string));
            this.dtModoCat.Rows.Add(0, "Histórico Automático");
            this.dtModoCat.Rows.Add(1, "Histórico Manual y Automático");

            this.dtGrupoOfi = cnCategoriaOfi.obtenerGrupoOfi();
            this.dtGrupoOfi.Rows.Add(0, "TODOS");
            this.dtCategoria = cnCategoriaOfi.obtenerCategoriaOfi();
            this.dtCategoria.Rows.Add(0, "TODOS");
            this.dtAgencias = cnAgencia.LisSoloAgencias();

            this.cboModo.DataSource = this.dtModoCat;
            this.cboModo.ValueMember = this.dtModoCat.Columns[0].ToString();
            this.cboModo.DisplayMember = this.dtModoCat.Columns[1].ToString(); ;
            this.cboModo.SelectedValue = 0;

            this.dtpDesde.ValueChanged -= this.dtpDesde_ValueChanged;
            this.dtpDesde.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            this.dtpDesde.ValueChanged += this.dtpDesde_ValueChanged;

            this.dtpHasta.ValueChanged -= this.dtpHasta_ValueChanged;
            this.dtpHasta.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            this.dtpHasta.ValueChanged += this.dtpHasta_ValueChanged;

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            List<int> aListaAgencias = new List<int>();

            DateTime dFechaDesde = dtpDesde.Value.Date;
            DateTime dFechaHasta = new DateTime(dtpHasta.Value.Year, dtpHasta.Value.Month, DateTime.DaysInMonth(dtpHasta.Value.Year, dtpHasta.Value.Month)).Date;

            int nModoCat = Convert.ToInt32(cboModo.SelectedValue);

            string cNomAgen = clsVarGlobal.cNomAge.ToString();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            string reportpath = "";

            if (nModoCat == 0)
            {
                this.dtCatOficinas = cnCategoriaOfi.obtenerCategorizacionOfiAut(dFechaDesde.Date, dFechaHasta.Date);
                reportpath = "rptHistCategorizacionAutOfi.rdlc";
            }
            else
            {
                this.dtCatOficinas = cnCategoriaOfi.obtenerCategorizacionOfi(dFechaDesde.Date, dFechaHasta.Date);
                reportpath = "rptHistCategorizacionOfi.rdlc";
            }

            if (this.dtCatOficinas.Rows.Count == 0)
            {
                MessageBox.Show("El reporte no contiene ningun dato para mostrar. Revisar los parametros.", "Reporte Historico de Categorizacion de Oficinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtslist.Add(new ReportDataSource("dtsHistCatOfi", dtCatOficinas));
            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

            
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.Normal);
            frmreporte.ShowDialog();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            DateTime dInicio = dtpDesde.Value;
            dtpDesde.Value = new DateTime(dInicio.Year, dInicio.Month, 1);
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            DateTime dFinal = dtpHasta.Value;
            dtpHasta.Value = new DateTime(dFinal.Year, dFinal.Month, 1);
        }

        #endregion

        #region Metodos

        private bool Validar()
        {
            if( dtpDesde.Value > new DateTime(dtpHasta.Value.Year, dtpHasta.Value.Month, DateTime.DaysInMonth(dtpHasta.Value.Year, dtpHasta.Value.Month)))
            {
                MessageBox.Show("La Fecha de Fin del Reporte debe ser mayor a la fecha de Inicio", "Reporte Historico de Categorizacion de Oficinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (this.cboModo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el Modo del Reporte", "Reporte Histórico de Categorizacion de Oficinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        #endregion





    }
}

