namespace DEP.Presentacion
{
    partial class frmSolicitudCartaCTSTransferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudCartaCTSTransferencias));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroCta = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnCancelarDet = new GEN.BotonesBase.btnCancelar();
            this.btnGrabarDet = new GEN.BotonesBase.btnGrabar();
            this.btnEditarDet = new GEN.BotonesBase.btnEditar();
            this.txtViaEntidad = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboTipoComp = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtNroOpOCheque = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtFechaOp = new GEN.ControlesBase.dtLargoBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtImporte = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboMonDestino = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboEntidadDes = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboTipoEntidadDes = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblUsuarioSol = new System.Windows.Forms.Label();
            this.lblEstadoSol = new GEN.ControlesBase.lblBase();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblUsuario = new GEN.ControlesBase.lblBase();
            this.lblFecSol = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcRUCEmpleador = new GEN.ControlesBase.txtBase(this.components);
            this.txtcEmpleador = new GEN.ControlesBase.txtBase(this.components);
            this.txtcCodEmpleador = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.lblBase16 = new GEN.ControlesBase.lblBase();
            this.lblBase17 = new GEN.ControlesBase.lblBase();
            this.txtMonto = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboMonOrigen = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.cboTipoEntidadOri = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.cboEntidadOri = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.chcNuevaSolicitud = new GEN.ControlesBase.chcBase(this.components);
            this.groupBox1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Location = new System.Drawing.Point(7, 6);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(566, 112);
            this.conBusCtaAho.TabIndex = 2;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbBase2);
            this.groupBox1.Controls.Add(this.cboMonDestino);
            this.groupBox1.Controls.Add(this.lblBase15);
            this.groupBox1.Controls.Add(this.lblBase5);
            this.groupBox1.Controls.Add(this.cboEntidadDes);
            this.groupBox1.Controls.Add(this.cboTipoEntidadDes);
            this.groupBox1.Controls.Add(this.lblBase4);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(384, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 314);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Destino ";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtNroCta);
            this.grbBase2.Controls.Add(this.btnCancelarDet);
            this.grbBase2.Controls.Add(this.btnGrabarDet);
            this.grbBase2.Controls.Add(this.btnEditarDet);
            this.grbBase2.Controls.Add(this.txtViaEntidad);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.cboTipoComp);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.txtNroOpOCheque);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.dtFechaOp);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.txtImporte);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(5, 93);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(354, 215);
            this.grbBase2.TabIndex = 153;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Transferencia";
            // 
            // txtNroCta
            // 
            this.txtNroCta.Location = new System.Drawing.Point(106, 112);
            this.txtNroCta.Name = "txtNroCta";
            this.txtNroCta.Size = new System.Drawing.Size(195, 20);
            this.txtNroCta.TabIndex = 145;
            // 
            // btnCancelarDet
            // 
            this.btnCancelarDet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarDet.BackgroundImage")));
            this.btnCancelarDet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarDet.Enabled = false;
            this.btnCancelarDet.Location = new System.Drawing.Point(173, 159);
            this.btnCancelarDet.Name = "btnCancelarDet";
            this.btnCancelarDet.Size = new System.Drawing.Size(60, 50);
            this.btnCancelarDet.TabIndex = 11;
            this.btnCancelarDet.Text = "&Cancelar";
            this.btnCancelarDet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelarDet.UseVisualStyleBackColor = true;
            this.btnCancelarDet.Click += new System.EventHandler(this.btnCancelarDet_Click);
            // 
            // btnGrabarDet
            // 
            this.btnGrabarDet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabarDet.BackgroundImage")));
            this.btnGrabarDet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabarDet.Enabled = false;
            this.btnGrabarDet.Location = new System.Drawing.Point(239, 159);
            this.btnGrabarDet.Name = "btnGrabarDet";
            this.btnGrabarDet.Size = new System.Drawing.Size(60, 50);
            this.btnGrabarDet.TabIndex = 12;
            this.btnGrabarDet.Text = "&Grabar";
            this.btnGrabarDet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarDet.UseVisualStyleBackColor = true;
            this.btnGrabarDet.Click += new System.EventHandler(this.btnGrabarDet_Click);
            // 
            // btnEditarDet
            // 
            this.btnEditarDet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarDet.BackgroundImage")));
            this.btnEditarDet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarDet.Enabled = false;
            this.btnEditarDet.Location = new System.Drawing.Point(107, 159);
            this.btnEditarDet.Name = "btnEditarDet";
            this.btnEditarDet.Size = new System.Drawing.Size(60, 50);
            this.btnEditarDet.TabIndex = 10;
            this.btnEditarDet.Text = "&Editar";
            this.btnEditarDet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarDet.UseVisualStyleBackColor = true;
            this.btnEditarDet.Click += new System.EventHandler(this.btnEditarDet_Click);
            // 
            // txtViaEntidad
            // 
            this.txtViaEntidad.Enabled = false;
            this.txtViaEntidad.Location = new System.Drawing.Point(106, 18);
            this.txtViaEntidad.Name = "txtViaEntidad";
            this.txtViaEntidad.Size = new System.Drawing.Size(237, 20);
            this.txtViaEntidad.TabIndex = 4;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(14, 22);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(90, 13);
            this.lblBase11.TabIndex = 153;
            this.lblBase11.Text = "Intermediario:";
            // 
            // cboTipoComp
            // 
            this.cboTipoComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComp.Enabled = false;
            this.cboTipoComp.FormattingEnabled = true;
            this.cboTipoComp.Location = new System.Drawing.Point(106, 41);
            this.cboTipoComp.Name = "cboTipoComp";
            this.cboTipoComp.Size = new System.Drawing.Size(237, 21);
            this.cboTipoComp.TabIndex = 5;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(14, 45);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(78, 13);
            this.lblBase10.TabIndex = 152;
            this.lblBase10.Text = "Tipo Comp.:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(14, 92);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(85, 13);
            this.lblBase7.TabIndex = 4;
            this.lblBase7.Text = "Nro. Ch./Op.:";
            // 
            // txtNroOpOCheque
            // 
            this.txtNroOpOCheque.Enabled = false;
            this.txtNroOpOCheque.Location = new System.Drawing.Point(106, 88);
            this.txtNroOpOCheque.Name = "txtNroOpOCheque";
            this.txtNroOpOCheque.Size = new System.Drawing.Size(195, 20);
            this.txtNroOpOCheque.TabIndex = 7;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(14, 138);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(58, 13);
            this.lblBase6.TabIndex = 3;
            this.lblBase6.Text = "Importe:";
            // 
            // dtFechaOp
            // 
            this.dtFechaOp.Enabled = false;
            this.dtFechaOp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaOp.Location = new System.Drawing.Point(106, 65);
            this.dtFechaOp.Name = "dtFechaOp";
            this.dtFechaOp.Size = new System.Drawing.Size(100, 20);
            this.dtFechaOp.TabIndex = 6;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(14, 115);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(64, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Nro. Cta.:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 69);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(69, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Op.:";
            // 
            // txtImporte
            // 
            this.txtImporte.Enabled = false;
            this.txtImporte.FormatoDecimal = false;
            this.txtImporte.Location = new System.Drawing.Point(106, 134);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImporte.nNumDecimales = 4;
            this.txtImporte.nvalor = 0D;
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 9;
            // 
            // cboMonDestino
            // 
            this.cboMonDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonDestino.Enabled = false;
            this.cboMonDestino.FormattingEnabled = true;
            this.cboMonDestino.Location = new System.Drawing.Point(97, 19);
            this.cboMonDestino.Name = "cboMonDestino";
            this.cboMonDestino.Size = new System.Drawing.Size(140, 21);
            this.cboMonDestino.TabIndex = 1;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(14, 23);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(56, 13);
            this.lblBase15.TabIndex = 149;
            this.lblBase15.Text = "Moneda:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(12, 71);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(70, 13);
            this.lblBase5.TabIndex = 10;
            this.lblBase5.Text = "Financiera:";
            // 
            // cboEntidadDes
            // 
            this.cboEntidadDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidadDes.DropDownWidth = 350;
            this.cboEntidadDes.Enabled = false;
            this.cboEntidadDes.FormattingEnabled = true;
            this.cboEntidadDes.Location = new System.Drawing.Point(97, 67);
            this.cboEntidadDes.Name = "cboEntidadDes";
            this.cboEntidadDes.Size = new System.Drawing.Size(262, 21);
            this.cboEntidadDes.TabIndex = 3;
            // 
            // cboTipoEntidadDes
            // 
            this.cboTipoEntidadDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntidadDes.Enabled = false;
            this.cboTipoEntidadDes.FormattingEnabled = true;
            this.cboTipoEntidadDes.Location = new System.Drawing.Point(97, 43);
            this.cboTipoEntidadDes.Name = "cboTipoEntidadDes";
            this.cboTipoEntidadDes.Size = new System.Drawing.Size(262, 21);
            this.cboTipoEntidadDes.TabIndex = 2;
            this.cboTipoEntidadDes.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(12, 47);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(82, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Tipo Entidad:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(701, 530);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(635, 530);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(569, 530);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 14;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(503, 530);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 13;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(616, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 142;
            // 
            // lblUsuarioSol
            // 
            this.lblUsuarioSol.AutoSize = true;
            this.lblUsuarioSol.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioSol.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuarioSol.Location = new System.Drawing.Point(152, 53);
            this.lblUsuarioSol.Name = "lblUsuarioSol";
            this.lblUsuarioSol.Size = new System.Drawing.Size(0, 13);
            this.lblUsuarioSol.TabIndex = 141;
            // 
            // lblEstadoSol
            // 
            this.lblEstadoSol.AutoSize = true;
            this.lblEstadoSol.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEstadoSol.ForeColor = System.Drawing.Color.Navy;
            this.lblEstadoSol.Location = new System.Drawing.Point(14, 25);
            this.lblEstadoSol.Name = "lblEstadoSol";
            this.lblEstadoSol.Size = new System.Drawing.Size(102, 13);
            this.lblEstadoSol.TabIndex = 137;
            this.lblEstadoSol.Text = "Estado Solicitud:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(152, 25);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 138;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblUsuario.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuario.Location = new System.Drawing.Point(14, 53);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(131, 13);
            this.lblUsuario.TabIndex = 139;
            this.lblUsuario.Text = "Personal que Solicitó:";
            // 
            // lblFecSol
            // 
            this.lblFecSol.AutoSize = true;
            this.lblFecSol.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecSol.ForeColor = System.Drawing.Color.Navy;
            this.lblFecSol.Location = new System.Drawing.Point(478, 25);
            this.lblFecSol.Name = "lblFecSol";
            this.lblFecSol.Size = new System.Drawing.Size(97, 13);
            this.lblFecSol.TabIndex = 140;
            this.lblFecSol.Text = "Fecha Solicitud:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.groupBox3);
            this.grbBase1.Controls.Add(this.groupBox1);
            this.grbBase1.Controls.Add(this.lblFecha);
            this.grbBase1.Controls.Add(this.lblEstadoSol);
            this.grbBase1.Controls.Add(this.lblEstado);
            this.grbBase1.Controls.Add(this.lblFecSol);
            this.grbBase1.Controls.Add(this.lblUsuario);
            this.grbBase1.Controls.Add(this.lblUsuarioSol);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 124);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(756, 398);
            this.grbBase1.TabIndex = 143;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Solicitud";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.txtMonto);
            this.groupBox3.Controls.Add(this.lblBase3);
            this.groupBox3.Controls.Add(this.cboMonOrigen);
            this.groupBox3.Controls.Add(this.lblBase9);
            this.groupBox3.Controls.Add(this.lblBase14);
            this.groupBox3.Controls.Add(this.cboTipoEntidadOri);
            this.groupBox3.Controls.Add(this.cboEntidadOri);
            this.groupBox3.Controls.Add(this.lblBase8);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(9, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 313);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Origen ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtcRUCEmpleador);
            this.groupBox2.Controls.Add(this.txtcEmpleador);
            this.groupBox2.Controls.Add(this.txtcCodEmpleador);
            this.groupBox2.Controls.Add(this.lblBase13);
            this.groupBox2.Controls.Add(this.lblBase16);
            this.groupBox2.Controls.Add(this.lblBase17);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(6, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 96);
            this.groupBox2.TabIndex = 144;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del empleador";
            // 
            // txtcRUCEmpleador
            // 
            this.txtcRUCEmpleador.Enabled = false;
            this.txtcRUCEmpleador.Location = new System.Drawing.Point(90, 67);
            this.txtcRUCEmpleador.Name = "txtcRUCEmpleador";
            this.txtcRUCEmpleador.Size = new System.Drawing.Size(190, 20);
            this.txtcRUCEmpleador.TabIndex = 13;
            // 
            // txtcEmpleador
            // 
            this.txtcEmpleador.Enabled = false;
            this.txtcEmpleador.Location = new System.Drawing.Point(90, 43);
            this.txtcEmpleador.Name = "txtcEmpleador";
            this.txtcEmpleador.Size = new System.Drawing.Size(258, 20);
            this.txtcEmpleador.TabIndex = 12;
            // 
            // txtcCodEmpleador
            // 
            this.txtcCodEmpleador.Enabled = false;
            this.txtcCodEmpleador.Location = new System.Drawing.Point(90, 19);
            this.txtcCodEmpleador.Name = "txtcCodEmpleador";
            this.txtcCodEmpleador.Size = new System.Drawing.Size(190, 20);
            this.txtcCodEmpleador.TabIndex = 11;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(12, 47);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(73, 13);
            this.lblBase13.TabIndex = 6;
            this.lblBase13.Text = "Empleador:";
            // 
            // lblBase16
            // 
            this.lblBase16.AutoSize = true;
            this.lblBase16.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase16.ForeColor = System.Drawing.Color.Navy;
            this.lblBase16.Location = new System.Drawing.Point(12, 23);
            this.lblBase16.Name = "lblBase16";
            this.lblBase16.Size = new System.Drawing.Size(52, 13);
            this.lblBase16.TabIndex = 10;
            this.lblBase16.Text = "Código:";
            // 
            // lblBase17
            // 
            this.lblBase17.AutoSize = true;
            this.lblBase17.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase17.ForeColor = System.Drawing.Color.Navy;
            this.lblBase17.Location = new System.Drawing.Point(12, 71);
            this.lblBase17.Name = "lblBase17";
            this.lblBase17.Size = new System.Drawing.Size(37, 13);
            this.lblBase17.TabIndex = 3;
            this.lblBase17.Text = "RUC:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.FormatoDecimal = false;
            this.txtMonto.Location = new System.Drawing.Point(97, 91);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonto.nNumDecimales = 4;
            this.txtMonto.nvalor = 0D;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 12;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(11, 95);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(74, 13);
            this.lblBase3.TabIndex = 11;
            this.lblBase3.Text = "Monto CTS:";
            // 
            // cboMonOrigen
            // 
            this.cboMonOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonOrigen.Enabled = false;
            this.cboMonOrigen.FormattingEnabled = true;
            this.cboMonOrigen.Location = new System.Drawing.Point(97, 19);
            this.cboMonOrigen.Name = "cboMonOrigen";
            this.cboMonOrigen.Size = new System.Drawing.Size(140, 21);
            this.cboMonOrigen.TabIndex = 1;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(11, 47);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(82, 13);
            this.lblBase9.TabIndex = 6;
            this.lblBase9.Text = "Tipo Entidad:";
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(11, 23);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(56, 13);
            this.lblBase14.TabIndex = 10;
            this.lblBase14.Text = "Moneda:";
            // 
            // cboTipoEntidadOri
            // 
            this.cboTipoEntidadOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntidadOri.DropDownWidth = 180;
            this.cboTipoEntidadOri.Enabled = false;
            this.cboTipoEntidadOri.FormattingEnabled = true;
            this.cboTipoEntidadOri.Location = new System.Drawing.Point(97, 43);
            this.cboTipoEntidadOri.Name = "cboTipoEntidadOri";
            this.cboTipoEntidadOri.Size = new System.Drawing.Size(258, 21);
            this.cboTipoEntidadOri.TabIndex = 2;
            this.cboTipoEntidadOri.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidadOri_SelectedIndexChanged);
            // 
            // cboEntidadOri
            // 
            this.cboEntidadOri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidadOri.Enabled = false;
            this.cboEntidadOri.FormattingEnabled = true;
            this.cboEntidadOri.Location = new System.Drawing.Point(97, 67);
            this.cboEntidadOri.Name = "cboEntidadOri";
            this.cboEntidadOri.Size = new System.Drawing.Size(258, 21);
            this.cboEntidadOri.TabIndex = 3;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(11, 71);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(70, 13);
            this.lblBase8.TabIndex = 3;
            this.lblBase8.Text = "Financiera:";
            // 
            // chcNuevaSolicitud
            // 
            this.chcNuevaSolicitud.AutoSize = true;
            this.chcNuevaSolicitud.Location = new System.Drawing.Point(363, 533);
            this.chcNuevaSolicitud.Name = "chcNuevaSolicitud";
            this.chcNuevaSolicitud.Size = new System.Drawing.Size(132, 17);
            this.chcNuevaSolicitud.TabIndex = 146;
            this.chcNuevaSolicitud.Text = "Enviar nueva Solicitud";
            this.chcNuevaSolicitud.UseVisualStyleBackColor = true;
            this.chcNuevaSolicitud.Visible = false;
            this.chcNuevaSolicitud.CheckedChanged += new System.EventHandler(this.chcNuevaSolicitud_CheckedChanged);
            // 
            // frmSolicitudCartaCTSTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 610);
            this.Controls.Add(this.chcNuevaSolicitud);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.conBusCtaAho);
            this.Name = "frmSolicitudCartaCTSTransferencias";
            this.Text = "Solicitud de Transferencia de CTS-Egreso";
            this.Load += new System.EventHandler(this.frmCartaCTSTransferencias_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.chcNuevaSolicitud, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidadDes;
        private GEN.ControlesBase.cboEntidad cboEntidadDes;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblUsuarioSol;
        private GEN.ControlesBase.lblBase lblEstadoSol;
        private System.Windows.Forms.Label lblEstado;
        private GEN.ControlesBase.lblBase lblUsuario;
        private GEN.ControlesBase.lblBase lblFecSol;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.chcBase chcNuevaSolicitud;
        private GEN.ControlesBase.cboMoneda cboMonOrigen;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.ControlesBase.cboEntidad cboEntidadOri;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidadOri;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.GroupBox groupBox3;
        private GEN.ControlesBase.cboMoneda cboMonDestino;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtViaEntidad;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.cboBase cboTipoComp;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtBase txtNroOpOCheque;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtLargoBase dtFechaOp;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtImporte;
        private GEN.BotonesBase.btnGrabar btnGrabarDet;
        private GEN.BotonesBase.btnEditar btnEditarDet;
        private GEN.BotonesBase.btnCancelar btnCancelarDet;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtcRUCEmpleador;
        private GEN.ControlesBase.txtBase txtcEmpleador;
        private GEN.ControlesBase.txtBase txtcCodEmpleador;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.lblBase lblBase16;
        private GEN.ControlesBase.lblBase lblBase17;
        private GEN.ControlesBase.txtNumRea txtMonto;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroCta;
    }
}