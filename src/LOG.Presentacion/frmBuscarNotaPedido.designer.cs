namespace LOG.Presentacion
{
    partial class frmBuscarNotaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarNotaPedido));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtNroNotaPedido = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgNotasPedido = new GEN.ControlesBase.dtgBase(this.components);
            this.idNotaPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaNotaPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgenciaGenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAreGenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idActividadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMotivoNotaPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoLogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMonedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuarioGenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuModDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalConvertidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIGVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonTipoCambioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsNotaPedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEstadoProcLog = new GEN.ControlesBase.cboEstadoProcLog(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.rbtNotaPedido = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBuscar = new GEN.ControlesBase.grbBase(this.components);
            this.rbtFecha = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtEstado = new GEN.ControlesBase.rbtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsNotaPedidoBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(64, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Nro de NP";
            // 
            // txtNroNotaPedido
            // 
            this.txtNroNotaPedido.Location = new System.Drawing.Point(68, 12);
            this.txtNroNotaPedido.Name = "txtNroNotaPedido";
            this.txtNroNotaPedido.Size = new System.Drawing.Size(241, 20);
            this.txtNroNotaPedido.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(5, 61);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Desde:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(180, 62);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(23, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Al:";
            // 
            // dFechaIni
            // 
            this.dFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaIni.Location = new System.Drawing.Point(68, 58);
            this.dFechaIni.Name = "dFechaIni";
            this.dFechaIni.Size = new System.Drawing.Size(105, 20);
            this.dFechaIni.TabIndex = 3;
            // 
            // dFechaFin
            // 
            this.dFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaFin.Location = new System.Drawing.Point(208, 58);
            this.dFechaFin.Name = "dFechaFin";
            this.dFechaFin.Size = new System.Drawing.Size(101, 20);
            this.dFechaFin.TabIndex = 5;
            // 
            // dtgNotasPedido
            // 
            this.dtgNotasPedido.AllowUserToAddRows = false;
            this.dtgNotasPedido.AllowUserToDeleteRows = false;
            this.dtgNotasPedido.AllowUserToResizeColumns = false;
            this.dtgNotasPedido.AllowUserToResizeRows = false;
            this.dtgNotasPedido.AutoGenerateColumns = false;
            this.dtgNotasPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNotasPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotasPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idNotaPedidoDataGridViewTextBoxColumn,
            this.dFechaNotaPedidoDataGridViewTextBoxColumn,
            this.idAgenciaGenDataGridViewTextBoxColumn,
            this.idAreGenDataGridViewTextBoxColumn,
            this.cArea,
            this.idActividadDataGridViewTextBoxColumn,
            this.cMotivoNotaPedidoDataGridViewTextBoxColumn,
            this.idEstadoLogDataGridViewTextBoxColumn,
            this.idMonedaDataGridViewTextBoxColumn,
            this.idTipoPedidoDataGridViewTextBoxColumn,
            this.idUsuarioGenDataGridViewTextBoxColumn,
            this.dFechaModDataGridViewTextBoxColumn,
            this.idUsuModDataGridViewTextBoxColumn,
            this.nTotalCostoDataGridViewTextBoxColumn,
            this.nTotalConvertidoDataGridViewTextBoxColumn,
            this.nIGVDataGridViewTextBoxColumn,
            this.nMonTipoCambioDataGridViewTextBoxColumn});
            this.dtgNotasPedido.DataSource = this.clsNotaPedidoBindingSource;
            this.dtgNotasPedido.Location = new System.Drawing.Point(8, 94);
            this.dtgNotasPedido.MultiSelect = false;
            this.dtgNotasPedido.Name = "dtgNotasPedido";
            this.dtgNotasPedido.ReadOnly = true;
            this.dtgNotasPedido.RowHeadersVisible = false;
            this.dtgNotasPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotasPedido.Size = new System.Drawing.Size(494, 115);
            this.dtgNotasPedido.TabIndex = 7;
            // 
            // idNotaPedidoDataGridViewTextBoxColumn
            // 
            this.idNotaPedidoDataGridViewTextBoxColumn.DataPropertyName = "idNotaPedido";
            this.idNotaPedidoDataGridViewTextBoxColumn.FillWeight = 70F;
            this.idNotaPedidoDataGridViewTextBoxColumn.HeaderText = "Nro de Nota";
            this.idNotaPedidoDataGridViewTextBoxColumn.Name = "idNotaPedidoDataGridViewTextBoxColumn";
            this.idNotaPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dFechaNotaPedidoDataGridViewTextBoxColumn
            // 
            this.dFechaNotaPedidoDataGridViewTextBoxColumn.DataPropertyName = "dFechaNotaPedido";
            this.dFechaNotaPedidoDataGridViewTextBoxColumn.FillWeight = 70F;
            this.dFechaNotaPedidoDataGridViewTextBoxColumn.HeaderText = "Fecha Pedido";
            this.dFechaNotaPedidoDataGridViewTextBoxColumn.Name = "dFechaNotaPedidoDataGridViewTextBoxColumn";
            this.dFechaNotaPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idAgenciaGenDataGridViewTextBoxColumn
            // 
            this.idAgenciaGenDataGridViewTextBoxColumn.DataPropertyName = "idAgenciaGen";
            this.idAgenciaGenDataGridViewTextBoxColumn.HeaderText = "idAgenciaGen";
            this.idAgenciaGenDataGridViewTextBoxColumn.Name = "idAgenciaGenDataGridViewTextBoxColumn";
            this.idAgenciaGenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAgenciaGenDataGridViewTextBoxColumn.Visible = false;
            // 
            // idAreGenDataGridViewTextBoxColumn
            // 
            this.idAreGenDataGridViewTextBoxColumn.DataPropertyName = "idAreGen";
            this.idAreGenDataGridViewTextBoxColumn.HeaderText = "idArea";
            this.idAreGenDataGridViewTextBoxColumn.Name = "idAreGenDataGridViewTextBoxColumn";
            this.idAreGenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAreGenDataGridViewTextBoxColumn.Visible = false;
            // 
            // cArea
            // 
            this.cArea.DataPropertyName = "cArea";
            this.cArea.HeaderText = "Area";
            this.cArea.Name = "cArea";
            this.cArea.ReadOnly = true;
            // 
            // idActividadDataGridViewTextBoxColumn
            // 
            this.idActividadDataGridViewTextBoxColumn.DataPropertyName = "idActividad";
            this.idActividadDataGridViewTextBoxColumn.HeaderText = "idActividad";
            this.idActividadDataGridViewTextBoxColumn.Name = "idActividadDataGridViewTextBoxColumn";
            this.idActividadDataGridViewTextBoxColumn.ReadOnly = true;
            this.idActividadDataGridViewTextBoxColumn.Visible = false;
            // 
            // cMotivoNotaPedidoDataGridViewTextBoxColumn
            // 
            this.cMotivoNotaPedidoDataGridViewTextBoxColumn.DataPropertyName = "cMotivoNotaPedido";
            this.cMotivoNotaPedidoDataGridViewTextBoxColumn.HeaderText = "Motivo";
            this.cMotivoNotaPedidoDataGridViewTextBoxColumn.Name = "cMotivoNotaPedidoDataGridViewTextBoxColumn";
            this.cMotivoNotaPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEstadoLogDataGridViewTextBoxColumn
            // 
            this.idEstadoLogDataGridViewTextBoxColumn.DataPropertyName = "idEstadoLog";
            this.idEstadoLogDataGridViewTextBoxColumn.HeaderText = "idEstadoLog";
            this.idEstadoLogDataGridViewTextBoxColumn.Name = "idEstadoLogDataGridViewTextBoxColumn";
            this.idEstadoLogDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEstadoLogDataGridViewTextBoxColumn.Visible = false;
            // 
            // idMonedaDataGridViewTextBoxColumn
            // 
            this.idMonedaDataGridViewTextBoxColumn.DataPropertyName = "idMoneda";
            this.idMonedaDataGridViewTextBoxColumn.HeaderText = "idMoneda";
            this.idMonedaDataGridViewTextBoxColumn.Name = "idMonedaDataGridViewTextBoxColumn";
            this.idMonedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idMonedaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTipoPedidoDataGridViewTextBoxColumn
            // 
            this.idTipoPedidoDataGridViewTextBoxColumn.DataPropertyName = "idTipoPedido";
            this.idTipoPedidoDataGridViewTextBoxColumn.HeaderText = "idTipoPedido";
            this.idTipoPedidoDataGridViewTextBoxColumn.Name = "idTipoPedidoDataGridViewTextBoxColumn";
            this.idTipoPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoPedidoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idUsuarioGenDataGridViewTextBoxColumn
            // 
            this.idUsuarioGenDataGridViewTextBoxColumn.DataPropertyName = "idUsuarioGen";
            this.idUsuarioGenDataGridViewTextBoxColumn.HeaderText = "idUsuario";
            this.idUsuarioGenDataGridViewTextBoxColumn.Name = "idUsuarioGenDataGridViewTextBoxColumn";
            this.idUsuarioGenDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuarioGenDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaModDataGridViewTextBoxColumn
            // 
            this.dFechaModDataGridViewTextBoxColumn.DataPropertyName = "dFechaMod";
            this.dFechaModDataGridViewTextBoxColumn.HeaderText = "dFechaMod";
            this.dFechaModDataGridViewTextBoxColumn.Name = "dFechaModDataGridViewTextBoxColumn";
            this.dFechaModDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaModDataGridViewTextBoxColumn.Visible = false;
            // 
            // idUsuModDataGridViewTextBoxColumn
            // 
            this.idUsuModDataGridViewTextBoxColumn.DataPropertyName = "idUsuMod";
            this.idUsuModDataGridViewTextBoxColumn.HeaderText = "idUsuMod";
            this.idUsuModDataGridViewTextBoxColumn.Name = "idUsuModDataGridViewTextBoxColumn";
            this.idUsuModDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUsuModDataGridViewTextBoxColumn.Visible = false;
            // 
            // nTotalCostoDataGridViewTextBoxColumn
            // 
            this.nTotalCostoDataGridViewTextBoxColumn.DataPropertyName = "nTotalCosto";
            this.nTotalCostoDataGridViewTextBoxColumn.HeaderText = "nTotalCosto";
            this.nTotalCostoDataGridViewTextBoxColumn.Name = "nTotalCostoDataGridViewTextBoxColumn";
            this.nTotalCostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nTotalCostoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nTotalConvertidoDataGridViewTextBoxColumn
            // 
            this.nTotalConvertidoDataGridViewTextBoxColumn.DataPropertyName = "nTotalConvertido";
            this.nTotalConvertidoDataGridViewTextBoxColumn.HeaderText = "nTotalConvertido";
            this.nTotalConvertidoDataGridViewTextBoxColumn.Name = "nTotalConvertidoDataGridViewTextBoxColumn";
            this.nTotalConvertidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nTotalConvertidoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nIGVDataGridViewTextBoxColumn
            // 
            this.nIGVDataGridViewTextBoxColumn.DataPropertyName = "nIGV";
            this.nIGVDataGridViewTextBoxColumn.HeaderText = "nIGV";
            this.nIGVDataGridViewTextBoxColumn.Name = "nIGVDataGridViewTextBoxColumn";
            this.nIGVDataGridViewTextBoxColumn.ReadOnly = true;
            this.nIGVDataGridViewTextBoxColumn.Visible = false;
            // 
            // nMonTipoCambioDataGridViewTextBoxColumn
            // 
            this.nMonTipoCambioDataGridViewTextBoxColumn.DataPropertyName = "nMonTipoCambio";
            this.nMonTipoCambioDataGridViewTextBoxColumn.HeaderText = "nMonTipoCambio";
            this.nMonTipoCambioDataGridViewTextBoxColumn.Name = "nMonTipoCambioDataGridViewTextBoxColumn";
            this.nMonTipoCambioDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMonTipoCambioDataGridViewTextBoxColumn.Visible = false;
            // 
            // clsNotaPedidoBindingSource
            // 
            this.clsNotaPedidoBindingSource.DataSource = typeof(EntityLayer.clsNotaPedido);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(375, 212);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(441, 212);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(441, 38);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 6;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNroNotaPedido);
            this.grbBase1.Controls.Add(this.cboEstadoProcLog);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dFechaIni);
            this.grbBase1.Controls.Add(this.dFechaFin);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(121, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(317, 85);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            // 
            // cboEstadoProcLog
            // 
            this.cboEstadoProcLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoProcLog.FormattingEnabled = true;
            this.cboEstadoProcLog.Location = new System.Drawing.Point(68, 34);
            this.cboEstadoProcLog.Name = "cboEstadoProcLog";
            this.cboEstadoProcLog.Size = new System.Drawing.Size(241, 21);
            this.cboEstadoProcLog.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(5, 37);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Estado";
            // 
            // rbtNotaPedido
            // 
            this.rbtNotaPedido.AutoSize = true;
            this.rbtNotaPedido.Checked = true;
            this.rbtNotaPedido.ForeColor = System.Drawing.Color.Navy;
            this.rbtNotaPedido.Location = new System.Drawing.Point(6, 17);
            this.rbtNotaPedido.Name = "rbtNotaPedido";
            this.rbtNotaPedido.Size = new System.Drawing.Size(103, 17);
            this.rbtNotaPedido.TabIndex = 13;
            this.rbtNotaPedido.TabStop = true;
            this.rbtNotaPedido.Text = "Por Nota Pedido";
            this.rbtNotaPedido.UseVisualStyleBackColor = true;
            this.rbtNotaPedido.CheckedChanged += new System.EventHandler(this.rbtNotaPedido_CheckedChanged);
            // 
            // grbBuscar
            // 
            this.grbBuscar.Controls.Add(this.rbtFecha);
            this.grbBuscar.Controls.Add(this.rbtEstado);
            this.grbBuscar.Controls.Add(this.rbtNotaPedido);
            this.grbBuscar.Location = new System.Drawing.Point(8, 3);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(112, 85);
            this.grbBuscar.TabIndex = 14;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "Buscar:";
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.ForeColor = System.Drawing.Color.Navy;
            this.rbtFecha.Location = new System.Drawing.Point(8, 63);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(74, 17);
            this.rbtFecha.TabIndex = 15;
            this.rbtFecha.Text = "Por Fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtFecha_CheckedChanged);
            // 
            // rbtEstado
            // 
            this.rbtEstado.AutoSize = true;
            this.rbtEstado.ForeColor = System.Drawing.Color.Navy;
            this.rbtEstado.Location = new System.Drawing.Point(6, 40);
            this.rbtEstado.Name = "rbtEstado";
            this.rbtEstado.Size = new System.Drawing.Size(77, 17);
            this.rbtEstado.TabIndex = 14;
            this.rbtEstado.Text = "Por Estado";
            this.rbtEstado.UseVisualStyleBackColor = true;
            this.rbtEstado.CheckedChanged += new System.EventHandler(this.rbtEstado_CheckedChanged);
            // 
            // frmBuscarNotaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 288);
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtgNotasPedido);
            this.Name = "frmBuscarNotaPedido";
            this.Text = "Buscar Nota de Pedido";
            this.Load += new System.EventHandler(this.frmBuscarNotaPedido_Load);
            this.Controls.SetChildIndex(this.dtgNotasPedido, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsNotaPedidoBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroNotaPedido;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dFechaIni;
        private GEN.ControlesBase.dtpCorto dFechaFin;
        private GEN.ControlesBase.dtgBase dtgNotasPedido;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private System.Windows.Forms.BindingSource clsNotaPedidoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNotaPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaNotaPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgenciaGenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAreGenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActividadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMotivoNotaPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoLogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioGenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuModDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalConvertidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIGVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonTipoCambioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nIncluImpuestoDataGridViewCheckBoxColumn;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboEstadoProcLog cboEstadoProcLog;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.rbtBase rbtNotaPedido;
        private GEN.ControlesBase.grbBase grbBuscar;
        private GEN.ControlesBase.rbtBase rbtFecha;
        private GEN.ControlesBase.rbtBase rbtEstado;
    }
}