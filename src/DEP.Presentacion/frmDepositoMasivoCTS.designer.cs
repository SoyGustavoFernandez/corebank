namespace DEP.Presentacion
{
    partial class frmDepositoMasivoCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepositoMasivoCTS));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtNumCtasDep = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNumCtas = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMonTotDep = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgDatosCtasCts = new GEN.ControlesBase.dtgBase(this.components);
            this.lblPeriodoCTS = new GEN.ControlesBase.lblBase();
            this.cboPeriodoCTS = new GEN.ControlesBase.cboPeriodoCTS(this.components);
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoCargaMasivaAho = new GEN.ControlesBase.cboTipoCargaMasivaAho(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCaracteristica = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboPlanilla = new GEN.ControlesBase.cboBase(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.btnImprimirIncosis = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirDepMas = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCtasCts)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 113);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(80, 109);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(210, 21);
            this.cboMoneda.TabIndex = 4;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(15, 600);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(129, 13);
            this.lblBase7.TabIndex = 53;
            this.lblBase7.Text = "Depositos a Realizar:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 576);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(132, 13);
            this.lblBase6.TabIndex = 52;
            this.lblBase6.Text = "Número de Registros:";
            // 
            // txtNumCtasDep
            // 
            this.txtNumCtasDep.Enabled = false;
            this.txtNumCtasDep.FormatoDecimal = false;
            this.txtNumCtasDep.Location = new System.Drawing.Point(151, 596);
            this.txtNumCtasDep.Name = "txtNumCtasDep";
            this.txtNumCtasDep.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumCtasDep.nNumDecimales = 4;
            this.txtNumCtasDep.nvalor = 0D;
            this.txtNumCtasDep.Size = new System.Drawing.Size(90, 20);
            this.txtNumCtasDep.TabIndex = 51;
            this.txtNumCtasDep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumCtas
            // 
            this.txtNumCtas.Enabled = false;
            this.txtNumCtas.FormatoDecimal = false;
            this.txtNumCtas.Location = new System.Drawing.Point(151, 572);
            this.txtNumCtas.Name = "txtNumCtas";
            this.txtNumCtas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumCtas.nNumDecimales = 4;
            this.txtNumCtas.nvalor = 0D;
            this.txtNumCtas.Size = new System.Drawing.Size(90, 20);
            this.txtNumCtas.TabIndex = 50;
            this.txtNumCtas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(15, 624);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(128, 13);
            this.lblBase3.TabIndex = 49;
            this.lblBase3.Text = "Importe a Depositar:";
            // 
            // txtMonTotDep
            // 
            this.txtMonTotDep.Enabled = false;
            this.txtMonTotDep.FormatoDecimal = false;
            this.txtMonTotDep.Location = new System.Drawing.Point(151, 620);
            this.txtMonTotDep.Name = "txtMonTotDep";
            this.txtMonTotDep.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonTotDep.nNumDecimales = 4;
            this.txtMonTotDep.nvalor = 0D;
            this.txtMonTotDep.Size = new System.Drawing.Size(90, 20);
            this.txtMonTotDep.TabIndex = 48;
            this.txtMonTotDep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(717, 572);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 45;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(652, 572);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 47;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(782, 572);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 46;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dtgDatosCtasCts
            // 
            this.dtgDatosCtasCts.AllowUserToAddRows = false;
            this.dtgDatosCtasCts.AllowUserToDeleteRows = false;
            this.dtgDatosCtasCts.AllowUserToResizeColumns = false;
            this.dtgDatosCtasCts.AllowUserToResizeRows = false;
            this.dtgDatosCtasCts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDatosCtasCts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosCtasCts.Location = new System.Drawing.Point(11, 259);
            this.dtgDatosCtasCts.MultiSelect = false;
            this.dtgDatosCtasCts.Name = "dtgDatosCtasCts";
            this.dtgDatosCtasCts.ReadOnly = true;
            this.dtgDatosCtasCts.RowHeadersVisible = false;
            this.dtgDatosCtasCts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDatosCtasCts.Size = new System.Drawing.Size(831, 307);
            this.dtgDatosCtasCts.TabIndex = 44;
            this.dtgDatosCtasCts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDepositosCTS_CellValueChanged);
            this.dtgDatosCtasCts.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgDepositosCTS_CurrentCellDirtyStateChanged);
            // 
            // lblPeriodoCTS
            // 
            this.lblPeriodoCTS.AutoSize = true;
            this.lblPeriodoCTS.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPeriodoCTS.ForeColor = System.Drawing.Color.Navy;
            this.lblPeriodoCTS.Location = new System.Drawing.Point(302, 134);
            this.lblPeriodoCTS.Name = "lblPeriodoCTS";
            this.lblPeriodoCTS.Size = new System.Drawing.Size(83, 13);
            this.lblPeriodoCTS.TabIndex = 55;
            this.lblPeriodoCTS.Text = "Periodo CTS:";
            // 
            // cboPeriodoCTS
            // 
            this.cboPeriodoCTS.FormattingEnabled = true;
            this.cboPeriodoCTS.Location = new System.Drawing.Point(387, 130);
            this.cboPeriodoCTS.Name = "cboPeriodoCTS";
            this.cboPeriodoCTS.Size = new System.Drawing.Size(294, 21);
            this.cboPeriodoCTS.TabIndex = 56;
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Enabled = false;
            this.btnImportar.Location = new System.Drawing.Point(716, 203);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 58;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.Filter = "Libro de Excel (*.xlsx)|*.xlsx|Libro de Excel 97-2003 (*.xls)|*.xls";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 138);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(36, 13);
            this.lblBase5.TabIndex = 59;
            this.lblBase5.Text = "Tipo:";
            // 
            // cboTipoCargaMasivaAho
            // 
            this.cboTipoCargaMasivaAho.FormattingEnabled = true;
            this.cboTipoCargaMasivaAho.Location = new System.Drawing.Point(80, 134);
            this.cboTipoCargaMasivaAho.Name = "cboTipoCargaMasivaAho";
            this.cboTipoCargaMasivaAho.Size = new System.Drawing.Size(210, 21);
            this.cboTipoCargaMasivaAho.TabIndex = 60;
            this.cboTipoCargaMasivaAho.SelectedIndexChanged += new System.EventHandler(this.cboTipoCargaMasivaAho_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(302, 109);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 61;
            this.lblBase4.Text = "Planilla:";
            this.lblBase4.Visible = false;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Enabled = false;
            this.btnAceptar1.Location = new System.Drawing.Point(782, 203);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 63;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Visible = false;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtCaracteristica);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.conBusCol);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboPlanilla);
            this.grbBase1.Controls.Add(this.conBusCli);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboTipoCargaMasivaAho);
            this.grbBase1.Controls.Add(this.lblPeriodoCTS);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboPeriodoCTS);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(13, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(699, 249);
            this.grbBase1.TabIndex = 64;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales";
            // 
            // txtCaracteristica
            // 
            this.txtCaracteristica.Enabled = false;
            this.txtCaracteristica.Location = new System.Drawing.Point(80, 161);
            this.txtCaracteristica.Multiline = true;
            this.txtCaracteristica.Name = "txtCaracteristica";
            this.txtCaracteristica.Size = new System.Drawing.Size(210, 82);
            this.txtCaracteristica.TabIndex = 69;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(306, 157);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(128, 13);
            this.lblBase8.TabIndex = 67;
            this.lblBase8.Text = "Datos del ordenante:";
            // 
            // conBusCol
            // 
            this.conBusCol.cEstado = "0";
            this.conBusCol.Enabled = false;
            this.conBusCol.Location = new System.Drawing.Point(298, 157);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(390, 86);
            this.conBusCol.TabIndex = 68;
            this.conBusCol.BuscarUsuario += new System.EventHandler(this.conBusCol_BuscarUsuario);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 164);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(68, 13);
            this.lblBase2.TabIndex = 66;
            this.lblBase2.Text = "Categoria:";
            // 
            // cboPlanilla
            // 
            this.cboPlanilla.FormattingEnabled = true;
            this.cboPlanilla.Location = new System.Drawing.Point(387, 105);
            this.cboPlanilla.Name = "cboPlanilla";
            this.cboPlanilla.Size = new System.Drawing.Size(294, 21);
            this.cboPlanilla.TabIndex = 62;
            this.cboPlanilla.Visible = false;
            this.cboPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboPlanilla_SelectedIndexChanged);
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(6, 19);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(675, 82);
            this.conBusCli.TabIndex = 65;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // btnImprimirIncosis
            // 
            this.btnImprimirIncosis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirIncosis.BackgroundImage")));
            this.btnImprimirIncosis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirIncosis.Enabled = false;
            this.btnImprimirIncosis.Location = new System.Drawing.Point(586, 572);
            this.btnImprimirIncosis.Name = "btnImprimirIncosis";
            this.btnImprimirIncosis.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirIncosis.TabIndex = 65;
            this.btnImprimirIncosis.Text = "Imprimir Inconsis.";
            this.btnImprimirIncosis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirIncosis.UseVisualStyleBackColor = true;
            this.btnImprimirIncosis.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnImprimirDepMas
            // 
            this.btnImprimirDepMas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirDepMas.BackgroundImage")));
            this.btnImprimirDepMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirDepMas.Location = new System.Drawing.Point(520, 572);
            this.btnImprimirDepMas.Name = "btnImprimirDepMas";
            this.btnImprimirDepMas.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirDepMas.TabIndex = 66;
            this.btnImprimirDepMas.Text = "Imprimir";
            this.btnImprimirDepMas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirDepMas.UseVisualStyleBackColor = true;
            this.btnImprimirDepMas.Click += new System.EventHandler(this.btnImprimirDepMas_Click);
            // 
            // frmDepositoMasivoCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 672);
            this.Controls.Add(this.btnImprimirDepMas);
            this.Controls.Add(this.btnImprimirIncosis);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtNumCtasDep);
            this.Controls.Add(this.txtNumCtas);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtMonTotDep);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgDatosCtasCts);
            this.Name = "frmDepositoMasivoCTS";
            this.Text = "Depositos Masivos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDepositoMasivoCTS_FormClosed);
            this.Load += new System.EventHandler(this.frmDepositoMasivoCTS_Load);
            this.Controls.SetChildIndex(this.dtgDatosCtasCts, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.txtMonTotDep, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtNumCtas, 0);
            this.Controls.SetChildIndex(this.txtNumCtasDep, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprimirIncosis, 0);
            this.Controls.SetChildIndex(this.btnImprimirDepMas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosCtasCts)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtNumCtasDep;
        private GEN.ControlesBase.txtNumRea txtNumCtas;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtMonTotDep;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtgBase dtgDatosCtasCts;
        private GEN.ControlesBase.lblBase lblPeriodoCTS;
        private GEN.ControlesBase.cboPeriodoCTS cboPeriodoCTS;
        private GEN.BotonesBase.btnImportar btnImportar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboTipoCargaMasivaAho cboTipoCargaMasivaAho;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboBase cboPlanilla;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.BotonesBase.btnImprimir btnImprimirIncosis;
        private GEN.BotonesBase.btnImprimir btnImprimirDepMas;
        private GEN.ControlesBase.txtBase txtCaracteristica;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.lblBase lblBase2;
    }
}

