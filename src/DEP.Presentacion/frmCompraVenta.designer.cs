namespace DEP.Presentacion
{
    partial class frmCompraVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompraVenta));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtCompraDolar = new System.Windows.Forms.RadioButton();
            this.rbtVentaDolar = new System.Windows.Forms.RadioButton();
            this.txtMonDolares = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcTipCamEsp = new GEN.ControlesBase.chcBase(this.components);
            this.txtMonEquiSol = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMonRed = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtMonNeto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.txtTipCamCom = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtTipCamFij = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtTipCamVen = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.chcCliente = new GEN.ControlesBase.chcBase(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnBusSolicitud = new GEN.BotonesBase.btnBusSolicitud();
            this.grbCli = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtNacionExt = new System.Windows.Forms.RadioButton();
            this.rbtNacionPer = new System.Windows.Forms.RadioButton();
            this.grbxDatosNoCliente = new System.Windows.Forms.GroupBox();
            this.txtCBNroDocumentos = new GEN.ControlesBase.txtCBNroDocumentos(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtDireccPerson = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipDocumento = new GEN.ControlesBase.cboTipDocumento(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNombrePerson = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.conSplaf1 = new GEN.ControlesBase.conSplaf();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.grbBase5.SuspendLayout();
            this.conBusCli.SuspendLayout();
            this.grbCli.SuspendLayout();
            this.grbBase6.SuspendLayout();
            this.grbxDatosNoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rbtCompraDolar);
            this.grbBase1.Controls.Add(this.rbtVentaDolar);
            this.grbBase1.Location = new System.Drawing.Point(7, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(469, 56);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            // 
            // rbtCompraDolar
            // 
            this.rbtCompraDolar.AutoSize = true;
            this.rbtCompraDolar.Location = new System.Drawing.Point(309, 22);
            this.rbtCompraDolar.Name = "rbtCompraDolar";
            this.rbtCompraDolar.Size = new System.Drawing.Size(100, 17);
            this.rbtCompraDolar.TabIndex = 76;
            this.rbtCompraDolar.TabStop = true;
            this.rbtCompraDolar.Text = "Compra Dólares";
            this.rbtCompraDolar.UseVisualStyleBackColor = true;
            this.rbtCompraDolar.CheckedChanged += new System.EventHandler(this.rbtVentaDolar_CheckedChanged);
            // 
            // rbtVentaDolar
            // 
            this.rbtVentaDolar.AutoSize = true;
            this.rbtVentaDolar.Location = new System.Drawing.Point(59, 22);
            this.rbtVentaDolar.Name = "rbtVentaDolar";
            this.rbtVentaDolar.Size = new System.Drawing.Size(92, 17);
            this.rbtVentaDolar.TabIndex = 75;
            this.rbtVentaDolar.TabStop = true;
            this.rbtVentaDolar.Text = "Venta Dólares";
            this.rbtVentaDolar.UseVisualStyleBackColor = true;
            this.rbtVentaDolar.CheckedChanged += new System.EventHandler(this.rbtCompraDolar_CheckedChanged);
            // 
            // txtMonDolares
            // 
            this.txtMonDolares.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonDolares.FormatoDecimal = true;
            this.txtMonDolares.Location = new System.Drawing.Point(252, 109);
            this.txtMonDolares.MaxLength = 10;
            this.txtMonDolares.Name = "txtMonDolares";
            this.txtMonDolares.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonDolares.nNumDecimales = 2;
            this.txtMonDolares.nvalor = 0D;
            this.txtMonDolares.Size = new System.Drawing.Size(104, 21);
            this.txtMonDolares.TabIndex = 80;
            this.txtMonDolares.TextChanged += new System.EventHandler(this.txtMonDolares_TextChanged);
            this.txtMonDolares.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonDolares_KeyPress);
            this.txtMonDolares.Leave += new System.EventHandler(this.txtMonDolares_Leave);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(25, 112);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(224, 13);
            this.lblBase6.TabIndex = 79;
            this.lblBase6.Text = "INGRESA EL MONTO A CAMBIAR  ($):";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.chcTipCamEsp);
            this.grbBase2.Location = new System.Drawing.Point(8, 92);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(534, 46);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Monto a Cambiar";
            // 
            // chcTipCamEsp
            // 
            this.chcTipCamEsp.AutoSize = true;
            this.chcTipCamEsp.ForeColor = System.Drawing.Color.Navy;
            this.chcTipCamEsp.Location = new System.Drawing.Point(355, 20);
            this.chcTipCamEsp.Name = "chcTipCamEsp";
            this.chcTipCamEsp.Size = new System.Drawing.Size(165, 17);
            this.chcTipCamEsp.TabIndex = 0;
            this.chcTipCamEsp.Text = "Con Tipo de Cambio Especial";
            this.chcTipCamEsp.UseVisualStyleBackColor = true;
            this.chcTipCamEsp.CheckedChanged += new System.EventHandler(this.chcTipCamEsp_CheckedChanged);
            // 
            // txtMonEquiSol
            // 
            this.txtMonEquiSol.Enabled = false;
            this.txtMonEquiSol.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonEquiSol.FormatoDecimal = false;
            this.txtMonEquiSol.Location = new System.Drawing.Point(244, 17);
            this.txtMonEquiSol.Name = "txtMonEquiSol";
            this.txtMonEquiSol.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonEquiSol.nNumDecimales = 4;
            this.txtMonEquiSol.nvalor = 0D;
            this.txtMonEquiSol.Size = new System.Drawing.Size(104, 21);
            this.txtMonEquiSol.TabIndex = 87;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(230, 13);
            this.lblBase2.TabIndex = 86;
            this.lblBase2.Text = "MONTO EQUIVALENTE EN SOLES (S/.):";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.txtMonEquiSol);
            this.grbBase3.Location = new System.Drawing.Point(8, 140);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(534, 46);
            this.grbBase3.TabIndex = 3;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Equivalente";
            // 
            // txtMonRed
            // 
            this.txtMonRed.Enabled = false;
            this.txtMonRed.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonRed.FormatoDecimal = false;
            this.txtMonRed.Location = new System.Drawing.Point(149, 22);
            this.txtMonRed.Name = "txtMonRed";
            this.txtMonRed.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonRed.nNumDecimales = 4;
            this.txtMonRed.nvalor = 0D;
            this.txtMonRed.Size = new System.Drawing.Size(104, 21);
            this.txtMonRed.TabIndex = 90;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(17, 25);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(78, 13);
            this.lblBase4.TabIndex = 89;
            this.lblBase4.Text = "REDONDEO:";
            // 
            // txtMonNeto
            // 
            this.txtMonNeto.Enabled = false;
            this.txtMonNeto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonNeto.FormatoDecimal = false;
            this.txtMonNeto.Location = new System.Drawing.Point(148, 51);
            this.txtMonNeto.Name = "txtMonNeto";
            this.txtMonNeto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonNeto.nNumDecimales = 4;
            this.txtMonNeto.nvalor = 0D;
            this.txtMonNeto.Size = new System.Drawing.Size(104, 21);
            this.txtMonNeto.TabIndex = 92;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonto.Location = new System.Drawing.Point(17, 54);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(120, 13);
            this.lblMonto.TabIndex = 91;
            this.lblMonto.Text = "MONTO A RECIBIR:";
            // 
            // txtTipCamCom
            // 
            this.txtTipCamCom.Enabled = false;
            this.txtTipCamCom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipCamCom.FormatoDecimal = false;
            this.txtTipCamCom.Location = new System.Drawing.Point(148, 37);
            this.txtTipCamCom.Name = "txtTipCamCom";
            this.txtTipCamCom.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamCom.nNumDecimales = 3;
            this.txtTipCamCom.nvalor = 0D;
            this.txtTipCamCom.Size = new System.Drawing.Size(104, 21);
            this.txtTipCamCom.TabIndex = 96;
            this.txtTipCamCom.Leave += new System.EventHandler(this.txtTipCamCom_Leave);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 40);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(134, 13);
            this.lblBase7.TabIndex = 95;
            this.lblBase7.Text = "Tipo Cambio Compra:";
            // 
            // txtTipCamFij
            // 
            this.txtTipCamFij.Enabled = false;
            this.txtTipCamFij.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipCamFij.FormatoDecimal = false;
            this.txtTipCamFij.Location = new System.Drawing.Point(148, 15);
            this.txtTipCamFij.Name = "txtTipCamFij";
            this.txtTipCamFij.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamFij.nNumDecimales = 3;
            this.txtTipCamFij.nvalor = 0D;
            this.txtTipCamFij.Size = new System.Drawing.Size(104, 21);
            this.txtTipCamFij.TabIndex = 94;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(108, 13);
            this.lblBase8.TabIndex = 93;
            this.lblBase8.Text = "Tipo Cambio Fijo:";
            // 
            // txtTipCamVen
            // 
            this.txtTipCamVen.Enabled = false;
            this.txtTipCamVen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipCamVen.FormatoDecimal = false;
            this.txtTipCamVen.Location = new System.Drawing.Point(148, 60);
            this.txtTipCamVen.Name = "txtTipCamVen";
            this.txtTipCamVen.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamVen.nNumDecimales = 3;
            this.txtTipCamVen.nvalor = 0D;
            this.txtTipCamVen.Size = new System.Drawing.Size(104, 21);
            this.txtTipCamVen.TabIndex = 98;
            this.txtTipCamVen.Leave += new System.EventHandler(this.txtTipCamVen_Leave);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(10, 63);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(120, 13);
            this.lblBase9.TabIndex = 97;
            this.lblBase9.Text = "Tipo Cambio Venta:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblBase4);
            this.grbBase4.Controls.Add(this.lblMonto);
            this.grbBase4.Controls.Add(this.txtMonRed);
            this.grbBase4.Controls.Add(this.txtMonNeto);
            this.grbBase4.Location = new System.Drawing.Point(8, 188);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(259, 85);
            this.grbBase4.TabIndex = 4;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Redondeo";
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.lblBase8);
            this.grbBase5.Controls.Add(this.txtTipCamFij);
            this.grbBase5.Controls.Add(this.lblBase7);
            this.grbBase5.Controls.Add(this.txtTipCamCom);
            this.grbBase5.Controls.Add(this.lblBase9);
            this.grbBase5.Controls.Add(this.txtTipCamVen);
            this.grbBase5.Location = new System.Drawing.Point(270, 188);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(272, 85);
            this.grbBase5.TabIndex = 100;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Tipos de Cambio";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(482, 459);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 104;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(360, 459);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 103;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(421, 459);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 102;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(299, 459);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 101;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // chcCliente
            // 
            this.chcCliente.AutoSize = true;
            this.chcCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcCliente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcCliente.Location = new System.Drawing.Point(7, 275);
            this.chcCliente.Name = "chcCliente";
            this.chcCliente.Size = new System.Drawing.Size(127, 17);
            this.chcCliente.TabIndex = 5;
            this.chcCliente.Text = "NO ES CLIENTE?";
            this.chcCliente.UseVisualStyleBackColor = true;
            this.chcCliente.CheckedChanged += new System.EventHandler(this.chcCliente_CheckedChanged);
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(7, 292);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(533, 106);
            this.conBusCli.TabIndex = 0;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            this.conBusCli.ChangeDocumentoID += new System.EventHandler(this.conBusCli_ChangeDocumentoID);
            // 
            // txtCodCli
            // 
            this.txtCodCli.Enabled = false;
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(161, 8);
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(180, 20);
            this.txtCodCli.TabIndex = 9;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.SystemColors.Info;
            this.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDescripcion.Location = new System.Drawing.Point(8, 62);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(534, 27);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "LA FINANCIERA VENDE DOLARES AL CLIENTE";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBusSolicitud
            // 
            this.btnBusSolicitud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusSolicitud.BackgroundImage")));
            this.btnBusSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusSolicitud.Location = new System.Drawing.Point(482, 9);
            this.btnBusSolicitud.Name = "btnBusSolicitud";
            this.btnBusSolicitud.Size = new System.Drawing.Size(60, 50);
            this.btnBusSolicitud.TabIndex = 77;
            this.btnBusSolicitud.Text = "&Buscar Solicitud";
            this.btnBusSolicitud.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusSolicitud.UseVisualStyleBackColor = true;
            this.btnBusSolicitud.Click += new System.EventHandler(this.btnBusSolicitud_Click);
            // 
            // grbCli
            // 
            this.grbCli.Controls.Add(this.grbBase6);
            this.grbCli.Controls.Add(this.grbxDatosNoCliente);
            this.grbCli.Location = new System.Drawing.Point(8, 292);
            this.grbCli.Name = "grbCli";
            this.grbCli.Size = new System.Drawing.Size(534, 163);
            this.grbCli.TabIndex = 7;
            this.grbCli.TabStop = false;
            this.grbCli.Text = "Datos del Cliente";
            this.grbCli.Visible = false;
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.rbtNacionExt);
            this.grbBase6.Controls.Add(this.rbtNacionPer);
            this.grbBase6.ForeColor = System.Drawing.Color.Navy;
            this.grbBase6.Location = new System.Drawing.Point(11, 12);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(515, 36);
            this.grbBase6.TabIndex = 0;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "Nacionalidad:";
            // 
            // rbtNacionExt
            // 
            this.rbtNacionExt.AutoSize = true;
            this.rbtNacionExt.Location = new System.Drawing.Point(224, 15);
            this.rbtNacionExt.Name = "rbtNacionExt";
            this.rbtNacionExt.Size = new System.Drawing.Size(72, 17);
            this.rbtNacionExt.TabIndex = 1;
            this.rbtNacionExt.TabStop = true;
            this.rbtNacionExt.Text = "Extranjera";
            this.rbtNacionExt.UseVisualStyleBackColor = true;
            this.rbtNacionExt.CheckedChanged += new System.EventHandler(this.RdBtnNacionExt_CheckedChanged);
            // 
            // rbtNacionPer
            // 
            this.rbtNacionPer.AutoSize = true;
            this.rbtNacionPer.Location = new System.Drawing.Point(85, 15);
            this.rbtNacionPer.Name = "rbtNacionPer";
            this.rbtNacionPer.Size = new System.Drawing.Size(65, 17);
            this.rbtNacionPer.TabIndex = 0;
            this.rbtNacionPer.TabStop = true;
            this.rbtNacionPer.Text = "Peruana";
            this.rbtNacionPer.UseVisualStyleBackColor = true;
            this.rbtNacionPer.CheckedChanged += new System.EventHandler(this.RdBtnNacionPer_CheckedChanged);
            // 
            // grbxDatosNoCliente
            // 
            this.grbxDatosNoCliente.Controls.Add(this.txtCBNroDocumentos);
            this.grbxDatosNoCliente.Controls.Add(this.lblBase3);
            this.grbxDatosNoCliente.Controls.Add(this.txtDireccPerson);
            this.grbxDatosNoCliente.Controls.Add(this.cboTipDocumento);
            this.grbxDatosNoCliente.Controls.Add(this.lblBase5);
            this.grbxDatosNoCliente.Controls.Add(this.lblBase1);
            this.grbxDatosNoCliente.Controls.Add(this.txtNombrePerson);
            this.grbxDatosNoCliente.Controls.Add(this.lblBase16);
            this.grbxDatosNoCliente.Location = new System.Drawing.Point(11, 48);
            this.grbxDatosNoCliente.Name = "grbxDatosNoCliente";
            this.grbxDatosNoCliente.Size = new System.Drawing.Size(515, 107);
            this.grbxDatosNoCliente.TabIndex = 119;
            this.grbxDatosNoCliente.TabStop = false;
            // 
            // txtCBNroDocumentos
            // 
            this.txtCBNroDocumentos.Location = new System.Drawing.Point(80, 35);
            this.txtCBNroDocumentos.MaxLength = 20;
            this.txtCBNroDocumentos.Name = "txtCBNroDocumentos";
            this.txtCBNroDocumentos.Size = new System.Drawing.Size(128, 20);
            this.txtCBNroDocumentos.TabIndex = 1;
            this.txtCBNroDocumentos.TextChanged += new System.EventHandler(this.txtCBNroDocumentos_TextChanged);
            this.txtCBNroDocumentos.Validating += new System.ComponentModel.CancelEventHandler(this.txtCBNroDocumentos_Validating);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 16);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(66, 13);
            this.lblBase3.TabIndex = 110;
            this.lblBase3.Text = "Tipo Doc.:";
            // 
            // txtDireccPerson
            // 
            this.txtDireccPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccPerson.Enabled = false;
            this.txtDireccPerson.Location = new System.Drawing.Point(80, 81);
            this.txtDireccPerson.Name = "txtDireccPerson";
            this.txtDireccPerson.Size = new System.Drawing.Size(299, 20);
            this.txtDireccPerson.TabIndex = 3;
            // 
            // cboTipDocumento
            // 
            this.cboTipDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipDocumento.FormattingEnabled = true;
            this.cboTipDocumento.Location = new System.Drawing.Point(80, 11);
            this.cboTipDocumento.Name = "cboTipDocumento";
            this.cboTipDocumento.Size = new System.Drawing.Size(300, 21);
            this.cboTipDocumento.TabIndex = 0;
            this.cboTipDocumento.SelectedIndexChanged += new System.EventHandler(this.cboTipDocumento_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 88);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(65, 13);
            this.lblBase5.TabIndex = 117;
            this.lblBase5.Text = "Dirección:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 40);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 112;
            this.lblBase1.Text = "N° Doc.:";
            // 
            // txtNombrePerson
            // 
            this.txtNombrePerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombrePerson.Enabled = false;
            this.txtNombrePerson.Location = new System.Drawing.Point(80, 58);
            this.txtNombrePerson.Name = "txtNombrePerson";
            this.txtNombrePerson.Size = new System.Drawing.Size(299, 20);
            this.txtNombrePerson.TabIndex = 2;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(6, 64);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(57, 13);
            this.lblBase16.TabIndex = 114;
            this.lblBase16.Text = "Nombre:";
            // 
            // conSplaf1
            // 
            this.conSplaf1.AutoSize = true;
            this.conSplaf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.conSplaf1.ForeColor = System.Drawing.Color.Red;
            this.conSplaf1.Location = new System.Drawing.Point(299, 511);
            this.conSplaf1.Name = "conSplaf1";
            this.conSplaf1.Size = new System.Drawing.Size(0, 20);
            this.conSplaf1.TabIndex = 110;
            // 
            // frmCompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 536);
            this.Controls.Add(this.conSplaf1);
            this.Controls.Add(this.grbCli);
            this.Controls.Add(this.btnBusSolicitud);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.chcCliente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.txtMonDolares);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.grbBase5);
            this.Controls.Add(this.conBusCli);
            this.Name = "frmCompraVenta";
            this.Text = "Compra Venta de Dólares";
            this.Load += new System.EventHandler(this.frmCompraVenta_Load);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonDolares, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.chcCliente, 0);
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.btnBusSolicitud, 0);
            this.Controls.SetChildIndex(this.grbCli, 0);
            this.Controls.SetChildIndex(this.conSplaf1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            this.grbCli.ResumeLayout(false);
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            this.grbxDatosNoCliente.ResumeLayout(false);
            this.grbxDatosNoCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.RadioButton rbtCompraDolar;
        private System.Windows.Forms.RadioButton rbtVentaDolar;
        private GEN.ControlesBase.txtNumRea txtMonDolares;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtNumRea txtMonEquiSol;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtNumRea txtMonRed;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMonNeto;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.ControlesBase.txtNumRea txtTipCamCom;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.chcBase chcCliente;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodCli;
        private System.Windows.Forms.Label lblDescripcion;
        private GEN.ControlesBase.chcBase chcTipCamEsp;
        private GEN.BotonesBase.btnBusSolicitud btnBusSolicitud;
        private GEN.ControlesBase.grbBase grbCli;
        private GEN.ControlesBase.conSplaf conSplaf1;
        private GEN.ControlesBase.grbBase grbBase6;
        private System.Windows.Forms.RadioButton rbtNacionExt;
        private System.Windows.Forms.RadioButton rbtNacionPer;
        private GEN.ControlesBase.cboTipDocumento cboTipDocumento;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox grbxDatosNoCliente;
        public GEN.ControlesBase.txtBase txtDireccPerson;
        private GEN.ControlesBase.lblBase lblBase5;
        public GEN.ControlesBase.txtBase txtNombrePerson;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.txtCBNroDocumentos txtCBNroDocumentos;
        public GEN.ControlesBase.txtNumRea txtTipCamFij;
        public GEN.ControlesBase.txtNumRea txtTipCamVen;
    }
}