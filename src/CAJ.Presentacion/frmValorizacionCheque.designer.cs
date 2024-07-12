namespace CAJ.Presentacion
{
    partial class frmValorizacionCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValorizacionCheque));
            this.grbValorizar = new GEN.ControlesBase.grbBase(this.components);
            this.txtTotMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaValorizar = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaValorizar = new GEN.ControlesBase.lblBase();
            this.dtgListaCheques = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbDatosCuenta = new GEN.ControlesBase.grbBase(this.components);
            this.txtSalCont = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSalDisp = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuentaBco = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtNroCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblMoneda = new GEN.ControlesBase.lblBase();
            this.lblNroCuenta = new GEN.ControlesBase.lblBase();
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.btnBuscarCuenta = new GEN.BotonesBase.btnBusqueda();
            this.grbDatosEmision = new GEN.ControlesBase.grbBase(this.components);
            this.txtBeneficiario = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFechaEmision = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblFechaEmision = new GEN.ControlesBase.lblBase();
            this.txtDescrMot = new GEN.ControlesBase.txtBase(this.components);
            this.lblDescripcion = new GEN.ControlesBase.lblBase();
            this.cboMotOperacionBco = new GEN.ControlesBase.cboMotOperacionBco(this.components);
            this.lblMotivo = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.lblDatosBeneficiario = new GEN.ControlesBase.lblBase();
            this.txtNroCheque = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lbNroCheque = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.grbValorizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaCheques)).BeginInit();
            this.grbDatosCuenta.SuspendLayout();
            this.grbDatosEmision.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbValorizar
            // 
            this.grbValorizar.Controls.Add(this.txtTotMonto);
            this.grbValorizar.Controls.Add(this.lblBase1);
            this.grbValorizar.Controls.Add(this.dtpFechaValorizar);
            this.grbValorizar.Controls.Add(this.lblFechaValorizar);
            this.grbValorizar.Controls.Add(this.dtgListaCheques);
            this.grbValorizar.Location = new System.Drawing.Point(12, 130);
            this.grbValorizar.Name = "grbValorizar";
            this.grbValorizar.Size = new System.Drawing.Size(662, 292);
            this.grbValorizar.TabIndex = 2;
            this.grbValorizar.TabStop = false;
            this.grbValorizar.Text = "Cheques por Valorizar";
            // 
            // txtTotMonto
            // 
            this.txtTotMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotMonto.FormatoDecimal = true;
            this.txtTotMonto.Location = new System.Drawing.Point(570, 263);
            this.txtTotMonto.Name = "txtTotMonto";
            this.txtTotMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotMonto.nNumDecimales = 2;
            this.txtTotMonto.nvalor = 0D;
            this.txtTotMonto.ReadOnly = true;
            this.txtTotMonto.Size = new System.Drawing.Size(77, 20);
            this.txtTotMonto.TabIndex = 605;
            this.txtTotMonto.Text = "00.00";
            this.txtTotMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(426, 266);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(132, 13);
            this.lblBase1.TabIndex = 604;
            this.lblBase1.Text = "TOTAL X VALORIZAR:";
            // 
            // dtpFechaValorizar
            // 
            this.dtpFechaValorizar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaValorizar.Location = new System.Drawing.Point(136, 19);
            this.dtpFechaValorizar.Name = "dtpFechaValorizar";
            this.dtpFechaValorizar.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaValorizar.TabIndex = 4;
            // 
            // lblFechaValorizar
            // 
            this.lblFechaValorizar.AutoSize = true;
            this.lblFechaValorizar.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaValorizar.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaValorizar.Location = new System.Drawing.Point(13, 22);
            this.lblFechaValorizar.Name = "lblFechaValorizar";
            this.lblFechaValorizar.Size = new System.Drawing.Size(117, 13);
            this.lblFechaValorizar.TabIndex = 3;
            this.lblFechaValorizar.Text = "Fecha Valorización:";
            // 
            // dtgListaCheques
            // 
            this.dtgListaCheques.AllowUserToAddRows = false;
            this.dtgListaCheques.AllowUserToDeleteRows = false;
            this.dtgListaCheques.AllowUserToResizeColumns = false;
            this.dtgListaCheques.AllowUserToResizeRows = false;
            this.dtgListaCheques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaCheques.Location = new System.Drawing.Point(16, 45);
            this.dtgListaCheques.MultiSelect = false;
            this.dtgListaCheques.Name = "dtgListaCheques";
            this.dtgListaCheques.ReadOnly = true;
            this.dtgListaCheques.RowHeadersVisible = false;
            this.dtgListaCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaCheques.Size = new System.Drawing.Size(631, 209);
            this.dtgListaCheques.TabIndex = 0;
            this.dtgListaCheques.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaCheques_CellContentClick);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(551, 612);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(427, 612);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(613, 612);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbDatosCuenta
            // 
            this.grbDatosCuenta.Controls.Add(this.txtSalCont);
            this.grbDatosCuenta.Controls.Add(this.txtSalDisp);
            this.grbDatosCuenta.Controls.Add(this.lblBase4);
            this.grbDatosCuenta.Controls.Add(this.lblBase3);
            this.grbDatosCuenta.Controls.Add(this.cboTipoCuentaBco);
            this.grbDatosCuenta.Controls.Add(this.lblBase2);
            this.grbDatosCuenta.Controls.Add(this.cboMoneda);
            this.grbDatosCuenta.Controls.Add(this.txtNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.cboEntidad);
            this.grbDatosCuenta.Controls.Add(this.lblMoneda);
            this.grbDatosCuenta.Controls.Add(this.lblNroCuenta);
            this.grbDatosCuenta.Controls.Add(this.lblEntidad);
            this.grbDatosCuenta.Controls.Add(this.btnBuscarCuenta);
            this.grbDatosCuenta.Location = new System.Drawing.Point(12, 12);
            this.grbDatosCuenta.Name = "grbDatosCuenta";
            this.grbDatosCuenta.Size = new System.Drawing.Size(662, 112);
            this.grbDatosCuenta.TabIndex = 5;
            this.grbDatosCuenta.TabStop = false;
            this.grbDatosCuenta.Text = "Datos Cuenta";
            // 
            // txtSalCont
            // 
            this.txtSalCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalCont.FormatoDecimal = false;
            this.txtSalCont.Location = new System.Drawing.Point(459, 37);
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
            this.txtSalCont.TabIndex = 621;
            this.txtSalCont.Text = "0.00";
            this.txtSalCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSalDisp
            // 
            this.txtSalDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalDisp.FormatoDecimal = false;
            this.txtSalDisp.Location = new System.Drawing.Point(459, 15);
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
            this.txtSalDisp.TabIndex = 620;
            this.txtSalDisp.Text = "0.00";
            this.txtSalDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(367, 41);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(79, 13);
            this.lblBase4.TabIndex = 619;
            this.lblBase4.Text = "S. Contable:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(367, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(87, 13);
            this.lblBase3.TabIndex = 618;
            this.lblBase3.Text = "S. Disponible:";
            // 
            // cboTipoCuentaBco
            // 
            this.cboTipoCuentaBco.Enabled = false;
            this.cboTipoCuentaBco.FormattingEnabled = true;
            this.cboTipoCuentaBco.Location = new System.Drawing.Point(100, 59);
            this.cboTipoCuentaBco.Name = "cboTipoCuentaBco";
            this.cboTipoCuentaBco.Size = new System.Drawing.Size(230, 21);
            this.cboTipoCuentaBco.TabIndex = 617;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 63);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(81, 13);
            this.lblBase2.TabIndex = 616;
            this.lblBase2.Text = "Tipo Cuenta:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(100, 82);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda.TabIndex = 614;
            // 
            // txtNroCuenta
            // 
            this.txtNroCuenta.Enabled = false;
            this.txtNroCuenta.Location = new System.Drawing.Point(100, 37);
            this.txtNroCuenta.Name = "txtNroCuenta";
            this.txtNroCuenta.Size = new System.Drawing.Size(230, 20);
            this.txtNroCuenta.TabIndex = 613;
            // 
            // cboEntidad
            // 
            this.cboEntidad.Enabled = false;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.ItemHeight = 13;
            this.cboEntidad.Location = new System.Drawing.Point(100, 14);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(230, 21);
            this.cboEntidad.TabIndex = 615;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMoneda.ForeColor = System.Drawing.Color.Navy;
            this.lblMoneda.Location = new System.Drawing.Point(16, 86);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(56, 13);
            this.lblMoneda.TabIndex = 612;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblNroCuenta
            // 
            this.lblNroCuenta.AutoSize = true;
            this.lblNroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCuenta.Location = new System.Drawing.Point(16, 41);
            this.lblNroCuenta.Name = "lblNroCuenta";
            this.lblNroCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblNroCuenta.TabIndex = 611;
            this.lblNroCuenta.Text = "Nro. Cuenta:";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(16, 18);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 610;
            this.lblEntidad.Text = "Entidad:";
            // 
            // btnBuscarCuenta
            // 
            this.btnBuscarCuenta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCuenta.BackgroundImage")));
            this.btnBuscarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarCuenta.Location = new System.Drawing.Point(587, 14);
            this.btnBuscarCuenta.Name = "btnBuscarCuenta";
            this.btnBuscarCuenta.Size = new System.Drawing.Size(60, 50);
            this.btnBuscarCuenta.TabIndex = 5;
            this.btnBuscarCuenta.Text = "&Buscar";
            this.btnBuscarCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarCuenta.UseVisualStyleBackColor = true;
            this.btnBuscarCuenta.Click += new System.EventHandler(this.btnBuscarCuenta_Click);
            // 
            // grbDatosEmision
            // 
            this.grbDatosEmision.Controls.Add(this.txtBeneficiario);
            this.grbDatosEmision.Controls.Add(this.dtpFechaEmision);
            this.grbDatosEmision.Controls.Add(this.lblFechaEmision);
            this.grbDatosEmision.Controls.Add(this.txtDescrMot);
            this.grbDatosEmision.Controls.Add(this.lblDescripcion);
            this.grbDatosEmision.Controls.Add(this.cboMotOperacionBco);
            this.grbDatosEmision.Controls.Add(this.lblMotivo);
            this.grbDatosEmision.Controls.Add(this.txtMonto);
            this.grbDatosEmision.Controls.Add(this.lblMonto);
            this.grbDatosEmision.Controls.Add(this.lblDatosBeneficiario);
            this.grbDatosEmision.Controls.Add(this.txtNroCheque);
            this.grbDatosEmision.Controls.Add(this.lbNroCheque);
            this.grbDatosEmision.Location = new System.Drawing.Point(12, 428);
            this.grbDatosEmision.Name = "grbDatosEmision";
            this.grbDatosEmision.Size = new System.Drawing.Size(662, 178);
            this.grbDatosEmision.TabIndex = 12;
            this.grbDatosEmision.TabStop = false;
            this.grbDatosEmision.Text = "Datos Emisión";
            // 
            // txtBeneficiario
            // 
            this.txtBeneficiario.Location = new System.Drawing.Point(102, 44);
            this.txtBeneficiario.Name = "txtBeneficiario";
            this.txtBeneficiario.Size = new System.Drawing.Size(283, 20);
            this.txtBeneficiario.TabIndex = 19;
            // 
            // dtpFechaEmision
            // 
            this.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEmision.Location = new System.Drawing.Point(532, 21);
            this.dtpFechaEmision.Name = "dtpFechaEmision";
            this.dtpFechaEmision.Size = new System.Drawing.Size(102, 20);
            this.dtpFechaEmision.TabIndex = 2;
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.AutoSize = true;
            this.lblFechaEmision.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFechaEmision.ForeColor = System.Drawing.Color.Navy;
            this.lblFechaEmision.Location = new System.Drawing.Point(433, 24);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Size = new System.Drawing.Size(93, 13);
            this.lblFechaEmision.TabIndex = 18;
            this.lblFechaEmision.Text = "Fecha Emisión:";
            // 
            // txtDescrMot
            // 
            this.txtDescrMot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescrMot.Location = new System.Drawing.Point(102, 97);
            this.txtDescrMot.Multiline = true;
            this.txtDescrMot.Name = "txtDescrMot";
            this.txtDescrMot.Size = new System.Drawing.Size(535, 46);
            this.txtDescrMot.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 100);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // cboMotOperacionBco
            // 
            this.cboMotOperacionBco.FormattingEnabled = true;
            this.cboMotOperacionBco.Location = new System.Drawing.Point(102, 70);
            this.cboMotOperacionBco.Name = "cboMotOperacionBco";
            this.cboMotOperacionBco.Size = new System.Drawing.Size(283, 21);
            this.cboMotOperacionBco.TabIndex = 3;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMotivo.ForeColor = System.Drawing.Color.Navy;
            this.lblMotivo.Location = new System.Drawing.Point(13, 73);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(49, 13);
            this.lblMotivo.TabIndex = 11;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMonto
            // 
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(102, 149);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 2;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 5;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonto.Location = new System.Drawing.Point(13, 152);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "Monto:";
            // 
            // lblDatosBeneficiario
            // 
            this.lblDatosBeneficiario.AutoSize = true;
            this.lblDatosBeneficiario.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDatosBeneficiario.ForeColor = System.Drawing.Color.Navy;
            this.lblDatosBeneficiario.Location = new System.Drawing.Point(13, 47);
            this.lblDatosBeneficiario.Name = "lblDatosBeneficiario";
            this.lblDatosBeneficiario.Size = new System.Drawing.Size(79, 13);
            this.lblDatosBeneficiario.TabIndex = 8;
            this.lblDatosBeneficiario.Text = "Beneficiario:";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(102, 21);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.ReadOnly = true;
            this.txtNroCheque.Size = new System.Drawing.Size(87, 20);
            this.txtNroCheque.TabIndex = 5;
            // 
            // lbNroCheque
            // 
            this.lbNroCheque.AutoSize = true;
            this.lbNroCheque.Font = new System.Drawing.Font("Verdana", 8F);
            this.lbNroCheque.ForeColor = System.Drawing.Color.Navy;
            this.lbNroCheque.Location = new System.Drawing.Point(13, 24);
            this.lbNroCheque.Name = "lbNroCheque";
            this.lbNroCheque.Size = new System.Drawing.Size(84, 13);
            this.lbNroCheque.TabIndex = 4;
            this.lbNroCheque.Text = "Nro. Cheque:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(489, 612);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmValorizacionCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 694);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbDatosEmision);
            this.Controls.Add(this.grbDatosCuenta);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbValorizar);
            this.Name = "frmValorizacionCheque";
            this.Text = "Valorizar Cheque";
            this.Load += new System.EventHandler(this.frmValorizarCheque_Load);
            this.Controls.SetChildIndex(this.grbValorizar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.grbDatosCuenta, 0);
            this.Controls.SetChildIndex(this.grbDatosEmision, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.grbValorizar.ResumeLayout(false);
            this.grbValorizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaCheques)).EndInit();
            this.grbDatosCuenta.ResumeLayout(false);
            this.grbDatosCuenta.PerformLayout();
            this.grbDatosEmision.ResumeLayout(false);
            this.grbDatosEmision.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbValorizar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.dtgBase dtgListaCheques;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbDatosCuenta;
        private GEN.BotonesBase.btnBusqueda btnBuscarCuenta;
        private GEN.ControlesBase.grbBase grbDatosEmision;
        private GEN.ControlesBase.txtBase txtBeneficiario;
        private GEN.ControlesBase.dtpCorto dtpFechaEmision;
        private GEN.ControlesBase.lblBase lblFechaEmision;
        private GEN.ControlesBase.txtBase txtDescrMot;
        private GEN.ControlesBase.lblBase lblDescripcion;
        private GEN.ControlesBase.cboMotOperacionBco cboMotOperacionBco;
        private GEN.ControlesBase.lblBase lblMotivo;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.ControlesBase.lblBase lblDatosBeneficiario;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCheque;
        private GEN.ControlesBase.lblBase lbNroCheque;
        private GEN.ControlesBase.dtpCorto dtpFechaValorizar;
        private GEN.ControlesBase.lblBase lblFechaValorizar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.txtNumRea txtSalCont;
        private GEN.ControlesBase.txtNumRea txtSalDisp;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBco;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtBase txtNroCuenta;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.lblBase lblMoneda;
        private GEN.ControlesBase.lblBase lblNroCuenta;
        private GEN.ControlesBase.lblBase lblEntidad;
        private GEN.ControlesBase.txtNumRea txtTotMonto;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}