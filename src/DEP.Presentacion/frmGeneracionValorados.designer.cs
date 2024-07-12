namespace DEP.Presentacion
{
    partial class frmGeneracionValorados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneracionValorados));
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboTipoValorado1 = new GEN.ControlesBase.cboTipoValorado(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtNumFinal = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumInicio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtNumSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboColaborador = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.chcAsignados = new GEN.ControlesBase.chcBase(this.components);
            this.chcAnulados = new GEN.ControlesBase.chcBase(this.components);
            this.dtgValorados = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.chcBase1 = new GEN.ControlesBase.chcBase(this.components);
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(310, 414);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(499, 414);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(625, 414);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(562, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(226, 13);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(56, 13);
            this.lblBase1.TabIndex = 9;
            this.lblBase1.Text = "Moneda:";
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(283, 10);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(125, 21);
            this.cboMoneda1.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(2, 13);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(91, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Tipo Valorado:";
            // 
            // cboTipoValorado1
            // 
            this.cboTipoValorado1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoValorado1.FormattingEnabled = true;
            this.cboTipoValorado1.Location = new System.Drawing.Point(90, 10);
            this.cboTipoValorado1.Name = "cboTipoValorado1";
            this.cboTipoValorado1.Size = new System.Drawing.Size(125, 21);
            this.cboTipoValorado1.TabIndex = 1;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.txtNumFinal);
            this.grbBase1.Controls.Add(this.txtNumInicio);
            this.grbBase1.Controls.Add(this.txtNumSerie);
            this.grbBase1.Controls.Add(this.cboColaborador);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Location = new System.Drawing.Point(5, 66);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(681, 79);
            this.grbBase1.TabIndex = 14;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de Valorado:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(415, 22);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(58, 13);
            this.lblBase6.TabIndex = 30;
            this.lblBase6.Text = "Num.Fin:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(220, 22);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 29;
            this.lblBase5.Text = "Num.Ini:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(66, 13);
            this.lblBase3.TabIndex = 28;
            this.lblBase3.Text = "Nro Serie:";
            // 
            // txtNumFinal
            // 
            this.txtNumFinal.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumFinal.Enabled = false;
            this.txtNumFinal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFinal.Location = new System.Drawing.Point(476, 19);
            this.txtNumFinal.MaxLength = 7;
            this.txtNumFinal.Name = "txtNumFinal";
            this.txtNumFinal.Size = new System.Drawing.Size(125, 22);
            this.txtNumFinal.TabIndex = 9;
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
            this.txtNumInicio.Location = new System.Drawing.Point(279, 19);
            this.txtNumInicio.MaxLength = 7;
            this.txtNumInicio.Name = "txtNumInicio";
            this.txtNumInicio.Size = new System.Drawing.Size(125, 22);
            this.txtNumInicio.TabIndex = 8;
            this.txtNumInicio.Text = "0000001";
            this.txtNumInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumInicio_KeyPress);
            this.txtNumInicio.Validated += new System.EventHandler(this.txtNumInicio_Validated);
            // 
            // txtNumSerie
            // 
            this.txtNumSerie.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumSerie.Enabled = false;
            this.txtNumSerie.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumSerie.Location = new System.Drawing.Point(90, 19);
            this.txtNumSerie.MaxLength = 7;
            this.txtNumSerie.Name = "txtNumSerie";
            this.txtNumSerie.Size = new System.Drawing.Size(125, 22);
            this.txtNumSerie.TabIndex = 7;
            this.txtNumSerie.Text = "0000001";
            this.txtNumSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumSerie.TextChanged += new System.EventHandler(this.txtNumSerie_TextChanged);
            this.txtNumSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumSerie_KeyPress);
            this.txtNumSerie.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumSerie_Validating);
            // 
            // cboColaborador
            // 
            this.cboColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColaborador.Enabled = false;
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Location = new System.Drawing.Point(87, 49);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(316, 21);
            this.cboColaborador.TabIndex = 10;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(18, 52);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(65, 13);
            this.lblBase7.TabIndex = 21;
            this.lblBase7.Text = "Usu.Resp:";
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(373, 414);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(226, 42);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(57, 13);
            this.lblBase8.TabIndex = 23;
            this.lblBase8.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(283, 39);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(125, 21);
            this.cboAgencia.TabIndex = 3;
            this.cboAgencia.SelectedIndexChanged += new System.EventHandler(this.cboAgencia1_SelectedIndexChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.chcAsignados);
            this.grbBase2.Controls.Add(this.chcAnulados);
            this.grbBase2.Controls.Add(this.dtgValorados);
            this.grbBase2.Location = new System.Drawing.Point(5, 151);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(681, 199);
            this.grbBase2.TabIndex = 15;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Valorados Generados";
            // 
            // chcAsignados
            // 
            this.chcAsignados.AutoSize = true;
            this.chcAsignados.Location = new System.Drawing.Point(593, 11);
            this.chcAsignados.Name = "chcAsignados";
            this.chcAsignados.Size = new System.Drawing.Size(78, 17);
            this.chcAsignados.TabIndex = 2;
            this.chcAsignados.Text = "Ingresados";
            this.chcAsignados.UseVisualStyleBackColor = true;
            this.chcAsignados.Visible = false;
            this.chcAsignados.CheckedChanged += new System.EventHandler(this.chcAsignados_CheckedChanged);
            // 
            // chcAnulados
            // 
            this.chcAnulados.AutoSize = true;
            this.chcAnulados.Location = new System.Drawing.Point(521, 11);
            this.chcAnulados.Name = "chcAnulados";
            this.chcAnulados.Size = new System.Drawing.Size(70, 17);
            this.chcAnulados.TabIndex = 1;
            this.chcAnulados.Text = "Anulados";
            this.chcAnulados.UseVisualStyleBackColor = true;
            this.chcAnulados.Visible = false;
            this.chcAnulados.CheckedChanged += new System.EventHandler(this.chcTodos_CheckedChanged);
            // 
            // dtgValorados
            // 
            this.dtgValorados.AllowUserToAddRows = false;
            this.dtgValorados.AllowUserToDeleteRows = false;
            this.dtgValorados.AllowUserToResizeColumns = false;
            this.dtgValorados.AllowUserToResizeRows = false;
            this.dtgValorados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgValorados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgValorados.Location = new System.Drawing.Point(26, 32);
            this.dtgValorados.MultiSelect = false;
            this.dtgValorados.Name = "dtgValorados";
            this.dtgValorados.ReadOnly = true;
            this.dtgValorados.RowHeadersVisible = false;
            this.dtgValorados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgValorados.Size = new System.Drawing.Size(642, 156);
            this.dtgValorados.TabIndex = 0;
            this.dtgValorados.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgValorados_CurrentCellDirtyStateChanged);
            this.dtgValorados.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgValorados_RowEnter);
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Enabled = false;
            this.btnAnular.Location = new System.Drawing.Point(436, 414);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 13;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular1_Click);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(420, 45);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(58, 13);
            this.lblBase9.TabIndex = 19;
            this.lblBase9.Text = "Fech.Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(481, 39);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaFin.TabIndex = 5;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            this.dtpFechaFin.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaFin_Validating);
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(421, 16);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(57, 13);
            this.lblBase10.TabIndex = 17;
            this.lblBase10.Text = "Fech.Ini:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(481, 10);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaInicio.TabIndex = 4;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            this.dtpFechaInicio.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaInicio_Validating);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(613, 9);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 6;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // chcBase1
            // 
            this.chcBase1.AutoSize = true;
            this.chcBase1.ForeColor = System.Drawing.Color.Red;
            this.chcBase1.Location = new System.Drawing.Point(92, 42);
            this.chcBase1.Name = "chcBase1";
            this.chcBase1.Size = new System.Drawing.Size(94, 17);
            this.chcBase1.TabIndex = 26;
            this.chcBase1.Text = "Mostrar Todos";
            this.chcBase1.UseVisualStyleBackColor = true;
            this.chcBase1.CheckedChanged += new System.EventHandler(this.chcBase1_CheckedChanged);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(5, 370);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(681, 38);
            this.txtMotivo.TabIndex = 27;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(2, 354);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(49, 13);
            this.lblBase4.TabIndex = 29;
            this.lblBase4.Text = "Motivo:";
            // 
            // frmGeneracionValorados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 487);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.chcBase1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.cboTipoValorado1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmGeneracionValorados";
            this.Text = "Asignación de Valorados";
            this.Load += new System.EventHandler(this.frmGeneracionValorados_Load);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.cboTipoValorado1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.chcBase1, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValorados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboTipoValorado cboTipoValorado1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.dtgBase dtgValorados;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.cboBase cboColaborador;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnProcesar btnProcesar;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumFinal;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumInicio;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumSerie;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.ControlesBase.chcBase chcBase1;
        private GEN.ControlesBase.chcBase chcAsignados;
        private GEN.ControlesBase.chcBase chcAnulados;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}