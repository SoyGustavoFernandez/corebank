namespace CRE.Presentacion
{
    partial class frmCondiSolCredIntegrante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondiSolCredIntegrante));
            this.nudMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbTasa = new GEN.ControlesBase.grbBase(this.components);
            this.pbxTasaAprob = new System.Windows.Forms.PictureBox();
            this.lblMontoMaximo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.cboTipoTasaCredito = new GEN.ControlesBase.cboBase(this.components);
            this.txtCuotaGraciaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCuotaAprox = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtTasaMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasCompensatoriaMin = new GEN.ControlesBase.txtBase(this.components);
            this.txtTEA = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTasCompensatoriaMax = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblNombreGrupo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblIdCli = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.lblCliente = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtIdCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNombreGrupo = new GEN.ControlesBase.txtBase(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPaqueteSeguro = new GEN.ControlesBase.cboPaqueteSeguro(this.components);
            this.lblPaqueteSeguro = new GEN.ControlesBase.lblBase();
            this.lblBase38 = new GEN.ControlesBase.lblBase();
            this.cboDetalleGasto1 = new GEN.ControlesBase.cboDetalleGasto(this.components);
            this.conActividadCIIU = new GEN.ControlesBase.conActividadCIIU();
            this.cboDestinoCredito = new GEN.ControlesBase.cboDestinoCredito(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbTasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTasaAprob)).BeginInit();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudMonto
            // 
            this.nudMonto.FormatoDecimal = false;
            this.nudMonto.Location = new System.Drawing.Point(107, 24);
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMonto.nNumDecimales = 2;
            this.nudMonto.nvalor = 0D;
            this.nudMonto.Size = new System.Drawing.Size(93, 20);
            this.nudMonto.TabIndex = 1;
            this.nudMonto.Leave += new System.EventHandler(this.nudMonto_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Monto:";
            // 
            // grbTasa
            // 
            this.grbTasa.Controls.Add(this.pbxTasaAprob);
            this.grbTasa.Controls.Add(this.lblMontoMaximo);
            this.grbTasa.Controls.Add(this.cboTipoTasaCredito);
            this.grbTasa.Controls.Add(this.txtCuotaGraciaAprox);
            this.grbTasa.Controls.Add(this.nudMonto);
            this.grbTasa.Controls.Add(this.txtCuotaAprox);
            this.grbTasa.Controls.Add(this.lblBase1);
            this.grbTasa.Controls.Add(this.lblBase15);
            this.grbTasa.Controls.Add(this.lblBase5);
            this.grbTasa.Controls.Add(this.lblBase14);
            this.grbTasa.Controls.Add(this.lblBase17);
            this.grbTasa.Controls.Add(this.lblBase13);
            this.grbTasa.Controls.Add(this.txtTasaMora);
            this.grbTasa.Controls.Add(this.txtTasCompensatoriaMin);
            this.grbTasa.Controls.Add(this.txtTEA);
            this.grbTasa.Controls.Add(this.txtTasCompensatoriaMax);
            this.grbTasa.Controls.Add(this.lblBase16);
            this.grbTasa.Controls.Add(this.lblBase9);
            this.grbTasa.Controls.Add(this.lblBase11);
            this.grbTasa.Location = new System.Drawing.Point(12, 109);
            this.grbTasa.Name = "grbTasa";
            this.grbTasa.Size = new System.Drawing.Size(463, 131);
            this.grbTasa.TabIndex = 1;
            this.grbTasa.TabStop = false;
            this.grbTasa.Text = "Selección tasa";
            // 
            // pbxTasaAprob
            // 
            this.pbxTasaAprob.Image = ((System.Drawing.Image)(resources.GetObject("pbxTasaAprob.Image")));
            this.pbxTasaAprob.Location = new System.Drawing.Point(15, 73);
            this.pbxTasaAprob.Name = "pbxTasaAprob";
            this.pbxTasaAprob.Size = new System.Drawing.Size(16, 16);
            this.pbxTasaAprob.TabIndex = 168;
            this.pbxTasaAprob.TabStop = false;
            this.pbxTasaAprob.Visible = false;
            this.pbxTasaAprob.Click += new System.EventHandler(this.pbxTasaAprob_Click);
            // 
            // lblMontoMaximo
            // 
            this.lblMontoMaximo.AutoSize = true;
            this.lblMontoMaximo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblMontoMaximo.ForeColor = System.Drawing.Color.Navy;
            this.lblMontoMaximo.Location = new System.Drawing.Point(216, 28);
            this.lblMontoMaximo.Name = "lblMontoMaximo";
            this.lblMontoMaximo.Size = new System.Drawing.Size(100, 13);
            this.lblMontoMaximo.TabIndex = 2;
            this.lblMontoMaximo.Text = "Monto Máximo";
            // 
            // cboTipoTasaCredito
            // 
            this.cboTipoTasaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTasaCredito.DropDownWidth = 200;
            this.cboTipoTasaCredito.FormattingEnabled = true;
            this.cboTipoTasaCredito.Location = new System.Drawing.Point(15, 50);
            this.cboTipoTasaCredito.Name = "cboTipoTasaCredito";
            this.cboTipoTasaCredito.Size = new System.Drawing.Size(112, 21);
            this.cboTipoTasaCredito.TabIndex = 3;
            this.cboTipoTasaCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoTasaCredito_SelectedIndexChanged);
            // 
            // txtCuotaGraciaAprox
            // 
            this.txtCuotaGraciaAprox.Enabled = false;
            this.txtCuotaGraciaAprox.FormatoDecimal = false;
            this.txtCuotaGraciaAprox.Location = new System.Drawing.Point(297, 94);
            this.txtCuotaGraciaAprox.Name = "txtCuotaGraciaAprox";
            this.txtCuotaGraciaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaGraciaAprox.nNumDecimales = 4;
            this.txtCuotaGraciaAprox.nvalor = 0D;
            this.txtCuotaGraciaAprox.Size = new System.Drawing.Size(100, 20);
            this.txtCuotaGraciaAprox.TabIndex = 11;
            this.txtCuotaGraciaAprox.TabStop = false;
            this.txtCuotaGraciaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCuotaAprox
            // 
            this.txtCuotaAprox.Enabled = false;
            this.txtCuotaAprox.FormatoDecimal = false;
            this.txtCuotaAprox.Location = new System.Drawing.Point(297, 72);
            this.txtCuotaAprox.Name = "txtCuotaAprox";
            this.txtCuotaAprox.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuotaAprox.nNumDecimales = 4;
            this.txtCuotaAprox.nvalor = 0D;
            this.txtCuotaAprox.Size = new System.Drawing.Size(100, 20);
            this.txtCuotaAprox.TabIndex = 7;
            this.txtCuotaAprox.TabStop = false;
            this.txtCuotaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(79, 98);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(91, 13);
            this.lblBase15.TabIndex = 8;
            this.lblBase15.Text = "Tasa Moratoria";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(258, 98);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(82, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Cuota Gracia";
            this.lblBase5.Visible = false;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(265, 54);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(30, 13);
            this.lblBase14.TabIndex = 121;
            this.lblBase14.Text = "Max";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(257, 76);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(83, 13);
            this.lblBase17.TabIndex = 126;
            this.lblBase17.Text = "Cuota Aprox.";
            this.lblBase17.Visible = false;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(144, 54);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(26, 13);
            this.lblBase13.TabIndex = 120;
            this.lblBase13.Text = "Min";
            // 
            // txtTasaMora
            // 
            this.txtTasaMora.Enabled = false;
            this.txtTasaMora.FormatoDecimal = false;
            this.txtTasaMora.Location = new System.Drawing.Point(172, 94);
            this.txtTasaMora.Name = "txtTasaMora";
            this.txtTasaMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaMora.nNumDecimales = 4;
            this.txtTasaMora.nvalor = 0D;
            this.txtTasaMora.Size = new System.Drawing.Size(55, 20);
            this.txtTasaMora.TabIndex = 9;
            // 
            // txtTasCompensatoriaMin
            // 
            this.txtTasCompensatoriaMin.Enabled = false;
            this.txtTasCompensatoriaMin.Location = new System.Drawing.Point(172, 50);
            this.txtTasCompensatoriaMin.Name = "txtTasCompensatoriaMin";
            this.txtTasCompensatoriaMin.Size = new System.Drawing.Size(55, 20);
            this.txtTasCompensatoriaMin.TabIndex = 4;
            this.txtTasCompensatoriaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTEA
            // 
            this.txtTEA.FormatoDecimal = false;
            this.txtTEA.Location = new System.Drawing.Point(172, 72);
            this.txtTEA.Name = "txtTEA";
            this.txtTEA.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTEA.nNumDecimales = 4;
            this.txtTEA.nvalor = 0D;
            this.txtTEA.Size = new System.Drawing.Size(55, 20);
            this.txtTEA.TabIndex = 6;
            // 
            // txtTasCompensatoriaMax
            // 
            this.txtTasCompensatoriaMax.Enabled = false;
            this.txtTasCompensatoriaMax.Location = new System.Drawing.Point(297, 50);
            this.txtTasCompensatoriaMax.Name = "txtTasCompensatoriaMax";
            this.txtTasCompensatoriaMax.Size = new System.Drawing.Size(55, 20);
            this.txtTasCompensatoriaMax.TabIndex = 5;
            this.txtTasCompensatoriaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(228, 98);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(19, 13);
            this.lblBase16.TabIndex = 114;
            this.lblBase16.Text = "%";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(141, 76);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(29, 13);
            this.lblBase9.TabIndex = 122;
            this.lblBase9.Text = "TEA";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(228, 76);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(19, 13);
            this.lblBase11.TabIndex = 123;
            this.lblBase11.Text = "%";
            // 
            // grbBase2
            // 
            this.grbBase2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBase2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grbBase2.Controls.Add(this.lblNombreGrupo);
            this.grbBase2.Controls.Add(this.lblIdCli);
            this.grbBase2.Controls.Add(this.txtCliente);
            this.grbBase2.Controls.Add(this.lblCliente);
            this.grbBase2.Controls.Add(this.txtIdCli);
            this.grbBase2.Controls.Add(this.txtNombreGrupo);
            this.grbBase2.Location = new System.Drawing.Point(12, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(463, 91);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "InfoCli";
            // 
            // lblNombreGrupo
            // 
            this.lblNombreGrupo.AutoSize = true;
            this.lblNombreGrupo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNombreGrupo.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreGrupo.Location = new System.Drawing.Point(6, 16);
            this.lblNombreGrupo.Name = "lblNombreGrupo";
            this.lblNombreGrupo.Size = new System.Drawing.Size(102, 13);
            this.lblNombreGrupo.TabIndex = 0;
            this.lblNombreGrupo.Text = "Nombre grupo : ";
            // 
            // lblIdCli
            // 
            this.lblIdCli.AutoSize = true;
            this.lblIdCli.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblIdCli.ForeColor = System.Drawing.Color.Navy;
            this.lblIdCli.Location = new System.Drawing.Point(48, 41);
            this.lblIdCli.Name = "lblIdCli";
            this.lblIdCli.Size = new System.Drawing.Size(53, 13);
            this.lblIdCli.TabIndex = 2;
            this.lblIdCli.Text = "ID Cli : ";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(114, 63);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(337, 20);
            this.txtCliente.TabIndex = 5;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCliente.ForeColor = System.Drawing.Color.Navy;
            this.lblCliente.Location = new System.Drawing.Point(48, 66);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente : ";
            // 
            // txtIdCli
            // 
            this.txtIdCli.Enabled = false;
            this.txtIdCli.Location = new System.Drawing.Point(114, 38);
            this.txtIdCli.Name = "txtIdCli";
            this.txtIdCli.Size = new System.Drawing.Size(94, 20);
            this.txtIdCli.TabIndex = 3;
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Enabled = false;
            this.txtNombreGrupo.Location = new System.Drawing.Point(114, 13);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(337, 20);
            this.txtNombreGrupo.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbBase2);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.grbBase1);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.grbTasa);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 459);
            this.panel1.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(349, 402);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboPaqueteSeguro);
            this.grbBase1.Controls.Add(this.lblPaqueteSeguro);
            this.grbBase1.Controls.Add(this.lblBase38);
            this.grbBase1.Controls.Add(this.cboDetalleGasto1);
            this.grbBase1.Controls.Add(this.conActividadCIIU);
            this.grbBase1.Controls.Add(this.cboDestinoCredito);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(12, 246);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(463, 150);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Integ: ";
            // 
            // cboPaqueteSeguro
            // 
            this.cboPaqueteSeguro.FormattingEnabled = true;
            this.cboPaqueteSeguro.Location = new System.Drawing.Point(107, 114);
            this.cboPaqueteSeguro.Name = "cboPaqueteSeguro";
            this.cboPaqueteSeguro.Size = new System.Drawing.Size(233, 21);
            this.cboPaqueteSeguro.TabIndex = 77;
            // 
            // lblPaqueteSeguro
            // 
            this.lblPaqueteSeguro.AutoSize = true;
            this.lblPaqueteSeguro.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPaqueteSeguro.ForeColor = System.Drawing.Color.Navy;
            this.lblPaqueteSeguro.Location = new System.Drawing.Point(3, 118);
            this.lblPaqueteSeguro.Name = "lblPaqueteSeguro";
            this.lblPaqueteSeguro.Size = new System.Drawing.Size(99, 13);
            this.lblPaqueteSeguro.TabIndex = 76;
            this.lblPaqueteSeguro.Text = "Plan de Seguro:";
            // 
            // lblBase38
            // 
            this.lblBase38.AutoSize = true;
            this.lblBase38.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase38.ForeColor = System.Drawing.Color.Navy;
            this.lblBase38.Location = new System.Drawing.Point(3, 85);
            this.lblBase38.Name = "lblBase38";
            this.lblBase38.Size = new System.Drawing.Size(99, 13);
            this.lblBase38.TabIndex = 75;
            this.lblBase38.Text = "Tipo de Seguro:";
            // 
            // cboDetalleGasto1
            // 
            this.cboDetalleGasto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetalleGasto1.FormattingEnabled = true;
            this.cboDetalleGasto1.Location = new System.Drawing.Point(107, 82);
            this.cboDetalleGasto1.Name = "cboDetalleGasto1";
            this.cboDetalleGasto1.Size = new System.Drawing.Size(233, 21);
            this.cboDetalleGasto1.TabIndex = 74;
            this.cboDetalleGasto1.SelectedIndexChanged += new System.EventHandler(this.cboDetalleGasto1_SelectedIndexChanged);
            // 
            // conActividadCIIU
            // 
            this.conActividadCIIU.AutoSize = true;
            this.conActividadCIIU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conActividadCIIU.Location = new System.Drawing.Point(12, 48);
            this.conActividadCIIU.Name = "conActividadCIIU";
            this.conActividadCIIU.Size = new System.Drawing.Size(385, 28);
            this.conActividadCIIU.TabIndex = 2;
            // 
            // cboDestinoCredito
            // 
            this.cboDestinoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinoCredito.FormattingEnabled = true;
            this.cboDestinoCredito.Location = new System.Drawing.Point(107, 21);
            this.cboDestinoCredito.Name = "cboDestinoCredito";
            this.cboDestinoCredito.Size = new System.Drawing.Size(142, 21);
            this.cboDestinoCredito.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 24);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Destino:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(415, 402);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmCondiSolCredIntegrante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(481, 486);
            this.Controls.Add(this.panel1);
            this.Name = "frmCondiSolCredIntegrante";
            this.Text = "Detalle Solicitud Integrante";
            this.Load += new System.EventHandler(this.frmCondiSolCredIntegrante_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.grbTasa.ResumeLayout(false);
            this.grbTasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTasaAprob)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea nudMonto;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbTasa;
        private GEN.ControlesBase.cboBase cboTipoTasaCredito;
        private GEN.ControlesBase.txtNumRea txtCuotaGraciaAprox;
        private GEN.ControlesBase.txtNumRea txtCuotaAprox;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtNumRea txtTasaMora;
        private GEN.ControlesBase.txtBase txtTasCompensatoriaMin;
        private GEN.ControlesBase.txtNumRea txtTEA;
        private GEN.ControlesBase.txtBase txtTasCompensatoriaMax;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBaseCustom lblNombreGrupo;
        private GEN.ControlesBase.lblBaseCustom lblIdCli;
        private GEN.ControlesBase.txtBase txtCliente;
        private GEN.ControlesBase.lblBaseCustom lblCliente;
        private GEN.ControlesBase.txtBase txtIdCli;
        private GEN.ControlesBase.txtBase txtNombreGrupo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private GEN.ControlesBase.lblBaseCustom lblMontoMaximo;
        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboDestinoCredito cboDestinoCredito;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.PictureBox pbxTasaAprob;
        private GEN.ControlesBase.conActividadCIIU conActividadCIIU;
        private GEN.ControlesBase.lblBase lblBase38;
        private GEN.ControlesBase.cboDetalleGasto cboDetalleGasto1;
        private GEN.ControlesBase.cboPaqueteSeguro cboPaqueteSeguro;
        private GEN.ControlesBase.lblBase lblPaqueteSeguro;

    }
}