namespace CAJ.Presentacion
{
    partial class frmPagoDetrac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagoDetrac));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpFecFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.chcPendientes = new GEN.ControlesBase.chcBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgCtasDetrac = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.idComprobantePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCtaDetraccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lPago = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGlosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoConv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNroCompSUNAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasDetrac)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFecFinal
            // 
            this.dtpFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinal.Location = new System.Drawing.Point(434, 69);
            this.dtpFecFinal.Name = "dtpFecFinal";
            this.dtpFecFinal.Size = new System.Drawing.Size(130, 20);
            this.dtpFecFinal.TabIndex = 5;
            // 
            // dtpFecInicial
            // 
            this.dtpFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicial.Location = new System.Drawing.Point(116, 71);
            this.dtpFecInicial.Name = "dtpFecInicial";
            this.dtpFecInicial.Size = new System.Drawing.Size(130, 20);
            this.dtpFecInicial.TabIndex = 4;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(116, 41);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(185, 21);
            this.cboAgencia.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(27, 45);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(355, 72);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(27, 75);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.chcPendientes);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.dtpFecFinal);
            this.grbBase1.Controls.Add(this.dtpFecInicial);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(4, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(772, 104);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(434, 41);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(174, 21);
            this.cboMoneda.TabIndex = 16;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(355, 44);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(56, 13);
            this.lblBase5.TabIndex = 17;
            this.lblBase5.Text = "Moneda:";
            // 
            // chcPendientes
            // 
            this.chcPendientes.AutoSize = true;
            this.chcPendientes.Location = new System.Drawing.Point(9, 15);
            this.chcPendientes.Name = "chcPendientes";
            this.chcPendientes.Size = new System.Drawing.Size(79, 17);
            this.chcPendientes.TabIndex = 7;
            this.chcPendientes.Text = "Pendientes";
            this.chcPendientes.UseVisualStyleBackColor = true;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(641, 41);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 8;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(580, 361);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 7;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(4, 361);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(716, 361);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgCtasDetrac
            // 
            this.dtgCtasDetrac.AllowUserToAddRows = false;
            this.dtgCtasDetrac.AllowUserToDeleteRows = false;
            this.dtgCtasDetrac.AllowUserToResizeColumns = false;
            this.dtgCtasDetrac.AllowUserToResizeRows = false;
            this.dtgCtasDetrac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCtasDetrac.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCtasDetrac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCtasDetrac.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idComprobantePago,
            this.cNombre,
            this.dFechaEmision,
            this.dFechaPago,
            this.nTotal,
            this.nTotalDetraccion,
            this.cCtaDetraccion,
            this.lPago,
            this.idCliente,
            this.cGlosa,
            this.nMontoConv,
            this.cNroCompSUNAT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCtasDetrac.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCtasDetrac.Location = new System.Drawing.Point(4, 115);
            this.dtgCtasDetrac.MultiSelect = false;
            this.dtgCtasDetrac.Name = "dtgCtasDetrac";
            this.dtgCtasDetrac.ReadOnly = true;
            this.dtgCtasDetrac.RowHeadersVisible = false;
            this.dtgCtasDetrac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCtasDetrac.Size = new System.Drawing.Size(772, 240);
            this.dtgCtasDetrac.TabIndex = 70;
            this.dtgCtasDetrac.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgCtasDetrac_EditingControlShowing);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(645, 361);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // idComprobantePago
            // 
            this.idComprobantePago.DataPropertyName = "idComprobantePago";
            this.idComprobantePago.FillWeight = 50F;
            this.idComprobantePago.HeaderText = "ID";
            this.idComprobantePago.Name = "idComprobantePago";
            this.idComprobantePago.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 150F;
            this.cNombre.HeaderText = "PROVEEDOR";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // dFechaEmision
            // 
            this.dFechaEmision.DataPropertyName = "dFechaEmision";
            this.dFechaEmision.FillWeight = 60F;
            this.dFechaEmision.HeaderText = "F. EMISION";
            this.dFechaEmision.Name = "dFechaEmision";
            this.dFechaEmision.ReadOnly = true;
            // 
            // dFechaPago
            // 
            this.dFechaPago.DataPropertyName = "dFechaPago";
            this.dFechaPago.FillWeight = 60F;
            this.dFechaPago.HeaderText = "F. PAGO";
            this.dFechaPago.Name = "dFechaPago";
            this.dFechaPago.ReadOnly = true;
            // 
            // nTotal
            // 
            this.nTotal.DataPropertyName = "nTotal";
            this.nTotal.FillWeight = 60F;
            this.nTotal.HeaderText = "TOTAL CPG";
            this.nTotal.Name = "nTotal";
            this.nTotal.ReadOnly = true;
            // 
            // nTotalDetraccion
            // 
            this.nTotalDetraccion.DataPropertyName = "nTotalDetraccion";
            this.nTotalDetraccion.FillWeight = 60F;
            this.nTotalDetraccion.HeaderText = "MONTO DETRAC.";
            this.nTotalDetraccion.Name = "nTotalDetraccion";
            this.nTotalDetraccion.ReadOnly = true;
            // 
            // cCtaDetraccion
            // 
            this.cCtaDetraccion.DataPropertyName = "cCtaDetraccion";
            this.cCtaDetraccion.FillWeight = 80F;
            this.cCtaDetraccion.HeaderText = "N° CUENTA";
            this.cCtaDetraccion.Name = "cCtaDetraccion";
            this.cCtaDetraccion.ReadOnly = true;
            // 
            // lPago
            // 
            this.lPago.DataPropertyName = "lPago";
            this.lPago.FillWeight = 60F;
            this.lPago.HeaderText = "CHK";
            this.lPago.Name = "lPago";
            this.lPago.ReadOnly = true;
            // 
            // idCliente
            // 
            this.idCliente.DataPropertyName = "idCliente";
            this.idCliente.HeaderText = "idCliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Visible = false;
            // 
            // cGlosa
            // 
            this.cGlosa.DataPropertyName = "cGlosa";
            this.cGlosa.HeaderText = "cGlosa";
            this.cGlosa.Name = "cGlosa";
            this.cGlosa.ReadOnly = true;
            this.cGlosa.Visible = false;
            // 
            // nMontoConv
            // 
            this.nMontoConv.DataPropertyName = "nMontoConv";
            this.nMontoConv.HeaderText = "MONTO CONV.";
            this.nMontoConv.Name = "nMontoConv";
            this.nMontoConv.ReadOnly = true;
            // 
            // cNroCompSUNAT
            // 
            this.cNroCompSUNAT.DataPropertyName = "cNroCompSUNAT";
            this.cNroCompSUNAT.HeaderText = "N° COMP";
            this.cNroCompSUNAT.Name = "cNroCompSUNAT";
            this.cNroCompSUNAT.ReadOnly = true;
            // 
            // frmPagoDetrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 436);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtgCtasDetrac);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.grbBase1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPagoDetrac";
            this.Text = "Pago de Detraccción de Proveedores";
            this.Load += new System.EventHandler(this.frmPagoDetrac_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgCtasDetrac, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCtasDetrac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFecFinal;
        private GEN.ControlesBase.dtpCorto dtpFecInicial;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.chcBase chcPendientes;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgCtasDetrac;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobantePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalDetraccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCtaDetraccion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGlosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoConv;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNroCompSUNAT;
    }
}