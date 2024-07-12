namespace ADM.Presentacion
{
    partial class frmVinculaCtasContablesNeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVinculaCtasContablesNeg));
            this.cboModulo = new GEN.ControlesBase.cboModulo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtgPlantillaCtaCtb = new GEN.ControlesBase.dtgBase(this.components);
            this.btnCtaCtbHaber = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtCtaCtbDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTipoAfectacionDebe = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnCtaCtbDebe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtCtaCtbHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTipoAfectacionHaber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnQuitar = new GEN.BotonesBase.btnQuitar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboTipoPersona = new GEN.ControlesBase.cboTipoPersona(this.components);
            this.cboTipoOperacion = new GEN.ControlesBase.cboTipoOperacion(this.components);
            this.cboProducto = new GEN.ControlesBase.cboProducto(this.components);
            this.cboCanal = new GEN.ControlesBase.cboCanal(this.components);
            this.cboConcepto = new GEN.ControlesBase.cboConcepto(this.components);
            this.cboTipoPago = new GEN.ControlesBase.cboTipoPago(this.components);
            this.cboCondicionContable = new GEN.ControlesBase.cboCondicionContable(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.cboCalificacion1 = new GEN.ControlesBase.cboCalificacion(this.components);
            this.lblCalifacacion = new GEN.ControlesBase.lblBase();
            this.lblCentroCosto = new GEN.ControlesBase.lblBase();
            this.txtDescCentroCosto = new GEN.ControlesBase.txtBase(this.components);
            this.btnAddCentroCosto = new GEN.BotonesBase.btnMiniAgregar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblMotOpe = new GEN.ControlesBase.lblBase();
            this.cboMotivoOperacion = new GEN.ControlesBase.cboMotivoOperacion(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlantillaCtaCtb)).BeginInit();
            this.SuspendLayout();
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(85, 6);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(572, 21);
            this.cboModulo.TabIndex = 2;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 10);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Módulo :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 35);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(66, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Producto :";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 110);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(120, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Tipo de Operación :";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(346, 60);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(129, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Canal de Operación :";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(346, 85);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(90, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Tipo de Pago :";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(346, 110);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(70, 13);
            this.lblBase6.TabIndex = 8;
            this.lblBase6.Text = "Concepto :";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(10, 85);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(108, 13);
            this.lblBase7.TabIndex = 9;
            this.lblBase7.Text = "Tipo de Persona :";
            // 
            // dtgPlantillaCtaCtb
            // 
            this.dtgPlantillaCtaCtb.AllowUserToAddRows = false;
            this.dtgPlantillaCtaCtb.AllowUserToDeleteRows = false;
            this.dtgPlantillaCtaCtb.AllowUserToResizeColumns = false;
            this.dtgPlantillaCtaCtb.AllowUserToResizeRows = false;
            this.dtgPlantillaCtaCtb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPlantillaCtaCtb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPlantillaCtaCtb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPlantillaCtaCtb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnCtaCtbHaber,
            this.txtCtaCtbDebe,
            this.cboTipoAfectacionDebe,
            this.btnCtaCtbDebe,
            this.txtCtaCtbHaber,
            this.cboTipoAfectacionHaber});
            this.dtgPlantillaCtaCtb.Location = new System.Drawing.Point(10, 188);
            this.dtgPlantillaCtaCtb.MultiSelect = false;
            this.dtgPlantillaCtaCtb.Name = "dtgPlantillaCtaCtb";
            this.dtgPlantillaCtaCtb.ReadOnly = true;
            this.dtgPlantillaCtaCtb.RowHeadersVisible = false;
            this.dtgPlantillaCtaCtb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPlantillaCtaCtb.Size = new System.Drawing.Size(581, 127);
            this.dtgPlantillaCtaCtb.TabIndex = 10;
            this.dtgPlantillaCtaCtb.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPlantillaCtaCtb_CellClick);
            this.dtgPlantillaCtaCtb.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgPlantillaCtaCtb_EditingControlShowing);
            // 
            // btnCtaCtbHaber
            // 
            this.btnCtaCtbHaber.FillWeight = 20F;
            this.btnCtaCtbHaber.HeaderText = "";
            this.btnCtaCtbHaber.Name = "btnCtaCtbHaber";
            this.btnCtaCtbHaber.ReadOnly = true;
            // 
            // txtCtaCtbDebe
            // 
            this.txtCtaCtbDebe.DataPropertyName = "cCtaDebe";
            this.txtCtaCtbDebe.HeaderText = "Debe";
            this.txtCtaCtbDebe.Name = "txtCtaCtbDebe";
            this.txtCtaCtbDebe.ReadOnly = true;
            // 
            // cboTipoAfectacionDebe
            // 
            this.cboTipoAfectacionDebe.DataPropertyName = "cTipSegDebe";
            this.cboTipoAfectacionDebe.HeaderText = "Afectación Debe";
            this.cboTipoAfectacionDebe.Name = "cboTipoAfectacionDebe";
            this.cboTipoAfectacionDebe.ReadOnly = true;
            this.cboTipoAfectacionDebe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboTipoAfectacionDebe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnCtaCtbDebe
            // 
            this.btnCtaCtbDebe.FillWeight = 20F;
            this.btnCtaCtbDebe.HeaderText = "";
            this.btnCtaCtbDebe.Name = "btnCtaCtbDebe";
            this.btnCtaCtbDebe.ReadOnly = true;
            // 
            // txtCtaCtbHaber
            // 
            this.txtCtaCtbHaber.DataPropertyName = "cCtaHaber";
            this.txtCtaCtbHaber.HeaderText = "Haber";
            this.txtCtaCtbHaber.Name = "txtCtaCtbHaber";
            this.txtCtaCtbHaber.ReadOnly = true;
            // 
            // cboTipoAfectacionHaber
            // 
            this.cboTipoAfectacionHaber.DataPropertyName = "cTipSegHaber";
            this.cboTipoAfectacionHaber.HeaderText = "Afectación Haber";
            this.cboTipoAfectacionHaber.Name = "cboTipoAfectacionHaber";
            this.cboTipoAfectacionHaber.ReadOnly = true;
            this.cboTipoAfectacionHaber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cboTipoAfectacionHaber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(597, 188);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(597, 321);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar.BackgroundImage")));
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar.Location = new System.Drawing.Point(597, 242);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar.TabIndex = 14;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(470, 321);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 15;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(531, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboTipoPersona
            // 
            this.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPersona.FormattingEnabled = true;
            this.cboTipoPersona.Location = new System.Drawing.Point(139, 81);
            this.cboTipoPersona.Name = "cboTipoPersona";
            this.cboTipoPersona.Size = new System.Drawing.Size(201, 21);
            this.cboTipoPersona.TabIndex = 17;
            this.cboTipoPersona.SelectedIndexChanged += new System.EventHandler(this.cboTipoPersona_SelectedIndexChanged);
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(139, 106);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(201, 21);
            this.cboTipoOperacion.TabIndex = 18;
            this.cboTipoOperacion.SelectedIndexChanged += new System.EventHandler(this.cboTipoOperacion_SelectedIndexChanged);
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(85, 31);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(572, 21);
            this.cboProducto.TabIndex = 19;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // cboCanal
            // 
            this.cboCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanal.FormattingEnabled = true;
            this.cboCanal.Location = new System.Drawing.Point(477, 56);
            this.cboCanal.Name = "cboCanal";
            this.cboCanal.Size = new System.Drawing.Size(180, 21);
            this.cboCanal.TabIndex = 20;
            this.cboCanal.SelectedIndexChanged += new System.EventHandler(this.cboCanal_SelectedIndexChanged);
            // 
            // cboConcepto
            // 
            this.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConcepto.FormattingEnabled = true;
            this.cboConcepto.Location = new System.Drawing.Point(477, 106);
            this.cboConcepto.Name = "cboConcepto";
            this.cboConcepto.Size = new System.Drawing.Size(180, 21);
            this.cboConcepto.TabIndex = 21;
            this.cboConcepto.SelectedIndexChanged += new System.EventHandler(this.cboConcepto_SelectedIndexChanged);
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(476, 81);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(181, 21);
            this.cboTipoPago.TabIndex = 22;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // cboCondicionContable
            // 
            this.cboCondicionContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionContable.FormattingEnabled = true;
            this.cboCondicionContable.Location = new System.Drawing.Point(139, 56);
            this.cboCondicionContable.Name = "cboCondicionContable";
            this.cboCondicionContable.Size = new System.Drawing.Size(201, 21);
            this.cboCondicionContable.TabIndex = 23;
            this.cboCondicionContable.SelectedIndexChanged += new System.EventHandler(this.cboCondicionContable_SelectedIndexChanged);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 60);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(127, 13);
            this.lblBase8.TabIndex = 24;
            this.lblBase8.Text = "Condición Contable :";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(409, 321);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 25;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cboCalificacion1
            // 
            this.cboCalificacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalificacion1.FormattingEnabled = true;
            this.cboCalificacion1.Location = new System.Drawing.Point(139, 156);
            this.cboCalificacion1.Name = "cboCalificacion1";
            this.cboCalificacion1.Size = new System.Drawing.Size(201, 21);
            this.cboCalificacion1.TabIndex = 26;
            this.cboCalificacion1.Visible = false;
            this.cboCalificacion1.SelectedIndexChanged += new System.EventHandler(this.cboCalificacion1_SelectedIndexChanged);
            // 
            // lblCalifacacion
            // 
            this.lblCalifacacion.AutoSize = true;
            this.lblCalifacacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCalifacacion.ForeColor = System.Drawing.Color.Navy;
            this.lblCalifacacion.Location = new System.Drawing.Point(13, 160);
            this.lblCalifacacion.Name = "lblCalifacacion";
            this.lblCalifacacion.Size = new System.Drawing.Size(77, 13);
            this.lblCalifacacion.TabIndex = 27;
            this.lblCalifacacion.Text = "Calificación:";
            this.lblCalifacacion.Visible = false;
            // 
            // lblCentroCosto
            // 
            this.lblCentroCosto.AutoSize = true;
            this.lblCentroCosto.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblCentroCosto.ForeColor = System.Drawing.Color.Navy;
            this.lblCentroCosto.Location = new System.Drawing.Point(346, 137);
            this.lblCentroCosto.Name = "lblCentroCosto";
            this.lblCentroCosto.Size = new System.Drawing.Size(106, 13);
            this.lblCentroCosto.TabIndex = 28;
            this.lblCentroCosto.Text = "Centro de Costo:";
            this.lblCentroCosto.Visible = false;
            // 
            // txtDescCentroCosto
            // 
            this.txtDescCentroCosto.Enabled = false;
            this.txtDescCentroCosto.Location = new System.Drawing.Point(478, 133);
            this.txtDescCentroCosto.Name = "txtDescCentroCosto";
            this.txtDescCentroCosto.Size = new System.Drawing.Size(143, 20);
            this.txtDescCentroCosto.TabIndex = 29;
            this.txtDescCentroCosto.Visible = false;
            // 
            // btnAddCentroCosto
            // 
            this.btnAddCentroCosto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCentroCosto.BackgroundImage")));
            this.btnAddCentroCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddCentroCosto.Location = new System.Drawing.Point(621, 129);
            this.btnAddCentroCosto.Name = "btnAddCentroCosto";
            this.btnAddCentroCosto.Size = new System.Drawing.Size(36, 28);
            this.btnAddCentroCosto.TabIndex = 30;
            this.btnAddCentroCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddCentroCosto.UseVisualStyleBackColor = true;
            this.btnAddCentroCosto.Visible = false;
            this.btnAddCentroCosto.Click += new System.EventHandler(this.btnAddCentroCosto_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(348, 321);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 31;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblMotOpe
            // 
            this.lblMotOpe.AutoSize = true;
            this.lblMotOpe.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMotOpe.ForeColor = System.Drawing.Color.Navy;
            this.lblMotOpe.Location = new System.Drawing.Point(12, 134);
            this.lblMotOpe.Name = "lblMotOpe";
            this.lblMotOpe.Size = new System.Drawing.Size(127, 13);
            this.lblMotOpe.TabIndex = 32;
            this.lblMotOpe.Text = "Motivo de operación:";
            // 
            // cboMotivoOperacion
            // 
            this.cboMotivoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoOperacion.FormattingEnabled = true;
            this.cboMotivoOperacion.Location = new System.Drawing.Point(139, 131);
            this.cboMotivoOperacion.Name = "cboMotivoOperacion";
            this.cboMotivoOperacion.Size = new System.Drawing.Size(201, 21);
            this.cboMotivoOperacion.TabIndex = 33;
            this.cboMotivoOperacion.SelectedIndexChanged += new System.EventHandler(this.cboMotivoOperacion_SelectedIndexChanged);
            // 
            // frmVinculaCtasContablesNeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 398);
            this.Controls.Add(this.cboMotivoOperacion);
            this.Controls.Add(this.lblMotOpe);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnAddCentroCosto);
            this.Controls.Add(this.txtDescCentroCosto);
            this.Controls.Add(this.lblCentroCosto);
            this.Controls.Add(this.lblCalifacacion);
            this.Controls.Add(this.cboCalificacion1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.cboCondicionContable);
            this.Controls.Add(this.cboTipoPago);
            this.Controls.Add(this.cboConcepto);
            this.Controls.Add(this.cboCanal);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.cboTipoOperacion);
            this.Controls.Add(this.cboTipoPersona);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtgPlantillaCtaCtb);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboModulo);
            this.Name = "frmVinculaCtasContablesNeg";
            this.Text = "Asignación de Cuentas Contables";
            this.Load += new System.EventHandler(this.frmVinculaCtasContablesNeg_Load);
            this.Controls.SetChildIndex(this.cboModulo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.dtgPlantillaCtaCtb, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboTipoPersona, 0);
            this.Controls.SetChildIndex(this.cboTipoOperacion, 0);
            this.Controls.SetChildIndex(this.cboProducto, 0);
            this.Controls.SetChildIndex(this.cboCanal, 0);
            this.Controls.SetChildIndex(this.cboConcepto, 0);
            this.Controls.SetChildIndex(this.cboTipoPago, 0);
            this.Controls.SetChildIndex(this.cboCondicionContable, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.cboCalificacion1, 0);
            this.Controls.SetChildIndex(this.lblCalifacacion, 0);
            this.Controls.SetChildIndex(this.lblCentroCosto, 0);
            this.Controls.SetChildIndex(this.txtDescCentroCosto, 0);
            this.Controls.SetChildIndex(this.btnAddCentroCosto, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblMotOpe, 0);
            this.Controls.SetChildIndex(this.cboMotivoOperacion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPlantillaCtaCtb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboModulo cboModulo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtgBase dtgPlantillaCtaCtb;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnQuitar btnQuitar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboTipoPersona cboTipoPersona;
        private GEN.ControlesBase.cboTipoOperacion cboTipoOperacion;
        private GEN.ControlesBase.cboProducto cboProducto;
        private GEN.ControlesBase.cboCanal cboCanal;
        private GEN.ControlesBase.cboConcepto cboConcepto;
        private GEN.ControlesBase.cboTipoPago cboTipoPago;
        private GEN.ControlesBase.cboCondicionContable cboCondicionContable;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.cboCalificacion cboCalificacion1;
        private GEN.ControlesBase.lblBase lblCalifacacion;
        private GEN.ControlesBase.lblBase lblCentroCosto;
        private GEN.ControlesBase.txtBase txtDescCentroCosto;
        private GEN.BotonesBase.btnMiniAgregar btnAddCentroCosto;
        private System.Windows.Forms.DataGridViewButtonColumn btnCtaCtbHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCtaCtbDebe;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboTipoAfectacionDebe;
        private System.Windows.Forms.DataGridViewButtonColumn btnCtaCtbDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCtaCtbHaber;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboTipoAfectacionHaber;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblMotOpe;
        private GEN.ControlesBase.cboMotivoOperacion cboMotivoOperacion;
    }
}

