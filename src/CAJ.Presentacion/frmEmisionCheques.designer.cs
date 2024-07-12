namespace CAJ.Presentacion
{
    partial class frmEmisionCheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmisionCheques));
            this.grbDatosCuenta = new GEN.ControlesBase.grbBase(this.components);
            this.txtSalCont = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSalDisp = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuentaBco = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtTotMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgTalonarios = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgCheques = new GEN.ControlesBase.dtgBase(this.components);
            this.btnBuscarCuenta = new GEN.BotonesBase.btnBusqueda();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.lblNroCuenta = new GEN.ControlesBase.lblBase();
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.grbDatosEmision = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblCodigo = new GEN.ControlesBase.lblBase();
            this.txtCodigo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.chcAnular = new GEN.ControlesBase.chcBase(this.components);
            this.dtpFechaEmision = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaEmision = new GEN.ControlesBase.lblBase();
            this.chcVerificarCliente = new GEN.ControlesBase.chcBase(this.components);
            this.txtDescrMot = new GEN.ControlesBase.txtBase(this.components);
            this.lblDescripcion = new GEN.ControlesBase.lblBase();
            this.cboMotOperacionBco = new GEN.ControlesBase.cboMotOperacionBco(this.components);
            this.lblMotivo = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.lblDatosBeneficiario = new GEN.ControlesBase.lblBase();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtNroCheque = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lbNroCheque = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbDatosCuenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTalonarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCheques)).BeginInit();
            this.grbDatosEmision.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosCuenta
            // 
            this.grbDatosCuenta.Controls.Add(this.txtSalCont);
            this.grbDatosCuenta.Controls.Add(this.txtSalDisp);
            this.grbDatosCuenta.Controls.Add(this.lblBase4);
            this.grbDatosCuenta.Controls.Add(this.lblBase3);
            this.grbDatosCuenta.Controls.Add(this.cboTipoCuentaBco);
            this.grbDatosCuenta.Controls.Add(this.lblBase2);
            this.grbDatosCuenta.Controls.Add(this.txtTotMonto);
            this.grbDatosCuenta.Controls.Add(this.lblBase1);
            this.grbDatosCuenta.Controls.Add(this.dtgTalonarios);
            this.grbDatosCuenta.Controls.Add(this.dtgCheques);
            this.grbDatosCuenta.Controls.Add(this.btnBuscarCuenta);
            this.grbDatosCuenta.Controls.Add(this.cboMoneda);
            this.grbDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.cboEntidad);
            this.grbDatosCuenta.Controls.Add(this.lblMoneda);
            this.grbDatosCuenta.Controls.Add(this.lblNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblEntidad);
            this.grbDatosCuenta.Location = new System.Drawing.Point(13, 12);
            this.grbDatosCuenta.Name = "grbDatosCuenta";
            this.grbDatosCuenta.Size = new System.Drawing.Size(649, 264);
            this.grbDatosCuenta.TabIndex = 2;
            this.grbDatosCuenta.TabStop = false;
            this.grbDatosCuenta.Text = "Datos Cuenta";
            // 
            // txtSalCont
            // 
            this.txtSalCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalCont.FormatoDecimal = false;
            this.txtSalCont.Location = new System.Drawing.Point(457, 42);
            this.txtSalCont.Name = "txtSalCont";
            this.txtSalCont.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSalCont.nNumDecimales = 2;
            this.txtSalCont.nvalor = 0D;
            this.txtSalCont.ReadOnly = true;
            this.txtSalCont.Size = new System.Drawing.Size(100, 20);
            this.txtSalCont.TabIndex = 609;
            this.txtSalCont.Text = "0.00";
            this.txtSalCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalDisp
            // 
            this.txtSalDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalDisp.FormatoDecimal = false;
            this.txtSalDisp.Location = new System.Drawing.Point(457, 20);
            this.txtSalDisp.Name = "txtSalDisp";
            this.txtSalDisp.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSalDisp.nNumDecimales = 2;
            this.txtSalDisp.nvalor = 0D;
            this.txtSalDisp.ReadOnly = true;
            this.txtSalDisp.Size = new System.Drawing.Size(100, 20);
            this.txtSalDisp.TabIndex = 608;
            this.txtSalDisp.Text = "0.00";
            this.txtSalDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(365, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(79, 13);
            this.lblBase4.TabIndex = 607;
            this.lblBase4.Text = "S. Contable:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(365, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(87, 13);
            this.lblBase3.TabIndex = 606;
            this.lblBase3.Text = "S. Disponible:";
            // 
            // cboTipoCuentaBco
            // 
            this.cboTipoCuentaBco.Enabled = false;
            this.cboTipoCuentaBco.FormattingEnabled = true;
            this.cboTipoCuentaBco.Location = new System.Drawing.Point(98, 64);
            this.cboTipoCuentaBco.Name = "cboTipoCuentaBco";
            this.cboTipoCuentaBco.Size = new System.Drawing.Size(230, 21);
            this.cboTipoCuentaBco.TabIndex = 605;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(81, 13);
            this.lblBase2.TabIndex = 604;
            this.lblBase2.Text = "Tipo Cuenta:";
            // 
            // txtTotMonto
            // 
            this.txtTotMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotMonto.FormatoDecimal = true;
            this.txtTotMonto.Location = new System.Drawing.Point(472, 237);
            this.txtTotMonto.Name = "txtTotMonto";
            this.txtTotMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotMonto.nNumDecimales = 2;
            this.txtTotMonto.nvalor = 0D;
            this.txtTotMonto.ReadOnly = true;
            this.txtTotMonto.Size = new System.Drawing.Size(69, 20);
            this.txtTotMonto.TabIndex = 603;
            this.txtTotMonto.Text = "00.00";
            this.txtTotMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(417, 240);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 602;
            this.lblBase1.Text = "TOTAL:";
            // 
            // dtgTalonarios
            // 
            this.dtgTalonarios.AllowUserToAddRows = false;
            this.dtgTalonarios.AllowUserToDeleteRows = false;
            this.dtgTalonarios.AllowUserToResizeColumns = false;
            this.dtgTalonarios.AllowUserToResizeRows = false;
            this.dtgTalonarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTalonarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTalonarios.Location = new System.Drawing.Point(14, 115);
            this.dtgTalonarios.MultiSelect = false;
            this.dtgTalonarios.Name = "dtgTalonarios";
            this.dtgTalonarios.ReadOnly = true;
            this.dtgTalonarios.RowHeadersVisible = false;
            this.dtgTalonarios.RowTemplate.Height = 18;
            this.dtgTalonarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTalonarios.Size = new System.Drawing.Size(229, 116);
            this.dtgTalonarios.TabIndex = 601;
            this.dtgTalonarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTalonarios_CellClick);
            this.dtgTalonarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgTalonarios_KeyDown);
            this.dtgTalonarios.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgTalonarios_KeyUp);
            // 
            // dtgCheques
            // 
            this.dtgCheques.AllowUserToAddRows = false;
            this.dtgCheques.AllowUserToDeleteRows = false;
            this.dtgCheques.AllowUserToResizeColumns = false;
            this.dtgCheques.AllowUserToResizeRows = false;
            this.dtgCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCheques.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCheques.Location = new System.Drawing.Point(249, 115);
            this.dtgCheques.MultiSelect = false;
            this.dtgCheques.Name = "dtgCheques";
            this.dtgCheques.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCheques.RowHeadersVisible = false;
            this.dtgCheques.RowTemplate.Height = 18;
            this.dtgCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCheques.Size = new System.Drawing.Size(394, 116);
            this.dtgCheques.TabIndex = 2;
            this.dtgCheques.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCheques_CellClick);
            this.dtgCheques.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgCheques_KeyDown);
            this.dtgCheques.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgCheques_KeyUp);
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.BackgroundImage")));
            this.btnBuscarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(573, 20);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarCuenta.TabIndex = 1;
            this.btnBuscarCuenta.Text = "&Buscar";
            this.btnBuscarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(98, 87);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 332;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(98, 42);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(230, 20);
            this.txtNroCuenta.TabIndex = 300;
            // 
            // cboEntidad
            // 
            this.cboEntidad.Enabled = false;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.ItemHeight = 13;
            this.cboEntidad.Location = new System.Drawing.Point(98, 19);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(230, 21);
            this.cboEntidad.TabIndex = 600;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(14, 89);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 2;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblNroCuenta
            // 
            this.lblNroCuenta.AutoSize = true;
            this.lblNroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCuenta.Location = new System.Drawing.Point(14, 45);
            this.lblNroCuenta.Name = "lblNroCuenta";
            this.lblNroCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblNroCuenta.TabIndex = 1;
            this.lblNroCuenta.Text = "Nro. Cuenta:";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(14, 23);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 0;
            this.lblEntidad.Text = "Entidad:";
            // 
            // grbDatosEmision
            // 
            this.grbDatosEmision.Controls.Add(this.grbBase4);
            this.grbDatosEmision.Controls.Add(this.chcAnular);
            this.grbDatosEmision.Controls.Add(this.dtpFechaEmision);
            this.grbDatosEmision.Controls.Add(this.lblFechaEmision);
            this.grbDatosEmision.Controls.Add(this.chcVerificarCliente);
            this.grbDatosEmision.Controls.Add(this.txtDescrMot);
            this.grbDatosEmision.Controls.Add(this.lblDescripcion);
            this.grbDatosEmision.Controls.Add(this.cboMotOperacionBco);
            this.grbDatosEmision.Controls.Add(this.lblMotivo);
            this.grbDatosEmision.Controls.Add(this.txtMonto);
            this.grbDatosEmision.Controls.Add(this.lblMonto);
            this.grbDatosEmision.Controls.Add(this.lblDatosBeneficiario);
            this.grbDatosEmision.Controls.Add(this.conBusCli);
            this.grbDatosEmision.Controls.Add(this.txtNroCheque);
            this.grbDatosEmision.Controls.Add(this.lbNroCheque);
            this.grbDatosEmision.Location = new System.Drawing.Point(13, 282);
            this.grbDatosEmision.Name = "grbDatosEmision";
            this.grbDatosEmision.Size = new System.Drawing.Size(650, 299);
            this.grbDatosEmision.TabIndex = 3;
            this.grbDatosEmision.TabStop = false;
            this.grbDatosEmision.Text = "Datos Emisión";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.btnBusqueda);
            this.grbBase4.Controls.Add(this.lblCodigo);
            this.grbBase4.Controls.Add(this.txtCodigo);
            this.grbBase4.Location = new System.Drawing.Point(411, 38);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(231, 45);
            this.grbBase4.TabIndex = 20;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Busca Comprobante";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(185, 13);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(36, 28);
            this.btnBusqueda.TabIndex = 17;
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCodigo.ForeColor = System.Drawing.Color.Navy;
            this.lblCodigo.Location = new System.Drawing.Point(6, 20);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 13);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Codigo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(74, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(105, 20);
            this.txtCodigo.TabIndex = 14;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // chcAnular
            // 
            this.chcAnular.AutoSize = true;
            this.chcAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcAnular.ForeColor = System.Drawing.Color.Red;
            this.chcAnular.Location = new System.Drawing.Point(445, 279);
            this.chcAnular.Name = "chcAnular";
            this.chcAnular.Size = new System.Drawing.Size(189, 17);
            this.chcAnular.TabIndex = 19;
            this.chcAnular.Text = "¿Desea anular este cheque?";
            this.chcAnular.UseVisualStyleBackColor = true;
            this.chcAnular.CheckedChanged += new System.EventHandler(this.chcAnular_CheckedChanged);
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(540, 18);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaEmision.TabIndex = 3;
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaEmision.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaEmision.Location = new System.Drawing.Point(417, 21);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(93, 13);
            this.lblFechaEmision.TabIndex = 18;
            this.lblFechaEmision.Text = "Fecha Emisión:";
            // 
            // chcVerificarCliente
            // 
            this.chcVerificarCliente.AutoSize = true;
            this.chcVerificarCliente.ForeColor = System.Drawing.Color.Red;
            this.chcVerificarCliente.Location = new System.Drawing.Point(102, 47);
            this.chcVerificarCliente.Name = "chcVerificarCliente";
            this.chcVerificarCliente.Size = new System.Drawing.Size(95, 17);
            this.chcVerificarCliente.TabIndex = 4;
            this.chcVerificarCliente.Text = "No es Cliente?";
            this.chcVerificarCliente.UseVisualStyleBackColor = true;
            this.chcVerificarCliente.CheckedChanged += new System.EventHandler(this.chcVerificarCliente_CheckedChanged);
            // 
            // txtDescrMot
            // 
            this.txtDescrMot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescrMot.Location = new System.Drawing.Point(99, 224);
            this.txtDescrMot.Multiline = true;
            this.txtDescrMot.Name = "txtDescrMot";
            this.txtDescrMot.Size = new System.Drawing.Size(535, 46);
            this.txtDescrMot.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 227);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // cboMotOperacionBco
            // 
            this.cboMotOperacionBco.FormattingEnabled = true;
            this.cboMotOperacionBco.Location = new System.Drawing.Point(99, 201);
            this.cboMotOperacionBco.Name = "cboMotOperacionBco";
            this.cboMotOperacionBco.Size = new System.Drawing.Size(264, 21);
            this.cboMotOperacionBco.TabIndex = 6;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMotivo.ForeColor = System.Drawing.Color.Navy;
            this.lblMotivo.Location = new System.Drawing.Point(12, 200);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(49, 13);
            this.lblMotivo.TabIndex = 11;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMonto
            // 
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(99, 272);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 2;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 8;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonto.Location = new System.Drawing.Point(12, 279);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "Monto:";
            // 
            // lblDatosBeneficiario
            // 
            this.lblDatosBeneficiario.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDatosBeneficiario.ForeColor = System.Drawing.Color.Navy;
            this.lblDatosBeneficiario.Location = new System.Drawing.Point(14, 87);
            this.lblDatosBeneficiario.Name = "lblDatosBeneficiario";
            this.lblDatosBeneficiario.Size = new System.Drawing.Size(81, 39);
            this.lblDatosBeneficiario.TabIndex = 8;
            this.lblDatosBeneficiario.Text = "Datos Beneficiario:";
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(98, 87);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(546, 105);
            this.conBusCli.TabIndex = 5;
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(102, 18);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.ReadOnly = true;
            this.txtNroCheque.Size = new System.Drawing.Size(141, 20);
            this.txtNroCheque.TabIndex = 2;
            // 
            // lbNroCheque
            // 
            this.lbNroCheque.AutoSize = true;
            this.lbNroCheque.Font = new System.Drawing.Font("Verdana", 8F);
            this.lbNroCheque.ForeColor = System.Drawing.Color.Navy;
            this.lbNroCheque.Location = new System.Drawing.Point(12, 21);
            this.lbNroCheque.Name = "lbNroCheque";
            this.lbNroCheque.Size = new System.Drawing.Size(84, 13);
            this.lbNroCheque.TabIndex = 4;
            this.lbNroCheque.Text = "Nro. Cheque:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(410, 587);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(602, 587);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(538, 587);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(474, 587);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(346, 587);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmEmisionCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 666);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbDatosEmision);
            this.Controls.Add(this.grbDatosCuenta);
            this.Name = "frmEmisionCheques";
            this.Text = "Emisión Cheques";
            this.Load += new System.EventHandler(this.frmEmisionCheques_Load);
            this.Controls.SetChildIndex(this.grbDatosCuenta, 0);
            this.Controls.SetChildIndex(this.grbDatosEmision, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.grbDatosCuenta.ResumeLayout(false);
            this.grbDatosCuenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTalonarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCheques)).EndInit();
            this.grbDatosEmision.ResumeLayout(false);
            this.grbDatosEmision.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosCuenta;
        private GEN.BotonesBase.btnBusqueda btnBuscarCuenta;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.ControlesBase.lblBase lblNroCuenta;
        private GEN.ControlesBase.lblBase lblEntidad;
        private GEN.ControlesBase.grbBase grbDatosEmision;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCheque;
        private GEN.ControlesBase.lblBase lbNroCheque;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.lblBase lblMotivo;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.ControlesBase.lblBase lblDatosBeneficiario;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.cboMotOperacionBco cboMotOperacionBco;
        private GEN.ControlesBase.dtgBase dtgCheques;
        private GEN.ControlesBase.dtpCorto dtpFechaEmision;
        private GEN.ControlesBase.lblBase lblFechaEmision;
        private GEN.ControlesBase.chcBase chcVerificarCliente;
        private GEN.ControlesBase.txtBase txtDescrMot;
        private GEN.ControlesBase.lblBase lblDescripcion;
        private GEN.ControlesBase.chcBase chcAnular;
        private GEN.ControlesBase.dtgBase dtgTalonarios;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.txtNumRea txtTotMonto;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtSalCont;
        private GEN.ControlesBase.txtNumRea txtSalDisp;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBco;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.BotonesBase.btnMiniBusq btnBusqueda;
        private GEN.ControlesBase.lblBase lblCodigo;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigo;
    }
}