namespace ADM.Presentacion
{
    partial class frmConfiguracionLimite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionLimite));
            this.dtgConfiguracionLimite = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoOpeEOB = new GEN.ControlesBase.cboTipoOpeEOB(this.components);
            this.cboLimitesExcep = new GEN.ControlesBase.cboLimitesExcep(this.components);
            this.txtLimiteSuperior = new GEN.ControlesBase.txtNumerico(this.components);
            this.txtLimiteInferior = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfiguracionLimite)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgConfiguracionLimite
            // 
            this.dtgConfiguracionLimite.AllowUserToAddRows = false;
            this.dtgConfiguracionLimite.AllowUserToDeleteRows = false;
            this.dtgConfiguracionLimite.AllowUserToResizeColumns = false;
            this.dtgConfiguracionLimite.AllowUserToResizeRows = false;
            this.dtgConfiguracionLimite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConfiguracionLimite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfiguracionLimite.Location = new System.Drawing.Point(11, 153);
            this.dtgConfiguracionLimite.MultiSelect = false;
            this.dtgConfiguracionLimite.Name = "dtgConfiguracionLimite";
            this.dtgConfiguracionLimite.ReadOnly = true;
            this.dtgConfiguracionLimite.RowHeadersVisible = false;
            this.dtgConfiguracionLimite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfiguracionLimite.Size = new System.Drawing.Size(603, 263);
            this.dtgConfiguracionLimite.TabIndex = 24;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboTipoOpeEOB);
            this.grbBase1.Controls.Add(this.cboLimitesExcep);
            this.grbBase1.Controls.Add(this.txtLimiteSuperior);
            this.grbBase1.Controls.Add(this.txtLimiteInferior);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(602, 135);
            this.grbBase1.TabIndex = 40;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos";
            // 
            // cboTipoOpeEOB
            // 
            this.cboTipoOpeEOB.FormattingEnabled = true;
            this.cboTipoOpeEOB.Location = new System.Drawing.Point(250, 13);
            this.cboTipoOpeEOB.Name = "cboTipoOpeEOB";
            this.cboTipoOpeEOB.Size = new System.Drawing.Size(232, 21);
            this.cboTipoOpeEOB.TabIndex = 51;
            // 
            // cboLimitesExcep
            // 
            this.cboLimitesExcep.FormattingEnabled = true;
            this.cboLimitesExcep.Location = new System.Drawing.Point(250, 47);
            this.cboLimitesExcep.Name = "cboLimitesExcep";
            this.cboLimitesExcep.Size = new System.Drawing.Size(232, 21);
            this.cboLimitesExcep.TabIndex = 50;
            // 
            // txtLimiteSuperior
            // 
            this.txtLimiteSuperior.Format = "n2";
            this.txtLimiteSuperior.Location = new System.Drawing.Point(250, 102);
            this.txtLimiteSuperior.Name = "txtLimiteSuperior";
            this.txtLimiteSuperior.Size = new System.Drawing.Size(232, 20);
            this.txtLimiteSuperior.TabIndex = 49;
            // 
            // txtLimiteInferior
            // 
            this.txtLimiteInferior.Format = "n2";
            this.txtLimiteInferior.Location = new System.Drawing.Point(250, 73);
            this.txtLimiteInferior.Name = "txtLimiteInferior";
            this.txtLimiteInferior.Size = new System.Drawing.Size(232, 20);
            this.txtLimiteInferior.TabIndex = 48;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(137, 102);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(94, 13);
            this.lblBase4.TabIndex = 47;
            this.lblBase4.Text = "Limite Superior";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(143, 76);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(88, 13);
            this.lblBase3.TabIndex = 46;
            this.lblBase3.Text = "Limite Inferior";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(184, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(47, 13);
            this.lblBase2.TabIndex = 45;
            this.lblBase2.Text = "Límites";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(120, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(111, 13);
            this.lblBase1.TabIndex = 44;
            this.lblBase1.Text = "Tipo de Operación";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(224, 436);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 47;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(290, 436);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 48;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(356, 436);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 49;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(422, 436);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(488, 436);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 51;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(554, 436);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 52;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // frmConfiguracionLimite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 521);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.dtgConfiguracionLimite);
            this.Name = "frmConfiguracionLimite";
            this.Text = "Configuración de Limites";
            this.Load += new System.EventHandler(this.frmConfiguracionLimite_Load);
            this.Controls.SetChildIndex(this.dtgConfiguracionLimite, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfiguracionLimite)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GEN.ControlesBase.dtgBase dtgConfiguracionLimite;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboTipoOpeEOB cboTipoOpeEOB;
        private GEN.ControlesBase.cboLimitesExcep cboLimitesExcep;
        private GEN.ControlesBase.txtNumerico txtLimiteSuperior;
        private GEN.ControlesBase.txtNumerico txtLimiteInferior;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.BotonesBase.btnSalir btnSalir1;
    }
}
