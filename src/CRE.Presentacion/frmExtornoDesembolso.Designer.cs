namespace CRE.Presentacion
{
    partial class frmExtornoDesembolso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtornoDesembolso));
            this.conBusCuentaCli = new GEN.ControlesBase.ConBusCuentaCli();
            this.btnExtorno1 = new GEN.BotonesBase.btnExtorno();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecDes = new GEN.ControlesBase.dtLargoBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.nudNroKardex = new GEN.ControlesBase.nudBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstadoSolic1 = new GEN.ControlesBase.cboEstadoSolic(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtCliente = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboTipoOperacion = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.txtModulo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtMonOpe = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMotivoExtorno = new GEN.ControlesBase.cboMotivoExtorno(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEnviar1 = new GEN.BotonesBase.btnEnviar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroKardex)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCuentaCli
            // 
            this.conBusCuentaCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.conBusCuentaCli.Location = new System.Drawing.Point(534, 12);
            this.conBusCuentaCli.Name = "conBusCuentaCli";
            this.conBusCuentaCli.Size = new System.Drawing.Size(556, 90);
            this.conBusCuentaCli.TabIndex = 2;
            this.conBusCuentaCli.MyKey += new System.Windows.Forms.KeyPressEventHandler(this.conBusCuentaCli_MyKey_1);
            this.conBusCuentaCli.MyClic += new System.EventHandler(this.conBusCuentaCli_MyClic);
            // 
            // btnExtorno1
            // 
            this.btnExtorno1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno1.BackgroundImage")));
            this.btnExtorno1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno1.Enabled = false;
            this.btnExtorno1.Location = new System.Drawing.Point(912, 211);
            this.btnExtorno1.Margin = new System.Windows.Forms.Padding(4);
            this.btnExtorno1.Name = "btnExtorno1";
            this.btnExtorno1.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno1.TabIndex = 3;
            this.btnExtorno1.Text = "&Extornar";
            this.btnExtorno1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno1.UseVisualStyleBackColor = true;
            this.btnExtorno1.Click += new System.EventHandler(this.btnExtorno1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(1032, 211);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // lblBase3
            // 
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 70);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(137, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Usuario :";
            this.lblBase3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase2
            // 
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(137, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Monto :";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase1
            // 
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 22);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(137, 18);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Fecha Desembolso :";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFecDes
            // 
            this.dtpFecDes.Enabled = false;
            this.dtpFecDes.Location = new System.Drawing.Point(153, 20);
            this.dtpFecDes.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecDes.Name = "dtpFecDes";
            this.dtpFecDes.Size = new System.Drawing.Size(260, 20);
            this.dtpFecDes.TabIndex = 14;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(153, 66);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(390, 20);
            this.txtUsuario.TabIndex = 13;
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(153, 43);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 4;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(260, 20);
            this.txtMonto.TabIndex = 12;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtUsuario);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFecDes);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(534, 109);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(4);
            this.grbBase1.Size = new System.Drawing.Size(559, 98);
            this.grbBase1.TabIndex = 18;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del desembolso";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(972, 211);
            this.btnCancelar1.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 19;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.nudNroKardex);
            this.grbBase2.Controls.Add(this.btnAceptar);
            this.grbBase2.Controls.Add(this.lblBase32);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(11, 2);
            this.grbBase2.Margin = new System.Windows.Forms.Padding(4);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Padding = new System.Windows.Forms.Padding(4);
            this.grbBase2.Size = new System.Drawing.Size(513, 70);
            this.grbBase2.TabIndex = 20;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Buscar Operación";
            // 
            // nudNroKardex
            // 
            this.nudNroKardex.Location = new System.Drawing.Point(199, 29);
            this.nudNroKardex.Margin = new System.Windows.Forms.Padding(4);
            this.nudNroKardex.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudNroKardex.Name = "nudNroKardex";
            this.nudNroKardex.Size = new System.Drawing.Size(127, 20);
            this.nudNroKardex.TabIndex = 0;
            this.nudNroKardex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudNroKardex_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(441, 14);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(25, 33);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(116, 13);
            this.lblBase32.TabIndex = 121;
            this.lblBase32.Text = "Nro. de Operación:";
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(1017, 22);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 27;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboEstadoSolic1);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.txtCliente);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.cboTipoOperacion);
            this.grbBase3.Controls.Add(this.txtModulo);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.cboMoneda);
            this.grbBase3.Controls.Add(this.txtMonOpe);
            this.grbBase3.Controls.Add(this.cboMotivoExtorno);
            this.grbBase3.Controls.Add(this.lblBase13);
            this.grbBase3.Controls.Add(this.txtSustento);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(11, 75);
            this.grbBase3.Margin = new System.Windows.Forms.Padding(4);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Padding = new System.Windows.Forms.Padding(4);
            this.grbBase3.Size = new System.Drawing.Size(516, 326);
            this.grbBase3.TabIndex = 21;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Operación";
            // 
            // cboEstadoSolic1
            // 
            this.cboEstadoSolic1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoSolic1.Enabled = false;
            this.cboEstadoSolic1.FormattingEnabled = true;
            this.cboEstadoSolic1.Location = new System.Drawing.Point(164, 21);
            this.cboEstadoSolic1.Margin = new System.Windows.Forms.Padding(4);
            this.cboEstadoSolic1.Name = "cboEstadoSolic1";
            this.cboEstadoSolic1.Size = new System.Drawing.Size(337, 21);
            this.cboEstadoSolic1.TabIndex = 145;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 21);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 144;
            this.lblBase4.Text = "Estado:";
            // 
            // txtCliente
            // 
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(164, 68);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(337, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(15, 72);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(52, 13);
            this.lblBase5.TabIndex = 143;
            this.lblBase5.Text = "Cliente:";
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.Enabled = false;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(164, 91);
            this.cboTipoOperacion.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(337, 21);
            this.cboTipoOperacion.TabIndex = 2;
            // 
            // txtModulo
            // 
            this.txtModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(164, 45);
            this.txtModulo.Margin = new System.Windows.Forms.Padding(4);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(337, 20);
            this.txtModulo.TabIndex = 0;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(15, 49);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(52, 13);
            this.lblBase11.TabIndex = 141;
            this.lblBase11.Text = "Módulo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 96);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(98, 13);
            this.lblBase6.TabIndex = 124;
            this.lblBase6.Text = "Tipo Operación:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(15, 120);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(102, 13);
            this.lblBase7.TabIndex = 137;
            this.lblBase7.Text = "Tipo de Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(164, 116);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(4);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(337, 21);
            this.cboMoneda.TabIndex = 3;
            // 
            // txtMonOpe
            // 
            this.txtMonOpe.Enabled = false;
            this.txtMonOpe.FormatoDecimal = false;
            this.txtMonOpe.Location = new System.Drawing.Point(164, 141);
            this.txtMonOpe.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonOpe.Name = "txtMonOpe";
            this.txtMonOpe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonOpe.nNumDecimales = 4;
            this.txtMonOpe.nvalor = 0D;
            this.txtMonOpe.Size = new System.Drawing.Size(117, 20);
            this.txtMonOpe.TabIndex = 4;
            this.txtMonOpe.Text = "0.00";
            // 
            // cboMotivoExtorno
            // 
            this.cboMotivoExtorno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoExtorno.DropDownWidth = 365;
            this.cboMotivoExtorno.Enabled = false;
            this.cboMotivoExtorno.FormattingEnabled = true;
            this.cboMotivoExtorno.Location = new System.Drawing.Point(164, 165);
            this.cboMotivoExtorno.Margin = new System.Windows.Forms.Padding(4);
            this.cboMotivoExtorno.Name = "cboMotivoExtorno";
            this.cboMotivoExtorno.Size = new System.Drawing.Size(337, 21);
            this.cboMotivoExtorno.TabIndex = 5;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(15, 194);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(110, 13);
            this.lblBase13.TabIndex = 130;
            this.lblBase13.Text = "Sustento Extorno:";
            // 
            // txtSustento
            // 
            this.txtSustento.BackColor = System.Drawing.SystemColors.Window;
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(164, 190);
            this.txtSustento.Margin = new System.Windows.Forms.Padding(4);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(337, 70);
            this.txtSustento.TabIndex = 6;
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(15, 169);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(97, 13);
            this.lblBase12.TabIndex = 127;
            this.lblBase12.Text = "Motivo Extorno:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(15, 145);
            this.lblBase8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(108, 13);
            this.lblBase8.TabIndex = 125;
            this.lblBase8.Text = "Monto Operación:";
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(11, 409);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 24;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Visible = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(407, 409);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(71, 409);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar1
            // 
            this.btnEnviar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar1.BackgroundImage")));
            this.btnEnviar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar1.Location = new System.Drawing.Point(467, 409);
            this.btnEnviar1.Name = "btnEnviar1";
            this.btnEnviar1.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar1.TabIndex = 26;
            this.btnEnviar1.Text = "&Enviar";
            this.btnEnviar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar1.UseVisualStyleBackColor = true;
            this.btnEnviar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // frmExtornoDesembolso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 486);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.btnEnviar1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.conBusCuentaCli);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnExtorno1);
            this.Controls.Add(this.grbBase1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmExtornoDesembolso";
            this.Text = "Extorno Desembolso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExtornoDesembolso_FormClosed);
            this.Load += new System.EventHandler(this.frmExtornoDesembolso_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnExtorno1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusCuentaCli, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEnviar1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroKardex)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCuentaCli conBusCuentaCli;
        private GEN.BotonesBase.btnExtorno btnExtorno1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtLargoBase dtpFecDes;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.nudBase nudNroKardex;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.cboEstadoSolic cboEstadoSolic1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtCliente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion;
        private GEN.ControlesBase.txtBase txtModulo;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtNumRea txtMonOpe;
        private GEN.ControlesBase.cboMotivoExtorno cboMotivoExtorno;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEnviar btnEnviar1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
    }
}