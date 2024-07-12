namespace GRH.Presentacion
{
    partial class frmRptCtasContablesPlanilla
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCtasContablesPlanilla));
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtgPlanillas1 = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtFechaPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboPeriodo = new GEN.ControlesBase.cboPeriodoDeclaracion(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.cboRelacionLabInst = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas1)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(8, 142);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(128, 13);
            this.lblBase4.TabIndex = 26;
            this.lblBase4.Text = "Seleccionar Planillas:";
            // 
            // dtgPlanillas1
            // 
            this.dtgPlanillas1.AllowUserToAddRows = false;
            this.dtgPlanillas1.AllowUserToDeleteRows = false;
            this.dtgPlanillas1.AllowUserToResizeColumns = false;
            this.dtgPlanillas1.AllowUserToResizeRows = false;
            this.dtgPlanillas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlanillas1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgPlanillas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillas1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdPlanilla,
            this.dtgtxtFechaPlanilla,
            this.dtgtxtModalidad});
            this.dtgPlanillas1.Location = new System.Drawing.Point(8, 158);
            this.dtgPlanillas1.MultiSelect = false;
            this.dtgPlanillas1.Name = "dtgPlanillas1";
            this.dtgPlanillas1.ReadOnly = true;
            this.dtgPlanillas1.RowHeadersVisible = false;
            this.dtgPlanillas1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillas1.Size = new System.Drawing.Size(340, 132);
            this.dtgPlanillas1.TabIndex = 28;
            // 
            // dtgtxtIdPlanilla
            // 
            this.dtgtxtIdPlanilla.DataPropertyName = "idPlanilla";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgtxtIdPlanilla.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgtxtIdPlanilla.FillWeight = 30F;
            this.dtgtxtIdPlanilla.HeaderText = "Código";
            this.dtgtxtIdPlanilla.MinimumWidth = 60;
            this.dtgtxtIdPlanilla.Name = "dtgtxtIdPlanilla";
            this.dtgtxtIdPlanilla.ReadOnly = true;
            // 
            // dtgtxtFechaPlanilla
            // 
            this.dtgtxtFechaPlanilla.DataPropertyName = "dFechaPlanilla";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgtxtFechaPlanilla.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.grbBase1.Controls.Add(this.btnProcesar);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.cboTipoPlanilla);
            this.grbBase1.Controls.Add(this.cboRelacionLabInst);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(8, 41);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(340, 95);
            this.grbBase1.TabIndex = 27;
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
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(268, 29);
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
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(123, 44);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(135, 21);
            this.cboTipoPlanilla.TabIndex = 7;
            // 
            // cboRelacionLabInst
            // 
            this.cboRelacionLabInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst.FormattingEnabled = true;
            this.cboRelacionLabInst.Location = new System.Drawing.Point(123, 21);
            this.cboRelacionLabInst.Name = "cboRelacionLabInst";
            this.cboRelacionLabInst.Size = new System.Drawing.Size(135, 21);
            this.cboRelacionLabInst.TabIndex = 8;
            this.cboRelacionLabInst.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(46, 12);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(264, 13);
            this.lblBase2.TabIndex = 25;
            this.lblBase2.Text = "SALDOS CUENTAS CONTABLE POR PLANILLA";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(276, 295);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 24;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(211, 295);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 23;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmRptCtasContablesPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 374);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtgPlanillas1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmRptCtasContablesPlanilla";
            this.Text = "Saldos de cuentas contables por planilla";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
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

        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.dtgBase dtgPlanillas1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtFechaPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtModalidad;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboPeriodoDeclaracion cboPeriodo;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir;

    }
}

