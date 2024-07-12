namespace LOG.Presentacion
{
    partial class frmNotaSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotaSalida));
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtCBEstUsuSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCBAreaSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtCBUsuarioSol = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtCBNombre = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboActividadLog = new GEN.ControlesBase.cboActividadLog(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetalleNS = new GEN.ControlesBase.dtgBase(this.components);
            this.txtNumNotaSal = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaNS = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.txtEstadoNotaSal = new GEN.ControlesBase.txtBase(this.components);
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboDestinoPedido = new GEN.ControlesBase.cboDestinoPedido(this.components);
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.idDetalleNotaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUniMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objCatalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnidMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCantidadApro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.txtCBEstUsuSol);
            this.grbBase3.Controls.Add(this.txtCBAreaSol);
            this.grbBase3.Controls.Add(this.lblBase9);
            this.grbBase3.Controls.Add(this.txtCBUsuarioSol);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.txtCBNombre);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(21, 95);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(695, 79);
            this.grbBase3.TabIndex = 8;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de Solicitante:";
            // 
            // txtCBEstUsuSol
            // 
            this.txtCBEstUsuSol.Enabled = false;
            this.txtCBEstUsuSol.Location = new System.Drawing.Point(551, 48);
            this.txtCBEstUsuSol.Name = "txtCBEstUsuSol";
            this.txtCBEstUsuSol.Size = new System.Drawing.Size(138, 20);
            this.txtCBEstUsuSol.TabIndex = 3;
            // 
            // txtCBAreaSol
            // 
            this.txtCBAreaSol.Enabled = false;
            this.txtCBAreaSol.Location = new System.Drawing.Point(112, 49);
            this.txtCBAreaSol.Name = "txtCBAreaSol";
            this.txtCBAreaSol.Size = new System.Drawing.Size(344, 20);
            this.txtCBAreaSol.TabIndex = 1;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(491, 52);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(50, 13);
            this.lblBase9.TabIndex = 18;
            this.lblBase9.Text = "Estado:";
            // 
            // txtCBUsuarioSol
            // 
            this.txtCBUsuarioSol.Enabled = false;
            this.txtCBUsuarioSol.Location = new System.Drawing.Point(551, 23);
            this.txtCBUsuarioSol.Name = "txtCBUsuarioSol";
            this.txtCBUsuarioSol.Size = new System.Drawing.Size(138, 20);
            this.txtCBUsuarioSol.TabIndex = 2;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(67, 52);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(39, 13);
            this.lblBase7.TabIndex = 15;
            this.lblBase7.Text = "Area:";
            // 
            // txtCBNombre
            // 
            this.txtCBNombre.Enabled = false;
            this.txtCBNombre.Location = new System.Drawing.Point(112, 24);
            this.txtCBNombre.Name = "txtCBNombre";
            this.txtCBNombre.Size = new System.Drawing.Size(344, 20);
            this.txtCBNombre.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(7, 28);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(104, 13);
            this.lblBase6.TabIndex = 13;
            this.lblBase6.Text = "Ape. y Nombres:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(491, 27);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(55, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Usuario:";
            // 
            // cboActividadLog
            // 
            this.cboActividadLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividadLog.Enabled = false;
            this.cboActividadLog.FormattingEnabled = true;
            this.cboActividadLog.Location = new System.Drawing.Point(133, 180);
            this.cboActividadLog.Name = "cboActividadLog";
            this.cboActividadLog.Size = new System.Drawing.Size(344, 21);
            this.cboActividadLog.TabIndex = 5;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(63, 184);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(64, 13);
            this.lblBase13.TabIndex = 4;
            this.lblBase13.Text = "Actividad:";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(566, 21);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(84, 13);
            this.lblBase10.TabIndex = 6;
            this.lblBase10.Text = "Agencia Gen:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(572, 37);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(145, 21);
            this.cboAgencia.TabIndex = 7;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia_SelectedIndexChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgDetalleNS);
            this.grbBase1.Location = new System.Drawing.Point(11, 232);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(641, 169);
            this.grbBase1.TabIndex = 11;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Items:";
            // 
            // dtgDetalleNS
            // 
            this.dtgDetalleNS.AllowUserToAddRows = false;
            this.dtgDetalleNS.AllowUserToDeleteRows = false;
            this.dtgDetalleNS.AllowUserToResizeColumns = false;
            this.dtgDetalleNS.AllowUserToResizeRows = false;
            this.dtgDetalleNS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleNotaSalida,
            this.idUniMedida,
            this.idCatalogo,
            this.objCatalogo,
            this.cProducto,
            this.cUnidMedida,
            this.nStock,
            this.nCantidadSol,
            this.nCantidadApro,
            this.lVigente});
            this.dtgDetalleNS.Location = new System.Drawing.Point(10, 19);
            this.dtgDetalleNS.MultiSelect = false;
            this.dtgDetalleNS.Name = "dtgDetalleNS";
            this.dtgDetalleNS.ReadOnly = true;
            this.dtgDetalleNS.RowHeadersVisible = false;
            this.dtgDetalleNS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgDetalleNS.Size = new System.Drawing.Size(625, 139);
            this.dtgDetalleNS.TabIndex = 5;
            this.dtgDetalleNS.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgDetalleNS_CellValidating);
            this.dtgDetalleNS.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgDetalleNS_EditingControlShowing);
            // 
            // txtNumNotaSal
            // 
            this.txtNumNotaSal.Location = new System.Drawing.Point(112, 22);
            this.txtNumNotaSal.Name = "txtNumNotaSal";
            this.txtNumNotaSal.Size = new System.Drawing.Size(128, 20);
            this.txtNumNotaSal.TabIndex = 16;
            this.txtNumNotaSal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumNotaSal_KeyPress);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(104, 13);
            this.lblBase1.TabIndex = 17;
            this.lblBase1.Text = "Solicitud de Req:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(257, 25);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 18;
            this.lblBase2.Text = "Estado:";
            // 
            // dtpFechaNS
            // 
            this.dtpFechaNS.Enabled = false;
            this.dtpFechaNS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNS.Location = new System.Drawing.Point(313, 48);
            this.dtpFechaNS.Name = "dtpFechaNS";
            this.dtpFechaNS.Size = new System.Drawing.Size(128, 20);
            this.dtpFechaNS.TabIndex = 19;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(256, 51);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 20;
            this.lblBase5.Text = "Fecha:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnBusqueda);
            this.grbBase2.Controls.Add(this.txtEstadoNotaSal);
            this.grbBase2.Controls.Add(this.txtNumNotaSal);
            this.grbBase2.Controls.Add(this.dtpFechaNS);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Location = new System.Drawing.Point(21, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(520, 77);
            this.grbBase2.TabIndex = 21;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Solicitud de Requerimiento:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(447, 22);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 22;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // txtEstadoNotaSal
            // 
            this.txtEstadoNotaSal.Enabled = false;
            this.txtEstadoNotaSal.Location = new System.Drawing.Point(313, 22);
            this.txtEstadoNotaSal.Name = "txtEstadoNotaSal";
            this.txtEstadoNotaSal.Size = new System.Drawing.Size(128, 20);
            this.txtEstadoNotaSal.TabIndex = 21;
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(572, 64);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(145, 21);
            this.cboAlmacen.TabIndex = 23;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(72, 210);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 24;
            this.lblBase3.Text = "Destino:";
            this.lblBase3.Visible = false;
            // 
            // cboDestinoPedido
            // 
            this.cboDestinoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinoPedido.FormattingEnabled = true;
            this.cboDestinoPedido.Location = new System.Drawing.Point(133, 206);
            this.cboDestinoPedido.Name = "cboDestinoPedido";
            this.cboDestinoPedido.Size = new System.Drawing.Size(344, 21);
            this.cboDestinoPedido.TabIndex = 25;
            this.cboDestinoPedido.Visible = false;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.txtSustento);
            this.grbBase4.Location = new System.Drawing.Point(11, 407);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(705, 112);
            this.grbBase4.TabIndex = 26;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Sustento";
            // 
            // txtSustento
            // 
            this.txtSustento.Location = new System.Drawing.Point(10, 19);
            this.txtSustento.MaxLength = 500;
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSustento.Size = new System.Drawing.Size(689, 87);
            this.txtSustento.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(12, 535);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(586, 535);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(655, 535);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(526, 535);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(466, 535);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(406, 535);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Location = new System.Drawing.Point(657, 303);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 10;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(656, 251);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.idUniMedida.HeaderText = "idUnidaMedida";
            this.idUniMedida.Name = "idUniMedida";
            this.idUniMedida.ReadOnly = true;
            this.idUniMedida.Visible = false;
            // 
            // idCatalogo
            // 
            this.idCatalogo.DataPropertyName = "idCatalogo";
            this.idCatalogo.HeaderText = "Cod. Prod.";
            this.idCatalogo.Name = "idCatalogo";
            this.idCatalogo.ReadOnly = true;
            // 
            // objCatalogo
            // 
            this.objCatalogo.DataPropertyName = "objCatalogo";
            this.objCatalogo.HeaderText = "objCatalogo";
            this.objCatalogo.Name = "objCatalogo";
            this.objCatalogo.ReadOnly = true;
            this.objCatalogo.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.FillWeight = 150F;
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            // 
            // cUnidMedida
            // 
            this.cUnidMedida.DataPropertyName = "cUnidMedida";
            this.cUnidMedida.FillWeight = 50F;
            this.cUnidMedida.HeaderText = "Uni. Medida";
            this.cUnidMedida.Name = "cUnidMedida";
            this.cUnidMedida.ReadOnly = true;
            // 
            // nStock
            // 
            this.nStock.DataPropertyName = "nStock";
            this.nStock.HeaderText = "Stock";
            this.nStock.Name = "nStock";
            this.nStock.ReadOnly = true;
            this.nStock.Visible = false;
            // 
            // nCantidadSol
            // 
            this.nCantidadSol.DataPropertyName = "nCantidadSol";
            this.nCantidadSol.FillWeight = 50F;
            this.nCantidadSol.HeaderText = "Cantidad";
            this.nCantidadSol.Name = "nCantidadSol";
            this.nCantidadSol.ReadOnly = true;
            // 
            // nCantidadApro
            // 
            this.nCantidadApro.DataPropertyName = "nCantidadApro";
            this.nCantidadApro.HeaderText = "nCantidadApro";
            this.nCantidadApro.Name = "nCantidadApro";
            this.nCantidadApro.ReadOnly = true;
            this.nCantidadApro.Visible = false;
            // 
            // lVigente
            // 
            this.lVigente.DataPropertyName = "lVigente";
            this.lVigente.HeaderText = "lVigente";
            this.lVigente.Name = "lVigente";
            this.lVigente.ReadOnly = true;
            this.lVigente.Visible = false;
            // 
            // frmNotaSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 610);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase4);
            this.Controls.Add(this.cboDestinoPedido);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboAlmacen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.cboActividadLog);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.cboAgencia);
            this.Name = "frmNotaSalida";
            this.Text = "Solicitud de Requerimiento";
            this.Load += new System.EventHandler(this.frmNotaSalida_Load);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.cboActividadLog, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboAlmacen, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboDestinoPedido, 0);
            this.Controls.SetChildIndex(this.grbBase4, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase4.ResumeLayout(false);
            this.grbBase4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBEstUsuSol;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBAreaSol;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBUsuarioSol;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNombre;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboActividadLog cboActividadLog;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgDetalleNS;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtBase txtNumNotaSal;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaNS;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtEstadoNotaSal;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboDestinoPedido cboDestinoPedido;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleNotaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUniMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn objCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUnidMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn nStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCantidadApro;
        private System.Windows.Forms.DataGridViewTextBoxColumn lVigente;
    }
}