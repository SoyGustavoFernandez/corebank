namespace GRH.Presentacion
{
    partial class frmEmisionBoletasRem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmisionBoletasRem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtgPlanillas1 = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtFechaPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPeriodo = new GEN.ControlesBase.cboPeriodoDeclaracion(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboTipoPlanilla1 = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.cboRelacionLabInst1 = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas1)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Enabled = false;
            this.btnImprimir1.Location = new System.Drawing.Point(211, 294);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 4;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(276, 294);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(52, 11);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(252, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "EMISIÓN DE BOLETAS DE REMUNERACIÓN";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(8, 141);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(128, 13);
            this.lblBase4.TabIndex = 20;
            this.lblBase4.Text = "Seleccionar Planillas:";
            // 
            // dtgPlanillas1
            // 
            this.dtgPlanillas1.AllowUserToAddRows = false;
            this.dtgPlanillas1.AllowUserToDeleteRows = false;
            this.dtgPlanillas1.AllowUserToResizeColumns = false;
            this.dtgPlanillas1.AllowUserToResizeRows = false;
            this.dtgPlanillas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanillas1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPlanillas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillas1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdPlanilla,
            this.dtgtxtFechaPlanilla,
            this.dtgtxtModalidad});
            this.dtgPlanillas1.Location = new System.Drawing.Point(8, 157);
            this.dtgPlanillas1.MultiSelect = false;
            this.dtgPlanillas1.Name = "dtgPlanillas1";
            this.dtgPlanillas1.ReadOnly = true;
            this.dtgPlanillas1.RowHeadersVisible = false;
            this.dtgPlanillas1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillas1.Size = new System.Drawing.Size(340, 132);
            this.dtgPlanillas1.TabIndex = 22;
            // 
            // dtgtxtIdPlanilla
            // 
            this.dtgtxtIdPlanilla.DataPropertyName = "idPlanilla";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgtxtIdPlanilla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgtxtIdPlanilla.FillWeight = 30F;
            this.dtgtxtIdPlanilla.HeaderText = "Código";
            this.dtgtxtIdPlanilla.MinimumWidth = 60;
            this.dtgtxtIdPlanilla.Name = "dtgtxtIdPlanilla";
            this.dtgtxtIdPlanilla.ReadOnly = true;
            // 
            // dtgtxtFechaPlanilla
            // 
            this.dtgtxtFechaPlanilla.DataPropertyName = "dFechaPlanilla";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgtxtFechaPlanilla.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.grbBase1.Controls.Add(this.cboPeriodo);
            this.grbBase1.Controls.Add(this.btnProcesar1);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.cboTipoPlanilla1);
            this.grbBase1.Controls.Add(this.cboRelacionLabInst1);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(8, 40);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(340, 95);
            this.grbBase1.TabIndex = 21;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione los Filtros: ";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(123, 67);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(135, 21);
            this.cboPeriodo.TabIndex = 14;
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(268, 29);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 13;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 70);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(105, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Periodo de Pago:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(12, 24);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(83, 13);
            this.lblBase6.TabIndex = 4;
            this.lblBase6.Text = "Clasificación:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(12, 47);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(98, 13);
            this.lblBase8.TabIndex = 9;
            this.lblBase8.Text = "Tipo de Planilla:";
            // 
            // cboTipoPlanilla1
            // 
            this.cboTipoPlanilla1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla1.FormattingEnabled = true;
            this.cboTipoPlanilla1.Location = new System.Drawing.Point(123, 44);
            this.cboTipoPlanilla1.Name = "cboTipoPlanilla1";
            this.cboTipoPlanilla1.Size = new System.Drawing.Size(135, 21);
            this.cboTipoPlanilla1.TabIndex = 7;
            // 
            // cboRelacionLabInst1
            // 
            this.cboRelacionLabInst1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst1.FormattingEnabled = true;
            this.cboRelacionLabInst1.Location = new System.Drawing.Point(123, 21);
            this.cboRelacionLabInst1.Name = "cboRelacionLabInst1";
            this.cboRelacionLabInst1.Size = new System.Drawing.Size(135, 21);
            this.cboRelacionLabInst1.TabIndex = 8;
            this.cboRelacionLabInst1.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst1_SelectedIndexChanged);
            // 
            // frmEmisionBoletasRem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 374);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgPlanillas1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmEmisionBoletasRem";
            this.Text = "Emisión de Boletas de Remuneración";
            this.Load += new System.EventHandler(this.frmEmisionBoletasRem_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgPlanillas1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas1)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtgBase dtgPlanillas1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla1;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst1;
        private GEN.ControlesBase.cboPeriodoDeclaracion cboPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtFechaPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtModalidad;
    }
}