using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using System.IO;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmEvaSolEmp : frmBase
    {
#region Declaraciones

        bool lFlagValidar = true;
        static int IdInterno;
        DataTable dtMaestro;
        DataTable dtDetalle;
        DataTable dtCosteoDetalle;
        DataTable dtDetCreNegocio;
        DataTable dtDetCreUniFam;
        DataTable dtDetGastosPersonal;
        DataTable dtGastServNego;
        DataTable dtGastUniFam;
        DataTable dtEstPerdGana;
        DataTable dtBalanceGeneral;
        DataTable dtIntervinientes;
        DataTable dtDetalleFotos = new DataTable("dtDetalleFotos");
        DataTable dtSolicitud = new DataTable();
        DataTable dtGarantias = new DataTable();
        clsListGarantia lstGarantias = new clsListGarantia();
        clsCNEvalEmp EvalEmp = new clsCNEvalEmp();
        clsCNSolicitud Solicitud = new clsCNSolicitud();
        clsCNGenAdmOpe tipoCambio = new clsCNGenAdmOpe();
        Int32 idNumEva = 0;//Número de evaluación anterior (se usa para actualizar estado en Base de Datos)
        Int16 nOpcConsulta = 1;//1 busqueda edicion, 2 consulta
        int nIndexDtg = 1;
        string cRutaFotos = "";
        bool lFlagGuardado = false;
        DataTable dtRutasAntesEditar;
        int nNroFoto = 0;

        ComboBox cboTipoGiro;//Combo que se usará para seleccionar el tipo del giro del negocio
                            //Se usará como control de pivote en el grid de Evaluación

        DataTable dtParametros  = new DataTable("dtParametros");//Los Praámetros porcentuales a los Conceptos de Ingreso/Egreso del Flujo de Caja

        DataTable dtTipoCambio;

        DataTable dtComportamientos = new DataTable("dtComportamientos");
        DataTable dtVariables       = new DataTable("dtVariables");//las Variables que afectan a los Meses del Ingreso/Egreso del Flujo de Caja

        DataTable dtFlujoCajaIngreso;//Contendrá el Flujo de Caja para INGRESO
        DataTable dtFlujoCajaEgreso;//Contendrá el Flujo de Caja para EGRESO

        DataTable dtFlujoCaja       = new DataTable("dtFlujoCaja");

        DataTable dtSolicitudCreEmpresarial= new DataTable();//Contiene los datos de la solicitud de crédito

        private class clsParametrosFlujoCaja
        {
            public Decimal INGRESO_TOTAL;
            public Decimal OTROS_INGRESOS;
            public Decimal PRESTAMO;
            public Decimal COSTO_TOTAL;
            public Decimal GASTOS_PERSONAL;
            public Decimal GASTOS_SERVICIOS_NEGOCIO;
            public Decimal PAGO_CUOTAS_OTROS_BANCOS;
            public Decimal CUOTAS;
            public Decimal GASTOS_FAMILIAR;
            public Decimal INVERSION_REINVERSION;
        }

        clsParametrosFlujoCaja ParametrosFlujoCaja = new clsParametrosFlujoCaja();
        clsCNEvaluacion Evalua = new clsCNEvaluacion();

#endregion

        #region constructor

        public frmEvaSolEmp()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos Controles Formulario

        private void Form_Load(object sender, EventArgs e)
        {
            DataSet dsParametrosFlujoCajaEvalEmp = EvalEmp.CNdsObtenerParametrosFlujoCajaEvalEmp();
            dtParametros = dsParametrosFlujoCajaEvalEmp.Tables[1];//Conceptos de Parametros
            if (dtParametros.Rows.Count == 0)//Crear parámetros por defecto
            {
                MessageBox.Show("Aún no se han registrado Parámetros para el Flujo de Caja de la Evaluación Empresarial.", "Parámetros Flujo Caja - Evaluacion Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            

            for (int f = 0; f < dtParametros.Rows.Count; f++)
			{
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==1)
                    ParametrosFlujoCaja.INGRESO_TOTAL = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==2)
                    ParametrosFlujoCaja.OTROS_INGRESOS = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==3)
                    ParametrosFlujoCaja.PRESTAMO = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==4)
                    ParametrosFlujoCaja.COSTO_TOTAL = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==5)
                    ParametrosFlujoCaja.GASTOS_PERSONAL = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==6)
                    ParametrosFlujoCaja.GASTOS_SERVICIOS_NEGOCIO = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);			    
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==7)
                    ParametrosFlujoCaja.PAGO_CUOTAS_OTROS_BANCOS = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			    if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==8)
                    ParametrosFlujoCaja.CUOTAS = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"])==9)
                    ParametrosFlujoCaja.GASTOS_FAMILIAR = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 10)
                    ParametrosFlujoCaja.INVERSION_REINVERSION = Convert.ToDecimal (dtParametros.Rows[f]["nPorcent"]);
			}

            pbFotos.Image = null;
            Habilitar(1);
            FormatoBalance();
            foreach (TabPage page in tbcGeneral.TabPages)
            {
                page.Show();
            }

            dtpFecReg.Value = clsVarGlobal.dFecSystem;
            dtpFechaDesembolso.Value = clsVarGlobal.dFecSystem;
            dtpFecTomInv.Value = clsVarGlobal.dFecSystem;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(this.conBusCli.txtCodCli.Text) || string.IsNullOrEmpty(this.conBusCli.txtNroDoc.Text))
            {
                MessageBox.Show("Debe seleccionar a un cliente para registrar una nueva evaluación", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.conBusCli.txtCodCli.Focus();
                return;
            }

            this.conBusCli.btnBusCliente.Enabled = false;

            Int32 nidCliente = Convert.ToInt32(conBusCli.txtCodCli.Text);
            //============= Verificar que exista una Solicitud vigente de crédito Empresarial ===========>
            dtSolicitudCreEmpresarial = Solicitud.CNdtBuscarDatosSolCreEmpresarial(nidCliente);

            if (dtSolicitudCreEmpresarial.Rows.Count > 0)
            {
                CargarDatosCreditoSolicitado();
            }
            else
            {
                MessageBox.Show("No existe solicitud de CRÉDITO TIPO EMPRESARIAL vigente para éste cliente", "Valida evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //=======================================================================================>

            DataTable dtEvalEmprCliente = EvalEmp.CNdtEvalEmprIdCliente(nidCliente);
            if (dtEvalEmprCliente.Rows.Count > 0 && dtEvalEmprCliente.Rows[0]["IdSolicitud"] == DBNull.Value)
            {
                idNumEva = Convert.ToInt32(dtEvalEmprCliente.Rows[0]["IdEvalEmp"].ToString());
                DialogResult result = MessageBox.Show("Presione:" + Environment.NewLine + "SI   : si desea registrar una evaluación vinculada." + Environment.NewLine + "NO: si desea crear una nueva Evaluación.",
                                                        "Evaluación Empresarial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    nOpcConsulta = 1;
                    txtNumEva.Enabled = true;
                    //idNumEva = Convert.ToInt32(dtEvalEmprCliente.Rows[0]["IdEvalEmp"].ToString());
                    txtNumEva.Text = idNumEva.ToString();
                    txtNumEva.Focus();
                    SendKeys.Send("{ENTER}");
                    dtgDetEva.Enabled = false;
                    btnImprimir.Visible = true;
                    return;
                }               
            }

            btnImprimir.Visible = false;

            dtgComportamiento.ForeColor = Color.Black;
            dtgIngresos.ForeColor = Color.Black;
            dtgEgresos.ForeColor = Color.Black;
            dtgVariables.ForeColor = Color.Black;

            DateTime dFechaAct = Convert.ToDateTime(clsVarApl.dicVarGen["dFechaAct"]);
            Int32 nVigenciaEva = Convert.ToInt32(clsVarApl.dicVarGen["nVigEvaEmp"]);

            DataSet ds = EvalEmp.CNdsEvalEmpr(0);
            dtMaestro = ds.Tables[0];

            decimal nTipCamFij = clsVarApl.dicVarGen["nTipCamFij"];

            DataRow dr = dtMaestro.NewRow();
            dr["IdEvalEmp"] = 0;
            dr["dFechaReg"] = dFechaAct;
            dr["dFechaVig"] = dFechaAct.AddDays(nVigenciaEva);
            dr["IdMoneda"] = 1;
            dr["nTipoCambio"] = nTipCamFij;
            dr["idCliente"] = nidCliente;
            dr["IdUsuReg"] = clsVarGlobal.User.idUsuario;
            dr["dFecTomaInv"] = dFechaAct;
            dr["nDeuSisFin"] = 0.00;
            dr["lvigente"] = 1;
            dtMaestro.Rows.Add(dr);

            dtDetalle = ds.Tables[1];
            dtDetalle.TableName = "dtDetEvaEmp";
            dtDetalle.Columns.Add("IdInterno", typeof(int));
            dtDetalle.Columns.Add("cDetallePeriodo", typeof(string));

            dtCosteoDetalle = ds.Tables[2];
            dtCosteoDetalle.TableName = "dtCosteoDetalle";
            dtCosteoDetalle.Columns.Add("IdInterno", typeof(int));

            dtDetCreNegocio = ds.Tables[3];

            dtDetCreUniFam = ds.Tables[4];

            dtDetGastosPersonal = ds.Tables[5];

            dtGastServNego = ds.Tables[6];

            dtGastUniFam = ds.Tables[7];

            conTLVBalance.cargarPlantilla(1);

            dtEstPerdGana = EvalEmp.CNdtEstPerGanan(0);

            dtDetalleFotos = ds.Tables[10];

            dtIntervinientes = ds.Tables[11];

            dtgDetEva.DataSource        = dtDetalle;
            dtgCosteo.DataSource        = dtCosteoDetalle;
            dtgDetCreNeg.DataSource     = dtDetCreNegocio;
            dtgDetCreFam.DataSource     = dtDetCreUniFam;
            dtgGasPersonal.DataSource   = dtDetGastosPersonal;
            dtgGasNego.DataSource       = dtGastServNego;
            dtgGasUniFam.DataSource     = dtGastUniFam;
            dtgEstPerdGanan.DataSource  = dtEstPerdGana;
            dtgDetalleFotos.DataSource  = dtDetalleFotos;
            dtgIntervinientes.DataSource= dtIntervinientes;

            AgregarComboBoxs();

            FormatoGridDetalle();
            VincEvaComponentes();
            FormatoGridCosteo();
            VincDetEvaComponentes();
            FormatoGridDetalleCreditos();
            FormatoGridDetGastPersonal();
            FormatoGridDetGastos();
            FormatoEstPerdGanan();
            FormatoGridDetalleFotos();
            FormatoGridIntervinientes();

            Habilitar(4);

            //Cargar TipoCambio
            CargarTipoCambio();

            //Comportamientos
            dtComportamientos            = FormarNuevaEstructuraComportamiento();
            dtgComportamiento.DataSource = dtComportamientos;
            dtgComportamiento.ReadOnly   = false;
            dtgComportamiento.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            
            ordenarCiclo(dtpFechaDesembolso.Value.Month);

            //Variables Porcetuales
            dtVariables             = FormarNuevaEstructuraVariables(dtComportamientos);
            dtgVariables.DataSource = dtVariables;
            DarFormatoGridVariables();

            //Flujo CajaIngresos
            dtFlujoCajaIngreso      = FormarNuevaEstructuraFCIngresos();
            dtgIngresos.DataSource  = dtFlujoCajaIngreso;
            DarFormatogridIngresos();
          
            //Flujo Caja Egresos
            dtFlujoCajaEgreso       = FormarNuevaEstructuraFCEgresos();
            dtgEgresos.DataSource   = dtFlujoCajaEgreso;
            DarFormatoGridEgresos();

            btnConsultar.Enabled = false;
        }

        private void ordenarCiclo(int nMes)
        {
            dtgComportamiento.Columns["Enero"].DisplayIndex = (1 - nMes) < 0 ? (1 - nMes + 12) : (1 - nMes);
            dtgComportamiento.Columns["Febrero"].DisplayIndex = (2 - nMes) < 0 ? (2 - nMes + 12) : (2 - nMes);
            dtgComportamiento.Columns["Marzo"].DisplayIndex = (3 - nMes) < 0 ? (3 - nMes + 12) : (3 - nMes);
            dtgComportamiento.Columns["Abril"].DisplayIndex = (4 - nMes) < 0 ? (4 - nMes + 12) : (4 - nMes);
            dtgComportamiento.Columns["Mayo"].DisplayIndex = (5 - nMes) < 0 ? (5 - nMes + 12) : (5 - nMes);
            dtgComportamiento.Columns["Junio"].DisplayIndex = (6 - nMes) < 0 ? (6 - nMes + 12) : (6 - nMes);
            dtgComportamiento.Columns["Julio"].DisplayIndex = (7 - nMes) < 0 ? (7 - nMes + 12) : (7 - nMes);
            dtgComportamiento.Columns["Agosto"].DisplayIndex = (8 - nMes) < 0 ? (8 - nMes + 12) : (8 - nMes);
            dtgComportamiento.Columns["Setiembre"].DisplayIndex = (9 - nMes) < 0 ? (9 - nMes + 12) : (9 - nMes);
            dtgComportamiento.Columns["Octubre"].DisplayIndex = (10 - nMes) < 0 ? (10 - nMes + 12) : (10 - nMes);
            dtgComportamiento.Columns["Noviembre"].DisplayIndex = (11 - nMes) < 0 ? (11 - nMes + 12) : (11 - nMes);
            dtgComportamiento.Columns["Diciembre"].DisplayIndex = (12 - nMes) < 0 ? (12 - nMes + 12) : (12 - nMes);

            foreach (DataGridViewColumn item in dtgComportamiento.Columns)
            {
                if (item.DisplayIndex == 0)
                {
                    item.ReadOnly = true;
                }
            }
        }

        private void CargarDatosCreditoSolicitado()
        {
            txtMonSolicitado.Text = dtSolicitudCreEmpresarial.Rows[0]["nCapitalSolicitado"].ToString();
            txtMonedaCreSol.Text = dtSolicitudCreEmpresarial.Rows[0]["cMoneda"].ToString();
            txtTipoCredito.Text = dtSolicitudCreEmpresarial.Rows[0]["cTipCredito"].ToString();
            txtProducto.Text = dtSolicitudCreEmpresarial.Rows[0]["cProducto"].ToString();
            txtNumCuotas.Text = dtSolicitudCreEmpresarial.Rows[0]["nCuotas"].ToString();
            txtFrecuencia.Text = dtSolicitudCreEmpresarial.Rows[0]["nPlazoCuota"].ToString();
            txtTasaInteres.Text = dtSolicitudCreEmpresarial.Rows[0]["nTasaCompensatoria"].ToString();
            txtDiaGracia.Text = dtSolicitudCreEmpresarial.Rows[0]["nDiasGracia"].ToString();
            txtActividad.Text = dtSolicitudCreEmpresarial.Rows[0]["cActividad"].ToString();
            txtDestino.Text = dtSolicitudCreEmpresarial.Rows[0]["cDestino"].ToString();

            int idTipoPeriodo = Convert.ToInt32(dtSolicitudCreEmpresarial.Rows[0]["idTipoPeriodo"]);
            txtTipoPeriodo.Text = dtSolicitudCreEmpresarial.Rows[0]["cDescripTipoPeriodo"].ToString();

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

            int idSol = Convert.ToInt32(dtSolicitudCreEmpresarial.Rows[0]["idSolicitud"]);

            DataTable dtTasaGarantia = new clsCNGarantia().CNSaldoTasado(idSol);
            if (dtTasaGarantia.Rows.Count > 0)
            {
                txtGarantia.Text = dtTasaGarantia.Rows[0]["nSaldo"].ToString();
            }
            cargarDatosPropuesta(idSol);
        }

        private void txtNumEva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Convert.ToInt64(txtNumEva.Text) > Int32.MaxValue)
                {
                    MessageBox.Show("El número es muy grande, Ingrese otro valor.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumEva.Text = "";
                    return;
                }

                idNumEva = Convert.ToInt32(txtNumEva.Text);

                DataSet ds  = EvalEmp.CNdsEvalEmpr(idNumEva);
                dtMaestro   = ds.Tables[0];
                
                if (dtMaestro.Rows.Count > 0)
                {
                    txtTotVentas.TextChanged -= new EventHandler(txtTotVentas_TextChanged);
                    txtMontProp.TextChanged -= new EventHandler(txtMontProp_TextChanged);
                    txtCuotaAprox.TextChanged -= new EventHandler(txtCuotaAprox_TextChanged);
                    txtNroCuotas.TextChanged -= new EventHandler(txtNroCuotas_TextChanged);
                    txtTEM.TextChanged -= new EventHandler(txtTEM_TextChanged);
                    txtTotMontCuotaNeg.TextChanged -= new EventHandler(txtTotMontCuotaNeg_TextChanged);
                    txtTotMontCuotaFam.TextChanged -= new EventHandler(txtTotMontCuotaFam_TextChanged);

                    dtMaestro.Rows[0]["IdEvalRel"] = idNumEva;

                    conBusCli.Enabled = true;
                    conBusCli.txtCodCli.Enabled = true;

                    conBusCli.txtCodCli.Text = dtMaestro.Rows[0]["IdCliente"].ToString();
                    conBusCli.txtCodCli.Focus();

                    //============= Verificar que exista una Solicitud vigente de crédito Empresarial ===========>
                    Int32 nidCliente            = Convert.ToInt32(conBusCli.txtCodCli.Text);
                    dtSolicitudCreEmpresarial   = Solicitud.CNdtBuscarDatosSolCreEmpresarial(nidCliente);
                    if (dtSolicitudCreEmpresarial.Rows.Count > 0)
                    {
                        CargarDatosCreditoSolicitado();
                    }
                    else
                    {
                        MessageBox.Show("No existe solicitud de CRÉDITO TIPO EMPRESARIAL vigente para éste cliente", "Valida evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //=======================================================================================>
                    SendKeys.Send("{ENTER}");
                    conBusCli.btnBusCliente.Enabled = false;

                    dtDetalle = ds.Tables[1];
                    dtDetalle.Columns.Add("IdInterno", typeof(int));
                    dtDetalle.Columns.Add("cDetallePeriodo", typeof(string));
                    dtDetalle.TableName = "dtDetEvaEmp";

                    dtCosteoDetalle = ds.Tables[2];
                    dtCosteoDetalle.Columns.Add("IdInterno", typeof(int));                   
                    
                    dtCosteoDetalle.TableName = "dtCosteoDetalle";

                    dtDetCreNegocio = ds.Tables[3];

                    dtDetCreUniFam = ds.Tables[4];

                    dtDetGastosPersonal = ds.Tables[5]; ;

                    dtGastServNego = ds.Tables[6];

                    dtGastUniFam = ds.Tables[7];

                    dtBalanceGeneral = ds.Tables[8];

                    dtEstPerdGana = ds.Tables[9];

                    dtDetalleFotos  = ds.Tables[10];

                    dtIntervinientes = ds.Tables[11];

                    dtGarantias = ds.Tables[12];

                    //---------------------------------------------------------------------------------------------------->
                    DateTime dFechaAuxiliar;
                    // Comportamientos                   
                    DataTable dtAuxVariables = ds.Tables[13];
                    
                    dtComportamientos = FormarNuevaEstructuraComportamiento();
                    for (int c = 0; c < dtComportamientos.Columns.Count; c++)
                    {
                        dtComportamientos.Rows[0][c]=false;
                        dtComportamientos.Rows[1][c] = false;
                        dtComportamientos.Rows[2][c] = false;
                    }

                    int nMes        =   0;
                    int nTipoCiclo  =   0;//1:BAJA 2:MEDIA 3:ALTA
#region Comportamiento
                    for (int f = 0; f < dtAuxVariables.Rows.Count; f++)
                    {
                        dFechaAuxiliar  = Convert.ToDateTime(dtAuxVariables.Rows[f]["dMes"]);
                        nMes            = dFechaAuxiliar.Month;                         
                        nTipoCiclo      = Convert.ToInt32(dtAuxVariables.Rows[f]["idTipoCicloNegocio"]);

                        if (nMes == 1)//Enero
                        {
                            if (nTipoCiclo == 1)
	                            dtComportamientos.Rows[2][nMes - 1] =   true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] =   true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] =   true;
                        }
                        if (nMes == 2)//Febrero
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 3)//Marzo
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 4)//Abril
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 5)//Mayo
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 6)//Junio
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 7)//Julio
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 8)//Agosto
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 9)//Setiembre
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 10)//Octubre
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 11)//Noviembre
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                        if (nMes == 12)//Diciembre
                        {
                            if (nTipoCiclo == 1)
                                dtComportamientos.Rows[2][nMes - 1] = true;
                            if (nTipoCiclo == 2)
                                dtComportamientos.Rows[1][nMes - 1] = true;
                            if (nTipoCiclo == 3)
                                dtComportamientos.Rows[0][nMes - 1] = true;
                        }
                    }
                    dtgComportamiento.DataSource = dtComportamientos;
