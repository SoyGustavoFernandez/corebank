namespace CAJ.Presentacion
{
    partial class frmTransferenciaBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferenciaBancaria));
            this.btnTransferir = new GEN.BotonesBase.btnTransferir();
            this.grbCtaOri = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.dtpfechaOperac = new GEN.ControlesBase.dtLargoBase(this.components);
            this.txtDescripción = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtSaldoDispOri = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtMontoTrans = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMotOperacionBco = new GEN.ControlesBase.cboMotOperacionBco(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNumeroCtaOri = new GEN.ControlesBase.txtBase(this.components);
            this.cboAgenOri = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuentaBcoOri = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.cboEntidadOri = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboTipoEntidadOri = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblTipoEntidad = new GEN.ControlesBase.lblBase();
            this.lblTipoCuenta = new GEN.ControlesBase.lblBase();
            this.lblCriterio = new GEN.ControlesBase.lblBase();
            this.lblEntidad = new GEN.ControlesBase.lblBase();
            this.btnBusCtaOri = new GEN.BotonesBase.btnBusqueda();
            this.grbCtaDes = new GEN.ControlesBase.grbBase(this.components);
            this.txtNumeroCtaDes = new GEN.ControlesBase.txtBase(this.components);
            this.txtSaldoDispDes = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.cboAgenDes = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuentaBcoDes = new GEN.ControlesBase.cboTipoCuentaBco(this.components);
            this.cboEntidadDes = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboTipoEntidadDes = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnBusCtaDes = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnExtorno = new GEN.BotonesBase.btnExtorno();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgListaTransferencias = new GEN.ControlesBase.dtgBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grbCtaOri.SuspendLayout();
            this.grbCtaDes.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTransferencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTransferir
            // 
            this.btnTransferir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransferir.BackgroundImage")));
            this.btnTransferir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTransferir.Location = new System.Drawing.Point(468, 216);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(60, 50);
            this.btnTransferir.TabIndex = 2;
            this.btnTransferir.Text = "&Transferir";
            this.btnTransferir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // grbCtaOri
            // 
            this.grbCtaOri.Controls.Add(this.cboMoneda);
            this.grbCtaOri.Controls.Add(this.lblBase13);
            this.grbCtaOri.Controls.Add(this.lblBase11);
            this.grbCtaOri.Controls.Add(this.dtpfechaOperac);
            this.grbCtaOri.Controls.Add(this.txtDescripción);
            this.grbCtaOri.Controls.Add(this.lblBase10);
            this.grbCtaOri.Controls.Add(this.txtSaldoDispOri);
            this.grbCtaOri.Controls.Add(this.lblBase9);
            this.grbCtaOri.Controls.Add(this.txtMontoTrans);
            this.grbCtaOri.Controls.Add(this.cboMotOperacionBco);
            this.grbCtaOri.Controls.Add(this.lblBase8);
            this.grbCtaOri.Controls.Add(this.lblBase7);
            this.grbCtaOri.Controls.Add(this.txtNumeroCtaOri);
            this.grbCtaOri.Controls.Add(this.cboAgenOri);
            this.grbCtaOri.Controls.Add(this.lblBase1);
            this.grbCtaOri.Controls.Add(this.cboTipoCuentaBcoOri);
            this.grbCtaOri.Controls.Add(this.cboEntidadOri);
            this.grbCtaOri.Controls.Add(this.cboTipoEntidadOri);
            this.grbCtaOri.Controls.Add(this.lblTipoEntidad);
            this.grbCtaOri.Controls.Add(this.lblTipoCuenta);
            this.grbCtaOri.Controls.Add(this.lblCriterio);
            this.grbCtaOri.Controls.Add(this.lblEntidad);
            this.grbCtaOri.Controls.Add(this.btnBusCtaOri);
            this.grbCtaOri.Location = new System.Drawing.Point(13, 12);
            this.grbCtaOri.Name = "grbCtaOri";
            this.grbCtaOri.Size = new System.Drawing.Size(451, 261);
            this.grbCtaOri.TabIndex = 0;
            this.grbCtaOri.TabStop = false;
            this.grbCtaOri.Text = "Cuenta Origen";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(346, 117);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(97, 21);
            this.cboMoneda.TabIndex = 6;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(241, 122);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(79, 13);
            this.lblBase13.TabIndex = 41;
            this.lblBase13.Text = "Tipo Moneda";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(241, 146);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(107, 13);
            this.lblBase11.TabIndex = 40;
            this.lblBase11.Text = "Fecha Operación:";
            // 
            // dtpfechaOperac
            // 
            this.dtpfechaOperac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaOperac.Location = new System.Drawing.Point(346, 143);
            this.dtpfechaOperac.Name = "dtpfechaOperac";
            this.dtpfechaOperac.Size = new System.Drawing.Size(96, 20);
            this.dtpfechaOperac.TabIndex = 8;
            // 
            // txtDescripción
            // 
            this.txtDescripción.Location = new System.Drawing.Point(121, 213);
            this.txtDescripción.Multiline = true;
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(321, 41);
            this.txtDescripción.TabIndex = 11;
            this.txtDescripción.TextChanged += new System.EventHandler(this.txtDescripción_TextChanged);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(8, 216);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(78, 13);
            this.lblBase10.TabIndex = 37;
            this.lblBase10.Text = "Descripción:";
            // 
            // txtSaldoDispOri
            // 
            this.txtSaldoDispOri.FormatoDecimal = false;
            this.txtSaldoDispOri.Location = new System.Drawing.Point(121, 142);
            this.txtSaldoDispOri.Name = "txtSaldoDispOri";
            this.txtSaldoDispOri.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoDispOri.nNumDecimales = 2;
            this.txtSaldoDispOri.nvalor = 0D;
            this.txtSaldoDispOri.Size = new System.Drawing.Size(117, 20);
            this.txtSaldoDispOri.TabIndex = 7;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(7, 145);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(107, 13);
            this.lblBase9.TabIndex = 35;
            this.lblBase9.Text = "Saldo Disponible:";
            // 
            // txtMontoTrans
            // 
            this.txtMontoTrans.FormatoDecimal = true;
            this.txtMontoTrans.Location = new System.Drawing.Point(121, 166);
            this.txtMontoTrans.MaxLength = 15;
            this.txtMontoTrans.Name = "txtMontoTrans";
            this.txtMontoTrans.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoTrans.nNumDecimales = 2;
            this.txtMontoTrans.nvalor = 0D;
            this.txtMontoTrans.Size = new System.Drawing.Size(117, 20);
            this.txtMontoTrans.TabIndex = 9;
            // 
            // cboMotOperacionBco
            // 
            this.cboMotOperacionBco.FormattingEnabled = true;
            this.cboMotOperacionBco.Location = new System.Drawing.Point(121, 190);
            this.cboMotOperacionBco.Name = "cboMotOperacionBco";
            this.cboMotOperacionBco.Size = new System.Drawing.Size(321, 21);
            this.cboMotOperacionBco.TabIndex = 10;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(7, 170);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(117, 13);
            this.lblBase8.TabIndex = 32;
            this.lblBase8.Text = "Monto a Transferir:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(6, 194);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(111, 13);
            this.lblBase7.TabIndex = 31;
            this.lblBase7.Text = "Motivo Operación:";
            // 
            // txtNumeroCtaOri
            // 
            this.txtNumeroCtaOri.Location = new System.Drawing.Point(90, 118);
            this.txtNumeroCtaOri.Name = "txtNumeroCtaOri";
            this.txtNumeroCtaOri.Size = new System.Drawing.Size(148, 20);
            this.txtNumeroCtaOri.TabIndex = 5;
            // 
            // cboAgenOri
            // 
            this.cboAgenOri.FormattingEnabled = true;
            this.cboAgenOri.Location = new System.Drawing.Point(90, 15);
            this.cboAgenOri.Name = "cboAgenOri";
            this.cboAgenOri.Size = new System.Drawing.Size(286, 21);
            this.cboAgenOri.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 28;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboTipoCuentaBcoOri
            // 
            this.cboTipoCuentaBcoOri.FormattingEnabled = true;
            this.cboTipoCuentaBcoOri.Location = new System.Drawing.Point(90, 91);
            this.cboTipoCuentaBcoOri.Name = "cboTipoCuentaBcoOri";
            this.cboTipoCuentaBcoOri.Size = new System.Drawing.Size(355, 21);
            this.cboTipoCuentaBcoOri.TabIndex = 4;
            // 
            // cboEntidadOri
            // 
            this.cboEntidadOri.FormattingEnabled = true;
            this.cboEntidadOri.Location = new System.Drawing.Point(90, 66);
            this.cboEntidadOri.Name = "cboEntidadOri";
            this.cboEntidadOri.Size = new System.Drawing.Size(355, 21);
            this.cboEntidadOri.TabIndex = 3;
            // 
            // cboTipoEntidadOri
            // 
            this.cboTipoEntidadOri.FormattingEnabled = true;
            this.cboTipoEntidadOri.Location = new System.Drawing.Point(90, 41);
            this.cboTipoEntidadOri.Name = "cboTipoEntidadOri";
            this.cboTipoEntidadOri.Size = new System.Drawing.Size(286, 21);
            this.cboTipoEntidadOri.TabIndex = 1;
            // 
            // lblTipoEntidad
            // 
            this.lblTipoEntidad.AutoSize = true;
            this.lblTipoEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoEntidad.Location = new System.Drawing.Point(6, 45);
            this.lblTipoEntidad.Name = "lblTipoEntidad";
            this.lblTipoEntidad.Size = new System.Drawing.Size(82, 13);
            this.lblTipoEntidad.TabIndex = 24;
            this.lblTipoEntidad.Text = "Tipo Entidad:";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoCuenta.Location = new System.Drawing.Point(6, 95);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(81, 13);
            this.lblTipoCuenta.TabIndex = 23;
            this.lblTipoCuenta.Text = "Tipo Cuenta:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCriterio.ForeColor = System.Drawing.Color.Navy;
            this.lblCriterio.Location = new System.Drawing.Point(7, 122);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(77, 13);
            this.lblCriterio.TabIndex = 22;
            this.lblCriterio.Text = "Nro Cuenta:";
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEntidad.ForeColor = System.Drawing.Color.Navy;
            this.lblEntidad.Location = new System.Drawing.Point(7, 70);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(54, 13);
            this.lblEntidad.TabIndex = 21;
            this.lblEntidad.Text = "Entidad:";
            // 
            // btnBusCtaOri
            // 
            this.btnBusCtaOri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCtaOri.BackgroundImage")));
            this.btnBusCtaOri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCtaOri.Location = new System.Drawing.Point(382, 13);
            this.btnBusCtaOri.Name = "btnBusCtaOri";
            this.btnBusCtaOri.Size = new System.Drawing.Size(60, 50);
            this.btnBusCtaOri.TabIndex = 2;
            this.btnBusCtaOri.Text = "&Buscar";
            this.btnBusCtaOri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCtaOri.UseVisualStyleBackColor = true;
            this.btnBusCtaOri.Click += new System.EventHandler(this.btnBusCtaOri_Click);
            // 
            // grbCtaDes
            // 
            this.grbCtaDes.Controls.Add(this.txtNumeroCtaDes);
            this.grbCtaDes.Controls.Add(this.txtSaldoDispDes);
            this.grbCtaDes.Controls.Add(this.lblBase12);
            this.grbCtaDes.Controls.Add(this.cboAgenDes);
            this.grbCtaDes.Controls.Add(this.lblBase2);
            this.grbCtaDes.Controls.Add(this.cboTipoCuentaBcoDes);
            this.grbCtaDes.Controls.Add(this.cboEntidadDes);
            this.grbCtaDes.Controls.Add(this.cboTipoEntidadDes);
            this.grbCtaDes.Controls.Add(this.lblBase3);
            this.grbCtaDes.Controls.Add(this.lblBase4);
            this.grbCtaDes.Controls.Add(this.lblBase5);
            this.grbCtaDes.Controls.Add(this.lblBase6);
            this.grbCtaDes.Controls.Add(this.btnBusCtaDes);
            this.grbCtaDes.Location = new System.Drawing.Point(467, 12);
            this.grbCtaDes.Name = "grbCtaDes";
            this.grbCtaDes.Size = new System.Drawing.Size(364, 200);
            this.grbCtaDes.TabIndex = 1;
            this.grbCtaDes.TabStop = false;
            this.grbCtaDes.Text = "Cuenta Destino";
            // 
            // txtNumeroCtaDes
            // 
            this.txtNumeroCtaDes.Location = new System.Drawing.Point(94, 117);
            this.txtNumeroCtaDes.Name = "txtNumeroCtaDes";
            this.txtNumeroCtaDes.Size = new System.Drawing.Size(258, 20);
            this.txtNumeroCtaDes.TabIndex = 4;
            // 
            // txtSaldoDispDes
            // 
            this.txtSaldoDispDes.FormatoDecimal = false;
            this.txtSaldoDispDes.Location = new System.Drawing.Point(124, 142);
            this.txtSaldoDispDes.Name = "txtSaldoDispDes";
            this.txtSaldoDispDes.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoDispDes.nNumDecimales = 2;
            this.txtSaldoDispDes.nvalor = 0D;
            this.txtSaldoDispDes.Size = new System.Drawing.Size(228, 20);
            this.txtSaldoDispDes.TabIndex = 5;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(6, 145);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(107, 13);
            this.lblBase12.TabIndex = 39;
            this.lblBase12.Text = "Saldo Disponible:";
            // 
            // cboAgenDes
            // 
            this.cboAgenDes.FormattingEnabled = true;
            this.cboAgenDes.Location = new System.Drawing.Point(94, 16);
            this.cboAgenDes.Name = "cboAgenDes";
            this.cboAgenDes.Size = new System.Drawing.Size(183, 21);
            this.cboAgenDes.TabIndex = 0;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 28;
            this.lblBase2.Text = "Agencia:";
            // 
            // cboTipoCuentaBcoDes
            // 
            this.cboTipoCuentaBcoDes.FormattingEnabled = true;
            this.cboTipoCuentaBcoDes.Location = new System.Drawing.Point(94, 92);
            this.cboTipoCuentaBcoDes.Name = "cboTipoCuentaBcoDes";
            this.cboTipoCuentaBcoDes.Size = new System.Drawing.Size(258, 21);
            this.cboTipoCuentaBcoDes.TabIndex = 3;
            // 
            // cboEntidadDes
            // 
            this.cboEntidadDes.FormattingEnabled = true;
            this.cboEntidadDes.Location = new System.Drawing.Point(94, 67);
            this.cboEntidadDes.Name = "cboEntidadDes";
            this.cboEntidadDes.Size = new System.Drawing.Size(258, 21);
            this.cboEntidadDes.TabIndex = 2;
            // 
            // cboTipoEntidadDes
            // 
            this.cboTipoEntidadDes.FormattingEnabled = true;
            this.cboTipoEntidadDes.Location = new System.Drawing.Point(94, 41);
            this.cboTipoEntidadDes.Name = "cboTipoEntidadDes";
            this.cboTipoEntidadDes.Size = new System.Drawing.Size(183, 21);
            this.cboTipoEntidadDes.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 45);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(82, 13);
            this.lblBase3.TabIndex = 24;
            this.lblBase3.Text = "Tipo Entidad:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 96);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(81, 13);
            this.lblBase4.TabIndex = 23;
            this.lblBase4.Text = "Tipo Cuenta:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 120);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(77, 13);
            this.lblBase5.TabIndex = 22;
            this.lblBase5.Text = "Nro Cuenta:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 71);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(54, 13);
            this.lblBase6.TabIndex = 21;
            this.lblBase6.Text = "Entidad:";
            // 
            // btnBusCtaDes
            // 
            this.btnBusCtaDes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCtaDes.BackgroundImage")));
            this.btnBusCtaDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCtaDes.Location = new System.Drawing.Point(292, 13);
            this.btnBusCtaDes.Name = "btnBusCtaDes";
            this.btnBusCtaDes.Size = new System.Drawing.Size(60, 50);
            this.btnBusCtaDes.TabIndex = 6;
            this.btnBusCtaDes.Text = "&Buscar";
            this.btnBusCtaDes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCtaDes.UseVisualStyleBackColor = true;
            this.btnBusCtaDes.Click += new System.EventHandler(this.btnBusCtaDes_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(759, 441);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnExtorno
            // 
            this.btnExtorno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno.BackgroundImage")));
            this.btnExtorno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno.Location = new System.Drawing.Point(534, 216);
            this.btnExtorno.Name = "btnExtorno";
            this.btnExtorno.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno.TabIndex = 4;
            this.btnExtorno.Text = "&Extornar";
            this.btnExtorno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno.UseVisualStyleBackColor = true;
            this.btnExtorno.Click += new System.EventHandler(this.btnExtorno_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgListaTransferencias);
            this.grbBase3.Location = new System.Drawing.Point(12, 273);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(819, 165);
            this.grbBase3.TabIndex = 3;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Lista De Tranasferencias De La Cuenta Origen";
            // 
            // dtgListaTransferencias
            // 
            this.dtgListaTransferencias.AllowUserToAddRows = false;
            this.dtgListaTransferencias.AllowUserToDeleteRows = false;
            this.dtgListaTransferencias.AllowUserToResizeColumns = false;
            this.dtgListaTransferencias.AllowUserToResizeRows = false;
            this.dtgListaTransferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgListaTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaTransferencias.Location = new System.Drawing.Point(10, 19);
            this.dtgListaTransferencias.MultiSelect = false;
            this.dtgListaTransferencias.Name = "dtgListaTransferencias";
            this.dtgListaTransferencias.ReadOnly = true;
            this.dtgListaTransferencias.RowHeadersVisible = false;
            this.dtgListaTransferencias.RowTemplate.Height = 18;
            this.dtgListaTransferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaTransferencias.Size = new System.Drawing.Size(797, 140);
            this.dtgListaTransferencias.TabIndex = 0;
            this.dtgListaTransferencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTransferencias_CellContentClick);
            this.dtgListaTransferencias.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaTransferencias_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Muestra Transferencias Del Dia";
            // 
            // frmTransferenciaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExtorno);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbCtaDes);
            this.Controls.Add(this.grbCtaOri);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmTransferenciaBancaria";
            this.Text = "Transferencia Interbancaria";
            this.Load += new System.EventHandler(this.frmTransferenciaBancaria_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnTransferir, 0);
            this.Controls.SetChildIndex(this.grbCtaOri, 0);
            this.Controls.SetChildIndex(this.grbCtaDes, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnExtorno, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.grbCtaOri.ResumeLayout(false);
            this.grbCtaOri.PerformLayout();
            this.grbCtaDes.ResumeLayout(false);
            this.grbCtaDes.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaTransferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnTransferir btnTransferir;
        private GEN.ControlesBase.grbBase grbCtaOri;
        private GEN.BotonesBase.btnBusqueda btnBusCtaOri;
        private GEN.ControlesBase.txtNumRea txtSaldoDispOri;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtMontoTrans;
        private GEN.ControlesBase.cboMotOperacionBco cboMotOperacionBco;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtNumeroCtaOri;
        private GEN.ControlesBase.cboAgencias cboAgenOri;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBcoOri;
        private GEN.ControlesBase.cboEntidad cboEntidadOri;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidadOri;
        private GEN.ControlesBase.lblBase lblTipoEntidad;
        private GEN.ControlesBase.lblBase lblTipoCuenta;
        private GEN.ControlesBase.lblBase lblCriterio;
        private GEN.ControlesBase.lblBase lblEntidad;
        private GEN.ControlesBase.grbBase grbCtaDes;
        private GEN.ControlesBase.cboAgencias cboAgenDes;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoCuentaBco cboTipoCuentaBcoDes;
        private GEN.ControlesBase.cboEntidad cboEntidadDes;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidadDes;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnBusqueda btnBusCtaDes;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnExtorno btnExtorno;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgListaTransferencias;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.txtNumRea txtSaldoDispDes;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtNumeroCtaDes;
        private GEN.ControlesBase.txtBase txtDescripción;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.dtLargoBase dtpfechaOperac;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase13;
    }
}