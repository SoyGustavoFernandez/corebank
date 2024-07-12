namespace GRH.Presentacion
{
    partial class frmAnulaPlanilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnulaPlanilla));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.cboRelacionLabInst = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgListaPlanillas = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtFechaPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPeriodoDeclaracion = new GEN.ControlesBase.cboPeriodoDeclaracion(this.components);
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPlanillas)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(268, 27);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 13;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 69);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(105, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Periodo de Pago:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(13, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Clasificación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(13, 46);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Tipo de Planilla:";
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(119, 42);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(140, 21);
            this.cboTipoPlanilla.TabIndex = 7;
            // 
            // cboRelacionLabInst
            // 
            this.cboRelacionLabInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst.FormattingEnabled = true;
            this.cboRelacionLabInst.Location = new System.Drawing.Point(119, 19);
            this.cboRelacionLabInst.Name = "cboRelacionLabInst";
            this.cboRelacionLabInst.Size = new System.Drawing.Size(140, 21);
            this.cboRelacionLabInst.TabIndex = 8;
            this.cboRelacionLabInst.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 107);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(122, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Seleccionar Planilla:";
            // 
            // dtgListaPlanillas
            // 
            this.dtgListaPlanillas.AllowUserToAddRows = false;
            this.dtgListaPlanillas.AllowUserToDeleteRows = false;
            this.dtgListaPlanillas.AllowUserToResizeColumns = false;
            this.dtgListaPlanillas.AllowUserToResizeRows = false;
            this.dtgListaPlanillas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListaPlanillas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgListaPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaPlanillas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdPlanilla,
            this.dtgtxtFechaPlanilla,
            this.dtgtxtModalidad});
            this.dtgListaPlanillas.Location = new System.Drawing.Point(8, 123);
            this.dtgListaPlanillas.MultiSelect = false;
            this.dtgListaPlanillas.Name = "dtgListaPlanillas";
            this.dtgListaPlanillas.ReadOnly = true;
            this.dtgListaPlanillas.RowHeadersVisible = false;
            this.dtgListaPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaPlanillas.Size = new System.Drawing.Size(340, 155);
            this.dtgListaPlanillas.TabIndex = 22;
            // 
            // dtgtxtIdPlanilla
            // 
            this.dtgtxtIdPlanilla.DataPropertyName = "idPlanilla";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgtxtIdPlanilla.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgtxtIdPlanilla.FillWeight = 30F;
            this.dtgtxtIdPlanilla.HeaderText = "Codigo";
            this.dtgtxtIdPlanilla.MinimumWidth = 60;
            this.dtgtxtIdPlanilla.Name = "dtgtxtIdPlanilla";
            this.dtgtxtIdPlanilla.ReadOnly = true;
            // 
            // dtgtxtFechaPlanilla
            // 
            this.dtgtxtFechaPlanilla.DataPropertyName = "dFechaPlanilla";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgtxtFechaPlanilla.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgtxtFechaPlanilla.FillWeight = 40F;
            this.dtgtxtFechaPlanilla.HeaderText = "Fecha";
            this.dtgtxtFechaPlanilla.MinimumWidth = 80;
            this.dtgtxtFechaPlanilla.Name = "dtgtxtFechaPlanilla";
            this.dtgtxtFechaPlanilla.ReadOnly = true;
            // 
            // dtgtxtModalidad
            // 
            this.dtgtxtModalidad.DataPropertyName = "cModalidad";
            this.dtgtxtModalidad.HeaderText = "Modalidad de Planilla";
            this.dtgtxtModalidad.MinimumWidth = 150;
            this.dtgtxtModalidad.Name = "dtgtxtModalidad";
            this.dtgtxtModalidad.ReadOnly = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnProcesar);
            this.grbBase1.Controls.Add(this.cboPeriodoDeclaracion);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboTipoPlanilla);
            this.grbBase1.Controls.Add(this.cboRelacionLabInst);
            this.grbBase1.Controls.Add(this.btnCancelar);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(8, 4);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(340, 97);
            this.grbBase1.TabIndex = 21;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione los Filtros: ";
            // 
            // cboPeriodoDeclaracion
            // 
            this.cboPeriodoDeclaracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoDeclaracion.FormattingEnabled = true;
            this.cboPeriodoDeclaracion.Location = new System.Drawing.Point(118, 65);
            this.cboPeriodoDeclaracion.Name = "cboPeriodoDeclaracion";
            this.cboPeriodoDeclaracion.Size = new System.Drawing.Size(140, 21);
            this.cboPeriodoDeclaracion.TabIndex = 14;
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Location = new System.Drawing.Point(213, 282);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 23;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(276, 282);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(268, 27);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAnulaPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 358);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtgListaPlanillas);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmAnulaPlanilla";
            this.Text = "Anulación de Planillas";
            this.Load += new System.EventHandler(this.frmAnulaPlanilla_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgListaPlanillas, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaPlanillas)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgListaPlanillas;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboPeriodoDeclaracion cboPeriodoDeclaracion;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtFechaPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtModalidad;
        private GEN.BotonesBase.btnCancelar btnCancelar;
    }
}

