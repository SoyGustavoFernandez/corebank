namespace CNE.Presentacion
{
    partial class frmConciliacionPagosObservaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConciliacionPagosObservaciones));
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboEstadoObs = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtpFechaObs = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.dtgConciliacionPagosObservacion = new GEN.ControlesBase.dtgBase(this.components);
            this.dFechaConci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstadoBitacora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuarioReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboCanal = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConciliacionPagosObservacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(558, 74);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboEstadoObs
            // 
            this.cboEstadoObs.FormattingEnabled = true;
            this.cboEstadoObs.Location = new System.Drawing.Point(110, 47);
            this.cboEstadoObs.Name = "cboEstadoObs";
            this.cboEstadoObs.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoObs.TabIndex = 22;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(19, 50);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 21;
            this.lblBase3.Text = "Estado:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(558, 286);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtpFechaObs
            // 
            this.dtpFechaObs.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaObs.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaObs.Location = new System.Drawing.Point(110, 21);
            this.dtpFechaObs.Name = "dtpFechaObs";
            this.dtpFechaObs.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaObs.TabIndex = 19;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(19, 24);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(85, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Fecha Conci.:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(492, 74);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(19, 76);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(110, 74);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(269, 50);
            this.txtDescripcion.TabIndex = 15;
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
            this.dtgConciliacionPagosObservacion.Location = new System.Drawing.Point(15, 135);
            this.dtgConciliacionPagosObservacion.MultiSelect = false;
            this.dtgConciliacionPagosObservacion.Name = "dtgConciliacionPagosObservacion";
            this.dtgConciliacionPagosObservacion.ReadOnly = true;
            this.dtgConciliacionPagosObservacion.RowHeadersVisible = false;
            this.dtgConciliacionPagosObservacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConciliacionPagosObservacion.Size = new System.Drawing.Size(603, 141);
            this.dtgConciliacionPagosObservacion.TabIndex = 14;
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
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(402, 24);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 24;
            this.lblBase4.Text = "Canal:";
            // 
            // cboCanal
            // 
            this.cboCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanal.FormattingEnabled = true;
            this.cboCanal.Location = new System.Drawing.Point(454, 20);
            this.cboCanal.Name = "cboCanal";
            this.cboCanal.Size = new System.Drawing.Size(164, 21);
            this.cboCanal.TabIndex = 25;
            // 
            // frmConciliacionPagosObservaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 361);
            this.Controls.Add(this.cboCanal);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboEstadoObs);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFechaObs);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dtgConciliacionPagosObservacion);
            this.Name = "frmConciliacionPagosObservaciones";
            this.Text = "frmConciliacionPagosObservaciones";
            this.Controls.SetChildIndex(this.dtgConciliacionPagosObservacion, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFechaObs, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboEstadoObs, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboCanal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConciliacionPagosObservacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboBase cboEstadoObs;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtpCorto dtpFechaObs;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.dtgBase dtgConciliacionPagosObservacion;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboCanal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaConci;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstadoBitacora;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuarioReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaReg;
    }
}