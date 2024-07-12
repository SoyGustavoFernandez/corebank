namespace CRE.Presentacion
{
    partial class frmScoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScoring));
            this.grbDocumento = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNroDocumento = new GEN.ControlesBase.txtCBDNI(this.components);
            this.btnMiniAceptar1 = new GEN.BotonesBase.btnMiniAceptar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chcBancarizado = new System.Windows.Forms.CheckBox();
            this.txtTipoCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombres = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbDatosAdicionales = new GEN.ControlesBase.grbBase(this.components);
            this.lblMaxPlazo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblMaxMonto = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.txtObligacionesFinancieras = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtExcedente = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPlazo = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtMontoSolicitado = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.chcFormalizado = new GEN.ControlesBase.chcBase(this.components);
            this.cboDestinoCredito = new GEN.ControlesBase.cboDestinoCredito(this.components);
            this.txtExperienciaNegocio = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtCodigoUbigeo = new GEN.ControlesBase.txtBase(this.components);
            this.txtEdad = new GEN.ControlesBase.txtNumerico(this.components);
            this.cboEstadoCivil = new GEN.ControlesBase.cboEstadoCivil(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblMensaje = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnRegInfCli = new GEN.BotonesBase.btnBlanco();
            this.grbDocumento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbDatosAdicionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDocumento
            // 
            this.grbDocumento.Controls.Add(this.lblBase1);
            this.grbDocumento.Controls.Add(this.txtNroDocumento);
            this.grbDocumento.Controls.Add(this.btnMiniAceptar1);
            this.grbDocumento.Location = new System.Drawing.Point(35, 13);
            this.grbDocumento.Name = "grbDocumento";
            this.grbDocumento.Size = new System.Drawing.Size(312, 51);
            this.grbDocumento.TabIndex = 0;
            this.grbDocumento.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(137, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Número de documento";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(159, 19);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtNroDocumento.TabIndex = 0;
            this.txtNroDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroDocumento_KeyDown);
            // 
            // btnMiniAceptar1
            // 
            this.btnMiniAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAceptar1.BackgroundImage")));
            this.btnMiniAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAceptar1.Location = new System.Drawing.Point(265, 17);
            this.btnMiniAceptar1.Name = "btnMiniAceptar1";
            this.btnMiniAceptar1.Size = new System.Drawing.Size(24, 22);
            this.btnMiniAceptar1.TabIndex = 1;
            this.btnMiniAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAceptar1.UseVisualStyleBackColor = true;
            this.btnMiniAceptar1.Click += new System.EventHandler(this.btnMiniAceptar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chcBancarizado);
            this.groupBox1.Controls.Add(this.txtTipoCliente);
            this.groupBox1.Controls.Add(this.txtNombres);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la persona";
            // 
            // chcBancarizado
            // 
            this.chcBancarizado.AutoSize = true;
            this.chcBancarizado.Enabled = false;
            this.chcBancarizado.Location = new System.Drawing.Point(155, 75);
            this.chcBancarizado.Name = "chcBancarizado";
            this.chcBancarizado.Size = new System.Drawing.Size(85, 17);
            this.chcBancarizado.TabIndex = 2;
            this.chcBancarizado.Text = "Bancarizado";
            this.chcBancarizado.UseVisualStyleBackColor = true;
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Enabled = false;
            this.txtTipoCliente.Location = new System.Drawing.Point(155, 49);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Size = new System.Drawing.Size(239, 20);
            this.txtTipoCliente.TabIndex = 1;
            // 
            // txtNombres
            // 
            this.txtNombres.Enabled = false;
            this.txtNombres.Location = new System.Drawing.Point(155, 26);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(239, 20);
            this.txtNombres.TabIndex = 0;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(59, 52);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(90, 13);
            this.lblBase3.TabIndex = 1;
            this.lblBase3.Text = "Tipo de cliente";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(134, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Nombre de la persona";
            // 
            // grbDatosAdicionales
            // 
            this.grbDatosAdicionales.Controls.Add(this.lblMaxPlazo);
            this.grbDatosAdicionales.Controls.Add(this.lblMaxMonto);
            this.grbDatosAdicionales.Controls.Add(this.btnProcesar1);
            this.grbDatosAdicionales.Controls.Add(this.txtObligacionesFinancieras);
            this.grbDatosAdicionales.Controls.Add(this.txtExcedente);
            this.grbDatosAdicionales.Controls.Add(this.txtPlazo);
            this.grbDatosAdicionales.Controls.Add(this.txtMontoSolicitado);
            this.grbDatosAdicionales.Controls.Add(this.lblBase12);
            this.grbDatosAdicionales.Controls.Add(this.lblBase11);
            this.grbDatosAdicionales.Controls.Add(this.lblBase10);
            this.grbDatosAdicionales.Controls.Add(this.lblBase9);
            this.grbDatosAdicionales.Controls.Add(this.chcFormalizado);
            this.grbDatosAdicionales.Controls.Add(this.cboDestinoCredito);
            this.grbDatosAdicionales.Controls.Add(this.txtExperienciaNegocio);
            this.grbDatosAdicionales.Controls.Add(this.txtCodigoUbigeo);
            this.grbDatosAdicionales.Controls.Add(this.txtEdad);
            this.grbDatosAdicionales.Controls.Add(this.cboEstadoCivil);
            this.grbDatosAdicionales.Controls.Add(this.lblBase8);
            this.grbDatosAdicionales.Controls.Add(this.lblBase7);
            this.grbDatosAdicionales.Controls.Add(this.lblBase6);
            this.grbDatosAdicionales.Controls.Add(this.lblBase5);
            this.grbDatosAdicionales.Controls.Add(this.lblBase4);
            this.grbDatosAdicionales.Location = new System.Drawing.Point(12, 175);
            this.grbDatosAdicionales.Name = "grbDatosAdicionales";
            this.grbDatosAdicionales.Size = new System.Drawing.Size(414, 261);
            this.grbDatosAdicionales.TabIndex = 2;
            this.grbDatosAdicionales.TabStop = false;
            this.grbDatosAdicionales.Text = "Datos adicionales";
            // 
            // lblMaxPlazo
            // 
            this.lblMaxPlazo.AutoSize = true;
            this.lblMaxPlazo.Font = new System.Drawing.Font("Arial", 8F);
            this.lblMaxPlazo.ForeColor = System.Drawing.Color.Green;
            this.lblMaxPlazo.Location = new System.Drawing.Point(304, 182);
            this.lblMaxPlazo.Name = "lblMaxPlazo";
            this.lblMaxPlazo.Size = new System.Drawing.Size(84, 14);
            this.lblMaxPlazo.TabIndex = 18;
            this.lblMaxPlazo.Text = "lblBaseCustom1";
            // 
            // lblMaxMonto
            // 
            this.lblMaxMonto.AutoSize = true;
            this.lblMaxMonto.Font = new System.Drawing.Font("Arial", 8F);
            this.lblMaxMonto.ForeColor = System.Drawing.Color.Green;
            this.lblMaxMonto.Location = new System.Drawing.Point(304, 154);
            this.lblMaxMonto.Name = "lblMaxMonto";
            this.lblMaxMonto.Size = new System.Drawing.Size(84, 14);
            this.lblMaxMonto.TabIndex = 8;
            this.lblMaxMonto.Text = "lblBaseCustom1";
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(315, 198);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 17;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // txtObligacionesFinancieras
            // 
            this.txtObligacionesFinancieras.FormatoDecimal = false;
            this.txtObligacionesFinancieras.Location = new System.Drawing.Point(183, 228);
            this.txtObligacionesFinancieras.Name = "txtObligacionesFinancieras";
            this.txtObligacionesFinancieras.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtObligacionesFinancieras.nNumDecimales = 4;
            this.txtObligacionesFinancieras.nvalor = 0D;
            this.txtObligacionesFinancieras.Size = new System.Drawing.Size(122, 20);
            this.txtObligacionesFinancieras.TabIndex = 9;
            // 
            // txtExcedente
            // 
            this.txtExcedente.FormatoDecimal = false;
            this.txtExcedente.Location = new System.Drawing.Point(183, 202);
            this.txtExcedente.Name = "txtExcedente";
            this.txtExcedente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtExcedente.nNumDecimales = 4;
            this.txtExcedente.nvalor = 0D;
            this.txtExcedente.Size = new System.Drawing.Size(122, 20);
            this.txtExcedente.TabIndex = 8;
            // 
            // txtPlazo
            // 
            this.txtPlazo.Format = "n2";
            this.txtPlazo.Location = new System.Drawing.Point(183, 177);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.Size = new System.Drawing.Size(123, 20);
            this.txtPlazo.TabIndex = 7;
            // 
            // txtMontoSolicitado
            // 
            this.txtMontoSolicitado.FormatoDecimal = false;
            this.txtMontoSolicitado.Location = new System.Drawing.Point(184, 151);
            this.txtMontoSolicitado.Name = "txtMontoSolicitado";
            this.txtMontoSolicitado.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoSolicitado.nNumDecimales = 4;
            this.txtMontoSolicitado.nvalor = 0D;
            this.txtMontoSolicitado.Size = new System.Drawing.Size(122, 20);
            this.txtMontoSolicitado.TabIndex = 6;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(28, 231);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(150, 13);
            this.lblBase12.TabIndex = 16;
            this.lblBase12.Text = "Obligaciones financieras:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(107, 205);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(71, 13);
            this.lblBase11.TabIndex = 15;
            this.lblBase11.Text = "Excedente:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(136, 180);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(42, 13);
            this.lblBase10.TabIndex = 14;
            this.lblBase10.Text = "Plazo:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(75, 154);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(103, 13);
            this.lblBase9.TabIndex = 13;
            this.lblBase9.Text = "Monto solicitado:";
            // 
            // chcFormalizado
            // 
            this.chcFormalizado.AutoSize = true;
            this.chcFormalizado.Location = new System.Drawing.Point(312, 100);
            this.chcFormalizado.Name = "chcFormalizado";
            this.chcFormalizado.Size = new System.Drawing.Size(82, 17);
            this.chcFormalizado.TabIndex = 4;
            this.chcFormalizado.Text = "Formalizado";
            this.chcFormalizado.UseVisualStyleBackColor = true;
            // 
            // cboDestinoCredito
            // 
            this.cboDestinoCredito.FormattingEnabled = true;
            this.cboDestinoCredito.Location = new System.Drawing.Point(184, 124);
            this.cboDestinoCredito.Name = "cboDestinoCredito";
            this.cboDestinoCredito.Size = new System.Drawing.Size(210, 21);
            this.cboDestinoCredito.TabIndex = 5;
            // 
            // txtExperienciaNegocio
            // 
            this.txtExperienciaNegocio.Format = "n2";
            this.txtExperienciaNegocio.Location = new System.Drawing.Point(184, 98);
            this.txtExperienciaNegocio.Name = "txtExperienciaNegocio";
            this.txtExperienciaNegocio.Size = new System.Drawing.Size(122, 20);
            this.txtExperienciaNegocio.TabIndex = 3;
            // 
            // txtCodigoUbigeo
            // 
            this.txtCodigoUbigeo.Location = new System.Drawing.Point(184, 72);
            this.txtCodigoUbigeo.Name = "txtCodigoUbigeo";
            this.txtCodigoUbigeo.Size = new System.Drawing.Size(122, 20);
            this.txtCodigoUbigeo.TabIndex = 2;
            // 
            // txtEdad
            // 
            this.txtEdad.Format = "n2";
            this.txtEdad.Location = new System.Drawing.Point(183, 46);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(123, 20);
            this.txtEdad.TabIndex = 1;
            // 
            // cboEstadoCivil
            // 
            this.cboEstadoCivil.FormattingEnabled = true;
            this.cboEstadoCivil.Location = new System.Drawing.Point(183, 19);
            this.cboEstadoCivil.Name = "cboEstadoCivil";
            this.cboEstadoCivil.Size = new System.Drawing.Size(211, 21);
            this.cboEstadoCivil.TabIndex = 0;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(59, 127);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(119, 13);
            this.lblBase8.TabIndex = 4;
            this.lblBase8.Text = "Destino del crédito:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(20, 101);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(158, 13);
            this.lblBase7.TabIndex = 3;
            this.lblBase7.Text = "Experiencia en el negocio:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(58, 75);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(120, 13);
            this.lblBase6.TabIndex = 2;
            this.lblBase6.Text = "Código ubigeo DNI:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(138, 49);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(40, 13);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Edad:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(102, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(76, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Estado civil:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(366, 14);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMensaje.Location = new System.Drawing.Point(27, 451);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(108, 14);
            this.lblMensaje.TabIndex = 6;
            this.lblMensaje.Text = "lblBaseCustom1";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(450, 95);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBase1.Size = new System.Drawing.Size(255, 341);
            this.dtgBase1.TabIndex = 7;
            // 
            // btnRegInfCli
            // 
            this.btnRegInfCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegInfCli.Enabled = false;
            this.btnRegInfCli.Location = new System.Drawing.Point(366, 442);
            this.btnRegInfCli.Name = "btnRegInfCli";
            this.btnRegInfCli.Size = new System.Drawing.Size(60, 50);
            this.btnRegInfCli.TabIndex = 8;
            this.btnRegInfCli.Text = "Registro de Contacto";
            this.btnRegInfCli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegInfCli.UseVisualStyleBackColor = true;
            this.btnRegInfCli.Click += new System.EventHandler(this.btnRegInfCli_Click);
            // 
            // frmScoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 686);
            this.Controls.Add(this.btnRegInfCli);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.grbDatosAdicionales);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbDocumento);
            this.Name = "frmScoring";
            this.Text = "Búsqueda de Campaña";
            this.Load += new System.EventHandler(this.frmScoring_Load);
            this.Controls.SetChildIndex(this.grbDocumento, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grbDatosAdicionales, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblMensaje, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.btnRegInfCli, 0);
            this.grbDocumento.ResumeLayout(false);
            this.grbDocumento.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDatosAdicionales.ResumeLayout(false);
            this.grbDatosAdicionales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDocumento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBDNI txtNroDocumento;
        private GEN.BotonesBase.btnMiniAceptar btnMiniAceptar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chcBancarizado;
        private GEN.ControlesBase.txtBase txtTipoCliente;
        private GEN.ControlesBase.txtBase txtNombres;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbDatosAdicionales;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtObligacionesFinancieras;
        private GEN.ControlesBase.txtNumRea txtExcedente;
        private GEN.ControlesBase.txtNumerico txtPlazo;
        private GEN.ControlesBase.txtNumRea txtMontoSolicitado;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.chcBase chcFormalizado;
        private GEN.ControlesBase.cboDestinoCredito cboDestinoCredito;
        private GEN.ControlesBase.txtNumerico txtExperienciaNegocio;
        private GEN.ControlesBase.txtBase txtCodigoUbigeo;
        private GEN.ControlesBase.txtNumerico txtEdad;
        private GEN.ControlesBase.cboEstadoCivil cboEstadoCivil;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBaseCustom lblMensaje;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.ControlesBase.lblBaseCustom lblMaxPlazo;
        private GEN.ControlesBase.lblBaseCustom lblMaxMonto;
        private GEN.BotonesBase.btnBlanco btnRegInfCli;
    }
}