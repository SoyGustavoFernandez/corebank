namespace CNT.Presentacion
{
    partial class frmAsientoManual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsientoManual));
            this.dtgAsiento = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCtaCtb = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipGen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idagencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lEditable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idItemAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoAsiento = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtFecSistema = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNumVoucher = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotDebeSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotHabeSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtGlosa = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtTotHabeDol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotDebeDol = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotHabeDolConvert = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotDebeDolConvert = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtRP = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtDiferencia = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.chcAsiReexp = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsiento)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgAsiento
            // 
            this.dtgAsiento.AllowUserToAddRows = false;
            this.dtgAsiento.AllowUserToDeleteRows = false;
            this.dtgAsiento.AllowUserToResizeColumns = false;
            this.dtgAsiento.AllowUserToResizeRows = false;
            this.dtgAsiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAsiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAsiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnCtaCtb,
            this.cCuentaContable,
            this.cDescripcion,
            this.cTipGen,
            this.nDebe,
            this.nHaber,
            this.idAsiento,
            this.dFecha,
            this.idagencia,
            this.cGlosa,
            this.lEditable,
            this.idItemAsiento,
            this.idMoneda,
            this.idUsuario,
            this.cNombre});
            this.dtgAsiento.Location = new System.Drawing.Point(15, 87);
            this.dtgAsiento.MultiSelect = false;
            this.dtgAsiento.Name = "dtgAsiento";
            this.dtgAsiento.ReadOnly = true;
            this.dtgAsiento.RowHeadersVisible = false;
            this.dtgAsiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAsiento.Size = new System.Drawing.Size(617, 196);
            this.dtgAsiento.TabIndex = 4;
            this.dtgAsiento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAsiento_CellClick);
            this.dtgAsiento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAsiento_CellEnter);
            this.dtgAsiento.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAsiento_CellLeave);
            this.dtgAsiento.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAsiento_CellValueChanged);
            this.dtgAsiento.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgAsiento_CurrentCellDirtyStateChanged);
            this.dtgAsiento.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgAsiento_DataError);
            this.dtgAsiento.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgAsiento_EditingControlShowing);
            this.dtgAsiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgAsiento_KeyDown);
            // 
            // btnCtaCtb
            // 
            this.btnCtaCtb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnCtaCtb.FillWeight = 20F;
            this.btnCtaCtb.Frozen = true;
            this.btnCtaCtb.HeaderText = "...";
            this.btnCtaCtb.Name = "btnCtaCtb";
            this.btnCtaCtb.ReadOnly = true;
            this.btnCtaCtb.Width = 20;
            // 
            // cCuentaContable
            // 
            this.cCuentaContable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cCuentaContable.DataPropertyName = "cCuentaContable";
            this.cCuentaContable.FillWeight = 12.59632F;
            this.cCuentaContable.Frozen = true;
            this.cCuentaContable.HeaderText = "Cuenta";
            this.cCuentaContable.MinimumWidth = 80;
            this.cCuentaContable.Name = "cCuentaContable";
            this.cCuentaContable.ReadOnly = true;
            this.cCuentaContable.Width = 80;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.FillWeight = 394.1321F;
            this.cDescripcion.HeaderText = "Descripcion";
            this.cDescripcion.MinimumWidth = 190;
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            this.cDescripcion.Width = 190;
            // 
            // cTipGen
            // 
            this.cTipGen.DataPropertyName = "cTipGen";
            this.cTipGen.FillWeight = 12.41891F;
            this.cTipGen.HeaderText = "Tipo";
            this.cTipGen.MinimumWidth = 35;
            this.cTipGen.Name = "cTipGen";
            this.cTipGen.ReadOnly = true;
            // 
            // nDebe
            // 
            this.nDebe.DataPropertyName = "nDebe";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.nDebe.DefaultCellStyle = dataGridViewCellStyle3;
            this.nDebe.FillWeight = 12.59632F;
            this.nDebe.HeaderText = "Debe";
            this.nDebe.MinimumWidth = 80;
            this.nDebe.Name = "nDebe";
            this.nDebe.ReadOnly = true;
            // 
            // nHaber
            // 
            this.nHaber.DataPropertyName = "nHaber";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.nHaber.DefaultCellStyle = dataGridViewCellStyle4;
            this.nHaber.FillWeight = 12.59632F;
            this.nHaber.HeaderText = "Haber";
            this.nHaber.MinimumWidth = 80;
            this.nHaber.Name = "nHaber";
            this.nHaber.ReadOnly = true;
            // 
            // idAsiento
            // 
            this.idAsiento.DataPropertyName = "idAsiento";
            this.idAsiento.HeaderText = "idAsiento";
            this.idAsiento.Name = "idAsiento";
            this.idAsiento.ReadOnly = true;
            this.idAsiento.Visible = false;
            // 
            // dFecha
            // 
            this.dFecha.DataPropertyName = "dFecha";
            this.dFecha.HeaderText = "dFecha";
            this.dFecha.Name = "dFecha";
            this.dFecha.ReadOnly = true;
            this.dFecha.Visible = false;
            // 
            // idagencia
            // 
            this.idagencia.DataPropertyName = "idagencia";
            this.idagencia.HeaderText = "idagencia";
            this.idagencia.Name = "idagencia";
            this.idagencia.ReadOnly = true;
            this.idagencia.Visible = false;
            // 
            // cGlosa
            // 
            this.cGlosa.DataPropertyName = "cGlosa";
            this.cGlosa.HeaderText = "cGlosa";
            this.cGlosa.Name = "cGlosa";
            this.cGlosa.ReadOnly = true;
            this.cGlosa.Visible = false;
            // 
            // lEditable
            // 
            this.lEditable.DataPropertyName = "lEditable";
            this.lEditable.HeaderText = "lEditable";
            this.lEditable.Name = "lEditable";
            this.lEditable.ReadOnly = true;
            this.lEditable.Visible = false;
            // 
            // idItemAsiento
            // 
            this.idItemAsiento.DataPropertyName = "idItemAsiento";
            this.idItemAsiento.HeaderText = "idItemAsiento";
            this.idItemAsiento.Name = "idItemAsiento";
            this.idItemAsiento.ReadOnly = true;
            this.idItemAsiento.Visible = false;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.HeaderText = "Moneda";
            this.idMoneda.MinimumWidth = 80;
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.ReadOnly = true;
            this.idMoneda.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idMoneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "cNombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Visible = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(430, 44);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(91, 13);
            this.lblBase1.TabIndex = 5;
            this.lblBase1.Text = "Fecha Asiento:";
            // 
            // cboTipoAsiento
            // 
            this.cboTipoAsiento.Enabled = false;
            this.cboTipoAsiento.FormattingEnabled = true;
            this.cboTipoAsiento.Location = new System.Drawing.Point(95, 40);
            this.cboTipoAsiento.Name = "cboTipoAsiento";
            this.cboTipoAsiento.Size = new System.Drawing.Size(333, 21);
            this.cboTipoAsiento.TabIndex = 7;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 44);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(82, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Tipo Asiento:";
            // 
            // dtFecSistema
            // 
            this.dtFecSistema.Enabled = false;
            this.dtFecSistema.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecSistema.Location = new System.Drawing.Point(527, 41);
            this.dtFecSistema.Name = "dtFecSistema";
            this.dtFecSistema.Size = new System.Drawing.Size(105, 20);
            this.dtFecSistema.TabIndex = 13;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(13, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(72, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "N° Asiento:";
            // 
            // txtNumVoucher
            // 
            this.txtNumVoucher.Enabled = false;
            this.txtNumVoucher.FormatoDecimal = false;
            this.txtNumVoucher.Location = new System.Drawing.Point(95, 14);
            this.txtNumVoucher.MaxLength = 9;
            this.txtNumVoucher.Name = "txtNumVoucher";
            this.txtNumVoucher.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumVoucher.nNumDecimales = 0;
            this.txtNumVoucher.nvalor = 0D;
            this.txtNumVoucher.Size = new System.Drawing.Size(100, 20);
            this.txtNumVoucher.TabIndex = 15;
            this.txtNumVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumVoucher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumVoucher_KeyPress);
            // 
            // txtTotDebeSol
            // 
            this.txtTotDebeSol.Enabled = false;
            this.txtTotDebeSol.FormatoDecimal = true;
            this.txtTotDebeSol.Location = new System.Drawing.Point(471, 285);
            this.txtTotDebeSol.Name = "txtTotDebeSol";
            this.txtTotDebeSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotDebeSol.nNumDecimales = 2;
            this.txtTotDebeSol.nvalor = 0D;
            this.txtTotDebeSol.Size = new System.Drawing.Size(80, 20);
            this.txtTotDebeSol.TabIndex = 17;
            this.txtTotDebeSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotHabeSol
            // 
            this.txtTotHabeSol.Enabled = false;
            this.txtTotHabeSol.FormatoDecimal = true;
            this.txtTotHabeSol.Location = new System.Drawing.Point(551, 285);
            this.txtTotHabeSol.Name = "txtTotHabeSol";
            this.txtTotHabeSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotHabeSol.nNumDecimales = 2;
            this.txtTotHabeSol.nvalor = 0D;
            this.txtTotHabeSol.Size = new System.Drawing.Size(80, 20);
            this.txtTotHabeSol.TabIndex = 18;
            this.txtTotHabeSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.Enabled = false;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(273, 13);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(359, 21);
            this.cboAgencias1.TabIndex = 24;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(210, 17);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 25;
            this.lblBase5.Text = "Agencia:";
            // 
            // txtGlosa
            // 
            this.txtGlosa.Enabled = false;
            this.txtGlosa.Location = new System.Drawing.Point(14, 346);
            this.txtGlosa.Multiline = true;
            this.txtGlosa.Name = "txtGlosa";
            this.txtGlosa.Size = new System.Drawing.Size(617, 68);
            this.txtGlosa.TabIndex = 27;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 329);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(44, 13);
            this.lblBase6.TabIndex = 28;
            this.lblBase6.Text = "Glosa:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 17);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(88, 13);
            this.lblBase7.TabIndex = 32;
            this.lblBase7.Text = "A: Automático";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 36);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(65, 13);
            this.lblBase8.TabIndex = 33;
            this.lblBase8.Text = "M: Manual";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 416);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(106, 53);
            this.grbBase1.TabIndex = 34;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Tipo Generación";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(344, 286);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(74, 13);
            this.lblBase9.TabIndex = 35;
            this.lblBase9.Text = "Total Soles:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(344, 307);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(87, 13);
            this.lblBase10.TabIndex = 36;
            this.lblBase10.Text = "Total Dolares:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(344, 326);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(129, 13);
            this.lblBase11.TabIndex = 37;
            this.lblBase11.Text = "Total Dol Convertido:";
            // 
            // txtTotHabeDol
            // 
            this.txtTotHabeDol.Enabled = false;
            this.txtTotHabeDol.FormatoDecimal = true;
            this.txtTotHabeDol.Location = new System.Drawing.Point(551, 305);
            this.txtTotHabeDol.Name = "txtTotHabeDol";
            this.txtTotHabeDol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotHabeDol.nNumDecimales = 2;
            this.txtTotHabeDol.nvalor = 0D;
            this.txtTotHabeDol.Size = new System.Drawing.Size(80, 20);
            this.txtTotHabeDol.TabIndex = 39;
            this.txtTotHabeDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotDebeDol
            // 
            this.txtTotDebeDol.Enabled = false;
            this.txtTotDebeDol.FormatoDecimal = true;
            this.txtTotDebeDol.Location = new System.Drawing.Point(471, 305);
            this.txtTotDebeDol.Name = "txtTotDebeDol";
            this.txtTotDebeDol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotDebeDol.nNumDecimales = 2;
            this.txtTotDebeDol.nvalor = 0D;
            this.txtTotDebeDol.Size = new System.Drawing.Size(80, 20);
            this.txtTotDebeDol.TabIndex = 38;
            this.txtTotDebeDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotHabeDolConvert
            // 
            this.txtTotHabeDolConvert.Enabled = false;
            this.txtTotHabeDolConvert.FormatoDecimal = true;
            this.txtTotHabeDolConvert.Location = new System.Drawing.Point(551, 323);
            this.txtTotHabeDolConvert.Name = "txtTotHabeDolConvert";
            this.txtTotHabeDolConvert.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotHabeDolConvert.nNumDecimales = 2;
            this.txtTotHabeDolConvert.nvalor = 0D;
            this.txtTotHabeDolConvert.Size = new System.Drawing.Size(80, 20);
            this.txtTotHabeDolConvert.TabIndex = 41;
            this.txtTotHabeDolConvert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotDebeDolConvert
            // 
            this.txtTotDebeDolConvert.Enabled = false;
            this.txtTotDebeDolConvert.FormatoDecimal = true;
            this.txtTotDebeDolConvert.Location = new System.Drawing.Point(471, 323);
            this.txtTotDebeDolConvert.Name = "txtTotDebeDolConvert";
            this.txtTotDebeDolConvert.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotDebeDolConvert.nNumDecimales = 2;
            this.txtTotDebeDolConvert.nvalor = 0D;
            this.txtTotDebeDolConvert.Size = new System.Drawing.Size(80, 20);
            this.txtTotDebeDolConvert.TabIndex = 40;
            this.txtTotDebeDolConvert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(211, 419);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 26;
            this.btnImprimir1.Text = "&Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click_1);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(571, 419);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 22;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Enabled = false;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(638, 121);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 31;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Enabled = false;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(638, 87);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 30;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(451, 419);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 16;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(331, 419);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(391, 419);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 11;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(511, 419);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(55, 13);
            this.lblBase2.TabIndex = 42;
            this.lblBase2.Text = "Usuario:";
            // 
            // txtRP
            // 
            this.txtRP.Enabled = false;
            this.txtRP.Location = new System.Drawing.Point(95, 64);
            this.txtRP.Name = "txtRP";
            this.txtRP.Size = new System.Drawing.Size(333, 20);
            this.txtRP.TabIndex = 43;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(19, 290);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(102, 13);
            this.lblBase12.TabIndex = 45;
            this.lblBase12.Text = "Diferencia(D-H):";
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.Enabled = false;
            this.txtDiferencia.FormatoDecimal = true;
            this.txtDiferencia.Location = new System.Drawing.Point(123, 286);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiferencia.nNumDecimales = 2;
            this.txtDiferencia.nvalor = 0D;
            this.txtDiferencia.Size = new System.Drawing.Size(80, 20);
            this.txtDiferencia.TabIndex = 44;
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(271, 419);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 46;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // chcAsiReexp
            // 
            this.chcAsiReexp.AutoSize = true;
            this.chcAsiReexp.Enabled = false;
            this.chcAsiReexp.ForeColor = System.Drawing.Color.Navy;
            this.chcAsiReexp.Location = new System.Drawing.Point(434, 66);
            this.chcAsiReexp.Name = "chcAsiReexp";
            this.chcAsiReexp.Size = new System.Drawing.Size(176, 17);
            this.chcAsiReexp.TabIndex = 47;
            this.chcAsiReexp.Text = "Registrar asientos reexpresados";
            this.chcAsiReexp.UseVisualStyleBackColor = true;
            // 
            // frmAsientoManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 500);
            this.Controls.Add(this.chcAsiReexp);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.txtDiferencia);
            this.Controls.Add(this.txtRP);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtTotHabeDolConvert);
            this.Controls.Add(this.txtTotDebeDolConvert);
            this.Controls.Add(this.txtTotHabeDol);
            this.Controls.Add(this.txtTotDebeDol);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtGlosa);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboAgencias1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnMiniQuitar1);
            this.Controls.Add(this.btnMiniAgregar1);
            this.Controls.Add(this.txtTotHabeSol);
            this.Controls.Add(this.txtTotDebeSol);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.txtNumVoucher);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtFecSistema);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboTipoAsiento);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgAsiento);
            this.Controls.Add(this.lblBase11);
            this.Name = "frmAsientoManual";
            this.Text = "Registro Manual de Asientos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAsientoManual_FormClosed);
            this.Load += new System.EventHandler(this.frmAsientoManual_Load);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.dtgAsiento, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoAsiento, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.dtFecSistema, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtNumVoucher, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.txtTotDebeSol, 0);
            this.Controls.SetChildIndex(this.txtTotHabeSol, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar1, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.cboAgencias1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.txtGlosa, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.txtTotDebeDol, 0);
            this.Controls.SetChildIndex(this.txtTotHabeDol, 0);
            this.Controls.SetChildIndex(this.txtTotDebeDolConvert, 0);
            this.Controls.SetChildIndex(this.txtTotHabeDolConvert, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtRP, 0);
            this.Controls.SetChildIndex(this.txtDiferencia, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.chcAsiReexp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsiento)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgAsiento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboTipoAsiento;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.dtpCorto dtFecSistema;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtNumVoucher;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtNumRea txtTotDebeSol;
        private GEN.ControlesBase.txtNumRea txtTotHabeSol;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.txtBase txtGlosa;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtTotHabeDol;
        private GEN.ControlesBase.txtNumRea txtTotDebeDol;
        private GEN.ControlesBase.txtNumRea txtTotHabeDolConvert;
        private GEN.ControlesBase.txtNumRea txtTotDebeDolConvert;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtRP;
        private System.Windows.Forms.DataGridViewButtonColumn btnCtaCtb;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn nHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idagencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGlosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn lEditable;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemAsiento;
        private System.Windows.Forms.DataGridViewComboBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtNumRea txtDiferencia;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.ControlesBase.chcBase chcAsiReexp;
    }
}