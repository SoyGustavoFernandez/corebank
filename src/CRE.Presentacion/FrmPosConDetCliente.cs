using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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
    public partial class FrmPosConDetCliente : frmBase
    {
        clsCNIntervCre IntervCre = new clsCNIntervCre();
        clsCNPlanPago PlanPago = new clsCNPlanPago();
        clsCNCredito Credito = new clsCNCredito();
        clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
        public FrmPosConDetCliente()
        {
            InitializeComponent();
        }


        public FrmPosConDetCliente(int idSolicitud, string Asesor, string GestorRecuperaciones, string Expediente, string MontoDesembolsado, string FechaDesembolso, string Estado, string Cuenta, string Moneda, int idCuenta)
        {
            InitializeComponent();

            txtCuenta.Text                  = Cuenta;
            txtExpediente.Text              = Expediente;
            txtMontoDesembolsado.Text       = MontoDesembolsado;
            txtFechaDesembolso.Text         = FechaDesembolso;
            txtEstado.Text                  = Estado;
            txtMoneda.Text                  = Moneda;
            txtAsesor.Text                  = Asesor;
            txtGestorRecuperaciones.Text    = GestorRecuperaciones;


            DataTable ListIntervCre = IntervCre.obtenerIntervinienteSolicitud(idSolicitud, clsVarGlobal.idModulo, false, false);
            dtgIntervinientes.DataSource = ListIntervCre;
            FormatoGridIntervinientes();
            // Cargar el Plan de Pagos

            DataTable ListPlanPago = PlanPago.CNdtPlanPagPosi(idCuenta);
            dtgPlanPagos.DataSource = ListPlanPago;
            FormatoPlanPagos();

            //Kardek de Pago
            DataTable Listkardex = Credito.CNdtLisKardexCre(idCuenta);
            dtgPagoKardex.DataSource = Listkardex;
            FormatoKardexpago();
            // Cargar gastos judiciales pendientes

            DataTable dtGastosJudiciales = CNGastosJudiciales.ListarPendientes(idCuenta);
            if (dtGastosJudiciales.Rows.Count > 0)
            {
                dtgGastosPendientes.DataSource = dtGastosJudiciales;
                formteardtgGastosPendientes();
            }
            else
            {
                dtgGastosPendientes.DataSource = null;
            }
        }
                         
        private void FrmPosConDetCliente_Load(object sender, EventArgs e)
        {

        }
        private void FormatoKardexpago()
        {
            foreach (DataGridViewColumn item in dtgPagoKardex.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPagoKardex.Columns["NumOrdPag"].Visible = true;
            dtgPagoKardex.Columns["dFechaOpe"].Visible = true;
            dtgPagoKardex.Columns["nAtrasoPago"].Visible = true;
            dtgPagoKardex.Columns["nMontoOperacion"].Visible = true;
            dtgPagoKardex.Columns["nMontoCapital"].Visible = true;
            dtgPagoKardex.Columns["nMontoInteres"].Visible = true;
            dtgPagoKardex.Columns["nMontoIntComp"].Visible = true;
            dtgPagoKardex.Columns["nMontoMora"].Visible = true;
            dtgPagoKardex.Columns["nMontoOtros"].Visible = true;
            dtgPagoKardex.Columns["nSaldoCap"].Visible = true;
            dtgPagoKardex.Columns["cWinUser"].Visible = true;
            dtgPagoKardex.Columns["cNombreAge"].Visible = true;
            dtgPagoKardex.Columns["cTipoOperacion"].Visible = true;
            dtgPagoKardex.Columns["cMotivoOperacion"].Visible = true;
            dtgPagoKardex.Columns["cDesTipoPago"].Visible = true;
            dtgPagoKardex.Columns["idKardex"].Visible = true;
            dtgPagoKardex.Columns["cNomPersOpe"].Visible = true;


            dtgPagoKardex.Columns["NumOrdPag"].HeaderText = "Nro";
            dtgPagoKardex.Columns["dFechaOpe"].HeaderText = "Fech. ope.";
            dtgPagoKardex.Columns["nAtrasoPago"].HeaderText = "Dias atraso";
            dtgPagoKardex.Columns["nMontoOperacion"].HeaderText = "Monto ope.";
            dtgPagoKardex.Columns["nMontoCapital"].HeaderText = "Monto cap.";
            dtgPagoKardex.Columns["nMontoInteres"].HeaderText = "Monto int.";
            dtgPagoKardex.Columns["nMontoIntComp"].HeaderText = "Monto int. comp.";
            dtgPagoKardex.Columns["nMontoMora"].HeaderText = "Monto mora";
            dtgPagoKardex.Columns["nMontoOtros"].HeaderText = "Monto otros";
            dtgPagoKardex.Columns["nSaldoCap"].HeaderText = "Saldo capital";
            dtgPagoKardex.Columns["cWinUser"].HeaderText = "Usuario";
            dtgPagoKardex.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgPagoKardex.Columns["cTipoOperacion"].HeaderText = "Operación";
            dtgPagoKardex.Columns["cMotivoOperacion"].HeaderText = "Mod. operación";
            dtgPagoKardex.Columns["cDesTipoPago"].HeaderText = "Tipo pago";
            dtgPagoKardex.Columns["idKardex"].HeaderText = "Nro. ope.";
            dtgPagoKardex.Columns["cNomPersOpe"].HeaderText = "Persona operación";

            dtgPagoKardex.Columns["NumOrdPag"].DisplayIndex = 0;
            dtgPagoKardex.Columns["idKardex"].DisplayIndex = 1;
            dtgPagoKardex.Columns["cTipoOperacion"].DisplayIndex = 2;
            dtgPagoKardex.Columns["cMotivoOperacion"].DisplayIndex = 3;
            dtgPagoKardex.Columns["dFechaOpe"].DisplayIndex = 4;
            dtgPagoKardex.Columns["nAtrasoPago"].DisplayIndex = 5;
            dtgPagoKardex.Columns["nMontoOperacion"].DisplayIndex = 6;
            dtgPagoKardex.Columns["nMontoCapital"].DisplayIndex = 7;
            dtgPagoKardex.Columns["nMontoInteres"].DisplayIndex = 8;
            dtgPagoKardex.Columns["nMontoIntComp"].DisplayIndex = 9;
            dtgPagoKardex.Columns["nMontoMora"].DisplayIndex = 10;
            dtgPagoKardex.Columns["nMontoOtros"].DisplayIndex = 11;
            dtgPagoKardex.Columns["nSaldoCap"].DisplayIndex = 12;
            dtgPagoKardex.Columns["cNomPersOpe"].DisplayIndex = 13;
            dtgPagoKardex.Columns["cWinUser"].DisplayIndex = 14;
            dtgPagoKardex.Columns["cNombreAge"].DisplayIndex = 15;
            dtgPagoKardex.Columns["cDesTipoPago"].DisplayIndex = 16;

            dtgPagoKardex.Columns["nMontoOperacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPagoKardex.Columns["nMontoCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPagoKardex.Columns["nMontoInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPagoKardex.Columns["nMontoIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPagoKardex.Columns["nMontoMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPagoKardex.Columns["nMontoOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgPagoKardex.Columns["nMontoOperacion"].DefaultCellStyle.Format = "#,0.00";
            dtgPagoKardex.Columns["nMontoCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPagoKardex.Columns["nMontoInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgPagoKardex.Columns["nMontoIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPagoKardex.Columns["nMontoMora"].DefaultCellStyle.Format = "#,0.00";
            dtgPagoKardex.Columns["nMontoOtros"].DefaultCellStyle.Format = "#,0.00";
        }
        private void FormatoGridIntervinientes()
        {
            foreach (DataGridViewColumn item in dtgIntervinientes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            this.dtgIntervinientes.Enabled = true;
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.Columns["cNombre"].Visible = true;
            this.dtgIntervinientes.Columns["cTipoIntervencion"].Visible = true;

            this.dtgIntervinientes.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Vínculo";
            this.dtgIntervinientes.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtgIntervinientes.Columns["cTipoIntervencion"].Width = 200;
        }
        private void FormatoPlanPagos()
        {
            foreach (DataGridViewColumn item in dtgPlanPagos.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPlanPagos.Columns["idCuota"].Visible = true;
            dtgPlanPagos.Columns["dFechaProg"].Visible = true;
            dtgPlanPagos.Columns["dFechaPago"].Visible = true;
            dtgPlanPagos.Columns["nAtrasoCuota"].Visible = true;
            dtgPlanPagos.Columns["nNumDiaCuota"].Visible = true;
            dtgPlanPagos.Columns["nMonCuoIni"].Visible = true;
            dtgPlanPagos.Columns["EstadoCuota"].Visible = true;
            dtgPlanPagos.Columns["nCapital"].Visible = true;
            dtgPlanPagos.Columns["nCapitalPagado"].Visible = true;
            dtgPlanPagos.Columns["nSalCap"].Visible = true;
            dtgPlanPagos.Columns["nInteres"].Visible = true;
            dtgPlanPagos.Columns["nInteresPagado"].Visible = true;
            dtgPlanPagos.Columns["nSalInt"].Visible = true;
            dtgPlanPagos.Columns["nInteresComp"].Visible = true;
            dtgPlanPagos.Columns["nInteresCompPago"].Visible = true;
            dtgPlanPagos.Columns["nSalIntComp"].Visible = true;
            dtgPlanPagos.Columns["nMoraGenerado"].Visible = true;
            dtgPlanPagos.Columns["nMoraPagada"].Visible = true;
            dtgPlanPagos.Columns["nSalMor"].Visible = true;
            dtgPlanPagos.Columns["nOtros"].Visible = true;
            dtgPlanPagos.Columns["nOtrosPagado"].Visible = true;
            dtgPlanPagos.Columns["nSalOtr"].Visible = true;
            dtgPlanPagos.Columns["nSalTot"].Visible = true;

            dtgPlanPagos.Columns["idCuota"].HeaderText = "Nro";
            dtgPlanPagos.Columns["dFechaProg"].HeaderText = "Fecha prog.";
            dtgPlanPagos.Columns["dFechaPago"].HeaderText = "Fecha pag.";
            dtgPlanPagos.Columns["nAtrasoCuota"].HeaderText = "Dias atr. cuo.";
            dtgPlanPagos.Columns["nNumDiaCuota"].HeaderText = "Dias cuota";
            dtgPlanPagos.Columns["nMonCuoIni"].HeaderText = "Monto cuota";
            dtgPlanPagos.Columns["EstadoCuota"].HeaderText = "Estado";
            dtgPlanPagos.Columns["nCapital"].HeaderText = "Capital";
            dtgPlanPagos.Columns["nCapitalPagado"].HeaderText = "Cap. pag.";
            dtgPlanPagos.Columns["nSalCap"].HeaderText = "Saldo cap.";
            dtgPlanPagos.Columns["nInteres"].HeaderText = "Int.";
            dtgPlanPagos.Columns["nInteresPagado"].HeaderText = "Int. pag.";
            dtgPlanPagos.Columns["nSalInt"].HeaderText = "Saldo int.";
            dtgPlanPagos.Columns["nInteresComp"].HeaderText = "Int. comp.";
            dtgPlanPagos.Columns["nInteresCompPago"].HeaderText = "Int. comp. pag.";
            dtgPlanPagos.Columns["nSalIntComp"].HeaderText = "Saldo int. comp.";
            dtgPlanPagos.Columns["nMoraGenerado"].HeaderText = "Mora. gen.";
            dtgPlanPagos.Columns["nMoraPagada"].HeaderText = "Mora. pag.";
            dtgPlanPagos.Columns["nSalMor"].HeaderText = "Saldo mora";
            dtgPlanPagos.Columns["nOtros"].HeaderText = "Otros";
            dtgPlanPagos.Columns["nOtrosPagado"].HeaderText = "Otros pag.";
            dtgPlanPagos.Columns["nSalOtr"].HeaderText = "Saldo otros";
            dtgPlanPagos.Columns["nSalTot"].HeaderText = "Saldo total";

            dtgPlanPagos.Columns["idCuota"].DisplayIndex = 0;
            dtgPlanPagos.Columns["dFechaProg"].DisplayIndex = 1;
            dtgPlanPagos.Columns["dFechaPago"].DisplayIndex = 2;
            dtgPlanPagos.Columns["nAtrasoCuota"].DisplayIndex = 3;
            dtgPlanPagos.Columns["nNumDiaCuota"].DisplayIndex = 4;
            dtgPlanPagos.Columns["nMonCuoIni"].DisplayIndex = 5;
            dtgPlanPagos.Columns["EstadoCuota"].DisplayIndex = 6;
            dtgPlanPagos.Columns["nCapital"].DisplayIndex = 7;
            dtgPlanPagos.Columns["nCapitalPagado"].DisplayIndex = 8;
            dtgPlanPagos.Columns["nSalCap"].DisplayIndex = 9;
            dtgPlanPagos.Columns["nInteres"].DisplayIndex = 10;
            dtgPlanPagos.Columns["nInteresPagado"].DisplayIndex = 11;
            dtgPlanPagos.Columns["nSalInt"].DisplayIndex = 12;
            dtgPlanPagos.Columns["nInteresComp"].DisplayIndex = 13;
            dtgPlanPagos.Columns["nInteresCompPago"].DisplayIndex = 14;
            dtgPlanPagos.Columns["nSalIntComp"].DisplayIndex = 15;
            dtgPlanPagos.Columns["nMoraGenerado"].DisplayIndex = 16;
            dtgPlanPagos.Columns["nMoraPagada"].DisplayIndex = 17;
            dtgPlanPagos.Columns["nSalMor"].DisplayIndex = 18;
            dtgPlanPagos.Columns["nOtros"].DisplayIndex = 19;
            dtgPlanPagos.Columns["nOtrosPagado"].DisplayIndex = 20;
            dtgPlanPagos.Columns["nSalOtr"].DisplayIndex = 21;
            dtgPlanPagos.Columns["nSalTot"].DisplayIndex = 22;


            dtgPlanPagos.Columns["nMonCuoIni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nSalCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nInteresPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nSalInt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nInteresCompPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nMoraGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nMoraPagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nSalMor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nOtrosPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nSalOtr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPlanPagos.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgPlanPagos.Columns["nMonCuoIni"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSalCap"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nInteresPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSalInt"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nInteresCompPago"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSalIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nMoraGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nMoraPagada"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSalMor"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nOtros"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nOtrosPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSalOtr"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSalTot"].DefaultCellStyle.Format = "#,0.00";


        }
        private void formteardtgGastosPendientes()
        {
            foreach (DataGridViewColumn column in dtgGastosPendientes.Columns)
            {
                column.Visible = false;
            }

            dtgGastosPendientes.Columns["dFechaRegistra"].Visible = true;
            dtgGastosPendientes.Columns["cConcepto"].Visible = true;
            dtgGastosPendientes.Columns["nMonto"].Visible = true;
            dtgGastosPendientes.Columns["cObservacion"].Visible = true;
            dtgGastosPendientes.Columns["cNombre"].Visible = true;
            dtgGastosPendientes.Columns["cMoneda"].Visible = true;

            dtgGastosPendientes.Columns["dFechaRegistra"].HeaderText = "Fecha Reg.";
            dtgGastosPendientes.Columns["cConcepto"].HeaderText = "Concepto";
            dtgGastosPendientes.Columns["nMonto"].HeaderText = "Monto";
            dtgGastosPendientes.Columns["cObservacion"].HeaderText = "Observación";
            dtgGastosPendientes.Columns["cNombre"].HeaderText = "Usuario Reg.";
            dtgGastosPendientes.Columns["cMoneda"].HeaderText = "Mon.";

            //dtgGastosPendientes.Columns["dFechaRegistra"].Width = 70;
            //dtgGastosPendientes.Columns["cConcepto"].Width = 100;
            //dtgGastosPendientes.Columns["nMonto"].Width = 70;
            //dtgGastosPendientes.Columns["cObservacion"].Width = 100;
            //dtgGastosPendientes.Columns["cNombre"].Width = 100;
            //dtgGastosPendientes.Columns["cMoneda"].Width = 25;

        }
    }
}
