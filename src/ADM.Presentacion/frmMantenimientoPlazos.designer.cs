namespace ADM.Presentacion
{
    partial class frmMantenimientoPlazos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoPlazos));
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtPlazoMax = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtPlazoMin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.CBaMas = new System.Windows.Forms.CheckBox();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.dtgPlazos = new GEN.ControlesBase.dtgBase(this.components);
            this.cboModulo1 = new GEN.ControlesBase.cboBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlazos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(335, 492);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
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
            this.btnNuevo1.Location = new System.Drawing.Point(213, 492);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtPlazoMax);
            this.grbBase1.Controls.Add(this.txtPlazoMin);
            this.grbBase1.Controls.Add(this.CBaMas);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(20, 43);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(436, 88);
            this.grbBase1.TabIndex = 28;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Rango de Plazo";
            // 
            // txtPlazoMax
            // 
            this.txtPlazoMax.Location = new System.Drawing.Point(356, 29);
            this.txtPlazoMax.MaxLength = 9;
            this.txtPlazoMax.Name = "txtPlazoMax";
            this.txtPlazoMax.Size = new System.Drawing.Size(67, 20);
            this.txtPlazoMax.TabIndex = 1;
            // 
            // txtPlazoMin
            // 
            this.txtPlazoMin.Location = new System.Drawing.Point(131, 29);
            this.txtPlazoMin.MaxLength = 9;
            this.txtPlazoMin.Name = "txtPlazoMin";
            this.txtPlazoMin.Size = new System.Drawing.Size(68, 20);
            this.txtPlazoMin.TabIndex = 0;
            // 
            // CBaMas
            // 
            this.CBaMas.AutoSize = true;
            this.CBaMas.Location = new System.Drawing.Point(356, 55);
            this.CBaMas.Name = "CBaMas";
            this.CBaMas.Size = new System.Drawing.Size(54, 17);
            this.CBaMas.TabIndex = 2;
            this.CBaMas.Text = "a más";
            this.CBaMas.UseVisualStyleBackColor = true;
            this.CBaMas.CheckedChanged += new System.EventHandler(this.CBaMas_CheckedChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(9, 32);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(121, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Plazo Mínimo(Días):";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(228, 32);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(125, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Plazo Máximo(Días):";
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(274, 492);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(396, 492);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 6;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(101, 13);
            this.lblBase1.TabIndex = 25;
            this.lblBase1.Text = "Escoger Módulo:";
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(396, 194);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 2;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Enabled = false;
            this.btnAgregar1.Location = new System.Drawing.Point(396, 141);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 1;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // dtgPlazos
            // 
            this.dtgPlazos.AllowUserToAddRows = false;
            this.dtgPlazos.AllowUserToDeleteRows = false;
            this.dtgPlazos.AllowUserToResizeColumns = false;
            this.dtgPlazos.AllowUserToResizeRows = false;
            this.dtgPlazos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlazos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlazos.Location = new System.Drawing.Point(20, 141);
            this.dtgPlazos.MultiSelect = false;
            this.dtgPlazos.Name = "dtgPlazos";
            this.dtgPlazos.ReadOnly = true;
            this.dtgPlazos.RowHeadersVisible = false;
            this.dtgPlazos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlazos.Size = new System.Drawing.Size(360, 337);
            this.dtgPlazos.TabIndex = 21;
            this.dtgPlazos.SelectionChanged += new System.EventHandler(this.dtgPlazos_SelectionChanged);
            // 
            // cboModulo1
            // 
            this.cboModulo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo1.FormattingEnabled = true;
            this.cboModulo1.Location = new System.Drawing.Point(135, 14);
            this.cboModulo1.Name = "cboModulo1";
            this.cboModulo1.Size = new System.Drawing.Size(121, 21);
            this.cboModulo1.TabIndex = 29;
            this.cboModulo1.SelectedIndexChanged += new System.EventHandler(this.cboModulo1_SelectedIndexChanged);
            // 
            // frmMantenimientoPlazos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 579);
            this.Controls.Add(this.cboModulo1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnQuitar1);
            this.Controls.Add(this.btnAgregar1);
            this.Controls.Add(this.dtgPlazos);
            this.Name = "frmMantenimientoPlazos";
            this.Text = "Mantenimiento de Rango de Plazos";
            this.Load += new System.EventHandler(this.MantenimientoPlazos_Load);
            this.Controls.SetChildIndex(this.dtgPlazos, 0);
            this.Controls.SetChildIndex(this.btnAgregar1, 0);
            this.Controls.SetChildIndex(this.btnQuitar1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.cboModulo1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlazos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.CheckBox CBaMas;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.ControlesBase.dtgBase dtgPlazos;
        private GEN.ControlesBase.txtCBNumerosEnteros txtPlazoMax;
        private GEN.ControlesBase.txtCBNumerosEnteros txtPlazoMin;
        private GEN.ControlesBase.cboBase cboModulo1;
    }
}