namespace RCP.Presentacion
{
    partial class frmRegistroVisita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroVisita));
            this.cboContactoRecupera1 = new GEN.ControlesBase.cboContactoRecupera(this.components);
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.cboTipoEventoRecupera1 = new GEN.ControlesBase.cboTipoEventoRecupera(this.components);
            this.cboProcesoRecupera1 = new GEN.ControlesBase.cboProcesoRecupera(this.components);
            this.cboTipoEfecto1 = new GEN.ControlesBase.cboTipoEfecto(this.components);
            this.cboMotivoRecupera1 = new GEN.ControlesBase.cboMotivoRecupera(this.components);
            this.txtTelefFijo1 = new GEN.ControlesBase.txtTelefFijo(this.components);
            this.txtTelefCel1 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.dtpProxContacto = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtObservaciones = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.dtpHoraProx = new GEN.ControlesBase.dtpCorto(this.components);
            this.chcProxContacto = new GEN.ControlesBase.chcBase(this.components);
            this.txtMontoMovilidad = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblMovilidad = new GEN.ControlesBase.lblBase();
            this.lblOrigen = new GEN.ControlesBase.lblBase();
            this.txtOrigen = new GEN.ControlesBase.txtBase(this.components);
            this.lblDestino = new GEN.ControlesBase.lblBase();
            this.txtDestino = new GEN.ControlesBase.txtBase(this.components);
            this.cboTipoRespuestaRecuperacion1 = new GEN.ControlesBase.cboTipoRespuestaRecuperacion(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboContactoRecupera1
            // 
            this.cboContactoRecupera1.DropDownWidth = 180;
            this.cboContactoRecupera1.Enabled = false;
            this.cboContactoRecupera1.FormattingEnabled = true;
            this.cboContactoRecupera1.Location = new System.Drawing.Point(422, 156);
            this.cboContactoRecupera1.Name = "cboContactoRecupera1";
            this.cboContactoRecupera1.Size = new System.Drawing.Size(170, 21);
            this.cboContactoRecupera1.TabIndex = 4;
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(12, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(586, 522);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 19;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(454, 522);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 17;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(520, 522);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 18;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // cboTipoEventoRecupera1
            // 
            this.cboTipoEventoRecupera1.Enabled = false;
            this.cboTipoEventoRecupera1.FormattingEnabled = true;
            this.cboTipoEventoRecupera1.Location = new System.Drawing.Point(129, 156);
            this.cboTipoEventoRecupera1.Name = "cboTipoEventoRecupera1";
            this.cboTipoEventoRecupera1.Size = new System.Drawing.Size(170, 21);
            this.cboTipoEventoRecupera1.TabIndex = 3;
            this.cboTipoEventoRecupera1.SelectedIndexChanged += new System.EventHandler(this.cboTipoEventoRecupera1_SelectedIndexChanged);
            // 
            // cboProcesoRecupera1
            // 
            this.cboProcesoRecupera1.Enabled = false;
            this.cboProcesoRecupera1.FormattingEnabled = true;
            this.cboProcesoRecupera1.Location = new System.Drawing.Point(129, 129);
            this.cboProcesoRecupera1.Name = "cboProcesoRecupera1";
            this.cboProcesoRecupera1.Size = new System.Drawing.Size(170, 21);
            this.cboProcesoRecupera1.TabIndex = 1;
            // 
            // cboTipoEfecto1
            // 
            this.cboTipoEfecto1.DropDownWidth = 180;
            this.cboTipoEfecto1.Enabled = false;
            this.cboTipoEfecto1.FormattingEnabled = true;
            this.cboTipoEfecto1.Location = new System.Drawing.Point(129, 184);
            this.cboTipoEfecto1.Name = "cboTipoEfecto1";
            this.cboTipoEfecto1.Size = new System.Drawing.Size(169, 21);
            this.cboTipoEfecto1.TabIndex = 5;
            // 
            // cboMotivoRecupera1
            // 
            this.cboMotivoRecupera1.DropDownWidth = 180;
            this.cboMotivoRecupera1.Enabled = false;
            this.cboMotivoRecupera1.FormattingEnabled = true;
            this.cboMotivoRecupera1.Location = new System.Drawing.Point(422, 129);
            this.cboMotivoRecupera1.Name = "cboMotivoRecupera1";
            this.cboMotivoRecupera1.Size = new System.Drawing.Size(170, 21);
            this.cboMotivoRecupera1.TabIndex = 2;
            // 
            // txtTelefFijo1
            // 
            this.txtTelefFijo1.Enabled = false;
            this.txtTelefFijo1.Location = new System.Drawing.Point(421, 183);
            this.txtTelefFijo1.MaxLength = 9;
            this.txtTelefFijo1.Name = "txtTelefFijo1";
            this.txtTelefFijo1.Size = new System.Drawing.Size(171, 20);
            this.txtTelefFijo1.TabIndex = 6;
            // 
            // txtTelefCel1
            // 
            this.txtTelefCel1.Enabled = false;
            this.txtTelefCel1.Location = new System.Drawing.Point(129, 211);
            this.txtTelefCel1.MaxLength = 9;
            this.txtTelefCel1.Name = "txtTelefCel1";
            this.txtTelefCel1.Size = new System.Drawing.Size(169, 20);
            this.txtTelefCel1.TabIndex = 7;
            // 
            // dtpProxContacto
            // 
            this.dtpProxContacto.Enabled = false;
            this.dtpProxContacto.Location = new System.Drawing.Point(421, 238);
            this.dtpProxContacto.Name = "dtpProxContacto";
            this.dtpProxContacto.Size = new System.Drawing.Size(121, 20);
            this.dtpProxContacto.TabIndex = 9;
            this.dtpProxContacto.ValueChanged += new System.EventHandler(this.dtpProxContacto_ValueChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Enabled = false;
            this.txtObservaciones.Location = new System.Drawing.Point(114, 467);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(532, 50);
            this.txtObservaciones.TabIndex = 15;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(12, 129);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(39, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Área:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 159);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 16;
            this.lblBase2.Text = "Acción realizada:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 186);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(68, 13);
            this.lblBase3.TabIndex = 16;
            this.lblBase3.Text = "Resultado:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(337, 159);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(63, 13);
            this.lblBase4.TabIndex = 16;
            this.lblBase4.Text = "Contacto:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(351, 132);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(49, 13);
            this.lblBase5.TabIndex = 16;
            this.lblBase5.Text = "Motivo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(318, 186);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(82, 13);
            this.lblBase6.TabIndex = 16;
            this.lblBase6.Text = "Teléfono fijo:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 214);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(95, 13);
            this.lblBase7.TabIndex = 16;
            this.lblBase7.Text = "Teléfono móvil:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(304, 217);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(190, 13);
            this.lblBase8.TabIndex = 16;
            this.lblBase8.Text = "Fecha de Compromiso de Pago:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(12, 470);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(96, 13);
            this.lblBase9.TabIndex = 16;
            this.lblBase9.Text = "Observaciones:";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(388, 522);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 16;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Enabled = false;
            this.dtgCreditos.Location = new System.Drawing.Point(13, 333);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(633, 119);
            this.dtgCreditos.TabIndex = 14;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(12, 317);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(113, 13);
            this.lblBase10.TabIndex = 16;
            this.lblBase10.Text = "Crédito Vinculado:";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(355, 244);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(45, 13);
            this.lblBase11.TabIndex = 16;
            this.lblBase11.Text = "Fecha:";
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(361, 270);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(39, 13);
            this.lblBase12.TabIndex = 16;
            this.lblBase12.Text = "Hora:";
            // 
            // dtpHoraProx
            // 
            this.dtpHoraProx.CustomFormat = "hh:mm tt";
            this.dtpHoraProx.Enabled = false;
            this.dtpHoraProx.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraProx.Location = new System.Drawing.Point(421, 264);
            this.dtpHoraProx.Name = "dtpHoraProx";
            this.dtpHoraProx.ShowUpDown = true;
            this.dtpHoraProx.Size = new System.Drawing.Size(121, 20);
            this.dtpHoraProx.TabIndex = 10;
            // 
            // chcProxContacto
            // 
            this.chcProxContacto.AutoSize = true;
            this.chcProxContacto.Checked = true;
            this.chcProxContacto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcProxContacto.Enabled = false;
            this.chcProxContacto.Location = new System.Drawing.Point(529, 217);
            this.chcProxContacto.Name = "chcProxContacto";
            this.chcProxContacto.Size = new System.Drawing.Size(15, 14);
            this.chcProxContacto.TabIndex = 8;
            this.chcProxContacto.UseVisualStyleBackColor = true;
            this.chcProxContacto.CheckedChanged += new System.EventHandler(this.chcProxContacto_CheckedChanged);
            // 
            // txtMontoMovilidad
            // 
            this.txtMontoMovilidad.Enabled = false;
            this.txtMontoMovilidad.FormatoDecimal = false;
            this.txtMontoMovilidad.Location = new System.Drawing.Point(129, 238);
            this.txtMontoMovilidad.MaxLength = 8;
            this.txtMontoMovilidad.Name = "txtMontoMovilidad";
            this.txtMontoMovilidad.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoMovilidad.nNumDecimales = 2;
            this.txtMontoMovilidad.nvalor = 0D;
            this.txtMontoMovilidad.Size = new System.Drawing.Size(169, 20);
            this.txtMontoMovilidad.TabIndex = 11;
            this.txtMontoMovilidad.Text = "0.00";
            this.txtMontoMovilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMovilidad
            // 
            this.lblMovilidad.AutoSize = true;
            this.lblMovilidad.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMovilidad.ForeColor = System.Drawing.Color.Navy;
            this.lblMovilidad.Location = new System.Drawing.Point(12, 241);
            this.lblMovilidad.Name = "lblMovilidad";
            this.lblMovilidad.Size = new System.Drawing.Size(113, 13);
            this.lblMovilidad.TabIndex = 16;
            this.lblMovilidad.Text = "Movilidad(Pasaje):";
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblOrigen.ForeColor = System.Drawing.Color.Navy;
            this.lblOrigen.Location = new System.Drawing.Point(12, 267);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(50, 13);
            this.lblOrigen.TabIndex = 16;
            this.lblOrigen.Text = "Origen:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Enabled = false;
            this.txtOrigen.Location = new System.Drawing.Point(129, 264);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(169, 20);
            this.txtOrigen.TabIndex = 12;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblDestino.ForeColor = System.Drawing.Color.Navy;
            this.lblDestino.Location = new System.Drawing.Point(12, 293);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(55, 13);
            this.lblDestino.TabIndex = 16;
            this.lblDestino.Text = "Destino:";
            // 
            // txtDestino
            // 
            this.txtDestino.Enabled = false;
            this.txtDestino.Location = new System.Drawing.Point(129, 290);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(170, 20);
            this.txtDestino.TabIndex = 13;
            // 
            // cboTipoRespuestaRecuperacion1
            // 
            this.cboTipoRespuestaRecuperacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRespuestaRecuperacion1.FormattingEnabled = true;
            this.cboTipoRespuestaRecuperacion1.Location = new System.Drawing.Point(421, 289);
            this.cboTipoRespuestaRecuperacion1.Name = "cboTipoRespuestaRecuperacion1";
            this.cboTipoRespuestaRecuperacion1.Size = new System.Drawing.Size(171, 21);
            this.cboTipoRespuestaRecuperacion1.TabIndex = 20;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(329, 292);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(71, 13);
            this.lblBase13.TabIndex = 21;
            this.lblBase13.Text = "Respuesta:";
            // 
            // frmRegistroVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 600);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.cboTipoRespuestaRecuperacion1);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.txtMontoMovilidad);
            this.Controls.Add(this.chcProxContacto);
            this.Controls.Add(this.dtgCreditos);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.lblMovilidad);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtTelefCel1);
            this.Controls.Add(this.txtTelefFijo1);
            this.Controls.Add(this.dtpHoraProx);
            this.Controls.Add(this.dtpProxContacto);
            this.Controls.Add(this.cboMotivoRecupera1);
            this.Controls.Add(this.cboTipoEfecto1);
            this.Controls.Add(this.cboProcesoRecupera1);
            this.Controls.Add(this.cboTipoEventoRecupera1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.cboContactoRecupera1);
            this.Name = "frmRegistroVisita";
            this.Text = "Registro de Contacto a Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.cboContactoRecupera1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.cboTipoEventoRecupera1, 0);
            this.Controls.SetChildIndex(this.cboProcesoRecupera1, 0);
            this.Controls.SetChildIndex(this.cboTipoEfecto1, 0);
            this.Controls.SetChildIndex(this.cboMotivoRecupera1, 0);
            this.Controls.SetChildIndex(this.dtpProxContacto, 0);
            this.Controls.SetChildIndex(this.dtpHoraProx, 0);
            this.Controls.SetChildIndex(this.txtTelefFijo1, 0);
            this.Controls.SetChildIndex(this.txtTelefCel1, 0);
            this.Controls.SetChildIndex(this.txtObservaciones, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblMovilidad, 0);
            this.Controls.SetChildIndex(this.lblOrigen, 0);
            this.Controls.SetChildIndex(this.lblDestino, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.dtgCreditos, 0);
            this.Controls.SetChildIndex(this.chcProxContacto, 0);
            this.Controls.SetChildIndex(this.txtMontoMovilidad, 0);
            this.Controls.SetChildIndex(this.txtOrigen, 0);
            this.Controls.SetChildIndex(this.txtDestino, 0);
            this.Controls.SetChildIndex(this.cboTipoRespuestaRecuperacion1, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboContactoRecupera cboContactoRecupera1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboTipoEventoRecupera cboTipoEventoRecupera1;
        private GEN.ControlesBase.cboProcesoRecupera cboProcesoRecupera1;
        private GEN.ControlesBase.cboTipoEfecto cboTipoEfecto1;
        private GEN.ControlesBase.cboMotivoRecupera cboMotivoRecupera1;
        private GEN.ControlesBase.txtTelefFijo txtTelefFijo1;
        private GEN.ControlesBase.txtTelefCel txtTelefCel1;
        private GEN.ControlesBase.dtpCorto dtpProxContacto;
        private GEN.ControlesBase.txtBase txtObservaciones;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.dtpCorto dtpHoraProx;
        private GEN.ControlesBase.chcBase chcProxContacto;
        private GEN.ControlesBase.txtNumRea txtMontoMovilidad;
        private GEN.ControlesBase.lblBase lblMovilidad;
        private GEN.ControlesBase.lblBase lblOrigen;
        private GEN.ControlesBase.txtBase txtOrigen;
        private GEN.ControlesBase.lblBase lblDestino;
        private GEN.ControlesBase.txtBase txtDestino;
        private GEN.ControlesBase.cboTipoRespuestaRecuperacion cboTipoRespuestaRecuperacion1;
        private GEN.ControlesBase.lblBase lblBase13;
    }
}

