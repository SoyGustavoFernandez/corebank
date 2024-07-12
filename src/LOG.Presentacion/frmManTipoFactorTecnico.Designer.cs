namespace LOG.Presentacion
{
    partial class frmManTipoFactorTecnico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTipoFactorTecnico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.clsTipoFactoresTecnicosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtgCriEva = new GEN.ControlesBase.dtgBase(this.components);
            this.idFacTecnicosDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFacTecnicosDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtDesCriEva = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtPuntCreEva = new GEN.ControlesBase.txtNumRea(this.components);
            this.tbcFacTecnicos = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboTipoPedido = new GEN.ControlesBase.cboTipoPedidoLog(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnGrabarTipPro = new GEN.BotonesBase.btnGrabar();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnContinuarTipoCanal = new GEN.BotonesBase.btnContinuar();
            this.btnEditarTipProc = new GEN.BotonesBase.btnEditar();
            this.btnNuevoTipProc = new GEN.BotonesBase.btnNuevo();
            this.dtgFacTec = new GEN.ControlesBase.dtgBase(this.components);
            this.idFacTecnicosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFacTecnicosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lVigenteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nPuntaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTipoFacTecnico = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtPuntajeFacTec = new GEN.ControlesBase.txtNumRea(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDesFacTec = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.btnRegresar1 = new GEN.BotonesBase.btnRegresar();
            this.btnGrabarCritEva = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevoCriEva = new GEN.BotonesBase.btnNuevo();
            this.btnEditarCriEva = new GEN.BotonesBase.btnEditar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chcVigente = new GEN.ControlesBase.chcBase(this.components);
            this.chcCritVigente = new GEN.ControlesBase.chcBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoFactoresTecnicosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCriEva)).BeginInit();
            this.tbcFacTecnicos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacTec)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(611, 251);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 14;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // clsTipoFactoresTecnicosBindingSource
            // 
            this.clsTipoFactoresTecnicosBindingSource.DataSource = typeof(EntityLayer.clsTipoFactoresTecnicos);
            // 
            // dtgCriEva
            // 
            this.dtgCriEva.AllowUserToAddRows = false;
            this.dtgCriEva.AllowUserToDeleteRows = false;
            this.dtgCriEva.AllowUserToResizeColumns = false;
            this.dtgCriEva.AllowUserToResizeRows = false;
            this.dtgCriEva.AutoGenerateColumns = false;
            this.dtgCriEva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCriEva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCriEva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFacTecnicosDataGridViewTextBoxColumn1,
            this.cFacTecnicosDataGridViewTextBoxColumn1,
            this.lVigenteDataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this.dtgCriEva.DataSource = this.clsTipoFactoresTecnicosBindingSource;
            this.dtgCriEva.Location = new System.Drawing.Point(6, 30);
            this.dtgCriEva.MultiSelect = false;
            this.dtgCriEva.Name = "dtgCriEva";
            this.dtgCriEva.ReadOnly = true;
            this.dtgCriEva.RowHeadersVisible = false;
            this.dtgCriEva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCriEva.Size = new System.Drawing.Size(326, 174);
            this.dtgCriEva.TabIndex = 20;
            this.dtgCriEva.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCriEva_CellContentClick);
            this.dtgCriEva.SelectionChanged += new System.EventHandler(this.dtgCriEva_SelectionChanged);
            // 
            // idFacTecnicosDataGridViewTextBoxColumn1
            // 
            this.idFacTecnicosDataGridViewTextBoxColumn1.DataPropertyName = "idFacTecnicos";
            this.idFacTecnicosDataGridViewTextBoxColumn1.HeaderText = "idFacTecnicos";
            this.idFacTecnicosDataGridViewTextBoxColumn1.Name = "idFacTecnicosDataGridViewTextBoxColumn1";
            this.idFacTecnicosDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idFacTecnicosDataGridViewTextBoxColumn1.Visible = false;
            // 
            // cFacTecnicosDataGridViewTextBoxColumn1
            // 
            this.cFacTecnicosDataGridViewTextBoxColumn1.DataPropertyName = "cFacTecnicos";
            this.cFacTecnicosDataGridViewTextBoxColumn1.FillWeight = 137.6539F;
            this.cFacTecnicosDataGridViewTextBoxColumn1.HeaderText = "Criterio Evaluacion";
            this.cFacTecnicosDataGridViewTextBoxColumn1.Name = "cFacTecnicosDataGridViewTextBoxColumn1";
            this.cFacTecnicosDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lVigenteDataGridViewCheckBoxColumn1
            // 
            this.lVigenteDataGridViewCheckBoxColumn1.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn1.Name = "lVigenteDataGridViewCheckBoxColumn1";
            this.lVigenteDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nPuntaje";
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Puntaje";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(338, 33);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(78, 13);
            this.lblBase1.TabIndex = 21;
            this.lblBase1.Text = "Descripción:";
            // 
            // txtDesCriEva
            // 
            this.txtDesCriEva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesCriEva.Location = new System.Drawing.Point(417, 31);
            this.txtDesCriEva.Multiline = true;
            this.txtDesCriEva.Name = "txtDesCriEva";
            this.txtDesCriEva.Size = new System.Drawing.Size(221, 91);
            this.txtDesCriEva.TabIndex = 22;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(338, 130);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 25;
            this.lblBase3.Text = "Puntaje:";
            // 
            // txtPuntCreEva
            // 
            this.txtPuntCreEva.FormatoDecimal = false;
            this.txtPuntCreEva.Location = new System.Drawing.Point(417, 128);
            this.txtPuntCreEva.MaxLength = 8;
            this.txtPuntCreEva.Name = "txtPuntCreEva";
            this.txtPuntCreEva.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPuntCreEva.nNumDecimales = 4;
            this.txtPuntCreEva.nvalor = 0D;
            this.txtPuntCreEva.Size = new System.Drawing.Size(87, 20);
            this.txtPuntCreEva.TabIndex = 26;
            // 
            // tbcFacTecnicos
            // 
            this.tbcFacTecnicos.Controls.Add(this.tabPage1);
            this.tbcFacTecnicos.Controls.Add(this.tabPage2);
            this.tbcFacTecnicos.Location = new System.Drawing.Point(10, 13);
            this.tbcFacTecnicos.Name = "tbcFacTecnicos";
            this.tbcFacTecnicos.SelectedIndex = 0;
            this.tbcFacTecnicos.Size = new System.Drawing.Size(659, 236);
            this.tbcFacTecnicos.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chcVigente);
            this.tabPage1.Controls.Add(this.cboTipoPedido);
            this.tabPage1.Controls.Add(this.lblBase2);
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.btnGrabarTipPro);
            this.tabPage1.Controls.Add(this.lblBase5);
            this.tabPage1.Controls.Add(this.lblBase4);
            this.tabPage1.Controls.Add(this.btnContinuarTipoCanal);
            this.tabPage1.Controls.Add(this.btnEditarTipProc);
            this.tabPage1.Controls.Add(this.btnNuevoTipProc);
            this.tabPage1.Controls.Add(this.dtgFacTec);
            this.tabPage1.Controls.Add(this.txtTipoFacTecnico);
            this.tabPage1.Controls.Add(this.txtPuntajeFacTec);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 210);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Factor Tecnico";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboTipoPedido
            // 
            this.cboTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedido.FormattingEnabled = true;
            this.cboTipoPedido.Location = new System.Drawing.Point(107, 5);
            this.cboTipoPedido.Name = "cboTipoPedido";
            this.cboTipoPedido.Size = new System.Drawing.Size(228, 21);
            this.cboTipoPedido.TabIndex = 39;
            this.cboTipoPedido.SelectedIndexChanged += new System.EventHandler(this.cboTipoPedido_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(342, 34);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(93, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Factor Técnico:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(521, 154);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabarTipPro
            // 
            this.btnGrabarTipPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarTipPro.BackgroundImage")));
            this.btnGrabarTipPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarTipPro.Location = new System.Drawing.Point(461, 154);
            this.btnGrabarTipPro.Name = "btnGrabarTipPro";
            this.btnGrabarTipPro.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarTipPro.TabIndex = 12;
            this.btnGrabarTipPro.Text = "&Grabar";
            this.btnGrabarTipPro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarTipPro.UseVisualStyleBackColor = true;
            this.btnGrabarTipPro.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 8);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(96, 13);
            this.lblBase5.TabIndex = 30;
            this.lblBase5.Text = "Tipo de Pedido:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(342, 132);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(103, 13);
            this.lblBase4.TabIndex = 27;
            this.lblBase4.Text = "Puntaje Máximo:";
            // 
            // btnContinuarTipoCanal
            // 
            this.btnContinuarTipoCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinuarTipoCanal.BackgroundImage")));
            this.btnContinuarTipoCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContinuarTipoCanal.Location = new System.Drawing.Point(581, 154);
            this.btnContinuarTipoCanal.Name = "btnContinuarTipoCanal";
            this.btnContinuarTipoCanal.Size = new System.Drawing.Size(60, 50);
            this.btnContinuarTipoCanal.TabIndex = 38;
            this.btnContinuarTipoCanal.Text = "Continuar";
            this.btnContinuarTipoCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContinuarTipoCanal.UseVisualStyleBackColor = true;
            this.btnContinuarTipoCanal.Click += new System.EventHandler(this.btnContinuarTipoCanal_Click);
            // 
            // btnEditarTipProc
            // 
            this.btnEditarTipProc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarTipProc.BackgroundImage")));
            this.btnEditarTipProc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarTipProc.Location = new System.Drawing.Point(401, 154);
            this.btnEditarTipProc.Name = "btnEditarTipProc";
            this.btnEditarTipProc.Size = new System.Drawing.Size(60, 50);
            this.btnEditarTipProc.TabIndex = 11;
            this.btnEditarTipProc.Text = "&Editar";
            this.btnEditarTipProc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarTipProc.UseVisualStyleBackColor = true;
            this.btnEditarTipProc.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevoTipProc
            // 
            this.btnNuevoTipProc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoTipProc.BackgroundImage")));
            this.btnNuevoTipProc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoTipProc.Location = new System.Drawing.Point(341, 154);
            this.btnNuevoTipProc.Name = "btnNuevoTipProc";
            this.btnNuevoTipProc.Size = new System.Drawing.Size(60, 50);
            this.btnNuevoTipProc.TabIndex = 10;
            this.btnNuevoTipProc.Text = "&Nuevo";
            this.btnNuevoTipProc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoTipProc.UseVisualStyleBackColor = true;
            this.btnNuevoTipProc.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // dtgFacTec
            // 
            this.dtgFacTec.AllowUserToAddRows = false;
            this.dtgFacTec.AllowUserToDeleteRows = false;
            this.dtgFacTec.AllowUserToResizeColumns = false;
            this.dtgFacTec.AllowUserToResizeRows = false;
            this.dtgFacTec.AutoGenerateColumns = false;
            this.dtgFacTec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFacTec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFacTec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFacTecnicosDataGridViewTextBoxColumn,
            this.cFacTecnicosDataGridViewTextBoxColumn,
            this.lVigenteDataGridViewCheckBoxColumn,
            this.nPuntaje});
            this.dtgFacTec.DataSource = this.clsTipoFactoresTecnicosBindingSource;
            this.dtgFacTec.Location = new System.Drawing.Point(9, 28);
            this.dtgFacTec.MultiSelect = false;
            this.dtgFacTec.Name = "dtgFacTec";
            this.dtgFacTec.ReadOnly = true;
            this.dtgFacTec.RowHeadersVisible = false;
            this.dtgFacTec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFacTec.Size = new System.Drawing.Size(326, 179);
            this.dtgFacTec.TabIndex = 19;
            this.dtgFacTec.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFacTec_CellContentClick);
            this.dtgFacTec.SelectionChanged += new System.EventHandler(this.dtgFacTec_SelectionChanged);
            // 
            // idFacTecnicosDataGridViewTextBoxColumn
            // 
            this.idFacTecnicosDataGridViewTextBoxColumn.DataPropertyName = "idFacTecnicos";
            this.idFacTecnicosDataGridViewTextBoxColumn.HeaderText = "idFacTecnicos";
            this.idFacTecnicosDataGridViewTextBoxColumn.Name = "idFacTecnicosDataGridViewTextBoxColumn";
            this.idFacTecnicosDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFacTecnicosDataGridViewTextBoxColumn.Visible = false;
            // 
            // cFacTecnicosDataGridViewTextBoxColumn
            // 
            this.cFacTecnicosDataGridViewTextBoxColumn.DataPropertyName = "cFacTecnicos";
            this.cFacTecnicosDataGridViewTextBoxColumn.FillWeight = 149.2386F;
            this.cFacTecnicosDataGridViewTextBoxColumn.HeaderText = "Tipo de Factores Técnicos";
            this.cFacTecnicosDataGridViewTextBoxColumn.Name = "cFacTecnicosDataGridViewTextBoxColumn";
            this.cFacTecnicosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lVigenteDataGridViewCheckBoxColumn
            // 
            this.lVigenteDataGridViewCheckBoxColumn.DataPropertyName = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.HeaderText = "lVigente";
            this.lVigenteDataGridViewCheckBoxColumn.Name = "lVigenteDataGridViewCheckBoxColumn";
            this.lVigenteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lVigenteDataGridViewCheckBoxColumn.Visible = false;
            // 
            // nPuntaje
            // 
            this.nPuntaje.DataPropertyName = "nPuntaje";
            dataGridViewCellStyle1.Format = "N2";
            this.nPuntaje.DefaultCellStyle = dataGridViewCellStyle1;
            this.nPuntaje.FillWeight = 50.76142F;
            this.nPuntaje.HeaderText = "Puntaje";
            this.nPuntaje.Name = "nPuntaje";
            this.nPuntaje.ReadOnly = true;
            // 
            // txtTipoFacTecnico
            // 
            this.txtTipoFacTecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoFacTecnico.Location = new System.Drawing.Point(454, 33);
            this.txtTipoFacTecnico.Multiline = true;
            this.txtTipoFacTecnico.Name = "txtTipoFacTecnico";
            this.txtTipoFacTecnico.Size = new System.Drawing.Size(187, 89);
            this.txtTipoFacTecnico.TabIndex = 16;
            // 
            // txtPuntajeFacTec
            // 
            this.txtPuntajeFacTec.FormatoDecimal = false;
            this.txtPuntajeFacTec.Location = new System.Drawing.Point(454, 128);
            this.txtPuntajeFacTec.MaxLength = 8;
            this.txtPuntajeFacTec.Name = "txtPuntajeFacTec";
            this.txtPuntajeFacTec.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPuntajeFacTec.nNumDecimales = 4;
            this.txtPuntajeFacTec.nvalor = 0D;
            this.txtPuntajeFacTec.Size = new System.Drawing.Size(69, 20);
            this.txtPuntajeFacTec.TabIndex = 28;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chcCritVigente);
            this.tabPage2.Controls.Add(this.txtDesFacTec);
            this.tabPage2.Controls.Add(this.lblBase6);
            this.tabPage2.Controls.Add(this.dtgCriEva);
            this.tabPage2.Controls.Add(this.lblBase1);
            this.tabPage2.Controls.Add(this.btnRegresar1);
            this.tabPage2.Controls.Add(this.txtDesCriEva);
            this.tabPage2.Controls.Add(this.btnGrabarCritEva);
            this.tabPage2.Controls.Add(this.btnCancelar1);
            this.tabPage2.Controls.Add(this.btnNuevoCriEva);
            this.tabPage2.Controls.Add(this.txtPuntCreEva);
            this.tabPage2.Controls.Add(this.btnEditarCriEva);
            this.tabPage2.Controls.Add(this.lblBase3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 210);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Criterio de Evaluacion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDesFacTec
            // 
            this.txtDesFacTec.Location = new System.Drawing.Point(103, 6);
            this.txtDesFacTec.Name = "txtDesFacTec";
            this.txtDesFacTec.ReadOnly = true;
            this.txtDesFacTec.Size = new System.Drawing.Size(535, 20);
            this.txtDesFacTec.TabIndex = 34;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(8, 9);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(93, 13);
            this.lblBase6.TabIndex = 46;
            this.lblBase6.Text = "Factor Técnico:";
            // 
            // btnRegresar1
            // 
            this.btnRegresar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegresar1.BackgroundImage")));
            this.btnRegresar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegresar1.Location = new System.Drawing.Point(338, 154);
            this.btnRegresar1.Name = "btnRegresar1";
            this.btnRegresar1.Size = new System.Drawing.Size(60, 50);
            this.btnRegresar1.TabIndex = 45;
            this.btnRegresar1.Text = "Regresar";
            this.btnRegresar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegresar1.UseVisualStyleBackColor = true;
            this.btnRegresar1.Click += new System.EventHandler(this.btnRegresar1_Click);
            // 
            // btnGrabarCritEva
            // 
            this.btnGrabarCritEva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarCritEva.BackgroundImage")));
            this.btnGrabarCritEva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarCritEva.Location = new System.Drawing.Point(518, 154);
            this.btnGrabarCritEva.Name = "btnGrabarCritEva";
            this.btnGrabarCritEva.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarCritEva.TabIndex = 43;
            this.btnGrabarCritEva.Text = "&Grabar";
            this.btnGrabarCritEva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarCritEva.UseVisualStyleBackColor = true;
            this.btnGrabarCritEva.Click += new System.EventHandler(this.btnGrabarCritEva_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(578, 154);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 42;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevoCriEva
            // 
            this.btnNuevoCriEva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoCriEva.BackgroundImage")));
            this.btnNuevoCriEva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevoCriEva.Location = new System.Drawing.Point(398, 154);
            this.btnNuevoCriEva.Name = "btnNuevoCriEva";
            this.btnNuevoCriEva.Size = new System.Drawing.Size(60, 50);
            this.btnNuevoCriEva.TabIndex = 40;
            this.btnNuevoCriEva.Text = "&Nuevo";
            this.btnNuevoCriEva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoCriEva.UseVisualStyleBackColor = true;
            this.btnNuevoCriEva.Click += new System.EventHandler(this.btnNuevoCriEva_Click);
            // 
            // btnEditarCriEva
            // 
            this.btnEditarCriEva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarCriEva.BackgroundImage")));
            this.btnEditarCriEva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarCriEva.Location = new System.Drawing.Point(458, 154);
            this.btnEditarCriEva.Name = "btnEditarCriEva";
            this.btnEditarCriEva.Size = new System.Drawing.Size(60, 50);
            this.btnEditarCriEva.TabIndex = 41;
            this.btnEditarCriEva.Text = "&Editar";
            this.btnEditarCriEva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarCriEva.UseVisualStyleBackColor = true;
            this.btnEditarCriEva.Click += new System.EventHandler(this.btnEditarCriEva_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(10, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(659, 27);
            this.lblTitulo.TabIndex = 33;
            this.lblTitulo.Text = "FACTORES TECNICOS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chcVigente
            // 
            this.chcVigente.AutoSize = true;
            this.chcVigente.ForeColor = System.Drawing.Color.Navy;
            this.chcVigente.Location = new System.Drawing.Point(567, 130);
            this.chcVigente.Name = "chcVigente";
            this.chcVigente.Size = new System.Drawing.Size(68, 17);
            this.chcVigente.TabIndex = 40;
            this.chcVigente.Text = "Vigente?";
            this.chcVigente.UseVisualStyleBackColor = true;
            // 
            // chcCritVigente
            // 
            this.chcCritVigente.AutoSize = true;
            this.chcCritVigente.ForeColor = System.Drawing.Color.Navy;
            this.chcCritVigente.Location = new System.Drawing.Point(564, 129);
            this.chcCritVigente.Name = "chcCritVigente";
            this.chcCritVigente.Size = new System.Drawing.Size(68, 17);
            this.chcCritVigente.TabIndex = 47;
            this.chcCritVigente.Text = "Vigente?";
            this.chcCritVigente.UseVisualStyleBackColor = true;
            // 
            // frmManTipoFactorTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 324);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tbcFacTecnicos);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmManTipoFactorTecnico";
            this.Text = "Mantenimiento Tipo de Factor Técnico";
            this.Load += new System.EventHandler(this.frmManTipoFactorTecnico_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.tbcFacTecnicos, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clsTipoFactoresTecnicosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCriEva)).EndInit();
            this.tbcFacTecnicos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacTec)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private System.Windows.Forms.BindingSource clsTipoFactoresTecnicosBindingSource;
        private GEN.ControlesBase.dtgBase dtgCriEva;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtCBLetra txtDesCriEva;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtPuntCreEva;
        private GEN.ControlesBase.tbcBase tbcFacTecnicos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTitulo;
        private GEN.BotonesBase.btnRegresar btnRegresar1;
        private GEN.BotonesBase.btnGrabar btnGrabarCritEva;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnNuevo btnNuevoCriEva;
        private GEN.BotonesBase.btnEditar btnEditarCriEva;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacTecnicosDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFacTecnicosDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private GEN.ControlesBase.txtCBLetra txtDesFacTec;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.cboTipoPedidoLog cboTipoPedido;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnGrabar btnGrabarTipPro;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnContinuar btnContinuarTipoCanal;
        private GEN.BotonesBase.btnEditar btnEditarTipProc;
        private GEN.BotonesBase.btnNuevo btnNuevoTipProc;
        private GEN.ControlesBase.dtgBase dtgFacTec;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacTecnicosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFacTecnicosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lVigenteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPuntaje;
        private GEN.ControlesBase.txtCBLetra txtTipoFacTecnico;
        private GEN.ControlesBase.txtNumRea txtPuntajeFacTec;
        private GEN.ControlesBase.chcBase chcVigente;
        private GEN.ControlesBase.chcBase chcCritVigente;
    }
}