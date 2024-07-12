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
using Microsoft.Reporting.WinForms;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptCreditosConGarantias : frmBase
    {
        #region Variable Globales

        clsCNGarantia cngarantia = new clsCNGarantia();

        #endregion

        public frmRptCreditosConGarantias()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            this.cboTipoCredito.CargarProducto(1);
            cboMoneda1.MonedasYTodos();
            cboAgencias1.AgenciasYTodos();
            cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
        }

        private void cboProducto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                this.cboSubTipoCredito.CargarProducto(Convert.ToInt32(cboTipoCredito.SelectedValue));
                this.cboSubTipoCredito.SelectedIndex = 1;
            }
            else
            {
                this.cboSubTipoCredito.CargarProducto(-1);
            }
        }

        private void cboProducto2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                this.cboTipoProducto.CargarProducto(Convert.ToInt32(cboSubTipoCredito.SelectedValue));
                this.cboTipoProducto.SelectedIndex = 1;
            }
            else
            {
                this.cboTipoProducto.CargarProducto(-1);
            }
        }

        private void cboProducto3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoProducto.SelectedIndex > 0)
            {
                this.cboSubProducto.ProductosYTodos(Convert.ToInt32(cboTipoProducto.SelectedValue));
                this.cboSubProducto.SelectedIndex = 1;
            }
            else
            {
                this.cboTipoProducto.CargarProducto(-1);
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
                var idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
                var idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
                var idAsesor = Convert.ToInt32(cboPersonalCreditos1.SelectedValue);

                DataTable dsCreGarantias = cngarantia.CNrptCreditosConGarantia(idProducto, idMoneda, idAgencia, idAsesor);

                if (dsCreGarantias.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para los parámetros seleccionados", "Validación de reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                dtslist.Add(new ReportDataSource("dsCreGarantias", dsCreGarantias));

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("idProducto", idProducto.ToString(), false));
                paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
                paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("idAsesor", idAsesor.ToString(), false));

                string reportpath = "rptCreditosConGarantia.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lVal = false;

            if (this.cboSubProducto.SelectedIndex<0)
            {
                MessageBox.Show("Por favor seleccione un producto de crédito", "Validación de reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoCredito.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

            
        #endregion

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias1.SelectedIndex > -1)
            {
                cboPersonalCreditos1.ListarPersonal(Convert.ToInt32(cboAgencias1.SelectedValue));
            }
        }

        
    }
}
