namespace GRH.Presentacion
{
    partial class frmMantenPeriodoPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenPeriodoPlanilla));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboTipoPlanilla1 = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboRelacionLabInst1 = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.cboEstadoPeriodo1 = new GEN.ControlesBase.cboEstadoPeriodo(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtDenominacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgPeriodos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(467, 432);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 89;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase4
            // 
            this.lblBase4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(15, 12);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(512, 19);
            this.lblBase4.TabIndex = 88;
            this.lblBase4.Text = "PERIODOS DE PLANILLAS";
            this.lblBase4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(340, 432);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 87;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(276, 432);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 86;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(212, 432);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 85;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(148, 432);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 84;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Controls.Add(this.cboEstadoPeriodo1);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.txtDenominacion);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtgPeriodos);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.dtpFecInicio);
            this.grbBase1.Location = new System.Drawing.Point(15, 17);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(512, 409);
            this.grbBase1.TabIndex = 83;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "grbBase1";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboTipoPlanilla1);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.cboRelacionLabInst1);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(16, 19);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(479, 58);
            this.grbBase2.TabIndex = 91;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Filtros de Búsqueda";
            // 
            // cboTipoPlanilla1
            // 
            this.cboTipoPlanilla1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla1.FormattingEnabled = true;
            this.cboTipoPlanilla1.Location = new System.Drawing.Point(343, 23);
            this.cboTipoPlanilla1.Name = "cboTipoPlanilla1";
            this.cboTipoPlanilla1.Size = new System.Drawing.Size(124, 21);
            this.cboTipoPlanilla1.TabIndex = 11;
            this.cboTipoPlanilla1.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla1_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(243, 26);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(98, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Tipo de Planilla:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(12, 26);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(83, 13);
            this.lblBase11.TabIndex = 88;
            this.lblBase11.Text = "Clasificación:";
            // 
            // cboRelacionLabInst1
            // 
            this.cboRelacionLabInst1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst1.FormattingEnabled = true;
            this.cboRelacionLabInst1.Location = new System.Drawing.Point(96, 23);
            this.cboRelacionLabInst1.Name = "cboRelacionLabInst1";
            this.cboRelacionLabInst1.Size = new System.Drawing.Size(124, 21);
            this.cboRelacionLabInst1.TabIndex = 89;
            this.cboRelacionLabInst1.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst1_SelectedIndexChanged);
            // 
            // cboEstadoPeriodo1
            // 
            this.cboEstadoPeriodo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoPeriodo1.FormattingEnabled = true;
            this.cboEstadoPeriodo1.Location = new System.Drawing.Point(357, 126);
            this.cboEstadoPeriodo1.Name = "cboEstadoPeriodo1";
            this.cboEstadoPeriodo1.Size = new System.Drawing.Size(124, 21);
            this.cboEstadoPeriodo1.TabIndex = 90;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(259, 129);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(50, 13);
            this.lblBase9.TabIndex = 16;
            this.lblBase9.Text = "Estado:";
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Location = new System.Drawing.Point(358, 97);
            this.txtDenominacion.MaxLength = 15;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(124, 20);
            this.txtDenominacion.TabIndex = 15;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(259, 100);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(88, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Denominación";
            // 
            // dtgPeriodos
            // 
            this.dtgPeriodos.AllowUserToAddRows = false;
            this.dtgPeriodos.AllowUserToDeleteRows = false;
            this.dtgPeriodos.AllowUserToResizeColumns = false;
            this.dtgPeriodos.AllowUserToResizeRows = false;
            this.dtgPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPeriodos.Location = new System.Drawing.Point(17, 159);
            this.dtgPeriodos.MultiSelect = false;
            this.dtgPeriodos.Name = "dtgPeriodos";
            this.dtgPeriodos.ReadOnly = true;
            this.dtgPeriodos.RowHeadersVisible = false;
            this.dtgPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPeriodos.Size = new System.Drawing.Size(478, 244);
            this.dtgPeriodos.TabIndex = 3;
            this.dtgPeriodos.SelectionChanged += new System.EventHandler(this.dtgPeriodos_SelectionChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(27, 126);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(60, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "F. de Fin:";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(112, 122);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(124, 20);
            this.dtpFecFin.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(28, 100);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(75, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "F. de Inicio:";
            // 
            // dtpFecInicio
            // 
            this.dtpFecInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicio.Location = new System.Drawing.Point(112, 96);
            this.dtpFecInicio.Name = "dtpFecInicio";
            this.dtpFecInicio.Size = new System.Drawing.Size(124, 20);
            this.dtpFecInicio.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(404, 432);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 90;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmMantenPeriodoPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 516);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenPeriodoPlanilla";
            this.Text = "Mantenimiento de Periodos de Planilla";
            this.Load += new System.EventHandler(this.frmMantenPeriodoPlanilla_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPeriodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst1;
        private GEN.ControlesBase.txtBase txtDenominacion;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgPeriodos;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecInicio;
        private GEN.ControlesBase.cboEstadoPeriodo cboEstadoPeriodo1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.grbBase grbBase2;
    }
}