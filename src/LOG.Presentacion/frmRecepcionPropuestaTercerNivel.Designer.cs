namespace LOG.Presentacion
{
    partial class frmRecepcionPropuestaTercerNivel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionPropuestaTercerNivel));
            this.dtgDetalleNS = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetallePropuesta = new GEN.ControlesBase.dtgBase(this.components);
            this.txtEstadoNotaSal = new GEN.ControlesBase.cboEstadoProcLog(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNumNotaSal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboProveedorProcesoAdq1 = new GEN.ControlesBase.cboProveedorProcesoAdq(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNombreProveedor = new GEN.ControlesBase.txtBase(this.components);
            this.btnLimpiarPropuesta = new GEN.BotonesBase.Boton2();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEvaluar = new GEN.BotonesBase.Boton2();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnProveedor1 = new GEN.BotonesBase.btnProveedor();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.panelProceso = new System.Windows.Forms.Panel();
            this.panelPropuesta = new System.Windows.Forms.Panel();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtLineaCredito = new GEN.ControlesBase.txtNumRea(this.components);
            this.chkIgv = new System.Windows.Forms.CheckBox();
            this.cboTipoComprobanteLog1 = new GEN.ControlesBase.cboTipoComprobanteLog(this.components);
            this.txtObservacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.panelResultado = new System.Windows.Forms.Panel();
            this.btnLimpiarResultado = new GEN.BotonesBase.Boton2();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.dtgDetalleResultados = new GEN.ControlesBase.dtgBase(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnGrabarResultado = new GEN.BotonesBase.btnGrabar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetallePropuesta)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.panelProceso.SuspendLayout();
            this.panelPropuesta.SuspendLayout();
            this.panelResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleResultados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDetalleNS
            // 
            this.dtgDetalleNS.AllowUserToAddRows = false;
            this.dtgDetalleNS.AllowUserToDeleteRows = false;
            this.dtgDetalleNS.AllowUserToResizeColumns = false;
            this.dtgDetalleNS.AllowUserToResizeRows = false;
            this.dtgDetalleNS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleNS.Location = new System.Drawing.Point(5, 4);
            this.dtgDetalleNS.MultiSelect = false;
            this.dtgDetalleNS.Name = "dtgDetalleNS";
            this.dtgDetalleNS.ReadOnly = true;
            this.dtgDetalleNS.RowHeadersVisible = false;
            this.dtgDetalleNS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgDetalleNS.Size = new System.Drawing.Size(860, 150);
            this.dtgDetalleNS.TabIndex = 6;
            // 
            // dtgDetallePropuesta
            // 
            this.dtgDetallePropuesta.AllowUserToAddRows = false;
            this.dtgDetallePropuesta.AllowUserToDeleteRows = false;
            this.dtgDetallePropuesta.AllowUserToResizeColumns = false;
            this.dtgDetallePropuesta.AllowUserToResizeRows = false;
            this.dtgDetallePropuesta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetallePropuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetallePropuesta.Location = new System.Drawing.Point(6, 33);
            this.dtgDetallePropuesta.MultiSelect = false;
            this.dtgDetallePropuesta.Name = "dtgDetallePropuesta";
            this.dtgDetallePropuesta.ReadOnly = true;
            this.dtgDetallePropuesta.RowHeadersVisible = false;
            this.dtgDetallePropuesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetallePropuesta.Size = new System.Drawing.Size(859, 150);
            this.dtgDetallePropuesta.TabIndex = 7;
            this.dtgDetallePropuesta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetallePropuesta_CellValueChanged);
            // 
            // txtEstadoNotaSal
            // 
            this.txtEstadoNotaSal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEstadoNotaSal.Enabled = false;
            this.txtEstadoNotaSal.FormattingEnabled = true;
            this.txtEstadoNotaSal.Location = new System.Drawing.Point(107, 48);
            this.txtEstadoNotaSal.Name = "txtEstadoNotaSal";
            this.txtEstadoNotaSal.Size = new System.Drawing.Size(122, 21);
            this.txtEstadoNotaSal.TabIndex = 33;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(2, 56);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(99, 13);
            this.lblBase9.TabIndex = 32;
            this.lblBase9.Text = "Estado Proceso:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(3, 25);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(99, 13);
            this.lblBase3.TabIndex = 29;
            this.lblBase3.Text = "Nro de Proceso:";
            // 
            // txtNumNotaSal
            // 
            this.txtNumNotaSal.Location = new System.Drawing.Point(107, 22);
            this.txtNumNotaSal.MaxLength = 9;
            this.txtNumNotaSal.Name = "txtNumNotaSal";
            this.txtNumNotaSal.Size = new System.Drawing.Size(122, 20);
            this.txtNumNotaSal.TabIndex = 28;
            this.txtNumNotaSal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPro_KeyPress);
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(416, 48);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(120, 21);
            this.cboMoneda1.TabIndex = 30;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(354, 56);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 31;
            this.lblBase2.Text = "Moneda:";
            // 
            // cboProveedorProcesoAdq1
            // 
            this.cboProveedorProcesoAdq1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedorProcesoAdq1.FormattingEnabled = true;
            this.cboProveedorProcesoAdq1.Location = new System.Drawing.Point(416, 21);
            this.cboProveedorProcesoAdq1.Name = "cboProveedorProcesoAdq1";
            this.cboProveedorProcesoAdq1.Size = new System.Drawing.Size(236, 21);
            this.cboProveedorProcesoAdq1.TabIndex = 34;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(241, 29);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(169, 13);
            this.lblBase4.TabIndex = 35;
            this.lblBase4.Text = "Proveedores con Propuesta:";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Location = new System.Drawing.Point(6, 7);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(453, 20);
            this.txtNombreProveedor.TabIndex = 36;
            // 
            // btnLimpiarPropuesta
            // 
            this.btnLimpiarPropuesta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLimpiarPropuesta.Location = new System.Drawing.Point(459, 6);
            this.btnLimpiarPropuesta.Name = "btnLimpiarPropuesta";
            this.btnLimpiarPropuesta.Size = new System.Drawing.Size(100, 21);
            this.btnLimpiarPropuesta.TabIndex = 38;
            this.btnLimpiarPropuesta.Text = "Limpiar Propuesta";
            this.btnLimpiarPropuesta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiarPropuesta.UseVisualStyleBackColor = true;
            this.btnLimpiarPropuesta.Click += new System.EventHandler(this.btnLimpiarPropuesta_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(674, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 16;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEvaluar.BackgroundImage")));
            this.btnEvaluar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEvaluar.Enabled = false;
            this.btnEvaluar.Location = new System.Drawing.Point(9, 1);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(60, 50);
            this.btnEvaluar.TabIndex = 15;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panelDatos);
            this.flowLayoutPanel1.Controls.Add(this.panelProceso);
            this.flowLayoutPanel1.Controls.Add(this.panelPropuesta);
            this.flowLayoutPanel1.Controls.Add(this.panelResultado);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(878, 764);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.grbBase2);
            this.panelDatos.Controls.Add(this.grbBase1);
            this.panelDatos.Location = new System.Drawing.Point(3, 3);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(872, 93);
            this.panelDatos.TabIndex = 40;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnProveedor1);
            this.grbBase2.Location = new System.Drawing.Point(726, 6);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(110, 81);
            this.grbBase2.TabIndex = 40;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Agregar Proveedor";
            // 
            // btnProveedor1
            // 
            this.btnProveedor1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProveedor1.BackgroundImage")));
            this.btnProveedor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProveedor1.Location = new System.Drawing.Point(22, 18);
            this.btnProveedor1.Name = "btnProveedor1";
            this.btnProveedor1.Size = new System.Drawing.Size(64, 50);
            this.btnProveedor1.TabIndex = 37;
            this.btnProveedor1.Text = "Pr&oveedor";
            this.btnProveedor1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProveedor1.UseVisualStyleBackColor = true;
            this.btnProveedor1.Click += new System.EventHandler(this.btnProveedor1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNumNotaSal);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboMoneda1);
            this.grbBase1.Controls.Add(this.txtEstadoNotaSal);
            this.grbBase1.Controls.Add(this.cboProveedorProcesoAdq1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(3, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(659, 84);
            this.grbBase1.TabIndex = 7;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Proceso";
            // 
            // panelProceso
            // 
            this.panelProceso.Controls.Add(this.dtgDetalleNS);
            this.panelProceso.Location = new System.Drawing.Point(3, 102);
            this.panelProceso.Name = "panelProceso";
            this.panelProceso.Size = new System.Drawing.Size(872, 162);
            this.panelProceso.TabIndex = 0;
            // 
            // panelPropuesta
            // 
            this.panelPropuesta.Controls.Add(this.lblBase5);
            this.panelPropuesta.Controls.Add(this.txtLineaCredito);
            this.panelPropuesta.Controls.Add(this.chkIgv);
            this.panelPropuesta.Controls.Add(this.cboTipoComprobanteLog1);
            this.panelPropuesta.Controls.Add(this.txtObservacion);
            this.panelPropuesta.Controls.Add(this.lblBase1);
            this.panelPropuesta.Controls.Add(this.dtgDetallePropuesta);
            this.panelPropuesta.Controls.Add(this.btnLimpiarPropuesta);
            this.panelPropuesta.Controls.Add(this.txtNombreProveedor);
            this.panelPropuesta.Location = new System.Drawing.Point(3, 270);
            this.panelPropuesta.Name = "panelPropuesta";
            this.panelPropuesta.Size = new System.Drawing.Size(872, 247);
            this.panelPropuesta.TabIndex = 1;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(655, 11);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(106, 13);
            this.lblBase5.TabIndex = 47;
            this.lblBase5.Text = "Linea de Crédito:";
            // 
            // txtLineaCredito
            // 
            this.txtLineaCredito.FormatoDecimal = false;
            this.txtLineaCredito.Location = new System.Drawing.Point(765, 7);
            this.txtLineaCredito.Name = "txtLineaCredito";
            this.txtLineaCredito.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLineaCredito.nNumDecimales = 4;
            this.txtLineaCredito.nvalor = 0D;
            this.txtLineaCredito.Size = new System.Drawing.Size(100, 20);
            this.txtLineaCredito.TabIndex = 46;
            this.txtLineaCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineaCredito_KeyPress);
            this.txtLineaCredito.Leave += new System.EventHandler(this.txtLineaCredito_Leave);
            // 
            // chkIgv
            // 
            this.chkIgv.AutoSize = true;
            this.chkIgv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIgv.ForeColor = System.Drawing.Color.Navy;
            this.chkIgv.Location = new System.Drawing.Point(234, 192);
            this.chkIgv.Name = "chkIgv";
            this.chkIgv.Size = new System.Drawing.Size(87, 17);
            this.chkIgv.TabIndex = 45;
            this.chkIgv.Text = "Incluye IGV: ";
            this.chkIgv.UseVisualStyleBackColor = true;
            // 
            // cboTipoComprobanteLog1
            // 
            this.cboTipoComprobanteLog1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobanteLog1.FormattingEnabled = true;
            this.cboTipoComprobanteLog1.Location = new System.Drawing.Point(156, 215);
            this.cboTipoComprobanteLog1.Name = "cboTipoComprobanteLog1";
            this.cboTipoComprobanteLog1.Size = new System.Drawing.Size(165, 21);
            this.cboTipoComprobanteLog1.TabIndex = 44;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(327, 189);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(538, 54);
            this.txtObservacion.TabIndex = 43;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(32, 218);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(118, 13);
            this.lblBase1.TabIndex = 41;
            this.lblBase1.Text = "Tipo Comprobante:";
            // 
            // panelResultado
            // 
            this.panelResultado.Controls.Add(this.btnLimpiarResultado);
            this.panelResultado.Controls.Add(this.txtBase1);
            this.panelResultado.Controls.Add(this.dtgDetalleResultados);
            this.panelResultado.Location = new System.Drawing.Point(3, 523);
            this.panelResultado.Name = "panelResultado";
            this.panelResultado.Size = new System.Drawing.Size(872, 178);
            this.panelResultado.TabIndex = 2;
            // 
            // btnLimpiarResultado
            // 
            this.btnLimpiarResultado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLimpiarResultado.Location = new System.Drawing.Point(459, 1);
            this.btnLimpiarResultado.Name = "btnLimpiarResultado";
            this.btnLimpiarResultado.Size = new System.Drawing.Size(100, 21);
            this.btnLimpiarResultado.TabIndex = 39;
            this.btnLimpiarResultado.Text = "Limpiar Resultado";
            this.btnLimpiarResultado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiarResultado.UseVisualStyleBackColor = true;
            this.btnLimpiarResultado.Click += new System.EventHandler(this.btnLimpiarResultado_Click);
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(6, 2);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(453, 20);
            this.txtBase1.TabIndex = 1;
            this.txtBase1.Text = "Resultados Caudro Comparativo";
            this.txtBase1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtgDetalleResultados
            // 
            this.dtgDetalleResultados.AllowUserToAddRows = false;
            this.dtgDetalleResultados.AllowUserToDeleteRows = false;
            this.dtgDetalleResultados.AllowUserToResizeColumns = false;
            this.dtgDetalleResultados.AllowUserToResizeRows = false;
            this.dtgDetalleResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleResultados.Location = new System.Drawing.Point(6, 25);
            this.dtgDetalleResultados.MultiSelect = false;
            this.dtgDetalleResultados.Name = "dtgDetalleResultados";
            this.dtgDetalleResultados.ReadOnly = true;
            this.dtgDetalleResultados.RowHeadersVisible = false;
            this.dtgDetalleResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleResultados.Size = new System.Drawing.Size(859, 150);
            this.dtgDetalleResultados.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimir1);
            this.panel1.Controls.Add(this.btnCancelar1);
            this.panel1.Controls.Add(this.btnEvaluar);
            this.panel1.Controls.Add(this.btnSalir1);
            this.panel1.Controls.Add(this.btnGrabarResultado);
            this.panel1.Controls.Add(this.btnGrabar);
            this.panel1.Location = new System.Drawing.Point(3, 707);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 54);
            this.panel1.TabIndex = 42;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(141, 1);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 42;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(740, 3);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 40;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(807, 3);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 41;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            this.btnSalir1.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnGrabarResultado
            // 
            this.btnGrabarResultado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarResultado.BackgroundImage")));
            this.btnGrabarResultado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarResultado.Location = new System.Drawing.Point(75, 1);
            this.btnGrabarResultado.Name = "btnGrabarResultado";
            this.btnGrabarResultado.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarResultado.TabIndex = 39;
            this.btnGrabarResultado.Text = "&Grabar";
            this.btnGrabarResultado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarResultado.UseVisualStyleBackColor = true;
            this.btnGrabarResultado.Click += new System.EventHandler(this.btnGrabarResultado_Click);
            // 
            // frmRecepcionPropuestaTercerNivel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(879, 785);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmRecepcionPropuestaTercerNivel";
            this.Text = "Recepcion de Propuestas - Proceso de Adquisicion";
            this.Load += new System.EventHandler(this.frmRecepcionPropuestaTercerNivel_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleNS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetallePropuesta)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.grbBase2.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.panelProceso.ResumeLayout(false);
            this.panelPropuesta.ResumeLayout(false);
            this.panelPropuesta.PerformLayout();
            this.panelResultado.ResumeLayout(false);
            this.panelResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgDetalleNS;
        private GEN.ControlesBase.dtgBase dtgDetallePropuesta;
        private GEN.BotonesBase.Boton2 btnEvaluar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.ControlesBase.cboEstadoProcLog txtEstadoNotaSal;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumNotaSal;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboProveedorProcesoAdq cboProveedorProcesoAdq1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtNombreProveedor;
        private GEN.BotonesBase.Boton2 btnLimpiarPropuesta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelProceso;
        private System.Windows.Forms.Panel panelPropuesta;
        private GEN.BotonesBase.btnProveedor btnProveedor1;
        private System.Windows.Forms.Panel panelResultado;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.BotonesBase.btnGrabar btnGrabarResultado;
        private GEN.ControlesBase.dtgBase dtgDetalleResultados;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.Panel panelDatos;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.Boton2 btnLimpiarResultado;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtObservacion;
        private GEN.ControlesBase.cboTipoComprobanteLog cboTipoComprobanteLog1;
        private System.Windows.Forms.CheckBox chkIgv;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtNumRea txtLineaCredito;
    }
}