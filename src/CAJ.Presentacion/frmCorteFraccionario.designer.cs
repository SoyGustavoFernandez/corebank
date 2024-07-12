namespace CAJ.Presentacion
{
    partial class frmCorteFraccionario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorteFraccionario));
            this.tbcCorte = new GEN.ControlesBase.tbcBase(this.components);
            this.tabSoles = new System.Windows.Forms.TabPage();
            this.txtMonTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonMoneda = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtgMonedas = new GEN.ControlesBase.dtgBase(this.components);
            this.txtMonBillete = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgBilletes = new GEN.ControlesBase.dtgBase(this.components);
            this.tabDolares = new System.Windows.Forms.TabPage();
            this.txtTotDolar = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtBillDol = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtgBillDolares = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.cboTipResponsable = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.tbcCorte.SuspendLayout();
            this.tabSoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonedas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBilletes)).BeginInit();
            this.tabDolares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBillDolares)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcCorte
            // 
            this.tbcCorte.Controls.Add(this.tabSoles);
            this.tbcCorte.Controls.Add(this.tabDolares);
            this.tbcCorte.Location = new System.Drawing.Point(3, 93);
            this.tbcCorte.Name = "tbcCorte";
            this.tbcCorte.SelectedIndex = 0;
            this.tbcCorte.Size = new System.Drawing.Size(571, 311);
            this.tbcCorte.TabIndex = 2;
            this.tbcCorte.Click += new System.EventHandler(this.tbcCorte_Click);
            // 
            // tabSoles
            // 
            this.tabSoles.Controls.Add(this.txtMonTotal);
            this.tabSoles.Controls.Add(this.lblBase5);
            this.tabSoles.Controls.Add(this.lblBase4);
            this.tabSoles.Controls.Add(this.txtMonMoneda);
            this.tabSoles.Controls.Add(this.dtgMonedas);
            this.tabSoles.Controls.Add(this.txtMonBillete);
            this.tabSoles.Controls.Add(this.lblBase6);
            this.tabSoles.Controls.Add(this.dtgBilletes);
            this.tabSoles.Location = new System.Drawing.Point(4, 22);
            this.tabSoles.Name = "tabSoles";
            this.tabSoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabSoles.Size = new System.Drawing.Size(563, 285);
            this.tabSoles.TabIndex = 0;
            this.tabSoles.Text = "Billetaje en Soles (S/.)";
            this.tabSoles.UseVisualStyleBackColor = true;
            // 
            // txtMonTotal
            // 
            this.txtMonTotal.Enabled = false;
            this.txtMonTotal.FormatoDecimal = true;
            this.txtMonTotal.Location = new System.Drawing.Point(154, 259);
            this.txtMonTotal.Name = "txtMonTotal";
            this.txtMonTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonTotal.nNumDecimales = 2;
            this.txtMonTotal.nvalor = 0D;
            this.txtMonTotal.Size = new System.Drawing.Size(124, 20);
            this.txtMonTotal.TabIndex = 27;
            this.txtMonTotal.Text = "0.00";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(2, 262);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(143, 13);
            this.lblBase5.TabIndex = 26;
            this.lblBase5.Text = "TOTAL BILLETAJE (S/.):";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(318, 229);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(111, 13);
            this.lblBase4.TabIndex = 24;
            this.lblBase4.Text = "TOTAL MONEDAS:";
            // 
            // txtMonMoneda
            // 
            this.txtMonMoneda.Enabled = false;
            this.txtMonMoneda.FormatoDecimal = true;
            this.txtMonMoneda.Location = new System.Drawing.Point(434, 226);
            this.txtMonMoneda.Name = "txtMonMoneda";
            this.txtMonMoneda.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonMoneda.nNumDecimales = 2;
            this.txtMonMoneda.nvalor = 0D;
            this.txtMonMoneda.Size = new System.Drawing.Size(124, 20);
            this.txtMonMoneda.TabIndex = 23;
            this.txtMonMoneda.Text = "0.00";
            // 
            // dtgMonedas
            // 
            this.dtgMonedas.AllowUserToAddRows = false;
            this.dtgMonedas.AllowUserToDeleteRows = false;
            this.dtgMonedas.AllowUserToResizeColumns = false;
            this.dtgMonedas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgMonedas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMonedas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgMonedas.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgMonedas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMonedas.Location = new System.Drawing.Point(285, 24);
            this.dtgMonedas.MultiSelect = false;
            this.dtgMonedas.Name = "dtgMonedas";
            this.dtgMonedas.ReadOnly = true;
            this.dtgMonedas.RowHeadersVisible = false;
            this.dtgMonedas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMonedas.Size = new System.Drawing.Size(273, 201);
            this.dtgMonedas.TabIndex = 1;
            this.dtgMonedas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMonedas_CellValueChanged);
            this.dtgMonedas.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgMonedas_EditingControlShowing);
            // 
            // txtMonBillete
            // 
            this.txtMonBillete.Enabled = false;
            this.txtMonBillete.FormatoDecimal = true;
            this.txtMonBillete.Location = new System.Drawing.Point(154, 226);
            this.txtMonBillete.Name = "txtMonBillete";
            this.txtMonBillete.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonBillete.nNumDecimales = 2;
            this.txtMonBillete.nvalor = 0D;
            this.txtMonBillete.Size = new System.Drawing.Size(124, 20);
            this.txtMonBillete.TabIndex = 25;
            this.txtMonBillete.Text = "0.00";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(42, 230);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(107, 13);
            this.lblBase6.TabIndex = 22;
            this.lblBase6.Text = "TOTAL BILLETES:";
            // 
            // dtgBilletes
            // 
            this.dtgBilletes.AllowUserToAddRows = false;
            this.dtgBilletes.AllowUserToDeleteRows = false;
            this.dtgBilletes.AllowUserToResizeColumns = false;
            this.dtgBilletes.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBilletes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgBilletes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBilletes.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgBilletes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBilletes.Location = new System.Drawing.Point(5, 24);
            this.dtgBilletes.MultiSelect = false;
            this.dtgBilletes.Name = "dtgBilletes";
            this.dtgBilletes.ReadOnly = true;
            this.dtgBilletes.RowHeadersVisible = false;
            this.dtgBilletes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBilletes.Size = new System.Drawing.Size(273, 201);
            this.dtgBilletes.TabIndex = 0;
            this.dtgBilletes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBilletes_CellValueChanged);
            this.dtgBilletes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBilletes_EditingControlShowing);
            // 
            // tabDolares
            // 
            this.tabDolares.Controls.Add(this.txtTotDolar);
            this.tabDolares.Controls.Add(this.lblBase7);
            this.tabDolares.Controls.Add(this.txtBillDol);
            this.tabDolares.Controls.Add(this.lblBase8);
            this.tabDolares.Controls.Add(this.dtgBillDolares);
            this.tabDolares.Location = new System.Drawing.Point(4, 22);
            this.tabDolares.Name = "tabDolares";
            this.tabDolares.Padding = new System.Windows.Forms.Padding(3);
            this.tabDolares.Size = new System.Drawing.Size(563, 285);
            this.tabDolares.TabIndex = 1;
            this.tabDolares.Text = "Billetaje en Dólares ($)";
            this.tabDolares.UseVisualStyleBackColor = true;
            // 
            // txtTotDolar
            // 
            this.txtTotDolar.Enabled = false;
            this.txtTotDolar.FormatoDecimal = true;
            this.txtTotDolar.Location = new System.Drawing.Point(301, 251);
            this.txtTotDolar.Name = "txtTotDolar";
            this.txtTotDolar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotDolar.nNumDecimales = 2;
            this.txtTotDolar.nvalor = 0D;
            this.txtTotDolar.Size = new System.Drawing.Size(113, 20);
            this.txtTotDolar.TabIndex = 32;
            this.txtTotDolar.Text = "0.00";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(162, 254);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(133, 13);
            this.lblBase7.TabIndex = 31;
            this.lblBase7.Text = "TOTAL BILLETAJE ($):";
            // 
            // txtBillDol
            // 
            this.txtBillDol.Enabled = false;
            this.txtBillDol.FormatoDecimal = true;
            this.txtBillDol.Location = new System.Drawing.Point(306, 215);
            this.txtBillDol.Name = "txtBillDol";
            this.txtBillDol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtBillDol.nNumDecimales = 2;
            this.txtBillDol.nvalor = 0D;
            this.txtBillDol.Size = new System.Drawing.Size(108, 20);
            this.txtBillDol.TabIndex = 30;
            this.txtBillDol.Text = "0.00";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(169, 218);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(107, 13);
            this.lblBase8.TabIndex = 29;
            this.lblBase8.Text = "TOTAL BILLETES:";
            // 
            // dtgBillDolares
            // 
            this.dtgBillDolares.AllowUserToAddRows = false;
            this.dtgBillDolares.AllowUserToDeleteRows = false;
            this.dtgBillDolares.AllowUserToResizeColumns = false;
            this.dtgBillDolares.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBillDolares.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgBillDolares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBillDolares.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtgBillDolares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBillDolares.Location = new System.Drawing.Point(97, 13);
            this.dtgBillDolares.MultiSelect = false;
            this.dtgBillDolares.Name = "dtgBillDolares";
            this.dtgBillDolares.ReadOnly = true;
            this.dtgBillDolares.RowHeadersVisible = false;
            this.dtgBillDolares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBillDolares.Size = new System.Drawing.Size(317, 201);
            this.dtgBillDolares.TabIndex = 0;
            this.dtgBillDolares.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBillDolares_CellValueChanged);
            this.dtgBillDolares.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBillDolares_EditingControlShowing);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(514, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(448, 406);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(94, 37);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(417, 20);
            this.txtNomUsu.TabIndex = 72;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 71;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(281, 13);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(42, 20);
            this.txtCodUsu.TabIndex = 70;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(230, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 69;
            this.lblBase2.Text = "Código:";
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Enabled = false;
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(94, 13);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaSis.TabIndex = 67;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 17);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 68;
            this.lblBase3.Text = "Fecha:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtUsuario);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.txtNomUsu);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.dtpFechaSis);
            this.grbBase3.Controls.Add(this.txtCodUsu);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Location = new System.Drawing.Point(5, -2);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(565, 63);
            this.grbBase3.TabIndex = 0;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(406, 13);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(102, 20);
            this.txtUsuario.TabIndex = 50;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(351, 20);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(55, 13);
            this.lblBase10.TabIndex = 49;
            this.lblBase10.Text = "Usuario:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(330, 406);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(389, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(271, 406);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cboTipResponsable
            // 
            this.cboTipResponsable.FormattingEnabled = true;
            this.cboTipResponsable.Location = new System.Drawing.Point(99, 66);
            this.cboTipResponsable.Name = "cboTipResponsable";
            this.cboTipResponsable.Size = new System.Drawing.Size(237, 21);
            this.cboTipResponsable.TabIndex = 1;
            this.cboTipResponsable.SelectedIndexChanged += new System.EventHandler(this.cboTipResponsable_SelectedIndexChanged);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(9, 69);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(84, 13);
            this.lblBase13.TabIndex = 79;
            this.lblBase13.Text = "Responsable:";
            // 
            // frmCorteFraccionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 481);
            this.Controls.Add(this.cboTipResponsable);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbcCorte);
            this.Name = "frmCorteFraccionario";
            this.Text = "Billetaje";
            this.Load += new System.EventHandler(this.frmCorteFraccionario_Load);
            this.Controls.SetChildIndex(this.tbcCorte, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.cboTipResponsable, 0);
            this.tbcCorte.ResumeLayout(false);
            this.tabSoles.ResumeLayout(false);
            this.tabSoles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonedas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBilletes)).EndInit();
            this.tabDolares.ResumeLayout(false);
            this.tabDolares.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBillDolares)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.tbcBase tbcCorte;
        private System.Windows.Forms.TabPage tabSoles;
        private System.Windows.Forms.TabPage tabDolares;
        private GEN.ControlesBase.dtgBase dtgMonedas;
        private GEN.ControlesBase.dtgBase dtgBilletes;
        private GEN.ControlesBase.txtNumRea txtMonTotal;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMonBillete;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMonMoneda;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtTotDolar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtBillDol;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtgBase dtgBillDolares;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase2;
        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboBase cboTipResponsable;
        private GEN.ControlesBase.lblBase lblBase13;
    }
}