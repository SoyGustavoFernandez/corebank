namespace CAJ.Presentacion
{
    partial class frmModificarRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarRecibo));
            this.chcAfectaCaja = new System.Windows.Forms.CheckBox();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboConcepto = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboTipRec = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.nudNroRecibo = new GEN.ControlesBase.nudBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.txtMonItf = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMonRec = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtTotRec = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtMotivoCambio = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudNroRecibo)).BeginInit();
            this.conBusCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // chcAfectaCaja
            // 
            this.chcAfectaCaja.AutoSize = true;
            this.chcAfectaCaja.Enabled = false;
            this.chcAfectaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcAfectaCaja.ForeColor = System.Drawing.Color.Navy;
            this.chcAfectaCaja.Location = new System.Drawing.Point(342, 113);
            this.chcAfectaCaja.Name = "chcAfectaCaja";
            this.chcAfectaCaja.Size = new System.Drawing.Size(103, 17);
            this.chcAfectaCaja.TabIndex = 106;
            this.chcAfectaCaja.Text = "Afecta a Caja";
            this.chcAfectaCaja.UseVisualStyleBackColor = true;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(95, 84);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(174, 21);
            this.cboMoneda.TabIndex = 100;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(14, 88);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 105;
            this.lblBase5.Text = "Moneda:";
            // 
            // cboConcepto
            // 
            this.cboConcepto.DropDownWidth = 310;
            this.cboConcepto.Enabled = false;
            this.cboConcepto.FormattingEnabled = true;
            this.cboConcepto.Location = new System.Drawing.Point(341, 85);
            this.cboConcepto.Name = "cboConcepto";
            this.cboConcepto.Size = new System.Drawing.Size(197, 21);
            this.cboConcepto.TabIndex = 102;
            this.cboConcepto.SelectedIndexChanged += new System.EventHandler(this.cboConcepto_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(274, 88);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(66, 13);
            this.lblBase4.TabIndex = 104;
            this.lblBase4.Text = "Concepto:";
            // 
            // cboTipRec
            // 
            this.cboTipRec.Enabled = false;
            this.cboTipRec.FormattingEnabled = true;
            this.cboTipRec.Location = new System.Drawing.Point(95, 111);
            this.cboTipRec.Name = "cboTipRec";
            this.cboTipRec.Size = new System.Drawing.Size(174, 21);
            this.cboTipRec.TabIndex = 101;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 115);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 103;
            this.lblBase3.Text = "Tipo Recibo:";
            // 
            // nudNroRecibo
            // 
            this.nudNroRecibo.Location = new System.Drawing.Point(213, 29);
            this.nudNroRecibo.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudNroRecibo.Name = "nudNroRecibo";
            this.nudNroRecibo.Size = new System.Drawing.Size(120, 20);
            this.nudNroRecibo.TabIndex = 138;
            this.nudNroRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudNroRecibo_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(26, 32);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(179, 13);
            this.lblBase1.TabIndex = 139;
            this.lblBase1.Text = "Ingrese el Número de Recibo:";
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.Controls.Add(this.txtCodInst);
            this.conBusCli.Controls.Add(this.txtCodAge);
            this.conBusCli.Controls.Add(this.txtDireccion);
            this.conBusCli.Controls.Add(this.txtCodCli);
            this.conBusCli.Controls.Add(this.txtNombre);
            this.conBusCli.Controls.Add(this.txtNroDoc);
            this.conBusCli.Enabled = false;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(4, 147);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(531, 82);
            this.conBusCli.TabIndex = 140;
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(161, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // txtMonItf
            // 
            this.txtMonItf.Enabled = false;
            this.txtMonItf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonItf.FormatoDecimal = false;
            this.txtMonItf.Location = new System.Drawing.Point(247, 244);
            this.txtMonItf.Name = "txtMonItf";
            this.txtMonItf.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonItf.nNumDecimales = 4;
            this.txtMonItf.nvalor = 0D;
            this.txtMonItf.Size = new System.Drawing.Size(66, 22);
            this.txtMonItf.TabIndex = 145;
            this.txtMonItf.Text = "0.00";
            this.txtMonItf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(211, 248);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(30, 13);
            this.lblBase7.TabIndex = 144;
            this.lblBase7.Text = "ITF:";
            // 
            // txtMonRec
            // 
            this.txtMonRec.Enabled = false;
            this.txtMonRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonRec.FormatoDecimal = true;
            this.txtMonRec.Location = new System.Drawing.Point(99, 243);
            this.txtMonRec.Name = "txtMonRec";
            this.txtMonRec.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonRec.nNumDecimales = 2;
            this.txtMonRec.nvalor = 0D;
            this.txtMonRec.Size = new System.Drawing.Size(104, 22);
            this.txtMonRec.TabIndex = 141;
            this.txtMonRec.Text = "0.00";
            this.txtMonRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(7, 247);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(88, 13);
            this.lblBase6.TabIndex = 143;
            this.lblBase6.Text = "Monto Recibo:";
            // 
            // txtTotRec
            // 
            this.txtTotRec.Enabled = false;
            this.txtTotRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotRec.FormatoDecimal = false;
            this.txtTotRec.Location = new System.Drawing.Point(415, 243);
            this.txtTotRec.Name = "txtTotRec";
            this.txtTotRec.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotRec.nNumDecimales = 4;
            this.txtTotRec.nvalor = 0D;
            this.txtTotRec.Size = new System.Drawing.Size(116, 22);
            this.txtTotRec.TabIndex = 147;
            this.txtTotRec.Text = "0.00";
            this.txtTotRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(331, 247);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(81, 13);
            this.lblBase8.TabIndex = 146;
            this.lblBase8.Text = "Total Recibo:";
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(99, 268);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(432, 32);
            this.txtSustento.TabIndex = 142;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(32, 271);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(62, 13);
            this.lblBase9.TabIndex = 148;
            this.lblBase9.Text = "Sustento:";
            // 
            // txtMotivoCambio
            // 
            this.txtMotivoCambio.Enabled = false;
            this.txtMotivoCambio.Location = new System.Drawing.Point(109, 313);
            this.txtMotivoCambio.MaxLength = 500;
            this.txtMotivoCambio.Multiline = true;
            this.txtMotivoCambio.Name = "txtMotivoCambio";
            this.txtMotivoCambio.Size = new System.Drawing.Size(422, 47);
            this.txtMotivoCambio.TabIndex = 149;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(11, 316);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(97, 13);
            this.lblBase2.TabIndex = 150;
            this.lblBase2.Text = "Motivo Cambio:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(277, 368);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 151;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(469, 368);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 154;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(397, 368);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 153;
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
            this.btnGrabar.Location = new System.Drawing.Point(337, 368);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 152;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(10, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(533, 49);
            this.grbBase1.TabIndex = 155;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Burcar Recibo a Modificar";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(10, 64);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(533, 75);
            this.grbBase3.TabIndex = 157;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos del Recibo";
            // 
            // grbBase4
            // 
            this.grbBase4.Location = new System.Drawing.Point(4, 227);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(536, 77);
            this.grbBase4.TabIndex = 157;
            this.grbBase4.TabStop = false;
            // 
            // frmModificarRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 445);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtMotivoCambio);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtMonItf);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtMonRec);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtTotRec);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.conBusCli);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.nudNroRecibo);
            this.Controls.Add(this.chcAfectaCaja);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboConcepto);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboTipRec);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase4);
            this.Name = "frmModificarRecibo";
            this.Text = "Modificar Datos del Recibo";
            this.Load += new System.EventHandler(this.frmModificarRecibo_Load);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipRec, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboConcepto, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.chcAfectaCaja, 0);
            this.Controls.SetChildIndex(this.nudNroRecibo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.conBusCli, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.txtTotRec, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtMonRec, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.txtMonItf, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.txtMotivoCambio, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudNroRecibo)).EndInit();
            this.conBusCli.ResumeLayout(false);
            this.conBusCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chcAfectaCaja;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboConcepto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboTipRec;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.nudBase nudNroRecibo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.ConBusCli conBusCli;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCli;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.ControlesBase.txtNumRea txtMonItf;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtMonRec;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtTotRec;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtMotivoCambio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase4;
    }
}