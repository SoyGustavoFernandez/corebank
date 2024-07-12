namespace CAJ.Presentacion
{
    partial class frmAgregDetRegVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregDetRegVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtPrecUnit = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtCantidad = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtBusCom = new GEN.ControlesBase.txtBase(this.components);
            this.lblConcepto = new GEN.ControlesBase.lblBase();
            this.dtgSubConceptos = new GEN.ControlesBase.dtgBase(this.components);
            this.idConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAfectoITF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtPrecUnit);
            this.grbBase1.Controls.Add(this.txtCantidad);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(16, 15);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase1.Size = new System.Drawing.Size(576, 100);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Detalle";
            // 
            // txtPrecUnit
            // 
            this.txtPrecUnit.FormatoDecimal = false;
            this.txtPrecUnit.Location = new System.Drawing.Point(421, 59);
            this.txtPrecUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecUnit.Name = "txtPrecUnit";
            this.txtPrecUnit.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecUnit.nNumDecimales = 4;
            this.txtPrecUnit.nvalor = 0D;
            this.txtPrecUnit.Size = new System.Drawing.Size(132, 22);
            this.txtPrecUnit.TabIndex = 5;
            this.txtPrecUnit.Leave += new System.EventHandler(this.txtPrecUnit_Leave);
            // 
            // txtCantidad
            // 
            this.txtCantidad.FormatoDecimal = false;
            this.txtCantidad.Location = new System.Drawing.Point(115, 59);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCantidad.nNumDecimales = 4;
            this.txtCantidad.nvalor = 0D;
            this.txtCantidad.Size = new System.Drawing.Size(160, 22);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(356, 62);
            this.lblBase3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(58, 17);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Monto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(17, 64);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(76, 17);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Cantidad:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(115, 25);
            this.cboAgencias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(439, 24);
            this.cboAgencias.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 30);
            this.lblBase1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(68, 17);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Agencia:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnBusqueda);
            this.grbBase2.Controls.Add(this.txtBusCom);
            this.grbBase2.Controls.Add(this.lblConcepto);
            this.grbBase2.Controls.Add(this.dtgSubConceptos);
            this.grbBase2.Location = new System.Drawing.Point(17, 122);
            this.grbBase2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbBase2.Size = new System.Drawing.Size(575, 297);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Buscar Concepto";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(473, 21);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 14;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtBusCom
            // 
            this.txtBusCom.Location = new System.Drawing.Point(113, 39);
            this.txtBusCom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusCom.Name = "txtBusCom";
            this.txtBusCom.Size = new System.Drawing.Size(340, 22);
            this.txtBusCom.TabIndex = 13;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblConcepto.ForeColor = System.Drawing.Color.Navy;
            this.lblConcepto.Location = new System.Drawing.Point(20, 44);
            this.lblConcepto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(81, 17);
            this.lblConcepto.TabIndex = 10;
            this.lblConcepto.Text = "Concepto:";
            // 
            // dtgSubConceptos
            // 
            this.dtgSubConceptos.AllowUserToAddRows = false;
            this.dtgSubConceptos.AllowUserToDeleteRows = false;
            this.dtgSubConceptos.AllowUserToResizeColumns = false;
            this.dtgSubConceptos.AllowUserToResizeRows = false;
            this.dtgSubConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSubConceptos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSubConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSubConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConcepto,
            this.cConcepto,
            this.cTipMonto,
            this.nMontoCon,
            this.nAfectoITF});
            this.dtgSubConceptos.Location = new System.Drawing.Point(20, 89);
            this.dtgSubConceptos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgSubConceptos.MultiSelect = false;
            this.dtgSubConceptos.Name = "dtgSubConceptos";
            this.dtgSubConceptos.ReadOnly = true;
            this.dtgSubConceptos.RowHeadersVisible = false;
            this.dtgSubConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSubConceptos.Size = new System.Drawing.Size(533, 191);
            this.dtgSubConceptos.TabIndex = 9;
            // 
            // idConcepto
            // 
            this.idConcepto.DataPropertyName = "idConcepto";
            this.idConcepto.FillWeight = 1F;
            this.idConcepto.HeaderText = "Codigo";
            this.idConcepto.MinimumWidth = 60;
            this.idConcepto.Name = "idConcepto";
            this.idConcepto.ReadOnly = true;
            // 
            // cConcepto
            // 
            this.cConcepto.DataPropertyName = "cConcepto";
            this.cConcepto.HeaderText = "Concepto";
            this.cConcepto.MinimumWidth = 300;
            this.cConcepto.Name = "cConcepto";
            this.cConcepto.ReadOnly = true;
            // 
            // cTipMonto
            // 
            this.cTipMonto.DataPropertyName = "cTipMonto";
            this.cTipMonto.HeaderText = "cTipMonto";
            this.cTipMonto.Name = "cTipMonto";
            this.cTipMonto.ReadOnly = true;
            this.cTipMonto.Visible = false;
            // 
            // nMontoCon
            // 
            this.nMontoCon.DataPropertyName = "nMontoCon";
            this.nMontoCon.HeaderText = "nMontoCon";
            this.nMontoCon.Name = "nMontoCon";
            this.nMontoCon.ReadOnly = true;
            this.nMontoCon.Visible = false;
            // 
            // nAfectoITF
            // 
            this.nAfectoITF.DataPropertyName = "nAfectoITF";
            this.nAfectoITF.HeaderText = "nAfectoITF";
            this.nAfectoITF.Name = "nAfectoITF";
            this.nAfectoITF.ReadOnly = true;
            this.nAfectoITF.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(512, 430);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(424, 430);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmAgregDetRegVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 532);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmAgregDetRegVentas";
            this.Text = "Agregar Detalle de Registro de Ventas";
            this.Load += new System.EventHandler(this.frmAgregDetRegVentas_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSubConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtPrecUnit;
        private GEN.ControlesBase.txtNumRea txtCantidad;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtBase txtBusCom;
        private GEN.ControlesBase.lblBase lblConcepto;
        private GEN.ControlesBase.dtgBase dtgSubConceptos;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAfectoITF;
    }
}