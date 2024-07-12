namespace CAJ.Presentacion
{
    partial class frmManRespBoveda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManRespBoveda));
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCargo = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgResBov = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipResponsableCaja1 = new GEN.ControlesBase.cboTipResponsableCaja(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblfecfin = new GEN.ControlesBase.lblBase();
            this.grbTiempo = new GEN.ControlesBase.grbBase(this.components);
            this.rbtIndeterminado = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtDeterminado = new GEN.ControlesBase.rbtBase(this.components);
            this.chclVigente = new GEN.ControlesBase.chcBase(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResBov)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbTiempo.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(124, 62);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(357, 21);
            this.cboColaborador.TabIndex = 4;
            this.cboColaborador.SelectedIndexChanged += new System.EventHandler(this.cboColaborador_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(8, 66);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(83, 13);
            this.lblBase4.TabIndex = 103;
            this.lblBase4.Text = "Colaborador:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(5, 16);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(63, 13);
            this.lblBase5.TabIndex = 102;
            this.lblBase5.Text = "Agencias:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(124, 13);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(194, 21);
            this.cboAgencias.TabIndex = 0;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Location = new System.Drawing.Point(6, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(609, 40);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(124, 87);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(357, 20);
            this.txtCargo.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 89);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(47, 13);
            this.lblBase1.TabIndex = 106;
            this.lblBase1.Text = "Cargo:";
            // 
            // dtgResBov
            // 
            this.dtgResBov.AllowUserToAddRows = false;
            this.dtgResBov.AllowUserToDeleteRows = false;
            this.dtgResBov.AllowUserToResizeColumns = false;
            this.dtgResBov.AllowUserToResizeRows = false;
            this.dtgResBov.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgResBov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResBov.Location = new System.Drawing.Point(6, 19);
            this.dtgResBov.MultiSelect = false;
            this.dtgResBov.Name = "dtgResBov";
            this.dtgResBov.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResBov.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgResBov.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgResBov.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgResBov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgResBov.Size = new System.Drawing.Size(597, 117);
            this.dtgResBov.TabIndex = 0;
            this.dtgResBov.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgResBov_RowEnter);
            this.dtgResBov.RowErrorTextChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtgResBov_RowErrorTextChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(112, 13);
            this.lblBase2.TabIndex = 116;
            this.lblBase2.Text = "Tipo Responsable:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboTipResponsableCaja1);
            this.grbBase2.Controls.Add(this.dtpFecFin);
            this.grbBase2.Controls.Add(this.lblfecfin);
            this.grbBase2.Controls.Add(this.grbTiempo);
            this.grbBase2.Controls.Add(this.chclVigente);
            this.grbBase2.Controls.Add(this.dtpFechaInicio);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.cboColaborador);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtCargo);
            this.grbBase2.Location = new System.Drawing.Point(6, 196);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(609, 117);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            // 
            // cboTipResponsableCaja1
            // 
            this.cboTipResponsableCaja1.FormattingEnabled = true;
            this.cboTipResponsableCaja1.Location = new System.Drawing.Point(124, 16);
            this.cboTipResponsableCaja1.Name = "cboTipResponsableCaja1";
            this.cboTipResponsableCaja1.Size = new System.Drawing.Size(205, 21);
            this.cboTipResponsableCaja1.TabIndex = 123;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(385, 39);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFecFin.TabIndex = 3;
            // 
            // lblfecfin
            // 
            this.lblfecfin.AutoSize = true;
            this.lblfecfin.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblfecfin.ForeColor = System.Drawing.Color.Navy;
            this.lblfecfin.Location = new System.Drawing.Point(334, 43);
            this.lblfecfin.Name = "lblfecfin";
            this.lblfecfin.Size = new System.Drawing.Size(44, 13);
            this.lblfecfin.TabIndex = 122;
            this.lblfecfin.Text = "Hasta:";
            // 
            // grbTiempo
            // 
            this.grbTiempo.Controls.Add(this.rbtIndeterminado);
            this.grbTiempo.Controls.Add(this.rbtDeterminado);
            this.grbTiempo.ForeColor = System.Drawing.Color.Navy;
            this.grbTiempo.Location = new System.Drawing.Point(486, 9);
            this.grbTiempo.Name = "grbTiempo";
            this.grbTiempo.Size = new System.Drawing.Size(117, 78);
            this.grbTiempo.TabIndex = 2;
            this.grbTiempo.TabStop = false;
            this.grbTiempo.Text = "Tiempo";
            // 
            // rbtIndeterminado
            // 
            this.rbtIndeterminado.AutoSize = true;
            this.rbtIndeterminado.ForeColor = System.Drawing.Color.Navy;
            this.rbtIndeterminado.Location = new System.Drawing.Point(15, 21);
            this.rbtIndeterminado.Name = "rbtIndeterminado";
            this.rbtIndeterminado.Size = new System.Drawing.Size(92, 17);
            this.rbtIndeterminado.TabIndex = 0;
            this.rbtIndeterminado.Text = "Indeterminado";
            this.rbtIndeterminado.UseVisualStyleBackColor = true;
            this.rbtIndeterminado.CheckedChanged += new System.EventHandler(this.rbtIndeterminado_CheckedChanged);
            // 
            // rbtDeterminado
            // 
            this.rbtDeterminado.AutoSize = true;
            this.rbtDeterminado.ForeColor = System.Drawing.Color.Navy;
            this.rbtDeterminado.Location = new System.Drawing.Point(15, 44);
            this.rbtDeterminado.Name = "rbtDeterminado";
            this.rbtDeterminado.Size = new System.Drawing.Size(85, 17);
            this.rbtDeterminado.TabIndex = 1;
            this.rbtDeterminado.Text = "Determinado";
            this.rbtDeterminado.UseVisualStyleBackColor = true;
            this.rbtDeterminado.CheckedChanged += new System.EventHandler(this.rbtDeterminado_CheckedChanged);
            // 
            // chclVigente
            // 
            this.chclVigente.AutoSize = true;
            this.chclVigente.ForeColor = System.Drawing.Color.Navy;
            this.chclVigente.Location = new System.Drawing.Point(501, 91);
            this.chclVigente.Name = "chclVigente";
            this.chclVigente.Size = new System.Drawing.Size(81, 17);
            this.chclVigente.TabIndex = 120;
            this.chclVigente.Text = "Dar de baja";
            this.chclVigente.UseVisualStyleBackColor = true;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(386, 16);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(335, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(48, 13);
            this.lblBase3.TabIndex = 117;
            this.lblBase3.Text = "Desde:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgResBov);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(6, 48);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(609, 142);
            this.grbBase3.TabIndex = 1;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Lista de responsables";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(304, 319);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(427, 319);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(549, 319);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(488, 319);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(365, 319);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmManRespBoveda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 400);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmManRespBoveda";
            this.Text = "Mantenimiento de responsable de caja";
            this.Load += new System.EventHandler(this.frmManRespBoveda_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResBov)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbTiempo.ResumeLayout(false);
            this.grbTiempo.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtCBLetra txtCargo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgResBov;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.chcBase chclVigente;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblfecfin;
        private GEN.ControlesBase.grbBase grbTiempo;
        private GEN.ControlesBase.rbtBase rbtIndeterminado;
        private GEN.ControlesBase.rbtBase rbtDeterminado;
        private GEN.ControlesBase.cboTipResponsableCaja cboTipResponsableCaja1;
    }
}