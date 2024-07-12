using CRE.CapaNegocio;
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
using System.Globalization;
using EntityLayer;
using GEN.Funciones;
using GEN.CapaNegocio;
using System.Xml.Linq;



namespace CRE.Presentacion
{
    public partial class frmSolCondonaPorCuota : frmBase
    {
        #region Variables Globales
        Boolean lEsCasoEspecial = false;
        int nNumCredito = 0;
        int idTipoCondonacion = 0;
        String cTipoCondonacion = String.Empty;
        Boolean lSoloVista = false;
        //int idCondicionContable = 0;
        String cTituloMensaje = "Solicitud de condonación por cuota";
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        DataTable dtPlanPago;
        List<SI_FinDetalleTipoCondonacion> lstTipCond;
        clsFunUtiles objFunciones = new clsFunUtiles();

        public Decimal nCapital = 0;
        public Decimal nInteres = 0;
        public Decimal nInteresComp = 0;
        public Decimal nMora = 0;
        public Decimal nOtros = 0;
        public Boolean lHayCondonacion = false;
        public String xmlCoutasCondonadas = String.Empty;
        public Decimal nMontoPagarTmp = 0;
        public Decimal nMontoCondonarTmp = 0;
        public Decimal nMontoCondonarGet = 0;
        public Decimal maxCondonarTmp = 0;
        public Decimal totalPagarTmp = 0;
        public int rowsAfected = 0;
        int maxRowsAfected = 0;
        int cuotasReal = 0;
        Color colorSel = Color.LightPink;
        public int nNumCuotasAfectadas;

        int idMonedaGral = 0;
        #endregion

        public frmSolCondonaPorCuota()
        {
            InitializeComponent();
        }

        public string getMontoXCuota() 
        {
            return totalPagarTmp.ToString();
        }

        public int getRowsAfected()
        {
            return cuotasReal;
        }

        public frmSolCondonaPorCuota(int idCuota, int idTipoCondonacion, String cTipoCondonacion, String xmlCoutasCondonadas, Boolean lSoloVista, decimal nMontoPagar, decimal nMontoCondonar, bool lEditar = true, int idMoneda=1, int nCuotasCubiertas=0)
        {
            this.nNumCredito = idCuota;
            this.idTipoCondonacion = idTipoCondonacion;
            this.cTipoCondonacion = cTipoCondonacion;
            this.xmlCoutasCondonadas = xmlCoutasCondonadas;
            this.lSoloVista = lSoloVista;
            this.nMontoPagarTmp = nMontoPagar;
            this.nMontoCondonarGet = nMontoCondonar;
            this.nNumCuotasAfectadas = 0;
            cuotasReal = nCuotasCubiertas;
            InitializeComponent();
            this.grbDetCondo.Enabled = false;
            this.idMonedaGral = idMoneda;
            this.btnEditar1.Enabled = lEditar;
            this.btnDistribuir.Enabled = false;
        }
        #region Eventos
        private void frmSolCondonaPorCuota_Load(object sender, EventArgs e)
        {
            this.lblTipoCondonacion.Text = cTipoCondonacion;
            CargaDetalleTipoCondonacion();
            cargarPlanPagos();
            this.dtgPpg.ReadOnly = lSoloVista;
            
            //txtTotalCondonar.Text = nMontoCondonarTmp.ToString();
            cuotasCubiertas.Text = maxRowsAfected.ToString();
            actualizarMontoCondonarPagar();
            if (cuotasReal != 0)
            {
                cuotasCubiertas.Text = cuotasReal.ToString();
                txtTotalCondonar.Text = nMontoCondonarGet.ToString();
            }
            distribuirCondonacion();
        }        
        

        private void sumarCuotaAPagar()
        {
            decimal nMontoTotal = 0;
            bool lEditado;
            lEditado = true;
            
            foreach (DataRow row in dtPlanPago.Rows)
            {
                try
                {
                    lEditado = Convert.ToBoolean(row["lEditado"]);
                }
                catch
                { 
                    lEditado = false;
                }

                if (lEditado)
                {
                    decimal nSaldoCapital = Convert.ToDecimal(row["nSalCap"]) - Convert.ToDecimal(row["nCapitalPagado"]);
                    decimal nSaldoInteres = Convert.ToDecimal(row["nInteresFechaSaldo"]) - Convert.ToDecimal(row["nInteresPagado"]);
                    decimal nSaldoCompensatorio = Convert.ToDecimal(row["nSalIntComp"]) - Convert.ToDecimal(row["nInteresCompPago"]);
                    decimal nSaldoMoratorio = Convert.ToDecimal(row["nSalMor"]) - Convert.ToDecimal(row["nMoraPagada"]);
                    decimal nSaldoOtros = Convert.ToDecimal(row["nSalOtr"]) - Convert.ToDecimal(row["nOtrosPagado"]);
                    nMontoTotal += (nSaldoCapital + nSaldoInteres + nSaldoCompensatorio + nSaldoMoratorio + nSaldoOtros);                    
                }
            }
   
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!validarUltimoDiasAtrazo())
                return;

