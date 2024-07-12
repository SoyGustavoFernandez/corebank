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
    public partial class frmImpresionLomosExpediente : frmBase
    {
        #region Variable Globales
        clsCNControlExp cnControlExp = new clsCNControlExp();
        DataTable dtTipoOpeExp;
        string cTitulo = "Impresión de lomos de expedientes";
        #endregion

        public frmImpresionLomosExpediente()
        {
            InitializeComponent();
            dtTipoOpeExp = cnControlExp.CNListaTipoExpediente();
            DataTable dt = cnControlExp.CNClienteParaImpresionLomoExpediente(0);
            foreach (DataColumn column in dt.Columns)
            {
                column.ReadOnly = false;
            }
            
            dtgClientesParaImpresion.DataSource = dt;
            formatoGrid();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Agregar al cliente para la impresión de lomos?", cTitulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resultado == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(conBusCli1.txtCodCli.Text)) 
                {
                    DataTable dtRpt = cnControlExp.CNClienteParaImpresionLomoExpediente(Convert.ToInt32(conBusCli1.txtCodCli.Text));
                    if (dtRpt.Rows.Count == 0)
                    {
                        MessageBox.Show("El cliente no tiene expedientes registrados", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conBusCli1.limpiarControles();
                        conBusCli1.txtCodCli.Enabled = true;
                        conBusCli1.txtCodCli.Focus();
                        return;
                    }
                    DataTable dtGrid = ((DataTable)dtgClientesParaImpresion.DataSource);
                    foreach (DataRow item in dtRpt.Rows)
                    {
                        dtGrid.ImportRow(item);
                    }
                    formatoGrid();
                }
                
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;


            return lValida;
        }

        private void formatoGrid()
        {
            
            dtgClientesParaImpresion.Columns["cCodCliente"].Visible = false;
            dtgClientesParaImpresion.Columns["cChar"].Visible = false;
            dtgClientesParaImpresion.Columns["cCodigoBarras"].Visible = false;
            dtgClientesParaImpresion.Columns["idCli"].Visible = false;

            dtgClientesParaImpresion.Columns["lSel"].HeaderText = " ";
            dtgClientesParaImpresion.Columns["cNombre"].HeaderText = "Cliente";
            dtgClientesParaImpresion.Columns["idExpediente"].HeaderText = "Cod. Expediente";
            dtgClientesParaImpresion.Columns["cDescripcion"].HeaderText = "Tipo Expediente";

            if(dtgClientesParaImpresion.RowCount>0)
                dtgClientesParaImpresion.Columns["lSel"].Width = 40;
        }

        private void limpiar()
        {
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Focus();
            if (dtgClientesParaImpresion.DataSource != null)
                ((DataTable)dtgClientesParaImpresion.DataSource).Clear();
        }

        #endregion

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgClientesParaImpresion.RowCount == 0)
            {
                MessageBox.Show("No hay Clientes para imprimir lomos", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtTemp = ((DataTable)dtgClientesParaImpresion.DataSource);
            DataTable dtImprimir = dtTemp.Clone();

            foreach (DataRow item in dtTemp.Rows)
            {
                if (Convert.ToBoolean(item["lSel"]))
                {
                    dtImprimir.ImportRow(item);
                }
            }

            clsCodigoBarra Funcion = new clsCodigoBarra();
            dtImprimir.Columns["cCodigoBarras"].ReadOnly = false;
            foreach (DataRow item in dtImprimir.Rows)
            {
                item["cCodigoBarras"] = Funcion.Convert(Convert.ToString(item["idCli"]), 520, 150);
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsImpresionDeLomosExp", dtImprimir));
            string reportpath = "rptImpresionLomosExpedientes.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Focus();
            conBusCli1.txtCodCli.Enabled = true;
        }

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dtgClientesParaImpresion.DataSource);
            foreach (DataRow item in dt.Rows)
            {
                item["lSel"] = chcBase1.Checked;
            }


        }

        private void dtgClientesParaImpresion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataTable)dtgClientesParaImpresion.DataSource).Rows[e.RowIndex]["lSel"] = !Convert.ToBoolean(((DataTable)dtgClientesParaImpresion.DataSource).Rows[e.RowIndex]["lSel"]);

        }
    }
}
