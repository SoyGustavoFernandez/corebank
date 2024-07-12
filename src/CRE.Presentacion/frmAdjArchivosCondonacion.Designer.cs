namespace CRE.Presentacion
{
    partial class frmAdjArchivosCondonacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjArchivosCondonacion));
            this.dtgFiles = new GEN.ControlesBase.dtgBase(this.components);
            this.cDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDeleteFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lEstado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vDocBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewFile = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.contPdf = new AxAcroPDFLib.AxAcroPDF();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFile = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgFiles
            // 
            this.dtgFiles.AllowUserToAddRows = false;
            this.dtgFiles.AllowUserToDeleteRows = false;
            this.dtgFiles.AllowUserToResizeColumns = false;
            this.dtgFiles.AllowUserToResizeRows = false;
            this.dtgFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDocumento,
            this.cNombreDoc,
            this.btnAddFile,
            this.btnDeleteFile,
            this.lEstado,
            this.idTipoDoc,
            this.vDocBase,
            this.cExtencion,
            this.btnViewFile});
            this.dtgFiles.Location = new System.Drawing.Point(3, 0);
            this.dtgFiles.MultiSelect = false;
            this.dtgFiles.Name = "dtgFiles";
            this.dtgFiles.ReadOnly = true;
            this.dtgFiles.RowHeadersVisible = false;
            this.dtgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFiles.Size = new System.Drawing.Size(738, 90);
            this.dtgFiles.TabIndex = 2;
            this.dtgFiles.CurrentCellChanged += new System.EventHandler(this.dtgFiles_CurrentCellChanged);
            // 
            // cDocumento
            // 
            this.cDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDocumento.DataPropertyName = "cDocumento";
            this.cDocumento.FillWeight = 35.69498F;
            this.cDocumento.HeaderText = "Tipo de Documento";
            this.cDocumento.Name = "cDocumento";
            this.cDocumento.ReadOnly = true;
            this.cDocumento.Width = 150;
            // 
            // cNombreDoc
            // 
            this.cNombreDoc.DataPropertyName = "cNombreDoc";
            this.cNombreDoc.FillWeight = 271.2818F;
            this.cNombreDoc.HeaderText = "Documento";
            this.cNombreDoc.Name = "cNombreDoc";
            this.cNombreDoc.ReadOnly = true;
            // 
            // btnAddFile
            // 
            this.btnAddFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.btnAddFile.HeaderText = "Adjuntar";
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.ReadOnly = true;
            this.btnAddFile.Text = "+";
            this.btnAddFile.ToolTipText = "Adj.";
            this.btnAddFile.UseColumnTextForButtonValue = true;
            this.btnAddFile.Width = 52;
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.btnDeleteFile.HeaderText = "Limpiar";
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.ReadOnly = true;
            this.btnDeleteFile.Text = "-";
            this.btnDeleteFile.UseColumnTextForButtonValue = true;
            this.btnDeleteFile.Width = 46;
            // 
            // lEstado
            // 
            this.lEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.lEstado.DataPropertyName = "lEstado";
            this.lEstado.HeaderText = "Oblig";
            this.lEstado.Name = "lEstado";
            this.lEstado.ReadOnly = true;
            this.lEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lEstado.Width = 56;
            // 
            // idTipoDoc
            // 
            this.idTipoDoc.DataPropertyName = "idTipoDoc";
            this.idTipoDoc.HeaderText = "idTipoDoc";
            this.idTipoDoc.Name = "idTipoDoc";
            this.idTipoDoc.ReadOnly = true;
            this.idTipoDoc.Visible = false;
            // 
            // vDocBase
            // 
            this.vDocBase.DataPropertyName = "vDocBase";
            this.vDocBase.FillWeight = 46.51163F;
            this.vDocBase.HeaderText = "vDocBase";
            this.vDocBase.Name = "vDocBase";
            this.vDocBase.ReadOnly = true;
            this.vDocBase.Visible = false;
            // 
            // cExtencion
            // 
            this.cExtencion.DataPropertyName = "cExtencion";
            this.cExtencion.FillWeight = 46.51163F;
            this.cExtencion.HeaderText = "cExtencion";
            this.cExtencion.Name = "cExtencion";
            this.cExtencion.ReadOnly = true;
            this.cExtencion.Visible = false;
            // 
            // btnViewFile
            // 
            this.btnViewFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.btnViewFile.HeaderText = "Ver";
            this.btnViewFile.Image = global::CRE.Presentacion.Properties.Resources.ImgPdf;
            this.btnViewFile.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.btnViewFile.Name = "btnViewFile";
            this.btnViewFile.ReadOnly = true;
            this.btnViewFile.Visible = false;
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(295, 96);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 4;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(361, 96);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // contPdf
            // 
            this.contPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contPdf.Enabled = true;
            this.contPdf.Location = new System.Drawing.Point(0, 0);
            this.contPdf.Name = "contPdf";
            this.contPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("contPdf.OcxState")));
            this.contPdf.Size = new System.Drawing.Size(744, 317);
            this.contPdf.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panelFile);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 484);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgFiles);
            this.panel1.Controls.Add(this.btnAceptar1);
            this.panel1.Controls.Add(this.btnCancelar1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 155);
            this.panel1.TabIndex = 8;
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.contPdf);
            this.panelFile.Location = new System.Drawing.Point(3, 164);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(744, 317);
            this.panelFile.TabIndex = 9;
            this.panelFile.Visible = false;
            // 
            // frmAdjArchivosCondonacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(759, 507);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmAdjArchivosCondonacion";
            this.Text = "Adjuntar Archivos para la Condonacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdjArchivosCondonacion_FormClosing);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contPdf)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgFiles;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private AxAcroPDFLib.AxAcroPDF contPdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDoc;
        private System.Windows.Forms.DataGridViewButtonColumn btnAddFile;
        private System.Windows.Forms.DataGridViewButtonColumn btnDeleteFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn vDocBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExtencion;
        private System.Windows.Forms.DataGridViewImageColumn btnViewFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelFile;
    }
}