            nCapital = Convert.ToDecimal(this.txtCapital.Text);
            nInteres = Convert.ToDecimal(this.txtInteres.Text);
            nInteresComp = Convert.ToDecimal(this.txtInteresComp.Text);
            nMora = Convert.ToDecimal(this.txtMora.Text);
            nOtros = Convert.ToDecimal(this.txtOtros.Text);
            dtPlanPago = null;
            dtPlanPago = (DataTable)dtgPpg.DataSource;
            DataSet dsCoutasCondonadas = new DataSet("DSCoutasCondonadas");
            for (int i = cuotasReal; i <= dtPlanPago.Rows.Count - 1; i++)
            {
                DataRow dtFila = dtPlanPago.Rows[i];
                dtFila.Delete();
            }
            dtPlanPago.AcceptChanges();
            if (dtPlanPago.Rows.Count > 0)
            {
                dsCoutasCondonadas.Tables.Add(dtPlanPago);
                xmlCoutasCondonadas = dsCoutasCondonadas.GetXml();
                xmlCoutasCondonadas = clsCNFormatoXML.EncodingXML(xmlCoutasCondonadas);
                dsCoutasCondonadas.Tables.Clear();
            }

            lHayCondonacion = true;
            totalPagarTmp = Convert.ToDecimal(txtTotalPagar.Text);

            this.nNumCuotasAfectadas = Convert.ToInt32(Convert.ToDecimal(txtOtros.Text));

            this.Dispose();
            
        }

