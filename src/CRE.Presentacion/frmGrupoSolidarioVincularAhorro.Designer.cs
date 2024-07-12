namespace CRE.Presentacion
{
    partial class frmGrupoSolidarioVincularAhorro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrupoSolidarioVincularAhorro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxIntegrantes = new System.Windows.Forms.GroupBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.dtgGrupoSolidarioAhorro = new GEN.ControlesBase.dtgBase(this.components);
            this.bsGrupoSolidarioAhorro = new System.Windows.Forms.BindingSource(this.components);
            this.btnCambiar = new GEN.BotonesBase.btnCambiar();
            this.cboCuentaAhorro = new GEN.ControlesBase.cboBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.lblNroCuenta = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.nudSaldoDisponible = new GEN.ControlesBase.nudBase(this.components);
            this.gbxCuentaAhorro = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDepositar = new GEN.BotonesBase.btnDepositar();
            this.btnContinuar = new GEN.BotonesBase.btnContinuar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.idSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuentaAhorroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoBloqueoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoPendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lBonoGestionadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nSaldoDisponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxIntegrantes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoSolidarioAhorro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupoSolidarioAhorro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldoDisponible)).BeginInit();
            this.gbxCuentaAhorro.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxIntegrantes
            // 
            this.gbxIntegrantes.Controls.Add(this.lblMensaje);
            this.gbxIntegrantes.Controls.Add(this.dtgGrupoSolidarioAhorro);
            this.gbxIntegrantes.Location = new System.Drawing.Point(0, 0);
            this.gbxIntegrantes.Margin = new System.Windows.Forms.Padding(0);
            this.gbxIntegrantes.Name = "gbxIntegrantes";
            this.gbxIntegrantes.Padding = new System.Windows.Forms.Padding(0);
            this.gbxIntegrantes.Size = new System.Drawing.Size(740, 301);
            this.gbxIntegrantes.TabIndex = 2;
            this.gbxIntegrantes.TabStop = false;
            this.gbxIntegrantes.Text = "Integrantes";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(5, 27);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(497, 15);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "* Realice la apertura de cuentas en el módulo de ahorros para los resaltados en R" +
    "OJO.";
            this.lblMensaje.Visible = false;
            // 
            // dtgGrupoSolidarioAhorro
            // 
            this.dtgGrupoSolidarioAhorro.AllowUserToAddRows = false;
            this.dtgGrupoSolidarioAhorro.AllowUserToDeleteRows = false;
            this.dtgGrupoSolidarioAhorro.AllowUserToResizeColumns = false;
            this.dtgGrupoSolidarioAhorro.AllowUserToResizeRows = false;
            this.dtgGrupoSolidarioAhorro.AutoGenerateColumns = false;
            this.dtgGrupoSolidarioAhorro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgGrupoSolidarioAhorro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGrupoSolidarioAhorro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSolicitudDataGridViewTextBoxColumn,
            this.idCuentaAhorroDataGridViewTextBoxColumn,
            this.nMontoBloqueoDataGridViewTextBoxColumn,
            this.nMontoPendiente,
            this.cClienteDataGridViewTextBoxColumn,
            this.idEstadoDataGridViewTextBoxColumn,
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn,
            this.lBonoGestionadoDataGridViewCheckBoxColumn,
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn,
            this.nSaldoDisponible});
            this.dtgGrupoSolidarioAhorro.DataSource = this.bsGrupoSolidarioAhorro;
            this.dtgGrupoSolidarioAhorro.Location = new System.Drawing.Point(5, 46);
            this.dtgGrupoSolidarioAhorro.MultiSelect = false;
            this.dtgGrupoSolidarioAhorro.Name = "dtgGrupoSolidarioAhorro";
            this.dtgGrupoSolidarioAhorro.ReadOnly = true;
            this.dtgGrupoSolidarioAhorro.RowHeadersVisible = false;
            this.dtgGrupoSolidarioAhorro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGrupoSolidarioAhorro.Size = new System.Drawing.Size(732, 253);
            this.dtgGrupoSolidarioAhorro.TabIndex = 0;
            this.dtgGrupoSolidarioAhorro.SelectionChanged += new System.EventHandler(this.dtgGrupoSolidarioAhorro_SelectionChanged);
            // 
            // bsGrupoSolidarioAhorro
            // 
            this.bsGrupoSolidarioAhorro.DataSource = typeof(EntityLayer.clsGrupoSolidarioAhorro);
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCambiar.BackgroundImage")));
            this.btnCambiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCambiar.Location = new System.Drawing.Point(9, 222);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(60, 50);
            this.btnCambiar.TabIndex = 2;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // cboCuentaAhorro
            // 
            this.cboCuentaAhorro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCuentaAhorro.FormattingEnabled = true;
            this.cboCuentaAhorro.Location = new System.Drawing.Point(5, 46);
            this.cboCuentaAhorro.Name = "cboCuentaAhorro";
            this.cboCuentaAhorro.Size = new System.Drawing.Size(150, 21);
            this.cboCuentaAhorro.TabIndex = 1;
            this.cboCuentaAhorro.SelectionChangeCommitted += new System.EventHandler(this.cboCuentaAhorro_SelectionChangeCommitted);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(536, 2);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(602, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(668, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblNroCuenta
            // 
            this.lblNroCuenta.AutoSize = true;
            this.lblNroCuenta.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroCuenta.ForeColor = System.Drawing.Color.Navy;
            this.lblNroCuenta.Location = new System.Drawing.Point(3, 27);
            this.lblNroCuenta.Name = "lblNroCuenta";
            this.lblNroCuenta.Size = new System.Drawing.Size(109, 13);
            this.lblNroCuenta.TabIndex = 3;
            this.lblNroCuenta.Text = "N° Cuenta Ahorro";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(3, 76);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(102, 13);
            this.lblBase2.TabIndex = 4;
            this.lblBase2.Text = "Saldo Disponible";
            this.lblBase2.Visible = false;
            // 
            // nudSaldoDisponible
            // 
            this.nudSaldoDisponible.BackColor = System.Drawing.SystemColors.Info;
            this.nudSaldoDisponible.DecimalPlaces = 2;
            this.nudSaldoDisponible.Enabled = false;
            this.nudSaldoDisponible.Location = new System.Drawing.Point(6, 96);
            this.nudSaldoDisponible.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSaldoDisponible.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
            this.nudSaldoDisponible.Name = "nudSaldoDisponible";
            this.nudSaldoDisponible.ReadOnly = true;
            this.nudSaldoDisponible.Size = new System.Drawing.Size(149, 20);
            this.nudSaldoDisponible.TabIndex = 5;
            this.nudSaldoDisponible.Visible = false;
            // 
            // gbxCuentaAhorro
            // 
            this.gbxCuentaAhorro.Controls.Add(this.nudSaldoDisponible);
            this.gbxCuentaAhorro.Controls.Add(this.lblNroCuenta);
            this.gbxCuentaAhorro.Controls.Add(this.lblBase2);
            this.gbxCuentaAhorro.Controls.Add(this.cboCuentaAhorro);
            this.gbxCuentaAhorro.Controls.Add(this.btnCambiar);
            this.gbxCuentaAhorro.Location = new System.Drawing.Point(740, 0);
            this.gbxCuentaAhorro.Margin = new System.Windows.Forms.Padding(0);
            this.gbxCuentaAhorro.Name = "gbxCuentaAhorro";
            this.gbxCuentaAhorro.Padding = new System.Windows.Forms.Padding(0);
            this.gbxCuentaAhorro.Size = new System.Drawing.Size(160, 301);
            this.gbxCuentaAhorro.TabIndex = 6;
            this.gbxCuentaAhorro.TabStop = false;
            this.gbxCuentaAhorro.Text = "Cuentas de Ahorro";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDepositar);
            this.panel1.Controls.Add(this.btnContinuar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnGrabar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Location = new System.Drawing.Point(3, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 56);
            this.panel1.TabIndex = 7;
            // 
            // btnDepositar
            // 
            this.btnDepositar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDepositar.BackgroundImage")));
            this.btnDepositar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDepositar.Location = new System.Drawing.Point(71, 2);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(60, 50);
            this.btnDepositar.TabIndex = 7;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContinuar.BackgroundImage")));
            this.btnContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContinuar.Location = new System.Drawing.Point(5, 2);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(60, 50);
            this.btnContinuar.TabIndex = 6;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 740F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.gbxIntegrantes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbxCuentaAhorro, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.95165F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.04835F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 364);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // idSolicitudDataGridViewTextBoxColumn
            // 
            this.idSolicitudDataGridViewTextBoxColumn.DataPropertyName = "idSolicitud";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idSolicitudDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idSolicitudDataGridViewTextBoxColumn.HeaderText = "Solicitud";
            this.idSolicitudDataGridViewTextBoxColumn.Name = "idSolicitudDataGridViewTextBoxColumn";
            this.idSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            this.idSolicitudDataGridViewTextBoxColumn.Width = 72;
            // 
            // idCuentaAhorroDataGridViewTextBoxColumn
            // 
            this.idCuentaAhorroDataGridViewTextBoxColumn.DataPropertyName = "idCuentaAhorro";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idCuentaAhorroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idCuentaAhorroDataGridViewTextBoxColumn.HeaderText = "Cta. Ahorro";
            this.idCuentaAhorroDataGridViewTextBoxColumn.Name = "idCuentaAhorroDataGridViewTextBoxColumn";
            this.idCuentaAhorroDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCuentaAhorroDataGridViewTextBoxColumn.Width = 85;
            // 
            // nMontoBloqueoDataGridViewTextBoxColumn
            // 
            this.nMontoBloqueoDataGridViewTextBoxColumn.DataPropertyName = "nMontoBloqueo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.Format = "###,###,#0.00";
            this.nMontoBloqueoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nMontoBloqueoDataGridViewTextBoxColumn.HeaderText = "A Bloquear";
            this.nMontoBloqueoDataGridViewTextBoxColumn.Name = "nMontoBloqueoDataGridViewTextBoxColumn";
            this.nMontoBloqueoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMontoBloqueoDataGridViewTextBoxColumn.Width = 84;
            // 
            // nMontoPendiente
            // 
            this.nMontoPendiente.DataPropertyName = "nMontoPendiente";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "###,###,##0.00";
            this.nMontoPendiente.DefaultCellStyle = dataGridViewCellStyle4;
            this.nMontoPendiente.HeaderText = "Pendiente";
            this.nMontoPendiente.Name = "nMontoPendiente";
            this.nMontoPendiente.ReadOnly = true;
            this.nMontoPendiente.Width = 80;
            // 
            // cClienteDataGridViewTextBoxColumn
            // 
            this.cClienteDataGridViewTextBoxColumn.DataPropertyName = "cCliente";
            this.cClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.cClienteDataGridViewTextBoxColumn.Name = "cClienteDataGridViewTextBoxColumn";
            this.cClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cClienteDataGridViewTextBoxColumn.Width = 64;
            // 
            // idEstadoDataGridViewTextBoxColumn
            // 
            this.idEstadoDataGridViewTextBoxColumn.DataPropertyName = "idEstado";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idEstadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.idEstadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.idEstadoDataGridViewTextBoxColumn.Name = "idEstadoDataGridViewTextBoxColumn";
            this.idEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEstadoDataGridViewTextBoxColumn.Width = 65;
            // 
            // lAhorroBloqueadoDataGridViewCheckBoxColumn
            // 
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn.DataPropertyName = "lAhorroBloqueado";
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn.HeaderText = "Aho. Bloq.";
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn.Name = "lAhorroBloqueadoDataGridViewCheckBoxColumn";
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lAhorroBloqueadoDataGridViewCheckBoxColumn.Width = 62;
            // 
            // lBonoGestionadoDataGridViewCheckBoxColumn
            // 
            this.lBonoGestionadoDataGridViewCheckBoxColumn.DataPropertyName = "lBonoGestionado";
            this.lBonoGestionadoDataGridViewCheckBoxColumn.HeaderText = "Bono Gest.";
            this.lBonoGestionadoDataGridViewCheckBoxColumn.Name = "lBonoGestionadoDataGridViewCheckBoxColumn";
            this.lBonoGestionadoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lBonoGestionadoDataGridViewCheckBoxColumn.Width = 66;
            // 
            // nMontoBloqGrupoSolDataGridViewTextBoxColumn
            // 
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn.DataPropertyName = "nMontoBloqGrupoSol";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.Format = "###,###,#0.00";
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn.HeaderText = "Bloqdo GS";
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn.Name = "nMontoBloqGrupoSolDataGridViewTextBoxColumn";
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMontoBloqGrupoSolDataGridViewTextBoxColumn.Width = 83;
            // 
            // nSaldoDisponible
            // 
            this.nSaldoDisponible.DataPropertyName = "nSaldoDisponible";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle7.Format = "###,###,##0.00";
            this.nSaldoDisponible.DefaultCellStyle = dataGridViewCellStyle7;
            this.nSaldoDisponible.HeaderText = "Disponible";
            this.nSaldoDisponible.Name = "nSaldoDisponible";
            this.nSaldoDisponible.ReadOnly = true;
            this.nSaldoDisponible.Visible = false;
            this.nSaldoDisponible.Width = 81;
            // 
            // frmGrupoSolidarioVincularAhorro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(906, 390);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGrupoSolidarioVincularAhorro";
            this.Text = "Cuenta de Ahorro - Grupo Solidario";
            this.Shown += new System.EventHandler(this.frmGrupoSolidarioVincularAhorro_Shown);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.gbxIntegrantes.ResumeLayout(false);
            this.gbxIntegrantes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGrupoSolidarioAhorro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupoSolidarioAhorro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaldoDisponible)).EndInit();
            this.gbxCuentaAhorro.ResumeLayout(false);
            this.gbxCuentaAhorro.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxIntegrantes;
        private GEN.ControlesBase.cboBase cboCuentaAhorro;
        private GEN.ControlesBase.dtgBase dtgGrupoSolidarioAhorro;
        private GEN.BotonesBase.btnCambiar btnCambiar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.lblBase lblNroCuenta;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.nudBase nudSaldoDisponible;
        private System.Windows.Forms.GroupBox gbxCuentaAhorro;
        private System.Windows.Forms.Panel panel1;
        private GEN.BotonesBase.btnContinuar btnContinuar;
        private GEN.BotonesBase.btnDepositar btnDepositar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.BindingSource bsGrupoSolidarioAhorro;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuentaAhorroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoBloqueoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoPendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lAhorroBloqueadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lBonoGestionadoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoBloqGrupoSolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nSaldoDisponible;
    }
}