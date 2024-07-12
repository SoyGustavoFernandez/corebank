namespace CRE.Presentacion
{
    partial class frmNuevaEvPyme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaEvPyme));
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.cboCIIU = new GEN.ControlesBase.cboActividadEco(this.components);
            this.cboActividadInterna = new GEN.ControlesBase.cboActividadInterna(this.components);
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cboTipoEvaluacion = new GEN.ControlesBase.cboBase(this.components);
            this.txtSaldoTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBaseCustom16 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtAniosActv = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBaseCustom3 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom12 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom5 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.cboSectorEcon = new GEN.ControlesBase.cboBase(this.components);
            this.lblBaseCustom11 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.conCreditoTasa = new GEN.ControlesBase.ConCreditoTasa();
            this.grbCredProp = new GEN.ControlesBase.grbBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.panelDG = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgSolicitud = new System.Windows.Forms.DataGridView();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.conBusCli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grbCredProp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDG.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitud)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodInst);
            this.conBusCli.Controls.Add(this.txtCodAge);
            this.conBusCli.Controls.Add(this.txtDireccion);
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.Controls.Add(this.txtNombre);
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(8, 10);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(532, 79);
            this.conBusCli.TabIndex = 0;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // cboCIIU
            // 
            this.cboCIIU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCIIU.Enabled = false;
            this.cboCIIU.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboCIIU, -28);
            this.cboCIIU.Location = new System.Drawing.Point(95, 72);
            this.cboCIIU.Name = "cboCIIU";
            this.cboCIIU.Size = new System.Drawing.Size(262, 21);
            this.cboCIIU.TabIndex = 5;
            // 
            // cboActividadInterna
            // 
            this.cboActividadInterna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadInterna.DropDownWidth = 400;
            this.cboActividadInterna.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboActividadInterna, -28);
            this.cboActividadInterna.Location = new System.Drawing.Point(95, 49);
            this.cboActividadInterna.Name = "cboActividadInterna";
            this.cboActividadInterna.Size = new System.Drawing.Size(262, 21);
            this.cboActividadInterna.TabIndex = 4;
            this.cboActividadInterna.SelectedIndexChanged += new System.EventHandler(this.cboActividadInterna_SelectedIndexChanged);
            this.cboActividadInterna.Validating += new System.ComponentModel.CancelEventHandler(this.cboActividadInterna_Validating);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::CRE.Presentacion.Properties.Resources.btn_agregar;
            this.btnAgregar.Location = new System.Drawing.Point(324, 1);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(30, 22);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboTipoEvaluacion
            // 
            this.cboTipoEvaluacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEvaluacion.Enabled = false;
            this.cboTipoEvaluacion.FormattingEnabled = true;
            this.cboTipoEvaluacion.Location = new System.Drawing.Point(95, 26);
            this.cboTipoEvaluacion.Name = "cboTipoEvaluacion";
            this.cboTipoEvaluacion.Size = new System.Drawing.Size(184, 21);
            this.cboTipoEvaluacion.TabIndex = 3;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Enabled = false;
            this.txtSaldoTotal.FormatoDecimal = false;
            this.errorProvider.SetIconPadding(this.txtSaldoTotal, -18);
            this.txtSaldoTotal.Location = new System.Drawing.Point(208, 2);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoTotal.nNumDecimales = 4;
            this.txtSaldoTotal.nvalor = 0D;
            this.txtSaldoTotal.Size = new System.Drawing.Size(113, 20);
            this.txtSaldoTotal.TabIndex = 1;
            this.txtSaldoTotal.Text = "0";
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaldoTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeudaSF_KeyDown);
            this.txtSaldoTotal.Leave += new System.EventHandler(this.txtDeudaSF_Leave);
            this.txtSaldoTotal.Validated += new System.EventHandler(this.txtSaldoTotal_Validated);
            // 
            // lblBaseCustom16
            // 
            this.lblBaseCustom16.AutoSize = true;
            this.lblBaseCustom16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom16.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom16.Location = new System.Drawing.Point(23, 6);
            this.lblBaseCustom16.Name = "lblBaseCustom16";
            this.lblBaseCustom16.Size = new System.Drawing.Size(70, 13);
            this.lblBaseCustom16.TabIndex = 87;
            this.lblBaseCustom16.Text = "Saldo Total";
            // 
            // txtAniosActv
            // 
            this.txtAniosActv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAniosActv.Enabled = false;
            this.txtAniosActv.FormatoDecimal = false;
            this.errorProvider.SetIconPadding(this.txtAniosActv, -18);
            this.txtAniosActv.Location = new System.Drawing.Point(95, 118);
            this.txtAniosActv.Name = "txtAniosActv";
            this.txtAniosActv.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAniosActv.nNumDecimales = 4;
            this.txtAniosActv.nvalor = 0D;
            this.txtAniosActv.ReadOnly = true;
            this.txtAniosActv.Size = new System.Drawing.Size(50, 20);
            this.txtAniosActv.TabIndex = 7;
            this.txtAniosActv.Text = "0";
            this.txtAniosActv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAniosActv.Validated += new System.EventHandler(this.txtAniosActv_Validated);
            // 
            // lblBaseCustom3
            // 
            this.lblBaseCustom3.AutoSize = true;
            this.lblBaseCustom3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom3.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom3.Location = new System.Drawing.Point(39, 29);
            this.lblBaseCustom3.Name = "lblBaseCustom3";
            this.lblBaseCustom3.Size = new System.Drawing.Size(54, 13);
            this.lblBaseCustom3.TabIndex = 80;
            this.lblBaseCustom3.Text = "Formato";
            // 
            // lblBaseCustom12
            // 
            this.lblBaseCustom12.AutoSize = true;
            this.lblBaseCustom12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom12.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom12.Location = new System.Drawing.Point(2, 121);
            this.lblBaseCustom12.Name = "lblBaseCustom12";
            this.lblBaseCustom12.Size = new System.Drawing.Size(91, 13);
            this.lblBaseCustom12.TabIndex = 91;
            this.lblBaseCustom12.Text = "Años Actividad";
            // 
            // lblBaseCustom5
            // 
            this.lblBaseCustom5.AutoSize = true;
            this.lblBaseCustom5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom5.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom5.Location = new System.Drawing.Point(18, 52);
            this.lblBaseCustom5.Name = "lblBaseCustom5";
            this.lblBaseCustom5.Size = new System.Drawing.Size(75, 13);
            this.lblBaseCustom5.TabIndex = 112;
            this.lblBaseCustom5.Text = "Act. Interna";
            // 
            // cboSectorEcon
            // 
            this.cboSectorEcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSectorEcon.FormattingEnabled = true;
            this.errorProvider.SetIconPadding(this.cboSectorEcon, -28);
            this.cboSectorEcon.Location = new System.Drawing.Point(95, 95);
            this.cboSectorEcon.Name = "cboSectorEcon";
            this.cboSectorEcon.Size = new System.Drawing.Size(184, 21);
            this.cboSectorEcon.TabIndex = 6;
            this.cboSectorEcon.Validated += new System.EventHandler(this.cboSectorEcon_Validated);
            // 
            // lblBaseCustom11
            // 
            this.lblBaseCustom11.AutoSize = true;
            this.lblBaseCustom11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom11.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom11.Location = new System.Drawing.Point(56, 75);
            this.lblBaseCustom11.Name = "lblBaseCustom11";
            this.lblBaseCustom11.Size = new System.Drawing.Size(37, 13);
            this.lblBaseCustom11.TabIndex = 114;
            this.lblBaseCustom11.Text = "CIUU";
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(14, 98);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(79, 13);
            this.lblBaseCustom1.TabIndex = 78;
            this.lblBaseCustom1.Text = "Sector Econ.";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // conCreditoTasa
            // 
            this.conCreditoTasa.AutoSize = true;
            this.conCreditoTasa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoTasa.CuotasEnabled = true;
            this.conCreditoTasa.DiasGraciaEnabled = false;
            this.conCreditoTasa.FechaDesembolsoEnabled = true;
            this.conCreditoTasa.lMostrarTodosNivCred = false;
            this.conCreditoTasa.Location = new System.Drawing.Point(0, 14);
            this.conCreditoTasa.MonedaEnabled = false;
            this.conCreditoTasa.MontoEnabled = true;
            this.conCreditoTasa.Name = "conCreditoTasa";
            this.conCreditoTasa.NivelesProductoEnabled = true;
            this.conCreditoTasa.PlazoCuotaEnabled = true;
            this.conCreditoTasa.Size = new System.Drawing.Size(325, 229);
            this.conCreditoTasa.TabIndex = 0;
            this.conCreditoTasa.TEAEnabled = true;
            this.conCreditoTasa.TipoPeriodoEnabled = true;
            this.conCreditoTasa.TipoTasaCreditoEnabled = true;
            this.conCreditoTasa.ChangeMonto += new System.EventHandler(this.conCreditoTasa_ChangeMonto);
            this.conCreditoTasa.ChangeMoneda += new System.EventHandler(this.conCreditoTasa_ChangeMoneda);
            // 
            // grbCredProp
            // 
            this.grbCredProp.Controls.Add(this.panel1);
            this.grbCredProp.Controls.Add(this.conCreditoTasa);
            this.grbCredProp.Location = new System.Drawing.Point(8, 194);
            this.grbCredProp.Name = "grbCredProp";
            this.grbCredProp.Size = new System.Drawing.Size(706, 297);
            this.grbCredProp.TabIndex = 2;
            this.grbCredProp.TabStop = false;
            this.grbCredProp.Text = "Crédito Propuesto";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboMoneda);
            this.panel1.Controls.Add(this.cboCIIU);
            this.panel1.Controls.Add(this.lblBaseCustom16);
            this.panel1.Controls.Add(this.cboActividadInterna);
            this.panel1.Controls.Add(this.lblBaseCustom1);
            this.panel1.Controls.Add(this.lblBaseCustom11);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.cboSectorEcon);
            this.panel1.Controls.Add(this.cboTipoEvaluacion);
            this.panel1.Controls.Add(this.lblBaseCustom5);
            this.panel1.Controls.Add(this.txtSaldoTotal);
            this.panel1.Controls.Add(this.lblBaseCustom12);
            this.panel1.Controls.Add(this.lblBaseCustom3);
            this.panel1.Controls.Add(this.txtAniosActv);
            this.panel1.Location = new System.Drawing.Point(330, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 251);
            this.panel1.TabIndex = 1;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(95, 3);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(107, 21);
            this.cboMoneda.TabIndex = 0;
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(655, 40);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 1;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(589, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(523, 497);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(655, 497);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelDG
            // 
            this.panelDG.Controls.Add(this.panel2);
            this.panelDG.Controls.Add(this.panelMenu);
            this.panelDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDG.Location = new System.Drawing.Point(0, 0);
            this.panelDG.Name = "panelDG";
            this.panelDG.Size = new System.Drawing.Size(705, 85);
            this.panelDG.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgSolicitud);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 61);
            this.panel2.TabIndex = 25;
            // 
            // dtgSolicitud
            // 
            this.dtgSolicitud.AllowUserToAddRows = false;
            this.dtgSolicitud.AllowUserToDeleteRows = false;
            this.dtgSolicitud.AllowUserToResizeColumns = false;
            this.dtgSolicitud.AllowUserToResizeRows = false;
            this.dtgSolicitud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitud.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgSolicitud.Location = new System.Drawing.Point(0, 0);
            this.dtgSolicitud.MultiSelect = false;
            this.dtgSolicitud.Name = "dtgSolicitud";
            this.dtgSolicitud.RowHeadersVisible = false;
            this.dtgSolicitud.Size = new System.Drawing.Size(705, 61);
            this.dtgSolicitud.TabIndex = 0;
            this.dtgSolicitud.TabStop = false;
            this.dtgSolicitud.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgSolicitud_KeyDown);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuStrip1);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(705, 24);
            this.panelMenu.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCancelar,
            this.tsmQuitar,
            this.tsmAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(200, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(505, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmCancelar
            // 
            this.tsmCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmCancelar.Enabled = false;
            this.tsmCancelar.Name = "tsmCancelar";
            this.tsmCancelar.Size = new System.Drawing.Size(12, 20);
            this.tsmCancelar.Text = "tsmCancelar";
            this.tsmCancelar.ToolTipText = "Cancelar edición.";
            this.tsmCancelar.Visible = false;
            // 
            // tsmQuitar
            // 
            this.tsmQuitar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmQuitar.Checked = true;
            this.tsmQuitar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmQuitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmQuitar.Enabled = false;
            this.tsmQuitar.Name = "tsmQuitar";
            this.tsmQuitar.Size = new System.Drawing.Size(12, 20);
            this.tsmQuitar.Text = "Quitar";
            this.tsmQuitar.ToolTipText = "Eliminar registro seleccionado.";
            this.tsmQuitar.Visible = false;
            // 
            // tsmAgregar
            // 
            this.tsmAgregar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmAgregar.Enabled = false;
            this.tsmAgregar.Name = "tsmAgregar";
            this.tsmAgregar.Size = new System.Drawing.Size(12, 20);
            this.tsmAgregar.Text = "Agregar";
            this.tsmAgregar.ToolTipText = "Agregar registro del formulario.";
            this.tsmAgregar.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Créditos Solicitados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.White;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(6, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(263, 24);
            this.miniToolStrip.TabIndex = 7;
            this.miniToolStrip.TabStop = true;
            // 
            // panelGlobal
            // 
            this.panelGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGlobal.Controls.Add(this.panelDG);
            this.panelGlobal.Location = new System.Drawing.Point(8, 95);
            this.panelGlobal.Name = "panelGlobal";
            this.panelGlobal.Size = new System.Drawing.Size(707, 87);
            this.panelGlobal.TabIndex = 108;
            // 
            // frmNuevaEvPyme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 573);
            this.Controls.Add(this.panelGlobal);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.grbCredProp);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmNuevaEvPyme";
            this.ShowInTaskbar = false;
            this.Text = "Nueva Evaluación";
            this.Load += new System.EventHandler(this.FrmNuevaEvPyme_Load);
            this.Shown += new System.EventHandler(this.FrmNuevaEvPyme_Shown);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbCredProp, 0);
            this.Controls.SetChildIndex(this.btnVincular, 0);
            this.Controls.SetChildIndex(this.panelGlobal, 0);
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grbCredProp.ResumeLayout(false);
            this.grbCredProp.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDG.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitud)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelGlobal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.txtNumRea txtSaldoTotal;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom16;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom3;
        private GEN.ControlesBase.cboBase cboTipoEvaluacion;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom5;
        private GEN.ControlesBase.txtNumRea txtAniosActv;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom12;
        private System.Windows.Forms.Button btnAgregar;
        private GEN.ControlesBase.cboBase cboSectorEcon;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom11;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
        private GEN.ControlesBase.cboActividadEco cboCIIU;
        private GEN.ControlesBase.cboActividadInterna cboActividadInterna;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.ControlesBase.ConCreditoTasa conCreditoTasa;
        private GEN.ControlesBase.grbBase grbCredProp;
        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.Panel panelDG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgSolicitud;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelar;
        private System.Windows.Forms.ToolStripMenuItem tsmQuitar;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.Panel panel1;
        private GEN.ControlesBase.cboMoneda cboMoneda;
    }
}