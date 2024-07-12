namespace CNT.Presentacion
{
    partial class frmExportaLibroElectronico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportaLibroElectronico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgListaReporte = new GEN.ControlesBase.dtgBase(this.components);
            this.idLibroElec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCodLibroSBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fisico = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cNombreLibroTxt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(889, 272);
            this.btnSalir1.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
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
            this.idLibroElec,
            this.cCodLibroSBS,
            this.cDescripcion,
            this.cNombreSp,
            this.Fisico,
            this.cNombreLibroTxt});
            this.dtgListaReporte.Location = new System.Drawing.Point(16, 41);
            this.dtgListaReporte.Margin = new System.Windows.Forms.Padding(4);
            this.dtgListaReporte.MultiSelect = false;
            this.dtgListaReporte.Name = "dtgListaReporte";
            this.dtgListaReporte.ReadOnly = true;
            this.dtgListaReporte.RowHeadersVisible = false;
            this.dtgListaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaReporte.Size = new System.Drawing.Size(933, 223);
            this.dtgListaReporte.TabIndex = 1;
            this.dtgListaReporte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaReporte_CellClick);
            // 
            // idLibroElec
            // 
            this.idLibroElec.DataPropertyName = "idLibroElec";
            this.idLibroElec.HeaderText = "idLibroElec";
            this.idLibroElec.Name = "idLibroElec";
            this.idLibroElec.ReadOnly = true;
            this.idLibroElec.Visible = false;
            // 
            // cCodLibroSBS
            // 
            this.cCodLibroSBS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cCodLibroSBS.DataPropertyName = "cCodLibroSBS";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCodLibroSBS.DefaultCellStyle = dataGridViewCellStyle2;
            this.cCodLibroSBS.FillWeight = 88.1016F;
            this.cCodLibroSBS.HeaderText = "Cod SBS";
            this.cCodLibroSBS.Name = "cCodLibroSBS";
            this.cCodLibroSBS.ReadOnly = true;
            this.cCodLibroSBS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cCodLibroSBS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cCodLibroSBS.Width = 60;
            // 
            // cDescripcion
            // 
            this.cDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDescripcion.DataPropertyName = "cDescripcion";
            this.cDescripcion.FillWeight = 200F;
            this.cDescripcion.HeaderText = "Descripción";
            this.cDescripcion.Name = "cDescripcion";
            this.cDescripcion.ReadOnly = true;
            this.cDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cDescripcion.Width = 780;
            // 
            // cNombreSp
            // 
            this.cNombreSp.DataPropertyName = "cNombreSp";
            this.cNombreSp.HeaderText = "cNombreSp";
            this.cNombreSp.Name = "cNombreSp";
            this.cNombreSp.ReadOnly = true;
            this.cNombreSp.Visible = false;
            // 
            // Fisico
            // 
            this.Fisico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Fisico.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fisico.FillWeight = 22.45998F;
            this.Fisico.HeaderText = "Físico";
            this.Fisico.Name = "Fisico";
            this.Fisico.ReadOnly = true;
            this.Fisico.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Fisico.Width = 55;
            // 
            // cNombreLibroTxt
            // 
            this.cNombreLibroTxt.DataPropertyName = "cNombreLibroTxt";
            this.cNombreLibroTxt.HeaderText = "cNombreLibroTxt";
            this.cNombreLibroTxt.Name = "cNombreLibroTxt";
            this.cNombreLibroTxt.ReadOnly = true;
            this.cNombreLibroTxt.Visible = false;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(20, 14);
            this.lblBase2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(54, 17);
            this.lblBase2.TabIndex = 20;
            this.lblBase2.Text = "Fecha:";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(82, 11);
            this.dtpFecFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(125, 22);
            this.dtpFecFin.TabIndex = 18;
            // 
            // frmExportaLibroElectronico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 351);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtgListaReporte);
            this.Controls.Add(this.btnSalir1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmExportaLibroElectronico";
            this.Text = "Genera exportación libros electronicos formato txt Inventario - Balance";
            this.Load += new System.EventHandler(this.frmExportaLibroElectronico_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgListaReporte, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgListaReporte;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLibroElec;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodLibroSBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreSp;
        private System.Windows.Forms.DataGridViewButtonColumn Fisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreLibroTxt;
    }
}