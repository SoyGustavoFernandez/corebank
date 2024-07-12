namespace ADM.Presentacion
{
    partial class frmAsigAgenciaUsu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsigAgenciaUsu));
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgAgenciasAsig = new GEN.ControlesBase.dtgBase(this.components);
            this.idAgenByUsu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuAsig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lPrincipal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcPrincipal = new GEN.ControlesBase.chcBase(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.conBusCol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgenciasAsig)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCol
            // 
            this.conBusCol.Controls.Add(this.grbBase1);
            this.conBusCol.Location = new System.Drawing.Point(12, 9);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(394, 86);
            this.conBusCol.TabIndex = 6;
            this.conBusCol.BuscarUsuario += new System.EventHandler(this.conBusCol_BuscarUsuario);
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(387, 86);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Colaborador";
            // 
            // dtgAgenciasAsig
            // 
            this.dtgAgenciasAsig.AllowUserToAddRows = false;
            this.dtgAgenciasAsig.AllowUserToDeleteRows = false;
            this.dtgAgenciasAsig.AllowUserToResizeColumns = false;
            this.dtgAgenciasAsig.AllowUserToResizeRows = false;
            this.dtgAgenciasAsig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAgenciasAsig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAgenciasAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAgenciasAsig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAgenByUsu,
            this.idAgencia,
            this.cAgencia,
            this.idUsuAsig,
            this.lPrincipal,
            this.idUsuario,
            this.dFecha,
            this.lVigente});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgAgenciasAsig.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgAgenciasAsig.Location = new System.Drawing.Point(12, 194);
            this.dtgAgenciasAsig.MultiSelect = false;
            this.dtgAgenciasAsig.Name = "dtgAgenciasAsig";
            this.dtgAgenciasAsig.ReadOnly = true;
            this.dtgAgenciasAsig.RowHeadersVisible = false;
            this.dtgAgenciasAsig.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAgenciasAsig.RowTemplate.Height = 20;
            this.dtgAgenciasAsig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAgenciasAsig.Size = new System.Drawing.Size(394, 136);
            this.dtgAgenciasAsig.TabIndex = 1;
            this.dtgAgenciasAsig.SelectionChanged += new System.EventHandler(this.dtgAgenciasAsig_SelectionChanged);
            // 
            // idAgenByUsu
            // 
            this.idAgenByUsu.DataPropertyName = "idAgenByUsu";
            this.idAgenByUsu.HeaderText = "idAgenByUsu";
            this.idAgenByUsu.Name = "idAgenByUsu";
            this.idAgenByUsu.ReadOnly = true;
            this.idAgenByUsu.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.FillWeight = 20F;
            this.idAgencia.HeaderText = "Cod.";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            // 
            // cAgencia
            // 
            this.cAgencia.DataPropertyName = "cAgencia";
            this.cAgencia.FillWeight = 60F;
            this.cAgencia.HeaderText = "Agencia";
            this.cAgencia.Name = "cAgencia";
            this.cAgencia.ReadOnly = true;
            // 
            // idUsuAsig
            // 
            this.idUsuAsig.DataPropertyName = "idUsuAsig";
            this.idUsuAsig.HeaderText = "idUsuAsig";
            this.idUsuAsig.Name = "idUsuAsig";
            this.idUsuAsig.ReadOnly = true;
            this.idUsuAsig.Visible = false;
            // 
            // lPrincipal
            // 
            this.lPrincipal.DataPropertyName = "lPrincipal";
            this.lPrincipal.FillWeight = 20F;
            this.lPrincipal.HeaderText = "Principal?";
            this.lPrincipal.Name = "lPrincipal";
            this.lPrincipal.ReadOnly = true;
            this.lPrincipal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "idUsuario";
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idUsuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idUsuario.Visible = false;
            // 
            // dFecha
            // 
            this.dFecha.DataPropertyName = "dFecha";
            this.dFecha.HeaderText = "dFecha";
            this.dFecha.Name = "dFecha";
            this.dFecha.ReadOnly = true;
            this.dFecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dFecha.Visible = false;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(346, 348);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(278, 348);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.chcPrincipal);
            this.grbBase2.Controls.Add(this.cboAgencias);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(12, 94);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(394, 94);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            // 
            // chcPrincipal
            // 
            this.chcPrincipal.AutoSize = true;
            this.chcPrincipal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.chcPrincipal.Location = new System.Drawing.Point(28, 63);
            this.chcPrincipal.Name = "chcPrincipal";
            this.chcPrincipal.Size = new System.Drawing.Size(90, 17);
            this.chcPrincipal.TabIndex = 1;
            this.chcPrincipal.Text = "Principal?";
            this.chcPrincipal.UseVisualStyleBackColor = true;
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(88, 25);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(292, 21);
            this.cboAgencias.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 28);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Agencia:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(156, 348);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(34, 348);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(95, 348);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(217, 348);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmAsigAgenciaUsu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 429);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.conBusCol);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dtgAgenciasAsig);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmAsigAgenciaUsu";
            this.Text = "Asignación de agencia a usuario";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtgAgenciasAsig, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.conBusCol, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.conBusCol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAgenciasAsig)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgAgenciasAsig;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.chcBase chcPrincipal;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgenByUsu;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuAsig;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;

    }
}

