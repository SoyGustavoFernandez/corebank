namespace GRH.Presentacion
{
    partial class frmPlanillasTmp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanillasTmp));
            this.dtgPlanillasProceso = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.dtgtxtIdTipoRelLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoRelLab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdPeriodoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtPeriodoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdPeriodoDeclaracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtPeriodoDeclaracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtNumPersonPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillasProceso)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgPlanillasProceso
            // 
            this.dtgPlanillasProceso.AllowUserToAddRows = false;
            this.dtgPlanillasProceso.AllowUserToDeleteRows = false;
            this.dtgPlanillasProceso.AllowUserToResizeColumns = false;
            this.dtgPlanillasProceso.AllowUserToResizeRows = false;
            this.dtgPlanillasProceso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanillasProceso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPlanillasProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillasProceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdTipoRelLab,
            this.dtgtxtTipoRelLab,
            this.dtgtxtIdTipoPlanilla,
            this.dtgtxtTipoPlanilla,
            this.dtgtxtIdModalidad,
            this.dtgtxtModalidad,
            this.dtgtxtIdPeriodoPlanilla,
            this.dtgtxtPeriodoPlanilla,
            this.dtgtxtIdPeriodoDeclaracion,
            this.dtgtxtPeriodoDeclaracion,
            this.dtgtxtNumPersonPlanilla});
            this.dtgPlanillasProceso.Location = new System.Drawing.Point(6, 12);
            this.dtgPlanillasProceso.MultiSelect = false;
            this.dtgPlanillasProceso.Name = "dtgPlanillasProceso";
            this.dtgPlanillasProceso.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanillasProceso.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPlanillasProceso.RowHeadersVisible = false;
            this.dtgPlanillasProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillasProceso.Size = new System.Drawing.Size(600, 150);
            this.dtgPlanillasProceso.TabIndex = 2;
            this.dtgPlanillasProceso.DoubleClick += new System.EventHandler(this.dtgPlanillasProceso_DoubleClick);
            this.dtgPlanillasProceso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgPlanillasProceso_KeyDown);
            this.dtgPlanillasProceso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgPlanillasProceso_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(546, 167);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(483, 167);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtgtxtIdTipoRelLab
            // 
            this.dtgtxtIdTipoRelLab.DataPropertyName = "idTipoRelLab";
            this.dtgtxtIdTipoRelLab.HeaderText = "idTipoRelLab";
            this.dtgtxtIdTipoRelLab.Name = "dtgtxtIdTipoRelLab";
            this.dtgtxtIdTipoRelLab.ReadOnly = true;
            this.dtgtxtIdTipoRelLab.Visible = false;
            // 
            // dtgtxtTipoRelLab
            // 
            this.dtgtxtTipoRelLab.DataPropertyName = "cTipoRelLab";
            this.dtgtxtTipoRelLab.HeaderText = "Clasificación";
            this.dtgtxtTipoRelLab.MinimumWidth = 90;
            this.dtgtxtTipoRelLab.Name = "dtgtxtTipoRelLab";
            this.dtgtxtTipoRelLab.ReadOnly = true;
            // 
            // dtgtxtIdTipoPlanilla
            // 
            this.dtgtxtIdTipoPlanilla.DataPropertyName = "idTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.HeaderText = "idTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.Name = "dtgtxtIdTipoPlanilla";
            this.dtgtxtIdTipoPlanilla.ReadOnly = true;
            this.dtgtxtIdTipoPlanilla.Visible = false;
            // 
            // dtgtxtTipoPlanilla
            // 
            this.dtgtxtTipoPlanilla.DataPropertyName = "cTipoPlanilla";
            this.dtgtxtTipoPlanilla.HeaderText = "Tipo";
            this.dtgtxtTipoPlanilla.MinimumWidth = 120;
            this.dtgtxtTipoPlanilla.Name = "dtgtxtTipoPlanilla";
            this.dtgtxtTipoPlanilla.ReadOnly = true;
            // 
            // dtgtxtIdModalidad
            // 
            this.dtgtxtIdModalidad.DataPropertyName = "idModalidad";
            this.dtgtxtIdModalidad.HeaderText = "idModalidad";
            this.dtgtxtIdModalidad.Name = "dtgtxtIdModalidad";
            this.dtgtxtIdModalidad.ReadOnly = true;
            this.dtgtxtIdModalidad.Visible = false;
            // 
            // dtgtxtModalidad
            // 
            this.dtgtxtModalidad.DataPropertyName = "cModalidad";
            this.dtgtxtModalidad.HeaderText = "Modalidad";
            this.dtgtxtModalidad.MinimumWidth = 120;
            this.dtgtxtModalidad.Name = "dtgtxtModalidad";
            this.dtgtxtModalidad.ReadOnly = true;
            // 
            // dtgtxtIdPeriodoPlanilla
            // 
            this.dtgtxtIdPeriodoPlanilla.DataPropertyName = "idPeriodoPlanilla";
            this.dtgtxtIdPeriodoPlanilla.HeaderText = "idPeriodoPlanilla";
            this.dtgtxtIdPeriodoPlanilla.Name = "dtgtxtIdPeriodoPlanilla";
            this.dtgtxtIdPeriodoPlanilla.ReadOnly = true;
            this.dtgtxtIdPeriodoPlanilla.Visible = false;
            // 
            // dtgtxtPeriodoPlanilla
            // 
            this.dtgtxtPeriodoPlanilla.DataPropertyName = "cPeriodoPlanilla";
            this.dtgtxtPeriodoPlanilla.HeaderText = "Periodo Planilla";
            this.dtgtxtPeriodoPlanilla.MinimumWidth = 70;
            this.dtgtxtPeriodoPlanilla.Name = "dtgtxtPeriodoPlanilla";
            this.dtgtxtPeriodoPlanilla.ReadOnly = true;
            // 
            // dtgtxtIdPeriodoDeclaracion
            // 
            this.dtgtxtIdPeriodoDeclaracion.DataPropertyName = "idPeriodoDeclaracion";
            this.dtgtxtIdPeriodoDeclaracion.HeaderText = "idPeriodoDeclaracion";
            this.dtgtxtIdPeriodoDeclaracion.Name = "dtgtxtIdPeriodoDeclaracion";
            this.dtgtxtIdPeriodoDeclaracion.ReadOnly = true;
            this.dtgtxtIdPeriodoDeclaracion.Visible = false;
            // 
            // dtgtxtPeriodoDeclaracion
            // 
            this.dtgtxtPeriodoDeclaracion.DataPropertyName = "cPeriodoDeclaracion";
            this.dtgtxtPeriodoDeclaracion.HeaderText = "Periodo Declaración";
            this.dtgtxtPeriodoDeclaracion.MinimumWidth = 70;
            this.dtgtxtPeriodoDeclaracion.Name = "dtgtxtPeriodoDeclaracion";
            this.dtgtxtPeriodoDeclaracion.ReadOnly = true;
            // 
            // dtgtxtNumPersonPlanilla
            // 
            this.dtgtxtNumPersonPlanilla.DataPropertyName = "nNumPersonPlanilla";
            this.dtgtxtNumPersonPlanilla.HeaderText = "Nro Personas";
            this.dtgtxtNumPersonPlanilla.MinimumWidth = 60;
            this.dtgtxtNumPersonPlanilla.Name = "dtgtxtNumPersonPlanilla";
            this.dtgtxtNumPersonPlanilla.ReadOnly = true;
            // 
            // frmPlanillasTmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 246);
            this.ControlBox = false;
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgPlanillasProceso);
            this.Name = "frmPlanillasTmp";
            this.Text = "Planillas en Proceso";
            this.Load += new System.EventHandler(this.frmPlanillasTmp_Load);
            this.Controls.SetChildIndex(this.dtgPlanillasProceso, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillasProceso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgPlanillasProceso;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoRelLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoRelLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdModalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtModalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdPeriodoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtPeriodoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdPeriodoDeclaracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtPeriodoDeclaracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtNumPersonPlanilla;
    }
}

