namespace ADM.Presentacion
{
    partial class frmEditarSeguroOptativo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarSeguroOptativo));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblPaquetes = new GEN.ControlesBase.lblBase();
            this.txtTipoSeguro = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoValor = new GEN.ControlesBase.cboBase(this.components);
            this.cboConceptoRecibo = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipoPago = new GEN.ControlesBase.cboBase(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.chbVigente = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlExpandCollapse1 = new GEN.ControlesBase.pnlExpandCollapse();
            this.btnAgregarPlanPagos = new GEN.BotonesBase.btnMiniAgregar();
            this.txtPrecioMensual = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnCancelarPlan = new GEN.BotonesBase.btnMiniCancelEst();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.dtgListaPlanSeguro = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.txtPrima = new GEN.ControlesBase.txtNumRea(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlExpandCollapse1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPlanSeguro)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(31, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(76, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Tipo Seguro";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(67, 39);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(40, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Prima";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(43, 62);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(64, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Tipo Valor";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(4, 85);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(103, 13);
            this.lblBase4.TabIndex = 5;
            this.lblBase4.Text = "Concepto Recibo";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(44, 107);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 6;
            this.lblBase5.Text = "Tipo Pago";
            // 
            // lblPaquetes
            // 
            this.lblPaquetes.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPaquetes.ForeColor = System.Drawing.Color.Navy;
            this.lblPaquetes.Location = new System.Drawing.Point(4, 145);
            this.lblPaquetes.Name = "lblPaquetes";
            this.lblPaquetes.Size = new System.Drawing.Size(318, 38);
            this.lblPaquetes.TabIndex = 65;
            this.lblPaquetes.Text = "El seguro actual solo puede modificarse en el mantenimiento de Planes de Seguro";
            this.lblPaquetes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPaquetes.Visible = false;
            // 
            // txtTipoSeguro
            // 
            this.txtTipoSeguro.Location = new System.Drawing.Point(109, 14);
            this.txtTipoSeguro.Name = "txtTipoSeguro";
            this.txtTipoSeguro.Size = new System.Drawing.Size(212, 20);
            this.txtTipoSeguro.TabIndex = 7;
            // 
            // cboTipoValor
            // 
            this.cboTipoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValor.FormattingEnabled = true;
            this.cboTipoValor.Location = new System.Drawing.Point(109, 58);
            this.cboTipoValor.Name = "cboTipoValor";
            this.cboTipoValor.Size = new System.Drawing.Size(212, 21);
            this.cboTipoValor.TabIndex = 9;
            // 
            // cboConceptoRecibo
            // 
            this.cboConceptoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptoRecibo.DropDownWidth = 267;
            this.cboConceptoRecibo.FormattingEnabled = true;
            this.cboConceptoRecibo.Location = new System.Drawing.Point(109, 81);
            this.cboConceptoRecibo.Name = "cboConceptoRecibo";
            this.cboConceptoRecibo.Size = new System.Drawing.Size(212, 21);
            this.cboConceptoRecibo.TabIndex = 10;
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(109, 104);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(212, 21);
            this.cboTipoPago.TabIndex = 11;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(192, 2);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 12;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // chbVigente
            // 
            this.chbVigente.AutoSize = true;
            this.chbVigente.Location = new System.Drawing.Point(109, 128);
            this.chbVigente.Name = "chbVigente";
            this.chbVigente.Size = new System.Drawing.Size(62, 17);
            this.chbVigente.TabIndex = 14;
            this.chbVigente.Text = "Vigente";
            this.chbVigente.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.pnlExpandCollapse1);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 186);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 241);
            this.flowLayoutPanel1.TabIndex = 64;
            // 
            // pnlExpandCollapse1
            // 
            this.pnlExpandCollapse1.ButtonSize = GEN.ControlesBase.btnExpandCollapse.ExpandButtonSize.Small;
            this.pnlExpandCollapse1.ButtonStyle = GEN.ControlesBase.btnExpandCollapse.ExpandButtonStyle.Classic;
            this.pnlExpandCollapse1.Controls.Add(this.btnAgregarPlanPagos);
            this.pnlExpandCollapse1.Controls.Add(this.txtPrecioMensual);
            this.pnlExpandCollapse1.Controls.Add(this.btnCancelarPlan);
            this.pnlExpandCollapse1.Controls.Add(this.lblBase6);
            this.pnlExpandCollapse1.Controls.Add(this.btnMiniEditar1);
            this.pnlExpandCollapse1.Controls.Add(this.dtgListaPlanSeguro);
            this.pnlExpandCollapse1.ExpandedHeight = 124;
            this.pnlExpandCollapse1.IsExpanded = true;
            this.pnlExpandCollapse1.Location = new System.Drawing.Point(3, 3);
            this.pnlExpandCollapse1.Name = "pnlExpandCollapse1";
            this.pnlExpandCollapse1.Size = new System.Drawing.Size(318, 174);
            this.pnlExpandCollapse1.TabIndex = 0;
            this.pnlExpandCollapse1.Text = "Plan Seguro";
            this.pnlExpandCollapse1.UseAnimation = true;
            this.pnlExpandCollapse1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlExpandCollapse1_Paint);
            // 
            // btnAgregarPlanPagos
            // 
            this.btnAgregarPlanPagos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarPlanPagos.BackgroundImage")));
            this.btnAgregarPlanPagos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarPlanPagos.Location = new System.Drawing.Point(246, 140);
            this.btnAgregarPlanPagos.Name = "btnAgregarPlanPagos";
            this.btnAgregarPlanPagos.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarPlanPagos.TabIndex = 10;
            this.btnAgregarPlanPagos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarPlanPagos.UseVisualStyleBackColor = true;
            this.btnAgregarPlanPagos.Click += new System.EventHandler(this.btnAgregarPlanPagos_Click);
            // 
            // txtPrecioMensual
            // 
            this.txtPrecioMensual.FormatoDecimal = false;
            this.txtPrecioMensual.Location = new System.Drawing.Point(106, 143);
            this.txtPrecioMensual.MaxLength = 14;
            this.txtPrecioMensual.Name = "txtPrecioMensual";
            this.txtPrecioMensual.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPrecioMensual.nNumDecimales = 2;
            this.txtPrecioMensual.nvalor = 0D;
            this.txtPrecioMensual.Size = new System.Drawing.Size(76, 21);
            this.txtPrecioMensual.TabIndex = 9;
            this.txtPrecioMensual.Text = "0.00";
            // 
            // btnCancelarPlan
            // 
            this.btnCancelarPlan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarPlan.BackgroundImage")));
            this.btnCancelarPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarPlan.Location = new System.Drawing.Point(210, 140);
            this.btnCancelarPlan.Name = "btnCancelarPlan";
            this.btnCancelarPlan.Size = new System.Drawing.Size(36, 28);
            this.btnCancelarPlan.TabIndex = 8;
            this.btnCancelarPlan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarPlan.UseVisualStyleBackColor = true;
            this.btnCancelarPlan.Click += new System.EventHandler(this.btnCancelarPlan_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 148);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(92, 13);
            this.lblBase6.TabIndex = 6;
            this.lblBase6.Text = "Precio Mensual";
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.btnMiniEditar1.Location = new System.Drawing.Point(282, 140);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 3;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = false;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditar1_Click);
            // 
            // dtgListaPlanSeguro
            // 
            this.dtgListaPlanSeguro.AllowUserToAddRows = false;
            this.dtgListaPlanSeguro.AllowUserToDeleteRows = false;
            this.dtgListaPlanSeguro.AllowUserToResizeColumns = false;
            this.dtgListaPlanSeguro.AllowUserToResizeRows = false;
            this.dtgListaPlanSeguro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgListaPlanSeguro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPlanSeguro.Location = new System.Drawing.Point(4, 29);
            this.dtgListaPlanSeguro.MultiSelect = false;
            this.dtgListaPlanSeguro.Name = "dtgListaPlanSeguro";
            this.dtgListaPlanSeguro.ReadOnly = true;
            this.dtgListaPlanSeguro.RowHeadersVisible = false;
            this.dtgListaPlanSeguro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPlanSeguro.Size = new System.Drawing.Size(314, 105);
            this.dtgListaPlanSeguro.TabIndex = 1;
            this.dtgListaPlanSeguro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaPlanSeguro_CellContentClick);
            this.dtgListaPlanSeguro.SelectionChanged += new System.EventHandler(this.dtgListaPlanSeguro_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalir1);
            this.panel1.Controls.Add(this.btnGrabar1);
            this.panel1.Location = new System.Drawing.Point(3, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 55);
            this.panel1.TabIndex = 2;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(258, 3);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 13;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // txtPrima
            // 
            this.txtPrima.FormatoDecimal = false;
            this.txtPrima.Location = new System.Drawing.Point(109, 36);
            this.txtPrima.MaxLength = 14;
            this.txtPrima.Name = "txtPrima";
            this.txtPrima.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPrima.nNumDecimales = 6;
            this.txtPrima.nvalor = 0D;
            this.txtPrima.Size = new System.Drawing.Size(212, 20);
            this.txtPrima.TabIndex = 10;
            this.txtPrima.Text = "0.00";
            // 
            // frmEditarSeguroOptativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(329, 441);
            this.Controls.Add(this.txtPrima);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chbVigente);
            this.Controls.Add(this.cboTipoPago);
            this.Controls.Add(this.cboConceptoRecibo);
            this.Controls.Add(this.cboTipoValor);
            this.Controls.Add(this.txtTipoSeguro);
            this.Controls.Add(this.lblPaquetes);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmEditarSeguroOptativo";
            this.Text = "Editar Seguro Optativo";
            this.Load += new System.EventHandler(this.frmEditarSeguroOptativo_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblPaquetes, 0);
            this.Controls.SetChildIndex(this.txtTipoSeguro, 0);
            this.Controls.SetChildIndex(this.cboTipoValor, 0);
            this.Controls.SetChildIndex(this.cboConceptoRecibo, 0);
            this.Controls.SetChildIndex(this.cboTipoPago, 0);
            this.Controls.SetChildIndex(this.chbVigente, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.txtPrima, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlExpandCollapse1.ResumeLayout(false);
            this.pnlExpandCollapse1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPlanSeguro)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblPaquetes;
        private GEN.ControlesBase.txtBase txtTipoSeguro;
        private GEN.ControlesBase.cboBase cboTipoValor;
        private GEN.ControlesBase.cboBase cboConceptoRecibo;
        private GEN.ControlesBase.cboBase cboTipoPago;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private System.Windows.Forms.CheckBox chbVigente;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GEN.ControlesBase.pnlExpandCollapse pnlExpandCollapse1;
        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private GEN.ControlesBase.dtgBase dtgListaPlanSeguro;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnMiniCancelEst btnCancelarPlan;
        private GEN.ControlesBase.txtNumRea txtPrecioMensual;
        private GEN.ControlesBase.txtNumRea txtPrima;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarPlanPagos;
    }
}