namespace CRE.Presentacion
{
    partial class frmCobAfectacionIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCobAfectacionIndividual));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnAgregaCobsTerceros = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtgCobs = new GEN.ControlesBase.dtgBase(this.components);
            this.txtMontoTotalCTA = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase19 = new GEN.ControlesBase.lblBase();
            this.lblBase18 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroCondonaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase23 = new GEN.ControlesBase.lblBase();
            this.lblBase21 = new GEN.ControlesBase.lblBase();
            this.txtAgencia = new GEN.ControlesBase.txtBase(this.components);
            this.txtMontoDesembolsado = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase20 = new GEN.ControlesBase.lblBase();
            this.txtAnioCastigo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.conProducto1 = new GEN.ControlesBase.conProducto();
            this.cboCondicionContVenc = new GEN.ControlesBase.cboCondicionContable(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.cboCondicionContNormal = new GEN.ControlesBase.cboCondicionContable(this.components);
            this.txtDiasAtraso = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.cboTipoAfectaciones1 = new GEN.ControlesBase.cboTipoAfectaciones(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbITF = new GEN.ControlesBase.grbBase(this.components);
            this.montoConItf = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase25 = new GEN.ControlesBase.lblBase();
            this.txtITF = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblConsolidado = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtComentario = new GEN.ControlesBase.txtBase(this.components);
            this.conBusCuentaCli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCobs)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbITF.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Controls.Add(this.grbBase1);
            this.conBusCuentaCli.Location = new System.Drawing.Point(0, 4);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(564, 98);
            this.conBusCuentaCli.TabIndex = 2;
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
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(435, 511);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(501, 511);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnAgregaCobsTerceros
            // 
            this.btnAgregaCobsTerceros.Location = new System.Drawing.Point(533, 326);
            this.btnAgregaCobsTerceros.Name = "btnAgregaCobsTerceros";
            this.btnAgregaCobsTerceros.Size = new System.Drawing.Size(24, 23);
            this.btnAgregaCobsTerceros.TabIndex = 64;
            this.btnAgregaCobsTerceros.Text = "+";
            this.btnAgregaCobsTerceros.UseVisualStyleBackColor = true;
            this.btnAgregaCobsTerceros.Click += new System.EventHandler(this.btnAgregaCobsTerceros_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(533, 293);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(24, 23);
            this.btnQuitar.TabIndex = 63;
            this.btnQuitar.Text = "-";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(533, 270);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 23);
            this.btnAgregar.TabIndex = 62;
            this.btnAgregar.Text = "A";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgCobs
            // 
            this.dtgCobs.AllowUserToAddRows = false;
            this.dtgCobs.AllowUserToDeleteRows = false;
            this.dtgCobs.AllowUserToResizeColumns = false;
            this.dtgCobs.AllowUserToResizeRows = false;
            this.dtgCobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgCobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCobs.Location = new System.Drawing.Point(3, 269);
            this.dtgCobs.MultiSelect = false;
            this.dtgCobs.Name = "dtgCobs";
            this.dtgCobs.ReadOnly = true;
            this.dtgCobs.RowHeadersVisible = false;
            this.dtgCobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCobs.Size = new System.Drawing.Size(529, 137);
            this.dtgCobs.TabIndex = 61;
            // 
            // txtMontoTotalCTA
            // 
            this.txtMontoTotalCTA.Format = "n2";
            this.txtMontoTotalCTA.Location = new System.Drawing.Point(123, 10);
            this.txtMontoTotalCTA.Name = "txtMontoTotalCTA";
            this.txtMontoTotalCTA.ReadOnly = true;
            this.txtMontoTotalCTA.Size = new System.Drawing.Size(113, 20);
            this.txtMontoTotalCTA.TabIndex = 58;
            this.txtMontoTotalCTA.Text = "0";
            // 
            // lblBase19
            // 
            this.lblBase19.AutoSize = true;
            this.lblBase19.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase19.ForeColor = System.Drawing.Color.Navy;
            this.lblBase19.Location = new System.Drawing.Point(3, 13);
            this.lblBase19.Name = "lblBase19";
            this.lblBase19.Size = new System.Drawing.Size(116, 13);
            this.lblBase19.TabIndex = 60;
            this.lblBase19.Text = "Monto Total COB\'s:";
            // 
            // lblBase18
            // 
            this.lblBase18.AutoSize = true;
            this.lblBase18.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase18.ForeColor = System.Drawing.Color.Navy;
            this.lblBase18.Location = new System.Drawing.Point(12, 253);
            this.lblBase18.Name = "lblBase18";
            this.lblBase18.Size = new System.Drawing.Size(42, 13);
            this.lblBase18.TabIndex = 59;
            this.lblBase18.Text = "COB\'s";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtNroCondonaciones);
            this.grbBase2.Controls.Add(this.lblBase23);
            this.grbBase2.Controls.Add(this.lblBase21);
            this.grbBase2.Controls.Add(this.txtAgencia);
            this.grbBase2.Controls.Add(this.txtMontoDesembolsado);
            this.grbBase2.Controls.Add(this.cboMoneda1);
            this.grbBase2.Controls.Add(this.lblBase20);
            this.grbBase2.Controls.Add(this.txtAnioCastigo);
            this.grbBase2.Controls.Add(this.lblBase17);
            this.grbBase2.Controls.Add(this.conProducto1);
            this.grbBase2.Controls.Add(this.cboCondicionContVenc);
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.Controls.Add(this.cboCondicionContNormal);
            this.grbBase2.Controls.Add(this.txtDiasAtraso);
            this.grbBase2.Controls.Add(this.lblBase13);
            this.grbBase2.Controls.Add(this.lblBase14);
            this.grbBase2.Location = new System.Drawing.Point(3, 105);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(554, 144);
            this.grbBase2.TabIndex = 65;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Cuenta";
            // 
            // txtNroCondonaciones
            // 
            this.txtNroCondonaciones.Enabled = false;
            this.txtNroCondonaciones.Location = new System.Drawing.Point(130, 117);
            this.txtNroCondonaciones.Name = "txtNroCondonaciones";
            this.txtNroCondonaciones.Size = new System.Drawing.Size(61, 20);
            this.txtNroCondonaciones.TabIndex = 27;
            // 
            // lblBase23
            // 
            this.lblBase23.AutoSize = true;
            this.lblBase23.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase23.ForeColor = System.Drawing.Color.Navy;
            this.lblBase23.Location = new System.Drawing.Point(5, 120);
            this.lblBase23.Name = "lblBase23";
            this.lblBase23.Size = new System.Drawing.Size(123, 13);
            this.lblBase23.TabIndex = 26;
            this.lblBase23.Text = "Nro Condonaciones:";
            // 
            // lblBase21
            // 
            this.lblBase21.AutoSize = true;
            this.lblBase21.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase21.ForeColor = System.Drawing.Color.Navy;
            this.lblBase21.Location = new System.Drawing.Point(334, 82);
            this.lblBase21.Name = "lblBase21";
            this.lblBase21.Size = new System.Drawing.Size(51, 13);
            this.lblBase21.TabIndex = 25;
            this.lblBase21.Text = "Oficina:";
            // 
            // txtAgencia
            // 
            this.txtAgencia.Enabled = false;
            this.txtAgencia.Location = new System.Drawing.Point(333, 96);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(208, 20);
            this.txtAgencia.TabIndex = 24;
            // 
            // txtMontoDesembolsado
            // 
            this.txtMontoDesembolsado.Enabled = false;
            this.txtMontoDesembolsado.FormatoDecimal = false;
            this.txtMontoDesembolsado.Location = new System.Drawing.Point(205, 93);
            this.txtMontoDesembolsado.Name = "txtMontoDesembolsado";
            this.txtMontoDesembolsado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoDesembolsado.nNumDecimales = 4;
            this.txtMontoDesembolsado.nvalor = 0D;
            this.txtMontoDesembolsado.Size = new System.Drawing.Size(112, 20);
            this.txtMontoDesembolsado.TabIndex = 23;
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(98, 92);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(101, 21);
            this.cboMoneda1.TabIndex = 22;
            // 
            // lblBase20
            // 
            this.lblBase20.AutoSize = true;
            this.lblBase20.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase20.ForeColor = System.Drawing.Color.Navy;
            this.lblBase20.Location = new System.Drawing.Point(5, 95);
            this.lblBase20.Name = "lblBase20";
            this.lblBase20.Size = new System.Drawing.Size(92, 13);
            this.lblBase20.TabIndex = 21;
            this.lblBase20.Text = "Mont desemb.:";
            // 
            // txtAnioCastigo
            // 
            this.txtAnioCastigo.Enabled = false;
            this.txtAnioCastigo.FormatoDecimal = false;
            this.txtAnioCastigo.Location = new System.Drawing.Point(267, 68);
            this.txtAnioCastigo.Name = "txtAnioCastigo";
            this.txtAnioCastigo.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAnioCastigo.nNumDecimales = 4;
            this.txtAnioCastigo.nvalor = 0D;
            this.txtAnioCastigo.Size = new System.Drawing.Size(50, 20);
            this.txtAnioCastigo.TabIndex = 20;
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(184, 71);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(81, 13);
            this.lblBase17.TabIndex = 19;
            this.lblBase17.Text = "Año Castigo:";
            // 
            // conProducto1
            // 
            this.conProducto1.AutoSize = true;
            this.conProducto1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conProducto1.Enabled = false;
            this.conProducto1.lBloquear3Niveles = true;
            this.conProducto1.lMostrarTipoCredito = false;
            this.conProducto1.Location = new System.Drawing.Point(-1, 19);
            this.conProducto1.Name = "conProducto1";
            this.conProducto1.Size = new System.Drawing.Size(322, 46);
            this.conProducto1.TabIndex = 4;
            // 
            // cboCondicionContVenc
            // 
            this.cboCondicionContVenc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionContVenc.Enabled = false;
            this.cboCondicionContVenc.FormattingEnabled = true;
            this.cboCondicionContVenc.Location = new System.Drawing.Point(333, 61);
            this.cboCondicionContVenc.Name = "cboCondicionContVenc";
            this.cboCondicionContVenc.Size = new System.Drawing.Size(208, 21);
            this.cboCondicionContVenc.TabIndex = 18;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(332, 46);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(136, 13);
            this.lblBase15.TabIndex = 17;
            this.lblBase15.Text = "Cond. Contable Venc.:";
            // 
            // cboCondicionContNormal
            // 
            this.cboCondicionContNormal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionContNormal.Enabled = false;
            this.cboCondicionContNormal.FormattingEnabled = true;
            this.cboCondicionContNormal.Location = new System.Drawing.Point(333, 24);
            this.cboCondicionContNormal.Name = "cboCondicionContNormal";
            this.cboCondicionContNormal.Size = new System.Drawing.Size(208, 21);
            this.cboCondicionContNormal.TabIndex = 16;
            // 
            // txtDiasAtraso
            // 
            this.txtDiasAtraso.Enabled = false;
            this.txtDiasAtraso.FormatoDecimal = false;
            this.txtDiasAtraso.Location = new System.Drawing.Point(98, 68);
            this.txtDiasAtraso.Name = "txtDiasAtraso";
            this.txtDiasAtraso.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiasAtraso.nNumDecimales = 4;
            this.txtDiasAtraso.nvalor = 0D;
            this.txtDiasAtraso.Size = new System.Drawing.Size(50, 20);
            this.txtDiasAtraso.TabIndex = 15;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(20, 71);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(77, 13);
            this.lblBase13.TabIndex = 14;
            this.lblBase13.Text = "Días atraso:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(332, 8);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(146, 13);
            this.lblBase14.TabIndex = 14;
            this.lblBase14.Text = "Cond. Contable Normal:";
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(369, 511);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 66;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // cboTipoAfectaciones1
            // 
            this.cboTipoAfectaciones1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAfectaciones1.FormattingEnabled = true;
            this.cboTipoAfectaciones1.Location = new System.Drawing.Point(158, 422);
            this.cboTipoAfectaciones1.Name = "cboTipoAfectaciones1";
            this.cboTipoAfectaciones1.Size = new System.Drawing.Size(151, 21);
            this.cboTipoAfectaciones1.TabIndex = 67;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(35, 425);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(117, 13);
            this.lblBase1.TabIndex = 68;
            this.lblBase1.Text = "Tipo de Afectación:";
            // 
            // grbITF
            // 
            this.grbITF.Controls.Add(this.montoConItf);
            this.grbITF.Controls.Add(this.lblBase2);
            this.grbITF.Controls.Add(this.lblBase25);
            this.grbITF.Controls.Add(this.txtMontoTotalCTA);
            this.grbITF.Controls.Add(this.lblBase19);
            this.grbITF.Controls.Add(this.txtITF);
            this.grbITF.Location = new System.Drawing.Point(315, 417);
            this.grbITF.Name = "grbITF";
            this.grbITF.Size = new System.Drawing.Size(242, 86);
            this.grbITF.TabIndex = 69;
            this.grbITF.TabStop = false;
            // 
            // montoConItf
            // 
            this.montoConItf.Location = new System.Drawing.Point(123, 63);
            this.montoConItf.Name = "montoConItf";
            this.montoConItf.ReadOnly = true;
            this.montoConItf.Size = new System.Drawing.Size(113, 20);
            this.montoConItf.TabIndex = 62;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(23, 66);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(94, 13);
            this.lblBase2.TabIndex = 61;
            this.lblBase2.Text = "Monto a Pagar:";
            // 
            // lblBase25
            // 
            this.lblBase25.AutoSize = true;
            this.lblBase25.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase25.ForeColor = System.Drawing.Color.Navy;
            this.lblBase25.Location = new System.Drawing.Point(83, 39);
            this.lblBase25.Name = "lblBase25";
            this.lblBase25.Size = new System.Drawing.Size(32, 13);
            this.lblBase25.TabIndex = 59;
            this.lblBase25.Text = "ITF.:";
            // 
            // txtITF
            // 
            this.txtITF.FormatoDecimal = false;
            this.txtITF.Location = new System.Drawing.Point(123, 36);
            this.txtITF.Name = "txtITF";
            this.txtITF.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtITF.nNumDecimales = 4;
            this.txtITF.nvalor = 0D;
            this.txtITF.ReadOnly = true;
            this.txtITF.Size = new System.Drawing.Size(113, 20);
            this.txtITF.TabIndex = 58;
            // 
            // lblConsolidado
            // 
            this.lblConsolidado.AutoSize = true;
            this.lblConsolidado.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblConsolidado.ForeColor = System.Drawing.Color.Red;
            this.lblConsolidado.Location = new System.Drawing.Point(19, 408);
            this.lblConsolidado.Name = "lblConsolidado";
            this.lblConsolidado.Size = new System.Drawing.Size(0, 13);
            this.lblConsolidado.TabIndex = 70;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(14, 453);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(79, 13);
            this.lblBase8.TabIndex = 72;
            this.lblBase8.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(99, 451);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(210, 52);
            this.txtComentario.TabIndex = 71;
            // 
            // frmCobAfectacionIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 587);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblConsolidado);
            this.Controls.Add(this.grbITF);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoAfectaciones1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnAgregaCobsTerceros);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtgCobs);
            this.Controls.Add(this.lblBase18);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusCuentaCli);
            this.Name = "frmCobAfectacionIndividual";
            this.Text = "Afectación de COB\'s Individual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCobAfectacionIndividual_FormClosing);
            this.Load += new System.EventHandler(this.frmCobAfectacionIndividual_Load);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase18, 0);
            this.Controls.SetChildIndex(this.dtgCobs, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.btnAgregaCobsTerceros, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.cboTipoAfectaciones1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.grbITF, 0);
            this.Controls.SetChildIndex(this.lblConsolidado, 0);
            this.Controls.SetChildIndex(this.txtComentario, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.conBusCuentaCli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCobs)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbITF.ResumeLayout(false);
            this.grbITF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.Button btnAgregaCobsTerceros;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private GEN.ControlesBase.dtgBase dtgCobs;
        private GEN.ControlesBase.txtNumerico txtMontoTotalCTA;
        private GEN.ControlesBase.lblBase lblBase19;
        private GEN.ControlesBase.lblBase lblBase18;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtNroCondonaciones;
        private GEN.ControlesBase.lblBase lblBase23;
        private GEN.ControlesBase.lblBase lblBase21;
        private GEN.ControlesBase.txtBase txtAgencia;
        private GEN.ControlesBase.txtNumRea txtMontoDesembolsado;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase20;
        private GEN.ControlesBase.txtNumRea txtAnioCastigo;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.conProducto conProducto1;
        private GEN.ControlesBase.cboCondicionContable cboCondicionContVenc;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.cboCondicionContable cboCondicionContNormal;
        private GEN.ControlesBase.txtNumRea txtDiasAtraso;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.ControlesBase.cboTipoAfectaciones cboTipoAfectaciones1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbITF;
        private GEN.ControlesBase.lblBase lblBase25;
        private GEN.ControlesBase.txtNumRea txtITF;
        private GEN.ControlesBase.txtBase montoConItf;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBaseCustom lblConsolidado;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtComentario;
    }
}