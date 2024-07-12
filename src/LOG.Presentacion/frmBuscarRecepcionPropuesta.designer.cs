namespace LOG.Presentacion
{
    partial class frmBuscarRecepcionPropuesta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarRecepcionPropuesta));
            this.rbtFecha = new GEN.ControlesBase.rbtBase(this.components);
            this.clsNotaPedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroProcesoAdj = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboEstadoProcLog = new GEN.ControlesBase.cboEstadoProcLog(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.rbtProcesoAdj = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBuscar = new GEN.ControlesBase.grbBase(this.components);
            this.rbtEstado = new GEN.ControlesBase.rbtBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.dtgProcesoAdj = new GEN.ControlesBase.dtgBase(this.components);
            this.idProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoProceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clsNotaPedidoBindingSource)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcesoAdj)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.ForeColor = System.Drawing.Color.Navy;
            this.rbtFecha.Location = new System.Drawing.Point(6, 63);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(74, 17);
            this.rbtFecha.TabIndex = 15;
            this.rbtFecha.Text = "Por Fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtFecha_CheckedChanged);
            // 
            // clsNotaPedidoBindingSource
            // 
            this.clsNotaPedidoBindingSource.DataSource = typeof(EntityLayer.clsNotaPedido);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNroProcesoAdj);
            this.grbBase1.Controls.Add(this.cboEstadoProcLog);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dFechaIni);
            this.grbBase1.Controls.Add(this.dFechaFin);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(125, 1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(317, 85);
            this.grbBase1.TabIndex = 19;
            this.grbBase1.TabStop = false;
            // 
            // txtNroProcesoAdj
            // 
            this.txtNroProcesoAdj.Location = new System.Drawing.Point(68, 14);
            this.txtNroProcesoAdj.Name = "txtNroProcesoAdj";
            this.txtNroProcesoAdj.Size = new System.Drawing.Size(241, 20);
            this.txtNroProcesoAdj.TabIndex = 1;
            // 
            // cboEstadoProcLog
            // 
            this.cboEstadoProcLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoProcLog.FormattingEnabled = true;
            this.cboEstadoProcLog.Location = new System.Drawing.Point(68, 37);
            this.cboEstadoProcLog.Name = "cboEstadoProcLog";
            this.cboEstadoProcLog.Size = new System.Drawing.Size(241, 21);
            this.cboEstadoProcLog.TabIndex = 12;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(179, 67);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(23, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Al:";
            // 
            // dFechaIni
            // 
            this.dFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaIni.Location = new System.Drawing.Point(68, 60);
            this.dFechaIni.Name = "dFechaIni";
            this.dFechaIni.Size = new System.Drawing.Size(105, 20);
            this.dFechaIni.TabIndex = 3;
            // 
            // dFechaFin
            // 
            this.dFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaFin.Location = new System.Drawing.Point(208, 61);
            this.dFechaFin.Name = "dFechaFin";
            this.dFechaFin.Size = new System.Drawing.Size(101, 20);
            this.dFechaFin.TabIndex = 5;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(5, 41);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Estado";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(48, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Desde:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(5, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(64, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "N Proceso";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(445, 36);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 15;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(445, 210);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // rbtProcesoAdj
            // 
            this.rbtProcesoAdj.AutoSize = true;
            this.rbtProcesoAdj.Checked = true;
            this.rbtProcesoAdj.ForeColor = System.Drawing.Color.Navy;
            this.rbtProcesoAdj.Location = new System.Drawing.Point(6, 17);
            this.rbtProcesoAdj.Name = "rbtProcesoAdj";
            this.rbtProcesoAdj.Size = new System.Drawing.Size(101, 17);
            this.rbtProcesoAdj.TabIndex = 13;
            this.rbtProcesoAdj.TabStop = true;
            this.rbtProcesoAdj.Text = "Por Proceso Adj";
            this.rbtProcesoAdj.UseVisualStyleBackColor = true;
            this.rbtProcesoAdj.CheckedChanged += new System.EventHandler(this.rbtProcesoAdj_CheckedChanged);
            // 
            // grbBuscar
            // 
            this.grbBuscar.Controls.Add(this.rbtFecha);
            this.grbBuscar.Controls.Add(this.rbtEstado);
            this.grbBuscar.Controls.Add(this.rbtProcesoAdj);
            this.grbBuscar.Location = new System.Drawing.Point(12, 1);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(112, 85);
            this.grbBuscar.TabIndex = 20;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "Buscar:";
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
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(379, 210);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtgProcesoAdj
            // 
            this.dtgProcesoAdj.AllowUserToAddRows = false;
            this.dtgProcesoAdj.AllowUserToDeleteRows = false;
            this.dtgProcesoAdj.AllowUserToResizeColumns = false;
            this.dtgProcesoAdj.AllowUserToResizeRows = false;
            this.dtgProcesoAdj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcesoAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcesoAdj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProceso,
            this.dFechaReg,
            this.idTipoProceso,
            this.cTipoProceso,
            this.idEstadoLog,
            this.cNombre});
            this.dtgProcesoAdj.Location = new System.Drawing.Point(12, 92);
            this.dtgProcesoAdj.MultiSelect = false;
            this.dtgProcesoAdj.Name = "dtgProcesoAdj";
            this.dtgProcesoAdj.ReadOnly = true;
            this.dtgProcesoAdj.RowHeadersVisible = false;
            this.dtgProcesoAdj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcesoAdj.Size = new System.Drawing.Size(492, 112);
            this.dtgProcesoAdj.TabIndex = 21;
            // 
            // idProceso
            // 
            this.idProceso.DataPropertyName = "idProceso";
            this.idProceso.HeaderText = "Nro Proceso Adj";
            this.idProceso.Name = "idProceso";
            this.idProceso.ReadOnly = true;
            // 
            // dFechaReg
            // 
            this.dFechaReg.DataPropertyName = "dFechaReg";
            this.dFechaReg.HeaderText = "Fecha Reg";
            this.dFechaReg.Name = "dFechaReg";
            this.dFechaReg.ReadOnly = true;
            // 
            // idTipoProceso
            // 
            this.idTipoProceso.DataPropertyName = "idTipoProceso";
            this.idTipoProceso.HeaderText = "idTipoProceso";
            this.idTipoProceso.Name = "idTipoProceso";
            this.idTipoProceso.ReadOnly = true;
            this.idTipoProceso.Visible = false;
            // 
            // cTipoProceso
            // 
            this.cTipoProceso.DataPropertyName = "cTipoProceso";
            this.cTipoProceso.HeaderText = "Tipo Proceso";
            this.cTipoProceso.Name = "cTipoProceso";
            this.cTipoProceso.ReadOnly = true;
            // 
            // idEstadoLog
            // 
            this.idEstadoLog.DataPropertyName = "idEstadoLog";
            this.idEstadoLog.HeaderText = "idEstadoLog";
            this.idEstadoLog.Name = "idEstadoLog";
            this.idEstadoLog.ReadOnly = true;
            this.idEstadoLog.Visible = false;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Estado";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // frmBuscarRecepcionPropuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 285);
            this.Controls.Add(this.dtgProcesoAdj);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmBuscarRecepcionPropuesta";
            this.Text = "Buscar Proceso Adjudicación";
            this.Load += new System.EventHandler(this.frmBuscarRecepcionPropuesta_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBuscar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgProcesoAdj, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clsNotaPedidoBindingSource)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcesoAdj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.rbtBase rbtFecha;
        private System.Windows.Forms.BindingSource clsNotaPedidoBindingSource;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroProcesoAdj;
        private GEN.ControlesBase.cboEstadoProcLog cboEstadoProcLog;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dFechaIni;
        private GEN.ControlesBase.dtpCorto dFechaFin;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.rbtBase rbtProcesoAdj;
        private GEN.ControlesBase.grbBase grbBuscar;
        private GEN.ControlesBase.rbtBase rbtEstado;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.dtgBase dtgProcesoAdj;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoProceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;

    }
}