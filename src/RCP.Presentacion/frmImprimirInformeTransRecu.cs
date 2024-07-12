using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmImprimirInformeTransRecu : frmBase
    {
        clsCNSolicitudRecuperacion cnSolicitud = new clsCNSolicitudRecuperacion();
        clsCNTranferencias cnTranferencias = new clsCNTranferencias();
        public frmImprimirInformeTransRecu()
        {
            InitializeComponent();
        }

        private void frmImprimirInformeTransRecu_Load(object sender, EventArgs e)
        {
            conBusCli1.ClicBuscar += conBusCli1_ClicBuscar;
            conBusCli1.txtCodCli.Focus();
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            //MessageBox.Show("" + conBusCli1.idCli);
            cargarCreditos();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
        }

        private void cargarCreditos()
        {
            var dtCreditos = cnSolicitud.LisCreRecuperaxCli(conBusCli1.idCli);
            if (dtCreditos.Rows.Count > 0)
            {
                dtgCreditos.DataSource = dtCreditos;
                formatoGridCreditos();
                dtgCreditos.Rows[0].Selected = true;                
            }
        }

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn columna in dtgCreditos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }

            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditos.Columns["cEstado"].Visible = true;
            dtgCreditos.Columns["nAtraso"].Visible = true;
            dtgCreditos.Columns["nSalTot"].Visible = true;
            dtgCreditos.Columns["nProvisionSoles"].Visible = true;
            dtgCreditos.Columns["cProducto"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha Des.";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditos.Columns["nSalTot"].HeaderText = "Saldo Total";
            dtgCreditos.Columns["nProvisionSoles"].HeaderText = "Prov. Soles";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";

            
            Font font = new Font(dtgCreditos.DefaultCellStyle.Font.FontFamily, dtgCreditos.DefaultCellStyle.Font.Size, FontStyle.Bold);

            dtgCreditos.Columns["idCuenta"].DefaultCellStyle.Font = font;
            dtgCreditos.Columns["nAtraso"].DefaultCellStyle.Font = font;

            dtgCreditos.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCreditos.Columns["nProvisionSoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nProvisionSoles"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Format = "N2";

            dtgCreditos.Columns["idCuenta"].Width = 60;
            dtgCreditos.Columns["dFechaDesembolso"].Width = 75;
            dtgCreditos.Columns["cEstado"].Width = 75;
            dtgCreditos.Columns["nAtraso"].Width = 50;
            dtgCreditos.Columns["nSalTot"].Width = 90;
            dtgCreditos.Columns["nProvisionSoles"].Width = 90;
            dtgCreditos.Columns["cProducto"].Width = 140;
        }

        private void dtgCreditos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataTable dtInformes = cnSolicitud.ListarInformesPorCuenta(Convert.ToInt32(dtgCreditos.Rows[e.RowIndex].Cells["idCuenta"].Value));
                if (dtInformes.Rows.Count > 0)
                {
                    dtgInforme.DataSource = dtInformes;
                    formatoGridInformes();
                    dtgInforme.Rows[0].Selected = true;
                }
            }
        }

        private void formatoGridInformes()
        {
            foreach (DataGridViewColumn columna in dtgInforme.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }

            dtgInforme.Columns["dFechaRegistra"].Visible = true;

            dtgInforme.Columns["dFechaRegistra"].HeaderText = "Fecha que registra";
            
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            clsCNTranferencias cnTranferencias = new clsCNTranferencias();

            DataRowView row = (DataRowView)dtgCreditos.SelectedRows[0].DataBoundItem;

            int idCuenta = Convert.ToInt32(row["idCuenta"]);
            int idInfPaseRecuperaciones = Convert.ToInt32(dtgInforme.SelectedRows[0].Cells["idInfPaseRecuperaciones"].Value);
            int idSolicitud = Convert.ToInt32(row["idSolicitud"]);

            DataTable dtCreditoTransferido = cnTranferencias.ObtenerCreditoTransferido(idInfPaseRecuperaciones);
            DataTable dtIntervinientes = cnTranferencias.ListarIntervinientes(idSolicitud);
            DataTable dtGestiones = cnTranferencias.listarGestiones(idCuenta);
            DataTable dtPromesas = cnTranferencias.listarPromesas(idCuenta);



            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsGestiones", dtGestiones));
            dtslist.Add(new ReportDataSource("dsPromesas", dtPromesas));
            dtslist.Add(new ReportDataSource("dsCredito", dtCreditoTransferido));
            dtslist.Add(new ReportDataSource("dsInterviniente", dtIntervinientes));

            string reportpath = "rptInformeTransferencia.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
