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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmRptOpinionRefina : frmBase
    {
        #region Variable Globales

        clsCNSolicitudAmortiza cnsolicitudamortiza = new clsCNSolicitudAmortiza();

        #endregion

        public frmRptOpinionRefina()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarSolRefina();
        }

        private void dtgSolRefina_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatosSol();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgSolRefina.SelectedRows.Count > 0)
            {
                string reportpath = "rptOpinionRefinanciacion.rdlc";
                var idSolicitud = (int)dtgSolRefina.SelectedRows[0].Cells["idSolicitud"].Value;
                List<ReportDataSource> lisData = new List<ReportDataSource>();
                List<ReportParameter> lisParametros = new List<ReportParameter>();

                lisParametros.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                lisParametros.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                lisParametros.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                lisParametros.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));

                lisData.Add(new ReportDataSource("dsOpinion", cnsolicitudamortiza.CNrptOpinionRefinanciacion(idSolicitud)));
                new frmReporteLocal(lisData, reportpath, lisParametros).ShowDialog();
            }
        }

        #endregion

        #region Métodos

        private void cargarSolRefina()
        {
            var dtSoliRefina = cnsolicitudamortiza.CNlistaOpinionRefinaXUsuarios(clsVarGlobal.User.idUsuario);
            if (dtSoliRefina.Rows.Count > 0)
            {
                dtgSolRefina.DataSource = dtSoliRefina;
                formatoGrid();
                cargarDatosSol();
            }
        }

        private void cargarDatosSol()
        {
            if (dtgSolRefina.SelectedRows.Count > 0)
            {
                var drSol = dtgSolRefina.SelectedRows[0];

                txtAntecedentes.Text = drSol.Cells["cAntecedentes"].Value.ToString();
                txtConclusion.Text = drSol.Cells["cConclusion"].Value.ToString();
                txtGestiones.Text = drSol.Cells["cGestiones"].Value.ToString();
                txtMotivoMora.Text = drSol.Cells["cMotivoMora"].Value.ToString();
                rbtSI.Checked = (bool)drSol.Cells["lMuestraVoluntad"].Value;
            }
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgSolRefina.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgSolRefina.Columns["idSolicitud"].Visible = true;
            dtgSolRefina.Columns["cNombre"].Visible = true;
            dtgSolRefina.Columns["nCapitalSolicitado"].Visible = true;
            dtgSolRefina.Columns["cMoneda"].Visible = true;
            dtgSolRefina.Columns["dFechaReg"].Visible = true;

            dtgSolRefina.Columns["idSolicitud"].HeaderText = "Cod.Sol.";
            dtgSolRefina.Columns["cNombre"].HeaderText = "Nombres";
            dtgSolRefina.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgSolRefina.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolRefina.Columns["dFechaReg"].HeaderText = "Fec.Reg.";

            dtgSolRefina.Columns["idSolicitud"].Width = 60;
            dtgSolRefina.Columns["nCapitalSolicitado"].Width = 70;
            dtgSolRefina.Columns["cMoneda"].Width = 90;
            dtgSolRefina.Columns["dFechaReg"].Width = 70;
            
        }

        #endregion

       
    }
}
