namespace DEP.Presentacion
{
    partial class frmAdministracionValorados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministracionValorados));
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoValorado1 = new GEN.ControlesBase.cboTipoValorado(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtNumFinal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgValEntregados = new GEN.ControlesBase.dtgBase(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgDetValorados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar1 = new GEN.BotonesBase.btnEliminar();
            this.grbBase1.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValEntregados)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetValorados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(487, 325);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(613, 325);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(550, 325);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(293, 14);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(125, 21);
            this.cboMoneda1.TabIndex = 6;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(231, 15);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Moneda:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(483, 14);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaInicio.TabIndex = 8;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            this.dtpFechaInicio.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaInicio_Validating_1);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(423, 15);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 9;
            this.lblBase2.Text = "Fech.Ini:";
            // 
            // cboTipoValorado1
            // 
            this.cboTipoValorado1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValorado1.FormattingEnabled = true;
            this.cboTipoValorado1.Location = new System.Drawing.Point(99, 14);
            this.cboTipoValorado1.Name = "cboTipoValorado1";
            this.cboTipoValorado1.Size = new System.Drawing.Size(125, 21);
            this.cboTipoValorado1.TabIndex = 13;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(9, 15);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(91, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Tipo Valorado:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(483, 42);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaFin.TabIndex = 14;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            this.dtpFechaFin.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaFin_Validating_1);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(423, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(58, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Fech.Fin:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboColaborador);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase8);
            this.grbBase1.Controls.Add(this.txtNumFinal);
            this.grbBase1.Controls.Add(this.txtNumInicio);
            this.grbBase1.Controls.Add(this.txtNumSerie);
            this.grbBase1.Location = new System.Drawing.Point(9, 67);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(665, 75);
            this.grbBase1.TabIndex = 16;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Valorado:";
            // 
            // cboColaborador
            // 
            this.cboColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColaborador.Enabled = false;
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(90, 48);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(315, 21);
            this.cboColaborador.TabIndex = 22;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(19, 51);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(65, 13);
            this.lblBase7.TabIndex = 21;
            this.lblBase7.Text = "Usu.Resp:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(414, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(58, 13);
            this.lblBase6.TabIndex = 20;
            this.lblBase6.Text = "Num.Fin:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(217, 22);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 19;
            this.lblBase5.Text = "Num.Ini:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(19, 22);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(66, 13);
            this.lblBase8.TabIndex = 18;
            this.lblBase8.Text = "Nro Serie:";
            // 
            // txtNumFinal
            // 
            this.txtNumFinal.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumFinal.Enabled = false;
            this.txtNumFinal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFinal.Location = new System.Drawing.Point(474, 19);
            this.txtNumFinal.Name = "txtNumFinal";
            this.txtNumFinal.Size = new System.Drawing.Size(125, 22);
            this.txtNumFinal.TabIndex = 17;
            this.txtNumFinal.Text = "0000001";
            this.txtNumFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumFinal_KeyPress);
            this.txtNumFinal.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumFinal_Validating);
            // 
            // txtNumInicio
            // 
            this.txtNumInicio.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumInicio.Enabled = false;
            this.txtNumInicio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumInicio.Location = new System.Drawing.Point(280, 19);
            this.txtNumInicio.Name = "txtNumInicio";
            this.txtNumInicio.Size = new System.Drawing.Size(125, 22);
            this.txtNumInicio.TabIndex = 16;
            this.txtNumInicio.Text = "0000001";
            this.txtNumInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNumSerie
            // 
            this.txtNumSerie.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumSerie.Enabled = false;
            this.txtNumSerie.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumSerie.Location = new System.Drawing.Point(90, 19);
            this.txtNumSerie.Name = "txtNumSerie";
            this.txtNumSerie.Size = new System.Drawing.Size(125, 22);
            this.txtNumSerie.TabIndex = 15;
            this.txtNumSerie.Text = "0000001";
            this.txtNumSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(361, 325);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Controls.Add(this.tabPage2);
            this.tbcBase1.Location = new System.Drawing.Point(9, 148);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(665, 175);
            this.tbcBase1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgValEntregados);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 149);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Valorados Entregados:";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgValEntregados
            // 
            this.dtgValEntregados.AllowUserToAddRows = false;
            this.dtgValEntregados.AllowUserToDeleteRows = false;
            this.dtgValEntregados.AllowUserToResizeColumns = false;
            this.dtgValEntregados.AllowUserToResizeRows = false;
            this.dtgValEntregados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValEntregados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValEntregados.Location = new System.Drawing.Point(17, 10);
            this.dtgValEntregados.MultiSelect = false;
            this.dtgValEntregados.Name = "dtgValEntregados";
            this.dtgValEntregados.ReadOnly = true;
            this.dtgValEntregados.RowHeadersVisible = false;
            this.dtgValEntregados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValEntregados.Size = new System.Drawing.Size(621, 130);
            this.dtgValEntregados.TabIndex = 0;
            this.dtgValEntregados.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgValEntregados_CurrentCellDirtyStateChanged);
            this.dtgValEntregados.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValEntregados_RowEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgDetValorados);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 149);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalle de Valorados:";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgDetValorados
            // 
            this.dtgDetValorados.AllowUserToAddRows = false;
            this.dtgDetValorados.AllowUserToDeleteRows = false;
            this.dtgDetValorados.AllowUserToResizeColumns = false;
            this.dtgDetValorados.AllowUserToResizeRows = false;
            this.dtgDetValorados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetValorados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetValorados.Location = new System.Drawing.Point(18, 11);
            this.dtgDetValorados.MultiSelect = false;
            this.dtgDetValorados.Name = "dtgDetValorados";
            this.dtgDetValorados.ReadOnly = true;
            this.dtgDetValorados.RowHeadersVisible = false;
            this.dtgDetValorados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetValorados.Size = new System.Drawing.Size(621, 127);
            this.dtgDetValorados.TabIndex = 1;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(614, 14);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 28;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.ForeColor = System.Drawing.Color.Red;
            this.chcBase1.Location = new System.Drawing.Point(293, 43);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(94, 17);
            this.chcBase1.TabIndex = 29;
            this.chcBase1.Text = "Mostrar Todos";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(84, 325);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 31;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 44);
            this.label1.TabIndex = 35;
            this.label1.Text = "Ver Valorados Asignados a Agencia:";
            // 
            // btnEliminar1
            // 
            this.btnEliminar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar1.BackgroundImage")));
            this.btnEliminar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar1.Location = new System.Drawing.Point(424, 325);
            this.btnEliminar1.Name = "btnEliminar1";
            this.btnEliminar1.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar1.TabIndex = 36;
            this.btnEliminar1.Text = "&Eliminar";
            this.btnEliminar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar1.UseVisualStyleBackColor = true;
            this.btnEliminar1.Click += new System.EventHandler(this.btnEliminar2_Click);
            // 
            // frmAdministracionValorados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 402);
            this.Controls.Add(this.btnEliminar1);
            this.Controls.Add(this.btnBusqueda1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.tbcBase1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.cboTipoValorado1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmAdministracionValorados";
            this.Text = "Generación de Valorados";
            this.Load += new System.EventHandler(this.frmAdministracionValorados_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipoValorado1, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.tbcBase1, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnBusqueda1, 0);
            this.Controls.SetChildIndex(this.btnEliminar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgValEntregados)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetValorados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoValorado cboTipoValorado1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumFinal;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumInicio;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumSerie;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GEN.ControlesBase.dtgBase dtgValEntregados;
        private GEN.ControlesBase.dtgBase dtgDetValorados;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnEliminar btnEliminar1;
    }
}