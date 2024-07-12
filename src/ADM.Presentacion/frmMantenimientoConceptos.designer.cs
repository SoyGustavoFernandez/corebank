namespace ADM.Presentacion
{
    partial class frmMantenimientoConceptos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoConceptos));
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboGrupo = new GEN.ControlesBase.cboBase(this.components);
            this.txtNombreCorto = new GEN.ControlesBase.txtCBLetra(this.components);
            this.CBGrupo = new System.Windows.Forms.CheckBox();
            this.CBVigente = new System.Windows.Forms.CheckBox();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtNombConcepto = new GEN.ControlesBase.txtCBLetra(this.components);
            this.CBAplicaCont = new System.Windows.Forms.CheckBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgConceptos = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(265, 490);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 2;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboGrupo);
            this.grbBase1.Controls.Add(this.txtNombreCorto);
            this.grbBase1.Controls.Add(this.CBGrupo);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.txtNombConcepto);
            this.grbBase1.Controls.Add(this.CBAplicaCont);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(13, 10);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(498, 135);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos Generales";
            // 
            // cboGrupo
            // 
            this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(122, 98);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(121, 21);
            this.cboGrupo.TabIndex = 3;
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Location = new System.Drawing.Point(122, 48);
            this.txtNombreCorto.MaxLength = 50;
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(341, 20);
            this.txtNombreCorto.TabIndex = 1;
            // 
            // CBGrupo
            // 
            this.CBGrupo.AutoSize = true;
            this.CBGrupo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBGrupo.ForeColor = System.Drawing.Color.Navy;
            this.CBGrupo.Location = new System.Drawing.Point(12, 74);
            this.CBGrupo.Name = "CBGrupo";
            this.CBGrupo.Size = new System.Drawing.Size(133, 17);
            this.CBGrupo.TabIndex = 2;
            this.CBGrupo.Text = "Pertenece a Grupo";
            this.CBGrupo.UseVisualStyleBackColor = true;
            this.CBGrupo.CheckedChanged += new System.EventHandler(this.CBGrupo_CheckedChanged);
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(363, 97);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 5;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 51);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(93, 13);
            this.lblBase6.TabIndex = 34;
            this.lblBase6.Text = "Nombre Corto:";
            // 
            // txtNombConcepto
            // 
            this.txtNombConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombConcepto.Location = new System.Drawing.Point(122, 24);
            this.txtNombConcepto.MaxLength = 50;
            this.txtNombConcepto.Name = "txtNombConcepto";
            this.txtNombConcepto.Size = new System.Drawing.Size(341, 20);
            this.txtNombConcepto.TabIndex = 0;
            // 
            // CBAplicaCont
            // 
            this.CBAplicaCont.AutoSize = true;
            this.CBAplicaCont.ForeColor = System.Drawing.Color.Navy;
            this.CBAplicaCont.Location = new System.Drawing.Point(363, 74);
            this.CBAplicaCont.Name = "CBAplicaCont";
            this.CBAplicaCont.Size = new System.Drawing.Size(100, 17);
            this.CBAplicaCont.TabIndex = 4;
            this.CBAplicaCont.Text = "Aplica Contable";
            this.CBAplicaCont.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 27);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(66, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Concepto:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 98);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(47, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Grupo:";
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(389, 490);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(203, 490);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 1;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(327, 490);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 3;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(451, 490);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgConceptos
            // 
            this.dtgConceptos.AllowUserToAddRows = false;
            this.dtgConceptos.AllowUserToDeleteRows = false;
            this.dtgConceptos.AllowUserToResizeColumns = false;
            this.dtgConceptos.AllowUserToResizeRows = false;
            this.dtgConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConceptos.Location = new System.Drawing.Point(13, 154);
            this.dtgConceptos.MultiSelect = false;
            this.dtgConceptos.Name = "dtgConceptos";
            this.dtgConceptos.ReadOnly = true;
            this.dtgConceptos.RowHeadersVisible = false;
            this.dtgConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConceptos.Size = new System.Drawing.Size(498, 330);
            this.dtgConceptos.TabIndex = 33;
            this.dtgConceptos.SelectionChanged += new System.EventHandler(this.dtgConceptos_SelectionChanged);
            // 
            // frmMantenimientoConceptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 572);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgConceptos);
            this.Name = "frmMantenimientoConceptos";
            this.Text = "Mantenimiento de Conceptos";
            this.Load += new System.EventHandler(this.MantenimientoConceptos_Load);
            this.Controls.SetChildIndex(this.dtgConceptos, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConceptos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.CheckBox CBVigente;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtCBLetra txtNombConcepto;
        private System.Windows.Forms.CheckBox CBAplicaCont;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgConceptos;
        private System.Windows.Forms.CheckBox CBGrupo;
        private GEN.ControlesBase.txtCBLetra txtNombreCorto;
        private GEN.ControlesBase.cboBase cboGrupo;
    }
}