namespace GRH.Presentacion
{
    partial class frmRptPlanillas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptPlanillas));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboPeriodoPlanilla = new GEN.ControlesBase.cboPeriodoPlanilla(this.components);
            this.cboModalidadPlanilla = new GEN.ControlesBase.cboModalidadPlanilla(this.components);
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.cboRelacionLabInst = new GEN.ControlesBase.cboRelacionLabInst(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnProcesar1 = new GEN.BotonesBase.btnProcesar();
            this.dtgPlanillas = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimirRes = new GEN.BotonesBase.btnImprimir();
            this.btnImprimirDet = new GEN.BotonesBase.btnImprimir();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 24);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Clasificación:";
            // 
            // cboPeriodoPlanilla
            // 
            this.cboPeriodoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoPlanilla.FormattingEnabled = true;
            this.cboPeriodoPlanilla.Location = new System.Drawing.Point(119, 67);
            this.cboPeriodoPlanilla.Name = "cboPeriodoPlanilla";
            this.cboPeriodoPlanilla.Size = new System.Drawing.Size(150, 21);
            this.cboPeriodoPlanilla.TabIndex = 3;
            // 
            // cboModalidadPlanilla
            // 
            this.cboModalidadPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadPlanilla.FormattingEnabled = true;
            this.cboModalidadPlanilla.Location = new System.Drawing.Point(119, 90);
            this.cboModalidadPlanilla.Name = "cboModalidadPlanilla";
            this.cboModalidadPlanilla.Size = new System.Drawing.Size(150, 21);
            this.cboModalidadPlanilla.TabIndex = 4;
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(119, 44);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(150, 21);
            this.cboTipoPlanilla.TabIndex = 2;
            this.cboTipoPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla1_SelectedIndexChanged);
            // 
            // cboRelacionLabInst
            // 
            this.cboRelacionLabInst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelacionLabInst.FormattingEnabled = true;
            this.cboRelacionLabInst.Location = new System.Drawing.Point(119, 21);
            this.cboRelacionLabInst.Name = "cboRelacionLabInst";
            this.cboRelacionLabInst.Size = new System.Drawing.Size(150, 21);
            this.cboRelacionLabInst.TabIndex = 1;
            this.cboRelacionLabInst.SelectedIndexChanged += new System.EventHandler(this.cboRelacionLabInst1_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Tipo de Planilla:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 93);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 11;
            this.lblBase4.Text = "Modalidad:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 70);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(55, 13);
            this.lblBase5.TabIndex = 12;
            this.lblBase5.Text = "Periodo:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnProcesar1);
            this.grbBase1.Controls.Add(this.cboModalidadPlanilla);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.cboPeriodoPlanilla);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboTipoPlanilla);
            this.grbBase1.Controls.Add(this.cboRelacionLabInst);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(350, 127);
            this.grbBase1.TabIndex = 13;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Seleccione los Filtros: ";
            // 
            // btnProcesar1
            // 
            this.btnProcesar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar1.BackgroundImage")));
            this.btnProcesar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar1.Location = new System.Drawing.Point(278, 44);
            this.btnProcesar1.Name = "btnProcesar1";
            this.btnProcesar1.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar1.TabIndex = 5;
            this.btnProcesar1.Text = "&Procesar";
            this.btnProcesar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar1.UseVisualStyleBackColor = true;
            this.btnProcesar1.Click += new System.EventHandler(this.btnProcesar1_Click);
            // 
            // dtgPlanillas
            // 
            this.dtgPlanillas.AllowUserToAddRows = false;
            this.dtgPlanillas.AllowUserToDeleteRows = false;
            this.dtgPlanillas.AllowUserToResizeColumns = false;
            this.dtgPlanillas.AllowUserToResizeRows = false;
            this.dtgPlanillas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlanillas.Location = new System.Drawing.Point(7, 150);
            this.dtgPlanillas.MultiSelect = false;
            this.dtgPlanillas.Name = "dtgPlanillas";
            this.dtgPlanillas.ReadOnly = true;
            this.dtgPlanillas.RowHeadersVisible = false;
            this.dtgPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlanillas.Size = new System.Drawing.Size(350, 94);
            this.dtgPlanillas.TabIndex = 14;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(7, 135);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(128, 13);
            this.lblBase3.TabIndex = 13;
            this.lblBase3.Text = "Seleccionar Planillas:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(285, 250);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimirRes
            // 
            this.btnImprimirRes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirRes.BackgroundImage")));
            this.btnImprimirRes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirRes.Enabled = false;
            this.btnImprimirRes.Location = new System.Drawing.Point(157, 250);
            this.btnImprimirRes.Name = "btnImprimirRes";
            this.btnImprimirRes.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirRes.TabIndex = 6;
            this.btnImprimirRes.Text = "&Resumen";
            this.btnImprimirRes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirRes.UseVisualStyleBackColor = true;
            this.btnImprimirRes.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnImprimirDet
            // 
            this.btnImprimirDet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimirDet.BackgroundImage")));
            this.btnImprimirDet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimirDet.Location = new System.Drawing.Point(221, 250);
            this.btnImprimirDet.Name = "btnImprimirDet";
            this.btnImprimirDet.Size = new System.Drawing.Size(60, 50);
            this.btnImprimirDet.TabIndex = 15;
            this.btnImprimirDet.Text = "&Detalle";
            this.btnImprimirDet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimirDet.UseVisualStyleBackColor = true;
            this.btnImprimirDet.Click += new System.EventHandler(this.btnImprimirDet_Click);
            // 
            // frmRptPlanillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 330);
            this.Controls.Add(this.btnImprimirDet);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtgPlanillas);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimirRes);
            this.Name = "frmRptPlanillas";
            this.Text = "Reporte de Planillas";
            this.Load += new System.EventHandler(this.frmRptPlanillas_Load);
            this.Controls.SetChildIndex(this.btnImprimirRes, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgPlanillas, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimirDet, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlanillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimirRes;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboPeriodoPlanilla cboPeriodoPlanilla;
        private GEN.ControlesBase.cboModalidadPlanilla cboModalidadPlanilla;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.cboRelacionLabInst cboRelacionLabInst;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnProcesar btnProcesar1;
        private GEN.ControlesBase.dtgBase dtgPlanillas;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnImprimir btnImprimirDet;
    }
}