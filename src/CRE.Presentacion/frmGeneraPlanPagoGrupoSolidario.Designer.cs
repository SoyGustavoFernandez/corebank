namespace CRE.Presentacion
{
    partial class frmGeneraPlanPagoGrupoSolidario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneraPlanPagoGrupoSolidario));
            CRE.CapaNegocio.clsCNPlanPago clsCNPlanPago1 = new CRE.CapaNegocio.clsCNPlanPago();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.conBusGrupoSol = new GEN.ControlesBase.ConBusGrupoSol();
            this.gbxIntregantes = new GEN.ControlesBase.grbBase(this.components);
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnMiniDetalle = new GEN.BotonesBase.btnMiniDetalle(this.components);
            this.dtgIntegrantesGrupoSol = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conPlanPagos1 = new GEN.ControlesBase.conPlanPagos();
            this.txtTCEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTEM = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTotCuota = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotInteres = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotCapital = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotDias = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotItf = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotComi = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgCalendario = new GEN.ControlesBase.dtgBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnPPInd = new GEN.BotonesBase.btnImprimir();
            this.btnPPGrupal = new GEN.BotonesBase.btnImprimir();
            this.tabPlanPagos = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chcExtractoPagos = new GEN.ControlesBase.chcBase(this.components);
            this.grbExtracto = new GEN.ControlesBase.grbBase(this.components);
            this.rbtMedEnvio3 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtMedEnvio2 = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtMedEnvio1 = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.nudMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasaEfectivaAnual = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPaqueteSeguro1 = new GEN.ControlesBase.cboPaqueteSeguro(this.components);
            this.cboDetalleGasto = new GEN.ControlesBase.cboDetalleGasto(this.components);
            this.lblPaqueteSeguro = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.chcMantenerCuotasCtes = new GEN.ControlesBase.chcBase(this.components);
            this.chcBancoNacion = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboOperacionCre = new GEN.ControlesBase.cboOperacionCre(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboAsesorNegociosGrupoSolidario = new GEN.ControlesBase.cboAsesorNegociosGrupoSolidario(this.components);
            this.conCondiCreditoGrupoSol = new GEN.ControlesBase.ConCondiCreditoGrupoSol();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnVincularPagare = new GEN.BotonesBase.btnBlanco();
            this.btnHojaResumen = new GEN.BotonesBase.btnBlanco();
            this.btnVincular = new GEN.BotonesBase.btnVincular();
            this.btnChecklist = new GEN.BotonesBase.btnDocumento();
            this.grbBase1.SuspendLayout();
            this.gbxIntregantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantesGrupoSol)).BeginInit();
            this.conPlanPagos1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalendario)).BeginInit();
            this.tabPlanPagos.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbExtracto.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.conBusGrupoSol);
            this.grbBase1.Location = new System.Drawing.Point(0, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(622, 67);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Grupo";
            // 
            // conBusGrupoSol
            // 
            this.conBusGrupoSol.Location = new System.Drawing.Point(2, 12);
            this.conBusGrupoSol.Name = "conBusGrupoSol";
            this.conBusGrupoSol.Size = new System.Drawing.Size(614, 49);
            this.conBusGrupoSol.TabIndex = 0;
            this.conBusGrupoSol.ClicBuscar += new System.EventHandler(this.conBusGrupoSol1_ClicBuscar);
            // 
            // gbxIntregantes
            // 
            this.gbxIntregantes.Controls.Add(this.chcBase1);
            this.gbxIntregantes.Controls.Add(this.lblBase1);
            this.gbxIntregantes.Controls.Add(this.btnMiniDetalle);
            this.gbxIntregantes.Controls.Add(this.dtgIntegrantesGrupoSol);
            this.gbxIntregantes.Location = new System.Drawing.Point(0, 67);
            this.gbxIntregantes.Name = "gbxIntregantes";
            this.gbxIntregantes.Size = new System.Drawing.Size(325, 485);
            this.gbxIntregantes.TabIndex = 3;
            this.gbxIntregantes.TabStop = false;
            this.gbxIntregantes.Text = "Integrantes";
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcBase1.Location = new System.Drawing.Point(260, 437);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(56, 17);
            this.chcBase1.TabIndex = 3;
            this.chcBase1.Text = "Todos";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 464);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Gastos";
            this.lblBase1.Visible = false;
            // 
            // btnMiniDetalle
            // 
            this.btnMiniDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDetalle.BackgroundImage")));
            this.btnMiniDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDetalle.Location = new System.Drawing.Point(12, 437);
            this.btnMiniDetalle.Name = "btnMiniDetalle";
            this.btnMiniDetalle.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDetalle.TabIndex = 1;
            this.btnMiniDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDetalle.UseVisualStyleBackColor = true;
            this.btnMiniDetalle.Visible = false;
            // 
            // dtgIntegrantesGrupoSol
            // 
            this.dtgIntegrantesGrupoSol.AllowUserToAddRows = false;
            this.dtgIntegrantesGrupoSol.AllowUserToDeleteRows = false;
            this.dtgIntegrantesGrupoSol.AllowUserToResizeColumns = false;
            this.dtgIntegrantesGrupoSol.AllowUserToResizeRows = false;
            this.dtgIntegrantesGrupoSol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgIntegrantesGrupoSol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantesGrupoSol.Location = new System.Drawing.Point(8, 19);
            this.dtgIntegrantesGrupoSol.MultiSelect = false;
            this.dtgIntegrantesGrupoSol.Name = "dtgIntegrantesGrupoSol";
            this.dtgIntegrantesGrupoSol.ReadOnly = true;
            this.dtgIntegrantesGrupoSol.RowHeadersVisible = false;
            this.dtgIntegrantesGrupoSol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantesGrupoSol.Size = new System.Drawing.Size(311, 412);
            this.dtgIntegrantesGrupoSol.TabIndex = 0;
            this.dtgIntegrantesGrupoSol.SelectionChanged += new System.EventHandler(this.dtgIntegrantesGrupoSol_SelectionChanged);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(264, 556);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // conPlanPagos1
            // 
            this.conPlanPagos1.cnplanpago = clsCNPlanPago1;
            this.conPlanPagos1.Controls.Add(this.txtTCEA);
            this.conPlanPagos1.Controls.Add(this.txtTEM);
            this.conPlanPagos1.Controls.Add(this.txtTEA);
            this.conPlanPagos1.Controls.Add(this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04);
            this.conPlanPagos1.Controls.Add(this.txtTotCuota);
            this.conPlanPagos1.Controls.Add(this.txtTotInteres);
            this.conPlanPagos1.Controls.Add(this.txtTotCapital);
            this.conPlanPagos1.Controls.Add(this.txtTotDias);
            this.conPlanPagos1.Controls.Add(this.txtTotItf);
            this.conPlanPagos1.Controls.Add(this.txtTotComi);
            this.conPlanPagos1.Controls.Add(this.dtgCalendario);
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
            this.conPlanPagos1.Location = new System.Drawing.Point(0, 3);
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
            this.conPlanPagos1.Size = new System.Drawing.Size(639, 567);
            this.conPlanPagos1.TabIndex = 1;
            // 
            // txtTCEA
            // 
            this.txtTCEA.BackColor = System.Drawing.SystemColors.Control;
            this.txtTCEA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCEA.FormatoDecimal = true;
            this.txtTCEA.Location = new System.Drawing.Point(237, 515);
            this.txtTCEA.Name = "txtTCEA";
            this.txtTCEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTCEA.nNumDecimales = 4;
            this.txtTCEA.nvalor = 0D;
            this.txtTCEA.ReadOnly = true;
            this.txtTCEA.Size = new System.Drawing.Size(64, 20);
            this.txtTCEA.TabIndex = 128;
            this.txtTCEA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTEM
            // 
            this.txtTEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTEM.FormatoDecimal = false;
            this.txtTEM.Location = new System.Drawing.Point(491, 514);
            this.txtTEM.Name = "txtTEM";
            this.txtTEM.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEM.nNumDecimales = 4;
            this.txtTEM.nvalor = 0D;
            this.txtTEM.ReadOnly = true;
            this.txtTEM.Size = new System.Drawing.Size(64, 20);
            this.txtTEM.TabIndex = 130;
            this.txtTEM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTEA
            // 
            this.txtTEA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTEA.FormatoDecimal = true;
            this.txtTEA.Location = new System.Drawing.Point(237, 542);
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 4;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.ReadOnly = true;
            this.txtTEA.Size = new System.Drawing.Size(64, 20);
            this.txtTEA.TabIndex = 131;
            this.txtTEA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // object_80a9a5f2_d902_4978_bfb7_da4825c4ad04
            // 
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04.Location = new System.Drawing.Point(643, 16);
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04.Name = "object_80a9a5f2_d902_4978_bfb7_da4825c4ad04";
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04.Size = new System.Drawing.Size(300, 462);
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04.TabIndex = 118;
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04.TabStop = false;
            this.object_80a9a5f2_d902_4978_bfb7_da4825c4ad04.Text = "Variaciones al Plan de Pagos";
            // 
            // txtTotCuota
            // 
            this.txtTotCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotCuota.FormatoDecimal = true;
            this.txtTotCuota.Location = new System.Drawing.Point(560, 482);
            this.txtTotCuota.Name = "txtTotCuota";
            this.txtTotCuota.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotCuota.nNumDecimales = 2;
            this.txtTotCuota.nvalor = 0D;
            this.txtTotCuota.ReadOnly = true;
            this.txtTotCuota.Size = new System.Drawing.Size(75, 20);
            this.txtTotCuota.TabIndex = 120;
            this.txtTotCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotInteres
            // 
            this.txtTotInteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotInteres.FormatoDecimal = true;
            this.txtTotInteres.Location = new System.Drawing.Point(401, 482);
            this.txtTotInteres.Name = "txtTotInteres";
            this.txtTotInteres.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotInteres.nNumDecimales = 2;
            this.txtTotInteres.nvalor = 0D;
            this.txtTotInteres.ReadOnly = true;
            this.txtTotInteres.Size = new System.Drawing.Size(75, 20);
            this.txtTotInteres.TabIndex = 121;
            this.txtTotInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotCapital
            // 
            this.txtTotCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotCapital.FormatoDecimal = true;
            this.txtTotCapital.Location = new System.Drawing.Point(317, 482);
            this.txtTotCapital.Name = "txtTotCapital";
            this.txtTotCapital.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotCapital.nNumDecimales = 2;
            this.txtTotCapital.nvalor = 0D;
            this.txtTotCapital.ReadOnly = true;
            this.txtTotCapital.Size = new System.Drawing.Size(84, 20);
            this.txtTotCapital.TabIndex = 122;
            this.txtTotCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotDias
            // 
            this.txtTotDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotDias.FormatoDecimal = false;
            this.txtTotDias.Location = new System.Drawing.Point(170, 482);
            this.txtTotDias.Name = "txtTotDias";
            this.txtTotDias.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotDias.nNumDecimales = 2;
            this.txtTotDias.nvalor = 0D;
            this.txtTotDias.ReadOnly = true;
            this.txtTotDias.Size = new System.Drawing.Size(59, 20);
            this.txtTotDias.TabIndex = 123;
            this.txtTotDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotItf
            // 
            this.txtTotItf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotItf.FormatoDecimal = true;
            this.txtTotItf.Location = new System.Drawing.Point(3, 482);
            this.txtTotItf.Name = "txtTotItf";
            this.txtTotItf.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotItf.nNumDecimales = 2;
            this.txtTotItf.nvalor = 0D;
            this.txtTotItf.ReadOnly = true;
            this.txtTotItf.Size = new System.Drawing.Size(74, 20);
            this.txtTotItf.TabIndex = 124;
            this.txtTotItf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotItf.Visible = false;
            // 
            // txtTotComi
            // 
            this.txtTotComi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotComi.FormatoDecimal = true;
            this.txtTotComi.Location = new System.Drawing.Point(471, 482);
            this.txtTotComi.Name = "txtTotComi";
            this.txtTotComi.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotComi.nNumDecimales = 2;
            this.txtTotComi.nvalor = 0D;
            this.txtTotComi.ReadOnly = true;
            this.txtTotComi.Size = new System.Drawing.Size(89, 20);
            this.txtTotComi.TabIndex = 125;
            this.txtTotComi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgCalendario
            // 
            this.dtgCalendario.AllowUserToAddRows = false;
            this.dtgCalendario.AllowUserToDeleteRows = false;
            this.dtgCalendario.AllowUserToResizeColumns = false;
            this.dtgCalendario.AllowUserToResizeRows = false;
            this.dtgCalendario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCalendario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCalendario.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCalendario.Location = new System.Drawing.Point(3, 16);
            this.dtgCalendario.MultiSelect = false;
            this.dtgCalendario.Name = "dtgCalendario";
            this.dtgCalendario.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCalendario.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCalendario.RowHeadersVisible = false;
            this.dtgCalendario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgCalendario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCalendario.Size = new System.Drawing.Size(634, 462);
            this.dtgCalendario.TabIndex = 119;
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(8, 556);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 5;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(200, 556);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnPPInd
            // 
            this.btnPPInd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPPInd.BackgroundImage")));
            this.btnPPInd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPPInd.Location = new System.Drawing.Point(136, 556);
            this.btnPPInd.Name = "btnPPInd";
            this.btnPPInd.Size = new System.Drawing.Size(60, 50);
            this.btnPPInd.TabIndex = 1;
            this.btnPPInd.Text = "PP Ind.";
            this.btnPPInd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPPInd.UseVisualStyleBackColor = true;
            this.btnPPInd.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnPPGrupal
            // 
            this.btnPPGrupal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPPGrupal.BackgroundImage")));
            this.btnPPGrupal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPPGrupal.Location = new System.Drawing.Point(72, 556);
            this.btnPPGrupal.Name = "btnPPGrupal";
            this.btnPPGrupal.Size = new System.Drawing.Size(60, 50);
            this.btnPPGrupal.TabIndex = 7;
            this.btnPPGrupal.Text = "PP Grupal";
            this.btnPPGrupal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPPGrupal.UseVisualStyleBackColor = true;
            this.btnPPGrupal.Click += new System.EventHandler(this.btnPPGrupal_Click);
            // 
            // tabPlanPagos
            // 
            this.tabPlanPagos.Controls.Add(this.tabPage2);
            this.tabPlanPagos.Controls.Add(this.tabPage1);
            this.tabPlanPagos.Location = new System.Drawing.Point(327, 64);
            this.tabPlanPagos.Name = "tabPlanPagos";
            this.tabPlanPagos.SelectedIndex = 0;
            this.tabPlanPagos.Size = new System.Drawing.Size(648, 597);
            this.tabPlanPagos.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chcExtractoPagos);
            this.tabPage2.Controls.Add(this.grbExtracto);
            this.tabPage2.Controls.Add(this.grbBase4);
            this.tabPage2.Controls.Add(this.grbBase3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(640, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Condiciones del crédito";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chcExtractoPagos
            // 
            this.chcExtractoPagos.AutoSize = true;
            this.chcExtractoPagos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcExtractoPagos.ForeColor = System.Drawing.Color.Navy;
            this.chcExtractoPagos.Location = new System.Drawing.Point(6, 360);
            this.chcExtractoPagos.Name = "chcExtractoPagos";
            this.chcExtractoPagos.Size = new System.Drawing.Size(580, 17);
            this.chcExtractoPagos.TabIndex = 131;
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
            this.grbExtracto.Location = new System.Drawing.Point(7, 376);
            this.grbExtracto.Name = "grbExtracto";
            this.grbExtracto.Size = new System.Drawing.Size(621, 90);
            this.grbExtracto.TabIndex = 132;
            this.grbExtracto.TabStop = false;
            this.grbExtracto.Visible = false;
            // 
            // rbtMedEnvio3
            // 
            this.rbtMedEnvio3.AutoSize = true;
            this.rbtMedEnvio3.Checked = true;
            this.rbtMedEnvio3.ForeColor = System.Drawing.Color.Navy;
            this.rbtMedEnvio3.Location = new System.Drawing.Point(9, 73);
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
            this.rbtMedEnvio2.Location = new System.Drawing.Point(9, 44);
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
            this.rbtMedEnvio1.Location = new System.Drawing.Point(9, 15);
            this.rbtMedEnvio1.Name = "rbtMedEnvio1";
            this.rbtMedEnvio1.Size = new System.Drawing.Size(569, 17);
            this.rbtMedEnvio1.TabIndex = 0;
            this.rbtMedEnvio1.Text = "a). Al domicilio señalado.Autorizo a la Caja Los Andes cargar a mi crédito la sum" +
    "a de S/. 3.50 por el costo de envío.";
            this.rbtMedEnvio1.UseVisualStyleBackColor = true;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblBase4);
            this.grbBase4.Controls.Add(this.lblBase9);
            this.grbBase4.Controls.Add(this.nudMonto);
            this.grbBase4.Controls.Add(this.txtTasaEfectivaAnual);
            this.grbBase4.Location = new System.Drawing.Point(6, 306);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(628, 47);
            this.grbBase4.TabIndex = 5;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Tasa - Integrante : ";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(25, 16);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(105, 13);
            this.lblBase4.TabIndex = 134;
            this.lblBase4.Text = "Monto Aprobado:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(241, 16);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(34, 13);
            this.lblBase9.TabIndex = 144;
            this.lblBase9.Text = "TEA:";
            // 
            // nudMonto
            // 
            this.nudMonto.Enabled = false;
            this.nudMonto.FormatoDecimal = false;
            this.nudMonto.Location = new System.Drawing.Point(130, 13);
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMonto.nNumDecimales = 2;
            this.nudMonto.nvalor = 0D;
            this.nudMonto.Size = new System.Drawing.Size(93, 20);
            this.nudMonto.TabIndex = 135;
            // 
            // txtTasaEfectivaAnual
            // 
            this.txtTasaEfectivaAnual.Enabled = false;
            this.txtTasaEfectivaAnual.FormatoDecimal = false;
            this.txtTasaEfectivaAnual.Location = new System.Drawing.Point(281, 13);
            this.txtTasaEfectivaAnual.Name = "txtTasaEfectivaAnual";
            this.txtTasaEfectivaAnual.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaEfectivaAnual.nNumDecimales = 4;
            this.txtTasaEfectivaAnual.nvalor = 0D;
            this.txtTasaEfectivaAnual.Size = new System.Drawing.Size(55, 20);
            this.txtTasaEfectivaAnual.TabIndex = 140;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboPaqueteSeguro1);
            this.grbBase3.Controls.Add(this.cboDetalleGasto);
            this.grbBase3.Controls.Add(this.lblPaqueteSeguro);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.lblBaseCustom1);
            this.grbBase3.Controls.Add(this.chcMantenerCuotasCtes);
            this.grbBase3.Controls.Add(this.chcBancoNacion);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.cboOperacionCre);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.cboAsesorNegociosGrupoSolidario);
            this.grbBase3.Controls.Add(this.conCondiCreditoGrupoSol);
            this.grbBase3.Location = new System.Drawing.Point(6, 6);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(628, 294);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Condiciones de Crédito";
            // 
            // cboPaqueteSeguro1
            // 
            this.cboPaqueteSeguro1.FormattingEnabled = true;
            this.cboPaqueteSeguro1.Location = new System.Drawing.Point(433, 268);
            this.cboPaqueteSeguro1.Name = "cboPaqueteSeguro1";
            this.cboPaqueteSeguro1.Size = new System.Drawing.Size(173, 21);
            this.cboPaqueteSeguro1.TabIndex = 139;
            this.cboPaqueteSeguro1.SelectedIndexChanged += new System.EventHandler(this.cboPaqueteSeguro_SelectedIndexChanged);
            // 
            // cboDetalleGasto
            // 
            this.cboDetalleGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetalleGasto.Enabled = false;
            this.cboDetalleGasto.FormattingEnabled = true;
            this.cboDetalleGasto.Location = new System.Drawing.Point(433, 245);
            this.cboDetalleGasto.Name = "cboDetalleGasto";
            this.cboDetalleGasto.Size = new System.Drawing.Size(173, 21);
            this.cboDetalleGasto.TabIndex = 138;
            // 
            // lblPaqueteSeguro
            // 
            this.lblPaqueteSeguro.AutoSize = true;
            this.lblPaqueteSeguro.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPaqueteSeguro.ForeColor = System.Drawing.Color.Navy;
            this.lblPaqueteSeguro.Location = new System.Drawing.Point(348, 272);
            this.lblPaqueteSeguro.Name = "lblPaqueteSeguro";
            this.lblPaqueteSeguro.Size = new System.Drawing.Size(76, 13);
            this.lblPaqueteSeguro.TabIndex = 137;
            this.lblPaqueteSeguro.Text = "Plan Seguro";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(337, 249);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(92, 13);
            this.lblBase5.TabIndex = 136;
            this.lblBase5.Text = "Tipo de seguro";
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(236, 16);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(147, 13);
            this.lblBaseCustom1.TabIndex = 135;
            this.lblBaseCustom1.Text = "Modalidad de crédito:";
            // 
            // chcMantenerCuotasCtes
            // 
            this.chcMantenerCuotasCtes.AutoSize = true;
            this.chcMantenerCuotasCtes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcMantenerCuotasCtes.Checked = true;
            this.chcMantenerCuotasCtes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcMantenerCuotasCtes.ForeColor = System.Drawing.Color.Navy;
            this.chcMantenerCuotasCtes.Location = new System.Drawing.Point(11, 270);
            this.chcMantenerCuotasCtes.Name = "chcMantenerCuotasCtes";
            this.chcMantenerCuotasCtes.Size = new System.Drawing.Size(323, 17);
            this.chcMantenerCuotasCtes.TabIndex = 133;
            this.chcMantenerCuotasCtes.Text = "Mantener Cuotas Constantes (a pesar de Comisiones variables)";
            this.chcMantenerCuotasCtes.UseVisualStyleBackColor = true;
            // 
            // chcBancoNacion
            // 
            this.chcBancoNacion.AutoSize = true;
            this.chcBancoNacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chcBancoNacion.ForeColor = System.Drawing.Color.Navy;
            this.chcBancoNacion.Location = new System.Drawing.Point(10, 247);
            this.chcBancoNacion.Name = "chcBancoNacion";
            this.chcBancoNacion.Size = new System.Drawing.Size(264, 17);
            this.chcBancoNacion.TabIndex = 50;
            this.chcBancoNacion.Text = "¿Desembolso se realizará en Banco de la Nación?";
            this.chcBancoNacion.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(58, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Operacion";
            // 
            // cboOperacionCre
            // 
            this.cboOperacionCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperacionCre.Enabled = false;
            this.cboOperacionCre.FormattingEnabled = true;
            this.cboOperacionCre.Location = new System.Drawing.Point(125, 42);
            this.cboOperacionCre.Name = "cboOperacionCre";
            this.cboOperacionCre.Size = new System.Drawing.Size(121, 21);
            this.cboOperacionCre.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(337, 46);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(46, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Asesor";
            // 
            // cboAsesorNegociosGrupoSolidario
            // 
            this.cboAsesorNegociosGrupoSolidario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesorNegociosGrupoSolidario.Enabled = false;
            this.cboAsesorNegociosGrupoSolidario.FormattingEnabled = true;
            this.cboAsesorNegociosGrupoSolidario.Location = new System.Drawing.Point(386, 42);
            this.cboAsesorNegociosGrupoSolidario.Name = "cboAsesorNegociosGrupoSolidario";
            this.cboAsesorNegociosGrupoSolidario.Size = new System.Drawing.Size(220, 21);
            this.cboAsesorNegociosGrupoSolidario.TabIndex = 3;
            // 
            // conCondiCreditoGrupoSol
            // 
            this.conCondiCreditoGrupoSol.Location = new System.Drawing.Point(11, 65);
            this.conCondiCreditoGrupoSol.MonedaEnabled = false;
            this.conCondiCreditoGrupoSol.Name = "conCondiCreditoGrupoSol";
            this.conCondiCreditoGrupoSol.NivelesProductoEnabled = true;
            this.conCondiCreditoGrupoSol.PeriodoEnabled = true;
            this.conCondiCreditoGrupoSol.Size = new System.Drawing.Size(595, 183);
            this.conCondiCreditoGrupoSol.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.conPlanPagos1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(640, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Plan Pagos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVincularPagare
            // 
            this.btnVincularPagare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularPagare.Enabled = false;
            this.btnVincularPagare.Location = new System.Drawing.Point(72, 611);
            this.btnVincularPagare.Name = "btnVincularPagare";
            this.btnVincularPagare.Size = new System.Drawing.Size(60, 50);
            this.btnVincularPagare.TabIndex = 57;
            this.btnVincularPagare.Text = "Vincular Pagaré";
            this.btnVincularPagare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularPagare.UseVisualStyleBackColor = true;
            this.btnVincularPagare.Click += new System.EventHandler(this.btnVincularPagare_Click);
            // 
            // btnHojaResumen
            // 
            this.btnHojaResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHojaResumen.Location = new System.Drawing.Point(136, 611);
            this.btnHojaResumen.Name = "btnHojaResumen";
            this.btnHojaResumen.Size = new System.Drawing.Size(60, 50);
            this.btnHojaResumen.TabIndex = 58;
            this.btnHojaResumen.Text = "Hoja Resumen";
            this.btnHojaResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHojaResumen.UseVisualStyleBackColor = true;
            this.btnHojaResumen.Click += new System.EventHandler(this.btnHojaResumen_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Location = new System.Drawing.Point(911, 16);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 59;
            this.btnVincular.Text = "Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnChecklist
            // 
            this.btnChecklist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChecklist.BackgroundImage")));
            this.btnChecklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChecklist.Enabled = false;
            this.btnChecklist.Location = new System.Drawing.Point(8, 611);
            this.btnChecklist.Name = "btnChecklist";
            this.btnChecklist.Size = new System.Drawing.Size(60, 50);
            this.btnChecklist.TabIndex = 64;
            this.btnChecklist.Text = "Checklist";
            this.btnChecklist.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChecklist.UseVisualStyleBackColor = true;
            this.btnChecklist.Click += new System.EventHandler(this.btnChecklist_Click);
            // 
            // frmGeneraPlanPagoGrupoSolidario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 689);
            this.Controls.Add(this.btnChecklist);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.btnHojaResumen);
            this.Controls.Add(this.btnVincularPagare);
            this.Controls.Add(this.tabPlanPagos);
            this.Controls.Add(this.btnPPGrupal);
            this.Controls.Add(this.gbxIntregantes);
            this.Controls.Add(this.btnPPInd);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.btnGrabar1);
            this.Name = "frmGeneraPlanPagoGrupoSolidario";
            this.Text = "Genera Plan de Pago GrupoSolidario";
            this.Load += new System.EventHandler(this.frmGeneraPlanPagoGrupoSolidario_Load);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnPPInd, 0);
            this.Controls.SetChildIndex(this.gbxIntregantes, 0);
            this.Controls.SetChildIndex(this.btnPPGrupal, 0);
            this.Controls.SetChildIndex(this.tabPlanPagos, 0);
            this.Controls.SetChildIndex(this.btnVincularPagare, 0);
            this.Controls.SetChildIndex(this.btnHojaResumen, 0);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.btnChecklist, 0);
            this.grbBase1.ResumeLayout(false);
            this.gbxIntregantes.ResumeLayout(false);
            this.gbxIntregantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantesGrupoSol)).EndInit();
            this.conPlanPagos1.ResumeLayout(false);
            this.conPlanPagos1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCalendario)).EndInit();
            this.tabPlanPagos.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grbExtracto.ResumeLayout(false);
            this.grbExtracto.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase gbxIntregantes;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.conPlanPagos conPlanPagos1;
        private GEN.ControlesBase.txtNumRea txtTCEA;
        private GEN.ControlesBase.txtNumRea txtTEM;
        private GEN.ControlesBase.txtNumRea txtTEA;
        private GEN.ControlesBase.grbBase object_80a9a5f2_d902_4978_bfb7_da4825c4ad04;
        private GEN.ControlesBase.txtNumRea txtTotCuota;
        private GEN.ControlesBase.txtNumRea txtTotInteres;
        private GEN.ControlesBase.txtNumRea txtTotCapital;
        private GEN.ControlesBase.txtNumRea txtTotDias;
        private GEN.ControlesBase.txtNumRea txtTotItf;
        private GEN.ControlesBase.txtNumRea txtTotComi;
        private GEN.ControlesBase.dtgBase dtgCalendario;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnMiniDetalle btnMiniDetalle;
        private GEN.ControlesBase.dtgBase dtgIntegrantesGrupoSol;
        private GEN.BotonesBase.btnImprimir btnPPInd;
        private GEN.BotonesBase.btnImprimir btnPPGrupal;
        private System.Windows.Forms.TabControl tabPlanPagos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.BotonesBase.btnBlanco btnVincularPagare;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboOperacionCre cboOperacionCre;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboAsesorNegociosGrupoSolidario cboAsesorNegociosGrupoSolidario;
        private GEN.ControlesBase.ConCondiCreditoGrupoSol conCondiCreditoGrupoSol;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea nudMonto;
        private GEN.ControlesBase.txtNumRea txtTasaEfectivaAnual;
        private GEN.ControlesBase.chcBase chcExtractoPagos;
        private GEN.ControlesBase.grbBase grbExtracto;
        private GEN.ControlesBase.rbtBase rbtMedEnvio3;
        private GEN.ControlesBase.rbtBase rbtMedEnvio2;
        private GEN.ControlesBase.rbtBase rbtMedEnvio1;
        private GEN.ControlesBase.chcBase chcBancoNacion;
        private GEN.ControlesBase.chcBase chcMantenerCuotasCtes;
        private GEN.BotonesBase.btnBlanco btnHojaResumen;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.BotonesBase.btnVincular btnVincular;
        private GEN.BotonesBase.btnDocumento btnChecklist;
        private GEN.ControlesBase.lblBase lblPaqueteSeguro;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboPaqueteSeguro cboPaqueteSeguro1;
        private GEN.ControlesBase.cboDetalleGasto cboDetalleGasto;
    }
}