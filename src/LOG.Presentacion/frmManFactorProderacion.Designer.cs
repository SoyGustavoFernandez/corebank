namespace LOG.Presentacion
{
    partial class frmManFactorProderacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManFactorProderacion));
            this.cboTipoPedidoLog1 = new GEN.ControlesBase.cboTipoPedidoLog(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgFactPond = new GEN.ControlesBase.dtgBase(this.components);
            this.idTipoPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoFacPonderacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFactorPonderacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nEvaMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nEvaMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nFacMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nFacMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clsTipoFacPonderacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtEvaMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtEvaMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtFacMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtFacMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtTipoFactor = new GEN.ControlesBase.txtCBLetra(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbDetFacPon = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactPond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoFacPonderacionBindingSource)).BeginInit();
            this.grbDetFacPon.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTipoPedidoLog1
            // 
            this.cboTipoPedidoLog1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedidoLog1.FormattingEnabled = true;
            this.cboTipoPedidoLog1.Location = new System.Drawing.Point(100, 6);
            this.cboTipoPedidoLog1.Name = "cboTipoPedidoLog1";
            this.cboTipoPedidoLog1.Size = new System.Drawing.Size(159, 21);
            this.cboTipoPedidoLog1.TabIndex = 1;
            this.cboTipoPedidoLog1.SelectedIndexChanged += new System.EventHandler(this.cboTipoPedidoLog1_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(96, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo de Pedido:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Tipo Factor:";
            // 
            // dtgFactPond
            // 
            this.dtgFactPond.AllowUserToAddRows = false;
            this.dtgFactPond.AllowUserToDeleteRows = false;
            this.dtgFactPond.AllowUserToResizeColumns = false;
            this.dtgFactPond.AllowUserToResizeRows = false;
            this.dtgFactPond.AutoGenerateColumns = false;
            this.dtgFactPond.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFactPond.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFactPond.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoPedidoDataGridViewTextBoxColumn,
            this.idTipoFacPonderacion,
            this.cFactorPonderacion,
            this.nEvaMinDataGridViewTextBoxColumn,
            this.nEvaMaxDataGridViewTextBoxColumn,
            this.nFacMinDataGridViewTextBoxColumn,
            this.nFacMaxDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn});
            this.dtgFactPond.DataSource = this.clsTipoFacPonderacionBindingSource;
            this.dtgFactPond.Location = new System.Drawing.Point(6, 33);
            this.dtgFactPond.MultiSelect = false;
            this.dtgFactPond.Name = "dtgFactPond";
            this.dtgFactPond.ReadOnly = true;
            this.dtgFactPond.RowHeadersVisible = false;
            this.dtgFactPond.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFactPond.Size = new System.Drawing.Size(253, 128);
            this.dtgFactPond.TabIndex = 2;
            this.dtgFactPond.SelectionChanged += new System.EventHandler(this.dtgFactPond_SelectionChanged);
            // 
            // idTipoPedidoDataGridViewTextBoxColumn
            // 
            this.idTipoPedidoDataGridViewTextBoxColumn.DataPropertyName = "idTipoPedido";
            this.idTipoPedidoDataGridViewTextBoxColumn.HeaderText = "idTipoPedido";
            this.idTipoPedidoDataGridViewTextBoxColumn.Name = "idTipoPedidoDataGridViewTextBoxColumn";
            this.idTipoPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoPedidoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTipoFacPonderacion
            // 
            this.idTipoFacPonderacion.DataPropertyName = "idTipoFacPonderacion";
            this.idTipoFacPonderacion.HeaderText = "idTipoFacPonderacion";
            this.idTipoFacPonderacion.Name = "idTipoFacPonderacion";
            this.idTipoFacPonderacion.ReadOnly = true;
            this.idTipoFacPonderacion.Visible = false;
            // 
            // cFactorPonderacion
            // 
            this.cFactorPonderacion.DataPropertyName = "cFactorPonderacion";
            this.cFactorPonderacion.HeaderText = "Factor de Ponderacion";
            this.cFactorPonderacion.Name = "cFactorPonderacion";
            this.cFactorPonderacion.ReadOnly = true;
            // 
            // nEvaMinDataGridViewTextBoxColumn
            // 
            this.nEvaMinDataGridViewTextBoxColumn.DataPropertyName = "nEvaMin";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.nEvaMinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.nEvaMinDataGridViewTextBoxColumn.HeaderText = "nEvaMin";
            this.nEvaMinDataGridViewTextBoxColumn.Name = "nEvaMinDataGridViewTextBoxColumn";
            this.nEvaMinDataGridViewTextBoxColumn.ReadOnly = true;
            this.nEvaMinDataGridViewTextBoxColumn.Visible = false;
            // 
            // nEvaMaxDataGridViewTextBoxColumn
            // 
            this.nEvaMaxDataGridViewTextBoxColumn.DataPropertyName = "nEvaMax";
            dataGridViewCellStyle6.Format = "N2";
            this.nEvaMaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.nEvaMaxDataGridViewTextBoxColumn.HeaderText = "nEvaMax";
            this.nEvaMaxDataGridViewTextBoxColumn.Name = "nEvaMaxDataGridViewTextBoxColumn";
            this.nEvaMaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.nEvaMaxDataGridViewTextBoxColumn.Visible = false;
            // 
            // nFacMinDataGridViewTextBoxColumn
            // 
            this.nFacMinDataGridViewTextBoxColumn.DataPropertyName = "nFacMin";
            dataGridViewCellStyle7.Format = "N2";
            this.nFacMinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.nFacMinDataGridViewTextBoxColumn.HeaderText = "nFacMin";
            this.nFacMinDataGridViewTextBoxColumn.Name = "nFacMinDataGridViewTextBoxColumn";
            this.nFacMinDataGridViewTextBoxColumn.ReadOnly = true;
            this.nFacMinDataGridViewTextBoxColumn.Visible = false;
            // 
            // nFacMaxDataGridViewTextBoxColumn
            // 
            this.nFacMaxDataGridViewTextBoxColumn.DataPropertyName = "nFacMax";
            dataGridViewCellStyle8.Format = "N2";
            this.nFacMaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.nFacMaxDataGridViewTextBoxColumn.HeaderText = "nFacMax";
            this.nFacMaxDataGridViewTextBoxColumn.Name = "nFacMaxDataGridViewTextBoxColumn";
            this.nFacMaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.nFacMaxDataGridViewTextBoxColumn.Visible = false;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // clsTipoFacPonderacionBindingSource
            // 
            this.clsTipoFacPonderacionBindingSource.DataSource = typeof(EntityLayer.clsTipoFacPonderacion);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 39);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Evaluación Min:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 62);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(100, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Evaluación Max:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 86);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(98, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Factibilidad Min:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 110);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(102, 13);
            this.lblBase6.TabIndex = 11;
            this.lblBase6.Text = "Factibilidad Max:";
            // 
            // txtEvaMin
            // 
            this.txtEvaMin.Enabled = false;
            this.txtEvaMin.FormatoDecimal = true;
            this.txtEvaMin.Location = new System.Drawing.Point(109, 36);
            this.txtEvaMin.MaxLength = 9;
            this.txtEvaMin.Name = "txtEvaMin";
            this.txtEvaMin.nDecValor = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtEvaMin.nNumDecimales = 2;
            this.txtEvaMin.nvalor = 100D;
            this.txtEvaMin.Size = new System.Drawing.Size(141, 20);
            this.txtEvaMin.TabIndex = 1;
            this.txtEvaMin.Text = "100";
            // 
            // txtEvaMax
            // 
            this.txtEvaMax.Enabled = false;
            this.txtEvaMax.FormatoDecimal = true;
            this.txtEvaMax.Location = new System.Drawing.Point(109, 59);
            this.txtEvaMax.MaxLength = 9;
            this.txtEvaMax.Name = "txtEvaMax";
            this.txtEvaMax.nDecValor = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtEvaMax.nNumDecimales = 2;
            this.txtEvaMax.nvalor = 100D;
            this.txtEvaMax.Size = new System.Drawing.Size(141, 20);
            this.txtEvaMax.TabIndex = 2;
            this.txtEvaMax.Text = "100";
            // 
            // txtFacMin
            // 
            this.txtFacMin.FormatoDecimal = true;
            this.txtFacMin.Location = new System.Drawing.Point(109, 83);
            this.txtFacMin.MaxLength = 9;
            this.txtFacMin.Name = "txtFacMin";
            this.txtFacMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFacMin.nNumDecimales = 2;
            this.txtFacMin.nvalor = 0D;
            this.txtFacMin.Size = new System.Drawing.Size(141, 20);
            this.txtFacMin.TabIndex = 3;
            // 
            // txtFacMax
            // 
            this.txtFacMax.FormatoDecimal = true;
            this.txtFacMax.Location = new System.Drawing.Point(109, 107);
            this.txtFacMax.MaxLength = 9;
            this.txtFacMax.Name = "txtFacMax";
            this.txtFacMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFacMax.nNumDecimales = 2;
            this.txtFacMax.nvalor = 0D;
            this.txtFacMax.Size = new System.Drawing.Size(141, 20);
            this.txtFacMax.TabIndex = 4;
            // 
            // txtTipoFactor
            // 
            this.txtTipoFactor.Enabled = false;
            this.txtTipoFactor.Location = new System.Drawing.Point(109, 13);
            this.txtTipoFactor.Name = "txtTipoFactor";
            this.txtTipoFactor.Size = new System.Drawing.Size(141, 20);
            this.txtTipoFactor.TabIndex = 0;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(387, 167);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(267, 167);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 5;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(327, 167);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(452, 167);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbDetFacPon
            // 
            this.grbDetFacPon.Controls.Add(this.lblBase2);
            this.grbDetFacPon.Controls.Add(this.lblBase3);
            this.grbDetFacPon.Controls.Add(this.lblBase4);
            this.grbDetFacPon.Controls.Add(this.lblBase5);
            this.grbDetFacPon.Controls.Add(this.lblBase6);
            this.grbDetFacPon.Controls.Add(this.txtEvaMin);
            this.grbDetFacPon.Controls.Add(this.txtEvaMax);
            this.grbDetFacPon.Controls.Add(this.txtFacMin);
            this.grbDetFacPon.Controls.Add(this.txtTipoFactor);
            this.grbDetFacPon.Controls.Add(this.txtFacMax);
            this.grbDetFacPon.Location = new System.Drawing.Point(262, 26);
            this.grbDetFacPon.Name = "grbDetFacPon";
            this.grbDetFacPon.Size = new System.Drawing.Size(261, 135);
            this.grbDetFacPon.TabIndex = 3;
            this.grbDetFacPon.TabStop = false;
            // 
            // frmManFactorProderacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 246);
            this.Controls.Add(this.grbDetFacPon);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgFactPond);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoPedidoLog1);
            this.Name = "frmManFactorProderacion";
            this.Text = "Manteminiento de Factor de Ponderación";
            this.Load += new System.EventHandler(this.frmManFactorProderacion_Load);
            this.Controls.SetChildIndex(this.cboTipoPedidoLog1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgFactPond, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbDetFacPon, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactPond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoFacPonderacionBindingSource)).EndInit();
            this.grbDetFacPon.ResumeLayout(false);
            this.grbDetFacPon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboTipoPedidoLog cboTipoPedidoLog1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgFactPond;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtNumRea txtEvaMin;
        private GEN.ControlesBase.txtNumRea txtEvaMax;
        private GEN.ControlesBase.txtNumRea txtFacMin;
        private GEN.ControlesBase.txtNumRea txtFacMax;
        private GEN.ControlesBase.txtCBLetra txtTipoFactor;
        private System.Windows.Forms.BindingSource clsTipoFacPonderacionBindingSource;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacTecnicosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFacTecnicosDataGridViewTextBoxColumn;
        private GEN.ControlesBase.grbBase grbDetFacPon;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoFacPonderacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFactorPonderacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nEvaMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nEvaMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nFacMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nFacMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
    }
}