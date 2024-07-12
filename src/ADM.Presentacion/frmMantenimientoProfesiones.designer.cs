namespace ADM.Presentacion
{
    partial class frmMantenimientoProfesiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoProfesiones));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgProfesion = new GEN.ControlesBase.dtgBase(this.components);
            this.txtProfesion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodSunat = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodSBS = new GEN.ControlesBase.txtBase(this.components);
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.cboEntidadReg = new GEN.ControlesBase.cboBase(this.components);
            this.chcAplicaSunat = new GEN.ControlesBase.chcBase(this.components);
            this.chcAplicaSBS = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProfesion)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(605, 145);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(479, 145);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(353, 145);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(416, 145);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 3;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(542, 145);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgProfesion
            // 
            this.dtgProfesion.AllowUserToAddRows = false;
            this.dtgProfesion.AllowUserToDeleteRows = false;
            this.dtgProfesion.AllowUserToResizeColumns = false;
            this.dtgProfesion.AllowUserToResizeRows = false;
            this.dtgProfesion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProfesion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProfesion.Location = new System.Drawing.Point(12, 38);
            this.dtgProfesion.MultiSelect = false;
            this.dtgProfesion.Name = "dtgProfesion";
            this.dtgProfesion.ReadOnly = true;
            this.dtgProfesion.RowHeadersVisible = false;
            this.dtgProfesion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProfesion.Size = new System.Drawing.Size(287, 131);
            this.dtgProfesion.TabIndex = 7;
            this.dtgProfesion.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProfesion_RowEnter);
            // 
            // txtProfesion
            // 
            this.txtProfesion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProfesion.Enabled = false;
            this.txtProfesion.Location = new System.Drawing.Point(101, 13);
            this.txtProfesion.MaxLength = 100;
            this.txtProfesion.Name = "txtProfesion";
            this.txtProfesion.Size = new System.Drawing.Size(243, 20);
            this.txtProfesion.TabIndex = 0;
            // 
            // txtCodSunat
            // 
            this.txtCodSunat.Enabled = false;
            this.txtCodSunat.Location = new System.Drawing.Point(101, 39);
            this.txtCodSunat.MaxLength = 3;
            this.txtCodSunat.Name = "txtCodSunat";
            this.txtCodSunat.Size = new System.Drawing.Size(105, 20);
            this.txtCodSunat.TabIndex = 2;
            // 
            // txtCodSBS
            // 
            this.txtCodSBS.Enabled = false;
            this.txtCodSBS.Location = new System.Drawing.Point(101, 66);
            this.txtCodSBS.MaxLength = 3;
            this.txtCodSBS.Name = "txtCodSBS";
            this.txtCodSBS.Size = new System.Drawing.Size(105, 20);
            this.txtCodSBS.TabIndex = 4;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.Enabled = false;
            this.chcVigente.Location = new System.Drawing.Point(101, 92);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(62, 17);
            this.chcVigente.TabIndex = 5;
            this.chcVigente.Text = "Vigente";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 12;
            this.lblBase1.Text = "Descripción:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 43);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(89, 13);
            this.lblBase2.TabIndex = 13;
            this.lblBase2.Text = "Código Sunat:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 70);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Código SBS:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(13, 13);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(77, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Filtrado por:";
            // 
            // cboEntidadReg
            // 
            this.cboEntidadReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidadReg.FormattingEnabled = true;
            this.cboEntidadReg.Location = new System.Drawing.Point(108, 9);
            this.cboEntidadReg.Name = "cboEntidadReg";
            this.cboEntidadReg.Size = new System.Drawing.Size(191, 21);
            this.cboEntidadReg.TabIndex = 0;
            this.cboEntidadReg.SelectedIndexChanged += new System.EventHandler(this.cboEntidadReg_SelectedIndexChanged);
            // 
            // chcAplicaSunat
            // 
            this.chcAplicaSunat.AutoSize = true;
            this.chcAplicaSunat.Enabled = false;
            this.chcAplicaSunat.Location = new System.Drawing.Point(211, 41);
            this.chcAplicaSunat.Name = "chcAplicaSunat";
            this.chcAplicaSunat.Size = new System.Drawing.Size(63, 17);
            this.chcAplicaSunat.TabIndex = 1;
            this.chcAplicaSunat.Text = "SUNAT";
            this.chcAplicaSunat.UseVisualStyleBackColor = true;
            this.chcAplicaSunat.CheckedChanged += new System.EventHandler(this.chcAplicaSunat_CheckedChanged);
            // 
            // chcAplicaSBS
            // 
            this.chcAplicaSBS.AutoSize = true;
            this.chcAplicaSBS.Enabled = false;
            this.chcAplicaSBS.Location = new System.Drawing.Point(211, 68);
            this.chcAplicaSBS.Name = "chcAplicaSBS";
            this.chcAplicaSBS.Size = new System.Drawing.Size(47, 17);
            this.chcAplicaSBS.TabIndex = 3;
            this.chcAplicaSBS.Text = "SBS";
            this.chcAplicaSBS.UseVisualStyleBackColor = true;
            this.chcAplicaSBS.CheckedChanged += new System.EventHandler(this.chcAplicaSBS_CheckedChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.chcAplicaSBS);
            this.grbBase1.Controls.Add(this.txtProfesion);
            this.grbBase1.Controls.Add(this.chcAplicaSunat);
            this.grbBase1.Controls.Add(this.txtCodSunat);
            this.grbBase1.Controls.Add(this.txtCodSBS);
            this.grbBase1.Controls.Add(this.chcVigente);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(312, 9);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(357, 130);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Profesiones";
            // 
            // frmMantenimientoProfesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 224);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.cboEntidadReg);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgProfesion);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMantenimientoProfesiones";
            this.Text = "Mantenimiento de profesiones u ocupaciones";
            this.Load += new System.EventHandler(this.frmMantenimientoProfesiones_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgProfesion, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboEntidadReg, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProfesion)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgProfesion;
        private GEN.ControlesBase.txtBase txtProfesion;
        private GEN.ControlesBase.txtBase txtCodSunat;
        private GEN.ControlesBase.txtBase txtCodSBS;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboEntidadReg;
        private GEN.ControlesBase.chcBase chcAplicaSunat;
        private GEN.ControlesBase.chcBase chcAplicaSBS;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}