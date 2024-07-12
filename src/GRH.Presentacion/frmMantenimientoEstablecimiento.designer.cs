namespace GRH.Presentacion
{
    partial class frmMantenimientoEstablecimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoEstablecimiento));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcAutBioComite = new GEN.ControlesBase.chcBase(this.components);
            this.chcVerificacionSMS = new GEN.ControlesBase.chcBase(this.components);
            this.chcAutBio = new GEN.ControlesBase.chcBase(this.components);
            this.cboTipoEstablecimiento = new GEN.ControlesBase.cboTipoEstablecimiento(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.CBCentroRiesgo = new GEN.ControlesBase.chcBase(this.components);
            this.txtTelefono = new GEN.ControlesBase.txtTelefCel(this.components);
            this.txtCodSUNAT = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.CBVigente = new GEN.ControlesBase.chcBase(this.components);
            this.txtReferencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtNomEstablecimiento = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conUbigeoDir = new GEN.ControlesBase.ConBusUbig();
            this.cboAnexo = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDepartamento = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboPais = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtgEstablecimiento = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1.SuspendLayout();
            this.conUbigeoDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstablecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcAutBioComite);
            this.grbBase1.Controls.Add(this.chcVerificacionSMS);
            this.grbBase1.Controls.Add(this.chcAutBio);
            this.grbBase1.Controls.Add(this.cboTipoEstablecimiento);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.CBCentroRiesgo);
            this.grbBase1.Controls.Add(this.txtTelefono);
            this.grbBase1.Controls.Add(this.txtCodSUNAT);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.CBVigente);
            this.grbBase1.Controls.Add(this.txtReferencia);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.txtNomEstablecimiento);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.conUbigeoDir);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.txtDireccion);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(19, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(547, 245);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Establecimiento";
            // 
            // chcAutBioComite
            // 
            this.chcAutBioComite.AutoSize = true;
            this.chcAutBioComite.Location = new System.Drawing.Point(273, 207);
            this.chcAutBioComite.Name = "chcAutBioComite";
            this.chcAutBioComite.Size = new System.Drawing.Size(178, 17);
            this.chcAutBioComite.TabIndex = 16;
            this.chcAutBioComite.Text = "Autenticación Biométrica Comité";
            this.chcAutBioComite.UseVisualStyleBackColor = true;
            // 
            // chcVerificacionSMS
            // 
            this.chcVerificacionSMS.AutoSize = true;
            this.chcVerificacionSMS.Location = new System.Drawing.Point(273, 228);
            this.chcVerificacionSMS.Name = "chcVerificacionSMS";
            this.chcVerificacionSMS.Size = new System.Drawing.Size(128, 17);
            this.chcVerificacionSMS.TabIndex = 15;
            this.chcVerificacionSMS.Text = "Verificación con SMS";
            this.chcVerificacionSMS.UseVisualStyleBackColor = true;
            // 
            // chcAutBio
            // 
            this.chcAutBio.AutoSize = true;
            this.chcAutBio.Location = new System.Drawing.Point(273, 187);
            this.chcAutBio.Name = "chcAutBio";
            this.chcAutBio.Size = new System.Drawing.Size(143, 17);
            this.chcAutBio.TabIndex = 14;
            this.chcAutBio.Text = "Autenticación Biométrica";
            this.chcAutBio.UseVisualStyleBackColor = true;
            // 
            // cboTipoEstablecimiento
            // 
            this.cboTipoEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEstablecimiento.DropDownWidth = 150;
            this.cboTipoEstablecimiento.FormattingEnabled = true;
            this.cboTipoEstablecimiento.Location = new System.Drawing.Point(117, 87);
            this.cboTipoEstablecimiento.Name = "cboTipoEstablecimiento";
            this.cboTipoEstablecimiento.Size = new System.Drawing.Size(158, 21);
            this.cboTipoEstablecimiento.TabIndex = 13;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(17, 91);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(40, 13);
            this.lblBase4.TabIndex = 12;
            this.lblBase4.Text = "Tipo :";
            // 
            // CBCentroRiesgo
            // 
            this.CBCentroRiesgo.AutoSize = true;
            this.CBCentroRiesgo.ForeColor = System.Drawing.Color.Navy;
            this.CBCentroRiesgo.Location = new System.Drawing.Point(273, 162);
            this.CBCentroRiesgo.Name = "CBCentroRiesgo";
            this.CBCentroRiesgo.Size = new System.Drawing.Size(108, 17);
            this.CBCentroRiesgo.TabIndex = 11;
            this.CBCentroRiesgo.Text = "Centro de Riesgo";
            this.CBCentroRiesgo.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Location = new System.Drawing.Point(366, 109);
            this.txtTelefono.MaxLength = 30;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(112, 20);
            this.txtTelefono.TabIndex = 4;
            // 
            // txtCodSUNAT
            // 
            this.txtCodSUNAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodSUNAT.Location = new System.Drawing.Point(366, 135);
            this.txtCodSUNAT.MaxLength = 4;
            this.txtCodSUNAT.Name = "txtCodSUNAT";
            this.txtCodSUNAT.Size = new System.Drawing.Size(112, 20);
            this.txtCodSUNAT.TabIndex = 5;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(270, 138);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(93, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Código SUNAT:";
            // 
            // CBVigente
            // 
            this.CBVigente.AutoSize = true;
            this.CBVigente.ForeColor = System.Drawing.Color.Navy;
            this.CBVigente.Location = new System.Drawing.Point(416, 187);
            this.CBVigente.Name = "CBVigente";
            this.CBVigente.Size = new System.Drawing.Size(62, 17);
            this.CBVigente.TabIndex = 6;
            this.CBVigente.Text = "Vigente";
            this.CBVigente.UseVisualStyleBackColor = true;
            // 
            // txtReferencia
            // 
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencia.Location = new System.Drawing.Point(117, 65);
            this.txtReferencia.MaxLength = 120;
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(424, 20);
            this.txtReferencia.TabIndex = 2;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(270, 113);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(60, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Teléfono:";
            // 
            // txtNomEstablecimiento
            // 
            this.txtNomEstablecimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomEstablecimiento.Location = new System.Drawing.Point(117, 21);
            this.txtNomEstablecimiento.MaxLength = 60;
            this.txtNomEstablecimiento.Name = "txtNomEstablecimiento";
            this.txtNomEstablecimiento.Size = new System.Drawing.Size(424, 20);
            this.txtNomEstablecimiento.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Nombre:";
            // 
            // conUbigeoDir
            // 
            this.conUbigeoDir.BackColor = System.Drawing.Color.Transparent;
            this.conUbigeoDir.Controls.Add(this.cboAnexo);
            this.conUbigeoDir.Controls.Add(this.cboDistrito);
            this.conUbigeoDir.Controls.Add(this.cboProvincia);
            this.conUbigeoDir.Controls.Add(this.cboDepartamento);
            this.conUbigeoDir.Controls.Add(this.cboPais);
            this.conUbigeoDir.Location = new System.Drawing.Point(14, 104);
            this.conUbigeoDir.Name = "conUbigeoDir";
            this.conUbigeoDir.nIdNodo = 0;
            this.conUbigeoDir.Size = new System.Drawing.Size(232, 106);
            this.conUbigeoDir.TabIndex = 3;
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
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(17, 47);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(65, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Dirección:";
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(17, 69);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(73, 13);
            this.lblBase9.TabIndex = 8;
            this.lblBase9.Text = "Referencia:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Location = new System.Drawing.Point(117, 43);
            this.txtDireccion.MaxLength = 120;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(424, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(446, 461);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(326, 461);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(386, 461);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Location = new System.Drawing.Point(266, 461);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(506, 461);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtgEstablecimiento
            // 
            this.dtgEstablecimiento.AllowUserToAddRows = false;
            this.dtgEstablecimiento.AllowUserToDeleteRows = false;
            this.dtgEstablecimiento.AllowUserToResizeColumns = false;
            this.dtgEstablecimiento.AllowUserToResizeRows = false;
            this.dtgEstablecimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEstablecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstablecimiento.Location = new System.Drawing.Point(19, 263);
            this.dtgEstablecimiento.MultiSelect = false;
            this.dtgEstablecimiento.Name = "dtgEstablecimiento";
            this.dtgEstablecimiento.ReadOnly = true;
            this.dtgEstablecimiento.RowHeadersVisible = false;
            this.dtgEstablecimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEstablecimiento.Size = new System.Drawing.Size(547, 192);
            this.dtgEstablecimiento.TabIndex = 2;
            this.dtgEstablecimiento.SelectionChanged += new System.EventHandler(this.dtgEstablecimiento_SelectionChanged);
            // 
            // frmMantenimientoEstablecimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 547);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgEstablecimiento);
            this.Name = "frmMantenimientoEstablecimiento";
            this.Text = "Mantenimiento de Establecimientos";
            this.Load += new System.EventHandler(this.frmMantenimientoEstablecimiento_Load);
            this.Controls.SetChildIndex(this.dtgEstablecimiento, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.conUbigeoDir.ResumeLayout(false);
            this.conUbigeoDir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstablecimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase CBVigente;
        private GEN.ControlesBase.txtCBLetra txtNomEstablecimiento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtBase txtReferencia;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.ConBusUbig conUbigeoDir;
        private GEN.ControlesBase.cboUbigeo cboAnexo;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.cboUbigeo cboDepartamento;
        private GEN.ControlesBase.cboUbigeo cboPais;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.txtCBLetra txtCodSUNAT;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtTelefCel txtTelefono;
        private GEN.ControlesBase.chcBase CBCentroRiesgo;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboTipoEstablecimiento cboTipoEstablecimiento;
        private GEN.ControlesBase.chcBase chcAutBio;
        private GEN.ControlesBase.chcBase chcVerificacionSMS;
        private GEN.ControlesBase.dtgBase dtgEstablecimiento;
        private GEN.ControlesBase.chcBase chcAutBioComite;
    }
}