        private bool validarUltimoDiasAtrazo()
        {
            int dia = Convert.ToInt32(clsVarGlobal.dFecSystem.Date.Day.ToString());
            int mes = Convert.ToInt32(clsVarGlobal.dFecSystem.Date.Month.ToString());
            int anio = Convert.ToInt32(clsVarGlobal.dFecSystem.Date.Year.ToString());

            int diasMes = System.DateTime.DaysInMonth(anio, mes);
            int minDiasAtrazo = clsVarApl.dicVarGen["nMinDiasAtraso"];

            if (cuotasReal<dtgPpg.Rows.Count)
            {
                int ultAtrazo = Convert.ToInt32(dtgPpg.Rows[cuotasReal].Cells["nAtrasoCuota"].Value);

                if (ultAtrazo + (diasMes - diasMes) > minDiasAtrazo)
                {
                    MessageBox.Show("El Crédito debe quedar con menos de " + minDiasAtrazo + " días de atraso proyectados al cierre del mes", "Validación de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Metodos
        private void calcularTotal()
        {
            decimal nTxtCapital = Convert.ToDecimal(txtCapital.Text);
            decimal nTxtInteres = Convert.ToDecimal(txtInteres.Text);
            decimal nTxtCompensatorio = Convert.ToDecimal(txtInteresComp.Text);
            decimal nTxtMoratorio = Convert.ToDecimal(txtMora.Text);
            decimal nTxtOtros = Convert.ToDecimal(txtOtros.Text);
            txtTotalCondonar.Text = (nTxtCapital + nTxtInteres + nTxtCompensatorio + nTxtMoratorio + nTxtOtros).ToString("0.00");
        }

        private void cargarPlanPagos()
        {
            // Cargar el Plan de Pagos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            dtPlanPago = PlanPago.CNdtPlanPagPosiCon(nNumCredito);
                       
            FormatoPlanPagos();
            llenarDatosDTG();
            //verificaSiVieneXMLcuotas();
        }
        private void FormatoPlanPagos()
        {
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtPlanPago.Columns.Add("nPorcCapital", typeof(Decimal));
                dtPlanPago.Columns.Add("nPorcCapitalEdit", typeof(Decimal));
            }
            dtPlanPago.Columns.Add("nPorcInteres", typeof(Decimal));
            dtPlanPago.Columns.Add("nPorcInteresEdit", typeof(Decimal));
            dtPlanPago.Columns.Add("nPorcInteresComp", typeof(Decimal));
            dtPlanPago.Columns.Add("nPorcInteresCompEdit", typeof(Decimal));
            dtPlanPago.Columns.Add("nPorcMora", typeof(Decimal));
            dtPlanPago.Columns.Add("nPorcMoraEdit", typeof(Decimal));
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtPlanPago.Columns.Add("nPorcOtros", typeof(Decimal));
                dtPlanPago.Columns.Add("nPorcOtrosEdit", typeof(Decimal));
            }
            dtPlanPago.Columns.Add("lEditado", typeof(Boolean));

            dtPlanPago.Columns.Add("nTotalCuota", typeof(Decimal));

            dtPlanPago.Columns["idCuota"].SetOrdinal(0);
            dtPlanPago.Columns["dFechaProg"].SetOrdinal(1);
            dtPlanPago.Columns["dFechaPago"].SetOrdinal(2);
            dtPlanPago.Columns["nAtrasoCuota"].SetOrdinal(3);
            dtPlanPago.Columns["nNumDiaCuota"].SetOrdinal(4);
            dtPlanPago.Columns["nMonCuoIni"].SetOrdinal(5);
            dtPlanPago.Columns["EstadoCuota"].SetOrdinal(6);
            dtPlanPago.Columns["nCapital"].SetOrdinal(7);
            dtPlanPago.Columns["nSalCap"].SetOrdinal(8);
            dtPlanPago.Columns["nCapitalPagado"].SetOrdinal(9);
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtPlanPago.Columns["nPorcCapital"].SetOrdinal(10);
                dtPlanPago.Columns["nPorcCapitalEdit"].SetOrdinal(11);
            }
            dtPlanPago.Columns["nInteres"].SetOrdinal(12);
            dtPlanPago.Columns["nInteresFechaSaldo"].SetOrdinal(13);
            dtPlanPago.Columns["nInteresPagado"].SetOrdinal(14);
            dtPlanPago.Columns["nPorcInteres"].SetOrdinal(15);
            dtPlanPago.Columns["nPorcInteresEdit"].SetOrdinal(16);
            dtPlanPago.Columns["nInteresComp"].SetOrdinal(17);
            dtPlanPago.Columns["nSalIntComp"].SetOrdinal(18);
            dtPlanPago.Columns["nInteresCompPago"].SetOrdinal(19);
            dtPlanPago.Columns["nPorcInteresComp"].SetOrdinal(20);
            dtPlanPago.Columns["nPorcInteresCompEdit"].SetOrdinal(21);
            dtPlanPago.Columns["nMoraGenerado"].SetOrdinal(22);
            dtPlanPago.Columns["nSalMor"].SetOrdinal(23);
            dtPlanPago.Columns["nMoraPagada"].SetOrdinal(24);
            dtPlanPago.Columns["nPorcMora"].SetOrdinal(25);
            dtPlanPago.Columns["nPorcMoraEdit"].SetOrdinal(26);
            dtPlanPago.Columns["nOtros"].SetOrdinal(27);
            dtPlanPago.Columns["nSalOtr"].SetOrdinal(28);
            dtPlanPago.Columns["nOtrosPagado"].SetOrdinal(29);
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtPlanPago.Columns["nPorcOtros"].SetOrdinal(30);
                dtPlanPago.Columns["nPorcOtrosEdit"].SetOrdinal(31);
            }
            dtPlanPago.Columns["idCuenta"].SetOrdinal(32);
            dtPlanPago.Columns["nSalTot"].SetOrdinal(33);
            dtPlanPago.Columns["cNombre"].SetOrdinal(34);
            dtPlanPago.Columns["dFechaDesembolso"].SetOrdinal(35);
            dtPlanPago.Columns["nCapitalDesembolso"].SetOrdinal(36);
            dtPlanPago.Columns["idAgenCli"].SetOrdinal(37);
            dtPlanPago.Columns["cAgenCli"].SetOrdinal(38);

            dtgPpg.DataSource = dtPlanPago;

            dtgPpg.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgPpg.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            
            dtPlanPago.Columns["nCapitalPagado"].ReadOnly = false;
            dtPlanPago.Columns["nInteresPagado"].ReadOnly = false;
            dtPlanPago.Columns["nInteresCompPago"].ReadOnly = false;
            dtPlanPago.Columns["nMoraPagada"].ReadOnly = false;
            dtPlanPago.Columns["nOtrosPagado"].ReadOnly = false;
            

            dtgPpg.Columns["dFechaProg"].Width = 70;
            dtgPpg.Columns["dFechaPago"].Width = 70;
            dtgPpg.Columns["nCapital"].Width = 40;
            dtgPpg.Columns["nCapitalPagado"].Width = 40;
            dtgPpg.Columns["nInteres"].Width = 40;
            dtgPpg.Columns["nInteresPagado"].Width = 40;
            dtgPpg.Columns["nInteresComp"].Width = 40;
            dtgPpg.Columns["nInteresCompPago"].Width = 40;
            dtgPpg.Columns["nMoraGenerado"].Width = 40;
            dtgPpg.Columns["nMoraPagada"].Width = 40;
            dtgPpg.Columns["nOtros"].Width = 40;
            dtgPpg.Columns["nOtrosPagado"].Width = 40;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtgPpg.Columns["nPorcCapital"].Width = 40;
                dtgPpg.Columns["nPorcCapitalEdit"].Width = 40;
            }
            dtgPpg.Columns["nPorcInteres"].Width = 40;
            dtgPpg.Columns["nPorcInteresComp"].Width = 40;
            dtgPpg.Columns["nPorcMora"].Width = 40;
            
            
            dtgPpg.Columns["nPorcInteresEdit"].Width = 40;
            dtgPpg.Columns["nPorcInteresCompEdit"].Width = 40;
            dtgPpg.Columns["nPorcMoraEdit"].Width = 40;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtgPpg.Columns["nPorcOtros"].Width = 40;
                dtgPpg.Columns["nPorcOtrosEdit"].Width = 40;
            }
            dtgPpg.Columns["nTotalCuota"].Width = 90;

            dtgPpg.Columns["idCuota"].Visible = true;
            dtgPpg.Columns["dFechaProg"].Visible = true;
            dtgPpg.Columns["dFechaPago"].Visible = true;
            dtgPpg.Columns["nAtrasoCuota"].Visible = true;
            //dtgPpg.Columns["nNumDiaCuota"].Visible = true;
            //dtgPpg.Columns["nMonCuoIni"].Visible = true;
            dtgPpg.Columns["EstadoCuota"].Visible = true;
            dtgPpg.Columns["nSalCap"].Visible = true;
            dtgPpg.Columns["nCapitalPagado"].Visible = true;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtgPpg.Columns["nPorcCapital"].Visible = true;
                dtgPpg.Columns["nPorcCapitalEdit"].Visible = true;
            }
            dtgPpg.Columns["nInteresFechaSaldo"].Visible = true;
            dtgPpg.Columns["nInteresPagado"].Visible = true;
            dtgPpg.Columns["nPorcInteres"].Visible = true;
            dtgPpg.Columns["nPorcInteresEdit"].Visible = true;
            dtgPpg.Columns["nSalIntComp"].Visible = true;
            dtgPpg.Columns["nInteresCompPago"].Visible = true;
            dtgPpg.Columns["nPorcInteresComp"].Visible = true;
            dtgPpg.Columns["nPorcInteresCompEdit"].Visible = true;
            dtgPpg.Columns["nSalMor"].Visible = true;
            dtgPpg.Columns["nMoraPagada"].Visible = true;
            dtgPpg.Columns["nPorcMora"].Visible = true;
            dtgPpg.Columns["nPorcMoraEdit"].Visible = true;
            dtgPpg.Columns["nSalOtr"].Visible = true;
            dtgPpg.Columns["nOtrosPagado"].Visible = true;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtgPpg.Columns["nPorcOtros"].Visible = true;
                dtgPpg.Columns["nPorcOtrosEdit"].Visible = true;
            }
            dtgPpg.Columns["nTotalCuota"].Visible = true;       

            dtgPpg.Columns["idCuota"].HeaderText = "Nro";
            dtgPpg.Columns["dFechaProg"].HeaderText = "Fecha prog.";
            dtgPpg.Columns["dFechaPago"].HeaderText = "Fecha pagd.";
            dtgPpg.Columns["nAtrasoCuota"].HeaderText = "Dias atr. cuo.";
            //dtgPpg.Columns["nNumDiaCuota"].HeaderText = "Dias cuota";
            //dtgPpg.Columns["nMonCuoIni"].HeaderText = "Monto cuota";
            dtgPpg.Columns["EstadoCuota"].HeaderText = "Estado";
            dtgPpg.Columns["nCapital"].HeaderText = "Capital";
            dtgPpg.Columns["nCapitalPagado"].HeaderText = "Cap. pagd.";
            dtgPpg.Columns["nSalCap"].HeaderText = "Saldo cap.";
            
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtgPpg.Columns["nPorcCapital"].HeaderText = "% Max. cond.";
                dtgPpg.Columns["nPorcCapitalEdit"].HeaderText = "% Edit";
            }
            dtgPpg.Columns["nInteres"].HeaderText = "Int.";
            dtgPpg.Columns["nInteresPagado"].HeaderText = "Int. pagd.";
            dtgPpg.Columns["nInteresFechaSaldo"].HeaderText = "Saldo int.";
            dtgPpg.Columns["nPorcInteres"].HeaderText = "% Max. cond.";
            dtgPpg.Columns["nPorcInteresEdit"].HeaderText = "% Edit";
            dtgPpg.Columns["nInteresComp"].HeaderText = "Int. comp.";
            dtgPpg.Columns["nInteresCompPago"].HeaderText = "Int. comp. pagd.";
            dtgPpg.Columns["nSalIntComp"].HeaderText = "Saldo int. comp.";
            dtgPpg.Columns["nPorcInteresComp"].HeaderText = "% Max. cond.";
            dtgPpg.Columns["nPorcInteresCompEdit"].HeaderText = "% Edit";
            dtgPpg.Columns["nMoraGenerado"].HeaderText = "Mora. gen.";
            dtgPpg.Columns["nMoraPagada"].HeaderText = "Mora. pagd.";
            dtgPpg.Columns["nSalMor"].HeaderText = "Saldo mora";
            dtgPpg.Columns["nPorcMora"].HeaderText = "% Max. cond.";
            dtgPpg.Columns["nPorcMoraEdit"].HeaderText = "% Edit";                
            dtgPpg.Columns["nOtros"].HeaderText = "Otros";
            dtgPpg.Columns["nOtrosPagado"].HeaderText = "Otros pagd.";
            dtgPpg.Columns["nSalOtr"].HeaderText = "Saldo otros";
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtgPpg.Columns["nPorcOtros"].HeaderText = "% Max. cond.";
                dtgPpg.Columns["nPorcOtrosEdit"].HeaderText = "% Edit";
            }
            dtgPpg.Columns["nTotalCuota"].HeaderText = "TotCuota";            
            
            //dtgPpg.Columns["nMonCuoIni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPpg.Columns["nSalCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPpg.Columns["nInteresFechaSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresCompPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPpg.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nMoraGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nMoraPagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPpg.Columns["nSalMor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nOtrosPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPpg.Columns["nSalOtr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPpg.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtgPpg.Columns["nPorcCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgPpg.Columns["nPorcCapitalEdit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            dtgPpg.Columns["nPorcInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPpg.Columns["nPorcInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPpg.Columns["nPorcMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgPpg.Columns["nPorcInteresEdit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPpg.Columns["nPorcInteresCompEdit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPpg.Columns["nPorcMoraEdit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtgPpg.Columns["nPorcOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgPpg.Columns["nPorcOtrosEdit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            dtgPpg.Columns["nTotalCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtgPpg.Columns["nPorcCapital"].DefaultCellStyle.ForeColor = Color.Red;
                dtgPpg.Columns["nPorcCapitalEdit"].DefaultCellStyle.ForeColor = Color.Blue;
            }
            dtgPpg.Columns["nPorcInteres"].DefaultCellStyle.ForeColor = Color.Red;
            dtgPpg.Columns["nPorcInteresComp"].DefaultCellStyle.ForeColor = Color.Red;
            dtgPpg.Columns["nPorcMora"].DefaultCellStyle.ForeColor = Color.Red;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtgPpg.Columns["nPorcOtros"].DefaultCellStyle.ForeColor = Color.Red;
                dtgPpg.Columns["nPorcOtrosEdit"].DefaultCellStyle.ForeColor = Color.Blue;
            }
            dtgPpg.Columns["nPorcInteresEdit"].DefaultCellStyle.ForeColor = Color.Blue;
            dtgPpg.Columns["nPorcInteresCompEdit"].DefaultCellStyle.ForeColor = Color.Blue;
            dtgPpg.Columns["nPorcMoraEdit"].DefaultCellStyle.ForeColor = Color.Blue;
            

            //dtgPpg.Columns["nMonCuoIni"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            //dtgPpg.Columns["nSalCap"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresPagado"].DefaultCellStyle.Format = "#,0.00";
            //dtgPpg.Columns["nInteresFechaSaldo"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresCompPago"].DefaultCellStyle.Format = "#,0.00";
            //dtgPpg.Columns["nSalIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nMoraGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nMoraPagada"].DefaultCellStyle.Format = "#,0.00";
            //dtgPpg.Columns["nSalMor"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nOtros"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nOtrosPagado"].DefaultCellStyle.Format = "#,0.00";
            //dtgPpg.Columns["nSalOtr"].DefaultCellStyle.Format = "#,0.00";
            //dtgPpg.Columns["nSalTot"].DefaultCellStyle.Format = "#,0.00";
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                dtgPpg.Columns["nPorcCapital"].DefaultCellStyle.Format = "#0";
                dtgPpg.Columns["nPorcCapitalEdit"].DefaultCellStyle.Format = "#0.00";
            }
            dtgPpg.Columns["nPorcInteres"].DefaultCellStyle.Format = "#0";
            dtgPpg.Columns["nPorcInteresComp"].DefaultCellStyle.Format = "#0";
            dtgPpg.Columns["nPorcMora"].DefaultCellStyle.Format = "#0";
            dtgPpg.Columns["nPorcInteresEdit"].DefaultCellStyle.Format = "#0.00";
            dtgPpg.Columns["nPorcInteresCompEdit"].DefaultCellStyle.Format = "#0.00";
            dtgPpg.Columns["nPorcMoraEdit"].DefaultCellStyle.Format = "#0.00";
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                dtgPpg.Columns["nPorcOtros"].DefaultCellStyle.Format = "#0";
                dtgPpg.Columns["nPorcOtrosEdit"].DefaultCellStyle.Format = "#0.00";
            }
            dtgPpg.Columns["nTotalCuota"].DefaultCellStyle.Format = "#,0.00";

            
        }

        private void llenarDatosDTG()
        {
            decimal porcCapital = -1;
            decimal porcInteres = -1;
            decimal porcIntComp = -1;
            decimal porcMora = -1;
            decimal porcOtros = -1;
            int minDiasAtrazo = 1;
            if (lEsCasoEspecial)
            {
                porcCapital = 0;
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
                    porcCapital = 100;
                porcInteres = 100;
                porcIntComp = 100;
                porcMora = 100;
                porcOtros = 0;
            }
            else
            {
                minDiasAtrazo = clsVarApl.dicVarGen["nMinDiasAtrasoCondonacion"];
                DataGridViewRow item_ = dtgPpg.Rows[0];
                lstTipCond.ForEach(delegate(SI_FinDetalleTipoCondonacion DetTipCond)
                {
                    if (porcInteres == -1)
                    {
                        if ((DetTipCond.nRangoMinimo <= Convert.ToInt32(item_.Cells["nAtrasoCuota"].Value) && Convert.ToInt32(item_.Cells["nAtrasoCuota"].Value) <= DetTipCond.nRangoMaximo) && DetTipCond.idTipoCartera == Convert.ToInt32(item_.Cells["idContable"].Value))
                        {
                            porcCapital = 0;
                            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
                                porcCapital = DetTipCond.nPorcDsctoCapital;
                            porcInteres = DetTipCond.nPorcDsctoInteres;
                            porcIntComp = DetTipCond.nPorcDsctoIntComp;
                            porcMora = DetTipCond.nPorcDsctoMora;
                            porcOtros = DetTipCond.nPorcDsctoGastos;
                        }
                    }
                });
            }

            foreach (DataGridViewRow item in this.dtgPpg.Rows)
            {
                item.Cells["nTotalCuota"].Value = (
                        (Convert.ToDecimal(item.Cells["nSalCap"].Value)) +
                        (Convert.ToDecimal(item.Cells["nInteresFechaSaldo"].Value)) +
                        (Convert.ToDecimal(item.Cells["nSalIntComp"].Value)) +
                        (Convert.ToDecimal(item.Cells["nSalMor"].Value)) +
                        (Convert.ToDecimal(item.Cells["nSalOtr"].Value))
                    ).ToString();
                if (Convert.ToInt32(item.Cells["nAtrasoCuota"].Value) >= minDiasAtrazo)
                {
                    maxRowsAfected++;
                    if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
                    {
                        item.Cells["nCapitalPagado"].Style.BackColor = Color.LightGreen;
                        item.Cells["nPorcCapital"].Value = porcCapital;
                        item.Cells["nPorcCapitalEdit"].Value = porcCapital;
                        //item.Cells["nPorcCapitalEdit"].ReadOnly = false;
                    }
                    item.Cells["nCapitalPagado"].Value = 0.00;

                    item.Cells["nInteresPagado"].Style.BackColor = Color.LightGreen;
                    item.Cells["nInteresPagado"].Value = 0.00;
                    item.Cells["nPorcInteres"].Value = porcInteres;
                    item.Cells["nPorcInteresEdit"].Value = porcInteres;
                    //item.Cells["nPorcInteresEdit"].ReadOnly = false;
                    item.Cells["nInteresCompPago"].Style.BackColor = Color.LightGreen;
                    item.Cells["nInteresCompPago"].Value = 0.00;
                    item.Cells["nPorcInteresComp"].Value = porcIntComp;
                    item.Cells["nPorcInteresCompEdit"].Value = porcIntComp;
                    //item.Cells["nPorcInteresCompEdit"].ReadOnly = false;
                    item.Cells["nMoraPagada"].Style.BackColor = Color.LightGreen;
                    item.Cells["nMoraPagada"].Value = 0.00;
                    item.Cells["nPorcMora"].Value = porcMora;
                    item.Cells["nPorcMoraEdit"].Value = porcMora;
                    //item.Cells["nPorcMoraEdit"].ReadOnly = false;
                    item.Cells["nOtrosPagado"].Value = 0.00;
                    if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
                    {
                        item.Cells["nPorcOtros"].Value = porcOtros;
                        item.Cells["nPorcOtrosEdit"].Value = porcOtros;
                        //item.Cells["nPorcOtrosEdit"].ReadOnly = false;
                    }
                }
            }
        }

        private void CargaDetalleTipoCondonacion()
        {
            //Boolean lAplicaReglas = false;
            if (this.idTipoCondonacion == 1) // caso especial
            {
                this.lEsCasoEspecial = true;                
            }
            else
            {
                DataTable dtReglasCondonacion = SolicCondonacion.listaReglasTipoCondonaXRangoTipoDato(this.idTipoCondonacion, 1);
                lstTipCond = DataTableToList.ConvertTo<SI_FinDetalleTipoCondonacion>(dtReglasCondonacion) as List<SI_FinDetalleTipoCondonacion>;            
            }            
        }
        private void verificaSiVieneXMLcuotas()
        {
            if (!String.IsNullOrEmpty(this.xmlCoutasCondonadas))
            {
                //cambiar los montos de condonacion por los que este en el xml
                var xDoc = XDocument.Parse(this.xmlCoutasCondonadas);

                List<clsCuota> listCronograma;

                listCronograma = (from x in xDoc.Root.Elements("Table1")
                                  select new clsCuota()
                                       {                                           
                                           idCuota = (int)x.Element("idCuota"),
                                           nCapitalPagado = (Decimal)x.Element("nCapitalPagado"),
                                           nInteresPagado = (Decimal)x.Element("nInteresPagado"),
                                           nInteresCompPago = (Decimal)x.Element("nInteresCompPago"),
                                           nMoraPagada = (Decimal)x.Element("nMoraPagada"),
                                           nOtrosPagado = (Decimal)x.Element("nOtrosPagado"),
                                       }).ToList();

                foreach (clsCuota item in listCronograma)
                {
                    int idCouta = item.idCuota;
                    foreach (DataRow row in this.dtPlanPago.Rows)
                    {
                        if (idCouta == Convert.ToInt32(row["idCuota"].ToString()))
                        {
                            row["nCapitalPagado"] = item.nCapitalPagado;
                            row["nInteresPagado"] = item.nInteresPagado;
                            row["nInteresCompPago"] = item.nInteresCompPago;
                            row["nMoraPagada"] = item.nMoraPagada;
                            row["nOtrosPagado"] = item.nOtrosPagado;
                            row["lEditado"] = true;
                        }
                    }                                        
                }
            }
            //sumarCondonacionxCuota();
            //sumarCuotaAPagar();
        }

        private bool verificarDecimal(string nValue)
        {
            decimal d;
            if (decimal.TryParse(nValue, out d))
            {
                return false;
            }

            else
            {
                return true;
            }

        }
