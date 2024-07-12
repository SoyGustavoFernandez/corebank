namespace RPT.Presentacion
{
    partial class frmReporte2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporte2));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgListaReporte = new GEN.ControlesBase.dtgBase(this.components);
            this.cCodigoSBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAnexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fisico = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sucave = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lFisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lSucave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtFacAju = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtLimGlo = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtPatEfeAdi = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtLimGloBC = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(45, 13);
            this.lblBase1.TabIndex = 30;
            this.lblBase1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(73, 15);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(101, 20);
            this.dtpFecha.TabIndex = 0;
            // 
            // dtgListaReporte
            // 
            this.dtgListaReporte.AllowUserToAddRows = false;
            this.dtgListaReporte.AllowUserToDeleteRows = false;
            this.dtgListaReporte.AllowUserToResizeColumns = false;
            this.dtgListaReporte.AllowUserToResizeRows = false;
            this.dtgListaReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgListaReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgListaReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgListaReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCodigoSBS,
            this.cAnexo,
            this.cDescripcion,
            this.Fisico,
            this.sucave,
            this.lFisico,
            this.lSucave});
            this.dtgListaReporte.Location = new System.Drawing.Point(9, 62);
            this.dtgListaReporte.MultiSelect = false;
            this.dtgListaReporte.Name = "dtgListaReporte";
            this.dtgListaReporte.ReadOnly = true;
            this.dtgListaReporte.RowHeadersVisible = false;
            this.dtgListaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaReporte.Size = new System.Drawing.Size(716, 179);
            this.dtgListaReporte.TabIndex = 3;
            this.dtgListaReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaReporte_CellContentClick);
            // 
            // cCodigoSBS
            // 
            this.cCodigoSBS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cCodigoSBS.DataPropertyName = "cCodigoSBS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCodigoSBS.DefaultCellStyle = dataGridViewCellStyle2;
            this.cCodigoSBS.FillWeight = 88.1016F;
            this.cCodigoSBS.HeaderText = "Cod SBS";
            this.cCodigoSBS.Name = "cCodigoSBS";
            this.cCodigoSBS.ReadOnly = true;
            this.cCodigoSBS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cCodigoSBS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cCodigoSBS.Width = 60;
            // 
            // cAnexo
            // 
            this.cAnexo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cAnexo.DataPropertyName = "cAnexo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cAnexo.DefaultCellStyle = dataGridViewCellStyle3;
            this.cAnexo.FillWeight = 121.7856F;
            this.cAnexo.HeaderText = "Anexo";
            this.cAnexo.Name = "cAnexo";
            this.cAnexo.ReadOnly = true;
            this.cAnexo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cAnexo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cAnexo.Width = 60;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.FillWeight = 142.7493F;
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            this.cDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cDescripcion.Width = 466;
            // 
            // Fisico
            // 
            this.Fisico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Fisico.DefaultCellStyle = dataGridViewCellStyle4;
            this.Fisico.FillWeight = 22.45998F;
            this.Fisico.HeaderText = "Físico";
            this.Fisico.Name = "Fisico";
            this.Fisico.ReadOnly = true;
            this.Fisico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Fisico.Width = 55;
            // 
            // sucave
            // 
            this.sucave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sucave.DefaultCellStyle = dataGridViewCellStyle5;
            this.sucave.FillWeight = 24.76613F;
            this.sucave.HeaderText = "SUCAVE";
            this.sucave.Name = "sucave";
            this.sucave.ReadOnly = true;
            this.sucave.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sucave.Width = 55;
            // 
            // lFisico
            // 
            this.lFisico.DataPropertyName = "lFisico";
            this.lFisico.HeaderText = "lFisico";
            this.lFisico.Name = "lFisico";
            this.lFisico.ReadOnly = true;
            this.lFisico.Visible = false;
            // 
            // lSucave
            // 
            this.lSucave.DataPropertyName = "lSucave";
            this.lSucave.HeaderText = "lSucave";
            this.lSucave.Name = "lSucave";
            this.lSucave.ReadOnly = true;
            this.lSucave.Visible = false;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(665, 247);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 4;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(356, 18);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(103, 13);
            this.lblBase2.TabIndex = 32;
            this.lblBase2.Text = "Factor de ajuste:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(180, 19);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(109, 13);
            this.lblBase3.TabIndex = 33;
            this.lblBase3.Text = "Límite global A D:";
            // 
            // txtFacAju
            // 
            this.txtFacAju.FormatoDecimal = true;
            this.txtFacAju.Location = new System.Drawing.Point(465, 14);
            this.txtFacAju.Name = "txtFacAju";
            this.txtFacAju.nDecValor = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.txtFacAju.nNumDecimales = 2;
            this.txtFacAju.nvalor = 1D;
            this.txtFacAju.Size = new System.Drawing.Size(40, 20);
            this.txtFacAju.TabIndex = 2;
            this.txtFacAju.Text = "1.00";
            this.txtFacAju.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLimGlo
            // 
            this.txtLimGlo.Enabled = false;
            this.txtLimGlo.FormatoDecimal = true;
            this.txtLimGlo.Location = new System.Drawing.Point(289, 15);
            this.txtLimGlo.Name = "txtLimGlo";
            this.txtLimGlo.nDecValor = new decimal(new int[] {
            1000,
            0,
            0,
            131072});
            this.txtLimGlo.nNumDecimales = 2;
            this.txtLimGlo.nvalor = 10D;
            this.txtLimGlo.Size = new System.Drawing.Size(50, 20);
            this.txtLimGlo.TabIndex = 1;
            this.txtLimGlo.Text = "10.00";
            this.txtLimGlo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(338, 18);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(19, 13);
            this.lblBase4.TabIndex = 34;
            this.lblBase4.Text = "%";
            // 
            // txtPatEfeAdi
            // 
            this.txtPatEfeAdi.FormatoDecimal = true;
            this.txtPatEfeAdi.Location = new System.Drawing.Point(628, 13);
            this.txtPatEfeAdi.Name = "txtPatEfeAdi";
            this.txtPatEfeAdi.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPatEfeAdi.nNumDecimales = 2;
            this.txtPatEfeAdi.nvalor = 0D;
            this.txtPatEfeAdi.Size = new System.Drawing.Size(97, 20);
            this.txtPatEfeAdi.TabIndex = 35;
            this.txtPatEfeAdi.Text = "0.00";
            this.txtPatEfeAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(508, 17);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(114, 13);
            this.lblBase5.TabIndex = 36;
            this.lblBase5.Text = "Pat. Efe. adicional:";
            // 
            // txtLimGloBC
            // 
            this.txtLimGloBC.Enabled = false;
            this.txtLimGloBC.FormatoDecimal = true;
            this.txtLimGloBC.Location = new System.Drawing.Point(289, 37);
            this.txtLimGloBC.Name = "txtLimGloBC";
            this.txtLimGloBC.nDecValor = new decimal(new int[] {
            1000,
            0,
            0,
            131072});
            this.txtLimGloBC.nNumDecimales = 2;
            this.txtLimGloBC.nvalor = 10D;
            this.txtLimGloBC.Size = new System.Drawing.Size(50, 20);
            this.txtLimGloBC.TabIndex = 37;
            this.txtLimGloBC.Text = "10.00";
            this.txtLimGloBC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(180, 41);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(109, 13);
            this.lblBase6.TabIndex = 38;
            this.lblBase6.Text = "Límite global B C:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(338, 40);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(19, 13);
            this.lblBase7.TabIndex = 39;
            this.lblBase7.Text = "%";
            // 
            // frmReporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 328);
            this.Controls.Add(this.txtLimGloBC);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.txtPatEfeAdi);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtLimGlo);
            this.Controls.Add(this.txtFacAju);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dtgListaReporte);
            this.Controls.Add(this.lblBase4);
            this.Name = "frmReporte2";
            this.Text = "Activos y Contingentes Ponderados por Riesgo de Crédito";
            this.Load += new System.EventHandler(this.frmReporte2_Load);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.dtgListaReporte, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtFacAju, 0);
            this.Controls.SetChildIndex(this.txtLimGlo, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtPatEfeAdi, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtLimGloBC, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.dtgBase dtgListaReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigoSBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAnexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewButtonColumn Fisico;
        private System.Windows.Forms.DataGridViewButtonColumn sucave;
        private System.Windows.Forms.DataGridViewTextBoxColumn lFisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn lSucave;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtFacAju;
        private GEN.ControlesBase.txtNumRea txtLimGlo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtPatEfeAdi;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtLimGloBC;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
    }
}