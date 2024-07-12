namespace GRH.Presentacion
{
    partial class frmAdelantoSueldo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdelantoSueldo));
            this.conBusPersonal = new GEN.ControlesBase.ConBusCol();
            this.dtgAdelantoUsuario = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtmIdAdelantoSueldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmIdTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmIdModalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmIdPeriodoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmPeriodoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gtgtxtmFechaSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmMontoAdelanto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmMotivoAdelanto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmIdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtmFechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDescuentoAdelantoSueldo = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtdIdAdelantoSueldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtdIdTipoPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgcbodIdPeriodoPlanilla = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dtgcbodIdModalidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dtgtxtdMontoDescontar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtdMontoDescontado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgchcdVigente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboPeriodoPlanilla = new GEN.ControlesBase.cboPeriodoPlanilla(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMontoAdelanto = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipoPlanilla = new GEN.ControlesBase.cboTipoPlanilla(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMotivoAdelanto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAdelantoUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDescuentoAdelantoSueldo)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusPersonal
            // 
            this.conBusPersonal.cEstado = "0";
            this.conBusPersonal.Location = new System.Drawing.Point(35, 3);
            this.conBusPersonal.Name = "conBusPersonal";
            this.conBusPersonal.Size = new System.Drawing.Size(390, 86);
            this.conBusPersonal.TabIndex = 0;
            this.conBusPersonal.BuscarUsuario += new System.EventHandler(this.conBusPersonal_BuscarUsuario);
            // 
            // dtgAdelantoUsuario
            // 
            this.dtgAdelantoUsuario.AllowUserToAddRows = false;
            this.dtgAdelantoUsuario.AllowUserToDeleteRows = false;
            this.dtgAdelantoUsuario.AllowUserToResizeColumns = false;
            this.dtgAdelantoUsuario.AllowUserToResizeRows = false;
            this.dtgAdelantoUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAdelantoUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAdelantoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAdelantoUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtmIdAdelantoSueldo,
            this.dtgtxtmIdTipoPlanilla,
            this.dtgtxtmTipoPlanilla,
            this.dtgtxtmIdModalidad,
            this.dtgtxtmIdPeriodoPlanilla,
            this.dtgtxtmPeriodoPlanilla,
            this.gtgtxtmFechaSolicitud,
            this.dtgtxtmMontoAdelanto,
            this.dtgtxtmMotivoAdelanto,
            this.dtgtxtmIdEstado,
            this.dtgtxtmEstado,
            this.dtgtxtmFechaPago});
            this.dtgAdelantoUsuario.Location = new System.Drawing.Point(8, 98);
            this.dtgAdelantoUsuario.MultiSelect = false;
            this.dtgAdelantoUsuario.Name = "dtgAdelantoUsuario";
            this.dtgAdelantoUsuario.ReadOnly = true;
            this.dtgAdelantoUsuario.RowHeadersVisible = false;
            this.dtgAdelantoUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAdelantoUsuario.Size = new System.Drawing.Size(445, 130);
            this.dtgAdelantoUsuario.TabIndex = 1;
            this.dtgAdelantoUsuario.SelectionChanged += new System.EventHandler(this.dtgAdelantoUsuario_SelectionChanged);
            // 
            // dtgtxtmIdAdelantoSueldo
            // 
            this.dtgtxtmIdAdelantoSueldo.DataPropertyName = "idAdelantoSueldo";
            this.dtgtxtmIdAdelantoSueldo.HeaderText = "idAdelantoSueldo";
            this.dtgtxtmIdAdelantoSueldo.Name = "dtgtxtmIdAdelantoSueldo";
            this.dtgtxtmIdAdelantoSueldo.ReadOnly = true;
            this.dtgtxtmIdAdelantoSueldo.Visible = false;
            // 
            // dtgtxtmIdTipoPlanilla
            // 
            this.dtgtxtmIdTipoPlanilla.DataPropertyName = "idTipoPlanilla";
            this.dtgtxtmIdTipoPlanilla.HeaderText = "idTipoPlanilla";
            this.dtgtxtmIdTipoPlanilla.Name = "dtgtxtmIdTipoPlanilla";
            this.dtgtxtmIdTipoPlanilla.ReadOnly = true;
            this.dtgtxtmIdTipoPlanilla.Visible = false;
            // 
            // dtgtxtmTipoPlanilla
            // 
            this.dtgtxtmTipoPlanilla.DataPropertyName = "cTipoPlanilla";
            this.dtgtxtmTipoPlanilla.FillWeight = 501.9812F;
            this.dtgtxtmTipoPlanilla.HeaderText = "Tipo de Planilla";
            this.dtgtxtmTipoPlanilla.MinimumWidth = 50;
            this.dtgtxtmTipoPlanilla.Name = "dtgtxtmTipoPlanilla";
            this.dtgtxtmTipoPlanilla.ReadOnly = true;
            // 
            // dtgtxtmIdModalidad
            // 
            this.dtgtxtmIdModalidad.DataPropertyName = "idModalidad";
            this.dtgtxtmIdModalidad.HeaderText = "idModalidad";
            this.dtgtxtmIdModalidad.Name = "dtgtxtmIdModalidad";
            this.dtgtxtmIdModalidad.ReadOnly = true;
            this.dtgtxtmIdModalidad.Visible = false;
            // 
            // dtgtxtmIdPeriodoPlanilla
            // 
            this.dtgtxtmIdPeriodoPlanilla.DataPropertyName = "idPeriodoPlanilla";
            this.dtgtxtmIdPeriodoPlanilla.HeaderText = "idPeriodoPlanilla";
            this.dtgtxtmIdPeriodoPlanilla.Name = "dtgtxtmIdPeriodoPlanilla";
            this.dtgtxtmIdPeriodoPlanilla.ReadOnly = true;
            this.dtgtxtmIdPeriodoPlanilla.Visible = false;
            // 
            // dtgtxtmPeriodoPlanilla
            // 
            this.dtgtxtmPeriodoPlanilla.DataPropertyName = "cPeriodoPlanilla";
            this.dtgtxtmPeriodoPlanilla.FillWeight = 1F;
            this.dtgtxtmPeriodoPlanilla.HeaderText = "Periodo";
            this.dtgtxtmPeriodoPlanilla.MinimumWidth = 55;
            this.dtgtxtmPeriodoPlanilla.Name = "dtgtxtmPeriodoPlanilla";
            this.dtgtxtmPeriodoPlanilla.ReadOnly = true;
            // 
            // gtgtxtmFechaSolicitud
            // 
            this.gtgtxtmFechaSolicitud.DataPropertyName = "dFechaSolicitud";
            this.gtgtxtmFechaSolicitud.FillWeight = 1F;
            this.gtgtxtmFechaSolicitud.HeaderText = "Fecha Solicitud";
            this.gtgtxtmFechaSolicitud.MinimumWidth = 70;
            this.gtgtxtmFechaSolicitud.Name = "gtgtxtmFechaSolicitud";
            this.gtgtxtmFechaSolicitud.ReadOnly = true;
            // 
            // dtgtxtmMontoAdelanto
            // 
            this.dtgtxtmMontoAdelanto.DataPropertyName = "nMontoAdelanto";
            this.dtgtxtmMontoAdelanto.FillWeight = 1F;
            this.dtgtxtmMontoAdelanto.HeaderText = "Monto Adelanto";
            this.dtgtxtmMontoAdelanto.MinimumWidth = 55;
            this.dtgtxtmMontoAdelanto.Name = "dtgtxtmMontoAdelanto";
            this.dtgtxtmMontoAdelanto.ReadOnly = true;
            // 
            // dtgtxtmMotivoAdelanto
            // 
            this.dtgtxtmMotivoAdelanto.DataPropertyName = "cMotivoAdelanto";
            this.dtgtxtmMotivoAdelanto.HeaderText = "cMotivoAdelanto";
            this.dtgtxtmMotivoAdelanto.Name = "dtgtxtmMotivoAdelanto";
            this.dtgtxtmMotivoAdelanto.ReadOnly = true;
            this.dtgtxtmMotivoAdelanto.Visible = false;
            // 
            // dtgtxtmIdEstado
            // 
            this.dtgtxtmIdEstado.DataPropertyName = "idEstado";
            this.dtgtxtmIdEstado.HeaderText = "idEstado";
            this.dtgtxtmIdEstado.Name = "dtgtxtmIdEstado";
            this.dtgtxtmIdEstado.ReadOnly = true;
            this.dtgtxtmIdEstado.Visible = false;
            // 
            // dtgtxtmEstado
            // 
            this.dtgtxtmEstado.DataPropertyName = "cEstado";
            this.dtgtxtmEstado.FillWeight = 1F;
            this.dtgtxtmEstado.HeaderText = "Estado";
            this.dtgtxtmEstado.MinimumWidth = 75;
            this.dtgtxtmEstado.Name = "dtgtxtmEstado";
            this.dtgtxtmEstado.ReadOnly = true;
            // 
            // dtgtxtmFechaPago
            // 
            this.dtgtxtmFechaPago.DataPropertyName = "dFechaPago";
            this.dtgtxtmFechaPago.FillWeight = 1F;
            this.dtgtxtmFechaPago.HeaderText = "Fecha de Pago";
            this.dtgtxtmFechaPago.MinimumWidth = 70;
            this.dtgtxtmFechaPago.Name = "dtgtxtmFechaPago";
            this.dtgtxtmFechaPago.ReadOnly = true;
            // 
            // dtgDescuentoAdelantoSueldo
            // 
            this.dtgDescuentoAdelantoSueldo.AllowUserToAddRows = false;
            this.dtgDescuentoAdelantoSueldo.AllowUserToDeleteRows = false;
            this.dtgDescuentoAdelantoSueldo.AllowUserToResizeColumns = false;
            this.dtgDescuentoAdelantoSueldo.AllowUserToResizeRows = false;
            this.dtgDescuentoAdelantoSueldo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDescuentoAdelantoSueldo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDescuentoAdelantoSueldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDescuentoAdelantoSueldo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtdIdAdelantoSueldo,
            this.dtgtxtdIdTipoPlanilla,
            this.dtgcbodIdPeriodoPlanilla,
            this.dtgcbodIdModalidad,
            this.dtgtxtdMontoDescontar,
            this.dtgtxtdMontoDescontado,
            this.dtgchcdVigente});
            this.dtgDescuentoAdelantoSueldo.Location = new System.Drawing.Point(9, 336);
            this.dtgDescuentoAdelantoSueldo.MultiSelect = false;
            this.dtgDescuentoAdelantoSueldo.Name = "dtgDescuentoAdelantoSueldo";
            this.dtgDescuentoAdelantoSueldo.ReadOnly = true;
            this.dtgDescuentoAdelantoSueldo.RowHeadersVisible = false;
            this.dtgDescuentoAdelantoSueldo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDescuentoAdelantoSueldo.Size = new System.Drawing.Size(404, 100);
            this.dtgDescuentoAdelantoSueldo.TabIndex = 8;
            // 
            // dtgtxtdIdAdelantoSueldo
            // 
            this.dtgtxtdIdAdelantoSueldo.DataPropertyName = "idAdelantoSueldo";
            this.dtgtxtdIdAdelantoSueldo.HeaderText = "idAdelantoSueldo";
            this.dtgtxtdIdAdelantoSueldo.Name = "dtgtxtdIdAdelantoSueldo";
            this.dtgtxtdIdAdelantoSueldo.ReadOnly = true;
            this.dtgtxtdIdAdelantoSueldo.Visible = false;
            // 
            // dtgtxtdIdTipoPlanilla
            // 
            this.dtgtxtdIdTipoPlanilla.DataPropertyName = "idTipoPlanilla";
            this.dtgtxtdIdTipoPlanilla.HeaderText = "Tipo de Planilla";
            this.dtgtxtdIdTipoPlanilla.Name = "dtgtxtdIdTipoPlanilla";
            this.dtgtxtdIdTipoPlanilla.ReadOnly = true;
            this.dtgtxtdIdTipoPlanilla.Visible = false;
            // 
            // dtgcbodIdPeriodoPlanilla
            // 
            this.dtgcbodIdPeriodoPlanilla.DataPropertyName = "idPeriodoPlanilla";
            this.dtgcbodIdPeriodoPlanilla.HeaderText = "Periodo Planilla";
            this.dtgcbodIdPeriodoPlanilla.MinimumWidth = 100;
            this.dtgcbodIdPeriodoPlanilla.Name = "dtgcbodIdPeriodoPlanilla";
            this.dtgcbodIdPeriodoPlanilla.ReadOnly = true;
            // 
            // dtgcbodIdModalidad
            // 
            this.dtgcbodIdModalidad.DataPropertyName = "idModalidad";
            this.dtgcbodIdModalidad.FillWeight = 1000F;
            this.dtgcbodIdModalidad.HeaderText = "Modalidad";
            this.dtgcbodIdModalidad.MinimumWidth = 140;
            this.dtgcbodIdModalidad.Name = "dtgcbodIdModalidad";
            this.dtgcbodIdModalidad.ReadOnly = true;
            this.dtgcbodIdModalidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgcbodIdModalidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtgtxtdMontoDescontar
            // 
            this.dtgtxtdMontoDescontar.DataPropertyName = "nMontoDescontar";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgtxtdMontoDescontar.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgtxtdMontoDescontar.HeaderText = "Monto a Descontar";
            this.dtgtxtdMontoDescontar.MinimumWidth = 70;
            this.dtgtxtdMontoDescontar.Name = "dtgtxtdMontoDescontar";
            this.dtgtxtdMontoDescontar.ReadOnly = true;
            // 
            // dtgtxtdMontoDescontado
            // 
            this.dtgtxtdMontoDescontado.DataPropertyName = "nMontoDescontado";
            this.dtgtxtdMontoDescontado.HeaderText = "Monto Descontado";
            this.dtgtxtdMontoDescontado.MinimumWidth = 70;
            this.dtgtxtdMontoDescontado.Name = "dtgtxtdMontoDescontado";
            this.dtgtxtdMontoDescontado.ReadOnly = true;
            // 
            // dtgchcdVigente
            // 
            this.dtgchcdVigente.DataPropertyName = "lVigente";
            this.dtgchcdVigente.HeaderText = "Vigente";
            this.dtgchcdVigente.MinimumWidth = 45;
            this.dtgchcdVigente.Name = "dtgchcdVigente";
            this.dtgchcdVigente.ReadOnly = true;
            this.dtgchcdVigente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgchcdVigente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dtgchcdVigente.Visible = false;
            // 
            // cboPeriodoPlanilla
            // 
            this.cboPeriodoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodoPlanilla.FormattingEnabled = true;
            this.cboPeriodoPlanilla.Location = new System.Drawing.Point(114, 259);
            this.cboPeriodoPlanilla.Name = "cboPeriodoPlanilla";
            this.cboPeriodoPlanilla.Size = new System.Drawing.Size(180, 21);
            this.cboPeriodoPlanilla.TabIndex = 3;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 263);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Periodo Planilla:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(326, 263);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Monto:";
            // 
            // txtMontoAdelanto
            // 
            this.txtMontoAdelanto.FormatoDecimal = false;
            this.txtMontoAdelanto.Location = new System.Drawing.Point(375, 260);
            this.txtMontoAdelanto.Name = "txtMontoAdelanto";
            this.txtMontoAdelanto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoAdelanto.nNumDecimales = 4;
            this.txtMontoAdelanto.nvalor = 0D;
            this.txtMontoAdelanto.Size = new System.Drawing.Size(75, 20);
            this.txtMontoAdelanto.TabIndex = 4;
            // 
            // cboTipoPlanilla
            // 
            this.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPlanilla.FormattingEnabled = true;
            this.cboTipoPlanilla.Location = new System.Drawing.Point(114, 235);
            this.cboTipoPlanilla.Name = "cboTipoPlanilla";
            this.cboTipoPlanilla.Size = new System.Drawing.Size(336, 21);
            this.cboTipoPlanilla.TabIndex = 2;
            this.cboTipoPlanilla.SelectedIndexChanged += new System.EventHandler(this.cboTipoPlanilla_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 239);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(98, 13);
            this.lblBase3.TabIndex = 15;
            this.lblBase3.Text = "Tipo de Planilla:";
            // 
            // txtMotivoAdelanto
            // 
            this.txtMotivoAdelanto.Location = new System.Drawing.Point(114, 283);
            this.txtMotivoAdelanto.Multiline = true;
            this.txtMotivoAdelanto.Name = "txtMotivoAdelanto";
            this.txtMotivoAdelanto.Size = new System.Drawing.Size(336, 45);
            this.txtMotivoAdelanto.TabIndex = 5;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 288);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(103, 13);
            this.lblBase4.TabIndex = 17;
            this.lblBase4.Text = "Motivo Adelanto:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(24, 444);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(84, 444);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(204, 444);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(264, 444);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(377, 444);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(144, 444);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(417, 337);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 6;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            this.btnMiniAgregar.Click += new System.EventHandler(this.btnMiniAgregar_Click);
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(417, 367);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 7;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // frmAdelantoSueldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 524);
            this.Controls.Add(this.btnMiniQuitar);
            this.Controls.Add(this.btnMiniAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMotivoAdelanto);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboTipoPlanilla);
            this.Controls.Add(this.txtMontoAdelanto);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboPeriodoPlanilla);
            this.Controls.Add(this.dtgDescuentoAdelantoSueldo);
            this.Controls.Add(this.dtgAdelantoUsuario);
            this.Controls.Add(this.conBusPersonal);
            this.Name = "frmAdelantoSueldo";
            this.Text = "Adelanto de Sueldo";
            this.Load += new System.EventHandler(this.frmAdelantoSueldo_Load);
            this.Controls.SetChildIndex(this.conBusPersonal, 0);
            this.Controls.SetChildIndex(this.dtgAdelantoUsuario, 0);
            this.Controls.SetChildIndex(this.dtgDescuentoAdelantoSueldo, 0);
            this.Controls.SetChildIndex(this.cboPeriodoPlanilla, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtMontoAdelanto, 0);
            this.Controls.SetChildIndex(this.cboTipoPlanilla, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.txtMotivoAdelanto, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnMiniAgregar, 0);
            this.Controls.SetChildIndex(this.btnMiniQuitar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAdelantoUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDescuentoAdelantoSueldo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusPersonal;
        private GEN.ControlesBase.dtgBase dtgAdelantoUsuario;
        private GEN.ControlesBase.dtgBase dtgDescuentoAdelantoSueldo;
        private GEN.ControlesBase.cboPeriodoPlanilla cboPeriodoPlanilla;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtMontoAdelanto;
        private GEN.ControlesBase.cboTipoPlanilla cboTipoPlanilla;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtMotivoAdelanto;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmIdAdelantoSueldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmIdTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmTipoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmIdModalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmIdPeriodoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmPeriodoPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn gtgtxtmFechaSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmMontoAdelanto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmMotivoAdelanto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmIdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtmFechaPago;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtdIdAdelantoSueldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtdIdTipoPlanilla;
        private System.Windows.Forms.DataGridViewComboBoxColumn dtgcbodIdPeriodoPlanilla;
        private System.Windows.Forms.DataGridViewComboBoxColumn dtgcbodIdModalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtdMontoDescontar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtdMontoDescontado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dtgchcdVigente;
    }
}

