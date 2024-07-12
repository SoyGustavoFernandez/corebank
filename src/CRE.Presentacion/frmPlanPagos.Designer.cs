namespace CRE.Presentacion
{
    partial class frmPlanPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanPagos));
            CRE.CapaNegocio.clsCNPlanPago clsCNPlanPago1 = new CRE.CapaNegocio.clsCNPlanPago();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtMonAprobado = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpFecDesembolso = new System.Windows.Forms.DateTimePicker();
            this.txtNumCuotaCre = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.nudDiasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.chcMantenerCuotasCtes = new GEN.ControlesBase.chcBase(this.components);
            this.dtgConfigGasto = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.btnListaAprob = new GEN.BotonesBase.btnListaAprob();
            this.tbcCalendario = new GEN.ControlesBase.tbcBase(this.components);
            this.tabParametros = new System.Windows.Forms.TabPage();
            this.conAutorizacionUsuDatos1 = new GEN.ControlesBase.conAutorizacionUsuDatos();
            this.conCreditoPeriodo = new GEN.ControlesBase.ConCreditoPeriodo();
            this.nudCuotasGracia = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.nudDiasPrimCuota = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.conCreditoPrimeraCuota = new GEN.ControlesBase.ConCreditoPrimeraCuota();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtExtraPrima = new System.Windows.Forms.TextBox();
            this.btnMiniCancelarExtraPrima = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnMiniAgregarExtraPrima = new GEN.BotonesBase.btnMiniAgregar();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboModDesemb = new GEN.ControlesBase.cboModDesemb(this.components);
            this.txtModalidadCre = new GEN.ControlesBase.txtBase(this.components);
            this.txtOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.chcExtractoPagos = new GEN.ControlesBase.chcBase(this.components);
            this.grbExtracto = new GEN.ControlesBase.grbBase(this.components);
            this.rbtMedEnvio3 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtMedEnvio2 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtMedEnvio1 = new GEN.ControlesBase.rbtBase(this.components);
            this.chcBancoNacion = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTasaInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.tabCalendario = new System.Windows.Forms.TabPage();
            this.conPlanPagos1 = new GEN.ControlesBase.conPlanPagos();
            this.btnHojaResumen = new GEN.BotonesBase.btnBlanco();
            this.ttpMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnVincularPagare = new GEN.BotonesBase.btnBlanco();
            this.btnVincularCuentaAhorro = new GEN.BotonesBase.btnBlanco();
            this.btnHabilitarSeguro = new GEN.BotonesBase.btnBlanco();
            this.btnCargaArhivos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            this.btnExpediente = new GEN.BotonesBase.Boton();
            this.btnValidarSMS = new GEN.BotonesBase.btnBuenaPro();
            this.btnChecklist = new GEN.BotonesBase.btnDocumento();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigGasto)).BeginInit();
            this.tbcCalendario.SuspendLayout();
            this.tabParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotasGracia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasPrimCuota)).BeginInit();
            this.grbExtracto.SuspendLayout();
            this.tabCalendario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(66, 141);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(100, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Monto Aprobado";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(34, 216);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(132, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Fecha de Desembolso";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(52, 165);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(114, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Número de Cuotas";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(413, 143);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(91, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Días de Gracia";
            // 
            // txtMonAprobado
            // 
            this.txtMonAprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonAprobado.FormatoDecimal = false;
            this.txtMonAprobado.Location = new System.Drawing.Point(169, 137);
            this.txtMonAprobado.Name = "txtMonAprobado";
            this.txtMonAprobado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonAprobado.nNumDecimales = 2;
            this.txtMonAprobado.nvalor = 0D;
            this.txtMonAprobado.ReadOnly = true;
            this.txtMonAprobado.Size = new System.Drawing.Size(117, 20);
            this.txtMonAprobado.TabIndex = 1;
            this.txtMonAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFecDesembolso
            // 
            this.dtpFecDesembolso.Location = new System.Drawing.Point(169, 212);
            this.dtpFecDesembolso.Name = "dtpFecDesembolso";
            this.dtpFecDesembolso.Size = new System.Drawing.Size(197, 20);
            this.dtpFecDesembolso.TabIndex = 2;
            this.dtpFecDesembolso.ValueChanged += new System.EventHandler(this.dtpFecDesembolso_ValueChanged);
            // 
            // txtNumCuotaCre
            // 
            this.txtNumCuotaCre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCuotaCre.FormatoDecimal = false;
            this.txtNumCuotaCre.Location = new System.Drawing.Point(169, 161);
            this.txtNumCuotaCre.Name = "txtNumCuotaCre";
            this.txtNumCuotaCre.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumCuotaCre.nNumDecimales = 0;
            this.txtNumCuotaCre.nvalor = 0D;
            this.txtNumCuotaCre.ReadOnly = true;
            this.txtNumCuotaCre.Size = new System.Drawing.Size(117, 20);
            this.txtNumCuotaCre.TabIndex = 3;
            this.txtNumCuotaCre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(904, 616);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(778, 616);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 9;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli1.Location = new System.Drawing.Point(10, 23);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(565, 104);
            this.conBusCuentaCli1.TabIndex = 0;
            this.conBusCuentaCli1.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli1_MyKey);
            this.conBusCuentaCli1.MyClic += new System.EventHandler(this.conBusCuentaCli1_MyClic);
            // 
            // nudDiasGracia
            // 
            this.nudDiasGracia.Enabled = false;
            this.nudDiasGracia.Location = new System.Drawing.Point(506, 140);
            this.nudDiasGracia.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudDiasGracia.Name = "nudDiasGracia";
            this.nudDiasGracia.ReadOnly = true;
            this.nudDiasGracia.Size = new System.Drawing.Size(70, 20);
            this.nudDiasGracia.TabIndex = 4;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(652, 616);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 10;
            this.btnImprimir1.Text = "&Cronogr.";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Enabled = false;
            this.btnProcesar1.Location = new System.Drawing.Point(841, 616);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 23;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click_1);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(715, 616);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 29;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Enabled = false;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(617, 188);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(0, 13);
            this.lblBase15.TabIndex = 42;
            // 
            // chcMantenerCuotasCtes
            // 
            this.chcMantenerCuotasCtes.AutoSize = true;
            this.chcMantenerCuotasCtes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcMantenerCuotasCtes.Checked = true;
            this.chcMantenerCuotasCtes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcMantenerCuotasCtes.ForeColor = System.Drawing.Color.Navy;
            this.chcMantenerCuotasCtes.Location = new System.Drawing.Point(8, 248);
            this.chcMantenerCuotasCtes.Name = "chcMantenerCuotasCtes";
            this.chcMantenerCuotasCtes.Size = new System.Drawing.Size(323, 17);
            this.chcMantenerCuotasCtes.TabIndex = 49;
            this.chcMantenerCuotasCtes.Text = "Mantener Cuotas Constantes (a pesar de Comisiones variables)";
            this.chcMantenerCuotasCtes.UseVisualStyleBackColor = true;
            // 
            // dtgConfigGasto
            // 
            this.dtgConfigGasto.AllowUserToAddRows = false;
            this.dtgConfigGasto.AllowUserToDeleteRows = false;
            this.dtgConfigGasto.AllowUserToResizeColumns = false;
            this.dtgConfigGasto.AllowUserToResizeRows = false;
            this.dtgConfigGasto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfigGasto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigGasto.Location = new System.Drawing.Point(11, 291);
            this.dtgConfigGasto.MultiSelect = false;
            this.dtgConfigGasto.Name = "dtgConfigGasto";
            this.dtgConfigGasto.ReadOnly = true;
            this.dtgConfigGasto.RowHeadersVisible = false;
            this.dtgConfigGasto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigGasto.Size = new System.Drawing.Size(937, 129);
            this.dtgConfigGasto.TabIndex = 50;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(8, 278);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(165, 13);
            this.lblBase16.TabIndex = 51;
            this.lblBase16.Text = "Configuraciones Aplicables:";
            // 
            // btnListaAprob
            // 
            this.btnListaAprob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaAprob.BackgroundImage")));
            this.btnListaAprob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListaAprob.Location = new System.Drawing.Point(586, 32);
            this.btnListaAprob.Name = "btnListaAprob";
            this.btnListaAprob.Size = new System.Drawing.Size(60, 50);
            this.btnListaAprob.TabIndex = 53;
            this.btnListaAprob.Text = "&Lista Aprob.";
            this.btnListaAprob.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaAprob.UseVisualStyleBackColor = true;
            this.btnListaAprob.Click += new System.EventHandler(this.btnListaAprob1_Click);
            // 
            // tbcCalendario
            // 
            this.tbcCalendario.Controls.Add(this.tabParametros);
            this.tbcCalendario.Controls.Add(this.tabCalendario);
            this.tbcCalendario.Location = new System.Drawing.Point(12, 12);
            this.tbcCalendario.Name = "tbcCalendario";
            this.tbcCalendario.SelectedIndex = 0;
            this.tbcCalendario.Size = new System.Drawing.Size(962, 598);
            this.tbcCalendario.TabIndex = 54;
            // 
            // tabParametros
            // 
            this.tabParametros.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabParametros.Controls.Add(this.conAutorizacionUsuDatos1);
            this.tabParametros.Controls.Add(this.conCreditoPeriodo);
            this.tabParametros.Controls.Add(this.nudCuotasGracia);
            this.tabParametros.Controls.Add(this.lblBase13);
            this.tabParametros.Controls.Add(this.nudDiasPrimCuota);
            this.tabParametros.Controls.Add(this.lblBase12);
            this.tabParametros.Controls.Add(this.conCreditoPrimeraCuota);
            this.tabParametros.Controls.Add(this.lblBase10);
            this.tabParametros.Controls.Add(this.txtExtraPrima);
            this.tabParametros.Controls.Add(this.btnMiniCancelarExtraPrima);
            this.tabParametros.Controls.Add(this.btnMiniAgregarExtraPrima);
            this.tabParametros.Controls.Add(this.lblBase11);
            this.tabParametros.Controls.Add(this.cboModDesemb);
            this.tabParametros.Controls.Add(this.txtModalidadCre);
            this.tabParametros.Controls.Add(this.txtOperacion);
            this.tabParametros.Controls.Add(this.lblBase9);
            this.tabParametros.Controls.Add(this.lblBase8);
            this.tabParametros.Controls.Add(this.chcExtractoPagos);
            this.tabParametros.Controls.Add(this.grbExtracto);
            this.tabParametros.Controls.Add(this.lblBase1);
            this.tabParametros.Controls.Add(this.dtgConfigGasto);
            this.tabParametros.Controls.Add(this.btnListaAprob);
            this.tabParametros.Controls.Add(this.lblBase2);
            this.tabParametros.Controls.Add(this.conBusCuentaCli1);
            this.tabParametros.Controls.Add(this.chcBancoNacion);
            this.tabParametros.Controls.Add(this.chcMantenerCuotasCtes);
            this.tabParametros.Controls.Add(this.lblBase4);
            this.tabParametros.Controls.Add(this.lblBase15);
            this.tabParametros.Controls.Add(this.lblBase3);
            this.tabParametros.Controls.Add(this.lblBase5);
            this.tabParametros.Controls.Add(this.txtTasaInteres);
            this.tabParametros.Controls.Add(this.txtMonAprobado);
            this.tabParametros.Controls.Add(this.dtpFecDesembolso);
            this.tabParametros.Controls.Add(this.txtNumCuotaCre);
            this.tabParametros.Controls.Add(this.nudDiasGracia);
            this.tabParametros.Controls.Add(this.lblBase16);
            this.tabParametros.Location = new System.Drawing.Point(4, 22);
            this.tabParametros.Name = "tabParametros";
            this.tabParametros.Padding = new System.Windows.Forms.Padding(3);
            this.tabParametros.Size = new System.Drawing.Size(954, 572);
            this.tabParametros.TabIndex = 0;
            this.tabParametros.Text = "Datos de la Solicitud";
            // 
            // conAutorizacionUsuDatos1
            // 
            this.conAutorizacionUsuDatos1.BackColor = System.Drawing.Color.Transparent;
            this.conAutorizacionUsuDatos1.cCodCliente = null;
            this.conAutorizacionUsuDatos1.idCliente = 0;
            this.conAutorizacionUsuDatos1.idSolicitud = 0;
            this.conAutorizacionUsuDatos1.Location = new System.Drawing.Point(353, 64);
            this.conAutorizacionUsuDatos1.Name = "conAutorizacionUsuDatos1";
            this.conAutorizacionUsuDatos1.pcDireccion = null;
            this.conAutorizacionUsuDatos1.pcDocumentoID = null;
            this.conAutorizacionUsuDatos1.pcNombre = null;
            this.conAutorizacionUsuDatos1.pcNombreJuridico = null;
            this.conAutorizacionUsuDatos1.pcNroDocJuridico = null;
            this.conAutorizacionUsuDatos1.pcTelefono = null;
            this.conAutorizacionUsuDatos1.pIdTipoDocumento = 0;
            this.conAutorizacionUsuDatos1.pIdTipoPersona = 0;
            this.conAutorizacionUsuDatos1.Size = new System.Drawing.Size(36, 28);
            this.conAutorizacionUsuDatos1.TabIndex = 151;
            // 
            // conCreditoPeriodo
            // 
            this.conCreditoPeriodo.AutoSize = true;
            this.conCreditoPeriodo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoPeriodo.lDiaEnabled = false;
            this.conCreditoPeriodo.Location = new System.Drawing.Point(420, 163);
            this.conCreditoPeriodo.lPeriodoEnabled = false;
            this.conCreditoPeriodo.lTipoPeriodoEnabled = false;
            this.conCreditoPeriodo.lUnicuota = false;
            this.conCreditoPeriodo.Margin = new System.Windows.Forms.Padding(0);
            this.conCreditoPeriodo.Name = "conCreditoPeriodo";
            this.conCreditoPeriodo.Size = new System.Drawing.Size(198, 45);
            this.conCreditoPeriodo.TabIndex = 150;
            // 
            // nudCuotasGracia
            // 
            this.nudCuotasGracia.Enabled = false;
            this.nudCuotasGracia.Location = new System.Drawing.Point(800, 136);
            this.nudCuotasGracia.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudCuotasGracia.Name = "nudCuotasGracia";
            this.nudCuotasGracia.ReadOnly = true;
            this.nudCuotasGracia.Size = new System.Drawing.Size(70, 20);
            this.nudCuotasGracia.TabIndex = 149;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(693, 139);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(106, 13);
            this.lblBase13.TabIndex = 148;
            this.lblBase13.Text = "Cuotas de Gracia";
            // 
            // nudDiasPrimCuota
            // 
            this.nudDiasPrimCuota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nudDiasPrimCuota.Enabled = false;
            this.nudDiasPrimCuota.Location = new System.Drawing.Point(800, 212);
            this.nudDiasPrimCuota.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDiasPrimCuota.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.nudDiasPrimCuota.Name = "nudDiasPrimCuota";
            this.nudDiasPrimCuota.ReadOnly = true;
            this.nudDiasPrimCuota.Size = new System.Drawing.Size(70, 20);
            this.nudDiasPrimCuota.TabIndex = 147;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(702, 214);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(97, 13);
            this.lblBase12.TabIndex = 146;
            this.lblBase12.Text = "Días 1ra. Cuota";
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
            this.conCreditoPrimeraCuota.Location = new System.Drawing.Point(726, 183);
            this.conCreditoPrimeraCuota.Margin = new System.Windows.Forms.Padding(0);
            this.conCreditoPrimeraCuota.Name = "conCreditoPrimeraCuota";
            this.conCreditoPrimeraCuota.nDiasGracia = 0;
            this.conCreditoPrimeraCuota.nPeriodoDia = 0;
            this.conCreditoPrimeraCuota.Size = new System.Drawing.Size(182, 22);
            this.conCreditoPrimeraCuota.TabIndex = 144;
            this.conCreditoPrimeraCuota.ValueChangedFecha += new System.EventHandler(this.conCreditoPrimeraCuota_ValueChangedFecha);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(706, 272);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(79, 13);
            this.lblBase10.TabIndex = 143;
            this.lblBase10.Text = "Extra Prima:";
            // 
            // txtExtraPrima
            // 
            this.txtExtraPrima.Enabled = false;
            this.txtExtraPrima.Location = new System.Drawing.Point(824, 267);
            this.txtExtraPrima.Name = "txtExtraPrima";
            this.txtExtraPrima.Size = new System.Drawing.Size(48, 20);
            this.txtExtraPrima.TabIndex = 142;
            this.txtExtraPrima.Text = "0.0";
            this.txtExtraPrima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMiniCancelarExtraPrima
            // 
            this.btnMiniCancelarExtraPrima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelarExtraPrima.BackgroundImage")));
            this.btnMiniCancelarExtraPrima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelarExtraPrima.Location = new System.Drawing.Point(871, 263);
            this.btnMiniCancelarExtraPrima.Name = "btnMiniCancelarExtraPrima";
            this.btnMiniCancelarExtraPrima.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelarExtraPrima.TabIndex = 141;
            this.btnMiniCancelarExtraPrima.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelarExtraPrima.UseVisualStyleBackColor = true;
            this.btnMiniCancelarExtraPrima.Click += new System.EventHandler(this.btnMiniCancelarExtraPrima_Click);
            // 
            // btnMiniAgregarExtraPrima
            // 
            this.btnMiniAgregarExtraPrima.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregarExtraPrima.BackgroundImage")));
            this.btnMiniAgregarExtraPrima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregarExtraPrima.Location = new System.Drawing.Point(788, 263);
            this.btnMiniAgregarExtraPrima.Name = "btnMiniAgregarExtraPrima";
            this.btnMiniAgregarExtraPrima.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregarExtraPrima.TabIndex = 138;
            this.btnMiniAgregarExtraPrima.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregarExtraPrima.UseVisualStyleBackColor = true;
            this.btnMiniAgregarExtraPrima.Click += new System.EventHandler(this.btnMiniAgregarExtraPrima_Click);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(395, 216);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(108, 13);
            this.lblBase11.TabIndex = 137;
            this.lblBase11.Text = "Mod. Desembolso";
            // 
            // cboModDesemb
            // 
            this.cboModDesemb.Enabled = false;
            this.cboModDesemb.FormattingEnabled = true;
            this.cboModDesemb.Location = new System.Drawing.Point(506, 212);
            this.cboModDesemb.Name = "cboModDesemb";
            this.cboModDesemb.Size = new System.Drawing.Size(140, 21);
            this.cboModDesemb.TabIndex = 135;
            // 
            // txtModalidadCre
            // 
            this.txtModalidadCre.Enabled = false;
            this.txtModalidadCre.Location = new System.Drawing.Point(725, 92);
            this.txtModalidadCre.Name = "txtModalidadCre";
            this.txtModalidadCre.Size = new System.Drawing.Size(182, 20);
            this.txtModalidadCre.TabIndex = 134;
            // 
            // txtOperacion
            // 
            this.txtOperacion.Enabled = false;
            this.txtOperacion.Location = new System.Drawing.Point(725, 46);
            this.txtOperacion.Name = "txtOperacion";
            this.txtOperacion.Size = new System.Drawing.Size(182, 20);
            this.txtOperacion.TabIndex = 133;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(663, 76);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(133, 13);
            this.lblBase9.TabIndex = 132;
            this.lblBase9.Text = "Modalidad de Crédito:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(663, 32);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(116, 13);
            this.lblBase8.TabIndex = 131;
            this.lblBase8.Text = "Tipo de Operación:";
            // 
            // chcExtractoPagos
            // 
            this.chcExtractoPagos.AutoSize = true;
            this.chcExtractoPagos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcExtractoPagos.ForeColor = System.Drawing.Color.Navy;
            this.chcExtractoPagos.Location = new System.Drawing.Point(10, 436);
            this.chcExtractoPagos.Name = "chcExtractoPagos";
            this.chcExtractoPagos.Size = new System.Drawing.Size(580, 17);
            this.chcExtractoPagos.TabIndex = 49;
            this.chcExtractoPagos.Text = "Solicito la remisión de mi extracto de pagos efectuados o aquellos que se encuent" +
    "ren pendientes de manera mensual.";
            this.chcExtractoPagos.UseVisualStyleBackColor = true;
            this.chcExtractoPagos.CheckedChanged += new System.EventHandler(this.chcExtractoPagos_CheckedChanged);
            // 
            // grbExtracto
            // 
            this.grbExtracto.Controls.Add(this.rbtMedEnvio3);
            this.grbExtracto.Controls.Add(this.rbtMedEnvio2);
            this.grbExtracto.Controls.Add(this.rbtMedEnvio1);
            this.grbExtracto.Location = new System.Drawing.Point(11, 452);
            this.grbExtracto.Name = "grbExtracto";
            this.grbExtracto.Size = new System.Drawing.Size(937, 103);
            this.grbExtracto.TabIndex = 130;
            this.grbExtracto.TabStop = false;
            this.grbExtracto.Visible = false;
            // 
            // rbtMedEnvio3
            // 
            this.rbtMedEnvio3.AutoSize = true;
            this.rbtMedEnvio3.Checked = true;
            this.rbtMedEnvio3.ForeColor = System.Drawing.Color.Navy;
            this.rbtMedEnvio3.Location = new System.Drawing.Point(9, 71);
            this.rbtMedEnvio3.Name = "rbtMedEnvio3";
            this.rbtMedEnvio3.Size = new System.Drawing.Size(260, 17);
            this.rbtMedEnvio3.TabIndex = 0;
            this.rbtMedEnvio3.TabStop = true;
            this.rbtMedEnvio3.Text = "c). Se aproximará a nuestras oficinas de atención.";
            this.rbtMedEnvio3.UseVisualStyleBackColor = true;
            // 
            // rbtMedEnvio2
            // 
            this.rbtMedEnvio2.AutoSize = true;
            this.rbtMedEnvio2.ForeColor = System.Drawing.Color.Navy;
            this.rbtMedEnvio2.Location = new System.Drawing.Point(9, 42);
            this.rbtMedEnvio2.Name = "rbtMedEnvio2";
            this.rbtMedEnvio2.Size = new System.Drawing.Size(127, 17);
            this.rbtMedEnvio2.TabIndex = 0;
            this.rbtMedEnvio2.TabStop = true;
            this.rbtMedEnvio2.Text = "b). Correo Electrónico";
            this.rbtMedEnvio2.UseVisualStyleBackColor = true;
            // 
            // rbtMedEnvio1
            // 
            this.rbtMedEnvio1.AutoSize = true;
            this.rbtMedEnvio1.ForeColor = System.Drawing.Color.Navy;
            this.rbtMedEnvio1.Location = new System.Drawing.Point(9, 13);
            this.rbtMedEnvio1.Name = "rbtMedEnvio1";
            this.rbtMedEnvio1.Size = new System.Drawing.Size(569, 17);
            this.rbtMedEnvio1.TabIndex = 0;
            this.rbtMedEnvio1.Text = "a). Al domicilio señalado.Autorizo a la Caja Los Andes cargar a mi crédito la sum" +
    "a de S/. 3.50 por el costo de envío.";
            this.rbtMedEnvio1.UseVisualStyleBackColor = true;
            // 
            // chcBancoNacion
            // 
            this.chcBancoNacion.AutoSize = true;
            this.chcBancoNacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcBancoNacion.ForeColor = System.Drawing.Color.Navy;
            this.chcBancoNacion.Location = new System.Drawing.Point(14, 189);
            this.chcBancoNacion.Name = "chcBancoNacion";
            this.chcBancoNacion.Size = new System.Drawing.Size(264, 17);
            this.chcBancoNacion.TabIndex = 49;
            this.chcBancoNacion.Text = "¿Desembolso se realizará en Banco de la Nación?";
            this.ttpMensaje.SetToolTip(this.chcBancoNacion, "Solo se activa cuando desembolso es en efectivo");
            this.chcBancoNacion.UseVisualStyleBackColor = true;
            this.chcBancoNacion.CheckedChanged += new System.EventHandler(this.chcBancoNacion_CheckedChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(703, 164);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(94, 13);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Tasa de interés";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTasaInteres.FormatoDecimal = false;
            this.txtTasaInteres.Location = new System.Drawing.Point(800, 160);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaInteres.nNumDecimales = 4;
            this.txtTasaInteres.nvalor = 0D;
            this.txtTasaInteres.ReadOnly = true;
            this.txtTasaInteres.Size = new System.Drawing.Size(107, 20);
            this.txtTasaInteres.TabIndex = 1;
            this.txtTasaInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabCalendario
            // 
            this.tabCalendario.Controls.Add(this.conPlanPagos1);
            this.tabCalendario.Location = new System.Drawing.Point(4, 22);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(954, 572);
            this.tabCalendario.TabIndex = 1;
            this.tabCalendario.Text = "Calendario";
            this.tabCalendario.UseVisualStyleBackColor = true;
            // 
            // conPlanPagos1
            // 
            this.conPlanPagos1.cnplanpago = clsCNPlanPago1;
            this.conPlanPagos1.dFechaDesembolso = new System.DateTime(((long)(0)));
            this.conPlanPagos1.dFecPriCuota = new System.DateTime(((long)(0)));
            this.conPlanPagos1.dtCalendarioPagos = null;
            this.conPlanPagos1.dtCargaGastos = null;
            this.conPlanPagos1.dtGastosPP = null;
            this.conPlanPagos1.idMoneda = 0;
            this.conPlanPagos1.IdSolicitud = 0;
            this.conPlanPagos1.idTipoPlanPago = 0;
            this.conPlanPagos1.lCuotaCte = false;
            this.conPlanPagos1.lEditorEnabled = false;
            this.conPlanPagos1.Location = new System.Drawing.Point(3, 2);
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
            // btnHojaResumen
            // 
            this.btnHojaResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHojaResumen.Enabled = false;
            this.btnHojaResumen.Location = new System.Drawing.Point(589, 616);
            this.btnHojaResumen.Name = "btnHojaResumen";
            this.btnHojaResumen.Size = new System.Drawing.Size(60, 50);
            this.btnHojaResumen.TabIndex = 55;
            this.btnHojaResumen.Text = "Hoja Resumen";
            this.btnHojaResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ttpMensaje.SetToolTip(this.btnHojaResumen, "Imprime Hoja Resumen del crédito");
            this.btnHojaResumen.UseVisualStyleBackColor = true;
            this.btnHojaResumen.Click += new System.EventHandler(this.btnHojaResumen_Click);
            // 
            // btnVincularPagare
            // 
            this.btnVincularPagare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularPagare.Enabled = false;
            this.btnVincularPagare.Location = new System.Drawing.Point(526, 616);
            this.btnVincularPagare.Name = "btnVincularPagare";
            this.btnVincularPagare.Size = new System.Drawing.Size(60, 50);
            this.btnVincularPagare.TabIndex = 56;
            this.btnVincularPagare.Text = "Vincular Pagaré";
            this.btnVincularPagare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularPagare.UseVisualStyleBackColor = true;
            this.btnVincularPagare.Click += new System.EventHandler(this.btnVincularPagare_Click);
            // 
            // btnVincularCuentaAhorro
            // 
            this.btnVincularCuentaAhorro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularCuentaAhorro.Enabled = false;
            this.btnVincularCuentaAhorro.Location = new System.Drawing.Point(462, 616);
            this.btnVincularCuentaAhorro.Name = "btnVincularCuentaAhorro";
            this.btnVincularCuentaAhorro.Size = new System.Drawing.Size(60, 50);
            this.btnVincularCuentaAhorro.TabIndex = 57;
            this.btnVincularCuentaAhorro.Text = "Vincular Cuenta Ahorro";
            this.btnVincularCuentaAhorro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularCuentaAhorro.UseVisualStyleBackColor = true;
            this.btnVincularCuentaAhorro.Click += new System.EventHandler(this.btnVincularCuentaAhorro_Click);
            // 
            // btnHabilitarSeguro
            // 
            this.btnHabilitarSeguro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHabilitarSeguro.Enabled = false;
            this.btnHabilitarSeguro.Location = new System.Drawing.Point(396, 616);
            this.btnHabilitarSeguro.Name = "btnHabilitarSeguro";
            this.btnHabilitarSeguro.Size = new System.Drawing.Size(60, 50);
            this.btnHabilitarSeguro.TabIndex = 58;
            this.btnHabilitarSeguro.Text = "Habilitar Seguros";
            this.btnHabilitarSeguro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHabilitarSeguro.UseVisualStyleBackColor = true;
            this.btnHabilitarSeguro.Click += new System.EventHandler(this.btnHabilitarSeguro_Click);
            // 
            // btnCargaArhivos
            // 
            this.btnCargaArhivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargaArhivos.BackgroundImage")));
            this.btnCargaArhivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaArhivos.Location = new System.Drawing.Point(330, 616);
            this.btnCargaArhivos.Name = "btnCargaArhivos";
            this.btnCargaArhivos.Size = new System.Drawing.Size(60, 50);
            this.btnCargaArhivos.TabIndex = 59;
            this.btnCargaArhivos.Text = "Carga de Archivos";
            this.btnCargaArhivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargaArhivos.UseVisualStyleBackColor = true;
            this.btnCargaArhivos.Click += new System.EventHandler(this.btnCargaArhivos_Click);
            // 
            // btnExpediente
            // 
            this.btnExpediente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExpediente.Location = new System.Drawing.Point(264, 616);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Size = new System.Drawing.Size(60, 50);
            this.btnExpediente.TabIndex = 60;
            this.btnExpediente.Text = "Expdnte Virtual";
            this.btnExpediente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpediente.UseVisualStyleBackColor = true;
            this.btnExpediente.Click += new System.EventHandler(this.boton1_Click);
            // 
            // btnValidarSMS
            // 
            this.btnValidarSMS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValidarSMS.BackgroundImage")));
            this.btnValidarSMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValidarSMS.Enabled = false;
            this.btnValidarSMS.Location = new System.Drawing.Point(198, 616);
            this.btnValidarSMS.Name = "btnValidarSMS";
            this.btnValidarSMS.Size = new System.Drawing.Size(60, 50);
            this.btnValidarSMS.TabIndex = 61;
            this.btnValidarSMS.Text = "Validar Contacto";
            this.btnValidarSMS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidarSMS.UseVisualStyleBackColor = true;
            this.btnValidarSMS.Click += new System.EventHandler(this.btnValidarSMS_Click);
            // 
            // btnChecklist
            // 
            this.btnChecklist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChecklist.BackgroundImage")));
            this.btnChecklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChecklist.Enabled = false;
            this.btnChecklist.Location = new System.Drawing.Point(66, 616);
            this.btnChecklist.Name = "btnChecklist";
            this.btnChecklist.Size = new System.Drawing.Size(60, 50);
            this.btnChecklist.TabIndex = 63;
            this.btnChecklist.Text = "Checklist";
            this.btnChecklist.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChecklist.UseVisualStyleBackColor = true;
            this.btnChecklist.Click += new System.EventHandler(this.btnChecklist_Click);
            // 
            // frmPlanPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 695);
            this.Controls.Add(this.btnChecklist);
            this.Controls.Add(this.btnValidarSMS);
            this.Controls.Add(this.btnExpediente);
            this.Controls.Add(this.btnCargaArhivos);
            this.Controls.Add(this.btnHabilitarSeguro);
            this.Controls.Add(this.btnVincularCuentaAhorro);
            this.Controls.Add(this.btnVincularPagare);
            this.Controls.Add(this.btnHojaResumen);
            this.Controls.Add(this.tbcCalendario);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmPlanPagos";
            this.Text = "Generación del Plan de Pagos";
            this.Load += new System.EventHandler(this.frmPlanPagos_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.tbcCalendario, 0);
            this.Controls.SetChildIndex(this.btnHojaResumen, 0);
            this.Controls.SetChildIndex(this.btnVincularPagare, 0);
            this.Controls.SetChildIndex(this.btnVincularCuentaAhorro, 0);
            this.Controls.SetChildIndex(this.btnHabilitarSeguro, 0);
            this.Controls.SetChildIndex(this.btnCargaArhivos, 0);
            this.Controls.SetChildIndex(this.btnExpediente, 0);
            this.Controls.SetChildIndex(this.btnValidarSMS, 0);
            this.Controls.SetChildIndex(this.btnChecklist, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasGracia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigGasto)).EndInit();
            this.tbcCalendario.ResumeLayout(false);
            this.tabParametros.ResumeLayout(false);
            this.tabParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotasGracia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasPrimCuota)).EndInit();
            this.grbExtracto.ResumeLayout(false);
            this.grbExtracto.PerformLayout();
            this.tabCalendario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMonAprobado;
        private System.Windows.Forms.DateTimePicker dtpFecDesembolso;
        private GEN.ControlesBase.txtNumRea txtNumCuotaCre;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.ControlesBase.nudBase nudDiasGracia;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.chcBase chcMantenerCuotasCtes;
        private GEN.ControlesBase.dtgBase dtgConfigGasto;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.BotonesBase.btnListaAprob btnListaAprob;
        private GEN.ControlesBase.tbcBase tbcCalendario;
        private System.Windows.Forms.TabPage tabParametros;
        private System.Windows.Forms.TabPage tabCalendario;
        private GEN.BotonesBase.btnBlanco btnHojaResumen;
        private System.Windows.Forms.ToolTip ttpMensaje;
        private GEN.BotonesBase.btnBlanco btnVincularPagare;
        private GEN.ControlesBase.chcBase chcBancoNacion;
        private GEN.ControlesBase.grbBase grbExtracto;
        private GEN.ControlesBase.rbtBase rbtMedEnvio1;
        private GEN.ControlesBase.chcBase chcExtractoPagos;
        private GEN.ControlesBase.rbtBase rbtMedEnvio3;
        private GEN.ControlesBase.rbtBase rbtMedEnvio2;
        private GEN.ControlesBase.conPlanPagos conPlanPagos1;
        private GEN.ControlesBase.txtNumRea txtTasaInteres;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtModalidadCre;
        private GEN.ControlesBase.txtBase txtOperacion;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.cboModDesemb cboModDesemb;
        private GEN.BotonesBase.btnBlanco btnVincularCuentaAhorro;
        private GEN.BotonesBase.btnBlanco btnHabilitarSeguro;
        private GEN.BotonesBase.btnAdjuntarFile btnCargaArhivos;
        private GEN.BotonesBase.Boton btnExpediente;
        private GEN.BotonesBase.btnBuenaPro btnValidarSMS;
        private System.Windows.Forms.TextBox txtExtraPrima;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelarExtraPrima;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregarExtraPrima;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.ConCreditoPrimeraCuota conCreditoPrimeraCuota;
        private GEN.ControlesBase.nudBase nudDiasPrimCuota;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.nudBase nudCuotasGracia;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.ConCreditoPeriodo conCreditoPeriodo;
        private GEN.BotonesBase.btnDocumento btnChecklist;
        private GEN.ControlesBase.conAutorizacionUsuDatos conAutorizacionUsuDatos1;
    }
}