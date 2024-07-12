namespace LOG.Presentacion
{
    partial class frmEvalFactorTecProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvalFactorTecProceso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtgGrupo = new GEN.ControlesBase.dtgBase(this.components);
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEvaFacTec = new GEN.ControlesBase.dtgBase(this.components);
            this.idProveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProcesoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacTecnicosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOrdenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDecripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPuntajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPuntajeMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Presentado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoEvaFacTecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoEvalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPadreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsEvaFactorTecnicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgDetProAdj = new GEN.ControlesBase.dtgBase(this.components);
            this.idProcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPrecioUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDesGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nsubTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsDetalleProcesoAdjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblNombreEmpres = new System.Windows.Forms.Label();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaFacTec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsEvaFactorTecnicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetProAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleProcesoAdjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(579, 373);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 22;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtgGrupo
            // 
            this.dtgGrupo.AllowUserToAddRows = false;
            this.dtgGrupo.AllowUserToDeleteRows = false;
            this.dtgGrupo.AllowUserToResizeColumns = false;
            this.dtgGrupo.AllowUserToResizeRows = false;
            this.dtgGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.Descripcion});
            this.dtgGrupo.Location = new System.Drawing.Point(12, 55);
            this.dtgGrupo.MultiSelect = false;
            this.dtgGrupo.Name = "dtgGrupo";
            this.dtgGrupo.ReadOnly = true;
            this.dtgGrupo.RowHeadersVisible = false;
            this.dtgGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupo.Size = new System.Drawing.Size(231, 115);
            this.dtgGrupo.TabIndex = 26;
            this.dtgGrupo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupo_CellClick);
            this.dtgGrupo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGrupo_CellContentClick);
            this.dtgGrupo.SelectionChanged += new System.EventHandler(this.dtgGrupo_SelectionChanged);
            // 
            // Grupo
            // 
            this.Grupo.FillWeight = 25F;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.MinimumWidth = 15;
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // dtgEvaFacTec
            // 
            this.dtgEvaFacTec.AllowUserToAddRows = false;
            this.dtgEvaFacTec.AllowUserToDeleteRows = false;
            this.dtgEvaFacTec.AllowUserToResizeColumns = false;
            this.dtgEvaFacTec.AllowUserToResizeRows = false;
            this.dtgEvaFacTec.AutoGenerateColumns = false;
            this.dtgEvaFacTec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvaFacTec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEvaFacTec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaFacTec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProveedorDataGridViewTextBoxColumn,
            this.idProcesoDataGridViewTextBoxColumn1,
            this.idFacTecnicosDataGridViewTextBoxColumn,
            this.nOrdenDataGridViewTextBoxColumn,
            this.idGrupoDataGridViewTextBoxColumn1,
            this.lVigenteDataGridViewCheckBoxColumn,
            this.cDecripcionDataGridViewTextBoxColumn,
            this.nPuntajeDataGridViewTextBoxColumn,
            this.nPuntajeMax,
            this.pGrupoDataGridViewTextBoxColumn,
            this.P_Presentado,
            this.idTipoEvaFacTecDataGridViewTextBoxColumn,
            this.cTipoEvalDataGridViewTextBoxColumn,
            this.idPadreDataGridViewTextBoxColumn});
            this.dtgEvaFacTec.DataSource = this.clsEvaFactorTecnicoBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEvaFacTec.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgEvaFacTec.Location = new System.Drawing.Point(12, 176);
            this.dtgEvaFacTec.MultiSelect = false;
            this.dtgEvaFacTec.Name = "dtgEvaFacTec";
            this.dtgEvaFacTec.ReadOnly = true;
            this.dtgEvaFacTec.RowHeadersVisible = false;
            this.dtgEvaFacTec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaFacTec.Size = new System.Drawing.Size(561, 247);
            this.dtgEvaFacTec.TabIndex = 27;
            this.dtgEvaFacTec.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgEvaFacTec_CellValidating);
            this.dtgEvaFacTec.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvaFacTec_CellValueChanged);
            this.dtgEvaFacTec.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEvaFacTec_EditingControlShowing);
            // 
            // idProveedorDataGridViewTextBoxColumn
            // 
            this.idProveedorDataGridViewTextBoxColumn.DataPropertyName = "idProveedor";
            this.idProveedorDataGridViewTextBoxColumn.HeaderText = "idProveedor";
            this.idProveedorDataGridViewTextBoxColumn.Name = "idProveedorDataGridViewTextBoxColumn";
            this.idProveedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProveedorDataGridViewTextBoxColumn.Visible = false;
            // 
            // idProcesoDataGridViewTextBoxColumn1
            // 
            this.idProcesoDataGridViewTextBoxColumn1.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn1.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn1.Name = "idProcesoDataGridViewTextBoxColumn1";
            this.idProcesoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn1.Visible = false;
            // 
            // idFacTecnicosDataGridViewTextBoxColumn
            // 
            this.idFacTecnicosDataGridViewTextBoxColumn.DataPropertyName = "idFacTecnicos";
            this.idFacTecnicosDataGridViewTextBoxColumn.HeaderText = "idFacTecnicos";
            this.idFacTecnicosDataGridViewTextBoxColumn.Name = "idFacTecnicosDataGridViewTextBoxColumn";
            this.idFacTecnicosDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFacTecnicosDataGridViewTextBoxColumn.Visible = false;
            // 
            // nOrdenDataGridViewTextBoxColumn
            // 
            this.nOrdenDataGridViewTextBoxColumn.DataPropertyName = "nOrden";
            this.nOrdenDataGridViewTextBoxColumn.FillWeight = 50F;
            this.nOrdenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.nOrdenDataGridViewTextBoxColumn.Name = "nOrdenDataGridViewTextBoxColumn";
            this.nOrdenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idGrupoDataGridViewTextBoxColumn1
            // 
            this.idGrupoDataGridViewTextBoxColumn1.DataPropertyName = "idGrupo";
            this.idGrupoDataGridViewTextBoxColumn1.FillWeight = 50F;
            this.idGrupoDataGridViewTextBoxColumn1.HeaderText = "Grupo";
            this.idGrupoDataGridViewTextBoxColumn1.Name = "idGrupoDataGridViewTextBoxColumn1";
            this.idGrupoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idGrupoDataGridViewTextBoxColumn1.Visible = false;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // cDecripcionDataGridViewTextBoxColumn
            // 
            this.cDecripcionDataGridViewTextBoxColumn.DataPropertyName = "cDecripcion";
            this.cDecripcionDataGridViewTextBoxColumn.FillWeight = 200F;
            this.cDecripcionDataGridViewTextBoxColumn.HeaderText = "Decripción";
            this.cDecripcionDataGridViewTextBoxColumn.Name = "cDecripcionDataGridViewTextBoxColumn";
            this.cDecripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPuntajeDataGridViewTextBoxColumn
            // 
            this.nPuntajeDataGridViewTextBoxColumn.DataPropertyName = "nPuntaje";
            dataGridViewCellStyle2.Format = "N2";
            this.nPuntajeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nPuntajeDataGridViewTextBoxColumn.FillWeight = 50F;
            this.nPuntajeDataGridViewTextBoxColumn.HeaderText = "Puntaje";
            this.nPuntajeDataGridViewTextBoxColumn.Name = "nPuntajeDataGridViewTextBoxColumn";
            this.nPuntajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPuntajeMax
            // 
            this.nPuntajeMax.DataPropertyName = "nPuntajeMax";
            this.nPuntajeMax.HeaderText = "Puntaje Max.";
            this.nPuntajeMax.Name = "nPuntajeMax";
            this.nPuntajeMax.ReadOnly = true;
            // 
            // pGrupoDataGridViewTextBoxColumn
            // 
            this.pGrupoDataGridViewTextBoxColumn.DataPropertyName = "P_Grupo";
            dataGridViewCellStyle3.Format = "N2";
            this.pGrupoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.pGrupoDataGridViewTextBoxColumn.FillWeight = 65F;
            this.pGrupoDataGridViewTextBoxColumn.HeaderText = "P. Grupo";
            this.pGrupoDataGridViewTextBoxColumn.Name = "pGrupoDataGridViewTextBoxColumn";
            this.pGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // P_Presentado
            // 
            this.P_Presentado.DataPropertyName = "CumpleReq";
            this.P_Presentado.FillWeight = 90F;
            this.P_Presentado.HeaderText = "Cumple Req.?";
            this.P_Presentado.Name = "P_Presentado";
            this.P_Presentado.ReadOnly = true;
            this.P_Presentado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.P_Presentado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idTipoEvaFacTecDataGridViewTextBoxColumn
            // 
            this.idTipoEvaFacTecDataGridViewTextBoxColumn.DataPropertyName = "idTipoEvaFacTec";
            this.idTipoEvaFacTecDataGridViewTextBoxColumn.HeaderText = "idTipoEvaFacTec";
            this.idTipoEvaFacTecDataGridViewTextBoxColumn.Name = "idTipoEvaFacTecDataGridViewTextBoxColumn";
            this.idTipoEvaFacTecDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTipoEvaFacTecDataGridViewTextBoxColumn.Visible = false;
            // 
            // cTipoEvalDataGridViewTextBoxColumn
            // 
            this.cTipoEvalDataGridViewTextBoxColumn.DataPropertyName = "cTipoEval";
            this.cTipoEvalDataGridViewTextBoxColumn.FillWeight = 80F;
            this.cTipoEvalDataGridViewTextBoxColumn.HeaderText = "Calificacción";
            this.cTipoEvalDataGridViewTextBoxColumn.Name = "cTipoEvalDataGridViewTextBoxColumn";
            this.cTipoEvalDataGridViewTextBoxColumn.ReadOnly = true;
            this.cTipoEvalDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPadreDataGridViewTextBoxColumn
            // 
            this.idPadreDataGridViewTextBoxColumn.DataPropertyName = "idPadre";
            this.idPadreDataGridViewTextBoxColumn.HeaderText = "idPadre";
            this.idPadreDataGridViewTextBoxColumn.Name = "idPadreDataGridViewTextBoxColumn";
            this.idPadreDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPadreDataGridViewTextBoxColumn.Visible = false;
            // 
            // clsEvaFactorTecnicoBindingSource
            // 
            this.clsEvaFactorTecnicoBindingSource.DataSource = typeof(EntityLayer.clsEvaFactorTecnico);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(665, 233);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 29;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(579, 322);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 28;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgDetProAdj
            // 
            this.dtgDetProAdj.AllowUserToAddRows = false;
            this.dtgDetProAdj.AllowUserToDeleteRows = false;
            this.dtgDetProAdj.AllowUserToResizeColumns = false;
            this.dtgDetProAdj.AllowUserToResizeRows = false;
            this.dtgDetProAdj.AutoGenerateColumns = false;
            this.dtgDetProAdj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetProAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetProAdj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProcesoDataGridViewTextBoxColumn,
            this.nItemDataGridViewTextBoxColumn,
            this.idCatalogoDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.idUnidadDataGridViewTextBoxColumn,
            this.cUnidadDataGridViewTextBoxColumn,
            this.nCantidadDataGridViewTextBoxColumn,
            this.nPrecioUnitDataGridViewTextBoxColumn,
            this.idGrupoDataGridViewTextBoxColumn,
            this.cDesGrupoDataGridViewTextBoxColumn,
            this.nsubTotalDataGridViewTextBoxColumn});
            this.dtgDetProAdj.DataSource = this.clsDetalleProcesoAdjBindingSource;
            this.dtgDetProAdj.Location = new System.Drawing.Point(249, 55);
            this.dtgDetProAdj.MultiSelect = false;
            this.dtgDetProAdj.Name = "dtgDetProAdj";
            this.dtgDetProAdj.ReadOnly = true;
            this.dtgDetProAdj.RowHeadersVisible = false;
            this.dtgDetProAdj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetProAdj.Size = new System.Drawing.Size(390, 115);
            this.dtgDetProAdj.TabIndex = 30;
            // 
            // idProcesoDataGridViewTextBoxColumn
            // 
            this.idProcesoDataGridViewTextBoxColumn.DataPropertyName = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.HeaderText = "idProceso";
            this.idProcesoDataGridViewTextBoxColumn.Name = "idProcesoDataGridViewTextBoxColumn";
            this.idProcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProcesoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nItemDataGridViewTextBoxColumn
            // 
            this.nItemDataGridViewTextBoxColumn.DataPropertyName = "nItem";
            this.nItemDataGridViewTextBoxColumn.HeaderText = "nItem";
            this.nItemDataGridViewTextBoxColumn.Name = "nItemDataGridViewTextBoxColumn";
            this.nItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.nItemDataGridViewTextBoxColumn.Visible = false;
            // 
            // idCatalogoDataGridViewTextBoxColumn
            // 
            this.idCatalogoDataGridViewTextBoxColumn.DataPropertyName = "idCatalogo";
            this.idCatalogoDataGridViewTextBoxColumn.HeaderText = "idCatalogo";
            this.idCatalogoDataGridViewTextBoxColumn.Name = "idCatalogoDataGridViewTextBoxColumn";
            this.idCatalogoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCatalogoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cProductoDataGridViewTextBoxColumn
            // 
            this.cProductoDataGridViewTextBoxColumn.DataPropertyName = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "Artículo";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUnidadDataGridViewTextBoxColumn
            // 
            this.idUnidadDataGridViewTextBoxColumn.DataPropertyName = "idUnidad";
            this.idUnidadDataGridViewTextBoxColumn.HeaderText = "idUnidad";
            this.idUnidadDataGridViewTextBoxColumn.Name = "idUnidadDataGridViewTextBoxColumn";
            this.idUnidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.idUnidadDataGridViewTextBoxColumn.Visible = false;
            // 
            // cUnidadDataGridViewTextBoxColumn
            // 
            this.cUnidadDataGridViewTextBoxColumn.DataPropertyName = "cUnidad";
            this.cUnidadDataGridViewTextBoxColumn.FillWeight = 50F;
            this.cUnidadDataGridViewTextBoxColumn.HeaderText = "Unidad";
            this.cUnidadDataGridViewTextBoxColumn.Name = "cUnidadDataGridViewTextBoxColumn";
            this.cUnidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nCantidadDataGridViewTextBoxColumn
            // 
            this.nCantidadDataGridViewTextBoxColumn.DataPropertyName = "nCantidad";
            dataGridViewCellStyle5.Format = "N2";
            this.nCantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.nCantidadDataGridViewTextBoxColumn.FillWeight = 60F;
            this.nCantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.nCantidadDataGridViewTextBoxColumn.Name = "nCantidadDataGridViewTextBoxColumn";
            this.nCantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nPrecioUnitDataGridViewTextBoxColumn
            // 
            this.nPrecioUnitDataGridViewTextBoxColumn.DataPropertyName = "nPrecioUnit";
            this.nPrecioUnitDataGridViewTextBoxColumn.HeaderText = "nPrecioUnit";
            this.nPrecioUnitDataGridViewTextBoxColumn.Name = "nPrecioUnitDataGridViewTextBoxColumn";
            this.nPrecioUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.nPrecioUnitDataGridViewTextBoxColumn.Visible = false;
            // 
            // idGrupoDataGridViewTextBoxColumn
            // 
            this.idGrupoDataGridViewTextBoxColumn.DataPropertyName = "idGrupo";
            this.idGrupoDataGridViewTextBoxColumn.HeaderText = "idGrupo";
            this.idGrupoDataGridViewTextBoxColumn.Name = "idGrupoDataGridViewTextBoxColumn";
            this.idGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idGrupoDataGridViewTextBoxColumn.Visible = false;
            // 
            // cDesGrupoDataGridViewTextBoxColumn
            // 
            this.cDesGrupoDataGridViewTextBoxColumn.DataPropertyName = "cDesGrupo";
            this.cDesGrupoDataGridViewTextBoxColumn.HeaderText = "cDesGrupo";
            this.cDesGrupoDataGridViewTextBoxColumn.Name = "cDesGrupoDataGridViewTextBoxColumn";
            this.cDesGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDesGrupoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nsubTotalDataGridViewTextBoxColumn
            // 
            this.nsubTotalDataGridViewTextBoxColumn.DataPropertyName = "nsubTotal";
            this.nsubTotalDataGridViewTextBoxColumn.HeaderText = "nsubTotal";
            this.nsubTotalDataGridViewTextBoxColumn.Name = "nsubTotalDataGridViewTextBoxColumn";
            this.nsubTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.nsubTotalDataGridViewTextBoxColumn.Visible = false;
            // 
            // clsDetalleProcesoAdjBindingSource
            // 
            this.clsDetalleProcesoAdjBindingSource.DataSource = typeof(EntityLayer.clsDetalleProcesoAdj);
            // 
            // lblNombreEmpres
            // 
            this.lblNombreEmpres.BackColor = System.Drawing.Color.White;
            this.lblNombreEmpres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpres.ForeColor = System.Drawing.Color.Navy;
            this.lblNombreEmpres.Location = new System.Drawing.Point(12, 9);
            this.lblNombreEmpres.Name = "lblNombreEmpres";
            this.lblNombreEmpres.Size = new System.Drawing.Size(627, 42);
            this.lblNombreEmpres.TabIndex = 31;
            this.lblNombreEmpres.Text = "NOMBRE DE EMPRESA";
            this.lblNombreEmpres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Enabled = false;
            this.btnEditar1.Location = new System.Drawing.Point(579, 222);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 33;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(579, 272);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 32;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // frmEvalFactorTecProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 448);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.lblNombreEmpres);
            this.Controls.Add(this.dtgDetProAdj);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.dtgEvaFacTec);
            this.Controls.Add(this.dtgGrupo);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmEvalFactorTecProceso";
            this.Text = "Evaluacion de Factores Tecnico para el Proceso";
            this.Load += new System.EventHandler(this.frmEvalFactorTecProceso_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.dtgGrupo, 0);
            this.Controls.SetChildIndex(this.dtgEvaFacTec, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.dtgDetProAdj, 0);
            this.Controls.SetChildIndex(this.lblNombreEmpres, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaFacTec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsEvaFactorTecnicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetProAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsDetalleProcesoAdjBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtgBase dtgGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private GEN.ControlesBase.dtgBase dtgEvaFacTec;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgDetProAdj;
        private System.Windows.Forms.BindingSource clsDetalleProcesoAdjBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPrecioUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDeseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValorRefDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDesGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVinculoProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clsEvaFactorTecnicoBindingSource;
        private System.Windows.Forms.Label lblNombreEmpres;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProcesoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacTecnicosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOrdenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDecripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPuntajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPuntajeMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn pGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn P_Presentado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoEvaFacTecDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoEvalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPadreDataGridViewTextBoxColumn;
    }
}