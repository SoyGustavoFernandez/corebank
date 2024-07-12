namespace CRE.Presentacion
{
    partial class frmCambiarOrdenPrelacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarOrdenPrelacion));
            this.grbOtros = new GEN.ControlesBase.grbBase(this.components);
            this.txtAsesor = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.txtEstadoCredito = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTasaInteres = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtTasaMoratoria = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDiasAtraso = new GEN.ControlesBase.txtBase(this.components);
            this.grbDetallesCredito = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtSaldoIntComp = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtSaldoOtros = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtSaldoMora = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtSaldoInteres = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotalDeuda = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtSaldoCapital = new GEN.ControlesBase.txtBase(this.components);
            this.conBusCuentaCli1 = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgConceptoNuevo = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgConceptoActual = new GEN.ControlesBase.dtgBase(this.components);
            this.grbOtros.SuspendLayout();
            this.grbDetallesCredito.SuspendLayout();
            this.conBusCuentaCli1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoNuevo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoActual)).BeginInit();
            this.SuspendLayout();
            // 
            // grbOtros
            // 
            this.grbOtros.Controls.Add(this.txtAsesor);
            this.grbOtros.Controls.Add(this.lblBase4);
            this.grbOtros.Controls.Add(this.txtMoneda);
            this.grbOtros.Controls.Add(this.txtEstadoCredito);
            this.grbOtros.Controls.Add(this.lblBase3);
            this.grbOtros.Controls.Add(this.txtTasaInteres);
            this.grbOtros.Controls.Add(this.lblBase13);
            this.grbOtros.Controls.Add(this.lblBase10);
            this.grbOtros.Controls.Add(this.txtTasaMoratoria);
            this.grbOtros.Controls.Add(this.lblBase11);
            this.grbOtros.Controls.Add(this.lblBase12);
            this.grbOtros.Controls.Add(this.txtDiasAtraso);
            this.grbOtros.Enabled = false;
            this.grbOtros.Location = new System.Drawing.Point(297, 118);
            this.grbOtros.Name = "grbOtros";
            this.grbOtros.Size = new System.Drawing.Size(272, 150);
            this.grbOtros.TabIndex = 34;
            this.grbOtros.TabStop = false;
            this.grbOtros.Text = "Otros";
            // 
            // txtAsesor
            // 
            this.txtAsesor.Location = new System.Drawing.Point(107, 116);
            this.txtAsesor.Name = "txtAsesor";
            this.txtAsesor.Size = new System.Drawing.Size(154, 20);
            this.txtAsesor.TabIndex = 5;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 119);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(51, 13);
            this.lblBase4.TabIndex = 30;
            this.lblBase4.Text = "Asesor:";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(107, 11);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(154, 20);
            this.txtMoneda.TabIndex = 0;
            // 
            // txtEstadoCredito
            // 
            this.txtEstadoCredito.Location = new System.Drawing.Point(107, 95);
            this.txtEstadoCredito.Name = "txtEstadoCredito";
            this.txtEstadoCredito.Size = new System.Drawing.Size(154, 20);
            this.txtEstadoCredito.TabIndex = 4;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(2, 16);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 27;
            this.lblBase3.Text = "Moneda:";
            // 
            // txtTasaInteres
            // 
            this.txtTasaInteres.Location = new System.Drawing.Point(107, 32);
            this.txtTasaInteres.Name = "txtTasaInteres";
            this.txtTasaInteres.Size = new System.Drawing.Size(154, 20);
            this.txtTasaInteres.TabIndex = 1;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(2, 100);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(96, 13);
            this.lblBase13.TabIndex = 26;
            this.lblBase13.Text = "Estado Crédito:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(2, 38);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(84, 13);
            this.lblBase10.TabIndex = 20;
            this.lblBase10.Text = "Tasa Interés:";
            // 
            // txtTasaMoratoria
            // 
            this.txtTasaMoratoria.Location = new System.Drawing.Point(107, 53);
            this.txtTasaMoratoria.Name = "txtTasaMoratoria";
            this.txtTasaMoratoria.Size = new System.Drawing.Size(154, 20);
            this.txtTasaMoratoria.TabIndex = 2;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(2, 58);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(97, 13);
            this.lblBase11.TabIndex = 22;
            this.lblBase11.Text = "Tasa Moratoria:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(2, 79);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(96, 13);
            this.lblBase12.TabIndex = 24;
            this.lblBase12.Text = "Días de Atraso:";
            // 
            // txtDiasAtraso
            // 
            this.txtDiasAtraso.Location = new System.Drawing.Point(108, 74);
            this.txtDiasAtraso.Name = "txtDiasAtraso";
            this.txtDiasAtraso.Size = new System.Drawing.Size(153, 20);
            this.txtDiasAtraso.TabIndex = 3;
            // 
            // grbDetallesCredito
            // 
            this.grbDetallesCredito.Controls.Add(this.lblBase1);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoIntComp);
            this.grbDetallesCredito.Controls.Add(this.lblBase9);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoOtros);
            this.grbDetallesCredito.Controls.Add(this.lblBase8);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoMora);
            this.grbDetallesCredito.Controls.Add(this.lblBase7);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoInteres);
            this.grbDetallesCredito.Controls.Add(this.txtTotalDeuda);
            this.grbDetallesCredito.Controls.Add(this.lblBase6);
            this.grbDetallesCredito.Controls.Add(this.lblBase2);
            this.grbDetallesCredito.Controls.Add(this.txtSaldoCapital);
            this.grbDetallesCredito.Enabled = false;
            this.grbDetallesCredito.Location = new System.Drawing.Point(12, 118);
            this.grbDetallesCredito.Name = "grbDetallesCredito";
            this.grbDetallesCredito.Size = new System.Drawing.Size(278, 150);
            this.grbDetallesCredito.TabIndex = 32;
            this.grbDetallesCredito.TabStop = false;
            this.grbDetallesCredito.Text = "Detalles de Crédito";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 61);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 13);
            this.lblBase1.TabIndex = 26;
            this.lblBase1.Text = "Saldo Comp:";
            // 
            // txtSaldoIntComp
            // 
            this.txtSaldoIntComp.Location = new System.Drawing.Point(106, 58);
            this.txtSaldoIntComp.Name = "txtSaldoIntComp";
            this.txtSaldoIntComp.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoIntComp.TabIndex = 2;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(11, 104);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(79, 13);
            this.lblBase9.TabIndex = 24;
            this.lblBase9.Text = "Saldo Otros:";
            // 
            // txtSaldoOtros
            // 
            this.txtSaldoOtros.Location = new System.Drawing.Point(106, 101);
            this.txtSaldoOtros.Name = "txtSaldoOtros";
            this.txtSaldoOtros.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoOtros.TabIndex = 4;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(11, 83);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(76, 13);
            this.lblBase8.TabIndex = 22;
            this.lblBase8.Text = "Saldo Mora:";
            // 
            // txtSaldoMora
            // 
            this.txtSaldoMora.Location = new System.Drawing.Point(106, 80);
            this.txtSaldoMora.Name = "txtSaldoMora";
            this.txtSaldoMora.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoMora.TabIndex = 3;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 39);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(89, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Saldo Interés:";
            // 
            // txtSaldoInteres
            // 
            this.txtSaldoInteres.Location = new System.Drawing.Point(106, 36);
            this.txtSaldoInteres.Name = "txtSaldoInteres";
            this.txtSaldoInteres.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoInteres.TabIndex = 1;
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.Location = new System.Drawing.Point(106, 122);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.Size = new System.Drawing.Size(165, 20);
            this.txtTotalDeuda.TabIndex = 5;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(11, 125);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(81, 13);
            this.lblBase6.TabIndex = 17;
            this.lblBase6.Text = "Total Deuda:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(88, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Saldo Capital:";
            // 
            // txtSaldoCapital
            // 
            this.txtSaldoCapital.Location = new System.Drawing.Point(106, 15);
            this.txtSaldoCapital.Name = "txtSaldoCapital";
            this.txtSaldoCapital.Size = new System.Drawing.Size(165, 20);
            this.txtSaldoCapital.TabIndex = 0;
            // 
            // conBusCuentaCli1
            // 
            this.conBusCuentaCli1.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli1.Controls.Add(this.grbBase1);
            this.conBusCuentaCli1.Controls.Add(this.grbBase2);
            this.conBusCuentaCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli1.Name = "conBusCuentaCli1";
            this.conBusCuentaCli1.Size = new System.Drawing.Size(564, 100);
            this.conBusCuentaCli1.TabIndex = 33;
            this.conBusCuentaCli1.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli1_MyKey);
            this.conBusCuentaCli1.MyClic += new System.EventHandler(this.conBusCuentaCli1_MyClic);
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(554, 99);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, -2);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(554, 99);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // dtgConceptoNuevo
            // 
            this.dtgConceptoNuevo.AllowUserToAddRows = false;
            this.dtgConceptoNuevo.AllowUserToDeleteRows = false;
            this.dtgConceptoNuevo.AllowUserToResizeColumns = false;
            this.dtgConceptoNuevo.AllowUserToResizeRows = false;
            this.dtgConceptoNuevo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConceptoNuevo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptoNuevo.Location = new System.Drawing.Point(50, 19);
            this.dtgConceptoNuevo.MultiSelect = false;
            this.dtgConceptoNuevo.Name = "dtgConceptoNuevo";
            this.dtgConceptoNuevo.ReadOnly = true;
            this.dtgConceptoNuevo.RowHeadersVisible = false;
            this.dtgConceptoNuevo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptoNuevo.Size = new System.Drawing.Size(183, 137);
            this.dtgConceptoNuevo.TabIndex = 35;
            this.dtgConceptoNuevo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConcepto_CellValueChanged);
            this.dtgConceptoNuevo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgConceptoNuevo_DataError);
            this.dtgConceptoNuevo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgConcepto_EditingControlShowing);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgConceptoNuevo);
            this.groupBox1.Location = new System.Drawing.Point(297, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 166);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden de prelación nueva";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(311, 446);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 37;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(443, 446);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 38;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(509, 446);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 39;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(377, 446);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 40;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgConceptoActual);
            this.groupBox2.Location = new System.Drawing.Point(15, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 166);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Orden de prelación actual";
            // 
            // dtgConceptoActual
            // 
            this.dtgConceptoActual.AllowUserToAddRows = false;
            this.dtgConceptoActual.AllowUserToDeleteRows = false;
            this.dtgConceptoActual.AllowUserToResizeColumns = false;
            this.dtgConceptoActual.AllowUserToResizeRows = false;
            this.dtgConceptoActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConceptoActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptoActual.Enabled = false;
            this.dtgConceptoActual.Location = new System.Drawing.Point(44, 19);
            this.dtgConceptoActual.MultiSelect = false;
            this.dtgConceptoActual.Name = "dtgConceptoActual";
            this.dtgConceptoActual.ReadOnly = true;
            this.dtgConceptoActual.RowHeadersVisible = false;
            this.dtgConceptoActual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptoActual.Size = new System.Drawing.Size(183, 137);
            this.dtgConceptoActual.TabIndex = 35;
            // 
            // frmCambiarOrdenPrelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbOtros);
            this.Controls.Add(this.grbDetallesCredito);
            this.Controls.Add(this.conBusCuentaCli1);
            this.Name = "frmCambiarOrdenPrelacion";
            this.Text = "Cambiar Orden Prelación";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCambiarOrdenPrelacion_FormClosed);
            this.Load += new System.EventHandler(this.frmCambiarOrdenPrelacion_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli1, 0);
            this.Controls.SetChildIndex(this.grbDetallesCredito, 0);
            this.Controls.SetChildIndex(this.grbOtros, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbOtros.ResumeLayout(false);
            this.grbOtros.PerformLayout();
            this.grbDetallesCredito.ResumeLayout(false);
            this.grbDetallesCredito.PerformLayout();
            this.conBusCuentaCli1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoNuevo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoActual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbOtros;
        private GEN.ControlesBase.txtBase txtAsesor;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.txtBase txtEstadoCredito;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtTasaInteres;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtBase txtTasaMoratoria;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtDiasAtraso;
        private GEN.ControlesBase.grbBase grbDetallesCredito;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtSaldoIntComp;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtSaldoOtros;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtSaldoMora;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtSaldoInteres;
        private GEN.ControlesBase.txtBase txtTotalDeuda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtSaldoCapital;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgConceptoNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgConceptoActual;
    }
}