namespace CRE.Presentacion
{
    partial class frmCambioGarantias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioGarantias));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.txtMonSoli = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.txtGravamen = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.cboSubPro = new GEN.ControlesBase.cboProducto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtPorAfe = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgGarantias = new GEN.ControlesBase.dtgBase(this.components);
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.btnActualizar = new GEN.BotonesBase.btnActualizar();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtgIntervinientes = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgGarantiasCli = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtTotMonGar = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotPorcentaje = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblMontoGrarantia = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.pbxAyuda1 = new GEN.ControlesBase.pbxAyuda();
            this.ttpMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.grbVinculacion = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantiasCli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).BeginInit();
            this.grbVinculacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCuentaCli.Location = new System.Drawing.Point(117, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(556, 73);
            this.conBusCuentaCli.TabIndex = 2;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // txtMonSoli
            // 
            this.txtMonSoli.Enabled = false;
            this.txtMonSoli.FormatoDecimal = false;
            this.txtMonSoli.Location = new System.Drawing.Point(116, 92);
            this.txtMonSoli.Name = "txtMonSoli";
            this.txtMonSoli.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonSoli.nNumDecimales = 4;
            this.txtMonSoli.nvalor = 0D;
            this.txtMonSoli.Size = new System.Drawing.Size(140, 20);
            this.txtMonSoli.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 96);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(88, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Saldo Capital:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 120);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(116, 117);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(140, 21);
            this.cboMoneda.TabIndex = 10;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(405, 96);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(62, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Producto:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Enabled = false;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(494, 93);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(252, 21);
            this.cboProducto.TabIndex = 12;
            // 
            // txtGravamen
            // 
            this.txtGravamen.BackColor = System.Drawing.Color.SkyBlue;
            this.txtGravamen.Enabled = false;
            this.txtGravamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGravamen.FormatoDecimal = false;
            this.txtGravamen.Location = new System.Drawing.Point(563, 168);
            this.txtGravamen.Name = "txtGravamen";
            this.txtGravamen.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGravamen.nNumDecimales = 2;
            this.txtGravamen.nvalor = 0D;
            this.txtGravamen.Size = new System.Drawing.Size(103, 26);
            this.txtGravamen.TabIndex = 13;
            this.txtGravamen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGravamen.TextChanged += new System.EventHandler(this.txtGravamen_TextChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(613, 561);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 15;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir1.Location = new System.Drawing.Point(743, 561);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 16;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // cboSubPro
            // 
            this.cboSubPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubPro.Enabled = false;
            this.cboSubPro.FormattingEnabled = true;
            this.cboSubPro.Location = new System.Drawing.Point(494, 117);
            this.cboSubPro.Name = "cboSubPro";
            this.cboSubPro.Size = new System.Drawing.Size(252, 21);
            this.cboSubPro.TabIndex = 18;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Enabled = false;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(405, 120);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(88, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Sub Producto:";
            // 
            // txtPorAfe
            // 
            this.txtPorAfe.Enabled = false;
            this.txtPorAfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorAfe.FormatoDecimal = false;
            this.txtPorAfe.Location = new System.Drawing.Point(563, 198);
            this.txtPorAfe.Name = "txtPorAfe";
            this.txtPorAfe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorAfe.nNumDecimales = 2;
            this.txtPorAfe.nvalor = 0D;
            this.txtPorAfe.Size = new System.Drawing.Size(103, 26);
            this.txtPorAfe.TabIndex = 19;
            this.txtPorAfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Enabled = false;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(485, 206);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(64, 13);
            this.lblBase4.TabIndex = 20;
            this.lblBase4.Text = "% Afecta:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Enabled = false;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(377, 176);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(180, 13);
            this.lblBase6.TabIndex = 21;
            this.lblBase6.Text = "Monto que cubrirá la garantía:";
            // 
            // dtgGarantias
            // 
            this.dtgGarantias.AllowUserToAddRows = false;
            this.dtgGarantias.AllowUserToDeleteRows = false;
            this.dtgGarantias.AllowUserToResizeColumns = false;
            this.dtgGarantias.AllowUserToResizeRows = false;
            this.dtgGarantias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantias.Location = new System.Drawing.Point(13, 372);
            this.dtgGarantias.MultiSelect = false;
            this.dtgGarantias.Name = "dtgGarantias";
            this.dtgGarantias.ReadOnly = true;
            this.dtgGarantias.RowHeadersVisible = false;
            this.dtgGarantias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantias.Size = new System.Drawing.Size(804, 149);
            this.dtgGarantias.TabIndex = 23;
            this.dtgGarantias.SelectionChanged += new System.EventHandler(this.dtgGarantias_SelectionChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(752, 169);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 24;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar.Location = new System.Drawing.Point(686, 169);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar.TabIndex = 26;
            this.btnActualizar.Text = "Asi&gnar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.texto = "Asi&gnar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(5, 10);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(91, 13);
            this.lblBase7.TabIndex = 28;
            this.lblBase7.Text = "Intervinientes:";
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Location = new System.Drawing.Point(8, 26);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(385, 136);
            this.dtgIntervinientes.TabIndex = 29;
            this.dtgIntervinientes.SelectionChanged += new System.EventHandler(this.dtgIntervinientes_SelectionChanged);
            // 
            // dtgGarantiasCli
            // 
            this.dtgGarantiasCli.AllowUserToAddRows = false;
            this.dtgGarantiasCli.AllowUserToDeleteRows = false;
            this.dtgGarantiasCli.AllowUserToResizeColumns = false;
            this.dtgGarantiasCli.AllowUserToResizeRows = false;
            this.dtgGarantiasCli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGarantiasCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGarantiasCli.Location = new System.Drawing.Point(399, 26);
            this.dtgGarantiasCli.MultiSelect = false;
            this.dtgGarantiasCli.Name = "dtgGarantiasCli";
            this.dtgGarantiasCli.ReadOnly = true;
            this.dtgGarantiasCli.RowHeadersVisible = false;
            this.dtgGarantiasCli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGarantiasCli.Size = new System.Drawing.Size(413, 136);
            this.dtgGarantiasCli.TabIndex = 30;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(396, 10);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(268, 13);
            this.lblBase8.TabIndex = 31;
            this.lblBase8.Text = "Garantías del Interviniente a favor del titular:";
            // 
            // txtTotMonGar
            // 
            this.txtTotMonGar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotMonGar.FormatoDecimal = false;
            this.txtTotMonGar.Location = new System.Drawing.Point(605, 526);
            this.txtTotMonGar.Name = "txtTotMonGar";
            this.txtTotMonGar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotMonGar.nNumDecimales = 4;
            this.txtTotMonGar.nvalor = 0D;
            this.txtTotMonGar.ReadOnly = true;
            this.txtTotMonGar.Size = new System.Drawing.Size(106, 20);
            this.txtTotMonGar.TabIndex = 32;
            this.txtTotMonGar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotPorcentaje
            // 
            this.txtTotPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotPorcentaje.FormatoDecimal = false;
            this.txtTotPorcentaje.Location = new System.Drawing.Point(712, 526);
            this.txtTotPorcentaje.Name = "txtTotPorcentaje";
            this.txtTotPorcentaje.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotPorcentaje.nNumDecimales = 4;
            this.txtTotPorcentaje.nvalor = 0D;
            this.txtTotPorcentaje.ReadOnly = true;
            this.txtTotPorcentaje.Size = new System.Drawing.Size(103, 20);
            this.txtTotPorcentaje.TabIndex = 32;
            this.txtTotPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(673, 561);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMontoGrarantia
            // 
            this.lblMontoGrarantia.AutoSize = true;
            this.lblMontoGrarantia.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMontoGrarantia.ForeColor = System.Drawing.Color.Navy;
            this.lblMontoGrarantia.Location = new System.Drawing.Point(372, 529);
            this.lblMontoGrarantia.Name = "lblMontoGrarantia";
            this.lblMontoGrarantia.Size = new System.Drawing.Size(229, 13);
            this.lblMontoGrarantia.TabIndex = 34;
            this.lblMontoGrarantia.Text = "Suma de garantías debe de ser: 100%";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(553, 561);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 35;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(493, 561);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 36;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // pbxAyuda1
            // 
            this.pbxAyuda1.Image = ((System.Drawing.Image)(resources.GetObject("pbxAyuda1.Image")));
            this.pbxAyuda1.Location = new System.Drawing.Point(795, 12);
            this.pbxAyuda1.Name = "pbxAyuda1";
            this.pbxAyuda1.Size = new System.Drawing.Size(20, 20);
            this.pbxAyuda1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAyuda1.TabIndex = 37;
            this.pbxAyuda1.TabStop = false;
            this.ttpMensaje.SetToolTip(this.pbxAyuda1, "Recordar que solo se lista garantías a favor del Cliente Titular\r\nPara agregar re" +
        "gistre desde la opcion de Registro de Garantía.");
            this.pbxAyuda1.Click += new System.EventHandler(this.pbxAyuda_Click);
            // 
            // ttpMensaje
            // 
            this.ttpMensaje.IsBalloon = true;
            // 
            // grbVinculacion
            // 
            this.grbVinculacion.Controls.Add(this.dtgGarantiasCli);
            this.grbVinculacion.Controls.Add(this.txtGravamen);
            this.grbVinculacion.Controls.Add(this.txtPorAfe);
            this.grbVinculacion.Controls.Add(this.lblBase4);
            this.grbVinculacion.Controls.Add(this.lblBase6);
            this.grbVinculacion.Controls.Add(this.btnQuitar);
            this.grbVinculacion.Controls.Add(this.btnActualizar);
            this.grbVinculacion.Controls.Add(this.lblBase7);
            this.grbVinculacion.Controls.Add(this.lblBase8);
            this.grbVinculacion.Controls.Add(this.dtgIntervinientes);
            this.grbVinculacion.Enabled = false;
            this.grbVinculacion.Location = new System.Drawing.Point(7, 140);
            this.grbVinculacion.Name = "grbVinculacion";
            this.grbVinculacion.Size = new System.Drawing.Size(828, 229);
            this.grbVinculacion.TabIndex = 38;
            this.grbVinculacion.TabStop = false;
            // 
            // frmCambioGarantias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir1;
            this.ClientSize = new System.Drawing.Size(832, 636);
            this.Controls.Add(this.grbVinculacion);
            this.Controls.Add(this.pbxAyuda1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblMontoGrarantia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtTotPorcentaje);
            this.Controls.Add(this.txtTotMonGar);
            this.Controls.Add(this.dtgGarantias);
            this.Controls.Add(this.cboSubPro);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtMonSoli);
            this.Controls.Add(this.conBusCuentaCli);
            this.Name = "frmCambioGarantias";
            this.Text = "Cambio de Garantías";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCambioGarantias_FormClosed);
            this.Load += new System.EventHandler(this.frmVincularGarantia_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.txtMonSoli, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboProducto, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboSubPro, 0);
            this.Controls.SetChildIndex(this.dtgGarantias, 0);
            this.Controls.SetChildIndex(this.txtTotMonGar, 0);
            this.Controls.SetChildIndex(this.txtTotPorcentaje, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblMontoGrarantia, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.pbxAyuda1, 0);
            this.Controls.SetChildIndex(this.grbVinculacion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGarantiasCli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAyuda1)).EndInit();
            this.grbVinculacion.ResumeLayout(false);
            this.grbVinculacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.txtNumRea txtMonSoli;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.txtNumRea txtGravamen;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.cboProducto cboSubPro;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtPorAfe;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtgBase dtgGarantias;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.BotonesBase.btnActualizar btnActualizar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtgBase dtgIntervinientes;
        private GEN.ControlesBase.dtgBase dtgGarantiasCli;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtTotMonGar;
        private GEN.ControlesBase.txtNumRea txtTotPorcentaje;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblMontoGrarantia;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.pbxAyuda pbxAyuda1;
        private System.Windows.Forms.ToolTip ttpMensaje;
        private GEN.ControlesBase.grbBase grbVinculacion;

    }
}

