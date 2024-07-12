namespace RSG.Presentacion
{
    partial class frmRptRiesgosGral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRiesgosGral));
            this.dFechaIni = new GEN.ControlesBase.DatePicker();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dFechaFin = new GEN.ControlesBase.DatePicker();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboDias = new GEN.ControlesBase.cboBase(this.components);
            this.lblDias = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtNumerico(this.components);
            this.lblMonto = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgReportes = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportes)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dFechaIni
            // 
            this.dFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaIni.Location = new System.Drawing.Point(11, 41);
            this.dFechaIni.Name = "dFechaIni";
            this.dFechaIni.Size = new System.Drawing.Size(111, 20);
            this.dFechaIni.TabIndex = 19;
            this.dFechaIni.Value = new System.DateTime(2016, 8, 11, 18, 46, 13, 629);
            // 
            // lblBase1
            // 
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(82, 17);
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Inicio:";
            // 
            // lblBase2
            // 
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(142, 21);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(82, 17);
            this.lblBase2.TabIndex = 22;
            this.lblBase2.Text = "Fin:";
            // 
            // dFechaFin
            // 
            this.dFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFechaFin.Location = new System.Drawing.Point(141, 41);
            this.dFechaFin.Name = "dFechaFin";
            this.dFechaFin.Size = new System.Drawing.Size(111, 20);
            this.dFechaFin.TabIndex = 21;
            this.dFechaFin.Value = new System.DateTime(2016, 8, 11, 18, 46, 13, 629);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 50);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(51, 13);
            this.lblBase3.TabIndex = 24;
            this.lblBase3.Text = "Oficina:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dFechaFin);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.dFechaIni);
            this.grbBase1.Location = new System.Drawing.Point(415, 7);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(260, 68);
            this.grbBase1.TabIndex = 25;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Fecha de Desembolso";
            // 
            // cboDias
            // 
            this.cboDias.FormattingEnabled = true;
            this.cboDias.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboDias.Location = new System.Drawing.Point(134, 107);
            this.cboDias.Name = "cboDias";
            this.cboDias.Size = new System.Drawing.Size(111, 21);
            this.cboDias.TabIndex = 28;
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDias.ForeColor = System.Drawing.Color.Navy;
            this.lblDias.Location = new System.Drawing.Point(131, 91);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(37, 13);
            this.lblDias.TabIndex = 27;
            this.lblDias.Text = "Días:";
            // 
            // txtMonto
            // 
            this.txtMonto.Format = "n2";
            this.txtMonto.Location = new System.Drawing.Point(11, 108);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 26;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMonto.ForeColor = System.Drawing.Color.Navy;
            this.lblMonto.Location = new System.Drawing.Point(8, 92);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(46, 13);
            this.lblMonto.TabIndex = 25;
            this.lblMonto.Text = "Monto:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(549, 216);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 1;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgReportes
            // 
            this.dtgReportes.AllowUserToAddRows = false;
            this.dtgReportes.AllowUserToDeleteRows = false;
            this.dtgReportes.AllowUserToResizeColumns = false;
            this.dtgReportes.AllowUserToResizeRows = false;
            this.dtgReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReportes.Location = new System.Drawing.Point(2, 7);
            this.dtgReportes.MultiSelect = false;
            this.dtgReportes.Name = "dtgReportes";
            this.dtgReportes.ReadOnly = true;
            this.dtgReportes.RowHeadersVisible = false;
            this.dtgReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgReportes.Size = new System.Drawing.Size(409, 203);
            this.dtgReportes.TabIndex = 28;
            this.dtgReportes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgReportes_CellMouseDoubleClick);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboAgencias1);
            this.grbBase2.Controls.Add(this.cboZona1);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.cboDias);
            this.grbBase2.Controls.Add(this.txtMonto);
            this.grbBase2.Controls.Add(this.lblDias);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblMonto);
            this.grbBase2.Location = new System.Drawing.Point(415, 74);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(261, 136);
            this.grbBase2.TabIndex = 29;
            this.grbBase2.TabStop = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(8, 7);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(41, 13);
            this.lblBase4.TabIndex = 30;
            this.lblBase4.Text = "Zona:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(483, 216);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 3;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(11, 24);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(234, 21);
            this.cboZona1.TabIndex = 32;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(11, 67);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(234, 21);
            this.cboAgencias1.TabIndex = 33;
            // 
            // frmRptRiesgosGral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 293);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.dtgReportes);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptRiesgosGral";
            this.Text = "Reportes Riesgos General";
            this.Load += new System.EventHandler(this.frmRptRiesgosGral_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.dtgReportes, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReportes)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.DatePicker dFechaIni;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.DatePicker dFechaFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboBase cboDias;
        private GEN.ControlesBase.lblBase lblDias;
        private GEN.ControlesBase.txtNumerico txtMonto;
        private GEN.ControlesBase.lblBase lblMonto;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgReportes;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;

    }
}