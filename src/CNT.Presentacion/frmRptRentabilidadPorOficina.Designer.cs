namespace CNT.Presentacion
{
    partial class frmRptRentabilidadPorOficina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRentabilidadPorOficina));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblZona = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.chcOriginal = new GEN.ControlesBase.chcBase(this.components);
            this.chcDistri = new GEN.ControlesBase.chcBase(this.components);
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.rptHistorico = new System.Windows.Forms.RadioButton();
            this.rptMensual = new System.Windows.Forms.RadioButton();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.NumDig = new GEN.ControlesBase.nudBase(this.components);
            this.groupBox1.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDig)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(20, 29);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(45, 13);
            this.lblBase2.TabIndex = 40;
            this.lblBase2.Text = "Fecha:";
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblZona.ForeColor = System.Drawing.Color.Navy;
            this.lblZona.Location = new System.Drawing.Point(24, 57);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(41, 13);
            this.lblZona.TabIndex = 45;
            this.lblZona.Text = "Zona:";
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(172, 237);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 48;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(238, 237);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 49;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // chcOriginal
            // 
            this.chcOriginal.AutoSize = true;
            this.chcOriginal.Checked = true;
            this.chcOriginal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcOriginal.Location = new System.Drawing.Point(156, 146);
            this.chcOriginal.Name = "chcOriginal";
            this.chcOriginal.Size = new System.Drawing.Size(61, 17);
            this.chcOriginal.TabIndex = 52;
            this.chcOriginal.Text = "Original";
            this.chcOriginal.UseVisualStyleBackColor = true;
            this.chcOriginal.CheckedChanged += new System.EventHandler(this.chcOriginal_CheckedChanged);
            // 
            // chcDistri
            // 
            this.chcDistri.AutoSize = true;
            this.chcDistri.Location = new System.Drawing.Point(61, 146);
            this.chcDistri.Name = "chcDistri";
            this.chcDistri.Size = new System.Drawing.Size(75, 17);
            this.chcDistri.TabIndex = 51;
            this.chcDistri.Text = "Distribuido";
            this.chcDistri.UseVisualStyleBackColor = true;
            this.chcDistri.CheckedChanged += new System.EventHandler(this.chcDistri_CheckedChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(74, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 20);
            this.dtpFecha.TabIndex = 53;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Controls.Add(this.NumDig);
            this.groupBox1.Controls.Add(this.cboAgencias1);
            this.groupBox1.Controls.Add(this.cboZona1);
            this.groupBox1.Controls.Add(this.cboAnio);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.lblBase2);
            this.groupBox1.Controls.Add(this.chcOriginal);
            this.groupBox1.Controls.Add(this.lblZona);
            this.groupBox1.Controls.Add(this.chcDistri);
            this.groupBox1.Controls.Add(this.lblBase3);
            this.groupBox1.Location = new System.Drawing.Point(14, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 173);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Reporte";
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(74, 76);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(210, 21);
            this.cboAgencias1.TabIndex = 60;
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(74, 49);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(210, 21);
            this.cboZona1.TabIndex = 59;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged_1);
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(74, 22);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(129, 21);
            this.cboAnio.TabIndex = 58;
            this.cboAnio.Visible = false;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 84);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 47;
            this.lblBase3.Text = "Agencia:";
            // 
            // rptHistorico
            // 
            this.rptHistorico.AutoSize = true;
            this.rptHistorico.Location = new System.Drawing.Point(158, 19);
            this.rptHistorico.Name = "rptHistorico";
            this.rptHistorico.Size = new System.Drawing.Size(107, 17);
            this.rptHistorico.TabIndex = 56;
            this.rptHistorico.Text = "Reporte Histórico";
            this.rptHistorico.UseVisualStyleBackColor = true;
            this.rptHistorico.CheckedChanged += new System.EventHandler(this.rptHistorico_CheckedChanged);
            // 
            // rptMensual
            // 
            this.rptMensual.AutoSize = true;
            this.rptMensual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rptMensual.Checked = true;
            this.rptMensual.Location = new System.Drawing.Point(23, 19);
            this.rptMensual.Name = "rptMensual";
            this.rptMensual.Size = new System.Drawing.Size(104, 17);
            this.rptMensual.TabIndex = 55;
            this.rptMensual.TabStop = true;
            this.rptMensual.Text = "Reporte por Mes";
            this.rptMensual.UseVisualStyleBackColor = true;
            this.rptMensual.CheckedChanged += new System.EventHandler(this.rptMensual_CheckedChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.rptMensual);
            this.grbBase1.Controls.Add(this.rptHistorico);
            this.grbBase1.Location = new System.Drawing.Point(14, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(290, 40);
            this.grbBase1.TabIndex = 57;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Tipo de Reporte";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 112);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 61;
            this.lblBase1.Text = "Dígitos:";
            // 
            // NumDig
            // 
            this.NumDig.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumDig.Location = new System.Drawing.Point(74, 105);
            this.NumDig.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumDig.Name = "NumDig";
            this.NumDig.Size = new System.Drawing.Size(51, 20);
            this.NumDig.TabIndex = 62;
            this.NumDig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumDig.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // frmRptRentabilidadPorOficina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 323);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnImprimir1);
            this.Name = "frmRptRentabilidadPorOficina";
            this.Text = "Reporte de Rentabilidad por Oficina";
            this.Load += new System.EventHandler(this.frmRptContabilidad4_Load);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblZona;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.chcBase chcOriginal;
        private GEN.ControlesBase.chcBase chcDistri;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase3;
        private System.Windows.Forms.RadioButton rptHistorico;
        private System.Windows.Forms.RadioButton rptMensual;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.ComboBox cboAnio;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.nudBase NumDig;
    }
}