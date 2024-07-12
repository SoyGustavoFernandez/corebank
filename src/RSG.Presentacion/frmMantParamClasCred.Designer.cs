namespace RSG.Presentacion
{
    partial class frmMantParamClasCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantParamClasCred));
            this.dtgParametros = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.nudMaxDias = new System.Windows.Forms.NumericUpDown();
            this.nudCuotasPagadas = new System.Windows.Forms.NumericUpDown();
            this.nudMinDias = new System.Windows.Forms.NumericUpDown();
            this.nudNivel = new System.Windows.Forms.NumericUpDown();
            this.txtModalidad = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblNivel = new GEN.ControlesBase.lblBase();
            this.CBVigente = new System.Windows.Forms.CheckBox();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTiposParametro = new GEN.ControlesBase.cboBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgParametros)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotasPagadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgParametros
            // 
            this.dtgParametros.AllowUserToAddRows = false;
            this.dtgParametros.AllowUserToDeleteRows = false;
            this.dtgParametros.AllowUserToResizeColumns = false;
            this.dtgParametros.AllowUserToResizeRows = false;
            this.dtgParametros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParametros.Location = new System.Drawing.Point(12, 161);
            this.dtgParametros.MultiSelect = false;
            this.dtgParametros.Name = "dtgParametros";
            this.dtgParametros.ReadOnly = true;
            this.dtgParametros.RowHeadersVisible = false;
            this.dtgParametros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParametros.Size = new System.Drawing.Size(498, 330);
            this.dtgParametros.TabIndex = 39;
            this.dtgParametros.SelectionChanged += new System.EventHandler(this.dtgParametros_SelectionChanged);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(264, 497);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 35;
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
            this.btnCancelar1.Location = new System.Drawing.Point(388, 497);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 37;
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
            this.btnNuevo1.Location = new System.Drawing.Point(202, 497);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 34;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Visible = false;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(326, 497);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 36;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(450, 497);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 38;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.nudMaxDias);
            this.grbBase1.Controls.Add(this.nudCuotasPagadas);
            this.grbBase1.Controls.Add(this.nudMinDias);
            this.grbBase1.Controls.Add(this.nudNivel);
            this.grbBase1.Controls.Add(this.txtModalidad);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblNivel);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(12, 47);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(498, 108);
            this.grbBase1.TabIndex = 40;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Parámetro";
            // 
            // nudMaxDias
            // 
            this.nudMaxDias.Location = new System.Drawing.Point(398, 49);
            this.nudMaxDias.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMaxDias.Name = "nudMaxDias";
            this.nudMaxDias.Size = new System.Drawing.Size(94, 20);
            this.nudMaxDias.TabIndex = 56;
            // 
            // nudCuotasPagadas
            // 
            this.nudCuotasPagadas.Location = new System.Drawing.Point(400, 22);
            this.nudCuotasPagadas.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCuotasPagadas.Name = "nudCuotasPagadas";
            this.nudCuotasPagadas.Size = new System.Drawing.Size(92, 20);
            this.nudCuotasPagadas.TabIndex = 53;
            // 
            // nudMinDias
            // 
            this.nudMinDias.Location = new System.Drawing.Point(150, 49);
            this.nudMinDias.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMinDias.Name = "nudMinDias";
            this.nudMinDias.Size = new System.Drawing.Size(92, 20);
            this.nudMinDias.TabIndex = 54;
            // 
            // nudNivel
            // 
            this.nudNivel.Location = new System.Drawing.Point(150, 75);
            this.nudNivel.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudNivel.Name = "nudNivel";
            this.nudNivel.Size = new System.Drawing.Size(92, 20);
            this.nudNivel.TabIndex = 55;
            // 
            // txtModalidad
            // 
            this.txtModalidad.Location = new System.Drawing.Point(150, 21);
            this.txtModalidad.MaxLength = 50;
            this.txtModalidad.Name = "txtModalidad";
            this.txtModalidad.Size = new System.Drawing.Size(92, 20);
            this.txtModalidad.TabIndex = 52;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(256, 24);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(120, 13);
            this.lblBase8.TabIndex = 51;
            this.lblBase8.Text = "N. Cuotas Pagadas:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(13, 25);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 45;
            this.lblBase4.Text = "Modalidad:";
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNivel.ForeColor = System.Drawing.Color.Navy;
            this.lblNivel.Location = new System.Drawing.Point(13, 77);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(101, 13);
            this.lblNivel.TabIndex = 48;
            this.lblNivel.Text = "Nivel de Mejora:";
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(259, 78);
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
            this.lblBase6.Location = new System.Drawing.Point(256, 51);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(144, 13);
            this.lblBase6.TabIndex = 34;
            this.lblBase6.Text = "Días de Atraso Máximo:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 51);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(140, 13);
            this.lblBase1.TabIndex = 15;
            this.lblBase1.Text = "Días de Atraso Mínimo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(118, 13);
            this.lblBase3.TabIndex = 43;
            this.lblBase3.Text = "Tipo de Parámetro:";
            // 
            // cboTiposParametro
            // 
            this.cboTiposParametro.FormattingEnabled = true;
            this.cboTiposParametro.Location = new System.Drawing.Point(162, 19);
            this.cboTiposParametro.Name = "cboTiposParametro";
            this.cboTiposParametro.Size = new System.Drawing.Size(92, 21);
            this.cboTiposParametro.TabIndex = 44;
            this.cboTiposParametro.SelectedIndexChanged += new System.EventHandler(this.cboTiposParametro_SelectedIndexChanged);
            // 
            // frmMantParamClasCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 583);
            this.Controls.Add(this.cboTiposParametro);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.dtgParametros);
            this.Name = "frmMantParamClasCred";
            this.Text = "Mantenimiento de Parámetros para la Clasificación de Créditos Refinanciados";
            this.Load += new System.EventHandler(this.frmMantenParamClasifCredito_Load);
            this.Controls.SetChildIndex(this.dtgParametros, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTiposParametro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgParametros)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotasPagadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgParametros;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.CheckBox CBVigente;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblNivel;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboTiposParametro;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtCBLetra txtModalidad;
        private System.Windows.Forms.NumericUpDown nudCuotasPagadas;
        private System.Windows.Forms.NumericUpDown nudMaxDias;
        private System.Windows.Forms.NumericUpDown nudMinDias;
        private System.Windows.Forms.NumericUpDown nudNivel;
    }
}