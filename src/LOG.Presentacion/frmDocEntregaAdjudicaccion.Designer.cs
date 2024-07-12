namespace LOG.Presentacion
{
    partial class frmDocEntregaAdjudicaccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocEntregaAdjudicaccion));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.lblNombreEmpres = new System.Windows.Forms.Label();
            this.dtgDocumento = new GEN.ControlesBase.dtgBase(this.components);
            this.idCalendarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDocProAdquiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cTipoDocProAdquiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaEvaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoEvaDoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clsEvaDocumentoProcesoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsEvaDocumentoProcesoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(546, 258);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 15;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(477, 258);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 20;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblNombreEmpres
            // 
            this.lblNombreEmpres.BackColor = System.Drawing.Color.White;
            this.lblNombreEmpres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpres.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreEmpres.Location = new System.Drawing.Point(10, 6);
            this.lblNombreEmpres.Name = "lblNombreEmpres";
            this.lblNombreEmpres.Size = new System.Drawing.Size(594, 42);
            this.lblNombreEmpres.TabIndex = 1;
            this.lblNombreEmpres.Text = "NOMBRE DE EMPRESA";
            this.lblNombreEmpres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgDocumento
            // 
            this.dtgDocumento.AllowUserToAddRows = false;
            this.dtgDocumento.AllowUserToDeleteRows = false;
            this.dtgDocumento.AllowUserToResizeColumns = false;
            this.dtgDocumento.AllowUserToResizeRows = false;
            this.dtgDocumento.AutoGenerateColumns = false;
            this.dtgDocumento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCalendarioDataGridViewTextBoxColumn,
            this.idProveedorDataGridViewTextBoxColumn,
            this.idProcesoDataGridViewTextBoxColumn,
            this.idTipoDocProAdquiDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn,
            this.cTipoDocProAdquiDataGridViewTextBoxColumn,
            this.dFechaEvaDataGridViewTextBoxColumn,
            this.idEstadoEvaDoc});
            this.dtgDocumento.DataSource = this.clsEvaDocumentoProcesoBindingSource;
            this.dtgDocumento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgDocumento.Location = new System.Drawing.Point(10, 51);
            this.dtgDocumento.MultiSelect = false;
            this.dtgDocumento.Name = "dtgDocumento";
            this.dtgDocumento.ReadOnly = true;
            this.dtgDocumento.RowHeadersVisible = false;
            this.dtgDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDocumento.Size = new System.Drawing.Size(594, 201);
            this.dtgDocumento.TabIndex = 22;
            this.dtgDocumento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumento_CellEndEdit);
            this.dtgDocumento.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgDocumento_CellPainting);
            this.dtgDocumento.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumento_CellValidated);
            this.dtgDocumento.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumento_CellValueChanged);
            this.dtgDocumento.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumento_RowLeave);
            // 
            // idCalendarioDataGridViewTextBoxColumn
            // 
            this.idCalendarioDataGridViewTextBoxColumn.DataPropertyName = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn.HeaderText = "idCalendario";
            this.idCalendarioDataGridViewTextBoxColumn.Name = "idCalendarioDataGridViewTextBoxColumn";
            this.idCalendarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCalendarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // idProveedorDataGridViewTextBoxColumn
            // 
            this.idProveedorDataGridViewTextBoxColumn.DataPropertyName = "idProveedor";
            this.idProveedorDataGridViewTextBoxColumn.HeaderText = "idProveedor";
            this.idProveedorDataGridViewTextBoxColumn.Name = "idProveedorDataGridViewTextBoxColumn";
            this.idProveedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProveedorDataGridViewTextBoxColumn.Visible = false;
            // 
            // idProcesoDataGridViewTextBoxColumn
            // 
            this.idProcesoDataGridViewTextBoxColumn.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.Name = "idProcesoDataGridViewTextBoxColumn";
            this.idProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTipoDocProAdquiDataGridViewTextBoxColumn
            // 
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.DataPropertyName = "idTipoDocProAdqui";
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.FillWeight = 25F;
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.Name = "idTipoDocProAdquiDataGridViewTextBoxColumn";
            this.idTipoDocProAdquiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // cTipoDocProAdquiDataGridViewTextBoxColumn
            // 
            this.cTipoDocProAdquiDataGridViewTextBoxColumn.DataPropertyName = "cTipoDocProAdqui";
            this.cTipoDocProAdquiDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.cTipoDocProAdquiDataGridViewTextBoxColumn.Name = "cTipoDocProAdquiDataGridViewTextBoxColumn";
            this.cTipoDocProAdquiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dFechaEvaDataGridViewTextBoxColumn
            // 
            this.dFechaEvaDataGridViewTextBoxColumn.DataPropertyName = "dFechaEva";
            this.dFechaEvaDataGridViewTextBoxColumn.HeaderText = "dFechaEva";
            this.dFechaEvaDataGridViewTextBoxColumn.Name = "dFechaEvaDataGridViewTextBoxColumn";
            this.dFechaEvaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaEvaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEstadoEvaDoc
            // 
            this.idEstadoEvaDoc.FillWeight = 70F;
            this.idEstadoEvaDoc.HeaderText = "Entrega";
            this.idEstadoEvaDoc.Name = "idEstadoEvaDoc";
            this.idEstadoEvaDoc.ReadOnly = true;
            // 
            // clsEvaDocumentoProcesoBindingSource
            // 
            this.clsEvaDocumentoProcesoBindingSource.DataSource = typeof(EntityLayer.clsEvaDocumentoProceso);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(357, 258);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 31;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(417, 258);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 30;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // frmDocEntregaAdjudicaccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 333);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.dtgDocumento);
            this.Controls.Add(this.lblNombreEmpres);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmDocEntregaAdjudicaccion";
            this.Text = "Documentos Entregado en la Propuesta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocEntregaAdjudicaccion_FormClosing);
            this.Load += new System.EventHandler(this.frmDocEntregaAdjudicaccion_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.lblNombreEmpres, 0);
            this.Controls.SetChildIndex(this.dtgDocumento, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsEvaDocumentoProcesoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.Label lblNombreEmpres;
        private GEN.ControlesBase.dtgBase dtgDocumento;
        private System.Windows.Forms.BindingSource clsEvaDocumentoProcesoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCalendarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocProAdquiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocProAdquiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaEvaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idEstadoEvaDoc;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;

    }
}