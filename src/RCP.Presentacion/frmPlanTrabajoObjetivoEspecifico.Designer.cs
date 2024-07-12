namespace RCP.Presentacion
{
    partial class frmPlanTrabajoObjetivoEspecifico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanTrabajoObjetivoEspecifico));
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.cboObjetivoTipo = new GEN.ControlesBase.cboBase(this.components);
            this.dtpFechaEspecifica = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtDescripcionObjetivoGeneral = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboObjetivoGeneral = new GEN.ControlesBase.cboBase(this.components);
            this.cboSemanaObjetivo = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboObjetivoResumen = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniDetalle = new GEN.BotonesBase.btnMiniDetalle(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.cboAccionResumen = new GEN.ControlesBase.cboBase(this.components);
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.dtgDetalleAccionCliente = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtDetalleAccion = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.txtDescripcionZonaVisita = new GEN.ControlesBase.txtBase(this.components);
            this.cboZona = new GEN.ControlesBase.cboZona(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAccionCliente)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(861, 424);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(921, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboObjetivoTipo
            // 
            this.cboObjetivoTipo.Enabled = false;
            this.cboObjetivoTipo.FormattingEnabled = true;
            this.cboObjetivoTipo.Location = new System.Drawing.Point(142, 19);
            this.cboObjetivoTipo.Name = "cboObjetivoTipo";
            this.cboObjetivoTipo.Size = new System.Drawing.Size(400, 21);
            this.cboObjetivoTipo.TabIndex = 0;
            this.cboObjetivoTipo.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoTipo_SelectedIndexChanged);
            // 
            // dtpFechaEspecifica
            // 
            this.dtpFechaEspecifica.Location = new System.Drawing.Point(142, 127);
            this.dtpFechaEspecifica.Name = "dtpFechaEspecifica";
            this.dtpFechaEspecifica.Size = new System.Drawing.Size(400, 20);
            this.dtpFechaEspecifica.TabIndex = 4;
            this.dtpFechaEspecifica.Leave += new System.EventHandler(this.dtpFechaEspecifica_Leave);
            // 
            // txtDescripcionObjetivoGeneral
            // 
            this.txtDescripcionObjetivoGeneral.Location = new System.Drawing.Point(142, 149);
            this.txtDescripcionObjetivoGeneral.MaxLength = 1000;
            this.txtDescripcionObjetivoGeneral.Multiline = true;
            this.txtDescripcionObjetivoGeneral.Name = "txtDescripcionObjetivoGeneral";
            this.txtDescripcionObjetivoGeneral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionObjetivoGeneral.Size = new System.Drawing.Size(400, 75);
            this.txtDescripcionObjetivoGeneral.TabIndex = 5;
            this.txtDescripcionObjetivoGeneral.Leave += new System.EventHandler(this.txtDescripcionObjetivoGeneral_Leave);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 23);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(88, 13);
            this.lblBase1.TabIndex = 7;
            this.lblBase1.Text = "Tipo Objetivo:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 131);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(103, 13);
            this.lblBase2.TabIndex = 8;
            this.lblBase2.Text = "Fecha Ejecución:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 173);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(120, 26);
            this.lblBase3.TabIndex = 9;
            this.lblBase3.Text = "Descripción del\r\nObjetivo Específico:";
            // 
            // cboObjetivoGeneral
            // 
            this.cboObjetivoGeneral.FormattingEnabled = true;
            this.cboObjetivoGeneral.Location = new System.Drawing.Point(142, 42);
            this.cboObjetivoGeneral.Name = "cboObjetivoGeneral";
            this.cboObjetivoGeneral.Size = new System.Drawing.Size(400, 21);
            this.cboObjetivoGeneral.TabIndex = 1;
            this.cboObjetivoGeneral.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoGeneral_SelectedIndexChanged);
            // 
            // cboSemanaObjetivo
            // 
            this.cboSemanaObjetivo.Enabled = false;
            this.cboSemanaObjetivo.FormattingEnabled = true;
            this.cboSemanaObjetivo.Location = new System.Drawing.Point(142, 65);
            this.cboSemanaObjetivo.Name = "cboSemanaObjetivo";
            this.cboSemanaObjetivo.Size = new System.Drawing.Size(400, 21);
            this.cboSemanaObjetivo.TabIndex = 2;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(109, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Objetivo General:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(16, 69);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(59, 13);
            this.lblBase5.TabIndex = 13;
            this.lblBase5.Text = "Semana:";
            // 
            // cboObjetivoResumen
            // 
            this.cboObjetivoResumen.FormattingEnabled = true;
            this.cboObjetivoResumen.Location = new System.Drawing.Point(142, 104);
            this.cboObjetivoResumen.Name = "cboObjetivoResumen";
            this.cboObjetivoResumen.Size = new System.Drawing.Size(400, 21);
            this.cboObjetivoResumen.TabIndex = 3;
            this.cboObjetivoResumen.SelectedIndexChanged += new System.EventHandler(this.cboObjetivoResumen_SelectedIndexChanged);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(16, 108);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(117, 13);
            this.lblBase6.TabIndex = 15;
            this.lblBase6.Text = "Resumen Objetivo:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboObjetivoTipo);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtpFechaEspecifica);
            this.grbBase1.Controls.Add(this.cboObjetivoResumen);
            this.grbBase1.Controls.Add(this.txtDescripcionObjetivoGeneral);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.cboSemanaObjetivo);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboObjetivoGeneral);
            this.grbBase1.Location = new System.Drawing.Point(7, 10);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(548, 228);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Objetivo Específico";
            // 
            // btnMiniDetalle
            // 
            this.btnMiniDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDetalle.BackgroundImage")));
            this.btnMiniDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDetalle.Location = new System.Drawing.Point(938, 95);
            this.btnMiniDetalle.Name = "btnMiniDetalle";
            this.btnMiniDetalle.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDetalle.TabIndex = 5;
            this.btnMiniDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDetalle.UseVisualStyleBackColor = true;
            this.btnMiniDetalle.Click += new System.EventHandler(this.btnMiniDetalle_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(16, 23);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(93, 26);
            this.lblBase7.TabIndex = 26;
            this.lblBase7.Text = "Resumen \r\nDetalle Acción:";
            // 
            // cboAccionResumen
            // 
            this.cboAccionResumen.FormattingEnabled = true;
            this.cboAccionResumen.Location = new System.Drawing.Point(142, 26);
            this.cboAccionResumen.Name = "cboAccionResumen";
            this.cboAccionResumen.Size = new System.Drawing.Size(300, 21);
            this.cboAccionResumen.TabIndex = 1;
            this.cboAccionResumen.SelectedIndexChanged += new System.EventHandler(this.cboAccionResumen_SelectedIndexChanged);
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(938, 67);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 4;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(938, 151);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 7;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(938, 123);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 6;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            this.btnMiniAgregar.Click += new System.EventHandler(this.btnMiniAgregar_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(16, 54);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(109, 13);
            this.lblBase8.TabIndex = 25;
            this.lblBase8.Text = "Clientes a Visitar:";
            // 
            // dtgDetalleAccionCliente
            // 
            this.dtgDetalleAccionCliente.AllowUserToAddRows = false;
            this.dtgDetalleAccionCliente.AllowUserToDeleteRows = false;
            this.dtgDetalleAccionCliente.AllowUserToResizeColumns = false;
            this.dtgDetalleAccionCliente.AllowUserToResizeRows = false;
            this.dtgDetalleAccionCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleAccionCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleAccionCliente.Location = new System.Drawing.Point(9, 67);
            this.dtgDetalleAccionCliente.MultiSelect = false;
            this.dtgDetalleAccionCliente.Name = "dtgDetalleAccionCliente";
            this.dtgDetalleAccionCliente.ReadOnly = true;
            this.dtgDetalleAccionCliente.RowHeadersVisible = false;
            this.dtgDetalleAccionCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleAccionCliente.Size = new System.Drawing.Size(923, 110);
            this.dtgDetalleAccionCliente.TabIndex = 8;
            this.dtgDetalleAccionCliente.Leave += new System.EventHandler(this.dtgDetalleAccionCliente_Leave);
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(459, 23);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(93, 26);
            this.lblBase9.TabIndex = 23;
            this.lblBase9.Text = "Descripción de\r\nDetalle Acción:";
            // 
            // txtDetalleAccion
            // 
            this.txtDetalleAccion.Location = new System.Drawing.Point(574, 13);
            this.txtDetalleAccion.MaxLength = 500;
            this.txtDetalleAccion.Multiline = true;
            this.txtDetalleAccion.Name = "txtDetalleAccion";
            this.txtDetalleAccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalleAccion.Size = new System.Drawing.Size(400, 45);
            this.txtDetalleAccion.TabIndex = 2;
            this.txtDetalleAccion.Leave += new System.EventHandler(this.txtDetalleAccion_Leave);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.btnMiniQuitar);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.dtgDetalleAccionCliente);
            this.grbBase2.Controls.Add(this.btnMiniDetalle);
            this.grbBase2.Controls.Add(this.cboAccionResumen);
            this.grbBase2.Controls.Add(this.btnMiniAgregar);
            this.grbBase2.Controls.Add(this.btnMiniBusq);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.txtDetalleAccion);
            this.grbBase2.Location = new System.Drawing.Point(7, 238);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(980, 183);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Detalle Acción";
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(11, 72);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(53, 13);
            this.lblBase10.TabIndex = 35;
            this.lblBase10.Text = "Distrito:";
            // 
            // cboDistrito
            // 
            this.cboDistrito.FormattingEnabled = true;
            this.cboDistrito.Location = new System.Drawing.Point(126, 69);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Size = new System.Drawing.Size(300, 21);
            this.cboDistrito.TabIndex = 3;
            this.cboDistrito.SelectedIndexChanged += new System.EventHandler(this.cboDistrito_SelectedIndexChanged);
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(126, 46);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(300, 21);
            this.cboAgencias.TabIndex = 1;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(11, 115);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(91, 26);
            this.lblBase11.TabIndex = 32;
            this.lblBase11.Text = "Descripción de\r\nla visita:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(11, 49);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(57, 13);
            this.lblBase12.TabIndex = 31;
            this.lblBase12.Text = "Agencia:";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(11, 26);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(41, 13);
            this.lblBase13.TabIndex = 30;
            this.lblBase13.Text = "Zona:";
            // 
            // txtDescripcionZonaVisita
            // 
            this.txtDescripcionZonaVisita.Location = new System.Drawing.Point(126, 92);
            this.txtDescripcionZonaVisita.MaxLength = 500;
            this.txtDescripcionZonaVisita.Multiline = true;
            this.txtDescripcionZonaVisita.Name = "txtDescripcionZonaVisita";
            this.txtDescripcionZonaVisita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcionZonaVisita.Size = new System.Drawing.Size(300, 75);
            this.txtDescripcionZonaVisita.TabIndex = 4;
            this.txtDescripcionZonaVisita.Leave += new System.EventHandler(this.txtDescripcionZonaVisita_Leave);
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(126, 23);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(300, 21);
            this.cboZona.TabIndex = 0;
            this.cboZona.SelectedIndexChanged += new System.EventHandler(this.cboZona_SelectedIndexChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.lblBase13);
            this.grbBase3.Controls.Add(this.lblBase10);
            this.grbBase3.Controls.Add(this.cboZona);
            this.grbBase3.Controls.Add(this.cboDistrito);
            this.grbBase3.Controls.Add(this.txtDescripcionZonaVisita);
            this.grbBase3.Controls.Add(this.cboAgencias);
            this.grbBase3.Controls.Add(this.lblBase12);
            this.grbBase3.Controls.Add(this.lblBase11);
            this.grbBase3.Location = new System.Drawing.Point(561, 10);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(431, 176);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Zona de Visita";
            // 
            // frmPlanTrabajoObjetivoEspecifico
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmPlanTrabajoObjetivoEspecifico";
            this.Text = "Mantenimiento Plan de Trabajo - Objetivos Específicos";
            this.Load += new System.EventHandler(this.frmPlanTrabajoObjetivoEspecifico_Load);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleAccionCliente)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.cboBase cboObjetivoTipo;
        private GEN.ControlesBase.dtpCorto dtpFechaEspecifica;
        private GEN.ControlesBase.txtBase txtDescripcionObjetivoGeneral;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboBase cboObjetivoGeneral;
        private GEN.ControlesBase.cboBase cboSemanaObjetivo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboObjetivoResumen;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnMiniDetalle btnMiniDetalle;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.cboBase cboAccionResumen;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.dtgBase dtgDetalleAccionCliente;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtDetalleAccion;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.txtBase txtDescripcionZonaVisita;
        private GEN.ControlesBase.cboZona cboZona;
        private GEN.ControlesBase.grbBase grbBase3;
    }
}