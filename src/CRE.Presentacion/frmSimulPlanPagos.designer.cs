namespace CRE.Presentacion
{
    partial class frmSimulPlanPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimulPlanPagos));
            CRE.CapaNegocio.clsCNPlanPago clsCNPlanPago2 = new CRE.CapaNegocio.clsCNPlanPago();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblTasaInteres = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMonAprobado = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasaInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.nudDiasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.conCreditoPrimeraCuota = new GEN.ControlesBase.ConCreditoPrimeraCuota();
            this.conCreditoPeriodo = new GEN.ControlesBase.ConCreditoPeriodo();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.cboClasificacionInterna1 = new GEN.ControlesBase.cboClasificacionInterna(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboTipoTasaCredito = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipoPersona = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.cboFuenteRecurso = new GEN.ControlesBase.cboFuenteRecurso(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtTasCompensatoriaMax = new GEN.ControlesBase.txtBase(this.components);
            this.txtTasCompensatoriaMin = new GEN.ControlesBase.txtBase(this.components);
            this.cboSubProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.dtpFecDesembolso = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.nudNumCuota = new GEN.ControlesBase.nudBase(this.components);
            this.cboSubTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.cboTipoCredito = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase20 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase26 = new GEN.ControlesBase.lblBase();
            this.lblBase27 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase31 = new GEN.ControlesBase.lblBase();
            this.lblBase24 = new GEN.ControlesBase.lblBase();
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.grbGastos = new GEN.ControlesBase.grbBase(this.components);
            this.txtValorCarga = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboAplicaCuota = new System.Windows.Forms.ComboBox();
            this.chcMantenerCuotasCtes = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblPorcentaje = new GEN.ControlesBase.lblBase();
            this.dtgConfigGasto = new GEN.ControlesBase.dtgBase(this.components);
            this.cboTipoValor = new GEN.ControlesBase.cboTipoValor(this.components);
            this.btnAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.lblTipoGasto = new GEN.ControlesBase.lblBase();
            this.btnQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.cboGrupoGasto = new System.Windows.Forms.ComboBox();
            this.cboTipoGasto = new System.Windows.Forms.ComboBox();
            this.lblGrupoGasto = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboAplicaConcepto = new System.Windows.Forms.ComboBox();
            this.lblTipoValor = new GEN.ControlesBase.lblBase();
            this.lblAplicaCuota = new GEN.ControlesBase.lblBase();
            this.lblAfectacion = new GEN.ControlesBase.lblBase();
            this.tbcPlnaPagos = new GEN.ControlesBase.tbcBase(this.components);
            this.tabParametros = new System.Windows.Forms.TabPage();
            this.btnHabilitarSeguro = new GEN.BotonesBase.btnBlanco();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnProcesaPpg = new GEN.BotonesBase.btnProcesar();
            this.tabCalendario = new System.Windows.Forms.TabPage();
            this.conPlanPagos1 = new GEN.ControlesBase.conPlanPagos();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.toolTipPP = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCuota)).BeginInit();
            this.grbGastos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigGasto)).BeginInit();
            this.tbcPlnaPagos.SuspendLayout();
            this.tabParametros.SuspendLayout();
            this.tabCalendario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(47, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 999;
            this.lblBase1.Text = "Monto:";
            this.toolTipPP.SetToolTip(this.lblBase1, "Monto solicitado");
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(234, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(77, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Desembolso";
            this.toolTipPP.SetToolTip(this.lblBase2, "Fecha de sugerida de desembolso");
            // 
            // lblTasaInteres
            // 
            this.lblTasaInteres.AutoSize = true;
            this.lblTasaInteres.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTasaInteres.ForeColor = System.Drawing.Color.Navy;
            this.lblTasaInteres.Location = new System.Drawing.Point(725, 105);
            this.lblTasaInteres.Name = "lblTasaInteres";
            this.lblTasaInteres.Size = new System.Drawing.Size(137, 13);
            this.lblTasaInteres.TabIndex = 3;
            this.lblTasaInteres.Text = "Tasa Efectiva Mensual:";
            this.toolTipPP.SetToolTip(this.lblTasaInteres, "Tasa efectiva mensual");
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(41, 47);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Cuotas:";
            this.toolTipPP.SetToolTip(this.lblBase4, "Número de cotas");
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(230, 77);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(78, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Días Gracia:";
            this.toolTipPP.SetToolTip(this.lblBase5, "Días de gracia");
            // 
            // txtMonAprobado
            // 
            this.txtMonAprobado.FormatoDecimal = false;
            this.txtMonAprobado.Location = new System.Drawing.Point(99, 20);
            this.txtMonAprobado.MaxLength = 14;
            this.txtMonAprobado.Name = "txtMonAprobado";
            this.txtMonAprobado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonAprobado.nNumDecimales = 2;
            this.txtMonAprobado.nvalor = 0D;
            this.txtMonAprobado.Size = new System.Drawing.Size(77, 20);
            this.txtMonAprobado.TabIndex = 0;
            this.txtMonAprobado.Text = "0.00";
            this.toolTipPP.SetToolTip(this.txtMonAprobado, "Monto solicitado");
            this.txtMonAprobado.Leave += new System.EventHandler(this.txtMonAprobado_Leave);
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.FormatoDecimal = false;
            this.txtTasaInteres.Location = new System.Drawing.Point(868, 102);
            this.txtTasaInteres.MaxLength = 8;
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            262144});
            this.txtTasaInteres.nNumDecimales = 4;
            this.txtTasaInteres.nvalor = 0D;
            this.txtTasaInteres.Size = new System.Drawing.Size(49, 20);
            this.txtTasaInteres.TabIndex = 15;
            this.txtTasaInteres.Text = "0.0000";
            this.txtTasaInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipPP.SetToolTip(this.txtTasaInteres, "Tasa efectiva mensual");
            // 
            // nudDiasGracia
            // 
            this.nudDiasGracia.Enabled = false;
            this.nudDiasGracia.Location = new System.Drawing.Point(314, 73);
            this.nudDiasGracia.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudDiasGracia.Name = "nudDiasGracia";
            this.nudDiasGracia.Size = new System.Drawing.Size(77, 20);
            this.nudDiasGracia.TabIndex = 6;
            this.toolTipPP.SetToolTip(this.nudDiasGracia, "Días de gracia");
            this.nudDiasGracia.ValueChanged += new System.EventHandler(this.nudDiasGracia_ValueChanged);
            this.nudDiasGracia.Enter += new System.EventHandler(this.nudDiasGracia_Enter);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.conCreditoPrimeraCuota);
            this.grbBase1.Controls.Add(this.conCreditoPeriodo);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.cboClasificacionInterna1);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.cboTipoTasaCredito);
            this.grbBase1.Controls.Add(this.cboTipoPersona);
            this.grbBase1.Controls.Add(this.cboFuenteRecurso);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.txtTasCompensatoriaMax);
            this.grbBase1.Controls.Add(this.txtTasCompensatoriaMin);
            this.grbBase1.Controls.Add(this.cboSubProducto);
            this.grbBase1.Controls.Add(this.dtpFecDesembolso);
            this.grbBase1.Controls.Add(this.txtTasaInteres);
            this.grbBase1.Controls.Add(this.cboProducto);
            this.grbBase1.Controls.Add(this.nudNumCuota);
            this.grbBase1.Controls.Add(this.txtMonAprobado);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboSubTipoCredito);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboTipoCredito);
            this.grbBase1.Controls.Add(this.lblBase20);
            this.grbBase1.Controls.Add(this.nudDiasGracia);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase14);
            this.grbBase1.Controls.Add(this.lblBase26);
            this.grbBase1.Controls.Add(this.lblBase27);
            this.grbBase1.Controls.Add(this.lblBase13);
            this.grbBase1.Controls.Add(this.lblBase12);
            this.grbBase1.Controls.Add(this.lblTasaInteres);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase31);
            this.grbBase1.Controls.Add(this.lblBase24);
            this.grbBase1.Controls.Add(this.lblBase23);
            this.grbBase1.Location = new System.Drawing.Point(17, 18);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(932, 185);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Valores a Simular";
            // 
            // conCreditoPrimeraCuota
            // 
            this.conCreditoPrimeraCuota.cFormatoFecha = "dd/MM/yyyy";
            this.conCreditoPrimeraCuota.dFechaDesembolso = new System.DateTime(((long)(0)));
            this.conCreditoPrimeraCuota.dFechaEsperada = new System.DateTime(((long)(0)));
            this.conCreditoPrimeraCuota.dFechaSelec = new System.DateTime(((long)(0)));
            this.conCreditoPrimeraCuota.idPeriodo = 0;
            this.conCreditoPrimeraCuota.idTipoPeriodo = 0;
            this.conCreditoPrimeraCuota.lFechaEnabled = true;
            this.conCreditoPrimeraCuota.lFechaSelec = false;
            this.conCreditoPrimeraCuota.Location = new System.Drawing.Point(240, 44);
            this.conCreditoPrimeraCuota.Margin = new System.Windows.Forms.Padding(0);
            this.conCreditoPrimeraCuota.Name = "conCreditoPrimeraCuota";
            this.conCreditoPrimeraCuota.nDiasGracia = 0;
            this.conCreditoPrimeraCuota.nPeriodoDia = 0;
            this.conCreditoPrimeraCuota.Size = new System.Drawing.Size(182, 22);
            this.conCreditoPrimeraCuota.TabIndex = 1020;
            // 
            // conCreditoPeriodo
            // 
            this.conCreditoPeriodo.AutoSize = true;
            this.conCreditoPeriodo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoPeriodo.lDiaEnabled = true;
            this.conCreditoPeriodo.Location = new System.Drawing.Point(12, 68);
            this.conCreditoPeriodo.lPeriodoEnabled = true;
            this.conCreditoPeriodo.lTipoPeriodoEnabled = true;
            this.conCreditoPeriodo.lUnicuota = false;
            this.conCreditoPeriodo.Margin = new System.Windows.Forms.Padding(0);
            this.conCreditoPeriodo.Name = "conCreditoPeriodo";
            this.conCreditoPeriodo.Size = new System.Drawing.Size(198, 45);
            this.conCreditoPeriodo.TabIndex = 1019;
            this.conCreditoPeriodo.ChangeTipoPeriodo += new System.EventHandler(this.conCreditoPeriodo_ChangeTipoPeriodo);
            this.conCreditoPeriodo.ChangePeriodo += new System.EventHandler(this.conCreditoPeriodo_ChangePeriodo);
            this.conCreditoPeriodo.ValueChangedDia += new System.EventHandler(this.conCreditoPeriodo_ValueChangedDia);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(724, 20);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(65, 13);
            this.lblBase9.TabIndex = 1018;
            this.lblBase9.Text = "Clas. Int.:";
            this.toolTipPP.SetToolTip(this.lblBase9, "Tasa efectiva mensual");
            // 
            // cboClasificacionInterna1
            // 
            this.cboClasificacionInterna1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasificacionInterna1.FormattingEnabled = true;
            this.cboClasificacionInterna1.Location = new System.Drawing.Point(790, 19);
            this.cboClasificacionInterna1.Name = "cboClasificacionInterna1";
            this.cboClasificacionInterna1.Size = new System.Drawing.Size(131, 21);
            this.cboClasificacionInterna1.TabIndex = 1017;
            this.cboClasificacionInterna1.SelectedIndexChanged += new System.EventHandler(this.cboClasificacionInterna1_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(252, 102);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 9;
            this.lblBase7.Text = "Moneda:";
            this.toolTipPP.SetToolTip(this.lblBase7, "Moneda del crédito solicitado");
            // 
            // cboTipoTasaCredito
            // 
            this.cboTipoTasaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaCredito.DropDownWidth = 160;
            this.cboTipoTasaCredito.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTipoTasaCredito.ForeColor = System.Drawing.Color.Navy;
            this.cboTipoTasaCredito.FormattingEnabled = true;
            this.cboTipoTasaCredito.Location = new System.Drawing.Point(789, 46);
            this.cboTipoTasaCredito.Name = "cboTipoTasaCredito";
            this.cboTipoTasaCredito.Size = new System.Drawing.Size(131, 21);
            this.cboTipoTasaCredito.TabIndex = 14;
            this.cboTipoTasaCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(314, 126);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(107, 21);
            this.cboTipoPersona.TabIndex = 8;
            // 
            // cboFuenteRecurso
            // 
            this.cboFuenteRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuenteRecurso.FormattingEnabled = true;
            this.cboFuenteRecurso.Location = new System.Drawing.Point(543, 118);
            this.cboFuenteRecurso.Name = "cboFuenteRecurso";
            this.cboFuenteRecurso.Size = new System.Drawing.Size(175, 21);
            this.cboFuenteRecurso.TabIndex = 13;
            this.cboFuenteRecurso.Visible = false;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.DropDownWidth = 120;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(314, 99);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(107, 21);
            this.cboMoneda.TabIndex = 7;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda2_SelectedIndexChanged);
            // 
            // txtTasCompensatoriaMax
            // 
            this.txtTasCompensatoriaMax.Enabled = false;
            this.txtTasCompensatoriaMax.Location = new System.Drawing.Point(850, 74);
            this.txtTasCompensatoriaMax.Name = "txtTasCompensatoriaMax";
            this.txtTasCompensatoriaMax.Size = new System.Drawing.Size(48, 20);
            this.txtTasCompensatoriaMax.TabIndex = 15;
            this.txtTasCompensatoriaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipPP.SetToolTip(this.txtTasCompensatoriaMax, "Tasa de interes máxima para las condiciones seleccionadas");
            // 
            // txtTasCompensatoriaMin
            // 
            this.txtTasCompensatoriaMin.Enabled = false;
            this.txtTasCompensatoriaMin.Location = new System.Drawing.Point(766, 74);
            this.txtTasCompensatoriaMin.Name = "txtTasCompensatoriaMin";
            this.txtTasCompensatoriaMin.Size = new System.Drawing.Size(48, 20);
            this.txtTasCompensatoriaMin.TabIndex = 14;
            this.txtTasCompensatoriaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipPP.SetToolTip(this.txtTasCompensatoriaMin, "Tasa de interes mínima para las condiciones seleccionadas");
            // 
            // cboSubProducto
            // 
            this.cboSubProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubProducto.FormattingEnabled = true;
            this.cboSubProducto.Location = new System.Drawing.Point(543, 92);
            this.cboSubProducto.Name = "cboSubProducto";
            this.cboSubProducto.Size = new System.Drawing.Size(175, 21);
            this.cboSubProducto.TabIndex = 12;
            this.cboSubProducto.SelectedIndexChanged += new System.EventHandler(this.cboSubProducto_SelectedIndexChanged);
            // 
            // dtpFecDesembolso
            // 
            this.dtpFecDesembolso.CustomFormat = "dd/MM/yyyy";
            this.dtpFecDesembolso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecDesembolso.Location = new System.Drawing.Point(314, 19);
            this.dtpFecDesembolso.Name = "dtpFecDesembolso";
            this.dtpFecDesembolso.Size = new System.Drawing.Size(107, 20);
            this.dtpFecDesembolso.TabIndex = 3;
            this.toolTipPP.SetToolTip(this.dtpFecDesembolso, "Fecha de sugerida de desembolso");
            this.dtpFecDesembolso.ValueChanged += new System.EventHandler(this.dtpFecDesembolso_ValueChanged);
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(543, 68);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(175, 21);
            this.cboProducto.TabIndex = 11;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // nudNumCuota
            // 
            this.nudNumCuota.Location = new System.Drawing.Point(99, 45);
            this.nudNumCuota.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudNumCuota.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumCuota.Name = "nudNumCuota";
            this.nudNumCuota.Size = new System.Drawing.Size(77, 20);
            this.nudNumCuota.TabIndex = 1;
            this.toolTipPP.SetToolTip(this.nudNumCuota, "Número de cotas");
            this.nudNumCuota.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNumCuota.ValueChanged += new System.EventHandler(this.nudNumCuota_ValueChanged);
            this.nudNumCuota.Enter += new System.EventHandler(this.nudNumCuota_Enter);
            // 
            // cboSubTipoCredito
            // 
            this.cboSubTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubTipoCredito.FormattingEnabled = true;
            this.cboSubTipoCredito.Location = new System.Drawing.Point(543, 44);
            this.cboSubTipoCredito.Name = "cboSubTipoCredito";
            this.cboSubTipoCredito.Size = new System.Drawing.Size(175, 21);
            this.cboSubTipoCredito.TabIndex = 10;
            this.cboSubTipoCredito.SelectedIndexChanged += new System.EventHandler(this.cboSubTipoCredito_SelectedIndexChanged);
            // 
            // cboTipoCredito
            // 
            this.cboTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCredito.FormattingEnabled = true;
            this.cboTipoCredito.Location = new System.Drawing.Point(543, 20);
            this.cboTipoCredito.Name = "cboTipoCredito";
            this.cboTipoCredito.Size = new System.Drawing.Size(175, 21);
            this.cboTipoCredito.TabIndex = 9;
            this.cboTipoCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoCredito_SelectedIndexChanged);
            // 
            // lblBase20
            // 
            this.lblBase20.AutoSize = true;
            this.lblBase20.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase20.ForeColor = System.Drawing.Color.Navy;
            this.lblBase20.Location = new System.Drawing.Point(446, 95);
            this.lblBase20.Name = "lblBase20";
            this.lblBase20.Size = new System.Drawing.Size(88, 13);
            this.lblBase20.TabIndex = 1008;
            this.lblBase20.Text = "Sub Producto:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(446, 71);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(62, 13);
            this.lblBase14.TabIndex = 1007;
            this.lblBase14.Text = "Producto:";
            // 
            // lblBase26
            // 
            this.lblBase26.AutoSize = true;
            this.lblBase26.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase26.ForeColor = System.Drawing.Color.Navy;
            this.lblBase26.Location = new System.Drawing.Point(813, 77);
            this.lblBase26.Name = "lblBase26";
            this.lblBase26.Size = new System.Drawing.Size(39, 13);
            this.lblBase26.TabIndex = 1011;
            this.lblBase26.Text = "- Max";
            // 
            // lblBase27
            // 
            this.lblBase27.AutoSize = true;
            this.lblBase27.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase27.ForeColor = System.Drawing.Color.Navy;
            this.lblBase27.Location = new System.Drawing.Point(896, 77);
            this.lblBase27.Name = "lblBase27";
            this.lblBase27.Size = new System.Drawing.Size(19, 13);
            this.lblBase27.TabIndex = 16;
            this.lblBase27.Text = "%";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(446, 45);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(62, 13);
            this.lblBase13.TabIndex = 1006;
            this.lblBase13.Text = "Sub Tipo:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(446, 20);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(82, 13);
            this.lblBase12.TabIndex = 1005;
            this.lblBase12.Text = "Tipo Crédito:";
            // 
            // lblBase8
            // 
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(208, 126);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(103, 18);
            this.lblBase8.TabIndex = 1014;
            this.lblBase8.Text = "Tipo de Persona";
            // 
            // lblBase31
            // 
            this.lblBase31.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase31.ForeColor = System.Drawing.Color.Navy;
            this.lblBase31.Location = new System.Drawing.Point(446, 121);
            this.lblBase31.Name = "lblBase31";
            this.lblBase31.Size = new System.Drawing.Size(100, 19);
            this.lblBase31.TabIndex = 1014;
            this.lblBase31.Text = "Fuente Recurso:";
            this.lblBase31.Visible = false;
            // 
            // lblBase24
            // 
            this.lblBase24.AutoSize = true;
            this.lblBase24.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase24.ForeColor = System.Drawing.Color.Navy;
            this.lblBase24.Location = new System.Drawing.Point(740, 77);
            this.lblBase24.Name = "lblBase24";
            this.lblBase24.Size = new System.Drawing.Size(31, 13);
            this.lblBase24.TabIndex = 1016;
            this.lblBase24.Text = "Min:";
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(724, 48);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(64, 13);
            this.lblBase23.TabIndex = 1016;
            this.lblBase23.Text = "Tipo tasa:";
            this.toolTipPP.SetToolTip(this.lblBase23, "Tasa efectiva mensual");
            // 
            // grbGastos
            // 
            this.grbGastos.Controls.Add(this.txtValorCarga);
            this.grbGastos.Controls.Add(this.cboAplicaCuota);
            this.grbGastos.Controls.Add(this.chcMantenerCuotasCtes);
            this.grbGastos.Controls.Add(this.lblBase16);
            this.grbGastos.Controls.Add(this.lblPorcentaje);
            this.grbGastos.Controls.Add(this.dtgConfigGasto);
            this.grbGastos.Controls.Add(this.cboTipoValor);
            this.grbGastos.Controls.Add(this.btnAgregar);
            this.grbGastos.Controls.Add(this.lblTipoGasto);
            this.grbGastos.Controls.Add(this.btnQuitar);
            this.grbGastos.Controls.Add(this.cboGrupoGasto);
            this.grbGastos.Controls.Add(this.cboTipoGasto);
            this.grbGastos.Controls.Add(this.lblGrupoGasto);
            this.grbGastos.Controls.Add(this.lblBase15);
            this.grbGastos.Controls.Add(this.cboAplicaConcepto);
            this.grbGastos.Controls.Add(this.lblTipoValor);
            this.grbGastos.Controls.Add(this.lblAplicaCuota);
            this.grbGastos.Controls.Add(this.lblAfectacion);
            this.grbGastos.Location = new System.Drawing.Point(17, 209);
            this.grbGastos.Name = "grbGastos";
            this.grbGastos.Size = new System.Drawing.Size(932, 310);
            this.grbGastos.TabIndex = 8;
            this.grbGastos.TabStop = false;
            this.grbGastos.Text = "Datos del Gasto:";
            // 
            // txtValorCarga
            // 
            this.txtValorCarga.FormatoDecimal = false;
            this.txtValorCarga.Location = new System.Drawing.Point(412, 61);
            this.txtValorCarga.MaxLength = 12;
            this.txtValorCarga.Name = "txtValorCarga";
            this.txtValorCarga.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtValorCarga.nNumDecimales = 2;
            this.txtValorCarga.nvalor = 0D;
            this.txtValorCarga.Size = new System.Drawing.Size(146, 20);
            this.txtValorCarga.TabIndex = 12;
            this.txtValorCarga.Text = "0.00";
            this.txtValorCarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboAplicaCuota
            // 
            this.cboAplicaCuota.FormattingEnabled = true;
            this.cboAplicaCuota.Location = new System.Drawing.Point(679, 60);
            this.cboAplicaCuota.Name = "cboAplicaCuota";
            this.cboAplicaCuota.Size = new System.Drawing.Size(170, 21);
            this.cboAplicaCuota.TabIndex = 13;
            // 
            // chcMantenerCuotasCtes
            // 
            this.chcMantenerCuotasCtes.AutoSize = true;
            this.chcMantenerCuotasCtes.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcMantenerCuotasCtes.ForeColor = System.Drawing.Color.Navy;
            this.chcMantenerCuotasCtes.Location = new System.Drawing.Point(14, 283);
            this.chcMantenerCuotasCtes.Name = "chcMantenerCuotasCtes";
            this.chcMantenerCuotasCtes.Size = new System.Drawing.Size(392, 17);
            this.chcMantenerCuotasCtes.TabIndex = 17;
            this.chcMantenerCuotasCtes.Text = "Mantener Cuotas Constantes (a pesar de Comisiones variables)";
            this.chcMantenerCuotasCtes.UseVisualStyleBackColor = true;
            this.chcMantenerCuotasCtes.CheckedChanged += new System.EventHandler(this.chcMantenerCuotasCtes_CheckedChanged);
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(9, 100);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(110, 13);
            this.lblBase16.TabIndex = 108;
            this.lblBase16.Text = "Gastos Cargados:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Navy;
            this.lblPorcentaje.Location = new System.Drawing.Point(555, 64);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(19, 13);
            this.lblPorcentaje.TabIndex = 103;
            this.lblPorcentaje.Text = "%";
            // 
            // dtgConfigGasto
            // 
            this.dtgConfigGasto.AllowUserToAddRows = false;
            this.dtgConfigGasto.AllowUserToDeleteRows = false;
            this.dtgConfigGasto.AllowUserToResizeColumns = false;
            this.dtgConfigGasto.AllowUserToResizeRows = false;
            this.dtgConfigGasto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfigGasto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigGasto.Location = new System.Drawing.Point(12, 115);
            this.dtgConfigGasto.MultiSelect = false;
            this.dtgConfigGasto.Name = "dtgConfigGasto";
            this.dtgConfigGasto.ReadOnly = true;
            this.dtgConfigGasto.RowHeadersVisible = false;
            this.dtgConfigGasto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigGasto.Size = new System.Drawing.Size(795, 162);
            this.dtgConfigGasto.TabIndex = 107;
            // 
            // cboTipoValor
            // 
            this.cboTipoValor.DropDownWidth = 180;
            this.cboTipoValor.FormattingEnabled = true;
            this.cboTipoValor.Location = new System.Drawing.Point(412, 24);
            this.cboTipoValor.Name = "cboTipoValor";
            this.cboTipoValor.Size = new System.Drawing.Size(162, 21);
            this.cboTipoValor.TabIndex = 10;
            this.cboTipoValor.SelectedIndexChanged += new System.EventHandler(this.cboTipoValor_SelectedIndexChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(813, 115);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTipoGasto
            // 
            this.lblTipoGasto.AutoSize = true;
            this.lblTipoGasto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoGasto.Location = new System.Drawing.Point(9, 64);
            this.lblTipoGasto.Name = "lblTipoGasto";
            this.lblTipoGasto.Size = new System.Drawing.Size(91, 13);
            this.lblTipoGasto.TabIndex = 58;
            this.lblTipoGasto.Text = "Tipo de Gasto:";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(813, 149);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 16;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // cboGrupoGasto
            // 
            this.cboGrupoGasto.FormattingEnabled = true;
            this.cboGrupoGasto.Location = new System.Drawing.Point(113, 24);
            this.cboGrupoGasto.Name = "cboGrupoGasto";
            this.cboGrupoGasto.Size = new System.Drawing.Size(190, 21);
            this.cboGrupoGasto.TabIndex = 8;
            this.cboGrupoGasto.SelectedIndexChanged += new System.EventHandler(this.cboGrupoGasto_SelectedIndexChanged);
            // 
            // cboTipoGasto
            // 
            this.cboTipoGasto.DropDownWidth = 220;
            this.cboTipoGasto.FormattingEnabled = true;
            this.cboTipoGasto.Location = new System.Drawing.Point(114, 61);
            this.cboTipoGasto.Name = "cboTipoGasto";
            this.cboTipoGasto.Size = new System.Drawing.Size(189, 21);
            this.cboTipoGasto.TabIndex = 9;
            // 
            // lblGrupoGasto
            // 
            this.lblGrupoGasto.AutoSize = true;
            this.lblGrupoGasto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblGrupoGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblGrupoGasto.Location = new System.Drawing.Point(9, 27);
            this.lblGrupoGasto.Name = "lblGrupoGasto";
            this.lblGrupoGasto.Size = new System.Drawing.Size(102, 13);
            this.lblGrupoGasto.TabIndex = 57;
            this.lblGrupoGasto.Text = "Grupo de Gasto:";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(319, 64);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(96, 13);
            this.lblBase15.TabIndex = 15;
            this.lblBase15.Text = "Valor a Cargar:";
            // 
            // cboAplicaConcepto
            // 
            this.cboAplicaConcepto.FormattingEnabled = true;
            this.cboAplicaConcepto.Location = new System.Drawing.Point(679, 24);
            this.cboAplicaConcepto.Name = "cboAplicaConcepto";
            this.cboAplicaConcepto.Size = new System.Drawing.Size(170, 21);
            this.cboAplicaConcepto.TabIndex = 11;
            // 
            // lblTipoValor
            // 
            this.lblTipoValor.AutoSize = true;
            this.lblTipoValor.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoValor.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoValor.Location = new System.Drawing.Point(319, 27);
            this.lblTipoValor.Name = "lblTipoValor";
            this.lblTipoValor.Size = new System.Drawing.Size(87, 13);
            this.lblTipoValor.TabIndex = 98;
            this.lblTipoValor.Text = "Tipo de valor:";
            // 
            // lblAplicaCuota
            // 
            this.lblAplicaCuota.AutoSize = true;
            this.lblAplicaCuota.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAplicaCuota.ForeColor = System.Drawing.Color.Navy;
            this.lblAplicaCuota.Location = new System.Drawing.Point(581, 64);
            this.lblAplicaCuota.Name = "lblAplicaCuota";
            this.lblAplicaCuota.Size = new System.Drawing.Size(100, 13);
            this.lblAplicaCuota.TabIndex = 112;
            this.lblAplicaCuota.Text = "Aplicar a Cuota:";
            // 
            // lblAfectacion
            // 
            this.lblAfectacion.AutoSize = true;
            this.lblAfectacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAfectacion.ForeColor = System.Drawing.Color.Navy;
            this.lblAfectacion.Location = new System.Drawing.Point(581, 27);
            this.lblAfectacion.Name = "lblAfectacion";
            this.lblAfectacion.Size = new System.Drawing.Size(71, 13);
            this.lblAfectacion.TabIndex = 99;
            this.lblAfectacion.Text = "Afectación:";
            // 
            // tbcPlnaPagos
            // 
            this.tbcPlnaPagos.Controls.Add(this.tabParametros);
            this.tbcPlnaPagos.Controls.Add(this.tabCalendario);
            this.tbcPlnaPagos.Location = new System.Drawing.Point(12, 12);
            this.tbcPlnaPagos.Name = "tbcPlnaPagos";
            this.tbcPlnaPagos.SelectedIndex = 0;
            this.tbcPlnaPagos.Size = new System.Drawing.Size(966, 607);
            this.tbcPlnaPagos.TabIndex = 0;
            // 
            // tabParametros
            // 
            this.tabParametros.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabParametros.Controls.Add(this.btnHabilitarSeguro);
            this.tabParametros.Controls.Add(this.btnProcesar1);
            this.tabParametros.Controls.Add(this.grbBase1);
            this.tabParametros.Controls.Add(this.grbGastos);
            this.tabParametros.Controls.Add(this.btnProcesaPpg);
            this.tabParametros.Location = new System.Drawing.Point(4, 22);
            this.tabParametros.Name = "tabParametros";
            this.tabParametros.Padding = new System.Windows.Forms.Padding(3);
            this.tabParametros.Size = new System.Drawing.Size(958, 581);
            this.tabParametros.TabIndex = 0;
            this.tabParametros.Text = "Parámetros";
            this.tabParametros.Enter += new System.EventHandler(this.tabParametros_Enter);
            // 
            // btnHabilitarSeguro
            // 
            this.btnHabilitarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHabilitarSeguro.Location = new System.Drawing.Point(823, 525);
            this.btnHabilitarSeguro.Name = "btnHabilitarSeguro";
            this.btnHabilitarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnHabilitarSeguro.TabIndex = 120;
            this.btnHabilitarSeguro.Text = "Habilitar Seguros";
            this.btnHabilitarSeguro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabilitarSeguro.UseVisualStyleBackColor = true;
            this.btnHabilitarSeguro.Click += new System.EventHandler(this.btnHabilitarSeguro_Click);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(889, 525);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 19;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click_1);
            // 
            // btnProcesaPpg
            // 
            this.btnProcesaPpg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesaPpg.BackgroundImage")));
            this.btnProcesaPpg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesaPpg.Location = new System.Drawing.Point(889, 525);
            this.btnProcesaPpg.Name = "btnProcesaPpg";
            this.btnProcesaPpg.Size = new System.Drawing.Size(60, 50);
            this.btnProcesaPpg.TabIndex = 8;
            this.btnProcesaPpg.Text = "&Procesar";
            this.btnProcesaPpg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesaPpg.UseVisualStyleBackColor = true;
            this.btnProcesaPpg.Visible = false;
            // 
            // tabCalendario
            // 
            this.tabCalendario.Controls.Add(this.conPlanPagos1);
            this.tabCalendario.Location = new System.Drawing.Point(4, 22);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(958, 581);
            this.tabCalendario.TabIndex = 1;
            this.tabCalendario.Text = "Calendario";
            this.tabCalendario.UseVisualStyleBackColor = true;
            // 
            // conPlanPagos1
            // 
            this.conPlanPagos1.cnplanpago = clsCNPlanPago2;
            this.conPlanPagos1.dFechaDesembolso = new System.DateTime(((long)(0)));
            this.conPlanPagos1.dFecPriCuota = new System.DateTime(((long)(0)));
            this.conPlanPagos1.dtCalendarioPagos = null;
            this.conPlanPagos1.dtCargaGastos = null;
            this.conPlanPagos1.dtGastosPP = null;
            this.conPlanPagos1.idMoneda = 0;
            this.conPlanPagos1.IdSolicitud = 0;
            this.conPlanPagos1.idTipoPlanPago = 0;
            this.conPlanPagos1.lCuotaCte = false;
            this.conPlanPagos1.lEditorEnabled = true;
            this.conPlanPagos1.Location = new System.Drawing.Point(4, 6);
            this.conPlanPagos1.Name = "conPlanPagos1";
            this.conPlanPagos1.nCapitalMaxCobSeg = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conPlanPagos1.nDiasGracia = 0;
            this.conPlanPagos1.nMonto = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conPlanPagos1.nNumCuotas = 0;
            this.conPlanPagos1.nPlazo = 0;
            this.conPlanPagos1.nTasaInteres = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.conPlanPagos1.nTipPeriodo = ((short)(0));
            this.conPlanPagos1.Size = new System.Drawing.Size(945, 564);
            this.conPlanPagos1.TabIndex = 0;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(839, 621);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 20;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(905, 621);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 30;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmSimulPlanPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 697);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.tbcPlnaPagos);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmSimulPlanPagos";
            this.Text = "Simulador de Plan de Pagos";
            this.Load += new System.EventHandler(this.frmPlanPagos_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.tbcPlnaPagos, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCuota)).EndInit();
            this.grbGastos.ResumeLayout(false);
            this.grbGastos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigGasto)).EndInit();
            this.tbcPlnaPagos.ResumeLayout(false);
            this.tabParametros.ResumeLayout(false);
            this.tabCalendario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblTasaInteres;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMonAprobado;
        private GEN.ControlesBase.txtNumRea txtTasaInteres;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnProcesar btnProcesaPpg;
        private GEN.ControlesBase.nudBase nudDiasGracia;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.nudBase nudNumCuota;
        private GEN.ControlesBase.grbBase grbGastos;
        private GEN.ControlesBase.lblBase lblPorcentaje;
        private GEN.ControlesBase.cboTipoValor cboTipoValor;
        private GEN.ControlesBase.lblBase lblTipoGasto;
        private System.Windows.Forms.ComboBox cboGrupoGasto;
        private System.Windows.Forms.ComboBox cboTipoGasto;
        private GEN.ControlesBase.lblBase lblGrupoGasto;
        private GEN.ControlesBase.lblBase lblBase15;
        private System.Windows.Forms.ComboBox cboAplicaConcepto;
        private GEN.ControlesBase.lblBase lblTipoValor;
        private GEN.ControlesBase.lblBase lblAfectacion;
        private GEN.BotonesBase.btnMiniAgregar btnAgregar;
        private GEN.BotonesBase.btnMiniQuitar btnQuitar;
        private GEN.ControlesBase.dtgBase dtgConfigGasto;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.txtNumRea txtValorCarga;
        private GEN.ControlesBase.lblBase lblAplicaCuota;
        private System.Windows.Forms.ComboBox cboAplicaCuota;
        private GEN.ControlesBase.chcBase chcMantenerCuotasCtes;
        private GEN.ControlesBase.tbcBase tbcPlnaPagos;
        private System.Windows.Forms.TabPage tabParametros;
        private System.Windows.Forms.TabPage tabCalendario;
        private GEN.ControlesBase.dtpCorto dtpFecDesembolso;
        private GEN.ControlesBase.cboProducto cboSubProducto;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.cboProducto cboSubTipoCredito;
        private GEN.ControlesBase.cboProducto cboTipoCredito;
        private GEN.ControlesBase.lblBase lblBase20;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase27;
        private GEN.ControlesBase.txtBase txtTasCompensatoriaMax;
        private GEN.ControlesBase.txtBase txtTasCompensatoriaMin;
        private GEN.ControlesBase.lblBase lblBase26;
        private System.Windows.Forms.ToolTip toolTipPP;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase31;
        private GEN.ControlesBase.cboFuenteRecurso cboFuenteRecurso;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.cboBase cboTipoTasaCredito;
        private GEN.ControlesBase.lblBase lblBase24;
        private GEN.ControlesBase.conPlanPagos conPlanPagos1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboClasificacionInterna cboClasificacionInterna1;
        private GEN.ControlesBase.ConCreditoPeriodo conCreditoPeriodo;
        private GEN.ControlesBase.ConCreditoPrimeraCuota conCreditoPrimeraCuota;
        private GEN.BotonesBase.btnBlanco btnHabilitarSeguro;

    }
}