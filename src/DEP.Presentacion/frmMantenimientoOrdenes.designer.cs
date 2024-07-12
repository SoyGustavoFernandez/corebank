namespace DEP.Presentacion
{
    partial class frmMantenimientoOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoOrdenes));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chcSelec = new GEN.ControlesBase.chcBase(this.components);
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.treeviewValorado = new GEN.ControlesBase.TreeviewCbx();
            this.cboEstado = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgDetalleVal = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbBase4 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtNumFinal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNumInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboLimitesVal1 = new GEN.ControlesBase.cboLimitesVal(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleVal)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.grbBase4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Location = new System.Drawing.Point(10, 0);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(580, 114);
            this.conBusCtaAho.TabIndex = 2;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Location = new System.Drawing.Point(10, 120);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(559, 227);
            this.tbcBase1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.chcSelec);
            this.tabPage1.Controls.Add(this.chcBase1);
            this.tabPage1.Controls.Add(this.treeviewValorado);
            this.tabPage1.Controls.Add(this.cboEstado);
            this.tabPage1.Controls.Add(this.lblBase4);
            this.tabPage1.Controls.Add(this.lblBase3);
            this.tabPage1.Controls.Add(this.dtgDetalleVal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(551, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos de Ordenes de Pago";
            // 
            // chcSelec
            // 
            this.chcSelec.AutoSize = true;
            this.chcSelec.Enabled = false;
            this.chcSelec.Location = new System.Drawing.Point(479, 4);
            this.chcSelec.Name = "chcSelec";
            this.chcSelec.Size = new System.Drawing.Size(56, 17);
            this.chcSelec.TabIndex = 32;
            this.chcSelec.Text = "Todos";
            this.chcSelec.UseVisualStyleBackColor = true;
            this.chcSelec.CheckedChanged += new System.EventHandler(this.chcSelec_CheckedChanged);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.Enabled = false;
            this.chcBase1.ForeColor = System.Drawing.Color.Red;
            this.chcBase1.Location = new System.Drawing.Point(479, 183);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(56, 17);
            this.chcBase1.TabIndex = 39;
            this.chcBase1.Text = "Anular";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged_1);
            // 
            // treeviewValorado
            // 
            this.treeviewValorado.CheckBoxes = true;
            this.treeviewValorado.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeviewValorado.Location = new System.Drawing.Point(6, 49);
            this.treeviewValorado.Name = "treeviewValorado";
            this.treeviewValorado.Size = new System.Drawing.Size(153, 130);
            this.treeviewValorado.TabIndex = 30;
            this.treeviewValorado.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeviewValorado_NodeMouseClick);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Enabled = false;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(6, 22);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(153, 21);
            this.cboEstado.TabIndex = 27;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 6);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(142, 13);
            this.lblBase4.TabIndex = 26;
            this.lblBase4.Text = "Estado de la Chequera:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(162, 6);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(113, 13);
            this.lblBase3.TabIndex = 25;
            this.lblBase3.Text = "Detalle Valorados:";
            // 
            // dtgDetalleVal
            // 
            this.dtgDetalleVal.AllowUserToAddRows = false;
            this.dtgDetalleVal.AllowUserToDeleteRows = false;
            this.dtgDetalleVal.AllowUserToResizeColumns = false;
            this.dtgDetalleVal.AllowUserToResizeRows = false;
            this.dtgDetalleVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleVal.Location = new System.Drawing.Point(165, 22);
            this.dtgDetalleVal.MultiSelect = false;
            this.dtgDetalleVal.Name = "dtgDetalleVal";
            this.dtgDetalleVal.ReadOnly = true;
            this.dtgDetalleVal.RowHeadersVisible = false;
            this.dtgDetalleVal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleVal.Size = new System.Drawing.Size(372, 157);
            this.dtgDetalleVal.TabIndex = 2;
            this.dtgDetalleVal.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleVal_CellEndEdit);
            this.dtgDetalleVal.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleVal_CellValueChanged_1);
            this.dtgDetalleVal.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgDetalleVal_CurrentCellDirtyStateChanged);
            this.dtgDetalleVal.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalleVal_RowEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbBase4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(551, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos de Cliente";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbBase4
            // 
            this.grbBase4.Controls.Add(this.dtgIntervinientes);
            this.grbBase4.Location = new System.Drawing.Point(3, 3);
            this.grbBase4.Name = "grbBase4";
            this.grbBase4.Size = new System.Drawing.Size(542, 192);
            this.grbBase4.TabIndex = 88;
            this.grbBase4.TabStop = false;
            this.grbBase4.Text = "Intervinientes de Cuenta:";
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCli,
            this.idTipoInterv,
            this.idSolicitud,
            this.cDocumentoID,
            this.cNombre,
            this.cTipoIntervencion,
            this.lCliAfeITF});
            this.dtgIntervinientes.Location = new System.Drawing.Point(6, 19);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(530, 156);
            this.dtgIntervinientes.TabIndex = 5;
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.FillWeight = 50F;
            this.idSolicitud.HeaderText = "Cuenta";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 80F;
            this.cDocumentoID.HeaderText = "Documento";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 250F;
            this.cNombre.HeaderText = "Nombre Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "Interviniente";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            // 
            // lCliAfeITF
            // 
            this.lCliAfeITF.DataPropertyName = "lCliAfeITF";
            this.lCliAfeITF.FillWeight = 25F;
            this.lCliAfeITF.HeaderText = "ITF";
            this.lCliAfeITF.Name = "lCliAfeITF";
            this.lCliAfeITF.ReadOnly = true;
            this.lCliAfeITF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCliAfeITF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(381, 494);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(507, 494);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(444, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Enabled = false;
            this.btnBusqueda.Location = new System.Drawing.Point(6, 437);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 34;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtNumFinal);
            this.grbBase1.Controls.Add(this.txtNumSerie);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtNumInicio);
            this.grbBase1.Location = new System.Drawing.Point(75, 409);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(490, 47);
            this.grbBase1.TabIndex = 36;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(328, 21);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(58, 13);
            this.lblBase6.TabIndex = 26;
            this.lblBase6.Text = "Num.Fin:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(5, 21);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(66, 13);
            this.lblBase8.TabIndex = 24;
            this.lblBase8.Text = "Nro Serie:";
            // 
            // txtNumFinal
            // 
            this.txtNumFinal.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumFinal.Enabled = false;
            this.txtNumFinal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFinal.Location = new System.Drawing.Point(387, 16);
            this.txtNumFinal.Name = "txtNumFinal";
            this.txtNumFinal.Size = new System.Drawing.Size(97, 22);
            this.txtNumFinal.TabIndex = 23;
            this.txtNumFinal.Text = "0000000";
            this.txtNumFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumSerie
            // 
            this.txtNumSerie.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumSerie.Enabled = false;
            this.txtNumSerie.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumSerie.Location = new System.Drawing.Point(71, 16);
            this.txtNumSerie.Name = "txtNumSerie";
            this.txtNumSerie.Size = new System.Drawing.Size(97, 22);
            this.txtNumSerie.TabIndex = 21;
            this.txtNumSerie.Text = "0000001";
            this.txtNumSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(171, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 25;
            this.lblBase5.Text = "Num.Ini:";
            // 
            // txtNumInicio
            // 
            this.txtNumInicio.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumInicio.Enabled = false;
            this.txtNumInicio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumInicio.Location = new System.Drawing.Point(228, 16);
            this.txtNumInicio.Name = "txtNumInicio";
            this.txtNumInicio.Size = new System.Drawing.Size(97, 22);
            this.txtNumInicio.TabIndex = 22;
            this.txtNumInicio.Text = "0000001";
            this.txtNumInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboLimitesVal1
            // 
            this.cboLimitesVal1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimitesVal1.Enabled = false;
            this.cboLimitesVal1.FormattingEnabled = true;
            this.cboLimitesVal1.Location = new System.Drawing.Point(442, 466);
            this.cboLimitesVal1.Name = "cboLimitesVal1";
            this.cboLimitesVal1.Size = new System.Drawing.Size(125, 21);
            this.cboLimitesVal1.TabIndex = 31;
            this.cboLimitesVal1.SelectedIndexChanged += new System.EventHandler(this.cboLimitesVal1_SelectedIndexChanged);
            this.cboLimitesVal1.TextChanged += new System.EventHandler(this.cboLimitesVal1_TextChanged);
            this.cboLimitesVal1.Validating += new System.ComponentModel.CancelEventHandler(this.cboLimitesVal1_Validating);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(366, 470);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(67, 13);
            this.lblBase1.TabIndex = 27;
            this.lblBase1.Text = "Canti.O/P:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(318, 494);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 38;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 348);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 43;
            this.lblBase2.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(10, 364);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(555, 35);
            this.txtMotivo.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ver Valorados Generados:";
            // 
            // frmMantenimientoOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 574);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.cboLimitesVal1);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.conBusCtaAho);
            this.Name = "frmMantenimientoOrdenes";
            this.Text = "Mantenimiento de Ordenes";
            this.Load += new System.EventHandler(this.frmMantenimientoOrdenes_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboLimitesVal1, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleVal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.grbBase4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgDetalleVal;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboBase cboEstado;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase4;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumFinal;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumInicio;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.TreeviewCbx treeviewValorado;
        private GEN.ControlesBase.cboLimitesVal cboLimitesVal1;
        private GEN.ControlesBase.chcBase chcSelec;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumSerie;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtBase txtMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
    }
}