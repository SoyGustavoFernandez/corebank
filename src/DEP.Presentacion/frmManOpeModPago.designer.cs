namespace DEP.Presentacion
{
    partial class frmManOpeModPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManOpeModPago));
            this.dtgManOpeModPago = new System.Windows.Forms.DataGridView();
            this.clsListaModPagoOperacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.cDesTipoPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOpeDeposito = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lOpeRetiroDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lOpeAperturaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lOpeCancelacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lOpePagoComPagoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lPagoCreditoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgManOpeModPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsListaModPagoOperacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgManOpeModPago
            // 
            this.dtgManOpeModPago.AllowUserToAddRows = false;
            this.dtgManOpeModPago.AllowUserToDeleteRows = false;
            this.dtgManOpeModPago.AutoGenerateColumns = false;
            this.dtgManOpeModPago.BackgroundColor = System.Drawing.Color.White;
            this.dtgManOpeModPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgManOpeModPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDesTipoPagoDataGridViewTextBoxColumn,
            this.lOpeDeposito,
            this.lOpeRetiroDataGridViewCheckBoxColumn,
            this.lOpeAperturaDataGridViewCheckBoxColumn,
            this.lOpeCancelacion,
            this.lOpePagoComPagoDataGridViewCheckBoxColumn,
            this.lPagoCreditoDataGridViewCheckBoxColumn,
            this.idTipoPagoDataGridViewTextBoxColumn});
            this.dtgManOpeModPago.DataSource = this.clsListaModPagoOperacionBindingSource;
            this.dtgManOpeModPago.Location = new System.Drawing.Point(9, 27);
            this.dtgManOpeModPago.Name = "dtgManOpeModPago";
            this.dtgManOpeModPago.ReadOnly = true;
            this.dtgManOpeModPago.RowHeadersWidth = 15;
            this.dtgManOpeModPago.Size = new System.Drawing.Size(655, 221);
            this.dtgManOpeModPago.TabIndex = 0;
            // 
            // clsListaModPagoOperacionBindingSource
            // 
            this.clsListaModPagoOperacionBindingSource.DataSource = typeof(EntityLayer.clsListaModPagoOperacion);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(604, 254);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(406, 254);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 1;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idTipoPago";
            this.dataGridViewTextBoxColumn1.HeaderText = "idTipoPago";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cDesTipoPago";
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Modalidad Pago";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // lblBase1
            // 
            this.lblBase1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblBase1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(194, 5);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(470, 21);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Operaciones";
            this.lblBase1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(538, 254);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(472, 254);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // cDesTipoPagoDataGridViewTextBoxColumn
            // 
            this.cDesTipoPagoDataGridViewTextBoxColumn.DataPropertyName = "cDesTipoPago";
            this.cDesTipoPagoDataGridViewTextBoxColumn.FillWeight = 170F;
            this.cDesTipoPagoDataGridViewTextBoxColumn.HeaderText = "Modalidad de Pago";
            this.cDesTipoPagoDataGridViewTextBoxColumn.Name = "cDesTipoPagoDataGridViewTextBoxColumn";
            this.cDesTipoPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDesTipoPagoDataGridViewTextBoxColumn.Width = 170;
            // 
            // lOpeDeposito
            // 
            this.lOpeDeposito.DataPropertyName = "lOpeDeposito";
            this.lOpeDeposito.FillWeight = 54F;
            this.lOpeDeposito.HeaderText = "Deposito";
            this.lOpeDeposito.Name = "lOpeDeposito";
            this.lOpeDeposito.ReadOnly = true;
            this.lOpeDeposito.Width = 54;
            // 
            // lOpeRetiroDataGridViewCheckBoxColumn
            // 
            this.lOpeRetiroDataGridViewCheckBoxColumn.DataPropertyName = "lOpeRetiro";
            this.lOpeRetiroDataGridViewCheckBoxColumn.FillWeight = 54F;
            this.lOpeRetiroDataGridViewCheckBoxColumn.HeaderText = "Retiro";
            this.lOpeRetiroDataGridViewCheckBoxColumn.Name = "lOpeRetiroDataGridViewCheckBoxColumn";
            this.lOpeRetiroDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lOpeRetiroDataGridViewCheckBoxColumn.Width = 54;
            // 
            // lOpeAperturaDataGridViewCheckBoxColumn
            // 
            this.lOpeAperturaDataGridViewCheckBoxColumn.DataPropertyName = "lOpeApertura";
            this.lOpeAperturaDataGridViewCheckBoxColumn.FillWeight = 54F;
            this.lOpeAperturaDataGridViewCheckBoxColumn.HeaderText = "Apertura";
            this.lOpeAperturaDataGridViewCheckBoxColumn.Name = "lOpeAperturaDataGridViewCheckBoxColumn";
            this.lOpeAperturaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lOpeAperturaDataGridViewCheckBoxColumn.Width = 54;
            // 
            // lOpeCancelacion
            // 
            this.lOpeCancelacion.DataPropertyName = "lOpeCancelacion";
            this.lOpeCancelacion.FillWeight = 70F;
            this.lOpeCancelacion.HeaderText = "Cancelación";
            this.lOpeCancelacion.Name = "lOpeCancelacion";
            this.lOpeCancelacion.ReadOnly = true;
            this.lOpeCancelacion.Width = 70;
            // 
            // lOpePagoComPagoDataGridViewCheckBoxColumn
            // 
            this.lOpePagoComPagoDataGridViewCheckBoxColumn.DataPropertyName = "lOpePagoComPago";
            this.lOpePagoComPagoDataGridViewCheckBoxColumn.FillWeight = 150F;
            this.lOpePagoComPagoDataGridViewCheckBoxColumn.HeaderText = "Pago Comprobante Pago";
            this.lOpePagoComPagoDataGridViewCheckBoxColumn.Name = "lOpePagoComPagoDataGridViewCheckBoxColumn";
            this.lOpePagoComPagoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lOpePagoComPagoDataGridViewCheckBoxColumn.Width = 150;
            // 
            // lPagoCreditoDataGridViewCheckBoxColumn
            // 
            this.lPagoCreditoDataGridViewCheckBoxColumn.DataPropertyName = "lPagoCredito";
            this.lPagoCreditoDataGridViewCheckBoxColumn.FillWeight = 80F;
            this.lPagoCreditoDataGridViewCheckBoxColumn.HeaderText = "Pago Credito";
            this.lPagoCreditoDataGridViewCheckBoxColumn.Name = "lPagoCreditoDataGridViewCheckBoxColumn";
            this.lPagoCreditoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lPagoCreditoDataGridViewCheckBoxColumn.Width = 80;
            // 
            // idTipoPagoDataGridViewTextBoxColumn
            // 
            this.idTipoPagoDataGridViewTextBoxColumn.DataPropertyName = "idTipoPago";
            this.idTipoPagoDataGridViewTextBoxColumn.HeaderText = "idTipoPago";
            this.idTipoPagoDataGridViewTextBoxColumn.Name = "idTipoPagoDataGridViewTextBoxColumn";
            this.idTipoPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoPagoDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmManOpeModPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 335);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.dtgManOpeModPago);
            this.Name = "frmManOpeModPago";
            this.Text = "Mantenimiento Operación por Modalidad de Pago";
            this.Load += new System.EventHandler(this.frmMantOperacionTipoPago_Load);
            this.Controls.SetChildIndex(this.dtgManOpeModPago, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgManOpeModPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsListaModPagoOperacionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgManOpeModPago;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.BindingSource clsListaModPagoOperacionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        protected GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesTipoPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lOpeDeposito;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lOpeRetiroDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lOpeAperturaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lOpeCancelacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lOpePagoComPagoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lPagoCreditoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPagoDataGridViewTextBoxColumn;
    }
}