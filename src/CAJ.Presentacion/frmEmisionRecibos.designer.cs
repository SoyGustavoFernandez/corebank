namespace CAJ.Presentacion
{
    partial class frmEmisionRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmisionRecibos));
            this.cboTipRec = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboConcepto = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcAfectaCaja = new System.Windows.Forms.CheckBox();
            this.lblAge = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.txtMonRec = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtMonItf = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtTotRec = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.chcBuscar = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtNroRec = new GEN.ControlesBase.txtBase(this.components);
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.chcColab = new GEN.ControlesBase.chcBase(this.components);
            this.chcCliente = new GEN.ControlesBase.chcBase(this.components);
            this.conCalcVuelto = new GEN.ControlesBase.conCalcVuelto();
            this.btnReciboProvicional = new System.Windows.Forms.Button();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnBusRec = new GEN.BotonesBase.btnBusqueda();
            this.btnCuentasPagar = new GEN.BotonesBase.btnPagar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTipRec
            // 
            this.cboTipRec.FormattingEnabled = true;
            this.cboTipRec.Location = new System.Drawing.Point(376, 22);
            this.cboTipRec.Name = "cboTipRec";
            this.cboTipRec.Size = new System.Drawing.Size(167, 21);
            this.cboTipRec.TabIndex = 1;
            this.cboTipRec.SelectedIndexChanged += new System.EventHandler(this.cboTipRec_SelectedIndexChanged);
            this.cboTipRec.SelectedValueChanged += new System.EventHandler(this.cboTipRec_SelectedValueChanged);
            this.cboTipRec.Click += new System.EventHandler(this.cboTipRec_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(295, 26);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Tipo Recibo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(297, 53);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(66, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Concepto:";
            // 
            // cboConcepto
            // 
            this.cboConcepto.DropDownWidth = 310;
            this.cboConcepto.FormattingEnabled = true;
            this.cboConcepto.Location = new System.Drawing.Point(376, 50);
            this.cboConcepto.Name = "cboConcepto";
            this.cboConcepto.Size = new System.Drawing.Size(167, 21);
            this.cboConcepto.TabIndex = 2;
            this.cboConcepto.SelectedIndexChanged += new System.EventHandler(this.cboConcepto_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(8, 26);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 15;
            this.lblBase5.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(89, 22);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(174, 21);
            this.cboMoneda.TabIndex = 0;
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Enabled = false;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(5, 314);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(547, 82);
            this.conBusCli.TabIndex = 3;
            this.conBusCli.ChangeDocumentoID += new System.EventHandler(this.conBusCli_ChangeDocumentoID);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcAfectaCaja);
            this.grbBase1.Controls.Add(this.lblAge);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboConcepto);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboTipRec);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Location = new System.Drawing.Point(5, 88);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(551, 98);
            this.grbBase1.TabIndex = 19;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales";
            // 
            // chcAfectaCaja
            // 
            this.chcAfectaCaja.AutoSize = true;
            this.chcAfectaCaja.Enabled = false;
            this.chcAfectaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcAfectaCaja.ForeColor = System.Drawing.Color.Navy;
            this.chcAfectaCaja.Location = new System.Drawing.Point(376, 77);
            this.chcAfectaCaja.Name = "chcAfectaCaja";
            this.chcAfectaCaja.Size = new System.Drawing.Size(103, 17);
            this.chcAfectaCaja.TabIndex = 99;
            this.chcAfectaCaja.Text = "Afecta a Caja";
            this.chcAfectaCaja.UseVisualStyleBackColor = true;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblAge.ForeColor = System.Drawing.Color.Navy;
            this.lblAge.Location = new System.Drawing.Point(8, 49);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(78, 13);
            this.lblAge.TabIndex = 98;
            this.lblAge.Text = "Ag. Destino:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.Enabled = false;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(89, 46);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(174, 21);
            this.cboAgencias.TabIndex = 97;
            // 
            // txtMonRec
            // 
            this.txtMonRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonRec.FormatoDecimal = true;
            this.txtMonRec.Location = new System.Drawing.Point(104, 410);
            this.txtMonRec.Name = "txtMonRec";
            this.txtMonRec.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonRec.nNumDecimales = 2;
            this.txtMonRec.nvalor = 0D;
            this.txtMonRec.Size = new System.Drawing.Size(104, 22);
            this.txtMonRec.TabIndex = 4;
            this.txtMonRec.Text = "0.00";
            this.txtMonRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonRec.TextChanged += new System.EventHandler(this.txtMonRec_TextChanged);
            this.txtMonRec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonRec_KeyPress);
            this.txtMonRec.Validated += new System.EventHandler(this.txtMonRec_Validated);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 414);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(88, 13);
            this.lblBase6.TabIndex = 20;
            this.lblBase6.Text = "Monto Recibo:";
            // 
            // txtMonItf
            // 
            this.txtMonItf.Enabled = false;
            this.txtMonItf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonItf.FormatoDecimal = false;
            this.txtMonItf.Location = new System.Drawing.Point(252, 411);
            this.txtMonItf.Name = "txtMonItf";
            this.txtMonItf.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonItf.nNumDecimales = 4;
            this.txtMonItf.nvalor = 0D;
            this.txtMonItf.Size = new System.Drawing.Size(66, 22);
            this.txtMonItf.TabIndex = 23;
            this.txtMonItf.Text = "0.00";
            this.txtMonItf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(216, 415);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(30, 13);
            this.lblBase7.TabIndex = 22;
            this.lblBase7.Text = "ITF:";
            // 
            // txtTotRec
            // 
            this.txtTotRec.Enabled = false;
            this.txtTotRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotRec.FormatoDecimal = false;
            this.txtTotRec.Location = new System.Drawing.Point(416, 14);
            this.txtTotRec.Name = "txtTotRec";
            this.txtTotRec.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotRec.nNumDecimales = 4;
            this.txtTotRec.nvalor = 0D;
            this.txtTotRec.Size = new System.Drawing.Size(116, 22);
            this.txtTotRec.TabIndex = 25;
            this.txtTotRec.Text = "0.00";
            this.txtTotRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(332, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(81, 13);
            this.lblBase8.TabIndex = 24;
            this.lblBase8.Text = "Total Recibo:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(37, 438);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 26;
            this.lblBase9.Text = "Sustento:";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(104, 435);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(432, 32);
            this.txtSustento.TabIndex = 5;
            this.txtSustento.TextChanged += new System.EventHandler(this.txtSustento_TextChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTotRec);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Location = new System.Drawing.Point(4, 396);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(549, 73);
            this.grbBase2.TabIndex = 33;
            this.grbBase2.TabStop = false;
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Enabled = false;
            this.txtNomUsu.Location = new System.Drawing.Point(77, 61);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(247, 20);
            this.txtNomUsu.TabIndex = 62;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 65);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 61;
            this.lblBase1.Text = "Nombre:";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Enabled = false;
            this.txtCodUsu.Location = new System.Drawing.Point(268, 33);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(50, 20);
            this.txtCodUsu.TabIndex = 60;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(210, 36);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(52, 13);
            this.lblBase10.TabIndex = 59;
            this.lblBase10.Text = "Código:";
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Enabled = false;
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(77, 18);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaSis.TabIndex = 57;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(13, 21);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(45, 13);
            this.lblBase11.TabIndex = 58;
            this.lblBase11.Text = "Fecha:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtUsuario);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.txtCodUsu);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Location = new System.Drawing.Point(6, 3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(326, 85);
            this.grbBase3.TabIndex = 63;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Sistema";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(71, 37);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(102, 20);
            this.txtUsuario.TabIndex = 50;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(7, 40);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(55, 13);
            this.lblBase12.TabIndex = 49;
            this.lblBase12.Text = "Usuario:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.chcBuscar);
            this.grbBase4.Controls.Add(this.lblBase13);
            this.grbBase4.Controls.Add(this.txtNroRec);
            this.grbBase4.Location = new System.Drawing.Point(334, 25);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(222, 63);
            this.grbBase4.TabIndex = 64;
            this.grbBase4.TabStop = false;
            // 
            // chcBuscar
            // 
            this.chcBuscar.AutoSize = true;
            this.chcBuscar.Location = new System.Drawing.Point(6, 15);
            this.chcBuscar.Name = "chcBuscar";
            this.chcBuscar.Size = new System.Drawing.Size(96, 17);
            this.chcBuscar.TabIndex = 67;
            this.chcBuscar.Text = "Buscar Recibo";
            this.chcBuscar.UseVisualStyleBackColor = true;
            this.chcBuscar.CheckedChanged += new System.EventHandler(this.chcBuscar_CheckedChanged);
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(6, 37);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(74, 13);
            this.lblBase13.TabIndex = 66;
            this.lblBase13.Text = "Nro Recibo:";
            // 
            // txtNroRec
            // 
            this.txtNroRec.Enabled = false;
            this.txtNroRec.Location = new System.Drawing.Point(81, 34);
            this.txtNroRec.Name = "txtNroRec";
            this.txtNroRec.Size = new System.Drawing.Size(68, 20);
            this.txtNroRec.TabIndex = 65;
            this.txtNroRec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroRec_KeyPress);
            // 
            // conBusCol
            // 
            this.conBusCol.cEstado = "0";
            this.conBusCol.Location = new System.Drawing.Point(6, 205);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(389, 87);
            this.conBusCol.TabIndex = 1;
            // 
            // chcColab
            // 
            this.chcColab.AutoSize = true;
            this.chcColab.Enabled = false;
            this.chcColab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcColab.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcColab.Location = new System.Drawing.Point(187, 193);
            this.chcColab.Name = "chcColab";
            this.chcColab.Size = new System.Drawing.Size(203, 17);
            this.chcColab.TabIndex = 0;
            this.chcColab.Text = "Habilitar Datos del Colaborador";
            this.chcColab.UseVisualStyleBackColor = true;
            this.chcColab.CheckedChanged += new System.EventHandler(this.chcColab_CheckedChanged);
            // 
            // chcCliente
            // 
            this.chcCliente.AutoSize = true;
            this.chcCliente.Enabled = false;
            this.chcCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcCliente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.chcCliente.Location = new System.Drawing.Point(186, 297);
            this.chcCliente.Name = "chcCliente";
            this.chcCliente.Size = new System.Drawing.Size(174, 17);
            this.chcCliente.TabIndex = 2;
            this.chcCliente.Text = "Habilitar Datos del Cliente";
            this.chcCliente.UseVisualStyleBackColor = true;
            this.chcCliente.CheckedChanged += new System.EventHandler(this.chcCliente_CheckedChanged);
            // 
            // conCalcVuelto
            // 
            this.conCalcVuelto.Location = new System.Drawing.Point(6, 469);
            this.conCalcVuelto.Name = "conCalcVuelto";
            this.conCalcVuelto.Size = new System.Drawing.Size(192, 61);
            this.conCalcVuelto.TabIndex = 65;
            // 
            // btnReciboProvicional
            // 
            this.btnReciboProvicional.Location = new System.Drawing.Point(415, 5);
            this.btnReciboProvicional.Name = "btnReciboProvicional";
            this.btnReciboProvicional.Size = new System.Drawing.Size(138, 23);
            this.btnReciboProvicional.TabIndex = 66;
            this.btnReciboProvicional.Text = "Cargar recibo provisional";
            this.btnReciboProvicional.UseVisualStyleBackColor = true;
            this.btnReciboProvicional.Visible = false;
            this.btnReciboProvicional.Click += new System.EventHandler(this.btnReciboProvicional_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(513, 473);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(450, 473);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(387, 473);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(324, 473);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBusRec
            // 
            this.btnBusRec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusRec.BackgroundImage")));
            this.btnBusRec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusRec.Enabled = false;
            this.btnBusRec.Location = new System.Drawing.Point(489, 34);
            this.btnBusRec.Name = "btnBusRec";
            this.btnBusRec.Size = new System.Drawing.Size(60, 50);
            this.btnBusRec.TabIndex = 10;
            this.btnBusRec.Text = "&Buscar";
            this.btnBusRec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusRec.UseVisualStyleBackColor = true;
            this.btnBusRec.Click += new System.EventHandler(this.btnBusRec_Click);
            // 
            // btnCuentasPagar
            // 
            this.btnCuentasPagar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCuentasPagar.BackgroundImage")));
            this.btnCuentasPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCuentasPagar.Location = new System.Drawing.Point(258, 473);
            this.btnCuentasPagar.Name = "btnCuentasPagar";
            this.btnCuentasPagar.Size = new System.Drawing.Size(60, 50);
            this.btnCuentasPagar.TabIndex = 69;
            this.btnCuentasPagar.Text = "Entregas a Rendir";
            this.btnCuentasPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCuentasPagar.UseVisualStyleBackColor = true;
            this.btnCuentasPagar.Click += new System.EventHandler(this.btnCuentasPagar_Click);
            // 
            // frmEmisionRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 555);
            this.Controls.Add(this.btnCuentasPagar);
            this.Controls.Add(this.btnReciboProvicional);
            this.Controls.Add(this.conCalcVuelto);
            this.Controls.Add(this.chcCliente);
            this.Controls.Add(this.chcColab);
            this.Controls.Add(this.conBusCol);
            this.Controls.Add(this.txtNomUsu);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaSis);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.txtMonItf);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtMonRec);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.btnBusRec);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase4);
            this.Name = "frmEmisionRecibos";
            this.Text = "Emisión de Recibos de Ingreso y Egreso";
            this.Load += new System.EventHandler(this.frmEmisionRecibos_Load);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnBusRec, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonRec, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.txtMonItf, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.dtpFechaSis, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtNomUsu, 0);
            this.Controls.SetChildIndex(this.conBusCol, 0);
            this.Controls.SetChildIndex(this.chcColab, 0);
            this.Controls.SetChildIndex(this.chcCliente, 0);
            this.Controls.SetChildIndex(this.conCalcVuelto, 0);
            this.Controls.SetChildIndex(this.btnReciboProvicional, 0);
            this.Controls.SetChildIndex(this.btnCuentasPagar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnBusqueda btnBusRec;
        private GEN.ControlesBase.cboBase cboTipRec;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboConcepto;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtMonItf;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtTotRec;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase10;
        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.chcBase chcBuscar;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtBase txtNroRec;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.chcBase chcColab;
        private GEN.ControlesBase.chcBase chcCliente;
        private GEN.ControlesBase.lblBase lblAge;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.conCalcVuelto conCalcVuelto;
        private System.Windows.Forms.CheckBox chcAfectaCaja;
        private System.Windows.Forms.Button btnReciboProvicional;
        private GEN.BotonesBase.btnPagar btnCuentasPagar;
        public GEN.ControlesBase.txtNumRea txtMonRec;
    }
}