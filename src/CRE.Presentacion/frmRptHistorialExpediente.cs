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
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmRptHistorialExpediente : frmBase
    {
        clsCNControlExp cnControlExp = new clsCNControlExp();
        int idTipoOpeExp;
        int idCli;
        public frmRptHistorialExpediente()
        {
            InitializeComponent();
            cboTipoExpediente1.cboCargarOpcionTodos(true);
            btnImprimir1.Enabled = false;
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            btnImprimir1.Enabled = false;
            cargarHistorial();
        }
        
        public void cargarHistorial()
        {
            if (String.IsNullOrEmpty(conBusCli1.txtCodCli.Text.Trim()))
            {
                limpiarTodo();
                MessageBox.Show("No hay cliente seleccionado", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCBEstadoActual.Clear();
                return;
            }
            cboTipoExpediente1.Enabled = true;
            if (cboTipoExpediente1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un Tipo de Expediente", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCBEstadoActual.Clear();
                return;
            }

            idTipoOpeExp = Convert.ToInt32(cboTipoExpediente1.SelectedValue);
            idCli = Convert.ToInt32(conBusCli1.txtCodCli.Text);
            DataTable dtResultado = cnControlExp.CNRptHistorialExpedientes(idCli, idTipoOpeExp);
            if (dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No hay Resultados para estos filtros", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dtgHistorialExpe.DataSource != null)
                    ((DataTable)dtgHistorialExpe.DataSource).Clear();
                txtCBEstadoActual.Clear();
                return;
            }

            dtgHistorialExpe.DataSource = dtResultado;
            formatoGrid();
            btnImprimir1.Enabled = true;
            txtCBEstadoActual.Text = Convert.ToString(dtResultado.Rows[Convert.ToInt32(dtResultado.Rows.Count)-1]["cUbicacion"]);
            
        }
        
        public void formatoGrid()
        {
            dtgHistorialExpe.Columns["idMovExpediente"].Visible = false;
            dtgHistorialExpe.Columns["idCli"].Visible = false;
            dtgHistorialExpe.Columns["idTipoOpeExp"].Visible = false;
            dtgHistorialExpe.Columns["cDescripcion"].Visible = false;
            dtgHistorialExpe.Columns["cChar"].Visible = false;

            dtgHistorialExpe.Columns["idExpediente"].HeaderText = "Expediente";
            dtgHistorialExpe.Columns["dFechaEntrega"].HeaderText = "Fecha Entrega";
            dtgHistorialExpe.Columns["cUbicacion"].HeaderText = "Ubicación";
            dtgHistorialExpe.Columns["cAgencia"].HeaderText = "Oficina";
            dtgHistorialExpe.Columns["cPersonal"].HeaderText = "Personal";
            dtgHistorialExpe.Columns["cMotivo"].HeaderText = "Motivo";

        }


        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarTodo();
        }
        
        private void limpiarTodo()
        {
            
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Focus();
            txtCBEstadoActual.Clear();
            if (dtgHistorialExpe.DataSource != null)
                ((DataTable)dtgHistorialExpe.DataSource).Clear();
            cboTipoExpediente1.Enabled = false;
            conBusCli1.txtCodCli.Enabled = true;
            btnImprimir1.Enabled = false;
            cboTipoExpediente1.SelectedValueChanged -=new EventHandler(cboTipoExpediente1_SelectedValueChanged);
            cboTipoExpediente1.SelectedIndex = -1;
            cboTipoExpediente1.SelectedValueChanged += new EventHandler(cboTipoExpediente1_SelectedValueChanged);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(conBusCli1.txtCodCli.Text))
            {
                MessageBox.Show("No hay cliente seleccionado", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtgHistorialExpe.RowCount < 1)
            {
                MessageBox.Show("No hay Registros de expediente", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            
            string reportpath = "rptHistorialDeExpedientes.rdlc";



            DataTable dtCliente = cnControlExp.CNClienteExpediente(idCli);
            if (dtCliente.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró resultados para el reporte", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtRpt = cnControlExp.CNRptHistorialExpedientes(idCli, idTipoOpeExp);
            if (dtRpt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró resultados para el reporte", "Historial de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];
            string cTipoExpediente = ((DataTable)cboTipoExpediente1.DataSource).Rows[cboTipoExpediente1.SelectedIndex]["cDescripcion"].ToString();

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("cTipoOpeExp", cTipoExpediente, false));

            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsHistorialExpe", dtRpt));
            dtslist.Add(new ReportDataSource("dsCliente", dtCliente));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }



        private void cboTipoExpediente1_SelectedValueChanged(object sender, EventArgs e)
        {
            cargarHistorial();
        }

    }
}
