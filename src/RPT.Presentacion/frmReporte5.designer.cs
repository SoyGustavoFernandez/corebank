namespace RPT.Presentacion
{
    partial class frmReporte5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporte5));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtpFecha = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtgListaReporte = new GEN.ControlesBase.dtgBase(this.components);
            this.cCodigoSBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAnexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fisico = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sucave = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lFisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lSucave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.lblBase1.TabIndex = 20;
            this.lblBase1.Text = "Fecha:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(655, 133);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(73, 16);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(107, 20);
            this.dtpFecha.TabIndex = 17;
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
            this.dtgListaReporte.Location = new System.Drawing.Point(15, 42);
            this.dtgListaReporte.MultiSelect = false;
            this.dtgListaReporte.Name = "dtgListaReporte";
            this.dtgListaReporte.ReadOnly = true;
            this.dtgListaReporte.RowHeadersVisible = false;
            this.dtgListaReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListaReporte.Size = new System.Drawing.Size(700, 85);
            this.dtgListaReporte.TabIndex = 21;
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
            // frmReporte5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 217);
            this.Controls.Add(this.dtgListaReporte);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtpFecha);
            this.Name = "frmReporte5";
            this.Text = "Cotización de Oferta y Demanda de Moneda Extranjera";
            this.Load += new System.EventHandler(this.frmReporte5_Load);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtgListaReporte, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtpCorto dtpFecha;
        private GEN.ControlesBase.dtgBase dtgListaReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigoSBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAnexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripcion;
        private System.Windows.Forms.DataGridViewButtonColumn Fisico;
        private System.Windows.Forms.DataGridViewButtonColumn sucave;
        private System.Windows.Forms.DataGridViewTextBoxColumn lFisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn lSucave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}