namespace LOG.Presentacion
{
    partial class frmManRangoProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManRangoProceso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtValMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtValMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoPedidoLog = new GEN.ControlesBase.cboTipoPedidoLog(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoProcesoLog = new GEN.ControlesBase.cboTipoProcesoLog(this.components);
            this.dtgRangoPedido = new GEN.ControlesBase.dtgBase(this.components);
            this.clsRangoPedidoProcesoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbDetTipoPed = new GEN.ControlesBase.grbBase(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.cboTipoEvalAdjudicacion = new GEN.ControlesBase.cboTipoEvalAdjudicacion(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.idTipoPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRelPedidoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoPedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValorMaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRangoPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsRangoPedidoProcesoBindingSource)).BeginInit();
            this.grbDetTipoPed.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValMax
            // 
            this.txtValMax.FormatoDecimal = true;
            this.txtValMax.Location = new System.Drawing.Point(126, 101);
            this.txtValMax.MaxLength = 10;
            this.txtValMax.Name = "txtValMax";
            this.txtValMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValMax.nNumDecimales = 2;
            this.txtValMax.nvalor = 0D;
            this.txtValMax.Size = new System.Drawing.Size(199, 20);
            this.txtValMax.TabIndex = 3;
            // 
            // txtValMin
            // 
            this.txtValMin.FormatoDecimal = true;
            this.txtValMin.Location = new System.Drawing.Point(126, 73);
            this.txtValMin.MaxLength = 10;
            this.txtValMin.Name = "txtValMin";
            this.txtValMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValMin.nNumDecimales = 2;
            this.txtValMin.nvalor = 0D;
            this.txtValMin.Size = new System.Drawing.Size(199, 20);
            this.txtValMin.TabIndex = 2;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 105);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(89, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Valor Máximo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 76);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(85, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Valor Mínimo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Tipo de Pedido:";
            // 
            // cboTipoPedidoLog
            // 
            this.cboTipoPedidoLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedidoLog.FormattingEnabled = true;
            this.cboTipoPedidoLog.Location = new System.Drawing.Point(126, 17);
            this.cboTipoPedidoLog.Name = "cboTipoPedidoLog";
            this.cboTipoPedidoLog.Size = new System.Drawing.Size(199, 21);
            this.cboTipoPedidoLog.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 11);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(103, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Tipo de Proceso:";
            // 
            // cboTipoProcesoLog
            // 
            this.cboTipoProcesoLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProcesoLog.FormattingEnabled = true;
            this.cboTipoProcesoLog.Location = new System.Drawing.Point(116, 7);
            this.cboTipoProcesoLog.Name = "cboTipoProcesoLog";
            this.cboTipoProcesoLog.Size = new System.Drawing.Size(213, 21);
            this.cboTipoProcesoLog.TabIndex = 1;
            this.cboTipoProcesoLog.SelectedIndexChanged += new System.EventHandler(this.cboTipoProcesoLog1_SelectedIndexChanged);
            // 
            // dtgRangoPedido
            // 
            this.dtgRangoPedido.AllowUserToAddRows = false;
            this.dtgRangoPedido.AllowUserToDeleteRows = false;
            this.dtgRangoPedido.AllowUserToResizeColumns = false;
            this.dtgRangoPedido.AllowUserToResizeRows = false;
            this.dtgRangoPedido.AutoGenerateColumns = false;
            this.dtgRangoPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRangoPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRangoPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoPedidoDataGridViewTextBoxColumn,
            this.idRelPedidoProceso,
            this.cTipoPedio,
            this.idTipoProcesoDataGridViewTextBoxColumn,
            this.nValorMinDataGridViewTextBoxColumn,
            this.nValorMaxDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn});
            this.dtgRangoPedido.DataSource = this.clsRangoPedidoProcesoBindingSource;
            this.dtgRangoPedido.Location = new System.Drawing.Point(10, 36);
            this.dtgRangoPedido.MultiSelect = false;
            this.dtgRangoPedido.Name = "dtgRangoPedido";
            this.dtgRangoPedido.ReadOnly = true;
            this.dtgRangoPedido.RowHeadersVisible = false;
            this.dtgRangoPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRangoPedido.Size = new System.Drawing.Size(319, 133);
            this.dtgRangoPedido.TabIndex = 2;
            this.dtgRangoPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRangoPedido_CellContentClick);
            this.dtgRangoPedido.SelectionChanged += new System.EventHandler(this.dtgRangoPedido_SelectionChanged);
            // 
            // clsRangoPedidoProcesoBindingSource
            // 
            this.clsRangoPedidoProcesoBindingSource.DataSource = typeof(EntityLayer.clsRangoPedidoProceso);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(513, 175);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(393, 175);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(333, 175);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(453, 175);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(599, 175);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 8;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbDetTipoPed
            // 
            this.grbDetTipoPed.Controls.Add(this.chcVigente);
            this.grbDetTipoPed.Controls.Add(this.cboTipoEvalAdjudicacion);
            this.grbDetTipoPed.Controls.Add(this.lblBase2);
            this.grbDetTipoPed.Controls.Add(this.lblBase3);
            this.grbDetTipoPed.Controls.Add(this.lblBase4);
            this.grbDetTipoPed.Controls.Add(this.lblBase5);
            this.grbDetTipoPed.Controls.Add(this.txtValMin);
            this.grbDetTipoPed.Controls.Add(this.txtValMax);
            this.grbDetTipoPed.Controls.Add(this.cboTipoPedidoLog);
            this.grbDetTipoPed.Location = new System.Drawing.Point(334, 2);
            this.grbDetTipoPed.Name = "grbDetTipoPed";
            this.grbDetTipoPed.Size = new System.Drawing.Size(330, 167);
            this.grbDetTipoPed.TabIndex = 3;
            this.grbDetTipoPed.TabStop = false;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Enabled = false;
            this.chcVigente.ForeColor = System.Drawing.Color.Navy;
            this.chcVigente.Location = new System.Drawing.Point(9, 135);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(79, 17);
            this.chcVigente.TabIndex = 8;
            this.chcVigente.Text = "No Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // cboTipoEvalAdjudicacion
            // 
            this.cboTipoEvalAdjudicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEvalAdjudicacion.FormattingEnabled = true;
            this.cboTipoEvalAdjudicacion.Location = new System.Drawing.Point(126, 45);
            this.cboTipoEvalAdjudicacion.Name = "cboTipoEvalAdjudicacion";
            this.cboTipoEvalAdjudicacion.Size = new System.Drawing.Size(199, 21);
            this.cboTipoEvalAdjudicacion.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 48);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(119, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Tipo de Evaluación:";
            // 
            // idTipoPedidoDataGridViewTextBoxColumn
            // 
            this.idTipoPedidoDataGridViewTextBoxColumn.DataPropertyName = "idTipoPedido";
            this.idTipoPedidoDataGridViewTextBoxColumn.HeaderText = "idTipoPedido";
            this.idTipoPedidoDataGridViewTextBoxColumn.Name = "idTipoPedidoDataGridViewTextBoxColumn";
            this.idTipoPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoPedidoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idRelPedidoProceso
            // 
            this.idRelPedidoProceso.DataPropertyName = "idRelPedidoProceso";
            this.idRelPedidoProceso.FillWeight = 32.48731F;
            this.idRelPedidoProceso.HeaderText = "ID.";
            this.idRelPedidoProceso.Name = "idRelPedidoProceso";
            this.idRelPedidoProceso.ReadOnly = true;
            // 
            // cTipoPedio
            // 
            this.cTipoPedio.DataPropertyName = "cTipoPedio";
            this.cTipoPedio.FillWeight = 104.5501F;
            this.cTipoPedio.HeaderText = "Tipo de Pedido";
            this.cTipoPedio.Name = "cTipoPedio";
            this.cTipoPedio.ReadOnly = true;
            // 
            // idTipoProcesoDataGridViewTextBoxColumn
            // 
            this.idTipoProcesoDataGridViewTextBoxColumn.DataPropertyName = "idTipoProceso";
            this.idTipoProcesoDataGridViewTextBoxColumn.HeaderText = "idTipoProceso";
            this.idTipoProcesoDataGridViewTextBoxColumn.Name = "idTipoProcesoDataGridViewTextBoxColumn";
            this.idTipoProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nValorMinDataGridViewTextBoxColumn
            // 
            this.nValorMinDataGridViewTextBoxColumn.DataPropertyName = "nValorMin";
            dataGridViewCellStyle1.Format = "N2";
            this.nValorMinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nValorMinDataGridViewTextBoxColumn.FillWeight = 91.48131F;
            this.nValorMinDataGridViewTextBoxColumn.HeaderText = "Valor Min.";
            this.nValorMinDataGridViewTextBoxColumn.Name = "nValorMinDataGridViewTextBoxColumn";
            this.nValorMinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nValorMaxDataGridViewTextBoxColumn
            // 
            this.nValorMaxDataGridViewTextBoxColumn.DataPropertyName = "nValorMax";
            dataGridViewCellStyle2.Format = "N2";
            this.nValorMaxDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nValorMaxDataGridViewTextBoxColumn.FillWeight = 91.48131F;
            this.nValorMaxDataGridViewTextBoxColumn.HeaderText = "Valor Max.";
            this.nValorMaxDataGridViewTextBoxColumn.Name = "nValorMaxDataGridViewTextBoxColumn";
            this.nValorMaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // frmManRangoProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 252);
            this.Controls.Add(this.grbDetTipoPed);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgRangoPedido);
            this.Controls.Add(this.cboTipoProcesoLog);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmManRangoProceso";
            this.Text = "Mantenimiento Rango de Procesos";
            this.Load += new System.EventHandler(this.frmMantenimientoRangoProceso_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboTipoProcesoLog, 0);
            this.Controls.SetChildIndex(this.dtgRangoPedido, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbDetTipoPed, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRangoPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsRangoPedidoProcesoBindingSource)).EndInit();
            this.grbDetTipoPed.ResumeLayout(false);
            this.grbDetTipoPed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtValMax;
        private GEN.ControlesBase.txtNumRea txtValMin;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoPedidoLog cboTipoPedidoLog;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoProcesoLog cboTipoProcesoLog;
        private GEN.ControlesBase.dtgBase dtgRangoPedido;
        private System.Windows.Forms.BindingSource clsRangoPedidoProcesoBindingSource;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbDetTipoPed;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoEvalAdjudicacion cboTipoEvalAdjudicacion;
        private GEN.ControlesBase.chcBase chcVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRelPedidoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoPedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorMaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
    }
}