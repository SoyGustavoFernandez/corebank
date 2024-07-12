namespace CRE.Presentacion
{
    partial class frmGrupoEconomico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoEconomico));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoGrupoEco1 = new GEN.ControlesBase.cboTipoGrupoEco(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.txtGrupoEconomico = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.lstParticipantes = new GEN.ControlesBase.lstBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgGrupoEconomico = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnQuitarParticipante = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregarParticipantes = new GEN.BotonesBase.btnMiniAgregar();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoEconomico)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(15, 9);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(158, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Tipo de Grupo Económico:";
            // 
            // cboTipoGrupoEco1
            // 
            this.cboTipoGrupoEco1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoGrupoEco1.FormattingEnabled = true;
            this.cboTipoGrupoEco1.Location = new System.Drawing.Point(179, 6);
            this.cboTipoGrupoEco1.Name = "cboTipoGrupoEco1";
            this.cboTipoGrupoEco1.Size = new System.Drawing.Size(169, 21);
            this.cboTipoGrupoEco1.TabIndex = 4;
            this.cboTipoGrupoEco1.SelectedIndexChanged += new System.EventHandler(this.cboTipoGrupoEco1_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(445, 383);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(380, 383);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(18, 383);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(314, 383);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtGrupoEconomico
            // 
            this.txtGrupoEconomico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupoEconomico.Enabled = false;
            this.txtGrupoEconomico.Location = new System.Drawing.Point(111, 36);
            this.txtGrupoEconomico.Name = "txtGrupoEconomico";
            this.txtGrupoEconomico.Size = new System.Drawing.Size(309, 20);
            this.txtGrupoEconomico.TabIndex = 9;
            this.txtGrupoEconomico.TextChanged += new System.EventHandler(this.txtGrupoEconomico_TextChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 39);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Descripción:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(248, 383);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lstParticipantes
            // 
            this.lstParticipantes.FormattingEnabled = true;
            this.lstParticipantes.Location = new System.Drawing.Point(6, 15);
            this.lstParticipantes.Name = "lstParticipantes";
            this.lstParticipantes.Size = new System.Drawing.Size(487, 147);
            this.lstParticipantes.TabIndex = 15;
            this.lstParticipantes.SelectedIndexChanged += new System.EventHandler(this.lstParticipantes_SelectedIndexChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgGrupoEconomico);
            this.grbBase1.Location = new System.Drawing.Point(12, 70);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(540, 129);
            this.grbBase1.TabIndex = 16;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Grupo Económico";
            // 
            // dtgGrupoEconomico
            // 
            this.dtgGrupoEconomico.AllowUserToAddRows = false;
            this.dtgGrupoEconomico.AllowUserToDeleteRows = false;
            this.dtgGrupoEconomico.AllowUserToResizeColumns = false;
            this.dtgGrupoEconomico.AllowUserToResizeRows = false;
            this.dtgGrupoEconomico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupoEconomico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoEconomico.Location = new System.Drawing.Point(6, 19);
            this.dtgGrupoEconomico.MultiSelect = false;
            this.dtgGrupoEconomico.Name = "dtgGrupoEconomico";
            this.dtgGrupoEconomico.ReadOnly = true;
            this.dtgGrupoEconomico.RowHeadersVisible = false;
            this.dtgGrupoEconomico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoEconomico.Size = new System.Drawing.Size(528, 110);
            this.dtgGrupoEconomico.TabIndex = 0;
            this.dtgGrupoEconomico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupoEconomico_CellClick);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnQuitarParticipante);
            this.grbBase2.Controls.Add(this.lstParticipantes);
            this.grbBase2.Controls.Add(this.btnAgregarParticipantes);
            this.grbBase2.Location = new System.Drawing.Point(12, 205);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(540, 172);
            this.grbBase2.TabIndex = 19;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Participantes";
            // 
            // btnQuitarParticipante
            // 
            this.btnQuitarParticipante.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitarParticipante.BackgroundImage")));
            this.btnQuitarParticipante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitarParticipante.Location = new System.Drawing.Point(499, 49);
            this.btnQuitarParticipante.Name = "btnQuitarParticipante";
            this.btnQuitarParticipante.Size = new System.Drawing.Size(36, 28);
            this.btnQuitarParticipante.TabIndex = 21;
            this.btnQuitarParticipante.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitarParticipante.UseVisualStyleBackColor = true;
            this.btnQuitarParticipante.Click += new System.EventHandler(this.btnQuitarParticipante_Click);
            // 
            // btnAgregarParticipantes
            // 
            this.btnAgregarParticipantes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarParticipantes.BackgroundImage")));
            this.btnAgregarParticipantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregarParticipantes.Location = new System.Drawing.Point(499, 15);
            this.btnAgregarParticipantes.Name = "btnAgregarParticipantes";
            this.btnAgregarParticipantes.Size = new System.Drawing.Size(36, 28);
            this.btnAgregarParticipantes.TabIndex = 20;
            this.btnAgregarParticipantes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarParticipantes.UseVisualStyleBackColor = true;
            this.btnAgregarParticipantes.Click += new System.EventHandler(this.btnAgregarParticipantes_Click);
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Location = new System.Drawing.Point(445, 39);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 20;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            this.chcVigente.CheckedChanged += new System.EventHandler(this.chcVigente_CheckedChanged);
            // 
            // frmGrupoEconomico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 471);
            this.Controls.Add(this.chcVigente);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtGrupoEconomico);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cboTipoGrupoEco1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmGrupoEconomico";
            this.Text = "Gupos Económicos";
            this.Load += new System.EventHandler(this.frmGrupoEconomico_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoGrupoEco1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtGrupoEconomico, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.chcVigente, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoEconomico)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoGrupoEco cboTipoGrupoEco1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.txtBase txtGrupoEconomico;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.lstBase lstParticipantes;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgGrupoEconomico;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnMiniAgregar btnAgregarParticipantes;
        private GEN.BotonesBase.btnMiniQuitar btnQuitarParticipante;
        private GEN.ControlesBase.chcBase chcVigente;
    }
}

