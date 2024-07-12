namespace DEP.Presentacion
{
    partial class frmTasaEspecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTasaEspecial));
            this.btnExtorAprob = new GEN.BotonesBase.Boton();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTasaEsp = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblEstExoner = new System.Windows.Forms.Label();
            this.CBNewSol = new System.Windows.Forms.CheckBox();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboPersSolicitud = new GEN.ControlesBase.cboPersonalGen(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMotivoDetalle = new GEN.ControlesBase.txtBase(this.components);
            this.dtFecSolicitud = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase21 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMotivos = new GEN.ControlesBase.cboMotivos(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.lblCaract = new GEN.ControlesBase.lblBase();
            this.lblTasa = new System.Windows.Forms.Label();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblTasaEfec = new GEN.ControlesBase.lblBase();
            this.lblEstadoCuenta = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblSaldoCont = new GEN.ControlesBase.lblBase();
            this.lblSaldoDisp = new GEN.ControlesBase.lblBase();
            this.lblTipoCta = new GEN.ControlesBase.lblBase();
            this.lblTipoPers = new GEN.ControlesBase.lblBase();
            this.lblTipoProd = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase38 = new GEN.ControlesBase.lblBase();
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.conBusCtaAho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExtorAprob
            // 
            this.btnExtorAprob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorAprob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtorAprob.Location = new System.Drawing.Point(589, 23);
            this.btnExtorAprob.Name = "btnExtorAprob";
            this.btnExtorAprob.Size = new System.Drawing.Size(60, 50);
            this.btnExtorAprob.TabIndex = 0;
            this.btnExtorAprob.Text = "Lista Solicitud Aprobadas";
            this.btnExtorAprob.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorAprob.UseVisualStyleBackColor = true;
            this.btnExtorAprob.Click += new System.EventHandler(this.btnExtorAprob_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Location = new System.Drawing.Point(511, 588);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(450, 588);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(634, 588);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(573, 588);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtTasaEsp);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Controls.Add(this.lblEstExoner);
            this.grbBase3.Controls.Add(this.CBNewSol);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.cboPersSolicitud);
            this.grbBase3.Controls.Add(this.lblBase22);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.txtMotivoDetalle);
            this.grbBase3.Controls.Add(this.dtFecSolicitud);
            this.grbBase3.Controls.Add(this.lblBase21);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.cboMotivos);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(374, 132);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(318, 300);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Solicitud";
            // 
            // txtTasaEsp
            // 
            this.txtTasaEsp.FormatoDecimal = false;
            this.txtTasaEsp.Location = new System.Drawing.Point(196, 54);
            this.txtTasaEsp.MaxLength = 7;
            this.txtTasaEsp.Name = "txtTasaEsp";
            this.txtTasaEsp.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasaEsp.nNumDecimales = 4;
            this.txtTasaEsp.nvalor = 0D;
            this.txtTasaEsp.Size = new System.Drawing.Size(109, 20);
            this.txtTasaEsp.TabIndex = 0;
            this.txtTasaEsp.Validating += new System.ComponentModel.CancelEventHandler(this.txtTasaEsp_Validating);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 57);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(147, 13);
            this.lblBase3.TabIndex = 66;
            this.lblBase3.Text = "Tasa Especial Solicitada:";
            // 
            // lblEstExoner
            // 
            this.lblEstExoner.AutoSize = true;
            this.lblEstExoner.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstExoner.ForeColor = System.Drawing.Color.Navy;
            this.lblEstExoner.Location = new System.Drawing.Point(161, 31);
            this.lblEstExoner.Name = "lblEstExoner";
            this.lblEstExoner.Size = new System.Drawing.Size(0, 13);
            this.lblEstExoner.TabIndex = 61;
            // 
            // CBNewSol
            // 
            this.CBNewSol.AutoSize = true;
            this.CBNewSol.ForeColor = System.Drawing.Color.Navy;
            this.CBNewSol.Location = new System.Drawing.Point(29, 273);
            this.CBNewSol.Name = "CBNewSol";
            this.CBNewSol.Size = new System.Drawing.Size(153, 17);
            this.CBNewSol.TabIndex = 56;
            this.CBNewSol.Text = "Enviar una nueva Solicitud";
            this.CBNewSol.UseVisualStyleBackColor = true;
            this.CBNewSol.Visible = false;
            this.CBNewSol.CheckedChanged += new System.EventHandler(this.CBNewSol_CheckedChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(26, 31);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(121, 13);
            this.lblBase7.TabIndex = 60;
            this.lblBase7.Text = "Estado Solic. Exon.:";
            // 
            // cboPersSolicitud
            // 
            this.cboPersSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersSolicitud.Enabled = false;
            this.cboPersSolicitud.FormattingEnabled = true;
            this.cboPersSolicitud.Location = new System.Drawing.Point(93, 245);
            this.cboPersSolicitud.Name = "cboPersSolicitud";
            this.cboPersSolicitud.Size = new System.Drawing.Size(212, 21);
            this.cboPersSolicitud.TabIndex = 4;
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(26, 88);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(49, 13);
            this.lblBase22.TabIndex = 52;
            this.lblBase22.Text = "Motivo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(26, 248);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(61, 13);
            this.lblBase2.TabIndex = 64;
            this.lblBase2.Text = "Personal:";
            // 
            // txtMotivoDetalle
            // 
            this.txtMotivoDetalle.Location = new System.Drawing.Point(29, 133);
            this.txtMotivoDetalle.MaxLength = 500;
            this.txtMotivoDetalle.Multiline = true;
            this.txtMotivoDetalle.Name = "txtMotivoDetalle";
            this.txtMotivoDetalle.Size = new System.Drawing.Size(276, 68);
            this.txtMotivoDetalle.TabIndex = 2;
            // 
            // dtFecSolicitud
            // 
            this.dtFecSolicitud.Enabled = false;
            this.dtFecSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecSolicitud.Location = new System.Drawing.Point(129, 214);
            this.dtFecSolicitud.Name = "dtFecSolicitud";
            this.dtFecSolicitud.Size = new System.Drawing.Size(176, 20);
            this.dtFecSolicitud.TabIndex = 3;
            // 
            // lblBase21
            // 
            this.lblBase21.AutoSize = true;
            this.lblBase21.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase21.ForeColor = System.Drawing.Color.Navy;
            this.lblBase21.Location = new System.Drawing.Point(26, 116);
            this.lblBase21.Name = "lblBase21";
            this.lblBase21.Size = new System.Drawing.Size(114, 13);
            this.lblBase21.TabIndex = 53;
            this.lblBase21.Text = "Detalle del Motivo:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 218);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(97, 13);
            this.lblBase1.TabIndex = 63;
            this.lblBase1.Text = "Fecha Solicitud:";
            // 
            // cboMotivos
            // 
            this.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivos.FormattingEnabled = true;
            this.cboMotivos.Location = new System.Drawing.Point(93, 85);
            this.cboMotivos.Name = "cboMotivos";
            this.cboMotivos.Size = new System.Drawing.Size(212, 21);
            this.cboMotivos.TabIndex = 1;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblCaract);
            this.grbBase4.Controls.Add(this.lblTasa);
            this.grbBase4.Controls.Add(this.lblBase11);
            this.grbBase4.Controls.Add(this.lblTasaEfec);
            this.grbBase4.Controls.Add(this.lblEstadoCuenta);
            this.grbBase4.Controls.Add(this.lblBase10);
            this.grbBase4.Controls.Add(this.lblBase15);
            this.grbBase4.Controls.Add(this.lblBase6);
            this.grbBase4.Controls.Add(this.lblSaldoCont);
            this.grbBase4.Controls.Add(this.lblSaldoDisp);
            this.grbBase4.Controls.Add(this.lblTipoCta);
            this.grbBase4.Controls.Add(this.lblTipoPers);
            this.grbBase4.Controls.Add(this.lblTipoProd);
            this.grbBase4.Controls.Add(this.lblBase8);
            this.grbBase4.Controls.Add(this.lblBase9);
            this.grbBase4.Controls.Add(this.lblBase4);
            this.grbBase4.Controls.Add(this.lblBase5);
            this.grbBase4.Controls.Add(this.lblBase16);
            this.grbBase4.ForeColor = System.Drawing.Color.Navy;
            this.grbBase4.Location = new System.Drawing.Point(15, 132);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(348, 300);
            this.grbBase4.TabIndex = 1;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Datos de la Cuenta";
            // 
            // lblCaract
            // 
            this.lblCaract.AutoSize = true;
            this.lblCaract.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCaract.ForeColor = System.Drawing.Color.Navy;
            this.lblCaract.Location = new System.Drawing.Point(144, 276);
            this.lblCaract.Name = "lblCaract";
            this.lblCaract.Size = new System.Drawing.Size(0, 13);
            this.lblCaract.TabIndex = 72;
            // 
            // lblTasa
            // 
            this.lblTasa.AutoSize = true;
            this.lblTasa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasa.ForeColor = System.Drawing.Color.Navy;
            this.lblTasa.Location = new System.Drawing.Point(144, 32);
            this.lblTasa.Name = "lblTasa";
            this.lblTasa.Size = new System.Drawing.Size(0, 13);
            this.lblTasa.TabIndex = 66;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(17, 276);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(91, 13);
            this.lblBase11.TabIndex = 71;
            this.lblBase11.Text = "Característica:";
            // 
            // lblTasaEfec
            // 
            this.lblTasaEfec.AutoSize = true;
            this.lblTasaEfec.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTasaEfec.ForeColor = System.Drawing.Color.Navy;
            this.lblTasaEfec.Location = new System.Drawing.Point(142, 59);
            this.lblTasaEfec.Name = "lblTasaEfec";
            this.lblTasaEfec.Size = new System.Drawing.Size(0, 13);
            this.lblTasaEfec.TabIndex = 62;
            // 
            // lblEstadoCuenta
            // 
            this.lblEstadoCuenta.AutoSize = true;
            this.lblEstadoCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstadoCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblEstadoCuenta.Location = new System.Drawing.Point(144, 245);
            this.lblEstadoCuenta.Name = "lblEstadoCuenta";
            this.lblEstadoCuenta.Size = new System.Drawing.Size(0, 13);
            this.lblEstadoCuenta.TabIndex = 70;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(15, 59);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(87, 13);
            this.lblBase10.TabIndex = 61;
            this.lblBase10.Text = "Tasa Efectiva:";
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(17, 245);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(127, 13);
            this.lblBase15.TabIndex = 69;
            this.lblBase15.Text = "Estado de la Cuenta:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 31);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(84, 13);
            this.lblBase6.TabIndex = 60;
            this.lblBase6.Text = "Tipo de Tasa:";
            // 
            // lblSaldoCont
            // 
            this.lblSaldoCont.AutoSize = true;
            this.lblSaldoCont.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoCont.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoCont.Location = new System.Drawing.Point(142, 120);
            this.lblSaldoCont.Name = "lblSaldoCont";
            this.lblSaldoCont.Size = new System.Drawing.Size(0, 13);
            this.lblSaldoCont.TabIndex = 59;
            // 
            // lblSaldoDisp
            // 
            this.lblSaldoDisp.AutoSize = true;
            this.lblSaldoDisp.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSaldoDisp.ForeColor = System.Drawing.Color.Navy;
            this.lblSaldoDisp.Location = new System.Drawing.Point(142, 89);
            this.lblSaldoDisp.Name = "lblSaldoDisp";
            this.lblSaldoDisp.Size = new System.Drawing.Size(0, 13);
            this.lblSaldoDisp.TabIndex = 58;
            // 
            // lblTipoCta
            // 
            this.lblTipoCta.AutoSize = true;
            this.lblTipoCta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoCta.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoCta.Location = new System.Drawing.Point(143, 181);
            this.lblTipoCta.Name = "lblTipoCta";
            this.lblTipoCta.Size = new System.Drawing.Size(0, 13);
            this.lblTipoCta.TabIndex = 56;
            // 
            // lblTipoPers
            // 
            this.lblTipoPers.AutoSize = true;
            this.lblTipoPers.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoPers.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoPers.Location = new System.Drawing.Point(143, 213);
            this.lblTipoPers.Name = "lblTipoPers";
            this.lblTipoPers.Size = new System.Drawing.Size(0, 13);
            this.lblTipoPers.TabIndex = 55;
            // 
            // lblTipoProd
            // 
            this.lblTipoProd.AutoSize = true;
            this.lblTipoProd.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoProd.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoProd.Location = new System.Drawing.Point(143, 151);
            this.lblTipoProd.Name = "lblTipoProd";
            this.lblTipoProd.Size = new System.Drawing.Size(0, 13);
            this.lblTipoProd.TabIndex = 54;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(15, 120);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(99, 13);
            this.lblBase8.TabIndex = 50;
            this.lblBase8.Text = "Saldo Contable:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(15, 89);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(107, 13);
            this.lblBase9.TabIndex = 51;
            this.lblBase9.Text = "Saldo Disponible:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 151);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(112, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Tipo de  Producto:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 181);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Tipo de Cuenta:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(17, 213);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(104, 13);
            this.lblBase16.TabIndex = 35;
            this.lblBase16.Text = "Tipo de Persona:";
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Controls.Add(this.txtNombre);
            this.conBusCtaAho.Controls.Add(this.grbBase1);
            this.conBusCtaAho.Controls.Add(this.txtBase1);
            this.conBusCtaAho.Controls.Add(this.grbBase2);
            this.conBusCtaAho.Location = new System.Drawing.Point(12, 12);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(571, 114);
            this.conBusCtaAho.TabIndex = 54;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho1_ClicBusCta);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(158, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(556, 112);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase1.Location = new System.Drawing.Point(158, 82);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(395, 20);
            this.txtBase1.TabIndex = 15;
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, -1);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(556, 112);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // lblBase38
            // 
            this.lblBase38.AutoSize = true;
            this.lblBase38.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase38.ForeColor = System.Drawing.Color.Navy;
            this.lblBase38.Location = new System.Drawing.Point(4, 439);
            this.lblBase38.Name = "lblBase38";
            this.lblBase38.Size = new System.Drawing.Size(282, 13);
            this.lblBase38.TabIndex = 70;
            this.lblBase38.Text = "Solicitudes y Aprobaciones de Tasas Especiales:";
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.Location = new System.Drawing.Point(7, 455);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(690, 126);
            this.dtgSolicitudes.TabIndex = 7;
            // 
            // frmTasaEspecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 667);
            this.Controls.Add(this.lblBase38);
            this.Controls.Add(this.dtgSolicitudes);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.btnExtorAprob);
            this.Controls.Add(this.conBusCtaAho);
            this.Name = "frmTasaEspecial";
            this.Text = "Tasa Especial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTasaEspecial_FormClosed);
            this.Load += new System.EventHandler(this.frmTasaEspecial_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.btnExtorAprob, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.dtgSolicitudes, 0);
            this.Controls.SetChildIndex(this.lblBase38, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.conBusCtaAho.ResumeLayout(false);
            this.conBusCtaAho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.Boton btnExtorAprob;
        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.Label lblEstExoner;
        private System.Windows.Forms.CheckBox CBNewSol;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboPersonalGen cboPersSolicitud;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMotivoDetalle;
        private GEN.ControlesBase.dtpCorto dtFecSolicitud;
        private GEN.ControlesBase.lblBase lblBase21;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMotivos cboMotivos;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase4;
        private System.Windows.Forms.Label lblTasa;
        private GEN.ControlesBase.lblBase lblTasaEfec;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblSaldoCont;
        private GEN.ControlesBase.lblBase lblSaldoDisp;
        private GEN.ControlesBase.lblBase lblTipoCta;
        private GEN.ControlesBase.lblBase lblTipoPers;
        private GEN.ControlesBase.lblBase lblTipoProd;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblCaract;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblEstadoCuenta;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.txtNumRea txtTasaEsp;
        private GEN.ControlesBase.lblBase lblBase38;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
    }
}