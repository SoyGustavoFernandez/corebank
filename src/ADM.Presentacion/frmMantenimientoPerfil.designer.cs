namespace ADM.Presentacion
{
    partial class frmMantenimientoPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoPerfil));
            this.txtNomPerfil = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtDescriPerfil = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.dtgPerfiles = new System.Windows.Forms.DataGridView();
            this.idPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lLimCobertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcManejoLimiteCobert = new GEN.ControlesBase.chcBase(this.components);
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfiles)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNomPerfil
            // 
            this.txtNomPerfil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomPerfil.Location = new System.Drawing.Point(126, 12);
            this.txtNomPerfil.Name = "txtNomPerfil";
            this.txtNomPerfil.Size = new System.Drawing.Size(425, 20);
            this.txtNomPerfil.TabIndex = 97;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(8, 19);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(111, 13);
            this.lblBase7.TabIndex = 98;
            this.lblBase7.Text = "Nombre del Perfil:";
            // 
            // txtDescriPerfil
            // 
            this.txtDescriPerfil.Location = new System.Drawing.Point(126, 38);
            this.txtDescriPerfil.Multiline = true;
            this.txtDescriPerfil.Name = "txtDescriPerfil";
            this.txtDescriPerfil.Size = new System.Drawing.Size(425, 32);
            this.txtDescriPerfil.TabIndex = 100;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(8, 47);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(78, 13);
            this.lblBase9.TabIndex = 99;
            this.lblBase9.Text = "Descripción:";
            // 
            // dtgPerfiles
            // 
            this.dtgPerfiles.AllowUserToAddRows = false;
            this.dtgPerfiles.AllowUserToDeleteRows = false;
            this.dtgPerfiles.AllowUserToResizeColumns = false;
            this.dtgPerfiles.AllowUserToResizeRows = false;
            this.dtgPerfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPerfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPerfil,
            this.cPerfil,
            this.cDescripcion,
            this.lVigente,
            this.lLimCobertura});
            this.dtgPerfiles.Location = new System.Drawing.Point(3, 109);
            this.dtgPerfiles.MultiSelect = false;
            this.dtgPerfiles.Name = "dtgPerfiles";
            this.dtgPerfiles.ReadOnly = true;
            this.dtgPerfiles.RowHeadersVisible = false;
            this.dtgPerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPerfiles.Size = new System.Drawing.Size(555, 169);
            this.dtgPerfiles.TabIndex = 101;
            this.dtgPerfiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPerfiles_CellContentClick);
            this.dtgPerfiles.SelectionChanged += new System.EventHandler(this.dtgPerfiles_SelectionChanged);
            // 
            // idPerfil
            // 
            this.idPerfil.DataPropertyName = "idPerfil";
            this.idPerfil.HeaderText = "idPerfil";
            this.idPerfil.Name = "idPerfil";
            this.idPerfil.ReadOnly = true;
            this.idPerfil.Visible = false;
            // 
            // cPerfil
            // 
            this.cPerfil.DataPropertyName = "cPerfil";
            this.cPerfil.HeaderText = "Perfil";
            this.cPerfil.Name = "cPerfil";
            this.cPerfil.ReadOnly = true;
            // 
            // cDescripcion
            // 
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // lLimCobertura
            // 
            this.lLimCobertura.DataPropertyName = "lLimCobertura";
            this.lLimCobertura.HeaderText = "lLimCobertura";
            this.lLimCobertura.Name = "lLimCobertura";
            this.lLimCobertura.ReadOnly = true;
            this.lLimCobertura.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(198, 284);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 119;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(498, 284);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 120;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(438, 284);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 116;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(318, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(258, 284);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 118;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcManejoLimiteCobert);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Location = new System.Drawing.Point(3, -3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(555, 106);
            this.grbBase1.TabIndex = 122;
            this.grbBase1.TabStop = false;
            // 
            // chcManejoLimiteCobert
            // 
            this.chcManejoLimiteCobert.AutoSize = true;
            this.chcManejoLimiteCobert.Font = new System.Drawing.Font("Verdana", 8F);
            this.chcManejoLimiteCobert.ForeColor = System.Drawing.Color.Navy;
            this.chcManejoLimiteCobert.Location = new System.Drawing.Point(123, 81);
            this.chcManejoLimiteCobert.Name = "chcManejoLimiteCobert";
            this.chcManejoLimiteCobert.Size = new System.Drawing.Size(185, 17);
            this.chcManejoLimiteCobert.TabIndex = 124;
            this.chcManejoLimiteCobert.Text = "Maneja Límite de Cobertura";
            this.chcManejoLimiteCobert.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(378, 284);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 123;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmMantenimientoPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 359);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtgPerfiles);
            this.Controls.Add(this.txtDescriPerfil);
            this.Controls.Add(this.txtNomPerfil);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoPerfil";
            this.Text = "Mantenimiento de Perfiles";
            this.Load += new System.EventHandler(this.frmMantenimientoPerfil_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.txtNomPerfil, 0);
            this.Controls.SetChildIndex(this.txtDescriPerfil, 0);
            this.Controls.SetChildIndex(this.dtgPerfiles, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPerfiles)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtBase txtNomPerfil;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtDescriPerfil;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.DataGridView dtgPerfiles;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcManejoLimiteCobert;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn lLimCobertura;
        private GEN.BotonesBase.btnEliminar btnEliminar;
    }
}