namespace CRE.Presentacion
{
    partial class frmPagosMasivoCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosMasivoCredito));
            this.grbOrdenante = new GEN.ControlesBase.grbBase(this.components);
            this.conBusCol1 = new GEN.ControlesBase.ConBusCol();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpCorto1 = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.conPagoBcos = new GEN.ControlesBase.conPagoBcos();
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoPagoMasivo1 = new GEN.ControlesBase.cboTipoPagoMasivo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTotalCuentas = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblCuentaNoExiste = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtCuentaNoExistente = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblCorrecto = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.lblErrorMsn = new GEN.ControlesBase.lblBase();
            this.lblError = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtPagar = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtPagarySobrante = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtgCreditosParaPago = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnImportar = new GEN.BotonesBase.btnImportar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbOrdenante.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.conPagoBcos.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosParaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // grbOrdenante
            // 
            this.grbOrdenante.Controls.Add(this.conBusCol1);
            this.grbOrdenante.Location = new System.Drawing.Point(7, 2);
            this.grbOrdenante.Name = "grbOrdenante";
            this.grbOrdenante.Size = new System.Drawing.Size(397, 113);
            this.grbOrdenante.TabIndex = 2;
            this.grbOrdenante.TabStop = false;
            this.grbOrdenante.Text = "Ordenante";
            // 
            // conBusCol1
            // 
            this.conBusCol1.cEstado = "0";
            this.conBusCol1.Location = new System.Drawing.Point(4, 14);
            this.conBusCol1.Name = "conBusCol1";
            this.conBusCol1.Size = new System.Drawing.Size(390, 95);
            this.conBusCol1.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(5, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Fecha:";
            // 
            // dtpCorto1
            // 
            this.dtpCorto1.Enabled = false;
            this.dtpCorto1.Location = new System.Drawing.Point(50, 15);
            this.dtpCorto1.Name = "dtpCorto1";
            this.dtpCorto1.Size = new System.Drawing.Size(164, 20);
            this.dtpCorto1.TabIndex = 10;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboMoneda1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpCorto1);
            this.grbBase1.Controls.Add(this.conPagoBcos);
            this.grbBase1.Controls.Add(this.cboTipoPagoMasivo1);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(410, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(513, 112);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Operación";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(9, 53);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(205, 21);
            this.cboMoneda1.TabIndex = 15;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 37);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 14;
            this.lblBase2.Text = "Moneda:";
            // 
            // conPagoBcos
            // 
            this.conPagoBcos.AutoSize = true;
            this.conPagoBcos.Controls.Add(this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496);
            this.conPagoBcos.Location = new System.Drawing.Point(224, 5);
            this.conPagoBcos.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.conPagoBcos.Name = "conPagoBcos";
            this.conPagoBcos.Size = new System.Drawing.Size(267, 110);
            this.conPagoBcos.TabIndex = 13;
            this.conPagoBcos.Tag = "";
            this.conPagoBcos.Visible = false;
            // 
            // object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496
            // 
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.Location = new System.Drawing.Point(0, 0);
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.Name = "object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496";
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.Size = new System.Drawing.Size(256, 93);
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.TabIndex = 60;
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.TabStop = false;
            this.object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496.Text = "Detalle Medio de Pago";
            // 
            // cboTipoPagoMasivo1
            // 
            this.cboTipoPagoMasivo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPagoMasivo1.FormattingEnabled = true;
            this.cboTipoPagoMasivo1.Location = new System.Drawing.Point(7, 91);
            this.cboTipoPagoMasivo1.Name = "cboTipoPagoMasivo1";
            this.cboTipoPagoMasivo1.Size = new System.Drawing.Size(210, 21);
            this.cboTipoPagoMasivo1.TabIndex = 7;
            this.cboTipoPagoMasivo1.SelectedIndexChanged += new System.EventHandler(this.cboTipoPagoMasivo1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 75);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(129, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Tipo de Pago Masivo:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTotalCuentas);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblCuentaNoExiste);
            this.grbBase2.Controls.Add(this.txtCuentaNoExistente);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.lblCorrecto);
            this.grbBase2.Controls.Add(this.lblErrorMsn);
            this.grbBase2.Controls.Add(this.lblError);
            this.grbBase2.Controls.Add(this.txtTotal);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.txtPagar);
            this.grbBase2.Controls.Add(this.txtPagarySobrante);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.dtgCreditosParaPago);
            this.grbBase2.Location = new System.Drawing.Point(7, 117);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(916, 449);
            this.grbBase2.TabIndex = 4;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Cuentas a Pagar";
            // 
            // txtTotalCuentas
            // 
            this.txtTotalCuentas.FormatoDecimal = false;
            this.txtTotalCuentas.Location = new System.Drawing.Point(474, 354);
            this.txtTotalCuentas.Name = "txtTotalCuentas";
            this.txtTotalCuentas.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalCuentas.nNumDecimales = 4;
            this.txtTotalCuentas.nvalor = 0D;
            this.txtTotalCuentas.ReadOnly = true;
            this.txtTotalCuentas.Size = new System.Drawing.Size(104, 20);
            this.txtTotalCuentas.TabIndex = 17;
            this.txtTotalCuentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(359, 358);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(108, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Total de Cuentas:";
            // 
            // lblCuentaNoExiste
            // 
            this.lblCuentaNoExiste.AutoSize = true;
            this.lblCuentaNoExiste.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCuentaNoExiste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCuentaNoExiste.Location = new System.Drawing.Point(523, 403);
            this.lblCuentaNoExiste.Name = "lblCuentaNoExiste";
            this.lblCuentaNoExiste.Size = new System.Drawing.Size(278, 13);
            this.lblCuentaNoExiste.TabIndex = 15;
            this.lblCuentaNoExiste.Text = "Cod de Cuenta No Existe | Crédito Cancelado :";
            // 
            // txtCuentaNoExistente
            // 
            this.txtCuentaNoExistente.BackColor = System.Drawing.Color.MistyRose;
            this.txtCuentaNoExistente.FormatoDecimal = false;
            this.txtCuentaNoExistente.Location = new System.Drawing.Point(806, 399);
            this.txtCuentaNoExistente.Name = "txtCuentaNoExistente";
            this.txtCuentaNoExistente.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCuentaNoExistente.nNumDecimales = 4;
            this.txtCuentaNoExistente.nvalor = 0D;
            this.txtCuentaNoExistente.ReadOnly = true;
            this.txtCuentaNoExistente.Size = new System.Drawing.Size(104, 20);
            this.txtCuentaNoExistente.TabIndex = 14;
            this.txtCuentaNoExistente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(27, 391);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(170, 13);
            this.lblBase10.TabIndex = 12;
            this.lblBase10.Text = "Se puede realizar Operación";
            // 
            // lblCorrecto
            // 
            this.lblCorrecto.BackColor = System.Drawing.Color.DarkGreen;
            this.lblCorrecto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCorrecto.ForeColor = System.Drawing.Color.Navy;
            this.lblCorrecto.Location = new System.Drawing.Point(6, 389);
            this.lblCorrecto.Name = "lblCorrecto";
            this.lblCorrecto.Size = new System.Drawing.Size(15, 15);
            this.lblCorrecto.TabIndex = 11;
            // 
            // lblErrorMsn
            // 
            this.lblErrorMsn.AutoSize = true;
            this.lblErrorMsn.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblErrorMsn.ForeColor = System.Drawing.Color.Navy;
            this.lblErrorMsn.Location = new System.Drawing.Point(27, 368);
            this.lblErrorMsn.Name = "lblErrorMsn";
            this.lblErrorMsn.Size = new System.Drawing.Size(206, 13);
            this.lblErrorMsn.TabIndex = 10;
            this.lblErrorMsn.Text = "Cuenta no existe en base de datos";
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblError.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblError.ForeColor = System.Drawing.Color.Navy;
            this.lblError.Location = new System.Drawing.Point(6, 366);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(15, 15);
            this.lblError.TabIndex = 9;
            // 
            // txtTotal
            // 
            this.txtTotal.FormatoDecimal = false;
            this.txtTotal.Location = new System.Drawing.Point(806, 421);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 4;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(104, 20);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(762, 425);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(39, 13);
            this.lblBase8.TabIndex = 7;
            this.lblBase8.Text = "Total:";
            // 
            // txtPagar
            // 
            this.txtPagar.FormatoDecimal = false;
            this.txtPagar.Location = new System.Drawing.Point(806, 377);
            this.txtPagar.Name = "txtPagar";
            this.txtPagar.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPagar.nNumDecimales = 4;
            this.txtPagar.nvalor = 0D;
            this.txtPagar.ReadOnly = true;
            this.txtPagar.Size = new System.Drawing.Size(104, 20);
            this.txtPagar.TabIndex = 6;
            this.txtPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPagarySobrante
            // 
            this.txtPagarySobrante.FormatoDecimal = false;
            this.txtPagarySobrante.Location = new System.Drawing.Point(806, 355);
            this.txtPagarySobrante.Name = "txtPagarySobrante";
            this.txtPagarySobrante.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPagarySobrante.nNumDecimales = 4;
            this.txtPagarySobrante.nvalor = 0D;
            this.txtPagarySobrante.ReadOnly = true;
            this.txtPagarySobrante.Size = new System.Drawing.Size(104, 20);
            this.txtPagarySobrante.TabIndex = 5;
            this.txtPagarySobrante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(757, 380);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(45, 13);
            this.lblBase7.TabIndex = 3;
            this.lblBase7.Text = "Pagar:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(636, 358);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(166, 13);
            this.lblBase6.TabIndex = 2;
            this.lblBase6.Text = "Pagar y Registrar sobrante:";
            // 
            // dtgCreditosParaPago
            // 
            this.dtgCreditosParaPago.AllowUserToAddRows = false;
            this.dtgCreditosParaPago.AllowUserToDeleteRows = false;
            this.dtgCreditosParaPago.AllowUserToResizeColumns = false;
            this.dtgCreditosParaPago.AllowUserToResizeRows = false;
            this.dtgCreditosParaPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditosParaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosParaPago.Location = new System.Drawing.Point(6, 19);
            this.dtgCreditosParaPago.MultiSelect = false;
            this.dtgCreditosParaPago.Name = "dtgCreditosParaPago";
            this.dtgCreditosParaPago.ReadOnly = true;
            this.dtgCreditosParaPago.RowHeadersVisible = false;
            this.dtgCreditosParaPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditosParaPago.Size = new System.Drawing.Size(904, 325);
            this.dtgCreditosParaPago.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(856, 572);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(793, 572);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(605, 572);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 8;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.BackgroundImage")));
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar.Location = new System.Drawing.Point(668, 572);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(60, 50);
            this.btnImportar.TabIndex = 18;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(731, 572);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 19;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmPagosMasivoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 649);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbOrdenante);
            this.Name = "frmPagosMasivoCredito";
            this.Text = "Pago Masivo de Créditos";
            this.Load += new System.EventHandler(this.frmPagosMasivoCredito_Load);
            this.Controls.SetChildIndex(this.grbOrdenante, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.grbOrdenante.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.conPagoBcos.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosParaPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbOrdenante;
        private GEN.ControlesBase.ConBusCol conBusCol1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtpCorto dtpCorto1;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtNumRea txtPagar;
        private GEN.ControlesBase.txtNumRea txtPagarySobrante;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBaseCustom lblCorrecto;
        private GEN.ControlesBase.lblBase lblErrorMsn;
        private GEN.ControlesBase.lblBaseCustom lblError;
        private GEN.ControlesBase.lblBaseCustom lblCuentaNoExiste;
        private GEN.ControlesBase.txtNumRea txtCuentaNoExistente;
        private GEN.ControlesBase.cboTipoPagoMasivo cboTipoPagoMasivo1;
        private GEN.ControlesBase.conPagoBcos conPagoBcos;
        private GEN.ControlesBase.grbBase object_d488c5f8_d58e_4b80_9a94_3ac9ec81a496;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtTotalCuentas;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImportar btnImportar;
        private GEN.ControlesBase.dtgBase dtgCreditosParaPago;
        private GEN.BotonesBase.btnGrabar btnGrabar;
    }
}