namespace CRE.Presentacion
{
    partial class frmRegistroGastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroGastos));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgGastosCuenta = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.txtTipDocGasto = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipDocGasto = new GEN.ControlesBase.cboTipDocGasto(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblMonGasto = new GEN.ControlesBase.lblBase();
            this.cboMonGasto = new GEN.ControlesBase.cboMoneda(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMontoMonCred = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMtoMonCred = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtDocSustento = new GEN.ControlesBase.txtBase(this.components);
            this.btnAddDoc = new GEN.BotonesBase.btnMiniAgregar();
            this.txtDetGasto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMontoGasto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMtoGasto = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipGasto = new GEN.ControlesBase.cboTipGasto(this.components);
            this.cboGrupoGasto = new GEN.ControlesBase.cboGrupoGasto(this.components);
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
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
            this.ttpMonCred = new GEN.ControlesBase.ttpToolTip();
            this.ttpMtoGasto = new GEN.ControlesBase.ttpToolTip();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnFiltroGastos = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase18 = new GEN.ControlesBase.lblBase();
            this.txtTotalGastos = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnMiniDescargar = new GEN.BotonesBase.btnMiniDescargar(this.components);
            this.lblCargaGasto = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosCuenta)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.Color.Transparent;
            this.conBusCuentaCli.Location = new System.Drawing.Point(12, 7);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(558, 100);
            this.conBusCuentaCli.TabIndex = 0;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(320, 627);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(505, 627);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(382, 627);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(566, 627);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dtgGastosCuenta
            // 
            this.dtgGastosCuenta.AllowUserToAddRows = false;
            this.dtgGastosCuenta.AllowUserToDeleteRows = false;
            this.dtgGastosCuenta.AllowUserToResizeColumns = false;
            this.dtgGastosCuenta.AllowUserToResizeRows = false;
            this.dtgGastosCuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGastosCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGastosCuenta.Location = new System.Drawing.Point(12, 226);
            this.dtgGastosCuenta.MultiSelect = false;
            this.dtgGastosCuenta.Name = "dtgGastosCuenta";
            this.dtgGastosCuenta.ReadOnly = true;
            this.dtgGastosCuenta.RowHeadersVisible = false;
            this.dtgGastosCuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGastosCuenta.Size = new System.Drawing.Size(614, 150);
            this.dtgGastosCuenta.TabIndex = 2;
            this.dtgGastosCuenta.SelectionChanged += new System.EventHandler(this.dtgGastosCuenta_SelectionChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase15);
            this.grbBase1.Controls.Add(this.txtTipDocGasto);
            this.grbBase1.Controls.Add(this.cboTipDocGasto);
            this.grbBase1.Controls.Add(this.lblBase14);
            this.grbBase1.Controls.Add(this.lblMonGasto);
            this.grbBase1.Controls.Add(this.cboMonGasto);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase13);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtMontoMonCred);
            this.grbBase1.Controls.Add(this.lblMtoMonCred);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.txtNroDoc);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtDocSustento);
            this.grbBase1.Controls.Add(this.btnAddDoc);
            this.grbBase1.Controls.Add(this.txtDetGasto);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtMontoGasto);
            this.grbBase1.Controls.Add(this.lblMtoGasto);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboTipGasto);
            this.grbBase1.Controls.Add(this.cboGrupoGasto);
            this.grbBase1.Location = new System.Drawing.Point(12, 400);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(614, 226);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle de gastos";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(19, 113);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(91, 13);
            this.lblBase15.TabIndex = 31;
            this.lblBase15.Text = "Det. Tip. Doc.:";
            // 
            // txtTipDocGasto
            // 
            this.txtTipDocGasto.Location = new System.Drawing.Point(113, 109);
            this.txtTipDocGasto.Name = "txtTipDocGasto";
            this.txtTipDocGasto.Size = new System.Drawing.Size(490, 20);
            this.txtTipDocGasto.TabIndex = 8;
            // 
            // cboTipDocGasto
            // 
            this.cboTipDocGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocGasto.FormattingEnabled = true;
            this.cboTipDocGasto.Location = new System.Drawing.Point(408, 86);
            this.cboTipDocGasto.Name = "cboTipDocGasto";
            this.cboTipDocGasto.Size = new System.Drawing.Size(195, 21);
            this.cboTipDocGasto.TabIndex = 7;
            this.cboTipDocGasto.SelectedIndexChanged += new System.EventHandler(this.cboTipDocGasto_SelectedIndexChanged);
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(300, 90);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(105, 13);
            this.lblBase14.TabIndex = 28;
            this.lblBase14.Text = "Tipo Documento:";
            // 
            // lblMonGasto
            // 
            this.lblMonGasto.AutoSize = true;
            this.lblMonGasto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonGasto.Location = new System.Drawing.Point(520, 69);
            this.lblMonGasto.Name = "lblMonGasto";
            this.lblMonGasto.Size = new System.Drawing.Size(0, 13);
            this.lblMonGasto.TabIndex = 27;
            // 
            // cboMonGasto
            // 
            this.cboMonGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonGasto.FormattingEnabled = true;
            this.cboMonGasto.Location = new System.Drawing.Point(408, 19);
            this.cboMonGasto.Name = "cboMonGasto";
            this.cboMonGasto.Size = new System.Drawing.Size(195, 21);
            this.cboMonGasto.TabIndex = 1;
            this.cboMonGasto.SelectedIndexChanged += new System.EventHandler(this.cboMonGasto_SelectedIndexChanged);
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.Enabled = false;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(113, 19);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(182, 21);
            this.cboAgencias.TabIndex = 0;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(53, 23);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(57, 13);
            this.lblBase13.TabIndex = 24;
            this.lblBase13.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(345, 23);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(60, 13);
            this.lblBase3.TabIndex = 22;
            this.lblBase3.Text = "Moneda :";
            // 
            // txtMontoMonCred
            // 
            this.txtMontoMonCred.Enabled = false;
            this.txtMontoMonCred.FormatoDecimal = false;
            this.txtMontoMonCred.Location = new System.Drawing.Point(408, 65);
            this.txtMontoMonCred.Name = "txtMontoMonCred";
            this.txtMontoMonCred.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMonCred.nNumDecimales = 4;
            this.txtMontoMonCred.nvalor = 0D;
            this.txtMontoMonCred.Size = new System.Drawing.Size(110, 20);
            this.txtMontoMonCred.TabIndex = 5;
            // 
            // lblMtoMonCred
            // 
            this.lblMtoMonCred.AutoSize = true;
            this.lblMtoMonCred.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMtoMonCred.ForeColor = System.Drawing.Color.Navy;
            this.lblMtoMonCred.Location = new System.Drawing.Point(292, 69);
            this.lblMtoMonCred.Name = "lblMtoMonCred";
            this.lblMtoMonCred.Size = new System.Drawing.Size(113, 13);
            this.lblMtoMonCred.TabIndex = 20;
            this.lblMtoMonCred.Text = "Monto Convertido:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(5, 90);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(105, 13);
            this.lblBase6.TabIndex = 19;
            this.lblBase6.Text = "Nro. Documento:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(113, 86);
            this.txtNroDoc.MaxLength = 20;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(110, 20);
            this.txtNroDoc.TabIndex = 6;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(18, 202);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(92, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Doc. Sustento:";
            // 
            // txtDocSustento
            // 
            this.txtDocSustento.Enabled = false;
            this.txtDocSustento.Location = new System.Drawing.Point(113, 198);
            this.txtDocSustento.Name = "txtDocSustento";
            this.txtDocSustento.Size = new System.Drawing.Size(408, 20);
            this.txtDocSustento.TabIndex = 10;
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDoc.BackgroundImage")));
            this.btnAddDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddDoc.Location = new System.Drawing.Point(524, 194);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(36, 28);
            this.btnAddDoc.TabIndex = 11;
            this.btnAddDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // txtDetGasto
            // 
            this.txtDetGasto.Location = new System.Drawing.Point(113, 130);
            this.txtDetGasto.Multiline = true;
            this.txtDetGasto.Name = "txtDetGasto";
            this.txtDetGasto.Size = new System.Drawing.Size(490, 64);
            this.txtDetGasto.TabIndex = 9;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(58, 156);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(52, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Detalle:";
            // 
            // txtMontoGasto
            // 
            this.txtMontoGasto.FormatoDecimal = false;
            this.txtMontoGasto.Location = new System.Drawing.Point(113, 65);
            this.txtMontoGasto.Name = "txtMontoGasto";
            this.txtMontoGasto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoGasto.nNumDecimales = 4;
            this.txtMontoGasto.nvalor = 0D;
            this.txtMontoGasto.Size = new System.Drawing.Size(110, 20);
            this.txtMontoGasto.TabIndex = 4;
            this.txtMontoGasto.Leave += new System.EventHandler(this.txtMontoGasto_Leave);
            // 
            // lblMtoGasto
            // 
            this.lblMtoGasto.AutoSize = true;
            this.lblMtoGasto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMtoGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblMtoGasto.Location = new System.Drawing.Point(27, 69);
            this.lblMtoGasto.Name = "lblMtoGasto";
            this.lblMtoGasto.Size = new System.Drawing.Size(83, 13);
            this.lblMtoGasto.TabIndex = 4;
            this.lblMtoGasto.Text = "Monto Gasto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(332, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(73, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Tipo Gasto:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 46);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Grupo gasto:";
            // 
            // cboTipGasto
            // 
            this.cboTipGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipGasto.FormattingEnabled = true;
            this.cboTipGasto.Location = new System.Drawing.Point(408, 42);
            this.cboTipGasto.Name = "cboTipGasto";
            this.cboTipGasto.Size = new System.Drawing.Size(195, 21);
            this.cboTipGasto.TabIndex = 3;
            // 
            // cboGrupoGasto
            // 
            this.cboGrupoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoGasto.Enabled = false;
            this.cboGrupoGasto.FormattingEnabled = true;
            this.cboGrupoGasto.Location = new System.Drawing.Point(113, 42);
            this.cboGrupoGasto.Name = "cboGrupoGasto";
            this.cboGrupoGasto.Size = new System.Drawing.Size(182, 21);
            this.cboGrupoGasto.TabIndex = 2;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(444, 627);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.grbBase2.Location = new System.Drawing.Point(12, 105);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(614, 87);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del crédito";
            // 
            // txtAtraso
            // 
            this.txtAtraso.BackColor = System.Drawing.SystemColors.Control;
            this.txtAtraso.Enabled = false;
            this.txtAtraso.Location = new System.Drawing.Point(122, 61);
            this.txtAtraso.Name = "txtAtraso";
            this.txtAtraso.Size = new System.Drawing.Size(157, 20);
            this.txtAtraso.TabIndex = 29;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(70, 65);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(49, 13);
            this.lblBase12.TabIndex = 30;
            this.lblBase12.Text = "Atraso:";
            // 
            // txtCuoPend
            // 
            this.txtCuoPend.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuoPend.Enabled = false;
            this.txtCuoPend.Location = new System.Drawing.Point(404, 61);
            this.txtCuoPend.Name = "txtCuoPend";
            this.txtCuoPend.Size = new System.Drawing.Size(189, 20);
            this.txtCuoPend.TabIndex = 27;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(323, 65);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(75, 13);
            this.lblBase11.TabIndex = 28;
            this.lblBase11.Text = "Cuo. Pend.:";
            // 
            // txtTipoCredito
            // 
            this.txtTipoCredito.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoCredito.Enabled = false;
            this.txtTipoCredito.Location = new System.Drawing.Point(122, 17);
            this.txtTipoCredito.Name = "txtTipoCredito";
            this.txtTipoCredito.Size = new System.Drawing.Size(157, 20);
            this.txtTipoCredito.TabIndex = 26;
            // 
            // txtSaldoCred
            // 
            this.txtSaldoCred.BackColor = System.Drawing.SystemColors.Control;
            this.txtSaldoCred.Enabled = false;
            this.txtSaldoCred.Location = new System.Drawing.Point(122, 39);
            this.txtSaldoCred.Name = "txtSaldoCred";
            this.txtSaldoCred.Size = new System.Drawing.Size(157, 20);
            this.txtSaldoCred.TabIndex = 20;
            // 
            // txtCuotas
            // 
            this.txtCuotas.BackColor = System.Drawing.SystemColors.Control;
            this.txtCuotas.Enabled = false;
            this.txtCuotas.Location = new System.Drawing.Point(404, 39);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(189, 20);
            this.txtCuotas.TabIndex = 21;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(404, 17);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(189, 21);
            this.cboMoneda.TabIndex = 19;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(342, 21);
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
            this.lblBase9.Location = new System.Drawing.Point(346, 43);
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
            this.lblBase7.Location = new System.Drawing.Point(19, 21);
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
            this.lblBase8.Location = new System.Drawing.Point(73, 43);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(46, 13);
            this.lblBase8.TabIndex = 22;
            this.lblBase8.Text = "Monto:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(17, 203);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(55, 13);
            this.lblBase16.TabIndex = 31;
            this.lblBase16.Text = "F. Inicio:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(200, 203);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(40, 13);
            this.lblBase17.TabIndex = 32;
            this.lblBase17.Text = "F. Fin:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(78, 199);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(113, 20);
            this.dtpFecIni.TabIndex = 4;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(246, 199);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(113, 20);
            this.dtpFecFin.TabIndex = 5;
            // 
            // btnFiltroGastos
            // 
            this.btnFiltroGastos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiltroGastos.BackgroundImage")));
            this.btnFiltroGastos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiltroGastos.Location = new System.Drawing.Point(372, 195);
            this.btnFiltroGastos.Name = "btnFiltroGastos";
            this.btnFiltroGastos.Size = new System.Drawing.Size(36, 28);
            this.btnFiltroGastos.TabIndex = 6;
            this.btnFiltroGastos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltroGastos.UseVisualStyleBackColor = true;
            this.btnFiltroGastos.Click += new System.EventHandler(this.btnFiltroGastos_Click);
            // 
            // lblBase18
            // 
            this.lblBase18.AutoSize = true;
            this.lblBase18.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase18.ForeColor = System.Drawing.Color.Navy;
            this.lblBase18.Location = new System.Drawing.Point(481, 382);
            this.lblBase18.Name = "lblBase18";
            this.lblBase18.Size = new System.Drawing.Size(39, 13);
            this.lblBase18.TabIndex = 36;
            this.lblBase18.Text = "Total:";
            // 
            // txtTotalGastos
            // 
            this.txtTotalGastos.Enabled = false;
            this.txtTotalGastos.FormatoDecimal = false;
            this.txtTotalGastos.Location = new System.Drawing.Point(526, 378);
            this.txtTotalGastos.Name = "txtTotalGastos";
            this.txtTotalGastos.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalGastos.nNumDecimales = 4;
            this.txtTotalGastos.nvalor = 0D;
            this.txtTotalGastos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalGastos.TabIndex = 37;
            // 
            // btnMiniDescargar
            // 
            this.btnMiniDescargar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDescargar.BackgroundImage")));
            this.btnMiniDescargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDescargar.Location = new System.Drawing.Point(590, 195);
            this.btnMiniDescargar.Name = "btnMiniDescargar";
            this.btnMiniDescargar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDescargar.TabIndex = 38;
            this.btnMiniDescargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDescargar.UseVisualStyleBackColor = true;
            this.btnMiniDescargar.Click += new System.EventHandler(this.btnMiniDescargar_Click);
            // 
            // lblCargaGasto
            // 
            this.lblCargaGasto.AutoSize = true;
            this.lblCargaGasto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargaGasto.ForeColor = System.Drawing.Color.Navy;
            this.lblCargaGasto.Location = new System.Drawing.Point(9, 648);
            this.lblCargaGasto.Name = "lblCargaGasto";
            this.lblCargaGasto.Size = new System.Drawing.Size(0, 16);
            this.lblCargaGasto.TabIndex = 39;
            // 
            // frmRegistroGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 704);
            this.Controls.Add(this.lblCargaGasto);
            this.Controls.Add(this.btnMiniDescargar);
            this.Controls.Add(this.txtTotalGastos);
            this.Controls.Add(this.lblBase18);
            this.Controls.Add(this.btnFiltroGastos);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.lblBase17);
            this.Controls.Add(this.lblBase16);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgGastosCuenta);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmRegistroGastos";
            this.Text = "Registro de gastos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegistroGastos_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.dtgGastosCuenta, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase16, 0);
            this.Controls.SetChildIndex(this.lblBase17, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.btnFiltroGastos, 0);
            this.Controls.SetChildIndex(this.lblBase18, 0);
            this.Controls.SetChildIndex(this.txtTotalGastos, 0);
            this.Controls.SetChildIndex(this.btnMiniDescargar, 0);
            this.Controls.SetChildIndex(this.lblCargaGasto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGastosCuenta)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.dtgBase dtgGastosCuenta;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboTipGasto cboTipGasto;
        private GEN.ControlesBase.cboGrupoGasto cboGrupoGasto;
        private GEN.ControlesBase.txtBase txtDetGasto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMontoGasto;
        private GEN.ControlesBase.lblBase lblMtoGasto;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtDocSustento;
        private GEN.BotonesBase.btnMiniAgregar btnAddDoc;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtSaldoCred;
        private GEN.ControlesBase.txtBase txtCuotas;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtTipoCredito;
        private GEN.ControlesBase.txtBase txtAtraso;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtCuoPend;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtMontoMonCred;
        private GEN.ControlesBase.lblBase lblMtoMonCred;
        private GEN.ControlesBase.ttpToolTip ttpMonCred;
        private GEN.ControlesBase.ttpToolTip ttpMtoGasto;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboMoneda cboMonGasto;
        private GEN.ControlesBase.lblBase lblMonGasto;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.txtBase txtTipDocGasto;
        private GEN.ControlesBase.cboTipDocGasto cboTipDocGasto;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.BotonesBase.btnMiniBusq btnFiltroGastos;
        private GEN.ControlesBase.lblBase lblBase18;
        private GEN.ControlesBase.txtNumRea txtTotalGastos;
        private GEN.BotonesBase.btnMiniDescargar btnMiniDescargar;
        private GEN.ControlesBase.lblBaseCustom lblCargaGasto;
    }
}

