using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmRptDepositoMasivo : frmBase
    {
        public frmRptDepositoMasivo()
        {
            InitializeComponent();
        }

     

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli.nidTipoPersona == 0)
            {
                return;
            }
            if (conBusCli.nidTipoPersona == 1)
            {
                MessageBox.Show("Debe elegir una persona jurídica", "Deposito masivo cts.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCli.limpiarControles();
                return;
            }
        }

       
        private void formatoGrid()
        {
            dtgListaDepositosMasivos.Columns["idCliente"].Visible = false;
            dtgListaDepositosMasivos.Columns["idTipoOperac"].Visible = false;
            dtgListaDepositosMasivos.Columns["idAgencia"].Visible = false;
            dtgListaDepositosMasivos.Columns["idProducto"].Visible = false;
            dtgListaDepositosMasivos.Columns["idMoneda"].Visible = false;

            dtgListaDepositosMasivos.Columns["cNomArchivo"].HeaderText  = "Nombre Archivo";
            dtgListaDepositosMasivos.Columns["cNomArchivo"].Width =150;
            dtgListaDepositosMasivos.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            dtgListaDepositosMasivos.Columns["cAgencia"].HeaderText = "Agencia";
            dtgListaDepositosMasivos.Columns["cProducto"].HeaderText = "Producto";
            dtgListaDepositosMasivos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgListaDepositosMasivos.Columns["cMoneda"].Width =70;
            dtgListaDepositosMasivos.Columns["cCategoria"].HeaderText = "Categoria";
            dtgListaDepositosMasivos.Columns["dFecOperacion"].HeaderText = "Fec. Operación";
            dtgListaDepositosMasivos.Columns["dFecOperacion"].Width = 80;
            dtgListaDepositosMasivos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgListaDepositosMasivos.RowCount<=0)
            {
                MessageBox.Show("No existe registros a mostrar", "Reporte depósito masivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
             List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            DataTable dtLista = (DataTable)dtgListaDepositosMasivos.DataSource;
            int fila = 0;
            if (dtgListaDepositosMasivos.CurrentRow!=null)
            {
                fila = dtgListaDepositosMasivos.CurrentRow.Index;
            }
            string idCliente = dtLista.Rows[fila]["idCliente"].ToString();
            string idProducto = dtLista.Rows[fila]["idProducto"].ToString();
            string idMoneda = dtLista.Rows[fila]["idMoneda"].ToString();
            string cNomArchivo = dtLista.Rows[fila]["cNomArchivo"].ToString();

            paramlist.Add(new ReportParameter("idCliente", idCliente, false));
            paramlist.Add(new ReportParameter("idMoneda", idMoneda, false));
            paramlist.Add(new ReportParameter("idAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", idProducto, false));
            paramlist.Add(new ReportParameter("dFechaOpe", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("cNombreArc", cNomArchivo, false));

            DataTable dtDepMasivo = new clsRPTCNDeposito().CNRptDepositoMasivo(Convert.ToInt32(idCliente), Convert.ToInt32(idMoneda), clsVarGlobal.nIdAgencia, Convert.ToInt32(idProducto), cNomArchivo);
       
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDepositoMasivo", dtDepMasivo));

            string reportpath = "rptDepositoMasivo.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();        
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        { 
            int idCli = 0;
            if (!chcTodos.Checked)
            {
                if (conBusCli.idCli==0)
                {
                    MessageBox.Show("Debe elegir a un cliente","Valida reporte depósito masivo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                idCli=conBusCli.idCli;

            }
            clsCNDeposito Deposito = new clsCNDeposito();
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
           
            DataTable dtDepMasivos = Deposito.CNListaDepositosMasivos(idCli, dFecIni, dFecFin);
            dtgListaDepositosMasivos.DataSource = dtDepMasivos;
            formatoGrid();
            
        }

        private void frmRptDepositoMasivo_Load(object sender, EventArgs e)
        {
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                conBusCli.Enabled = false;
                conBusCli.limpiarControles();
                dtgListaDepositosMasivos.DataSource = null;
            }
            else
            {
                conBusCli.Enabled = true;
                dtgListaDepositosMasivos.DataSource = null;
                conBusCli.txtCodCli.Enabled = true;
            }
        }
    }
}
