namespace DEP.Presentacion
{
    partial class frmValorizarDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValorizarDocs));
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoValorado = new GEN.ControlesBase.cboTipoValoradoFiltro(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.dtgValoradosPend = new GEN.ControlesBase.dtgBase(this.components);
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblMotivo = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtComision = new GEN.ControlesBase.txtNumRea(this.components);
            this.rbtAceptValorado = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtRechazaValord = new GEN.ControlesBase.rbtnBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipCuenta = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoComision = new GEN.ControlesBase.cboBase(this.components);
            this.txtTipoPersona = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoradosPend)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(439, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 3;
            this.lblBase6.Text = "Tipo de Valorado:";
            // 
            // lblBase7
            // 
            this.lblBase7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(9, 62);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(804, 19);
            this.lblBase7.TabIndex = 79;
            this.lblBase7.Text = "VALORADOS PENDIENTES";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(753, 478);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 78;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(67, 22);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 99;
            this.lblBase5.Text = "Agencias:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoValorado);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(806, 50);
            this.grbBase1.TabIndex = 101;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Filtros de Búsqueda";
            // 
            // cboTipoValorado
            // 
            this.cboTipoValorado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValorado.FormattingEnabled = true;
            this.cboTipoValorado.Location = new System.Drawing.Point(566, 15);
            this.cboTipoValorado.Name = "cboTipoValorado";
            this.cboTipoValorado.Size = new System.Drawing.Size(161, 21);
            this.cboTipoValorado.TabIndex = 105;
            this.cboTipoValorado.SelectedIndexChanged += new System.EventHandler(this.cboTipoValorado_SelectedIndexChanged_1);
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(142, 15);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(161, 21);
            this.cboAgencia.TabIndex = 102;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // dtgValoradosPend
            // 
            this.dtgValoradosPend.AllowUserToAddRows = false;
            this.dtgValoradosPend.AllowUserToDeleteRows = false;
            this.dtgValoradosPend.AllowUserToResizeColumns = false;
            this.dtgValoradosPend.AllowUserToResizeRows = false;
            this.dtgValoradosPend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValoradosPend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValoradosPend.Location = new System.Drawing.Point(9, 84);
            this.dtgValoradosPend.MultiSelect = false;
            this.dtgValoradosPend.Name = "dtgValoradosPend";
            this.dtgValoradosPend.ReadOnly = true;
            this.dtgValoradosPend.RowHeadersVisible = false;
            this.dtgValoradosPend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValoradosPend.Size = new System.Drawing.Size(804, 168);
            this.dtgValoradosPend.TabIndex = 102;
            this.dtgValoradosPend.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValoradosPend_RowEnter);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(9, 145);
            this.txtMotivo.MaxLength = 200;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(798, 73);
            this.txtMotivo.TabIndex = 104;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMotivo.ForeColor = System.Drawing.Color.Navy;
            this.lblMotivo.Location = new System.Drawing.Point(7, 129);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(53, 13);
            this.lblMotivo.TabIndex = 103;
            this.lblMotivo.Text = "Motivo :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 105;
            this.lblBase2.Text = "Tipo cuenta:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(346, 15);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 106;
            this.lblBase3.Text = "Moneda:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 43);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 107;
            this.lblBase4.Text = "Producto:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(346, 43);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(86, 13);
            this.lblBase8.TabIndex = 108;
            this.lblBase8.Text = "Tipo persona:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(590, 15);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(102, 13);
            this.lblBase9.TabIndex = 109;
            this.lblBase9.Text = "Fec. documento:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(6, 15);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(108, 13);
            this.lblBase10.TabIndex = 110;
            this.lblBase10.Text = "Tipo de comisión:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(6, 41);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(65, 13);
            this.lblBase11.TabIndex = 111;
            this.lblBase11.Text = "Comisión:";
            // 
            // txtComision
            // 
            this.txtComision.Enabled = false;
            this.txtComision.FormatoDecimal = true;
            this.txtComision.Location = new System.Drawing.Point(120, 36);
            this.txtComision.Name = "txtComision";
            this.txtComision.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtComision.nNumDecimales = 2;
            this.txtComision.nvalor = 0D;
            this.txtComision.ReadOnly = true;
            this.txtComision.Size = new System.Drawing.Size(151, 20);
            this.txtComision.TabIndex = 114;
            this.txtComision.Text = "0.00";
            // 
            // rbtAceptValorado
            // 
            this.rbtAceptValorado.AutoSize = true;
            this.rbtAceptValorado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtAceptValorado.ForeColor = System.Drawing.Color.Navy;
            this.rbtAceptValorado.Location = new System.Drawing.Point(6, 15);
            this.rbtAceptValorado.Name = "rbtAceptValorado";
            this.rbtAceptValorado.Size = new System.Drawing.Size(140, 17);
            this.rbtAceptValorado.TabIndex = 115;
            this.rbtAceptValorado.TabStop = true;
            this.rbtAceptValorado.Text = "Aceptación del valorado";
            this.rbtAceptValorado.UseVisualStyleBackColor = true;
            this.rbtAceptValorado.CheckedChanged += new System.EventHandler(this.rbtAceptValorado_CheckedChanged);
            // 
            // rbtRechazaValord
            // 
            this.rbtRechazaValord.AutoSize = true;
            this.rbtRechazaValord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtRechazaValord.ForeColor = System.Drawing.Color.Navy;
            this.rbtRechazaValord.Location = new System.Drawing.Point(6, 37);
            this.rbtRechazaValord.Name = "rbtRechazaValord";
            this.rbtRechazaValord.Size = new System.Drawing.Size(129, 17);
            this.rbtRechazaValord.TabIndex = 116;
            this.rbtRechazaValord.TabStop = true;
            this.rbtRechazaValord.Text = "Rechazo del valorado";
            this.rbtRechazaValord.UseVisualStyleBackColor = true;
            this.rbtRechazaValord.CheckedChanged += new System.EventHandler(this.rbtRechazaValord_CheckedChanged);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(438, 11);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(146, 21);
            this.cboMoneda.TabIndex = 117;
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(90, 39);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(248, 20);
            this.txtProducto.TabIndex = 118;
            // 
            // txtTipCuenta
            // 
            this.txtTipCuenta.Enabled = false;
            this.txtTipCuenta.Location = new System.Drawing.Point(90, 13);
            this.txtTipCuenta.Name = "txtTipCuenta";
            this.txtTipCuenta.ReadOnly = true;
            this.txtTipCuenta.Size = new System.Drawing.Size(248, 20);
            this.txtTipCuenta.TabIndex = 120;
            // 
            // txtFechaDocumento
            // 
            this.txtFechaDocumento.Enabled = false;
            this.txtFechaDocumento.Location = new System.Drawing.Point(698, 11);
            this.txtFechaDocumento.MaxLength = 100;
            this.txtFechaDocumento.Name = "txtFechaDocumento";
            this.txtFechaDocumento.ReadOnly = true;
            this.txtFechaDocumento.Size = new System.Drawing.Size(109, 20);
            this.txtFechaDocumento.TabIndex = 121;
            // 
            // cboTipoComision
            // 
            this.cboTipoComision.Enabled = false;
            this.cboTipoComision.FormattingEnabled = true;
            this.cboTipoComision.Location = new System.Drawing.Point(120, 11);
            this.cboTipoComision.Name = "cboTipoComision";
            this.cboTipoComision.Size = new System.Drawing.Size(151, 21);
            this.cboTipoComision.TabIndex = 122;
            // 
            // txtTipoPersona
            // 
            this.txtTipoPersona.Enabled = false;
            this.txtTipoPersona.Location = new System.Drawing.Point(438, 39);
            this.txtTipoPersona.Name = "txtTipoPersona";
            this.txtTipoPersona.ReadOnly = true;
            this.txtTipoPersona.Size = new System.Drawing.Size(369, 20);
            this.txtTipoPersona.TabIndex = 123;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.rbtAceptValorado);
            this.grbBase2.Controls.Add(this.rbtRechazaValord);
            this.grbBase2.Location = new System.Drawing.Point(6, 62);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(155, 63);
            this.grbBase2.TabIndex = 124;
            this.grbBase2.TabStop = false;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Controls.Add(this.txtComision);
            this.grbBase3.Controls.Add(this.cboTipoComision);
            this.grbBase3.Location = new System.Drawing.Point(167, 63);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(280, 63);
            this.grbBase3.TabIndex = 125;
            this.grbBase3.TabStop = false;
            this.grbBase3.Visible = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.lblBase1);
            this.grbBase4.Controls.Add(this.lblBase2);
            this.grbBase4.Controls.Add(this.grbBase3);
            this.grbBase4.Controls.Add(this.txtMotivo);
            this.grbBase4.Controls.Add(this.grbBase2);
            this.grbBase4.Controls.Add(this.lblMotivo);
            this.grbBase4.Controls.Add(this.txtTipoPersona);
            this.grbBase4.Controls.Add(this.lblBase3);
            this.grbBase4.Controls.Add(this.txtFechaDocumento);
            this.grbBase4.Controls.Add(this.lblBase4);
            this.grbBase4.Controls.Add(this.txtTipCuenta);
            this.grbBase4.Controls.Add(this.lblBase8);
            this.grbBase4.Controls.Add(this.txtProducto);
            this.grbBase4.Controls.Add(this.lblBase9);
            this.grbBase4.Controls.Add(this.cboMoneda);
            this.grbBase4.Location = new System.Drawing.Point(4, 253);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(811, 222);
            this.grbBase4.TabIndex = 126;
            this.grbBase4.TabStop = false;
            // 
            // lblBase1
            // 
            this.lblBase1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblBase1.Location = new System.Drawing.Point(438, 69);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(366, 56);
            this.lblBase1.TabIndex = 126;
            this.lblBase1.Text = "La Aceptación o Rechazo del Documento Valorado, puede tener algún costo, por favo" +
    "r debe proceder de acuerdo a su procedimiento.";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(687, 478);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 127;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmValorizarDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 553);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.dtgValoradosPend);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmValorizarDocs";
            this.Text = "Valorización de Documentos";
            this.Load += new System.EventHandler(this.frmValorizarDocs_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.dtgValoradosPend, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoradosPend)).EndInit();
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

        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.dtgBase dtgValoradosPend;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.lblBase lblMotivo;
        private GEN.ControlesBase.cboTipoValoradoFiltro cboTipoValorado;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtComision;
        private GEN.ControlesBase.rbtnBase rbtAceptValorado;
        private GEN.ControlesBase.rbtnBase rbtRechazaValord;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.txtBase txtTipCuenta;
        private GEN.ControlesBase.txtBase txtFechaDocumento;
        private GEN.ControlesBase.cboBase cboTipoComision;
        private GEN.ControlesBase.txtBase txtTipoPersona;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase1;

    }
}