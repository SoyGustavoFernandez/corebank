using GEN.BotonesBase;

namespace CNE.Presentacion
{
    partial class frmConciliacionPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConciliacionPagos));
            this.btnCargar = new GEN.BotonesBase.btnCargarFile();
            this.dtgDatosCargados = new GEN.ControlesBase.dtgBase(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCarga = new System.Windows.Forms.TabPage();
            this.btnPagar = new GEN.BotonesBase.btnPagar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboArchivoCargado = new GEN.ControlesBase.cboBase(this.components);
            this.btnEjecutar = new GEN.BotonesBase.btnEjecutar();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.cboCanalesElec = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFechaCarga = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.tabPageConciliacion = new System.Windows.Forms.TabPage();
            this.btnAbsolver = new GEN.BotonesBase.btnAbsolver();
            this.cboArchivoCargado2 = new GEN.ControlesBase.cboBase(this.components);
            this.cboCanalesElec2 = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFechaConci = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadCore = new GEN.ControlesBase.txtBase(this.components);
            this.txtCantidadConci = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtTotalCore = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotalConci = new GEN.ControlesBase.txtBase(this.components);
            this.dtgPagosCoreBank = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgPagosCargados = new GEN.ControlesBase.dtgBase(this.components);
            this.idPagosCargados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCodigoCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCanalServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSemaforo = new System.Windows.Forms.Panel();
            this.btnRed = new GEN.BotonesBase.btnRoundButton();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.btnYellow = new GEN.BotonesBase.btnRoundButton();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnGreen = new GEN.BotonesBase.btnRoundButton();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnObservacion = new GEN.BotonesBase.btnObservacion();
            this.btnConsultarConci = new GEN.BotonesBase.btnConsultar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnBitacora = new GEN.BotonesBase.btnDetalle();
            this.btnExporLog = new GEN.BotonesBase.btnExporTxt();
            this.dFechaOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdKardex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtrasoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMotivoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoKardex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoKardex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoCB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCargados)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCarga.SuspendLayout();
            this.tabPageConciliacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagosCoreBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagosCargados)).BeginInit();
            this.panelSemaforo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargar.BackgroundImage")));
            this.btnCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargar.Location = new System.Drawing.Point(1177, 13);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(60, 50);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // dtgDatosCargados
            // 
            this.dtgDatosCargados.AllowUserToAddRows = false;
            this.dtgDatosCargados.AllowUserToDeleteRows = false;
            this.dtgDatosCargados.AllowUserToResizeColumns = false;
            this.dtgDatosCargados.AllowUserToResizeRows = false;
            this.dtgDatosCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatosCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosCargados.Location = new System.Drawing.Point(16, 75);
            this.dtgDatosCargados.MultiSelect = false;
            this.dtgDatosCargados.Name = "dtgDatosCargados";
            this.dtgDatosCargados.ReadOnly = true;
            this.dtgDatosCargados.RowHeadersVisible = false;
            this.dtgDatosCargados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatosCargados.Size = new System.Drawing.Size(1221, 444);
            this.dtgDatosCargados.TabIndex = 10;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCarga);
            this.tabControl.Controls.Add(this.tabPageConciliacion);
            this.tabControl.Location = new System.Drawing.Point(12, 26);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1260, 561);
            this.tabControl.TabIndex = 11;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageCarga
            // 
            this.tabPageCarga.Controls.Add(this.btnPagar);
            this.tabPageCarga.Controls.Add(this.lblBase1);
            this.tabPageCarga.Controls.Add(this.cboArchivoCargado);
            this.tabPageCarga.Controls.Add(this.btnEjecutar);
            this.tabPageCarga.Controls.Add(this.btnConsultar);
            this.tabPageCarga.Controls.Add(this.cboCanalesElec);
            this.tabPageCarga.Controls.Add(this.dtpFechaCarga);
            this.tabPageCarga.Controls.Add(this.lblBase6);
            this.tabPageCarga.Controls.Add(this.lblBase5);
            this.tabPageCarga.Controls.Add(this.dtgDatosCargados);
            this.tabPageCarga.Controls.Add(this.btnCargar);
            this.tabPageCarga.Location = new System.Drawing.Point(4, 22);
            this.tabPageCarga.Name = "tabPageCarga";
            this.tabPageCarga.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCarga.Size = new System.Drawing.Size(1252, 535);
            this.tabPageCarga.TabIndex = 0;
            this.tabPageCarga.Text = "1. Carga";
            this.tabPageCarga.UseVisualStyleBackColor = true;
            // 
            // btnPagar
            // 
            this.btnPagar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPagar.BackgroundImage")));
            this.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPagar.Location = new System.Drawing.Point(1097, 14);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(60, 50);
            this.btnPagar.TabIndex = 24;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(262, 45);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 23;
            this.lblBase1.Text = "Archivo de Carga:";
            // 
            // cboArchivoCargado
            // 
            this.cboArchivoCargado.FormattingEnabled = true;
            this.cboArchivoCargado.Location = new System.Drawing.Point(378, 42);
            this.cboArchivoCargado.Name = "cboArchivoCargado";
            this.cboArchivoCargado.Size = new System.Drawing.Size(168, 21);
            this.cboArchivoCargado.TabIndex = 22;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.BackgroundImage")));
            this.btnEjecutar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEjecutar.Location = new System.Drawing.Point(1177, 13);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(60, 50);
            this.btnEjecutar.TabIndex = 21;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(554, 14);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboCanalesElec
            // 
            this.cboCanalesElec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalesElec.FormattingEnabled = true;
            this.cboCanalesElec.Location = new System.Drawing.Point(16, 34);
            this.cboCanalesElec.Name = "cboCanalesElec";
            this.cboCanalesElec.Size = new System.Drawing.Size(227, 21);
            this.cboCanalesElec.TabIndex = 15;
            this.cboCanalesElec.SelectedIndexChanged += new System.EventHandler(this.cboCanalesElec_SelectedIndexChanged);
            // 
            // dtpFechaCarga
            // 
            this.dtpFechaCarga.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCarga.Location = new System.Drawing.Point(378, 16);
            this.dtpFechaCarga.Name = "dtpFechaCarga";
            this.dtpFechaCarga.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaCarga.TabIndex = 14;
            this.dtpFechaCarga.ValueChanged += new System.EventHandler(this.dtpFechaCarga_ValueChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(262, 21);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(102, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Fecha de Carga:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 17);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(49, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Canal: ";
            // 
            // tabPageConciliacion
            // 
            this.tabPageConciliacion.Controls.Add(this.btnAbsolver);
            this.tabPageConciliacion.Controls.Add(this.cboArchivoCargado2);
            this.tabPageConciliacion.Controls.Add(this.cboCanalesElec2);
            this.tabPageConciliacion.Controls.Add(this.dtpFechaConci);
            this.tabPageConciliacion.Controls.Add(this.lblBase3);
            this.tabPageConciliacion.Controls.Add(this.lblBase2);
            this.tabPageConciliacion.Controls.Add(this.lblBase16);
            this.tabPageConciliacion.Controls.Add(this.label3);
            this.tabPageConciliacion.Controls.Add(this.label2);
            this.tabPageConciliacion.Controls.Add(this.txtCantidadCore);
            this.tabPageConciliacion.Controls.Add(this.txtCantidadConci);
            this.tabPageConciliacion.Controls.Add(this.lblBase9);
            this.tabPageConciliacion.Controls.Add(this.lblBase8);
            this.tabPageConciliacion.Controls.Add(this.lblBase7);
            this.tabPageConciliacion.Controls.Add(this.lblBase12);
            this.tabPageConciliacion.Controls.Add(this.txtTotalCore);
            this.tabPageConciliacion.Controls.Add(this.txtTotalConci);
            this.tabPageConciliacion.Controls.Add(this.dtgPagosCoreBank);
            this.tabPageConciliacion.Controls.Add(this.dtgPagosCargados);
            this.tabPageConciliacion.Controls.Add(this.panelSemaforo);
            this.tabPageConciliacion.Controls.Add(this.btnObservacion);
            this.tabPageConciliacion.Controls.Add(this.btnConsultarConci);
            this.tabPageConciliacion.Location = new System.Drawing.Point(4, 22);
            this.tabPageConciliacion.Name = "tabPageConciliacion";
            this.tabPageConciliacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConciliacion.Size = new System.Drawing.Size(1252, 535);
            this.tabPageConciliacion.TabIndex = 1;
            this.tabPageConciliacion.Text = "2. Conciliación";
            this.tabPageConciliacion.UseVisualStyleBackColor = true;
            // 
            // btnAbsolver
            // 
            this.btnAbsolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbsolver.BackgroundImage")));
            this.btnAbsolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAbsolver.Location = new System.Drawing.Point(751, 16);
            this.btnAbsolver.Name = "btnAbsolver";
            this.btnAbsolver.Size = new System.Drawing.Size(60, 50);
            this.btnAbsolver.TabIndex = 50;
            this.btnAbsolver.Text = "Absolver";
            this.btnAbsolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbsolver.UseVisualStyleBackColor = true;
            this.btnAbsolver.Click += new System.EventHandler(this.btnAbsolver_Click);
            // 
            // cboArchivoCargado2
            // 
            this.cboArchivoCargado2.FormattingEnabled = true;
            this.cboArchivoCargado2.Location = new System.Drawing.Point(393, 42);
            this.cboArchivoCargado2.Name = "cboArchivoCargado2";
            this.cboArchivoCargado2.Size = new System.Drawing.Size(168, 21);
            this.cboArchivoCargado2.TabIndex = 49;
            // 
            // cboCanalesElec2
            // 
            this.cboCanalesElec2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalesElec2.FormattingEnabled = true;
            this.cboCanalesElec2.Location = new System.Drawing.Point(14, 34);
            this.cboCanalesElec2.Name = "cboCanalesElec2";
            this.cboCanalesElec2.Size = new System.Drawing.Size(227, 21);
            this.cboCanalesElec2.TabIndex = 48;
            // 
            // dtpFechaConci
            // 
            this.dtpFechaConci.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaConci.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaConci.Location = new System.Drawing.Point(393, 16);
            this.dtpFechaConci.Name = "dtpFechaConci";
            this.dtpFechaConci.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaConci.TabIndex = 47;
            this.dtpFechaConci.ValueChanged += new System.EventHandler(this.dtpFechaConci_ValueChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(254, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(135, 13);
            this.lblBase3.TabIndex = 22;
            this.lblBase3.Text = "Fecha de Conciliación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(255, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(112, 13);
            this.lblBase2.TabIndex = 27;
            this.lblBase2.Text = "Archivo de Carga:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(15, 17);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(49, 13);
            this.lblBase16.TabIndex = 45;
            this.lblBase16.Text = "Canal: ";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(476, 79);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(763, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Información Core Bank";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Canal Externo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCantidadCore
            // 
            this.txtCantidadCore.Enabled = false;
            this.txtCantidadCore.Location = new System.Drawing.Point(548, 502);
            this.txtCantidadCore.Name = "txtCantidadCore";
            this.txtCantidadCore.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadCore.TabIndex = 38;
            // 
            // txtCantidadConci
            // 
            this.txtCantidadConci.Enabled = false;
            this.txtCantidadConci.Location = new System.Drawing.Point(79, 502);
            this.txtCantidadConci.Name = "txtCantidadConci";
            this.txtCantidadConci.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadConci.TabIndex = 37;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(479, 505);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(63, 13);
            this.lblBase9.TabIndex = 36;
            this.lblBase9.Text = "Cantidad:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 505);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(63, 13);
            this.lblBase8.TabIndex = 35;
            this.lblBase8.Text = "Cantidad:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(1094, 505);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(39, 13);
            this.lblBase7.TabIndex = 34;
            this.lblBase7.Text = "Total:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(318, 505);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(39, 13);
            this.lblBase12.TabIndex = 33;
            this.lblBase12.Text = "Total:";
            // 
            // txtTotalCore
            // 
            this.txtTotalCore.Enabled = false;
            this.txtTotalCore.Location = new System.Drawing.Point(1139, 502);
            this.txtTotalCore.Name = "txtTotalCore";
            this.txtTotalCore.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCore.TabIndex = 32;
            // 
            // txtTotalConci
            // 
            this.txtTotalConci.Enabled = false;
            this.txtTotalConci.Location = new System.Drawing.Point(363, 502);
            this.txtTotalConci.Name = "txtTotalConci";
            this.txtTotalConci.Size = new System.Drawing.Size(100, 20);
            this.txtTotalConci.TabIndex = 31;
            // 
            // dtgPagosCoreBank
            // 
            this.dtgPagosCoreBank.AllowUserToAddRows = false;
            this.dtgPagosCoreBank.AllowUserToDeleteRows = false;
            this.dtgPagosCoreBank.AllowUserToResizeColumns = false;
            this.dtgPagosCoreBank.AllowUserToResizeRows = false;
            this.dtgPagosCoreBank.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPagosCoreBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagosCoreBank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dFechaOpe,
            this.idCuenta,
            this.idCuota,
            this.cDocumentoID,
            this.IdKardex,
            this.nMontoOperacion,
            this.nAtrasoPago,
            this.cTipoOperacion,
            this.cMotivoOperacion,
            this.idEstadoKardex,
            this.cEstadoKardex,
            this.idEstadoCB});
            this.dtgPagosCoreBank.Location = new System.Drawing.Point(476, 102);
            this.dtgPagosCoreBank.MultiSelect = false;
            this.dtgPagosCoreBank.Name = "dtgPagosCoreBank";
            this.dtgPagosCoreBank.ReadOnly = true;
            this.dtgPagosCoreBank.RowHeadersVisible = false;
            this.dtgPagosCoreBank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPagosCoreBank.Size = new System.Drawing.Size(763, 394);
            this.dtgPagosCoreBank.TabIndex = 30;
            this.dtgPagosCoreBank.SelectionChanged += new System.EventHandler(this.dtgPagosCoreBank_SelectionChanged);
            // 
            // dtgPagosCargados
            // 
            this.dtgPagosCargados.AllowUserToAddRows = false;
            this.dtgPagosCargados.AllowUserToDeleteRows = false;
            this.dtgPagosCargados.AllowUserToResizeColumns = false;
            this.dtgPagosCargados.AllowUserToResizeRows = false;
            this.dtgPagosCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPagosCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPagosCargados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPagosCargados,
            this.dFechaPago,
            this.cTipo,
            this.nCodigoCredito,
            this.nMontoPagado,
            this.idEstado,
            this.idCanalServicio});
            this.dtgPagosCargados.Location = new System.Drawing.Point(13, 102);
            this.dtgPagosCargados.MultiSelect = false;
            this.dtgPagosCargados.Name = "dtgPagosCargados";
            this.dtgPagosCargados.ReadOnly = true;
            this.dtgPagosCargados.RowHeadersVisible = false;
            this.dtgPagosCargados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPagosCargados.Size = new System.Drawing.Size(450, 394);
            this.dtgPagosCargados.TabIndex = 29;
            this.dtgPagosCargados.SelectionChanged += new System.EventHandler(this.dtgPagosCargados_SelectionChanged);
            // 
            // idPagosCargados
            // 
            this.idPagosCargados.DataPropertyName = "idPagosCargados";
            this.idPagosCargados.HeaderText = "idPagosCargados";
            this.idPagosCargados.Name = "idPagosCargados";
            this.idPagosCargados.ReadOnly = true;
            this.idPagosCargados.Visible = false;
            // 
            // dFechaPago
            // 
            this.dFechaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaPago.DataPropertyName = "dFechaPago";
            this.dFechaPago.FillWeight = 100.2631F;
            this.dFechaPago.HeaderText = "Fecha Pago";
            this.dFechaPago.Name = "dFechaPago";
            this.dFechaPago.ReadOnly = true;
            this.dFechaPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFechaPago.Width = 71;
            // 
            // cTipo
            // 
            this.cTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipo.DataPropertyName = "cTipoOperacion";
            this.cTipo.FillWeight = 103.2299F;
            this.cTipo.HeaderText = "Tipo";
            this.cTipo.Name = "cTipo";
            this.cTipo.ReadOnly = true;
            this.cTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cTipo.Width = 34;
            // 
            // nCodigoCredito
            // 
            this.nCodigoCredito.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nCodigoCredito.DataPropertyName = "nCodigoCredito";
            this.nCodigoCredito.FillWeight = 117.1371F;
            this.nCodigoCredito.HeaderText = "Codigo Credito";
            this.nCodigoCredito.Name = "nCodigoCredito";
            this.nCodigoCredito.ReadOnly = true;
            this.nCodigoCredito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nMontoPagado
            // 
            this.nMontoPagado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nMontoPagado.DataPropertyName = "nMontoPagado";
            this.nMontoPagado.FillWeight = 86.09576F;
            this.nMontoPagado.HeaderText = "Monto Pagado";
            this.nMontoPagado.Name = "nMontoPagado";
            this.nMontoPagado.ReadOnly = true;
            this.nMontoPagado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // idEstado
            // 
            this.idEstado.DataPropertyName = "idEstado";
            this.idEstado.HeaderText = "Estado";
            this.idEstado.Name = "idEstado";
            this.idEstado.ReadOnly = true;
            this.idEstado.Visible = false;
            // 
            // idCanalServicio
            // 
            this.idCanalServicio.DataPropertyName = "idCanalServicio";
            this.idCanalServicio.HeaderText = "idCanalServicio";
            this.idCanalServicio.Name = "idCanalServicio";
            this.idCanalServicio.ReadOnly = true;
            this.idCanalServicio.Visible = false;
            // 
            // panelSemaforo
            // 
            this.panelSemaforo.Controls.Add(this.btnRed);
            this.panelSemaforo.Controls.Add(this.lblBase11);
            this.panelSemaforo.Controls.Add(this.btnYellow);
            this.panelSemaforo.Controls.Add(this.lblBase10);
            this.panelSemaforo.Controls.Add(this.btnGreen);
            this.panelSemaforo.Controls.Add(this.lblBase4);
            this.panelSemaforo.Location = new System.Drawing.Point(993, 3);
            this.panelSemaforo.Name = "panelSemaforo";
            this.panelSemaforo.Size = new System.Drawing.Size(242, 73);
            this.panelSemaforo.TabIndex = 28;
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.FlatAppearance.BorderSize = 0;
            this.btnRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed.Location = new System.Drawing.Point(15, 48);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(20, 20);
            this.btnRed.TabIndex = 52;
            this.btnRed.UseVisualStyleBackColor = false;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(42, 52);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(190, 13);
            this.lblBase11.TabIndex = 26;
            this.lblBase11.Text = "No Existe Coincidencia - Cuenta";
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatAppearance.BorderSize = 0;
            this.btnYellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow.Location = new System.Drawing.Point(15, 26);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(20, 20);
            this.btnYellow.TabIndex = 51;
            this.btnYellow.UseVisualStyleBackColor = false;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(42, 30);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(65, 13);
            this.lblBase10.TabIndex = 25;
            this.lblBase10.Text = "Extornado";
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Green;
            this.btnGreen.FlatAppearance.BorderSize = 0;
            this.btnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen.Location = new System.Drawing.Point(15, 4);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(20, 20);
            this.btnGreen.TabIndex = 50;
            this.btnGreen.UseVisualStyleBackColor = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(42, 7);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(171, 13);
            this.lblBase4.TabIndex = 24;
            this.lblBase4.Text = "Existe Coincidencia - Cuenta";
            // 
            // btnObservacion
            // 
            this.btnObservacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObservacion.BackgroundImage")));
            this.btnObservacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnObservacion.Location = new System.Drawing.Point(817, 16);
            this.btnObservacion.Name = "btnObservacion";
            this.btnObservacion.Size = new System.Drawing.Size(60, 50);
            this.btnObservacion.TabIndex = 25;
            this.btnObservacion.Text = "&Obs.";
            this.btnObservacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnObservacion.UseVisualStyleBackColor = true;
            this.btnObservacion.Click += new System.EventHandler(this.btnObservacion_Click);
            // 
            // btnConsultarConci
            // 
            this.btnConsultarConci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultarConci.BackgroundImage")));
            this.btnConsultarConci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultarConci.Location = new System.Drawing.Point(578, 16);
            this.btnConsultarConci.Name = "btnConsultarConci";
            this.btnConsultarConci.Size = new System.Drawing.Size(60, 50);
            this.btnConsultarConci.TabIndex = 24;
            this.btnConsultarConci.Text = "&Consultar";
            this.btnConsultarConci.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultarConci.UseVisualStyleBackColor = true;
            this.btnConsultarConci.Click += new System.EventHandler(this.btnConsultarConci_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(529, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Conciliación de Pagos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(1208, 593);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnBitacora
            // 
            this.btnBitacora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBitacora.BackgroundImage")));
            this.btnBitacora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBitacora.Location = new System.Drawing.Point(12, 593);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(60, 50);
            this.btnBitacora.TabIndex = 15;
            this.btnBitacora.Text = "&Bitacora";
            this.btnBitacora.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBitacora.texto = "&Bitacora";
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnExporLog
            // 
            this.btnExporLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporLog.BackgroundImage")));
            this.btnExporLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporLog.Location = new System.Drawing.Point(12, 593);
            this.btnExporLog.Name = "btnExporLog";
            this.btnExporLog.Size = new System.Drawing.Size(60, 50);
            this.btnExporLog.TabIndex = 16;
            this.btnExporLog.Text = "&Log";
            this.btnExporLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporLog.texto = "&Log";
            this.btnExporLog.UseVisualStyleBackColor = true;
            this.btnExporLog.Click += new System.EventHandler(this.btnExporLog_Click);
            // 
            // dFechaOpe
            // 
            this.dFechaOpe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaOpe.DataPropertyName = "dFechaOpe";
            this.dFechaOpe.HeaderText = "FechaOpe";
            this.dFechaOpe.Name = "dFechaOpe";
            this.dFechaOpe.ReadOnly = true;
            this.dFechaOpe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFechaOpe.Width = 63;
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idCuenta.Width = 47;
            // 
            // idCuota
            // 
            this.idCuota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuota.DataPropertyName = "idCuota";
            this.idCuota.HeaderText = "Cuota";
            this.idCuota.Name = "idCuota";
            this.idCuota.ReadOnly = true;
            this.idCuota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idCuota.Width = 41;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.HeaderText = "Nro.Doc.";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            this.cDocumentoID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cDocumentoID.Width = 56;
            // 
            // IdKardex
            // 
            this.IdKardex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdKardex.DataPropertyName = "IdKardex";
            this.IdKardex.HeaderText = "Kardex";
            this.IdKardex.Name = "IdKardex";
            this.IdKardex.ReadOnly = true;
            this.IdKardex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdKardex.Width = 46;
            // 
            // nMontoOperacion
            // 
            this.nMontoOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nMontoOperacion.DataPropertyName = "nMontoOperacion";
            this.nMontoOperacion.HeaderText = "MontoOperacion";
            this.nMontoOperacion.Name = "nMontoOperacion";
            this.nMontoOperacion.ReadOnly = true;
            this.nMontoOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nMontoOperacion.Width = 92;
            // 
            // nAtrasoPago
            // 
            this.nAtrasoPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtrasoPago.DataPropertyName = "nAtrasoPago";
            this.nAtrasoPago.HeaderText = "AtrasoPago";
            this.nAtrasoPago.Name = "nAtrasoPago";
            this.nAtrasoPago.ReadOnly = true;
            this.nAtrasoPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nAtrasoPago.Width = 68;
            // 
            // cTipoOperacion
            // 
            this.cTipoOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoOperacion.DataPropertyName = "cTipoOperacion";
            this.cTipoOperacion.HeaderText = "TipoOperacion";
            this.cTipoOperacion.Name = "cTipoOperacion";
            this.cTipoOperacion.ReadOnly = true;
            this.cTipoOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cTipoOperacion.Width = 83;
            // 
            // cMotivoOperacion
            // 
            this.cMotivoOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cMotivoOperacion.DataPropertyName = "cMotivoOperacion";
            this.cMotivoOperacion.HeaderText = "MotivoOperacion";
            this.cMotivoOperacion.Name = "cMotivoOperacion";
            this.cMotivoOperacion.ReadOnly = true;
            this.cMotivoOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cMotivoOperacion.Width = 94;
            // 
            // idEstadoKardex
            // 
            this.idEstadoKardex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idEstadoKardex.DataPropertyName = "idEstadoKardex";
            this.idEstadoKardex.HeaderText = "idEstadoKardex";
            this.idEstadoKardex.Name = "idEstadoKardex";
            this.idEstadoKardex.ReadOnly = true;
            this.idEstadoKardex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idEstadoKardex.Visible = false;
            this.idEstadoKardex.Width = 87;
            // 
            // cEstadoKardex
            // 
            this.cEstadoKardex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cEstadoKardex.DataPropertyName = "cEstadoKardex";
            this.cEstadoKardex.HeaderText = "EstadoKardex";
            this.cEstadoKardex.Name = "cEstadoKardex";
            this.cEstadoKardex.ReadOnly = true;
            this.cEstadoKardex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cEstadoKardex.Width = 79;
            // 
            // idEstadoCB
            // 
            this.idEstadoCB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idEstadoCB.DataPropertyName = "idEstado";
            this.idEstadoCB.HeaderText = "idEstadoCB";
            this.idEstadoCB.Name = "idEstadoCB";
            this.idEstadoCB.ReadOnly = true;
            this.idEstadoCB.Visible = false;
            this.idEstadoCB.Width = 87;
            // 
            // frmConciliacionPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 673);
            this.Controls.Add(this.btnExporLog);
            this.Controls.Add(this.btnBitacora);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Name = "frmConciliacionPagos";
            this.Text = "Conciliacion de Pagos";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnBitacora, 0);
            this.Controls.SetChildIndex(this.btnExporLog, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCargados)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCarga.ResumeLayout(false);
            this.tabPageCarga.PerformLayout();
            this.tabPageConciliacion.ResumeLayout(false);
            this.tabPageConciliacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagosCoreBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPagosCargados)).EndInit();
            this.panelSemaforo.ResumeLayout(false);
            this.panelSemaforo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCargarFile btnCargar;
        private GEN.ControlesBase.dtgBase dtgDatosCargados;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCarga;
        private System.Windows.Forms.TabPage tabPageConciliacion;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtpCorto dtpFechaCarga;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboBase cboCanalesElec;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.BotonesBase.btnEjecutar btnEjecutar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboArchivoCargado;
        private System.Windows.Forms.Panel panelSemaforo;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnObservacion btnObservacion;
        private GEN.BotonesBase.btnConsultar btnConsultarConci;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private GEN.ControlesBase.txtBase txtCantidadCore;
        private GEN.ControlesBase.txtBase txtCantidadConci;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtTotalCore;
        private GEN.ControlesBase.txtBase txtTotalConci;
        private GEN.ControlesBase.dtgBase dtgPagosCoreBank;
        private GEN.ControlesBase.dtgBase dtgPagosCargados;
        private GEN.ControlesBase.cboBase cboArchivoCargado2;
        private GEN.ControlesBase.cboBase cboCanalesElec2;
        private GEN.ControlesBase.dtpCorto dtpFechaConci;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.BotonesBase.btnRoundButton btnRed;
        private GEN.BotonesBase.btnRoundButton btnYellow;
        private GEN.BotonesBase.btnRoundButton btnGreen;
        private GEN.BotonesBase.btnAbsolver btnAbsolver;
        private GEN.BotonesBase.btnDetalle btnBitacora;
        private btnExporTxt btnExporLog;
        private btnPagar btnPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPagosCargados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCodigoCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCanalServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdKardex;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtrasoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMotivoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoKardex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoKardex;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoCB;
    }
}