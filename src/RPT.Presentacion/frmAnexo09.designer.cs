namespace RPT.Presentacion
{
    partial class frmAnexo09
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnexo09));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnImportar1 = new GEN.BotonesBase.btnImportar();
            this.dtgSeriesTC = new GEN.ControlesBase.dtgBase(this.components);
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArchivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnExporExcel1 = new GEN.BotonesBase.btnExporExcel();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnExportar1 = new GEN.BotonesBase.btnExportar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtUltFec = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeriesTC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(278, 262);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(410, 262);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(136, 291);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(107, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(7, 295);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(94, 13);
            this.lblBase4.TabIndex = 19;
            this.lblBase4.Text = "Fecha Proceso:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnImportar1);
            this.grbBase1.Controls.Add(this.dtgSeriesTC);
            this.grbBase1.Controls.Add(this.txtArchivo);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnExporExcel1);
            this.grbBase1.Location = new System.Drawing.Point(7, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(484, 236);
            this.grbBase1.TabIndex = 22;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Carga datos";
            // 
            // btnImportar1
            // 
            this.btnImportar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImportar1.BackgroundImage")));
            this.btnImportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImportar1.Enabled = false;
            this.btnImportar1.Location = new System.Drawing.Point(381, 173);
            this.btnImportar1.Name = "btnImportar1";
            this.btnImportar1.Size = new System.Drawing.Size(60, 50);
            this.btnImportar1.TabIndex = 3;
            this.btnImportar1.Text = "&Importar";
            this.btnImportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar1.UseVisualStyleBackColor = false;
            this.btnImportar1.Click += new System.EventHandler(this.btnImportar1_Click);
            // 
            // dtgSeriesTC
            // 
            this.dtgSeriesTC.AllowUserToAddRows = false;
            this.dtgSeriesTC.AllowUserToDeleteRows = false;
            this.dtgSeriesTC.AllowUserToResizeColumns = false;
            this.dtgSeriesTC.AllowUserToResizeRows = false;
            this.dtgSeriesTC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSeriesTC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgSeriesTC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSeriesTC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.TipoCambio});
            this.dtgSeriesTC.Location = new System.Drawing.Point(110, 86);
            this.dtgSeriesTC.MultiSelect = false;
            this.dtgSeriesTC.Name = "dtgSeriesTC";
            this.dtgSeriesTC.ReadOnly = true;
            this.dtgSeriesTC.RowHeadersVisible = false;
            this.dtgSeriesTC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSeriesTC.Size = new System.Drawing.Size(265, 137);
            this.dtgSeriesTC.TabIndex = 2;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "dFecha";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle5;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // TipoCambio
            // 
            this.TipoCambio.DataPropertyName = "nTipoCambio";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle6;
            this.TipoCambio.HeaderText = "Tipo de Cambio";
            this.TipoCambio.Name = "TipoCambio";
            this.TipoCambio.ReadOnly = true;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Enabled = false;
            this.txtArchivo.Location = new System.Drawing.Point(97, 47);
            this.txtArchivo.Multiline = true;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(366, 33);
            this.txtArchivo.TabIndex = 1;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(94, 31);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(103, 13);
            this.lblBase2.TabIndex = 25;
            this.lblBase2.Text = "Archivo exportar";
            // 
            // btnExporExcel1
            // 
            this.btnExporExcel1.BackColor = System.Drawing.SystemColors.Control;
            this.btnExporExcel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExporExcel1.BackgroundImage")));
            this.btnExporExcel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporExcel1.Location = new System.Drawing.Point(21, 31);
            this.btnExporExcel1.Name = "btnExporExcel1";
            this.btnExporExcel1.Size = new System.Drawing.Size(60, 50);
            this.btnExporExcel1.TabIndex = 0;
            this.btnExporExcel1.Text = "E&xcel";
            this.btnExporExcel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExporExcel1.UseVisualStyleBackColor = false;
            this.btnExporExcel1.Click += new System.EventHandler(this.btnExporExcel1_Click_1);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 269);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(113, 13);
            this.lblBase1.TabIndex = 23;
            this.lblBase1.Text = "Fecha último dato:";
            // 
            // btnExportar1
            // 
            this.btnExportar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnExportar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar1.BackgroundImage")));
            this.btnExportar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExportar1.Location = new System.Drawing.Point(344, 262);
            this.btnExportar1.Name = "btnExportar1";
            this.btnExportar1.Size = new System.Drawing.Size(60, 50);
            this.btnExportar1.TabIndex = 2;
            this.btnExportar1.Text = "E&xportar";
            this.btnExportar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar1.UseVisualStyleBackColor = false;
            this.btnExportar1.Click += new System.EventHandler(this.btnExportar1_Click);
            // 
            // txtUltFec
            // 
            this.txtUltFec.Enabled = false;
            this.txtUltFec.Location = new System.Drawing.Point(136, 261);
            this.txtUltFec.Name = "txtUltFec";
            this.txtUltFec.Size = new System.Drawing.Size(107, 20);
            this.txtUltFec.TabIndex = 24;
            this.txtUltFec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmAnexo09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 343);
            this.Controls.Add(this.txtUltFec);
            this.Controls.Add(this.btnExportar1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmAnexo09";
            this.Text = "Riesgo Cambiario";
            this.Load += new System.EventHandler(this.frmAnexo09_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnExportar1, 0);
            this.Controls.SetChildIndex(this.txtUltFec, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSeriesTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnImportar btnImportar1;
        private GEN.ControlesBase.dtgBase dtgSeriesTC;
        private GEN.ControlesBase.txtBase txtArchivo;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnExporExcel btnExporExcel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCambio;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnExportar btnExportar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.txtBase txtUltFec;
    }
}