/**************************************************************************************************************************************/
        private void sumarCondonacionxCuota()
        {
            Decimal nCapital = 0;
            Decimal nInteres = 0;
            Decimal nInteresComp = 0;
            Decimal nMora = 0;
            Decimal nOtros = 0;

            foreach (DataGridViewRow item in this.dtgPpg.Rows)
            {
                if (!String.IsNullOrEmpty(item.Cells["nPorcCapital"].Value.ToString()))
                {
                    nCapital += Math.Round(Convert.ToDecimal(item.Cells["nCapitalPagado"].Value), 2);
                }
                if (!String.IsNullOrEmpty(item.Cells["nPorcInteres"].Value.ToString()))
                {
                    nInteres += Math.Round(Convert.ToDecimal(item.Cells["nInteresPagado"].Value), 2);
                }
                if (!String.IsNullOrEmpty(item.Cells["nPorcInteresComp"].Value.ToString()))
                {
                    nInteresComp += Math.Round(Convert.ToDecimal(item.Cells["nInteresCompPago"].Value), 2);
                }
                if (!String.IsNullOrEmpty(item.Cells["nPorcMora"].Value.ToString()))
                {
                    nMora += Math.Round(Convert.ToDecimal(item.Cells["nMoraPagada"].Value), 2);
                }
                if (!String.IsNullOrEmpty(item.Cells["nPorcOtros"].Value.ToString()))
                {
                    nOtros += Math.Round(Convert.ToDecimal(item.Cells["nOtrosPagado"].Value), 2);
                }
            }
            this.txtCapital.Text = nCapital.ToString("N2");
            this.txtInteres.Text = nInteres.ToString("N2");
            this.txtInteresComp.Text = nInteresComp.ToString("N2");
            this.txtMora.Text = nMora.ToString("N2");
            this.txtOtros.Text = nOtros.ToString("N2");

            calcularTotal();
        }
        #endregion
