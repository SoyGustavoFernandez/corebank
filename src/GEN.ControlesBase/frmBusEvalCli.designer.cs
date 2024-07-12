namespace GEN.ControlesBase
{
    partial class frmBusEvalCli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusEvalCli));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnDevolver = new GEN.BotonesBase.btnDevolver(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgEvalCli = new GEN.ControlesBase.dtgBase(this.components);
            this.lSeleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cEstSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAsesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.conBusCli = new GEN.ControlesBase.ConBusCli();
            this.btnBuscar = new GEN.BotonesBase.btnBusqueda();
            this.chcBusMonto = new GEN.ControlesBase.chcBase(this.components);
            this.grbBusMontoSol = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtMontoFin = new GEN.ControlesBase.txtNumRea(this.components);
            this.txtMontoIni = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcBusFecSol = new GEN.ControlesBase.chcBase(this.components);
            this.grbBusFecSol = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.chcBusCli = new GEN.ControlesBase.chcBase(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grbCanalAproCred = new GEN.ControlesBase.grbBase(this.components);
            this.btnBuscarPorCanal = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.cboCanalAproCred = new GEN.ControlesBase.cboCanalAproCred(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvalCli)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBusMontoSol.SuspendLayout();
            this.grbBusFecSol.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.grbCanalAproCred.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.btnAceptar);
            this.grbBase3.Controls.Add(this.btnDevolver);
            this.grbBase3.Controls.Add(this.btnSalir);
            this.grbBase3.Location = new System.Drawing.Point(3, 504);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Padding = new System.Windows.Forms.Padding(1);
            this.grbBase3.Size = new System.Drawing.Size(746, 63);
            this.grbBase3.TabIndex = 13;
            this.grbBase3.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(614, 9);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDevolver.BackgroundImage")));
            this.btnDevolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDevolver.Location = new System.Drawing.Point(6, 9);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(60, 50);
            this.btnDevolver.TabIndex = 13;
            this.btnDevolver.Text = "&Devolver";
            this.btnDevolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(680, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dtgEvalCli
            // 
            this.dtgEvalCli.AllowUserToAddRows = false;
            this.dtgEvalCli.AllowUserToDeleteRows = false;
            this.dtgEvalCli.AllowUserToResizeColumns = false;
            this.dtgEvalCli.AllowUserToResizeRows = false;
            this.dtgEvalCli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvalCli.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEvalCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvalCli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lSeleccion,
            this.Column1,
            this.idEval,
            this.idSolicitud,
            this.cEstSol,
            this.cNombre,
            this.cAsesor,
            this.cMoneda,
            this.nMontoSol,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEvalCli.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgEvalCli.Location = new System.Drawing.Point(3, 286);
            this.dtgEvalCli.MultiSelect = false;
            this.dtgEvalCli.Name = "dtgEvalCli";
            this.dtgEvalCli.ReadOnly = true;
            this.dtgEvalCli.RowHeadersVisible = false;
            this.dtgEvalCli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvalCli.Size = new System.Drawing.Size(746, 212);
            this.dtgEvalCli.TabIndex = 10;
            this.dtgEvalCli.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEvalCli_CellClick);
            // 
            // lSeleccion
            // 
            this.lSeleccion.FillWeight = 15F;
            this.lSeleccion.HeaderText = "";
            this.lSeleccion.Name = "lSeleccion";
            this.lSeleccion.ReadOnly = true;
            this.lSeleccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lSeleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "cCanalAproCred";
            this.Column1.HeaderText = "Canal";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // idEval
            // 
            this.idEval.DataPropertyName = "idEval";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idEval.DefaultCellStyle = dataGridViewCellStyle2;
            this.idEval.FillWeight = 97.50419F;
            this.idEval.HeaderText = "Eval.";
            this.idEval.Name = "idEval";
            this.idEval.ReadOnly = true;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.FillWeight = 97.50419F;
            this.idSolicitud.HeaderText = "Solicitud";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            // 
            // cEstSol
            // 
            this.cEstSol.DataPropertyName = "cEstSol";
            this.cEstSol.FillWeight = 97.50419F;
            this.cEstSol.HeaderText = "Estado";
            this.cEstSol.Name = "cEstSol";
            this.cEstSol.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 97.50419F;
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cAsesor
            // 
            this.cAsesor.DataPropertyName = "cAsesor";
            this.cAsesor.FillWeight = 97.50419F;
            this.cAsesor.HeaderText = "Asesor";
            this.cAsesor.Name = "cAsesor";
            this.cAsesor.ReadOnly = true;
            // 
            // cMoneda
            // 
            this.cMoneda.DataPropertyName = "cMoneda";
            this.cMoneda.FillWeight = 97.50419F;
            this.cMoneda.HeaderText = "Moneda";
            this.cMoneda.Name = "cMoneda";
            this.cMoneda.ReadOnly = true;
            // 
            // nMontoSol
            // 
            this.nMontoSol.DataPropertyName = "nMontoProp";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,0.00";
            this.nMontoSol.DefaultCellStyle = dataGridViewCellStyle3;
            this.nMontoSol.FillWeight = 97.50419F;
            this.nMontoSol.HeaderText = "Monto";
            this.nMontoSol.Name = "nMontoSol";
            this.nMontoSol.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cNomCorto";
            this.Column2.FillWeight = 160F;
            this.Column2.HeaderText = "Agencia";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "cNombreEstab";
            this.Column3.FillWeight = 200F;
            this.Column3.HeaderText = "Establec.";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Controls.Add(this.btnBuscar);
            this.grbBase1.Controls.Add(this.chcBusMonto);
            this.grbBase1.Controls.Add(this.grbBusMontoSol);
            this.grbBase1.Controls.Add(this.chcBusFecSol);
            this.grbBase1.Controls.Add(this.grbBusFecSol);
            this.grbBase1.Controls.Add(this.chcBusCli);
            this.grbBase1.Location = new System.Drawing.Point(3, 60);
            this.grbBase1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(746, 223);
            this.grbBase1.TabIndex = 12;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Parametros de busqueda";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.conBusCli);
            this.grbBase2.Location = new System.Drawing.Point(14, 38);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(550, 90);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            // 
            // conBusCli
            // 
            this.conBusCli.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli.idCli = 0;
            this.conBusCli.Location = new System.Drawing.Point(5, 10);
            this.conBusCli.Name = "conBusCli";
            this.conBusCli.Size = new System.Drawing.Size(523, 78);
            this.conBusCli.TabIndex = 11;
            this.conBusCli.ClicBuscar += new System.EventHandler(this.conBusCli_ClicBuscar);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.Location = new System.Drawing.Point(680, 165);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 50);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // chcBusMonto
            // 
            this.chcBusMonto.AutoSize = true;
            this.chcBusMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcBusMonto.ForeColor = System.Drawing.Color.Navy;
            this.chcBusMonto.Location = new System.Drawing.Point(297, 139);
            this.chcBusMonto.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chcBusMonto.Name = "chcBusMonto";
            this.chcBusMonto.Size = new System.Drawing.Size(200, 17);
            this.chcBusMonto.TabIndex = 1;
            this.chcBusMonto.Text = "Busqueda por monto solicitado";
            this.chcBusMonto.UseVisualStyleBackColor = true;
            this.chcBusMonto.CheckedChanged += new System.EventHandler(this.chcBusMonto_CheckedChanged);
            // 
            // grbBusMontoSol
            // 
            this.grbBusMontoSol.Controls.Add(this.lblBase4);
            this.grbBusMontoSol.Controls.Add(this.lblBase3);
            this.grbBusMontoSol.Controls.Add(this.txtMontoFin);
            this.grbBusMontoSol.Controls.Add(this.txtMontoIni);
            this.grbBusMontoSol.Enabled = false;
            this.grbBusMontoSol.Location = new System.Drawing.Point(292, 150);
            this.grbBusMontoSol.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.grbBusMontoSol.Name = "grbBusMontoSol";
            this.grbBusMontoSol.Size = new System.Drawing.Size(272, 65);
            this.grbBusMontoSol.TabIndex = 14;
            this.grbBusMontoSol.TabStop = false;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(34, 42);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Hasta:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(30, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(48, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Desde:";
            // 
            // txtMontoFin
            // 
            this.txtMontoFin.FormatoDecimal = false;
            this.txtMontoFin.Location = new System.Drawing.Point(84, 38);
            this.txtMontoFin.MaxLength = 9;
            this.txtMontoFin.Name = "txtMontoFin";
            this.txtMontoFin.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoFin.nNumDecimales = 4;
            this.txtMontoFin.nvalor = 0D;
            this.txtMontoFin.Size = new System.Drawing.Size(155, 20);
            this.txtMontoFin.TabIndex = 1;
            this.txtMontoFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoFin.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // txtMontoIni
            // 
            this.txtMontoIni.FormatoDecimal = false;
            this.txtMontoIni.Location = new System.Drawing.Point(84, 16);
            this.txtMontoIni.MaxLength = 9;
            this.txtMontoIni.Name = "txtMontoIni";
            this.txtMontoIni.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoIni.nNumDecimales = 4;
            this.txtMontoIni.nvalor = 0D;
            this.txtMontoIni.Size = new System.Drawing.Size(155, 20);
            this.txtMontoIni.TabIndex = 0;
            this.txtMontoIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontoIni.Leave += new System.EventHandler(this.txtMonto_Leave);
            // 
            // chcBusFecSol
            // 
            this.chcBusFecSol.AutoSize = true;
            this.chcBusFecSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcBusFecSol.ForeColor = System.Drawing.Color.Navy;
            this.chcBusFecSol.Location = new System.Drawing.Point(14, 139);
            this.chcBusFecSol.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chcBusFecSol.Name = "chcBusFecSol";
            this.chcBusFecSol.Size = new System.Drawing.Size(209, 17);
            this.chcBusFecSol.TabIndex = 12;
            this.chcBusFecSol.Text = "Busqueda por fecha de solicitud";
            this.chcBusFecSol.UseVisualStyleBackColor = true;
            this.chcBusFecSol.CheckedChanged += new System.EventHandler(this.chcBusFecSol_CheckedChanged);
            // 
            // grbBusFecSol
            // 
            this.grbBusFecSol.Controls.Add(this.lblBase2);
            this.grbBusFecSol.Controls.Add(this.lblBase1);
            this.grbBusFecSol.Controls.Add(this.dtpFecFin);
            this.grbBusFecSol.Controls.Add(this.dtpFecIni);
            this.grbBusFecSol.Enabled = false;
            this.grbBusFecSol.Location = new System.Drawing.Point(14, 150);
            this.grbBusFecSol.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.grbBusFecSol.Name = "grbBusFecSol";
            this.grbBusFecSol.Size = new System.Drawing.Size(272, 65);
            this.grbBusFecSol.TabIndex = 13;
            this.grbBusFecSol.TabStop = false;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(36, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Hasta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(32, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Desde:";
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(86, 38);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(155, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(86, 16);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(155, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // chcBusCli
            // 
            this.chcBusCli.AutoSize = true;
            this.chcBusCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcBusCli.ForeColor = System.Drawing.Color.Navy;
            this.chcBusCli.Location = new System.Drawing.Point(14, 20);
            this.chcBusCli.Name = "chcBusCli";
            this.chcBusCli.Size = new System.Drawing.Size(146, 17);
            this.chcBusCli.TabIndex = 0;
            this.chcBusCli.Text = "Busqueda por cliente";
            this.chcBusCli.UseVisualStyleBackColor = true;
            this.chcBusCli.CheckedChanged += new System.EventHandler(this.chcBusCli_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.grbCanalAproCred);
            this.flowLayoutPanel1.Controls.Add(this.grbBase1);
            this.flowLayoutPanel1.Controls.Add(this.dtgEvalCli);
            this.flowLayoutPanel1.Controls.Add(this.grbBase3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(755, 571);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // grbCanalAproCred
            // 
            this.grbCanalAproCred.Controls.Add(this.btnBuscarPorCanal);
            this.grbCanalAproCred.Controls.Add(this.cboCanalAproCred);
            this.grbCanalAproCred.Controls.Add(this.lblBase5);
            this.grbCanalAproCred.Location = new System.Drawing.Point(3, 3);
            this.grbCanalAproCred.Name = "grbCanalAproCred";
            this.grbCanalAproCred.Size = new System.Drawing.Size(746, 54);
            this.grbCanalAproCred.TabIndex = 14;
            this.grbCanalAproCred.TabStop = false;
            this.grbCanalAproCred.Text = "Parametros de busqueda globales";
            this.grbCanalAproCred.Visible = false;
            // 
            // btnBuscarPorCanal
            // 
            this.btnBuscarPorCanal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarPorCanal.BackgroundImage")));
            this.btnBuscarPorCanal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarPorCanal.Location = new System.Drawing.Point(346, 19);
            this.btnBuscarPorCanal.Name = "btnBuscarPorCanal";
            this.btnBuscarPorCanal.Size = new System.Drawing.Size(36, 28);
            this.btnBuscarPorCanal.TabIndex = 4;
            this.btnBuscarPorCanal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarPorCanal.UseVisualStyleBackColor = true;
            this.btnBuscarPorCanal.Click += new System.EventHandler(this.btnBuscarPorCanal_Click);
            // 
            // cboCanalAproCred
            // 
            this.cboCanalAproCred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCanalAproCred.FormattingEnabled = true;
            this.cboCanalAproCred.Location = new System.Drawing.Point(148, 22);
            this.cboCanalAproCred.Name = "cboCanalAproCred";
            this.cboCanalAproCred.Size = new System.Drawing.Size(172, 21);
            this.cboCanalAproCred.TabIndex = 1;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(11, 25);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(131, 13);
            this.lblBase5.TabIndex = 0;
            this.lblBase5.Text = "Canal de Aprobacion:";
            // 
            // frmBusEvalCli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(755, 593);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmBusEvalCli";
            this.ShowInTaskbar = false;
            this.Text = "Buscar evaluaciones de clientes";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvalCli)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBusMontoSol.ResumeLayout(false);
            this.grbBusMontoSol.PerformLayout();
            this.grbBusFecSol.ResumeLayout(false);
            this.grbBusFecSol.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.grbCanalAproCred.ResumeLayout(false);
            this.grbCanalAproCred.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private grbBase grbBase3;
        private BotonesBase.BtnAceptar btnAceptar;
        private BotonesBase.btnDevolver btnDevolver;
        private BotonesBase.btnSalir btnSalir;
        private dtgBase dtgEvalCli;
        private grbBase grbBase1;
        private grbBase grbBase2;
        private ConBusCli conBusCli;
        private BotonesBase.btnBusqueda btnBuscar;
        private chcBase chcBusMonto;
        private grbBase grbBusMontoSol;
        private lblBase lblBase4;
        private lblBase lblBase3;
        private txtNumRea txtMontoFin;
        private txtNumRea txtMontoIni;
        private chcBase chcBusFecSol;
        private grbBase grbBusFecSol;
        private lblBase lblBase2;
        private lblBase lblBase1;
        private dtpCorto dtpFecFin;
        private dtpCorto dtpFecIni;
        private chcBase chcBusCli;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private grbBase grbCanalAproCred;
        private lblBase lblBase5;
        private cboCanalAproCred cboCanalAproCred;
        private BotonesBase.btnMiniBusq btnBuscarPorCanal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lSeleccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEval;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cEstSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAsesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

