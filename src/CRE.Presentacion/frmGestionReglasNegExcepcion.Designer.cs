namespace CRE.Presentacion
{
    partial class frmGestionReglasNegExcepcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionReglasNegExcepcion));
            this.bsExcepcion = new System.Windows.Forms.BindingSource(this.components);
            this.bsRegularizacion = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExpediente = new GEN.BotonesBase.Boton();
            this.pnlComentarioAprobador = new System.Windows.Forms.Panel();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtComentarioAprobador = new GEN.ControlesBase.txtBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSolicitar = new GEN.BotonesBase.btnSolicitar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.bsExcepcionResum = new System.Windows.Forms.BindingSource(this.components);
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dtgSolicitud = new GEN.ControlesBase.dtgBase(this.components);
            this.idSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOperacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPlazoCuotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCuotasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTasaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ndiasgraciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAgenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nReglasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSolicitados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDerivadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAprobadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDenegadosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSolicitudExcepcion = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCanSustReg = new GEN.BotonesBase.btnCancelar();
            this.btnAcepSustReg = new GEN.BotonesBase.BtnAceptar();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtSustentoReg = new GEN.ControlesBase.txtBase(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAnularER = new System.Windows.Forms.ToolStripButton();
            this.tsbQuitarER = new System.Windows.Forms.ToolStripButton();
            this.tsbEditarER = new System.Windows.Forms.ToolStripButton();
            this.tsbAgregarER = new System.Windows.Forms.ToolStripButton();
            this.tsbDenegarReg = new System.Windows.Forms.ToolStripButton();
            this.tsbAprobarReg = new System.Windows.Forms.ToolStripButton();
            this.dtgRegularizacion = new GEN.ControlesBase.dtgBase(this.components);
            this.lAutomaticoDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRegla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAcronimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReglaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.bsExcepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegularizacion)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlComentarioAprobador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsExcepcionResum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitud)).BeginInit();
            this.pnlSolicitudExcepcion.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegularizacion)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsExcepcion
            // 
            this.bsExcepcion.DataSource = typeof(EntityLayer.clsExcepcionReglaNeg);
            // 
            // bsRegularizacion
            // 
            this.bsRegularizacion.DataSource = typeof(EntityLayer.clsExcepcionReglaNeg);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnExpediente);
            this.panel1.Controls.Add(this.pnlComentarioAprobador);
            this.panel1.Controls.Add(this.btnGrabar);
            this.panel1.Controls.Add(this.btnSolicitar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Location = new System.Drawing.Point(3, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 62);
            this.panel1.TabIndex = 1;
            // 
            // btnExpediente
            // 
            this.btnExpediente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpediente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExpediente.Location = new System.Drawing.Point(610, 6);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Size = new System.Drawing.Size(60, 50);
            this.btnExpediente.TabIndex = 2;
            this.btnExpediente.Text = "Expediente";
            this.btnExpediente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpediente.UseVisualStyleBackColor = true;
            this.btnExpediente.Click += new System.EventHandler(this.btnExpediente_Click);
            // 
            // pnlComentarioAprobador
            // 
            this.pnlComentarioAprobador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlComentarioAprobador.Controls.Add(this.lblBase1);
            this.pnlComentarioAprobador.Controls.Add(this.lblBase2);
            this.pnlComentarioAprobador.Controls.Add(this.txtComentarioAprobador);
            this.pnlComentarioAprobador.Location = new System.Drawing.Point(3, 3);
            this.pnlComentarioAprobador.Name = "pnlComentarioAprobador";
            this.pnlComentarioAprobador.Size = new System.Drawing.Size(601, 56);
            this.pnlComentarioAprobador.TabIndex = 12;
            // 
            // lblBase1
            // 
            this.lblBase1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(3, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(74, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Comentario";
            // 
            // lblBase2
            // 
            this.lblBase2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 31);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(72, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Aprobador:";
            // 
            // txtComentarioAprobador
            // 
            this.txtComentarioAprobador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComentarioAprobador.Location = new System.Drawing.Point(78, 3);
            this.txtComentarioAprobador.MaxLength = 500;
            this.txtComentarioAprobador.Multiline = true;
            this.txtComentarioAprobador.Name = "txtComentarioAprobador";
            this.txtComentarioAprobador.Size = new System.Drawing.Size(520, 50);
            this.txtComentarioAprobador.TabIndex = 9;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(676, 6);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolicitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolicitar.BackgroundImage")));
            this.btnSolicitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolicitar.Location = new System.Drawing.Point(742, 6);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(60, 50);
            this.btnSolicitar.TabIndex = 1;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolicitar.UseVisualStyleBackColor = true;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(808, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // bsExcepcionResum
            // 
            this.bsExcepcionResum.DataSource = typeof(EntityLayer.clsExcepReglaNegResum);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.LightSkyBlue;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(358, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(721, 25);
            this.miniToolStrip.TabIndex = 26;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(340, 22);
            this.toolStripLabel2.Text = "Solicitudes de Excepción y Regularización de Reglas Crediticias ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dtgSolicitud
            // 
            this.dtgSolicitud.AllowUserToAddRows = false;
            this.dtgSolicitud.AllowUserToDeleteRows = false;
            this.dtgSolicitud.AllowUserToResizeColumns = false;
            this.dtgSolicitud.AllowUserToResizeRows = false;
            this.dtgSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSolicitud.AutoGenerateColumns = false;
            this.dtgSolicitud.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitud.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSolicitudDataGridViewTextBoxColumn,
            this.dFechaRegistroDataGridViewTextBoxColumn,
            this.cUsuarioDataGridViewTextBoxColumn,
            this.cClienteDataGridViewTextBoxColumn,
            this.cOperacionDataGridViewTextBoxColumn,
            this.cProductoDataGridViewTextBoxColumn,
            this.nMontoDataGridViewTextBoxColumn,
            this.nPlazoCuotaDataGridViewTextBoxColumn,
            this.nCuotasDataGridViewTextBoxColumn,
            this.nTasaDataGridViewTextBoxColumn,
            this.ndiasgraciaDataGridViewTextBoxColumn,
            this.cAgenciaDataGridViewTextBoxColumn,
            this.nReglasDataGridViewTextBoxColumn,
            this.nSolicitados,
            this.nDerivadosDataGridViewTextBoxColumn,
            this.nAprobadosDataGridViewTextBoxColumn,
            this.nDenegadosDataGridViewTextBoxColumn});
            this.dtgSolicitud.DataSource = this.bsExcepcionResum;
            this.dtgSolicitud.Location = new System.Drawing.Point(3, 27);
            this.dtgSolicitud.MultiSelect = false;
            this.dtgSolicitud.Name = "dtgSolicitud";
            this.dtgSolicitud.ReadOnly = true;
            this.dtgSolicitud.RowHeadersVisible = false;
            this.dtgSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitud.Size = new System.Drawing.Size(865, 142);
            this.dtgSolicitud.TabIndex = 27;
            this.dtgSolicitud.SelectionChanged += new System.EventHandler(this.dtgSolicitud_SelectionChanged);
            // 
            // idSolicitudDataGridViewTextBoxColumn
            // 
            this.idSolicitudDataGridViewTextBoxColumn.DataPropertyName = "idSolicitud";
            this.idSolicitudDataGridViewTextBoxColumn.HeaderText = "Solicitud";
            this.idSolicitudDataGridViewTextBoxColumn.Name = "idSolicitudDataGridViewTextBoxColumn";
            this.idSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            this.idSolicitudDataGridViewTextBoxColumn.Width = 72;
            // 
            // dFechaRegistroDataGridViewTextBoxColumn
            // 
            this.dFechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "dFechaRegistro";
            this.dFechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.dFechaRegistroDataGridViewTextBoxColumn.Name = "dFechaRegistroDataGridViewTextBoxColumn";
            this.dFechaRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dFechaRegistroDataGridViewTextBoxColumn.Width = 62;
            // 
            // cUsuarioDataGridViewTextBoxColumn
            // 
            this.cUsuarioDataGridViewTextBoxColumn.DataPropertyName = "cUsuario";
            this.cUsuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.cUsuarioDataGridViewTextBoxColumn.Name = "cUsuarioDataGridViewTextBoxColumn";
            this.cUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUsuarioDataGridViewTextBoxColumn.Width = 68;
            // 
            // cClienteDataGridViewTextBoxColumn
            // 
            this.cClienteDataGridViewTextBoxColumn.DataPropertyName = "cCliente";
            this.cClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.cClienteDataGridViewTextBoxColumn.Name = "cClienteDataGridViewTextBoxColumn";
            this.cClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cClienteDataGridViewTextBoxColumn.Width = 64;
            // 
            // cOperacionDataGridViewTextBoxColumn
            // 
            this.cOperacionDataGridViewTextBoxColumn.DataPropertyName = "cOperacion";
            this.cOperacionDataGridViewTextBoxColumn.HeaderText = "Operacion";
            this.cOperacionDataGridViewTextBoxColumn.Name = "cOperacionDataGridViewTextBoxColumn";
            this.cOperacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOperacionDataGridViewTextBoxColumn.Width = 81;
            // 
            // cProductoDataGridViewTextBoxColumn
            // 
            this.cProductoDataGridViewTextBoxColumn.DataPropertyName = "cProducto";
            this.cProductoDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.cProductoDataGridViewTextBoxColumn.Name = "cProductoDataGridViewTextBoxColumn";
            this.cProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cProductoDataGridViewTextBoxColumn.Width = 75;
            // 
            // nMontoDataGridViewTextBoxColumn
            // 
            this.nMontoDataGridViewTextBoxColumn.DataPropertyName = "nMonto";
            this.nMontoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.nMontoDataGridViewTextBoxColumn.Name = "nMontoDataGridViewTextBoxColumn";
            this.nMontoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMontoDataGridViewTextBoxColumn.Width = 62;
            // 
            // nPlazoCuotaDataGridViewTextBoxColumn
            // 
            this.nPlazoCuotaDataGridViewTextBoxColumn.DataPropertyName = "nPlazoCuota";
            this.nPlazoCuotaDataGridViewTextBoxColumn.HeaderText = "PlzCt";
            this.nPlazoCuotaDataGridViewTextBoxColumn.Name = "nPlazoCuotaDataGridViewTextBoxColumn";
            this.nPlazoCuotaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nPlazoCuotaDataGridViewTextBoxColumn.Width = 56;
            // 
            // nCuotasDataGridViewTextBoxColumn
            // 
            this.nCuotasDataGridViewTextBoxColumn.DataPropertyName = "nCuotas";
            this.nCuotasDataGridViewTextBoxColumn.HeaderText = "Cuotas";
            this.nCuotasDataGridViewTextBoxColumn.Name = "nCuotasDataGridViewTextBoxColumn";
            this.nCuotasDataGridViewTextBoxColumn.ReadOnly = true;
            this.nCuotasDataGridViewTextBoxColumn.Width = 65;
            // 
            // nTasaDataGridViewTextBoxColumn
            // 
            this.nTasaDataGridViewTextBoxColumn.DataPropertyName = "nTasa";
            this.nTasaDataGridViewTextBoxColumn.HeaderText = "Tasa";
            this.nTasaDataGridViewTextBoxColumn.Name = "nTasaDataGridViewTextBoxColumn";
            this.nTasaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nTasaDataGridViewTextBoxColumn.Width = 56;
            // 
            // ndiasgraciaDataGridViewTextBoxColumn
            // 
            this.ndiasgraciaDataGridViewTextBoxColumn.DataPropertyName = "ndiasgracia";
            this.ndiasgraciaDataGridViewTextBoxColumn.HeaderText = "D.Gracia";
            this.ndiasgraciaDataGridViewTextBoxColumn.Name = "ndiasgraciaDataGridViewTextBoxColumn";
            this.ndiasgraciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.ndiasgraciaDataGridViewTextBoxColumn.Width = 74;
            // 
            // cAgenciaDataGridViewTextBoxColumn
            // 
            this.cAgenciaDataGridViewTextBoxColumn.DataPropertyName = "cAgencia";
            this.cAgenciaDataGridViewTextBoxColumn.HeaderText = "Agencia";
            this.cAgenciaDataGridViewTextBoxColumn.Name = "cAgenciaDataGridViewTextBoxColumn";
            this.cAgenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cAgenciaDataGridViewTextBoxColumn.Width = 71;
            // 
            // nReglasDataGridViewTextBoxColumn
            // 
            this.nReglasDataGridViewTextBoxColumn.DataPropertyName = "nReglas";
            this.nReglasDataGridViewTextBoxColumn.HeaderText = "Reglas";
            this.nReglasDataGridViewTextBoxColumn.Name = "nReglasDataGridViewTextBoxColumn";
            this.nReglasDataGridViewTextBoxColumn.ReadOnly = true;
            this.nReglasDataGridViewTextBoxColumn.Width = 65;
            // 
            // nSolicitados
            // 
            this.nSolicitados.DataPropertyName = "nSolicitados";
            this.nSolicitados.HeaderText = "Solicitados";
            this.nSolicitados.Name = "nSolicitados";
            this.nSolicitados.ReadOnly = true;
            this.nSolicitados.Width = 83;
            // 
            // nDerivadosDataGridViewTextBoxColumn
            // 
            this.nDerivadosDataGridViewTextBoxColumn.DataPropertyName = "nDerivados";
            this.nDerivadosDataGridViewTextBoxColumn.HeaderText = "Derivados";
            this.nDerivadosDataGridViewTextBoxColumn.Name = "nDerivadosDataGridViewTextBoxColumn";
            this.nDerivadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.nDerivadosDataGridViewTextBoxColumn.Width = 80;
            // 
            // nAprobadosDataGridViewTextBoxColumn
            // 
            this.nAprobadosDataGridViewTextBoxColumn.DataPropertyName = "nAprobados";
            this.nAprobadosDataGridViewTextBoxColumn.HeaderText = "Aprobados";
            this.nAprobadosDataGridViewTextBoxColumn.Name = "nAprobadosDataGridViewTextBoxColumn";
            this.nAprobadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.nAprobadosDataGridViewTextBoxColumn.Width = 83;
            // 
            // nDenegadosDataGridViewTextBoxColumn
            // 
            this.nDenegadosDataGridViewTextBoxColumn.DataPropertyName = "nDenegados";
            this.nDenegadosDataGridViewTextBoxColumn.HeaderText = "Denegados";
            this.nDenegadosDataGridViewTextBoxColumn.Name = "nDenegadosDataGridViewTextBoxColumn";
            this.nDenegadosDataGridViewTextBoxColumn.ReadOnly = true;
            this.nDenegadosDataGridViewTextBoxColumn.Width = 87;
            // 
            // pnlSolicitudExcepcion
            // 
            this.pnlSolicitudExcepcion.Controls.Add(this.dtgSolicitud);
            this.pnlSolicitudExcepcion.Controls.Add(this.toolStrip2);
            this.pnlSolicitudExcepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSolicitudExcepcion.Location = new System.Drawing.Point(3, 3);
            this.pnlSolicitudExcepcion.Name = "pnlSolicitudExcepcion";
            this.pnlSolicitudExcepcion.Size = new System.Drawing.Size(871, 172);
            this.pnlSolicitudExcepcion.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(871, 25);
            this.toolStrip2.TabIndex = 26;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCanSustReg);
            this.panel2.Controls.Add(this.btnAcepSustReg);
            this.panel2.Controls.Add(this.lblBase4);
            this.panel2.Controls.Add(this.txtSustentoReg);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.dtgRegularizacion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 206);
            this.panel2.TabIndex = 3;
            // 
            // btnCanSustReg
            // 
            this.btnCanSustReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanSustReg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCanSustReg.BackgroundImage")));
            this.btnCanSustReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCanSustReg.Location = new System.Drawing.Point(742, 153);
            this.btnCanSustReg.Name = "btnCanSustReg";
            this.btnCanSustReg.Size = new System.Drawing.Size(60, 50);
            this.btnCanSustReg.TabIndex = 36;
            this.btnCanSustReg.Text = "&Cancelar";
            this.btnCanSustReg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCanSustReg.UseVisualStyleBackColor = true;
            this.btnCanSustReg.Click += new System.EventHandler(this.btnCanSustReg_Click);
            // 
            // btnAcepSustReg
            // 
            this.btnAcepSustReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcepSustReg.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAcepSustReg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAcepSustReg.BackgroundImage")));
            this.btnAcepSustReg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAcepSustReg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcepSustReg.Location = new System.Drawing.Point(808, 153);
            this.btnAcepSustReg.Name = "btnAcepSustReg";
            this.btnAcepSustReg.Size = new System.Drawing.Size(60, 50);
            this.btnAcepSustReg.TabIndex = 34;
            this.btnAcepSustReg.Text = "&Aceptar";
            this.btnAcepSustReg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAcepSustReg.UseVisualStyleBackColor = true;
            this.btnAcepSustReg.Click += new System.EventHandler(this.btnAcepSustReg_Click);
            // 
            // lblBase4
            // 
            this.lblBase4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBase4.AutoSize = true;
            this.lblBase4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 163);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(62, 13);
            this.lblBase4.TabIndex = 35;
            this.lblBase4.Text = "Sustento:";
            // 
            // txtSustentoReg
            // 
            this.txtSustentoReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSustentoReg.BackColor = System.Drawing.SystemColors.Window;
            this.txtSustentoReg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSustentoReg.Location = new System.Drawing.Point(80, 133);
            this.txtSustentoReg.MaxLength = 500;
            this.txtSustentoReg.Multiline = true;
            this.txtSustentoReg.Name = "txtSustentoReg";
            this.txtSustentoReg.Size = new System.Drawing.Size(656, 70);
            this.txtSustentoReg.TabIndex = 33;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.toolStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsbAnularER,
            this.tsbQuitarER,
            this.tsbEditarER,
            this.tsbAgregarER,
            this.tsbDenegarReg,
            this.tsbAprobarReg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(871, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(283, 22);
            this.toolStripLabel1.Text = "Excepciones y Regularizaciones de Reglas Crediticias";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAnularER
            // 
            this.tsbAnularER.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAnularER.Image = global::CRE.Presentacion.Properties.Resources.delete;
            this.tsbAnularER.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnularER.Name = "tsbAnularER";
            this.tsbAnularER.Size = new System.Drawing.Size(62, 22);
            this.tsbAnularER.Text = "Anular";
            this.tsbAnularER.Click += new System.EventHandler(this.tsbAnularER_Click);
            // 
            // tsbQuitarER
            // 
            this.tsbQuitarER.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbQuitarER.Image = global::CRE.Presentacion.Properties.Resources.minus_16x16;
            this.tsbQuitarER.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuitarER.Name = "tsbQuitarER";
            this.tsbQuitarER.Size = new System.Drawing.Size(60, 22);
            this.tsbQuitarER.Text = "Quitar";
            this.tsbQuitarER.Click += new System.EventHandler(this.tsbQuitarER_Click);
            // 
            // tsbEditarER
            // 
            this.tsbEditarER.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbEditarER.Image = global::CRE.Presentacion.Properties.Resources.pencil_16x16;
            this.tsbEditarER.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditarER.Name = "tsbEditarER";
            this.tsbEditarER.Size = new System.Drawing.Size(57, 22);
            this.tsbEditarER.Text = "Editar";
            this.tsbEditarER.Click += new System.EventHandler(this.tsbEditarER_Click);
            // 
            // tsbAgregarER
            // 
            this.tsbAgregarER.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAgregarER.Image = global::CRE.Presentacion.Properties.Resources.add_16x16;
            this.tsbAgregarER.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAgregarER.Name = "tsbAgregarER";
            this.tsbAgregarER.Size = new System.Drawing.Size(69, 22);
            this.tsbAgregarER.Text = "Agregar";
            this.tsbAgregarER.Click += new System.EventHandler(this.tsbAgregarER_Click);
            // 
            // tsbDenegarReg
            // 
            this.tsbDenegarReg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDenegarReg.Image = global::CRE.Presentacion.Properties.Resources.prohibition_16x16;
            this.tsbDenegarReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDenegarReg.Name = "tsbDenegarReg";
            this.tsbDenegarReg.Size = new System.Drawing.Size(71, 22);
            this.tsbDenegarReg.Text = "Denegar";
            this.tsbDenegarReg.Click += new System.EventHandler(this.tsbDenegarReg_Click);
            // 
            // tsbAprobarReg
            // 
            this.tsbAprobarReg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAprobarReg.Image = global::CRE.Presentacion.Properties.Resources.check_16x16;
            this.tsbAprobarReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAprobarReg.Name = "tsbAprobarReg";
            this.tsbAprobarReg.Size = new System.Drawing.Size(70, 22);
            this.tsbAprobarReg.Text = "Aprobar";
            this.tsbAprobarReg.Click += new System.EventHandler(this.tsbAprobarReg_Click);
            // 
            // dtgRegularizacion
            // 
            this.dtgRegularizacion.AllowUserToAddRows = false;
            this.dtgRegularizacion.AllowUserToDeleteRows = false;
            this.dtgRegularizacion.AllowUserToResizeColumns = false;
            this.dtgRegularizacion.AllowUserToResizeRows = false;
            this.dtgRegularizacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgRegularizacion.AutoGenerateColumns = false;
            this.dtgRegularizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegularizacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgRegularizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegularizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lAutomaticoDataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.idRegla,
            this.cAcronimo,
            this.cReglaDataGridViewTextBoxColumn1,
            this.dFechaDataGridViewTextBoxColumn1});
            this.dtgRegularizacion.DataSource = this.bsRegularizacion;
            this.dtgRegularizacion.Location = new System.Drawing.Point(3, 28);
            this.dtgRegularizacion.MultiSelect = false;
            this.dtgRegularizacion.Name = "dtgRegularizacion";
            this.dtgRegularizacion.ReadOnly = true;
            this.dtgRegularizacion.RowHeadersVisible = false;
            this.dtgRegularizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegularizacion.Size = new System.Drawing.Size(865, 99);
            this.dtgRegularizacion.TabIndex = 32;
            this.dtgRegularizacion.SelectionChanged += new System.EventHandler(this.dtgRegularizacion_SelectionChanged);
            // 
            // lAutomaticoDataGridViewCheckBoxColumn1
            // 
            this.lAutomaticoDataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lAutomaticoDataGridViewCheckBoxColumn1.DataPropertyName = "lAutomatico";
            this.lAutomaticoDataGridViewCheckBoxColumn1.FillWeight = 38.57714F;
            this.lAutomaticoDataGridViewCheckBoxColumn1.HeaderText = "Auto";
            this.lAutomaticoDataGridViewCheckBoxColumn1.Name = "lAutomaticoDataGridViewCheckBoxColumn1";
            this.lAutomaticoDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.lAutomaticoDataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "cEstado";
            this.dataGridViewTextBoxColumn1.FillWeight = 50.76142F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // idRegla
            // 
            this.idRegla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idRegla.DataPropertyName = "idRegla";
            this.idRegla.FillWeight = 30F;
            this.idRegla.HeaderText = "NºRegla";
            this.idRegla.Name = "idRegla";
            this.idRegla.ReadOnly = true;
            this.idRegla.Width = 60;
            // 
            // cAcronimo
            // 
            this.cAcronimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cAcronimo.DataPropertyName = "cNombreCorto";
            this.cAcronimo.FillWeight = 35.69502F;
            this.cAcronimo.HeaderText = "Canal";
            this.cAcronimo.MaxInputLength = 10;
            this.cAcronimo.Name = "cAcronimo";
            this.cAcronimo.ReadOnly = true;
            this.cAcronimo.Width = 70;
            // 
            // cReglaDataGridViewTextBoxColumn1
            // 
            this.cReglaDataGridViewTextBoxColumn1.DataPropertyName = "cRegla";
            this.cReglaDataGridViewTextBoxColumn1.FillWeight = 73.96714F;
            this.cReglaDataGridViewTextBoxColumn1.HeaderText = "Mensaje de Regla";
            this.cReglaDataGridViewTextBoxColumn1.Name = "cReglaDataGridViewTextBoxColumn1";
            this.cReglaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dFechaDataGridViewTextBoxColumn1
            // 
            this.dFechaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dFechaDataGridViewTextBoxColumn1.DataPropertyName = "dFecha";
            this.dFechaDataGridViewTextBoxColumn1.FillWeight = 0.9992834F;
            this.dFechaDataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.dFechaDataGridViewTextBoxColumn1.Name = "dFechaDataGridViewTextBoxColumn1";
            this.dFechaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dFechaDataGridViewTextBoxColumn1.Width = 70;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pnlSolicitudExcepcion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(300, 300);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // frmGestionReglasNegExcepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGestionReglasNegExcepcion";
            this.Text = "Gestión de Excepciones de Reglas Crediticias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGestionReglasNegExcepcion_FormClosing);
            this.Load += new System.EventHandler(this.frmGestionReglasNegExcepcion_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bsExcepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRegularizacion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlComentarioAprobador.ResumeLayout(false);
            this.pnlComentarioAprobador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsExcepcionResum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitud)).EndInit();
            this.pnlSolicitudExcepcion.ResumeLayout(false);
            this.pnlSolicitudExcepcion.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegularizacion)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnSolicitar btnSolicitar;
        private System.Windows.Forms.BindingSource bsExcepcion;
        private System.Windows.Forms.BindingSource bsRegularizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nEnviadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsExcepcionResum;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtComentarioAprobador;
        private System.Windows.Forms.Panel pnlComentarioAprobador;
        private GEN.BotonesBase.Boton btnExpediente;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private GEN.ControlesBase.dtgBase dtgSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOperacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPlazoCuotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCuotasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTasaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ndiasgraciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAgenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nReglasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSolicitados;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDerivadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAprobadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDenegadosDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel pnlSolicitudExcepcion;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel2;
        private GEN.BotonesBase.BtnAceptar btnAcepSustReg;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtSustentoReg;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAnularER;
        private System.Windows.Forms.ToolStripButton tsbQuitarER;
        private System.Windows.Forms.ToolStripButton tsbEditarER;
        private System.Windows.Forms.ToolStripButton tsbAgregarER;
        private System.Windows.Forms.ToolStripButton tsbDenegarReg;
        private System.Windows.Forms.ToolStripButton tsbAprobarReg;
        private GEN.ControlesBase.dtgBase dtgRegularizacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GEN.BotonesBase.btnCancelar btnCanSustReg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lAutomaticoDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRegla;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAcronimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReglaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaDataGridViewTextBoxColumn1;
    }
}