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
using GEN.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class frmCuentaCreditoVinculado : frmBase
    {
        public DataTable dtCreditosAmp = new DataTable();
        public clsSolicitudCredSimp objSolicitud = new clsSolicitudCredSimp();
        public clsCliente objCliente = new clsCliente();
        public decimal nMontoTotal = 0;

        public frmCuentaCreditoVinculado()
        {
            InitializeComponent();
        }

        public void CargarDatos(clsSolicitudCredSimp _objSolicitud, clsCliente _objCliente, DataTable _dtCreditosAmp)
        {
            this.objSolicitud = _objSolicitud;
            this.objCliente = _objCliente;
            this.dtCreditosAmp = _dtCreditosAmp;
        }

        public void CargaDataGridView()
        {
            dtgCuentaCreditoVinculado.DataSource = dtCreditosAmp;

            dtgCuentaCreditoVinculado.Columns["idSolicitud"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["lPermQuitar"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["nTasaCompensatoria"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["nTasaMoratoria"].Visible = false;

            dtgCuentaCreditoVinculado.Columns["idCuenta"].HeaderText = "CUENTA";
            dtgCuentaCreditoVinculado.Columns["nTotal"].HeaderText = "SALDO CREDITO";
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].HeaderText = "SALDO CAPITAL";
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].HeaderText = "SALDO INTERES";
            dtgCuentaCreditoVinculado.Columns["nSalMora"].HeaderText = "SALDO MORA";
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].HeaderText = "SALDO OTROS";
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].HeaderText = "SALDO INT. COMPENSATORIO";
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].HeaderText = "DESEMBOLSO";

            dtgCuentaCreditoVinculado.Columns["idCuenta"].Width = 80;
            dtgCuentaCreditoVinculado.Columns["nTotal"].Width = 108;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].Width = 180;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].Width = 100;

            dtgCuentaCreditoVinculado.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCuentaCreditoVinculado.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
            dtgCuentaCreditoVinculado.ClearSelection();
        }
        private void CargarCuentaVinculada(int idSolicitud)
        {
            clsCNSolicitud nListCreditosAmp = new clsCNSolicitud();

            if (dtCreditosAmp.AsEnumerable().Where(row => row.RowState != DataRowState.Deleted).Any(row => row.Field<int>("idSolicitud") == 0))
            {
                CargaDataGridView();
            }
            else 
            {
                dtCreditosAmp = nListCreditosAmp.CNRetCuentasAmpliadas(idSolicitud);//Aplica para ampliación y refinanciación
                CargaDataGridView();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idCuenta = 0;
            if (objCliente.idCli == 0)
            {
                return;
            }
            if (objSolicitud.idOperacion.In(2, 4))
            {
                clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(objCliente.idCli, "C", "[5]");

                if (dtDatosCuentaSolCliente.Rows.Count == 0)
                {
                    MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                    frmBusCuenCli.CargarDatos(objCliente.idCli, "C", "[5]");
                    frmBusCuenCli.ShowDialog();
                    idCuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                    if (idCuenta != 0)
                    {
                        agregarCreditos(idCuenta);
                    }
                }
            }
        }

        private void frmCuentaCreditoVinculado_Load(object sender, EventArgs e)
        {
            CargarCuentaVinculada(objSolicitud.idSolicitud);
        }

        private void agregarCreditos(int idCuentaCre)
        {
            CRE.CapaNegocio.clsCNCredito credito = new CRE.CapaNegocio.clsCNCredito();
            clsCredito entCredito = credito.retornaDatosCredito(idCuentaCre);

            if (dtCreditosAmp.AsEnumerable().Any(x => x.Field<int>("idCuenta") == entCredito.idCuenta))
                return;

            if (entCredito.IdMoneda != objSolicitud.idMoneda)
            {
                MessageBox.Show("Debe seleccionar creditos del mismo tipo de moneda", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (objSolicitud.idOperacion.In(2, 6) && entCredito.nInteresDia - entCredito.nInteresPagado < 0)
            {
                MessageBox.Show("No se puede refinanciar un crédito con intereses pagados por adelantado.", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow drCredito = dtCreditosAmp.NewRow();
            drCredito["idSolicitud"] = "0";
            drCredito["idCuenta"] = entCredito.idCuenta;
            drCredito["nTotal"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado) +
                                    (entCredito.nInteresDia - entCredito.nInteresPagado) +
                                    (entCredito.nMoraGenerado - entCredito.nMoraPagada) +
                                    (entCredito.nOtrosGenerado - entCredito.nOtrosPagado) +
                                    (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["nSalCapital"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado);
            drCredito["nSalInteres"] = (entCredito.nInteresDia - entCredito.nInteresPagado);
            drCredito["nSalMora"] = (entCredito.nMoraGenerado - entCredito.nMoraPagada);
            drCredito["nSalOtros"] = (entCredito.nOtrosGenerado - entCredito.nOtrosPagado);
            drCredito["nSalIntComp"] = (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["lPermQuitar"] = 1;
            drCredito["nTasaCompensatoria"] = entCredito.nTasaCompensatoria;
            drCredito["nTasaMoratoria"] = entCredito.nTasaMoratoria;
            drCredito["nCapitalDesembolso"] = entCredito.nCapitalDesembolso;

            dtCreditosAmp.Rows.Add(drCredito);

            txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgCuentaCreditoVinculado.SelectedRows.Count > 0)
            {
                dtgCuentaCreditoVinculado.Rows.RemoveAt(this.dtgCuentaCreditoVinculado.SelectedCells[0].RowIndex);
                txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
                if (objSolicitud.idOperacion.In (2,4,6))
                {
                    nMontoTotal = Convert.ToDecimal(txtSalTotalCre.Text);
                }
            }
            else
            {
                MessageBox.Show("Seleccione por favor un item para quitar", "Desvincular crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
