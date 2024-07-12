namespace LOG.Presentacion
{
    partial class frmBusNotaSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusNotaSalida));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbParametros = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboEstadoProcLog = new GEN.ControlesBase.cboEstadoProcLog(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgNotSalida = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgItems = new GEN.ControlesBase.dtgBase(this.components);
            this.idDetalleNotaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUniMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadApro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadAten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grbParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).BeginInit();
            this.grbBase4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(578, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(512, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbParametros
            // 
            this.grbParametros.Controls.Add(this.btnBusqueda);
            this.grbParametros.Controls.Add(this.lblBase4);
            this.grbParametros.Controls.Add(this.lblBase3);
            this.grbParametros.Controls.Add(this.dtpFecFin);
            this.grbParametros.Controls.Add(this.dtpFecIni);
            this.grbParametros.Controls.Add(this.lblBase2);
            this.grbParametros.Controls.Add(this.cboEstadoProcLog);
            this.grbParametros.Controls.Add(this.cboAgencias);
            this.grbParametros.Controls.Add(this.lblBase1);
            this.grbParametros.Location = new System.Drawing.Point(0, 0);
            this.grbParametros.Name = "grbParametros";
            this.grbParametros.Size = new System.Drawing.Size(638, 74);
            this.grbParametros.TabIndex = 4;
            this.grbParametros.TabStop = false;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(572, 13);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 8;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(276, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(74, 13);
            this.lblBase4.TabIndex = 7;
            this.lblBase4.Text = "Fec. Salida:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 49);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(70, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Fec. Inicio:";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(356, 43);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(161, 20);
            this.dtpFecFin.TabIndex = 5;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(79, 43);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(161, 20);
            this.dtpFecIni.TabIndex = 4;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(300, 17);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Estado:";
            // 
            // cboEstadoProcLog
            // 
            this.cboEstadoProcLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoProcLog.FormattingEnabled = true;
            this.cboEstadoProcLog.Location = new System.Drawing.Point(356, 13);
            this.cboEstadoProcLog.Name = "cboEstadoProcLog";
            this.cboEstadoProcLog.Size = new System.Drawing.Size(210, 21);
            this.cboEstadoProcLog.TabIndex = 2;
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(79, 14);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(210, 21);
            this.cboAgencias.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Agencia:";
            // 
            // dtgNotSalida
            // 
            this.dtgNotSalida.AllowUserToAddRows = false;
            this.dtgNotSalida.AllowUserToDeleteRows = false;
            this.dtgNotSalida.AllowUserToResizeColumns = false;
            this.dtgNotSalida.AllowUserToResizeRows = false;
            this.dtgNotSalida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNotSalida.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgNotSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgNotSalida.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgNotSalida.Location = new System.Drawing.Point(0, 80);
            this.dtgNotSalida.MultiSelect = false;
            this.dtgNotSalida.Name = "dtgNotSalida";
            this.dtgNotSalida.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgNotSalida.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgNotSalida.RowHeadersVisible = false;
            this.dtgNotSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotSalida.Size = new System.Drawing.Size(638, 160);
            this.dtgNotSalida.TabIndex = 57;
            this.dtgNotSalida.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgNotSalida_CellDoubleClick);
            // 
            // dtgItems
            // 
            this.dtgItems.AllowUserToAddRows = false;
            this.dtgItems.AllowUserToDeleteRows = false;
            this.dtgItems.AllowUserToResizeColumns = false;
            this.dtgItems.AllowUserToResizeRows = false;
            this.dtgItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleNotaSalida,
            this.idUniMedida,
            this.objCatalogo,
            this.cProducto,
            this.cUnidMedida,
            this.nStock,
            this.nCantidadSol,
            this.nCantidadApro,
            this.nCantidadAten,
            this.lVigente,
            this.nPrecioUnitario});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItems.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtgItems.Location = new System.Drawing.Point(3, 3);
            this.dtgItems.MultiSelect = false;
            this.dtgItems.Name = "dtgItems";
            this.dtgItems.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgItems.RowHeadersVisible = false;
            this.dtgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgItems.Size = new System.Drawing.Size(638, 140);
            this.dtgItems.TabIndex = 58;
            // 
            // idDetalleNotaSalida
            // 
            this.idDetalleNotaSalida.DataPropertyName = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.HeaderText = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.Name = "idDetalleNotaSalida";
            this.idDetalleNotaSalida.ReadOnly = true;
            this.idDetalleNotaSalida.Visible = false;
            // 
            // idUniMedida
            // 
            this.idUniMedida.DataPropertyName = "idUniMedida";
            this.idUniMedida.HeaderText = "idUniMedida ";
            this.idUniMedida.Name = "idUniMedida";
            this.idUniMedida.ReadOnly = true;
            this.idUniMedida.Visible = false;
            // 
            // objCatalogo
            // 
            this.objCatalogo.DataPropertyName = "objCatalogo";
            this.objCatalogo.HeaderText = "objCatalogo ";
            this.objCatalogo.Name = "objCatalogo";
            this.objCatalogo.ReadOnly = true;
            this.objCatalogo.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.FillWeight = 166.1138F;
            this.cProducto.HeaderText = "Producto ";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cUnidMedida
            // 
            this.cUnidMedida.DataPropertyName = "cUnidMedida";
            this.cUnidMedida.FillWeight = 55.37127F;
            this.cUnidMedida.HeaderText = "Unidad";
            this.cUnidMedida.Name = "cUnidMedida";
            this.cUnidMedida.ReadOnly = true;
            // 
            // nStock
            // 
            this.nStock.FillWeight = 55.37127F;
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            // 
            // nCantidadSol
            // 
            this.nCantidadSol.DataPropertyName = "nCantidadSol";
            this.nCantidadSol.FillWeight = 66.44552F;
            this.nCantidadSol.HeaderText = "Cant. Solicitada";
            this.nCantidadSol.Name = "nCantidadSol";
            this.nCantidadSol.ReadOnly = true;
            // 
            // nCantidadApro
            // 
            this.nCantidadApro.DataPropertyName = "nCantidadApro";
            this.nCantidadApro.FillWeight = 66.44552F;
            this.nCantidadApro.HeaderText = "Cant. Aprobada";
            this.nCantidadApro.Name = "nCantidadApro";
            this.nCantidadApro.ReadOnly = true;
            // 
            // nCantidadAten
            // 
            this.nCantidadAten.DataPropertyName = "nCantidadAten";
            this.nCantidadAten.FillWeight = 66.44552F;
            this.nCantidadAten.HeaderText = "Cant. Atendida";
            this.nCantidadAten.Name = "nCantidadAten";
            this.nCantidadAten.ReadOnly = true;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // nPrecioUnitario
            // 
            this.nPrecioUnitario.DataPropertyName = "nPrecioUnitario";
            this.nPrecioUnitario.HeaderText = "nPrecioUnitario";
            this.nPrecioUnitario.Name = "nPrecioUnitario";
            this.nPrecioUnitario.ReadOnly = true;
            this.nPrecioUnitario.Visible = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.txtSustento);
            this.grbBase4.Location = new System.Drawing.Point(3, 149);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(638, 97);
            this.grbBase4.TabIndex = 93;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Sustento";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(7, 19);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSustento.Size = new System.Drawing.Size(625, 75);
            this.txtSustento.TabIndex = 10;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(3, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 94;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.pnlDetalle);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(660, 571);
            this.flowLayoutPanel1.TabIndex = 95;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbParametros);
            this.panel1.Controls.Add(this.dtgNotSalida);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 242);
            this.panel1.TabIndex = 0;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.grbBase4);
            this.pnlDetalle.Controls.Add(this.dtgItems);
            this.pnlDetalle.Location = new System.Drawing.Point(3, 251);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(644, 246);
            this.pnlDetalle.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnImprimir);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Location = new System.Drawing.Point(3, 503);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 56);
            this.panel3.TabIndex = 2;
            // 
            // frmBusNotaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(660, 593);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmBusNotaSalida";
            this.Text = "Buscar Solicitud de Requerimiento";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.grbParametros.ResumeLayout(false);
            this.grbParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).EndInit();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.grbBase grbParametros;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboEstadoProcLog cboEstadoProcLog;
        private GEN.ControlesBase.cboAgencia cboAgencias;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgNotSalida;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtgBase dtgItems;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleNotaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUniMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn objCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadApro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadAten;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPrecioUnitario;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Panel panel3;
    }
}

