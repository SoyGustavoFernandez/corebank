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
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmPagoDetrac : frmBase
    {
        clsCNComprobantes objCaja = new clsCNComprobantes();
        clsCNGenAdmOpe ObjTipoCambio = new clsCNGenAdmOpe();
        private int x_idGrupo=0;
        DataTable dtTipoCambioFijo;

        public frmPagoDetrac()
        {
            InitializeComponent();
        }

        private void frmPagoDetrac_Load(object sender, EventArgs e)
        {
            FormatoGridDetraccion();
            this.dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFinal.Value = clsVarGlobal.dFecSystem;
            this.cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;

            dtTipoCambioFijo = ObjTipoCambio.RetornaTiposCambio(clsVarGlobal.dFecSystem);
        }

        private void FormatoGridDetraccion()
        {
            //POR MODIFICAR
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("idComprobantePago", typeof(int)));
            dt.Columns.Add(new DataColumn("cNombre", typeof(string)));
            dt.Columns.Add(new DataColumn("dFechaEmision", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("dFechaPago", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("nTotal", typeof(decimal)));
            dt.Columns.Add(new DataColumn("nTotalDetraccion", typeof(decimal)));
            dt.Columns.Add(new DataColumn("cCtaDetraccion", typeof(string)));
            dt.Columns.Add(new DataColumn("lPago", typeof(bool)));
            dt.Columns.Add(new DataColumn("idCliente", typeof(int)));
            dt.Columns.Add(new DataColumn("cGlosa", typeof(string)));
            dt.Columns.Add(new DataColumn("nMontoConv", typeof(decimal)));
            dt.Columns.Add(new DataColumn("cNroCompSUNAT", typeof(string)));
            dt.Columns.Add(new DataColumn("cNroCheque", typeof(int)));
            dt.Columns.Add(new DataColumn("idTipoPago", typeof(int)));

            DataTable dtTipPago = objCaja.CNListaTipoPago();

            DataGridViewComboBoxColumn cmb1 = new DataGridViewComboBoxColumn();
            cmb1.HeaderText = "TIP. PAGO";
            cmb1.Name = "cmb1";
            cmb1.FillWeight = 50;
            cmb1.MaxDropDownItems = 4;            
            cmb1.DataSource = dtTipPago;
            cmb1.DisplayMember = dtTipPago.Columns["cDesTipoPago"].ToString();
            cmb1.ValueMember = dtTipPago.Columns["idTipoPago"].ToString();
            this.dtgCtasDetrac.Columns.Add(cmb1);

            this.dtgCtasDetrac.DataSource = dt;

            this.dtgCtasDetrac.Columns["cNroCheque"].Visible = false;

            this.dtgCtasDetrac.Columns["idComprobantePago"].Width = 40;
            this.dtgCtasDetrac.Columns["cNombre"].Width = 120;
            this.dtgCtasDetrac.Columns["dFechaEmision"].Width = 60;
            this.dtgCtasDetrac.Columns["dFechaPago"].Width = 60;
            this.dtgCtasDetrac.Columns["nTotal"].Width = 50;
            this.dtgCtasDetrac.Columns["nTotalDetraccion"].Width = 50;
            this.dtgCtasDetrac.Columns["cCtaDetraccion"].Width = 80;            
            this.dtgCtasDetrac.Columns["lPago"].Width = 30;
            this.dtgCtasDetrac.Columns["nMontoConv"].Width = 50;
            this.dtgCtasDetrac.Columns["cNroCompSUNAT"].Width = 70;
            this.dtgCtasDetrac.Columns["cmb1"].Width = 80;

            this.dtgCtasDetrac.Columns["idTipoPago"].Visible = false;
            OrdenCeldasGridDetraccion();
            
            //FIN MODIF
        }
        private void OrdenCeldasGridDetraccion()
        {
            this.dtgCtasDetrac.Columns["idComprobantePago"].DisplayIndex = 1;
            this.dtgCtasDetrac.Columns["cNombre"].DisplayIndex = 2;
            this.dtgCtasDetrac.Columns["dFechaEmision"].DisplayIndex = 3;
            this.dtgCtasDetrac.Columns["dFechaPago"].DisplayIndex = 4;
            this.dtgCtasDetrac.Columns["nTotal"].DisplayIndex = 5;
            this.dtgCtasDetrac.Columns["nTotalDetraccion"].DisplayIndex = 6;
            this.dtgCtasDetrac.Columns["cCtaDetraccion"].DisplayIndex = 7;
            this.dtgCtasDetrac.Columns["idCliente"].DisplayIndex = 8;
            this.dtgCtasDetrac.Columns["cGlosa"].DisplayIndex = 9;
            this.dtgCtasDetrac.Columns["lPago"].DisplayIndex = 10;
            this.dtgCtasDetrac.Columns["nMontoConv"].DisplayIndex = 11;
            this.dtgCtasDetrac.Columns["cNroCompSUNAT"].DisplayIndex = 12;
            this.dtgCtasDetrac.Columns["cmb1"].DisplayIndex = 13;
            this.dtgCtasDetrac.Columns["cNroCheque"].DisplayIndex = 14;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosLista())
            {
                return;
            }
            x_idGrupo = 0;
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue.ToString());
            DateTime dFecIni = this.dtpFecInicial.Value;
            DateTime dFecFin = this.dtpFecFinal.Value;
            int idMoneda = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            dtgCtasDetrac.ReadOnly = false;
            DataTable tblista = objCaja.CNListarCtaDetracProveedor(idAgencia, dFecIni, dFecFin, idMoneda);
            if (tblista.Rows.Count>0)
            {                
                tblista.Columns["lPago"].ReadOnly = false;

                for (int i = 0; i < tblista.Rows.Count; i++)
                {
                    if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
                    {
                        tblista.Rows[i]["nMontoConv"] =  Convert.ToDecimal(Math.Round(Convert.ToDecimal(tblista.Rows[i]["nTotalDetraccion"]) * Convert.ToDecimal(dtTipoCambioFijo.Rows[0]["nTipCamFij"]),1).ToString("###0.00"));
                    }
                    else
                    {
                        tblista.Rows[i]["nMontoConv"] = Convert.ToDecimal(Convert.ToDecimal(tblista.Rows[i]["nTotalDetraccion"]));
                    }
                }

                dtgCtasDetrac.DataSource = tblista;

                dtgCtasDetrac.Columns["lPago"].ReadOnly = false;
                dtgCtasDetrac.Columns["idComprobantePago"].ReadOnly = true;
                dtgCtasDetrac.Columns["cNombre"].ReadOnly = true;
                dtgCtasDetrac.Columns["dFechaEmision"].ReadOnly = true;
                dtgCtasDetrac.Columns["dFechaPago"].ReadOnly = true;
                dtgCtasDetrac.Columns["nTotal"].ReadOnly = true;
                dtgCtasDetrac.Columns["nTotalDetraccion"].ReadOnly = true;
                dtgCtasDetrac.Columns["cCtaDetraccion"].ReadOnly = true;
                dtgCtasDetrac.Columns["nMontoConv"].ReadOnly = true;                
                dtgCtasDetrac.Columns["cNroCompSUNAT"].ReadOnly = false;
                dtgCtasDetrac.Columns["cmb1"].ReadOnly = false;
                OrdenCeldasGridDetraccion();
            }
            else
            {
                btnProcesar.Enabled = false;
            }
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private bool ValidarDatosLista()
        {
            if (Convert.ToInt32(cboAgencia.SelectedValue.ToString())<0)
            {
                MessageBox.Show("Primero debe Seleccionar Una Agencia", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.dtpFecInicial.Value>this.dtpFecFinal.Value)
            {
                MessageBox.Show("La Fecha Fina debe Ser Mayor o Igual a la Fecha Inicial", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(cboMoneda.SelectedValue.ToString()) < 0)
            {
                MessageBox.Show("Primero debe Seleccionar la Moneda", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            if (MessageBox.Show("¿Esta seguro(a) de Generar el Listado de Pago?", "Pago de Detracciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            x_idGrupo = 0;
            DataSet dsDetrac = new DataSet("dsDetraccion");
            DataTable dtDetrac = (DataTable)dtgCtasDetrac.DataSource;

            for (int i = 0; i < dtDetrac.Rows.Count; i++)
            {
                dtDetrac.Rows[i]["idTipoPago"] = Convert.ToInt32(this.dtgCtasDetrac.Rows[i].Cells["cmb1"].Value);                
            }

            dsDetrac.Tables.Add(dtDetrac);
            string xmlDetrac = clsCNFormatoXML.EncodingXML(dsDetrac.GetXml());
            DataTable tdDetracProv = objCaja.CNRegistraDetracProveedor(xmlDetrac, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia);
            if (Convert.ToInt16(tdDetracProv.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tdDetracProv.Rows[0]["cMensage"].ToString(), "Pago de Detracción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                x_idGrupo = Convert.ToInt32(tdDetracProv.Rows[0]["idGrupo"].ToString());
            }
            else
            {
                MessageBox.Show(tdDetracProv.Rows[0]["cMensage"].ToString(), "Pago de Detracción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnImprimir.Enabled = true;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private bool ValidarDatos()
        {
            if (dtgCtasDetrac.Rows.Count<=0)
            {
                MessageBox.Show("No Existe Datos en la Lista", "Validar Lista de Detracción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            int x = 0;
            for (int i = 0; i < dtgCtasDetrac.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgCtasDetrac.Rows[i].Cells["lPago"].Value))
                {
                    x = x + 1;
                    break;
                }
            }
            if (x==0)
            {
                return false;
            }
            return true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idGrupo = x_idGrupo;

            paramlist.Add(new ReportParameter("x_idGrupo", idGrupo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("DsGrupoCpg", new clsCNComprobantes().CNRptGrupoDetracProveedor(idGrupo)));

            string reportpath = "RptGrupoPagDetraccion.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            x_idGrupo = 0;
            btnProcesar.Enabled = false;
            btnImprimir.Enabled = false;
        }

        private void dtgCtasDetrac_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnDetrac = dtgCtasDetrac.CurrentCell.ColumnIndex;
            int rowDetrac = dtgCtasDetrac.CurrentCell.RowIndex;

            if (columnDetrac == 12)
            {
                TextBox txtbox = e.Control as TextBox;
                txtbox.MaxLength = 15;
                if (columnDetrac > 3 && columnDetrac < 13 && txtbox != null)
                    txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }

            if (columnDetrac == 13)
            {
                    if (Convert.ToInt32(dtgCtasDetrac.Rows[rowDetrac].Cells["cmb1"].Value) == 3)
                    {
                        this.dtgCtasDetrac.Columns["cNroCheque"].ReadOnly = false;
                        this.dtgCtasDetrac.Columns["cNroCheque"].Visible = true;
                        this.dtgCtasDetrac.Columns["cNroCheque"].HeaderText = "N° CHEQUE";
                    }
                    else
                    {
                        this.dtgCtasDetrac.Columns["cNroCheque"].ReadOnly = true;
                        this.dtgCtasDetrac.Columns["cNroCheque"].Visible = false;
                    }                
            }           
        }

        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
