namespace ADM.Presentacion
{
    partial class frmVincuConceptoRecPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincuConceptoRecPerfil));
            this.cboPerfiles = new GEN.ControlesBase.cboListaPerfil(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgConcepAsig = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAgregar = new GEN.BotonesBase.btnContinuar();
            this.btnQuitar = new GEN.BotonesBase.btnRegresar();
            this.dtgConceptoNoAsig = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipRec = new GEN.ControlesBase.cboBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConcepAsig)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoNoAsig)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPerfiles
            // 
            this.cboPerfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerfiles.FormattingEnabled = true;
            this.cboPerfiles.Location = new System.Drawing.Point(408, 17);
            this.cboPerfiles.Name = "cboPerfiles";
            this.cboPerfiles.Size = new System.Drawing.Size(332, 21);
            this.cboPerfiles.TabIndex = 2;
            this.cboPerfiles.SelectedIndexChanged += new System.EventHandler(this.cboPerfiles_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(365, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(41, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Perfil:";
            // 
            // dtgConcepAsig
            // 
            this.dtgConcepAsig.AllowUserToAddRows = false;
            this.dtgConcepAsig.AllowUserToDeleteRows = false;
            this.dtgConcepAsig.AllowUserToResizeColumns = false;
            this.dtgConcepAsig.AllowUserToResizeRows = false;
            this.dtgConcepAsig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConcepAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConcepAsig.Location = new System.Drawing.Point(408, 44);
            this.dtgConcepAsig.MultiSelect = false;
            this.dtgConcepAsig.Name = "dtgConcepAsig";
            this.dtgConcepAsig.ReadOnly = true;
            this.dtgConcepAsig.RowHeadersVisible = false;
            this.dtgConcepAsig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConcepAsig.Size = new System.Drawing.Size(332, 204);
            this.dtgConcepAsig.TabIndex = 3;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnAgregar);
            this.grbBase1.Controls.Add(this.btnQuitar);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.dtgConceptoNoAsig);
            this.grbBase1.Controls.Add(this.cboPerfiles);
            this.grbBase1.Controls.Add(this.dtgConcepAsig);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboTipRec);
            this.grbBase1.Location = new System.Drawing.Point(8, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(750, 254);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Concepto Por Perfil";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(344, 44);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "A&gregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(344, 100);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 5;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dtgConceptoNoAsig
            // 
            this.dtgConceptoNoAsig.AllowUserToAddRows = false;
            this.dtgConceptoNoAsig.AllowUserToDeleteRows = false;
            this.dtgConceptoNoAsig.AllowUserToResizeColumns = false;
            this.dtgConceptoNoAsig.AllowUserToResizeRows = false;
            this.dtgConceptoNoAsig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConceptoNoAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptoNoAsig.Location = new System.Drawing.Point(9, 44);
            this.dtgConceptoNoAsig.MultiSelect = false;
            this.dtgConceptoNoAsig.Name = "dtgConceptoNoAsig";
            this.dtgConceptoNoAsig.ReadOnly = true;
            this.dtgConceptoNoAsig.RowHeadersVisible = false;
            this.dtgConceptoNoAsig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptoNoAsig.Size = new System.Drawing.Size(332, 204);
            this.dtgConceptoNoAsig.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(78, 13);
            this.lblBase3.TabIndex = 17;
            this.lblBase3.Text = "Tipo Recibo:";
            // 
            // cboTipRec
            // 
            this.cboTipRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipRec.FormattingEnabled = true;
            this.cboTipRec.Location = new System.Drawing.Point(85, 17);
            this.cboTipRec.Name = "cboTipRec";
            this.cboTipRec.Size = new System.Drawing.Size(256, 21);
            this.cboTipRec.TabIndex = 0;
            this.cboTipRec.SelectedIndexChanged += new System.EventHandler(this.cboTipRec_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(685, 272);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(619, 272);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(553, 272);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(487, 272);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmVincuConceptoRecPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 347);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmVincuConceptoRecPerfil";
            this.Text = "Vincular Concepto de Recibo con Perfil";
            this.Load += new System.EventHandler(this.frmVincuConceptoRecPerfil_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConcepAsig)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptoNoAsig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboListaPerfil cboPerfiles;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgConcepAsig;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboTipRec;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtgBase dtgConceptoNoAsig;
        private GEN.BotonesBase.btnContinuar btnAgregar;
        private GEN.BotonesBase.btnRegresar btnQuitar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
    }
}