#endregion                     
                    dtgComportamiento.ReadOnly = false;
                    dtgComportamiento.RowsDefaultCellStyle.SelectionBackColor = Color.White;

                    if (dtMaestro.Rows.Count > 0)
                    {
                        ordenarCiclo(dtpFechaDesembolso.Value.Month);
                    }
                    

                    //Variables Porcentuales
                    dtVariables = FormarNuevaEstructuraVariables(dtComportamientos);
                    for (int c = 0; c < dtAuxVariables.Rows.Count; c++)
                    {
                        dFechaAuxiliar              = Convert.ToDateTime(dtAuxVariables.Rows[c]["dMes"]);
                        dtVariables.Rows[0][c + 3]  = dtAuxVariables.Rows[c]["nPorcentVarIngreso"];
                    }
                    dtgVariables.DataSource = dtVariables;
                    DarFormatoGridVariables();                    
                    //--------------------------------------------------------------------------------------------------->

                    dtFlujoCaja = ds.Tables[14];

                    //INGRESO
                    dtFlujoCajaIngreso = new DataTable("dtFlujoCajaIngreso");
                    dtFlujoCajaIngreso.Columns.Add("cDescr",typeof(string));
                    dtFlujoCajaIngreso.Columns.Add("idFlujoCajaEvalEmp", typeof(int));
                    dtFlujoCajaIngreso.Columns.Add("IdParametrosFlujoCaja",typeof(int));
                    for (int c = 1; c <= 12; c++)
			        {
                        dtFlujoCajaIngreso.Columns.Add("nMes" + c,typeof(int));
			        }

                    dtFlujoCajaEgreso = dtFlujoCajaIngreso.Clone();
                    dtFlujoCajaEgreso.TableName = "dtFlujoCajaEgreso";

                    for (int f = 0; f < dtFlujoCaja.Rows.Count; f++)
			        {                        
			            if (Convert.ToInt32(dtFlujoCaja.Rows[f]["idTipoIngresoEgreso"])==1)//INGRESO
	                    {
		                    DataRow dr      = dtFlujoCajaIngreso.NewRow();
                            dr["cDescr"]    = dtFlujoCaja.Rows[f]["cConcepIngresoEgreso"];
                            dr["idFlujoCajaEvalEmp"] = dtFlujoCaja.Rows[f]["idFlujoCajaEvalEmp"];
                            dr["IdParametrosFlujoCaja"]    = dtFlujoCaja.Rows[f]["IdParametrosFlujoCaja"];
                            dr["nMes1"]     = dtFlujoCaja.Rows[f]["nMes1"];
                            dr["nMes2"]     = dtFlujoCaja.Rows[f]["nMes2"];
                            dr["nMes3"]     = dtFlujoCaja.Rows[f]["nMes3"];
                            dr["nMes4"]     = dtFlujoCaja.Rows[f]["nMes4"];
                            dr["nMes5"]     = dtFlujoCaja.Rows[f]["nMes5"];
                            dr["nMes6"]     = dtFlujoCaja.Rows[f]["nMes6"];
                            dr["nMes7"]     = dtFlujoCaja.Rows[f]["nMes7"];
                            dr["nMes8"]     = dtFlujoCaja.Rows[f]["nMes8"];
                            dr["nMes9"]     = dtFlujoCaja.Rows[f]["nMes9"];
                            dr["nMes10"]     = dtFlujoCaja.Rows[f]["nMes10"];
                            dr["nMes11"]     = dtFlujoCaja.Rows[f]["nMes11"];
                            dr["nMes12"]     = dtFlujoCaja.Rows[f]["nMes12"];

                            dtFlujoCajaIngreso.Rows.Add(dr);
	                    }
                        if (Convert.ToInt32(dtFlujoCaja.Rows[f]["idTipoIngresoEgreso"])==2)//EGRESO
	                    {
		                    DataRow dr      = dtFlujoCajaEgreso.NewRow();
                            dr["cDescr"]    = dtFlujoCaja.Rows[f]["cConcepIngresoEgreso"];
                            dr["idFlujoCajaEvalEmp"] = dtFlujoCaja.Rows[f]["idFlujoCajaEvalEmp"];
                            dr["IdParametrosFlujoCaja"]    = dtFlujoCaja.Rows[f]["IdParametrosFlujoCaja"];
                            dr["nMes1"]     = dtFlujoCaja.Rows[f]["nMes1"];
                            dr["nMes2"]     = dtFlujoCaja.Rows[f]["nMes2"];
                            dr["nMes3"]     = dtFlujoCaja.Rows[f]["nMes3"];
                            dr["nMes4"]     = dtFlujoCaja.Rows[f]["nMes4"];
                            dr["nMes5"]     = dtFlujoCaja.Rows[f]["nMes5"];
                            dr["nMes6"]     = dtFlujoCaja.Rows[f]["nMes6"];
                            dr["nMes7"]     = dtFlujoCaja.Rows[f]["nMes7"];
                            dr["nMes8"]     = dtFlujoCaja.Rows[f]["nMes8"];
                            dr["nMes9"]     = dtFlujoCaja.Rows[f]["nMes9"];
                            dr["nMes10"]     = dtFlujoCaja.Rows[f]["nMes10"];
                            dr["nMes11"]     = dtFlujoCaja.Rows[f]["nMes11"];
                            dr["nMes12"]     = dtFlujoCaja.Rows[f]["nMes12"];

                            dtFlujoCajaEgreso.Rows.Add(dr);
	                    }
			        }

                    AnadirCamposCamposSumatoria();
                    DarFormatogridIngresos();
                    DarFormatoGridEgresos();

                    dtgComportamiento.ReadOnly  = true;
                    dtgIngresos.ReadOnly        = true;
                    dtgEgresos.ReadOnly         = true;
                    dtgVariables.ReadOnly       = true;

                    dtgComportamiento.ForeColor = Color.Gray; 
                    dtgIngresos.ForeColor       = Color.Gray;                    
                    dtgEgresos.ForeColor        = Color.Gray;                    
                    dtgVariables.ForeColor      = Color.Gray;
              
                    dtDetCreNegocio.DefaultView.RowFilter       = ("lVigente <> 0");
                    dtDetCreUniFam.DefaultView.RowFilter        = ("lVigente <> 0");
                    dtDetGastosPersonal.DefaultView.RowFilter   = ("lVigente <> 0");
                    dtGastServNego.DefaultView.RowFilter        = ("lVigente <> 0");
                    dtGastUniFam.DefaultView.RowFilter          = ("lVigente <> 0");
                    dtEstPerdGana.DefaultView.RowFilter         = ("lVigente <> 0");
                    dtDetalleFotos.DefaultView.RowFilter        = ("lVigente <> 0");
                    dtIntervinientes.DefaultView.RowFilter      = ("lVigente <> 0");

                    lstGarantias = ConvertToList(dtGarantias);

                    dtgDetEva.DataSource        = dtDetalle;
                    dtgCosteo.DataSource        = dtCosteoDetalle;
                    dtgDetCreNeg.DataSource     = dtDetCreNegocio;
                    dtgDetCreFam.DataSource     = dtDetCreUniFam;
                    dtgGasPersonal.DataSource   = dtDetGastosPersonal;
                    dtgGasNego.DataSource       = dtGastServNego;
                    dtgGasUniFam.DataSource     = dtGastUniFam;
                    dtgEstPerdGanan.DataSource  = dtEstPerdGana;
                    dtgDetalleFotos.DataSource  = dtDetalleFotos;
                    dtgIntervinientes.DataSource= dtIntervinientes;
                    dtgGarantias.DataSource     = lstGarantias;

                    if (dtDetalle.Rows.Count > 0)//EXISTEN VALORES YA GUARDADOS
                    {
                        dtgDetEva.ForeColor         = Color.Gray;
                        dtgCosteo.ForeColor         = Color.Gray;
                        dtgDetCreNeg.ForeColor      = Color.Gray;
                        dtgDetCreFam.ForeColor      = Color.Gray;
                        dtgGasPersonal.ForeColor    = Color.Gray;
                        dtgGasNego.ForeColor        = Color.Gray;
                        dtgGasUniFam.ForeColor      = Color.Gray;
                        conTLVBalance.ForeColor     = Color.Gray;
                        dtgEstPerdGanan.ForeColor   = Color.Gray;
                        dtgDetalleFotos.ForeColor   = Color.Gray;
                        dtgIntervinientes.ForeColor = Color.Gray;
                        dtgGarantias.ForeColor      = Color.Gray;
                    }
                    else
                    {
                        dtgDetEva.ForeColor = Color.Black;
                        dtgCosteo.ForeColor = Color.Black;
                        dtgDetCreNeg.ForeColor = Color.Black;
                        dtgDetCreFam.ForeColor = Color.Black;
                        dtgGasPersonal.ForeColor = Color.Black;
                        dtgGasNego.ForeColor = Color.Black;
                        dtgGasUniFam.ForeColor = Color.Black;
                        conTLVBalance.ForeColor = Color.Black;
                        dtgEstPerdGanan.ForeColor = Color.Black;
                        dtgDetalleFotos.ForeColor = Color.Black;
                        dtgIntervinientes.ForeColor = Color.Black;
                        dtgGarantias.ForeColor = Color.Black;
                    }

                    LlenarBalance();

                    AgregarComboBoxs();

                    ModificarIdEvalDatagrids();                    

                    FormatoGridDetalle();
                    VincEvaComponentes();
                    FormatoGridCosteo();
                    VincDetEvaComponentes();
                    FormatoGridDetalleCreditos();
                    FormatoGridDetGastPersonal();
                    FormatoGridDetGastos();
                    FormatoEstPerdGanan();
                    FormatoGridDetalleFotos();
                    FormatoGridIntervinientes();
                    FormatdtgGarantias();

                    TotalFinalDetalle();
                    TotalFinalCosteo();
                    TotalFinalCredNegocio();
                    TotalFinalCredFamliar();
                    TotalFinalGasPersonal();
                    TotalFinalGastNegocio();
                    TotalFinalGasUniFam();

                    Habilitar(3);

                    if (nOpcConsulta == 1)
                    {
                        btnEditar.Enabled = true;
                    }
                    else if (nOpcConsulta == 2)
                    {
                        btnEditar.Enabled   = false;
                        btnGrabar.Enabled   = false;
                        btnImprimir.Enabled = true;
                        btnImprimir1.Enabled = true;
                    }

                    txtTotVentas.TextChanged += new EventHandler(txtTotVentas_TextChanged);
                    txtMontProp.TextChanged += new EventHandler(txtMontProp_TextChanged);
                    txtCuotaAprox.TextChanged += new EventHandler(txtCuotaAprox_TextChanged);
                    txtNroCuotas.TextChanged += new EventHandler(txtNroCuotas_TextChanged);
                    txtTEM.TextChanged += new EventHandler(txtTEM_TextChanged);
                    txtTotMontCuotaNeg.TextChanged += new EventHandler(txtTotMontCuotaNeg_TextChanged);
                    txtTotMontCuotaFam.TextChanged += new EventHandler(txtTotMontCuotaFam_TextChanged);

                    //Cargar TipoCambio
                    CargarTipoCambio();
                    btnImprimir.Visible = true;
                    btnImprimir1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna evaluación con ese número", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumEva.Text = "";
                    btnImprimir.Visible = false;
                    btnImprimir1.Visible = false;
                }
            }
        }

        private void AnadirCamposCamposSumatoria()
        {  
            //CAMPO SUMATORIA
            DataRow fila = dtFlujoCajaIngreso.NewRow();
            fila["cDescr"] = "TOTAL INGRESOS (A)";
            fila["idFlujoCajaEvalEmp"] = 0;
            fila["IdParametrosFlujoCaja"] = 0;
            //Rellenar el Flujo Caja Ingresos
            for (int c = 3; c < dtFlujoCajaIngreso.Columns.Count; c++)//Por que la 1era: CONCEPTO y la 2da:IdParametrosFlujoCaja
            {
                //TOTAL INGRESOS (A)
                fila["nMes"+(c-2)] = Math.Round(    Convert.ToDecimal (dtFlujoCajaIngreso.Rows[0][c]) +
                                                    Convert.ToDecimal (dtFlujoCajaIngreso.Rows[1][c]) +
                                                    Convert.ToDecimal (dtFlujoCajaIngreso.Rows[2][c]), 0);
            }
            dtFlujoCajaIngreso.Rows.Add(fila);         

            DataTable dtFCEgresos = new DataTable("dtFlujoCajaEgreso");
            dtFCEgresos.Columns.Add("cDescr", typeof(string));
            dtFCEgresos.Columns.Add("idFlujoCajaEvalEmp", typeof(int));
            dtFCEgresos.Columns.Add("IdParametrosFlujoCaja", typeof(int));

            dtgIngresos.DataSource = dtFlujoCajaIngreso;
            
            //SUMATORIAS
            dtFlujoCajaEgreso.Rows.Add("TOTAL EGRESOS (B)",      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dtFlujoCajaEgreso.Rows.Add("SALDO MENSUAL (A-B)",    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dtFlujoCajaEgreso.Rows.Add("SALDO DE CAJA ANTERIOR", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            dtFlujoCajaEgreso.Rows.Add("SALDO FINAL DE CAJA (C)",0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

            //Rellenar el Flujo Caja Egresos
            for (int c = 3; c < dtFlujoCajaEgreso.Columns.Count; c++)
            {
                for (int f = 0; f < dtFlujoCajaEgreso.Rows.Count; f++)
                {                    
                    if (f == 7)//TOTAL EGRESOS (B)
                        dtFlujoCajaEgreso.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFlujoCajaEgreso.Rows[0][c]) + Convert.ToDecimal (dtFlujoCajaEgreso.Rows[1][c]) +
                                                                    Convert.ToDecimal(dtFlujoCajaEgreso.Rows[2][c]) + Convert.ToDecimal(dtFlujoCajaEgreso.Rows[3][c]) +
                                                                    Convert.ToDecimal(dtFlujoCajaEgreso.Rows[4][c]) + Convert.ToDecimal(dtFlujoCajaEgreso.Rows[5][c]) +
                                                                    Convert.ToDecimal(dtFlujoCajaEgreso.Rows[6][c]), 0);
                    if (f == 8)//AÑADIR FILA: SALDO MENSUAL (A-B)
                    {
                        dtFlujoCajaEgreso.Rows[f][c] = Math.Round((Convert.ToDecimal (dtgIngresos.Rows[3].Cells[c].Value) - Convert.ToDecimal (dtFlujoCajaEgreso.Rows[7][c])), 0);
                    }
                    if (f == 9)//SALDO DE CAJA ANTERIOR
                    {
                        if (c == 3)
                            dtFlujoCajaEgreso.Rows[f][c] = 0;
                        else
                            dtFlujoCajaEgreso.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFlujoCajaEgreso.Rows[10][c - 1]), 0);
                    }
                    if (f == 10)//SALDO FINAL DE CAJA (C)
                    {
                        dtFlujoCajaEgreso.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFlujoCajaEgreso.Rows[8][c]) + Convert.ToDecimal (dtFlujoCajaEgreso.Rows[9][c]), 0);
                    }
                }
            }
            dtgEgresos.DataSource = dtFlujoCajaEgreso;
        } 

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int CodigoCliente   = Convert.ToInt32(conBusCli.txtCodCli.Text);
            int IdEvalEmpr      = Convert.ToInt32(txtNumEva.Text);

            string cNomEmp      = clsVarApl.dicVarGen["cNomEmpresa"];
            String AgenEmision  = clsVarApl.dicVarGen["cNomAge"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            //paramlist.Clear();

            paramlist.Add(new ReportParameter("IdEvalEmpr", IdEvalEmpr.ToString(), false));
            paramlist.Add(new ReportParameter("pnidCli", CodigoCliente.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));

            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));            

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("DataSetCliente", new clsRPTCNClientes().CNRetornoCliente(CodigoCliente)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            dtslist.Add(new ReportDataSource("dtsFlujoCajaVariablesPorcentuales", new clsRPTCNCredito().CNFlujoCajaVariablesPorcentuales(IdEvalEmpr)));
            dtslist.Add(new ReportDataSource("dtsFlujoCajaIngresosEvalEmpresarial", new clsRPTCNCredito().CNFlujoCajaIngresoEvalEmpresarial(IdEvalEmpr)));
            dtslist.Add(new ReportDataSource("dtsFlujoCajaEgresosEvalEmpresarial", new clsRPTCNCredito().CNFlujoCajaEgresoEvalEmpresarial(IdEvalEmpr)));

            dtslist.Add(new ReportDataSource("dtsMesesGenerados", new clsRPTCNCredito().CNMesesGeneradosFlujoCaja(IdEvalEmpr)));

            dtslist.Add(new ReportDataSource("dtsBalancesGeneral1erCre", new clsRPTCNCredito().CNBalancesGeneral1erCre(CodigoCliente)));
            dtslist.Add(new ReportDataSource("dtsBalancesGeneralUltimoCre", new clsRPTCNCredito().CNBalancesGeneralUltimoCre(CodigoCliente)));
            dtslist.Add(new ReportDataSource("dtsBalancesGeneralActualEval", new clsRPTCNCredito().CNBalancesGeneralActualEval(IdEvalEmpr)));

            dtslist.Add(new ReportDataSource("dtsEstPerdidasGananc1erCreEvalEmpresarial", new clsRPTCNCredito().CNEstPerdidasGananc1erCreEvalEmpresarial(CodigoCliente)));
            dtslist.Add(new ReportDataSource("dtsEstPerdidasGanancUltimoCreEvalEmpresarial", new clsRPTCNCredito().CNEstPerdidasGanancUltimoCreEvalEmpresarial(CodigoCliente)));
            dtslist.Add(new ReportDataSource("dtsEstPerdidasGanancActualEvalEmpresarial", new clsRPTCNCredito().CNEstPerdidasGanancActualEvalEmpresarial(IdEvalEmpr)));

            string reportpath = "rptEvalEmpresarial.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }       

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            dtgIntervinientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            registrarRastreo(Convert.ToInt32(conBusCli.idCli),  0,  "Inicio - Registro de Evaluación Empresarial",  btnGrabar);
            ValidarDatos();
            if (!lFlagValidar) return;

            dtMaestro.Rows[0]["IdEvalEmp"]          = 0;
            dtMaestro.Rows[0]["nMonCapacidaPago"]   = Convert.ToDecimal(dtEstPerdGana.Rows[11]["nMontoParti"].ToString());

            CopiarBalanceDataTable();
            EditarDataTableEstPerdganan();
            dtGarantias = ConvertToDataTable<clsGarantia>(lstGarantias);
            
            //=======================================================================
            //--Crear los DataSet y agregar los Datatables para los xml
            //=======================================================================
            //Simular evento SelectionChanged -- para que no haya problemas de visibilidad al aplicar los 'AcceptChanges()' siguientes.
            if (dtgDetEva.Rows.Count > 0)
            {
                dtgDetEva.CurrentCell = null;
                dtgDetEva.CurrentCell = dtgDetEva[4, 0];//seleccionar la primera fila
                dtgDetEva.CurrentCell.Selected = true;
            }
            this.dtMaestro.AcceptChanges();
            this.dtDetalle.AcceptChanges();
            this.dtCosteoDetalle.AcceptChanges();
            this.dtDetCreNegocio.AcceptChanges();
            this.dtDetCreUniFam.AcceptChanges();
            this.dtDetGastosPersonal.AcceptChanges();
            this.dtGastServNego.AcceptChanges();
            this.dtGastUniFam.AcceptChanges();
            this.dtBalanceGeneral.AcceptChanges();
            this.dtEstPerdGana.AcceptChanges();
            this.dtDetalleFotos.AcceptChanges();
            this.dtIntervinientes.AcceptChanges();
            this.dtGarantias.AcceptChanges();

            DataTable dtEvaEmp = this.dtMaestro.Copy();
            DataTable dtDetEvaEmp = this.dtDetalle.Copy();
            DataTable dtCosteoEvaEmpr = this.dtCosteoDetalle.Copy();
            DataTable dtCredNeg = this.dtDetCreNegocio.Copy();
            DataTable dtCredUniFam = this.dtDetCreUniFam.Copy();
            DataTable dtGastPersonal = this.dtDetGastosPersonal.Copy();
            DataTable dtGastNeg = this.dtGastServNego.Copy();
            DataTable dtGastUniFam = this.dtGastUniFam.Copy();
            DataTable dtBalGeneral = this.dtBalanceGeneral.Copy();
            DataTable dtEstPerdGanan = this.dtEstPerdGana.Copy();
            DataTable dtDetFotos = this.dtDetalleFotos.Copy();
            DataTable dtDetInterv = this.dtIntervinientes.Copy();
            DataTable dtDetGarant = this.dtGarantias.Copy();

            DataSet dsComprPago = new DataSet("dsEvaEmpr");
            DataSet dsDetComprPago = new DataSet("dsDetEvaEmpr");
            DataSet dsCosteoEvaEmpr = new DataSet("dsCosteoEvaEmpr");
            DataSet dsCredNeg = new DataSet("dsCredNeg");
            DataSet dsCredUniFam = new DataSet("dsCredUniFam");
            DataSet dsGastPersonal = new DataSet("dsGastPersonal");
            DataSet dsGastNeg = new DataSet("dsGastNeg");
            DataSet dsGastUniFam = new DataSet("dsGastUniFam");
            DataSet dsBalGeneral = new DataSet("dsBalGeneral");
            DataSet dsEstPerdGanan = new DataSet("dsEstPerdGanan");
            DataSet dsDetFotos = new DataSet("dsDetFotos");
            DataSet dsDetInterv = new DataSet("dsDetInterv");
            DataSet dsDetGarant = new DataSet("dsDetGarant");

            dtEvaEmp.TableName = "dtEvaEmpr";
            dtDetEvaEmp.TableName = "dtDetEvaEmpr";
            dtCosteoEvaEmpr.TableName = "dtCosteoEvaEmpr";
            dtCredNeg.TableName = "dtCredNeg";
            dtCredUniFam.TableName = "dtCredUniFam";
            dtGastPersonal.TableName = "dtGastPersonal";
            dtGastNeg.TableName = "dtGastNeg";
            dtGastUniFam.TableName = "dtGastUniFam";
            dtBalGeneral.TableName = "dtBalGeneral";
            dtEstPerdGanan.TableName = "dtEstPerdGanan";
            dtDetFotos.TableName = "dtDetFotos";
            dtDetInterv.TableName = "dtDetInterv";
            dtDetGarant.TableName = "dtDetGarant";

            dsComprPago.Tables.Add(dtEvaEmp);
            dsDetComprPago.Tables.Add(dtDetEvaEmp);
            dsCosteoEvaEmpr.Tables.Add(dtCosteoEvaEmpr);
            dsCredNeg.Tables.Add(dtCredNeg);
            dsCredUniFam.Tables.Add(dtCredUniFam);
            dsGastPersonal.Tables.Add(dtGastPersonal);
            dsGastNeg.Tables.Add(dtGastNeg);
            dsGastUniFam.Tables.Add(dtGastUniFam);
            dsBalGeneral.Tables.Add(dtBalGeneral);
            dsEstPerdGanan.Tables.Add(dtEstPerdGanan);
            dsDetFotos.Tables.Add(dtDetFotos);
            dsDetInterv.Tables.Add(dtDetInterv);
            dsDetGarant.Tables.Add(dtDetGarant);

            string xmlEvaEmpr = clsCNFormatoXML.EncodingXML(dsComprPago.GetXml());
            string xmlDetEvaEmpr = clsCNFormatoXML.EncodingXML(dsDetComprPago.GetXml());
            string xmlCosteoEvaEmpr = clsCNFormatoXML.EncodingXML(dsCosteoEvaEmpr.GetXml());
            string xmlCredNeg = clsCNFormatoXML.EncodingXML(dsCredNeg.GetXml());
            string xmlCredUniFam = clsCNFormatoXML.EncodingXML(dsCredUniFam.GetXml());
            string xmlGastPersonal = clsCNFormatoXML.EncodingXML(dsGastPersonal.GetXml());
            string xmlGastNeg = clsCNFormatoXML.EncodingXML(dsGastNeg.GetXml());
            string xmlGastUniFam = clsCNFormatoXML.EncodingXML(dsGastUniFam.GetXml());
            string xmlBalGeneral = clsCNFormatoXML.EncodingXML(dsBalGeneral.GetXml());
            string xmlEstPerdGanan = clsCNFormatoXML.EncodingXML(dsEstPerdGanan.GetXml());
            string xmlDetFotos = clsCNFormatoXML.EncodingXML(dsDetFotos.GetXml());
            string xmlDetInterv = clsCNFormatoXML.EncodingXML(dsDetInterv.GetXml());
            string xmlDetGarant = clsCNFormatoXML.EncodingXML(dsDetGarant.GetXml());

            dsComprPago.Tables.Clear();
            dsDetComprPago.Tables.Clear();
            dsCosteoEvaEmpr.Tables.Clear();
            dsCredNeg.Tables.Clear();
            dsCredUniFam.Tables.Clear();
            dsGastPersonal.Tables.Clear();
            dsGastNeg.Tables.Clear();
            dsGastUniFam.Tables.Clear();
            dsBalGeneral.Tables.Clear();
            dsEstPerdGanan.Tables.Clear();
            dsDetFotos.Tables.Clear();
            dsDetInterv.Tables.Clear();
            dsDetGarant.Tables.Clear();

            //============================ Variación de Ingresos x Mes ============================================>
            DataTable dtPorcentVariablesFlujoCaja = new DataTable("dtPorcentVariablesFlujoCaja");
            dtPorcentVariablesFlujoCaja.Columns.Add("IdEvalEmp",typeof(int));
            dtPorcentVariablesFlujoCaja.Columns.Add("IdPorcentVariablesFlujoCaja",typeof(int));
            dtPorcentVariablesFlujoCaja.Columns.Add("idTipoCicloNegocio",typeof(int));
            dtPorcentVariablesFlujoCaja.Columns.Add("dMes",typeof(DateTime));
            dtPorcentVariablesFlujoCaja.Columns.Add("nPorcentVarIngreso",typeof(Decimal));
            dtPorcentVariablesFlujoCaja.Columns.Add("lVigente",typeof(bool));
            
            //1:BAJA 2:MEDIA 3:ALTA
            DateTime dAuxFechaDesembolso = dtpFechaDesembolso.Value;
            for (int c = 3; c < dtVariables.Columns.Count; c++)
            {
                int nMes = dAuxFechaDesembolso.Month;

                DataRow dr = dtPorcentVariablesFlujoCaja.NewRow();
                dr["IdEvalEmp"] = 0;
                dr["IdPorcentVariablesFlujoCaja"] = 0;

                if (Convert.ToBoolean(dtComportamientos.Rows[0][nMes-1]))
                    dr["idTipoCicloNegocio"] = 3;
                if (Convert.ToBoolean(dtComportamientos.Rows[1][nMes - 1]))
                    dr["idTipoCicloNegocio"] = 2;
                if (Convert.ToBoolean(dtComportamientos.Rows[2][nMes - 1]))
                    dr["idTipoCicloNegocio"] = 1;               

                dr["dMes"] = dAuxFechaDesembolso;
                dr["nPorcentVarIngreso"] = Convert.ToDecimal (dtVariables.Rows[0][c]);//Valores porcentuales
                dr["lVigente"] = 1;
                dtPorcentVariablesFlujoCaja.Rows.Add(dr);

                dAuxFechaDesembolso = dAuxFechaDesembolso.AddMonths(1);
            }

            DataSet dsPorcentVariablesFlujoCaja     = new DataSet("dsPorcentVariablesFlujoCaja");
            dtPorcentVariablesFlujoCaja.TableName   = "dtPorcentVariablesFlujoCaja";
            dsPorcentVariablesFlujoCaja.Tables.Add(dtPorcentVariablesFlujoCaja);

            string xmlPorcentVariacionFlujoCaja= clsCNFormatoXML.EncodingXML(dsPorcentVariablesFlujoCaja.GetXml());
            //=====================================================================================================>

            //========================================= Flujo de Caja  =============================================>
            DataTable dtFlujoCaja = new DataTable("dtFlujoCaja");
            dtFlujoCaja.Columns.Add("idFlujoCajaEvalEmp", typeof(int));
            dtFlujoCaja.Columns.Add("IdParametrosFlujoCaja", typeof(int));
            dtFlujoCaja.Columns.Add("dMesInicio", typeof(DateTime));

            for (int c = 1; c <= 12; c++)
                dtFlujoCaja.Columns.Add("nMes" + c, typeof(Decimal));

            //INGRESOS
            for (int f = 0; f < dtFlujoCajaIngreso.Rows.Count-1; f++)
            {
                DataRow fila    = dtFlujoCaja.NewRow();
                fila["idFlujoCajaEvalEmp"]      = 0;//dtFlujoCajaIngreso.Rows[f]["idFlujoCajaEvalEmp"];
                fila["IdParametrosFlujoCaja"]   = dtFlujoCajaIngreso.Rows[f]["IdParametrosFlujoCaja"];
                fila["dMesInicio"] = dtpFechaDesembolso.Value;
                fila["nMes1"]   = dtFlujoCajaIngreso.Rows[f]["nMes1"];
                fila["nMes2"]   = dtFlujoCajaIngreso.Rows[f]["nMes2"];
                fila["nMes3"]   = dtFlujoCajaIngreso.Rows[f]["nMes3"];
                fila["nMes4"]   = dtFlujoCajaIngreso.Rows[f]["nMes4"];
                fila["nMes5"]   = dtFlujoCajaIngreso.Rows[f]["nMes5"];
                fila["nMes6"]   = dtFlujoCajaIngreso.Rows[f]["nMes6"];
                fila["nMes7"]   = dtFlujoCajaIngreso.Rows[f]["nMes7"];
                fila["nMes8"]   = dtFlujoCajaIngreso.Rows[f]["nMes8"];
                fila["nMes9"]   = dtFlujoCajaIngreso.Rows[f]["nMes9"];
                fila["nMes10"]  = dtFlujoCajaIngreso.Rows[f]["nMes10"];
                fila["nMes11"]  = dtFlujoCajaIngreso.Rows[f]["nMes11"];
                fila["nMes12"]  = dtFlujoCajaIngreso.Rows[f]["nMes12"];
                dtFlujoCaja.Rows.Add(fila);
            }

            //EGRESOS
            for (int f = 0; f < dtFlujoCajaEgreso.Rows.Count-4; f++)
            {
                DataRow fila    = dtFlujoCaja.NewRow();
                fila["idFlujoCajaEvalEmp"]      = 0;//dtFlujoCajaEgreso.Rows[f]["idFlujoCajaEvalEmp"];
                fila["IdParametrosFlujoCaja"]   = dtFlujoCajaEgreso.Rows[f]["IdParametrosFlujoCaja"];
                fila["dMesInicio"] = dtpFechaDesembolso.Value;
                fila["nMes1"]   = dtFlujoCajaEgreso.Rows[f]["nMes1"];
                fila["nMes2"]   = dtFlujoCajaEgreso.Rows[f]["nMes2"];
                fila["nMes3"]   = dtFlujoCajaEgreso.Rows[f]["nMes3"];
                fila["nMes4"]   = dtFlujoCajaEgreso.Rows[f]["nMes4"];
                fila["nMes5"]   = dtFlujoCajaEgreso.Rows[f]["nMes5"];
                fila["nMes6"]   = dtFlujoCajaEgreso.Rows[f]["nMes6"];
                fila["nMes7"]   = dtFlujoCajaEgreso.Rows[f]["nMes7"];
                fila["nMes8"]   = dtFlujoCajaEgreso.Rows[f]["nMes8"];
                fila["nMes9"]   = dtFlujoCajaEgreso.Rows[f]["nMes9"];
                fila["nMes10"]  = dtFlujoCajaEgreso.Rows[f]["nMes10"];
                fila["nMes11"]  = dtFlujoCajaEgreso.Rows[f]["nMes11"];
                fila["nMes12"]  = dtFlujoCajaEgreso.Rows[f]["nMes12"];
                dtFlujoCaja.Rows.Add(fila);
            }

            DataSet dsFlujoCaja     = new DataSet("dsFlujoCaja");
            dtFlujoCaja.TableName   = "dtFlujoCaja";
            dsFlujoCaja.Tables.Add(dtFlujoCaja);
            string xmlFlujoCaja     = clsCNFormatoXML.EncodingXML(dsFlujoCaja.GetXml());
            //=====================================================================================================>

            DataTable result = EvalEmp.CNdtRegEvalEmpr( xmlEvaEmpr, xmlDetEvaEmpr, xmlCosteoEvaEmpr, xmlCredNeg,
                                                        xmlCredUniFam, xmlGastPersonal, xmlGastNeg, xmlGastUniFam,
                                                        xmlBalGeneral, xmlEstPerdGanan, xmlDetFotos,xmlDetInterv,
                                                        xmlDetGarant,
                                                        xmlPorcentVariacionFlujoCaja, xmlFlujoCaja, idNumEva);

            if (result.Rows[0]["idMsje"].ToString().Equals("0"))
            {
                this.txtNumEva.Text = result.Rows[0]["idEvaEmpr"].ToString();
                MessageBox.Show("Evaluación N° " + result.Rows[0]["idEvaEmpr"].ToString() + " Registrada Correctamente", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Habilitar(3);
                btnImprimir.Enabled = true;
                btnImprimir1.Enabled = true;
                ActNomRutFotos();
                lFlagGuardado = true;
                {
                    dtgDetEva.ForeColor         = Color.Gray;
                    dtgCosteo.ForeColor         = Color.Gray;
                    dtgDetCreNeg.ForeColor      = Color.Gray;
                    dtgDetCreFam.ForeColor      = Color.Gray;
                    dtgGasPersonal.ForeColor    = Color.Gray;
                    dtgGasNego.ForeColor        = Color.Gray;
                    dtgGasUniFam.ForeColor      = Color.Gray;
                    conTLVBalance.ForeColor     = Color.Gray;
                    dtgEstPerdGanan.ForeColor   = Color.Gray;
                    dtgDetalleFotos.ForeColor   = Color.Gray;
                    dtgIntervinientes.ForeColor = Color.Gray;
                    dtgGarantias.ForeColor      = Color.Gray;
                }
                idNumEva = Convert.ToInt32(result.Rows[0]["idEvaEmpr"]);
                btnImprimir.Visible = true;
                btnImprimir.Enabled = true;
                btnImprimir1.Visible = true;
                btnImprimir1.Enabled = true;
                guardarDatosPropuesta(Convert.ToInt32(dtSolicitudCreEmpresarial.Rows[0]["idSolicitud"]));

            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Congelar el grid
            dtgDetEva.Enabled = false;
            this.registrarRastreo(Convert.ToInt32(conBusCli.idCli), 0, "Fin - Registro de Evaluación Empresarial", btnGrabar);
        }        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            {
                dtgDetEva.ForeColor = Color.Black;
                dtgCosteo.ForeColor = Color.Black;
                dtgDetCreNeg.ForeColor = Color.Black;
                dtgDetCreFam.ForeColor = Color.Black;
                dtgGasPersonal.ForeColor = Color.Black;
                dtgGasNego.ForeColor = Color.Black;
                dtgGasUniFam.ForeColor = Color.Black;
                conTLVBalance.ForeColor = Color.Black;
                dtgEstPerdGanan.ForeColor = Color.Black;
                dtgDetalleFotos.ForeColor = Color.Black;
                dtgIntervinientes.ForeColor = Color.Black;
                dtgGarantias.ForeColor = Color.Black;
            }

            Habilitar(4);
            btnConsultar.Enabled = false;
            dtgDetEva.Enabled = true;
            dtgGarantias.Enabled = true;
            FormatoGridDetalle();
            FormatoGridCosteo();
            FormatoGridDetalleCreditos();
            FormatoGridDetGastPersonal();
            FormatoGridDetGastos();
            FormatoEstPerdGanan();
            FormatoGridDetalleFotos();
            FormatoGridIntervinientes();
            DarFormatoGridEgresos();
            DarFormatogridIngresos();
            cRutaFotos = clsVarApl.dicVarGen["cUrlFotosEvaEmp"] + @"\EvaEmp_" + Convert.ToInt32(this.conBusCli.txtCodCli.Text) + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            if (!System.IO.Directory.Exists(cRutaFotos))
            {
                System.IO.Directory.CreateDirectory(cRutaFotos);
            }
            //Copia un temporal de la carpeta de fotos reiniciando el nombre de los archivos desde 0
            string[] filePaths = new string[20];
            int i = 0;

            foreach (DataRow row in this.dtDetalleFotos.Rows)
            {
                //Actualizar nombre de archivos al copiar
                File.Copy(row["cRutaFoto"].ToString(), cRutaFotos + @"\Foto_" + i + ".Jpg");

                //Actualizar nombre de direccion de archivos
                string cNomFoto = row["cRutaFoto"].ToString().Substring(row["cRutaFoto"].ToString().Length - 13, 13);
                while (cNomFoto.Substring(0, 1) != "F")
                {
                    cNomFoto = cNomFoto.Substring(1, cNomFoto.Length - 1);
                }
                row["cRutaFoto"] = clsVarApl.dicVarGen["cUrlFotosEvaEmp"] + @"\EvaEmp_" + Convert.ToInt32(this.conBusCli.txtCodCli.Text) + "_" + row["IdEvalEmp"].ToString() + @"\" + cNomFoto.Replace(cNomFoto, "Foto_" + i + ".Jpg");

                i++;
            }
            nNroFoto = i;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //---------- Flujo de Caja ------------------------------------------------------------------->
            dtComportamientos   = null;
            dtTipoCambio        = null;
            dtFlujoCajaIngreso  = null;
            dtFlujoCajaEgreso   = null;
            dtVariables         = null;

            dtgComportamiento.DataSource = dtComportamientos;
            dtgTipoCambio.DataSource = dtTipoCambio;
                   
            //Para evitar la actualización de campos en el Grid(Ya no es necesari0)     
            dtgEgresos.CellLeave    -= new DataGridViewCellEventHandler(dtgEgresos_CellLeave);
            dtgVariables.CellLeave  -= new DataGridViewCellEventHandler(dtgVariables_CellLeave); 

            dtgEgresos.DataSource = dtFlujoCajaEgreso;            
            dtgIngresos.DataSource = dtFlujoCajaIngreso; 
           
            dtgVariables.DataSource = dtVariables;

            //Añadir los eventos para la próxima evaluación
            dtgEgresos.CellLeave    += new DataGridViewCellEventHandler(dtgEgresos_CellLeave);
            dtgVariables.CellLeave  += new DataGridViewCellEventHandler(dtgVariables_CellLeave);
            //-------------------------------------------------------------------------------------------->

            DesvincEvaComponentes();
            DesvincDetEvaComponentes();
            dtDetCreNegocio = null;
            dtDetCreUniFam = null;
            dtDetGastosPersonal = null;
            dtGastServNego = null;
            dtGastUniFam = null;
            dtBalanceGeneral = null;
            dtEstPerdGana = null;
            dtDetalleFotos = null;
            dtIntervinientes = null;
            dtgDetEva.DataSource = null;
            dtgCosteo.DataSource = null;
            dtgDetCreNeg.DataSource = null;
            dtgDetCreFam.DataSource = null;
            dtgGasPersonal.DataSource = null;
            dtgGasNego.DataSource = null;
            dtgGasUniFam.DataSource = null;
            dtgEstPerdGanan.DataSource = null;
            dtgDetalleFotos.DataSource = null;
            dtgIntervinientes.DataSource = null;
            dtgGarantias.DataSource = null;

            conBusCli.Enabled = true;
            conBusCli.txtCodCli.Enabled = true;
            btnAgrInterv.Enabled = false;
            btnQuitInterv.Enabled = false;
            dtgIntervinientes.ReadOnly = true;
            txtNumEva.Enabled = false;
            btnCancelar.Enabled = true;
            btnImprimir.Enabled = false;
            btnImprimir1.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btn_Vincular.Enabled = false;
            btnGrabar.Enabled = false;
            dtpFecReg.Enabled = false;
            dtpFecVig.Enabled = false;
            dtpFecTomInv.Enabled = false;
            dtgDetEva.ReadOnly = true;
            btnAgrDetEva.Enabled = false;
            btnQuitDetEva.Enabled = false;
            cboFrecPagEva.Enabled = false;
            txtDeuSistFin.Enabled = false;
            dtgCosteo.Enabled = false;
            btnAgrItemCosteo.Enabled = false;
            btnQuitItemCosteo.Enabled = false;
            txtUnidProd.Enabled = false;
            dtgDetCreNeg.ReadOnly = true;
            btnAgrDetCredNeg.Enabled = false;
            btnQuitDetCredNeg.Enabled = false;
            dtgDetCreFam.ReadOnly = true;
            btnAgrDetCredFam.Enabled = false;
            btnQuitDetCredFam.Enabled = false;
            dtgGasPersonal.ReadOnly = true;
            btnAgrGastPers.Enabled = false;
            btnQuitGastPers.Enabled = false;
            dtgGasNego.ReadOnly = true;
            btnAgrGastServNeg.Enabled = false;
            btnQuitGastServNeg.Enabled = false;
            dtgGasUniFam.ReadOnly = true;
            btnAgrGastUniFam.Enabled = false;
            btnQuitGastUniFam.Enabled = false;
            dtgEstPerdGanan.ReadOnly = true;
            btnAgrGarant.Enabled = false;
            btnQuitGarant.Enabled = false;
            dtgGarantias.ReadOnly = true;
            txtComRatLiq.Text = "";
            txtComRatApalFin.Text = "";
            txtComRatRentAct.Text = "";
            txtComRatRotCapTrbjo.Text = "";
            txtComRatRotInv.Text = "";
            txtComRatSolv.Text = "";
            txtComRds.Text = "";
            txtComCentralRsgo.Text = "";
            txtComConting.Text = "";
            txtComDebilid.Text = "";
            txtComFortalezas.Text = "";
            txtComMesBue.Text = "";
            txtComMesMal.Text = "";
            txtComPoliticaFin.Text = "";
            txtComPosInterv.Text = "";
            txtComProveed.Text = "";
            txtRatApalFin.Text = "";
            txtRatLiquidez.Text = "";
            txtRatRentActivo.Text = "";
            txtRatRotCapTrab.Text = "";
            txtRatRotInv.Text = "";
            txtRatSolvencia.Text = "";
            grbComentarios.Text = "";
            conBusCli.txtCodCli.Text = "";
            conBusCli.txtNroDoc.Text = "";
            conBusCli.txtNombre.Text = "";
            conBusCli.txtCodAge.Text = "";
            conBusCli.txtCodInst.Text = "";
            txtNumEva.Text = "";
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.btnBusCliente.Enabled = true;
            txtTotCostoCompra.Text = "";
            txtTotCostProd.Text = "";
            txtTotGastosFam.Text = "";
            txtTotGastosNeg.Text = "";
            txtTotVentas.Text = "";
            txtTotIngresos.Text = "";
            txtMargenUtiTot.Text = "";
            txtTotPorParti.Text = "";
            txtTotMercaderia.Text = "";
            txtUnidProd.Text = "";
            txtTotStock.Text = "";
            txtCostUnit.Text = "";
            txtTotInv.Text = "";
            txtTotMontCuotaFam.Text = "";
            txtTotMontCuotaNeg.Text = "";
            txtTotPuesto.Text = "";
            txtTotSalCredFam.Text = "";
            txtTotSalCredNego.Text = "";
            txtDeuSistFin.Text = "";
            txtTipoCambio.Text = "0.00";
            cboMoneda.SelectedIndex = -1;
            cboTipoUsoLocal.SelectedIndex = -1;
            txtTiempoUsoLocal.Text = "";
            cboUniTiempoUsoLoc.SelectedIndex = -1;
            txtTiempoExp.Text = "0";
            cboUniTiempoExp.SelectedIndex = -1;
            txtHorasAtenc.Text = "0";
            txtHorasDedic.Text = "0";
            txtNroDepend.Text = "0";
            txtNroColab.Text = "0";
            txtMontProp.Text = "0.00";
            txtNroCuotas.Text = "0";
            txtTEM.Text = "0.0000";
            txtCuotaAprox.Text = "0.00";
            txtCoberCuota.Text = "0.00";
            pbFotos.Image = null;

            lblCoberCuota.Visible = true;
            lblMontCuota.Visible = true;
            txtCoberCuota.Visible = true;
            txtCuotaAprox.Visible = true;

            if (dtgEstPerdGanan.RowCount>0)
            {
                dtgEstPerdGanan.Rows[10].Visible = true;
                dtgEstPerdGanan.Rows[11].Visible = true;
            }

            conTLVBalance.cargarPlantilla(1);
            dtEstPerdGana = EvalEmp.CNdtEstPerGanan(0);
            dtgEstPerdGanan.DataSource = dtEstPerdGana;
            FormatoEstPerdGanan();

            Habilitar(1);
            if (!lFlagGuardado)
            {
                ElimFotosNoGuardadas();
            }
            lFlagGuardado = false;
            cRutaFotos = "";
            nNroFoto = 0;

            {
                dtgDetEva.ForeColor = Color.Black;
                dtgCosteo.ForeColor = Color.Black;
                dtgDetCreNeg.ForeColor = Color.Black;
                dtgDetCreFam.ForeColor = Color.Black;
                dtgGasPersonal.ForeColor = Color.Black;
                dtgGasNego.ForeColor = Color.Black;
                dtgGasUniFam.ForeColor = Color.Black;
                conTLVBalance.ForeColor = Color.Black;
                dtgEstPerdGanan.ForeColor = Color.Black;
                dtgDetalleFotos.ForeColor = Color.Black;
                dtgIntervinientes.ForeColor = Color.Black;
                dtgGarantias.ForeColor = Color.Black;
            }

            //============= Limpiar Datos de la solicitud de Crédito ==================>
            txtMonSolicitado.Clear();
            txtMonedaCreSol.Clear();
            txtTipoCredito.Clear();
            txtProducto.Clear();
            txtGarantia.Clear();
            txtNumCuotas.Clear();
            txtFrecuencia.Clear();
            txtTasaInteres.Clear();
            txtActividad.Clear();
            txtDestino.Clear();
            txtTipoPeriodo.Clear();
            txtDiaGracia.Clear();

            txtMontProp.Clear();
            txtTEM.Clear();
            txtNroCuotas.Clear();
            txtCuotaAprox.Clear(); 
            //=========================================================================>

            btnConsultar.Enabled = true;

            tbcGeneral.SelectedIndex = 0;
            conBusCli.txtCodCli.Focus();
        }

        private void btn_Vincular_Click(object sender, EventArgs e)
        {
            if (dtMaestro.Rows[0]["IdSolicitud"]!=DBNull.Value)
            {
                MessageBox.Show("La evaluación ya se encuentra vinculada, No puede volver a Vincularla", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btn_Vincular.Enabled = false;
                return;
            }

            Int32 nIdCliente    = Convert.ToInt32(this.conBusCli.txtCodCli.Text);
            Int32 nIdEval       = idNumEva;
            dtSolicitud         = Solicitud.CNdtLisSolEstSol(nIdCliente);
            dtSolicitud.DefaultView.RowFilter = ("nTipCre in (2,10,11,12,13)");
            if (dtSolicitud.Rows.Count > 0)
            {
                for (int i = 0; i < dtSolicitud.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtSolicitud.Rows[i]["nTipCre"]) == 2    || Convert.ToInt32(dtSolicitud.Rows[i]["nTipCre"]) == 10 ||
                        Convert.ToInt32(dtSolicitud.Rows[i]["nTipCre"]) == 11   || Convert.ToInt32(dtSolicitud.Rows[i]["nTipCre"]) == 12 ||
                        Convert.ToInt32(dtSolicitud.Rows[i]["nTipCre"]) == 13)
                    {
                        frmBusSolCre frmBusSolCre1  = new frmBusSolCre();
                        frmBusSolCre1.nFormCall     = 2;
                        frmBusSolCre1.cargadatos(nIdCliente, nIdEval);
                        frmBusSolCre1.ShowDialog();
                        btn_Vincular.Enabled        = false;
                    }
                    else
                    {
                        MessageBox.Show("No tiene solicitud de credito EMPRESARIAL pendiente para VINCULAR", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existe Solicitud Credito para Vincular", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            nOpcConsulta        = 2;
            txtNumEva.Enabled   = true;
            conBusCli.Enabled   = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled    = false;
            txtNumEva.Focus();
        }

        private void txtTotCostProd_TextChanged(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentRow != null)
            {
                if (!string.IsNullOrEmpty(txtTotCostProd.Text))
                {
                    dtgDetEva.CurrentRow.Cells["nSubTotCosProdu"].Value = Convert.ToDecimal(txtTotCostProd.Text);
                }
            }   
            if (dtgDetEva.SelectedCells.Count > 0)
                dtgDetEva.Rows[dtgDetEva.SelectedCells[0].RowIndex].Cells["nSubTotCosProdu"].Value = txtTotCostProd.Text;
        }
        
        private void txtTotInv_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotInv.Text))
                ActualizarBalance();
        }

        private void txtTotMercaderia_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotMercaderia.Text))
                ActualizarBalance();
        }     
        
        private void txtTotSalCredNego_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotSalCredNego.Text))
            {
                ActualizarBalance();
                ActualizarEstPerdGanan();
                ActualizaFlujoCajaPrimerPeriodo();
            }
        }

        private void txtTotPuesto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotPuesto.Text))
            {
                ActualizarEstPerdGanan();
                //Actualizar Flujo Caja
                ActualizaFlujoCajaPrimerPeriodo();
            }
        }

        private void txtTotGastosNeg_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotGastosNeg.Text))
            {
                ActualizarEstPerdGanan();
                //Actualizar Flujo Caja
                ActualizaFlujoCajaPrimerPeriodo();
            }
        }

        private void txtTotGastosFam_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotGastosFam.Text))
            {
                ActualizarEstPerdGanan();
                //Actualizar Flujo Caja
                ActualizaFlujoCajaPrimerPeriodo();
            }
        }

        private void txtTotSalCredFam_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotSalCredFam.Text))
                ActualizarEstPerdGanan();
        }

        private void txtCostUnit_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCostUnit.Text))
                return;
            if (dtgDetEva.Rows.Count > 0 && dtgDetEva.SelectedCells.Count > 0)
            {
                if (Convert.ToInt32(dtgDetEva.Rows[dtgDetEva.SelectedCells[0].RowIndex].Cells["IdTipoGiroNego"].Value) == 1)
                    return;
            }
            decimal nCostUnit = Convert.ToDecimal(txtCostUnit.Text);
            txtCostUnit.Text = nCostUnit.ToString("##,##0.00");
            if (dtgDetEva.SelectedCells.Count > 0)
                dtgDetEva.Rows[dtgDetEva.SelectedCells[0].RowIndex].Cells["nPreUniCompra_Prod"].Value = txtCostUnit.Text;
        }

        private void txtDeuSistFin_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtDeuSistFin.Text) > Decimal.MaxValue)
            {
                MessageBox.Show("El número es muy grande, ingrese otro valor.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeuSistFin.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(txtDeuSistFin.Text))
                return;
            decimal nDeuda = Convert.ToDecimal(txtDeuSistFin.Text);
            txtDeuSistFin.Text = nDeuda.ToString("##,##0.00");
        }

        private void txtUnidProd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnidProd.Text))
            {
                MessageBox.Show("Para los de giros de Negocio tipo: SERVICIO ó PRODUCCIÓN debe ingresar la cantidad de unidades a ser costeadas.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnidProd.Text = "";
                return;
            }
            if (!string.IsNullOrEmpty(txtUnidProd.Text))
            {
                if (Convert.ToInt64(txtUnidProd.Text)<=0)
                {
                    MessageBox.Show("Para los de giros de Negocio tipo: SERVICIO ó PRODUCCIÓN debe ingresar la cantidad de unidades a ser costeadas.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnidProd.Text = "";
                    return;
                }
                if (Convert.ToInt64(txtUnidProd.Text) > Int32.MaxValue)
                {
                    MessageBox.Show("El numero es muy grande, Ingrese otro valor.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnidProd.Text = "";
                    return;
                }
            }
            CalcularCostoUnit();
            if (dtgDetEva.SelectedCells.Count > 0)
                dtgDetEva.Rows[dtgDetEva.SelectedCells[0].RowIndex].Cells["nUniCosteadas"].Value = txtUnidProd.Text;
        }

        private void txtMontProp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontProp.Text))
                return;
            decimal nMonto = Convert.ToDecimal(txtMontProp.Text);
            txtMontProp.Text = nMonto.ToString("##,##0.00");
            CalcularCuotaAprox();
            CalcularRatios();
        }

        private void txtNroCuotas_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAprox();
        }

        private void txtTEM_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAprox();
        }

        private void dtpFechaDesembolso_ValueChanged(object sender, EventArgs e)
        {
            CalcularCuotaAprox();
            DarFormatogridIngresos();
        }

        private void cboMoneda_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cboMoneda.SelectedIndex == -1) return;
            TotalFinalDetalle();
            TotalFinalCosteo();
        }       

        #endregion

        #region DtgDetalle

        private void btnAgrDetEva_Click(object sender, EventArgs e)
        {
            if (dtgDetEva.RowCount > 0)
            {
                if (dtgDetEva.Rows[dtgDetEva.RowCount - 1].Cells["IdTipoGiroNego"].Value != DBNull.Value)
                {
                    int idTipoGiroNeg = Convert.ToInt32(dtgDetEva.Rows[dtgDetEva.RowCount - 1].Cells["IdTipoGiroNego"].Value);

                    if ((idTipoGiroNeg == 2 && dtgCosteo.RowCount == 0) || (idTipoGiroNeg == 3 && dtgCosteo.RowCount == 0))
                    {
                        MessageBox.Show("No puede agregar mas actividades si no ingresa el costeo de esta actividad.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUnidProd.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el tipo de actividad.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtgDetEva.Rows[dtgDetEva.RowCount - 1].Cells["IdMoneda"].Value == DBNull.Value)
                {
                    MessageBox.Show("Seleccione la moneda de este tipo de actividad.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataRow dr = dtDetalle.NewRow();
            dr["IdInterno"] = ++IdInterno;
            dr["IdDetalleEvaEmp"] = -1;
            dr["IdTipoGiroNego"] = 1;
            dr["IdTipoIng"] = 1;
            dr["IdMoneda"] = 1;
            dr["cDescriProdSer"] = "";
            dr["nNumDiaBue_Est"] = 0;
            dr["nNumDiaMalos"] = 0;
            dr["nCantiVenDiaBue_Est"] = 0;
            dr["nCantiVenDiaMalos"] = 0;
            dr["IdUnidadMedida"] = 1;
            dr["nNumRepitexFrec"] = 0;
            dr["nPreUniCompra_Prod"] = 0;
            dr["nCantiProduTerm"] = 0;
            dr["nPrecioVenta"] = 0.00;
            dr["nSubTotCostoCompra_Prod"] = 0.00;
            dr["nSubTotVentas"] = 0.00;
            dr["nSubTotIngresos"] = 0.00;
            dr["nMargenUtiProdSer"] = 0.00;
            dr["nPorcenPartiProdSer"] = 0.00;
            dr["nSubTotMercaderia"] = 0.00;
            dr["nSubTotMatPrimaIns"] = 0.00;
            dr["nUniCosteadas"] = 0.00;
            dr["lVigente"] = 1;
            dtDetalle.Rows.Add(dr);

            var dtDetalleCosteoNuevo = dtCosteoDetalle.Clone();
            frmDetIngEvaEmp frmdetingreso = new frmDetIngEvaEmp(dr, dtDetalleCosteoNuevo, dtMaestro, Transaccion.Nuevo);
            frmdetingreso.ShowDialog();

            foreach (DataRow item in dtDetalleCosteoNuevo.Rows)
            {
                dtCosteoDetalle.ImportRow(item);
            }
            dtgCosteo.DataSource = dtCosteoDetalle;
            
            dtDetalle.AcceptChanges();
            this.dtgDetEva.Refresh();
            TotalFinalDetalle();
            ActualizarBalance();
        }

        private void btnQuitDetEva_Click(object sender, EventArgs e)
        {
            if (this.dtgDetEva.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //===========================================
                // Limpiar el detalle de Costos de Producción
                //===========================================
                int nCantFilasDetalle = dtgCosteo.Rows.Count;
                if (nCantFilasDetalle > 0)
                {
                    for (int i = nCantFilasDetalle - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(dtgCosteo.Rows[i].Cells["IdDetalleEvaEmp"].Value) == -1)
                        { dtgCosteo.Rows.RemoveAt(i); }
                        else
                            dtgCosteo.Rows[i].Cells["lVigente"].Value = 0;
                    }
                }

                QuitarDetalleCostosProduccion();
                txtUnidProd.Enabled = false;
                btnAgrItemCosteo.Enabled = false;
                btnQuitItemCosteo.Enabled = false;
                txtUnidProd.Text = "0";

                dtCosteoDetalle.AcceptChanges();//Elimina definitivamente las filas de costeo que han sido borradas

                //===========================================
                // Limpiar grid fuentes de ingreso
                //===========================================
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetEva.SelectedCells[0].RowIndex);
                dtgDetEva["cboTipoGiro", nFilaActual].Selected = true;
                if (Convert.ToInt32(dtgDetEva.Rows[nFilaActual].Cells["IdDetalleEvaEmp"].Value) == -1)
                {
                    dtgDetEva.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetEva.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetEva.Focus();
                ProcessTabKey(true);
                TotalFinalDetalle();
                dtDetalle.AcceptChanges();
                //===========================================
            }
        }

        private void dtgDetEva_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboTipoGiro"))
            {
                cboTipoGiro = e.Control as ComboBox;
                if (cboTipoGiro != null)
                {
                    cboTipoGiro.DropDown -= new EventHandler(cboTipoGiro_DropDown);
                    cboTipoGiro.DropDown += new EventHandler(cboTipoGiro_DropDown);

                    cboTipoGiro.DropDownClosed -= new EventHandler(cboTipoGiro_DropDownClosed);
                    cboTipoGiro.DropDownClosed += new EventHandler(cboTipoGiro_DropDownClosed);

                    cboTipoGiro.SelectedIndexChanged -= new EventHandler(cboTipoGiro_SelectedIndexChanged);
                    cboTipoGiro.SelectedIndexChanged += new EventHandler(cboTipoGiro_SelectedIndexChanged);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboTipoIngr"))
            {
                ComboBox cboTipoIngr = e.Control as ComboBox;
                if (cboTipoIngr != null)
                {
                    cboTipoIngr.DropDown -= new EventHandler(cboTipoIngr_DropDown);
                    cboTipoIngr.DropDown += new EventHandler(cboTipoIngr_DropDown);

                    cboTipoIngr.DropDownClosed -= new EventHandler(cboTipoIngr_DropDownClosed);
                    cboTipoIngr.DropDownClosed += new EventHandler(cboTipoIngr_DropDownClosed);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboMoneda"))
            {
                ComboBox cboMoneda = e.Control as ComboBox;
                if (cboMoneda != null)
                {
                    cboMoneda.DropDown -= new EventHandler(cboMoneda_DropDown);
                    cboMoneda.DropDown += new EventHandler(cboMoneda_DropDown);

                    cboMoneda.DropDownClosed -= new EventHandler(cboMoneda_DropDownClosed);
                    cboMoneda.DropDownClosed += new EventHandler(cboMoneda_DropDownClosed);

                    cboMoneda.SelectedIndexChanged -= new EventHandler(cboMoneda_SelectedIndexChanged);
                    cboMoneda.SelectedIndexChanged += new EventHandler(cboMoneda_SelectedIndexChanged);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboMetCosteo"))
            {
                ComboBox cboMetCosteo = e.Control as ComboBox;
                if (cboMetCosteo != null)
                {
                    cboMetCosteo.DropDown -= new EventHandler(cboMetCosteo_DropDown);
                    cboMetCosteo.DropDown += new EventHandler(cboMetCosteo_DropDown);

                    cboMetCosteo.DropDownClosed -= new EventHandler(cboMetCosteo_DropDownClosed);
                    cboMetCosteo.DropDownClosed += new EventHandler(cboMetCosteo_DropDownClosed);

                    cboMetCosteo.SelectedIndexChanged -= new EventHandler(cboMetCosteo_SelectedIndexChanged);
                    cboMetCosteo.SelectedIndexChanged += new EventHandler(cboMetCosteo_SelectedIndexChanged);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboUnidadMed"))
            {
                ComboBox cboUnidadMed = e.Control as ComboBox;
                if (cboUnidadMed != null)
                {
                    cboUnidadMed.DropDown -= new EventHandler(cboUnidadMed_DropDown);
                    cboUnidadMed.DropDown += new EventHandler(cboUnidadMed_DropDown);

                    cboUnidadMed.DropDownClosed -= new EventHandler(cboUnidadMed_DropDownClosed);
                    cboUnidadMed.DropDownClosed += new EventHandler(cboUnidadMed_DropDownClosed);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiVenDiaBue_Est")  ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiVenDiaMalos")    ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nPreUniCompra_Prod")   ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nPrecioVenta"))            
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxReales_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxReales_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNum_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNum_Leave);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nNumDiaBue_Est")   ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nNumDiaMalos")     ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiProduTerm")  ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nNumRepitexFrec"))
            {
                TextBox txtboxEnteros = e.Control as TextBox;
                txtboxEnteros.MaxLength = 8;
                if (txtboxEnteros != null)
                {
                    txtboxEnteros.KeyPress -= new KeyPressEventHandler(txtboxEnteros_KeyPress);
                    txtboxEnteros.KeyPress += new KeyPressEventHandler(txtboxEnteros_KeyPress);

                    txtboxEnteros.Leave -= new EventHandler(txtboxNum_Leave);
                    txtboxEnteros.Leave += new EventHandler(txtboxNum_Leave);
                }
            }
        }

        private void txtboxReales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nCantiVenDiaBue_Est")   ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nCantiVenDiaMalos")     ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nPreUniCompra_Prod")    ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nPrecioVenta"))
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
                     var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxEnteros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nNumDiaBue_Est")    ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nNumDiaMalos")      ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nCantiProduTerm")   ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nNumRepitexFrec"))
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

        private void txtboxNum_Leave(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nCantiVenDiaBue_Est")   ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nCantiVenDiaMalos")     ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nPreUniCompra_Prod")    ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nCantiProduTerm")       ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nPrecioVenta")          ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nNumDiaBue_Est")        ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nNumDiaMalos")          ||
                dtgDetEva.CurrentCell.OwningColumn.Name.Equals("nNumRepitexFrec"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text)) 
                {
                    if (dtgDetEva.CurrentCell != null)
                        dtgDetEva.CurrentCell.Value = 0;
                }
            }
        }

        private void cboTipoGiro_DropDown(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboTipoGiro"))
            {
                DataGridViewComboBoxEditingControl cboTipoGiro = sender as DataGridViewComboBoxEditingControl;
                if (cboTipoGiro != null)
                    cboTipoGiro.DisplayMember = "cDesTipoGiroNego";
            }
        }

        private void cboTipoGiro_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals( "cboTipoGiro"))
            {
                DataGridViewComboBoxEditingControl cboTipoGiro = sender as DataGridViewComboBoxEditingControl;
                int index = cboTipoGiro.SelectedIndex;
                if (cboTipoGiro != null)
                {
                    cboTipoGiro.DisplayMember = "cDesCorTipoGiroNego";
                    cboTipoGiro.SelectedIndex = index;
                }
            }
        }    

        private void cboTipoIngr_DropDown(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboTipoIngr"))
            {
                DataGridViewComboBoxEditingControl cboTipoIngr = sender as DataGridViewComboBoxEditingControl;
                if (cboTipoIngr != null)
                    cboTipoIngr.DisplayMember = "cDesTipoIng";
            }
        }

        private void cboTipoIngr_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboTipoIngr"))
            {
                DataGridViewComboBoxEditingControl cboTipoIngr = sender as DataGridViewComboBoxEditingControl;
                int index = cboTipoIngr.SelectedIndex;
                if (cboTipoIngr != null)
                {
                    cboTipoIngr.DisplayMember = "cDesCorTipoIng";
                    cboTipoIngr.SelectedIndex = index;
                }
            }
        }

        private void cboMoneda_DropDown(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboMoneda"))
            {
                DataGridViewComboBoxEditingControl cboMoneda = sender as DataGridViewComboBoxEditingControl;
                if (cboMoneda != null)
                    cboMoneda.DisplayMember = "cMoneda";
            }
        }

        private void cboMoneda_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboMoneda"))
            {
                DataGridViewComboBoxEditingControl cboMoneda = sender as DataGridViewComboBoxEditingControl;
                int index = cboMoneda.SelectedIndex;
                if (cboMoneda != null)
                {
                    cboMoneda.DisplayMember = "cSimbolo";
                    cboMoneda.SelectedIndex = index;
                }
            }
        }

        private void cboMetCosteo_DropDown(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboMetCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMetCosteo = sender as DataGridViewComboBoxEditingControl;
                if (cboMetCosteo != null)
                    cboMetCosteo.DisplayMember = "cDescrMetodoCosteo";
            }
        }

        private void cboMetCosteo_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboMetCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMetCosteo = sender as DataGridViewComboBoxEditingControl;
                int index = cboMetCosteo.SelectedIndex;
                if (cboMetCosteo != null)
                {
                    cboMetCosteo.DisplayMember = "cDescrCortaMetodoCosteo";
                    cboMetCosteo.SelectedIndex = index;
                }
            }
        }

        private void cboUnidadMed_DropDown(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboUnidadMed"))
            {
                DataGridViewComboBoxEditingControl cboUnidadMed = sender as DataGridViewComboBoxEditingControl;
                if (cboUnidadMed != null)
                    cboUnidadMed.DisplayMember = "cDesTipoUniMed";
            }
        }

        private void cboUnidadMed_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name .Equals("cboUnidadMed"))
            {
                DataGridViewComboBoxEditingControl cboUnidadMed = sender as DataGridViewComboBoxEditingControl;
                int index = cboUnidadMed.SelectedIndex;
                if (cboUnidadMed != null)
                {
                    cboUnidadMed.DisplayMember = "cDesCorTipoUniMed";
                    cboUnidadMed.SelectedIndex = index;
                }
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboMoneda"))
            {
                if (dtgCosteo.RowCount > 0)
                {
                    DataGridViewComboBoxEditingControl cboMoneda = sender as DataGridViewComboBoxEditingControl;
                    if (cboMoneda != null)
                    {
                        if (cboMoneda.SelectedValue is Int32)
                        {
                            int value = Convert.ToInt32(cboMoneda.SelectedValue);
                            foreach (DataGridViewRow row in dtgCosteo.Rows)
                            {
                                row.Cells["cboMonedaCosteo"].Value = value;
                            }
                            dtgCosteo.EndEdit();
                        }

                    }
                }
            }
        }

        private void cboMetCosteo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboMetCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMetCosteo = sender as DataGridViewComboBoxEditingControl;
                if (cboMetCosteo != null)
                {
                    if (cboMetCosteo.SelectedIndex == 0)
                    {
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaBue_Est"].Style.BackColor = Color.White;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaBue_Est"].ReadOnly = false;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaMalos"].Style.BackColor = Color.White;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaMalos"].ReadOnly = false;

                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaBue_Est"].Style.BackColor = Color.White;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaBue_Est"].ReadOnly = false;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaMalos"].Style.BackColor = Color.White;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaMalos"].ReadOnly = false;

                    }
                    else if (cboMetCosteo.SelectedIndex == 1)
                    {
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaBue_Est"].Style.BackColor = Color.White;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaBue_Est"].ReadOnly = false;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaMalos"].Style.BackColor = Color.SkyBlue;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nNumDiaMalos"].ReadOnly = true;

                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaBue_Est"].Style.BackColor = Color.White;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaBue_Est"].ReadOnly = false;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaMalos"].Style.BackColor = Color.SkyBlue;
                        cboMetCosteo.EditingControlDataGridView.CurrentRow.Cells["nCantiVenDiaMalos"].ReadOnly = true;
                    }
                }
            }
        }

        private void QuitarDetalleCostosProduccion()
        {
            txtTotCostProd.Text = "0.00";
            if (string.IsNullOrEmpty(txtTotInv.Text))
            {
                txtTotInv.Text = "0.00";
            }
            txtTotInv.Text = (Convert.ToDecimal (txtTotInv.Text) - Convert.ToDecimal (txtTotStock.Text)).ToString("##,##0.00");
            txtTotStock.Text = "0.00";
            txtCostUnit.Text = "0.00";
        }

        private void cboTipoGiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell.OwningColumn.Name.Equals("cboTipoGiro"))
            {
                DataGridViewComboBoxEditingControl cboTipoGiro = sender as DataGridViewComboBoxEditingControl;
                if (cboTipoGiro != null)
                {
                    if (cboTipoGiro.SelectedIndex == 0)//Comercio
                    {
                        cboTipoGiro.EditingControlDataGridView.CurrentRow.Cells["nPreUniCompra_Prod"].Style.BackColor = Color.White;
                        cboTipoGiro.EditingControlDataGridView.CurrentRow.Cells["nPreUniCompra_Prod"].ReadOnly = false;
                        this.txtUnidProd.Enabled = false;
                        this.txtUnidProd.Text = "0";
                        this.btnAgrItemCosteo.Enabled = false;
                        this.btnQuitItemCosteo.Enabled = false;
                        //===========================================
                        // Limpiar el detalle de Costos de Producción
                        //===========================================
                        int nCantFilasDetalle = dtgCosteo.Rows.Count;
                        if (nCantFilasDetalle > 0)
                        {
                            for (int i = nCantFilasDetalle - 1; i >= 0; i--)
                            {
                                if (Convert.ToInt32(dtgCosteo.Rows[i].Cells["IdDetalleEvaEmp"].Value) == -1)
                                { dtgCosteo.Rows.RemoveAt(i); }
                                else
                                    dtgCosteo.Rows[i].Cells["lVigente"].Value = 0;
                            }
                            QuitarDetalleCostosProduccion();
                        }
                        dtCosteoDetalle.AcceptChanges();//Elimina definitivamente las filas de costeo que han sido borradas
                        return;
                        //===========================================
                    }
                    else if (cboTipoGiro.SelectedIndex == 1)//Producción
                    {
                        cboTipoGiro.EditingControlDataGridView.CurrentRow.Cells["nPreUniCompra_Prod"].Style.BackColor = Color.SkyBlue;
                        cboTipoGiro.EditingControlDataGridView.CurrentRow.Cells["nPreUniCompra_Prod"].ReadOnly = true;
                        this.txtUnidProd.Enabled = true;
                        this.btnAgrItemCosteo.Enabled = true;
                        this.btnQuitItemCosteo.Enabled = true;
                        return;
                    }
                    else if (cboTipoGiro.SelectedIndex == 2)//Servicio
                    {
                        cboTipoGiro.EditingControlDataGridView.CurrentRow.Cells["nPreUniCompra_Prod"].Style.BackColor = Color.SkyBlue;
                        cboTipoGiro.EditingControlDataGridView.CurrentRow.Cells["nPreUniCompra_Prod"].ReadOnly = true;
                        this.txtUnidProd.Enabled = true;
                        this.btnAgrItemCosteo.Enabled = true;
                        this.btnQuitItemCosteo.Enabled = true;
                        return;
                    }
                }
            }
        }

        private void dtgDetEva_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dtgDetEva.Columns.Contains("cboTipoGiro"))
            {
                dtgDetEva.Focus();
                dtgDetEva["cboTipoGiro", e.RowIndex].Selected = true;
            }
        }

        private void dtgDetEva_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDetEva.CurrentCell != null)
            {
                DataGridView dtg = (DataGridView)sender;
                dtCosteoDetalle.DefaultView.RowFilter = "";
                if (Convert.ToInt32(dtg.Rows[dtg.CurrentCell.RowIndex].Cells["IdTipoGiroNego"].Value) == 1)// Tipo COMERCIO
                {
                    this.txtUnidProd.Enabled = false;
                    this.btnAgrItemCosteo.Enabled = false;
                    this.btnQuitItemCosteo.Enabled = false;
                    txtUnidProd.Text = "";
                }
                else // Tipo PRODUCCIÓN y SERVICIO
                {
                    this.txtUnidProd.Enabled = true;
                    this.btnAgrItemCosteo.Enabled = true;
                    this.btnQuitItemCosteo.Enabled = true;
                    txtUnidProd.Text = dtg.CurrentRow.Cells["nUniCosteadas"].Value.ToString();
                }

                if (dtg.CurrentRow.Cells["IdInterno"].Value != DBNull.Value )
                {
                    if (Convert.ToInt32(dtg.CurrentRow.Cells["IdTipoGiroNego"].Value) != 1)
                    {
                        dtCosteoDetalle.DefaultView.RowFilter = ("IdInterno = " + dtg.Rows[dtg.CurrentCell.RowIndex].Cells["IdInterno"].Value + " and lVigente <> 0");
                        TotalFinalCosteo();
                    }
                    else
                    {
                        dtCosteoDetalle.DefaultView.RowFilter = ("IdInterno = " + dtg.Rows[dtg.CurrentCell.RowIndex].Cells["IdInterno"].Value + " and lVigente <> 0");
                        txtTotCostProd.Text = (0.00M).ToString("##,##0.00");
                        txtTotStock.Text = (0.00M).ToString("##,##0.00");
                        txtCostUnit.Text = (0.00M).ToString("##,##0.00"); 
                    }
                }
                nIndexDtg = dtgDetEva.CurrentCell.RowIndex;                
            }
        }

        private void dtgDetEva_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToString() == @"Value '' cannot be converted to type 'System.String'.")
                e.Cancel = true;
        }

        private void dtgDetEva_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgDetEva.Columns[e.ColumnIndex].Name.Equals("cboMoneda")           ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nNumDiaBue_Est")      ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nNumDiaMalos")        ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nCantiVenDiaBue_Est") ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nCantiVenDiaMalos")   ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nNumRepitexFrec")     ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nCantiProduTerm")     ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nPrecioVenta")        ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nNumRepitexFrec")     ||
                dtgDetEva.Columns[e.ColumnIndex].Name.Equals("nPreUniCompra_Prod"))
            {
                CalcularTotalFilaDetalle(e.RowIndex);
            }
        }

        private void CalcularTotalFilaDetalle(int index)
        {       
            int nCantiProduTerm = 0;
            int nNumRepitexFrec = 0;
            int nNumDiaBue_Est = 0;
            decimal nCantiVenDiaBue_Est = 0.00M;
            int nNumDiaMalos = 0;
            decimal nCantiVenDiaMalos = 0.00M;
            decimal nPreUniCompra_Prod = 0.00M;
            decimal nPrecioVenta = 0.00M;
            decimal nSubTotVentas = 0.00M;
            decimal nSubTotCostoCompra_Prod = 0.00M;

            if (dtgDetEva.Rows[index].Cells["nCantiProduTerm"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nCantiProduTerm"].Value = 0;
            }
            if (dtgDetEva.Rows[index].Cells["nNumRepitexFrec"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nNumRepitexFrec"].Value = 0;
            }
            if(dtgDetEva.Rows[index].Cells["nNumDiaBue_Est"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nNumDiaBue_Est"].Value = 0;
            }
            if (dtgDetEva.Rows[index].Cells["nCantiVenDiaBue_Est"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nCantiVenDiaBue_Est"].Value = 0;
            }
            if (dtgDetEva.Rows[index].Cells["nNumDiaMalos"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nNumDiaMalos"].Value = 0;
            }          
            if (dtgDetEva.Rows[index].Cells["nCantiVenDiaMalos"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nCantiVenDiaMalos"].Value = 0;
            }
            if (dtgDetEva.Rows[index].Cells["nPreUniCompra_Prod"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nPreUniCompra_Prod"].Value = 0;
            }    
            if (dtgDetEva.Rows[index].Cells["nPrecioVenta"].Value == DBNull.Value)
            {
                dtgDetEva.Rows[index].Cells["nPrecioVenta"].Value = 0;
            }
            

            nCantiProduTerm = Convert.ToInt32(dtgDetEva.Rows[index].Cells["nCantiProduTerm"].Value);
            nNumRepitexFrec = Convert.ToInt32(dtgDetEva.Rows[index].Cells["nNumRepitexFrec"].Value);
            nNumDiaBue_Est = Convert.ToInt32(dtgDetEva.Rows[index].Cells["nNumDiaBue_Est"].Value);
            nCantiVenDiaBue_Est = Convert.ToDecimal(dtgDetEva.Rows[index].Cells["nCantiVenDiaBue_Est"].Value);
            nNumDiaMalos = Convert.ToInt32(dtgDetEva.Rows[index].Cells["nNumDiaMalos"].Value);
            nCantiVenDiaMalos = Convert.ToDecimal(dtgDetEva.Rows[index].Cells["nCantiVenDiaMalos"].Value);
            nPreUniCompra_Prod = Convert.ToDecimal(dtgDetEva.Rows[index].Cells["nPreUniCompra_Prod"].Value);
            nPrecioVenta = Convert.ToDecimal(dtgDetEva.Rows[index].Cells["nPrecioVenta"].Value);

            dtgDetEva.Rows[index].Cells["nSubTotMercaderia"].Value = nCantiProduTerm * nPreUniCompra_Prod;
            dtgDetEva.Rows[index].Cells["nSubTotCostoCompra_Prod"].Value = (nNumRepitexFrec * ((nNumDiaBue_Est * nCantiVenDiaBue_Est) + (nNumDiaMalos * nCantiVenDiaMalos))) * nPreUniCompra_Prod;
            dtgDetEva.Rows[index].Cells["nSubTotVentas"].Value = (nNumRepitexFrec * ((nNumDiaBue_Est * nCantiVenDiaBue_Est) + (nNumDiaMalos * nCantiVenDiaMalos))) * nPrecioVenta;
            nSubTotVentas = Convert.ToDecimal(dtgDetEva.Rows[index].Cells["nSubTotVentas"].Value.ToString());
            nSubTotCostoCompra_Prod = Convert.ToDecimal(dtgDetEva.Rows[index].Cells["nSubTotCostoCompra_Prod"].Value.ToString());
            dtgDetEva.Rows[index].Cells["nSubTotIngresos"].Value = +nSubTotVentas - nSubTotCostoCompra_Prod;
            if (nSubTotVentas > 0)
            {
                dtgDetEva.Rows[index].Cells["nMargenUtiProdSer"].Value = ((nSubTotVentas - nSubTotCostoCompra_Prod) / nSubTotVentas);
            }
            else
            {
                dtgDetEva.Rows[index].Cells["nMargenUtiProdSer"].Value = 0.00;
            }

            TotalFinalDetalle();         
        }

        private void TotalFinalDetalle()
        {
            decimal nTotCostoCompra_Prod = 0.00M;
            decimal nTotVentas = 0.00M;
            decimal nTotIngresos = 0.00M;
            decimal nMargenUtiTot = 0.00M;
            decimal nTotPorParti = 0.00M;
            decimal nTotMercaderia = 0.00M;

            foreach (DataGridViewRow row in dtgDetEva.Rows)
            {

                if (Convert.ToInt32(row.Cells["IdMoneda"].Value) == Convert.ToInt32(cboMoneda.SelectedValue))
                {
                    nTotCostoCompra_Prod += Convert.ToDecimal(row.Cells["nSubTotCostoCompra_Prod"].Value);
                    nTotVentas += Convert.ToDecimal(row.Cells["nSubTotVentas"].Value);
                    nTotIngresos += Convert.ToDecimal(row.Cells["nSubTotIngresos"].Value);

                    nTotMercaderia += Convert.ToDecimal(row.Cells["nSubTotMercaderia"].Value);
                }
                else
                {
                    nTotCostoCompra_Prod += CambioMoneda(Convert.ToInt32(row.Cells["IdMoneda"].Value), Convert.ToDecimal(row.Cells["nSubTotCostoCompra_Prod"].Value));
                    nTotVentas += CambioMoneda(Convert.ToInt32(row.Cells["IdMoneda"].Value), Convert.ToDecimal(row.Cells["nSubTotVentas"].Value));
                    nTotIngresos += CambioMoneda(Convert.ToInt32(row.Cells["IdMoneda"].Value), Convert.ToDecimal(row.Cells["nSubTotIngresos"].Value));

                    nTotMercaderia += CambioMoneda(Convert.ToInt32(row.Cells["IdMoneda"].Value), Convert.ToDecimal(row.Cells["nSubTotMercaderia"].Value));
                }
            }

            foreach (DataGridViewRow row in dtgDetEva.Rows)
            {
                if (nTotIngresos > 0)
                {
                    if (Convert.ToInt32(row.Cells["IdMoneda"].Value) == Convert.ToInt32(cboMoneda.SelectedValue))
                    {
                        row.Cells["nPorcenPartiProdSer"].Value = Convert.ToDecimal(row.Cells["nSubTotIngresos"].Value) / nTotIngresos;
                    }
                    else
                    {
                        row.Cells["nPorcenPartiProdSer"].Value = CambioMoneda(Convert.ToInt32(row.Cells["IdMoneda"].Value), Convert.ToDecimal(row.Cells["nSubTotIngresos"].Value)) / nTotIngresos;
                    }
                }
                else
                {
                    row.Cells["nPorcenPartiProdSer"].Value = 0.00;
                }
                nTotPorParti += Convert.ToDecimal(row.Cells["nPorcenPartiProdSer"].Value);
            }
            if (nTotVentas > 0)
            {
                nMargenUtiTot += ((nTotVentas - nTotCostoCompra_Prod) / nTotVentas);
            }
            else
            {
                nMargenUtiTot = 0.00M;
            }
            txtTotCostoCompra.Text = nTotCostoCompra_Prod.ToString("##,##0.00");
            txtTotVentas.Text = nTotVentas.ToString("##,##0.00");
            txtTotIngresos.Text = nTotIngresos.ToString("##,##0.00");
            txtMargenUtiTot.Text = nMargenUtiTot.ToString("##,##0.0%");
            txtTotPorParti.Text = nTotPorParti.ToString("##,##0.0%");
            txtTotMercaderia.Text = nTotMercaderia.ToString("##,##0.00");
            ActualizarBalance();
            ActualizarEstPerdGanan();
        }

        private void FormatoGridDetalle()
        {
            foreach (DataGridViewColumn column in dtgDetEva.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetEva.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgDetEva.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgDetEva.ReadOnly = false;

            dtgDetEva.Columns["IdDetalleEvaEmp"].Visible = false;
            dtgDetEva.Columns["IdTipoGiroNego"].Visible = false;
            dtgDetEva.Columns["IdTipoIng"].Visible = false;
            dtgDetEva.Columns["IdMoneda"].Visible = false;
            dtgDetEva.Columns["cDescriProdSer"].Visible = true;
            dtgDetEva.Columns["IdMetCosteo"].Visible = false;
            dtgDetEva.Columns["nNumDiaBue_Est"].Visible = true;
            dtgDetEva.Columns["nNumDiaMalos"].Visible = true;
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].Visible = true;
            dtgDetEva.Columns["nCantiVenDiaMalos"].Visible = true;
            dtgDetEva.Columns["IdUnidadMedida"].Visible = false;
            dtgDetEva.Columns["nNumRepitexFrec"].Visible = true;
            dtgDetEva.Columns["nPreUniCompra_Prod"].Visible = true;
            dtgDetEva.Columns["nCantiProduTerm"].Visible = true;
            dtgDetEva.Columns["nPrecioVenta"].Visible = true;
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].Visible = true;
            dtgDetEva.Columns["nSubTotVentas"].Visible = true;
            dtgDetEva.Columns["nSubTotIngresos"].Visible = true;
            dtgDetEva.Columns["nMargenUtiProdSer"].Visible = true;
            dtgDetEva.Columns["nPorcenPartiProdSer"].Visible = true;
            dtgDetEva.Columns["nSubTotMercaderia"].Visible = true;
            dtgDetEva.Columns["nSubTotMatPrimaIns"].Visible = false;
            dtgDetEva.Columns["nUniCosteadas"].Visible = false;
            dtgDetEva.Columns["nSubTotCosProdu"].Visible = false;
            dtgDetEva.Columns["lVigente"].Visible = false;
            dtgDetEva.Columns["IdInterno"].Visible = false;
            dtgDetEva.Columns["cDetallePeriodo"].Visible = false;
            dtgDetEva.Columns["cDetalle"].Visible = false;

            dtgDetEva.Columns["cDescriProdSer"].ReadOnly = false;
            dtgDetEva.Columns["nNumDiaBue_Est"].ReadOnly = true;
            dtgDetEva.Columns["nNumDiaMalos"].ReadOnly = true;
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].ReadOnly = true;
            dtgDetEva.Columns["nCantiVenDiaMalos"].ReadOnly = true;
            dtgDetEva.Columns["nNumRepitexFrec"].ReadOnly = false;
            dtgDetEva.Columns["nPreUniCompra_Prod"].ReadOnly = false;
            dtgDetEva.Columns["nCantiProduTerm"].ReadOnly = false;
            dtgDetEva.Columns["nPrecioVenta"].ReadOnly = false;
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].ReadOnly = true;
            dtgDetEva.Columns["nSubTotVentas"].ReadOnly = true;
            dtgDetEva.Columns["nSubTotIngresos"].ReadOnly = true;
            dtgDetEva.Columns["nMargenUtiProdSer"].ReadOnly = true;
            dtgDetEva.Columns["nPorcenPartiProdSer"].ReadOnly = true;
            dtgDetEva.Columns["nSubTotMercaderia"].ReadOnly = true;
            dtgDetEva.Columns["nSubTotCosProdu"].ReadOnly = true;

            dtgDetEva.Columns["cDescriProdSer"].HeaderText = "Descripción";
            dtgDetEva.Columns["nNumDiaBue_Est"].HeaderText = "NDB";
            dtgDetEva.Columns["nNumDiaMalos"].HeaderText = "NDM";
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].HeaderText = "CVDB";
            dtgDetEva.Columns["nCantiVenDiaMalos"].HeaderText = "CVDM";
            dtgDetEva.Columns["nNumRepitexFrec"].HeaderText = "N° Rep";
            dtgDetEva.Columns["nPreUniCompra_Prod"].HeaderText = "Prec. Compra";
            dtgDetEva.Columns["nCantiProduTerm"].HeaderText = "Stock Prod";
            dtgDetEva.Columns["nPrecioVenta"].HeaderText = "Prec. Venta";
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].HeaderText = "SubTot Compras";
            dtgDetEva.Columns["nSubTotVentas"].HeaderText = "SubTot Ventas";
            dtgDetEva.Columns["nSubTotIngresos"].HeaderText = "SubTot Ingresos";
            dtgDetEva.Columns["nMargenUtiProdSer"].HeaderText = "Margen Utilidad";
            dtgDetEva.Columns["nPorcenPartiProdSer"].HeaderText = "Porc. Part.";
            dtgDetEva.Columns["nSubTotMercaderia"].HeaderText = "SubTot Mercad";

            dtgDetEva.Columns["cDescriProdSer"].ToolTipText = "Descripcion de actividad";
            dtgDetEva.Columns["nNumDiaBue_Est"].ToolTipText = "N° Dias Buenos";
            dtgDetEva.Columns["nNumDiaMalos"].ToolTipText = "N° Dias Malos";
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].ToolTipText = "Cant. Vend. Dia Bueno";
            dtgDetEva.Columns["nCantiVenDiaMalos"].ToolTipText = "Cant. Vend. Dia Malo";
            dtgDetEva.Columns["nNumRepitexFrec"].ToolTipText = "N° Repeticiones x Unidad de Tiempo";
            dtgDetEva.Columns["nPreUniCompra_Prod"].ToolTipText = "Precio de Compra";
            dtgDetEva.Columns["nCantiProduTerm"].ToolTipText = "Cant. Prod Terminados";
            dtgDetEva.Columns["nPrecioVenta"].ToolTipText = "Precio de Venta";
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].ToolTipText = "SubTotal de Compras";
            dtgDetEva.Columns["nSubTotVentas"].ToolTipText = "SubTotal de Ventas";
            dtgDetEva.Columns["nSubTotIngresos"].ToolTipText = "SubTotal de Ingresos";
            dtgDetEva.Columns["nMargenUtiProdSer"].ToolTipText = "Margen de Utiidad";
            dtgDetEva.Columns["nPorcenPartiProdSer"].ToolTipText = "% Participación";
            dtgDetEva.Columns["nSubTotMercaderia"].ToolTipText = "SubTotal Mercaderia";

            dtgDetEva.Columns["nNumDiaBue_Est"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nNumDiaMalos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nCantiVenDiaMalos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nNumRepitexFrec"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nPreUniCompra_Prod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nCantiProduTerm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nPrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nSubTotVentas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nSubTotIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nMargenUtiProdSer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nPorcenPartiProdSer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetEva.Columns["nSubTotMercaderia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDetEva.Columns["cboTipoGiro"].FillWeight = 30;
            dtgDetEva.Columns["cboTipoIngr"].FillWeight = 30;
            dtgDetEva.Columns["cboMoneda"].FillWeight = 36;
            dtgDetEva.Columns["cDescriProdSer"].FillWeight = 70;
            dtgDetEva.Columns["cboMetCosteo"].FillWeight = 44;
            dtgDetEva.Columns["nNumDiaBue_Est"].FillWeight = 27;
            dtgDetEva.Columns["nNumDiaMalos"].FillWeight = 29;
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].FillWeight = 34;
            dtgDetEva.Columns["nCantiVenDiaMalos"].FillWeight = 34;
            dtgDetEva.Columns["cboUnidadMed"].FillWeight = 40;
            dtgDetEva.Columns["nNumRepitexFrec"].FillWeight = 25;
            dtgDetEva.Columns["nPreUniCompra_Prod"].FillWeight = 42;
            dtgDetEva.Columns["nCantiProduTerm"].FillWeight = 35;
            dtgDetEva.Columns["nPrecioVenta"].FillWeight = 42;
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].FillWeight = 65;
            dtgDetEva.Columns["nSubTotVentas"].FillWeight = 65;
            dtgDetEva.Columns["nSubTotIngresos"].FillWeight = 65;
            dtgDetEva.Columns["nMargenUtiProdSer"].FillWeight = 45;
            dtgDetEva.Columns["nPorcenPartiProdSer"].FillWeight = 40;
            dtgDetEva.Columns["nSubTotMercaderia"].FillWeight = 65;

            dtgDetEva.Columns["cboTipoGiro"].DisplayIndex = 1;
            dtgDetEva.Columns["cboTipoIngr"].DisplayIndex = 2;
            dtgDetEva.Columns["cboMoneda"].DisplayIndex = 3;
            dtgDetEva.Columns["cDescriProdSer"].DisplayIndex = 4;
            dtgDetEva.Columns["cboMetCosteo"].DisplayIndex = 5;
            dtgDetEva.Columns["nNumDiaBue_Est"].DisplayIndex = 6;
            dtgDetEva.Columns["nNumDiaMalos"].DisplayIndex = 7;
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].DisplayIndex = 8;
            dtgDetEva.Columns["nCantiVenDiaMalos"].DisplayIndex = 9;
            dtgDetEva.Columns["cboUnidadMed"].DisplayIndex = 10;
            dtgDetEva.Columns["nNumRepitexFrec"].DisplayIndex = 11;
            dtgDetEva.Columns["nPreUniCompra_Prod"].DisplayIndex = 12;
            dtgDetEva.Columns["nCantiProduTerm"].DisplayIndex = 13;
            dtgDetEva.Columns["nPrecioVenta"].DisplayIndex = 14;
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].DisplayIndex = 15;
            dtgDetEva.Columns["nSubTotVentas"].DisplayIndex = 16;
            dtgDetEva.Columns["nSubTotIngresos"].DisplayIndex = 17;
            dtgDetEva.Columns["nMargenUtiProdSer"].DisplayIndex = 18;
            dtgDetEva.Columns["nPorcenPartiProdSer"].DisplayIndex = 19;
            dtgDetEva.Columns["nSubTotMercaderia"].DisplayIndex = 20;

            dtgDetEva.Columns["nNumDiaBue_Est"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nNumDiaMalos"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nNumDiaBue_Est"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nNumDiaMalos"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nCantiVenDiaBue_Est"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nCantiVenDiaMalos"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nSubTotVentas"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nSubTotIngresos"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nMargenUtiProdSer"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nPorcenPartiProdSer"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgDetEva.Columns["nSubTotMercaderia"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgDetEva.Columns["nCantiVenDiaBue_Est"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nCantiVenDiaMalos"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nPreUniCompra_Prod"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nPrecioVenta"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nSubTotCostoCompra_Prod"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nSubTotVentas"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nSubTotIngresos"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetEva.Columns["nMargenUtiProdSer"].DefaultCellStyle.Format = "##,##0.0%";
            dtgDetEva.Columns["nPorcenPartiProdSer"].DefaultCellStyle.Format = "##,##0.0%";
            dtgDetEva.Columns["nSubTotMercaderia"].DefaultCellStyle.Format = "##,##0.00";

            if (dtgDetEva.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgDetEva.Rows)
                {
                    if (Convert.ToInt32(row.Cells["cboTipoGiro"].Value) == 1)
                    {
                        row.Cells["nPreUniCompra_Prod"].Style.BackColor = Color.White;
                        row.Cells["nPreUniCompra_Prod"].ReadOnly = false;
                    }
                    else if (Convert.ToInt32(row.Cells["cboTipoGiro"].Value) == 2)
                    {
                        row.Cells["nPreUniCompra_Prod"].Style.BackColor = Color.SkyBlue;
                        row.Cells["nPreUniCompra_Prod"].ReadOnly = true;
                    }
                    else if (Convert.ToInt32(row.Cells["cboTipoGiro"].Value) == 3)
                    {
                        row.Cells["nPreUniCompra_Prod"].Style.BackColor = Color.SkyBlue;
                        row.Cells["nPreUniCompra_Prod"].ReadOnly = true;
                    }
                    if (Convert.ToInt32(row.Cells["cboMetCosteo"].Value) == 1)
                    {
                        row.Cells["nNumDiaBue_Est"].Style.BackColor = Color.White;
                        row.Cells["nNumDiaBue_Est"].ReadOnly = false;
                        row.Cells["nNumDiaMalos"].Style.BackColor = Color.White;
                        row.Cells["nNumDiaMalos"].ReadOnly = false;

                        row.Cells["nCantiVenDiaBue_Est"].Style.BackColor = Color.White;
                        row.Cells["nCantiVenDiaBue_Est"].ReadOnly = false;
                        row.Cells["nCantiVenDiaMalos"].Style.BackColor = Color.White;
                        row.Cells["nCantiVenDiaMalos"].ReadOnly = false;
                    }
                    else if (Convert.ToInt32(row.Cells["cboMetCosteo"].Value) == 2)
                    {
                        row.Cells["nNumDiaBue_Est"].Style.BackColor = Color.White;
                        row.Cells["nNumDiaBue_Est"].ReadOnly = false;
                        row.Cells["nNumDiaMalos"].Style.BackColor = Color.SkyBlue;
                        row.Cells["nNumDiaMalos"].ReadOnly = true;

                        row.Cells["nCantiVenDiaBue_Est"].Style.BackColor = Color.White;
                        row.Cells["nCantiVenDiaBue_Est"].ReadOnly = false;
                        row.Cells["nCantiVenDiaMalos"].Style.BackColor = Color.SkyBlue;
                        row.Cells["nCantiVenDiaMalos"].ReadOnly = true;
                    }
                }
            }
        }

        #endregion

        #region DtgCosteo

        private void dtgCosteo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboUnidadMedCosteo"))
            {
                ComboBox cboUnidadMedCosteo = e.Control as ComboBox;
                if (cboUnidadMedCosteo != null)
                {
                    cboUnidadMedCosteo.DropDown -= new EventHandler(cboUnidadMedCosteo_DropDown);
                    cboUnidadMedCosteo.DropDown += new EventHandler(cboUnidadMedCosteo_DropDown);

                    cboUnidadMedCosteo.DropDownClosed -= new EventHandler(cboUnidadMedCosteo_DropDownClosed);
                    cboUnidadMedCosteo.DropDownClosed += new EventHandler(cboUnidadMedCosteo_DropDownClosed);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboMonedaCosteo"))
            {
                ComboBox cboMonedaCosteo = e.Control as ComboBox;
                if (cboMonedaCosteo != null)
                {
                    cboMonedaCosteo.DropDown -= new EventHandler(cboMonedaCosteo_DropDown);
                    cboMonedaCosteo.DropDown += new EventHandler(cboMonedaCosteo_DropDown);

                    cboMonedaCosteo.DropDownClosed -= new EventHandler(cboMonedaCosteo_DropDownClosed);
                    cboMonedaCosteo.DropDownClosed += new EventHandler(cboMonedaCosteo_DropDownClosed);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiUtiMatIns") ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nPrecioCompMatIns") ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiMatInsStock"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgCosteo_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgCosteo_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgCosteo_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgCosteo_Leave);
                }
            }
        }

        private void txtboxRealesdtgCosteo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiUtiMatIns")   ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nPrecioCompMatIns") ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiMatInsStock"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxNumdtgCosteo_Leave(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiUtiMatIns")   ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nPrecioCompMatIns") ||
                dtgCosteo.CurrentCell.OwningColumn.Name.Equals("nCantiMatInsStock"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgCosteo.CurrentCell != null)
                    {
                        dtgCosteo.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void cboUnidadMedCosteo_DropDown(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboUnidadMedCosteo"))
            {
                DataGridViewComboBoxEditingControl cboUnidadMedCosteo = sender as DataGridViewComboBoxEditingControl;
                if (cboUnidadMedCosteo != null)
                    cboUnidadMedCosteo.DisplayMember = "cDesTipoUniMed";
            }
        }

        private void cboUnidadMedCosteo_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboUnidadMedCosteo"))
            {
                DataGridViewComboBoxEditingControl cboUnidadMedCosteo = sender as DataGridViewComboBoxEditingControl;
                int index = cboUnidadMedCosteo.SelectedIndex;
                if (cboUnidadMedCosteo != null)
                {
                    cboUnidadMedCosteo.DisplayMember = "cDesCorTipoUniMed";
                    cboUnidadMedCosteo.SelectedIndex = index;
                }
            }     
        }

        private void cboMonedaCosteo_DropDown(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboMonedaCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMonedaCosteo = sender as DataGridViewComboBoxEditingControl;
                if (cboMonedaCosteo != null)
                    cboMonedaCosteo.DisplayMember = "cMoneda";
            }
        }

        private void cboMonedaCosteo_DropDownClosed(object sender, EventArgs e)
        {
            if (dtgCosteo.CurrentCell.OwningColumn.Name.Equals("cboMonedaCosteo"))
            {
                DataGridViewComboBoxEditingControl cboMonedaCosteo = sender as DataGridViewComboBoxEditingControl;
                int index = cboMonedaCosteo.SelectedIndex;
                if (cboMonedaCosteo != null)
                {
                    cboMonedaCosteo.DisplayMember = "cSimbolo";
                    cboMonedaCosteo.SelectedIndex = index;
                }
            }
        }

        private void btnAgrItemCosteo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUnidProd.Text))
            {
                MessageBox.Show("Ingrese la cantidad de unidades a ser costeadas", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnidProd.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(this.txtUnidProd.Text))
            {
                if (Convert.ToDecimal(this.txtUnidProd.Text) <=0)
                {
                    MessageBox.Show("La cantidad de unidades a ser costeadas debe ser mayor a 0", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnidProd.Focus();
                    return;
                }
            }
            if (this.dtgDetEva.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el registro (Fuente de Ingreso) al cual quiere agregar el costeo", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow dr = dtCosteoDetalle.NewRow();
            dr["IdCosteo"] = -1;
            dr["IdDetalleEvaEmp"] = dtgDetEva.CurrentRow.Cells["IdDetalleEvaEmp"].Value;
            dr["cDescriMatIns"] = "";
            dr["IdMoneda"] = dtgDetEva.CurrentRow.Cells["IdMoneda"].Value;
            dr["nCantiUtiMatIns"] = 0;
            dr["IdUnidadMedida"] = 1;
            dr["nPrecioCompMatIns"] = 0.00;
            dr["nCantiMatInsStock"] = 0;
            dr["nSubTotCostoProdu"] = 0.00;
            dr["nSubTotMatInsStock"] = 0.00;
            dr["lVigente"] = 1;
            dr["IdInterno"] = dtgDetEva.CurrentRow.Cells["IdInterno"].Value;
            dtCosteoDetalle.Rows.Add(dr);
            dtgCosteo.DataSource = dtCosteoDetalle;
        }        

        private void btnQuitItemCosteo_Click(object sender, EventArgs e)
        {
            if (this.dtgCosteo.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {                
                Int32 nFilaActual = Convert.ToInt32(this.dtgCosteo.SelectedCells[0].RowIndex);
                dtgCosteo["cDescriMatIns", nFilaActual].Selected = true;
                if (Convert.ToInt32(dtgCosteo.Rows[nFilaActual].Cells["IdDetalleEvaEmp"].Value) == -1)
                {
                    dtgCosteo.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgCosteo.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgCosteo.Focus();
                ProcessTabKey(true);
                dtCosteoDetalle.AcceptChanges();//Elimina definitivamente las filas de costeo que han sido borradas
                TotalFinalCosteo();
            }        
        }

        private void dtgCosteo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgCosteo.Focus();
            dtgCosteo["cDescriMatIns", e.RowIndex].Selected = true;
        }

        private void dtgCosteo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message.ToString() == @"Value '' cannot be converted to type 'System.String'.")
            {
                e.Cancel = true;
            }
        }

        private void dtgCosteo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgCosteo.Columns[e.ColumnIndex].Name.Equals("nCantiUtiMatIns") ||
                dtgCosteo.Columns[e.ColumnIndex].Name.Equals("nPrecioCompMatIns") ||
                dtgCosteo.Columns[e.ColumnIndex].Name.Equals("nCantiMatInsStock"))
            {
                CalcularTotalFilaCosteo(e.RowIndex);
            }
        }

        private void CalcularTotalFilaCosteo(int index)
        {
            if (dtgCosteo.RowCount > 0)
            {
                decimal nPrecioCompMatIns = 0.00M;
                decimal nCantiUtiMatIns = 0.00M;
                decimal nCantiMatInsStock = 0.00M;

                if (dtgCosteo.Rows[index].Cells["nPrecioCompMatIns"].Value == DBNull.Value)
                {
                    dtgCosteo.Rows[index].Cells["nPrecioCompMatIns"].Value = 0;
                }
                if (dtgCosteo.Rows[index].Cells["nCantiUtiMatIns"].Value == DBNull.Value)
                {
                    dtgCosteo.Rows[index].Cells["nCantiUtiMatIns"].Value = 0;
                }
                if (dtgCosteo.Rows[index].Cells["nCantiMatInsStock"].Value == DBNull.Value)
                {
                    dtgCosteo.Rows[index].Cells["nCantiMatInsStock"].Value = 0;
                }

                nPrecioCompMatIns = Convert.ToDecimal(dtgCosteo.Rows[index].Cells["nPrecioCompMatIns"].Value); ;
                nCantiUtiMatIns = Convert.ToDecimal(dtgCosteo.Rows[index].Cells["nCantiUtiMatIns"].Value); ;
                nCantiMatInsStock = Convert.ToDecimal(dtgCosteo.Rows[index].Cells["nCantiMatInsStock"].Value);
                dtgCosteo.Rows[index].Cells["nSubTotCostoProdu"].Value = nPrecioCompMatIns * nCantiUtiMatIns;
                dtgCosteo.Rows[index].Cells["nSubTotMatInsStock"].Value = nPrecioCompMatIns * nCantiMatInsStock;
            }
            else
            {
                txtTotCostProd.Text = "0.00";
                txtTotStock.Text = "0.00";
                txtCostUnit.Text = "0.00";
            }
            TotalFinalCosteo();
        }

        private void TotalFinalCosteo()
        {
            decimal nSubTotCostoProdu = 0.00M;
            decimal nSubTotMatInsStock = 0.00M;
            decimal nTotalInventario = 0.00M;

            foreach (DataGridViewRow row in dtgCosteo.Rows)
            {
                nSubTotCostoProdu += Convert.ToDecimal(row.Cells["nSubTotCostoProdu"].Value);
                nSubTotMatInsStock += Convert.ToDecimal(row.Cells["nSubTotMatInsStock"].Value);
            }

            foreach (DataRow row in dtCosteoDetalle.Rows)
            {
                if (Convert.ToBoolean(row["lVigente"].ToString()))
                {
                    if (Convert.ToInt32(row["IdMoneda"].ToString()) == Convert.ToInt32(cboMoneda.SelectedValue))
                    {
                        nTotalInventario += Convert.ToDecimal(row["nSubTotMatInsStock"].ToString());
                    }
                    else
                    {
                        nTotalInventario += CambioMoneda(Convert.ToInt32(row["IdMoneda"].ToString()), Convert.ToDecimal(row["nSubTotMatInsStock"].ToString()));
                    }
                }
            }

            txtTotCostProd.Text = nSubTotCostoProdu.ToString("##,##0.00");
            txtTotStock.Text = nSubTotMatInsStock.ToString("##,##0.00");
            txtTotInv.Text = nTotalInventario.ToString("##,##0.00");
            try
            {
                if (string.IsNullOrEmpty(txtTotCostProd.Text)) txtTotCostProd.Text = "0.00";
                if (string.IsNullOrEmpty(txtUnidProd.Text)) txtUnidProd.Text = "1";

                txtCostUnit.Text = (Convert.ToDecimal(txtTotCostProd.Text) / Convert.ToDecimal(txtUnidProd.Text)).ToString("##,##0.00"); 
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Debe ingresar el NÚMERO DE UNIDADES COSTEADAS para los giros de Negocio tipo: SERVICIO ó PRODUCCIÓN.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnidProd.Focus();
            }
        }

        private void CalcularCostoUnit()
        {
            if (string.IsNullOrEmpty(txtUnidProd.Text)) return;
            if (dtgCosteo.Rows.Count <= 0) return;
            txtCostUnit.Text = (Convert.ToDecimal(txtTotCostProd.Text) / Convert.ToDecimal(txtUnidProd.Text)).ToString("##,##0.00");
        }

        private void FormatoGridCosteo()
        {
            foreach (DataGridViewColumn column in dtgCosteo.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCosteo.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgCosteo.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgCosteo.ReadOnly = false;

            dtgCosteo.Columns["IdCosteo"].Visible = false;
            dtgCosteo.Columns["IdDetalleEvaEmp"].Visible = false;
            dtgCosteo.Columns["cDescriMatIns"].Visible = true;
            dtgCosteo.Columns["IdMoneda"].Visible = false;
            dtgCosteo.Columns["nCantiUtiMatIns"].Visible = true;
            dtgCosteo.Columns["IdUnidadMedida"].Visible = false;
            dtgCosteo.Columns["nPrecioCompMatIns"].Visible = true;
            dtgCosteo.Columns["nCantiMatInsStock"].Visible = true;
            dtgCosteo.Columns["nSubTotCostoProdu"].Visible = true;
            dtgCosteo.Columns["nSubTotMatInsStock"].Visible = true;
            dtgCosteo.Columns["IdInterno"].Visible = false;
            dtgCosteo.Columns["lVigente"].Visible = false;

            dtgCosteo.Columns["cDescriMatIns"].ReadOnly = false;
            dtgCosteo.Columns["nCantiUtiMatIns"].ReadOnly = false;
            dtgCosteo.Columns["nPrecioCompMatIns"].ReadOnly = false;
            dtgCosteo.Columns["nCantiMatInsStock"].ReadOnly = false;
            dtgCosteo.Columns["nSubTotCostoProdu"].ReadOnly = true;
            dtgCosteo.Columns["nSubTotMatInsStock"].ReadOnly = true;

            dtgCosteo.Columns["cDescriMatIns"].HeaderText = "Descripción";
            dtgCosteo.Columns["nCantiUtiMatIns"].HeaderText = "Cant. Util.";
            dtgCosteo.Columns["nPrecioCompMatIns"].HeaderText = "Prec. Compra";
            dtgCosteo.Columns["nCantiMatInsStock"].HeaderText = "Cant. Mat. Stock";
            dtgCosteo.Columns["nSubTotCostoProdu"].HeaderText = "SubTotal Costo Prod";
            dtgCosteo.Columns["nSubTotMatInsStock"].HeaderText = "SubTotal Stock ";

            dtgCosteo.Columns["cDescriMatIns"].ToolTipText = "Descripción";
            dtgCosteo.Columns["nCantiUtiMatIns"].ToolTipText = "Cantidad Utilizada";
            dtgCosteo.Columns["nPrecioCompMatIns"].ToolTipText = "Precio Compra";
            dtgCosteo.Columns["nCantiMatInsStock"].ToolTipText = "Cantidad Materiales en Stock";
            dtgCosteo.Columns["nSubTotCostoProdu"].ToolTipText = "SubTotal Costo Produccion";
            dtgCosteo.Columns["nSubTotMatInsStock"].ToolTipText = "SubTotal Mateiales en Stock";

            dtgCosteo.Columns["nCantiUtiMatIns"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nPrecioCompMatIns"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nCantiMatInsStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nSubTotCostoProdu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCosteo.Columns["nSubTotMatInsStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCosteo.Columns["cDescriMatIns"].FillWeight = 60;
            dtgCosteo.Columns["cboMonedaCosteo"].FillWeight = 25;
            dtgCosteo.Columns["cboUnidadMedCosteo"].FillWeight = 25;
            dtgCosteo.Columns["nCantiUtiMatIns"].FillWeight = 20;
            dtgCosteo.Columns["nPrecioCompMatIns"].FillWeight = 30;
            dtgCosteo.Columns["nCantiMatInsStock"].FillWeight = 30;
            dtgCosteo.Columns["nSubTotCostoProdu"].FillWeight = 28;
            dtgCosteo.Columns["nSubTotMatInsStock"].FillWeight = 28;

            dtgCosteo.Columns["cDescriMatIns"].DisplayIndex = 1;
            dtgCosteo.Columns["cboMonedaCosteo"].DisplayIndex = 2;
            dtgCosteo.Columns["nCantiUtiMatIns"].DisplayIndex = 3;
            dtgCosteo.Columns["cboUnidadMedCosteo"].DisplayIndex = 4;
            dtgCosteo.Columns["nPrecioCompMatIns"].DisplayIndex = 5;
            dtgCosteo.Columns["nCantiMatInsStock"].DisplayIndex = 6;
            dtgCosteo.Columns["nSubTotCostoProdu"].DisplayIndex = 7;
            dtgCosteo.Columns["nSubTotMatInsStock"].DisplayIndex = 8;

            dtgCosteo.Columns["nSubTotCostoProdu"].DefaultCellStyle.BackColor = Color.SkyBlue;
            dtgCosteo.Columns["nSubTotMatInsStock"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgCosteo.Columns["nCantiUtiMatIns"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nPrecioCompMatIns"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nCantiMatInsStock"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nSubTotCostoProdu"].DefaultCellStyle.Format = "##,##0.00";
            dtgCosteo.Columns["nSubTotMatInsStock"].DefaultCellStyle.Format = "##,##0.00";

            //Simular evento SelectionChanged -- para que el detalle del costeo se carge de acuerdo a la evaluación seleccionada(fila de la evaluación)
            if (dtgDetEva.Rows.Count > 0)
            {
                dtgDetEva.CurrentCell = null;
                dtgDetEva.CurrentCell = dtgDetEva[4, 0];//seleccionar la primera fila
                dtgDetEva.CurrentCell.Selected = true;
            }
            else
            {
                dtgDetEva.CurrentCell = null;
            }
        }

        #endregion

        #region DtgCredNeg

        private void btnAgrDetCredNeg_Click(object sender, EventArgs e)
        {
            DataRow dr = dtDetCreNegocio.NewRow();
            dr["IdDetCrediNego"] = -1;
            dr["IdPerteneceDeuda"] = 1;
            dr["cDesInstitucion"] = "";
            dr["nTotCuotas"] = 0;
            dr["nCuoPagdas"] = 0;
            dr["nCuoPendientes"] = 0;
            dr["nMontoCuota"] = 0;
            dr["nSaldoCredito"] = 0;
            dr["lVigente"] = 1;
            dtDetCreNegocio.Rows.Add(dr);
        }

        private void btnQuitDetCredNeg_Click(object sender, EventArgs e)
        {
            if (this.dtgDetCreNeg.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetCreNeg.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgDetCreNeg.Rows[nFilaActual].Cells["IdDetCrediNego"].Value) == -1)
                {
                    dtgDetCreNeg.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetCreNeg.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetCreNeg.Focus();
                TotalFinalCredNegocio();
                ProcessTabKey(true);
            }
        }

        private void dtgDetCreNeg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nTotCuotas") ||
                ((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCuoPagdas" ))
            {
                TextBox txtboxEnteros = e.Control as TextBox;
                txtboxEnteros.MaxLength = 8;
                if (txtboxEnteros != null)
                {
                    txtboxEnteros.KeyPress -= new KeyPressEventHandler(txtboxEnterosdtgDetCreNeg_KeyPress);
                    txtboxEnteros.KeyPress += new KeyPressEventHandler(txtboxEnterosdtgDetCreNeg_KeyPress);

                    txtboxEnteros.Leave -= new EventHandler(txtboxNumdtgDetCreNeg_Leave);
                    txtboxEnteros.Leave += new EventHandler(txtboxNumdtgDetCreNeg_Leave);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.In("nMontoCuota", "nSaldoCredito"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgDetCreNeg_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgDetCreNeg_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgDetCreNeg_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgDetCreNeg_Leave);
                }
            }
        }

        private void txtboxRealesdtgDetCreNeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgDetCreNeg.CurrentCell.OwningColumn.Name.In("nMontoCuota", "nSaldoCredito"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxEnterosdtgDetCreNeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgDetCreNeg.CurrentCell.OwningColumn.Name.In("nTotCuotas", "nCuoPagdas"))
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

        private void txtboxNumdtgDetCreNeg_Leave(object sender, EventArgs e)
        {
            if (dtgDetCreNeg.CurrentCell.OwningColumn.Name.In("nMontoCuota","nTotCuotas","nCuoPagdas"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgDetCreNeg.CurrentCell != null)
                    {
                        dtgDetCreNeg.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void dtgDetCreNeg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgDetCreNeg.Focus();
            dtgDetCreNeg["cDesInstitucion", e.RowIndex].Selected = true;
        }

        private void dtgDetCreNeg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgDetCreNeg.Columns[e.ColumnIndex].Name.In("nTotCuotas","nCuoPagdas","nMontoCuota","nSaldoCredito"))
            {
                CalcularTotalFilaCredNegocio(e.RowIndex);
            }
        }

        private void CalcularTotalFilaCredNegocio(int index)
        {
            int nTotCuotas = 0;
            int nCuoPagdas = 0;
            int nCuoPendientes = 0;
            decimal nMontoCuota = 0.00M;

            if (dtgDetCreNeg.Rows[index].Cells["nTotCuotas"].Value == DBNull.Value) dtgDetCreNeg.Rows[index].Cells["nTotCuotas"].Value = 0;
            if (dtgDetCreNeg.Rows[index].Cells["nCuoPagdas"].Value == DBNull.Value) dtgDetCreNeg.Rows[index].Cells["nCuoPagdas"].Value = 0;
            if (dtgDetCreNeg.Rows[index].Cells["nMontoCuota"].Value == DBNull.Value) dtgDetCreNeg.Rows[index].Cells["nMontoCuota"].Value = 0;
            if (dtgDetCreNeg.Rows[index].Cells["nSaldoCredito"].Value == DBNull.Value) dtgDetCreNeg.Rows[index].Cells["nSaldoCredito"].Value = 0;

            nTotCuotas = Convert.ToInt32(dtgDetCreNeg.Rows[index].Cells["nTotCuotas"].Value);
            nCuoPagdas = Convert.ToInt32(dtgDetCreNeg.Rows[index].Cells["nCuoPagdas"].Value);

            //Desactivar el evento para que el flujo continue con normalidad
            dtgDetCreNeg.CellValueChanged -= new DataGridViewCellEventHandler(dtgDetCreNeg_CellValueChanged);
            dtgDetCreNeg.Rows[index].Cells["nCuoPendientes"].Value = nTotCuotas - nCuoPagdas;            
            
            nCuoPendientes = Convert.ToInt32(dtgDetCreNeg.Rows[index].Cells["nCuoPendientes"].Value);
            nMontoCuota = Convert.ToDecimal(dtgDetCreNeg.Rows[index].Cells["nMontoCuota"].Value);

           // dtgDetCreNeg.Rows[index].Cells["nSaldoCredito"].Value = nCuoPendientes * nMontoCuota;
            dtgDetCreNeg.CellValueChanged += new DataGridViewCellEventHandler(dtgDetCreNeg_CellValueChanged);

            TotalFinalCredNegocio();
        }

        private void TotalFinalCredNegocio()
        {
            decimal nTotMontoCuota = 0.00M;
            decimal nTotSaldoCred = 0.00M;

            foreach (DataGridViewRow row in dtgDetCreNeg.Rows)
            {
                nTotMontoCuota += Convert.ToDecimal(row.Cells["nMontoCuota"].Value);
                nTotSaldoCred += Convert.ToDecimal(row.Cells["nSaldoCredito"].Value);
            }
            txtTotMontCuotaNeg.Text = nTotMontoCuota.ToString("##,##0.00");
            txtTotSalCredNego.Text = nTotSaldoCred.ToString("##,##0.00");
        }

        private void FormatoGridDetalleCreditos()
        {
            foreach (DataGridViewColumn column in dtgDetCreNeg.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetCreNeg.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgDetCreNeg.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgDetCreNeg.ReadOnly = false;

            dtgDetCreNeg.Columns["IdDetCrediNego"].Visible = false;
            dtgDetCreNeg.Columns["IdEvalEmp"].Visible = false;
            dtgDetCreNeg.Columns["IdPerteneceDeuda"].Visible = false;
            dtgDetCreNeg.Columns["cDesInstitucion"].Visible = true;
            dtgDetCreNeg.Columns["nTotCuotas"].Visible = true;
            dtgDetCreNeg.Columns["nCuoPagdas"].Visible = true;
            dtgDetCreNeg.Columns["nCuoPendientes"].Visible = true;
            dtgDetCreNeg.Columns["nMontoCuota"].Visible = true;
            dtgDetCreNeg.Columns["nSaldoCredito"].Visible = true;
            dtgDetCreNeg.Columns["lVigente"].Visible = false;

            dtgDetCreNeg.Columns["cDesInstitucion"].ReadOnly = false;
            dtgDetCreNeg.Columns["nTotCuotas"].ReadOnly = false;
            dtgDetCreNeg.Columns["nCuoPagdas"].ReadOnly = false;
            dtgDetCreNeg.Columns["nCuoPendientes"].ReadOnly = true;
            dtgDetCreNeg.Columns["nMontoCuota"].ReadOnly = false;
            dtgDetCreNeg.Columns["nSaldoCredito"].ReadOnly = false;

            dtgDetCreNeg.Columns["cDesInstitucion"].HeaderText = "Institución";
            dtgDetCreNeg.Columns["nTotCuotas"].HeaderText = "N° Cuotas";
            dtgDetCreNeg.Columns["nCuoPagdas"].HeaderText = "Cuo. Pag.";
            dtgDetCreNeg.Columns["nCuoPendientes"].HeaderText = "Cuo. Pend.";
            dtgDetCreNeg.Columns["nMontoCuota"].HeaderText = "Mon. Cuota";
            dtgDetCreNeg.Columns["nSaldoCredito"].HeaderText = "Saldo Capital";

            dtgDetCreNeg.Columns["cDesInstitucion"].ToolTipText = "Institución";
            dtgDetCreNeg.Columns["nTotCuotas"].ToolTipText = "Número Total de Cuotas";
            dtgDetCreNeg.Columns["nCuoPagdas"].ToolTipText = "Número de Cuotas Pagadas";
            dtgDetCreNeg.Columns["nCuoPendientes"].ToolTipText = "Número de Cuotas Pendientes";
            dtgDetCreNeg.Columns["nMontoCuota"].ToolTipText = "Monto de la Cuota";
            dtgDetCreNeg.Columns["nSaldoCredito"].ToolTipText = "Saldo capital del Crédito";

            dtgDetCreNeg.Columns["nTotCuotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreNeg.Columns["nCuoPagdas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreNeg.Columns["nCuoPendientes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreNeg.Columns["nMontoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreNeg.Columns["nSaldoCredito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDetCreNeg.Columns["cDesInstitucion"].FillWeight = 75;
            dtgDetCreNeg.Columns["nTotCuotas"].FillWeight = 40;
            dtgDetCreNeg.Columns["nCuoPagdas"].FillWeight = 50;
            dtgDetCreNeg.Columns["nCuoPendientes"].FillWeight = 45;
            dtgDetCreNeg.Columns["nMontoCuota"].FillWeight = 50;
            dtgDetCreNeg.Columns["nSaldoCredito"].FillWeight = 50;

            dtgDetCreNeg.Columns["nCuoPendientes"].DefaultCellStyle.BackColor = Color.SkyBlue;
            //dtgDetCreNeg.Columns["nSaldoCredito"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgDetCreNeg.Columns["nMontoCuota"].DefaultCellStyle.Format     = "##,##0.00";
            dtgDetCreNeg.Columns["nSaldoCredito"].DefaultCellStyle.Format   = "##,##0.00";

            foreach (DataGridViewColumn column in dtgDetCreFam.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetCreFam.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgDetCreFam.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgDetCreFam.ReadOnly = false;

            dtgDetCreFam.Columns["IdDetCrediNego"].Visible = false;
            dtgDetCreFam.Columns["IdEvalEmp"].Visible = false;
            dtgDetCreFam.Columns["IdPerteneceDeuda"].Visible = false;
            dtgDetCreFam.Columns["cDesInstitucion"].Visible = true;
            dtgDetCreFam.Columns["nTotCuotas"].Visible = true;
            dtgDetCreFam.Columns["nCuoPagdas"].Visible = true;
            dtgDetCreFam.Columns["nCuoPendientes"].Visible = true;
            dtgDetCreFam.Columns["nMontoCuota"].Visible = true;
            dtgDetCreFam.Columns["nSaldoCredito"].Visible = true;
            dtgDetCreFam.Columns["lVigente"].Visible = false;

            dtgDetCreFam.Columns["cDesInstitucion"].ReadOnly = false;
            dtgDetCreFam.Columns["nTotCuotas"].ReadOnly = false;
            dtgDetCreFam.Columns["nCuoPagdas"].ReadOnly = false;
            dtgDetCreFam.Columns["nCuoPendientes"].ReadOnly = true;
            dtgDetCreFam.Columns["nMontoCuota"].ReadOnly = false;
            dtgDetCreFam.Columns["nSaldoCredito"].ReadOnly = false;

            dtgDetCreFam.Columns["cDesInstitucion"].HeaderText = "Institución";
            dtgDetCreFam.Columns["nTotCuotas"].HeaderText = "N° Cuotas";
            dtgDetCreFam.Columns["nCuoPagdas"].HeaderText = "Cuo. Pag.";
            dtgDetCreFam.Columns["nCuoPendientes"].HeaderText = "Cuo. Pend.";
            dtgDetCreFam.Columns["nMontoCuota"].HeaderText = "Mon. Cuota";
            dtgDetCreFam.Columns["nSaldoCredito"].HeaderText = "Saldo Capital";

            dtgDetCreFam.Columns["cDesInstitucion"].ToolTipText = "Institución";
            dtgDetCreFam.Columns["nTotCuotas"].ToolTipText = "Número Total de Cuotas";
            dtgDetCreFam.Columns["nCuoPagdas"].ToolTipText = "Número de Cuotas Pagadas";
            dtgDetCreFam.Columns["nCuoPendientes"].ToolTipText = "Número de Cuotas Pendientes";
            dtgDetCreFam.Columns["nMontoCuota"].ToolTipText = "Monto de la Cuota";
            dtgDetCreFam.Columns["nSaldoCredito"].ToolTipText = "Saldo capital del Crédito";

            dtgDetCreFam.Columns["nTotCuotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreFam.Columns["nCuoPagdas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreFam.Columns["nCuoPendientes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreFam.Columns["nMontoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDetCreFam.Columns["nSaldoCredito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDetCreFam.Columns["cDesInstitucion"].FillWeight = 75;
            dtgDetCreFam.Columns["nTotCuotas"].FillWeight = 40;
            dtgDetCreFam.Columns["nCuoPagdas"].FillWeight = 50;
            dtgDetCreFam.Columns["nCuoPendientes"].FillWeight = 45;
            dtgDetCreFam.Columns["nMontoCuota"].FillWeight = 50;
            dtgDetCreFam.Columns["nSaldoCredito"].FillWeight = 50;

            dtgDetCreFam.Columns["nCuoPendientes"].DefaultCellStyle.BackColor = Color.SkyBlue;
            //dtgDetCreFam.Columns["nSaldoCredito"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgDetCreFam.Columns["nMontoCuota"].DefaultCellStyle.Format = "##,##0.00";
            dtgDetCreFam.Columns["nSaldoCredito"].DefaultCellStyle.Format = "##,##0.00";
        } 

        #endregion

        #region DtgCredFam

        private void btnAgrDetCredFam_Click(object sender, EventArgs e)
        {
            DataRow dr = dtDetCreUniFam.NewRow();
            dr["IdDetCrediNego"] = -1;
            dr["IdPerteneceDeuda"] = 2;
            dr["cDesInstitucion"] = "";
            dr["nTotCuotas"] = 0;
            dr["nCuoPagdas"] = 0;
            dr["nCuoPendientes"] = 0;
            dr["nMontoCuota"] = 0;
            dr["nSaldoCredito"] = 0;
            dr["lVigente"] = 1;
            dtDetCreUniFam.Rows.Add(dr);
        }

        private void btnQuitDetCredFam_Click(object sender, EventArgs e)
        {
            if (this.dtgDetCreFam.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetCreFam.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgDetCreFam.Rows[nFilaActual].Cells["IdDetCrediNego"].Value) == -1)
                {
                    dtgDetCreFam.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgDetCreFam.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgDetCreFam.Focus();
                TotalFinalCredFamliar();
                ProcessTabKey(true);
            }
        }

        private void dtgDetCreFam_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.In("nTotCuotas","nCuoPagdas"))
            {
                TextBox txtboxEnteros = e.Control as TextBox;
                txtboxEnteros.MaxLength = 8;
                if (txtboxEnteros != null)
                {
                    txtboxEnteros.KeyPress -= new KeyPressEventHandler(txtboxEnterosdtgDetCreFam_KeyPress);
                    txtboxEnteros.KeyPress += new KeyPressEventHandler(txtboxEnterosdtgDetCreFam_KeyPress);

                    txtboxEnteros.Leave -= new EventHandler(txtboxNumdtgDetCreFam_Leave);
                    txtboxEnteros.Leave += new EventHandler(txtboxNumdtgDetCreFam_Leave);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.In("nMontoCuota", "nSaldoCredito"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgDetCreFam_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgDetCreFam_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgDetCreFam_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgDetCreFam_Leave);
                }
            }
        }

        private void txtboxRealesdtgDetCreFam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgDetCreFam.CurrentCell.OwningColumn.Name.In("nMontoCuota", "nSaldoCredito"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxEnterosdtgDetCreFam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgDetCreFam.CurrentCell.OwningColumn.Name.Equals("nTotCuotas") ||
                dtgDetCreFam.CurrentCell.OwningColumn.Name.Equals("nCuoPagdas"))
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

        private void txtboxNumdtgDetCreFam_Leave(object sender, EventArgs e)
        {
            if (dtgDetCreFam.CurrentCell.OwningColumn.Name.In("nMontoCuota", "nTotCuotas", "nCuoPagdas", "nSaldoCredito"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgDetCreFam.CurrentCell != null)
                    {
                        dtgDetCreFam.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void dtgDetCreFam_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgDetCreFam.Focus();
            dtgDetCreFam["cDesInstitucion", e.RowIndex].Selected = true;
        }

        private void dtgDetCreFam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgDetCreFam.Columns[e.ColumnIndex].Name.In("nTotCuotas", "nCuoPagdas", "nMontoCuota", "nSaldoCredito"))
            {
                CalcularTotalFilaCredFamiliar(e.RowIndex);
            }
        }

        private void CalcularTotalFilaCredFamiliar(int index)
        {
            int nTotCuotas = 0;
            int nCuoPagdas = 0;
            int nCuoPendientes = 0;
            decimal nMontoCuota = 0.00M;

            if (dtgDetCreFam.Rows[index].Cells["nTotCuotas"].Value == DBNull.Value)
            {
                dtgDetCreFam.Rows[index].Cells["nTotCuotas"].Value = 0;
            }
            if (dtgDetCreFam.Rows[index].Cells["nCuoPagdas"].Value == DBNull.Value)
            {
                dtgDetCreFam.Rows[index].Cells["nCuoPagdas"].Value = 0;
            }
            if (dtgDetCreFam.Rows[index].Cells["nMontoCuota"].Value == DBNull.Value)
            {
                dtgDetCreFam.Rows[index].Cells["nMontoCuota"].Value = 0;
            }
            if (dtgDetCreFam.Rows[index].Cells["nSaldoCredito"].Value == DBNull.Value)
            {
                dtgDetCreFam.Rows[index].Cells["nSaldoCredito"].Value = 0;
            }

            nTotCuotas = Convert.ToInt32(dtgDetCreFam.Rows[index].Cells["nTotCuotas"].Value);
            nCuoPagdas = Convert.ToInt32(dtgDetCreFam.Rows[index].Cells["nCuoPagdas"].Value);

            //Quitar evento para que el flujo continue con normalidad
            dtgDetCreFam.CellValueChanged -= new DataGridViewCellEventHandler(dtgDetCreFam_CellValueChanged);
            dtgDetCreFam.Rows[index].Cells["nCuoPendientes"].Value = nTotCuotas - nCuoPagdas;

            nCuoPendientes = Convert.ToInt32(dtgDetCreFam.Rows[index].Cells["nCuoPendientes"].Value);
            nMontoCuota = Convert.ToDecimal(dtgDetCreFam.Rows[index].Cells["nMontoCuota"].Value);

            //dtgDetCreFam.Rows[index].Cells["nSaldoCredito"].Value = nCuoPendientes * nMontoCuota;
            dtgDetCreFam.CellValueChanged += new DataGridViewCellEventHandler(dtgDetCreFam_CellValueChanged);

            TotalFinalCredFamliar();
        }

        private void TotalFinalCredFamliar()
        {
            decimal nTotMontoCuota = 0.00M;
            decimal nTotSaldoCred = 0.00M;

            foreach (DataGridViewRow row in dtgDetCreFam.Rows)
            {
                nTotMontoCuota += Convert.ToDecimal(row.Cells["nMontoCuota"].Value);
                nTotSaldoCred += Convert.ToDecimal(row.Cells["nSaldoCredito"].Value);
            }
            txtTotMontCuotaFam.Text = nTotMontoCuota.ToString("##,##0.00");
            txtTotSalCredFam.Text = nTotSaldoCred.ToString("##,##0.00");
        }

        #endregion

        #region DtgGastPers

        private void btnAgrGastPers_Click(object sender, EventArgs e)
        {
            DataRow dr = dtDetGastosPersonal.NewRow();
            dr["IdDetPersonaNego"] = -1;
            dr["nCantiPersonas"] = 0;
            dr["nSueldoPuesto"] = 0.00;
            dr["nSubTotPuesto"] = 0.00;
            dr["lVigente"] = 1;
            dtDetGastosPersonal.Rows.Add(dr);
        }

        private void btnQuitGastPers_Click(object sender, EventArgs e)
        {
            if (this.dtgGasPersonal.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgGasPersonal.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgGasPersonal.Rows[nFilaActual].Cells["IdDetPersonaNego"].Value) == -1)
                {
                    dtgGasPersonal.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgGasPersonal.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgGasPersonal.Focus();
                TotalFinalGasPersonal();
                ProcessTabKey(true);
            }
        }

        private void dtgGasPersonal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nCantiPersonas"))
            {
                TextBox txtboxEnteros = e.Control as TextBox;
                txtboxEnteros.MaxLength = 8;
                if (txtboxEnteros != null)
                {
                    txtboxEnteros.KeyPress -= new KeyPressEventHandler(txtboxEnterosdtgGasPersonal_KeyPress);
                    txtboxEnteros.KeyPress += new KeyPressEventHandler(txtboxEnterosdtgGasPersonal_KeyPress);

                    txtboxEnteros.Leave -= new EventHandler(txtboxNumdtgGasPersonal_Leave);
                    txtboxEnteros.Leave += new EventHandler(txtboxNumdtgGasPersonal_Leave);
                }
            }

            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nSueldoPuesto"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgGasPersonal_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgGasPersonal_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgGasPersonal_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgGasPersonal_Leave);
                }
            }
        }

        private void txtboxRealesdtgGasPersonal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgGasPersonal.CurrentCell.OwningColumn.Name.Equals("nSueldoPuesto"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxEnterosdtgGasPersonal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgGasPersonal.CurrentCell.OwningColumn.Name.Equals("nCantiPersonas"))
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

        private void txtboxNumdtgGasPersonal_Leave(object sender, EventArgs e)
        {
            if (dtgGasPersonal.CurrentCell.OwningColumn.Name.Equals("nCantiPersonas") ||
                dtgGasPersonal.CurrentCell.OwningColumn.Name.Equals("nSueldoPuesto"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgGasPersonal.CurrentCell != null)
                    {
                        dtgGasPersonal.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void dtgGasPersonal_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgGasPersonal.Focus();
            dtgGasPersonal["cDescriPuesto", e.RowIndex].Selected = true;
        }

        private void dtgGasPersonal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgGasPersonal.Columns[e.ColumnIndex].Name.Equals("nCantiPersonas") ||
                dtgGasPersonal.Columns[e.ColumnIndex].Name.Equals("nSueldoPuesto"))
            {
                CalcularTotalFilaGasPersonal(e.RowIndex);
            }
        }

        private void CalcularTotalFilaGasPersonal(int index)
        {
            int nCantiPersonas = 0;
            decimal nSueldoPuesto = 0.00M;

            if (dtgGasPersonal.Rows[index].Cells["nCantiPersonas"].Value == DBNull.Value)
            {
                dtgGasPersonal.Rows[index].Cells["nCantiPersonas"].Value = 0;
            }
            if (dtgGasPersonal.Rows[index].Cells["nSueldoPuesto"].Value == DBNull.Value)
            {
                dtgGasPersonal.Rows[index].Cells["nSueldoPuesto"].Value = 0;
            }

            nCantiPersonas  = Convert.ToInt32(dtgGasPersonal.Rows[index].Cells["nCantiPersonas"].Value);
            nSueldoPuesto   = Convert.ToDecimal(dtgGasPersonal.Rows[index].Cells["nSueldoPuesto"].Value);

            dtgGasPersonal.CellValueChanged -= new DataGridViewCellEventHandler(dtgGasPersonal_CellValueChanged);
            dtgGasPersonal.Rows[index].Cells["nSubTotPuesto"].Value = nCantiPersonas * nSueldoPuesto;
            dtgGasPersonal.CellValueChanged += new DataGridViewCellEventHandler(dtgGasPersonal_CellValueChanged); 

            TotalFinalGasPersonal();
        }

        private void TotalFinalGasPersonal()
        {
            decimal nTotPuesto = 0.00M;
            
            foreach (DataGridViewRow row in dtgGasPersonal.Rows)
            {
                nTotPuesto += Convert.ToDecimal(row.Cells["nSubTotPuesto"].Value);
            }
            txtTotPuesto.Text = nTotPuesto.ToString("##,##0.00");
        }

        private void FormatoGridDetGastPersonal()
        {
            foreach (DataGridViewColumn column in dtgGasPersonal.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGasPersonal.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgGasPersonal.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgGasPersonal.ReadOnly = false;

            dtgGasPersonal.Columns["IdDetPersonaNego"].Visible = false;
            dtgGasPersonal.Columns["IdEvalEmp"].Visible = false;
            dtgGasPersonal.Columns["cDescriPuesto"].Visible = true;
            dtgGasPersonal.Columns["nCantiPersonas"].Visible = true;
            dtgGasPersonal.Columns["nSueldoPuesto"].Visible = true;
            dtgGasPersonal.Columns["nSubTotPuesto"].Visible = true;
            dtgGasPersonal.Columns["lVigente"].Visible = false;

            dtgGasPersonal.Columns["cDescriPuesto"].ReadOnly = false;
            dtgGasPersonal.Columns["nCantiPersonas"].ReadOnly = false;
            dtgGasPersonal.Columns["nSueldoPuesto"].ReadOnly = false;
            dtgGasPersonal.Columns["nSubTotPuesto"].ReadOnly = true;

            dtgGasPersonal.Columns["cDescriPuesto"].HeaderText = "Puesto";
            dtgGasPersonal.Columns["nCantiPersonas"].HeaderText = "Cant. Personas";
            dtgGasPersonal.Columns["nSueldoPuesto"].HeaderText = "Sueldo";
            dtgGasPersonal.Columns["nSubTotPuesto"].HeaderText = "SubTotal";

            dtgGasPersonal.Columns["cDescriPuesto"].ToolTipText = "Descripcion del Puesto";
            dtgGasPersonal.Columns["nCantiPersonas"].ToolTipText = "Cantidad de Personas";
            dtgGasPersonal.Columns["nSueldoPuesto"].ToolTipText = "Sueldo del Puesto";
            dtgGasPersonal.Columns["nSubTotPuesto"].ToolTipText = "SubTotal";

            dtgGasPersonal.Columns["nCantiPersonas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGasPersonal.Columns["nSueldoPuesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGasPersonal.Columns["nSubTotPuesto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGasPersonal.Columns["cDescriPuesto"].FillWeight = 100;
            dtgGasPersonal.Columns["nCantiPersonas"].FillWeight = 30;
            dtgGasPersonal.Columns["nSueldoPuesto"].FillWeight = 40;
            dtgGasPersonal.Columns["nSubTotPuesto"].FillWeight = 50;

            dtgGasPersonal.Columns["nSubTotPuesto"].DefaultCellStyle.BackColor = Color.SkyBlue;

            dtgGasPersonal.Columns["nSueldoPuesto"].DefaultCellStyle.Format = "##,##0.00";
            dtgGasPersonal.Columns["nSubTotPuesto"].DefaultCellStyle.Format = "##,##0.00";
        }

        #endregion

        #region DtgGastNego

        private void btnAgrGastServNeg_Click(object sender, EventArgs e)
        {
            DataRow dr = dtGastServNego.NewRow();
            dr["IdDetGastosNego"] = -1;
            dr["IdPerteneceGasto"] = 1;
            dr["nImporteGas"] = 0;
            dr["lVigente"] = 1;
            dtGastServNego.Rows.Add(dr);
        }

        private void btnQuitGastServNeg_Click(object sender, EventArgs e)
        {
            if (this.dtgGasNego.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgGasNego.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgGasNego.Rows[nFilaActual].Cells["IdDetGastosNego"].Value) == -1)
                {
                    dtgGasNego.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgGasNego.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgGasNego.Focus();
                ProcessTabKey(true);
                TotalFinalGastNegocio();
            }
        }

        private void dtgGasNego_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nImporteGas"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgGasNego_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgGasNego_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgGasNego_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgGasNego_Leave);
                }
            }
        }

        private void txtboxRealesdtgGasNego_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgGasNego.CurrentCell.OwningColumn.Name.Equals("nImporteGas"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxNumdtgGasNego_Leave(object sender, EventArgs e)
        {
            if (dtgGasNego.CurrentCell.OwningColumn.Name.Equals("nImporteGas"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgGasNego.CurrentCell != null)
                    {
                        dtgGasNego.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void dtgGasNego_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgGasNego.Focus();
            dtgGasNego["cDescriGas", e.RowIndex].Selected = true;
        }

        private void dtgGasNego_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgGasNego.Columns[e.ColumnIndex].Name.Equals("nImporteGas"))
            {
                TotalFinalGastNegocio();
            }
        }   

        private void TotalFinalGastNegocio()
        {
            //txtTotGastosNeg.Text = "0.00";
            decimal nTotImporteGas = 0.00M;

            foreach (DataGridViewRow row in dtgGasNego.Rows)
            {
                if (row.Cells["nImporteGas"].Value == DBNull.Value)
                {
                    row.Cells["nImporteGas"].Value = 0;
                }
                nTotImporteGas += Convert.ToDecimal(row.Cells["nImporteGas"].Value);
            }

            txtTotGastosNeg.Text = nTotImporteGas.ToString("##,##0.00");
        }

        private void FormatoGridDetGastos()
        {
            foreach (DataGridViewColumn column in dtgGasNego.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGasNego.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgGasNego.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgGasNego.ReadOnly = false;

            dtgGasNego.Columns["IdDetGastosNego"].Visible = false;
            dtgGasNego.Columns["IdEvalEmp"].Visible = false;
            dtgGasNego.Columns["IdPerteneceGasto"].Visible = false;
            dtgGasNego.Columns["cDescriGas"].Visible = true;
            dtgGasNego.Columns["nImporteGas"].Visible = true;
            dtgGasNego.Columns["lVigente"].Visible = false;

            dtgGasNego.Columns["cDescriGas"].ReadOnly = false;
            dtgGasNego.Columns["nImporteGas"].ReadOnly = false;

            dtgGasNego.Columns["cDescriGas"].HeaderText = "Descripcion";
            dtgGasNego.Columns["nImporteGas"].HeaderText = "Importe";

            dtgGasNego.Columns["cDescriGas"].ToolTipText = "Descripcion del Gasto";
            dtgGasNego.Columns["nImporteGas"].ToolTipText = "Descripcion del Importe";

            dtgGasNego.Columns["nImporteGas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGasNego.Columns["cDescriGas"].FillWeight = 100;
            dtgGasNego.Columns["nImporteGas"].FillWeight = 40;

            dtgGasNego.Columns["nImporteGas"].DefaultCellStyle.Format = "##,##0.00";


            foreach (DataGridViewColumn column in dtgGasUniFam.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGasUniFam.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgGasUniFam.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgGasUniFam.ReadOnly = false;

            dtgGasUniFam.Columns["IdDetGastosNego"].Visible = false;
            dtgGasUniFam.Columns["IdEvalEmp"].Visible = false;
            dtgGasUniFam.Columns["IdPerteneceGasto"].Visible = false;
            dtgGasUniFam.Columns["cDescriGas"].Visible = true;
            dtgGasUniFam.Columns["nImporteGas"].Visible = true;
            dtgGasUniFam.Columns["lVigente"].Visible = false;

            dtgGasUniFam.Columns["cDescriGas"].ReadOnly = false;
            dtgGasUniFam.Columns["nImporteGas"].ReadOnly = false;

            dtgGasUniFam.Columns["cDescriGas"].HeaderText = "Descripcion";
            dtgGasUniFam.Columns["nImporteGas"].HeaderText = "Importe";

            dtgGasUniFam.Columns["cDescriGas"].ToolTipText = "Descripcion del Gasto";
            dtgGasUniFam.Columns["nImporteGas"].ToolTipText = "Importe del Gasto";

            dtgGasUniFam.Columns["nImporteGas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGasUniFam.Columns["cDescriGas"].FillWeight = 100;
            dtgGasUniFam.Columns["nImporteGas"].FillWeight = 40;

            dtgGasUniFam.Columns["nImporteGas"].DefaultCellStyle.Format = "##,##0.00";

        }

        #endregion

        #region DtgGastFam

        private void btnQuitGastUniFam_Click(object sender, EventArgs e)
        {
            if (this.dtgGasUniFam.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgGasUniFam.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgGasUniFam.Rows[nFilaActual].Cells["IdDetGastosNego"].Value) == -1)
                {
                    dtgGasUniFam.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgGasUniFam.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgGasUniFam.Focus();               
                ProcessTabKey(true);
                TotalFinalGasUniFam();
            }
        }

        private void btnAgrGastUniFam_Click(object sender, EventArgs e)
        {
            DataRow dr = dtGastUniFam.NewRow();
            dr["IdDetGastosNego"] = -1;
            dr["IdPerteneceGasto"] = 1;
            dr["nImporteGas"] = 0;
            dr["lVigente"] = 1;
            dtGastUniFam.Rows.Add(dr);
        }

        private void dtgGasUniFam_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nImporteGas"))
            {
                TextBox txtboxReales = e.Control as TextBox;
                txtboxReales.MaxLength = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgGasUniFam_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgGasUniFam_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgGasUniFam_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgGasUniFam_Leave);
                }
            }
        }

        private void txtboxRealesdtgGasUniFam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgGasUniFam.CurrentCell.OwningColumn.Name.Equals("nImporteGas"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxNumdtgGasUniFam_Leave(object sender, EventArgs e)
        {
            if (dtgGasUniFam.CurrentCell.OwningColumn.Name.Equals("nImporteGas"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgGasUniFam.CurrentCell != null) dtgGasUniFam.CurrentCell.Value = 0;
                }
            }
        }

        private void dtgGasUniFam_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtgGasUniFam.Focus();
            dtgGasUniFam["cDescriGas", e.RowIndex].Selected = true;
        }

        private void dtgGasUniFam_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dtgGasUniFam.Columns[e.ColumnIndex].Name.Equals("nImporteGas"))
            {
                TotalFinalGasUniFam();
            }
        }

        private void TotalFinalGasUniFam()
        {
            txtTotGastosFam.Text = "0.00";
            decimal nTotImporteGas = 0.00M;

            foreach (DataGridViewRow row in dtgGasUniFam.Rows)
            {
                if (row.Cells["nImporteGas"].Value == DBNull.Value)
                {
                    row.Cells["nImporteGas"].Value = 0;
                }
                nTotImporteGas += Convert.ToDecimal(row.Cells["nImporteGas"].Value);
            }

            txtTotGastosFam.Text = nTotImporteGas.ToString("##,##0.00");
        }

        #endregion

        #region DtgEstPerdGanan

        private void dtgEstPerdGanan_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 7 && e.ColumnIndex == 2)//Otros Ingresos de la Unidad Económica Familiar
            {
                dtgEstPerdGanan.EndEdit();
                ActualizarEstPerdGanan();
                ActualizaFlujoCajaPrimerPeriodo();
            }
        }

        private void dtgEstPerdGanan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("nMontoParti"))
            {
                TextBox txtboxReales    = e.Control as TextBox;
                txtboxReales.MaxLength  = 8;
                if (txtboxReales != null)
                {
                    txtboxReales.KeyPress -= new KeyPressEventHandler(txtboxRealesdtgEstPerdGanan_KeyPress);
                    txtboxReales.KeyPress += new KeyPressEventHandler(txtboxRealesdtgEstPerdGanan_KeyPress);

                    txtboxReales.Leave -= new EventHandler(txtboxNumdtgEstPerdGanan_Leave);
                    txtboxReales.Leave += new EventHandler(txtboxNumdtgEstPerdGanan_Leave);
                }
            }
        }

        private void txtboxRealesdtgEstPerdGanan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgEstPerdGanan.CurrentCell.OwningColumn.Name.Equals("nMontoParti"))
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
                    var fff = (from L in ((DataGridViewTextBoxEditingControl)sender).Text.ToString()
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
        }

        private void txtboxNumdtgEstPerdGanan_Leave(object sender, EventArgs e)
        {
            if (dtgEstPerdGanan.CurrentCell.OwningColumn.Name.Equals("nMontoParti"))
            {
                if (string.IsNullOrEmpty(((TextBox)sender).Text))
                {
                    if (dtgEstPerdGanan.CurrentCell != null)
                    {
                        dtgEstPerdGanan.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void FormatoEstPerdGanan()
        {
            foreach (DataGridViewColumn column in dtgEstPerdGanan.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgEstPerdGanan.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgEstPerdGanan.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgEstPerdGanan.ReadOnly = false;

            if (dtgEstPerdGanan.Columns.Contains("IdEstPerdiGana"))
            {
                dtgEstPerdGanan.Columns["IdEstPerdiGana"].Visible = false;
            }

            if (dtgEstPerdGanan.Columns.Contains("IdEvalEmp"))
            {
                dtgEstPerdGanan.Columns["IdEvalEmp"].Visible = false;
            }

            if (dtgEstPerdGanan.Columns.Contains("IdPlantiEstPerdiGana"))
            {
                dtgEstPerdGanan.Columns["IdPlantiEstPerdiGana"].Visible = false;
            }

            dtgEstPerdGanan.Columns["cDescriPartida"].Visible   = true;
            dtgEstPerdGanan.Columns["nMontoParti"].Visible      = true;
            dtgEstPerdGanan.Columns["cTipoRegPartida"].Visible  = false;
            dtgEstPerdGanan.Columns["cTipoIngEgrParti"].Visible = false;
            dtgEstPerdGanan.Columns["nPorcenParti"].Visible     = false;
            dtgEstPerdGanan.Columns["cCodigoParti"].Visible     = false;
            dtgEstPerdGanan.Columns["cFormuCalcParti"].Visible  = false;
            dtgEstPerdGanan.Columns["lVigente"].Visible         = false;

            dtgEstPerdGanan.Columns["cDescriPartida"].ReadOnly  = true;
            dtgEstPerdGanan.Columns["nMontoParti"].ReadOnly     = false;

            dtgEstPerdGanan.Columns["cDescriPartida"].HeaderText= "Descripción";
            dtgEstPerdGanan.Columns["nMontoParti"].HeaderText   = "Monto";

            dtgEstPerdGanan.Columns["cDescriPartida"].FillWeight= 300;
            dtgEstPerdGanan.Columns["nMontoParti"].FillWeight   = 150;

            dtgEstPerdGanan.Columns["nMontoParti"].DefaultCellStyle.Format = "##,##0.00";

            dtgEstPerdGanan.Columns["nMontoParti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewRow row in dtgEstPerdGanan.Rows)
            {
                if (row.Cells["cTipoRegPartida"].Value.ToString().Equals("C"))
                {
                    row.Cells["nMontoParti"].ReadOnly = true;
                    //row.Cells["nMontoParti"].Style.BackColor = Color.SkyBlue;
                }
                if (row.Cells["cTipoRegPartida"].Value.ToString().Equals("I"))
                {
                    row.Cells["nMontoParti"].Style.BackColor = Color.Yellow;
                }

                if (row.Cells["cDescriPartida"].Value.Equals("Utilidad Bruta") ||
                    row.Cells["cDescriPartida"].Value.Equals("Utilidad Operativa") ||
                    row.Cells["cDescriPartida"].Value.Equals("Utilidad Neta")                 
                    )
                {
                    row.Cells["cDescriPartida"].Style.BackColor = Color.SkyBlue;
                    row.Cells["nMontoParti"].Style.BackColor = Color.SkyBlue;
                }
            }
        }  

        private void ActualizarEstPerdGanan()
        {
            foreach (DataGridViewRow row in dtgEstPerdGanan.Rows)
            {
                switch (Convert.ToInt32(row.Cells["IdPlantiEstPerdiGana"].Value))
                {
                    case 1://Monto de Ventas
                        if (string.IsNullOrEmpty(txtTotVentas.Text)) txtTotVentas.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotVentas.Text);
                        break;
                    case 2://Costo Total de Compras y/o Producción
                        if (string.IsNullOrEmpty(txtTotCostoCompra.Text)) txtTotCostoCompra.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotCostoCompra.Text);
                        break;
                    case 3://Utilidad Bruta
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 0].Value) -
                                                        Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 1].Value);
                        break;
                    case 4://Gastos Operativos
                        if (string.IsNullOrEmpty(txtTotPuesto.Text)) txtTotPuesto.Text = "0.00";
                        if (string.IsNullOrEmpty(txtTotGastosNeg.Text)) txtTotGastosNeg.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotPuesto.Text) + Convert.ToDecimal(txtTotGastosNeg.Text);
                        break;
                    case 5://Utilidad Operativa
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 2].Value) -
                                                         Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 3].Value);
                        break;
                    case 6://Obligaciones del Negocio
                        if (string.IsNullOrEmpty(txtTotMontCuotaNeg.Text)) txtTotMontCuotaNeg.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotMontCuotaNeg.Text);
                        break;
                    case 7://Utilidad Neta
                        row.Cells["nMontoParti"].Value =Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 4].Value) -
                                                        Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 5].Value);
                        break;
                    case 9://Obligaciones de la Unidad Económica Familiar
                        if (string.IsNullOrEmpty(txtTotMontCuotaFam.Text)) txtTotMontCuotaFam.Text = "0.00";
                        row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotMontCuotaFam.Text);
                        break;
                    case 10://Gastos de la Unidad Económica Familiar
                        if (string.IsNullOrEmpty(txtTotGastosFam.Text)) txtTotGastosFam.Text = "0.00";
                         row.Cells["nMontoParti"].Value = Convert.ToDecimal(txtTotGastosFam.Text);
                        break;
                    case 11://Excedente la Unidad Económica Familiar'
                        row.Cells["nMontoParti"].Value =    Convert.ToDecimal(dtgEstPerdGanan["nMontoParti", 6].Value) +
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
            CalcularRatios();
        }

        private void EditarDataTableEstPerdganan()
        {
            if (!dtgEstPerdGanan.Columns.Contains("IdEstPerdiGana"))
            {
                dtEstPerdGana.Columns.Add("IdEstPerdiGana", typeof(int), "-1");
            }

            if (!dtgEstPerdGanan.Columns.Contains("IdEvalEmp"))
            {
                dtEstPerdGana.Columns.Add("IdEvalEmp", typeof(int), "-1");
            }
        }

        #endregion

        #region DtgDetalleFotos

        private void dtgDetalleFotos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (File.Exists(dtgDetalleFotos.CurrentRow.Cells["cRutaFoto"].Value.ToString()))
            {
                FileStream fs = new System.IO.FileStream(dtgDetalleFotos.CurrentRow.Cells["cRutaFoto"].Value.ToString(), FileMode.Open, FileAccess.Read);
                pbFotos.Image = Image.FromStream(fs);
                fs.Close();
            }

        }

        private void btnAgrFoto_Click(object sender, EventArgs e)
        {
            Decimal nAltoImageMax = pbFotos.Size.Height;
            Decimal nAnchoImagemax = pbFotos.Size.Width;
            Decimal nAltoImage;
            Decimal nAnchoImage;
            int newnAltoImage;
            int newnAnchoImage;
            Decimal nPorcenReduce = 1;
            string targetPath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Fotos en JPG|*.jpg";
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbFotos.Image = Image.FromFile(dialog.FileName);
                nAltoImage = pbFotos.Image.Size.Height;
                nAnchoImage = pbFotos.Image.Size.Width;
                if (((nAltoImageMax - nAltoImage) < 0) || (nAnchoImagemax - nAnchoImage) < 0)
                {
                    if (Math.Abs(nAltoImage - nAltoImageMax) > Math.Abs(nAnchoImage - nAnchoImagemax))
                    {
                        if (nAltoImageMax > nAltoImage)
                        {
                            nPorcenReduce = nAltoImage / nAltoImageMax;
                        }
                        else
                        {
                            nPorcenReduce = nAltoImageMax / nAltoImage;
                        }
                    }
                    else
                    {
                        if (nAnchoImagemax > nAnchoImage)
                        {
                            nPorcenReduce = nAnchoImage / nAnchoImagemax;
                        }
                        else
                        {
                            nPorcenReduce = nAnchoImagemax / nAnchoImage;
                        }
                    }
                }

                newnAltoImage = Convert.ToInt16(nAltoImage * nPorcenReduce);
                newnAnchoImage = Convert.ToInt16(nAnchoImage * nPorcenReduce);
                clsFunUtiles Funciones = new clsFunUtiles();
                Image newimg = Funciones.ResizeImage(this.pbFotos.Image, newnAnchoImage, newnAltoImage);
                this.pbFotos.Image = newimg;
                this.pbFotos.Refresh();
                if (string.IsNullOrEmpty(cRutaFotos))
                {
                    targetPath = clsVarApl.dicVarGen["cUrlFotosEvaEmp"] + @"\EvaEmp_" + Convert.ToInt32(this.conBusCli.txtCodCli.Text) + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss");//Variable global, ruta en la que se guardarán las fotos de la evaluación en cada agencia
                    cRutaFotos = targetPath;
                }
                string fileName = "Foto_" + nNroFoto + ".Jpg";//Nombre = Número de evaluación + un secuencial de foto
                string destFile = System.IO.Path.Combine(cRutaFotos, fileName);
                if (!System.IO.Directory.Exists(cRutaFotos))
                {
                    System.IO.Directory.CreateDirectory(cRutaFotos);
                }
                DataRow dr = dtDetalleFotos.NewRow();
                dr["cRutaFoto"] = destFile;
                dr["lVigente"] = 1;
                dtDetalleFotos.Rows.Add(dr);
                dtgDetalleFotos.Focus();
                newimg.Save(destFile);
                nNroFoto++;
            }

        }

        private void btnQuitFoto_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleFotos.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la foto que desee eliminar.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgDetalleFotos.SelectedCells[0].RowIndex);
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar esta imagen?", "Registro de Evaluación Empresarial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Identificando la ruta de la foto
                    string cRutaFoto = dtgDetalleFotos.CurrentRow.Cells["cRutaFoto"].Value.ToString();

                    //Identificando el Nombre de la Foto
                    string cNomFoto = cRutaFoto.Substring(cRutaFoto.Length - 13, 13);
                    while (cNomFoto.Substring(0, 1) != "F")
                    {
                        cNomFoto = cNomFoto.Substring(1, cNomFoto.Length - 1);
                    }
                    string cNombreArchivoABorrar = cRutaFotos + @"\" + cNomFoto;
                    //--->

                    if (System.IO.Directory.Exists(cRutaFotos))
                    {
                        pbFotos.Image = null;
                        System.IO.File.Delete(cNombreArchivoABorrar);//Eliminando la foto del directorio temporal


                        dtgDetalleFotos.Rows.Remove(dtgDetalleFotos.Rows[nFilaActual]);
                    }
                    else
                    {
                        MessageBox.Show("El archivo no se encuentra en la ruta especificada", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }

        private void FormatoGridDetalleFotos()
        {
            foreach (DataGridViewColumn column in dtgDetalleFotos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetalleFotos.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dtgDetalleFotos.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dtgDetalleFotos.ReadOnly = false;

            dtgDetalleFotos.Columns["IdFotoEvaEmp"].Visible = false;
            dtgDetalleFotos.Columns["IdEvalEmp"].Visible = false;
            dtgDetalleFotos.Columns["cDescriFoto"].Visible = true;
            dtgDetalleFotos.Columns["cRutaFoto"].Visible = false;
            dtgDetalleFotos.Columns["lVigente"].Visible = false;

            dtgDetalleFotos.Columns["cDescriFoto"].HeaderText = "Descripción de Foto";

            dtgDetalleFotos.Columns["cDescriFoto"].ReadOnly = false;
        }

        #endregion

        #region DtgIntervinientes

        private void btnAgrInterv_Click(object sender, EventArgs e)
        {
            DataRow dr = dtIntervinientes.NewRow();
            dr["IdTipoIntervEva"] = -1;
            dr["IdEvaluacion"] = 0;
            dr["lVigente"] = 1;
            dtIntervinientes.Rows.Add(dr);
        }

        private void btnQuitInterv_Click(object sender, EventArgs e)
        {
            if (this.dtgIntervinientes.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el interviniente a eliminar", "Registro de Evaluacion Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgIntervinientes.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtIntervinientes.Rows[nFilaActual]["IdTipoIntervEva"]) == -1)
                {
                    dtIntervinientes.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtIntervinientes.Rows[nFilaActual]["lVigente"] = 0;
                }
                this.dtgIntervinientes.Focus();
                ProcessTabKey(true);
            }
        }

        private void dtgIntervinientes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name.Equals("cboTipoInterv"))
            {
                ComboBox cboTipoInterv = e.Control as ComboBox;
                if (cboMoneda != null)
                {
                    cboTipoInterv.SelectionChangeCommitted -= new EventHandler(cboTipoInterv_SelectionChangeCommitted);
                    cboTipoInterv.SelectionChangeCommitted += new EventHandler(cboTipoInterv_SelectionChangeCommitted);
                }
            }
            
        }

        private void cboTipoInterv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dtgIntervinientes.CurrentCell.OwningColumn.Name.Equals("cboTipoInterv"))
            {
                if (dtgIntervinientes.RowCount > 1)
                {
                    DataGridViewComboBoxEditingControl cboTipoInterv = sender as DataGridViewComboBoxEditingControl;
                    if (cboTipoInterv != null)
                    {
                        if (cboTipoInterv.SelectedValue is Int32)
                        {
                            int value = Convert.ToInt32(cboTipoInterv.SelectedValue);
                            foreach (DataGridViewRow row in dtgIntervinientes.Rows)
                            {
                                if (row.Cells["IdTipoInterv"].Value != DBNull.Value)
                                {
                                    if (Convert.ToInt32(row.Cells["IdTipoInterv"].Value) == value)
                                    {
                                        MessageBox.Show("No puede existir duplicidad en los tipos de intervinientes", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        cboTipoInterv.SelectedIndex = -1;
                                        return;
                                    }
                                }
                            }
                        }

                    }
                }
            }
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
            dtgIntervinientes.Columns["cboTipoInterv"].Visible = true;
            dtgIntervinientes.Columns["lVigente"].Visible = false;

            dtgIntervinientes.Columns["cboTipoInterv"].HeaderText = "Tipo de Interviniente";

            dtgIntervinientes.Columns["cboTipoInterv"].ReadOnly = false;

        }

        #endregion

        #region DtgGarantias

        private void btnAgrGarant_Click(object sender, EventArgs e)
        {
            frmBusGarantEvaEmp frmBusGar = new frmBusGarantEvaEmp();
            frmBusGar.ShowDialog();
            if (frmBusGar.itemGarantia != null)
            {
                if (!lstGarantias.Any(item => item.idGarantia == frmBusGar.itemGarantia.idGarantia))
                {
                    lstGarantias.Add(frmBusGar.itemGarantia);
                    dtgGarantias.DataSource = null;
                    //dtgGarantias.DataSource = lstGarantias;
                    dtgGarantias.DataSource = ConvertToDataTable<clsGarantia>(lstGarantias);
                }
                else
                {
                    MessageBox.Show("La garantia seleccionada ya se encuentra en la lista.", "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                FormatdtgGarantias();
            }
            else
            {
            }
        }

        private void btnQuitGarant_Click(object sender, EventArgs e)
        {
            if (this.dtgGarantias.SelectedRows.Count == 0)
            {
                if (dtgGarantias.Rows.Count == 0)
                {
                    MessageBox.Show("No se tiene registrada ninguna garantía agregada.", "Registro de Evaluacion Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar la garantía a eliminar", "Registro de Evaluacion Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                int nfilaSelec = dtgGarantias.CurrentRow.Index;

                // clsGarantia Garantia =  (clsGarantia)dtgGarantias.CurrentRow.DataBoundItem;
                //lstGarantias.Remove(Garantia);
                lstGarantias.RemoveAt(nfilaSelec);
                dtgGarantias.DataSource = null;
                dtgGarantias.DataSource = ConvertToDataTable<clsGarantia>(lstGarantias);
                FormatdtgGarantias();

                //Asignar una selección
                if (dtgGarantias.Rows.Count > 0)
                {
                    dtgGarantias.CurrentCell = dtgGarantias["idGarantia", dtgGarantias.Rows.Count - 1];
                    dtgGarantias.CurrentCell.Selected = true;
                }
            }
        }

        private void FormatdtgGarantias()
        {
            dtgGarantias.Columns["idGarantia"].Visible = true;
            dtgGarantias.Columns["cGarantia"].Visible = true;
            dtgGarantias.Columns["idTipoGarantia"].Visible = false;
            dtgGarantias.Columns["idClaseGarantia"].Visible = false;
            dtgGarantias.Columns["idMoneda"].Visible = false;
            dtgGarantias.Columns["idEstado"].Visible = false;
            dtgGarantias.Columns["dFecRegistro"].Visible = false;
            dtgGarantias.Columns["nTipoCambio"].Visible = false;
            dtgGarantias.Columns["nMonGarantia"].Visible = true;
            dtgGarantias.Columns["nValorComercial"].Visible = true;
            dtgGarantias.Columns["nValorMercado"].Visible = true;
            dtgGarantias.Columns["nValorEdifica"].Visible = true;
            dtgGarantias.Columns["nValorNuevo"].Visible = true;
            dtgGarantias.Columns["nValorRealiza"].Visible = true;
            dtgGarantias.Columns["cDesObserva"].Visible = true;
            dtgGarantias.Columns["idUbigeo"].Visible = false;
            dtgGarantias.Columns["cDireccion"].Visible = true;
            dtgGarantias.Columns["cReferencia"].Visible = false;
            dtgGarantias.Columns["nMonGravamen"].Visible = true;
            dtgGarantias.Columns["idGrupoGarantia"].Visible = false;
            dtgGarantias.Columns["nValorVenta"].Visible = false;
            dtgGarantias.Columns["lIndSabana"].Visible = false;
            dtgGarantias.Columns["lIndPriVenta"].Visible = false;

            dtgGarantias.Columns["idGarantia"].HeaderText = "N° Garantía";
            dtgGarantias.Columns["cGarantia"].HeaderText = "Descripción";
            dtgGarantias.Columns["nMonGarantia"].HeaderText = "Mont. Garantía";
            dtgGarantias.Columns["nValorComercial"].HeaderText = "Val. Comerc.";
            dtgGarantias.Columns["nValorMercado"].HeaderText = "Val. Mercado";
            dtgGarantias.Columns["nValorEdifica"].HeaderText = "Val. Edifica";
            dtgGarantias.Columns["nValorNuevo"].HeaderText = "Val. Nuevo";
            dtgGarantias.Columns["nValorRealiza"].HeaderText = "Val. Realiza.";
            dtgGarantias.Columns["cDesObserva"].HeaderText = "Observaciones";
            dtgGarantias.Columns["cDireccion"].HeaderText = "Dirección";
            dtgGarantias.Columns["nMonGravamen"].HeaderText = "Mont. Gravamen";

            dtgGarantias.Columns["idGarantia"].FillWeight = 40;
            dtgGarantias.Columns["cGarantia"].FillWeight = 60;
            dtgGarantias.Columns["cDireccion"].FillWeight = 60;
            dtgGarantias.Columns["cDesObserva"].FillWeight = 60;
            dtgGarantias.Columns["nMonGarantia"].FillWeight = 40;
            dtgGarantias.Columns["nValorComercial"].FillWeight = 40;
            dtgGarantias.Columns["nValorMercado"].FillWeight = 40;
            dtgGarantias.Columns["nValorEdifica"].FillWeight = 40;
            dtgGarantias.Columns["nValorNuevo"].FillWeight = 40;
            dtgGarantias.Columns["nValorRealiza"].FillWeight = 40;
            dtgGarantias.Columns["nMonGravamen"].FillWeight = 40;

        }

        #endregion

        #region Balance

        private void FormatoBalance()
        {
            conTLVBalance.listViewEditable1.Height = 475;
            conTLVBalance.Height = 477;
            conTLVBalance.listViewEditable1.Width = 340;
            conTLVBalance.listViewEditable1.Columns[0].Width = 246;
        }

        private void ActualizarBalance()
        {
            foreach (ListViewItem itemList in conTLVBalance.listViewEditable1.Items)
            {
                clsItemBalance itemBal = (clsItemBalance)itemList.Tag;
                if (itemBal.idItem == 7)//Calculando el Total de Inventario
                {
                    if (!string.IsNullOrEmpty(txtTotInv.Text))
                    {
                        itemList.SubItems[1].Text = txtTotInv.Text;
                        conTLVBalance.listViewEditable1.sumarItemPadre(itemBal.idItemPadre);
                    }
                }
                if (itemBal.idItem == 9)//Calculando el Total de mercaderia
                {
                    if (!string.IsNullOrEmpty(txtTotMercaderia.Text))
                    {
                        itemList.SubItems[1].Text = txtTotMercaderia.Text;
                        conTLVBalance.listViewEditable1.sumarItemPadre(itemBal.idItemPadre);
                    }
                }
                if (itemBal.idItem == 25)//Calculando las obligaciones bancarias del Negocio
                {
                    //if (dtgDetCreNeg.RowCount > 0)
                    //{
                        decimal nObliBanc = 0.00M;
                        foreach (DataGridViewRow row in dtgDetCreNeg.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["nCuoPendientes"].Value) <= 12)
                            {
                                nObliBanc += Convert.ToInt32(row.Cells["nSaldoCredito"].Value);
                            }
                        }
                        itemList.SubItems[1].Text = nObliBanc.ToString("##,##0.00");
                        conTLVBalance.listViewEditable1.sumarItemPadre(itemBal.idItemPadre);
                    //}
                }
                if (itemBal.idItem == 35)//Calculando las obligaciones bancarias del Negocio
                {
                    //if (dtgDetCreNeg.RowCount > 0)
                    //{
                        decimal nCred = 0.00M;
                        foreach (DataGridViewRow row in dtgDetCreNeg.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["nCuoPendientes"].Value) > 12)
                            {
                                nCred += Convert.ToInt32(row.Cells["nSaldoCredito"].Value);
                            }
                        }
                        itemList.SubItems[1].Text = nCred.ToString("##,##0.00");
                        conTLVBalance.listViewEditable1.sumarItemPadre(itemBal.idItemPadre);
                    //}
                }

            }
            conTLVBalance.listViewEditable1.TotalizarBalance();
            CalcularRatios();
        }

        private void CopiarBalanceDataTable()
        {
            dtBalanceGeneral = null;

            dtBalanceGeneral = new DataTable();

            dtBalanceGeneral.Columns.Add("IdCuentaCtb", typeof(Int32));
            dtBalanceGeneral.Columns.Add("IdItem", typeof(Int32));
            dtBalanceGeneral.Columns.Add("IdEvalEmp", typeof(Int32));
            dtBalanceGeneral.Columns.Add("IdItemPadre", typeof(Int32));
            dtBalanceGeneral.Columns.Add("cDescriCuentaCtb", typeof(string));
            dtBalanceGeneral.Columns.Add("nMontoCuentaCtb", typeof(decimal));
            dtBalanceGeneral.Columns.Add("nNivelCuentaCtb", typeof(Int32));
            dtBalanceGeneral.Columns.Add("nOrdenCuentaCtb", typeof(Int32));
            dtBalanceGeneral.Columns.Add("lVigente", typeof(Int32));

            foreach (ListViewItem itemList in conTLVBalance.listViewEditable1.Items)
            {
                clsItemBalance itemBal = (clsItemBalance)itemList.Tag;
                DataRow dr = dtBalanceGeneral.NewRow();
                dr["IdCuentaCtb"] = -1;
                dr["IdItem"] = itemBal.idItem;
                dr["IdEvalEmp"] = 0;
                dr["IdItemPadre"] = itemBal.idItemPadre;
                dr["cDescriCuentaCtb"] = itemBal.cDesItem;
                dr["nMontoCuentaCtb"] = Convert.ToDecimal(itemList.SubItems[1].Text);
                dr["nNivelCuentaCtb"] = itemBal.nNivel;
                dr["nOrdenCuentaCtb"] = itemBal.nOrden;
                dr["lVigente"] = itemBal.lVigente;
                dtBalanceGeneral.Rows.Add(dr);
            }
        }

        private void LlenarBalance()
        {
            ListViewItem lvitem;
            conTLVBalance.listViewEditable1.Items.Clear();

            foreach (DataRow row in dtBalanceGeneral.Rows)
            {
                clsItemBalance item = new clsItemBalance();
                item.idItem = Convert.ToInt32(row["IdItem"].ToString());
                item.nOrden = Convert.ToInt32(row["nOrdenCuentaCtb"].ToString());
                item.idItemPadre = Convert.ToInt32(row["IdItemPadre"].ToString());
                item.nNivel = Convert.ToInt32(row["nNivelCuentaCtb"].ToString());
                item.lVigente = Convert.ToInt32(row["lVigente"]);
                item.cDesItem = row["cDescriCuentaCtb"].ToString();
                item.nMonto = Convert.ToDecimal(row["nMontoCuentaCtb"].ToString());
                string[] s = new string[4];
                s[0] = item.cDesItem;
                s[1] = item.nMonto.ToString();

                lvitem = new ListViewItem(s);
                if (item.nNivel.In(1, 3, 6))
                {
                    lvitem.Font = new Font(conTLVBalance.listViewEditable1.Font, FontStyle.Bold);
                }

                if (item.nNivel.In(3))
                {
                    lvitem.SubItems[0].BackColor = Color.Aqua;
                }

                lvitem.Tag = item;

                this.conTLVBalance.listViewEditable1.Items.Add(lvitem);
            }
        }

        private void CalcularRatios()
        {
            decimal nRatLiq = 0.00M;
            decimal nRatSolv = 0.00M;
            decimal nRatRotCapTrab = 0.00M;
            decimal nRatRentAct = 0.00M;
            decimal nRatRotInv = 0.00M;
            decimal nRatApalFin = 0.00M;
            decimal nActCorr = 0.00M;
            decimal nPasivCorr = 0.00M;
            decimal nPatrimonio = 0.00M;
            decimal nPasivo = 0.00M;
            decimal nVenta = 0.00M;
            decimal nInventario = 0.00M;
            decimal nActivo = 0.00M;
            decimal nUtiNeta = 0.00M;
            decimal nCostoProd = 0.00M;
            decimal nMontoOtorg = 0.00M;

            foreach (ListViewItem itemList in conTLVBalance.listViewEditable1.Items)
            {
                clsItemBalance itemBal = (clsItemBalance)itemList.Tag;
                if (itemBal.idItem == 2)
                {
                    nActivo = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
                if (itemBal.idItem == 3)
                {
                    nActCorr = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
                if (itemBal.idItem == 6)
                {
                    nInventario = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
                if (itemBal.idItem == 22)
                {
                    nPasivo = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
                if (itemBal.idItem == 23)
                {
                    nPasivCorr = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
                if (itemBal.idItem == 37)
                {
                    nPatrimonio = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
            }

            foreach (DataGridViewRow row in dtgEstPerdGanan.Rows)
            {
                if (Convert.ToInt32(row.Cells["IdPlantiEstPerdiGana"].Value) == 1)
                {
                    nVenta = Convert.ToDecimal(row.Cells["nMontoParti"].Value);
                }
                if (Convert.ToInt32(row.Cells["IdPlantiEstPerdiGana"].Value) == 2)
                {
                    nCostoProd = Convert.ToDecimal(row.Cells["nMontoParti"].Value);
                }
                if (Convert.ToInt32(row.Cells["IdPlantiEstPerdiGana"].Value) == 7)
                {
                    nUtiNeta = Convert.ToDecimal(row.Cells["nMontoParti"].Value);
                }
            }

            if (!string.IsNullOrEmpty(txtMontProp.Text))
            {
                nMontoOtorg = Convert.ToDecimal(txtMontProp.Text);
            }

            //=================================================================================
            //  Calculando los INDICADORES FINANCIEROS
            //=================================================================================

            if (nPasivCorr != 0)
            {
                nRatLiq = nActCorr / nPasivCorr;//bien
            }
            if (nPasivo != 0)
            {
                nRatSolv = nActivo / nPasivo;//bien               
            }
            if (nPatrimonio != 0)
            {
                nRatApalFin = (nPasivo + nMontoOtorg) / nPatrimonio;
            }
            if (nInventario != 0)
            {
                nRatRotInv = nCostoProd / nInventario;// bien
            }
            if ((nActCorr - nPasivCorr) != 0)
            {
                nRatRotCapTrab = nVenta / (nActCorr - nPasivCorr);//bien
            }
            if (nActivo != 0)
            {
                nRatRentAct = nUtiNeta / nActivo;//bien
            }

            txtRatLiquidez.Text = nRatLiq.ToString("##,##0.00");
            txtRatSolvencia.Text = nRatSolv.ToString("##,##0.00");
            txtRatApalFin.Text = nRatApalFin.ToString("##,##0.00");
            txtRatRotCapTrab.Text = nRatRotCapTrab.ToString("##,##0.00");
            txtRatRotInv.Text = nRatRotInv.ToString("##,##0.00");
            txtRatRentActivo.Text = nRatRentAct.ToString("##,##0.00");
        }

        private void conTLVBalance_Leave(object sender, EventArgs e)
        {
            ActualizarBalance();
            ActualizarEstPerdGanan();
        }

        #endregion

        #region Metodos

        private void VincEvaComponentes()
        {
            this.txtNumEva.DataBindings.Add("Text", dtMaestro, "IdEvalEmp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cboMoneda.DataBindings.Add("SelectedValue", dtMaestro, "IdMoneda", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTipoCambio.DataBindings.Add("Text", dtMaestro, "nTipoCambio", false, DataSourceUpdateMode.OnPropertyChanged);
            this.conBusCli.txtCodCli.DataBindings.Add("Text", dtMaestro, "idCliente", false, DataSourceUpdateMode.OnPropertyChanged);
            this.dtpFecReg.DataBindings.Add("Text", dtMaestro, "dFechaReg", false, DataSourceUpdateMode.OnPropertyChanged);
            this.dtpFecVig.DataBindings.Add("Text", dtMaestro, "dFechaVig", false, DataSourceUpdateMode.OnPropertyChanged);
            this.dtpFecTomInv.DataBindings.Add("Text", dtMaestro, "dFecTomaInv", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtDeuSistFin.DataBindings.Add("Text", dtMaestro, "nDeuSisFin", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.cboFrecPagEva.DataBindings.Add("SelectedValue", dtMaestro, "nFrecEval", false, DataSourceUpdateMode.OnPropertyChanged, 0);
            this.txtMontProp.DataBindings.Add("Text", dtMaestro, "nMonPropuesto", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtNroCuotas.DataBindings.Add("Text", dtMaestro, "nNumcuotas", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTEM.DataBindings.Add("Text", dtMaestro, "nTEM", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtCuotaAprox.DataBindings.Add("Text", dtMaestro, "nCuotaAprox", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtCoberCuota.DataBindings.Add("Text", dtMaestro, "nCoberturaCuota", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtRatLiquidez.DataBindings.Add("Text", dtMaestro, "nRatLiquidez", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtComRatLiq.DataBindings.Add("Text", dtMaestro, "cComRatLiquidez", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtRatSolvencia.DataBindings.Add("Text", dtMaestro, "nRatSolvencia", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtComRatSolv.DataBindings.Add("Text", dtMaestro, "cComRatSolvencia", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtRatRotCapTrab.DataBindings.Add("Text", dtMaestro, "nRatRotCapTrabajo", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtComRatRotCapTrbjo.DataBindings.Add("Text", dtMaestro, "cComRatRotCapTrabajo", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtRatRentActivo.DataBindings.Add("Text", dtMaestro, "nRatRentaActivo", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtComRatRentAct.DataBindings.Add("Text", dtMaestro, "cComRatRentaActivo", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtRatRotInv.DataBindings.Add("Text", dtMaestro, "nRatRotInventario", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtComRatRotInv.DataBindings.Add("Text", dtMaestro, "cComRatRotInventario", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtRatApalFin.DataBindings.Add("Text", dtMaestro, "nRatApalFin", false, DataSourceUpdateMode.OnPropertyChanged, 0.00, "##,##0.00");
            this.txtComRatApalFin.DataBindings.Add("Text", dtMaestro, "cComRatApalFin", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cboTipoUsoLocal.DataBindings.Add("SelectedValue", dtMaestro, "IdTipoUsoLocal", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTiempoUsoLocal.DataBindings.Add("Text", dtMaestro, "nTiempoUsoLocal", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cboUniTiempoUsoLoc.DataBindings.Add("SelectedValue", dtMaestro, "IdUniTiempoUsoLocal", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtTiempoExp.DataBindings.Add("Text", dtMaestro, "nTiempoExpActivi", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cboUniTiempoExp.DataBindings.Add("SelectedValue", dtMaestro, "IdUniTiempoExp", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtHorasDedic.DataBindings.Add("Text", dtMaestro, "nHorasDediActivi", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtHorasAtenc.DataBindings.Add("Text", dtMaestro, "nHorasAtenNego", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtNroColab.DataBindings.Add("Text", dtMaestro, "nNumColabora", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtNroDepend.DataBindings.Add("Text", dtMaestro, "nNumDependientes", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComMesBue.DataBindings.Add("Text", dtMaestro, "cMesesBuenos", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComMesMal.DataBindings.Add("Text", dtMaestro, "cMesesMalos", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComFortalezas.DataBindings.Add("Text", dtMaestro, "cComFortaleza", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComDebilid.DataBindings.Add("Text", dtMaestro, "cComDebilidad", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComProveed.DataBindings.Add("Text", dtMaestro, "cComProveedores", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComPoliticaFin.DataBindings.Add("Text", dtMaestro, "cComPoliFinan", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComConting.DataBindings.Add("Text", dtMaestro, "cComContingentes", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComCentralRsgo.DataBindings.Add("Text", dtMaestro, "cComCentralRie", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComPosInterv.DataBindings.Add("Text", dtMaestro, "cComPosiInterv", false, DataSourceUpdateMode.OnPropertyChanged);
            this.txtComRds.DataBindings.Add("Text", dtMaestro, "cComRDS", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void VincDetEvaComponentes()
        {
            //this.txtUnidProd.DataBindings.Add("Text", dtDetalle, "nUniCosteadas");
            //this.txtTotCostProd.DataBindings.Add("Text", dtDetalle, "nSubTotCosProdu");
            //this.txtCostUnit.DataBindings.Add("Text", dtDetalle, "nPreUniCompra_Prod");
        }

        private void DesvincEvaComponentes()
        {
            this.txtNumEva.DataBindings.Clear();
            this.cboMoneda.DataBindings.Clear();
            this.txtTipoCambio.DataBindings.Clear();
            this.conBusCli.txtCodCli.DataBindings.Clear();
            this.dtpFecReg.DataBindings.Clear();
            this.dtpFecVig.DataBindings.Clear();
            this.dtpFecTomInv.DataBindings.Clear();
            this.txtDeuSistFin.DataBindings.Clear();
            this.cboFrecPagEva.DataBindings.Clear();
            this.txtMontProp.DataBindings.Clear();
            this.txtNroCuotas.DataBindings.Clear();
            this.txtTEM.DataBindings.Clear();
            this.txtCuotaAprox.DataBindings.Clear();
            this.txtCoberCuota.DataBindings.Clear();
            this.txtRatLiquidez.DataBindings.Clear();
            this.txtComRatLiq.DataBindings.Clear();
            this.txtRatSolvencia.DataBindings.Clear();
            this.txtComRatSolv.DataBindings.Clear();
            this.txtRatRotCapTrab.DataBindings.Clear();
            this.txtComRatRotCapTrbjo.DataBindings.Clear();
            this.txtRatRentActivo.DataBindings.Clear();
            this.txtComRatRentAct.DataBindings.Clear();
            this.txtRatRotInv.DataBindings.Clear();
            this.txtComRatRotInv.DataBindings.Clear();
            this.txtRatApalFin.DataBindings.Clear();
            this.txtComRatApalFin.DataBindings.Clear();
            this.cboTipoUsoLocal.DataBindings.Clear();
            this.txtTiempoUsoLocal.DataBindings.Clear();
            this.cboUniTiempoUsoLoc.DataBindings.Clear();
            this.txtTiempoExp.DataBindings.Clear();
            this.cboUniTiempoExp.DataBindings.Clear();
            this.txtHorasDedic.DataBindings.Clear();
            this.txtHorasAtenc.DataBindings.Clear();
            this.txtNroColab.DataBindings.Clear();
            this.txtNroDepend.DataBindings.Clear();
            this.txtComMesBue.DataBindings.Clear();
            this.txtComMesMal.DataBindings.Clear();
            this.txtComFortalezas.DataBindings.Clear();
            this.txtComDebilid.DataBindings.Clear();
            this.txtComProveed.DataBindings.Clear();
            this.txtComPoliticaFin.DataBindings.Clear();
            this.txtComConting.DataBindings.Clear();
            this.txtComCentralRsgo.DataBindings.Clear();
            this.txtComPosInterv.DataBindings.Clear();
            this.txtComRds.DataBindings.Clear();
        }

        private void DesvincDetEvaComponentes()
        {
            //this.txtUnidProd.DataBindings.Clear();
            //this.txtTotCostProd.DataBindings.Clear();
            //this.txtCostUnit.DataBindings.Clear();
        }             

        private void AgregarComboBoxs()
        {
            DataTable dtTipGiro = EvalEmp.CNdtLstTipoGiro();
            DataGridViewComboBoxColumn cboTipoGiro = new DataGridViewComboBoxColumn();
            cboTipoGiro.HeaderText = "Tipo Giro";
            cboTipoGiro.ToolTipText = "Tipo de Giro";
            cboTipoGiro.Name = "cboTipoGiro";
            cboTipoGiro.DataPropertyName = "IdTipoGiroNego";
            cboTipoGiro.MaxDropDownItems = 4;
            cboTipoGiro.DropDownWidth = 100;
            cboTipoGiro.DataSource = dtTipGiro;
            cboTipoGiro.DisplayMember = dtTipGiro.Columns["cDesCorTipoGiroNego"].ToString();
            cboTipoGiro.ValueMember = dtTipGiro.Columns["IdTipoGiroNego"].ToString();
            this.dtgDetEva.Columns.Add(cboTipoGiro);

            DataTable dtTipIngr = EvalEmp.CNdtLstTipoIngresos();
            DataGridViewComboBoxColumn cboTipoIngr = new DataGridViewComboBoxColumn();
            cboTipoIngr.HeaderText = "Tipo Ingr.";
            cboTipoIngr.ToolTipText = "Tipo de Ingreso";
            cboTipoIngr.Name = "cboTipoIngr";
            cboTipoIngr.DataPropertyName = "IdTipoIng";
            cboTipoIngr.MaxDropDownItems = 4;
            cboTipoIngr.DropDownWidth = 100;
            cboTipoIngr.DataSource = dtTipIngr;
            cboTipoIngr.DisplayMember = dtTipIngr.Columns["cDesCorTipoIng"].ToString();
            cboTipoIngr.ValueMember = dtTipIngr.Columns["IdTipoIng"].ToString();
            this.dtgDetEva.Columns.Add(cboTipoIngr);

            DataTable dtMetCosteo = EvalEmp.CNdtLstMetCosteo();
            DataGridViewComboBoxColumn cboMetCosteo = new DataGridViewComboBoxColumn();
            cboMetCosteo.HeaderText = "Met. Costeo";
            cboMetCosteo.ToolTipText = "Metodo de Costeo";
            cboMetCosteo.Name = "cboMetCosteo";
            cboMetCosteo.DataPropertyName = "IdMetCosteo";
            cboMetCosteo.MaxDropDownItems = 4;
            cboMetCosteo.DropDownWidth = 100;
            cboMetCosteo.DataSource = dtMetCosteo;
            cboMetCosteo.DisplayMember = dtMetCosteo.Columns["cDescrCortaMetodoCosteo"].ToString();
            cboMetCosteo.ValueMember = dtMetCosteo.Columns["IdMetCosteo"].ToString();
            this.dtgDetEva.Columns.Add(cboMetCosteo);

            DataTable dtUnidadMed = EvalEmp.CNdtLstUnidadMed();
            DataGridViewComboBoxColumn cboUnidadMed = new DataGridViewComboBoxColumn();
            cboUnidadMed.HeaderText = "Uni. Med.";
            cboUnidadMed.ToolTipText = "Unidad de Medida";
            cboUnidadMed.Name = "cboUnidadMed";
            cboUnidadMed.DataPropertyName = "IdUnidadMedida";
            cboUnidadMed.MaxDropDownItems = 4;
            cboUnidadMed.DropDownWidth = 50;
            cboUnidadMed.DataSource = dtUnidadMed;
            cboUnidadMed.DisplayMember = dtUnidadMed.Columns["cDesCorTipoUniMed"].ToString();
            cboUnidadMed.ValueMember = dtUnidadMed.Columns["IdUnidadMedida"].ToString();
            this.dtgDetEva.Columns.Add(cboUnidadMed);

            DataTable dtMoneda = EvalEmp.CNdtLstMoneda();
            DataGridViewComboBoxColumn cboMoneda = new DataGridViewComboBoxColumn();
            cboMoneda.HeaderText = "Mon.";
            cboMoneda.ToolTipText = "Moneda";
            cboMoneda.Name = "cboMoneda";
            cboMoneda.DataPropertyName = "IdMoneda";
            cboMoneda.MaxDropDownItems = 4;
            cboMoneda.DropDownWidth = 100;
            cboMoneda.DataSource = dtMoneda;
            cboMoneda.DisplayMember = dtMoneda.Columns["cSimbolo"].ToString();
            cboMoneda.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            this.dtgDetEva.Columns.Add(cboMoneda);

            DataGridViewComboBoxColumn cboUnidadMedCosteo = new DataGridViewComboBoxColumn();
            cboUnidadMedCosteo.HeaderText = "Uni. Med.";
            cboUnidadMedCosteo.ToolTipText = "Unidad de Medida";
            cboUnidadMedCosteo.Name = "cboUnidadMedCosteo";
            cboUnidadMedCosteo.DataPropertyName = "IdUnidadMedida";
            cboUnidadMedCosteo.MaxDropDownItems = 4;
            cboUnidadMedCosteo.DropDownWidth = 50;
            cboUnidadMedCosteo.DataSource = dtUnidadMed;
            cboUnidadMedCosteo.DisplayMember = dtUnidadMed.Columns["cDesCorTipoUniMed"].ToString();
            cboUnidadMedCosteo.ValueMember = dtUnidadMed.Columns["IdUnidadMedida"].ToString();
            this.dtgCosteo.Columns.Add(cboUnidadMedCosteo);

            DataGridViewComboBoxColumn cboMonedaCosteo = new DataGridViewComboBoxColumn();
            cboMonedaCosteo.HeaderText = "Mon.";
            cboMonedaCosteo.ToolTipText = "Moneda";
            cboMonedaCosteo.Name = "cboMonedaCosteo";
            cboMonedaCosteo.DataPropertyName = "IdMoneda";
            cboMonedaCosteo.MaxDropDownItems = 4;
            cboMonedaCosteo.DropDownWidth = 100;
            cboMonedaCosteo.DataSource = dtMoneda;
            cboMonedaCosteo.DisplayMember = dtMoneda.Columns["cSimbolo"].ToString();
            cboMonedaCosteo.ValueMember = dtMoneda.Columns["idMoneda"].ToString();
            cboMonedaCosteo.ReadOnly = true;
            this.dtgCosteo.Columns.Add(cboMonedaCosteo);

            DataTable dtTipoInterv = new clsCNInterviniente().CNListaTipoInterv();
            DataGridViewComboBoxColumn cboTipoInterv = new DataGridViewComboBoxColumn();
            cboTipoInterv.HeaderText = "Tipo Interv.";
            cboTipoInterv.ToolTipText = "Tipo de Interviniente";
            cboTipoInterv.Name = "cboTipoInterv";
            cboTipoInterv.DataPropertyName = "IdTipoInterv";
            cboTipoInterv.MaxDropDownItems = 4;
            cboTipoInterv.DropDownWidth = 50;
            cboTipoInterv.DataSource = dtTipoInterv;
            cboTipoInterv.DisplayMember = dtTipoInterv.Columns["CTIPOINTERVENCION"].ToString();
            cboTipoInterv.ValueMember = dtTipoInterv.Columns["idtipointerv"].ToString();
            this.dtgIntervinientes.Columns.Add(cboTipoInterv);
        }

        private void QuitarComboBoxs()
        {
            this.dtgDetEva.Columns.Remove("cboTipoGiro");
            this.dtgDetEva.Columns.Remove("cboTipoIngr");
            this.dtgDetEva.Columns.Remove("cboMetCosteo");
            this.dtgDetEva.Columns.Remove("cboUnidadMed");
            this.dtgCosteo.Columns.Remove("cboUnidadMedCosteo");
            this.dtgIntervinientes.Columns.Remove("cboTipoInterv");
        }

        private void ValidarDatos()
        {
            string Msje = "";
            lFlagValidar = true;

            if (string.IsNullOrEmpty(txtDeuSistFin.Text))
            {
                Msje += "Ingrese el monto de deuda con el sistema financiero.\n";
                lFlagValidar = false;
                txtDeuSistFin.Focus();
            }
            if (cboFrecPagEva.SelectedIndex == -1)
            {
                Msje += "Seleccione la frecuencia de pago.\n";
                lFlagValidar = false;
                cboFrecPagEva.Focus();
            }
            if (string.IsNullOrEmpty(txtTotVentas.Text))
            {
                Msje += "Registre las ventas de la evaluación.\n";
                lFlagValidar = false;
                txtTotVentas.Focus();
            }
            else
            {
                if (Convert.ToDecimal(txtTotVentas.Text) <= 0)
                {
                    Msje += "Las ventas no pueden ser 0 o negativas.\n";
                    lFlagValidar = false;
                    txtTotVentas.Focus();
                }
            }
            if (cboMoneda.SelectedIndex == -1)
            {
                Msje += "Elija el tipo de moneda de la Evaluación.\n";
                lFlagValidar = false;
                txtTotVentas.Focus();
            }
            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                Msje += "Ingrese el tipo de cambio fijo .\n";
                lFlagValidar = false;
                txtTotVentas.Focus();
            }
            if (!string.IsNullOrEmpty(txtTotVentas.Text))
            {
                if (Convert.ToDecimal(txtTotVentas.Text) == 0 || dtgDetEva.RowCount == 0)
                {
                    Msje += "No se puede registrar una evaluacion sin ventas.\n";
                    lFlagValidar = false;
                    dtgDetEva.Focus();
                }
            }
            if (cboTipoUsoLocal.SelectedIndex == -1)
            {
                Msje += "Seleccione tipo de uso de local, en la pestaña Fotos.\n";
                lFlagValidar = false;
                cboTipoUsoLocal.Focus();
            }
            if (string.IsNullOrEmpty(txtTiempoUsoLocal.Text) || cboUniTiempoUsoLoc.SelectedIndex == 1)
            {
                Msje += "Ingrese el tiempo de uso de local con sus respectivas unidades.\n";
                lFlagValidar = false;
                txtTiempoUsoLocal.Focus();
            }

            if (string.IsNullOrEmpty(txtTiempoExp.Text) || cboUniTiempoExp.SelectedIndex == 1)
            {
                Msje += "Ingrese el tiempo de experiencia en el negocio con sus respectivas unidades.\n";
                lFlagValidar = false;
                txtTiempoExp.Focus();
            }

            if (string.IsNullOrEmpty(txtHorasDedic.Text))
            {
                Msje += "Ingrese las horas de dedicación al negocio.\n";
                lFlagValidar = false;
                txtHorasDedic.Focus();
            }

            if (string.IsNullOrEmpty(txtHorasAtenc.Text))
            {
                Msje += "Ingrese las horas de atención en el negocio.\n";
                lFlagValidar = false;
                txtHorasAtenc.Focus();
            }

            if (string.IsNullOrEmpty(txtNroColab.Text))
            {
                Msje += "Ingrese el número de colaboradores.\n";
                lFlagValidar = false;
                txtTiempoUsoLocal.Focus();
            }

            if (string.IsNullOrEmpty(txtNroDepend.Text))
            {
                Msje += "Ingrese el número de depedientes.\n";
                lFlagValidar = false;
                txtTiempoUsoLocal.Focus();
            }

            if (string.IsNullOrEmpty(txtMontProp.Text))
            {
                Msje += "Ingrese el monto propuesto.\n";
                lFlagValidar = false;
                txtMontProp.Focus();
            }
            if (txtMontProp.nvalor==0.00)
            {
                Msje += "El monto propuesto debe ser mayor que 0.00 \n";
                lFlagValidar = false;
                txtMontProp.Focus();
            }

            if (string.IsNullOrEmpty(txtNroCuotas.Text))
            {
                Msje += "Ingrese el número de cuotas propuesto.\n";
                lFlagValidar = false;
                txtNroCuotas.Focus();
            }
            else
            {
                if (Convert.ToDecimal (txtNroCuotas.Text) == 0.00m)
                {
                    Msje += "El número de cuotas propuesto debe ser mayor que 0.\n";
                    lFlagValidar = false;
                    txtNroCuotas.Focus();
                }
            }

            if (string.IsNullOrEmpty(txtTEM.Text))
            {
                Msje += "Ingrese la tasa efectiva mensual(TEM).\n";
                lFlagValidar = false;
                txtTEM.Focus();
            }
            if (txtTEM.nvalor==0.00)
            {
                Msje += "la Tasa efectiva mensual desbe ser mayor que 0.00.\n";
                lFlagValidar = false;
                txtTEM.Focus();
            }

            decimal nValorBalance = 0.00M;
            foreach (ListViewItem itemList in conTLVBalance.listViewEditable1.Items)
            {
                clsItemBalance itemBal = (clsItemBalance)itemList.Tag;
                if (itemBal.idItem == 1)
                {
                    nValorBalance = Convert.ToDecimal(itemList.SubItems[1].Text);
                }
            }
            if (nValorBalance != 0)
            {
                Msje += "El Activo no es igual a la suma del pasivo y patrimonio, No puede guardar la evaluación.\n";
                lFlagValidar = false;
                conTLVBalance.Focus();
            }

            if (dtgIntervinientes.Rows.Count == 0)
            {
                Msje += "Seleccione por lo menos un interviniente de tipo TITULAR.\n";
                lFlagValidar = false;
                dtgIntervinientes.Focus();
            }

            //valida el registro de intervinientes -- Los datos de la tabla estén completos
            Boolean lEstaTitular = false;
            if (dtIntervinientes.Rows.Count > 0)
            {
                for (int i = 0; i < dtIntervinientes.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtIntervinientes.Rows[i]["IdTipoInterv"]) == 1)//Identificar si se ha seleccionado al titular
                    {
                        lEstaTitular=true;
                    }
                }
            }
            if (lEstaTitular == false)
            {
                Msje += "Seleccione por lo menos un interviniente de tipo TITULAR.\n";
                lFlagValidar = false;
            }
            //

            foreach (DataGridViewRow row in dtgDetalleFotos.Rows)
            {
                if (row.Cells["cDescriFoto"].Value == DBNull.Value || string.IsNullOrEmpty((row.Cells["cDescriFoto"].Value.ToString().Trim())))
                {
                    Msje += "Ingrese la descripción para todas las fotos.\n";
                    lFlagValidar = false;
                    dtgDetalleFotos.Focus();
                    break;
                }
            }

            foreach (DataGridViewRow row in dtgDetEva.Rows)
            {
                if ((row.Cells["cDescriProdSer"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["cDescriProdSer"].Value.ToString().Trim())) ||
                    (row.Cells["IdMetCosteo"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["IdMetCosteo"].Value.ToString().Trim())))
                {
                    Msje += "Existen campos vacios o combos no seleccionados en el DETALLE DE LA EVALUACIÓN.\n";
                    lFlagValidar = false;
                    dtgDetEva.Focus();
                    break;
                }
            }

            foreach (DataRow row in dtCosteoDetalle.Rows)
            {
                if ((row["cDescriMatIns"] == DBNull.Value || string.IsNullOrEmpty(row["cDescriMatIns"].ToString().Trim())))
                {
                    Msje += "Existen campos vacios en el COSTEO DE LAS ACTIVIDADES.\n";
                    lFlagValidar = false;
                    dtgCosteo.Focus();
                    break;
                }
            }

            foreach (DataGridViewRow row in dtgDetCreNeg.Rows)
            {
                if ((row.Cells["cDesInstitucion"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["cDesInstitucion"].Value.ToString().Trim())))
                {
                    Msje += "Existen campos vacios en el DETALLE DE CRÉDITOS DEL NEGOCIO.\n";
                    lFlagValidar = false;
                    dtgDetCreNeg.Focus();
                    break;
                }
            }

            foreach (DataGridViewRow row in dtgDetCreFam.Rows)
            {
                if ((row.Cells["cDesInstitucion"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["cDesInstitucion"].Value.ToString().Trim())))
                {
                    Msje += "Existen campos vacios en el DETALLE DE CRÉDITOS DE LA UNIDAD FAMILIAR.\n";
                    lFlagValidar = false;
                    dtgDetCreFam.Focus();
                    break;
                }
            }

            foreach (DataGridViewRow row in dtgGasPersonal.Rows)
            {
                if ((row.Cells["cDescriPuesto"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["cDescriPuesto"].Value.ToString().Trim())))
                {
                    Msje += "Existen campos vacios en el DETALLE DE GASTOS DE PERSONAL.\n";
                    lFlagValidar = false;
                    dtgGasPersonal.Focus();
                    break;
                }
            }

            foreach (DataGridViewRow row in dtgGasNego.Rows)
            {
                if ((row.Cells["cDescriGas"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["cDescriGas"].Value.ToString().Trim())))
                {
                    Msje += "Existen campos vacios en el DETALLE DE GASTOS DE SERVICIO DEL NEGOCIO.\n";
                    lFlagValidar = false;
                    dtgGasNego.Focus();
                    break;
                }
            }

            foreach (DataGridViewRow row in dtgGasUniFam.Rows)
            {
                if ((row.Cells["cDescriGas"].Value == DBNull.Value || string.IsNullOrEmpty(row.Cells["cDescriGas"].Value.ToString().Trim())))
                {
                    Msje += "Existen campos vacios en el DETALLE DE GASTOS DE LA UNIDAD ECONÓMICA FAMILIAR.\n";
                    lFlagValidar = false;
                    dtgGasUniFam.Focus();
                    break;
                }
            }

            if (string.IsNullOrEmpty(txtDetNegocio.Text))
            {
                 Msje += "Ingresar comentario sobre el negocio.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtDetDestino.Text))
            {
                Msje += "Ingresar comentario sobre el Destino del Crédito.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtDetExperiencia.Text))
            {
                Msje += "Ingresar comentario sobre experiencia crediticia del cliente.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtDetEntorno.Text))
            {
                Msje += "Ingresar comentario sobre entorno familiar del cliente.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtDetEvaluacion.Text))
            {
                Msje += "Ingresar comentario sobre la evaluación.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtDetGarantia.Text))
            {
                Msje += "Ingresar comentario sobre las garantías.\n";
                lFlagValidar = false;
            }
            if (string.IsNullOrEmpty(txtConclusiones.Text))
            {
                Msje += "Ingresar las conclusiones de la evaluación.\n";
                lFlagValidar = false;
            }

            if (!string.IsNullOrEmpty(Msje.Trim()))
            {
                MessageBox.Show(Msje, "Registro de Evaluación Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lFlagValidar = false;
            }



        }

        private void Habilitar(int nOpcion)
        {
            if (nOpcion == 1) // Inicio del Formulario
            {
                tbcGeneral.Enabled = false;
                btnAgrInterv.Enabled = false;
                btnQuitInterv.Enabled = false;
                dtgIntervinientes.Enabled = false;
                txtNumEva.Enabled = false;
                btnCancelar.Enabled = false;
                btnImprimir.Enabled = false;
                btnImprimir1.Enabled = false;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btn_Vincular.Enabled = false;
                btnConsultar.Enabled = true;
                btnGrabar.Enabled = false;
                dtpFecReg.Enabled = false;
                dtpFecVig.Enabled = false;
            }
            else if (nOpcion == 2) 
            {
                tbcGeneral.Enabled = true;
                btnAgrInterv.Enabled = true;
                btnQuitInterv.Enabled = true;
                dtgIntervinientes.Enabled = true;
                txtNumEva.Enabled = false;
                btnCancelar.Enabled = false;
                btnImprimir.Enabled = false;
                btnImprimir1.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = true;
                btn_Vincular.Enabled = false;
                btnConsultar.Enabled = false;
                btnGrabar.Enabled = true;
                dtpFecReg.Enabled = false;
                dtpFecVig.Enabled = false;
            }
            else if (nOpcion == 3) //Grabar
            {
                tbcGeneral.Enabled = true;
                btnAgrInterv.Enabled = false;
                btnQuitInterv.Enabled = false;
                dtgIntervinientes.ReadOnly = true;
                txtNumEva.Enabled = false;
                btnCancelar.Enabled = true;
                btnImprimir.Enabled = false;
                btnImprimir1.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btn_Vincular.Enabled = false;
                btnGrabar.Enabled = false;
                btnConsultar.Enabled = false;
                dtpFecReg.Enabled = false;
                dtpFecVig.Enabled = false;
                dtpFecTomInv.Enabled = false;
                dtgDetEva.ReadOnly = true;
                btnAgrDetEva.Enabled = false;
                btnQuitDetEva.Enabled = false;
                cboFrecPagEva.Enabled = false;
                txtDeuSistFin.Enabled = false;
                txtTipoCambio.Enabled = false;
                cboMoneda.Enabled = false;
                dtgCosteo.Enabled = false;
                btnAgrItemCosteo.Enabled = false;
                btnQuitItemCosteo.Enabled = false;
                txtUnidProd.Enabled = false;
                dtgDetCreNeg.ReadOnly = true;
                btnAgrDetCredNeg.Enabled = false;
                btnQuitDetCredNeg.Enabled = false;
                dtgDetCreFam.ReadOnly = true;
                btnAgrDetCredFam.Enabled = false;
                btnQuitDetCredFam.Enabled = false;
                dtgGasPersonal.ReadOnly = true;
                btnAgrGastPers.Enabled = false;
                btnQuitGastPers.Enabled = false;
                dtgGasNego.ReadOnly = true;
                btnAgrGastServNeg.Enabled = false;
                btnQuitGastServNeg.Enabled = false;
                dtgGasUniFam.ReadOnly = true;
                btnAgrGastUniFam.Enabled = false;
                btnQuitGastUniFam.Enabled = false;
                conTLVBalance.listViewEditable1.ReadOnly = true;               
                grbComentarios.Enabled = false;
                grbRatios.Enabled = false;
                foreach (Control item in tabFotografias.Controls)
                {
                    item.Enabled = false;
                }
                foreach (Control item in this.tabCualitativo.Controls)
                {
                    item.Enabled = false;
                }
                foreach (Control item in this.tabGarantia.Controls)
                {
                    item.Enabled = false;
                }
                grbDatCredito.Enabled = false;
                dtgDetalleFotos.ReadOnly = true;
                btnAgrFoto.Enabled = false;
                btnQuitFoto.Enabled = false;
                btn_Vincular.Enabled = true;
                FormatoEstPerdGanan();
                dtgEstPerdGanan.ReadOnly = true;
                dtgGarantias.ReadOnly = true;
                btnAgrGarant.Enabled = false;
                btnQuitGarant.Enabled = false;

                lblCoberCuota.Visible = true;
                lblMontCuota.Visible = true;
                txtCoberCuota.Visible = true;
                txtCuotaAprox.Visible = true;

                if (dtgEstPerdGanan.RowCount > 0)
                {
                    dtgEstPerdGanan.Rows[10].Visible = true;
                    dtgEstPerdGanan.Rows[11].Visible = true;
                }
            }
            else if (nOpcion == 4) //Nuevo
            {
                tbcGeneral.Enabled = true;
                btnAgrInterv.Enabled = true;
                btnQuitInterv.Enabled = true;
                txtNumEva.Enabled = false;
                btnCancelar.Enabled = true;
                btnImprimir.Enabled = false;
                btnImprimir1.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btn_Vincular.Enabled = false;
                btnConsultar.Enabled = true;
                btnGrabar.Enabled = true;
                dtpFecReg.Enabled = false;
                dtpFecVig.Enabled = false;
                dtpFecTomInv.Enabled = true;
                btnAgrDetEva.Enabled = true;
                btnQuitDetEva.Enabled = true;
                cboFrecPagEva.Enabled = true;
                txtDeuSistFin.Enabled = true;
                txtTipoCambio.Enabled = true;
                cboMoneda.Enabled = true;
                dtgCosteo.Enabled = true;
                btnAgrItemCosteo.Enabled = true;
                btnQuitItemCosteo.Enabled = true;
                txtUnidProd.Enabled = true;
                btnAgrDetCredNeg.Enabled = true;
                btnQuitDetCredNeg.Enabled = true;
                btnAgrDetCredFam.Enabled = true;
                btnQuitDetCredFam.Enabled = true;
                btnAgrGastPers.Enabled = true;
                btnQuitGastPers.Enabled = true;
                btnAgrGastServNeg.Enabled = true;
                btnQuitGastServNeg.Enabled = true;
                btnAgrGastUniFam.Enabled = true;
                btnQuitGastUniFam.Enabled = true;
                grbComentarios.Enabled = true;
                grbRatios.Enabled = true;
                foreach (Control item in tabFotografias.Controls)
                {
                    item.Enabled = true;
                }
                foreach (Control item in this.tabCualitativo.Controls)
                {
                    item.Enabled = true;
                }
                foreach (Control item in this.tabGarantia.Controls)
                {
                    item.Enabled = true;
                }
                grbDatCredito.Enabled = true;
                //grbAspCuali.Enabled = true;
                btnAgrFoto.Enabled = true;
                btnQuitFoto.Enabled = true;
                dtgIntervinientes.Enabled = true;
                dtgIntervinientes.ReadOnly = false;
                conTLVBalance.listViewEditable1.ReadOnly = false;
                dtgGarantias.ReadOnly = true;
                btnAgrGarant.Enabled = true;
                btnQuitGarant.Enabled = true;

                lblCoberCuota.Visible = false;
                lblMontCuota.Visible = false;
                txtCoberCuota.Visible = false;
                txtCuotaAprox.Visible = false;

                if (dtgEstPerdGanan.RowCount > 0)
                {
                    dtgEstPerdGanan.Rows[10].Visible = false;
                    dtgEstPerdGanan.Rows[11].Visible = false;
                }
                dtgVariables.ReadOnly = false;
                dtgComportamiento.ReadOnly = false;
            }
        }       

        private void CalcularCuotaAprox()
        {
            Decimal  nMonto, nTEM;
            int     nNroCuotas;
            DateTime dFecDesemb = dtpFechaDesembolso.Value;

            if (string.IsNullOrEmpty(txtMontProp.Text)) { txtMontProp.Text = "0.00"; return;}
            nMonto = Convert.ToDecimal (txtMontProp.Text);

            if (string.IsNullOrEmpty(txtTEM.Text)){txtTEM.Text="0.00";return;}
            nTEM = Convert.ToDecimal (txtTEM.Text) / 100.00m;

            if (string.IsNullOrEmpty(txtNroCuotas.Text)) {txtNroCuotas.Text="0";return;}
            nNroCuotas = Convert.ToInt32(txtNroCuotas.Text);

            if (nNroCuotas == 0) return;

            //======== método del plan de pagos para calcular cuotas constantes ===========================>            
            int nDiaGraCta      = Convert.ToInt32(txtDiaGracia.Text);
            short nTipPerPag    = Convert.ToInt16(dtSolicitudCreEmpresarial.Rows[0]["idTipoPeriodo"]);
            int nDiaFecPag      = Convert.ToInt32(txtFrecuencia.Text);
            int nNumsolicitud   = 0;//No es necesario especificar la solicitud, puesto que sólo se necesita el método que calcula cuotas        
            int idMoneda        = Convert.ToInt32(dtSolicitudCreEmpresarial.Rows[0]["IdMoneda"]);

            //Tablas necesarias que por defecto se envían
            DataTable dtConfigGasto     = new DataTable();
            DataTable dtCuotasDobles    = new DataTable();

            DateTime dFecPrimeracuota = dFecDesemb.AddDays(nDiaGraCta);
            clsCNPlanPago CalPlanPago   = new clsCNPlanPago();
            DataTable dtCalendarioPagos = CalPlanPago.CalculaPpgCuotasConstantes(nMonto, nTEM, dFecDesemb, nNroCuotas, nDiaGraCta, nTipPerPag, nDiaFecPag,
                                                       nNumsolicitud, dtConfigGasto, idMoneda, dtCuotasDobles, dFecPrimeracuota);
            //==============================================================================================>
            //Cuota Aproximada Mensualizada
            txtCuotaAprox.Text = dtCalendarioPagos.Rows[0]["imp_cuota"].ToString();

            if (Convert.ToDecimal (txtCuotaAprox.Text) == 0.00m) { txtCoberCuota.Text = "0.00"; return; }

            txtCoberCuota.Text = (Convert.ToDecimal(dtgEstPerdGanan.Rows[11].Cells["nMontoParti"].Value) / Convert.ToDecimal(txtCuotaAprox.Text)).ToString("##,##0.00");
        }     

        private decimal CambioMoneda(int idMoneda,decimal nMonto)
        {
            decimal nMontConvert = 0.00M;
            decimal nTipoCambio = Convert.ToDecimal(dtMaestro.Rows[0]["nTipoCambio"]);

            if (idMoneda == 1)
            {
                nMontConvert = nMonto / nTipoCambio;
                return nMontConvert;
            }
            else 
            {
                nMontConvert = nMonto * nTipoCambio;
                return nMontConvert;
            }
        }

        private void ModificarIdEvalDatagrids()
        {
            if (dtDetalle.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetalle.Rows)
                {
                    row["IdInterno"] = row["IdDetalleEvaEmp"];
                    row["cDetallePeriodo"] = row["cDetalle"];
                    row["IdDetalleEvaEmp"] = -1;
                }
            }

            if (dtCosteoDetalle.Rows.Count > 0)
            {
                foreach (DataRow row in dtCosteoDetalle.Rows)
                {
                    row["IdInterno"] = row["IdDetalleEvaEmp"];
                    row["IdDetalleEvaEmp"] = -1;
                    row["IdCosteo"] = -1;
                }
            }
            if (dtDetCreNegocio.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetCreNegocio.Rows)
                    row["IdDetCrediNego"] = -1;
            }
            if (dtDetCreUniFam.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetCreUniFam.Rows)
                    row["IdDetCrediNego"] = -1;
            }
            if (dtDetGastosPersonal.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetGastosPersonal.Rows)
                    row["IdDetPersonaNego"] = -1;
            }
            if (dtGastServNego.Rows.Count > 0)
            {
                foreach (DataRow row in dtGastServNego.Rows)
                    row["IdDetGastosNego"] = -1;
            }
            if (dtGastUniFam.Rows.Count > 0)
            {
                foreach (DataRow row in dtGastUniFam.Rows)
                    row["IdDetGastosNego"] = -1;
            }
            if (dtBalanceGeneral.Rows.Count > 0)
            {
                foreach (DataRow row in dtBalanceGeneral.Rows)
                    row["IdCuentaCtb"] = -1;
            }

            if (dtEstPerdGana.Rows.Count > 0)
            {
                foreach (DataRow row in dtEstPerdGana.Rows)
                    row["IdEstPerdiGana"] = -1;
            }
            if (dtDetalleFotos.Rows.Count > 0)
            {
                foreach (DataRow row in dtDetalleFotos.Rows)
                    row["IdFotoEvaEmp"] = -1;
            }
            if (dtIntervinientes.Rows.Count > 0)
            {
                foreach (DataRow row in dtIntervinientes.Rows)
                    row["IdTipoIntervEva"] = -1;
            }                    
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public clsListGarantia ConvertToList(DataTable dt)
        {
            PropertyDescriptorCollection properties =TypeDescriptor.GetProperties(typeof(clsGarantia));
            clsListGarantia list = new clsListGarantia();
            foreach (DataRow row in dt.Rows)
            {
                clsGarantia itemGar = new clsGarantia();
                foreach (PropertyDescriptor prop in properties)
                    if (dt.Columns.Contains(prop.Name))
                    {
                        if (prop.PropertyType == typeof(Decimal))
                        {
                            prop.SetValue(itemGar, Convert.ToDecimal (row[prop.Name]));
                        }
                        else
                        {
                            prop.SetValue(itemGar, row[prop.Name]);
                        }
                    }
                list.Add(itemGar);
            }
            return list;
        }      

        #endregion            

        private void ActNomRutFotos()
        {
            string cNuevaRuta = "";

            cNuevaRuta =clsVarApl.dicVarGen["cUrlFotosEvaEmp"] + @"\EvaEmp_"+ Convert.ToInt32(this.conBusCli.txtCodCli.Text) + "_" + this.txtNumEva.Text;
            if (System.IO.Directory.Exists(cRutaFotos))
            {
                DataTable dtDetFotos = this.dtDetalleFotos.Copy();
                foreach (DataRow row in dtDetFotos.Rows)
                {          
                    string cNomFoto = row["cRutaFoto"].ToString().Substring(row["cRutaFoto"].ToString().Length-13,13);
                    while (cNomFoto.Substring(0,1)!="F")
                    {
                        cNomFoto = cNomFoto.Substring(1, cNomFoto.Length - 1);
                    }
                    row["IdEvalEmp"] = this.txtNumEva.Text;
                    row["cRutaFoto"] = cNuevaRuta + @"\"+cNomFoto;
                }
                DataSet dsDetFotos = new DataSet("dsDetFotos");
                dtDetFotos.TableName = "dtDetFotos";
                dsDetFotos.Tables.Add(dtDetFotos);
                string xmlDetFotos = clsCNFormatoXML.EncodingXML(dsDetFotos.GetXml());
                dsDetFotos.Tables.Clear();
                DataTable result = EvalEmp.CNdtActRutasFotos(Convert.ToInt32(this.txtNumEva.Text), xmlDetFotos);
                System.IO.Directory.Move(cRutaFotos,cNuevaRuta);
            }            
        }

        private void frmEvaSolEmp_FormClosing(object sender, FormClosingEventArgs e)
        {
            ElimFotosNoGuardadas();
        }

        private void ElimFotosNoGuardadas()
        {
            if (System.IO.Directory.Exists(cRutaFotos) && !lFlagGuardado)
            {
                string[] filePaths = Directory.GetFiles(cRutaFotos);
                foreach (string filePath in filePaths)
                {
                    File.Delete(filePath);
                }
                System.IO.Directory.Delete(cRutaFotos);
            }
        }

        private void dtgDetEva_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Eliminar el evento cambio de indice (para que el control no se quede con el evento y dispare constantemente el evento)
            if (cboTipoGiro != null)
                cboTipoGiro.SelectedIndexChanged -= new EventHandler(cboTipoGiro_SelectedIndexChanged); 
        }       

        private void dtgComportamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (sender as DataGridView);
            if (dtgComportamiento.Columns[e.ColumnIndex].DisplayIndex == 0)
            {
                dtgComportamiento.CancelEdit();
                return;
            }
            foreach (DataGridViewRow row in datagridview.Rows)
            {
               row.Cells[e.ColumnIndex].Value = false;
            }
            DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)datagridview.CurrentCell;

            bool isChecked = (bool)checkbox.EditedFormattedValue;
            if (!isChecked)
            {
                dtgComportamiento.CancelEdit();
            }

            datagridview.CurrentCell.Value = true;
            
            ActualizarCicloNegocio();
            ActualizarSumaCampos(dtgComportamiento.Columns[e.ColumnIndex].DisplayIndex + 3, e.RowIndex + 1);
            
        }

        private void ActualizarCicloNegocio()
        {
            DateTime dAuxFechaDesembolso = dtpFechaDesembolso.Value;
            for (int c = 3; c < dtVariables.Columns.Count; c++)
            {
                if (dAuxFechaDesembolso.Month == 1)//Enero
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Enero"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Enero"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Enero"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 2)//Febrero
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Febrero"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Febrero"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Febrero"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 3)//Marzo
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Marzo"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Marzo"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Marzo"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 4)//Abril
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Abril"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Abril"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Abril"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 5)//Mayo
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Mayo"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Mayo"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Mayo"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 6)//Junio
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Junio"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Junio"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Junio"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 7)//Julio
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Julio"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Julio"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Julio"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 8)//Agosto
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Agosto"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Agosto"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Agosto"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 9)//Setiembre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Setiembre"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Setiembre"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Setiembre"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 10)//Octubre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Octubre"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Octubre"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Octubre"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 11)//Noviembre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Noviembre"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Noviembre"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Noviembre"])) dtVariables.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 12)//Diciembre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Diciembre"])) dtVariables.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Diciembre"])) dtVariables.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Diciembre"])) dtVariables.Rows[1][c] = "BAJA";
                }
                dAuxFechaDesembolso = dAuxFechaDesembolso.AddMonths(1);
            }           
            DarFormatoGridVariables();
        }

        private DataTable FormarNuevaEstructuraComportamiento()
        {
            DataTable dtCicloEconomico = new DataTable("");

            dtCicloEconomico.Columns.Add("Enero", typeof(bool));
            dtCicloEconomico.Columns.Add("Febrero", typeof(bool));
            dtCicloEconomico.Columns.Add("Marzo", typeof(bool));
            dtCicloEconomico.Columns.Add("Abril", typeof(bool));
            dtCicloEconomico.Columns.Add("Mayo", typeof(bool));
            dtCicloEconomico.Columns.Add("Junio", typeof(bool));
            dtCicloEconomico.Columns.Add("Julio", typeof(bool));
            dtCicloEconomico.Columns.Add("Agosto", typeof(bool));
            dtCicloEconomico.Columns.Add("Setiembre", typeof(bool));
            dtCicloEconomico.Columns.Add("Octubre", typeof(bool));
            dtCicloEconomico.Columns.Add("Noviembre", typeof(bool));
            dtCicloEconomico.Columns.Add("Diciembre", typeof(bool));

            for (int f = 0; f < 3; f++)//3 veces para Alta-Media-Baja
            {
                DataRow dr = dtCicloEconomico.NewRow();
                dr["Enero"]     = 0;
                dr["Febrero"]   = 0;
                dr["Marzo"]     = 0;
                dr["Abril"]     = 0;
                dr["Mayo"]      = 0;
                dr["Junio"]     = 0;
                dr["Julio"]     = 0;
                dr["Agosto"]    = 0;
                dr["Setiembre"] = 0;
                dr["Octubre"]   = 0;
                dr["Noviembre"] = 0;
                dr["Diciembre"] = 0;
                dtCicloEconomico.Rows.Add(dr);
            }
            for (int c = 0; c < dtCicloEconomico.Columns.Count; c++)
                dtCicloEconomico.Rows[1][c] = 1;//Setear x defecto a MEDIA

            return dtCicloEconomico;
        }
        private DataTable FormarNuevaEstructuraVariables(DataTable dtComportamientos)
        {
            DataTable dtVarIngresos = new DataTable("");
            dtVarIngresos.Columns.Add("cDescr", typeof(string));
            dtVarIngresos.Columns.Add("cCampoVacio", typeof(string));
            dtVarIngresos.Columns.Add("IdPorcentVariablesFlujoCaja", typeof(int));

            dtVarIngresos.Rows.Add("% Variación de Ingresos","", 0);
            dtVarIngresos.Rows.Add("Ciclo del Negocio", "",0);

            for (int c = 1; c <= dtComportamientos.Columns.Count; c++)
                dtVarIngresos.Columns.Add("nMes" + c, typeof(string));

            // Cargar el Ciclo del Negocio (BAJA - MEDIA - ALTA) según se definió para el Comportamiento(Año)
            DateTime dAuxFechaDesembolso = dtpFechaDesembolso.Value;
            for (int c = 3; c < dtVarIngresos.Columns.Count; c++)
            {
                if (dAuxFechaDesembolso.Month == 1)//Enero
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Enero"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Enero"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Enero"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 2)//Febrero
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Febrero"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Febrero"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Febrero"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 3)//Marzo
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Marzo"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Marzo"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Marzo"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 4)//Abril
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Abril"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Abril"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Abril"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 5)//Mayo
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Mayo"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Mayo"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Mayo"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 6)//Junio
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Junio"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Junio"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Junio"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 7)//Julio
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Julio"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Julio"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Julio"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 8)//Agosto
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Agosto"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Agosto"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Agosto"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 9)//Setiembre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Setiembre"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Setiembre"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Setiembre"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 10)//Octubre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Octubre"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Octubre"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Octubre"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 11)//Noviembre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Noviembre"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Noviembre"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Noviembre"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                if (dAuxFechaDesembolso.Month == 12)//Diciembre
                {
                    if (Convert.ToBoolean(dtComportamientos.Rows[0]["Diciembre"])) dtVarIngresos.Rows[1][c] = "ALTA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[1]["Diciembre"])) dtVarIngresos.Rows[1][c] = "MEDIA";
                    if (Convert.ToBoolean(dtComportamientos.Rows[2]["Diciembre"])) dtVarIngresos.Rows[1][c] = "BAJA";
                }
                dAuxFechaDesembolso = dAuxFechaDesembolso.AddMonths(1);
            }
            //Setear valores por defecto
            for (int c = 3; c < dtVarIngresos.Columns.Count; c++)
                dtVarIngresos.Rows[0][c] = 0;

            return dtVarIngresos;
        }
        
        private DataTable FormarNuevaEstructuraFCIngresos()
        {
            Decimal nIngresoTotal    = string.IsNullOrEmpty(txtTotVentas.Text)? 0.00m :Convert.ToDecimal (txtTotVentas.Text);
            Decimal nOtrosIngresos   = Convert.ToDecimal (dtgEstPerdGanan["nMontoParti", 7].Value);
            Decimal nPrestamoPrymera = string.IsNullOrEmpty(txtMontProp.Text) ? 0.00m : Convert.ToDecimal(txtMontProp.Text);

            DataTable dtFCIngresos = new DataTable("dtFlujoCajaIngreso");
            dtFCIngresos.Columns.Add("cDescr", typeof(string));
            dtFCIngresos.Columns.Add("idFlujoCajaEvalEmp", typeof(int));
            dtFCIngresos.Columns.Add("IdParametrosFlujoCaja", typeof(int));

            for (int f = 0; f < dtParametros.Rows.Count; f++)
            {
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 1)//INGRESO TOTAL
                    dtFCIngresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 2)//OTROS INGRESOS
                    dtFCIngresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 3)//PRESTAMO PRYMERA
                    dtFCIngresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
            }
            dtFCIngresos.Rows.Add("TOTAL INGRESOS (A)", 0, 0);//CAMPO SUMATORIA

            //Añadir las columnas de los Meses (12)
            for (int c = 1; c <= 12; c++)
                dtFCIngresos.Columns.Add("nMes"+ c, typeof(decimal));

            //Rellenar el Flujo Caja Ingresos
            for (int c = 3; c < dtFCIngresos.Columns.Count; c++)//Por que la 1era: CONCEPTO y la 2da:IdParametrosFlujoCaja
            {
                for (int f = 0; f < dtFCIngresos.Rows.Count; f++)
                {
                    if (f == 0)//INGRESO TOTAL
                    {
                        if (c == 3)
                            dtFCIngresos.Rows[f][c] = Math.Round(nIngresoTotal, 0);
                        else
                            dtFCIngresos.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.INGRESO_TOTAL / 100)) * nIngresoTotal, 0);//No se está consideranado Dolares                            
                    }
                    if (f == 1)//OTROS INGRESOS
                    {
                        if (c == 3)
                            dtFCIngresos.Rows[f][c] = Math.Round(nOtrosIngresos, 0);
                        else
                            dtFCIngresos.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.OTROS_INGRESOS / 100)) * nOtrosIngresos, 0); //No se está consideranado Dolares
                    }
                    if (f == 2)//PRÉSTAMO PRYMERA
                    {
                        if (c == 3)
                            dtFCIngresos.Rows[f][c] = Math.Round(nPrestamoPrymera, 0);
                        else
                            dtFCIngresos.Rows[f][c] = 0;                        
                    }
                    if (f == 3)//TOTAL INGRESOS (A)
                        dtFCIngresos.Rows[f][c] = Math.Round(Convert.ToDecimal(dtFCIngresos.Rows[0][c]) +
                                                            Convert.ToDecimal (dtFCIngresos.Rows[1][c]) +
                                                            Convert.ToDecimal (dtFCIngresos.Rows[2][c]), 0);
                }
            }
            return dtFCIngresos;
        }

        private DataTable FormarNuevaEstructuraFCEgresos()
        {
            Decimal nCostoTotal      = string.IsNullOrEmpty(txtTotCostoCompra.Text) ? 0 : Convert.ToDecimal (txtTotCostoCompra.Text);
            Decimal nGastosPersonal  = string.IsNullOrEmpty(txtTotPuesto.Text) ? 0 : Convert.ToDecimal (txtTotPuesto.Text);
            Decimal nGastosServicionegocio = string.IsNullOrEmpty(txtTotGastosNeg.Text) ? 0 : Convert.ToDecimal (txtTotGastosNeg.Text);
            Decimal nPagoCuotasOtrosBancos = (string.IsNullOrEmpty(txtTotMontCuotaNeg.Text) ? 0 : Convert.ToDecimal (txtTotMontCuotaNeg.Text)) + (string.IsNullOrEmpty(txtTotMontCuotaFam.Text) ? 0 : Convert.ToDecimal (txtTotMontCuotaFam.Text));
            Decimal nCuotasPrymera   = string.IsNullOrEmpty(txtCuotaAprox.Text) ? 0 : Convert.ToDecimal (txtCuotaAprox.Text);
            Decimal nGastoFamiliar   = string.IsNullOrEmpty(txtTotGastosFam.Text) ? 0 : Convert.ToDecimal (txtTotGastosFam.Text);
            Decimal nInversionReinversion = string.IsNullOrEmpty(txtMontProp.Text) ? 0 : Convert.ToDecimal (txtMontProp.Text);

            DataTable dtFCEgresos = new DataTable("dtFlujoCajaEgreso");
            dtFCEgresos.Columns.Add("cDescr", typeof(string));
            dtFCEgresos.Columns.Add("idFlujoCajaEvalEmp", typeof(int));
            dtFCEgresos.Columns.Add("IdParametrosFlujoCaja", typeof(int));

            for (int f = 0; f < dtParametros.Rows.Count; f++)
            {
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 4)//COSTO TOTAL
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 5)//GASTOS DE PERSONAL
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 6)//GASTOS DEL SERVICIO DEL NEGOCIO
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 7)//PAGO DE CUOTAS OTROS BANCOS
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 8)//CUOTAS
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 9)//GASTOS FAMILIAR
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
                if (Convert.ToInt32(dtParametros.Rows[f]["idConcepIngresoEgresoEvalEmp"]) == 10)//INVERSIÓN, REINVERSIÓN
                    dtFCEgresos.Rows.Add(dtParametros.Rows[f]["cConcepIngresoEgreso"].ToString(), 0, Convert.ToInt32(dtParametros.Rows[f]["IdParametrosFlujoCaja"]));
            }

            //SUMATORIAS
            dtFCEgresos.Rows.Add("TOTAL EGRESOS (B)", 0,0);
            dtFCEgresos.Rows.Add("SALDO MENSUAL (A-B)", 0,0);
            dtFCEgresos.Rows.Add("SALDO DE CAJA ANTERIOR", 0,0);
            dtFCEgresos.Rows.Add("SALDO FINAL DE CAJA (C)", 0,0);

            //Añadir las columnas de los Meses (12)
            for (int c = 1; c <= 12; c++)
                dtFCEgresos.Columns.Add("nMes" + c, typeof(decimal));

            //Rellenar el Flujo Caja Egresos
            for (int c = 3; c < dtFCEgresos.Columns.Count; c++)
            {
                for (int f = 0; f < dtFCEgresos.Rows.Count; f++)
                {
                    if (f == 0)//COSTO TOTAL
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = Math.Round(nCostoTotal, 0);
                        else
                            dtFCEgresos.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.COSTO_TOTAL / 100)) * nCostoTotal, 0);//No se está consideranado Dolares                            
                    }
                    if (f == 1)//GASTOS DE PERSONAL
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = Math.Round(nGastosPersonal, 0);
                        else
                            dtFCEgresos.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.GASTOS_PERSONAL / 100)) * nGastosPersonal, 0);//No se está consideranado Dolares
                    }
                    if (f == 2)//GASTOS DEL SERVICIO DEL NEGOCIO
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = Math.Round(nGastosServicionegocio, 0);
                        else
                            dtFCEgresos.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.GASTOS_SERVICIOS_NEGOCIO / 100)) * nGastosServicionegocio, 0);//No se está consideranado Dolares
                    }
                    if (f == 3)//PAGO DE CUOTAS OTROS BANCOS
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = Math.Round(nPagoCuotasOtrosBancos, 0);
                        else                           
                            dtFCEgresos.Rows[f][c] = 0;
                    }
                    if (f == 4)//CUOTAS PRYMERA
                    {
                        dtFCEgresos.Rows[f][c] = Math.Round(nCuotasPrymera, 0);
                    }
                    if (f == 5)//GASTO FAMILIAR
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = Math.Round(nGastoFamiliar, 0);
                        else
                            dtFCEgresos.Rows[f][c] = 0;
                    }
                    if (f == 6)//INVERSIÓN, REINVERSIÓN
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = Math.Round(nInversionReinversion, 0);
                        else
                            dtFCEgresos.Rows[f][c] = 0;
                    }
                    if (f == 7)//TOTAL EGRESOS (B)
                        dtFCEgresos.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFCEgresos.Rows[0][c]) + Convert.ToDecimal (dtFCEgresos.Rows[1][c]) +
                                                                    Convert.ToDecimal (dtFCEgresos.Rows[2][c]) + Convert.ToDecimal (dtFCEgresos.Rows[3][c]) +
                                                                    Convert.ToDecimal (dtFCEgresos.Rows[4][c]) + Convert.ToDecimal (dtFCEgresos.Rows[5][c]) +
                                                                    Convert.ToDecimal (dtFCEgresos.Rows[6][c]), 0);
                    if (f == 8)//AÑADIR FILA: SALDO MENSUAL (A-B)
                    {
                        dtFCEgresos.Rows[f][c] = Math.Round((Convert.ToDecimal (dtgIngresos.Rows[3].Cells[c].Value) - Convert.ToDecimal (dtFCEgresos.Rows[7][c])), 0);
                    }
                    if (f == 9)//SALDO DE CAJA ANTERIOR
                    {
                        if (c == 3)
                            dtFCEgresos.Rows[f][c] = 0;
                        else
                            dtFCEgresos.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFCEgresos.Rows[10][c - 1]), 0);
                    }
                    if (f == 10)//SALDO FINAL DE CAJA (C)
                    {
                        dtFCEgresos.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFCEgresos.Rows[8][c]) + Convert.ToDecimal (dtFCEgresos.Rows[9][c]), 0);
                    }
                }
            }
            return dtFCEgresos;
        }

        private void CargarTipoCambio()
        {
            Decimal nTipoCambio = Convert.ToDecimal (txtTipoCambio.Text);
            dtTipoCambio = new DataTable("dtTipoCambio");
            //Añadir las columnas de los Meses (12)
            for (int c = 1; c <= 12; c++)
                dtTipoCambio.Columns.Add("nMes" + c, typeof(decimal));

            //-------- Formar el Grid de TIPO DE CAMBIO --------------------------------------->
            for (int c = 0; c < dtTipoCambio.Columns.Count; c++)
            {
                if (c == 0)
                {
                    DataRow filaTipoCambio  = dtTipoCambio.NewRow();
                    filaTipoCambio[c]       = nTipoCambio;
                    dtTipoCambio.Rows.Add(filaTipoCambio);
                }
                else
                {
                    dtTipoCambio.Rows[0][c] = nTipoCambio;
                    nTipoCambio = Math.Round((Convert.ToDecimal (dtTipoCambio.Rows[0][c - 1]) * 1.01m), 2);
                }
            }
            //---------------------------------------------------------------------------------> 
            dtgTipoCambio.DataSource = dtTipoCambio;
            dtgTipoCambio.ColumnHeadersVisible = false;
            DarFormatogridTipoCambio();
        }

        private void ActualizarSumaCampos(int nColumna, int nFila)//Actualiza la suma de Campos del Flujo de Caja
        {

            //Variables para INGRESO
            Decimal nIngresoTotal    = string.IsNullOrEmpty(txtTotVentas.Text) ? 0.00m: Convert.ToDecimal (txtTotVentas.Text);
            Decimal nOtrosIngresos   = Convert.ToDecimal (dtgEstPerdGanan["nMontoParti", 7].Value);
            Decimal nPrestamoPrymera = string.IsNullOrEmpty(txtMontProp.Text) ? 0.00m: Convert.ToDecimal (txtMontProp.Text);

            //Variables para EGRESO
            Decimal nCostoTotal              = string.IsNullOrEmpty(txtTotCostoCompra.Text) ? 0 : Convert.ToDecimal (txtTotCostoCompra.Text);
            Decimal nGastosPersonal          = string.IsNullOrEmpty(txtTotPuesto.Text) ? 0 : Convert.ToDecimal (txtTotPuesto.Text);
            Decimal nGastosServicionegocio   = string.IsNullOrEmpty(txtTotGastosNeg.Text) ? 0 : Convert.ToDecimal (txtTotGastosNeg.Text);
            Decimal nPagoCuotasOtrosBancos   = (string.IsNullOrEmpty(txtTotMontCuotaNeg.Text) ? 0 : Convert.ToDecimal (txtTotMontCuotaNeg.Text)) + (string.IsNullOrEmpty(txtTotMontCuotaFam.Text) ? 0 : Convert.ToDecimal (txtTotMontCuotaFam.Text));

            Decimal nCuotasPrymera = string.IsNullOrEmpty(txtCuotaAprox.Text) ? 0 : Convert.ToDecimal (txtCuotaAprox.Text);
            if (txtCuotaAprox.Text.Equals("NeuN"))
            {
                nCuotasPrymera = 0.00m;
            }
            Decimal nGastoFamiliar           = string.IsNullOrEmpty(txtTotGastosFam.Text) ? 0 : Convert.ToDecimal (txtTotGastosFam.Text);
            Decimal nInversionReinversion    = string.IsNullOrEmpty(txtMontProp.Text) ? 0 : Convert.ToDecimal (txtMontProp.Text);



            Decimal nValorVariable =0.00m;

            if (dtgVariables.Rows[1].Cells[nColumna].Value.ToString().ToUpper() == "ALTA" )
            {
                nValorVariable = Convert.ToDecimal (dtgVariables.Rows[0].Cells[nColumna].Value) ;
            }
            else if (dtgVariables.Rows[1].Cells[nColumna].Value.ToString().ToUpper() == "BAJA" )
            {
                nValorVariable = Convert.ToDecimal (dtgVariables.Rows[0].Cells[nColumna].Value) * (-1);
            }

            //INGRESOS
            //for (int c = 3; c < dtFlujoCajaIngreso.Columns.Count; c++)//Por que la 1era: CONCEPTO y la 2da:IdParametrosFlujoCaja
            //{
                for (int f = 0; f < dtFlujoCajaIngreso.Rows.Count; f++)
                {
                    
                    if (f == 0)//INGRESO TOTAL
                    {
                        if (nColumna == 3)
                            dtFlujoCajaIngreso.Rows[f][nColumna] = Math.Round(nIngresoTotal, 0, MidpointRounding.ToEven);
                        else
                            dtFlujoCajaIngreso.Rows[f][nColumna] = Math.Round(nIngresoTotal + ((nValorVariable / 100.00m) * (ParametrosFlujoCaja.INGRESO_TOTAL / 100.00m) * nIngresoTotal), 0);//No se está consideranado Dolares                            
                        continue;
                    }
                    if (f == 1)//OTROS INGRESOS
                    {
                        if (nColumna == 3)
                            dtFlujoCajaIngreso.Rows[f][nColumna] = Math.Round(nOtrosIngresos, 0, MidpointRounding.ToEven);
                        else
                            dtFlujoCajaIngreso.Rows[f][nColumna] = Math.Round((nOtrosIngresos + ((nValorVariable / 100.00m) * (ParametrosFlujoCaja.OTROS_INGRESOS / 100.00m) * nOtrosIngresos)), 0); //No se está consideranado Dolares
                        continue;
                    }
                    if (f == 2)//PRÉSTAMO PRYMERA
                    {
                        if (nColumna == 3)
                            dtFlujoCajaIngreso.Rows[f][nColumna] = Math.Round(nPrestamoPrymera, 0, MidpointRounding.ToEven);
                        else
                            dtFlujoCajaIngreso.Rows[f][nColumna] = 0;
                        continue;
                    }
                    if (f == 3)//TOTAL INGRESOS (A)
                        dtFlujoCajaIngreso.Rows[f][nColumna] = Math.Round(Convert.ToDecimal (dtFlujoCajaIngreso.Rows[0][nColumna]) +
                                                                    Convert.ToDecimal (dtFlujoCajaIngreso.Rows[1][nColumna]) +
                                                                    Convert.ToDecimal (dtFlujoCajaIngreso.Rows[2][nColumna]), 0);

                }
            //}
            dtgIngresos.Rows[0].Cells[4].Selected = true;
            dtgIngresos.Rows[0].Cells[4].Selected = false;            
            
            for (int f = 0; f < dtgEgresos.Rows.Count; f++)
            {
                if (f == 0)//COSTO TOTAL
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round((nCostoTotal + ((nValorVariable / 100) * (ParametrosFlujoCaja.COSTO_TOTAL / 100) * nCostoTotal)), 0, MidpointRounding.ToEven);//No se está consideranado Dolares                            
                    continue;
                }
                if (f == 1)//GASTOS DE PERSONAL
                {
                    //dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round((1 + (nValorVariable / 100) * (ParametrosFlujoCaja.GASTOS_PERSONAL / 100)) * nGastosPersonal, 0, MidpointRounding.ToEven);//No se está consideranado Dolares
                    continue;
                }
                if (f == 2)//GASTOS DEL SERVICIO DEL NEGOCIO
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round((nGastosServicionegocio + ((nValorVariable / 100) * (ParametrosFlujoCaja.GASTOS_SERVICIOS_NEGOCIO / 100) * nGastosServicionegocio)), 0, MidpointRounding.ToEven);//No se está consideranado Dolares
                    continue;
                }
                if (f == 3)//PAGO DE CUOTAS OTROS BANCOS
                {
                    //dtgEgresos.Rows[f].Cells[nColumna].Value = 0;
                    continue;
                }
                if (f == 4)//CUOTAS PRYMERA
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round(nCuotasPrymera, 0, MidpointRounding.ToEven);
                    continue;
                }
                if (f == 5)//GASTO FAMILIAR
                {
                    //dtgEgresos.Rows[f].Cells[nColumna].Value = 0;
                    continue;
                }
                if (f == 6)//INVERSIÓN, REINVERSIÓN
                {
                    //dtgEgresos.Rows[f].Cells[nColumna].Value = 0;
                    continue;
                }
                if (f == 7)//TOTAL EGRESOS (B)
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round(  Convert.ToDecimal (dtgEgresos.Rows[0].Cells[nColumna].Value) + Convert.ToDecimal (dtgEgresos.Rows[1].Cells[nColumna].Value) +
                                                                            Convert.ToDecimal (dtgEgresos.Rows[2].Cells[nColumna].Value) + Convert.ToDecimal (dtgEgresos.Rows[3].Cells[nColumna].Value) +
                                                                            Convert.ToDecimal (dtgEgresos.Rows[4].Cells[nColumna].Value) + Convert.ToDecimal (dtgEgresos.Rows[5].Cells[nColumna].Value) +
                                                                            Convert.ToDecimal (dtgEgresos.Rows[6].Cells[nColumna].Value), 0, MidpointRounding.ToEven);
                    continue;
                }
                if (f == 8)//ANADIR FILA: SALDO MENSUAL (A-B)
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round(Convert.ToDecimal (dtgIngresos.Rows[3].Cells[nColumna].Value) - Convert.ToDecimal (dtgEgresos.Rows[7].Cells[nColumna].Value), 0, MidpointRounding.ToEven);
                    continue;
                }
                if (f == 9)//SALDO DE CAJA ANTERIOR
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round(Convert.ToDecimal (dtgEgresos.Rows[10].Cells[nColumna - 1].Value), 0, MidpointRounding.ToEven);
                    continue;
                }
                if (f == 10)//SALDO FINAL DE CAJA (C)
                {
                    dtgEgresos.Rows[f].Cells[nColumna].Value = Math.Round(Convert.ToDecimal (dtgEgresos.Rows[8].Cells[nColumna].Value) + Convert.ToDecimal (dtgEgresos.Rows[9].Cells[nColumna].Value), 0, MidpointRounding.ToEven);
                    continue;
                }                
            }
            
            //Actualizar Sumas de EGRESOS
            for (int c = 3; c < dtgEgresos.Columns.Count; c++)
            {
                for (int f = 0; f < dtgEgresos.Rows.Count; f++)
                {
                    if (f == 7)//TOTAL EGRESOS (B)
                    {
                        dtgEgresos.Rows[f].Cells[c].Value = Math.Round( Convert.ToDecimal (dtgEgresos.Rows[0].Cells[c].Value) + Convert.ToDecimal (dtgEgresos.Rows[1].Cells[c].Value) +
                                                                        Convert.ToDecimal (dtgEgresos.Rows[2].Cells[c].Value) + Convert.ToDecimal (dtgEgresos.Rows[3].Cells[c].Value) +
                                                                        Convert.ToDecimal (dtgEgresos.Rows[4].Cells[c].Value) + Convert.ToDecimal (dtgEgresos.Rows[5].Cells[c].Value) +
                                                                        Convert.ToDecimal (dtgEgresos.Rows[6].Cells[c].Value), 0);
                        continue;
                    }
                    if (f == 8)//ANADIR FILA: SALDO MENSUAL (A-B)
                    {
                        dtgEgresos.Rows[f].Cells[c].Value = Math.Round(Convert.ToDecimal (dtgIngresos.Rows[3].Cells[c].Value) - Convert.ToDecimal (dtgEgresos.Rows[7].Cells[c].Value), 0);
                        continue;
                    }
                    if (f == 9)//SALDO DE CAJA ANTERIOR
                    {
                        dtgEgresos.Rows[f].Cells[c].Value = Math.Round(Convert.ToDecimal (dtgEgresos.Rows[10].Cells[c - 1].Value), 0);
                        continue;
                    }
                    if (f == 10)//SALDO FINAL DE CAJA (C)
                    {
                        dtgEgresos.Rows[f].Cells[c].Value = Math.Round(Convert.ToDecimal (dtgEgresos.Rows[8].Cells[c].Value) + Convert.ToDecimal (dtgEgresos.Rows[9].Cells[c].Value), 0);
                        continue;
                    }
                }
            }
            //ACTUALIZAR EL SALDO DE CAJA ANTERIOR
            for (int c = 3; c < this.dtgEgresos.Columns.Count; c++)
                dtgEgresos.Rows[9].Cells[c].Value = Math.Round(Convert.ToDecimal (dtgEgresos.Rows[10].Cells[c-1].Value), 0);

            //Para evitar el sobrepintado
            dtgEgresos.Rows[0].Selected = true;
            dtgEgresos.Rows[0].Selected = false;
        }

        private void ActualizaFlujoCajaPrimerPeriodo()
        {
            Decimal nIngresoTotal    = string.IsNullOrEmpty(txtTotVentas.Text) ? 0.00m : Convert.ToDecimal (txtTotVentas.Text);
            if (dtgEstPerdGanan.Columns.Count == 0)
            {
                return;
            }
            Decimal nOtrosIngresos   = Convert.ToDecimal (dtgEstPerdGanan["nMontoParti", 7].Value);
            Decimal nPrestamoPrymera = string.IsNullOrEmpty(txtMontProp.Text) ? 0.00m : Convert.ToDecimal (txtMontProp.Text);

            if (dtFlujoCajaIngreso!=null)
            {
                //INGRESOS
                for (int c = 3; c < dtFlujoCajaIngreso.Columns.Count; c++)//Por que la 1era: CONCEPTO y la 2da:IdParametrosFlujoCaja
                {
                    for (int f = 0; f < dtFlujoCajaIngreso.Rows.Count; f++)
                    {
                        if (f == 0)//INGRESO TOTAL
                        {
                            if (c == 3)
                                dtFlujoCajaIngreso.Rows[f][c] = Math.Round(nIngresoTotal, 0);
                            else
                                dtFlujoCajaIngreso.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.INGRESO_TOTAL / 100)) * nIngresoTotal, 0);//No se está consideranado Dolares                            
                        }
                        if (f == 1)//OTROS INGRESOS
                        {
                            if (c == 3)
                                dtFlujoCajaIngreso.Rows[f][c] = Math.Round(nOtrosIngresos, 0);
                            else
                                dtFlujoCajaIngreso.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.OTROS_INGRESOS / 100)) * nOtrosIngresos, 0); //No se está consideranado Dolares
                        }
                        if (f == 2)//PRÉSTAMO PRYMERA
                        {
                            if (c == 3)
                                dtFlujoCajaIngreso.Rows[f][c] = Math.Round(nPrestamoPrymera, 0);
                            else
                                dtFlujoCajaIngreso.Rows[f][c] = 0;
                        }
                        if (f == 3)//TOTAL INGRESOS (A)
                            dtFlujoCajaIngreso.Rows[f][c] = Math.Round( Convert.ToDecimal (dtFlujoCajaIngreso.Rows[0][c]) +
                                                                        Convert.ToDecimal (dtFlujoCajaIngreso.Rows[1][c]) +
                                                                        Convert.ToDecimal (dtFlujoCajaIngreso.Rows[2][c]), 0);
                    }
                }
            }            

            Decimal nCostoTotal      = string.IsNullOrEmpty(txtTotCostoCompra.Text)  ? 0 : Convert.ToDecimal (txtTotCostoCompra.Text);
            Decimal nGastosPersonal  = string.IsNullOrEmpty(txtTotPuesto.Text)       ? 0 : Convert.ToDecimal (txtTotPuesto.Text);
            Decimal nGastosServicionegocio = string.IsNullOrEmpty(txtTotGastosNeg.Text) ? 0 : Convert.ToDecimal (txtTotGastosNeg.Text);
            Decimal nPagoCuotasOtrosBancos = Convert.ToDecimal (dtgEstPerdGanan["nMontoParti", 5].Value);

            Decimal nCuotasPrymera   = string.IsNullOrEmpty(txtCuotaAprox.Text) ? 0 : Convert.ToDecimal (txtCuotaAprox.Text);
            if (txtCuotaAprox.Text.Equals("NeuN"))
            {
                nCuotasPrymera = 0.00m;
            }
            Decimal nGastoFamiliar   = string.IsNullOrEmpty(txtTotGastosFam.Text)    ? 0 : Convert.ToDecimal (txtTotGastosFam.Text);
            Decimal nInversionReinversion = string.IsNullOrEmpty(txtMontProp.Text)   ? 0 : Convert.ToDecimal (txtMontProp.Text);

            if (dtFlujoCajaEgreso != null)
            {
                //EGRESOS
                for (int c = 3; c < dtFlujoCajaEgreso.Columns.Count; c++)
                {
                    for (int f = 0; f < dtFlujoCajaEgreso.Rows.Count; f++)
                    {
                        if (f == 0)//COSTO TOTAL
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nCostoTotal, 0);
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.COSTO_TOTAL / 100)) * nCostoTotal, 0);//No se está consideranado Dolares                            
                        }
                        if (f == 1)//GASTOS DE PERSONAL
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nGastosPersonal, 0);
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.GASTOS_PERSONAL / 100)) * nGastosPersonal, 0);//No se está consideranado Dolares
                        }
                        if (f == 2)//GASTOS DEL SERVICIO DEL NEGOCIO
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nGastosServicionegocio, 0);
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.GASTOS_SERVICIOS_NEGOCIO / 100)) * nGastosServicionegocio, 0);//No se está consideranado Dolares
                        }
                        if (f == 3)//PAGO DE CUOTAS OTROS BANCOS
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nPagoCuotasOtrosBancos, 0);
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = 0;
                        }
                        if (f == 4)//CUOTAS PRYMERA
                        {
                            dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nCuotasPrymera, 0);
                        }
                        if (f == 5)//GASTO FAMILIAR
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nGastoFamiliar, 0);
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round((1 + (Convert.ToDecimal (dtVariables.Rows[0][c]) / 100) * (ParametrosFlujoCaja.GASTOS_FAMILIAR / 100)) * nGastoFamiliar, 0);//No se está consideranado Dolares
                        }
                        if (f == 6)//INVERSIÓN, REINVERSIÓN
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(nInversionReinversion, 0);
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = 0;
                        }
                        if (f == 7)//TOTAL EGRESOS (B)
                            dtFlujoCajaEgreso.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFlujoCajaEgreso.Rows[0][c]) + Convert.ToDecimal (dtFlujoCajaEgreso.Rows[1][c]) +
                                                                        Convert.ToDecimal(dtFlujoCajaEgreso.Rows[2][c]) + Convert.ToDecimal(dtFlujoCajaEgreso.Rows[3][c]) +
                                                                        Convert.ToDecimal(dtFlujoCajaEgreso.Rows[4][c]) + Convert.ToDecimal(dtFlujoCajaEgreso.Rows[5][c]) +
                                                                        Convert.ToDecimal(dtFlujoCajaEgreso.Rows[6][c]), 0);
                        if (f == 8)//AÑADIR FILA: SALDO MENSUAL (A-B)
                        {
                            dtFlujoCajaEgreso.Rows[f][c] = Math.Round((Convert.ToDecimal (dtgIngresos.Rows[3].Cells[c].Value) - Convert.ToDecimal (dtFlujoCajaEgreso.Rows[7][c])), 0);
                        }
                        if (f == 9)//SALDO DE CAJA ANTERIOR
                        {
                            if (c == 3)
                                dtFlujoCajaEgreso.Rows[f][c] = 0;
                            else
                                dtFlujoCajaEgreso.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFlujoCajaEgreso.Rows[10][c - 1]), 0);
                        }
                        if (f == 10)//SALDO FINAL DE CAJA (C)
                        {
                            dtFlujoCajaEgreso.Rows[f][c] = Math.Round(Convert.ToDecimal (dtFlujoCajaEgreso.Rows[8][c]) + Convert.ToDecimal (dtFlujoCajaEgreso.Rows[9][c]), 0);
                        }
                    }
                }
            }            
        }

        private void DarFormatogridTipoCambio()
        {
            if (dtgTipoCambio.Rows!=null)
            {
                for (int c = 0; c < dtgTipoCambio.Rows.Count; c++)
                {
                    dtgTipoCambio.Columns[c].Width = 73;
                }
                dtgTipoCambio.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
                dtgTipoCambio.RowsDefaultCellStyle.SelectionBackColor = Color.White;
            }            
        }
        private void DarFormatogridIngresos()
        {
            if (dtgIngresos.Rows.Count > 0)
            {
                dtgIngresos.ReadOnly = true;
                for (int c = 0; c < dtgIngresos.Columns.Count; c++)
                {
                    if (c == 0)
                    {
                        dtgIngresos.Columns[c].Width = 140;
                        dtgIngresos.Columns[c].HeaderText = "INGRESOS:";
                    }
                    else
                    {
                        if(c>=3)
                            dtgIngresos.Columns[c].Width = 73;
                        else
                            dtgIngresos.Columns[c].Width = 1;
                    }
                        
                }
                dtgIngresos.Rows[3].DefaultCellStyle.BackColor = Color.SkyBlue;

                DateTime dAuxFechaDesembolso = dtpFechaDesembolso.Value;
                //Nombre de Encabezado
                for (int c = 3; c < dtgIngresos.Columns.Count; c++)
                {
                    if (dAuxFechaDesembolso.Month == 1)
                        dtgIngresos.Columns[c].HeaderText = "Enero";
                    else if (dAuxFechaDesembolso.Month == 2)
                        dtgIngresos.Columns[c].HeaderText = "Febrero";
                    else if (dAuxFechaDesembolso.Month == 3)
                        dtgIngresos.Columns[c].HeaderText = "Marzo";
                    else if (dAuxFechaDesembolso.Month == 4)
                        dtgIngresos.Columns[c].HeaderText = "Abril";
                    else if (dAuxFechaDesembolso.Month == 5)
                        dtgIngresos.Columns[c].HeaderText = "Mayo";
                    else if (dAuxFechaDesembolso.Month == 6)
                        dtgIngresos.Columns[c].HeaderText = "Junio";
                    else if (dAuxFechaDesembolso.Month == 7)
                        dtgIngresos.Columns[c].HeaderText = "Julio";
                    else if (dAuxFechaDesembolso.Month == 8)
                        dtgIngresos.Columns[c].HeaderText = "Agosto";
                    else if (dAuxFechaDesembolso.Month == 9)
                        dtgIngresos.Columns[c].HeaderText = "Setiembre";
                    else if (dAuxFechaDesembolso.Month == 10)
                        dtgIngresos.Columns[c].HeaderText = "Octubre";
                    else if (dAuxFechaDesembolso.Month == 11)
                        dtgIngresos.Columns[c].HeaderText = "Noviembre";
                    else
                        dtgIngresos.Columns[c].HeaderText = "Diciembre";
                    dAuxFechaDesembolso = dAuxFechaDesembolso.AddMonths(1);
                    //Alineación texto
                    dtgIngresos.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                dtgIngresos.Columns["idFlujoCajaEvalEmp"].Visible       = false;
                dtgIngresos.Columns["IdParametrosFlujoCaja"].Visible    = false;

                dtgIngresos.Rows[0].Selected = true;
                dtgIngresos.Rows[0].Selected = false;
            }
        }

        private void DarFormatoGridEgresos()
        {
            if (dtgEgresos.Rows != null)
            {
                dtgEgresos.ReadOnly = false;
                //Formato de Cabecera
                for (int c = 0; c < dtgEgresos.Columns.Count; c++)
                {
                    if (c == 0)
                    {
                        dtgEgresos.Columns[c].Width = 140;
                        dtgEgresos.Columns[c].HeaderText = "EGRESOS:";
                    }
                    else
                    {
                        if (c >= 3)
                        {
                            dtgEgresos.Columns[c].Width = 73;
                            dtgEgresos.Columns[c].HeaderText = "";
                        }
                        else
                            dtgEgresos.Columns[c].Width = 1;  
                    }
                }

                //Habilitar Secciones para rellenado                               
                for (int f = 0; f < dtgEgresos.Rows.Count; f++)
                {
                    for (int c = 0; c < dtgEgresos.Columns.Count; c++)
                    {
                        //COSTO TOTAL
                        //GASTOS DEL SERVICIO DEL NEGOCIO
                        //CUOTAS PRYMERA
                        if (f == 0 || f == 2 || f == 4 ||
                            f == 7 || f == 8 | f == 9 || f == 10)//CAMPOS SUMAS
                        {
                            dtgEgresos.Rows[f].Cells[c].ReadOnly = true;
                            //Alineación Texto
                            if (c>1)
                                dtgEgresos.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        //GASTOS PERSONAL
                        //PAGO DE CUOTAS OTROS BANCOS
                        //GASTO FAMILIAR  
                        //INVERSIÓN, REINVERSIÓN
                        if (f == 1 || f == 3 || f == 5 || f == 6)
                        {
                            if (c<=3)
                            {
                                dtgEgresos.Rows[f].Cells[c].ReadOnly = true;
                                //Alineación Texto
                                if (c > 0)
                                    dtgEgresos.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            else
                            {
                                dtgEgresos.Rows[f].Cells[c].ReadOnly        = false;
                                dtgEgresos.Rows[f].Cells[c].Style.BackColor = Color.Yellow;
                                //Alineación Texto
                                    dtgEgresos.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }                            
                        }                       
                    }
                }
                dtgEgresos.Rows[7].DefaultCellStyle.BackColor   = Color.SkyBlue;
                dtgEgresos.Rows[10].DefaultCellStyle.BackColor  = Color.SkyBlue;

                foreach (DataGridViewColumn column in dtgEgresos.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dtgEgresos.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
                dtgEgresos.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

                dtgEgresos.Columns["IdParametrosFlujoCaja"].Visible = false;
                dtgEgresos.Columns["idFlujoCajaEvalEmp"].Visible = false;
                //Para evitar el sobrepintado
                dtgEgresos.Rows[0].Selected = true;
                dtgEgresos.Rows[0].Selected = false;
            }
        }

        private void DarFormatoGridVariables()
        {
            if (dtgVariables.Rows != null)
            {
                dtgVariables.ReadOnly = false;
                for (int c = 0; c < dtgVariables.Columns.Count; c++)
                {
                    if (c == 0)
                    {
                        dtgVariables.Columns[c].Width = 140;
                        dtgVariables.Columns[c].HeaderText = "VARIABLES:";
                        dtgVariables.Columns[c].ReadOnly = true;
                        dtgVariables.Rows[c].Cells[1].ReadOnly = true;
                    }
                    else
                    {
                        if (c == 3)
                        {
                            dtgVariables.Columns[c].HeaderText = "";
                            dtgVariables.Rows[0].Cells[c].ReadOnly = true;
                            dtgVariables.Rows[1].Cells[c].ReadOnly = true;
                        }
                        else if (c > 2)
                        {
                            dtgVariables.Columns[c].Width = 73;
                            dtgVariables.Columns[c].HeaderText = "";
                            dtgVariables.Rows[1].Cells[c].ReadOnly = true;
                            dtgVariables.Rows[0].Cells[c].Style.BackColor = Color.Yellow;
                        }
                        else
                            dtgVariables.Columns[c].Width = 1;
                    }                    
                    //PINTANDO 
                    if (dtgVariables.Rows[1].Cells[c].Value.ToString().Equals("ALTA"))
                    {
                        dtgVariables.Rows[1].Cells[c].Style.BackColor = Color.LimeGreen;
                    }
                    else if (dtgVariables.Rows[1].Cells[c].Value.ToString().Equals("MEDIA"))
                    {
                        dtgVariables.Rows[1].Cells[c].Style.BackColor = Color.LightYellow;
                    }
                    else//BAJA
                    {
                        if (dtgVariables.Rows[1].Cells[c].Value.ToString().Equals("BAJA"))
                            dtgVariables.Rows[1].Cells[c].Style.BackColor = Color.OrangeRed;
                    }
                    //Alineación texto
                    dtgVariables.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;                    
                }
                foreach (DataGridViewColumn column in dtgVariables.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dtgVariables.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
                dtgVariables.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

                dtgVariables.Columns["IdPorcentVariablesFlujoCaja"].Visible = false;
                dtgVariables.Columns["cCampoVacio"].Visible = false;

                //Para evitar el sobrepintado
                dtgVariables.Rows[1].Selected = true;
                dtgVariables.Rows[1].Selected = false;
            }
        }        

        private void dtgEgresos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            txtbox.MaxLength = 6;
            int columnIng = dtgEgresos.CurrentCell.ColumnIndex;
            if (columnIng > 3 && columnIng < 13 && txtbox != null)
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress); 
        }

        private void dtgVariables_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            txtbox.MaxLength = 6;
            int columnIng = dtgVariables.CurrentCell.ColumnIndex;
            if (columnIng > 3 && columnIng < 13 && txtbox != null)
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress); 
        }

        private void dtgEgresos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEgresos.CurrentCell != null)
            {                
                int columnIng   = dtgEgresos.CurrentCell.ColumnIndex;
                int filaIng     = dtgEgresos.CurrentCell.RowIndex;
                if (columnIng > 1)
                {
                    dtgEgresos.EndEdit();
                    ActualizarSumaCampos(columnIng, filaIng); 
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

        private void txtTotVentas_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void txtMontProp_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void txtCuotaAprox_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void txtNroCuotas_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void txtTEM_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void txtTotMontCuotaNeg_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void txtTotMontCuotaFam_TextChanged(object sender, EventArgs e)
        {
            //Actualizar Flujo Caja
            ActualizaFlujoCajaPrimerPeriodo();
        }

        private void btnEditDetEva_Click(object sender, EventArgs e)
        {
            if (dtgDetEva.RowCount > 0)
            {
                if (dtgDetEva.CurrentCell != null)
                {
                    var dtDetEva = (DataTable)dtgDetEva.DataSource;
                    var dr = dtDetEva.Rows[dtgDetEva.CurrentCell.RowIndex];
                    var dtDetalleCosteoNuevo = (DataTable)dtgCosteo.DataSource;

                    frmDetIngEvaEmp frmdetingreso = new frmDetIngEvaEmp(dr, dtDetalleCosteoNuevo, dtMaestro, Transaccion.Edita);
                    frmdetingreso.ShowDialog();
                    dtCosteoDetalle = dtDetalleCosteoNuevo;
                    dtDetalle.AcceptChanges();
                    this.dtgDetEva.Refresh();
                    TotalFinalDetalle();
                    ActualizarBalance();
                }
            }
        }

        private void tabCualitativo_Click(object sender, EventArgs e)
        {

        }

        private void cargarDatosPropuesta(int idSolicitud)
        {
            DataTable dtPropuesta = Evalua.CNConsPropuesta(idSolicitud);
            if (dtPropuesta.Rows.Count > 0)
            {
                txtDetNegocio.Text = dtPropuesta.Rows[0]["cNegocio"].ToString();
                txtDetDestino.Text = dtPropuesta.Rows[0]["cExpCrediticia"].ToString();
                txtDetExperiencia.Text = dtPropuesta.Rows[0]["cDestinoCredito"].ToString();
                txtDetEntorno.Text = dtPropuesta.Rows[0]["cEntornoFamiliar"].ToString();
                txtDetEvaluacion.Text = dtPropuesta.Rows[0]["cEvaluacion"].ToString();
                txtDetGarantia.Text = dtPropuesta.Rows[0]["cGarantia"].ToString();
                txtConclusiones.Text = dtPropuesta.Rows[0]["cConclusiones"].ToString();
            }
            else
            {
                txtDetNegocio.Focus();
            }
        }

        private void guardarDatosPropuesta(int idSolicitud)
        {
            decimal nGarantia =  txtGarantia.nDecValor;
            string cNegocio = txtDetNegocio.Text;
            string cDestino = txtDetDestino.Text;
            string cExperiencia = txtDetExperiencia.Text;
            string cEntorno = txtDetEntorno.Text;
            string cEvalua = txtDetEvaluacion.Text;
            string cGarantia = txtDetGarantia.Text;
            string cConclusion = txtConclusiones.Text;

            DataTable dtResultado = Evalua.CNInsUpdPropuesta(idSolicitud, nGarantia, cNegocio, cExperiencia,
                    cDestino, cEntorno, cEvalua, cGarantia, cConclusion);

            if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 0)
            {
                MessageBox.Show("Error en Grabación de Propuesta de Crédito Empresarial", "Propuesta de Crédito Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);      
            }
        }

        private void imprimirDatosPropuesta(int idSolicitud)
        {
            var dtPropuesta=Evalua.CNConsPropuestaCre(idSolicitud);
            if (dtPropuesta.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("x_idSolicitud", idSolicitud.ToString(), false));

                DataTable dtRutaLogo = new clsRPTCNAgencia().CNRutaLogo();

                dtslist.Add(new ReportDataSource("dtsRutaLogo", dtRutaLogo));
                dtslist.Add(new ReportDataSource("dtsComentarios", Evalua.CNConsPropuesta(idSolicitud)));
                dtslist.Add(new ReportDataSource("dtsDatoCredito", dtPropuesta));
                dtslist.Add(new ReportDataSource("dtsExcepciones", Evalua.CNConsExcepciones(idSolicitud)));

                string reportpath = "RptPropuestaCredito.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor primero debe de vincular la evaluación con la solicitud", "Validación de vinculación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Vincular.PerformClick();
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            imprimirDatosPropuesta(Convert.ToInt32(dtSolicitudCreEmpresarial.Rows[0]["idSolicitud"]));
        }

        private void dtgVariables_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgVariables.CurrentCell != null)
            {
                int columnIng = dtgVariables.CurrentCell.ColumnIndex;
                int filaIng = 0;
                if (columnIng > 1)
                {
                    if (dtgVariables.Rows[filaIng].Cells[columnIng].Value == System.DBNull.Value)
                    {
                        dtgVariables.Rows[filaIng].Cells[columnIng].Value = 0;
                    }
                    if (dtgVariables.Rows[filaIng + 1].Cells[columnIng].Value.ToString().ToUpper() == "MEDIA")
                    {
                        dtgVariables.Rows[filaIng].Cells[columnIng].Value = 0;
                    }
                    dtgVariables.EndEdit();
                    ActualizarSumaCampos(columnIng, filaIng);
                }
            }
        }

       
    }
}
