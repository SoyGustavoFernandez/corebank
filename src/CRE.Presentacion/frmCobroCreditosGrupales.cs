using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using DEP.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.PrintHelper;
using GEN.Funciones;
using System.Drawing.Printing;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using SPL.Presentacion;
//using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCobroCreditosGrupales : frmBase
    {

        #region Variables Globales
        clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
        public const int idTipoOperacion = 2;
        public DataTable dtCredito = new DataTable("dtCredito");
        public DataTable dtPlanPago = new DataTable("dtPlanPago");
        public DataTable dtOrdenPrelacion = new DataTable("dtOrdenPrelacion");
        public string pcTipoBusqueda;
        public string pnEstadoCredito;
        string cEstadoForm = "E";
        decimal nITFNormal = 0;
        bool lCargoPlanPagos = false;
        bool lCargoKardexPagos = false;
        clsFunUtiles objFunciones = new clsFunUtiles();
        CRE.CapaNegocio.clsCNCredito cnCredito = new CRE.CapaNegocio.clsCNCredito();
        private DataTable dtGrupoSolidarioAlerta = new DataTable();

        private const int idTipoOpeRegimenReforzado = 169;

        private DataTable dtCobs;

        int idTipoOperacionCOBs = 7;
        int idSolicitud = 0;

        int idSolGS = 0;
        int idModalidadCredito = 0;
        string cTitulo = "Cobro de Créditos Grupales";
        DataTable dtPagos;
        #endregion

        #region Var Global 2
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        int idCuenta = 0;
        decimal dMontoTotal;
        decimal dMontoTotalConRedondeo;
        decimal dMontoTotalTmp;
        decimal dMontoTotalTmp2;
        decimal dMontoTotalRedondeo;
        int nElimina = 0;
        decimal dRedondeoPago = 0.00m;
        decimal dItf = 0.00m;
        string txtMCCapital="";
        string txtMCInteres="";
        string txtMCIntComp="";
        string txtMCMora   ="";
        string txtMCOtros = "";
        string txtRedondeo="";
        string txtImpuestos = "";
        
        int idVoucher = 0;
        int nBloqueoActivo = 0;
        private conDatosReprogramacion conDatosReprog = new conDatosReprogramacion();
        #endregion


        public frmCobroCreditosGrupales()
        {
            InitializeComponent();
            btnGrabar1.Enabled = false;
            txtBase1.Enabled = false;
            txtBase6.Enabled = false;
            txtBase2.Enabled = false;
            this.conBusGrupoSol.LimpiarControl();
            
            cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedValue = 5;
          
            GEN.CapaNegocio.clsCNTipoPago TipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable dtTipoPago = TipoPago.CNListarTipPagCredito();

            cboTipoPago.DataSource = dtTipoPago;
            cboTipoPago.ValueMember = dtTipoPago.Columns["idTipoPago"].ToString();
            cboTipoPago.DisplayMember = dtTipoPago.Columns["cDesTipoPago"].ToString();

            conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));
            this.txtBase2.Text = "0.00";
            this.checkBox1.Checked = true;
        }
        
        
        #region Eventos

     

        //private void tbpPpg_Enter(object sender, EventArgs e)
        private void CargarPlanPagos()
        {
            int nNumCredito = idCuenta;//this.conBusCuentaCli.nValBusqueda;

            if (nNumCredito <= 0)
            {
                return;
            }
            
            // Cargar el Plan de Pagos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable ListPlanPago = PlanPago.CNdtPlanPagPosi(nNumCredito);

            ////========================= Redondeo del Monto A pagar===================================================
            //foreach (DataColumn item in ListPlanPago.Columns)
            //{
            //    item.ReadOnly = false;
            //}

            //for (int i = 0; i < ListPlanPago.Rows.Count; i++)
            //{
            //    ListPlanPago.Rows[i]["nSalTot"] = Math.Round(Convert.ToDecimal (ListPlanPago.Rows[i]["nSalTot"]), 1);
            //}

            //foreach (DataColumn item in ListPlanPago.Columns)
            //{
            //    item.ReadOnly = true;
            //}
            //============================================================================
            dtgPpg.DataSource = ListPlanPago;
            FormatoPlanPagos();
            
        }

        //private void tbpKardex_Enter(object sender, EventArgs e)
        private void CargarKardex()
        {
            int nNumCredito = idCuenta;//this.conBusCuentaCli.nValBusqueda;

            if (nNumCredito <= 0)
            {
                return;
            }

           

            // cargar el kardex
            CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
            DataTable Listkardex = Credito.CNdtLisKardexCre(nNumCredito);
            dtgKardex.DataSource = Listkardex;
            FormatoKardexpago();

          
        }

  
     
        #endregion

        #region Metodos



        private DataTable ArmarTablaParametros()//Armar los parametros para validar que el usuario del Sistema no sea el mismo que pague sus cuotas
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = Convert.ToString(idCuenta);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void FormatoKardexpago()
        {
            foreach (DataGridViewColumn item in dtgKardex.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgKardex.Columns["NumOrdPag"].Visible = true;
            dtgKardex.Columns["dFechaOpe"].Visible = true;
            dtgKardex.Columns["nAtrasoPago"].Visible = true;
            dtgKardex.Columns["nMontoOperacion"].Visible = true;
            dtgKardex.Columns["nMontoCapital"].Visible = true;
            dtgKardex.Columns["nMontoInteres"].Visible = true;
            dtgKardex.Columns["nMontoIntComp"].Visible = true;
            dtgKardex.Columns["nMontoMora"].Visible = true;
            dtgKardex.Columns["nMontoOtros"].Visible = true;
            dtgKardex.Columns["nSaldoCap"].Visible = true;
            dtgKardex.Columns["cWinUser"].Visible = true;
            dtgKardex.Columns["cNombreAge"].Visible = true;
            dtgKardex.Columns["cTipoOperacion"].Visible = true;
            dtgKardex.Columns["cMotivoOperacion"].Visible = true;
            dtgKardex.Columns["cDesTipoPago"].Visible = true;
            dtgKardex.Columns["idKardex"].Visible = true;
            dtgKardex.Columns["cNomPersOpe"].Visible = true;


            dtgKardex.Columns["NumOrdPag"].HeaderText = "Nro";
            dtgKardex.Columns["dFechaOpe"].HeaderText = "Fech. ope.";
            dtgKardex.Columns["nAtrasoPago"].HeaderText = "Dias atraso";
            dtgKardex.Columns["nMontoOperacion"].HeaderText = "Monto ope.";
            dtgKardex.Columns["nMontoCapital"].HeaderText = "Monto cap.";
            dtgKardex.Columns["nMontoInteres"].HeaderText = "Monto int.";
            dtgKardex.Columns["nMontoIntComp"].HeaderText = "Monto int. comp.";
            dtgKardex.Columns["nMontoMora"].HeaderText = "Monto mora";
            dtgKardex.Columns["nMontoOtros"].HeaderText = "Monto otros";
            dtgKardex.Columns["nSaldoCap"].HeaderText = "Saldo capital";
            dtgKardex.Columns["cWinUser"].HeaderText = "Usuario";
            dtgKardex.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgKardex.Columns["cTipoOperacion"].HeaderText = "Operación";
            dtgKardex.Columns["cMotivoOperacion"].HeaderText = "Mod. operación";
            dtgKardex.Columns["cDesTipoPago"].HeaderText = "Tipo pago";
            dtgKardex.Columns["idKardex"].HeaderText = "Nro. ope.";
            dtgKardex.Columns["cNomPersOpe"].HeaderText = "Persona operación";

            dtgKardex.Columns["NumOrdPag"].DisplayIndex = 0;
            dtgKardex.Columns["idKardex"].DisplayIndex = 1;
            dtgKardex.Columns["cTipoOperacion"].DisplayIndex = 2;
            dtgKardex.Columns["cMotivoOperacion"].DisplayIndex = 3;
            dtgKardex.Columns["dFechaOpe"].DisplayIndex = 4;
            dtgKardex.Columns["nAtrasoPago"].DisplayIndex = 5;
            dtgKardex.Columns["nMontoOperacion"].DisplayIndex = 6;
            dtgKardex.Columns["nMontoCapital"].DisplayIndex = 7;
            dtgKardex.Columns["nMontoInteres"].DisplayIndex = 8;
            dtgKardex.Columns["nMontoIntComp"].DisplayIndex = 9;
            dtgKardex.Columns["nMontoMora"].DisplayIndex = 10;
            dtgKardex.Columns["nMontoOtros"].DisplayIndex = 11;
            dtgKardex.Columns["nSaldoCap"].DisplayIndex = 12;
            dtgKardex.Columns["cNomPersOpe"].DisplayIndex = 13;
            dtgKardex.Columns["cWinUser"].DisplayIndex = 14;
            dtgKardex.Columns["cNombreAge"].DisplayIndex = 15;
            dtgKardex.Columns["cDesTipoPago"].DisplayIndex = 16;

            dtgKardex.Columns["nMontoOperacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgKardex.Columns["nMontoOperacion"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoMora"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoOtros"].DefaultCellStyle.Format = "#,0.00";
        }

        private void FormatoPlanPagos()
        {
            foreach (DataGridViewColumn item in dtgPpg.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPpg.Columns["idCuota"].Visible = true;
            dtgPpg.Columns["dFechaProg"].Visible = true;
            dtgPpg.Columns["dFechaPago"].Visible = true;
            dtgPpg.Columns["nAtrasoCuota"].Visible = true;
            dtgPpg.Columns["nNumDiaCuota"].Visible = true;
            dtgPpg.Columns["nMonCuoIni"].Visible = true;
            dtgPpg.Columns["EstadoCuota"].Visible = true;
            dtgPpg.Columns["nCapital"].Visible = true;
            dtgPpg.Columns["nCapitalPagado"].Visible = true;
            dtgPpg.Columns["nSalCap"].Visible = true;
            dtgPpg.Columns["nInteres"].Visible = true;
            dtgPpg.Columns["nInteresPagado"].Visible = true;
            dtgPpg.Columns["nSalInt"].Visible = true;
            dtgPpg.Columns["nInteresComp"].Visible = true;
            dtgPpg.Columns["nInteresCompPago"].Visible = true;
            dtgPpg.Columns["nSalIntComp"].Visible = true;
            dtgPpg.Columns["nMoraGenerado"].Visible = true;
            dtgPpg.Columns["nMoraPagada"].Visible = true;
            dtgPpg.Columns["nSalMor"].Visible = true;
            dtgPpg.Columns["nOtros"].Visible = true;
            dtgPpg.Columns["nOtrosPagado"].Visible = true;
            dtgPpg.Columns["nSalOtr"].Visible = true;
            dtgPpg.Columns["nSalTot"].Visible = true;

            dtgPpg.Columns["idCuota"].HeaderText = "Nro";
            dtgPpg.Columns["dFechaProg"].HeaderText = "Fecha prog.";
            dtgPpg.Columns["dFechaPago"].HeaderText = "Fecha pag.";
            dtgPpg.Columns["nAtrasoCuota"].HeaderText = "Dias atr. cuo.";
            dtgPpg.Columns["nNumDiaCuota"].HeaderText = "Dias cuota";
            dtgPpg.Columns["nMonCuoIni"].HeaderText = "Monto cuota";
            dtgPpg.Columns["EstadoCuota"].HeaderText = "Estado";
            dtgPpg.Columns["nCapital"].HeaderText = "Capital";
            dtgPpg.Columns["nCapitalPagado"].HeaderText = "Cap. pag.";
            dtgPpg.Columns["nSalCap"].HeaderText = "Saldo cap.";
            dtgPpg.Columns["nInteres"].HeaderText = "Int.";
            dtgPpg.Columns["nInteresPagado"].HeaderText = "Int. pag.";
            dtgPpg.Columns["nSalInt"].HeaderText = "Saldo int.";
            dtgPpg.Columns["nInteresComp"].HeaderText = "Int. comp.";
            dtgPpg.Columns["nInteresCompPago"].HeaderText = "Int. comp. pag.";
            dtgPpg.Columns["nSalIntComp"].HeaderText = "Saldo int. comp.";
            dtgPpg.Columns["nMoraGenerado"].HeaderText = "Mora. gen.";
            dtgPpg.Columns["nMoraPagada"].HeaderText = "Mora. pag.";
            dtgPpg.Columns["nSalMor"].HeaderText = "Saldo mora";
            dtgPpg.Columns["nOtros"].HeaderText = "Otros";
            dtgPpg.Columns["nOtrosPagado"].HeaderText = "Otros pag.";
            dtgPpg.Columns["nSalOtr"].HeaderText = "Saldo otros";
            dtgPpg.Columns["nSalTot"].HeaderText = "Saldo total";


            dtgPpg.Columns["idCuota"].DisplayIndex = 0;
            dtgPpg.Columns["dFechaProg"].DisplayIndex = 1;
            dtgPpg.Columns["dFechaPago"].DisplayIndex = 2;
            dtgPpg.Columns["nAtrasoCuota"].DisplayIndex = 3;
            dtgPpg.Columns["nNumDiaCuota"].DisplayIndex = 4;
            dtgPpg.Columns["nMonCuoIni"].DisplayIndex = 5;
            dtgPpg.Columns["EstadoCuota"].DisplayIndex = 6;
            dtgPpg.Columns["nCapital"].DisplayIndex = 7;
            dtgPpg.Columns["nCapitalPagado"].DisplayIndex = 8;
            dtgPpg.Columns["nSalCap"].DisplayIndex = 9;
            dtgPpg.Columns["nInteres"].DisplayIndex = 10;
            dtgPpg.Columns["nInteresPagado"].DisplayIndex = 11;
            dtgPpg.Columns["nSalInt"].DisplayIndex = 12;
            dtgPpg.Columns["nInteresComp"].DisplayIndex = 13;
            dtgPpg.Columns["nInteresCompPago"].DisplayIndex = 14;
            dtgPpg.Columns["nSalIntComp"].DisplayIndex = 15;
            dtgPpg.Columns["nMoraGenerado"].DisplayIndex = 16;
            dtgPpg.Columns["nMoraPagada"].DisplayIndex = 17;
            dtgPpg.Columns["nSalMor"].DisplayIndex = 18;
            dtgPpg.Columns["nOtros"].DisplayIndex = 19;
            dtgPpg.Columns["nOtrosPagado"].DisplayIndex = 20;
            dtgPpg.Columns["nSalOtr"].DisplayIndex = 21;
            dtgPpg.Columns["nSalTot"].DisplayIndex = 22;

            dtgPpg.Columns["nMonCuoIni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalInt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresCompPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nMoraGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nMoraPagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalMor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nOtrosPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalOtr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgPpg.Columns["nMonCuoIni"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalCap"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalInt"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresCompPago"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nMoraGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nMoraPagada"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalMor"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nOtros"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nOtrosPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalOtr"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalTot"].DefaultCellStyle.Format = "#,0.00";
        }

        private void EmitirVoucher(DataTable dtDatosCobro, int idKardex)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal.ToString(), false));
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));

            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }
        
        #endregion

    

        #region Cambios POl


        private void CargarPlanGrupal(int idGrupoSol, int idSolicitudGS)
        {
            if (idSolicitudGS == 0)
            {
                MessageBox.Show("El grupo no tiene alguna solicitud activa o no se selecciono una solicitud.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

          

            DataTable dtPlanPagosGrupal = new clsCNPlanPago().CNdtPlanPagoGrupal(idGrupoSol,idSolicitudGS);
            
            this.dtgBase1.DataSource = dtPlanPagosGrupal;
            dtPagos = dtPlanPagosGrupal;
            if (nElimina != 1)
            {
                AgregarCampoCheck();
                nElimina = 1;
            }
             FormatearDataGrid();
             this.conBusGrupoSol.btnBusqueda.Enabled = false;

             DataTable dtPresi = new clsCNPlanPago().CNdtBuscarPresi(idSolicitudGS);

             //if (ValidarBloqueo(Convert.ToInt32(dtPlanPagosGrupal.Rows[0]["idCuenta"].ToString())))
             //{



                 conDatPerReaOperac.txtDocIdePerson.Text = (dtPresi.Rows.Count > 0) ? dtPresi.Rows[0]["cDocumentoID"].ToString() : String.Empty;
                 MarcarTodos(true);
                 //validar cuenta
                 foreach (DataGridViewRow row in dtgBase1.Rows)
                 {

                     int idCuentaBloq = Convert.ToInt32(row.Cells["idCuenta"].Value);
                     if (!ValidarBloqueo(idCuentaBloq))
                     {
                         nBloqueoActivo = 0;
                         Reiniciar();

                         return;
                     }

                 }


                 // Bloquear Cuentas
                 foreach (DataGridViewRow row in dtgBase1.Rows)
                 {

                     int idCuentaBloq = Convert.ToInt32(row.Cells["idCuenta"].Value);
                     BloquearCuenta(idCuentaBloq);
                     nBloqueoActivo = 1;

                 }
             //}
             //return;


                //Validar Créditos pagados
                 foreach (DataGridViewRow row in dtgBase1.Rows)
                 {
                     int nMontoSinRedondeo = Convert.ToInt32(row.Cells["nMonto"].Value);
                     int nMontoTotalPago = Convert.ToInt32(row.Cells["nCapitalxPagar"].Value);
                       if (nMontoSinRedondeo == 0 || nMontoTotalPago == 0 )
                       {
                           row.Cells["chk"].Value = 0;
                       }
                 }

            List<int> lstCuenta = new List<int>();
            lstCuenta = dtPlanPagosGrupal.AsEnumerable().Select(item => item.Field<int>("idCuenta")).ToList();
            conDatosReprog.cargarComponentes(lstCuenta, true, false);

        }
        private void AgregarCampoCheck()
        {
             //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["nPagoAct"];
              
                dtgBase1.Columns.Add(chk);
                chk.HeaderText = "Sel.";
                chk.Name = "chk";
        }
        private void QuitarCampoCheck()
        {
            //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["nPagoAct"];
            dtgBase1.Columns.Remove(chk);
            
        }
        private void MarcarTodos(bool Cambio) 
        {
            this.txtBase1.Text = "";
          
            dMontoTotalTmp = 0.00m;
            //if (Cambio)
            //{
            dMontoTotalTmp2=0.00m;
            dMontoTotalRedondeo = 0.00m;
            this.txtBase2.Text = "0.00";
                foreach (DataGridViewRow row in dtgBase1.Rows)
                {
                    row.Cells[chk.Name].Value = Cambio;
                    if (Cambio)
                    {
                        
                        decimal dMontoTmp;
                        decimal dMontoTmpRedondeo;

                        decimal dMontoTotalTmpRedondeo;

                        dMontoTmp = Convert.ToDecimal(RetornaMontoPago(row.Index));

                        //redondeo preprocesamiento
                        string txtMCTotalPago = calcularTotal(dMontoTmp);
                        dMontoTmpRedondeo = Convert.ToDecimal(txtMCTotalPago);
                        dMontoTotalTmpRedondeo = (dMontoTmp + Convert.ToDecimal(calcularItf(dMontoTmp))) - dMontoTmpRedondeo;
                        dMontoTmp = dMontoTmpRedondeo;

                        dMontoTotalTmp += dMontoTmp;

                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;

                        this.txtBase1.Text = Convert.ToString(dMontoTotalTmp);
                        //END

                        //PAGOS NETOS
                        decimal dMontoTmp2;

                        dMontoTmp2 = Convert.ToDecimal(RetornaMontoPago(row.Index));
                        dMontoTotalTmp2 += dMontoTmp2;
                        // end

                        // redondeo 
                        dMontoTotalRedondeo += dMontoTotalTmpRedondeo;

                        // end

                        string txtItf = calcularItf(dMontoTmp);
                        decimal n = SumarITF(Convert.ToDecimal(txtItf));
                        this.txtBase2.Text = Convert.ToString(n);
                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp + n;
                        this.btnGrabar1.Enabled = true;

                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;// +n;

                        this.txtBase6.Text = Convert.ToString(conCalcVuelto1.nMontoTotalpago.ToString());

                        this.txtBase7.Text = Convert.ToString(dMontoTotalTmp2);
                        this.txtBase3.Text = Convert.ToString(dMontoTotalRedondeo);

                    }

                    else
                    {
                        decimal dMontoTmp;
                        decimal dMontoTmpRedondeo;

                        decimal dMontoTotalTmpRedondeo;

                        dMontoTmp = Convert.ToDecimal(RetornaMontoPago(row.Index));

                        //redondeo preprocesamiento
                        string txtMCTotalPago = calcularTotal(dMontoTmp);
                        dMontoTmpRedondeo = Convert.ToDecimal(txtMCTotalPago);
                        dMontoTotalTmpRedondeo = (dMontoTmp + Convert.ToDecimal(calcularItf(dMontoTmp))) - dMontoTmpRedondeo;
                        dMontoTmp = dMontoTmpRedondeo;

                        dMontoTotalTmp += dMontoTmp;

                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;

                        this.txtBase1.Text = Convert.ToString(dMontoTotalTmp);
                        //END

                        //PAGOS NETOS
                        decimal dMontoTmp2;

                        dMontoTmp2 = Convert.ToDecimal(RetornaMontoPago(row.Index));
                        dMontoTotalTmp2 += dMontoTmp2;
                        // end

                        // redondeo 
                        dMontoTotalRedondeo -= dMontoTotalTmpRedondeo;

                        // end

                        string txtItf = calcularItf(dMontoTmp);
                        decimal n = SumarITF(Convert.ToDecimal(txtItf));
                        this.txtBase2.Text = Convert.ToString(n);
                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp + n;
                        this.btnGrabar1.Enabled = true;

                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;// + n;

                        this.txtBase6.Text = Convert.ToString(conCalcVuelto1.nMontoTotalpago.ToString());

                        this.txtBase7.Text = Convert.ToString(dMontoTotalTmp2);
                        this.txtBase3.Text = Convert.ToString(dMontoTotalRedondeo);
                    }
                    /*****************
                     * Validar Créditos pagados
                     * ********/
                    int nMontoSinRedondeo = Convert.ToInt32(row.Cells["nMonto"].Value);
                    int nMontoTotalPago = Convert.ToInt32(row.Cells["nCapitalxPagar"].Value);

                    if (nMontoSinRedondeo == 0 || nMontoTotalPago == 0)
                    {
                        row.Cells[chk.Name].Value = 0;
                    }
                    
                }
                this.dtgKardex.DataSource = null;
                this.dtgPpg.DataSource = null;
            //}
            //else
            //{
           
            //    foreach (DataGridViewRow row in dtgBase1.Rows)
            //    {
            //        row.Cells[chk.Name].Value = Cambio;
            //    }
            //    this.txtBase7.Text = null;
            //    this.txtBase3.Text = null;
            //    this.txtBase1.Text = null;
            //    this.txtBase2.Text = "0.00";
            //    conCalcVuelto1.nMontoTotalpago = 0.00m;
            //    dMontoTotalTmp2=0.00m;
            //    dMontoTotalRedondeo = 0.00m;
           
           
            //}



        }
        
        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         
            }

            dtgBase1.Columns["idCuenta"].DisplayIndex = 0;
            dtgBase1.Columns["cNombre"].DisplayIndex = 1;
            dtgBase1.Columns["nCapitalDesembolso"].DisplayIndex = 2;
            dtgBase1.Columns["nMonto"].DisplayIndex = 3;
            dtgBase1.Columns["nCuotasPagadas"].DisplayIndex = 4;
            dtgBase1.Columns["nAtraso"].DisplayIndex = 5;
            dtgBase1.Columns["nCapitalPagado"].DisplayIndex = 6;
            dtgBase1.Columns["nCapitalxPagar"].DisplayIndex = 7;
            dtgBase1.Columns["chk"].DisplayIndex = 8;

            dtgBase1.Columns["idCuenta"].Visible = true;
            dtgBase1.Columns["cNombre"].Visible = true;
            dtgBase1.Columns["nCapitalDesembolso"].Visible = true;
            dtgBase1.Columns["nMonto"].Visible = true;
            dtgBase1.Columns["nCuotasPagadas"].Visible = true;
            dtgBase1.Columns["nAtraso"].Visible = true;
            dtgBase1.Columns["nCapitalPagado"].Visible = true;
            dtgBase1.Columns["nCapitalxPagar"].Visible = true;
            dtgBase1.Columns["chk"].Visible = true;


            dtgBase1.Columns["idCuenta"].HeaderText = "N° Cuenta";
            dtgBase1.Columns["cNombre"].HeaderText = "Nombre de Cliente";
            dtgBase1.Columns["nCapitalDesembolso"].HeaderText = "Cap. Desemb.";
            dtgBase1.Columns["nMonto"].HeaderText = "Monto a Pagar";
            dtgBase1.Columns["nCuotasPagadas"].HeaderText = "Cuotas Pagadas";
            dtgBase1.Columns["nAtraso"].HeaderText = "Atraso";
            dtgBase1.Columns["nCapitalPagado"].HeaderText = "Cap. Pagado";
            dtgBase1.Columns["nCapitalxPagar"].HeaderText = "Cap. por Pagar";
            dtgBase1.Columns["chk"].HeaderText = "Sel.";


            dtgBase1.Columns["idCuenta"].FillWeight = 25;
            dtgBase1.Columns["cNombre"].FillWeight = 100;
            dtgBase1.Columns["nCapitalDesembolso"].FillWeight = 35;
            dtgBase1.Columns["nMonto"].FillWeight = 35;
            dtgBase1.Columns["nCuotasPagadas"].FillWeight = 30;
            dtgBase1.Columns["nAtraso"].FillWeight = 20;
            dtgBase1.Columns["nCapitalPagado"].FillWeight = 35;
            dtgBase1.Columns["nCapitalxPagar"].FillWeight = 35;
            dtgBase1.Columns["chk"].FillWeight = 15;

            dtgBase1.Columns["chk"].Selected = true;
            //dtgBase1.Columns["nMonto"].DefaultCellStyle.Format = "### ### ##0.00";
            //dtgBase1.Columns["nTea"].DefaultCellStyle.Format = "##0.00";
            //dtgBase1.Columns["nTasaMoratoria"].DefaultCellStyle.Format = "##0.00";
            //
            dtgBase1.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }



        private void btnHistorialCredito_Click_1(object sender, EventArgs e)
        {
            FrmPosicionCli frmposicioncli = new FrmPosicionCli(123);
            frmposicioncli.ShowDialog();
        }

        private void conBusGrupoSol_ClicBuscar_2(object sender, EventArgs e)
        {
            int idGrupoSol;           
            
            idGrupoSol = this.conBusGrupoSol.idGrupoSolidario;
            BuscarSoli(idGrupoSol);
        }

        public void BuscarSoli(int idGrupo)
        {
            if (idGrupo != 0)
            {
                frmBuscarSoliGrupal Buscar = new frmBuscarSoliGrupal(idGrupo);
                Buscar.ShowDialog();
                idSolGS = Buscar.idSolicitudGS;
                this.idModalidadCredito = Buscar.idModalidadCredito;

                CRE.CapaNegocio.clsCNGrupoSolidario objCNGrupoSolidario = new CapaNegocio.clsCNGrupoSolidario();

                if (this.idModalidadCredito == (int)ModalidadCredito.Principal)
                {
                    string cMensaje = string.Empty;                    
                    DataTable dtAmpliacionGS = objCNGrupoSolidario.existeAmpliacionGrupoSol(idGrupo);
                    if (dtAmpliacionGS.Rows.Count > 0)
                    {
                        cMensaje = "Se encontró una solicitud de ampliación grupal. \n\n" +
                               "Solicitud Nro: " + Convert.ToString(dtAmpliacionGS.Rows[0]["idSolicitudCredGrupoSol"]) + "\n" +
                               "Estado: " + Convert.ToString(dtAmpliacionGS.Rows[0]["cEstado"]) + "\n" +
                               "\nADVERTENCIA: Si realiza el COBRO de la cuenta se ANULARÁ la solicitud de ampliación de TODO EL GRUPO.\n¿Está seguro de continuar? \n";

                        DialogResult idResultado = MessageBox.Show(cMensaje, "Solicitud de ampliación pendiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (idResultado != DialogResult.Yes)
                        {
                            this.conBusGrupoSol.LimpiarControl();
                            this.conBusGrupoSol.btnBusqueda.Enabled = true;
                            return;
                        }
                    }
                }
                
                CargarPlanGrupal(idGrupo, idSolGS);                
                dtGrupoSolidarioAlerta = objCNGrupoSolidario.obtenerGrupoSolidarioMoraAlerta(idSolGS);
            }
            else
            {
                MessageBox.Show("El N° de Grupo debe de ser diferente a 0.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }

        private bool ValidarBloqueo(int idCuentaPresi)
        {
            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();

            DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(idCuentaPresi);
            int nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
            if (nidUserBloqueo != 0)
            {
                DataTable dtUsu = new DataTable();
                dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }                            
            else
            {
                return true;
            }
        }

        public void BloquearCuenta(int idCuenta)
        {
            int nValBusqueda = idCuenta;
            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();

            DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
            int nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
            if (nidUserBloqueo != 0)
            {
                // DataTable dtUsu = new DataTable();
                // dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                // string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                // MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);
            }

        }


        public void LiberarCuenta(int idCuenta)
        {
            if (idCuenta > 0)
            {
                new clsCNRetornaNumCuenta().UpdEstCuenta(idCuenta, 0);
            }
        }



        private void dtgBase1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = string.Empty;

            if (e.RowIndex == -1)
                return;

            /*******
             * Validacion creditos pagados
             * ***/
            int nMontoSinRedondeo = Convert.ToInt32(dtgBase1.Rows[e.RowIndex].Cells["nMonto"].Value);
            int nMontoTotalPago = Convert.ToInt32(dtgBase1.Rows[e.RowIndex].Cells["nCapitalxPagar"].Value);
            if (nMontoSinRedondeo == 0 || nMontoTotalPago == 0)
            {
                /*========================================================================================
                 * VALIDACION DE MONTO 0
                 ========================================================================================*/
                MessageBox.Show("Selección de crédito NO procesado, El monto a pagar y/o capital por pagar deben de ser mayor a 0.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }

            bool lConfirmacion = true;

            int nMoraMinimoAlerta = 0;
            int nMoraGrupal = 0;

            if (dtGrupoSolidarioAlerta.Rows.Count > 0)
            {
                nMoraMinimoAlerta = Convert.ToInt32(dtGrupoSolidarioAlerta.Rows[0]["nMoraMinimaAlerta"]);
                nMoraGrupal = Convert.ToInt32(dtPagos.AsEnumerable().Max(item => Convert.ToInt32(item["nAtraso"])));
                bool lSeleccion = Convert.ToBoolean(this.dtgBase1.Rows[e.RowIndex].Cells["chk"].Value);
                int nCreditoPendiente = dtPagos.AsEnumerable().Count(item => !Convert.ToBoolean(item["lCancelado"]));
                int nMarcados = dtgBase1.Rows.Cast<DataGridViewRow>().Count(item => Convert.ToBoolean(item.Cells["chk"].Value));

                if((nMarcados > 1 && lSeleccion) || (nMarcados + 1 < nCreditoPendiente && !lSeleccion ))
                {
                    if (nMoraGrupal > nMoraMinimoAlerta)
                    {
                        MessageBox.Show("El Grupo Solidario / Banca Comunal tiene un atraso MAYOR a " + nMoraMinimoAlerta + " días.\n - Puede realizar el pago individual de 1 a más créditos del Grupo solidario / Banca Comunal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                        lConfirmacion = true;
                    }
                    else
                    {
                        DialogResult drResultado = MessageBox.Show("El Grupo Solidario / Banca Comunal tiene un atraso MENOR o IGUAL a " + nMoraMinimoAlerta + " días.\n - El pago de crédito debe ser de todos los integrantes del Grupo Solidario / Banca Comunal.\n - Para realizar el pago INDIVIDUAL del crédito, el cliente debe comunicarse con su ASESOR.\n¿Está seguro que desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                        if (drResultado == DialogResult.No)
                        {
                            lConfirmacion = false;
                        }
                        else
                        {
                            lConfirmacion = true;
                        }
                    }
                }
            }

            if (checkBox1.Checked==true)
            {
                if (lConfirmacion)
                {
                    this.checkBox1.Checked = false;
                    MarcarTodos(true);
                    this.dtgBase1.BeginEdit(true);
                    DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell)this.dtgBase1.Rows[e.RowIndex].Cells["chk"];

                    celda.Value = false;
                    decimal dMontoTmp;
                    decimal dMontoTmpRedondeo;

                    decimal dMontoTotalTmpRedondeo;

                    dMontoTmp = Convert.ToDecimal(RetornaMontoPago(e.RowIndex));

                    //redondeo preprocesamiento
                    string txtMCTotalPago = calcularTotal(dMontoTmp);
                    dMontoTmpRedondeo = Convert.ToDecimal(txtMCTotalPago);
                    dMontoTotalTmpRedondeo = (dMontoTmp + Convert.ToDecimal(calcularItf(dMontoTmp))) - dMontoTmpRedondeo;
                    dMontoTmp = dMontoTmpRedondeo;

                    dMontoTotalTmp -= dMontoTmp;

                    conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;

                    this.txtBase1.Text = Convert.ToString(dMontoTotalTmp);
                    //END

                    //PAGOS NETOS
                    decimal dMontoTmp2;

                    dMontoTmp2 = Convert.ToDecimal(RetornaMontoPago(e.RowIndex));
                    dMontoTotalTmp2 -= dMontoTmp2;
                    // end

                    // redondeo 
                    dMontoTotalRedondeo -= dMontoTotalTmpRedondeo;

                    // end

                    idCuenta = Convert.ToInt32(RetornaIdCuenta(e.RowIndex));
                    CargarPlanPagos();
                    CargarKardex();
                    this.btnGrabar1.Enabled = true;

                    this.dtgBase1.EndEdit();

                    string txtItf = calcularItf(dMontoTmp);
                    decimal n = RestarITF(Convert.ToDecimal(txtItf));
                    this.txtBase2.Text = Convert.ToString(n);

                    conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;// +n;
                    this.txtBase6.Text = Convert.ToString(conCalcVuelto1.nMontoTotalpago.ToString());
                    this.txtBase7.Text = Convert.ToString(dMontoTotalTmp2);
                    this.txtBase3.Text = Convert.ToString(dMontoTotalRedondeo);
                }

            }
            else
            {
                this.dtgBase1.BeginEdit(true);
                DataGridViewCheckBoxCell celda = (DataGridViewCheckBoxCell)this.dtgBase1.Rows[e.RowIndex].Cells["chk"];

                bool isSelected1 = Convert.ToBoolean(celda.Value);
                if (isSelected1)
                {
                    if (lConfirmacion)
                    {
                        celda.Value = false;
                        decimal dMontoTmp;
                        decimal dMontoTmpRedondeo;

                        decimal dMontoTotalTmpRedondeo;

                        dMontoTmp = Convert.ToDecimal(RetornaMontoPago(e.RowIndex));

                        //redondeo preprocesamiento
                        string txtMCTotalPago = calcularTotal(dMontoTmp);
                        dMontoTmpRedondeo = Convert.ToDecimal(txtMCTotalPago);
                        dMontoTotalTmpRedondeo = (dMontoTmp + Convert.ToDecimal(calcularItf(dMontoTmp))) - dMontoTmpRedondeo;
                        dMontoTmp = dMontoTmpRedondeo;

                        dMontoTotalTmp -= dMontoTmp;

                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;

                        this.txtBase1.Text = Convert.ToString(dMontoTotalTmp);

                        //END

                        //PAGOS NETOS
                        decimal dMontoTmp2;

                        dMontoTmp2 = Convert.ToDecimal(RetornaMontoPago(e.RowIndex));
                        dMontoTotalTmp2 -= dMontoTmp2;
                        // end

                        // redondeo 
                        dMontoTotalRedondeo -= dMontoTotalTmpRedondeo;

                        // end


                        this.dtgKardex.DataSource = null;
                        this.dtgPpg.DataSource = null;
                        //this.btnGrabar1.Enabled = false;
                        string txtItf = calcularItf(dMontoTmp);
                        decimal n = RestarITF(Convert.ToDecimal(txtItf));
                        this.txtBase2.Text = Convert.ToString(n);
                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;// +n;
                        this.txtBase6.Text = Convert.ToString(conCalcVuelto1.nMontoTotalpago.ToString());
                        this.txtBase7.Text = Convert.ToString(dMontoTotalTmp2);
                        this.txtBase3.Text = Convert.ToString(dMontoTotalRedondeo);
                    }
                }
                else
                {
                    if (lConfirmacion)
                    {
                        celda.Value = true;
                        decimal dMontoTmp;
                        decimal dMontoTmpRedondeo;

                        decimal dMontoTotalTmpRedondeo;

                        dMontoTmp = Convert.ToDecimal(RetornaMontoPago(e.RowIndex));

                        //redondeo preprocesamiento
                        string txtMCTotalPago = calcularTotal(dMontoTmp);
                        dMontoTmpRedondeo = Convert.ToDecimal(txtMCTotalPago);
                        dMontoTotalTmpRedondeo = (dMontoTmp + Convert.ToDecimal(calcularItf(dMontoTmp))) - dMontoTmpRedondeo;
                        dMontoTmp = dMontoTmpRedondeo;

                        dMontoTotalTmp += dMontoTmp;

                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;

                        this.txtBase1.Text = Convert.ToString(dMontoTotalTmp);

                        //END

                        //PAGOS NETOS
                        decimal dMontoTmp2;

                        dMontoTmp2 = Convert.ToDecimal(RetornaMontoPago(e.RowIndex));
                        dMontoTotalTmp2 += dMontoTmp2;
                        // end

                        // redondeo 
                        dMontoTotalRedondeo += dMontoTotalTmpRedondeo;

                        // end

                        idCuenta = Convert.ToInt32(RetornaIdCuenta(e.RowIndex));
                        CargarPlanPagos();
                        CargarKardex();
                        this.btnGrabar1.Enabled = true;
                        string txtItf = calcularItf(dMontoTmp);
                        decimal n = SumarITF(Convert.ToDecimal(txtItf));
                        this.txtBase2.Text = Convert.ToString(n);
                        conCalcVuelto1.nMontoTotalpago = dMontoTotalTmp;// + n;
                        this.txtBase6.Text = Convert.ToString(conCalcVuelto1.nMontoTotalpago.ToString());
                        this.txtBase7.Text = Convert.ToString(dMontoTotalTmp2);
                        this.txtBase3.Text = Convert.ToString(dMontoTotalRedondeo);
                    }
                }
                    this.dtgBase1.EndEdit();
                //return;
            }

            foreach (DataGridViewRow row in dtgBase1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                if (isSelected)
                {
                    message += Environment.NewLine;
                    message += row.Cells["idCuenta"].Value.ToString();
                    idCuenta = Convert.ToInt32(row.Cells["idCuenta"].Value);

                }
            
            }
            //CargaDatos();
            //MessageBox.Show("Selected Values" + message);
        }

   //Check Box Marcar todos
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                MarcarTodos(true);
            }
            else
            {
                MarcarTodos(false);
                ReiniciarVariables();
            }
        }


        #endregion
        private void ReiniciarVariables()
        {
            this.dtgKardex.DataSource = null;
            this.dtgPpg.DataSource = null;
            this.txtBase1.Text = null;
            this.txtBase6.Text = null;
            
            this.conCalcVuelto1.limpiar();
            
            this.dMontoTotal = 0.00m;
            this.dMontoTotalTmp = 0.00m;
            this.idCuenta = 0;
            this.txtBase2.Text = "0.00";
            this.txtBase3.Text = "0.00";
            this.txtBase7.Text = "0.00";
            

            this.dMontoTotalTmp2 = 0.00m;
            this.dMontoTotalRedondeo = 0.00m;
            this.dRedondeoPago = 0.00m;
            this.dItf = 0.00m;
            this.txtMCCapital = "";
            this.txtMCInteres = "";
            this.txtMCIntComp = "";
            this.txtMCMora = "";
            this.txtMCOtros = "";
            this.txtRedondeo = "";
            this.txtImpuestos = "";
            int idVoucher = 0;
        }

        private void Reiniciar()
        {
            
            this.dtgKardex.DataSource = null;
            this.dtgPpg.DataSource = null;
            this.conBusGrupoSol.LimpiarControl();
            this.txtBase1.Text = null;
            this.txtBase6.Text = null;
            this.conCalcVuelto1.limpiar();
           
            this.conBusGrupoSol.btnBusqueda.Enabled = true;
            this.dMontoTotal = 0.00m;
            this.dMontoTotalTmp = 0.00m;
            this.idCuenta = 0;
            this.conDatPerReaOperac.txtDocIdePerson.Text = null;
            this.txtBase2.Text = "0.00";
            this.conPagoBcos.LimpiarControles();
            this.conPagoBcos.Visible = false;
            
            this.dMontoTotalTmp2=0.00m;
            this.dMontoTotalRedondeo=0.00m;
            this.dRedondeoPago = 0.00m;
            this.dItf = 0.00m;
            this.txtMCCapital = "";
            this.txtMCInteres = "";
            this.txtMCIntComp = "";
            this.txtMCMora = "";
            this.txtMCOtros = "";
            this.txtRedondeo = "";
            this.txtImpuestos = "";
            int idVoucher = 0;
            this.txtBase3.Text = "0.00";
            this.txtBase7.Text = "0.00";


            btnGrabar1.Enabled = false;
            txtBase1.Enabled = false;
            txtBase6.Enabled = false;
            txtBase2.Enabled = false;
            
            // LIBERAR Cuentas

            if (!(dtPagos == null))
            {
                if ((dtPagos.Rows.Count > 0) && nBloqueoActivo == 1)
                {
                    this.dtgBase1.DataSource = null;
                    this.dtgBase1.DataSource = dtPagos;

                    for (int i = 0; i < dtPagos.Rows.Count; i++)
                    {
                        int idCuentaBloq = Convert.ToInt32(dtPagos.Rows[i]["idCuenta"].ToString());
                        LiberarCuenta(idCuentaBloq);

                    }
                    //    foreach (DataGridViewRow row in dtgBase1.Rows)
                    //    {
                    //
                    //        int idCuentaBloq = Convert.ToInt32(row.Cells["idCuenta"].Value);
                    //        LiberarCuenta(idCuentaBloq);
                    //
                    //    }
                    nBloqueoActivo = 0;
                }
            }
            this.dtPagos = null;
            this.dtgBase1.DataSource = null;
            this.checkBox1.Checked = false;
            this.conDatosReprog.limpiarDatos();
            this.dtGrupoSolidarioAlerta = new DataTable();
            
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Reiniciar();        
        }

        private void Pagar()
        {
            string cIdCuenta = "";
            string cMonto = "";
            
                foreach (DataGridViewRow row in dtgBase1.Rows)
                {
                    dtgBase1.Rows[row.Index].Selected = true;
               
                    bool isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                    if (isSelected)
                    {
                        decimal dMontoTmp;
                        decimal dMontoTmpRedondeo;
                        cIdCuenta = RetornaIdCuenta(row.Index);
                        idCuenta = Convert.ToInt32(cIdCuenta);
                        cMonto = RetornaMontoPago(row.Index);
                        

                        dMontoTmp = Convert.ToDecimal(cMonto);
                        
                        //redondeo
                        string txtMCTotalPago = calcularTotal(dMontoTmp);
                        dMontoTmpRedondeo = Convert.ToDecimal(txtMCTotalPago);
                        dMontoTotalConRedondeo += dMontoTmpRedondeo;
                            //dMontoTmp = dMontoTmpRedondeo;
                        //endRedondeo

                        dMontoTotal += dMontoTmp;
                        //conCalcVuelto1.nMontoTotalpago = dMontoTotal;



                        this.txtBase6.Text = Convert.ToString(dMontoTotalConRedondeo);
            
                        //MessageBox.Show("Se pagara esta cuenta: " + cIdCuenta+", el monto de :"+cMonto, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsCNPlanPago PlanPago = new clsCNPlanPago();
                        dtPlanPago = PlanPago.CNdtPlanPagoGS(idCuenta);
                        DataTable DatosCli = PlanPago.CNdtBuscarCli(idCuenta);
                        CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
                        dtCredito = Credito.CNdtDataCreditoCobro(idCuenta);
                        distribuiyeValores(idCuenta,dMontoTmp);

                        try
                        {
                            GestionPago(Convert.ToInt32(DatosCli.Rows[0]["idCli"].ToString()), Convert.ToString(DatosCli.Rows[0]["cDocumentoID"].ToString()), idCuenta, dRedondeoPago, dMontoTmp);//Convert.ToDecimal(cMonto));
                             
                        }
                        catch(Exception e)
                        {
                            //MessageBox.Show(" No se realizo Pago: "+ e.StackTrace+" ,\n "+e.Message+" ,\n "+e.Source, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show(" No se realizo Pago para la cuenta :"+Convert.ToString(idCuenta)+".", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }

                    }
                }

                /*========================================================================================
                                 * IMPRESIOND DEL VOUCHER GRUPAL
                ========================================================================================*/
            ImprimirVoucherGrupal();

            while (MessageBox.Show("¿Desea reimprimir el voucher GRUPAL?", "Impresion de voucher grupal",
                                                                        MessageBoxButtons.YesNo,
                                                                        MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ImprimirVoucherGrupal();
            }
            Reiniciar();

            

        }
        private string calcularTotal(decimal MontoNeto)
        {
            Decimal nMonPago = (Convert.ToDecimal(MontoNeto));// + Convert.ToDecimal (this.txtNumRea3.Text));
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(1));

            //Asignando el ItfNormal (Sin redondeo)
            nITFNormal = clsVarGlobal.nITF / 100.00m * (decimal)nMonPago;
            nITFNormal = objFunciones.truncarNumero(nITFNormal, 2);

            Decimal nMonFavCli = 0.00m;

            Decimal nMonRedBcr = 0.00m;

            if (Convert.ToInt32(1) == 1)
            {
                nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, Convert.ToInt32(1), true, true);
            }
            else
            {
                nMonRedBcr = (nMonPago + nITF);
            }
            txtRedondeo = Math.Round(nMonFavCli, 2).ToString();
            txtImpuestos = Math.Round(nITF, 2).ToString();
                  
            return (nMonRedBcr).ToString();
        }

        private string calcularItf(decimal MontoNeto)
        {
            Decimal nMonPago = (Convert.ToDecimal(MontoNeto));// + Convert.ToDecimal (this.txtNumRea3.Text));
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(1));

            //Asignando el ItfNormal (Sin redondeo)
            nITFNormal = clsVarGlobal.nITF / 100.00m * (decimal)nMonPago;
            nITFNormal = objFunciones.truncarNumero(nITFNormal, 2);

            Decimal nMonFavCli = 0.00m;

            Decimal nMonRedBcr = 0.00m;

            if (Convert.ToInt32(1) == 1)
            {
                nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, Convert.ToInt32(1), true, true);
            }
            else
            {
                nMonRedBcr = (nMonPago + nITF);
            }
            txtRedondeo = Math.Round(nMonFavCli, 2).ToString();
            txtImpuestos = Math.Round(nITF, 2).ToString();
                                  
            return txtImpuestos.ToString();
        }


        private decimal SumarITF(decimal nItf)
        {
            decimal n;
            decimal m;
            n = Convert.ToDecimal(this.txtBase2.Text.Trim());
            m = n + nItf;
            return m;
        }

        private decimal RestarITF(decimal nItf)
        {
            decimal n;
            decimal m;
            n = Convert.ToDecimal(this.txtBase2.Text.Trim());
            m = n - nItf;
            return m;
        }

        public void distribuiyeValores(int idCuenta, decimal MontNeto)
        {
            int nNumCredito = idCuenta;
            CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
            Decimal nMonSalCre = Credito.nSaldoCredito(dtCredito);
            nMonSalCre = Convert.ToDecimal(string.Format("{0:#,0.00}", Convert.ToDecimal(nMonSalCre.ToString())));
            if (Math.Round(nMonSalCre, 2) < Convert.ToDecimal(MontNeto))
            {
                MessageBox.Show("Monto a pagar no puede exceder al saldo del crédito: " + nMonSalCre.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar1.Enabled = false;
                return;
            }

           // CargaDatos();

            //clsCNCredito Credito = new clsCNCredito();
            dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);
            dtOrdenPrelacion = cnCredito.ObtenerOrdenPrelacion(nNumCredito, Convert.ToInt32(dtCredito.Rows[0]["idOrdenPrelacion"]));

            Decimal nMontoaPagar = Convert.ToDecimal(MontNeto);

            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            //dtPlanPagado = new clsCNPlanPago().dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
            dtPlanPagado = new clsCNPlanPago().dtCNPagoDistConOrdenPrelacion(dtPlanPago, nMontoaPagar, true, dtOrdenPrelacion);
           
            txtMCCapital = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
            txtMCInteres = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
            txtMCIntComp = dtPlanPagado.Rows[0]["nIntCompPag"].ToString();
            txtMCMora    = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
            txtMCOtros   = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();

            string txtMCTotalPago = calcularTotal(MontNeto);
            
            dRedondeoPago = Convert.ToDecimal(txtMCTotalPago);
            
            //FormatoMonto();

            //this.btnGrabar1.Enabled = true;
            //if (conCalcVuelto1.nMontoTotalpago != Convert.ToDecimal(txtMCTotalPago))
            //{
            //    conCalcVuelto1.limpiar();
            //}
            //conCalcVuelto1.nMontoTotalpago = Convert.ToDecimal(txtMCTotalPago);
            
            //conCalcVuelto1.Enabled = true;
            //conCalcVuelto1.txtMonEfectivo.Focus();
            //conCalcVuelto1.txtMonEfectivo.SelectAll();
        }
        
        private bool ValidarSplaft(int nIdCuenta, int nIdCliente, decimal nMontoTotalPago)
        {
            /*========================================================================================
              * VALIDACIONES PARA REGIMEN DEL CLIENTE
              ========================================================================================*/
            DataTable dtProducto = new clsCNPlanPago().CNdtExtraeProducto(nIdCuenta);

            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(nIdCliente,
                                                                               Convert.ToInt32(1),
                                                                               Convert.ToInt32(dtProducto.Rows[0]["idProducto"].ToString()),
                                                                               nIdCuenta,
                                                                               Convert.ToDecimal(nMontoTotalPago));
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                //MessageBox.Show("No se realizo el Pago",cTitulo);
                //MessageBox.Show(" No se realizo Pago para la cuenta :" + Convert.ToString(idCuenta) + ".", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;

        }

        private void GestionPago(int nIdCliente, string cDocumento, int nIdCuenta, decimal nMontoTotalPago,decimal nMontoSinRedondeo)
        {
          /*========================================================================================
          * VALIDACION DE MONTO 0
          ========================================================================================*/
            if (nMontoSinRedondeo == 0 || nMontoTotalPago == 0 )
            {
                MessageBox.Show("El monto a pagar y/o capital por pagar deben de ser mayor a 0.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            MessageBox.Show("Se gestionará el pago de la cuenta :  "+Convert.ToString(nIdCuenta)+"\r\n con el monto (incluye redondeo) :  "+Convert.ToString(nMontoTotalPago), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
 
            /*========================================================================================
           * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
           ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(this.conDatPerReaOperac.idCli, this.conDatPerReaOperac.cDocumentoID, clsVarGlobal.nIdAgencia, idTipoOperacion, nIdCliente);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            //--------------------------------------------------------------------------------
            //--- Registro PEP
            //--------------------------------------------------------------------------------
            string mensaje = "",
                   x_cNroDni = "";
            int x_idEstApr = 0;
            int CodCliente = nIdCliente;
            int CodIddocumento = 1;//idTipoDocumento;

            if (!conSplaf1.ValidaAprobacionClientePep(CodCliente, ref mensaje, ref x_cNroDni, ref x_idEstApr))
            {
                MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (x_idEstApr == 1) //--Solicitado
                {
                    frmPep frmPepx = new frmPep(CodIddocumento, x_cNroDni);

                    frmPepx.ShowDialog();
                }
                btnGrabar1.Enabled = true;
                return;
            }

            //VALIDACIÓN DE CONDONACIÓN DE DEUDA

            this.registrarRastreo(Convert.ToInt32(nIdCliente), Convert.ToInt32(cDocumento), "Inicio - Registro de Cobranza de Crédito", btnGrabar1);

            //if (!Validar()) return;

            int idTipoPago = Convert.ToInt32(cboTipoPago.SelectedValue),
              idEntidad = 0,
              idCtaEntidad = 0;
            if (idTipoPago == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(1), 1, Convert.ToDecimal(nMontoTotalPago)))
                {
                    return;
                }
            }

            //APLICAR REGLA DINAMICA: EL usuario actual del sistema, no puede ser el mismo que pague su crédito
            GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            String cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(cDocumento),
                                                   1, Convert.ToInt32(1), 0,
                                                   0, int.Parse(cDocumento), clsVarGlobal.dFecSystem,
                                                   2, 1, clsVarGlobal.User.idUsuario, ref nNivAuto);

            if (!cCumpleReglas.Equals("Cumple"))
            {
                return;
            }

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            //DataTable dtProducto = new clsCNPlanPago().CNdtExtraeProducto(nIdCuenta);

            //clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(nIdCliente,
            //                                                                   Convert.ToInt32(1),
            //                                                                   Convert.ToInt32(dtProducto.Rows[0]["idProducto"].ToString()),
            //                                                                   nIdCuenta,
            //                                                                   Convert.ToDecimal(nMontoTotalPago));
            //if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            //{
            //    //MessageBox.Show("No se realizo el Pago",cTitulo);
            //    MessageBox.Show(" No se realizo Pago para la cuenta :" + Convert.ToString(idCuenta) + ".", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                          
            //    return;
            //}

            while (ValidarSplaft(nIdCuenta, nIdCliente, nMontoTotalPago) == false)
            //{
            //    MessageBox.Show("Aún no se aprobó la solicitud para la cuenta :" + Convert.ToString(idCuenta) + ".", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            btnGrabar1.Enabled = false;
            //Filtramos el plan de pagos

            var resultPpg = dtPlanPago.AsEnumerable().Where(x => x.Field<decimal>("nCapitalPagado") +
                                                                 x.Field<decimal>("nInteresPagado") +
                                                                 x.Field<decimal>("nInteresCompPago") +
                                                                 x.Field<decimal>("nMoraPagada") +
                                                                 x.Field<decimal>("nOtrosPagado") > 0);
            if (resultPpg.Any())
            {
                dtPlanPago = resultPpg.CopyToDataTable();
            }

          //  dtPlanPago.Rows[0]["dFechaPago"] = System.DateTime.Now;

            DataSet ds = new DataSet("dsPlanPagos");
            
            dtPlanPago.TableName = "dtPlanPagos";
            ds.Tables.Add(dtPlanPago);

            string xmlPpg = ds.GetXml();//Solo Plan Pagos

            clsCNPlanPago planPago = new clsCNPlanPago();

            DataTable dtDetalleCargaGasto = planPago.DistribuirGastosPagados(dtPlanPago);
            dtDetalleCargaGasto.TableName = "TablaDetalleCargaGasto";
            ds.Tables.Add(dtDetalleCargaGasto);

            //Guardar los Datos de la persona que está pagando la cuota
            {
                DataTable dtPagador = new DataTable("TablaDatosPagador");

                dtPagador.Columns.Add("cNroDNI", typeof(string));
                dtPagador.Columns.Add("cNomCliente", typeof(string));
                dtPagador.Columns.Add("cDireccion", typeof(string));

                DataRow drfila = dtPagador.NewRow();
                drfila["cNroDNI"] = conDatPerReaOperac.txtDocIdePerson.Text;
                drfila["cNomCliente"] = conDatPerReaOperac.txtNombrePerson.Text;
                drfila["cDireccion"] = conDatPerReaOperac.txtDireccPerson.Text;
                dtPagador.Rows.Add(drfila);

                ds.Tables.Add(dtPagador);
            }

            xmlPpg = ds.GetXml();//Plan Pagos y DetalleCargaGastos en caso se haya realizado pagos
            xmlPpg = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPpg);

            ds.Tables.Clear();
            //cambiar monto total, nombredonde, nimpuest
            Decimal nMoraPagada = Convert.ToDecimal(txtMCMora);
            int nNumCredito = nIdCuenta;
            Decimal nMonRedondeo = Convert.ToDecimal(txtRedondeo);
            Decimal nImpuesto = Convert.ToDecimal(txtImpuestos);

            string cNroTrx = "";
            
            if (idTipoPago != 1)
            {
                conPagoBcos.CargaResultado();
                if (!conPagoBcos.lResulta)
                {
                    btnGrabar1.Enabled = true;
                    return;
                }
                idEntidad = conPagoBcos.idEntidad;
                idCtaEntidad = conPagoBcos.idCuenta;
                cNroTrx = conPagoBcos.cNroTrx;
            }

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 1; //INGRESO

            if (idTipoPago == 1)
                lModificaSaldoLinea = true;

            DataTable TablaUpPpg = planPago.UpCobroPpg(PpgXml: xmlPpg,
                                                        dFecSis: clsVarGlobal.dFecSystem,
                                                        nUsuSis: clsVarGlobal.User.idUsuario,
                                                        nIdAgencia: clsVarGlobal.nIdAgencia,
                                                        nMoraPagada: nMoraPagada,
                                                        idCuenta: nNumCredito,
                                                        idCanal: clsVarGlobal.idCanal,
                                                        nMonRedondeo: nMonRedondeo,
                                                        nImpuesto: nImpuesto,
                                                        nITFNormal: nITFNormal,
                                                        idTipoPago: idTipoPago,
                                                        idEntidad: idEntidad,
                                                        idCtaEntidad: idCtaEntidad,
                                                        cNroTrx: cNroTrx,
                                                        idMotivoOperacion: Convert.ToInt32(5),
                                                        cXmlCobs: this.ObtenerCobsXml(),
                                                        lModificaSaldoLinea: lModificaSaldoLinea,
                                                        idTipoTransac: idTipoTransac,
                                                        idMoneda: 1, //SOLES
                                                        nMontoOpe: Convert.ToDecimal(nMontoTotalPago));

            int nIdKardex,
                nIdKardexCob;
            if (TablaUpPpg.Rows.Count > 0)
            {
                nIdKardex = Convert.ToInt32(TablaUpPpg.Rows[0]["idKardex"]);
                nIdKardexCob = Convert.ToInt32(TablaUpPpg.Rows[0]["idKardexReciboCob"]);

                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show("Cobro satisfactorio con N° de operación: " + nIdKardex.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancelar1.Enabled = false;
                //-----------------------------------------------------------------------------------------------------
                //--    REGISTRA El pago del intergrante del grupo en  SI_FinRegistroPagoGrupal
                //-----------------------------------------------------------------------------------------------------

                DataTable dtRegPagosGrupal = new clsCNPlanPago().CNdtRegPagosGrup(idVoucher
                                                                                    , nIdKardex
                                                                                    ,Convert.ToInt32(TablaUpPpg.Rows[0]["idEstado"])
                                                                                    , idSolGS
                                                                                    ,nIdCuenta
                                                                                    ,nIdCliente
                                                                                    , nMontoTotalPago
                                                                                    , nMonRedondeo
                                                                                    , nMontoSinRedondeo);
                //int idKardex, int idEstado, int idSolGS, int idCuenta, int idCli, decimal dMonto


                //Obtiene idestado del crédito despues de la cobranza
                var idEstado = Convert.ToInt32(TablaUpPpg.Rows[0]["idEstado"]);
                var lGarantia = Convert.ToBoolean(TablaUpPpg.Rows[0]["lGarantia"]);
                var lTieneGarAhorro = Convert.ToBoolean(TablaUpPpg.Rows[0]["lTieneGarAhorro"]);
                if (idEstado == 6 && lGarantia && !lTieneGarAhorro)
                {
                    MessageBox.Show("El crédito se canceló, cliente debe de realizar el trámite \n para liberar su garantía, coordinar con su asesor", "Validar garantía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(nIdKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(nIdKardex);
            }
            else
            {
                MessageBox.Show("Ocurrió un problema al realizar el Cobro de Crédito", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Emision de Voucher
            ImpresionVoucher(nIdKardex: nIdKardex, idModulo: 1, idTipoOpe: idTipoOperacion, idEstadoKardex: 1,
                                nValRec: nMontoTotalPago,//conCalcVuelto1.txtMonEfectivo.nDecValor,
                                nValdev: 0.00m,//conCalcVuelto1.txtMonDiferencia.nDecValor,
                                idKardexAd: 0, idTipoImpresion: 1);

            // **************************************************************************
            //Emisión del Voucher de la Cob
            // **************************************************************************
            if (nIdKardexCob != 0)
            {
                foreach (DataRow item in TablaUpPpg.Rows)
                {
                    ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt32(1), Convert.ToInt32(item["idTipoOperacion"]) == 5 ? 1 : 2, Convert.ToDecimal(item["nMontoPag"]));
                }
                foreach (DataRow item in TablaUpPpg.Rows)
                {
                    ImpresionVoucher(
                            nIdKardex: Convert.ToInt32(item["idKardexReciboCob"]),
                            idModulo: 3,
                            idTipoOpe: Convert.ToInt32(item["idTipoOperacion"]) /**/,
                            idEstadoKardex: 1,
                            nValRec: Convert.ToDecimal(item["nMontoPag"]),
                            nValdev: 0,
                            idKardexAd: 0,
                            idTipoImpresion: 1);
                }
            }

            //this.objFrmSemaforo.ValidarSaldoSemaforo();
            ds.Dispose();
            cEstadoForm = "E";

            //comentado paulgpp
            /* this.conBusCuentaCli.LiberarCuenta();
             pnlDatCredito.Enabled = true;
             grbBase2.Enabled = false;
             grbBase3.Enabled = false;
             conBusCuentaCli.Enabled = false;
             btnGrabar.Enabled = false;
             conDatPerReaOperac.Enabled = false;
             cboTipoPago.Enabled = false;
             conPagoBcos.Enabled = false;
             btnCancelar.Enabled = true;
             btnPrePago.Enabled = false;
             conCalcVuelto.Enabled = false;*/


            
            /*========================================================================================
         * ACTUALIZACIOND DE CANTIDAD DE LOS QUE PAGARON
         ========================================================================================*/
            DataTable dtActualizacion = new clsCNPlanPago().CNdtActVoucherGrupal(idVoucher);

           /*========================================================================================
             * REGISTRO DE RASTREO
             ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(nIdCliente), Convert.ToInt32(cDocumento), "Fin - Registro de Cobranza de Crédito", btnGrabar1);

            lCargoPlanPagos = false;
            lCargoKardexPagos = false;

        }

        private string ArmarVoucherEmpresa(int idPlant)
        {
            DataTable dtDatosVoucher = new clsCNPlanPago().CNdtDatosVoucherGrupal(idVoucher,Convert.ToDecimal(conCalcVuelto1.txtMonEfectivo.Text));

            string cPlantillaEmpresa = "";
            string cOficina= Convert.ToString(clsVarGlobal.cNomAge.Trim());
            string cCajero=Convert.ToString(clsVarGlobal.User.cWinUser.Trim());
            string cFecha=dtDatosVoucher.Rows[0]["dFecha"].ToString();
            string cHora=dtDatosVoucher.Rows[0]["cHora"].ToString();
            string cMontoRecibido= conCalcVuelto1.txtMonEfectivo.Text;
            string cMontoCobrado=dtDatosVoucher.Rows[0]["nMontoTotal"].ToString();
            string cCambio=dtDatosVoucher.Rows[0]["nMontoCambio"].ToString();
            string cIdUsu = Convert.ToString(clsVarGlobal.User.idUsuario.ToString());
            string idGrupoSol = dtDatosVoucher.Rows[0]["idGrupo"].ToString(); 
            string cNombreGrupo = dtDatosVoucher.Rows[0]["cNombreGrupo"].ToString(); 
            string cRedondeoGrupal = dtDatosVoucher.Rows[0]["dMonRedondeo"].ToString(); 
            string cMontoSinRedondeo = dtDatosVoucher.Rows[0]["dMonSinRedondeo"].ToString();
            string cSaldoCapital = dtDatosVoucher.Rows[0]["dSaldoCapital"].ToString(); 
            
            this.conCalcVuelto1.txtMonDiferencia.Text=cCambio;

            cMontoCobrado=ConvertToDecimalParse(cMontoCobrado);
            cCambio = ConvertToDecimalParse(cCambio);
            /*========================================================================================
            * NORMAL
            ========================================================================================*/
            if (idPlant == 1)
            {
                cPlantillaEmpresa = "PAGO DE PRÉSTAMO GRUPAL\r\nGRUPO SOLIDARIO\r\n----------------------------------------------\r\nNro DNI  : " +
                                    conDatPerReaOperac.txtDocIdePerson.Text+
                                    "\r\nNOMBRE   : "+conDatPerReaOperac.txtNombrePerson.Text+
                                    "\r\nNro Grupo: " + idGrupoSol +
                                    "\r\nNom. Grup: " + cNombreGrupo +
                                    "\r\nOFICINA  : "+cOficina+"     CAJERO: "+cCajero+
                                    "\r\nFECHA    : "+cFecha+"   HORA  : "+cHora+
                                    "\r\nMONEDA   : SOLES  MOD.PAGO: EFECTIVO\r\n----------------------------------------------"+
                                    "\r\nMOTIVO   : COBRANZA GRUPAL" +
                                    "\r\n\r\nTOTAL PAGO      :  " + RellenarAst(cMontoCobrado, 46, 31) +
                                    "\r\n----------------------------------------------"+
                                    "\r\nMONTO RECIBIDO  :  " + RellenarAst(cMontoRecibido, 46, 31) +
                                    "\r\nCAMBIO          :  " + RellenarAst(cCambio, 46, 31) +
                                    "\r\n\r\nFIRMA :                        ---------------\r\nDNI:\r\n"+
                                    "EL PRESENTE ES REFERENCIAL Y SE EMITE\r\nSOLAMENTE PARA CONTROL GRUPAL."
                                    ;

                return cPlantillaEmpresa;

            }
            /*========================================================================================
           * MATRICIAL
           ========================================================================================*/
            string cNom = conDatPerReaOperac.txtNombrePerson.Text;
            string cNom1 = "";
            string cNom2 = "";
            string cNom3 = "";
            int len = Convert.ToInt32(cNom.Length);
            if (len > 25)
            {
                cNom1=cNom.Substring(0, 25);
                cNom2=cNom.Substring(25,len-25);
                cNom3 = "\r\n           " + cNom2;
            }
            else
            {
                cNom1 = cNom;
                //cNom2 = "";
            }
            string cNomGru = cNombreGrupo;
            string cNomGru1 = "";
            string cNomGru2= "";
            string cNomGru3 = "";
            int len2 = Convert.ToInt32(cNomGru.Length);
            if (len2 > 25)
            {
                cNomGru1 = cNomGru.Substring(0, 25);
                cNomGru2 = cNomGru.Substring(25, len2 - 25);
                cNomGru3 = "\r\n           " + cNomGru2;
            }
            else
            {
                cNomGru1 = cNomGru;
                //cNom2 = "";
            }



            cPlantillaEmpresa = "PAGO DE PRÉSTAMO GRUPAL\r\n          GRUPO SOLIDARIO\r\n------------------------------------\r\nNro DNI  : "+
                                 conDatPerReaOperac.txtDocIdePerson.Text+
                                 "\r\nNOMBRE   : " + cNom1 + cNom3 +
                                 "\r\nNro Grupo: " + idGrupoSol +
                                 "\r\nNom. Grup: " + cNomGru1 + cNomGru3+
                                 "\r\nOFICINA  : "+cOficina+"\r\nCAJERO   : "+cIdUsu+"\r\nFEC/HRA  : "+cFecha+" / "+cHora+
                                 "\r\nMONEDA   : SOLES\r\nM.PAGO   : EFECTIVO\r\n------------------------------------"+
                                 "\r\nMOTIVO   : COBRANZA GRUPAL"+
                                 "\r\n\r\nTOTAL PAGO      : " + RellenarAst(cMontoCobrado, 36, 21) +
                                 "\r\n------------------------------------"+
                                 "\r\nMONTO RECIBIDO  : " + RellenarAst(cMontoRecibido, 36, 21) +
                                 "\r\nCAMBIO          : " + RellenarAst(cCambio, 36, 21) +
                                 "\r\n\r\n\r\n\r\nFIRMA: -----------------------------\r\nDNI  :\r\nEL PRESENTE ES REFERENCIAL Y SE\r\nEMITE SOLAMENTE PARA EL CONTROL\r\nGRUPAL."  
                ;

            
                return cPlantillaEmpresa;
            
            
        }
        
        private string ConvertToDecimalParse(string cDato)
        {
            string cResultado;
            if (!(string.IsNullOrEmpty(cDato)))
            {
                decimal dDato = Convert.ToDecimal(cDato);
                cResultado = string.Format("{0:#,#0.00}", dDato);
                return cResultado;
            }
            cResultado = "0.00";
            return cResultado;

        }
        private string RellenarAst(string cDato, int nCantidad, int nPrevio)
        {
            string cResultado="";
            string Tmp="";
            int nLen = cDato.Length;
            nCantidad = nCantidad - nPrevio;

            for (int i = 1; i < (nCantidad - nLen); i++)
            {
                Tmp = Tmp + "*";
            }

            cResultado = Tmp + cDato;
            
            return cResultado;
        }


        private string ArmarVoucherCliente(int idPlant)
        {
            DataTable dtDatosVoucher = new clsCNPlanPago().CNdtDatosVoucherGrupal(idVoucher, Convert.ToDecimal(conCalcVuelto1.txtMonEfectivo.Text));

            string cPlantillaCliente = "";
            string cOficina = Convert.ToString(clsVarGlobal.cNomAge.Trim());
            string cCajero = Convert.ToString(clsVarGlobal.User.cWinUser.Trim());
            string cFecha = dtDatosVoucher.Rows[0]["dFecha"].ToString();
            string cHora = dtDatosVoucher.Rows[0]["cHora"].ToString();
            string cMontoRecibido = conCalcVuelto1.txtMonEfectivo.Text;
            string cMontoCobrado = dtDatosVoucher.Rows[0]["nMontoTotal"].ToString(); ;
            string cCambio = dtDatosVoucher.Rows[0]["nMontoCambio"].ToString(); ;
            string idGrupoSol = dtDatosVoucher.Rows[0]["idGrupo"].ToString(); ;
            string cNombreGrupo = dtDatosVoucher.Rows[0]["cNombreGrupo"].ToString(); ;
            string cRedondeoGrupal = dtDatosVoucher.Rows[0]["dMonRedondeo"].ToString();
            string cMontoSinRedondeo = dtDatosVoucher.Rows[0]["dMonSinRedondeo"].ToString();
            string cSaldoCapital = dtDatosVoucher.Rows[0]["dSaldoCapital"].ToString(); 

            this.conCalcVuelto1.txtMonDiferencia.Text = cCambio;

            cMontoCobrado = ConvertToDecimalParse(cMontoCobrado);
            cCambio = ConvertToDecimalParse(cCambio);
            /*========================================================================================
            * NORMAL
            ========================================================================================*/
            if (idPlant == 1)
            {
                cPlantillaCliente = "PAGO DE PRÉSTAMO GRUPAL\r\nGRUPO SOLIDARIO\r\n----------------------------------------------\r\nNro DNI  : " +
                                    conDatPerReaOperac.txtDocIdePerson.Text +
                                    "\r\nNOMBRE   : " + conDatPerReaOperac.txtNombrePerson.Text +
                                    "\r\nNro Grupo: " + idGrupoSol+
                                    "\r\nNom. Grup: " + cNombreGrupo +
                                    "\r\nOFICINA  : " + cOficina + "     CAJERO: " + cCajero +
                                    "\r\nFECHA    : " + cFecha + "   HORA  : " + cHora +
                                    "\r\nMONEDA   : SOLES  MOD.PAGO: EFECTIVO\r\n----------------------------------------------" +
                                    "\r\nMOTIVO   : COBRANZA GRUPAL" +
                                    "\r\n\r\nTOTAL PAGO      :  " + RellenarAst(cMontoCobrado, 46, 31) +
                                    "\r\n----------------------------------------------"+
                                    "\r\nMONTO RECIBIDO  :  " + RellenarAst(cMontoRecibido, 46, 31) +
                                    "\r\nCAMBIO          :  " + RellenarAst(cCambio, 46, 31) +
                                    "\r\n\r\nEL PRESENTE ES REFERENCIAL Y SE EMITE\r\nSOLAMENTE PARA EL CONTROL GRUPAL."
                                    ;

                return cPlantillaCliente;

            }
            /*========================================================================================
           * MATRICIAL
           ========================================================================================*/


            return cPlantillaCliente;
            

        }

        private void ImprimirVoucherGrupal()
        {
            string cPlantillaCliente = "";
            string cPlantillaEmpresa = "";
            string cNombreEmpresa = clsVarApl.dicVarGen["cNomCortoEmp"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];

            string cTipoImpresion = "   ";//idTipoImpresion == 1 ? "   " : "COPIA";

            int idTipoPlantImpresion = clsVarGlobal.idTipoPlantillaImpresion;

            cPlantillaEmpresa = ArmarVoucherEmpresa(idTipoPlantImpresion);//ArmarVoucher(nIdKardex, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion);
            
            if (idTipoPlantImpresion == 2)
            {
                cPlantillaCliente = cPlantillaEmpresa;
            }
            else
            {
                cPlantillaCliente = ArmarVoucherCliente(idTipoPlantImpresion);//ArmarVoucher(nIdKardex, idModulo, idTipoOpe, idEstadoKardex, nValRec, nValdev, idTipoImpresion);
            }

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cTextoEmpresa", cPlantillaEmpresa, false));
                paramlist.Add(new ReportParameter("cTextoCliente", cPlantillaCliente, false));
                paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
                paramlist.Add(new ReportParameter("cRUC", cRUC, false));
                paramlist.Add(new ReportParameter("cTipoImpresion", cTipoImpresion, false));
                paramlist.Add(new ReportParameter("nIdKardex", idVoucher.ToString(), false));
                string reportpath = "rptVoucher.rdlc";

                if (idTipoPlantImpresion == 2)
                {
                    reportpath = "rptVoucherTicketMatricial.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                }
                else
                {
                    new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                }

            
        }

        
        public string ObtenerCobsXml()
        {
            DataSet ds = new DataSet("xmlCobs");

            if (dtCobs == null)
            {
                return "<xmlCobs/>";
            }

            if (dtCobs.DataSet == null)
            {
                ds.Tables.Add(dtCobs);
            }
            else
            {
                ds = dtCobs.DataSet;
            }

            return ds.GetXml();
        }
        private void GestionVoucher()
        {
            MessageBox.Show("Imprime voucher", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private string RetornaIdCuenta(int n)
        {
            return Convert.ToString(dtPagos.Rows[n]["idCuenta"]);
        }
        private string RetornaMontoPago(int n)
        {
            return Convert.ToString(dtPagos.Rows[n]["nMonto"]);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.txtBase6.Text = null;

            DataTable dtVoucherGrupal = new clsCNPlanPago().CNdtVoucherGrupal(this.conBusGrupoSol.idGrupoSolidario);

            idVoucher = Convert.ToInt32(dtVoucherGrupal.Rows[0]["idRegVoucher"]);

            if(!validar())
            {
                return;
            }

            //MessageBox.Show("¿Esta seguro de realizar esta operacion? ", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (MessageBox.Show("¿Esta seguro de realizar esta operacion? ", cTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                decimal dEfectivo = Convert.ToDecimal(conCalcVuelto1.txtMonEfectivo.Text);
                //decimal dEfectivo = Convert.ToDecimal(conCalcVuelto1.txtMonEfectivo.Text);

                if (dEfectivo > 0.00m)
                {
                    Pagar();
                }
                else
                {
                    MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.conCalcVuelto1.txtMonEfectivo.Text="0.00";
                    this.conCalcVuelto1.txtMonEfectivo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Se restablecerá el formulario.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Question);
                Reiniciar();
            }
            // Reiniciar();
        }

        private void dtgBase1_SelectionChanged(object sender, EventArgs e)
        {
           // CargarPlanPagos();
           // CargarKardex();
        }
        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.SelectedIndex == -1 || cboTipoPago.SelectedValue is DataRowView)
                return;

            conPagoBcos.LimpiarControles();
            conCalcVuelto1.limpiar();

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 4)
            {
                conPagoBcos.Visible = true;
                conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));
                //conCalcVuelto1.txtMonEfectivo.Enabled = false;
            }
            else
            {
                conPagoBcos.Visible = false;
                conCalcVuelto1.txtMonEfectivo.Enabled = true;
            }

            //txtBase1.Text = calcularTotal(Convert.ToDecimal(txtBase1.Text.Trim()));
            //if (conCalcVuelto1.nMontoTotalpago != Convert.ToDecimal(txtBase1.Text.Trim()))
            //{
            //    conCalcVuelto1.limpiar();
            //}
            //conCalcVuelto1.nMontoTotalpago = Convert.ToDecimal(txtBase1.Text.Trim());
            //conCalcVuelto1.Enabled = true;
            //conCalcVuelto1.txtMonEfectivo.Focus();
            //conCalcVuelto1.txtMonEfectivo.SelectAll();
        }

        private void frmCobroCreditosGrupales_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
        }
        public string ValidarInicioOpe()
        {
            if (!clsVarGlobal.PerfilUsu.lResVentanilla)
            {
                MessageBox.Show("Debe ser responsable de ventanilla para realizar esta operación.", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "R";
            }
            if (!clsVarGlobal.PerfilUsu.lLimCobertura)
            {
                MessageBox.Show("Debe asignar los montos del límite de cobertura para VENTANILLA", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "R";
            }
            string cResp = ValidarBilletaje(1, clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), "Ya registró su billetaje,");
            if (cResp.Equals("R"))
            {
                return cResp;
            }

            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, 1);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            //string cRpta = this.ValidarInicioOpe();
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            {
                case "F":
                    MessageBox.Show("Falta realizar el inicio de Operaciones \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Dispose();
                    break;
            }

            return cEstCie;
        }

        private void frmCobroCreditosGrupales_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reiniciar();
        }

        private bool validar()
        {
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el número de DOCUMENTO DE IDENTIDAD", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtNombrePerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el NOMBRE", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conDatPerReaOperac.txtNombrePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDireccPerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la DIRECCIÓN", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conDatPerReaOperac.txtDireccPerson.Focus();
                return false;
            }
            return true;
        }


    }
}
