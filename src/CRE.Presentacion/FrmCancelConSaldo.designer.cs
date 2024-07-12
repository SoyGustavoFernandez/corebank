namespace CRE.Presentacion
{
    partial class FrmCancelConSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCancelConSaldo));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.txtMot = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCap = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtInt = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtOtro = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMora = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtIntComp = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.cboMot = new GEN.ControlesBase.cboMotivos(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblEstSolicitud = new System.Windows.Forms.Label();
            this.lblFecAprob = new GEN.ControlesBase.lblBase();
            this.dtFecSolicitud = new System.Windows.Forms.DateTimePicker();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtAgenReg = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtUruReg = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSolAprobadas = new GEN.BotonesBase.btnSolAprobadas();
            this.lblMensaje = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Location = new System.Drawing.Point(12, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(556, 102);
            this.conBusCuentaCli.TabIndex = 2;
            // 
            // txtMot
            // 
            this.txtMot.Enabled = false;
            this.txtMot.Location = new System.Drawing.Point(303, 88);
            this.txtMot.Multiline = true;
            this.txtMot.Name = "txtMot";
            this.txtMot.Size = new System.Drawing.Size(306, 62);
            this.txtMot.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(300, 42);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(111, 13);
            this.lblBase1.TabIndex = 8;
            this.lblBase1.Text = "Mot. condonación:";
            // 
            // txtCap
            // 
            this.txtCap.Enabled = false;
            this.txtCap.FormatoDecimal = false;
            this.txtCap.Location = new System.Drawing.Point(156, 19);
            this.txtCap.Name = "txtCap";
            this.txtCap.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCap.nNumDecimales = 4;
            this.txtCap.nvalor = 0D;
            this.txtCap.Size = new System.Drawing.Size(106, 20);
            this.txtCap.TabIndex = 9;
            this.txtCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInt
            // 
            this.txtInt.Enabled = false;
            this.txtInt.FormatoDecimal = false;
            this.txtInt.Location = new System.Drawing.Point(156, 42);
            this.txtInt.Name = "txtInt";
            this.txtInt.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInt.nNumDecimales = 4;
            this.txtInt.nvalor = 0D;
            this.txtInt.Size = new System.Drawing.Size(106, 20);
            this.txtInt.TabIndex = 10;
            this.txtInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOtro
            // 
            this.txtOtro.Enabled = false;
            this.txtOtro.FormatoDecimal = false;
            this.txtOtro.Location = new System.Drawing.Point(156, 88);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOtro.nNumDecimales = 4;
            this.txtOtro.nvalor = 0D;
            this.txtOtro.Size = new System.Drawing.Size(106, 20);
            this.txtOtro.TabIndex = 11;
            this.txtOtro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMora
            // 
            this.txtMora.Enabled = false;
            this.txtMora.FormatoDecimal = false;
            this.txtMora.Location = new System.Drawing.Point(156, 111);
            this.txtMora.Name = "txtMora";
            this.txtMora.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMora.nNumDecimales = 4;
            this.txtMora.nvalor = 0D;
            this.txtMora.Size = new System.Drawing.Size(106, 20);
            this.txtMora.TabIndex = 12;
            this.txtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.FormatoDecimal = false;
            this.txtTotal.Location = new System.Drawing.Point(156, 134);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 4;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.Size = new System.Drawing.Size(106, 20);
            this.txtTotal.TabIndex = 13;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(26, 23);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(52, 13);
            this.lblBase2.TabIndex = 14;
            this.lblBase2.Text = "Capital:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 46);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(53, 13);
            this.lblBase3.TabIndex = 15;
            this.lblBase3.Text = "Interés:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(26, 92);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(43, 13);
            this.lblBase4.TabIndex = 16;
            this.lblBase4.Text = "Otros:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(26, 115);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(40, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Mora:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(26, 138);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(48, 13);
            this.lblBase6.TabIndex = 18;
            this.lblBase6.Text = "TOTAL:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(300, 69);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(109, 13);
            this.lblBase7.TabIndex = 19;
            this.lblBase7.Text = "Detalle del Motivo";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase14);
            this.grbBase1.Controls.Add(this.cboMotivoOperacion);
            this.grbBase1.Controls.Add(this.txtIntComp);
            this.grbBase1.Controls.Add(this.lblBase13);
            this.grbBase1.Controls.Add(this.cboMot);
            this.grbBase1.Controls.Add(this.txtTotal);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.txtMot);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtCap);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtMora);
            this.grbBase1.Controls.Add(this.txtInt);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.txtOtro);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 240);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(618, 166);
            this.grbBase1.TabIndex = 20;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle de Condonación";
            // 
            // txtIntComp
            // 
            this.txtIntComp.Enabled = false;
            this.txtIntComp.FormatoDecimal = false;
            this.txtIntComp.Location = new System.Drawing.Point(156, 65);
            this.txtIntComp.Name = "txtIntComp";
            this.txtIntComp.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtIntComp.nNumDecimales = 4;
            this.txtIntComp.nvalor = 0D;
            this.txtIntComp.Size = new System.Drawing.Size(106, 20);
            this.txtIntComp.TabIndex = 34;
            this.txtIntComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(26, 69);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(123, 13);
            this.lblBase13.TabIndex = 33;
            this.lblBase13.Text = "Int. Compensatorio:";
            // 
            // cboMot
            // 
            this.cboMot.Enabled = false;
            this.cboMot.FormattingEnabled = true;
            this.cboMot.Location = new System.Drawing.Point(414, 38);
            this.cboMot.Name = "cboMot";
            this.cboMot.Size = new System.Drawing.Size(195, 21);
            this.cboMot.TabIndex = 32;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(23, 22);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(90, 13);
            this.lblBase8.TabIndex = 20;
            this.lblBase8.Text = "Solicitado por:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblEstSolicitud);
            this.grbBase2.Controls.Add(this.lblFecAprob);
            this.grbBase2.Controls.Add(this.dtFecSolicitud);
            this.grbBase2.Controls.Add(this.lblBase12);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.txtAgenReg);
            this.grbBase2.Controls.Add(this.txtUruReg);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(12, 120);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(618, 115);
            this.grbBase2.TabIndex = 31;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Solicitud";
            // 
            // lblEstSolicitud
            // 
            this.lblEstSolicitud.AutoSize = true;
            this.lblEstSolicitud.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstSolicitud.ForeColor = System.Drawing.Color.Navy;
            this.lblEstSolicitud.Location = new System.Drawing.Point(130, 79);
            this.lblEstSolicitud.Name = "lblEstSolicitud";
            this.lblEstSolicitud.Size = new System.Drawing.Size(0, 13);
            this.lblEstSolicitud.TabIndex = 38;
            // 
            // lblFecAprob
            // 
            this.lblFecAprob.AutoSize = true;
            this.lblFecAprob.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecAprob.ForeColor = System.Drawing.Color.Navy;
            this.lblFecAprob.Location = new System.Drawing.Point(449, 79);
            this.lblFecAprob.Name = "lblFecAprob";
            this.lblFecAprob.Size = new System.Drawing.Size(0, 13);
            this.lblFecAprob.TabIndex = 49;
            // 
            // dtFecSolicitud
            // 
            this.dtFecSolicitud.Enabled = false;
            this.dtFecSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecSolicitud.Location = new System.Drawing.Point(450, 47);
            this.dtFecSolicitud.Name = "dtFecSolicitud";
            this.dtFecSolicitud.Size = new System.Drawing.Size(139, 20);
            this.dtFecSolicitud.TabIndex = 47;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(318, 78);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(131, 13);
            this.lblBase12.TabIndex = 26;
            this.lblBase12.Text = "Fecha de Aprobación:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(23, 78);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(102, 13);
            this.lblBase11.TabIndex = 25;
            this.lblBase11.Text = "Estado Solicitud:";
            // 
            // txtAgenReg
            // 
            this.txtAgenReg.Enabled = false;
            this.txtAgenReg.FormatoDecimal = false;
            this.txtAgenReg.Location = new System.Drawing.Point(133, 47);
            this.txtAgenReg.Name = "txtAgenReg";
            this.txtAgenReg.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAgenReg.nNumDecimales = 4;
            this.txtAgenReg.nvalor = 0D;
            this.txtAgenReg.Size = new System.Drawing.Size(165, 20);
            this.txtAgenReg.TabIndex = 23;
            // 
            // txtUruReg
            // 
            this.txtUruReg.Enabled = false;
            this.txtUruReg.FormatoDecimal = false;
            this.txtUruReg.Location = new System.Drawing.Point(133, 19);
            this.txtUruReg.Name = "txtUruReg";
            this.txtUruReg.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUruReg.nNumDecimales = 4;
            this.txtUruReg.nvalor = 0D;
            this.txtUruReg.Size = new System.Drawing.Size(456, 20);
            this.txtUruReg.TabIndex = 20;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(319, 50);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(115, 13);
            this.lblBase10.TabIndex = 22;
            this.lblBase10.Text = "Fecha de Solicitud:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(23, 50);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(57, 13);
            this.lblBase9.TabIndex = 21;
            this.lblBase9.Text = "Agencia:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(570, 412);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(444, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSolAprobadas
            // 
            this.btnSolAprobadas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolAprobadas.BackgroundImage")));
            this.btnSolAprobadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolAprobadas.Location = new System.Drawing.Point(570, 21);
            this.btnSolAprobadas.Name = "btnSolAprobadas";
            this.btnSolAprobadas.Size = new System.Drawing.Size(60, 50);
            this.btnSolAprobadas.TabIndex = 42;
            this.btnSolAprobadas.Text = "&S. Aprob.";
            this.btnSolAprobadas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolAprobadas.UseVisualStyleBackColor = true;
            this.btnSolAprobadas.Click += new System.EventHandler(this.btnSolAprobadas_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Navy;
            this.lblMensaje.Location = new System.Drawing.Point(41, 433);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 13);
            this.lblMensaje.TabIndex = 43;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(507, 412);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 32;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.Enabled = false;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(414, 14);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(195, 21);
            this.cboMotivoOperacion.TabIndex = 35;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(300, 18);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(96, 13);
            this.lblBase14.TabIndex = 36;
            this.lblBase14.Text = "Mot. operación:";
            // 
            // FrmCancelConSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ClientSize = new System.Drawing.Size(640, 487);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnSolAprobadas);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Name = "FrmCancelConSaldo";
            this.Text = "Condonación de Deuda";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCancelConSaldo_FormClosed);
            this.Load += new System.EventHandler(this.FrmCancelConSaldo_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSolAprobadas, 0);
            this.Controls.SetChildIndex(this.lblMensaje, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.txtBase txtMot;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtCap;
        private GEN.ControlesBase.txtNumRea txtInt;
        private GEN.ControlesBase.txtNumRea txtOtro;
        private GEN.ControlesBase.txtNumRea txtMora;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtAgenReg;
        private GEN.ControlesBase.txtNumRea txtUruReg;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.DateTimePicker dtFecSolicitud;
        private GEN.ControlesBase.lblBase lblFecAprob;
        private System.Windows.Forms.Label lblEstSolicitud;
        private GEN.ControlesBase.cboMotivos cboMot;
        private GEN.BotonesBase.btnSolAprobadas btnSolAprobadas;
        private GEN.ControlesBase.lblBase lblMensaje;
        private GEN.ControlesBase.txtNumRea txtIntComp;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;
    }
}