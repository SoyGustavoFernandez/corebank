namespace CNE.Presentacion
{
    partial class frmReporteBitacora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteBitacora));
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboCanal = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnExporExcel = new GEN.BotonesBase.btnExporExcel();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.dtgConciliacionPagosObservacion = new GEN.ControlesBase.dtgBase(this.components);
            this.dFechaConci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoBitacora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConciliacionPagosObservacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(111, 41);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaFin.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(20, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(111, 16);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaInicio.TabIndex = 13;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // cboCanal
            // 
            this.cboCanal.FormattingEnabled = true;
            this.cboCanal.Location = new System.Drawing.Point(300, 15);
            this.cboCanal.Name = "cboCanal";
            this.cboCanal.Size = new System.Drawing.Size(138, 21);
            this.cboCanal.TabIndex = 15;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(249, 18);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(45, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Canal:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(558, 297);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnExporExcel
            // 
            this.btnExporExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel.BackgroundImage")));
            this.btnExporExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel.Location = new System.Drawing.Point(558, 19);
            this.btnExporExcel.Name = "btnExporExcel";
            this.btnExporExcel.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel.TabIndex = 22;
            this.btnExporExcel.Text = "E&xcel";
            this.btnExporExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel.UseVisualStyleBackColor = true;
            this.btnExporExcel.Click += new System.EventHandler(this.btnExporExcel_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(492, 19);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 23;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // dtgConciliacionPagosObservacion
            // 
            this.dtgConciliacionPagosObservacion.AllowUserToAddRows = false;
            this.dtgConciliacionPagosObservacion.AllowUserToDeleteRows = false;
            this.dtgConciliacionPagosObservacion.AllowUserToResizeColumns = false;
            this.dtgConciliacionPagosObservacion.AllowUserToResizeRows = false;
            this.dtgConciliacionPagosObservacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConciliacionPagosObservacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConciliacionPagosObservacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dFechaConci,
            this.cEstadoBitacora,
            this.cDescripcion,
            this.cUsuarioReg,
            this.dFechaReg});
            this.dtgConciliacionPagosObservacion.Location = new System.Drawing.Point(15, 75);
            this.dtgConciliacionPagosObservacion.MultiSelect = false;
            this.dtgConciliacionPagosObservacion.Name = "dtgConciliacionPagosObservacion";
            this.dtgConciliacionPagosObservacion.ReadOnly = true;
            this.dtgConciliacionPagosObservacion.RowHeadersVisible = false;
            this.dtgConciliacionPagosObservacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConciliacionPagosObservacion.Size = new System.Drawing.Size(603, 216);
            this.dtgConciliacionPagosObservacion.TabIndex = 24;
            // 
            // dFechaConci
            // 
            this.dFechaConci.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaConci.DataPropertyName = "dFechaConci";
            this.dFechaConci.HeaderText = "Fecha Conci";
            this.dFechaConci.Name = "dFechaConci";
            this.dFechaConci.ReadOnly = true;
            this.dFechaConci.Width = 92;
            // 
            // cEstadoBitacora
            // 
            this.cEstadoBitacora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cEstadoBitacora.DataPropertyName = "cEstadoBitacora";
            this.cEstadoBitacora.HeaderText = "Estado";
            this.cEstadoBitacora.Name = "cEstadoBitacora";
            this.cEstadoBitacora.ReadOnly = true;
            this.cEstadoBitacora.Width = 65;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.HeaderText = "Descripcion";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // cUsuarioReg
            // 
            this.cUsuarioReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cUsuarioReg.DataPropertyName = "cUsuarioReg";
            this.cUsuarioReg.HeaderText = "Usuario Reg";
            this.cUsuarioReg.Name = "cUsuarioReg";
            this.cUsuarioReg.ReadOnly = true;
            this.cUsuarioReg.Width = 91;
            // 
            // dFechaReg
            // 
            this.dFechaReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dFechaReg.DataPropertyName = "dFechaReg";
            this.dFechaReg.HeaderText = "Fecha Reg";
            this.dFechaReg.Name = "dFechaReg";
            this.dFechaReg.ReadOnly = true;
            this.dFechaReg.Width = 85;
            // 
            // frmReporteBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 378);
            this.Controls.Add(this.dtgConciliacionPagosObservacion);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.btnExporExcel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cboCanal);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblBase2);
            this.Name = "frmReporteBitacora";
            this.Text = "frmReporteBitacora";
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboCanal, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnExporExcel, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.dtgConciliacionPagosObservacion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConciliacionPagosObservacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboBase cboCanal;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnExporExcel btnExporExcel;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtgBase dtgConciliacionPagosObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaConci;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoBitacora;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaReg;
    }
}