/*******************************************************************************************************************************************************/
        private void cuotasCubiertas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Convert.ToInt32(cuotasCubiertas.Text) > maxRowsAfected)
                {
                    MessageBox.Show("Número de Cuotas excede al permitido", "Numero de Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cuotasCubiertas.Text = maxRowsAfected.ToString();
                }

                actualizarMontoCondonarPagar();
            }
        }

        private void actualizarMontoCondonarPagar(bool lActualizarMonto = true)
        {
            nMontoCondonarTmp = 0;
            int cuotas = Convert.ToInt32(cuotasCubiertas.Text);
            foreach (DataGridViewRow item in this.dtgPpg.Rows)
            {
                if (cuotas == 0)
                    break;
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
                {
                    nMontoCondonarTmp += TruncateDecimal((Convert.ToDecimal(item.Cells["nSalCap"].Value) * Convert.ToDecimal(item.Cells["nPorcCapital"].Value)/100),2);
                }
                nMontoCondonarTmp += TruncateDecimal((Convert.ToDecimal(item.Cells["nInteresFechaSaldo"].Value) * Convert.ToDecimal(item.Cells["nPorcInteres"].Value) / 100),2);
                nMontoCondonarTmp += TruncateDecimal((Convert.ToDecimal(item.Cells["nSalIntComp"].Value) * Convert.ToDecimal(item.Cells["nPorcInteresComp"].Value) / 100),2);
                nMontoCondonarTmp += TruncateDecimal((Convert.ToDecimal(item.Cells["nSalMor"].Value) * Convert.ToDecimal(item.Cells["nPorcMora"].Value) / 100),2);
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
                {
                    nMontoCondonarTmp += TruncateDecimal((Convert.ToDecimal(item.Cells["nSalOtr"].Value) * Convert.ToDecimal(item.Cells["nPorcOtros"].Value) / 100),2);
                }
                cuotas--;
            }
            
            if(lActualizarMonto)
                txtTotalCondonar.Text = nMontoCondonarTmp.ToString();

            maxCondonar.Text = nMontoCondonarTmp.ToString();
        }

        private void distribuirCondonacion()
        {
            int cuotas = Convert.ToInt32(cuotasCubiertas.Text);
            cuotasReal = cuotas;
            nCapital = 0;
            nInteres = 0;
            nInteresComp = 0;
            nMora = 0;
            nOtros = 0;
            Decimal nCondonar = Convert.ToDecimal(txtTotalCondonar.Text);
            Decimal monto = 0;
            Decimal nPagar = 0;
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
            {
                for (int i = 0; i < cuotas; i++)
                {
                    monto = TruncateDecimal(Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalOtr"].Value) * Convert.ToDecimal(dtgPpg.Rows[i].Cells["nPorcOtros"].Value) / 100, 2);
                    if (nCondonar <= monto || nCondonar == 0)
                        monto = nCondonar;
                    dtgPpg.Rows[i].Cells["nOtrosPagado"].Value = monto;
                    Decimal porc = 100;
                    if (Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalOtr"].Value) != 0)
                        porc = monto*100 / Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalOtr"].Value);
                    dtgPpg.Rows[i].Cells["nPorcOtrosEdit"].Value = porc;
                    nOtros += monto;
                    nCondonar -= monto;
                }
            }
            for (int i = 0; i < cuotas; i++)
            {
                monto = TruncateDecimal(Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalMor"].Value) * Convert.ToDecimal(dtgPpg.Rows[i].Cells["nPorcMora"].Value) / 100, 2);
                if (nCondonar <= monto || nCondonar == 0)
                    monto = nCondonar;
                dtgPpg.Rows[i].Cells["nMoraPagada"].Value = monto;
                Decimal porc = 100;
                if (Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalMor"].Value) != 0)
                    porc = monto * 100 / Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalMor"].Value);
                dtgPpg.Rows[i].Cells["nPorcMoraEdit"].Value = porc;
                nMora += monto;
                nCondonar -= monto;
            }
            for (int i = 0; i < cuotas; i++)
            {
                monto = TruncateDecimal(Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalIntComp"].Value) * Convert.ToDecimal(dtgPpg.Rows[i].Cells["nPorcInteresComp"].Value) / 100, 2);
                if (nCondonar <= monto || nCondonar == 0)
                    monto = nCondonar;
                dtgPpg.Rows[i].Cells["nInteresCompPago"].Value = monto;
                Decimal porc = 100;
                if (Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalIntComp"].Value) != 0)
                    porc = monto * 100 / Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalIntComp"].Value);
                dtgPpg.Rows[i].Cells["nPorcInteresCompEdit"].Value = porc;
                nInteresComp += monto;
                nCondonar -= monto;
            }
            for (int i = 0; i < cuotas; i++)
            {
                monto = TruncateDecimal(Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalInt"].Value) * Convert.ToDecimal(dtgPpg.Rows[i].Cells["nPorcInteres"].Value) / 100, 2);
                if (nCondonar <= monto || nCondonar == 0)
                    monto = nCondonar;
                dtgPpg.Rows[i].Cells["nInteresPagado"].Value = monto;
                Decimal porc = 100;
                if (Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalInt"].Value) != 0)
                    porc = monto * 100 / Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalInt"].Value);
                dtgPpg.Rows[i].Cells["nPorcInteresEdit"].Value = porc;
                nInteres += monto;
                nCondonar -= monto;
            }
            if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
            {
                for (int i = 0; i < cuotas; i++)
                {
                    monto = TruncateDecimal(Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalCap"].Value) * Convert.ToDecimal(dtgPpg.Rows[i].Cells["nPorcCapital"].Value) / 100, 2);
                    if (nCondonar <= monto || nCondonar == 0)
                        monto = nCondonar;
                    dtgPpg.Rows[i].Cells["nCapitalPagado"].Value = monto;
                    Decimal porc = 100;
                    if (Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalCap"].Value) != 0)
                        porc = monto * 100 / Convert.ToDecimal(dtgPpg.Rows[i].Cells["nSalCap"].Value);
                    dtgPpg.Rows[i].Cells["nPorcCapitalEdit"].Value = porc;
                    nCapital += monto;
                    nCondonar -= monto;
                }
            }
            txtOtros.Text = nOtros.ToString();
            txtMora.Text = nMora.ToString();
            txtInteresComp.Text = nInteresComp.ToString();
            txtInteres.Text = nInteres.ToString();
            txtCapital.Text = nCapital.ToString();
            for (int i = 0; i < cuotas; i++)
            {
                nPagar += Convert.ToDecimal(dtgPpg.Rows[i].Cells["nTotalCuota"].Value);
                dtgPpg.Rows[i].Cells["lEditado"].Value = true;
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
                {
                    dtgPpg.Rows[i].Cells["nCapitalPagado"].Style.BackColor = Color.LightPink;
                }
                dtgPpg.Rows[i].Cells["nInteresPagado"].Style.BackColor = Color.LightPink;
                dtgPpg.Rows[i].Cells["nInteresCompPago"].Style.BackColor = Color.LightPink;
                dtgPpg.Rows[i].Cells["nMoraPagada"].Style.BackColor = Color.LightPink;
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
                {
                    dtgPpg.Rows[i].Cells["nOtrosPagado"].Style.BackColor = Color.LightPink;
                }
            }
            txtTotalPagar.Text = (nPagar-Convert.ToDecimal(txtTotalCondonar.Text)).ToString();
            cargaITF();
            /*******************************/
            for (int i = cuotas; i < maxRowsAfected; i++)
            {
                dtgPpg.Rows[i].Cells["lEditado"].Value = false;
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaCapitalXCuota"])))
                {
                    dtgPpg.Rows[i].Cells["nCapitalPagado"].Value = 0;
                    dtgPpg.Rows[i].Cells["nCapitalPagado"].Style.BackColor = Color.LightSeaGreen;
                    dtgPpg.Rows[i].Cells["nPorcCapitalEdit"].Value = 0;
                }
                dtgPpg.Rows[i].Cells["nInteresPagado"].Value = 0;
                dtgPpg.Rows[i].Cells["nPorcInteresEdit"].Value = 0;
                dtgPpg.Rows[i].Cells["nInteresCompPago"].Value = 0;
                dtgPpg.Rows[i].Cells["nPorcInteresCompEdit"].Value = 0;
                dtgPpg.Rows[i].Cells["nMoraPagada"].Value = 0;
                dtgPpg.Rows[i].Cells["nPorcMoraEdit"].Value = 0;

                /*******/
                dtgPpg.Rows[i].Cells["nInteresPagado"].Style.BackColor = Color.LightGreen;
                dtgPpg.Rows[i].Cells["nInteresCompPago"].Style.BackColor = Color.LightGreen;
                dtgPpg.Rows[i].Cells["nMoraPagada"].Style.BackColor = Color.LightGreen;
                /********/
                if (Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["condonaOtrosXCuota"])))
                {
                    dtgPpg.Rows[i].Cells["nOtrosPagado"].Value = 0;
                    dtgPpg.Rows[i].Cells["nOtrosPagado"].Style.BackColor = Color.LightGreen;
                    dtgPpg.Rows[i].Cells["nPorcOtrosEdit"].Value = 0;
                }
            }
            
        }

        public decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }

        private void cargaITF()
        {
            decimal nMonPago = Convert.ToDecimal(txtTotalPagar.Text);
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, idMonedaGral);

            if (Math.Round(nITF, 2) > 0)
            {
                grbITF.Visible = true;
                this.txtITF.Text = Math.Round(nITF, 2).ToString();
            }
            else
            {
                grbITF.Visible = false;
                this.txtITF.Text = "0".ToString();
            }

        }

        private void habilitarControles(bool lEditar_, string cControl)
        {
            btnAceptar1.Enabled = !lEditar_;
            cuotasCubiertas.Enabled = false;
            txtTotalCondonar.Enabled = false;

            if (cControl == "cuota")
            {
                cuotasCubiertas.Enabled = true;
            }

            if (cControl == "condona")
            {
                txtTotalCondonar.Enabled = true;
            }
        }

        private void btnMiniEditarCuotas_Click(object sender, EventArgs e)
        {
            habilitarControles(true, "cuota");
        }

        private void btnMiniEditarTotCondonar_Click(object sender, EventArgs e)
        {
            habilitarControles(true, "condona");
        }

        private void btnDistribuir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cuotasCubiertas.Text) > maxRowsAfected)
            {
                MessageBox.Show("Número de Cuotas excede al permitido", "Numero de Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cuotasCubiertas.Text = maxRowsAfected.ToString();
                return;
            }

            actualizarMontoCondonarPagar(false);

            if (Convert.ToDecimal(txtTotalCondonar.Text) > Convert.ToDecimal(maxCondonar.Text))
            {
                MessageBox.Show("Monto a Condonar excede al Máximo a Condonar para este Número de Cuotas", "Monto a Condonar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTotalCondonar.Text = maxCondonar.Text;
                return;
            }

            distribuirCondonacion();
            grbDetCondo.Enabled = false;
            btnAceptar1.Enabled = true;
            btnDistribuir.Enabled = false;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            grbDetCondo.Enabled = true;
            btnAceptar1.Enabled = false;
            btnDistribuir.Enabled = true;
        }
    }
}