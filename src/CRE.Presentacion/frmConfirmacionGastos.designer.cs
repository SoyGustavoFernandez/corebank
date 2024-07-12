namespace CRE.Presentacion
{
    partial class frmConfirmacionGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmacionGastos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtAtraso = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtCuoPend = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtTipoCredito = new GEN.ControlesBase.txtBase(this.components);
            this.txtSaldoCred = new GEN.ControlesBase.txtBase(this.components);
            this.txtCuotas = new GEN.ControlesBase.txtBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtgGastosCuenta = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMontoConvert = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.cboMonSentencia = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtMontoAceptado = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboJuez = new GEN.ControlesBase.cboJuez(this.components);
            this.cboJuzgado = new GEN.ControlesBase.cboJuzgado(this.components);
            this.dtpFecSentencia = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.ttpDetalle = new GEN.ControlesBase.ttpToolTip();
            this.txtSumAceptado = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSumGastos = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcTodosGastos = new GEN.ControlesBase.chcBase(this.components);
            this.dtgPlanPagos = new GEN.ControlesBase.dtgBase(this.components);
            this.chcTodasCuotas = new GEN.ControlesBase.chcBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosCuenta)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(782, 477);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(722, 477);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(851, 477);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Location = new System.Drawing.Point(11, 7);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(564, 100);
            this.conBusCuentaCli.TabIndex = 7;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtAtraso);
            this.grbBase2.Controls.Add(this.lblBase12);
            this.grbBase2.Controls.Add(this.txtCuoPend);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.txtTipoCredito);
            this.grbBase2.Controls.Add(this.txtSaldoCred);
            this.grbBase2.Controls.Add(this.txtCuotas);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Location = new System.Drawing.Point(588, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(323, 218);
            this.grbBase2.TabIndex = 8;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del crédito";
            // 
            // txtAtraso
            // 
            this.txtAtraso.BackColor = System.Drawing.SystemColors.Control;
            this.txtAtraso.Enabled = false;
            this.txtAtraso.Location = new System.Drawing.Point(114, 112);
            this.txtAtraso.Name = "txtAtraso";
            this.txtAtraso.Size = new System.Drawing.Size(122, 20);
            this.txtAtraso.TabIndex = 29;
            this.txtAtraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(62, 116);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(49, 13);
            this.lblBase12.TabIndex = 30;
            this.lblBase12.Text = "Atraso:";
            // 
            // txtCuoPend
            // 
            this.txtCuoPend.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuoPend.Enabled = false;
            this.txtCuoPend.Location = new System.Drawing.Point(114, 173);
            this.txtCuoPend.Name = "txtCuoPend";
            this.txtCuoPend.Size = new System.Drawing.Size(122, 20);
            this.txtCuoPend.TabIndex = 27;
            this.txtCuoPend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(33, 177);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(75, 13);
            this.lblBase11.TabIndex = 28;
            this.lblBase11.Text = "Cuo. Pend.:";
            // 
            // txtTipoCredito
            // 
            this.txtTipoCredito.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoCredito.Enabled = false;
            this.txtTipoCredito.Location = new System.Drawing.Point(114, 22);
            this.txtTipoCredito.Name = "txtTipoCredito";
            this.txtTipoCredito.Size = new System.Drawing.Size(189, 20);
            this.txtTipoCredito.TabIndex = 26;
            // 
            // txtSaldoCred
            // 
            this.txtSaldoCred.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldoCred.Enabled = false;
            this.txtSaldoCred.Location = new System.Drawing.Point(114, 82);
            this.txtSaldoCred.Name = "txtSaldoCred";
            this.txtSaldoCred.Size = new System.Drawing.Size(122, 20);
            this.txtSaldoCred.TabIndex = 20;
            this.txtSaldoCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCuotas
            // 
            this.txtCuotas.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuotas.Enabled = false;
            this.txtCuotas.Location = new System.Drawing.Point(114, 143);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(122, 20);
            this.txtCuotas.TabIndex = 21;
            this.txtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(114, 52);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(189, 21);
            this.cboMoneda.TabIndex = 19;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(52, 56);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(56, 13);
            this.lblBase10.TabIndex = 25;
            this.lblBase10.Text = "Moneda:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(56, 147);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(52, 13);
            this.lblBase9.TabIndex = 24;
            this.lblBase9.Text = "Cuotas:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 26);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(100, 13);
            this.lblBase7.TabIndex = 23;
            this.lblBase7.Text = "Tipo de Crédito:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(65, 86);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(46, 13);
            this.lblBase8.TabIndex = 22;
            this.lblBase8.Text = "Monto:";
            // 
            // dtgGastosCuenta
            // 
            this.dtgGastosCuenta.AllowUserToAddRows = false;
            this.dtgGastosCuenta.AllowUserToDeleteRows = false;
            this.dtgGastosCuenta.AllowUserToResizeColumns = false;
            this.dtgGastosCuenta.AllowUserToResizeRows = false;
            this.dtgGastosCuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGastosCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgGastosCuenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgGastosCuenta.Location = new System.Drawing.Point(12, 136);
            this.dtgGastosCuenta.MultiSelect = false;
            this.dtgGastosCuenta.Name = "dtgGastosCuenta";
            this.dtgGastosCuenta.ReadOnly = true;
            this.dtgGastosCuenta.RowHeadersVisible = false;
            this.dtgGastosCuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGastosCuenta.Size = new System.Drawing.Size(567, 150);
            this.dtgGastosCuenta.TabIndex = 9;
            this.dtgGastosCuenta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGastosCuenta_CellValueChanged);
            this.dtgGastosCuenta.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgGastosCuenta_CurrentCellDirtyStateChanged);
            this.dtgGastosCuenta.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgGastosCuenta_EditingControlShowing);
            this.dtgGastosCuenta.SelectionChanged += new System.EventHandler(this.dtgGastosCuenta_SelectionChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtMontoConvert);
            this.grbBase3.Controls.Add(this.lblBase14);
            this.grbBase3.Controls.Add(this.cboMonSentencia);
            this.grbBase3.Controls.Add(this.lblBase13);
            this.grbBase3.Controls.Add(this.txtMontoAceptado);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.cboJuez);
            this.grbBase3.Controls.Add(this.cboJuzgado);
            this.grbBase3.Controls.Add(this.dtpFecSentencia);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Location = new System.Drawing.Point(588, 236);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(323, 232);
            this.grbBase3.TabIndex = 11;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Detalle sentencia";
            // 
            // txtMontoConvert
            // 
            this.txtMontoConvert.Enabled = false;
            this.txtMontoConvert.FormatoDecimal = false;
            this.txtMontoConvert.Location = new System.Drawing.Point(126, 183);
            this.txtMontoConvert.Name = "txtMontoConvert";
            this.txtMontoConvert.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoConvert.nNumDecimales = 4;
            this.txtMontoConvert.nvalor = 0D;
            this.txtMontoConvert.Size = new System.Drawing.Size(110, 20);
            this.txtMontoConvert.TabIndex = 5;
            this.txtMontoConvert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(10, 187);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(113, 13);
            this.lblBase14.TabIndex = 17;
            this.lblBase14.Text = "Monto Convertido:";
            // 
            // cboMonSentencia
            // 
            this.cboMonSentencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonSentencia.FormattingEnabled = true;
            this.cboMonSentencia.Location = new System.Drawing.Point(126, 122);
            this.cboMonSentencia.Name = "cboMonSentencia";
            this.cboMonSentencia.Size = new System.Drawing.Size(182, 21);
            this.cboMonSentencia.TabIndex = 3;
            this.cboMonSentencia.SelectedIndexChanged += new System.EventHandler(this.cboMonSentencia_SelectedIndexChanged);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(67, 126);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(56, 13);
            this.lblBase13.TabIndex = 15;
            this.lblBase13.Text = "Moneda:";
            // 
            // txtMontoAceptado
            // 
            this.txtMontoAceptado.FormatoDecimal = false;
            this.txtMontoAceptado.Location = new System.Drawing.Point(126, 153);
            this.txtMontoAceptado.Name = "txtMontoAceptado";
            this.txtMontoAceptado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoAceptado.nNumDecimales = 4;
            this.txtMontoAceptado.nvalor = 0D;
            this.txtMontoAceptado.Size = new System.Drawing.Size(110, 20);
            this.txtMontoAceptado.TabIndex = 4;
            this.txtMontoAceptado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoAceptado.Enter += new System.EventHandler(this.txtMontoAceptado_Enter);
            this.txtMontoAceptado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoAceptado_KeyPress);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(20, 157);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(103, 13);
            this.lblBase6.TabIndex = 14;
            this.lblBase6.Text = "Monto Aceptado:";
            // 
            // cboJuez
            // 
            this.cboJuez.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJuez.FormattingEnabled = true;
            this.cboJuez.Location = new System.Drawing.Point(126, 91);
            this.cboJuez.Name = "cboJuez";
            this.cboJuez.Size = new System.Drawing.Size(182, 21);
            this.cboJuez.TabIndex = 2;
            // 
            // cboJuzgado
            // 
            this.cboJuzgado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJuzgado.FormattingEnabled = true;
            this.cboJuzgado.Location = new System.Drawing.Point(126, 60);
            this.cboJuzgado.Name = "cboJuzgado";
            this.cboJuzgado.Size = new System.Drawing.Size(182, 21);
            this.cboJuzgado.TabIndex = 1;
            // 
            // dtpFecSentencia
            // 
            this.dtpFecSentencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecSentencia.Location = new System.Drawing.Point(126, 30);
            this.dtpFecSentencia.Name = "dtpFecSentencia";
            this.dtpFecSentencia.Size = new System.Drawing.Size(110, 20);
            this.dtpFecSentencia.TabIndex = 0;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(86, 95);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(37, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Juez:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(65, 64);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(58, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Juzgado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 34);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(95, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Fec. Sentencia:";
            // 
            // ttpDetalle
            // 
            this.ttpDetalle.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpDetalle.ToolTipTitle = "Detalle del gasto:";
            // 
            // txtSumAceptado
            // 
            this.txtSumAceptado.Enabled = false;
            this.txtSumAceptado.FormatoDecimal = false;
            this.txtSumAceptado.Location = new System.Drawing.Point(521, 289);
            this.txtSumAceptado.Name = "txtSumAceptado";
            this.txtSumAceptado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSumAceptado.nNumDecimales = 4;
            this.txtSumAceptado.nvalor = 0D;
            this.txtSumAceptado.Size = new System.Drawing.Size(58, 20);
            this.txtSumAceptado.TabIndex = 14;
            this.txtSumAceptado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSumGastos
            // 
            this.txtSumGastos.Enabled = false;
            this.txtSumGastos.FormatoDecimal = false;
            this.txtSumGastos.Location = new System.Drawing.Point(463, 289);
            this.txtSumGastos.Name = "txtSumGastos";
            this.txtSumGastos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSumGastos.nNumDecimales = 4;
            this.txtSumGastos.nvalor = 0D;
            this.txtSumGastos.Size = new System.Drawing.Size(58, 20);
            this.txtSumGastos.TabIndex = 15;
            this.txtSumGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chcTodosGastos
            // 
            this.chcTodosGastos.AutoSize = true;
            this.chcTodosGastos.Location = new System.Drawing.Point(12, 113);
            this.chcTodosGastos.Name = "chcTodosGastos";
            this.chcTodosGastos.Size = new System.Drawing.Size(161, 17);
            this.chcTodosGastos.TabIndex = 16;
            this.chcTodosGastos.Text = "Seleccionar todos los gastos";
            this.chcTodosGastos.UseVisualStyleBackColor = true;
            this.chcTodosGastos.CheckedChanged += new System.EventHandler(this.chcTodosGastos_CheckedChanged);
            // 
            // dtgPlanPagos
            // 
            this.dtgPlanPagos.AllowUserToAddRows = false;
            this.dtgPlanPagos.AllowUserToDeleteRows = false;
            this.dtgPlanPagos.AllowUserToResizeColumns = false;
            this.dtgPlanPagos.AllowUserToResizeRows = false;
            this.dtgPlanPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPlanPagos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgPlanPagos.Location = new System.Drawing.Point(13, 331);
            this.dtgPlanPagos.MultiSelect = false;
            this.dtgPlanPagos.Name = "dtgPlanPagos";
            this.dtgPlanPagos.ReadOnly = true;
            this.dtgPlanPagos.RowHeadersVisible = false;
            this.dtgPlanPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanPagos.Size = new System.Drawing.Size(567, 174);
            this.dtgPlanPagos.TabIndex = 17;
            this.dtgPlanPagos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgPlanPagos_CurrentCellDirtyStateChanged);
            // 
            // chcTodasCuotas
            // 
            this.chcTodasCuotas.AutoSize = true;
            this.chcTodasCuotas.Location = new System.Drawing.Point(12, 308);
            this.chcTodasCuotas.Name = "chcTodasCuotas";
            this.chcTodasCuotas.Size = new System.Drawing.Size(147, 17);
            this.chcTodasCuotas.TabIndex = 18;
            this.chcTodasCuotas.Text = "Aplicar a todas las cuotas";
            this.chcTodasCuotas.UseVisualStyleBackColor = true;
            this.chcTodasCuotas.CheckedChanged += new System.EventHandler(this.chcTodasCuotas_CheckedChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(662, 477);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 19;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmConfirmacionGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 552);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.chcTodasCuotas);
            this.Controls.Add(this.dtgPlanPagos);
            this.Controls.Add(this.chcTodosGastos);
            this.Controls.Add(this.txtSumGastos);
            this.Controls.Add(this.txtSumAceptado);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.dtgGastosCuenta);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmConfirmacionGastos";
            this.Text = "Confirmación de cobranza de gastos";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.dtgGastosCuenta, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.txtSumAceptado, 0);
            this.Controls.SetChildIndex(this.txtSumGastos, 0);
            this.Controls.SetChildIndex(this.chcTodosGastos, 0);
            this.Controls.SetChildIndex(this.dtgPlanPagos, 0);
            this.Controls.SetChildIndex(this.chcTodasCuotas, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosCuenta)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtAtraso;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtCuoPend;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtTipoCredito;
        private GEN.ControlesBase.txtBase txtSaldoCred;
        private GEN.ControlesBase.txtBase txtCuotas;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtgBase dtgGastosCuenta;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtNumRea txtMontoAceptado;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboJuez cboJuez;
        private GEN.ControlesBase.cboJuzgado cboJuzgado;
        private GEN.ControlesBase.dtpCorto dtpFecSentencia;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtMontoConvert;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.cboMoneda cboMonSentencia;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.ttpToolTip ttpDetalle;
        private GEN.ControlesBase.txtNumRea txtSumAceptado;
        private GEN.ControlesBase.txtNumRea txtSumGastos;
        private GEN.ControlesBase.chcBase chcTodosGastos;
        private GEN.ControlesBase.dtgBase dtgPlanPagos;
        private GEN.ControlesBase.chcBase chcTodasCuotas;
        private GEN.BotonesBase.btnNuevo btnNuevo;
    }
}

