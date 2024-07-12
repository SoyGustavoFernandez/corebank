namespace LOG.Presentacion
{
    partial class frmMantenimientoAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoAlmacen));
            this.cboAgencia = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgAlmacenAgencia = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNombreAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdEstabAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNombreEstab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboEstablecimiento = new GEN.ControlesBase.cboEstablecimiento(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNombreAlmacen = new GEN.ControlesBase.txtBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAlmacenAgencia)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(73, 8);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(269, 21);
            this.cboAgencia.TabIndex = 3;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 12);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Agencia:";
            // 
            // dtgAlmacenAgencia
            // 
            this.dtgAlmacenAgencia.AllowUserToAddRows = false;
            this.dtgAlmacenAgencia.AllowUserToDeleteRows = false;
            this.dtgAlmacenAgencia.AllowUserToResizeColumns = false;
            this.dtgAlmacenAgencia.AllowUserToResizeRows = false;
            this.dtgAlmacenAgencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAlmacenAgencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAlmacenAgencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAlmacenAgencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdAlmacen,
            this.dtgtxtNombreAlmacen,
            this.dtgtxtIdEstabAgencia,
            this.dtgtxtIdEstablecimiento,
            this.dtgtxtNombreEstab});
            this.dtgAlmacenAgencia.Location = new System.Drawing.Point(8, 37);
            this.dtgAlmacenAgencia.MultiSelect = false;
            this.dtgAlmacenAgencia.Name = "dtgAlmacenAgencia";
            this.dtgAlmacenAgencia.ReadOnly = true;
            this.dtgAlmacenAgencia.RowHeadersVisible = false;
            this.dtgAlmacenAgencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAlmacenAgencia.Size = new System.Drawing.Size(520, 150);
            this.dtgAlmacenAgencia.TabIndex = 5;
            this.dtgAlmacenAgencia.SelectionChanged += new System.EventHandler(this.dtgAlmacenAgencia_SelectionChanged);
            // 
            // dtgtxtIdAlmacen
            // 
            this.dtgtxtIdAlmacen.DataPropertyName = "idAlmacen";
            this.dtgtxtIdAlmacen.FillWeight = 1F;
            this.dtgtxtIdAlmacen.HeaderText = "Código";
            this.dtgtxtIdAlmacen.MinimumWidth = 60;
            this.dtgtxtIdAlmacen.Name = "dtgtxtIdAlmacen";
            this.dtgtxtIdAlmacen.ReadOnly = true;
            // 
            // dtgtxtNombreAlmacen
            // 
            this.dtgtxtNombreAlmacen.DataPropertyName = "cNombreAlmacen";
            this.dtgtxtNombreAlmacen.HeaderText = "Almacén";
            this.dtgtxtNombreAlmacen.MinimumWidth = 100;
            this.dtgtxtNombreAlmacen.Name = "dtgtxtNombreAlmacen";
            this.dtgtxtNombreAlmacen.ReadOnly = true;
            // 
            // dtgtxtIdEstabAgencia
            // 
            this.dtgtxtIdEstabAgencia.DataPropertyName = "idEstabAgencia";
            this.dtgtxtIdEstabAgencia.HeaderText = "idEstabAgencia";
            this.dtgtxtIdEstabAgencia.Name = "dtgtxtIdEstabAgencia";
            this.dtgtxtIdEstabAgencia.ReadOnly = true;
            this.dtgtxtIdEstabAgencia.Visible = false;
            // 
            // dtgtxtIdEstablecimiento
            // 
            this.dtgtxtIdEstablecimiento.DataPropertyName = "idEstablecimiento";
            this.dtgtxtIdEstablecimiento.HeaderText = "idEstablecimiento";
            this.dtgtxtIdEstablecimiento.Name = "dtgtxtIdEstablecimiento";
            this.dtgtxtIdEstablecimiento.ReadOnly = true;
            this.dtgtxtIdEstablecimiento.Visible = false;
            // 
            // dtgtxtNombreEstab
            // 
            this.dtgtxtNombreEstab.DataPropertyName = "cNombreEstab";
            this.dtgtxtNombreEstab.HeaderText = "Establecimiento";
            this.dtgtxtNombreEstab.MinimumWidth = 100;
            this.dtgtxtNombreEstab.Name = "dtgtxtNombreEstab";
            this.dtgtxtNombreEstab.ReadOnly = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(162, 255);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(222, 255);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(402, 255);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(342, 255);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(282, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(468, 255);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboEstablecimiento
            // 
            this.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstablecimiento.FormattingEnabled = true;
            this.cboEstablecimiento.Location = new System.Drawing.Point(139, 221);
            this.cboEstablecimiento.Name = "cboEstablecimiento";
            this.cboEstablecimiento.Size = new System.Drawing.Size(263, 21);
            this.cboEstablecimiento.TabIndex = 12;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 224);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(101, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Establecimiento:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 200);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(128, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Nombre de Almacén:";
            // 
            // txtNombreAlmacen
            // 
            this.txtNombreAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreAlmacen.Location = new System.Drawing.Point(139, 196);
            this.txtNombreAlmacen.Name = "txtNombreAlmacen";
            this.txtNombreAlmacen.Size = new System.Drawing.Size(389, 20);
            this.txtNombreAlmacen.TabIndex = 15;
            // 
            // frmMantenimientoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 335);
            this.Controls.Add(this.txtNombreAlmacen);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboEstablecimiento);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgAlmacenAgencia);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmMantenimientoAlmacen";
            this.Text = "Mantenimiento de Almacenes";
            this.Load += new System.EventHandler(this.frmMantenimientoAlmacen_Load);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgAlmacenAgencia, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboEstablecimiento, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtNombreAlmacen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAlmacenAgencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboAgencias cboAgencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgAlmacenAgencia;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.cboEstablecimiento cboEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtNombreAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNombreAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdEstabAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNombreEstab;
    }
}

