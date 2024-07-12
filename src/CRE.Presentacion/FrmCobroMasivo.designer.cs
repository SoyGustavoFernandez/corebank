namespace CRE.Presentacion
{
    partial class FrmCobroMasivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCobroMasivo));
            this.cboPersonalCreditos1 = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgBase1 = new GEN.ControlesBase.dtgBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.txtNumRea1 = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNumRea2 = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNumRea3 = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNumRea4 = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtNumRea5 = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPersonalCreditos1
            // 
            this.cboPersonalCreditos1.FormattingEnabled = true;
            this.cboPersonalCreditos1.Location = new System.Drawing.Point(70, 16);
            this.cboPersonalCreditos1.Name = "cboPersonalCreditos1";
            this.cboPersonalCreditos1.Size = new System.Drawing.Size(284, 21);
            this.cboPersonalCreditos1.TabIndex = 2;
            this.cboPersonalCreditos1.SelectedIndexChanged += new System.EventHandler(this.cboPersonalCreditos1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Asesor:";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(70, 43);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(284, 21);
            this.cboMoneda1.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(51, 13);
            this.lblBase2.TabIndex = 5;
            this.lblBase2.Text = "Moneda";
            // 
            // dtgBase1
            // 
            this.dtgBase1.AllowUserToAddRows = false;
            this.dtgBase1.AllowUserToDeleteRows = false;
            this.dtgBase1.AllowUserToOrderColumns = true;
            this.dtgBase1.AllowUserToResizeColumns = false;
            this.dtgBase1.AllowUserToResizeRows = false;
            this.dtgBase1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBase1.Location = new System.Drawing.Point(16, 78);
            this.dtgBase1.MultiSelect = false;
            this.dtgBase1.Name = "dtgBase1";
            this.dtgBase1.ReadOnly = true;
            this.dtgBase1.RowHeadersVisible = false;
            this.dtgBase1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgBase1.Size = new System.Drawing.Size(904, 293);
            this.dtgBase1.TabIndex = 6;
            this.dtgBase1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellContentClick);
            this.dtgBase1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBase1_CellValueChanged);
            this.dtgBase1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgBase1_EditingControlShowing);
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(360, 14);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 7;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(794, 377);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 8;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(860, 377);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 9;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(728, 377);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // txtNumRea1
            // 
            this.txtNumRea1.Enabled = false;
            this.txtNumRea1.FormatoDecimal = false;
            this.txtNumRea1.Location = new System.Drawing.Point(396, 384);
            this.txtNumRea1.Name = "txtNumRea1";
            this.txtNumRea1.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumRea1.nNumDecimales = 4;
            this.txtNumRea1.nvalor = 0D;
            this.txtNumRea1.Size = new System.Drawing.Size(100, 20);
            this.txtNumRea1.TabIndex = 11;
            this.txtNumRea1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumRea2
            // 
            this.txtNumRea2.Enabled = false;
            this.txtNumRea2.FormatoDecimal = false;
            this.txtNumRea2.Location = new System.Drawing.Point(396, 411);
            this.txtNumRea2.Name = "txtNumRea2";
            this.txtNumRea2.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumRea2.nNumDecimales = 4;
            this.txtNumRea2.nvalor = 0D;
            this.txtNumRea2.Size = new System.Drawing.Size(100, 20);
            this.txtNumRea2.TabIndex = 12;
            this.txtNumRea2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumRea3
            // 
            this.txtNumRea3.Enabled = false;
            this.txtNumRea3.FormatoDecimal = false;
            this.txtNumRea3.Location = new System.Drawing.Point(396, 438);
            this.txtNumRea3.Name = "txtNumRea3";
            this.txtNumRea3.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumRea3.nNumDecimales = 4;
            this.txtNumRea3.nvalor = 0D;
            this.txtNumRea3.Size = new System.Drawing.Size(100, 20);
            this.txtNumRea3.TabIndex = 13;
            this.txtNumRea3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(275, 387);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(115, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Importe de Cuotas";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(275, 413);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Importe de Moras";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(275, 441);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(88, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Total Cobrado";
            // 
            // txtNumRea4
            // 
            this.txtNumRea4.Enabled = false;
            this.txtNumRea4.FormatoDecimal = false;
            this.txtNumRea4.Location = new System.Drawing.Point(170, 384);
            this.txtNumRea4.Name = "txtNumRea4";
            this.txtNumRea4.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumRea4.nNumDecimales = 4;
            this.txtNumRea4.nvalor = 0D;
            this.txtNumRea4.Size = new System.Drawing.Size(100, 20);
            this.txtNumRea4.TabIndex = 17;
            this.txtNumRea4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumRea5
            // 
            this.txtNumRea5.Enabled = false;
            this.txtNumRea5.FormatoDecimal = false;
            this.txtNumRea5.Location = new System.Drawing.Point(170, 411);
            this.txtNumRea5.Name = "txtNumRea5";
            this.txtNumRea5.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNumRea5.nNumDecimales = 4;
            this.txtNumRea5.nvalor = 0D;
            this.txtNumRea5.Size = new System.Drawing.Size(100, 20);
            this.txtNumRea5.TabIndex = 18;
            this.txtNumRea5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(16, 387);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(105, 13);
            this.lblBase6.TabIndex = 19;
            this.lblBase6.Text = "Total de Créditos";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(19, 413);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(146, 13);
            this.lblBase7.TabIndex = 20;
            this.lblBase7.Text = "Total Créditos Cobrados";
            // 
            // FrmCobroMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 489);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtNumRea5);
            this.Controls.Add(this.txtNumRea4);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.txtNumRea3);
            this.Controls.Add(this.txtNumRea2);
            this.Controls.Add(this.txtNumRea1);
            this.Controls.Add(this.dtgBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnProcesar1);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboPersonalCreditos1);
            this.Name = "FrmCobroMasivo";
            this.Text = "Cobros Masivos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCobroMasivo_FormClosed);
            this.Load += new System.EventHandler(this.FrmCobroMasivo_Load);
            this.Controls.SetChildIndex(this.cboPersonalCreditos1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.btnProcesar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.dtgBase1, 0);
            this.Controls.SetChildIndex(this.txtNumRea1, 0);
            this.Controls.SetChildIndex(this.txtNumRea2, 0);
            this.Controls.SetChildIndex(this.txtNumRea3, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtNumRea4, 0);
            this.Controls.SetChildIndex(this.txtNumRea5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBase1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboPersonalCreditos cboPersonalCreditos1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtNumRea txtNumRea1;
        private GEN.ControlesBase.txtNumRea txtNumRea2;
        private GEN.ControlesBase.txtNumRea txtNumRea3;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtNumRea4;
        private GEN.ControlesBase.txtNumRea txtNumRea5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}