using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmEvaSolConsumo : frmBase
    {
        #region VARIABLES_GLOBALES

        DataTable dtDetalleIngEvalConsumo   = new DataTable("dtDetalleIngEvalConsumo");
        DataTable dtDetalleEgrEvalConsumo   = new DataTable("dtDetalleEgrEvalConsumo");
        clsCNEvalConsumo EvalConsumo        = new clsCNEvalConsumo();
        clsCNSolicitud Solicitud            = new clsCNSolicitud();
        DataTable dtEvalConsumo             = new DataTable("dtEvalConsumo");
        DataTable dtSolicitud               = new DataTable();
        clsCNMoneda ListadoMoneda           = new clsCNMoneda();
        clsCNEvalConsumo CalculaExdenteIng  = new clsCNEvalConsumo();
        Int32 nEstado                       = 0;

        Decimal TotalIngresos    = 0,TotalEgresos     = 0;        

        //Otros Detalles Evaluación Consumo
        DataTable dtTarjetasCredito             = new DataTable();
        DataTable dtCreditos                    = new DataTable();
        DataTable dtBalanceGeneral              = new DataTable();
        DataTable dtReferenciasPersonales       = new DataTable();
        DataTable dtReferenciasLaborales        = new DataTable();
        DataTable dtEstPerdGanancias            = new DataTable();

        DataTable dtSolicitudCreConsumo         = new DataTable();//Contiene los datos de la solictud de crédito

        DataTable dtRiesgoCambiarioCrediticio   = new DataTable();//En base a ésta tabla se calculará el si el cliente está 'SUSTANCIALMENTE EXPUESTO'
        DataTable dtPlantillaBalanceGeneral     = new DataTable();

        private DataTable dtIntervinientes      = new DataTable();
        DataTable dtEscenarioRcc                = new DataTable();//Recupera los escenarios cambiarios del RCC

        //SUPUESTO: Se puede editar una evaluac. Consumo mientras ésta no haya sido vinculada
        //Si se utiliza una evaluac. Consumo como plantilla para realizar otra(al final se guarad con otro ID)
        //Siempre debe existir sólo una evaluac. Consumo vigente

        int IdEvalConsumoAnterior = 0; //Para poner en estado vigente a 0. De ésta evaluación se está tomando como plantilla para una nueva evaluación.
        clsCNEvaluacion cnevaluacion = new clsCNEvaluacion();
        ToolTip toolTip1 = new ToolTip();

        #endregion

        public frmEvaSolConsumo()
        {
            InitializeComponent();            
        }

        #region EVENTOS

        private void Form1_Load(object sender, EventArgs e)
        {
            dtDetalleIngEvalConsumo.Columns.Add("IdDetalleEvalCon", typeof(Int32));
            dtDetalleIngEvalConsumo.Columns.Add("IdEvalConsumo", typeof(Int32));
            dtDetalleIngEvalConsumo.Columns.Add("IdTipIngEgr", typeof(Int16));
            dtDetalleIngEvalConsumo.Columns.Add("IdTipPerDet", typeof(Int16));
            dtDetalleIngEvalConsumo.Columns.Add("cDescriFlujo", typeof(string));
            dtDetalleIngEvalConsumo.Columns.Add("IdMoneda", typeof(Int16));     //se agrego la moneda
            dtDetalleIngEvalConsumo.Columns.Add("nMontoFlujo", typeof(Decimal));
            dtDetalleIngEvalConsumo.Columns.Add("cTipModif", typeof(string));
            dtDetalleIngEvalConsumo.Columns.Add("nPorcPartFlujo", typeof(Decimal));//se agrego la porcentaje de participacion

            dtDetalleEgrEvalConsumo.Columns.Add("IdDetalleEvalCon", typeof(Int32));
            dtDetalleEgrEvalConsumo.Columns.Add("IdEvalConsumo", typeof(Int32));
            dtDetalleEgrEvalConsumo.Columns.Add("IdTipIngEgr", typeof(Int16));
            dtDetalleEgrEvalConsumo.Columns.Add("IdTipPerDet", typeof(Int16));
            dtDetalleEgrEvalConsumo.Columns.Add("IdMoneda", typeof(Int16));     //se agrego la moneda
            dtDetalleEgrEvalConsumo.Columns.Add("cDescriFlujo", typeof(string));
            dtDetalleEgrEvalConsumo.Columns.Add("nMontoFlujo", typeof(Decimal));
            dtDetalleEgrEvalConsumo.Columns.Add("cTipModif", typeof(string));
            dtDetalleEgrEvalConsumo.Columns.Add("nPorcPartFlujo", typeof(Decimal)); //se agrego la porcentaje de participacion

            DataTable dtTipPerDetEvaCons = EvalConsumo.CNdtLisTipPerDetEvaCons();

            DataGridViewComboBoxColumn cmb1 = new DataGridViewComboBoxColumn();
            cmb1.HeaderText         = "Titular | Conyugue";
            cmb1.Name               = "cmb1";
            cmb1.DataPropertyName   = "IdTipPerDet";
            cmb1.FillWeight         = 70;
            cmb1.MaxDropDownItems   = 4;
            cmb1.DataSource         = dtTipPerDetEvaCons;
            cmb1.DisplayMember      = dtTipPerDetEvaCons.Columns["cTipoPerDetEvaCons"].ToString();
            cmb1.ValueMember        = dtTipPerDetEvaCons.Columns["IdTipPerDetEvaCons"].ToString();                       
            this.dtgIngreso.Columns.Add(cmb1);          

            DataGridViewComboBoxColumn cmb2 = new DataGridViewComboBoxColumn();
            cmb2.HeaderText         = "Titular | Conyugue";
            cmb2.Name               = "cmb2";
            cmb2.DataPropertyName   = "IdTipPerDet";
            cmb2.FillWeight         = 70;
            cmb2.MaxDropDownItems   = 4;            
            cmb2.DataSource         = dtTipPerDetEvaCons;
            cmb2.DisplayMember      = dtTipPerDetEvaCons.Columns["cTipoPerDetEvaCons"].ToString();
            cmb2.ValueMember        = dtTipPerDetEvaCons.Columns["IdTipPerDetEvaCons"].ToString();
            this.dtgEgreso.Columns.Add(cmb2);
            this.Habilitar(false);
            this.btn_Vincular1.Enabled  = false;
            btnImprimir1.Enabled        = false;
            btnImprimir2.Enabled = false;

            //se agredo el combo de moneda para ingreso y egreso
            DataTable dtTipListadoMoneda = ListadoMoneda.listarMoneda();

            DataGridViewComboBoxColumn cbMonIngreso = new DataGridViewComboBoxColumn();
            cbMonIngreso.HeaderText         = "Moneda";
            cbMonIngreso.Name               = "cbMonIngreso";
            cbMonIngreso.DataPropertyName   = "idMoneda";
            cbMonIngreso.FillWeight         = 70;
            cbMonIngreso.MaxDropDownItems   = 4;
            cbMonIngreso.DataSource         = dtTipListadoMoneda;
            cbMonIngreso.DisplayMember      = dtTipListadoMoneda.Columns["cMoneda"].ToString();
            cbMonIngreso.ValueMember        = dtTipListadoMoneda.Columns["idMoneda"].ToString();
            this.dtgIngreso.Columns.Add(cbMonIngreso);

            DataGridViewComboBoxColumn cbMonEgreso = new DataGridViewComboBoxColumn();
            cbMonEgreso.HeaderText          = "Moneda";
            cbMonEgreso.Name                = "cbMonEgreso";
            cbMonEgreso.DataPropertyName    = "idMoneda";
            cbMonEgreso.FillWeight          = 70;
            cbMonEgreso.MaxDropDownItems    = 4;
            cbMonEgreso.DataSource          = dtTipListadoMoneda;
            cbMonEgreso.DisplayMember       = dtTipListadoMoneda.Columns["cMoneda"].ToString();
            cbMonEgreso.ValueMember         = dtTipListadoMoneda.Columns["idMoneda"].ToString();
            this.dtgEgreso.Columns.Add(cbMonEgreso);

            //termina en combo   
            //carga las fechas de registro y fecha de vigencia en función a las variables globales
            dtpFecReg.Value = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
            dtpFecVig.Value = dtpFecReg.Value.AddDays(Convert.ToInt32(clsVarApl.dicVarGen["nVigEvaCon"]));

            //============== DES HABILITAR PANELES PRINCIPALES ===========>
            pnlIntervinientes.Enabled = false;
            foreach (TabPage item in tbcBase1.TabPages)
            {
                ((Control)item).Enabled = false;
                item.Show();
            }
            //============================================================>
        }        

        private void txtNumEva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Int32 idNumEva  = Convert.ToInt32(txtNumEva.Text);                
                dtEvalConsumo   = EvalConsumo.CNdtEvalConsumo(idNumEva);
                btnImprimir1.Enabled = true;
                btnImprimir2.Enabled = true;

                if ( dtEvalConsumo.Rows.Count > 0 )
                {
                    txtNumEva.Text                      =   dtEvalConsumo.Rows[0]["IdEvalConsumo"].ToString();
                    dtpFecReg.Value                     =   Convert.ToDateTime(dtEvalConsumo.Rows[0]["dFechaReg"]);
                    dtpFecVig.Value                     =   Convert.ToDateTime(dtEvalConsumo.Rows[0]["dFechaVig"]) ;
                    cboMoneda1.SelectedValue            =   Convert.ToInt32(dtEvalConsumo.Rows[0]["IdMoneda"]);                    
                    txtFortaleza.Text                   =   dtEvalConsumo.Rows[0]["cFortalezas"].ToString();
                    txtDebilidad.Text                   =   dtEvalConsumo.Rows[0]["cDebilidades"].ToString();
                    txtOtros.Text                       =   dtEvalConsumo.Rows[0]["cOtrComentarios"].ToString();
                    cboPorcenIngReal.SelectedValue      =   Convert.ToInt32(dtEvalConsumo.Rows[0]["nPorCenIngReal"]);
                    cboTipGarRDS.SelectedValue          =   Convert.ToInt32(dtEvalConsumo.Rows[0]["IdTipGarRDS"]);
                    txtNumCuoRDS.Text                   =   dtEvalConsumo.Rows[0]["nNumCuoRDS"].ToString() ;
                    txtComenRDS.Text                    =   dtEvalConsumo.Rows[0]["cComenRDS"].ToString();
                    txtMontProp.Text                    =   dtEvalConsumo.Rows[0]["nMonPropuesto"].ToString();
                    txtNroCuotas.Text                   =   dtEvalConsumo.Rows[0]["nNumcuotas"].ToString();
                    txtTEM.Text                         =   dtEvalConsumo.Rows[0]["nTEM"].ToString();
                    txtCuotaAprox.Text                  =   dtEvalConsumo.Rows[0]["nCuotaAprox"].ToString();
                    txtCoberCuota.Text                  =   dtEvalConsumo.Rows[0]["nCoberturaCuota"].ToString();
                    txtTipCamFij.Text                   =   dtEvalConsumo.Rows[0]["nTipoCambio"].ToString();
                    txtNumSolicitud.Text                =   dtEvalConsumo.Rows[0]["idSolicitud"].ToString();

                    this.conBusCli1.txtCodInst.Text     = Convert.ToString(dtEvalConsumo.Rows[0]["cCodCliente"]).Substring(0, 3);
                    this.conBusCli1.txtCodAge.Text      = Convert.ToString(dtEvalConsumo.Rows[0]["cCodCliente"]).Substring(3, 3);
                    this.conBusCli1.txtCodCli.Text      = Convert.ToString(dtEvalConsumo.Rows[0]["cCodCliente"]).Substring(6);                    
                    this.conBusCli1.txtNroDoc.Text      = Convert.ToString(dtEvalConsumo.Rows[0]["cDocumentoID"]);
                    this.conBusCli1.txtNombre.Text      = Convert.ToString(dtEvalConsumo.Rows[0]["cNombre"]);
                    this.conBusCli1.txtDireccion.Text   = Convert.ToString(dtEvalConsumo.Rows[0]["cDireccion"]);
                    this.txtTipCamFij.Text              = Convert.ToString(dtEvalConsumo.Rows[0]["nTipoCambio"]);  

                    //SE AGREGO INTERVINIENTES 
                    dtIntervinientes = EvalConsumo.CNdtRetornaIntervCons(idNumEva);
                    dtIntervinientes.DefaultView.RowFilter = ("lVigente <> 0");
                    dtgIntervinientes.DataSource = dtIntervinientes;
                    
                    //RATIOS
                    txtCuotaExcedente.Text      = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratCuotaExcedente"]).ToString();
                    txtDeudaTotalPatrimonio.Text= Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratDeudaPatrimonio"]).ToString();
                    txtGarantiasPrestamo.Text   = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratGarantiaPrestamo"]).ToString();
                    txtIngresosExcedente.Text   = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratIngrConyugueExcedente"]).ToString();

                    //RCC
                    txtRCC.Text          = dtEvalConsumo.Rows[0]["cRCC"].ToString();
                    TxtSustExpuesto.Text = dtEvalConsumo.Rows[0]["cSustExpuesto"].ToString();

                    //GARANTIAS
                    txtGaranTitular.Text = Convert.ToDecimal (dtEvalConsumo.Rows[0]["nGarantTitular"]).ToString();
                    txtGaranAval.Text    = Convert.ToDecimal (dtEvalConsumo.Rows[0]["nGarantAval"]).ToString();

                    //============= Verificar que exista una Solicitud vigente de crédito Consumo ===========>
                    dtSolicitudCreConsumo = Solicitud.CNdtBuscarPropuestaCreConsumo(Convert.ToInt32(conBusCli1.txtCodCli.Text));

                    if (dtSolicitudCreConsumo.Rows.Count > 0)
                    {
                        CargarPropuestaEconomica();
                    }
                    else
                    {
                        MessageBox.Show("No existe solicitud de CRÉDITO TIPO CONSUMO vigente para éste cliente", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //=======================================================================================>

                    //==================================== Otros detalle Evaluación Consumo ========================================================================>
                    DataSet dsOtrosEvalConsumo  = EvalConsumo.CNdsRetornaOtrosDetalleEvalConsumo(idNumEva);
                    dtTarjetasCredito           = dsOtrosEvalConsumo.Tables[0];
                    dtCreditos                  = dsOtrosEvalConsumo.Tables[1];
                    dtBalanceGeneral            = dsOtrosEvalConsumo.Tables[2];
                    dtReferenciasPersonales     = dsOtrosEvalConsumo.Tables[3];
                    dtReferenciasLaborales      = dsOtrosEvalConsumo.Tables[4];
                    dtRiesgoCambiarioCrediticio = dsOtrosEvalConsumo.Tables[5];
                    dtEstPerdGanancias          = dsOtrosEvalConsumo.Tables[6];

                    if (dtEstPerdGanancias.Rows.Count == 0)
                    {
                        dtEstPerdGanancias = new clsCNEvalEmp().CNdtEstPerGanan(0);
                    }

                    //TARJETAS CREDITO
                    dtTarjetasCredito.DefaultView.RowFilter = ("cTipModif <> 'D'");
                    dtgTarjetasCre.DataSource   = dtTarjetasCredito;                   

                    //CREDITOS EN OTRAS INSTITUCIONES
                    dtCreditos.DefaultView.RowFilter = ("cTipModif <> 'D'");
                    dtgCre.DataSource = dtCreditos;

                    //REFERENCIAS PERSONALES
                    dtReferenciasPersonales.DefaultView.RowFilter = ("cTipModif <> 'D'");
                    dtgRefPersonales.DataSource = dtReferenciasPersonales;

                    //REFERENCIAS LABORALES
                    dtReferenciasLaborales.DefaultView.RowFilter = ("cTipModif <> 'D'");
                    dtgRefLaborales.DataSource  = dtReferenciasLaborales;

                    //ESTADO PERDIDAS Y GANANCIAS
                    dtgEstPerdGanan.DataSource = dtEstPerdGanancias;

                    AgregarComboBoxs();
                    FormatoGridIntervinientes();

                    DarFormatoGridTarjetas();
                    DarFormatoOtrosCreditos();
                    DarFormatoRefPersonales();
                    DarFormatoRefLaborales();

                    DarFormatoEstPerdGanancias("N");

                    AsignarBalanceGeneral();

                    //Cargar los escenarios del Riesgo cambiario Crediticio (RCC)
                    dtEscenarioRcc = EvalConsumo.CargarEscenarioRCC();
                    //================================================================================================================================================>

                    //============== DES HABILITAR PANELES PRINCIPALES ===========>
                    pnlIntervinientes.Enabled = true;
                    foreach (TabPage item in tbcBase1.TabPages)
                    {
                        ((Control)item).Enabled = false;
                    }
                    //============================================================>

                    IdEvalConsumoAnterior = 0;//Puesto que sóplo se está editando ésta evaluac. Consumo
                }
                else
                {
                    MessageBox.Show("No se encuentra el número de evaluación ingresado", "Valida Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // cargando el detalle de Ingresos               
                dtDetalleIngEvalConsumo     = EvalConsumo.CNdtDetalleEvalConsumo(idNumEva, 1);
                dtDetalleIngEvalConsumo.DefaultView.RowFilter = ("cTipModif <> 'D'");
                this.dtgIngreso.DataSource  = dtDetalleIngEvalConsumo.DefaultView;

                // cargando el detalle de Egresos
                dtDetalleEgrEvalConsumo     = EvalConsumo.CNdtDetalleEvalConsumo(idNumEva, 2);
                dtDetalleEgrEvalConsumo.DefaultView.RowFilter = ("cTipModif <> 'D'");
                this.dtgEgreso.DataSource   = dtDetalleEgrEvalConsumo.DefaultView;
                this.FormatoGrid();

                if (dtDetalleIngEvalConsumo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDetalleIngEvalConsumo.Rows.Count; i++)
                    {
                        this.dtgIngreso.Rows[i].Cells["cmb1"].Value         = Convert.ToInt32(dtDetalleIngEvalConsumo.Rows[i]["IdTipPerDet"].ToString());
                        this.dtgIngreso.Rows[i].Cells["cbMonIngreso"].Value = Convert.ToInt32(dtDetalleIngEvalConsumo.Rows[i]["IdMoneda"].ToString());
                    }
                }

                if (dtDetalleEgrEvalConsumo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDetalleEgrEvalConsumo.Rows.Count; i++)
                    {
                        this.dtgEgreso.Rows[i].Cells["cmb2"].Value          = Convert.ToInt32(dtDetalleEgrEvalConsumo.Rows[i]["IdTipPerDet"].ToString());
                        this.dtgEgreso.Rows[i].Cells["cbMonEgreso"].Value   = Convert.ToInt32(dtDetalleEgrEvalConsumo.Rows[i]["IdMoneda"].ToString());
                    }
                }
                sumaIngresos();
                CalculaPorcParticipIng();
                sumaEgresos();
                CalculaPorcParticipEgr();
                CalculaExcedente();
                this.Habilitar(true);
                btnGrabar1.Enabled = false;
            }
        }

        private void cboPorcenIngReal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TotalIngresos > 0 && TotalEgresos > 0)
            {
                CalculaExcedente();
                CalcularCuotaAprox();
            }
        }

        private void cboMonedaIngresos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgIngreso.CurrentCell.OwningColumn.Name == "cbMonIngreso")
            {
                DataGridViewComboBoxEditingControl cboMoneda = sender as DataGridViewComboBoxEditingControl;
                if (cboMoneda != null)
                {
                    dtgIngreso.Rows[dtgIngreso.CurrentRow.Index].Cells[8].Selected = true;
                    dtgIngreso.Rows[dtgIngreso.CurrentRow.Index].Cells[10].Selected = true;
                }
            }
        }

        private void cboMoneda1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgIngreso.EndEdit();
            dtgEgreso.EndEdit();
            sumaIngresos();
            sumaEgresos();
            if (TotalIngresos > 0 && TotalEgresos > 0)
            {
                CalculaExcedente();
                CalcularCuotaAprox();
            }
        }

        private void txtMontProp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontProp.Text)) return;
            decimal nMonto = Convert.ToDecimal(txtMontProp.Text);
            txtMontProp.Text = nMonto.ToString("##,##0.00");
            CalcularCuotaAprox();
            CalcularRatios();
        }

        private void txtNroCuotas_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAprox();
            CalcularRatios();
        }

        private void txtTEM_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAprox();
            CalcularRatios();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int CodigoCliente = Convert.ToInt32(conBusCli1.txtCodCli.Text);
            int IdEvalConsumo = Convert.ToInt32(txtNumEva.Text);

            String AgenEmision = clsVarApl.dicVarGen["cNomAge"];
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("pnidCli", CodigoCliente.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
            paramlist.Add(new ReportParameter("IdEvalConsumo", IdEvalConsumo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("DataSetCliente", new clsRPTCNClientes().CNRetornoCliente(CodigoCliente)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            dtslist.Add(new ReportDataSource("dtsTarjetasCre", new clsRPTCNCredito().CNTarjetasCreEvalConsumo(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsOtrosCre", new clsRPTCNCredito().CNOtrosCreEvalConsumo(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsRefPersonal", new clsRPTCNCredito().CNRefPersonalEvalConsumo(IdEvalConsumo)));

            dtslist.Add(new ReportDataSource("dtsRefLaboral", new clsRPTCNCredito().CNRefLaboralEvalConsumo(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsEvalConsumo", new clsRPTCNCredito().CNEvalConsumo(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsIngresosTitular", new clsRPTCNCredito().CNIngresosTitular(IdEvalConsumo)));

            dtslist.Add(new ReportDataSource("dtsIngresosConyugue", new clsRPTCNCredito().CNIngresosConyugue(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsEgresos", new clsRPTCNCredito().CNEgresos(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsBalanceGeneral", new clsRPTCNCredito().CNBalanceGeneral(IdEvalConsumo)));
            dtslist.Add(new ReportDataSource("dtsEstPerdGanancias", new clsRPTCNCredito().CNEstPerdGananciasEvalConsumo(IdEvalConsumo)));

            string reportpath = "rptEvalConsumo.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Habilitar(false);
            btnImprimir1.Enabled = false;
            btnImprimir2.Enabled = false;

            //Ingresos  y Egresos
            dtDetalleEgrEvalConsumo.Clear();
            dtDetalleIngEvalConsumo.Clear();
            //SE AGREGO INTERVINIENTES  
            dtgIntervinientes.DataSource = null;

            this.txtNumEva.Text = "";
            this.dtpFecReg.Text = "";
            this.dtpFecVig.Text = "";
            this.txtFortaleza.Text = "";
            this.txtDebilidad.Text = "";
            this.txtOtros.Text = "";
            this.cboPorcenIngReal.Text = "";
            this.cboTipGarRDS.Text = "";
            this.txtNumCuoRDS.Text = "";
            this.txtComenRDS.Text = "";
            this.txtNumReaExede.Text = "";
            this.txtNumReaCuota.Text = "";
            this.txtMontProp.Text = "";
            this.txtNroCuotas.Text = "";
            this.txtTEM.Text = "";
            this.txtCuotaAprox.Text = "";
            this.txtCoberCuota.Text = "";
            this.txtTipCamFij.Text = "";
            this.txtNumSolicitud.Text = "";

            this.conBusCli1.txtCodInst.Text = "";
            this.conBusCli1.txtCodAge.Text = "";
            this.conBusCli1.txtCodCli.Text = "";
            this.conBusCli1.txtNroDoc.Text = "";
            this.conBusCli1.txtNombre.Text = "";
            this.conBusCli1.txtDireccion.Text = "";
            this.conBusCli1.txtCodCli.Enabled = true;
            this.conBusCli1.txtCodCli.Focus();

            //============== DESHABILITAR PANELES PRINCIPALES ===============>
            pnlIntervinientes.Enabled = false;
            foreach (TabPage item in tbcBase1.TabPages)
            {
                ((Control)item).Enabled = false;
            }
            //============================================================>

            //------------------Limpiar TAB: Créditos - Balance General ------------------->
            dtgTarjetasCre.DataSource = null;
            dtgCre.DataSource = null;
            foreach (Control item in grbBalanceGeneral.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
                else if (item is txtCBNumerosEnteros)
                {
                    item.Text = "0";
                }
                else
                {
                    if (item is TextBox)
                        ((TextBox)item).Clear();
                }
            }
            dtTarjetasCredito.Clear();
            dtCreditos.Clear();
            dtBalanceGeneral.Clear();
            dtPlantillaBalanceGeneral.Clear();
            //---------------------------------------------------------------------------->

            //------------------ Limpiar TAB: Referencias ------------------->
            dtgRefPersonales.DataSource = null;
            dtgRefLaborales.DataSource = null;
            dtReferenciasPersonales.Clear();
            dtReferenciasLaborales.Clear();
            //-------------------------------------------------------------->

            //---------------Limpiar TAB: Análisis Ratios------------------->
            foreach (Control item in grbDatosCreSol.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
                else if (item is txtCBNumerosEnteros)
                {
                    item.Text = "0";
                }
                else
                {
                    if (item is TextBox)
                        ((TextBox)item).Clear();
                }

            }

            //---------------Limpiar TAB: Propuesta------------------->
            foreach (Control item in this.grbEvalCualitativa.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
                else if (item is txtCBNumerosEnteros)
                {
                    item.Text = "0";
                }
                else
                {
                    if (item is TextBox)
                        ((TextBox)item).Clear();
                }

            }

            foreach (Control item in grbRDS.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
                else if (item is txtCBNumerosEnteros)
                {
                    item.Text = "0";
                }
                else
                {
                    if (item is TextBox)
                        ((TextBox)item).Clear();
                }
            }

            foreach (Control item in grbRatios.Controls)
            {
                if (item is txtNumRea)
                {
                    item.Text = "0.00";
                }
                else if (item is txtCBNumerosEnteros)
                {
                    item.Text = "0";
                }
                else
                {
                    if (item is TextBox)
                        ((TextBox)item).Clear();
                }
            }
            txtRCC.Text = "";
            TxtSustExpuesto.Text = "";

            dtSolicitudCreConsumo.Clear();
            dtRiesgoCambiarioCrediticio.Clear();
            dtEscenarioRcc.Clear();
            //----------------------------------------------------------->
            //---------------Limpiar TAB: Perdidas y ganancias------------------->
            dtgEstPerdGanan.DataSource = null;
            dtEstPerdGanancias = new clsCNEvalEmp().CNdtEstPerGanan(0);
            dtgEstPerdGanan.DataSource = dtEstPerdGanancias;
            DarFormatoEstPerdGanancias("N");
            //----------------------------------------------------------->
        }

        private void btn_Vincular1_Click(object sender, EventArgs e)
        {
            Int32 nIdCliente = Convert.ToInt32(this.conBusCli1.txtCodCli.Text);
            Int32 nIdEvalCons = Convert.ToInt32(this.txtNumEva.Text);
            dtSolicitud = Solicitud.CNdtLisSolEstSol(nIdCliente);
            dtSolicitud.DefaultView.RowFilter = ("nTipCre=3");
            if (dtSolicitud.Rows.Count > 0)
            {
                for (int i = 0; i < dtSolicitud.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtSolicitud.Rows[i]["nTipCre"]) == 3)
                    {
                        frmBusSolCre frmBusSolCre1 = new frmBusSolCre();
                        frmBusSolCre1.nFormCall = 1;
                        frmBusSolCre1.cargadatos(nIdCliente, nIdEvalCons);
                        frmBusSolCre1.ShowDialog();
                        txtNumSolicitud.Text = Convert.ToString(frmBusSolCre1.nNumSolicitud);
                        grbNroSolicitud.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("La Solicitud de Crédito no es CONSUMO para VINCULAR", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Evaluación ya Vinculada o No existe Solicitud Crédito CONSUMO para Vincular", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtGaranTitular_TextChanged(object sender, EventArgs e)
        {
            RatioGarantiaPrestamo();
        }

        private void txtGaranAval_TextChanged(object sender, EventArgs e)
        {
            RatioGarantiaPrestamo();
        }

        private void dtgRefPersonales_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgRefPersonales.CurrentCell.ColumnIndex == 7)//Combo Referencias Personales
            {
                if (this.dtgRefPersonales.IsCurrentCellDirty)
                    dtgRefPersonales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgRefLaborales_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgRefLaborales.CurrentCell.ColumnIndex == 7)//Combo Referencias Laborales
            {
                if (this.dtgRefLaborales.IsCurrentCellDirty)
                    dtgRefLaborales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void txtOtrosSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) this.txtOtrosDolares.Focus();
        }

        private void txtOtrosSoles_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtOtrosDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtOtrasDeudasSoles.Focus();
        }

        private void txtOtrosDolares_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            int idsolici = Convert.ToInt32(dtSolicitudCreConsumo.Rows[0]["idSolicitud"]);
            var dtPropuesta = cnevaluacion.CNConsPropuestaCreConsumo(idsolici);
            if (dtPropuesta.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("x_idSolicitud", idsolici.ToString(), false));

                DataTable dtRutaLogo = new clsRPTCNAgencia().CNRutaLogo();

                dtslist.Add(new ReportDataSource("dtsRutaLogo", dtRutaLogo));
                dtslist.Add(new ReportDataSource("dtsPropuestaCreConsumo", this.cnevaluacion.CNConsPropuestaConsumo(idsolici)));
                dtslist.Add(new ReportDataSource("dtsDatoCredito", dtPropuesta));
                dtslist.Add(new ReportDataSource("dtsExcepciones", cnevaluacion.CNConsExcepciones(idsolici)));

                string reportpath = "RptPropuestaCreditoConsum.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor primero debe de vincular la evaluación con la solicitud", "Validación de vinculación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btn_Vincular1.PerformClick();
            }
        }

        private void tbcBase1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Créditos - Balance General
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();

            //Estado de Resultados
            sumaIngresos();
            sumaEgresos();
            CalcularExcedente();

            //Cálculo de Ratios
            CalcularRatios();
        }

        private void txtTotalPasivoSoles_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstPerdGanan();
        }

        private void txtTotalIngrEstResulSolesTotal_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstPerdGanan();
        }

        private void txtTotalEgrEstResulSolesTotal_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstPerdGanan();
        }
        
        #endregion

        #region GRABAR

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            dtgIntervinientes.EndEdit();
            this.registrarRastreo(Convert.ToInt32(conBusCli1.idCli), 0, "Inicio - Registro de Evaluación Consumo", btnGrabar1);
            validaGrabar();
            
            if (nEstado == 0)
            {
                dtEvalConsumo.Rows[0]["cDebilidades"]      = Convert.ToString(txtDebilidad.Text);
                dtEvalConsumo.Rows[0]["cFortalezas"]       = Convert.ToString(txtFortaleza.Text);
                dtEvalConsumo.Rows[0]["cOtrComentarios"]   = Convert.ToString(txtOtros.Text);
                dtEvalConsumo.Rows[0]["nNumCuoRDS"]        = string.IsNullOrEmpty(txtNumCuoRDS.Text) ? 0 : Convert.ToInt32(txtNumCuoRDS.Text);
                dtEvalConsumo.Rows[0]["cComenRDS"]         = Convert.ToString(txtComenRDS.Text);
                dtEvalConsumo.Rows[0]["nMonPropuesto"]     = Convert.ToDecimal (txtMontProp.Text);
                dtEvalConsumo.Rows[0]["nNumcuotas"]        = Convert.ToInt32(txtNroCuotas.Text);
                dtEvalConsumo.Rows[0]["nTEM"]              = Convert.ToDecimal (txtTEM.Text);
                dtEvalConsumo.Rows[0]["nCuotaAprox"]       = Convert.ToDecimal (txtCuotaAprox.Text);
                dtEvalConsumo.Rows[0]["nCoberturaCuota"]   = Convert.ToDecimal (txtCoberCuota.Text);
                dtEvalConsumo.Rows[0]["IdMoneda"]          = Convert.ToInt32(cboMoneda1.SelectedValue);
                dtEvalConsumo.Rows[0]["nPorCenIngReal"]    = Convert.ToDecimal (cboPorcenIngReal.SelectedValue);
                dtEvalConsumo.Rows[0]["IdTipGarRDS"]       = Convert.ToDecimal (cboTipGarRDS.SelectedValue);
                dtEvalConsumo.Rows[0]["nTipoCambio"]       = Convert.ToDecimal (txtTipCamFij.Text);

                dtEvalConsumo.Rows[0]["cRCC"]               = txtRCC.Text;
                dtEvalConsumo.Rows[0]["cSustExpuesto"]      = TxtSustExpuesto.Text;
                dtEvalConsumo.Rows[0]["nGarantTitular"]     = Convert.ToDecimal (txtGaranTitular.Text);
                dtEvalConsumo.Rows[0]["nGarantAval"]        = Convert.ToDecimal (txtGaranAval.Text);

                dtEvalConsumo.Rows[0]["ratCuotaExcedente"]          = Convert.ToDecimal (txtCuotaExcedente.Text);
                dtEvalConsumo.Rows[0]["ratDeudaPatrimonio"]         = Convert.ToDecimal (txtDeudaTotalPatrimonio.Text);
                dtEvalConsumo.Rows[0]["ratGarantiaPrestamo"]        = Convert.ToDecimal (txtGarantiasPrestamo.Text);
                dtEvalConsumo.Rows[0]["ratIngrConyugueExcedente"]   = Convert.ToDecimal (txtIngresosExcedente.Text);

                //EVALUACIÓN COMSUMO
                DataSet dsEvalConsumo = new DataSet("dsEvalConsumo");
                dsEvalConsumo.Tables.Add(dtEvalConsumo);
                string xmlEvalConsumo   = dsEvalConsumo.GetXml();
                xmlEvalConsumo          = clsCNFormatoXML.EncodingXML(xmlEvalConsumo);
                dsEvalConsumo.Tables.Clear();

                //INGRESOS
                DataSet dsDetIngEvalConsumo     = new DataSet("dsDetIngEvalConsumo");
                dsDetIngEvalConsumo.Tables.Add(dtDetalleIngEvalConsumo);
                string xmlDetIngEvalConsumo     = dsDetIngEvalConsumo.GetXml();
                xmlDetIngEvalConsumo            = clsCNFormatoXML.EncodingXML(xmlDetIngEvalConsumo);
                dsDetIngEvalConsumo.Tables.Clear();

                //EGRESOS
                DataSet dsDetEgrEvalConsumo     = new DataSet("dsDetEgrEvalConsumo");
                dsDetEgrEvalConsumo.Tables.Add(dtDetalleEgrEvalConsumo);
                string xmlDetEgrEvalConsumo     = dsDetEgrEvalConsumo.GetXml();
                xmlDetEgrEvalConsumo            = clsCNFormatoXML.EncodingXML(xmlDetEgrEvalConsumo);
                dsDetEgrEvalConsumo.Tables.Clear();

                //INTERVINIENTES
                dtIntervinientes.AcceptChanges();
                DataTable dtDetInterv   = this.dtIntervinientes.Copy();
                DataSet dsDetInterv     = new DataSet("dsDetInterv");
                dtDetInterv.TableName   = "dtDetInterv";
                dsDetInterv.Tables.Add(dtDetInterv);
                string xmlDetInterv     = clsCNFormatoXML.EncodingXML(dsDetInterv.GetXml());
                dsDetInterv.Tables.Clear();

                //RIESGO CAMBIARIO CREDITICIO
                DataTable dtAuxRiesgoCambiarioCrediticio    = dtRiesgoCambiarioCrediticio.Copy();
                dtAuxRiesgoCambiarioCrediticio.TableName    = "dtRiesgoCambiarioCrediticio";
                DataSet dsRiesgoCambiarioCrediticio         = new DataSet("dsRiesgoCambiarioCrediticio");
                dsRiesgoCambiarioCrediticio.Tables.Add(dtAuxRiesgoCambiarioCrediticio);
                string xmlRiesgoCambiarioCrediticio         = dsRiesgoCambiarioCrediticio.GetXml();
                xmlRiesgoCambiarioCrediticio                = clsCNFormatoXML.EncodingXML(xmlRiesgoCambiarioCrediticio);
                dsRiesgoCambiarioCrediticio.Tables.Clear();

                //TARJETAS DE CRÉDITO
                DataTable dtAuxTarjetasCredito  = dtTarjetasCredito.Copy();
                dtAuxTarjetasCredito.TableName  = ("dtTarjetasCredito");
                DataSet dsTarjetasCredito       = new DataSet("dsTarjetasCredito");
                dsTarjetasCredito.Tables.Add(dtAuxTarjetasCredito);
                string xmlTarjetasCredito       = dsTarjetasCredito.GetXml();
                xmlTarjetasCredito              = clsCNFormatoXML.EncodingXML(xmlTarjetasCredito);
                dsTarjetasCredito.Tables.Clear();

                //CRÉDITOS OTRAS INSTITUCIONES
                DataTable dtAuxdtCredito    = dtCreditos.Copy();              
                dtAuxdtCredito.TableName    = ("dtCreditos");
                DataSet dsCreditos          = new DataSet("dsCreditos");
                dsCreditos.Tables.Add(dtAuxdtCredito);
                string xmlCreditos          = dsCreditos.GetXml();
                xmlCreditos                 = clsCNFormatoXML.EncodingXML(xmlCreditos);
                dsCreditos.Tables.Clear();

                //================================= BALANCE GENERAL ==========================================>
            #region PlantillaBalanceGeneral
                Char cAccion = 'I';
                if (dtBalanceGeneral.Rows.Count>0)
	            {
                    cAccion = Convert.ToChar(dtBalanceGeneral.Rows[0]["cTipModif"]);
                    if (cAccion.Equals('I'))//NUEVO con datos de una evaluación anterior (tomado como plantilla)
                    {
                        dtPlantillaBalanceGeneral = EvalConsumo.CargarPlantillaBalanceGeneral();
                        dtBalanceGeneral = BalanceGeneral(dtPlantillaBalanceGeneral, cAccion, 0);
                    }
                    else//EDICION
                    {
                        //IdEvalConsumoAnterior: Evaluación de la que está tomando como plantilla para la nueva evaluación
                        dtBalanceGeneral = BalanceGeneral(dtBalanceGeneral, cAccion, IdEvalConsumoAnterior);
                    }                    
	            }
                else//Nueva evaluación
	            {                    
                    dtBalanceGeneral.Clear();//Limpiar Balance General, para cargar nuevos Balance General
                    dtPlantillaBalanceGeneral = EvalConsumo.CargarPlantillaBalanceGeneral();//Plantilla Balance General
                    dtBalanceGeneral            = BalanceGeneral(dtPlantillaBalanceGeneral, cAccion,0);
	            }              
#endregion
                DataTable dtAuxBalanceGeneral   = dtBalanceGeneral.Copy();
                dtAuxBalanceGeneral.TableName   = "dtBalanGenEvaConsumo";
                DataSet dsBalanGenEvaConsumo    = new DataSet("dsBalanGenEvaConsumo");
                dsBalanGenEvaConsumo.Tables.Add(dtAuxBalanceGeneral);
                string xmlBalanceGeneral        = dsBalanGenEvaConsumo.GetXml();
                xmlBalanceGeneral               = clsCNFormatoXML.EncodingXML(xmlBalanceGeneral);
                dsBalanGenEvaConsumo.Tables.Clear();
                //============================================================================================>

                //REFERENCIAS PERSONALES
                DataTable dtAuxReferenciasPersonales    = dtReferenciasPersonales.Copy();
                dtAuxReferenciasPersonales.TableName    = ("dtReferenciasPersonales");
                DataSet dsReferenciasPersonales         = new DataSet("dsReferenciasPersonales");
                dsReferenciasPersonales.Tables.Add(dtAuxReferenciasPersonales);
                string xmlReferenciasPersonales         = dsReferenciasPersonales.GetXml();
                xmlReferenciasPersonales                = clsCNFormatoXML.EncodingXML(xmlReferenciasPersonales);
                dsReferenciasPersonales.Tables.Clear();

                //REFERENCIAS LABORALES
                DataTable dtAuxdtReferenciasLaborales   = dtReferenciasLaborales.Copy();
                dtAuxdtReferenciasLaborales.TableName   = ("dtReferenciasLaborales");
                DataSet dsReferenciasLaborales          = new DataSet("dsReferenciasLaborales");
                dsReferenciasLaborales.Tables.Add(dtAuxdtReferenciasLaborales);
                string xmlReferenciasLaborales          = dsReferenciasLaborales.GetXml();
                xmlReferenciasLaborales                 = clsCNFormatoXML.EncodingXML(xmlReferenciasLaborales);
                dsReferenciasLaborales.Tables.Clear();
           
                //ESTADO DE PERDIDAS Y GANANCIAS
                EditarDataTableEstPerdganan();
                DataTable dtEstPerdGanan                = dtEstPerdGanancias.Copy();
                dtEstPerdGanan.TableName                = "dtEstPerdGanancias";
                DataSet dsEstPerdGanancias              = new DataSet("dsEstPerdGanancias");
                dsEstPerdGanancias.Tables.Add(dtEstPerdGanan);
                string xmlEstPerdGanancias              = dsEstPerdGanancias.GetXml();
                xmlEstPerdGanancias                     = clsCNFormatoXML.EncodingXML(xmlEstPerdGanancias);
                dsEstPerdGanancias.Tables.Clear();


                DataTable dtResulRegEvalConsumo = EvalConsumo.CNdtRegEvalConsumo(xmlEvalConsumo, xmlDetIngEvalConsumo, xmlDetEgrEvalConsumo, xmlDetInterv,
                                                xmlRiesgoCambiarioCrediticio, xmlTarjetasCredito, xmlCreditos, xmlReferenciasPersonales, xmlReferenciasLaborales, 
                                                xmlBalanceGeneral, xmlEstPerdGanancias, IdEvalConsumoAnterior);

                guardarPropuesta();

                this.txtNumEva.Text             = dtResulRegEvalConsumo.Rows[0][0].ToString();
                MessageBox.Show("Evaluación N° " + dtResulRegEvalConsumo.Rows[0][0].ToString() + " Registrada Correctamente", "Registro de Evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Habilitar(true);
                this.btnGrabar1.Enabled = false;
                this.btnNuevo1.Enabled  = false;

                //======================================>
                pnlIntervinientes.Enabled   = false;
                foreach (TabPage item in tbcBase1.TabPages)
	            {
                    ((Control)item).Enabled = false;
	            }                
                //======================================>
                btnImprimir1.Enabled    = true;
                btnImprimir2.Enabled = true;
                DarFormatoEstPerdGanancias("G");
                this.registrarRastreo(Convert.ToInt32(conBusCli1.idCli), 0, "Fin - Registro de Evaluación Consumo", btnGrabar1);
            }
        }

        private void guardarPropuesta()
        {
            int idSolicitud = Convert.ToInt32(dtSolicitudCreConsumo.Rows[0]["idSolicitud"]);
            decimal nGarantia = 0;
            nGarantia = txtGarantia.nDecValor;

            string cEntornoFamDomicil = txtEntornoFamDomicil.Text;
            string cVerificLaboral = txtVerificLaboral.Text;
            string cOtrosIngrAcred = txtOtrosIngrAcred.Text;

            string cAvalGarante = txtAvalGarante.Text;
            string cDescrPatrim = txtDescrPatrim.Text;
            string cDestinoCre = txtDestinoCre.Text;

            this.cnevaluacion.CNInsUpdPropuestaCreConsumo(idSolicitud, nGarantia,
                            cEntornoFamDomicil, cVerificLaboral, cOtrosIngrAcred,
                            cAvalGarante, cDescrPatrim, cDestinoCre);            
        }

        //Recibe una Tabla que contendrá el balance General, y deacuerdo ala accion
        //cAccion I:insert U:update
        private DataTable BalanceGeneral(DataTable dtTblBalanceGeneral, Char cAccion, int idEvalConsum)
        {
            DataTable dtTablaBalanceGeneral = dtBalanceGeneral.Clone();

            if (dtTblBalanceGeneral.Columns.Count == 3)//TOTALMENTE NUEVO -- o con plantilla de evaluac anterior
            {
                for (int fila = 0; fila < dtTblBalanceGeneral.Rows.Count; fila++)
                {
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtTotalActivoSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtTotalActivoDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("PASIVO"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtPasivoSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtPasivoDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("PATRIMONIO"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtPatrimonioSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]             = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtPatrimonioDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO CORRIENTE"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtTotalActivoCorrSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtTotalActivoCorrDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO NO CORRIENTE"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtInmuebleTotalActivoNoCorrSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtInmuebleTotalActivoNoCorrDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("AHORROS/DEPÓSITOS A PLAZOS"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtAhoDepPlazoFijoSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtAhoDepPlazoFijoDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("VEHÍCULOS"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtVehiculoSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtVehiculoDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("INMUEBLES/ACTIVO FIJO"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtInmuebleSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtInmuebleDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }

                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().ToUpper().Equals("OTROS/ENSERES"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"] = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"] = txtOtrosSoles.nvalor;
                        drFilaS["idMoneda"] = 1;
                        drFilaS["IdEvalConsumo"] = idEvalConsum;
                        drFilaS["idItemPadre"] = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"] = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"] = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"] = txtOtrosDolares.nvalor;
                        drFilaD["idMoneda"] = 2;
                        drFilaD["IdEvalConsumo"] = idEvalConsum;
                        drFilaD["idItemPadre"] = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"] = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }


                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("SALDO DE TARJETAS DE CRÉDITO"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtSaldoTarjetasCreSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtSaldoTarjetasCreDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("SALDO DE CRÉDITOS"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtSaldoCreSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtSaldoCreDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("OTRAS DEUDAS"))
                    {   //SOLES
                        DataRow drFilaS = dtTablaBalanceGeneral.NewRow();
                        drFilaS["idBalanGenEvaConsumo"] = 0;
                        drFilaS["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaS["nMonto"]               = Convert.ToDecimal (txtOtrasDeudasSoles.Text);
                        drFilaS["idMoneda"]             = 1;
                        drFilaS["IdEvalConsumo"]        = idEvalConsum;
                        drFilaS["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaS["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaS);

                        //DÓLARES
                        DataRow drFilaD = dtTablaBalanceGeneral.NewRow();
                        drFilaD["idBalanGenEvaConsumo"] = 0;
                        drFilaD["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConcepto"];
                        drFilaD["nMonto"]               = Convert.ToDecimal (txtOtrasDeudasDolares.Text);
                        drFilaD["idMoneda"]             = 2;
                        drFilaD["IdEvalConsumo"]        = idEvalConsum;
                        drFilaD["idItemPadre"]          = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFilaD["cTipModif"]            = "I";
                        dtTablaBalanceGeneral.Rows.Add(drFilaD);
                    }
                }
            }
            else//=========================== (EDICION )  ===========================================
            {
                for (int fila = 0; fila < dtTblBalanceGeneral.Rows.Count; fila++)
                {
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];

                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtTotalActivoSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtTotalActivoDolares.Text);
                      
                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                      
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("PASIVO"))
                    {   
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];

                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtPasivoSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtPasivoDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("PATRIMONIO"))
                    {   
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];

                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"]    = Convert.ToDecimal (txtPatrimonioSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"]    = Convert.ToDecimal (txtPatrimonioDolares.Text);
                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO CORRIENTE"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
  
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtTotalActivoCorrSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtTotalActivoCorrDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO NO CORRIENTE"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
   
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtInmuebleTotalActivoNoCorrSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtInmuebleTotalActivoNoCorrDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("AHORROS/DEPÓSITOS A PLAZOS"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
                        
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtAhoDepPlazoFijoSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtAhoDepPlazoFijoDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("VEHÍCULOS"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"] = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]        = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]       = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
                        
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtVehiculoSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtVehiculoDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("INMUEBLES/ACTIVO FIJO"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
                        
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtInmuebleSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtInmuebleDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }

                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("OTROS/ENSERES"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"] = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"] = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"] = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];

                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = txtOtrosSoles.nvalor;
                        else//DÓLARES
                            drFila["nMonto"] = txtOtrosDolares.nvalor;

                        drFila["idMoneda"] = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"] = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"] = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);
                    }

                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("SALDO DE TARJETAS DE CRÉDITO"))
                    {   //SOLES
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
                        
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtSaldoTarjetasCreSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtSaldoTarjetasCreDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("SALDO DE CRÉDITOS"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
                        
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtSaldoCreSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtSaldoCreDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);                        
                    }
                    if (dtTblBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("OTRAS DEUDAS"))
                    {
                        DataRow drFila = dtTablaBalanceGeneral.NewRow();
                        drFila["idBalanGenEvaConsumo"]  = dtTblBalanceGeneral.Rows[fila]["idBalanGenEvaConsumo"];
                        drFila["IdEvalConsumo"]         = dtTblBalanceGeneral.Rows[fila]["IdEvalConsumo"];
                        drFila["idConceptoItem"]        = dtTblBalanceGeneral.Rows[fila]["idConceptoItem"];
                        
                        if (Convert.ToInt32(dtTblBalanceGeneral.Rows[fila]["idMoneda"]) == 1)//SOLES
                            drFila["nMonto"] = Convert.ToDecimal (txtOtrasDeudasSoles.Text);
                        else//DÓLARES
                            drFila["nMonto"] = Convert.ToDecimal (txtOtrasDeudasDolares.Text);

                        drFila["idMoneda"]      = dtTblBalanceGeneral.Rows[fila]["idMoneda"];
                        drFila["idItemPadre"]   = dtTblBalanceGeneral.Rows[fila]["idItemPadre"];
                        drFila["cTipModif"]     = cAccion;
                        dtTablaBalanceGeneral.Rows.Add(drFila);
                    }
                }
            }            
            return dtTablaBalanceGeneral;
        }

        private void validaGrabar()
        {
            if (Convert.ToInt32(dtgIngreso.RowCount) == 0)
            {
                MessageBox.Show("Debe Registrar Fuentes de Ingreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return;
            }
            if (Convert.ToInt32(dtgEgreso.RowCount) == 0)
            {
                MessageBox.Show("Debe Registrar Fuentes de Egreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return;
            }
            //agrega validacion de detalle de ingresos y egreso

            if (dtgIngreso.Rows.Count > 0)
            {
                for (int i = 0; i < dtgIngreso.Rows.Count; i++)
                {
                    if (dtgIngreso.Rows[i].Cells["cmb1"].Value == null)
                    {
                        MessageBox.Show("Ingrese Titular o Conyuge en el Ingreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nEstado = 1;
                        return;
                    }
                    if (dtgIngreso.Rows[i].Cells["cbMonIngreso"].Value == null)
                    {
                        MessageBox.Show("Seleccione tipo de moneda válido en el Ingreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nEstado = 1;
                        return;
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(dtgIngreso.Rows[i].Cells["cDescriFlujo"].Value)) == true)
                    {
                        MessageBox.Show("Ingrese el detalle en el Ingreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nEstado = 1;
                        return;
                    }
                    if (Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) <= 0)
                    {
                        MessageBox.Show("Ingrese monto válido en el Ingreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nEstado = 1;
                        return;
                    }
                }
                //valida el registro de intervinientes
                if (dtgIntervinientes.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dtgIntervinientes.Rows[i].Cells["IdTipoInterv"].Value)) == true)
                        {
                            MessageBox.Show("Debe seleccionar a un interviniente", "Valida Registro de intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                    }
                }
                //

                if (dtgEgreso.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgEgreso.Rows.Count; i++)
                    {
                        if (dtgEgreso.Rows[i].Cells["cmb2"].Value == null)
                        {
                            MessageBox.Show("Ingrese Titular o Conyuge en el Egreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                        if (dtgEgreso.Rows[i].Cells["cbMonEgreso"].Value == null)
                        {
                            MessageBox.Show("Seleccione tipo de moneda válido en el Egreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(dtgEgreso.Rows[i].Cells["cDescriFlujo"].Value)) == true)
                        {
                            MessageBox.Show("Ingrese el detalle en el Egreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                        if (Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) <= 0)
                        {
                            MessageBox.Show("Ingrese monto válido en el Egreso", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                    }
                }

                if (cboPorcenIngReal.SelectedIndex < 0)
                {
                    MessageBox.Show("El Porcentaje de Ingreso fuera de rango", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (dtpFecReg.Value > dtpFecVig.Value)
                {
                    MessageBox.Show("Fecha de Vigencia DEBE SER MAYOR a la Fecha de Registro", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtMontProp.Text) || txtMontProp.Text == "0" || txtMontProp.Text == "0.00")
                {
                    MessageBox.Show("Ingrese el Monto del crédito", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtNroCuotas.Text) || txtNroCuotas.Text == "0")
                {
                    MessageBox.Show("Ingrese el número de cuotas del crédito", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtTEM.Text) || txtTEM.Text == "0")
                {
                    MessageBox.Show("Ingrese la tasa efectiva mensual(TEM)", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }

                if (string.IsNullOrEmpty(txtEntornoFamDomicil.Text))
                {
                    MessageBox.Show("Ingresar comentario sobre el ENTORNO FAMILIAR", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtVerificLaboral.Text))
                {
                    MessageBox.Show("Ingresar comentario sobre la VERIFICACIÓN LABORAL", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtOtrosIngrAcred.Text))
                {
                    MessageBox.Show("Ingresar comentario sobre OTROS INGRESOS ACREDITADOS", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtAvalGarante.Text))
                {
                    MessageBox.Show("Ingresar comentario sobre el AVAL O GARANTE", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtDescrPatrim.Text))
                {
                    MessageBox.Show("Ingresar comentario sobre DESCRIPCIÓN DEL PATRIMONIO", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }
                if (string.IsNullOrEmpty(txtDestinoCre.Text))
                {
                    MessageBox.Show("Ingresar las conclusiones sobre el DESTINO DEL CRÉDITO", "Propuesta de Crédito Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return;
                }

                nEstado = 0;
            }

            //Valida Grid Referencias Personales
            dtgRefPersonales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (this.dtgRefPersonales.Rows.Count > 0)
            {
                for (int f = 0; f < dtReferenciasPersonales.Rows.Count; f++)
                {
                    if (dtReferenciasPersonales.Rows[f]["cTipModif"].ToString().Equals("I") || dtReferenciasPersonales.Rows[f]["cTipModif"].ToString().Equals("U"))
                    {
                        if (string.IsNullOrEmpty(dtReferenciasPersonales.Rows[f]["cApellidosNombres"].ToString()))
                        {
                            MessageBox.Show("Falta ingresar Apellidos y nombres en REFERENCIAS PERSONALES", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                        if (string.IsNullOrEmpty(dtReferenciasPersonales.Rows[f]["cRelacVinculo"].ToString()))
                        {
                            MessageBox.Show("Falta ingresar la relación/vinculo en REFERENCIAS PERSONALES", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                    }
                }
            }

            //Valida Grid Referencias Laborales
            dtgRefLaborales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (this.dtgRefLaborales.Rows.Count > 0)
            {
                for (int f = 0; f < dtReferenciasLaborales.Rows.Count; f++)
                {
                    if (dtReferenciasLaborales.Rows[f]["cTipModif"].ToString().Equals("I") || dtReferenciasLaborales.Rows[f]["cTipModif"].ToString().Equals("U"))
                    {
                        if (string.IsNullOrEmpty(dtReferenciasLaborales.Rows[f]["cApellidosNombres"].ToString()))
                        {
                            MessageBox.Show("Falta ingresar Apellidos y nombres en REFERENCIAS LABORALES", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                        if (string.IsNullOrEmpty(dtReferenciasLaborales.Rows[f]["cRelacVinculo"].ToString()))
                        {
                            MessageBox.Show("Falta ingresar la relación/vinculo en REFERENCIAS LABORALES", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            nEstado = 1;
                            return;
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(txtNumCuoRDS.Text))
            {
                txtNumCuoRDS.Text = "0";
            }
        }

        #endregion

        #region NUEVO

        private void btnNuevo1_Click(object sender, EventArgs e)
        {            
            if (this.conBusCli1.txtCodCli.Text == "" && this.conBusCli1.txtCodInst.Text=="")
            {
                MessageBox.Show("Debe seleccionar a un cliente para registrar una nueva evaluación", "Valida registro de Evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Int32 nidCliente    = Convert.ToInt32(this.conBusCli1.txtCodCli.Text);
            dtEvalConsumo       = EvalConsumo.CNdtEvalConsumo(0);

            DataTable dtBuscaEvaConxCli = EvalConsumo.CNdtBuscaEvaConxCli(nidCliente);
            if (dtBuscaEvaConxCli.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Presione:"+Environment.NewLine+"SI   : si desea registrar una evaluación vinculada." + Environment.NewLine + "NO: si desea crear una nueva Evaluación.",
                                                        "Evaluación Consumo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)//SE UTILIZARÁ UNA ELUAC. EXISTENTE COMO PLANTILLA PARA CREAR OTRA
                {
                    int idNumEva = Convert.ToInt32(dtBuscaEvaConxCli.Rows[0]["IdEvalConsumo"].ToString());

                    DataTable dtRetornaEvalCon  = new DataTable("dtRetornaEvalCon");
                    dtRetornaEvalCon            = EvalConsumo.CNdtEvalConsumo(idNumEva);

                    IdEvalConsumoAnterior = idNumEva;
                    if (dtRetornaEvalCon.Rows.Count > 0)
                    {
                        //============= Verificar que exista una Solicitud vigente de crédito Consumo ===========>
                        dtSolicitudCreConsumo = Solicitud.CNdtBuscarPropuestaCreConsumo(nidCliente);

                        if (dtSolicitudCreConsumo.Rows.Count > 0)
                        {
                            CargarPropuestaEconomica();
                        }
                        else
                        {
                            MessageBox.Show("No existe solicitud de CRÉDITO TIPO CONSUMO vigente para éste cliente", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        //=======================================================================================>

                        DataRow dr = dtEvalConsumo.NewRow();
                        dr["IdEvalConsumo"]     = 0;
                        dr["IdCliente"]         = dtRetornaEvalCon.Rows[0]["IdCliente"];
                        dr["dFechaReg"]         = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
                        dr["dFechaVig"]         = dtRetornaEvalCon.Rows[0]["dFechaVig"];
                        dr["cDebilidades"]      = dtRetornaEvalCon.Rows[0]["cDebilidades"];
                        dr["cFortalezas"]       = dtRetornaEvalCon.Rows[0]["cFortalezas"];
                        dr["cOtrComentarios"]   = dtRetornaEvalCon.Rows[0]["cOtrComentarios"];
                        dr["nPorCenIngReal"]    = dtRetornaEvalCon.Rows[0]["nPorCenIngReal"];
                        dr["IdMoneda"]          = dtRetornaEvalCon.Rows[0]["IdMoneda"];
                        dr["IdTipGarRDS"]       = dtRetornaEvalCon.Rows[0]["IdTipGarRDS"];
                        dr["nNumCuoRDS"]        = dtRetornaEvalCon.Rows[0]["nNumCuoRDS"];
                        dr["cComenRDS"]         = dtRetornaEvalCon.Rows[0]["cComenRDS"];
                        dr["nMonPropuesto"]     = dtRetornaEvalCon.Rows[0]["nMonPropuesto"];
                        dr["nNumcuotas"]        = dtRetornaEvalCon.Rows[0]["nNumcuotas"];
                        dr["nTEM"]              = dtRetornaEvalCon.Rows[0]["nTEM"];
                        dr["nCuotaAprox"]       = dtRetornaEvalCon.Rows[0]["nCuotaAprox"];
                        dr["nCoberturaCuota"]   = dtRetornaEvalCon.Rows[0]["nCoberturaCuota"];
                        dr["nTipoCambio"]       = dtRetornaEvalCon.Rows[0]["nTipoCambio"];
                        dr["nTipoCambio"]       = dtRetornaEvalCon.Rows[0]["nTipoCambio"];
                        dr["IdUsuReg"]          = clsVarGlobal.User.idUsuario;
                        dr["lVigente"]          = dtRetornaEvalCon.Rows[0]["lVigente"];
                        dr["cTipModif"]         = "I";
                        dr["IdEvalConRelacional"] = dtRetornaEvalCon.Rows[0]["IdEvalConsumo"];

                        dr["ratCuotaExcedente"]         = dtRetornaEvalCon.Rows[0]["ratCuotaExcedente"];
                        dr["ratDeudaPatrimonio"]        = dtRetornaEvalCon.Rows[0]["ratDeudaPatrimonio"];
                        dr["ratGarantiaPrestamo"]       = dtRetornaEvalCon.Rows[0]["ratGarantiaPrestamo"];
                        dr["ratIngrConyugueExcedente"]  = dtRetornaEvalCon.Rows[0]["ratIngrConyugueExcedente"];
                        dr["cRCC"]                      = dtRetornaEvalCon.Rows[0]["cRCC"];
                        dr["cSustExpuesto"]             = dtRetornaEvalCon.Rows[0]["cSustExpuesto"];
                        dr["nGarantTitular"]            = dtRetornaEvalCon.Rows[0]["nGarantTitular"];
                        dr["nGarantAval"]               = dtRetornaEvalCon.Rows[0]["nGarantAval"];
                        dr["cDocumentoID"]              = dtRetornaEvalCon.Rows[0]["cDocumentoID"];
                        dr["cNombre"]                   = dtRetornaEvalCon.Rows[0]["cNombre"];

                        dtEvalConsumo.Rows.Add(dr);

                        txtNumEva.Text                  = dtEvalConsumo.Rows[0]["IdEvalConsumo"].ToString();
                        dtpFecReg.Value                 = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
                        dtpFecVig.Value                 = Convert.ToDateTime(dtEvalConsumo.Rows[0]["dFechaVig"]);
                        cboMoneda1.SelectedValue        = Convert.ToInt32(dtEvalConsumo.Rows[0]["IdMoneda"]);
                        txtFortaleza.Text               = dtEvalConsumo.Rows[0]["cFortalezas"].ToString();
                        txtDebilidad.Text               = dtEvalConsumo.Rows[0]["cDebilidades"].ToString();
                        txtOtros.Text                   = dtEvalConsumo.Rows[0]["cOtrComentarios"].ToString();
                        cboPorcenIngReal.SelectedValue  = Convert.ToInt32(dtEvalConsumo.Rows[0]["nPorCenIngReal"]);
                        cboTipGarRDS.SelectedValue      = Convert.ToInt32(dtEvalConsumo.Rows[0]["IdTipGarRDS"]);
                        txtNumCuoRDS.Text               = dtEvalConsumo.Rows[0]["nNumCuoRDS"].ToString();
                        txtComenRDS.Text                = dtEvalConsumo.Rows[0]["cComenRDS"].ToString();
                        txtMontProp.Text                = dtEvalConsumo.Rows[0]["nMonPropuesto"].ToString();
                        txtNroCuotas.Text               = dtEvalConsumo.Rows[0]["nNumcuotas"].ToString();
                        txtTEM.Text                     = dtEvalConsumo.Rows[0]["nTEM"].ToString();
                        txtCuotaAprox.Text              = dtEvalConsumo.Rows[0]["nCuotaAprox"].ToString();
                        txtCoberCuota.Text              = dtEvalConsumo.Rows[0]["nCoberturaCuota"].ToString();
                        txtTipCamFij.Text               = dtEvalConsumo.Rows[0]["nTipoCambio"].ToString();

                        //txtVarRCD.Text = dtEvalConsumo.Rows[0]["nTipoCambio"].ToString();

                        //RATIOS
                        txtCuotaExcedente.Text          = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratCuotaExcedente"]).ToString();
                        txtDeudaTotalPatrimonio.Text    = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratDeudaPatrimonio"]).ToString();
                        txtGarantiasPrestamo.Text       = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratGarantiaPrestamo"]).ToString();
                        txtIngresosExcedente.Text       = Convert.ToDecimal (dtEvalConsumo.Rows[0]["ratIngrConyugueExcedente"]).ToString();

                        //RCC
                        txtRCC.Text             = dtEvalConsumo.Rows[0]["cRCC"].ToString();
                        TxtSustExpuesto.Text    = dtEvalConsumo.Rows[0]["cSustExpuesto"].ToString();

                        //GARANTIAS
                        txtGaranTitular.Text    = Convert.ToDecimal (dtEvalConsumo.Rows[0]["nGarantTitular"]).ToString();
                        txtGaranAval.Text       = Convert.ToDecimal (dtEvalConsumo.Rows[0]["nGarantAval"]).ToString();

                        dtIntervinientes = EvalConsumo.CNdtRetornaIntervCons(idNumEva);
                        dtIntervinientes.Columns["IdTipoIntervEva"].ReadOnly = false;
                        foreach (DataRow row in dtIntervinientes.Rows)
                        {
                            row["IdTipoIntervEva"] = -1;
                            row["IdEvaluacion"] = 0;
                            row["IdTipoInterv"] = 1;
                            row["lVigente"] = true;
                        }                                              
                        dtIntervinientes.DefaultView.RowFilter  = ("lVigente <> 0");
                        dtgIntervinientes.DataSource            = dtIntervinientes;


                        //==================================== Otros detalle Evaluación Consumo ========================================================================>
                        DataSet dsOtrosEvalConsumo  = EvalConsumo.CNdsRetornaOtrosDetalleEvalConsumo(Convert.ToInt32(dtRetornaEvalCon.Rows[0]["IdEvalConsumo"]));
                        dtTarjetasCredito           = dsOtrosEvalConsumo.Tables[0];
                        foreach (DataRow row in dtTarjetasCredito.Rows)
                        {
                            row["IdEvalConsumo"] = 0;
                            row["cTipModif"] = 'I';
                        }
                        dtCreditos                  = dsOtrosEvalConsumo.Tables[1];
                        foreach (DataRow row in dtCreditos.Rows)
                        {
                            row["IdEvalConsumo"] = 0;
                            row["cTipModif"] = 'I';
                        }
                        dtBalanceGeneral            = dsOtrosEvalConsumo.Tables[2];
                        foreach (DataRow row in dtBalanceGeneral.Rows)
                        {
                            row["IdEvalConsumo"] = 0;
                            row["cTipModif"] = 'I';
                        }
                        dtReferenciasPersonales     = dsOtrosEvalConsumo.Tables[3];
                        foreach (DataRow row in dtReferenciasPersonales.Rows)
                        {
                            row["IdEvalConsumo"] = 0;
                            row["cTipModif"] = 'I';
                        }
                        dtReferenciasLaborales      = dsOtrosEvalConsumo.Tables[4];
                        foreach (DataRow row in dtReferenciasLaborales.Rows)
                        {
                            row["IdEvalConsumo"] = 0;
                            row["cTipModif"] = 'I';
                        }
                        dtRiesgoCambiarioCrediticio = dsOtrosEvalConsumo.Tables[5];
                        foreach (DataRow row in dtRiesgoCambiarioCrediticio.Rows)
                        {
                            row["idEvalConsumo"] = 0;
                            row["cTipModif"] = 'I';
                        }
                        dtEstPerdGanancias          = dsOtrosEvalConsumo.Tables[6];          
                        if (dtEstPerdGanancias.Rows.Count == 0)
                        {
                            dtEstPerdGanancias = new clsCNEvalEmp().CNdtEstPerGanan(0);
                        }
                        else
                        {
                            dtEstPerdGanancias.Columns["IdEstPerdiGana"].ReadOnly = false;
                            foreach (DataRow row in dtEstPerdGanancias.Rows)
                            {
                                row["IdEstPerdiGana"] = -1;
                            }
                        }

                        //TARJETAS CREDITO
                        dtTarjetasCredito.DefaultView.RowFilter = ("cTipModif <> 'D'");
                        dtgTarjetasCre.DataSource = dtTarjetasCredito;

                        //CREDITOS EN OTRAS INSTITUCIONES
                        dtCreditos.DefaultView.RowFilter = ("cTipModif <> 'D'");
                        dtgCre.DataSource = dtCreditos;

                        //REFERENCIAS PERSONALES
                        dtReferenciasPersonales.DefaultView.RowFilter = ("cTipModif <> 'D'");
                        dtgRefPersonales.DataSource = dtReferenciasPersonales;

                        //REFERENCIAS LABORALES
                        dtReferenciasLaborales.DefaultView.RowFilter = ("cTipModif <> 'D'");
                        dtgRefLaborales.DataSource = dtReferenciasLaborales;

                        //ESTADO DE PERDIDAS Y GANANCIAS
                        dtgEstPerdGanan.DataSource = dtEstPerdGanancias;

                        AgregarComboBoxs();
                        FormatoGridIntervinientes();

                        DarFormatoGridTarjetas();
                        DarFormatoOtrosCreditos();
                        DarFormatoRefPersonales();
                        DarFormatoRefLaborales();

                        DarFormatoEstPerdGanancias("N");

                        AsignarBalanceGeneral();

                        //Cargar los escenarios del Riesgo cambiario Crediticio (RCC)
                        dtEscenarioRcc = EvalConsumo.CargarEscenarioRCC();
                        //================================================================================================================================================>
                  
                        // cargando el detalle de Ingresos   
                        dtDetalleIngEvalConsumo = EvalConsumo.CNdtDetalleEvalConsumo(0, 1);
                        DataTable dtDetIngEva   = EvalConsumo.CNdtDetalleEvalConsumo(idNumEva, 1);
                        for (int i = 0; i < dtDetIngEva.Rows.Count; i++)
                        {
                            DataRow drDetIngEva = dtDetalleIngEvalConsumo.NewRow();
                            drDetIngEva["IdDetalleEvalCon"] = 0;
                            drDetIngEva["IdEvalConsumo"]    = 0;
                            drDetIngEva["IdTipIngEgr"]      = dtDetIngEva.Rows[i]["IdTipIngEgr"];
                            drDetIngEva["IdTipPerDet"]      = dtDetIngEva.Rows[i]["IdTipPerDet"];
                            drDetIngEva["cDescriFlujo"]     = dtDetIngEva.Rows[i]["cDescriFlujo"];
                            drDetIngEva["IdMoneda"]         = dtDetIngEva.Rows[i]["IdMoneda"];
                            drDetIngEva["nMontoFlujo"]      = dtDetIngEva.Rows[i]["nMontoFlujo"];
                            drDetIngEva["cTipModif"]        = "I";
                            drDetIngEva["nPorcPartFlujo"]   = dtDetIngEva.Rows[i]["nPorcPartFlujo"];
                            dtDetalleIngEvalConsumo.Rows.Add(drDetIngEva);
                        }                        
                        dtDetalleIngEvalConsumo.DefaultView.RowFilter = ("cTipModif <> 'D'");
                        this.dtgIngreso.DataSource = dtDetalleIngEvalConsumo.DefaultView;
                        this.dtgIngreso.Focus();

                        // cargando el detalle de Egresos            
                        dtDetalleEgrEvalConsumo = EvalConsumo.CNdtDetalleEvalConsumo(0, 2);
                        DataTable dtDetEgrEva = EvalConsumo.CNdtDetalleEvalConsumo(idNumEva, 2);
                        for (int i = 0; i < dtDetEgrEva.Rows.Count; i++)
                        {
                            DataRow drDetEgrEva = dtDetalleEgrEvalConsumo.NewRow();
                            drDetEgrEva["IdDetalleEvalCon"] = 0;
                            drDetEgrEva["IdEvalConsumo"]    = 0;
                            drDetEgrEva["IdTipIngEgr"]      = dtDetEgrEva.Rows[i]["IdTipIngEgr"];
                            drDetEgrEva["IdTipPerDet"]      = dtDetEgrEva.Rows[i]["IdTipPerDet"];
                            drDetEgrEva["cDescriFlujo"]     = dtDetEgrEva.Rows[i]["cDescriFlujo"];
                            drDetEgrEva["IdMoneda"]         = dtDetEgrEva.Rows[i]["IdMoneda"];
                            drDetEgrEva["nMontoFlujo"]      = dtDetEgrEva.Rows[i]["nMontoFlujo"];
                            drDetEgrEva["cTipModif"]        = "I";
                            drDetEgrEva["nPorcPartFlujo"]   = dtDetEgrEva.Rows[i]["nPorcPartFlujo"];
                            dtDetalleEgrEvalConsumo.Rows.Add(drDetEgrEva);
                        }   
                        
                        dtDetalleEgrEvalConsumo.DefaultView.RowFilter = ("cTipModif <> 'D'");
                        this.dtgEgreso.DataSource = dtDetalleEgrEvalConsumo.DefaultView;
                        this.dtgEgreso.Focus();
                        this.FormatoGrid();

                        if (dtDetalleIngEvalConsumo.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtDetalleIngEvalConsumo.Rows.Count; i++)
                            {
                                this.dtgIngreso.Rows[i].Cells["cmb1"].Value         = Convert.ToInt32(dtDetalleIngEvalConsumo.Rows[i]["IdTipPerDet"].ToString());
                                this.dtgIngreso.Rows[i].Cells["cbMonIngreso"].Value = Convert.ToInt32(dtDetalleIngEvalConsumo.Rows[i]["IdMoneda"].ToString());
                            }
                        }

                        if (dtDetalleEgrEvalConsumo.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtDetalleEgrEvalConsumo.Rows.Count; i++)
                            {
                                this.dtgEgreso.Rows[i].Cells["cmb2"].Value          = Convert.ToInt32(dtDetalleEgrEvalConsumo.Rows[i]["IdTipPerDet"].ToString());
                                this.dtgEgreso.Rows[i].Cells["cbMonEgreso"].Value   = Convert.ToInt32(dtDetalleEgrEvalConsumo.Rows[i]["IdMoneda"].ToString());
                            }
                        }
                        sumaIngresos();
                        CalculaPorcParticipIng();
                        sumaEgresos();
                        CalculaPorcParticipEgr();
                        CalculaExcedente();                       
                        this.Habilitar(true);

                        //============== HABILITAR PANELES PRINCIPALES ===============>
                        pnlIntervinientes.Enabled = true;
                        foreach (TabPage item in tbcBase1.TabPages)
                        {
                            ((Control)item).Enabled = true;
                        }
                        //============================================================>
                    }
                }
                else//NUEVA 
                {
                    NuevaEva(nidCliente);
                    dtpFecVig.Enabled = true;
                    IdEvalConsumoAnterior = Convert.ToInt32(dtBuscaEvaConxCli.Rows[0]["IdEvalConsumo"]);//Puesto que siempre debe existir sólo una evaluac. Consumo
                }
            }
            else//NUEVA
            {
                NuevaEva(nidCliente);
                dtpFecVig.Enabled       = true;
                IdEvalConsumoAnterior   = 0;//Puesto que no existen evaluaciones anteriores
            }            
            btnAgrInterv.Enabled        = true;
            btnQuitInterv.Enabled       = true;
            this.btn_Vincular1.Enabled  = false;
            this.txtNumReaExede.Visible = false;
            this.txtNumReaCuota.Visible = false;            
        }

        #region AsignaBalancegeneral

        /// <summary>
        /// Asigna los valores del Balance General recuperado a sus respectivos campos
        /// </summary>
        private void AsignarBalanceGeneral()
        {
            for (int fila = 0; fila < dtBalanceGeneral.Rows.Count; fila++)
            {
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO"))
                {   //SOLES                    
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtTotalActivoSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtTotalActivoDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("PASIVO"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtPasivoSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtPasivoDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("PATRIMONIO"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtPatrimonioSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtPatrimonioDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO CORRIENTE"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtTotalActivoCorrSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtTotalActivoCorrDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("ACTIVO NO CORRIENTE"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtInmuebleTotalActivoNoCorrSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtInmuebleTotalActivoNoCorrDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("AHORROS/DEPÓSITOS A PLAZOS"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtAhoDepPlazoFijoSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtAhoDepPlazoFijoDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("VEHÍCULOS"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtVehiculoSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtVehiculoDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("INMUEBLES/ACTIVO FIJO"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtInmuebleSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtInmuebleDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }


                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().ToUpper().Equals("OTROS/ENSERES"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        this.txtOtrosSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        this.txtOtrosDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                }

                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("SALDO DE TARJETAS DE CRÉDITO"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtSaldoTarjetasCreSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtSaldoTarjetasCreDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("SALDO DE CRÉDITOS"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtSaldoCreSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtSaldoCreDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
                if (dtBalanceGeneral.Rows[fila]["cConcepto"].ToString().Trim().Equals("OTRAS DEUDAS"))
                {   //SOLES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 1)
                    {
                        txtOtrasDeudasSoles.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }
                    //DÓLARES
                    if (Convert.ToInt32(dtBalanceGeneral.Rows[fila]["idMoneda"]) == 2)
                    {
                        txtOtrasDeudasDolares.Text = dtBalanceGeneral.Rows[fila]["nMonto"].ToString();
                    }                    
                }
            }
            //Calcular Totales
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
            CalcularTotalActivo();
            CalcularTotalPatrimonio();
        }

        #endregion

        private void NuevaEva(Int32 nidCliente) 
        { 
            //============= Verificar que exista una Solicitud vigente de crédito Consumo ===========>
            dtSolicitudCreConsumo = Solicitud.CNdtBuscarPropuestaCreConsumo(nidCliente);

            if (dtSolicitudCreConsumo.Rows.Count > 0)
            {
                CargarPropuestaEconomica();
            }
            else
            {
                MessageBox.Show("No existe solicitud de CRÉDITO TIPO CONSUMO vigente para éste cliente", "Valida evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //=======================================================================================>
            
            DateTime dFechaAct = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
            Int32 nVigenciaEva = Convert.ToInt32(clsVarApl.dicVarGen["nVigEvaCon"]);

            DataRow dr = dtEvalConsumo.NewRow();
            dr["IdEvalConsumo"] = 0;
            dr["dFechaReg"]     = dFechaAct; 
            dr["dFechaVig"]     = dFechaAct.AddDays(nVigenciaEva);
            dr["IdCliente"]     = nidCliente;
            dr["IdUsuReg"]      = clsVarGlobal.User.idUsuario;
            dr["lVigente"]      = 1;
            dr["cTipModif"]     = "I";
            dr["IdMoneda"]      = 1;
            dr["cDocumentoID"] = "";//-->ELIMINAR
            dr["cNombre"] = "";//-->ELIMINAR

            dtEvalConsumo.Rows.Add(dr);
            cboPorcenIngReal.Text   = "";
            cboTipGarRDS.Text       = "";

            // cargando el detalle de Ingresos
            dtgIngreso.Focus();
            dtDetalleIngEvalConsumo = EvalConsumo.CNdtDetalleEvalConsumo(0, 1);
            dtDetalleIngEvalConsumo.DefaultView.RowFilter = ("cTipModif <> 'D'");
            dtgIngreso.DataSource   = dtDetalleIngEvalConsumo.DefaultView;            

            // cargando el detalle de Egresos  
            dtgEgreso.Focus(); 
            dtDetalleEgrEvalConsumo = EvalConsumo.CNdtDetalleEvalConsumo(0, 2);
            dtDetalleEgrEvalConsumo.DefaultView.RowFilter = ("cTipModif <> 'D'");
            dtgEgreso.DataSource    = dtDetalleEgrEvalConsumo.DefaultView;
                     
            FormatoGrid();

            if (clsVarApl.dicVarGen["nTipCamFij"] > 0)
            {
                this.txtTipCamFij.Text = Convert.ToString(clsVarApl.dicVarGen["nTipCamFij"]);
                dtEvalConsumo.Rows[0]["nTipoCambio"] = Convert.ToDecimal (txtTipCamFij.Text);
            }
            else
            {
                MessageBox.Show("No existe tasa para la fecha", "Valida registro de Evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtIntervinientes                = EvalConsumo.CNdtRetornaIntervCons(0);  //INTERVINIENTES
            dtgIntervinientes.DataSource    = dtIntervinientes;    //INTERVINIENTES
            this.Habilitar(true);            

            //Otros detalle Evaluación Consumo
            DataSet dsOtrosEvalConsumo  = EvalConsumo.CNdsRetornaOtrosDetalleEvalConsumo(0);
            dtTarjetasCredito           = dsOtrosEvalConsumo.Tables[0];
            dtCreditos                  = dsOtrosEvalConsumo.Tables[1];
            dtBalanceGeneral            = dsOtrosEvalConsumo.Tables[2];
            dtReferenciasPersonales     = dsOtrosEvalConsumo.Tables[3];

            dtReferenciasLaborales      = dsOtrosEvalConsumo.Tables[4];
            dtRiesgoCambiarioCrediticio = dsOtrosEvalConsumo.Tables[5];

            //Carga la plantilla vigente del estado de perdidas y ganancias
            dtEstPerdGanancias          = new clsCNEvalEmp().CNdtEstPerGanan(0);

            //TARJETAS CREDITO
            dtgTarjetasCre.DataSource   = dtTarjetasCredito;

            //CREDITOS EN OTRAS INSTITUCIONES
            dtgCre.DataSource           = dtCreditos;
            
            //REFERENCIAS PERSONALES
            dtgRefPersonales.DataSource = dtReferenciasPersonales;

            //REFERENCIAS LABORALES
            dtgRefLaborales.DataSource  = dtReferenciasLaborales;

            //ESTADO DE PERDIDAS Y GANANCIAS
            dtgEstPerdGanan.DataSource  = dtEstPerdGanancias;
          
            AgregarComboBoxs();
            FormatoGridIntervinientes();

            DarFormatoGridTarjetas();
            DarFormatoOtrosCreditos();
            DarFormatoRefPersonales();
            DarFormatoRefLaborales();

            DarFormatoEstPerdGanancias("N");

            //Cargar los escenarios del Riesgo cambiario Crediticio (RCC)
            dtEscenarioRcc = EvalConsumo.CargarEscenarioRCC();

            //============== HABILITAR PANELES PRINCIPALES ===============>
            pnlIntervinientes.Enabled = true;
            foreach (TabPage item in tbcBase1.TabPages)
            {
                ((Control)item).Enabled = true;
            }
            //============================================================>
        }

        private void CargarPropuestaEconomica()
        {
            txtMonSolicitado.Text   = dtSolicitudCreConsumo.Rows[0]["nCapitalSolicitado"].ToString();
            txtMonedaCreSol.Text    = dtSolicitudCreConsumo.Rows[0]["cMoneda"].ToString();
            txtTipoCredito.Text     = dtSolicitudCreConsumo.Rows[0]["cTipCredito"].ToString();
            txtProducto.Text        = dtSolicitudCreConsumo.Rows[0]["cProducto"].ToString();
            txtNumCuotas.Text       = dtSolicitudCreConsumo.Rows[0]["nCuotas"].ToString();
            txtFrecuencia.Text      = dtSolicitudCreConsumo.Rows[0]["nPlazoCuota"].ToString();
            txtTasaInteres.Text     = dtSolicitudCreConsumo.Rows[0]["nTasaCompensatoria"].ToString();
            txtDiaGracia.Text       = dtSolicitudCreConsumo.Rows[0]["nDiasGracia"].ToString();
            txtActividad.Text       = dtSolicitudCreConsumo.Rows[0]["cActividad"].ToString();
            txtDestino.Text         = dtSolicitudCreConsumo.Rows[0]["cDestino"].ToString();

            int idTipoPeriodo   = Convert.ToInt32(dtSolicitudCreConsumo.Rows[0]["idTipoPeriodo"]);
            txtTipoPeriodo.Text = dtSolicitudCreConsumo.Rows[0]["cDescripTipoPeriodo"].ToString();

            lblEnDias.Visible = false;
            if (idTipoPeriodo == 1)//Fecha Fija
            {
                lblFrec.Text = "Día de Pago: ";
            }
            if (idTipoPeriodo == 2)//Periodo Fijo
            {
                lblFrec.Text = "Frecuencia: ";
                lblEnDias.Visible = true;
            }

            int idSol = Convert.ToInt32(dtSolicitudCreConsumo.Rows[0]["idSolicitud"]);

            DataTable dtTasaGarantia = new clsCNGarantia().CNSaldoTasado(idSol);
            if (dtTasaGarantia.Rows.Count > 0)
            {
                txtGarantia.Text = dtTasaGarantia.Rows[0]["nSaldo"].ToString();
            }
            cargarPropuesta(idSol);
        }

        private void cargarPropuesta(int idSolicitud)
        {
            DataTable dtPropuesta = cnevaluacion.CNConsPropuestaConsumo(idSolicitud);
            if (dtPropuesta.Rows.Count > 0)
            {
                txtEntornoFamDomicil.Text = dtPropuesta.Rows[0]["cEntornoFam"].ToString();
                txtVerificLaboral.Text = dtPropuesta.Rows[0]["cVerificLaboral"].ToString();
                txtOtrosIngrAcred.Text = dtPropuesta.Rows[0]["cOtrosIngr"].ToString();

                txtAvalGarante.Text = dtPropuesta.Rows[0]["cAvalGarante"].ToString();
                txtDescrPatrim.Text = dtPropuesta.Rows[0]["cPatrimonio"].ToString();
                txtDestinoCre.Text = dtPropuesta.Rows[0]["cDestinoCre"].ToString();
            }
        }

        #endregion

        #region FORMATO_GRIDS

        private void DarFormatoGridTarjetas()
        {
            dtgTarjetasCre.ReadOnly = false;
            dtgTarjetasCre.Columns["idEvalConsumoTarjetaCre"].Visible   = false;
            dtgTarjetasCre.Columns["IdEvalConsumo"].Visible             = false;
            dtgTarjetasCre.Columns["cEntidadFinancTarjeta"].HeaderText  = "Entidad Financiera/Tarjeta";
            dtgTarjetasCre.Columns["idMoneda"].Visible                  = false;//Será superpuesto por el combo de MONEDA que se agrega a éste grid
            dtgTarjetasCre.Columns["nLineaCre"].HeaderText              = "Línea de Crédito";
            dtgTarjetasCre.Columns["nSaldoActual"].HeaderText           = "Saldo Actual";
            dtgTarjetasCre.Columns["nCuotaMensual"].HeaderText          = "Cuota Mensual";
            dtgTarjetasCre.Columns["cTipModif"].Visible                 = false;

            dtgTarjetasCre.Columns["cEntidadFinancTarjeta"].SortMode= DataGridViewColumnSortMode.NotSortable;
            dtgTarjetasCre.Columns["nLineaCre"].SortMode            = DataGridViewColumnSortMode.NotSortable;
            dtgTarjetasCre.Columns["nSaldoActual"].SortMode         = DataGridViewColumnSortMode.NotSortable;
            dtgTarjetasCre.Columns["nCuotaMensual"].SortMode        = DataGridViewColumnSortMode.NotSortable;

            dtgTarjetasCre.Columns["nLineaCre"].FillWeight      = 37;
            dtgTarjetasCre.Columns["nSaldoActual"].FillWeight   = 34;
            dtgTarjetasCre.Columns["nCuotaMensual"].FillWeight  = 34;
            dtgTarjetasCre.Columns["cboMonedaTar"].FillWeight   = 44;    
        }

        private void DarFormatoOtrosCreditos()
        {
            dtgCre.ReadOnly = false;
            dtgCre.Columns["idEvalConsumoCreditos"].Visible = false;
            dtgCre.Columns["IdEvalConsumo"].Visible         = false;
            dtgCre.Columns["cEntidadFinanc"].HeaderText     = "Entidad Financiera";
            dtgCre.Columns["idMoneda"].Visible              = false;//Será superpuesto por el combo de MONEDA que se agrega a éste grid
            dtgCre.Columns["cTipoCre"].HeaderText           = "Tipo de Crédito";
            dtgCre.Columns["nSaldoActual"].HeaderText       = "Saldo Actual";
            dtgCre.Columns["nCuotaMensual"].HeaderText      = "Cuota Mensual";
            dtgCre.Columns["cTipModif"].Visible             = false;

            dtgCre.Columns["cEntidadFinanc"].SortMode   = DataGridViewColumnSortMode.NotSortable;
            dtgCre.Columns["cTipoCre"].SortMode         = DataGridViewColumnSortMode.NotSortable;
            dtgCre.Columns["nSaldoActual"].SortMode     = DataGridViewColumnSortMode.NotSortable;
            dtgCre.Columns["nCuotaMensual"].SortMode    = DataGridViewColumnSortMode.NotSortable;

            dtgCre.Columns["cTipoCre"].FillWeight       = 37;
            dtgCre.Columns["nSaldoActual"].FillWeight   = 34;
            dtgCre.Columns["nCuotaMensual"].FillWeight  = 34;
            dtgCre.Columns["cboMonedaTar"].FillWeight   = 44;  
        }

        private void DarFormatoRefPersonales()
        {
            dtgRefPersonales.ReadOnly                               = false;
            dtgRefPersonales.Columns["idRefPerson"].Visible         = false;
            dtgRefPersonales.Columns["IdEvalConsumo"].Visible       = false;
            dtgRefPersonales.Columns["cApellidosNombres"].HeaderText= "Apellidos y Nombres";
            dtgRefPersonales.Columns["cTelefono"].HeaderText        = "Teléfono";
            dtgRefPersonales.Columns["idCalificaRef"].Visible       = false;//Será superpuesto por el combo de CALIFICACIÓN que se agrega a éste grid
            dtgRefPersonales.Columns["cRelacVinculo"].HeaderText    = "Relación / Vinculo";
            dtgRefPersonales.Columns["cTipModif"].Visible           = false;

            dtgRefPersonales.Columns["cApellidosNombres"].SortMode  = DataGridViewColumnSortMode.NotSortable;
            dtgRefPersonales.Columns["cTelefono"].SortMode          = DataGridViewColumnSortMode.NotSortable;
            dtgRefPersonales.Columns["cRelacVinculo"].SortMode      = DataGridViewColumnSortMode.NotSortable;

            dtgRefPersonales.Columns["cboCalificaRef"].FillWeight   = 60;
            dtgRefPersonales.Columns["cTelefono"].FillWeight        = 60;
            dtgRefPersonales.Columns["cRelacVinculo"].FillWeight    = 60;
        }

        private void DarFormatoRefLaborales()
        {
            dtgRefLaborales.ReadOnly                                = false;
            dtgRefLaborales.Columns["idRefLaboral"].Visible         = false;
            dtgRefLaborales.Columns["IdEvalConsumo"].Visible        = false;
            dtgRefLaborales.Columns["cApellidosNombres"].HeaderText = "Apellidos y Nombres";
            dtgRefLaborales.Columns["cTelefono"].HeaderText         = "Teléfono";
            dtgRefLaborales.Columns["idCalificaRef"].Visible        = false;//Será superpuesto por el combo de CALIFICACIÓN que se agrega a éste grid
            dtgRefLaborales.Columns["cRelacVinculo"].HeaderText     = "Relación / Vinculo";
            dtgRefLaborales.Columns["cTipModif"].Visible            = false;

            dtgRefLaborales.Columns["cApellidosNombres"].SortMode   = DataGridViewColumnSortMode.NotSortable;
            dtgRefLaborales.Columns["cTelefono"].SortMode           = DataGridViewColumnSortMode.NotSortable;
            dtgRefLaborales.Columns["cRelacVinculo"].SortMode       = DataGridViewColumnSortMode.NotSortable;

            dtgRefLaborales.Columns["cboCalificaRef"].FillWeight    = 60;
            dtgRefLaborales.Columns["cTelefono"].FillWeight         = 60;
            dtgRefLaborales.Columns["cRelacVinculo"].FillWeight     = 60;
        }

        private void FormatoGridIntervinientes()
        {

            foreach (DataGridViewColumn column in dtgIntervinientes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgIntervinientes.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgIntervinientes.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgIntervinientes.ReadOnly = false;

            dtgIntervinientes.Columns["IdTipoIntervEva"].Visible = false;
            dtgIntervinientes.Columns["IdEvaluacion"].Visible = false;
            dtgIntervinientes.Columns["IdTipoInterv"].Visible = false;
            dtgIntervinientes.Columns["lVigente"].Visible = false;

            dtgIntervinientes.Columns["cboTipoInterv"].Visible = true;
            dtgIntervinientes.Columns["cboTipoInterv"].HeaderText = "Tipo de Interviniente";
            dtgIntervinientes.Columns["cboTipoInterv"].ReadOnly = false;
        }

        private void FormatoGrid()
        {
            //-------------------------------------- GRID INGRESOS -------------------------------------->
            dtgIngreso.Enabled  = true;
            dtgIngreso.ReadOnly = false;

            dtgIngreso.Columns["nPorcPartFlujo"].ReadOnly  = true;
            dtgIngreso.Columns["cTipModif"].Visible        = false;
            dtgIngreso.Columns["IdTipIngEgr"].Visible      = false;
            dtgIngreso.Columns["IdEvalConsumo"].Visible    = false;
            dtgIngreso.Columns["IdDetalleEvalCon"].Visible = false;

            dtgIngreso.Columns["cmb1"].FillWeight           = 46;//Combo TITULAR / CONYUGUE
            dtgIngreso.Columns["cbMonIngreso"].FillWeight   = 40;//Combo MONEDA
            dtgIngreso.Columns["nMontoFlujo"].FillWeight    = 36;
            dtgIngreso.Columns["nPorcPartFlujo"].FillWeight = 26;

            dtgIngreso.Columns["cDescriFlujo"].HeaderText  = "Detalle";
            dtgIngreso.Columns["nMontoFlujo"].HeaderText   = "Monto";
            dtgIngreso.Columns["nPorcPartFlujo"].HeaderText= "% Proporc.";

            dtgIngreso.Columns["nPorcPartFlujo"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgIngreso.Columns["cDescriFlujo"].SortMode     = DataGridViewColumnSortMode.NotSortable;
            dtgIngreso.Columns["nMontoFlujo"].SortMode      = DataGridViewColumnSortMode.NotSortable;
            dtgIngreso.Columns["nPorcPartFlujo"].SortMode   = DataGridViewColumnSortMode.NotSortable;
            //---------------------------------------------------------------------------------------------->

            dtDetalleIngEvalConsumo.Columns["cTipModif"].ReadOnly = false;

            //-------------------------------------- GRID EGRESOS -------------------------------------->
            dtgEgreso.Enabled   = true;
            dtgEgreso.ReadOnly  = false;
            dtgEgreso.Columns["nPorcPartFlujo"].ReadOnly= true;

            dtgEgreso.Columns["cTipModif"].Visible         = false;
            dtgEgreso.Columns["IdTipIngEgr"].Visible       = false;
            dtgEgreso.Columns["IdEvalConsumo"].Visible     = false;
            dtgEgreso.Columns["IdDetalleEvalCon"].Visible  = false;

            dtgEgreso.Columns["cDescriFlujo"].HeaderText   = "Detalle";
            dtgEgreso.Columns["nMontoFlujo"].HeaderText    = "Monto";
            dtgEgreso.Columns["nPorcPartFlujo"].HeaderText = "% Proporc.";

            dtgEgreso.Columns["cmb2"].FillWeight            = 46;//Combo TITULAR / CONYUGUE
            dtgEgreso.Columns["cbMonEgreso"].FillWeight     = 40;//Combo MONEDA
            dtgEgreso.Columns["nMontoFlujo"].FillWeight     = 36;
            dtgEgreso.Columns["nPorcPartFlujo"].FillWeight  = 26;

            dtgEgreso.Columns["nPorcPartFlujo"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgEgreso.Columns["cDescriFlujo"].SortMode      = DataGridViewColumnSortMode.NotSortable;
            dtgEgreso.Columns["nMontoFlujo"].SortMode       = DataGridViewColumnSortMode.NotSortable;
            dtgEgreso.Columns["nPorcPartFlujo"].SortMode    = DataGridViewColumnSortMode.NotSortable;
            //------------------------------------------------------------------------------------------>

            dtDetalleEgrEvalConsumo.Columns["cTipModif"].ReadOnly = false;
            cboTipGarRDS.Text = "";
        }

        private void DarFormatoEstPerdGanancias(string cTipFormato)
        {
            dtgEstPerdGanan.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgEstPerdGanan.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;      
            }

            dtgEstPerdGanan.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgEstPerdGanan.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            
            foreach (DataGridViewRow row in dtgEstPerdGanan.Rows)
            {
                if (row.Cells["cTipoRegPartida"].Value.ToString().Equals("I"))
                {
                    row.Cells["nMontoParti"].ReadOnly = false;
                    row.Cells["nMontoParti"].Style.BackColor = Color.Yellow;
                }

                if (row.Cells["cDescriPartida"].Value.Equals("Utilidad Bruta") ||
                    row.Cells["cDescriPartida"].Value.Equals("Utilidad Operativa") ||
                    row.Cells["cDescriPartida"].Value.Equals("Utilidad Neta"))
                {
                    row.Cells["cDescriPartida"].Style.BackColor = Color.SkyBlue;
                    row.Cells["nMontoParti"].Style.BackColor = Color.SkyBlue;
                }

                if(cTipFormato.Equals("N"))
                {
                    if (row.Index.In(10, 11))
                    {
                        row.Visible = false;
                    }
                }
            }

            dtgEstPerdGanan.Columns["cDescriPartida"].Visible = true;
            dtgEstPerdGanan.Columns["nMontoParti"].Visible = true;

            dtgEstPerdGanan.Columns["cDescriPartida"].HeaderText = "Descripción";
            dtgEstPerdGanan.Columns["nMontoParti"].HeaderText = "Monto";

            dtgEstPerdGanan.Columns["cDescriPartida"].FillWeight = 66;
            dtgEstPerdGanan.Columns["nMontoParti"].FillWeight = 33;

            dtgEstPerdGanan.Columns["nMontoParti"].DefaultCellStyle.Format = "##,##0.00";

            dtgEstPerdGanan.Columns["nMontoParti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      
        }

        #endregion
        
        #region GRID_INGRESOS

        private void dtgIngreso_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nMontoFlujo"))
             {
                 TextBox txtbox     = e.Control as TextBox;
                 txtbox.MaxLength   = 8;
                 int columnIng = dtgIngreso.CurrentCell.ColumnIndex;
                 if (columnIng == 8 && txtbox != null)
                 {
                     txtbox.KeyPress -= new KeyPressEventHandler(txtbox_KeyPress);
                     txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                 }
             }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cDescriFlujo"))
            {
                TextBox txtbox = e.Control as TextBox;
                txtbox.MaxLength = 100;
                txtbox.KeyPress -= new KeyPressEventHandler(txtbox_KeyPress);
            } 
        }

        private void dtgIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).CurrentCell is DataGridViewTextBoxCell)
            {
                int columnIng = dtgIngreso.CurrentCell.ColumnIndex;
                if (columnIng == 6)//MONTO
                {
                    sumaIngresos();
                    sumaEgresos();
                    CalcularExcedente();
                    //Quitar evento para evitar bucle infinito
                    dtgIngreso.CellValueChanged -= new DataGridViewCellEventHandler(dtgIngreso_CellValueChanged);
                    CalculaPorcParticipIng();
                    dtgIngreso.CellValueChanged += new DataGridViewCellEventHandler(dtgIngreso_CellValueChanged);

                    if (TotalIngresos > 0 && TotalEgresos > 0)
                    {
                        CalculaExcedente();
                        CalcularCuotaAprox();
                    }
                }
            }

            //COMBOBOX MONEDA
            if ((sender as DataGridView).CurrentCell is DataGridViewComboBoxCell)
            {
                int columnIng = dtgIngreso.CurrentCell.ColumnIndex;
                if (columnIng == 5)
                {
                    sumaIngresos();
                    sumaEgresos();
                    CalcularExcedente();
                    dtgIngreso.CellValueChanged -= new DataGridViewCellEventHandler(dtgIngreso_CellValueChanged);
                    CalculaPorcParticipIng();
                    dtgIngreso.CellValueChanged += new DataGridViewCellEventHandler(dtgIngreso_CellValueChanged);
                    if (TotalIngresos > 0 && TotalEgresos > 0)
                    {
                        CalculaExcedente();
                        CalcularCuotaAprox();
                    }
                }
            }
        }

        //Para hacer commit cuando se cambie de indice el comboBox del grid
        private void dtgIngreso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgIngreso.CurrentCell.ColumnIndex == 5)//Combo Moneda
            {
                if (this.dtgIngreso.IsCurrentCellDirty)
                    dtgIngreso.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgIngreso_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int filaIng     = dtgIngreso.CurrentCell.RowIndex;
            int columnIng   = dtgIngreso.CurrentCell.ColumnIndex;
            if (columnIng == 8)//MONTO
            {
                if (dtgIngreso.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value) dtgIngreso.Rows[filaIng].Cells[columnIng].Value = 0;

                if (TotalIngresos > 0 && TotalEgresos > 0)
                {
                    CalculaExcedente();
                    CalcularCuotaAprox();
                }
            }
        }

        private void dtgIngreso_Leave(object sender, EventArgs e)
        {
            if (TotalIngresos > 0 && TotalEgresos > 0)
            {
                CalculaExcedente();
            }
        }

        private void btnAgregaIng_Click(object sender, EventArgs e)
        {
            DataRow dr          = dtDetalleIngEvalConsumo.NewRow();
            dr["cTipModif"]     = "I";
            dr["IdEvalConsumo"] = Convert.ToInt32(dtEvalConsumo.Rows[0]["IdEvalConsumo"]);
            dr["IdTipIngEgr"]   = 1;
            dr["IdTipPerDet"]   = 1;
            dr["nMontoFlujo"]   = 0.00;
            dr["nPorcPartFlujo"]= 0.00;
            dr["IdMoneda"]      = 1;         
            dtDetalleIngEvalConsumo.Rows.Add(dr);

            int nFilas = dtgIngreso.Rows.Count;

            //Setear por defecto para evitar errores
            dtgIngreso.Rows[nFilas - 1].Cells["cmb1"].Value         = 1;//Titular/Conyugue
            dtgIngreso.Rows[nFilas - 1].Cells["cbMonIngreso"].Value = 1;//Moneda
        }

        private void btnQuitaIng_Click(object sender, EventArgs e)
        {
            if (this.dtgIngreso.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgIngreso.SelectedCells[0].RowIndex);
                if (dtgIngreso.Rows[nFilaActual].Cells["cTipModif"].Value.ToString().Equals("I"))
                {
                    dtgIngreso.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgIngreso.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                dtgIngreso.CurrentCell = null;
                dtgIngreso.ClearSelection();

                sumaIngresos();
                sumaEgresos();
                CalcularExcedente();
                dtgIngreso.CellValueChanged -= new DataGridViewCellEventHandler(dtgIngreso_CellValueChanged);
                CalculaPorcParticipIng();
                dtgIngreso.CellValueChanged += new DataGridViewCellEventHandler(dtgIngreso_CellValueChanged);
            }
        }

        #endregion

        #region GRID_EGRESOS

        private void dtgEgreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nMontoFlujo"))
             {
                 TextBox txtbox     = e.Control as TextBox;
                 txtbox.MaxLength   = 8;
                 int columnIng = dtgEgreso.CurrentCell.ColumnIndex;
                 if (columnIng == 8 && txtbox != null)
                 {
                     txtbox.KeyPress -= new KeyPressEventHandler(txtbox_KeyPress);
                     txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                 }
             }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cDescriFlujo"))
            {
                TextBox txtbox = e.Control as TextBox;
                txtbox.MaxLength = 100;
                txtbox.KeyPress -= new KeyPressEventHandler(txtbox_KeyPress);
            } 
        }

        private void dtgEgreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).CurrentCell is DataGridViewTextBoxCell)
            {
                int columnIng = dtgEgreso.CurrentCell.ColumnIndex;
                if (columnIng == 6)//MONTO
                {
                    sumaIngresos();
                    sumaEgresos();
                    CalcularExcedente();
                    //Quitar evento para evitar bucle infinito
                    dtgEgreso.CellValueChanged -= new DataGridViewCellEventHandler(dtgEgreso_CellValueChanged);
                    CalculaPorcParticipEgr();
                    dtgEgreso.CellValueChanged += new DataGridViewCellEventHandler(dtgEgreso_CellValueChanged);

                    if (TotalIngresos > 0 && TotalEgresos > 0)
                    {
                        CalculaExcedente();
                        CalcularCuotaAprox();
                    }
                }
            }

            //COMBOBOX MONEDA
            if ((sender as DataGridView).CurrentCell is DataGridViewComboBoxCell)
            {
                int columnIng = dtgEgreso.CurrentCell.ColumnIndex;
                if (columnIng == 5)
                {
                    sumaIngresos();
                    sumaEgresos();
                    CalcularExcedente();
                    dtgEgreso.CellValueChanged -= new DataGridViewCellEventHandler(dtgEgreso_CellValueChanged);
                    CalculaPorcParticipEgr();
                    dtgEgreso.CellValueChanged += new DataGridViewCellEventHandler(dtgEgreso_CellValueChanged);
                    if (TotalIngresos > 0 && TotalEgresos > 0)
                    {
                        CalculaExcedente();
                        CalcularCuotaAprox();
                    }
                }
            }
        }

        //Para hacer commit cuando se cambie de indice el comboBox del grid
        private void dtgEgreso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgEgreso.CurrentCell.ColumnIndex == 5)//Combo Moneda
            {
                if (this.dtgEgreso.IsCurrentCellDirty)
                    dtgEgreso.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtgEgreso_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int filaIng = dtgEgreso.CurrentCell.RowIndex;
            int columnIng = dtgEgreso.CurrentCell.ColumnIndex;
            if (columnIng == 8)//MONTO
            {
                if (dtgEgreso.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value) dtgEgreso.Rows[filaIng].Cells[columnIng].Value = 0;

                if (TotalIngresos > 0 && TotalEgresos > 0)
                {
                    CalculaExcedente();
                    CalcularCuotaAprox();
                }
            }
        }        

        private void dtgEgreso_Leave(object sender, EventArgs e)
        {
            if (TotalIngresos > 0 && TotalEgresos > 0)
            {
                CalculaExcedente();
                CalcularCuotaAprox();
            }
        }

        private void btnAgregaEgr_Click(object sender, EventArgs e)
        {
            DataRow dr              = dtDetalleEgrEvalConsumo.NewRow();
            dr["cTipModif"]         = "I";
            dr["IdEvalConsumo"]     = Convert.ToInt32(dtEvalConsumo.Rows[0]["IdEvalConsumo"]);
            dr["IdTipIngEgr"]       = 2;
            dr["IdTipPerDet"]       = 1;
            dr["nMontoFlujo"]       = 0.00;
            dr["nPorcPartFlujo"]    = 0.00;
            dtDetalleEgrEvalConsumo.Rows.Add(dr);

            int nFilas = dtgEgreso.Rows.Count;

            //Setear por defecto para evitar errores
            dtgEgreso.Rows[nFilas - 1].Cells["cmb2"].Value = 1;//Titular/Conyugue
            dtgEgreso.Rows[nFilas - 1].Cells["cbMonEgreso"].Value = 1;//Moneda
        }

        private void btnQuitarEgr_Click(object sender, EventArgs e)
        {
            if (this.dtgEgreso.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Egresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgEgreso.SelectedCells[0].RowIndex);
                if (dtgEgreso.Rows[nFilaActual].Cells["cTipModif"].Value.ToString().Equals("I"))
                {
                    dtgEgreso.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgEgreso.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                dtgEgreso.CurrentCell = null;
                dtgEgreso.ClearSelection();

                sumaIngresos();
                sumaEgresos();
                CalcularExcedente();
                dtgEgreso.CellValueChanged -= new DataGridViewCellEventHandler(dtgEgreso_CellValueChanged);
                CalculaPorcParticipEgr();
                dtgEgreso.CellValueChanged += new DataGridViewCellEventHandler(dtgEgreso_CellValueChanged);
            }            
        }

        #endregion    

        #region dtgIntervinientes

        private void btnAgrInterv_Click(object sender, EventArgs e)
        {
            DataRow drInterv            = dtIntervinientes.NewRow();
            drInterv["IdTipoIntervEva"] = -1;
            drInterv["IdEvaluacion"]    = 0;
            drInterv["lVigente"]        = 1;
            dtIntervinientes.Rows.Add(drInterv);
        }

        private void btnQuitInterv_Click(object sender, EventArgs e)
        {
            if (this.dtgIntervinientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgIntervinientes.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgIntervinientes.Rows[nFilaActual].Cells["IdTipoIntervEva"].Value) == -1)
                {
                    dtgIntervinientes.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgIntervinientes.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgIntervinientes.Focus();
                ProcessTabKey(true);
            }
        }

        #endregion

        #region AGREGAR_COMBOBOX_A_GRIDS 

        private void AgregarComboBoxs()
        {
            DataTable dtTipoInterv                  = new clsCNInterviniente().CNListaTipoInterv();
            DataGridViewComboBoxColumn cboTipoInterv= new DataGridViewComboBoxColumn();
            cboTipoInterv.HeaderText                = "Tipo Interv.";
            cboTipoInterv.ToolTipText               = "Tipo de Interviniente";
            cboTipoInterv.Name                      = "cboTipoInterv";
            cboTipoInterv.DataPropertyName          = "idtipointerv";
            cboTipoInterv.MaxDropDownItems          = 4;
            cboTipoInterv.DropDownWidth             = 50;
            cboTipoInterv.DataSource                = dtTipoInterv;
            cboTipoInterv.DisplayMember             = dtTipoInterv.Columns["CTIPOINTERVENCION"].ToString();
            cboTipoInterv.ValueMember               = dtTipoInterv.Columns["idtipointerv"].ToString();
            this.dtgIntervinientes.Columns.Add(cboTipoInterv);

            //=========================   Agregar ComboBox REFERENCIAS PERSONALES================================>
            DataTable dtCalificRefPersonales            = EvalConsumo.CNdtListaCalifRef();
            DataGridViewComboBoxColumn cboCalificRefPerson= new DataGridViewComboBoxColumn();
            cboCalificRefPerson.HeaderText              = "Referencia";
            cboCalificRefPerson.ToolTipText             = "Calificación";
            cboCalificRefPerson.Name                    = "cboCalificaRef";
            cboCalificRefPerson.DataPropertyName        = "idCalificaRef";
            cboCalificRefPerson.MaxDropDownItems        = 4;
            cboCalificRefPerson.DropDownWidth           = 60;
            cboCalificRefPerson.DataSource              = dtCalificRefPersonales;
            cboCalificRefPerson.DisplayMember           = dtCalificRefPersonales.Columns["cCalificaRef"].ToString();
            cboCalificRefPerson.ValueMember             = dtCalificRefPersonales.Columns["idCalificaRef"].ToString();
            dtgRefPersonales.Columns.Add(cboCalificRefPerson);
            //===================================================================================================>

            //========================= ComboBox REFERENCIAS LABORALES ================================>
            DataTable dtCalificRefLaborales = dtCalificRefPersonales.Clone();
            for (int f = 0; f < dtCalificRefPersonales.Rows.Count; f++)
            {
                DataRow fila            = dtCalificRefLaborales.NewRow();
                fila["cCalificaRef"]    = dtCalificRefPersonales.Rows[f]["cCalificaRef"];
                fila["idCalificaRef"]   = dtCalificRefPersonales.Rows[f]["idCalificaRef"];
                dtCalificRefLaborales.Rows.Add(fila);
            }

            DataGridViewComboBoxColumn cboCalificRefLaboral = new DataGridViewComboBoxColumn();
            cboCalificRefLaboral.HeaderText         = "Referencia";
            cboCalificRefLaboral.ToolTipText        = "Calificación";
            cboCalificRefLaboral.Name               = "cboCalificaRef";
            cboCalificRefLaboral.DataPropertyName   = "idCalificaRef";
            cboCalificRefLaboral.MaxDropDownItems   = 4;
            cboCalificRefLaboral.DropDownWidth      = 60;
            cboCalificRefLaboral.DataSource         = dtCalificRefLaborales;
            cboCalificRefLaboral.DisplayMember      = dtCalificRefLaborales.Columns["cCalificaRef"].ToString();
            cboCalificRefLaboral.ValueMember        = dtCalificRefLaborales.Columns["idCalificaRef"].ToString();
            dtgRefLaborales.Columns.Add(cboCalificRefLaboral);
            //===================================================================================================>

            //========================= ComboBox MONEDA - grid Tarjetas de Crédito================================>
            DataTable dtMonedaTarjetasCre   = ListadoMoneda.listarMoneda();
            DataGridViewComboBoxColumn cboMonedaTar = new DataGridViewComboBoxColumn();
            cboMonedaTar.HeaderText         = "Moneda";
            cboMonedaTar.ToolTipText        = "Moneda";
            cboMonedaTar.Name               = "cboMonedaTar";
            cboMonedaTar.DataPropertyName   = "idMoneda";
            cboMonedaTar.MaxDropDownItems   = 4;
            cboMonedaTar.DropDownWidth      = 60;
            //cboMonedaTar.FillWeight
            cboMonedaTar.DataSource         = dtMonedaTarjetasCre;
            cboMonedaTar.DisplayMember      = dtMonedaTarjetasCre.Columns["cMoneda"].ToString();
            cboMonedaTar.ValueMember        = dtMonedaTarjetasCre.Columns["idMoneda"].ToString();
            dtgTarjetasCre.Columns.Add(cboMonedaTar);
            //===================================================================================================>

            //========================= ComboBox MONEDA - grid Crédito en otras instituciones =====================>
            DataGridViewComboBoxColumn cboMonedaCre = new DataGridViewComboBoxColumn();
            cboMonedaCre.HeaderText         = "Moneda";
            cboMonedaCre.ToolTipText        = "Moneda";
            cboMonedaCre.Name               = "cboMonedaTar";
            cboMonedaCre.DataPropertyName   = "idMoneda";
            cboMonedaCre.MaxDropDownItems   = 4;
            cboMonedaCre.DropDownWidth      = 60;
            //cboMonedaTar.FillWeight
            cboMonedaCre.DataSource         = dtMonedaTarjetasCre;
            cboMonedaCre.DisplayMember      = dtMonedaTarjetasCre.Columns["cMoneda"].ToString();
            cboMonedaCre.ValueMember        = dtMonedaTarjetasCre.Columns["idMoneda"].ToString();
            dtgCre.Columns.Add(cboMonedaCre);
            //===================================================================================================>
        }

        #endregion
        
        #region CALCULO_INGRESOS_EGRESOS

        private void sumaIngresos()
        {
            Decimal sumaIng      = 0.00m;
            Decimal ntipCambio = 0.00m;
            if (string.IsNullOrEmpty(txtTipCamFij.Text)==false)
            {
                ntipCambio = Convert.ToDecimal (txtTipCamFij.Text);
            }             
            int nMonedaBase     = Convert.ToInt32(cboMoneda1.SelectedValue);
            int nMonedaConvIng  = 0;//Moneda Convertida

            Decimal SumaIngresosMonedaBase           = 0.00m;
            Decimal SumaIngresosMonedaConvertida     = 0.00m;
            Decimal SumaTotalIngresosMonedaConvertida= 0.00m;

            if (dtgIngreso.Rows.Count > 0 && cboMoneda1.SelectedIndex >= 0)
            {
                for (int i = 0; i < dtgIngreso.Rows.Count; i++)
                {
                    if (dtgIngreso.Rows[i].Cells["cTipModif"].Value.ToString().Equals("D")==false)
	                {
                        nMonedaConvIng = Convert.ToInt32(dtgIngreso.Rows[i].Cells["cbMonIngreso"].Value);

                        if (nMonedaBase == nMonedaConvIng)
                        {
                            if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                sumaIng += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value);

                            if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                SumaIngresosMonedaBase += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value);
                        }
                        else
                        {
                            if (nMonedaBase < nMonedaConvIng)
                            {
                                if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    sumaIng += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) * ntipCambio;

                                if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaIngresosMonedaConvertida += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value);

                                if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaTotalIngresosMonedaConvertida += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) * ntipCambio;
                            }
                            else
                            {
                                if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    sumaIng += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) / ntipCambio;

                                if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaIngresosMonedaConvertida += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value);

                                if (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaTotalIngresosMonedaConvertida += Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) / ntipCambio;
                            }
                        }
	                }                    
                }
            }
            TotalIngresos = sumaIng;

            txtTotalIngrEstResulSoles.Text      = SumaIngresosMonedaBase.ToString();
            txtTotalIngrEstResulDolares.Text    = SumaIngresosMonedaConvertida.ToString();
            txtTotalIngrEstResulSolesTotal.Text = (SumaIngresosMonedaBase + SumaTotalIngresosMonedaConvertida).ToString();
        }

        private void sumaEgresos()
        {
            Decimal sumaEgr      = 0.00m;
            Decimal ntipCambio = 0.00m;
            if (string.IsNullOrEmpty(txtTipCamFij.Text) == false)
            {
                ntipCambio = Convert.ToDecimal (txtTipCamFij.Text);
            }  
            int nMonedaBase     = Convert.ToInt32(cboMoneda1.SelectedValue);
            int nMonedaConvEgr  = 0;

            Decimal SumaEgresosMonedaBase            = 0.00m;
            Decimal SumaEgresosMonedaConvertida      = 0.00m;
            Decimal SumaTotalEgresosMonedaConvertida = 0.00m;

            if (dtgEgreso.Rows.Count > 0 && cboMoneda1.SelectedIndex >= 0)
            {                
                for (int i = 0; i < dtgEgreso.Rows.Count; i++)
                {
                    if (dtgEgreso.Rows[i].Cells["cTipModif"].Value.ToString().Equals("D") == false)
                    {
                        nMonedaConvEgr = Convert.ToInt32(dtgEgreso.Rows[i].Cells["cbMonEgreso"].Value);

                        if (nMonedaBase == nMonedaConvEgr)
                        {
                            if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                sumaEgr += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value);

                            if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                SumaEgresosMonedaBase += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value);
                        }
                        else
                        {
                            if (nMonedaBase < nMonedaConvEgr)
                            {
                                if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    sumaEgr += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) * ntipCambio;

                                if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaEgresosMonedaConvertida += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value);

                                if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaTotalEgresosMonedaConvertida += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) * ntipCambio;
                            }
                            else
                            {
                                if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    sumaEgr += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) / ntipCambio;

                                if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaEgresosMonedaConvertida += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value);

                                if (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value != System.DBNull.Value)
                                    SumaTotalEgresosMonedaConvertida += Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) / ntipCambio;
                            }
                        }
                    }                    
                }
            }
            TotalEgresos = sumaEgr;

            txtTotalEgrEstResulSoles.Text       = SumaEgresosMonedaBase.ToString();
            txtTotalEgrEstResulDolares.Text     = SumaEgresosMonedaConvertida.ToString();
            txtTotalEgrEstResulSolesTotal.Text  = (SumaEgresosMonedaBase + SumaTotalEgresosMonedaConvertida).ToString();
        }

        private void CalcularExcedente()
        {
            //---------------- Validar campos vacios de ingresos y egresos ---------------------->
            if (string.IsNullOrEmpty(txtTotalIngrEstResulSoles.Text)) txtTotalIngrEstResulSoles.Text            = "0.00";
            if (string.IsNullOrEmpty(txtTotalIngrEstResulDolares.Text)) txtTotalIngrEstResulDolares.Text        = "0.00";
            if (string.IsNullOrEmpty(txtTotalIngrEstResulSolesTotal.Text)) txtTotalIngrEstResulSolesTotal.Text  = "0.00";

            if (string.IsNullOrEmpty(txtTotalEgrEstResulSoles.Text)) txtTotalEgrEstResulSoles.Text              = "0.00";
            if (string.IsNullOrEmpty(txtTotalEgrEstResulDolares.Text)) txtTotalEgrEstResulDolares.Text          = "0.00";
            if (string.IsNullOrEmpty(txtTotalEgrEstResulSolesTotal.Text)) txtTotalEgrEstResulSolesTotal.Text    = "0.00";
            //---------------------------------------------------------------------------------->

            Decimal nTotalIngrEstResulSoles      = Convert.ToDecimal (txtTotalIngrEstResulSoles.Text);
            Decimal nTotalIngrEstResulDolares    = Convert.ToDecimal (txtTotalIngrEstResulDolares.Text);
            Decimal nTotalIngrEstResulSolesTotal = Convert.ToDecimal (txtTotalIngrEstResulSolesTotal.Text);

            Decimal nTotalEgrEstResulSoles       = Convert.ToDecimal (txtTotalEgrEstResulSoles.Text);
            Decimal nTotalEgrEstResulDolares     = Convert.ToDecimal (txtTotalEgrEstResulDolares.Text);
            Decimal nTotalEgrEstResulSolesTotal  = Convert.ToDecimal (txtTotalEgrEstResulSolesTotal.Text);

            txtExcedenteSoles.Text      = (nTotalIngrEstResulSoles - nTotalEgrEstResulSoles).ToString();
            txtExcedenteDolares.Text    = (nTotalIngrEstResulDolares - nTotalEgrEstResulDolares).ToString();
            txtExcedenteTotalSoles.Text = (nTotalIngrEstResulSolesTotal - nTotalEgrEstResulSolesTotal).ToString();
        }

        void CalculaPorcParticipIng()
        {
            Decimal ntipCambio = Convert.ToDecimal (txtTipCamFij.Text);
            int nMonedaBase = Convert.ToInt32(cboMoneda1.SelectedValue);
            int nMonedaConvIng = 0;

            if (dtgIngreso.Rows.Count > 0 && cboMoneda1.SelectedIndex >= 0 && TotalIngresos > 0.00m)
            {
                for (int i = 0; i < dtgIngreso.Rows.Count; i++)
                {
                    nMonedaConvIng = Convert.ToInt32(dtgIngreso.Rows[i].Cells["cbMonIngreso"].Value);

                    if (nMonedaBase == nMonedaConvIng)
                    {
                        dtgIngreso.Rows[i].Cells["nPorcPartFlujo"].Value = Math.Round((Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) / TotalIngresos) * 100.00m, 2);
                    }
                    else
                    {
                        if (nMonedaBase < nMonedaConvIng)
                        {
                            dtgIngreso.Rows[i].Cells["nPorcPartFlujo"].Value = Math.Round(((Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) * ntipCambio) / TotalIngresos) * 100.00m, 2);
                        }
                        else
                        {
                            dtgIngreso.Rows[i].Cells["nPorcPartFlujo"].Value = Math.Round(((Convert.ToDecimal (dtgIngreso.Rows[i].Cells["nMontoFlujo"].Value) / ntipCambio) / TotalIngresos) * 100.00m, 2);
                        }
                    }
                }
            }
        }

        void CalculaPorcParticipEgr()
        {
            Decimal ntipCambio = Convert.ToDecimal (txtTipCamFij.Text);
            int nMonedaBase = Convert.ToInt32(cboMoneda1.SelectedValue);
            int nMonedaConvEgr = 0;

            if (dtgEgreso.Rows.Count > 0 && cboMoneda1.SelectedIndex >= 0 && TotalEgresos > 0.00m)
            {
                for (int i = 0; i < dtgEgreso.Rows.Count; i++)
                {
                    nMonedaConvEgr = Convert.ToInt32(dtgEgreso.Rows[i].Cells["cbMonEgreso"].Value);

                    if (nMonedaBase == nMonedaConvEgr)
                    {
                        dtgEgreso.Rows[i].Cells["nPorcPartFlujo"].Value = Math.Round((Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) / TotalEgresos) * 100, 2);
                    }
                    else
                    {
                        if (nMonedaBase < nMonedaConvEgr)
                        {
                            dtgEgreso.Rows[i].Cells["nPorcPartFlujo"].Value = Math.Round(((Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) * ntipCambio) / TotalEgresos) * 100.00m, 2);
                        }
                        else
                        {
                            dtgEgreso.Rows[i].Cells["nPorcPartFlujo"].Value = Math.Round(((Convert.ToDecimal (dtgEgreso.Rows[i].Cells["nMontoFlujo"].Value) / ntipCambio) / TotalEgresos) * 100.00m, 2);
                        }
                    }
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
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }       

        void CalculaExcedente()
        {
            if (dtgIngreso.Rows.Count > 0 && dtgEgreso.Rows.Count > 0)
            {
                if (TotalIngresos <= TotalEgresos)
                {
                    MessageBox.Show("El monto del Ingreso debe ser mayor al Egreso", "Valida registro de Evaluación Consumo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                txtNumReaExede.Text = Convert.ToString(Math.Round((TotalIngresos - TotalEgresos), 2));
                txtNumReaCuota.Text = Convert.ToString(Math.Round((Convert.ToDecimal (txtNumReaExede.Text) * Convert.ToDecimal (cboPorcenIngReal.SelectedValue) / 100), 2));
            }
        }

        private void CalcularCuotaAprox()
        {
            Decimal nMonto       = 0.00m;
            Decimal nTEM         = 0.00m;
            int nNroCuotas      = 0;

            if (string.IsNullOrEmpty(txtMontProp.Text)) { txtMontProp.Text = "0.00"; return; }
            nMonto = Convert.ToDecimal (txtMontProp.Text);

            if (string.IsNullOrEmpty(txtTEM.Text)) { txtTEM.Text = "0.00"; return; }
            nTEM = Convert.ToDecimal (txtTEM.Text) / 100.00m;

            if (string.IsNullOrEmpty(txtNroCuotas.Text)) { txtNroCuotas.Text = "0"; return; }
            nNroCuotas = Convert.ToInt32(txtNroCuotas.Text);

            if (nNroCuotas == 0) return;
            
            //======== método del plan de pagos para calcular cuotas constantes ===========================>            
            int nDiaGraCta      = Convert.ToInt32(txtDiaGracia.Text);
            short nTipPerPag    = Convert.ToInt16(dtSolicitudCreConsumo.Rows[0]["idTipoPeriodo"]);
            int nDiaFecPag      = Convert.ToInt32(txtFrecuencia.Text);
            int nNumsolicitud   = 0;//No es necesario especificar la solicitud, puesto que sólo se necesita el método que calcula cuotas        
            int idMoneda        = Convert.ToInt32(dtSolicitudCreConsumo.Rows[0]["IdMoneda"]);

            //Tablas necesarias que por defecto se envían
            DataTable dtConfigGasto = new DataTable();
            DataTable dtCuotasDobles = new DataTable();

            DateTime dFecDesemb = dtpFecReg.Value;

            DateTime dFecPrimeracuota = dFecDesemb.AddDays(nDiaGraCta);

            clsCNPlanPago CalPlanPago = new clsCNPlanPago();
            DataTable dtCalendarioPagos = CalPlanPago.CalculaPpgCuotasConstantes(nMonto, nTEM, dFecDesemb, nNroCuotas, nDiaGraCta, nTipPerPag, nDiaFecPag,
                                                       nNumsolicitud, dtConfigGasto, idMoneda, dtCuotasDobles, dFecPrimeracuota);
            //==============================================================================================>
            //Cuota Aproximada Mensualizada
            txtCuotaAprox.Text = dtCalendarioPagos.Rows[0]["imp_cuota"].ToString();

            if (Convert.ToDecimal (txtCuotaAprox.Text) == 0.00m) { txtCoberCuota.Text = "0.00"; return; }

            if (string.IsNullOrEmpty(txtNumReaCuota.Text)) txtNumReaCuota.Text = "0.00";
            
            txtCoberCuota.Text = (Convert.ToDecimal(txtNumReaCuota.Text) / Convert.ToDecimal(txtCuotaAprox.Text)).ToString("##,##0.00");
        }

        #endregion

        #region REFERENCIAS_PERSONALES_EVENTOS

        private void dtgRefPersonales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cTelefono"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 9;            
                if (txtBox != null)
                {
                    txtBox.KeyPress -= new KeyPressEventHandler(txtboxEnterosdtgRefPersonales_KeyPress);
                    txtBox.KeyPress += new KeyPressEventHandler(txtboxEnterosdtgRefPersonales_KeyPress);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cRelacVinculo"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 100;
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cApellidosNombres"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 150;
            }
        }

        private void btnAgregaRefPersonales_Click(object sender, EventArgs e)
        {
            DataRow drNuevaFila = dtReferenciasPersonales.NewRow();
            drNuevaFila["cTipModif"]        = "I";

            drNuevaFila["idRefPerson"]      = 0 ;
            drNuevaFila["IdEvalConsumo"]    = 0 ;
            drNuevaFila["cApellidosNombres"]= "";
            drNuevaFila["cTelefono"]        = "";
            drNuevaFila["idCalificaRef"]    = 1 ;//Setear por defecto
            drNuevaFila["cRelacVinculo"]    = "";

            dtReferenciasPersonales.Rows.Add(drNuevaFila);
        }

        private void btnQuitaRefPersonales_Click(object sender, EventArgs e)
        {
            if (this.dtgRefPersonales.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Referencias Personales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgRefPersonales.SelectedCells[0].RowIndex);
                if (dtgRefPersonales.Rows[nFilaActual].Cells["cTipModif"].Value.ToString() == "I")
                {
                    dtgRefPersonales.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgRefPersonales.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                this.dtgRefPersonales.Focus();
                ProcessTabKey(true);
            }
        }
        //Handler para permitir sólo enteros en una columna del grid de 'Referecncias Personales'
        private void txtboxEnterosdtgRefPersonales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgRefPersonales.CurrentCell.OwningColumn.Name.Equals("cTelefono"))
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

        #endregion

        #region REFERENCIAS_LABORALES_EVENTOS 

        private void dtgRefLaborales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cTelefono"))
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.MaxLength = 9;
                if (txtBox != null)
                {
                    txtBox.KeyPress -= new KeyPressEventHandler(txtboxEnterosdtgRefLaborales_KeyPress);
                    txtBox.KeyPress += new KeyPressEventHandler(txtboxEnterosdtgRefLaborales_KeyPress);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cRelacVinculo"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 100;
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cApellidosNombres"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 150;
            }
        }

        private void btnAgregaRefLaborales_Click(object sender, EventArgs e)
        {
            DataRow drNuevaFila = dtReferenciasLaborales.NewRow();
            drNuevaFila["cTipModif"]        = "I";

            drNuevaFila["idRefLaboral"]     = 0;
            drNuevaFila["IdEvalConsumo"]    = 0;//Convert.ToInt32(dtEvalConsumo.Rows[0]["IdEvalConsumo"]);
            drNuevaFila["cApellidosNombres"]= "";
            drNuevaFila["cTelefono"]        = "";
            drNuevaFila["idCalificaRef"]    = 1;//Setear por defecto
            drNuevaFila["cRelacVinculo"]    = "";

            dtReferenciasLaborales.Rows.Add(drNuevaFila);
        }

        private void btnQuitaRefLaborales_Click(object sender, EventArgs e)
        {
            if (this.dtgRefLaborales.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Referencias Laborales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgRefLaborales.SelectedCells[0].RowIndex);
                if (dtgRefLaborales.Rows[nFilaActual].Cells["cTipModif"].Value.ToString() == "I")
                {
                    dtgRefLaborales.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgRefLaborales.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                this.dtgRefLaborales.Focus();
                ProcessTabKey(true);
            }
        }

        //Handler para permitir sólo enteros en una columna del grid de 'Referecncias Laborales'
        private void txtboxEnterosdtgRefLaborales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgRefLaborales.CurrentCell.OwningColumn.Name.Equals("cTelefono"))
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

        #endregion

        #region TARJETAS_CREDITO

        private void dtgTarjetasCre_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.In("nLineaCre","nCuotaMensual") )
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.MaxLength = 6;
                if (txtBox != null)
                {
                    txtBox.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgTarjetasCre_KeyPress);
                    txtBox.KeyPress += new KeyPressEventHandler(txtboxRealesdtgTarjetasCre_KeyPress);
                }
            }

            //SALDO ACTUAL
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nSaldoActual"))
            {
                TextBox txtBox = e.Control as TextBox;
                txtBox.MaxLength = 6;
                if (txtBox != null)
                {
                    txtBox.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgTarjetasCre_KeyPress);
                    txtBox.KeyPress += new KeyPressEventHandler(txtboxRealesdtgTarjetasCre_KeyPress);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cEntidadFinancTarjeta"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 150;
            }
        }       

        private void dtgTarjetasCre_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgTarjetasCre.CurrentCell != null)
            {
                int columnIng = dtgTarjetasCre.CurrentCell.ColumnIndex;
                int filaIng = dtgTarjetasCre.CurrentCell.RowIndex;
                dtgTarjetasCre.EndEdit();
                if (columnIng == 2)//ENTIDAD FINANCIERA / TARJETA
                {
                    if (dtgTarjetasCre.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value)
                        dtgTarjetasCre.Rows[filaIng].Cells[columnIng].Value = "";
                }
                else//CAMPOS NUMÉRICOS
                {
                    if (dtgTarjetasCre.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value)
                        dtgTarjetasCre.Rows[filaIng].Cells[columnIng].Value = 0;
                }

                var nSaldoActual = Convert.ToDecimal(dtgTarjetasCre.Rows[dtgTarjetasCre.CurrentCell.RowIndex].Cells["nSaldoActual"].Value);
                var nLineaCre = Convert.ToDecimal(dtgTarjetasCre.Rows[dtgTarjetasCre.CurrentCell.RowIndex].Cells["nLineaCre"].Value);

                if (nSaldoActual > nLineaCre)
                {
                    dtgTarjetasCre.CurrentCell.Value = 0.00;
                    if (dtgTarjetasCre.CurrentCell != null)
                    {
                        var cell = dtgTarjetasCre.CurrentCell;
                        var cellDisplayRect = dtgTarjetasCre.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                        toolTip1.Show("Ingrese un valor menor a la línea de crédito",
                                      dtgTarjetasCre,
                                      cellDisplayRect.X + cell.Size.Width / 2,
                                      cellDisplayRect.Y + cell.Size.Height / 2,
                                      4000);
                        dtgTarjetasCre.ShowCellToolTips = false;
                    }
                }

            }
        }

        private void dtgTarjetasCre_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void dtgTarjetasCre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            

            //SALDO ACTUAL
            if ((sender as DataGridView).CurrentCell is DataGridViewTextBoxCell)
            {
                int columnIng   = dtgTarjetasCre.CurrentCell.ColumnIndex;
                int filaIng     = dtgTarjetasCre.CurrentCell.RowIndex;
                if (columnIng == 5)
                {
                    CalcularTotalActivoCorriente();
                    CalcularTotalActivoNoCorriente();
                }
            }
            //COMBOBOX MONEDA
            if ((sender as DataGridView).CurrentCell is DataGridViewComboBoxCell)
            {                
                CalcularTotalActivoCorriente();
                CalcularTotalActivoNoCorriente();                
            }
        }

        //Para hacer commit cuando se cambie de indice el comboBox del grid
        private void dtgTarjetasCre_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgTarjetasCre.CurrentCell.ColumnIndex == 8)//Combo Moneda
            {
                if (this.dtgTarjetasCre.IsCurrentCellDirty)
                    dtgTarjetasCre.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }                     
        }

        private void btnAgregaTarjetaCre_Click(object sender, EventArgs e)
        {
            DataRow drNuevaFila         = dtTarjetasCredito.NewRow();
            drNuevaFila["cTipModif"]    = "I";

            drNuevaFila["idEvalConsumoTarjetaCre"]  = 0;
            drNuevaFila["IdEvalConsumo"]            = 0;//Convert.ToInt32(dtEvalConsumo.Rows[0]["IdEvalConsumo"]);
            drNuevaFila["cEntidadFinancTarjeta"]    = "";
            drNuevaFila["idMoneda"]                 = 1;
            drNuevaFila["nLineaCre"]                = 0;
            drNuevaFila["nSaldoActual"]             = 0;
            drNuevaFila["nCuotaMensual"]            = 0;

            dtTarjetasCredito.Rows.Add(drNuevaFila);
        }

        private void btnQuitaTarjetaCre_Click(object sender, EventArgs e)
        {
            if (this.dtgTarjetasCre.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Referencias Personales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgTarjetasCre.SelectedCells[0].RowIndex);
                if (dtgTarjetasCre.Rows[nFilaActual].Cells["cTipModif"].Value.ToString() == "I")
                {
                    dtgTarjetasCre.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgTarjetasCre.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                this.dtgTarjetasCre.Focus();
                ProcessTabKey(true);
            }
            CalcularTotalGridTarjetasCre();
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        //Handler para permitir sólo enteros en una columna del grid de 'Referecncias Laborales'
        private void txtboxRealesdtgTarjetasCre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgTarjetasCre.CurrentCell.OwningColumn.Name.Equals("nLineaCre") ||
                dtgTarjetasCre.CurrentCell.OwningColumn.Name.Equals("nSaldoActual") ||
                dtgTarjetasCre.CurrentCell.OwningColumn.Name.Equals("nCuotaMensual")
                )
            {
                if (e.KeyChar == 8)//BORRADO
                {
                    e.Handled = false;
                    return;
                }                
                if (e.KeyChar >= 48 && e.KeyChar <= 57)//SÓLO NÚMEROS
                {                    
                    e.Handled = false;
                }
                else
                {                    
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region CREDITO_OTRAS_INSTITUCIONES

        private void dtgCre_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nSaldoActual") ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCuotaMensual"))
            {
                TextBox txtBox  = e.Control as TextBox;
                txtBox.MaxLength= 6;
                if (txtBox != null)
                {
                    txtBox.KeyPress -= new KeyPressEventHandler(txtboxReales_KeyPress);
                    txtBox.KeyPress += new KeyPressEventHandler(txtboxReales_KeyPress);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cEntidadFinanc"))
            {
                TextBox txtBox      = e.Control as TextBox;
                txtBox.MaxLength    = 150;
            }
        }        

        private void dtgCre_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCre.CurrentCell != null)
            {
                int columnIng   = dtgCre.CurrentCell.ColumnIndex;
                int filaIng     = dtgCre.CurrentCell.RowIndex;
                dtgCre.EndEdit();
                if (columnIng == 2)//ENTIDAD FINANCIERA
                {
                    if (dtgCre.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value)
                        dtgCre.Rows[filaIng].Cells[columnIng].Value = "";
                }
                else//CAMPOS NUMÉRICOS
                {
                    if (dtgCre.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value)
                        dtgCre.Rows[filaIng].Cells[columnIng].Value = 0;
                }
            }
        }

        private void dtgCre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //SALDO ACTUAL
            if ((sender as DataGridView).CurrentCell is DataGridViewTextBoxCell)
            {
                int columnIng   = dtgCre.CurrentCell.ColumnIndex;
                int filaIng     = dtgCre.CurrentCell.RowIndex;
                if (columnIng == 5)
                {
                    CalcularTotalActivoCorriente();
                    CalcularTotalActivoNoCorriente();
                }
            }

            //COMBOBOX MONEDA
            if ((sender as DataGridView).CurrentCell is DataGridViewComboBoxCell)
            {
                CalcularTotalActivoCorriente();
                CalcularTotalActivoNoCorriente();
            }
        }

        //Para hacer commit cuando se cambie de indice el comboBox del grid
        private void dtgCre_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgCre.CurrentCell.ColumnIndex == 8)//Combo Moneda
            {
                if (this.dtgCre.IsCurrentCellDirty)
                    dtgCre.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAgregaCre_Click(object sender, EventArgs e)
        {
            DataRow drNuevaFila                 = dtCreditos.NewRow();
            drNuevaFila["cTipModif"]            = "I";

            drNuevaFila["idEvalConsumoCreditos"]= 0;
            drNuevaFila["IdEvalConsumo"]        = 0;//Convert.ToInt32(dtEvalConsumo.Rows[0]["IdEvalConsumo"]);
            drNuevaFila["cEntidadFinanc"]       = "";
            drNuevaFila["idMoneda"]             = 1;
            drNuevaFila["cTipoCre"]             = "";
            drNuevaFila["nSaldoActual"]         = 0;
            drNuevaFila["nCuotaMensual"]        = 0;

            dtCreditos.Rows.Add(drNuevaFila);
        }

        private void btnQuitaCre_Click(object sender, EventArgs e)
        {
            if (this.dtgCre.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Valida registro de Referencias Personales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgCre.SelectedCells[0].RowIndex);
                if (dtgCre.Rows[nFilaActual].Cells["cTipModif"].Value.ToString() == "I")
                {
                    dtgCre.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgCre.Rows[nFilaActual].Cells["cTipModif"].Value = "D";
                }
                this.dtgCre.Focus();
                ProcessTabKey(true);
                CalcularTotalActivoCorriente();
                CalcularTotalActivoNoCorriente();
            }
        }

        //Handler para permitir NUMEROS REALES en una columna del grid de 'CRÉDITO OTRAS INSTITUCIONES'
        private void txtboxReales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgCre.CurrentCell.OwningColumn.Name.Equals("nSaldoActual") ||
                dtgCre.CurrentCell.OwningColumn.Name.Equals("nCuotaMensual"))
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

        #endregion

        #region CALCULO_BALANCE_GENERAL

        private void CalcularTotalGridTarjetasCre()
        {
            Decimal nTotalSoles      = 0.00m;
            Decimal nTotalDolares    = 0.00m;

            for (int f = 0; f < dtTarjetasCredito.Rows.Count; f++)
            {
                if (dtTarjetasCredito.Rows[f]["cTipModif"].ToString().Equals("D") == false)
                {
                    if (Convert.ToInt32(dtTarjetasCredito.Rows[f]["idMoneda"]) == 1)//SOLES
                    {
                        if (dtTarjetasCredito.Rows[f]["nSaldoActual"] != System.DBNull.Value)
                            nTotalSoles = nTotalSoles + Convert.ToDecimal (dtTarjetasCredito.Rows[f]["nSaldoActual"]);
                    }
                    else//DÓLARES
                    {
                        if (dtTarjetasCredito.Rows[f]["nSaldoActual"] != System.DBNull.Value)
                            nTotalDolares = nTotalDolares + Convert.ToDecimal (dtTarjetasCredito.Rows[f]["nSaldoActual"]);
                    }
                }                
            }

            txtSaldoTarjetasCreSoles.Text   = nTotalSoles.ToString();
            txtSaldoTarjetasCreDolares.Text = nTotalDolares.ToString();

            nTotalSoles = nTotalSoles + ConvertirDolaresASoles(nTotalDolares);
            txtTotalSaldoTarjetasCreSoles.Text = nTotalSoles.ToString();
        }

        private void CalcularTotalGridCre()
        {
            Decimal nTotalSoles      = 0.00m;
            Decimal nTotalDolares    = 0.00m;
            for (int f = 0; f < dtCreditos.Rows.Count; f++)
            {
                if (dtCreditos.Rows[f]["cTipModif"].ToString().Equals("D") == false)
                {
                    if (Convert.ToInt32(dtCreditos.Rows[f]["idMoneda"]) == 1)//SOLES
                    {
                        if (dtCreditos.Rows[f]["nSaldoActual"] != System.DBNull.Value)
                            nTotalSoles = nTotalSoles + Convert.ToDecimal (dtCreditos.Rows[f]["nSaldoActual"]);
                    }
                    else//DÓLARES
                    {
                        if (dtCreditos.Rows[f]["nSaldoActual"] != System.DBNull.Value)
                            nTotalDolares = nTotalDolares + Convert.ToDecimal (dtCreditos.Rows[f]["nSaldoActual"]);
                    }
                }                
            }

            txtSaldoCreSoles.Text   = nTotalSoles.ToString();
            txtSaldoCreDolares.Text = nTotalDolares.ToString();

            nTotalSoles                 = nTotalSoles + ConvertirDolaresASoles(nTotalDolares);
            txtTotalSaldoCreSoles.Text  = nTotalSoles.ToString();
        }

        private void CalcularTotalPasivo()
        {
            //Calcular total 'SALDO DE CRÉDITOS'
            CalcularTotalGridTarjetasCre();
            CalcularTotalGridCre();

            //------------- validar campos vacios ------------->
            if (string.IsNullOrEmpty(txtSaldoTarjetasCreSoles.Text)) txtSaldoTarjetasCreSoles.Text      = "0.00";
            if (string.IsNullOrEmpty(txtSaldoTarjetasCreDolares.Text)) txtSaldoTarjetasCreDolares.Text  = "0.00";
            txtTotalSaldoTarjetasCreSoles.Text = (Convert.ToDecimal (txtSaldoTarjetasCreSoles.Text) + ConvertirDolaresASoles(Convert.ToDecimal (txtSaldoTarjetasCreDolares.Text))).ToString();

            if (string.IsNullOrEmpty(txtSaldoCreSoles.Text)) txtSaldoCreSoles.Text      = "0.00";
            if (string.IsNullOrEmpty(txtSaldoCreDolares.Text)) txtSaldoCreDolares.Text  = "0.00";
            txtTotalSaldoCreSoles.Text = (Convert.ToDecimal (txtSaldoCreSoles.Text) + ConvertirDolaresASoles(Convert.ToDecimal (txtSaldoCreDolares.Text))).ToString();

            if (string.IsNullOrEmpty(txtOtrasDeudasSoles.Text)) txtOtrasDeudasSoles.Text        = "0.00";
            if (string.IsNullOrEmpty(txtOtrasDeudasDolares.Text)) txtOtrasDeudasDolares.Text    = "0.00";
            txtTotalOtrasDeudasSoles.Text = (Convert.ToDecimal (txtOtrasDeudasSoles.Text) + ConvertirDolaresASoles(Convert.ToDecimal (txtOtrasDeudasDolares.Text))).ToString();
            //------------------------------------------------->            

            txtPasivoSoles.Text = (Convert.ToDecimal (txtSaldoTarjetasCreSoles.Text) + Convert.ToDecimal (txtSaldoCreSoles.Text) + Convert.ToDecimal (txtOtrasDeudasSoles.Text)).ToString();
            txtPasivoDolares.Text = (Convert.ToDecimal (txtSaldoTarjetasCreDolares.Text) + Convert.ToDecimal (txtSaldoCreDolares.Text) + Convert.ToDecimal (txtOtrasDeudasDolares.Text)).ToString();
            txtTotalPasivoSoles.Text = (Convert.ToDecimal (txtPasivoSoles.Text) + ConvertirDolaresASoles(Convert.ToDecimal (txtPasivoDolares.Text))).ToString();
        }

        private void CalcularTotalActivoCorriente()
        {
            Decimal nTotalSoles      = 0.00m;
            Decimal nTotalDolares    = 0.00m;

            if (string.IsNullOrEmpty(txtAhoDepPlazoFijoSoles.Text)) txtAhoDepPlazoFijoSoles.Text        = "0.00";
            if (string.IsNullOrEmpty(txtAhoDepPlazoFijoDolares.Text)) txtAhoDepPlazoFijoDolares.Text    = "0.00";

            txtTotalActivoCorrSoles.Text    = (Convert.ToDecimal (txtAhoDepPlazoFijoSoles.Text)).ToString();
            txtTotalActivoCorrDolares.Text  = (Convert.ToDecimal (txtAhoDepPlazoFijoDolares.Text)).ToString();

            nTotalSoles     = Convert.ToDecimal (txtAhoDepPlazoFijoSoles.Text);
            nTotalDolares   = Convert.ToDecimal (txtAhoDepPlazoFijoDolares.Text);

            nTotalSoles = nTotalSoles + ConvertirDolaresASoles(nTotalDolares);

            txtAhoDepPlazoFijoTotalSoles.Text = nTotalSoles.ToString();
            txtTotalActivoCorrTotalSoles.Text = nTotalSoles.ToString();

            CalcularTotalActivo();
            CalcularTotalPasivo();
            CalcularTotalPatrimonio();
        }

        private void CalcularTotalActivoNoCorriente()
        {
            Decimal nTotalSolesVehiculos = 0.00m, nTotalSolesInmuebles = 0.00m,nTotalSolesOtros=0.00m;

            if (string.IsNullOrEmpty(txtVehiculoSoles.Text)) txtVehiculoSoles.Text      = "0.00";
            if (string.IsNullOrEmpty(txtInmuebleSoles.Text)) txtInmuebleSoles.Text      = "0.00";
            if (string.IsNullOrEmpty(txtOtrosSoles.Text)) txtOtrosSoles.Text = "0.00";
            if (string.IsNullOrEmpty(txtVehiculoDolares.Text)) txtVehiculoDolares.Text  = "0.00";
            if (string.IsNullOrEmpty(txtInmuebleDolares.Text)) txtInmuebleDolares.Text  = "0.00";
            if (string.IsNullOrEmpty(txtOtrosDolares.Text)) txtOtrosDolares.Text = "0.00";

            txtInmuebleTotalActivoNoCorrSoles.Text      = string.Format("{0:0.00}",txtVehiculoSoles.nvalor + txtInmuebleSoles.nvalor + txtOtrosSoles.nvalor);
            txtInmuebleTotalActivoNoCorrDolares.Text    = string.Format("{0:0.00}",txtVehiculoDolares.nvalor + txtInmuebleDolares.nvalor + txtOtrosDolares.nvalor);

            //TOTAL EN SOLES
            nTotalSolesVehiculos        = txtVehiculoSoles.nDecValor + ConvertirDolaresASoles(txtVehiculoDolares.nDecValor);
            txtVehiculoTotalSoles.Text  = nTotalSolesVehiculos.ToString();

            nTotalSolesInmuebles        = txtInmuebleSoles.nDecValor + ConvertirDolaresASoles(txtInmuebleDolares.nDecValor);
            txtInmuebleTotalSoles.Text  = nTotalSolesInmuebles.ToString();

            nTotalSolesOtros            = txtOtrosSoles.nDecValor + ConvertirDolaresASoles(txtOtrosDolares.nDecValor);
            txtOtrosTotalSoles.Text     =nTotalSolesOtros.ToString();

            txtInmuebleTotalActivoNoCorrTotalSoles.Text = (nTotalSolesVehiculos + nTotalSolesInmuebles + nTotalSolesOtros).ToString();

            CalcularTotalActivo();
            CalcularTotalPasivo();
            CalcularTotalPatrimonio();
        }

        private void CalcularTotalActivo()
        {
            //------------- validar campos vacios ------------->
            if (string.IsNullOrEmpty(txtAhoDepPlazoFijoSoles.Text)) txtAhoDepPlazoFijoSoles.Text            = "0.00";
            if (string.IsNullOrEmpty(txtAhoDepPlazoFijoDolares.Text)) txtAhoDepPlazoFijoDolares.Text        = "0.00";
            if (string.IsNullOrEmpty(txtAhoDepPlazoFijoTotalSoles.Text)) txtAhoDepPlazoFijoTotalSoles.Text  = "0.00";

            if (string.IsNullOrEmpty(txtTotalActivoCorrSoles.Text)) txtTotalActivoCorrSoles.Text            = "0.00";
            if (string.IsNullOrEmpty(txtTotalActivoCorrDolares.Text)) txtTotalActivoCorrDolares.Text        = "0.00";
            if (string.IsNullOrEmpty(txtTotalActivoCorrTotalSoles.Text)) txtTotalActivoCorrTotalSoles.Text  = "0.00";


            if (string.IsNullOrEmpty(txtVehiculoSoles.Text)) txtVehiculoSoles.Text          = "0.00";
            if (string.IsNullOrEmpty(txtVehiculoDolares.Text)) txtVehiculoDolares.Text      = "0.00";
            if (string.IsNullOrEmpty(txtVehiculoTotalSoles.Text)) txtVehiculoTotalSoles.Text= "0.00";

            if (string.IsNullOrEmpty(txtInmuebleSoles.Text)) txtInmuebleSoles.Text          = "0.00";
            if (string.IsNullOrEmpty(txtInmuebleDolares.Text)) txtInmuebleDolares.Text      = "0.00";
            if (string.IsNullOrEmpty(txtInmuebleTotalSoles.Text)) txtInmuebleTotalSoles.Text= "0.00";

            if (string.IsNullOrEmpty(txtInmuebleTotalActivoNoCorrSoles.Text)) txtInmuebleTotalActivoNoCorrSoles.Text            = "0.00";
            if (string.IsNullOrEmpty(txtInmuebleTotalActivoNoCorrDolares.Text)) txtInmuebleTotalActivoNoCorrDolares.Text        = "0.00";
            if (string.IsNullOrEmpty(txtInmuebleTotalActivoNoCorrTotalSoles.Text)) txtInmuebleTotalActivoNoCorrTotalSoles.Text  = "0.00";
            //------------------------------------------------>
            txtTotalActivoSoles.Text        = (txtTotalActivoCorrSoles.nvalor + txtInmuebleTotalActivoNoCorrSoles.nvalor).ToString();
            txtTotalActivoDolares.Text      = (txtTotalActivoCorrDolares.nvalor + txtInmuebleTotalActivoNoCorrDolares.nvalor).ToString();
            txtTotalActivoTotalSoles.Text   = (txtTotalActivoCorrTotalSoles.nvalor + txtInmuebleTotalActivoNoCorrTotalSoles.nvalor).ToString();
        }

        private void CalcularTotalPatrimonio()
        {
            txtPatrimonioSoles.Text         = (Convert.ToDecimal (txtTotalActivoSoles.Text) - Convert.ToDecimal (txtPasivoSoles.Text)).ToString();
            txtPatrimonioDolares.Text       = (Convert.ToDecimal (txtTotalActivoDolares.Text) - Convert.ToDecimal (txtPasivoDolares.Text)).ToString();
            txtTotalPatrimonioSoles.Text    = (Convert.ToDecimal (txtTotalActivoTotalSoles.Text) - Convert.ToDecimal (txtTotalPasivoSoles.Text)).ToString();
        }

        private Decimal ConvertirDolaresASoles(Decimal nMontoDolares)
        {
            Decimal nConvertido = 0.00m;
            if (nMontoDolares == 0.00m) return nConvertido;

            Decimal nTipoCambio = 0.00m;
            if (!string.IsNullOrEmpty(txtTipCamFij.Text)) { nTipoCambio = Convert.ToDecimal (txtTipCamFij.Text); }
            
            nConvertido = Math.Round(nMontoDolares * Convert.ToDecimal (txtTipCamFij.Text), 1);
            return nConvertido;
        }

        #endregion

        #region EVENTOS_CAMPOS_BALANCE_GENERAL

        private void txtAhoDepPlazoFijoSoles_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtAhoDepPlazoFijoDolares_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtVehiculoSoles_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtVehiculoDolares_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtInmuebleSoles_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtInmuebleDolares_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtAhoDepPlazoFijoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtAhoDepPlazoFijoDolares.Focus();
        }

        private void txtAhoDepPlazoFijoDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtVehiculoSoles.Focus();
        }

        private void txtVehiculoSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtVehiculoDolares.Focus();
        }

        private void txtVehiculoDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtInmuebleSoles.Focus();
        }

        private void txtInmuebleSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtInmuebleDolares.Focus();
        }

        private void txtInmuebleDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) this.txtOtrosSoles.Focus();
        }

        private void txtOtrasDeudasSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtOtrasDeudasDolares.Focus();
        }

        private void txtOtrasDeudasDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtAhoDepPlazoFijoSoles.Focus();
        }

        private void txtOtrasDeudasSoles_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        private void txtOtrasDeudasDolares_Leave(object sender, EventArgs e)
        {
            CalcularTotalActivoCorriente();
            CalcularTotalActivoNoCorriente();
        }

        #endregion
                
        #region METODOS

        private void CalcularRatios()
        {
            //========== CUOTA / EXCEDENTE ==============================================>
            Decimal nCuota = 0;
            if (string.IsNullOrEmpty(txtCuotaAprox.Text)==false) nCuota = Convert.ToDecimal (txtCuotaAprox.Text);

            Decimal nExcedenteTotalSoles = 0;
            if (string.IsNullOrEmpty(txtExcedenteTotalSoles.Text) == false) nExcedenteTotalSoles = Convert.ToDecimal (txtExcedenteTotalSoles.Text);

            if (nExcedenteTotalSoles == 0)
                txtCuotaExcedente.Text = "0.00";
            else
                txtCuotaExcedente.Text = Math.Round((nCuota / nExcedenteTotalSoles), 2).ToString();
            //===========================================================================>

            //========== DEUDA TOTAL / PATRIMONIO =========================================>
            Decimal nMontoSolicitado = 0;
            if (string.IsNullOrEmpty(txtMontProp.Text) == false) nMontoSolicitado = Convert.ToDecimal (txtMontProp.Text);

            Decimal nTotalPasivoSoles = 0;
            if (string.IsNullOrEmpty(txtTotalPasivoSoles.Text)==false) nTotalPasivoSoles = Convert.ToDecimal (txtTotalPasivoSoles.Text);

            Decimal nTotalPatrimonioSoles = 0;
            if (string.IsNullOrEmpty(txtTotalPatrimonioSoles.Text)==false) nTotalPatrimonioSoles = Convert.ToDecimal (txtTotalPatrimonioSoles.Text);

            if (nTotalPatrimonioSoles == 0)
                txtDeudaTotalPatrimonio.Text = "0.00";
            else
                txtDeudaTotalPatrimonio.Text = Math.Round(((nMontoSolicitado + nTotalPasivoSoles) / nTotalPatrimonioSoles), 2).ToString();
            //=============================================================================>

            //========== GARANTÍAS / PRÉSTAMO ===========================================>
            RatioGarantiaPrestamo();
            //===========================================================================>

            //========== INGRESOS DEL CÓNYUGUE Y OTROS / EXCEDENTE =========================================>
            Decimal nIngresosConyugueEnSoles     = 0;
            Decimal nIngresosConyugueEnDolares   = 0;
            Decimal nIngresosConyugueTotalSoles  = 0;
            for (int f = 0; f < dtDetalleIngEvalConsumo.Rows.Count; f++)
            {
                if (Convert.ToInt32(dtDetalleIngEvalConsumo.Rows[f]["IdMoneda"])==1)//SOLES
                {
                    nIngresosConyugueEnSoles += Convert.ToDecimal (dtDetalleIngEvalConsumo.Rows[f]["nMontoFlujo"]);
                }
                else//DOLARES
                {
                    nIngresosConyugueEnDolares += Convert.ToDecimal (dtDetalleIngEvalConsumo.Rows[f]["nMontoFlujo"]);
                }                                
            }
            Decimal nTipoCambio = 0.00m;
            if (string.IsNullOrEmpty(txtTipCamFij.Text)==false)
            {
                nTipoCambio = Convert.ToDecimal (txtTipCamFij.Text);
            }
            nIngresosConyugueTotalSoles = nIngresosConyugueEnSoles + nIngresosConyugueEnDolares * nTipoCambio;

            if (nExcedenteTotalSoles == 0)
                txtIngresosExcedente.Text = "0.00";
            else
                txtIngresosExcedente.Text = Math.Round((nIngresosConyugueTotalSoles / nExcedenteTotalSoles), 2).ToString();
            //===============================================================================================>

            //========== EXPUESTO AL RCC ===================================================================>
            // Supuesto:    Si en los ingresos existen dólares, 
            //              ó en los egresos existen dólares, entonces se está expuesto al RCC
            Decimal nExcedenteDolares = 0;

            if (string.IsNullOrEmpty(txtExcedenteDolares.Text) == false) nExcedenteDolares = Convert.ToDecimal (txtExcedenteDolares.Text);
            if (nExcedenteDolares != 0)
            {
                txtRCC.Text = "SI";                
            }
            else
            {
                txtRCC.Text = "NO";
            }

            //----------------- Verificación adicional para TARJETAS DE CRÉDITO Y CRÉDITOS ----->
            if (txtRCC.Text.Equals("NO"))
            {
                if (Convert.ToDecimal (txtPasivoDolares.Text)>0)
                {
                    txtRCC.Text = "SI";
                }
                else
                {
                    txtRCC.Text = "NO";
                }                                
            }
            if (txtRCC.Text.Equals("NO"))
            {
                //------------- Balance General Activo ---------->
                if (Convert.ToDecimal (txtTotalActivoDolares.Text) > 0)
                {
                    txtRCC.Text = "SI";
                }
                else
                {
                    txtRCC.Text = "NO";
                }
            }
            //===========================================================================>

            //========== SUSTANCIALMENTE EXPUESTO =========================================>
            int nCuotas     = 0;
            if (string.IsNullOrEmpty(txtNroCuotas.Text) == false)
                nCuotas = Convert.ToInt32(txtNroCuotas.Text);

            int nPeriodoPago = 0;
            if (string.IsNullOrEmpty(txtFrecuencia.Text) == false)
            nPeriodoPago    =   Convert.ToInt32(txtFrecuencia.Text);

            ProcesaRiesgoCambiarioCrediticio();
                       
            if (txtRCC.Text.Equals("NO"))
            {
                TxtSustExpuesto.Text = "NO";
            }
            else
            {
                for (int r = 0; r < dtRiesgoCambiarioCrediticio.Rows.Count; r++)
                {
                    if ((nCuotas * nPeriodoPago / 30) >= Convert.ToDecimal (dtEscenarioRcc.Rows[r]["nLimInf"]) &&
                        (nCuotas * nPeriodoPago / 30) <= Convert.ToDecimal (dtEscenarioRcc.Rows[r]["nLimSup"]) &&
                        (Convert.ToDecimal (dtRiesgoCambiarioCrediticio.Rows[r]["nRelacCuotaIngreso"]) <= 0 || Convert.ToDecimal (dtRiesgoCambiarioCrediticio.Rows[r]["nRelacCuotaIngreso"]) >= 1 || dtRiesgoCambiarioCrediticio.Rows[r]["cRiesgoPorPlazo"].ToString().Equals("SI"))
                        )
                    {
                        TxtSustExpuesto.Text = "SI";
                        break;
                    }
                    else
                    {
                        if (r == (dtEscenarioRcc.Rows.Count-1))//Última consulta
                        {
                            TxtSustExpuesto.Text = "NO";
                        }
                    }
                }
            }

            calcularNivelesRatios();
            //=============================================================================>
        }

        private void calcularNivelesRatios()
        {
            DataTable dtRatios = new DataTable("dtRatios");
            dtRatios.Columns.Add("cCodIndicador",typeof(string));
            dtRatios.Columns.Add("nValorIndicador", typeof(decimal));

            DataRow drIndicador;
            drIndicador = dtRatios.NewRow();
            drIndicador["cCodIndicador"] = "I003";
            drIndicador["nValorIndicador"] = txtCuotaExcedente.nvalor*100.00;
            dtRatios.Rows.Add(drIndicador);

            drIndicador = dtRatios.NewRow();
            drIndicador["cCodIndicador"] = "I006";
            drIndicador["nValorIndicador"] = txtDeudaTotalPatrimonio.nvalor*100.00;
            dtRatios.Rows.Add(drIndicador);

            drIndicador = dtRatios.NewRow();
            drIndicador["cCodIndicador"] = "I007";
            drIndicador["nValorIndicador"] = txtGarantiasPrestamo.nvalor*100.00;
            dtRatios.Rows.Add(drIndicador);

            drIndicador = dtRatios.NewRow();
            drIndicador["cCodIndicador"] = "I002";
            drIndicador["nValorIndicador"] = txtIngresosExcedente.nvalor;
            dtRatios.Rows.Add(drIndicador);

            DataSet dsRatios = new DataSet("dsRatios");
            dsRatios.Tables.Add(dtRatios);
            var xmlRatios = dsRatios.GetXml();

            var dtResulRatios = cnevaluacion.CNValidarRangoRatios(xmlRatios);
            if (dtResulRatios.Rows.Count > 0)
            {
                txtI002.Text = "";
                txtI003.Text = "";
                txtI006.Text = "";
                txtI007.Text = "";
                foreach (DataRow item in dtResulRatios.Rows)
                {
                    if (item["cCodIndicador"].ToString() == "I003")
                    {
                        txtI003.Text = item["cDescripcion"].ToString();
                    }
                    if (item["cCodIndicador"].ToString() == "I006")
                    {
                        txtI006.Text = item["cDescripcion"].ToString();
                    }
                    if (item["cCodIndicador"].ToString() == "I007")
                    {
                        txtI007.Text = item["cDescripcion"].ToString();
                    }
                    if (item["cCodIndicador"].ToString() == "I002")
                    {
                        txtI002.Text = item["cDescripcion"].ToString();
                    }                    
                }
                
            }
        }

        private void RatioGarantiaPrestamo()
        {
            Decimal nMontoSolicitado = 0;
            if (string.IsNullOrEmpty(txtMontProp.Text))
            {
                txtMontProp.Text = "0.00";
            }
            nMontoSolicitado = Convert.ToDecimal (txtMontProp.Text);
            
            Decimal nGarantiaTitular = 0;
            if (string.IsNullOrEmpty(txtGaranTitular.Text))
            {
                txtGaranTitular.Text = "0.00";
            }
            nGarantiaTitular = Convert.ToDecimal (txtGaranTitular.Text); ;

            Decimal nGarantiaAval = 0;
            if (string.IsNullOrEmpty(txtGaranAval.Text))
            {
                txtGaranAval.Text = "0.00";
            }
            nGarantiaAval = Convert.ToDecimal (txtGaranAval.Text);

            Decimal nTotalGarantia = nGarantiaTitular + nGarantiaAval;
            if (nMontoSolicitado == 0.00m)
                txtGarantiasPrestamo.Text   = "0.00";
            else
                txtGarantiasPrestamo.Text   = Math.Round((nTotalGarantia/nMontoSolicitado),2).ToString();
        }

        /// <summary>
        /// Calcular el Riesgo Cambiario Crediticio, cuando el tipo de cambio se incrementa en 10%, 20% y 30%
        /// </summary>
        private void ProcesaRiesgoCambiarioCrediticio()
        {
            dtRiesgoCambiarioCrediticio.Clear();//Limpiar la Data anterior, para volver a calcular el nuevo Escenario de Riesgo Crediticio

            Decimal nTipoCambio = 0.00m;
            if (string.IsNullOrEmpty(txtTipCamFij.Text) == false)
            {
                nTipoCambio = Convert.ToDecimal (txtTipCamFij.Text);
            }

            Decimal nCuota = 0;
            if (string.IsNullOrEmpty(txtCuotaAprox.Text)==false)
            {
                nCuota = Convert.ToDecimal (txtCuotaAprox.Text);//Monto de una Cuota según la solicitud de Crédito 
            }

            int nMonedaSolCre = 0;
            if (dtSolicitudCreConsumo.Rows.Count>0)
            {
                nMonedaSolCre = Convert.ToInt32(dtSolicitudCreConsumo.Rows[0]["idMoneda"]);//Moneda según la solitud de crédito
            }               

            Decimal nExcedenteSoles      = Convert.ToDecimal (txtExcedenteSoles.Text);
            Decimal nExcedenteDolares    = Convert.ToDecimal (txtExcedenteDolares.Text);

            //Activo
            Decimal nTotalActivoSoles  =  0;            
            Decimal nTotalActivoDolares=  0;
            //Pasivo
            Decimal nPasivoSoles   =  0;            
            Decimal nPasivoDolares =  0;

            int nNumCuotas = 0;
            if (string.IsNullOrEmpty(txtNumCuotas.Text) == false)
            {
                nNumCuotas = Convert.ToInt32(txtNumCuotas.Text);//Número de cuotas
            }

            int nPeriodoPago = 0;
            if (string.IsNullOrEmpty(txtFrecuencia.Text) == false)
            {
                nPeriodoPago = Convert.ToInt32(txtFrecuencia.Text);//Periodo de PAGO
            }                 

            for (int f = 0; f < dtEscenarioRcc.Rows.Count; f++)
            {
                DataRow drFila                  = dtRiesgoCambiarioCrediticio.NewRow();
                drFila["idRccEvalConsumo"]      = 0;
                drFila["idEvalConsumo"]         = 0;
                drFila["idEscenarioRcc"]        = dtEscenarioRcc.Rows[f]["idEscenarioRcc"].ToString();
                drFila["cEscenario"]            = dtEscenarioRcc.Rows[f]["cEscenario"].ToString();
                drFila["nPorcent"]              = Convert.ToDecimal (dtEscenarioRcc.Rows[f]["nPorcent"]);
                drFila["nPorcentTipoCambio"]    = Math.Round((1+Convert.ToDecimal (dtEscenarioRcc.Rows[f]["nPorcent"])/100)*nTipoCambio,2);

                drFila["cTipModif"] = "I";

                drFila["nRelacCuotaIngreso"] = 0;
                //Identificando la moneda en la que se ha realizado la solictud de crédito
                if (nMonedaSolCre == 1)//Soles
                {
                    //Descalce en Moneda Nacional = Excedente totalizado en soles - cuotaEnSoles*TipoCambio
                    drFila["nDescalceMN"] = Math.Round(nExcedenteSoles + nExcedenteDolares * Convert.ToDecimal (drFila["nPorcentTipoCambio"]) - 1 * nCuota,2);

                    if (Convert.ToDecimal (txtExcedenteTotalSoles.Text) != 0)
	                {
                        drFila["nRelacCuotaIngreso"] = Math.Round(nCuota * 1 / Convert.ToDecimal (txtExcedenteTotalSoles.Text),2);//División entre cuota en Soles/ Excedente en soles
	                }                  
                }
                else//Dólares
                {
                    //Descalce en Moneda Nacional = Excedente totalizado en soles - cuotaEnSoles*TipoCambio
                    drFila["nDescalceMN"] = Math.Round(nExcedenteSoles + nExcedenteDolares * Convert.ToDecimal (drFila["nPorcentTipoCambio"]) - Convert.ToDecimal (drFila["nPorcentTipoCambio"]) * nCuota,2);

                    if (Convert.ToDecimal (txtExcedenteTotalSoles.Text) != 0)
                    {
                        drFila["nRelacCuotaIngreso"] = Math.Round(nCuota * Convert.ToDecimal (drFila["nPorcentTipoCambio"]) / Convert.ToDecimal (txtExcedenteTotalSoles.Text),2);//División entre cuota en Soles/ Excedente en soles
                    }                     
                }

                //---------------------------------------------- IMPACTO AL PATRIMONIO ---------------------------------------------->
                //Activo
                nTotalActivoSoles     = Convert.ToDecimal (txtTotalActivoSoles.Text);
                nTotalActivoDolares   = Convert.ToDecimal (txtTotalActivoDolares.Text);
                //Pasivo
                nPasivoSoles      = Convert.ToDecimal (txtPasivoSoles.Text);
                nPasivoDolares    = Convert.ToDecimal (txtPasivoDolares.Text);

                drFila["nImpactoPatrim"] = Math.Round(
                                                    (nTotalActivoSoles + nTotalActivoDolares * Convert.ToDecimal (drFila["nPorcentTipoCambio"])) -
                                                    ((nPasivoSoles      + nPasivoDolares * Convert.ToDecimal (drFila["nPorcentTipoCambio"])))
                                            ,2);//Variación del tipo de cambio sobre los ingreso y egresos
                //------------------------------------------------------------------------------------------------------------------->
                
                //---------------------- Insolvencia o Fortaleza Patrimonial por Tipo de Cambio -------------------------------------->
                // ImpactoAlPatrimonioConTipoCambioNormal/(Impacto Al Patrimonio + Descalce en Moneda Nacional)
                Decimal ImpactoAlPatrimonioConTipoCambioNormal = (nTotalActivoSoles + nTotalActivoDolares * nTipoCambio) -
                                                                (nPasivoSoles + nPasivoDolares*nTipoCambio);

                drFila["nInsolvFortPatrimTC"] = 0;
                if (Convert.ToDecimal (drFila["nImpactoPatrim"]) + Convert.ToDecimal (drFila["nDescalceMN"]) != 0)
                {
                    drFila["nInsolvFortPatrimTC"] = Math.Round(ImpactoAlPatrimonioConTipoCambioNormal / (Convert.ToDecimal (drFila["nImpactoPatrim"]) + Convert.ToDecimal (drFila["nDescalceMN"])),2); 
                }                 
                //------------------------------------------------------------------------------------------------------------------->

                //---------------------------------------- Riesgo Por Plazo -------------------------------------------------->
                if (Convert.ToDecimal (drFila["nImpactoPatrim"]) < 0)
                {
                    drFila["cRiesgoPorPlazo"] = "SI";
                }
                else
                {
                    if (Convert.ToDecimal (drFila["nInsolvFortPatrimTC"]) > 0)
                    {
                        drFila["cRiesgoPorPlazo"] = "NO";
                    }
                    else
                    {
                        if (Convert.ToDecimal (drFila["nInsolvFortPatrimTC"]) <= 0 &&
                            (nNumCuotas * nPeriodoPago) / 360 <= Math.Abs(Convert.ToDecimal (drFila["nInsolvFortPatrimTC"]))
                            )
                        {
                             drFila["cRiesgoPorPlazo"] = "SI";
                        }
                        else
	                    {
                             drFila["cRiesgoPorPlazo"] = "NO";
	                    }
                    }
                }
                //------------------------------------------------------------------------------------------------------------>
                dtRiesgoCambiarioCrediticio.Rows.Add(drFila);
			}
        }

        private void Habilitar(bool lval)
        {
            this.btnGrabar1.Enabled = lval;
            this.btnNuevo1.Enabled = !lval;
            //this.btnEditar1.Enabled   = lval;
            this.btnCancelar1.Enabled = lval;
            this.btn_Vincular1.Enabled = lval;
            this.cboPorcenIngReal.Enabled = lval;
            this.cboTipGarRDS.Enabled = lval;
            this.txtComenRDS.Enabled = lval;
            this.txtDebilidad.Enabled = lval;
            this.txtFortaleza.Enabled = lval;
            this.txtNumCuoRDS.Enabled = lval;
            this.txtOtros.Enabled = lval;
            this.dtpFecVig.Enabled = !lval;
            this.txtNumEva.Enabled = !lval;
            this.btnAgregaEgr.Enabled = lval;
            this.btnAgregaIng.Enabled = lval;
            this.btnQuitaIng.Enabled = lval;
            this.btnQuitarEgr.Enabled = lval;
            this.conBusCli1.txtCodCli.Enabled = !lval;
            this.txtNumReaExede.Visible = true;
            this.txtNumReaCuota.Visible = true;
            this.grbNroSolicitud.Enabled = lval;
            this.grbEvalCualitativa.Enabled = lval;
        }

        private void QuitarComboBoxs()
        {
            this.dtgIntervinientes.Columns.Remove("cboTipoInterv");
        }

        private void ActualizarEstPerdGanan()
        {
            foreach (DataGridViewRow row in dtgEstPerdGanan.Rows)
            {
                switch (Convert.ToInt32(row.Cells["IdPlantiEstPerdiGana"].Value))
                {
                    case 1://Monto de Ventas
                        if (string.IsNullOrEmpty(txtTotalIngrEstResulSolesTotal.Text)) txtTotalIngrEstResulSolesTotal.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotalIngrEstResulSolesTotal.Text);
                        break;
                    case 2://Costo Total de Compras y/o Producción                       
                        row.Cells["nMontoParti"].Value = "0.00";
                        break;
                    case 3://Utilidad Bruta
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 0].Value) -
                                                        Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 1].Value);
                        break;
                    case 4://Gastos Operativos
                        if (string.IsNullOrEmpty(txtTotalEgrEstResulSolesTotal.Text)) txtTotalEgrEstResulSolesTotal.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotalEgrEstResulSolesTotal.Text);
                        break;
                    case 5://Utilidad Operativa
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 2].Value) -
                                                         Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 3].Value);
                        break;
                    case 6://Obligaciones del Negocio
                        if (string.IsNullOrEmpty(txtTotalPasivoSoles.Text)) txtTotalPasivoSoles.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotalPasivoSoles.Text);
                        break;
                    case 7://Utilidad Neta
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 4].Value) -
                                                        Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 5].Value);
                        break;
                    case 9://Obligaciones de la Unidad Económica Familiar
                        row.Cells["nMontoParti"].Value = "0.00";
                        break;
                    case 10://Gastos de la Unidad Económica Familiar
                        row.Cells["nMontoParti"].Value = "0.00";
                        break;
                    case 11://Excedente la Unidad Económica Familiar'
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 6].Value) +
                                                            Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 7].Value) -
                                                            Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 8].Value) -
                                                            Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 9].Value);
                        break;
                    case 12://Capacidad de Pago
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 10].Value) *
                                                        Convert.ToDecimal(row.Cells["nPorcenParti"].Value) / 100;
                        break;
                }
            }
            //CalcularRatios();
        }

        private void EditarDataTableEstPerdganan()
        {
            if (!dtgEstPerdGanan.Columns.Contains("IdEstPerdiGana"))
            {
                dtEstPerdGanancias.Columns.Add("IdEstPerdiGana", typeof(int), "-1");
            }

            if (!dtgEstPerdGanan.Columns.Contains("IdEvalEmp"))
            {
                dtEstPerdGanancias.Columns.Add("IdEvalEmp", typeof(int), "-1");
            }
        }

        #endregion

    }
}