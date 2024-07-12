namespace RCP.Presentacion
{
    partial class frmDireccionRecupera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDireccionRecupera));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTelefCel1 = new GEN.ControlesBase.txtTelefCel(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtTelefFijo1 = new GEN.ControlesBase.txtTelefFijo(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtgDireccion = new System.Windows.Forms.DataGridView();
            this.txtVia = new GEN.ControlesBase.txtCBLetra(this.components);
            this.txtZona = new GEN.ControlesBase.txtCBLetra(this.components);
            this.conBusUbiCli = new GEN.ControlesBase.ConBusUbig();
            this.cboAnexo = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDistrito = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboProvincia = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboDepartamento = new GEN.ControlesBase.cboUbigeo(this.components);
            this.cboPais = new GEN.ControlesBase.cboUbigeo(this.components);
            this.lblBase56 = new GEN.ControlesBase.lblBase();
            this.txtOtrosVivienda = new GEN.ControlesBase.txtCBLetra(this.components);
            this.cboTipVivienda = new GEN.ControlesBase.cboTipVivienda(this.components);
            this.txtPropVivienda = new GEN.ControlesBase.txtCBLetra(this.components);
            this.lblBase55 = new GEN.ControlesBase.lblBase();
            this.lblBase54 = new GEN.ControlesBase.lblBase();
            this.textLote = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.textKm = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.textNro = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboTipoZona = new GEN.ControlesBase.cboTipoZona(this.components);
            this.cboTipoVia = new GEN.ControlesBase.cboTipoVia(this.components);
            this.textMz = new System.Windows.Forms.TextBox();
            this.lblBase52 = new GEN.ControlesBase.lblBase();
            this.lblBase53 = new GEN.ControlesBase.lblBase();
            this.textInt = new System.Windows.Forms.TextBox();
            this.textDpto = new System.Windows.Forms.TextBox();
            this.lblBase50 = new GEN.ControlesBase.lblBase();
            this.lblBase51 = new GEN.ControlesBase.lblBase();
            this.lblBase48 = new GEN.ControlesBase.lblBase();
            this.lblBase49 = new GEN.ControlesBase.lblBase();
            this.lblBase27 = new GEN.ControlesBase.lblBase();
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.lblBase33 = new GEN.ControlesBase.lblBase();
            this.btnAgregar = new GEN.BotonesBase.btnAgregar();
            this.lblBase47 = new GEN.ControlesBase.lblBase();
            this.txtReferencia = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase29 = new GEN.ControlesBase.lblBase();
            this.txtDireccion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDireccion)).BeginInit();
            this.conBusUbiCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(564, 570);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
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
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(498, 570);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 4;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(432, 570);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 3;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grbBase2.Controls.Add(this.txtTelefCel1);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.txtTelefFijo1);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.dtgDireccion);
            this.grbBase2.Controls.Add(this.txtVia);
            this.grbBase2.Controls.Add(this.txtZona);
            this.grbBase2.Controls.Add(this.conBusUbiCli);
            this.grbBase2.Controls.Add(this.lblBase56);
            this.grbBase2.Controls.Add(this.txtOtrosVivienda);
            this.grbBase2.Controls.Add(this.cboTipVivienda);
            this.grbBase2.Controls.Add(this.txtPropVivienda);
            this.grbBase2.Controls.Add(this.lblBase55);
            this.grbBase2.Controls.Add(this.lblBase54);
            this.grbBase2.Controls.Add(this.textLote);
            this.grbBase2.Controls.Add(this.textKm);
            this.grbBase2.Controls.Add(this.textNro);
            this.grbBase2.Controls.Add(this.cboTipoZona);
            this.grbBase2.Controls.Add(this.cboTipoVia);
            this.grbBase2.Controls.Add(this.textMz);
            this.grbBase2.Controls.Add(this.lblBase52);
            this.grbBase2.Controls.Add(this.lblBase53);
            this.grbBase2.Controls.Add(this.textInt);
            this.grbBase2.Controls.Add(this.textDpto);
            this.grbBase2.Controls.Add(this.lblBase50);
            this.grbBase2.Controls.Add(this.lblBase51);
            this.grbBase2.Controls.Add(this.lblBase48);
            this.grbBase2.Controls.Add(this.lblBase49);
            this.grbBase2.Controls.Add(this.lblBase27);
            this.grbBase2.Controls.Add(this.lblBase32);
            this.grbBase2.Controls.Add(this.lblBase33);
            this.grbBase2.Controls.Add(this.btnAgregar);
            this.grbBase2.Controls.Add(this.lblBase47);
            this.grbBase2.Controls.Add(this.txtReferencia);
            this.grbBase2.Controls.Add(this.lblBase29);
            this.grbBase2.Controls.Add(this.txtDireccion);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Location = new System.Drawing.Point(12, 133);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(612, 428);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Dirección";
            // 
            // txtTelefCel1
            // 
            this.txtTelefCel1.Location = new System.Drawing.Point(357, 252);
            this.txtTelefCel1.MaxLength = 12;
            this.txtTelefCel1.Name = "txtTelefCel1";
            this.txtTelefCel1.Size = new System.Drawing.Size(175, 20);
            this.txtTelefCel1.TabIndex = 16;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(249, 256);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(102, 13);
            this.lblBase2.TabIndex = 80;
            this.lblBase2.Text = "Número Celular:";
            // 
            // txtTelefFijo1
            // 
            this.txtTelefFijo1.Location = new System.Drawing.Point(110, 252);
            this.txtTelefFijo1.MaxLength = 9;
            this.txtTelefFijo1.Name = "txtTelefFijo1";
            this.txtTelefFijo1.Size = new System.Drawing.Size(127, 20);
            this.txtTelefFijo1.TabIndex = 15;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 256);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 78;
            this.lblBase1.Text = "Telefono fijo:";
            // 
            // dtgDireccion
            // 
            this.dtgDireccion.AllowUserToAddRows = false;
            this.dtgDireccion.AllowUserToDeleteRows = false;
            this.dtgDireccion.AllowUserToResizeColumns = false;
            this.dtgDireccion.AllowUserToResizeRows = false;
            this.dtgDireccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDireccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDireccion.Location = new System.Drawing.Point(14, 278);
            this.dtgDireccion.MultiSelect = false;
            this.dtgDireccion.Name = "dtgDireccion";
            this.dtgDireccion.RowHeadersVisible = false;
            this.dtgDireccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDireccion.Size = new System.Drawing.Size(587, 140);
            this.dtgDireccion.TabIndex = 7;
            // 
            // txtVia
            // 
            this.txtVia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVia.Location = new System.Drawing.Point(466, 43);
            this.txtVia.MaxLength = 30;
            this.txtVia.Name = "txtVia";
            this.txtVia.Size = new System.Drawing.Size(133, 20);
            this.txtVia.TabIndex = 3;
            this.txtVia.TextChanged += new System.EventHandler(this.textVia_TextChanged);
            // 
            // txtZona
            // 
            this.txtZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZona.Location = new System.Drawing.Point(466, 15);
            this.txtZona.MaxLength = 30;
            this.txtZona.Name = "txtZona";
            this.txtZona.Size = new System.Drawing.Size(133, 20);
            this.txtZona.TabIndex = 1;
            this.txtZona.TextChanged += new System.EventHandler(this.textZonas_TextChanged);
            // 
            // conBusUbiCli
            // 
            this.conBusUbiCli.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.conBusUbiCli.Controls.Add(this.cboAnexo);
            this.conBusUbiCli.Controls.Add(this.cboDistrito);
            this.conBusUbiCli.Controls.Add(this.cboProvincia);
            this.conBusUbiCli.Controls.Add(this.cboDepartamento);
            this.conBusUbiCli.Controls.Add(this.cboPais);
            this.conBusUbiCli.Location = new System.Drawing.Point(7, 12);
            this.conBusUbiCli.Name = "conBusUbiCli";
            this.conBusUbiCli.nIdNodo = 0;
            this.conBusUbiCli.Size = new System.Drawing.Size(232, 129);
            this.conBusUbiCli.TabIndex = 0;
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
            // lblBase56
            // 
            this.lblBase56.AutoSize = true;
            this.lblBase56.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase56.ForeColor = System.Drawing.Color.Navy;
            this.lblBase56.Location = new System.Drawing.Point(246, 202);
            this.lblBase56.Name = "lblBase56";
            this.lblBase56.Size = new System.Drawing.Size(104, 13);
            this.lblBase56.TabIndex = 77;
            this.lblBase56.Text = "Otros (Descrip.):";
            // 
            // txtOtrosVivienda
            // 
            this.txtOtrosVivienda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtrosVivienda.Location = new System.Drawing.Point(354, 198);
            this.txtOtrosVivienda.MaxLength = 50;
            this.txtOtrosVivienda.Name = "txtOtrosVivienda";
            this.txtOtrosVivienda.Size = new System.Drawing.Size(245, 20);
            this.txtOtrosVivienda.TabIndex = 13;
            // 
            // cboTipVivienda
            // 
            this.cboTipVivienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipVivienda.DropDownWidth = 150;
            this.cboTipVivienda.FormattingEnabled = true;
            this.cboTipVivienda.Location = new System.Drawing.Point(109, 198);
            this.cboTipVivienda.Name = "cboTipVivienda";
            this.cboTipVivienda.Size = new System.Drawing.Size(128, 21);
            this.cboTipVivienda.TabIndex = 12;
            this.cboTipVivienda.SelectedIndexChanged += new System.EventHandler(this.cboTipVivienda_SelectedIndexChanged);
            // 
            // txtPropVivienda
            // 
            this.txtPropVivienda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPropVivienda.Location = new System.Drawing.Point(109, 226);
            this.txtPropVivienda.MaxLength = 100;
            this.txtPropVivienda.Name = "txtPropVivienda";
            this.txtPropVivienda.Size = new System.Drawing.Size(424, 20);
            this.txtPropVivienda.TabIndex = 14;
            this.txtPropVivienda.Visible = false;
            // 
            // lblBase55
            // 
            this.lblBase55.AutoSize = true;
            this.lblBase55.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase55.ForeColor = System.Drawing.Color.Navy;
            this.lblBase55.Location = new System.Drawing.Point(10, 230);
            this.lblBase55.Name = "lblBase55";
            this.lblBase55.Size = new System.Drawing.Size(74, 13);
            this.lblBase55.TabIndex = 73;
            this.lblBase55.Text = "Propietario:";
            this.lblBase55.Visible = false;
            // 
            // lblBase54
            // 
            this.lblBase54.AutoSize = true;
            this.lblBase54.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase54.ForeColor = System.Drawing.Color.Navy;
            this.lblBase54.Location = new System.Drawing.Point(10, 202);
            this.lblBase54.Name = "lblBase54";
            this.lblBase54.Size = new System.Drawing.Size(89, 13);
            this.lblBase54.TabIndex = 72;
            this.lblBase54.Text = "Tipo/vivienda:";
            // 
            // textLote
            // 
            this.textLote.Location = new System.Drawing.Point(536, 96);
            this.textLote.MaxLength = 3;
            this.textLote.Name = "textLote";
            this.textLote.Size = new System.Drawing.Size(65, 20);
            this.textLote.TabIndex = 9;
            this.textLote.TextChanged += new System.EventHandler(this.textLote_TextChanged);
            // 
            // textKm
            // 
            this.textKm.Location = new System.Drawing.Point(281, 96);
            this.textKm.MaxLength = 3;
            this.textKm.Name = "textKm";
            this.textKm.Size = new System.Drawing.Size(65, 20);
            this.textKm.TabIndex = 7;
            this.textKm.TextChanged += new System.EventHandler(this.textKm_TextChanged);
            // 
            // textNro
            // 
            this.textNro.Location = new System.Drawing.Point(280, 71);
            this.textNro.MaxLength = 5;
            this.textNro.Name = "textNro";
            this.textNro.Size = new System.Drawing.Size(66, 20);
            this.textNro.TabIndex = 4;
            this.textNro.TextChanged += new System.EventHandler(this.textNro_TextChanged);
            // 
            // cboTipoZona
            // 
            this.cboTipoZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoZona.DropDownWidth = 150;
            this.cboTipoZona.FormattingEnabled = true;
            this.cboTipoZona.Location = new System.Drawing.Point(281, 15);
            this.cboTipoZona.MaximumSize = new System.Drawing.Size(160, 0);
            this.cboTipoZona.MaxLength = 50;
            this.cboTipoZona.MinimumSize = new System.Drawing.Size(105, 0);
            this.cboTipoZona.Name = "cboTipoZona";
            this.cboTipoZona.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboTipoZona.Size = new System.Drawing.Size(105, 21);
            this.cboTipoZona.TabIndex = 0;
            this.cboTipoZona.SelectedIndexChanged += new System.EventHandler(this.cboTipoZona_SelectedIndexChanged);
            // 
            // cboTipoVia
            // 
            this.cboTipoVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVia.FormattingEnabled = true;
            this.cboTipoVia.Location = new System.Drawing.Point(281, 43);
            this.cboTipoVia.Name = "cboTipoVia";
            this.cboTipoVia.Size = new System.Drawing.Size(105, 21);
            this.cboTipoVia.TabIndex = 2;
            this.cboTipoVia.SelectedIndexChanged += new System.EventHandler(this.cboTipoVia_SelectedIndexChanged);
            // 
            // textMz
            // 
            this.textMz.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMz.Location = new System.Drawing.Point(403, 96);
            this.textMz.MaxLength = 3;
            this.textMz.Name = "textMz";
            this.textMz.Size = new System.Drawing.Size(65, 20);
            this.textMz.TabIndex = 8;
            this.textMz.TextChanged += new System.EventHandler(this.textMz_TextChanged);
            // 
            // lblBase52
            // 
            this.lblBase52.AutoSize = true;
            this.lblBase52.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase52.ForeColor = System.Drawing.Color.Navy;
            this.lblBase52.Location = new System.Drawing.Point(492, 100);
            this.lblBase52.Name = "lblBase52";
            this.lblBase52.Size = new System.Drawing.Size(36, 13);
            this.lblBase52.TabIndex = 70;
            this.lblBase52.Text = "Lote:";
            // 
            // lblBase53
            // 
            this.lblBase53.AutoSize = true;
            this.lblBase53.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase53.ForeColor = System.Drawing.Color.Navy;
            this.lblBase53.Location = new System.Drawing.Point(363, 100);
            this.lblBase53.Name = "lblBase53";
            this.lblBase53.Size = new System.Drawing.Size(27, 13);
            this.lblBase53.TabIndex = 69;
            this.lblBase53.Text = "Mz:";
            // 
            // textInt
            // 
            this.textInt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textInt.Location = new System.Drawing.Point(536, 71);
            this.textInt.MaxLength = 5;
            this.textInt.Name = "textInt";
            this.textInt.Size = new System.Drawing.Size(65, 20);
            this.textInt.TabIndex = 6;
            this.textInt.TextChanged += new System.EventHandler(this.textInt_TextChanged);
            // 
            // textDpto
            // 
            this.textDpto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textDpto.Location = new System.Drawing.Point(403, 71);
            this.textDpto.MaxLength = 4;
            this.textDpto.Name = "textDpto";
            this.textDpto.Size = new System.Drawing.Size(65, 20);
            this.textDpto.TabIndex = 5;
            this.textDpto.TextChanged += new System.EventHandler(this.textDpto_TextChanged);
            // 
            // lblBase50
            // 
            this.lblBase50.AutoSize = true;
            this.lblBase50.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase50.ForeColor = System.Drawing.Color.Navy;
            this.lblBase50.Location = new System.Drawing.Point(492, 75);
            this.lblBase50.Name = "lblBase50";
            this.lblBase50.Size = new System.Drawing.Size(28, 13);
            this.lblBase50.TabIndex = 66;
            this.lblBase50.Text = "Int:";
            // 
            // lblBase51
            // 
            this.lblBase51.AutoSize = true;
            this.lblBase51.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase51.ForeColor = System.Drawing.Color.Navy;
            this.lblBase51.Location = new System.Drawing.Point(363, 75);
            this.lblBase51.Name = "lblBase51";
            this.lblBase51.Size = new System.Drawing.Size(39, 13);
            this.lblBase51.TabIndex = 65;
            this.lblBase51.Text = "Dpto:";
            // 
            // lblBase48
            // 
            this.lblBase48.AutoSize = true;
            this.lblBase48.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase48.ForeColor = System.Drawing.Color.Navy;
            this.lblBase48.Location = new System.Drawing.Point(393, 47);
            this.lblBase48.Name = "lblBase48";
            this.lblBase48.Size = new System.Drawing.Size(64, 13);
            this.lblBase48.TabIndex = 61;
            this.lblBase48.Text = "Nom. Vía:";
            // 
            // lblBase49
            // 
            this.lblBase49.AutoSize = true;
            this.lblBase49.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase49.ForeColor = System.Drawing.Color.Navy;
            this.lblBase49.Location = new System.Drawing.Point(393, 19);
            this.lblBase49.Name = "lblBase49";
            this.lblBase49.Size = new System.Drawing.Size(75, 13);
            this.lblBase49.TabIndex = 60;
            this.lblBase49.Text = "Nom. Zona:";
            // 
            // lblBase27
            // 
            this.lblBase27.AutoSize = true;
            this.lblBase27.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase27.ForeColor = System.Drawing.Color.Navy;
            this.lblBase27.Location = new System.Drawing.Point(242, 100);
            this.lblBase27.Name = "lblBase27";
            this.lblBase27.Size = new System.Drawing.Size(31, 13);
            this.lblBase27.TabIndex = 56;
            this.lblBase27.Text = "Km:";
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(242, 47);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(30, 13);
            this.lblBase32.TabIndex = 55;
            this.lblBase32.Text = "Vía:";
            // 
            // lblBase33
            // 
            this.lblBase33.AutoSize = true;
            this.lblBase33.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase33.ForeColor = System.Drawing.Color.Navy;
            this.lblBase33.Location = new System.Drawing.Point(242, 19);
            this.lblBase33.Name = "lblBase33";
            this.lblBase33.Size = new System.Drawing.Size(41, 13);
            this.lblBase33.TabIndex = 54;
            this.lblBase33.Text = "Zona:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Location = new System.Drawing.Point(539, 224);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 50);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblBase47
            // 
            this.lblBase47.AutoSize = true;
            this.lblBase47.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase47.ForeColor = System.Drawing.Color.Navy;
            this.lblBase47.Location = new System.Drawing.Point(242, 75);
            this.lblBase47.Name = "lblBase47";
            this.lblBase47.Size = new System.Drawing.Size(32, 13);
            this.lblBase47.TabIndex = 53;
            this.lblBase47.Text = "Nro:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencia.Enabled = false;
            this.txtReferencia.Location = new System.Drawing.Point(109, 173);
            this.txtReferencia.MaxLength = 50;
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(492, 20);
            this.txtReferencia.TabIndex = 11;
            // 
            // lblBase29
            // 
            this.lblBase29.AutoSize = true;
            this.lblBase29.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase29.ForeColor = System.Drawing.Color.Navy;
            this.lblBase29.Location = new System.Drawing.Point(11, 177);
            this.lblBase29.Name = "lblBase29";
            this.lblBase29.Size = new System.Drawing.Size(73, 13);
            this.lblBase29.TabIndex = 22;
            this.lblBase29.Text = "Referencia:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(109, 147);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(492, 20);
            this.txtDireccion.TabIndex = 10;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(11, 151);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(65, 13);
            this.lblBase7.TabIndex = 8;
            this.lblBase7.Text = "Dirección:";
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(366, 570);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 2;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // frmDireccionRecupera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 651);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.conBusCli1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmDireccionRecupera";
            this.Text = "Registro de Direcciones de Recuperaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDireccion)).EndInit();
            this.conBusUbiCli.ResumeLayout(false);
            this.conBusUbiCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.grbBase grbBase2;
        private System.Windows.Forms.DataGridView dtgDireccion;
        private GEN.ControlesBase.txtCBLetra txtVia;
        private GEN.ControlesBase.txtCBLetra txtZona;
        private GEN.ControlesBase.ConBusUbig conBusUbiCli;
        private GEN.ControlesBase.cboUbigeo cboAnexo;
        private GEN.ControlesBase.cboUbigeo cboDistrito;
        private GEN.ControlesBase.cboUbigeo cboProvincia;
        private GEN.ControlesBase.cboUbigeo cboDepartamento;
        private GEN.ControlesBase.cboUbigeo cboPais;
        private GEN.ControlesBase.lblBase lblBase56;
        private GEN.ControlesBase.txtCBLetra txtOtrosVivienda;
        private GEN.ControlesBase.cboTipVivienda cboTipVivienda;
        private GEN.ControlesBase.txtCBLetra txtPropVivienda;
        private GEN.ControlesBase.lblBase lblBase55;
        private GEN.ControlesBase.lblBase lblBase54;
        private GEN.ControlesBase.txtCBNumerosEnteros textLote;
        private GEN.ControlesBase.txtCBNumerosEnteros textKm;
        private GEN.ControlesBase.txtCBNumerosEnteros textNro;
        private GEN.ControlesBase.cboTipoZona cboTipoZona;
        private GEN.ControlesBase.cboTipoVia cboTipoVia;
        private System.Windows.Forms.TextBox textMz;
        private GEN.ControlesBase.lblBase lblBase52;
        private GEN.ControlesBase.lblBase lblBase53;
        private System.Windows.Forms.TextBox textInt;
        private System.Windows.Forms.TextBox textDpto;
        private GEN.ControlesBase.lblBase lblBase50;
        private GEN.ControlesBase.lblBase lblBase51;
        private GEN.ControlesBase.lblBase lblBase48;
        private GEN.ControlesBase.lblBase lblBase49;
        private GEN.ControlesBase.lblBase lblBase27;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.lblBase lblBase33;
        private GEN.BotonesBase.btnAgregar btnAgregar;
        private GEN.ControlesBase.lblBase lblBase47;
        private GEN.ControlesBase.txtBase txtReferencia;
        private GEN.ControlesBase.lblBase lblBase29;
        private GEN.ControlesBase.txtBase txtDireccion;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.ControlesBase.txtTelefCel txtTelefCel1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtTelefFijo txtTelefFijo1;
        private GEN.ControlesBase.lblBase lblBase1;
    }
}

