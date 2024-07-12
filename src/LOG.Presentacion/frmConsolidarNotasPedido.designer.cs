namespace LOG.Presentacion
{
    partial class frmConsolidarNotasPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsolidarNotasPedido));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleNP = new GEN.ControlesBase.dtgBase(this.components);
            this.grbNotaPedAdj = new GEN.ControlesBase.grbBase(this.components);
            this.txtActividad = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgNotasPedido = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboTipoPedidoLog = new GEN.ControlesBase.cboTipoPedidoLog(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.dtpFechaNP = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtEstadoNP = new GEN.ControlesBase.txtBase(this.components);
            this.txtCBNumNP = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtIgv = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcIgv = new GEN.ControlesBase.chcBase(this.components);
            this.txtConvertido = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSubTotal = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.txtObjetivoNP = new GEN.ControlesBase.txtBase(this.components);
            this.idNotaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaNotaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuarioGen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nIGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).BeginInit();
            this.grbNotaPedAdj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasPedido)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleNP);
            this.grbBase1.Location = new System.Drawing.Point(9, 224);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(704, 169);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Items:";
            // 
            // dtgDetalleNP
            // 
            this.dtgDetalleNP.AllowUserToAddRows = false;
            this.dtgDetalleNP.AllowUserToDeleteRows = false;
            this.dtgDetalleNP.AllowUserToResizeColumns = false;
            this.dtgDetalleNP.AllowUserToResizeRows = false;
            this.dtgDetalleNP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nItem,
            this.idCatalogo,
            this.cProducto,
            this.cUnidad,
            this.nCantidad,
            this.nPrecioUnit});
            this.dtgDetalleNP.Location = new System.Drawing.Point(10, 19);
            this.dtgDetalleNP.MultiSelect = false;
            this.dtgDetalleNP.Name = "dtgDetalleNP";
            this.dtgDetalleNP.ReadOnly = true;
            this.dtgDetalleNP.RowHeadersVisible = false;
            this.dtgDetalleNP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleNP.Size = new System.Drawing.Size(688, 139);
            this.dtgDetalleNP.TabIndex = 5;
            // 
            // grbNotaPedAdj
            // 
            this.grbNotaPedAdj.Controls.Add(this.txtActividad);
            this.grbNotaPedAdj.Controls.Add(this.lblBase7);
            this.grbNotaPedAdj.Controls.Add(this.btnQuitar);
            this.grbNotaPedAdj.Controls.Add(this.btnAgregar);
            this.grbNotaPedAdj.Controls.Add(this.dtgNotasPedido);
            this.grbNotaPedAdj.ForeColor = System.Drawing.Color.Navy;
            this.grbNotaPedAdj.Location = new System.Drawing.Point(9, 79);
            this.grbNotaPedAdj.Name = "grbNotaPedAdj";
            this.grbNotaPedAdj.Size = new System.Drawing.Size(704, 143);
            this.grbNotaPedAdj.TabIndex = 1;
            this.grbNotaPedAdj.TabStop = false;
            this.grbNotaPedAdj.Text = "Notas de Pedido";
            // 
            // txtActividad
            // 
            this.txtActividad.Enabled = false;
            this.txtActividad.Location = new System.Drawing.Point(77, 117);
            this.txtActividad.Name = "txtActividad";
            this.txtActividad.Size = new System.Drawing.Size(579, 20);
            this.txtActividad.TabIndex = 65;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(7, 120);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(64, 13);
            this.lblBase7.TabIndex = 64;
            this.lblBase7.Text = "Actividad:";
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(662, 44);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnQuitar.TabIndex = 1;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(662, 14);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgNotasPedido
            // 
            this.dtgNotasPedido.AllowUserToAddRows = false;
            this.dtgNotasPedido.AllowUserToDeleteRows = false;
            this.dtgNotasPedido.AllowUserToResizeColumns = false;
            this.dtgNotasPedido.AllowUserToResizeRows = false;
            this.dtgNotasPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNotasPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotasPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idNotaPedido,
            this.dFechaNotaPedido,
            this.cAgencia,
            this.cArea,
            this.cUsuarioGen,
            this.nTotalCosto,
            this.nIGV});
            this.dtgNotasPedido.Location = new System.Drawing.Point(7, 14);
            this.dtgNotasPedido.MultiSelect = false;
            this.dtgNotasPedido.Name = "dtgNotasPedido";
            this.dtgNotasPedido.ReadOnly = true;
            this.dtgNotasPedido.RowHeadersVisible = false;
            this.dtgNotasPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotasPedido.Size = new System.Drawing.Size(649, 99);
            this.dtgNotasPedido.TabIndex = 2;
            this.dtgNotasPedido.SelectionChanged += new System.EventHandler(this.dtgNotasPedido_SelectionChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(419, 489);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(419, 489);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(483, 489);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(546, 489);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(483, 489);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 50;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(647, 489);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.cboTipoPedidoLog);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.cboAgencia);
            this.grbBase2.Controls.Add(this.dtpFechaNP);
            this.grbBase2.Controls.Add(this.btnBusqueda);
            this.grbBase2.Controls.Add(this.txtEstadoNP);
            this.grbBase2.Controls.Add(this.txtCBNumNP);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Location = new System.Drawing.Point(9, 3);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(704, 70);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos Nota de Pedido";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(518, 41);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(116, 21);
            this.cboMoneda.TabIndex = 11;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(459, 46);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Moneda:";
            // 
            // cboTipoPedidoLog
            // 
            this.cboTipoPedidoLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedidoLog.Enabled = false;
            this.cboTipoPedidoLog.FormattingEnabled = true;
            this.cboTipoPedidoLog.Location = new System.Drawing.Point(313, 43);
            this.cboTipoPedidoLog.Name = "cboTipoPedidoLog";
            this.cboTipoPedidoLog.Size = new System.Drawing.Size(138, 21);
            this.cboTipoPedidoLog.TabIndex = 7;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(233, 47);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Tipo Pedido:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(6, 47);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(84, 13);
            this.lblBase10.TabIndex = 2;
            this.lblBase10.Text = "Agencia Gen:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.Enabled = false;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(92, 43);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(136, 21);
            this.cboAgencia.TabIndex = 3;
            // 
            // dtpFechaNP
            // 
            this.dtpFechaNP.Enabled = false;
            this.dtpFechaNP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNP.Location = new System.Drawing.Point(518, 16);
            this.dtpFechaNP.Name = "dtpFechaNP";
            this.dtpFechaNP.Size = new System.Drawing.Size(116, 20);
            this.dtpFechaNP.TabIndex = 9;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(638, 14);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 12;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtEstadoNP
            // 
            this.txtEstadoNP.Enabled = false;
            this.txtEstadoNP.Location = new System.Drawing.Point(313, 18);
            this.txtEstadoNP.Name = "txtEstadoNP";
            this.txtEstadoNP.Size = new System.Drawing.Size(138, 20);
            this.txtEstadoNP.TabIndex = 5;
            // 
            // txtCBNumNP
            // 
            this.txtCBNumNP.Location = new System.Drawing.Point(92, 18);
            this.txtCBNumNP.MaxLength = 9;
            this.txtCBNumNP.Name = "txtCBNumNP";
            this.txtCBNumNP.Size = new System.Drawing.Size(136, 20);
            this.txtCBNumNP.TabIndex = 1;
            this.txtCBNumNP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCBNumNP_KeyPress);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(470, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 8;
            this.lblBase5.Text = "Fecha:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(69, 13);
            this.lblBase4.TabIndex = 0;
            this.lblBase4.Text = "Nro de NP:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(261, 21);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(50, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Estado:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.FormatoDecimal = true;
            this.txtTotal.Location = new System.Drawing.Point(585, 441);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotal.nNumDecimales = 2;
            this.txtTotal.nvalor = 0D;
            this.txtTotal.Size = new System.Drawing.Size(122, 20);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(543, 444);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(40, 13);
            this.lblBase11.TabIndex = 62;
            this.lblBase11.Text = "Total:";
            // 
            // txtIgv
            // 
            this.txtIgv.Enabled = false;
            this.txtIgv.FormatoDecimal = true;
            this.txtIgv.Location = new System.Drawing.Point(585, 418);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIgv.nNumDecimales = 2;
            this.txtIgv.nvalor = 0D;
            this.txtIgv.Size = new System.Drawing.Size(122, 20);
            this.txtIgv.TabIndex = 5;
            this.txtIgv.Text = "0.00";
            this.txtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chcIgv
            // 
            this.chcIgv.AutoSize = true;
            this.chcIgv.Enabled = false;
            this.chcIgv.ForeColor = System.Drawing.Color.Navy;
            this.chcIgv.Location = new System.Drawing.Point(482, 420);
            this.chcIgv.Name = "chcIgv";
            this.chcIgv.Size = new System.Drawing.Size(101, 17);
            this.chcIgv.TabIndex = 55;
            this.chcIgv.Text = "Incluir  IGV 18%";
            this.chcIgv.UseVisualStyleBackColor = true;
            // 
            // txtConvertido
            // 
            this.txtConvertido.Enabled = false;
            this.txtConvertido.FormatoDecimal = true;
            this.txtConvertido.Location = new System.Drawing.Point(585, 462);
            this.txtConvertido.Name = "txtConvertido";
            this.txtConvertido.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtConvertido.nNumDecimales = 2;
            this.txtConvertido.nvalor = 0D;
            this.txtConvertido.Size = new System.Drawing.Size(122, 20);
            this.txtConvertido.TabIndex = 7;
            this.txtConvertido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.FormatoDecimal = true;
            this.txtSubTotal.Location = new System.Drawing.Point(585, 396);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSubTotal.nNumDecimales = 2;
            this.txtSubTotal.nvalor = 0D;
            this.txtSubTotal.Size = new System.Drawing.Size(122, 20);
            this.txtSubTotal.TabIndex = 4;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(508, 466);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(75, 13);
            this.lblBase15.TabIndex = 58;
            this.lblBase15.Text = "Convertido:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(517, 399);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(66, 13);
            this.lblBase6.TabIndex = 57;
            this.lblBase6.Text = "Sub Total:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(16, 396);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(123, 13);
            this.lblBase12.TabIndex = 56;
            this.lblBase12.Text = "Objetivo del Pedido:";
            // 
            // txtObjetivoNP
            // 
            this.txtObjetivoNP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObjetivoNP.Enabled = false;
            this.txtObjetivoNP.Location = new System.Drawing.Point(19, 412);
            this.txtObjetivoNP.Multiline = true;
            this.txtObjetivoNP.Name = "txtObjetivoNP";
            this.txtObjetivoNP.Size = new System.Drawing.Size(450, 71);
            this.txtObjetivoNP.TabIndex = 3;
            // 
            // idNotaPedido
            // 
            this.idNotaPedido.DataPropertyName = "idNotaPedido";
            this.idNotaPedido.HeaderText = "Nota Pedido";
            this.idNotaPedido.Name = "idNotaPedido";
            this.idNotaPedido.ReadOnly = true;
            // 
            // dFechaNotaPedido
            // 
            this.dFechaNotaPedido.DataPropertyName = "dFechaNotaPedido";
            this.dFechaNotaPedido.HeaderText = "Fecha";
            this.dFechaNotaPedido.Name = "dFechaNotaPedido";
            this.dFechaNotaPedido.ReadOnly = true;
            // 
            // cAgencia
            // 
            this.cAgencia.DataPropertyName = "cAgencia";
            this.cAgencia.HeaderText = "Agencia";
            this.cAgencia.Name = "cAgencia";
            this.cAgencia.ReadOnly = true;
            // 
            // cArea
            // 
            this.cArea.DataPropertyName = "cArea";
            this.cArea.HeaderText = "Area";
            this.cArea.Name = "cArea";
            this.cArea.ReadOnly = true;
            // 
            // cUsuarioGen
            // 
            this.cUsuarioGen.DataPropertyName = "cUsuarioGen";
            this.cUsuarioGen.HeaderText = "Usuario";
            this.cUsuarioGen.Name = "cUsuarioGen";
            this.cUsuarioGen.ReadOnly = true;
            // 
            // nTotalCosto
            // 
            this.nTotalCosto.DataPropertyName = "nTotalCosto";
            this.nTotalCosto.HeaderText = "Costo Total";
            this.nTotalCosto.Name = "nTotalCosto";
            this.nTotalCosto.ReadOnly = true;
            // 
            // nIGV
            // 
            this.nIGV.DataPropertyName = "nIGV";
            this.nIGV.HeaderText = "IGV";
            this.nIGV.Name = "nIGV";
            this.nIGV.ReadOnly = true;
            // 
            // nItem
            // 
            this.nItem.DataPropertyName = "nItem";
            this.nItem.HeaderText = "Item";
            this.nItem.Name = "nItem";
            this.nItem.ReadOnly = true;
            // 
            // idCatalogo
            // 
            this.idCatalogo.DataPropertyName = "idCatalogo";
            this.idCatalogo.HeaderText = "Código";
            this.idCatalogo.Name = "idCatalogo";
            this.idCatalogo.ReadOnly = true;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cUnidad
            // 
            this.cUnidad.DataPropertyName = "cUnidad";
            this.cUnidad.HeaderText = "Unidad";
            this.cUnidad.Name = "cUnidad";
            this.cUnidad.ReadOnly = true;
            // 
            // nCantidad
            // 
            this.nCantidad.DataPropertyName = "nCantidad";
            this.nCantidad.HeaderText = "Cantidad";
            this.nCantidad.Name = "nCantidad";
            this.nCantidad.ReadOnly = true;
            // 
            // nPrecioUnit
            // 
            this.nPrecioUnit.DataPropertyName = "nPrecioUnit";
            this.nPrecioUnit.HeaderText = "Precio Unit";
            this.nPrecioUnit.Name = "nPrecioUnit";
            this.nPrecioUnit.ReadOnly = true;
            // 
            // frmConsolidarNotasPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 565);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.txtIgv);
            this.Controls.Add(this.chcIgv);
            this.Controls.Add(this.txtConvertido);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblBase15);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.txtObjetivoNP);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbNotaPedAdj);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmConsolidarNotasPedido";
            this.Text = "Consolidar Notas de Pedido";
            this.Load += new System.EventHandler(this.frmConsolidarNotasPedido_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbNotaPedAdj, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.txtObjetivoNP, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase15, 0);
            this.Controls.SetChildIndex(this.txtSubTotal, 0);
            this.Controls.SetChildIndex(this.txtConvertido, 0);
            this.Controls.SetChildIndex(this.chcIgv, 0);
            this.Controls.SetChildIndex(this.txtIgv, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNP)).EndInit();
            this.grbNotaPedAdj.ResumeLayout(false);
            this.grbNotaPedAdj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasPedido)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgDetalleNP;
        private GEN.ControlesBase.grbBase grbNotaPedAdj;
        private GEN.BotonesBase.btnMiniQuitar btnQuitar;
        private GEN.BotonesBase.btnMiniAgregar btnAgregar;
        private GEN.ControlesBase.dtgBase dtgNotasPedido;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaNP;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.txtBase txtEstadoNP;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNumNP;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoPedidoLog cboTipoPedidoLog;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtTotal;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtNumRea txtIgv;
        private GEN.ControlesBase.chcBase chcIgv;
        private GEN.ControlesBase.txtNumRea txtConvertido;
        private GEN.ControlesBase.txtNumRea txtSubTotal;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.txtBase txtObjetivoNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGrupoActivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nsubTotalDataGridViewTextBoxColumn;
        private GEN.ControlesBase.txtCBLetra txtActividad;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nIncluImpuestoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPrecioUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNotaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaNotaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuarioGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nIGV;
    }
}