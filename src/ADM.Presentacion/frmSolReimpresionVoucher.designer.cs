namespace ADM.Presentacion
{
    partial class frmSolReimpresionVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolReimpresionVoucher));
            this.nudNroOperacion = new GEN.ControlesBase.nudBase(this.components);
            this.txtEstadoOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcSaldo = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblNroImpresion = new GEN.ControlesBase.lblBase();
            this.txtModulo = new GEN.ControlesBase.txtBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtMonOpe = new GEN.ControlesBase.txtNumRea(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipoOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboMotivos = new GEN.ControlesBase.cboMotivos(this.components);
            this.lblBase22 = new GEN.ControlesBase.lblBase();
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnReimpresionVoucher1 = new GEN.BotonesBase.btnReimpresionVoucher();
            this.btnEmitirRecibo1 = new GEN.BotonesBase.btnEmitirRecibo();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.nudNumeroRecibo = new GEN.ControlesBase.nudBase(this.components);
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCanal = new GEN.ControlesBase.txtBase(this.components);
            this.lblCanal = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.nudNroOperacion)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroRecibo)).BeginInit();
            this.grbBase6.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudNroOperacion
            // 
            this.nudNroOperacion.Location = new System.Drawing.Point(166, 20);
            this.nudNroOperacion.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudNroOperacion.Name = "nudNroOperacion";
            this.nudNroOperacion.Size = new System.Drawing.Size(180, 20);
            this.nudNroOperacion.TabIndex = 2;
            this.nudNroOperacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudNroOperacion_KeyPress);
            // 
            // txtEstadoOpe
            // 
            this.txtEstadoOpe.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstadoOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstadoOpe.Enabled = false;
            this.txtEstadoOpe.Location = new System.Drawing.Point(164, 48);
            this.txtEstadoOpe.Name = "txtEstadoOpe";
            this.txtEstadoOpe.Size = new System.Drawing.Size(182, 20);
            this.txtEstadoOpe.TabIndex = 169;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 51);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 170;
            this.lblBase1.Text = "Estado Operación:";
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(26, 22);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(137, 13);
            this.lblBase32.TabIndex = 168;
            this.lblBase32.Text = "Número de Operación:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtEstadoOpe);
            this.grbBase1.Controls.Add(this.nudNroOperacion);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase32);
            this.grbBase1.Location = new System.Drawing.Point(12, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(405, 81);
            this.grbBase1.TabIndex = 171;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar por Número de Operación";
            // 
            // chcSaldo
            // 
            this.chcSaldo.AutoSize = true;
            this.chcSaldo.Enabled = false;
            this.chcSaldo.Location = new System.Drawing.Point(258, 304);
            this.chcSaldo.Name = "chcSaldo";
            this.chcSaldo.Size = new System.Drawing.Size(72, 17);
            this.chcSaldo.TabIndex = 205;
            this.chcSaldo.Text = "Ver Saldo";
            this.chcSaldo.UseVisualStyleBackColor = true;
            this.chcSaldo.Visible = false;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(21, 304);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(68, 13);
            this.lblBase3.TabIndex = 203;
            this.lblBase3.Text = "Nro. Impr:";
            // 
            // lblNroImpresion
            // 
            this.lblNroImpresion.AutoSize = true;
            this.lblNroImpresion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroImpresion.ForeColor = System.Drawing.Color.Navy;
            this.lblNroImpresion.Location = new System.Drawing.Point(97, 304);
            this.lblNroImpresion.Name = "lblNroImpresion";
            this.lblNroImpresion.Size = new System.Drawing.Size(14, 13);
            this.lblNroImpresion.TabIndex = 204;
            this.lblNroImpresion.Text = "0";
            // 
            // txtModulo
            // 
            this.txtModulo.BackColor = System.Drawing.SystemColors.Control;
            this.txtModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(131, 148);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(258, 20);
            this.txtModulo.TabIndex = 200;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(131, 204);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(258, 21);
            this.cboMoneda.TabIndex = 198;
            // 
            // txtMonOpe
            // 
            this.txtMonOpe.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonOpe.Enabled = false;
            this.txtMonOpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonOpe.FormatoDecimal = false;
            this.txtMonOpe.Location = new System.Drawing.Point(131, 232);
            this.txtMonOpe.Name = "txtMonOpe";
            this.txtMonOpe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonOpe.nNumDecimales = 4;
            this.txtMonOpe.nvalor = 0D;
            this.txtMonOpe.Size = new System.Drawing.Size(258, 20);
            this.txtMonOpe.TabIndex = 196;
            this.txtMonOpe.Text = "0.00";
            this.txtMonOpe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtCanal);
            this.grbBase2.Controls.Add(this.lblCanal);
            this.grbBase2.Controls.Add(this.txtTipoOperacion);
            this.grbBase2.Controls.Add(this.txtFechaOpe);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.grbBase3);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Location = new System.Drawing.Point(12, 99);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(405, 186);
            this.grbBase2.TabIndex = 197;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Operación";
            // 
            // txtTipoOperacion
            // 
            this.txtTipoOperacion.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoOperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoOperacion.Enabled = false;
            this.txtTipoOperacion.Location = new System.Drawing.Point(119, 77);
            this.txtTipoOperacion.Name = "txtTipoOperacion";
            this.txtTipoOperacion.Size = new System.Drawing.Size(258, 20);
            this.txtTipoOperacion.TabIndex = 211;
            // 
            // txtFechaOpe
            // 
            this.txtFechaOpe.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaOpe.Enabled = false;
            this.txtFechaOpe.Location = new System.Drawing.Point(119, 23);
            this.txtFechaOpe.Name = "txtFechaOpe";
            this.txtFechaOpe.Size = new System.Drawing.Size(175, 20);
            this.txtFechaOpe.TabIndex = 168;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(4, 26);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(107, 13);
            this.lblBase4.TabIndex = 169;
            this.lblBase4.Text = "Fecha Operación:";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(1, -69);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(461, 64);
            this.grbBase3.TabIndex = 146;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Operación";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(4, 50);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(52, 13);
            this.lblBase11.TabIndex = 187;
            this.lblBase11.Text = "Módulo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(4, 78);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 179;
            this.lblBase2.Text = "Tipo Operación:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(4, 134);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 180;
            this.lblBase6.Text = "Monto Operación:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(4, 106);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 183;
            this.lblBase7.Text = "Moneda:";
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.txtMotivo);
            this.grbBase4.Controls.Add(this.lblBase5);
            this.grbBase4.Controls.Add(this.cboMotivos);
            this.grbBase4.Controls.Add(this.lblBase22);
            this.grbBase4.Location = new System.Drawing.Point(12, 336);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(405, 105);
            this.grbBase4.TabIndex = 206;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Datos de la Solicitud de Reimpresión";
            this.grbBase4.Enter += new System.EventHandler(this.grbBase4_Enter);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(134, 45);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(262, 53);
            this.txtMotivo.TabIndex = 150;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(8, 45);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(78, 13);
            this.lblBase5.TabIndex = 151;
            this.lblBase5.Text = "Descripción:";
            // 
            // cboMotivos
            // 
            this.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivos.Enabled = false;
            this.cboMotivos.FormattingEnabled = true;
            this.cboMotivos.Location = new System.Drawing.Point(135, 20);
            this.cboMotivos.Name = "cboMotivos";
            this.cboMotivos.Size = new System.Drawing.Size(261, 21);
            this.cboMotivos.TabIndex = 149;
            this.cboMotivos.SelectedIndexChanged += new System.EventHandler(this.cboMotivos_SelectedIndexChanged);
            // 
            // lblBase22
            // 
            this.lblBase22.AutoSize = true;
            this.lblBase22.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase22.ForeColor = System.Drawing.Color.Navy;
            this.lblBase22.Location = new System.Drawing.Point(8, 23);
            this.lblBase22.Name = "lblBase22";
            this.lblBase22.Size = new System.Drawing.Size(124, 13);
            this.lblBase22.TabIndex = 152;
            this.lblBase22.Text = "Motivo Reimpresion:";
            // 
            // grbBase5
            // 
            this.grbBase5.Location = new System.Drawing.Point(12, 285);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(405, 46);
            this.grbBase5.TabIndex = 207;
            this.grbBase5.TabStop = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(208, 505);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 208;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(270, 505);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 209;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(345, 505);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 210;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnReimpresionVoucher1
            // 
            this.btnReimpresionVoucher1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReimpresionVoucher1.BackgroundImage")));
            this.btnReimpresionVoucher1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReimpresionVoucher1.Location = new System.Drawing.Point(145, 505);
            this.btnReimpresionVoucher1.Name = "btnReimpresionVoucher1";
            this.btnReimpresionVoucher1.Size = new System.Drawing.Size(60, 50);
            this.btnReimpresionVoucher1.TabIndex = 211;
            this.btnReimpresionVoucher1.Text = "&Reimprimir Voucher";
            this.btnReimpresionVoucher1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReimpresionVoucher1.UseVisualStyleBackColor = true;
            this.btnReimpresionVoucher1.Click += new System.EventHandler(this.btnReimpresionVoucher1_Click);
            // 
            // btnEmitirRecibo1
            // 
            this.btnEmitirRecibo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmitirRecibo1.BackgroundImage")));
            this.btnEmitirRecibo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEmitirRecibo1.Enabled = false;
            this.btnEmitirRecibo1.Location = new System.Drawing.Point(81, 505);
            this.btnEmitirRecibo1.Name = "btnEmitirRecibo1";
            this.btnEmitirRecibo1.Size = new System.Drawing.Size(60, 50);
            this.btnEmitirRecibo1.TabIndex = 212;
            this.btnEmitirRecibo1.Text = "&Emitir Recibo";
            this.btnEmitirRecibo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmitirRecibo1.UseVisualStyleBackColor = true;
            this.btnEmitirRecibo1.Click += new System.EventHandler(this.btnEmitirRecibo1_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(37, 21);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(74, 13);
            this.lblBase8.TabIndex = 153;
            this.lblBase8.Text = "Nro.Recibo:";
            // 
            // nudNumeroRecibo
            // 
            this.nudNumeroRecibo.Enabled = false;
            this.nudNumeroRecibo.Location = new System.Drawing.Point(119, 19);
            this.nudNumeroRecibo.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudNumeroRecibo.Name = "nudNumeroRecibo";
            this.nudNumeroRecibo.Size = new System.Drawing.Size(180, 20);
            this.nudNumeroRecibo.TabIndex = 171;
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.nudNumeroRecibo);
            this.grbBase6.Controls.Add(this.lblBase8);
            this.grbBase6.Location = new System.Drawing.Point(12, 447);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(401, 51);
            this.grbBase6.TabIndex = 213;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "Datos del Recibo";
            // 
            // txtCanal
            // 
            this.txtCanal.BackColor = System.Drawing.SystemColors.Control;
            this.txtCanal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCanal.Enabled = false;
            this.txtCanal.Location = new System.Drawing.Point(119, 159);
            this.txtCanal.Name = "txtCanal";
            this.txtCanal.Size = new System.Drawing.Size(258, 20);
            this.txtCanal.TabIndex = 213;
            // 
            // lblCanal
            // 
            this.lblCanal.AutoSize = true;
            this.lblCanal.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCanal.ForeColor = System.Drawing.Color.Navy;
            this.lblCanal.Location = new System.Drawing.Point(4, 166);
            this.lblCanal.Name = "lblCanal";
            this.lblCanal.Size = new System.Drawing.Size(45, 13);
            this.lblCanal.TabIndex = 212;
            this.lblCanal.Text = "Canal:";
            // 
            // frmSolReimpresionVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 584);
            this.Controls.Add(this.grbBase6);
            this.Controls.Add(this.btnEmitirRecibo1);
            this.Controls.Add(this.btnReimpresionVoucher1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.chcSaldo);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblNroImpresion);
            this.Controls.Add(this.txtModulo);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.txtMonOpe);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase5);
            this.Name = "frmSolReimpresionVoucher";
            this.Text = "Solicitud para Reimpresión de Voucher";
            this.Load += new System.EventHandler(this.frmSolReimpresionVoucher_Load);
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.txtMonOpe, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.txtModulo, 0);
            this.Controls.SetChildIndex(this.lblNroImpresion, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.chcSaldo, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnReimpresionVoucher1, 0);
            this.Controls.SetChildIndex(this.btnEmitirRecibo1, 0);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudNroOperacion)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroRecibo)).EndInit();
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.nudBase nudNroOperacion;
        private GEN.ControlesBase.txtBase txtEstadoOpe;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcSaldo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblNroImpresion;
        private GEN.ControlesBase.txtBase txtModulo;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtNumRea txtMonOpe;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtFechaOpe;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboMotivos cboMotivos;
        private GEN.ControlesBase.lblBase lblBase22;
        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtBase txtTipoOperacion;
        private GEN.BotonesBase.btnReimpresionVoucher btnReimpresionVoucher1;
        private GEN.BotonesBase.btnEmitirRecibo btnEmitirRecibo1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.nudBase nudNumeroRecibo;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.txtBase txtCanal;
        private GEN.ControlesBase.lblBase lblCanal;
    }
}