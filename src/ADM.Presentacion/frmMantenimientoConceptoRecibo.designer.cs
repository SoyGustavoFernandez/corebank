namespace ADM.Presentacion
{
    partial class frmMantenimientoConceptoRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoConceptoRecibo));
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcAfectaCaja = new System.Windows.Forms.CheckBox();
            this.cboTipoMonto = new GEN.ControlesBase.cboBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.CBVigente = new System.Windows.Forms.CheckBox();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.CBSoloPersonal = new System.Windows.Forms.CheckBox();
            this.txtNombConcepto = new GEN.ControlesBase.txtCBLetra(this.components);
            this.CBAfectaITF = new System.Windows.Forms.CheckBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgConcepRecib = new GEN.ControlesBase.dtgBase(this.components);
            this.cboTipoRecibo = new GEN.ControlesBase.cboBase(this.components);
            this.chbRestringido = new System.Windows.Forms.CheckBox();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConcepRecib)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(303, 508);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chbRestringido);
            this.grbBase1.Controls.Add(this.chcAfectaCaja);
            this.grbBase1.Controls.Add(this.cboTipoMonto);
            this.grbBase1.Controls.Add(this.txtMonto);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.CBSoloPersonal);
            this.grbBase1.Controls.Add(this.txtNombConcepto);
            this.grbBase1.Controls.Add(this.CBAfectaITF);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(16, 41);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(533, 123);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales";
            // 
            // chcAfectaCaja
            // 
            this.chcAfectaCaja.AutoSize = true;
            this.chcAfectaCaja.ForeColor = System.Drawing.Color.Navy;
            this.chcAfectaCaja.Location = new System.Drawing.Point(122, 102);
            this.chcAfectaCaja.Name = "chcAfectaCaja";
            this.chcAfectaCaja.Size = new System.Drawing.Size(90, 17);
            this.chcAfectaCaja.TabIndex = 24;
            this.chcAfectaCaja.Text = "Afecta a Caja";
            this.chcAfectaCaja.UseVisualStyleBackColor = true;
            // 
            // cboTipoMonto
            // 
            this.cboTipoMonto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMonto.FormattingEnabled = true;
            this.cboTipoMonto.Location = new System.Drawing.Point(122, 48);
            this.cboTipoMonto.Name = "cboTipoMonto";
            this.cboTipoMonto.Size = new System.Drawing.Size(112, 21);
            this.cboTipoMonto.TabIndex = 1;
            // 
            // txtMonto
            // 
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(122, 75);
            this.txtMonto.MaxLength = 10;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 4;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(112, 20);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(409, 85);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 5;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 78);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(46, 13);
            this.lblBase5.TabIndex = 23;
            this.lblBase5.Text = "Monto:";
            // 
            // CBSoloPersonal
            // 
            this.CBSoloPersonal.AutoSize = true;
            this.CBSoloPersonal.ForeColor = System.Drawing.Color.Navy;
            this.CBSoloPersonal.Location = new System.Drawing.Point(409, 67);
            this.CBSoloPersonal.Name = "CBSoloPersonal";
            this.CBSoloPersonal.Size = new System.Drawing.Size(91, 17);
            this.CBSoloPersonal.TabIndex = 4;
            this.CBSoloPersonal.Text = "Sólo Personal";
            this.CBSoloPersonal.UseVisualStyleBackColor = true;
            // 
            // txtNombConcepto
            // 
            this.txtNombConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombConcepto.Location = new System.Drawing.Point(122, 22);
            this.txtNombConcepto.MaxLength = 50;
            this.txtNombConcepto.Name = "txtNombConcepto";
            this.txtNombConcepto.Size = new System.Drawing.Size(371, 20);
            this.txtNombConcepto.TabIndex = 0;
            // 
            // CBAfectaITF
            // 
            this.CBAfectaITF.AutoSize = true;
            this.CBAfectaITF.ForeColor = System.Drawing.Color.Navy;
            this.CBAfectaITF.Location = new System.Drawing.Point(409, 49);
            this.CBAfectaITF.Name = "CBAfectaITF";
            this.CBAfectaITF.Size = new System.Drawing.Size(76, 17);
            this.CBAfectaITF.TabIndex = 3;
            this.CBAfectaITF.Text = "Afecta ITF";
            this.CBAfectaITF.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(66, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Concepto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 51);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(92, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Tipo de Monto:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 15);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 29;
            this.lblBase3.Text = "Tipo de Recibo:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(427, 508);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(241, 508);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(365, 508);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(489, 508);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgConcepRecib
            // 
            this.dtgConcepRecib.AllowUserToAddRows = false;
            this.dtgConcepRecib.AllowUserToDeleteRows = false;
            this.dtgConcepRecib.AllowUserToResizeColumns = false;
            this.dtgConcepRecib.AllowUserToResizeRows = false;
            this.dtgConcepRecib.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConcepRecib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConcepRecib.Location = new System.Drawing.Point(16, 172);
            this.dtgConcepRecib.MultiSelect = false;
            this.dtgConcepRecib.Name = "dtgConcepRecib";
            this.dtgConcepRecib.ReadOnly = true;
            this.dtgConcepRecib.RowHeadersVisible = false;
            this.dtgConcepRecib.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConcepRecib.Size = new System.Drawing.Size(533, 330);
            this.dtgConcepRecib.TabIndex = 23;
            this.dtgConcepRecib.SelectionChanged += new System.EventHandler(this.dtgConcepRecib_SelectionChanged);
            // 
            // cboTipoRecibo
            // 
            this.cboTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRecibo.FormattingEnabled = true;
            this.cboTipoRecibo.Location = new System.Drawing.Point(138, 15);
            this.cboTipoRecibo.Name = "cboTipoRecibo";
            this.cboTipoRecibo.Size = new System.Drawing.Size(287, 21);
            this.cboTipoRecibo.TabIndex = 0;
            this.cboTipoRecibo.SelectedIndexChanged += new System.EventHandler(this.cboTipoRecibo_SelectedIndexChanged_1);
            // 
            // chbRestringido
            // 
            this.chbRestringido.AutoSize = true;
            this.chbRestringido.ForeColor = System.Drawing.Color.Navy;
            this.chbRestringido.Location = new System.Drawing.Point(409, 102);
            this.chbRestringido.Name = "chbRestringido";
            this.chbRestringido.Size = new System.Drawing.Size(79, 17);
            this.chbRestringido.TabIndex = 25;
            this.chbRestringido.Text = "Restringido";
            this.chbRestringido.UseVisualStyleBackColor = true;
            // 
            // frmMantenimientoConceptoRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 584);
            this.Controls.Add(this.cboTipoRecibo);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgConcepRecib);
            this.Name = "frmMantenimientoConceptoRecibo";
            this.Text = "Mantenimiento de Concepto de Recibos";
            this.Load += new System.EventHandler(this.frmMantenimientoConceptoRecibo_Load);
            this.Controls.SetChildIndex(this.dtgConcepRecib, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.cboTipoRecibo, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConcepRecib)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.CheckBox CBSoloPersonal;
        private GEN.ControlesBase.txtCBLetra txtNombConcepto;
        private System.Windows.Forms.CheckBox CBAfectaITF;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgConcepRecib;
        private System.Windows.Forms.CheckBox CBVigente;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.cboBase cboTipoRecibo;
        private GEN.ControlesBase.cboBase cboTipoMonto;
        private System.Windows.Forms.CheckBox chcAfectaCaja;
        private System.Windows.Forms.CheckBox chbRestringido;
    }
}