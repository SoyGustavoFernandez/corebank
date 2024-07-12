namespace GRC.Presentacion
{
    partial class frmRegistroConsejo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroConsejo));
            this.cboTipoConsejo1 = new GEN.ControlesBase.cboTipoConsejo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgIntegrantes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgConsejos = new GEN.ControlesBase.dtgBase(this.components);
            this.txtConsejo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.rbtActivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.rbtnInactivo = new GEN.ControlesBase.rbtnBase(this.components);
            this.grbDatosIntegrante = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.txtCodInst = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodAge = new GEN.ControlesBase.txtBase(this.components);
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.txtCodCli = new GEN.ControlesBase.txtBase(this.components);
            this.txtNroDoc = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboTipoIntegranteConsejo1 = new GEN.ControlesBase.cboTipoIntegranteConsejo(this.components);
            this.btnAgregar1 = new GEN.BotonesBase.btnAgregar();
            this.btnQuitar1 = new GEN.BotonesBase.btnQuitar();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnSalir2 = new GEN.BotonesBase.btnSalir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsejos)).BeginInit();
            this.grbDatosIntegrante.SuspendLayout();
            this.conBusCli1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTipoConsejo1
            // 
            this.cboTipoConsejo1.DropDownWidth = 180;
            this.cboTipoConsejo1.Enabled = false;
            this.cboTipoConsejo1.FormattingEnabled = true;
            this.cboTipoConsejo1.Location = new System.Drawing.Point(165, 120);
            this.cboTipoConsejo1.Name = "cboTipoConsejo1";
            this.cboTipoConsejo1.Size = new System.Drawing.Size(198, 21);
            this.cboTipoConsejo1.TabIndex = 2;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 123);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(155, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Tipo de Organo Directivo:";
            // 
            // dtgIntegrantes
            // 
            this.dtgIntegrantes.AllowUserToAddRows = false;
            this.dtgIntegrantes.AllowUserToDeleteRows = false;
            this.dtgIntegrantes.AllowUserToResizeColumns = false;
            this.dtgIntegrantes.AllowUserToResizeRows = false;
            this.dtgIntegrantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantes.Location = new System.Drawing.Point(12, 212);
            this.dtgIntegrantes.MultiSelect = false;
            this.dtgIntegrantes.Name = "dtgIntegrantes";
            this.dtgIntegrantes.ReadOnly = true;
            this.dtgIntegrantes.RowHeadersVisible = false;
            this.dtgIntegrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantes.Size = new System.Drawing.Size(549, 138);
            this.dtgIntegrantes.TabIndex = 6;
            this.dtgIntegrantes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgIntegrantes_CellMouseClick);
            this.dtgIntegrantes.SelectionChanged += new System.EventHandler(this.dtgIntegrantes_SelectionChanged);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(237, 565);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 9;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(303, 565);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 10;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(435, 565);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 11;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(369, 565);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 12;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgConsejos
            // 
            this.dtgConsejos.AllowUserToAddRows = false;
            this.dtgConsejos.AllowUserToDeleteRows = false;
            this.dtgConsejos.AllowUserToResizeColumns = false;
            this.dtgConsejos.AllowUserToResizeRows = false;
            this.dtgConsejos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgConsejos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConsejos.Location = new System.Drawing.Point(12, 12);
            this.dtgConsejos.MultiSelect = false;
            this.dtgConsejos.Name = "dtgConsejos";
            this.dtgConsejos.ReadOnly = true;
            this.dtgConsejos.RowHeadersVisible = false;
            this.dtgConsejos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConsejos.Size = new System.Drawing.Size(549, 103);
            this.dtgConsejos.TabIndex = 14;
            this.dtgConsejos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgConsejos_CellMouseClick);
            this.dtgConsejos.SelectionChanged += new System.EventHandler(this.dtgConsejos_SelectionChanged);
            // 
            // txtConsejo
            // 
            this.txtConsejo.Enabled = false;
            this.txtConsejo.Location = new System.Drawing.Point(165, 144);
            this.txtConsejo.Name = "txtConsejo";
            this.txtConsejo.Size = new System.Drawing.Size(396, 20);
            this.txtConsejo.TabIndex = 15;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 147);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(59, 13);
            this.lblBase3.TabIndex = 4;
            this.lblBase3.Text = "Consejo:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 172);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(50, 13);
            this.lblBase4.TabIndex = 18;
            this.lblBase4.Text = "Estado:";
            // 
            // rbtActivo
            // 
            this.rbtActivo.AutoSize = true;
            this.rbtActivo.Enabled = false;
            this.rbtActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtActivo.Location = new System.Drawing.Point(165, 170);
            this.rbtActivo.Name = "rbtActivo";
            this.rbtActivo.Size = new System.Drawing.Size(55, 17);
            this.rbtActivo.TabIndex = 16;
            this.rbtActivo.TabStop = true;
            this.rbtActivo.Text = "Activo";
            this.rbtActivo.UseVisualStyleBackColor = true;
            // 
            // rbtnInactivo
            // 
            this.rbtnInactivo.AutoSize = true;
            this.rbtnInactivo.Enabled = false;
            this.rbtnInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnInactivo.Location = new System.Drawing.Point(223, 170);
            this.rbtnInactivo.Name = "rbtnInactivo";
            this.rbtnInactivo.Size = new System.Drawing.Size(63, 17);
            this.rbtnInactivo.TabIndex = 17;
            this.rbtnInactivo.TabStop = true;
            this.rbtnInactivo.Text = "Inactivo";
            this.rbtnInactivo.UseVisualStyleBackColor = true;
            // 
            // grbDatosIntegrante
            // 
            this.grbDatosIntegrante.Controls.Add(this.lblBase7);
            this.grbDatosIntegrante.Controls.Add(this.lblBase6);
            this.grbDatosIntegrante.Controls.Add(this.lblBase5);
            this.grbDatosIntegrante.Controls.Add(this.conBusCli1);
            this.grbDatosIntegrante.Controls.Add(this.dtpFecFin);
            this.grbDatosIntegrante.Controls.Add(this.dtpFecIni);
            this.grbDatosIntegrante.Controls.Add(this.cboTipoIntegranteConsejo1);
            this.grbDatosIntegrante.Controls.Add(this.btnAgregar1);
            this.grbDatosIntegrante.Controls.Add(this.btnQuitar1);
            this.grbDatosIntegrante.Controls.Add(this.txtNombre);
            this.grbDatosIntegrante.Enabled = false;
            this.grbDatosIntegrante.Location = new System.Drawing.Point(12, 354);
            this.grbDatosIntegrante.Name = "grbDatosIntegrante";
            this.grbDatosIntegrante.Size = new System.Drawing.Size(549, 185);
            this.grbDatosIntegrante.TabIndex = 20;
            this.grbDatosIntegrante.TabStop = false;
            this.grbDatosIntegrante.Text = "Datos Integrante";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(18, 159);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(93, 13);
            this.lblBase7.TabIndex = 31;
            this.lblBase7.Text = "Fin de Periodo:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(18, 135);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 30;
            this.lblBase6.Text = "Inicio de Periodo:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(18, 108);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(100, 13);
            this.lblBase5.TabIndex = 29;
            this.lblBase5.Text = "Tipo Integrante:";
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.Controls.Add(this.txtCodInst);
            this.conBusCli1.Controls.Add(this.txtCodAge);
            this.conBusCli1.Controls.Add(this.txtDireccion);
            this.conBusCli1.Controls.Add(this.txtCodCli);
            this.conBusCli1.Controls.Add(this.txtNroDoc);
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(8, 19);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 80);
            this.conBusCli1.TabIndex = 28;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // txtCodInst
            // 
            this.txtCodInst.Enabled = false;
            this.txtCodInst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodInst.Location = new System.Drawing.Point(161, 8);
            this.txtCodInst.Name = "txtCodInst";
            this.txtCodInst.Size = new System.Drawing.Size(27, 20);
            this.txtCodInst.TabIndex = 13;
            // 
            // txtCodAge
            // 
            this.txtCodAge.Enabled = false;
            this.txtCodAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodAge.Location = new System.Drawing.Point(186, 8);
            this.txtCodAge.Name = "txtCodAge";
            this.txtCodAge.Size = new System.Drawing.Size(27, 20);
            this.txtCodAge.TabIndex = 12;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(161, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(357, 20);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtCodCli
            // 
            this.txtCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCli.Location = new System.Drawing.Point(211, 8);
            this.txtCodCli.MaxLength = 7;
            this.txtCodCli.Name = "txtCodCli";
            this.txtCodCli.Size = new System.Drawing.Size(130, 20);
            this.txtCodCli.TabIndex = 1;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDoc.Location = new System.Drawing.Point(161, 31);
            this.txtNroDoc.MaxLength = 15;
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(180, 20);
            this.txtNroDoc.TabIndex = 5;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(171, 153);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFecFin.TabIndex = 27;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(171, 129);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(121, 20);
            this.dtpFecIni.TabIndex = 26;
            // 
            // cboTipoIntegranteConsejo1
            // 
            this.cboTipoIntegranteConsejo1.FormattingEnabled = true;
            this.cboTipoIntegranteConsejo1.Location = new System.Drawing.Point(171, 105);
            this.cboTipoIntegranteConsejo1.Name = "cboTipoIntegranteConsejo1";
            this.cboTipoIntegranteConsejo1.Size = new System.Drawing.Size(121, 21);
            this.cboTipoIntegranteConsejo1.TabIndex = 25;
            // 
            // btnAgregar1
            // 
            this.btnAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar1.BackgroundImage")));
            this.btnAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar1.Location = new System.Drawing.Point(412, 122);
            this.btnAgregar1.Name = "btnAgregar1";
            this.btnAgregar1.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar1.TabIndex = 24;
            this.btnAgregar1.Text = "&Agregar";
            this.btnAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar1.UseVisualStyleBackColor = true;
            this.btnAgregar1.Click += new System.EventHandler(this.btnAgregar1_Click);
            // 
            // btnQuitar1
            // 
            this.btnQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitar1.BackgroundImage")));
            this.btnQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitar1.Location = new System.Drawing.Point(478, 122);
            this.btnQuitar1.Name = "btnQuitar1";
            this.btnQuitar1.Size = new System.Drawing.Size(60, 50);
            this.btnQuitar1.TabIndex = 23;
            this.btnQuitar1.Text = "&Quitar";
            this.btnQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitar1.UseVisualStyleBackColor = true;
            this.btnQuitar1.Click += new System.EventHandler(this.btnQuitar1_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(183, 79);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(357, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 196);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(78, 13);
            this.lblBase2.TabIndex = 21;
            this.lblBase2.Text = "Integrantes:";
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir2.BackgroundImage")));
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir2.Location = new System.Drawing.Point(501, 565);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(60, 50);
            this.btnSalir2.TabIndex = 22;
            this.btnSalir2.Text = "&Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // frmRegistroConsejo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 641);
            this.Controls.Add(this.btnSalir2);
            this.Controls.Add(this.grbDatosIntegrante);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.rbtActivo);
            this.Controls.Add(this.rbtnInactivo);
            this.Controls.Add(this.txtConsejo);
            this.Controls.Add(this.dtgConsejos);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.dtgIntegrantes);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboTipoConsejo1);
            this.Name = "frmRegistroConsejo";
            this.Text = " Registro de Organo Directivo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.cboTipoConsejo1, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtgIntegrantes, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgConsejos, 0);
            this.Controls.SetChildIndex(this.txtConsejo, 0);
            this.Controls.SetChildIndex(this.rbtnInactivo, 0);
            this.Controls.SetChildIndex(this.rbtActivo, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.grbDatosIntegrante, 0);
            this.Controls.SetChildIndex(this.btnSalir2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConsejos)).EndInit();
            this.grbDatosIntegrante.ResumeLayout(false);
            this.grbDatosIntegrante.PerformLayout();
            this.conBusCli1.ResumeLayout(false);
            this.conBusCli1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.cboTipoConsejo cboTipoConsejo1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgIntegrantes;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtgBase dtgConsejos;
        private GEN.ControlesBase.txtBase txtConsejo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.rbtnBase rbtActivo;
        private GEN.ControlesBase.rbtnBase rbtnInactivo;
        private GEN.ControlesBase.grbBase grbDatosIntegrante;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.txtBase txtCodInst;
        private GEN.ControlesBase.txtBase txtCodAge;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtBase txtCodCli;
        private GEN.ControlesBase.txtBase txtNroDoc;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.cboTipoIntegranteConsejo cboTipoIntegranteConsejo1;
        private GEN.BotonesBase.btnAgregar btnAgregar1;
        private GEN.BotonesBase.btnQuitar btnQuitar1;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnSalir btnSalir2;
    }
}

