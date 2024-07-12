namespace RCP.Presentacion
{
    partial class frmAgregarCreditoHojaRuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarCreditoHojaRuta));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAccion1 = new GEN.ControlesBase.cboAccion(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtgCarteraCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.idDetalleHojaRutaCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idIntervCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTotalPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDirPrincipal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DireccionRecupera = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUbigeo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cboTipoIntervCre1 = new GEN.ControlesBase.cboTipoIntervCre(this.components);
            this.chbTodosIntervinientes = new System.Windows.Forms.CheckBox();
            this.btnConsultar1 = new GEN.BotonesBase.btnConsultar();
            this.chbDireccionPrincipal = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtAtrazoMax = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtAtrazoMin = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSaldoCapitalMax = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtSaldoCapitalMin = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.conBusUbig1 = new GEN.ControlesBase.ConBusUbig();
            this.cboAnexo = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDepartamento = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboPais = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoNotificacion1 = new GEN.ControlesBase.cboTipoNotificacion(this.components);
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnAceptar1 = new GEN.BotonesBase.BtnAceptar();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraCreditos)).BeginInit();
            this.grbFiltros.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.conBusUbig1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(25, 400);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(53, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Acción: ";
            // 
            // cboAccion1
            // 
            this.cboAccion1.DisplayMember = "cTipoAccion";
            this.cboAccion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccion1.FormattingEnabled = true;
            this.cboAccion1.Location = new System.Drawing.Point(74, 397);
            this.cboAccion1.Name = "cboAccion1";
            this.cboAccion1.Size = new System.Drawing.Size(349, 21);
            this.cboAccion1.TabIndex = 0;
            this.cboAccion1.ValueMember = "idTipoAccion";
            this.cboAccion1.SelectedIndexChanged += new System.EventHandler(this.cboAccion1_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtgCarteraCreditos);
            this.groupBox6.Location = new System.Drawing.Point(15, 193);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(873, 201);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cartera";
            // 
            // dtgCarteraCreditos
            // 
            this.dtgCarteraCreditos.AllowUserToAddRows = false;
            this.dtgCarteraCreditos.AllowUserToDeleteRows = false;
            this.dtgCarteraCreditos.AllowUserToResizeColumns = false;
            this.dtgCarteraCreditos.AllowUserToResizeRows = false;
            this.dtgCarteraCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCarteraCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarteraCreditos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDetalleHojaRutaCre,
            this.idIntervCre,
            this.idDireccion,
            this.nTotalPagar,
            this.idCli,
            this.idCuenta,
            this.cTipoIntervencion,
            this.cNombre,
            this.cTipoDir,
            this.lDirPrincipal,
            this.DireccionRecupera,
            this.cDireccion,
            this.nAtraso,
            this.cSimbolo,
            this.nSaldoCapital,
            this.cUbigeo,
            this.cObservacion});
            this.dtgCarteraCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCarteraCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCarteraCreditos.MultiSelect = false;
            this.dtgCarteraCreditos.Name = "dtgCarteraCreditos";
            this.dtgCarteraCreditos.ReadOnly = true;
            this.dtgCarteraCreditos.RowHeadersVisible = false;
            this.dtgCarteraCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCarteraCreditos.Size = new System.Drawing.Size(867, 182);
            this.dtgCarteraCreditos.TabIndex = 0;
            this.dtgCarteraCreditos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCarteraCreditos_CellEnter);
            // 
            // idDetalleHojaRutaCre
            // 
            this.idDetalleHojaRutaCre.DataPropertyName = "idDetalleHojaRuta";
            this.idDetalleHojaRutaCre.HeaderText = "idDetalleHojaRuta";
            this.idDetalleHojaRutaCre.Name = "idDetalleHojaRutaCre";
            this.idDetalleHojaRutaCre.ReadOnly = true;
            this.idDetalleHojaRutaCre.Visible = false;
            // 
            // idIntervCre
            // 
            this.idIntervCre.DataPropertyName = "idIntervCre";
            this.idIntervCre.HeaderText = "idIntervCre";
            this.idIntervCre.Name = "idIntervCre";
            this.idIntervCre.ReadOnly = true;
            this.idIntervCre.Visible = false;
            // 
            // idDireccion
            // 
            this.idDireccion.DataPropertyName = "idDireccion";
            this.idDireccion.HeaderText = "idDireccion";
            this.idDireccion.Name = "idDireccion";
            this.idDireccion.ReadOnly = true;
            this.idDireccion.Visible = false;
            // 
            // nTotalPagar
            // 
            this.nTotalPagar.DataPropertyName = "nTotalPagar";
            this.nTotalPagar.HeaderText = "nTotalPagar";
            this.nTotalPagar.Name = "nTotalPagar";
            this.nTotalPagar.ReadOnly = true;
            this.nTotalPagar.Visible = false;
            // 
            // idCli
            // 
            this.idCli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "Cod. Cliente";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Width = 89;
            // 
            // idCuenta
            // 
            this.idCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Width = 66;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "Tipo Interv";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            this.cTipoIntervencion.Width = 83;
            // 
            // cNombre
            // 
            this.cNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Nombres";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 74;
            // 
            // cTipoDir
            // 
            this.cTipoDir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTipoDir.DataPropertyName = "cTipoDir";
            this.cTipoDir.HeaderText = "Tipo Dirección";
            this.cTipoDir.Name = "cTipoDir";
            this.cTipoDir.ReadOnly = true;
            this.cTipoDir.Width = 101;
            // 
            // lDirPrincipal
            // 
            this.lDirPrincipal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lDirPrincipal.DataPropertyName = "lDirPrincipal";
            this.lDirPrincipal.HeaderText = "Dir. Princ.";
            this.lDirPrincipal.Name = "lDirPrincipal";
            this.lDirPrincipal.ReadOnly = true;
            this.lDirPrincipal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lDirPrincipal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.lDirPrincipal.Width = 78;
            // 
            // DireccionRecupera
            // 
            this.DireccionRecupera.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DireccionRecupera.DataPropertyName = "lDireccionRecupera";
            this.DireccionRecupera.HeaderText = "Dir. Recupera";
            this.DireccionRecupera.Name = "DireccionRecupera";
            this.DireccionRecupera.ReadOnly = true;
            this.DireccionRecupera.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DireccionRecupera.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DireccionRecupera.Width = 98;
            // 
            // cDireccion
            // 
            this.cDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDireccion.DataPropertyName = "cDireccion";
            this.cDireccion.HeaderText = "Direccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Width = 77;
            // 
            // nAtraso
            // 
            this.nAtraso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nAtraso.DataPropertyName = "nAtraso";
            this.nAtraso.HeaderText = "Atraso";
            this.nAtraso.Name = "nAtraso";
            this.nAtraso.ReadOnly = true;
            this.nAtraso.Width = 62;
            // 
            // cSimbolo
            // 
            this.cSimbolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cSimbolo.DataPropertyName = "cSimbolo";
            this.cSimbolo.HeaderText = "Moneda";
            this.cSimbolo.Name = "cSimbolo";
            this.cSimbolo.ReadOnly = true;
            this.cSimbolo.Width = 71;
            // 
            // nSaldoCapital
            // 
            this.nSaldoCapital.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nSaldoCapital.DataPropertyName = "nSaldoCapital";
            this.nSaldoCapital.HeaderText = "Saldo Capital";
            this.nSaldoCapital.Name = "nSaldoCapital";
            this.nSaldoCapital.ReadOnly = true;
            this.nSaldoCapital.Width = 94;
            // 
            // cUbigeo
            // 
            this.cUbigeo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cUbigeo.DataPropertyName = "cUbigeo";
            this.cUbigeo.HeaderText = "Ubigeo";
            this.cUbigeo.Name = "cUbigeo";
            this.cUbigeo.ReadOnly = true;
            this.cUbigeo.Width = 66;
            // 
            // cObservacion
            // 
            this.cObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cObservacion.DataPropertyName = "cObservacion";
            this.cObservacion.HeaderText = "Observación";
            this.cObservacion.Name = "cObservacion";
            this.cObservacion.ReadOnly = true;
            this.cObservacion.Width = 92;
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.groupBox8);
            this.grbFiltros.Controls.Add(this.btnConsultar1);
            this.grbFiltros.Controls.Add(this.chbDireccionPrincipal);
            this.grbFiltros.Controls.Add(this.groupBox5);
            this.grbFiltros.Controls.Add(this.groupBox4);
            this.grbFiltros.Controls.Add(this.groupBox3);
            this.grbFiltros.Location = new System.Drawing.Point(18, 9);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(870, 178);
            this.grbFiltros.TabIndex = 0;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cboTipoIntervCre1);
            this.groupBox8.Controls.Add(this.chbTodosIntervinientes);
            this.groupBox8.Location = new System.Drawing.Point(470, 115);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(305, 46);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Intervinientes";
            // 
            // cboTipoIntervCre1
            // 
            this.cboTipoIntervCre1.FormattingEnabled = true;
            this.cboTipoIntervCre1.Location = new System.Drawing.Point(14, 16);
            this.cboTipoIntervCre1.Name = "cboTipoIntervCre1";
            this.cboTipoIntervCre1.Size = new System.Drawing.Size(212, 21);
            this.cboTipoIntervCre1.TabIndex = 0;
            // 
            // chbTodosIntervinientes
            // 
            this.chbTodosIntervinientes.AutoSize = true;
            this.chbTodosIntervinientes.ForeColor = System.Drawing.Color.Navy;
            this.chbTodosIntervinientes.Location = new System.Drawing.Point(244, 18);
            this.chbTodosIntervinientes.Name = "chbTodosIntervinientes";
            this.chbTodosIntervinientes.Size = new System.Drawing.Size(56, 17);
            this.chbTodosIntervinientes.TabIndex = 1;
            this.chbTodosIntervinientes.Text = "Todos";
            this.chbTodosIntervinientes.UseVisualStyleBackColor = true;
            this.chbTodosIntervinientes.CheckedChanged += new System.EventHandler(this.chbTodosIntervinientes_CheckedChanged);
            // 
            // btnConsultar1
            // 
            this.btnConsultar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar1.BackgroundImage")));
            this.btnConsultar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar1.Location = new System.Drawing.Point(793, 19);
            this.btnConsultar1.Name = "btnConsultar1";
            this.btnConsultar1.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar1.TabIndex = 5;
            this.btnConsultar1.Text = "&Consultar";
            this.btnConsultar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar1.UseVisualStyleBackColor = true;
            this.btnConsultar1.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // chbDireccionPrincipal
            // 
            this.chbDireccionPrincipal.AutoSize = true;
            this.chbDireccionPrincipal.Checked = true;
            this.chbDireccionPrincipal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDireccionPrincipal.ForeColor = System.Drawing.Color.Navy;
            this.chbDireccionPrincipal.Location = new System.Drawing.Point(304, 130);
            this.chbDireccionPrincipal.Name = "chbDireccionPrincipal";
            this.chbDireccionPrincipal.Size = new System.Drawing.Size(160, 17);
            this.chbDireccionPrincipal.TabIndex = 3;
            this.chbDireccionPrincipal.Text = "Solo Direcciones Principales";
            this.chbDireccionPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtAtrazoMax);
            this.groupBox5.Controls.Add(this.txtAtrazoMin);
            this.groupBox5.Controls.Add(this.lblBase7);
            this.groupBox5.Controls.Add(this.lblBase8);
            this.groupBox5.Location = new System.Drawing.Point(295, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(480, 46);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Atraso";
            // 
            // txtAtrazoMax
            // 
            this.txtAtrazoMax.Location = new System.Drawing.Point(329, 16);
            this.txtAtrazoMax.Name = "txtAtrazoMax";
            this.txtAtrazoMax.Size = new System.Drawing.Size(132, 20);
            this.txtAtrazoMax.TabIndex = 1;
            // 
            // txtAtrazoMin
            // 
            this.txtAtrazoMin.Location = new System.Drawing.Point(75, 16);
            this.txtAtrazoMin.Name = "txtAtrazoMin";
            this.txtAtrazoMin.Size = new System.Drawing.Size(132, 20);
            this.txtAtrazoMin.TabIndex = 0;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(267, 20);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 3;
            this.lblBase7.Text = "Maximo:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(17, 20);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(52, 13);
            this.lblBase8.TabIndex = 2;
            this.lblBase8.Text = "Minimo:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSaldoCapitalMax);
            this.groupBox4.Controls.Add(this.txtSaldoCapitalMin);
            this.groupBox4.Controls.Add(this.lblBase6);
            this.groupBox4.Controls.Add(this.lblBase5);
            this.groupBox4.Location = new System.Drawing.Point(295, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(480, 46);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Saldo Capital:";
            // 
            // txtSaldoCapitalMax
            // 
            this.txtSaldoCapitalMax.FormatoDecimal = false;
            this.txtSaldoCapitalMax.Location = new System.Drawing.Point(329, 16);
            this.txtSaldoCapitalMax.Name = "txtSaldoCapitalMax";
            this.txtSaldoCapitalMax.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoCapitalMax.nNumDecimales = 4;
            this.txtSaldoCapitalMax.nvalor = 0D;
            this.txtSaldoCapitalMax.Size = new System.Drawing.Size(132, 20);
            this.txtSaldoCapitalMax.TabIndex = 1;
            // 
            // txtSaldoCapitalMin
            // 
            this.txtSaldoCapitalMin.FormatoDecimal = false;
            this.txtSaldoCapitalMin.Location = new System.Drawing.Point(75, 16);
            this.txtSaldoCapitalMin.Name = "txtSaldoCapitalMin";
            this.txtSaldoCapitalMin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoCapitalMin.nNumDecimales = 4;
            this.txtSaldoCapitalMin.nvalor = 0D;
            this.txtSaldoCapitalMin.Size = new System.Drawing.Size(132, 20);
            this.txtSaldoCapitalMin.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(267, 20);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(56, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "Maximo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(17, 20);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(52, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Minimo:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.conBusUbig1);
            this.groupBox3.Location = new System.Drawing.Point(14, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 153);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ubigeo";
            // 
            // conBusUbig1
            // 
            this.conBusUbig1.BackColor = System.Drawing.Color.Transparent;
            this.conBusUbig1.Controls.Add(this.cboAnexo);
            this.conBusUbig1.Controls.Add(this.cboDistrito);
            this.conBusUbig1.Controls.Add(this.cboProvincia);
            this.conBusUbig1.Controls.Add(this.cboDepartamento);
            this.conBusUbig1.Controls.Add(this.cboPais);
            this.conBusUbig1.Location = new System.Drawing.Point(23, 12);
            this.conBusUbig1.Name = "conBusUbig1";
            this.conBusUbig1.nIdNodo = 0;
            this.conBusUbig1.Size = new System.Drawing.Size(232, 130);
            this.conBusUbig1.TabIndex = 0;
            // 
            // cboAnexo
            // 
            this.cboAnexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnexo.FormattingEnabled = true;
            this.cboAnexo.Location = new System.Drawing.Point(103, 106);
            this.cboAnexo.Name = "cboAnexo";
            this.cboAnexo.Size = new System.Drawing.Size(121, 21);
            this.cboAnexo.TabIndex = 4;
            // 
            // cboDistrito
            // 
            this.cboDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(103, 81);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(121, 21);
            this.cboDistrito.TabIndex = 3;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(103, 56);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 2;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(103, 31);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(121, 21);
            this.cboDepartamento.TabIndex = 1;
            // 
            // cboPais
            // 
            this.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(103, 6);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(121, 21);
            this.cboPais.TabIndex = 0;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(439, 400);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(77, 13);
            this.lblBase2.TabIndex = 15;
            this.lblBase2.Text = "Notificación:";
            // 
            // cboTipoNotificacion1
            // 
            this.cboTipoNotificacion1.FormattingEnabled = true;
            this.cboTipoNotificacion1.Location = new System.Drawing.Point(522, 397);
            this.cboTipoNotificacion1.Name = "cboTipoNotificacion1";
            this.cboTipoNotificacion1.Size = new System.Drawing.Size(363, 21);
            this.cboTipoNotificacion1.TabIndex = 1;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(820, 426);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnAceptar1
            // 
            this.btnAceptar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar1.BackgroundImage")));
            this.btnAceptar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar1.Location = new System.Drawing.Point(754, 426);
            this.btnAceptar1.Name = "btnAceptar1";
            this.btnAceptar1.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar1.TabIndex = 2;
            this.btnAceptar1.Text = "&Aceptar";
            this.btnAceptar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar1.UseVisualStyleBackColor = true;
            this.btnAceptar1.Click += new System.EventHandler(this.btnAceptar1_Click);
            // 
            // frmAgregarCreditoHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 506);
            this.Controls.Add(this.cboTipoNotificacion1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.grbFiltros);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnAceptar1);
            this.Controls.Add(this.cboAccion1);
            this.Controls.Add(this.lblBase1);
            this.Name = "frmAgregarCreditoHojaRuta";
            this.Text = "Agregar Crédito";
            this.Load += new System.EventHandler(this.frmAgregarCreditoHojaRuta_Load);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.cboAccion1, 0);
            this.Controls.SetChildIndex(this.btnAceptar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbFiltros, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoNotificacion1, 0);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarteraCreditos)).EndInit();
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.conBusUbig1.ResumeLayout(false);
            this.conBusUbig1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        public GEN.ControlesBase.cboAccion cboAccion1;
        private GEN.BotonesBase.BtnAceptar btnAceptar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private System.Windows.Forms.GroupBox groupBox6;
        private GEN.ControlesBase.dtgBase dtgCarteraCreditos;
        private System.Windows.Forms.GroupBox grbFiltros;
        private System.Windows.Forms.GroupBox groupBox8;
        private GEN.ControlesBase.cboTipoIntervCre cboTipoIntervCre1;
        private System.Windows.Forms.CheckBox chbTodosIntervinientes;
        private GEN.BotonesBase.btnConsultar btnConsultar1;
        private System.Windows.Forms.CheckBox chbDireccionPrincipal;
        private System.Windows.Forms.GroupBox groupBox5;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrazoMax;
        private GEN.ControlesBase.txtCBNumerosEnteros txtAtrazoMin;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private System.Windows.Forms.GroupBox groupBox4;
        private GEN.ControlesBase.txtNumRea txtSaldoCapitalMax;
        private GEN.ControlesBase.txtNumRea txtSaldoCapitalMin;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private System.Windows.Forms.GroupBox groupBox3;
        private GEN.ControlesBase.ConBusUbig conBusUbig1;
        private GEN.ControlesBase.cboUbigeo cboAnexo;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.cboUbigeo cboDepartamento;
        private GEN.ControlesBase.cboUbigeo cboPais;
        private GEN.ControlesBase.lblBase lblBase2;
        public GEN.ControlesBase.cboTipoNotificacion cboTipoNotificacion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleHojaRutaCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIntervCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTotalPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lDirPrincipal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DireccionRecupera;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUbigeo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacion;
    }
}