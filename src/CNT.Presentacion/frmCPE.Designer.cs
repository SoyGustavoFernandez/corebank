
namespace CNT.Presentacion
{
    partial class frmCPE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCPE));
            this.GrbBusqueda = new GEN.ControlesBase.grbBase(this.components);
            this.BtnBuscar = new GEN.BotonesBase.btnBusqueda();
            this.CboEstadoProcesoCPE = new GEN.ControlesBase.cboEstadoProcesoCPE(this.components);
            this.DtpFiltroFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.DtpFiltroIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.GrbProcesos = new GEN.ControlesBase.grbBase(this.components);
            this.DtgProcesos = new GEN.ControlesBase.dtgBase(this.components);
            this.CodigoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFinalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OkColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnularColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrbArchivos = new GEN.ControlesBase.grbBase(this.components);
            this.DtgArchivos = new GEN.ControlesBase.dtgBase(this.components);
            this.CodigoArchivoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreArchivoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrelativoIni1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrelativoFin1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serie2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrelativoIni2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrelativoFin2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoArchivoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEnvioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCDRColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblInfo = new GEN.ControlesBase.lblBaseCustom(this.components);
            this.BtnGenerar = new GEN.BotonesBase.btnGenerar();
            this.BtnAnular = new GEN.BotonesBase.btnAnular();
            this.BtnRegistrarEnvio = new GEN.BotonesBase.btnBlanco();
            this.BtnProcesar = new GEN.BotonesBase.btnProcesar();
            this.BtnSalir = new GEN.BotonesBase.btnSalir();
            this.BtnNuevo = new GEN.BotonesBase.btnNuevo();
            this.BtnNumerar = new GEN.BotonesBase.btnNumerar();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.GrbBusqueda.SuspendLayout();
            this.GrbProcesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProcesos)).BeginInit();
            this.GrbArchivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgArchivos)).BeginInit();
            this.SuspendLayout();
            // 
            // GrbBusqueda
            // 
            this.GrbBusqueda.Controls.Add(this.BtnBuscar);
            this.GrbBusqueda.Controls.Add(this.CboEstadoProcesoCPE);
            this.GrbBusqueda.Controls.Add(this.DtpFiltroFin);
            this.GrbBusqueda.Controls.Add(this.DtpFiltroIni);
            this.GrbBusqueda.Controls.Add(this.lblBase3);
            this.GrbBusqueda.Controls.Add(this.lblBase2);
            this.GrbBusqueda.Controls.Add(this.lblBase1);
            this.GrbBusqueda.Location = new System.Drawing.Point(12, 12);
            this.GrbBusqueda.Name = "GrbBusqueda";
            this.GrbBusqueda.Size = new System.Drawing.Size(804, 81);
            this.GrbBusqueda.TabIndex = 1;
            this.GrbBusqueda.TabStop = false;
            this.GrbBusqueda.Text = "Búsqueda";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.BackgroundImage")));
            this.BtnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnBuscar.Location = new System.Drawing.Point(701, 19);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(60, 50);
            this.BtnBuscar.TabIndex = 4;
            this.BtnBuscar.Text = "&Buscar";
            this.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // CboEstadoProcesoCPE
            // 
            this.CboEstadoProcesoCPE.AgregarItemTodos = true;
            this.CboEstadoProcesoCPE.Cursor = System.Windows.Forms.Cursors.Default;
            this.CboEstadoProcesoCPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstadoProcesoCPE.FormattingEnabled = true;
            this.CboEstadoProcesoCPE.Location = new System.Drawing.Point(516, 34);
            this.CboEstadoProcesoCPE.Name = "CboEstadoProcesoCPE";
            this.CboEstadoProcesoCPE.Size = new System.Drawing.Size(150, 21);
            this.CboEstadoProcesoCPE.TabIndex = 3;
            // 
            // DtpFiltroFin
            // 
            this.DtpFiltroFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFiltroFin.Location = new System.Drawing.Point(292, 34);
            this.DtpFiltroFin.Name = "DtpFiltroFin";
            this.DtpFiltroFin.Size = new System.Drawing.Size(150, 20);
            this.DtpFiltroFin.TabIndex = 2;
            // 
            // DtpFiltroIni
            // 
            this.DtpFiltroIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFiltroIni.Location = new System.Drawing.Point(74, 34);
            this.DtpFiltroIni.Name = "DtpFiltroIni";
            this.DtpFiltroIni.Size = new System.Drawing.Size(150, 20);
            this.DtpFiltroIni.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(460, 38);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Estado:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(242, 38);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Hasta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(20, 38);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Desde:";
            // 
            // GrbProcesos
            // 
            this.GrbProcesos.Controls.Add(this.DtgProcesos);
            this.GrbProcesos.Location = new System.Drawing.Point(12, 99);
            this.GrbProcesos.Name = "GrbProcesos";
            this.GrbProcesos.Size = new System.Drawing.Size(804, 219);
            this.GrbProcesos.TabIndex = 2;
            this.GrbProcesos.TabStop = false;
            this.GrbProcesos.Text = "Procesos CPE";
            // 
            // DtgProcesos
            // 
            this.DtgProcesos.AllowUserToAddRows = false;
            this.DtgProcesos.AllowUserToDeleteRows = false;
            this.DtgProcesos.AllowUserToResizeColumns = false;
            this.DtgProcesos.AllowUserToResizeRows = false;
            this.DtgProcesos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProcesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoColumn,
            this.FechaColumn,
            this.FechaInicialColumn,
            this.FechaFinalColumn,
            this.TotalColumn,
            this.OkColumn,
            this.ObsColumn,
            this.AnularColumn,
            this.EstadoColumn});
            this.DtgProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgProcesos.Location = new System.Drawing.Point(3, 16);
            this.DtgProcesos.MultiSelect = false;
            this.DtgProcesos.Name = "DtgProcesos";
            this.DtgProcesos.ReadOnly = true;
            this.DtgProcesos.RowHeadersVisible = false;
            this.DtgProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgProcesos.Size = new System.Drawing.Size(798, 200);
            this.DtgProcesos.TabIndex = 0;
            this.DtgProcesos.TabStop = false;
            this.DtgProcesos.SelectionChanged += new System.EventHandler(this.DtgProcesos_SelectionChanged);
            // 
            // CodigoColumn
            // 
            this.CodigoColumn.DataPropertyName = "IdProcesoCPE";
            this.CodigoColumn.FillWeight = 1F;
            this.CodigoColumn.HeaderText = "Id";
            this.CodigoColumn.Name = "CodigoColumn";
            this.CodigoColumn.ReadOnly = true;
            // 
            // FechaColumn
            // 
            this.FechaColumn.DataPropertyName = "FechaReg";
            this.FechaColumn.FillWeight = 2F;
            this.FechaColumn.HeaderText = "Fecha";
            this.FechaColumn.Name = "FechaColumn";
            this.FechaColumn.ReadOnly = true;
            // 
            // FechaInicialColumn
            // 
            this.FechaInicialColumn.DataPropertyName = "FechaIniCPE";
            this.FechaInicialColumn.FillWeight = 2F;
            this.FechaInicialColumn.HeaderText = "Fecha inicial CPE";
            this.FechaInicialColumn.Name = "FechaInicialColumn";
            this.FechaInicialColumn.ReadOnly = true;
            // 
            // FechaFinalColumn
            // 
            this.FechaFinalColumn.DataPropertyName = "FechaFinCPE";
            this.FechaFinalColumn.FillWeight = 2F;
            this.FechaFinalColumn.HeaderText = "Fecha final CPE";
            this.FechaFinalColumn.Name = "FechaFinalColumn";
            this.FechaFinalColumn.ReadOnly = true;
            // 
            // TotalColumn
            // 
            this.TotalColumn.DataPropertyName = "NroTotalCPE";
            this.TotalColumn.FillWeight = 2F;
            this.TotalColumn.HeaderText = "Total CPE";
            this.TotalColumn.Name = "TotalColumn";
            this.TotalColumn.ReadOnly = true;
            // 
            // OkColumn
            // 
            this.OkColumn.DataPropertyName = "NroOkCPE";
            this.OkColumn.FillWeight = 1F;
            this.OkColumn.HeaderText = "OK";
            this.OkColumn.Name = "OkColumn";
            this.OkColumn.ReadOnly = true;
            // 
            // ObsColumn
            // 
            this.ObsColumn.DataPropertyName = "NroErrorCPE";
            this.ObsColumn.FillWeight = 1F;
            this.ObsColumn.HeaderText = "OBS";
            this.ObsColumn.Name = "ObsColumn";
            this.ObsColumn.ReadOnly = true;
            // 
            // AnularColumn
            // 
            this.AnularColumn.DataPropertyName = "NroAnula";
            this.AnularColumn.FillWeight = 1F;
            this.AnularColumn.HeaderText = "ANULA";
            this.AnularColumn.Name = "AnularColumn";
            this.AnularColumn.ReadOnly = true;
            // 
            // EstadoColumn
            // 
            this.EstadoColumn.DataPropertyName = "DescripcionEstadoProcesoCPE";
            this.EstadoColumn.FillWeight = 2F;
            this.EstadoColumn.HeaderText = "Estado";
            this.EstadoColumn.Name = "EstadoColumn";
            this.EstadoColumn.ReadOnly = true;
            // 
            // GrbArchivos
            // 
            this.GrbArchivos.Controls.Add(this.DtgArchivos);
            this.GrbArchivos.Location = new System.Drawing.Point(12, 324);
            this.GrbArchivos.Name = "GrbArchivos";
            this.GrbArchivos.Size = new System.Drawing.Size(804, 139);
            this.GrbArchivos.TabIndex = 3;
            this.GrbArchivos.TabStop = false;
            this.GrbArchivos.Text = "Archivos generados";
            // 
            // DtgArchivos
            // 
            this.DtgArchivos.AllowUserToAddRows = false;
            this.DtgArchivos.AllowUserToDeleteRows = false;
            this.DtgArchivos.AllowUserToResizeColumns = false;
            this.DtgArchivos.AllowUserToResizeRows = false;
            this.DtgArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoArchivoColumn,
            this.NombreArchivoColumn,
            this.Serie1Column,
            this.CorrelativoIni1Column,
            this.CorrelativoFin1Column,
            this.Serie2Column,
            this.CorrelativoIni2Column,
            this.CorrelativoFin2Column,
            this.EstadoArchivoColumn,
            this.FechaEnvioColumn,
            this.NombreCDRColumn});
            this.DtgArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgArchivos.Location = new System.Drawing.Point(3, 16);
            this.DtgArchivos.MultiSelect = false;
            this.DtgArchivos.Name = "DtgArchivos";
            this.DtgArchivos.ReadOnly = true;
            this.DtgArchivos.RowHeadersVisible = false;
            this.DtgArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgArchivos.Size = new System.Drawing.Size(798, 120);
            this.DtgArchivos.TabIndex = 0;
            this.DtgArchivos.TabStop = false;
            // 
            // CodigoArchivoColumn
            // 
            this.CodigoArchivoColumn.DataPropertyName = "IdArchivoCPE";
            this.CodigoArchivoColumn.FillWeight = 1F;
            this.CodigoArchivoColumn.HeaderText = "Id";
            this.CodigoArchivoColumn.Name = "CodigoArchivoColumn";
            this.CodigoArchivoColumn.ReadOnly = true;
            // 
            // NombreArchivoColumn
            // 
            this.NombreArchivoColumn.DataPropertyName = "NombreArchivo";
            this.NombreArchivoColumn.FillWeight = 3.5F;
            this.NombreArchivoColumn.HeaderText = "Nombre";
            this.NombreArchivoColumn.Name = "NombreArchivoColumn";
            this.NombreArchivoColumn.ReadOnly = true;
            // 
            // Serie1Column
            // 
            this.Serie1Column.DataPropertyName = "Serie_1";
            this.Serie1Column.FillWeight = 1F;
            this.Serie1Column.HeaderText = "Serie 1";
            this.Serie1Column.Name = "Serie1Column";
            this.Serie1Column.ReadOnly = true;
            // 
            // CorrelativoIni1Column
            // 
            this.CorrelativoIni1Column.DataPropertyName = "CorrelaIni_1";
            this.CorrelativoIni1Column.FillWeight = 1F;
            this.CorrelativoIni1Column.HeaderText = "Nro. inicial";
            this.CorrelativoIni1Column.Name = "CorrelativoIni1Column";
            this.CorrelativoIni1Column.ReadOnly = true;
            // 
            // CorrelativoFin1Column
            // 
            this.CorrelativoFin1Column.DataPropertyName = "CorrelaFin_1";
            this.CorrelativoFin1Column.FillWeight = 1F;
            this.CorrelativoFin1Column.HeaderText = "Nro. final";
            this.CorrelativoFin1Column.Name = "CorrelativoFin1Column";
            this.CorrelativoFin1Column.ReadOnly = true;
            // 
            // Serie2Column
            // 
            this.Serie2Column.DataPropertyName = "Serie_2";
            this.Serie2Column.FillWeight = 1F;
            this.Serie2Column.HeaderText = "Serie 2";
            this.Serie2Column.Name = "Serie2Column";
            this.Serie2Column.ReadOnly = true;
            // 
            // CorrelativoIni2Column
            // 
            this.CorrelativoIni2Column.DataPropertyName = "CorrelaIni_2";
            this.CorrelativoIni2Column.FillWeight = 1F;
            this.CorrelativoIni2Column.HeaderText = "Nro. inicial 2";
            this.CorrelativoIni2Column.Name = "CorrelativoIni2Column";
            this.CorrelativoIni2Column.ReadOnly = true;
            // 
            // CorrelativoFin2Column
            // 
            this.CorrelativoFin2Column.DataPropertyName = "CorrelaFin_2";
            this.CorrelativoFin2Column.FillWeight = 1F;
            this.CorrelativoFin2Column.HeaderText = "Nro. final 2";
            this.CorrelativoFin2Column.Name = "CorrelativoFin2Column";
            this.CorrelativoFin2Column.ReadOnly = true;
            // 
            // EstadoArchivoColumn
            // 
            this.EstadoArchivoColumn.DataPropertyName = "DescripcionEstadoEnvio";
            this.EstadoArchivoColumn.FillWeight = 2F;
            this.EstadoArchivoColumn.HeaderText = "Estado";
            this.EstadoArchivoColumn.Name = "EstadoArchivoColumn";
            this.EstadoArchivoColumn.ReadOnly = true;
            // 
            // FechaEnvioColumn
            // 
            this.FechaEnvioColumn.DataPropertyName = "FechaEnvio";
            this.FechaEnvioColumn.FillWeight = 1.5F;
            this.FechaEnvioColumn.HeaderText = "Fecha envío";
            this.FechaEnvioColumn.Name = "FechaEnvioColumn";
            this.FechaEnvioColumn.ReadOnly = true;
            // 
            // NombreCDRColumn
            // 
            this.NombreCDRColumn.DataPropertyName = "NombreCDR";
            this.NombreCDRColumn.FillWeight = 3F;
            this.NombreCDRColumn.HeaderText = "Nombre CDR";
            this.NombreCDRColumn.Name = "NombreCDRColumn";
            this.NombreCDRColumn.ReadOnly = true;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Verdana", 8F);
            this.LblInfo.ForeColor = System.Drawing.Color.Tomato;
            this.LblInfo.Location = new System.Drawing.Point(78, 502);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(0, 13);
            this.LblInfo.TabIndex = 12;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnGenerar.BackgroundImage")));
            this.BtnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnGenerar.Location = new System.Drawing.Point(629, 469);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(60, 50);
            this.BtnGenerar.TabIndex = 7;
            this.BtnGenerar.Text = "Gene&rar";
            this.BtnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // BtnAnular
            // 
            this.BtnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAnular.BackgroundImage")));
            this.BtnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnAnular.Location = new System.Drawing.Point(690, 469);
            this.BtnAnular.Name = "BtnAnular";
            this.BtnAnular.Size = new System.Drawing.Size(60, 50);
            this.BtnAnular.TabIndex = 8;
            this.BtnAnular.Text = "Anu&lar";
            this.BtnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAnular.UseVisualStyleBackColor = true;
            this.BtnAnular.Click += new System.EventHandler(this.BtnAnular_Click);
            // 
            // BtnRegistrarEnvio
            // 
            this.BtnRegistrarEnvio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnRegistrarEnvio.Location = new System.Drawing.Point(12, 469);
            this.BtnRegistrarEnvio.Name = "BtnRegistrarEnvio";
            this.BtnRegistrarEnvio.Size = new System.Drawing.Size(60, 50);
            this.BtnRegistrarEnvio.TabIndex = 9;
            this.BtnRegistrarEnvio.Text = "Registrar envío sunat";
            this.BtnRegistrarEnvio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnRegistrarEnvio.UseVisualStyleBackColor = true;
            this.BtnRegistrarEnvio.Click += new System.EventHandler(this.BtnRegistrarEnvio_Click);
            // 
            // BtnProcesar
            // 
            this.BtnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnProcesar.BackgroundImage")));
            this.BtnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnProcesar.Location = new System.Drawing.Point(507, 469);
            this.BtnProcesar.Name = "BtnProcesar";
            this.BtnProcesar.Size = new System.Drawing.Size(60, 50);
            this.BtnProcesar.TabIndex = 5;
            this.BtnProcesar.Text = "&Procesar";
            this.BtnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnProcesar.UseVisualStyleBackColor = true;
            this.BtnProcesar.Click += new System.EventHandler(this.BtnProcesar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSalir.BackgroundImage")));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.Location = new System.Drawing.Point(756, 469);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(60, 50);
            this.BtnSalir.TabIndex = 10;
            this.BtnSalir.Text = "&Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnNuevo.BackgroundImage")));
            this.BtnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnNuevo.Location = new System.Drawing.Point(446, 469);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(60, 50);
            this.BtnNuevo.TabIndex = 4;
            this.BtnNuevo.Text = "&Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnNumerar
            // 
            this.BtnNumerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnNumerar.BackgroundImage")));
            this.BtnNumerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnNumerar.Location = new System.Drawing.Point(568, 469);
            this.BtnNumerar.Name = "BtnNumerar";
            this.BtnNumerar.Size = new System.Drawing.Size(60, 50);
            this.BtnNumerar.TabIndex = 6;
            this.BtnNumerar.Text = "&Numerar";
            this.BtnNumerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNumerar.UseVisualStyleBackColor = true;
            this.BtnNumerar.Click += new System.EventHandler(this.BtnNumerar_Click);
            // 
            // frmCPE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 550);
            this.Controls.Add(this.BtnNumerar);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BtnAnular);
            this.Controls.Add(this.BtnRegistrarEnvio);
            this.Controls.Add(this.BtnProcesar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.GrbArchivos);
            this.Controls.Add(this.GrbProcesos);
            this.Controls.Add(this.GrbBusqueda);
            this.Name = "frmCPE";
            this.Text = "Generación de archivos de comprobantes de pago electrónico (CPE) a sunat";
            this.Load += new System.EventHandler(this.frmCPE_Load);
            this.Controls.SetChildIndex(this.GrbBusqueda, 0);
            this.Controls.SetChildIndex(this.GrbProcesos, 0);
            this.Controls.SetChildIndex(this.GrbArchivos, 0);
            this.Controls.SetChildIndex(this.BtnNuevo, 0);
            this.Controls.SetChildIndex(this.BtnSalir, 0);
            this.Controls.SetChildIndex(this.BtnProcesar, 0);
            this.Controls.SetChildIndex(this.BtnRegistrarEnvio, 0);
            this.Controls.SetChildIndex(this.BtnAnular, 0);
            this.Controls.SetChildIndex(this.BtnGenerar, 0);
            this.Controls.SetChildIndex(this.LblInfo, 0);
            this.Controls.SetChildIndex(this.BtnNumerar, 0);
            this.GrbBusqueda.ResumeLayout(false);
            this.GrbBusqueda.PerformLayout();
            this.GrbProcesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgProcesos)).EndInit();
            this.GrbArchivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgArchivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase GrbBusqueda;
        private GEN.ControlesBase.dtpCorto DtpFiltroFin;
        private GEN.ControlesBase.dtpCorto DtpFiltroIni;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnBusqueda BtnBuscar;
        private GEN.ControlesBase.cboEstadoProcesoCPE CboEstadoProcesoCPE;
        private GEN.ControlesBase.grbBase GrbProcesos;
        private GEN.ControlesBase.dtgBase DtgProcesos;
        private GEN.ControlesBase.grbBase GrbArchivos;
        private GEN.ControlesBase.dtgBase DtgArchivos;
        private GEN.BotonesBase.btnNuevo BtnNuevo;
        private GEN.BotonesBase.btnSalir BtnSalir;
        private GEN.BotonesBase.btnProcesar BtnProcesar;
        private GEN.BotonesBase.btnAnular BtnAnular;
        private GEN.BotonesBase.btnBlanco BtnRegistrarEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFinalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OkColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnularColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoColumn;
        private GEN.BotonesBase.btnGenerar BtnGenerar;
        private GEN.ControlesBase.lblBaseCustom LblInfo;
        private GEN.BotonesBase.btnNumerar BtnNumerar;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoArchivoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrelativoIni1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrelativoFin1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrelativoIni2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrelativoFin2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoArchivoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEnvioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCDRColumn;
    }
}