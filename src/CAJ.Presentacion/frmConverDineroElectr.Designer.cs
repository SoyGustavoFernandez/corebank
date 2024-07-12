namespace CAJ.Presentacion
{
    partial class frmConverDineroElectr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConverDineroElectr));
            this.dtpFechaSis = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNomUsu = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtCodUsu = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTelefCel1 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNombres = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoDocumento1 = new GEN.ControlesBase.cboTipoDocumento(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.cboConcepto = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.conCalcVuelto = new GEN.ControlesBase.conCalcVuelto();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbBase3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaSis
            // 
            this.dtpFechaSis.Enabled = false;
            this.dtpFechaSis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaSis.Location = new System.Drawing.Point(72, 15);
            this.dtpFechaSis.Name = "dtpFechaSis";
            this.dtpFechaSis.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaSis.TabIndex = 65;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFechaSis);
            this.grbBase3.Controls.Add(this.txtNomUsu);
            this.grbBase3.Controls.Add(this.lblBase1);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.txtUsuario);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.txtCodUsu);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Location = new System.Drawing.Point(161, 9);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(326, 85);
            this.grbBase3.TabIndex = 67;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Sistema";
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Enabled = false;
            this.txtNomUsu.Location = new System.Drawing.Point(71, 59);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(247, 20);
            this.txtNomUsu.TabIndex = 66;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 63);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 63;
            this.lblBase1.Text = "Nombre:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(17, 18);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(45, 13);
            this.lblBase11.TabIndex = 61;
            this.lblBase11.Text = "Fecha:";
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
            // txtCodUsu
            // 
            this.txtCodUsu.Enabled = false;
            this.txtCodUsu.Location = new System.Drawing.Point(268, 15);
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
            this.lblBase10.Location = new System.Drawing.Point(210, 18);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(52, 13);
            this.lblBase10.TabIndex = 59;
            this.lblBase10.Text = "Código:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTelefCel1);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Controls.Add(this.txtNombres);
            this.groupBox1.Controls.Add(this.cboTipoDocumento1);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.lblBase6);
            this.groupBox1.Location = new System.Drawing.Point(13, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del cliente";
            // 
            // txtTelefCel1
            // 
            this.txtTelefCel1.Location = new System.Drawing.Point(156, 65);
            this.txtTelefCel1.MaxLength = 9;
            this.txtTelefCel1.Name = "txtTelefCel1";
            this.txtTelefCel1.Size = new System.Drawing.Size(160, 20);
            this.txtTelefCel1.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(103, 68);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(53, 13);
            this.lblBase3.TabIndex = 120;
            this.lblBase3.Text = "Celular:";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(156, 42);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(310, 20);
            this.txtNombres.TabIndex = 2;
            // 
            // cboTipoDocumento1
            // 
            this.cboTipoDocumento1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento1.FormattingEnabled = true;
            this.cboTipoDocumento1.Location = new System.Drawing.Point(156, 19);
            this.cboTipoDocumento1.Name = "cboTipoDocumento1";
            this.cboTipoDocumento1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDocumento1.TabIndex = 0;
            this.cboTipoDocumento1.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocumento1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(-2, 45);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(158, 13);
            this.lblBase2.TabIndex = 111;
            this.lblBase2.Text = "Ap. y Nomb. o Razón Soc:";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(283, 19);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(183, 20);
            this.txtNroDoc.TabIndex = 1;
            this.txtNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDoc_KeyPress);
            this.txtNroDoc.Leave += new System.EventHandler(this.txtNroDoc_Leave);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(33, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(123, 13);
            this.lblBase6.TabIndex = 113;
            this.lblBase6.Text = "Nro. de Documento:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMonto);
            this.groupBox2.Controls.Add(this.cboMoneda1);
            this.groupBox2.Controls.Add(this.cboConcepto);
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Location = new System.Drawing.Point(13, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la operación:";
            // 
            // txtMonto
            // 
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(283, 43);
            this.txtMonto.MaxLength = 6;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 4;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(183, 20);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Validated += new System.EventHandler(this.txtMonto_Validated);
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(156, 43);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(121, 21);
            this.cboMoneda1.TabIndex = 1;
            // 
            // cboConcepto
            // 
            this.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConcepto.FormattingEnabled = true;
            this.cboConcepto.Location = new System.Drawing.Point(156, 18);
            this.cboConcepto.Name = "cboConcepto";
            this.cboConcepto.Size = new System.Drawing.Size(310, 21);
            this.cboConcepto.TabIndex = 0;
            this.cboConcepto.SelectedIndexChanged += new System.EventHandler(this.cboConcepto_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(80, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(70, 13);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Operación:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(104, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(46, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Monto:";
            // 
            // conCalcVuelto
            // 
            this.conCalcVuelto.Location = new System.Drawing.Point(96, 261);
            this.conCalcVuelto.Name = "conCalcVuelto";
            this.conCalcVuelto.Size = new System.Drawing.Size(192, 61);
            this.conCalcVuelto.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(419, 272);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(356, 272);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(293, 272);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmConverDineroElectr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 360);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.conCalcVuelto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmConverDineroElectr";
            this.Text = "Converción de Dinero Electronico";
            this.Load += new System.EventHandler(this.frmConverDineroElectr_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.conCalcVuelto, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.dtpCorto dtpFechaSis;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtCodUsu;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.txtCBLetra txtNomUsu;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase2;
        public GEN.ControlesBase.txtBase txtNroDoc;
        public GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtTelefCel txtTelefCel1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtNombres;
        private GEN.ControlesBase.cboTipoDocumento cboTipoDocumento1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.cboBase cboConcepto;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.conCalcVuelto conCalcVuelto;


    }
}