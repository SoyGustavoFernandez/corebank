namespace CRE.Presentacion
{
    partial class frmExcepciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcepciones));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.dtgExcepGeneradas = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniAcept1 = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniCancelEst1 = new GEN.BotonesBase.btnMiniCancelEst();
            this.btnNuevo = new GEN.BotonesBase.btnMiniNuevo(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.txtReglaDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboReglas = new GEN.ControlesBase.cboBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblTotalExcep = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepGeneradas)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniEditar1);
            this.grbBase1.Controls.Add(this.btnMiniQuitar1);
            this.grbBase1.Controls.Add(this.dtgExcepGeneradas);
            this.grbBase1.Location = new System.Drawing.Point(12, 23);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(639, 223);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Excepciones Generadas";
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.Location = new System.Drawing.Point(597, 53);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 2;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = true;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(597, 19);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 1;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // dtgExcepGeneradas
            // 
            this.dtgExcepGeneradas.AllowUserToAddRows = false;
            this.dtgExcepGeneradas.AllowUserToDeleteRows = false;
            this.dtgExcepGeneradas.AllowUserToResizeColumns = false;
            this.dtgExcepGeneradas.AllowUserToResizeRows = false;
            this.dtgExcepGeneradas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgExcepGeneradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExcepGeneradas.Location = new System.Drawing.Point(6, 19);
            this.dtgExcepGeneradas.MultiSelect = false;
            this.dtgExcepGeneradas.Name = "dtgExcepGeneradas";
            this.dtgExcepGeneradas.ReadOnly = true;
            this.dtgExcepGeneradas.RowHeadersVisible = false;
            this.dtgExcepGeneradas.RowTemplate.Height = 44;
            this.dtgExcepGeneradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcepGeneradas.Size = new System.Drawing.Size(585, 197);
            this.dtgExcepGeneradas.TabIndex = 0;
            this.dtgExcepGeneradas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgExcepGeneradas_CellDoubleClick);
            this.dtgExcepGeneradas.SelectionChanged += new System.EventHandler(this.dtgExcepGeneradas_SelectionChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniAcept1);
            this.grbBase2.Controls.Add(this.btnMiniCancelEst1);
            this.grbBase2.Controls.Add(this.btnNuevo);
            this.grbBase2.Controls.Add(this.txtSustento);
            this.grbBase2.Controls.Add(this.txtReglaDescripcion);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.cboReglas);
            this.grbBase2.Location = new System.Drawing.Point(12, 247);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(639, 189);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            // 
            // btnMiniAcept1
            // 
            this.btnMiniAcept1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAcept1.BackgroundImage")));
            this.btnMiniAcept1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAcept1.Location = new System.Drawing.Point(597, 54);
            this.btnMiniAcept1.Name = "btnMiniAcept1";
            this.btnMiniAcept1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAcept1.TabIndex = 3;
            this.btnMiniAcept1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAcept1.UseVisualStyleBackColor = true;
            this.btnMiniAcept1.Click += new System.EventHandler(this.btnMiniAcept1_Click);
            // 
            // btnMiniCancelEst1
            // 
            this.btnMiniCancelEst1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniCancelEst1.BackgroundImage")));
            this.btnMiniCancelEst1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniCancelEst1.Location = new System.Drawing.Point(597, 88);
            this.btnMiniCancelEst1.Name = "btnMiniCancelEst1";
            this.btnMiniCancelEst1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniCancelEst1.TabIndex = 5;
            this.btnMiniCancelEst1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniCancelEst1.UseVisualStyleBackColor = true;
            this.btnMiniCancelEst1.Click += new System.EventHandler(this.btnMiniCancelEst1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(598, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(36, 28);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(100, 77);
            this.txtSustento.MaxLength = 500;
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(491, 98);
            this.txtSustento.TabIndex = 2;
            // 
            // txtReglaDescripcion
            // 
            this.txtReglaDescripcion.Location = new System.Drawing.Point(100, 48);
            this.txtReglaDescripcion.Name = "txtReglaDescripcion";
            this.txtReglaDescripcion.Size = new System.Drawing.Size(491, 20);
            this.txtReglaDescripcion.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(32, 77);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(62, 13);
            this.lblBase3.TabIndex = 3;
            this.lblBase3.Text = "Sustento:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(25, 51);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(69, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Excepción:";
            // 
            // cboReglas
            // 
            this.cboReglas.FormattingEnabled = true;
            this.cboReglas.Location = new System.Drawing.Point(100, 21);
            this.cboReglas.Name = "cboReglas";
            this.cboReglas.Size = new System.Drawing.Size(491, 21);
            this.cboReglas.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(591, 441);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(459, 440);
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
            this.btnCancelar1.Location = new System.Drawing.Point(525, 440);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 4;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(393, 440);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 2;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(386, 10);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(43, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Total :";
            // 
            // lblTotalExcep
            // 
            this.lblTotalExcep.AutoSize = true;
            this.lblTotalExcep.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTotalExcep.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalExcep.Location = new System.Drawing.Point(423, 10);
            this.lblTotalExcep.Name = "lblTotalExcep";
            this.lblTotalExcep.Size = new System.Drawing.Size(14, 13);
            this.lblTotalExcep.TabIndex = 7;
            this.lblTotalExcep.Text = "0";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(463, 10);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(71, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Automatico";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(560, 10);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(47, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Manual";
            // 
            // frmExcepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(663, 515);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblTotalExcep);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmExcepciones";
            this.Text = "Excepciones Generadas";
            this.Load += new System.EventHandler(this.frmExcepGen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmExcepciones_paint);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblTotalExcep, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepGeneradas)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgExcepGeneradas;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtReglaDescripcion;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboBase cboReglas;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private GEN.BotonesBase.btnMiniCancelEst btnMiniCancelEst1;
        private GEN.BotonesBase.btnMiniNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblTotalExcep;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAcept1;
    }
}