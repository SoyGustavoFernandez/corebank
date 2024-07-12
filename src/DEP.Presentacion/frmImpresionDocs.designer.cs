namespace DEP.Presentacion
{
    partial class frmImpresionDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpresionDocs));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroMaxFolio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtEstadoCta = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtNroImpresiones = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboTipoCuenta1 = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.dtpCorto1 = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNroFolio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtCodCertificado = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnVincular = new GEN.BotonesBase.Btn_Vincular();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgFormatos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.idCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoInterv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoIntervencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lCliAfeITF = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isReqFirma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conAutorizacionUsuDatos1 = new GEN.ControlesBase.conAutorizacionUsuDatos();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFormatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Location = new System.Drawing.Point(7, 7);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho.TabIndex = 1;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho1_ClicBusCta);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(615, 481);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(488, 481);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtNroMaxFolio);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.txtEstadoCta);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.txtNroImpresiones);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.cboTipoCuenta1);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.dtpCorto1);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtProducto);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(12, 124);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(664, 127);
            this.grbBase2.TabIndex = 9;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Cuenta:";
            // 
            // txtNroMaxFolio
            // 
            this.txtNroMaxFolio.Enabled = false;
            this.txtNroMaxFolio.Location = new System.Drawing.Point(465, 101);
            this.txtNroMaxFolio.Name = "txtNroMaxFolio";
            this.txtNroMaxFolio.Size = new System.Drawing.Size(105, 20);
            this.txtNroMaxFolio.TabIndex = 37;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(268, 104);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(193, 13);
            this.lblBase8.TabIndex = 36;
            this.lblBase8.Text = "Nro Máximo del Folio Entregado:";
            // 
            // txtEstadoCta
            // 
            this.txtEstadoCta.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstadoCta.Enabled = false;
            this.txtEstadoCta.Location = new System.Drawing.Point(132, 74);
            this.txtEstadoCta.Name = "txtEstadoCta";
            this.txtEstadoCta.Size = new System.Drawing.Size(220, 20);
            this.txtEstadoCta.TabIndex = 35;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(21, 77);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(95, 13);
            this.lblBase4.TabIndex = 34;
            this.lblBase4.Text = "Estado Cuenta:";
            // 
            // txtNroImpresiones
            // 
            this.txtNroImpresiones.Enabled = false;
            this.txtNroImpresiones.Location = new System.Drawing.Point(132, 101);
            this.txtNroImpresiones.Name = "txtNroImpresiones";
            this.txtNroImpresiones.Size = new System.Drawing.Size(105, 20);
            this.txtNroImpresiones.TabIndex = 33;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(21, 104);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(107, 13);
            this.lblBase6.TabIndex = 22;
            this.lblBase6.Text = "Nro Impresiones:";
            // 
            // cboTipoCuenta1
            // 
            this.cboTipoCuenta1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCuenta1.Enabled = false;
            this.cboTipoCuenta1.FormattingEnabled = true;
            this.cboTipoCuenta1.Location = new System.Drawing.Point(132, 47);
            this.cboTipoCuenta1.Name = "cboTipoCuenta1";
            this.cboTipoCuenta1.Size = new System.Drawing.Size(220, 21);
            this.cboTipoCuenta1.TabIndex = 21;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(465, 23);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(159, 21);
            this.cboMoneda.TabIndex = 11;
            // 
            // dtpCorto1
            // 
            this.dtpCorto1.Enabled = false;
            this.dtpCorto1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCorto1.Location = new System.Drawing.Point(465, 52);
            this.dtpCorto1.Name = "dtpCorto1";
            this.dtpCorto1.Size = new System.Drawing.Size(159, 20);
            this.dtpCorto1.TabIndex = 19;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(362, 55);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 18;
            this.lblBase5.Text = "Fecha Apertura:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(405, 26);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Moneda:";
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.SystemColors.Control;
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(95, 19);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(257, 20);
            this.txtProducto.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(21, 50);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Tipo de Cuenta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(21, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(62, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Producto:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(552, 481);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(12, 48);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(167, 13);
            this.lblBase7.TabIndex = 28;
            this.lblBase7.Text = "Nro de Folio del Certificado:";
            // 
            // txtNroFolio
            // 
            this.txtNroFolio.Enabled = false;
            this.txtNroFolio.Location = new System.Drawing.Point(182, 46);
            this.txtNroFolio.MaxLength = 8;
            this.txtNroFolio.Name = "txtNroFolio";
            this.txtNroFolio.Size = new System.Drawing.Size(105, 20);
            this.txtNroFolio.TabIndex = 29;
            // 
            // txtCodCertificado
            // 
            this.txtCodCertificado.Enabled = false;
            this.txtCodCertificado.Location = new System.Drawing.Point(182, 19);
            this.txtCodCertificado.Name = "txtCodCertificado";
            this.txtCodCertificado.Size = new System.Drawing.Size(105, 20);
            this.txtCodCertificado.TabIndex = 31;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(40, 22);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(139, 13);
            this.lblBase9.TabIndex = 30;
            this.lblBase9.Text = "Código del Certificado:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnVincular);
            this.grbBase1.Controls.Add(this.txtCodCertificado);
            this.grbBase1.Controls.Add(this.lblBase9);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.txtNroFolio);
            this.grbBase1.Location = new System.Drawing.Point(317, 399);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(361, 74);
            this.grbBase1.TabIndex = 32;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Vinculación con el Certificado";
            // 
            // btnVincular
            // 
            this.btnVincular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincular.BackgroundImage")));
            this.btnVincular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincular.Enabled = false;
            this.btnVincular.Image = ((System.Drawing.Image)(resources.GetObject("btnVincular.Image")));
            this.btnVincular.Location = new System.Drawing.Point(296, 14);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(60, 50);
            this.btnVincular.TabIndex = 32;
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgFormatos);
            this.grbBase3.Location = new System.Drawing.Point(12, 392);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(298, 110);
            this.grbBase3.TabIndex = 33;
            this.grbBase3.TabStop = false;
            // 
            // dtgFormatos
            // 
            this.dtgFormatos.AllowUserToAddRows = false;
            this.dtgFormatos.AllowUserToDeleteRows = false;
            this.dtgFormatos.AllowUserToResizeColumns = false;
            this.dtgFormatos.AllowUserToResizeRows = false;
            this.dtgFormatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFormatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFormatos.Enabled = false;
            this.dtgFormatos.Location = new System.Drawing.Point(3, 12);
            this.dtgFormatos.MultiSelect = false;
            this.dtgFormatos.Name = "dtgFormatos";
            this.dtgFormatos.ReadOnly = true;
            this.dtgFormatos.RowHeadersVisible = false;
            this.dtgFormatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFormatos.Size = new System.Drawing.Size(286, 93);
            this.dtgFormatos.TabIndex = 35;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCli,
            this.idTipoInterv,
            this.idSolicitud,
            this.cTipoDocumento,
            this.cDocumentoID,
            this.cNombre,
            this.cTipoIntervencion,
            this.lCliAfeITF,
            this.isReqFirma,
            this.idTipoDocumento});
            this.dtgIntervinientes.Location = new System.Drawing.Point(15, 257);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(654, 128);
            this.dtgIntervinientes.TabIndex = 34;
            this.dtgIntervinientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIntervinientes_CellClick);
            this.dtgIntervinientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIntervinientes_CellContentClick);
            // 
            // idCli
            // 
            this.idCli.DataPropertyName = "idCli";
            this.idCli.HeaderText = "idCli";
            this.idCli.Name = "idCli";
            this.idCli.ReadOnly = true;
            this.idCli.Visible = false;
            // 
            // idTipoInterv
            // 
            this.idTipoInterv.DataPropertyName = "idTipoInterv";
            this.idTipoInterv.HeaderText = "idTipoInterv";
            this.idTipoInterv.Name = "idTipoInterv";
            this.idTipoInterv.ReadOnly = true;
            this.idTipoInterv.Visible = false;
            // 
            // idSolicitud
            // 
            this.idSolicitud.DataPropertyName = "idSolicitud";
            this.idSolicitud.FillWeight = 80F;
            this.idSolicitud.HeaderText = "CUENTA";
            this.idSolicitud.Name = "idSolicitud";
            this.idSolicitud.ReadOnly = true;
            this.idSolicitud.Visible = false;
            // 
            // cTipoDocumento
            // 
            this.cTipoDocumento.DataPropertyName = "cTipoDocumento";
            this.cTipoDocumento.HeaderText = "TIPO DOC.";
            this.cTipoDocumento.Name = "cTipoDocumento";
            this.cTipoDocumento.ReadOnly = true;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.HeaderText = "DOCUMENTO";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 300F;
            this.cNombre.HeaderText = "NOMBRE CLIENTE";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            // 
            // cTipoIntervencion
            // 
            this.cTipoIntervencion.DataPropertyName = "cTipoIntervencion";
            this.cTipoIntervencion.HeaderText = "INTERVINIENTE";
            this.cTipoIntervencion.Name = "cTipoIntervencion";
            this.cTipoIntervencion.ReadOnly = true;
            // 
            // lCliAfeITF
            // 
            this.lCliAfeITF.DataPropertyName = "lCliAfeITF";
            this.lCliAfeITF.FillWeight = 25F;
            this.lCliAfeITF.HeaderText = "ITF";
            this.lCliAfeITF.Name = "lCliAfeITF";
            this.lCliAfeITF.ReadOnly = true;
            this.lCliAfeITF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lCliAfeITF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isReqFirma
            // 
            this.isReqFirma.DataPropertyName = "isReqFirma";
            this.isReqFirma.HeaderText = "isReqFirma";
            this.isReqFirma.Name = "isReqFirma";
            this.isReqFirma.ReadOnly = true;
            this.isReqFirma.Visible = false;
            // 
            // idTipoDocumento
            // 
            this.idTipoDocumento.DataPropertyName = "idTipoDocumento";
            this.idTipoDocumento.HeaderText = "idTipoDocumento";
            this.idTipoDocumento.Name = "idTipoDocumento";
            this.idTipoDocumento.ReadOnly = true;
            this.idTipoDocumento.Visible = false;
            // 
            // conAutorizacionUsuDatos1
            // 
            this.conAutorizacionUsuDatos1.BackColor = System.Drawing.Color.Transparent;
            this.conAutorizacionUsuDatos1.cCodCliente = null;
            this.conAutorizacionUsuDatos1.idCliente = 0;
            this.conAutorizacionUsuDatos1.idSolicitud = 0;
            this.conAutorizacionUsuDatos1.Location = new System.Drawing.Point(354, 56);
            this.conAutorizacionUsuDatos1.Name = "conAutorizacionUsuDatos1";
            this.conAutorizacionUsuDatos1.pcDireccion = null;
            this.conAutorizacionUsuDatos1.pcDocumentoID = null;
            this.conAutorizacionUsuDatos1.pcNombre = null;
            this.conAutorizacionUsuDatos1.pcNombreJuridico = null;
            this.conAutorizacionUsuDatos1.pcNroDocJuridico = null;
            this.conAutorizacionUsuDatos1.pcTelefono = null;
            this.conAutorizacionUsuDatos1.pIdTipoDocumento = 0;
            this.conAutorizacionUsuDatos1.pIdTipoPersona = 0;
            this.conAutorizacionUsuDatos1.Size = new System.Drawing.Size(36, 28);
            this.conAutorizacionUsuDatos1.TabIndex = 36;
            this.conAutorizacionUsuDatos1.Load += new System.EventHandler(this.conAutorizacionUsuDatos1_Load);
            // 
            // frmImpresionDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 559);
            this.Controls.Add(this.conAutorizacionUsuDatos1);
            this.Controls.Add(this.dtgIntervinientes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.conBusCtaAho);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmImpresionDocs";
            this.Text = "Imprimir Formatos de Ahorros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReimpresionDocs_FormClosed);
            this.Load += new System.EventHandler(this.frmReimpresionCertificado_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.dtgIntervinientes, 0);
            this.Controls.SetChildIndex(this.conAutorizacionUsuDatos1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFormatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.dtpCorto dtpCorto1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroFolio;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCertificado;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.Btn_Vincular btnVincular;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroImpresiones;
        private GEN.ControlesBase.lblBase lblBase6;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private GEN.ControlesBase.dtgBase dtgFormatos;
        private GEN.ControlesBase.txtBase txtEstadoCta;
        private GEN.ControlesBase.lblBase lblBase4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoInterv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoIntervencion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lCliAfeITF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReqFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDocumento;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroMaxFolio;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.conAutorizacionUsuDatos conAutorizacionUsuDatos1;
    }
}