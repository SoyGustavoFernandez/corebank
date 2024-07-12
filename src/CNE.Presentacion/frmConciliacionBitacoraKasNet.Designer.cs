namespace CNE.Presentacion
{
    partial class frmConciliacionBitacoraKasNet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConciliacionBitacoraKasNet));
            this.dtgBitacoraConciKasNet = new GEN.ControlesBase.dtgBase(this.components);
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaConci = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboEstadoConci = new GEN.ControlesBase.cboBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.dtFechaConci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWinUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacoraConciKasNet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBitacoraConciKasNet
            // 
            this.dtgBitacoraConciKasNet.AllowUserToAddRows = false;
            this.dtgBitacoraConciKasNet.AllowUserToDeleteRows = false;
            this.dtgBitacoraConciKasNet.AllowUserToResizeColumns = false;
            this.dtgBitacoraConciKasNet.AllowUserToResizeRows = false;
            this.dtgBitacoraConciKasNet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgBitacoraConciKasNet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBitacoraConciKasNet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtFechaConci,
            this.dFechaReg,
            this.cEstado,
            this.cDescripcion,
            this.cWinUser,
            this.lVigente});
            this.dtgBitacoraConciKasNet.Location = new System.Drawing.Point(16, 121);
            this.dtgBitacoraConciKasNet.MultiSelect = false;
            this.dtgBitacoraConciKasNet.Name = "dtgBitacoraConciKasNet";
            this.dtgBitacoraConciKasNet.ReadOnly = true;
            this.dtgBitacoraConciKasNet.RowHeadersVisible = false;
            this.dtgBitacoraConciKasNet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBitacoraConciKasNet.Size = new System.Drawing.Size(560, 163);
            this.dtgBitacoraConciKasNet.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(104, 65);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(243, 50);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 67);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Descripción:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(353, 65);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 15);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(85, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Fecha Conci.:";
            // 
            // dtpFechaConci
            // 
            this.dtpFechaConci.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaConci.Location = new System.Drawing.Point(104, 12);
            this.dtpFechaConci.Name = "dtpFechaConci";
            this.dtpFechaConci.Size = new System.Drawing.Size(101, 20);
            this.dtpFechaConci.TabIndex = 9;
            this.dtpFechaConci.ValueChanged += new System.EventHandler(this.dtpFechaConci_ValueChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(516, 290);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(13, 41);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Estado:";
            // 
            // cboEstadoConci
            // 
            this.cboEstadoConci.FormattingEnabled = true;
            this.cboEstadoConci.Location = new System.Drawing.Point(104, 38);
            this.cboEstadoConci.Name = "cboEstadoConci";
            this.cboEstadoConci.Size = new System.Drawing.Size(121, 21);
            this.cboEstadoConci.TabIndex = 12;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(419, 65);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtFechaConci
            // 
            this.dtFechaConci.DataPropertyName = "dtFechaConci";
            this.dtFechaConci.HeaderText = "FechaConci";
            this.dtFechaConci.Name = "dtFechaConci";
            this.dtFechaConci.ReadOnly = true;
            this.dtFechaConci.Visible = false;
            // 
            // dFechaReg
            // 
            this.dFechaReg.DataPropertyName = "dFechaReg";
            this.dFechaReg.HeaderText = "FechaReg";
            this.dFechaReg.Name = "dFechaReg";
            this.dFechaReg.ReadOnly = true;
            // 
            // cEstado
            // 
            this.cEstado.DataPropertyName = "cEstado";
            this.cEstado.HeaderText = "Estado";
            this.cEstado.Name = "cEstado";
            this.cEstado.ReadOnly = true;
            // 
            // cDescripcion
            // 
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // cWinUser
            // 
            this.cWinUser.DataPropertyName = "cWinUser";
            this.cWinUser.HeaderText = "Usuario";
            this.cWinUser.Name = "cWinUser";
            this.cWinUser.ReadOnly = true;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "Vigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmConciliacionBitacoraKasNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 372);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboEstadoConci);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFechaConci);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dtgBitacoraConciKasNet);
            this.Name = "frmConciliacionBitacoraKasNet";
            this.Text = "Bitacora de Conciliación KasNet";
            this.Controls.SetChildIndex(this.dtgBitacoraConciKasNet, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFechaConci, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboEstadoConci, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBitacoraConciKasNet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgBitacoraConciKasNet;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaConci;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboEstadoConci;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFechaConci;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWinUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigente;
    }
}