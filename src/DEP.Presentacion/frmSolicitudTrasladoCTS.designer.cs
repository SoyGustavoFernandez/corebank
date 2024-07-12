namespace DEP.Presentacion
{
    partial class frmSolicitudTrasladoCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudTrasladoCTS));
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboEntidad = new GEN.ControlesBase.cboEntidad(this.components);
            this.cboTipoEntidad = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboEntida = new GEN.ControlesBase.cboEntidad(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.conBusCol = new GEN.ControlesBase.ConBusCol();
            this.cboTipoEntida = new GEN.ControlesBase.cboTipoEntidad(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboMonDestino = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase15 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMonOrigen = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase14 = new GEN.ControlesBase.lblBase();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.chcNuevaSolicitud = new GEN.ControlesBase.chcBase(this.components);
            this.lblUsuario = new GEN.ControlesBase.lblBase();
            this.lblFecSol = new GEN.ControlesBase.lblBase();
            this.tbcBase1 = new GEN.ControlesBase.tbcBase(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.conBusCliEmpleador = new GEN.ControlesBase.ConBusCli();
            this.conBusCliente = new GEN.ControlesBase.ConBusCli();
            this.lblTipPago = new System.Windows.Forms.Label();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblUsuarioSol = new System.Windows.Forms.Label();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.tbcBase1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 69);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(70, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Financiera:";
            // 
            // cboEntidad
            // 
            this.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntidad.DropDownWidth = 380;
            this.cboEntidad.FormattingEnabled = true;
            this.cboEntidad.Location = new System.Drawing.Point(93, 65);
            this.cboEntidad.Name = "cboEntidad";
            this.cboEntidad.Size = new System.Drawing.Size(230, 21);
            this.cboEntidad.TabIndex = 3;
            // 
            // cboTipoEntidad
            // 
            this.cboTipoEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntidad.DropDownWidth = 180;
            this.cboTipoEntidad.FormattingEnabled = true;
            this.cboTipoEntidad.Location = new System.Drawing.Point(93, 41);
            this.cboTipoEntidad.Name = "cboTipoEntidad";
            this.cboTipoEntidad.Size = new System.Drawing.Size(230, 21);
            this.cboTipoEntidad.TabIndex = 2;
            this.cboTipoEntidad.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidad1_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 45);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(82, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Tipo Entidad:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboEntida);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.conBusCol);
            this.grbBase2.Controls.Add(this.cboTipoEntida);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.cboAgencias);
            this.grbBase2.Controls.Add(this.cboMonDestino);
            this.grbBase2.Controls.Add(this.lblBase15);
            this.grbBase2.ForeColor = System.Drawing.Color.Navy;
            this.grbBase2.Location = new System.Drawing.Point(346, 72);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(402, 219);
            this.grbBase2.TabIndex = 2;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos Destino ";
            // 
            // cboEntida
            // 
            this.cboEntida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntida.DropDownWidth = 380;
            this.cboEntida.FormattingEnabled = true;
            this.cboEntida.Location = new System.Drawing.Point(96, 93);
            this.cboEntida.Name = "cboEntida";
            this.cboEntida.Size = new System.Drawing.Size(300, 21);
            this.cboEntida.TabIndex = 12;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(9, 45);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 15;
            this.lblBase4.Text = "Agencia:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 101);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(70, 13);
            this.lblBase1.TabIndex = 13;
            this.lblBase1.Text = "Financiera:";
            // 
            // conBusCol
            // 
            this.conBusCol.Location = new System.Drawing.Point(5, 125);
            this.conBusCol.Name = "conBusCol";
            this.conBusCol.Size = new System.Drawing.Size(386, 86);
            this.conBusCol.TabIndex = 5;
            this.conBusCol.BuscarUsuario += new System.EventHandler(this.conBusCol_BuscarUsuario);
            // 
            // cboTipoEntida
            // 
            this.cboTipoEntida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEntida.DropDownWidth = 180;
            this.cboTipoEntida.FormattingEnabled = true;
            this.cboTipoEntida.Location = new System.Drawing.Point(96, 69);
            this.cboTipoEntida.Name = "cboTipoEntida";
            this.cboTipoEntida.Size = new System.Drawing.Size(300, 21);
            this.cboTipoEntida.TabIndex = 11;
            this.cboTipoEntida.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntida_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(9, 72);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(82, 13);
            this.lblBase5.TabIndex = 14;
            this.lblBase5.Text = "Tipo Entidad:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(96, 41);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(300, 21);
            this.cboAgencias.TabIndex = 5;
            // 
            // cboMonDestino
            // 
            this.cboMonDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonDestino.FormattingEnabled = true;
            this.cboMonDestino.Location = new System.Drawing.Point(96, 17);
            this.cboMonDestino.Name = "cboMonDestino";
            this.cboMonDestino.Size = new System.Drawing.Size(156, 21);
            this.cboMonDestino.TabIndex = 4;
            // 
            // lblBase15
            // 
            this.lblBase15.AutoSize = true;
            this.lblBase15.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase15.ForeColor = System.Drawing.Color.Navy;
            this.lblBase15.Location = new System.Drawing.Point(9, 21);
            this.lblBase15.Name = "lblBase15";
            this.lblBase15.Size = new System.Drawing.Size(56, 13);
            this.lblBase15.TabIndex = 12;
            this.lblBase15.Text = "Moneda:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.cboMonOrigen);
            this.grbBase3.Controls.Add(this.lblBase14);
            this.grbBase3.Controls.Add(this.cboEntidad);
            this.grbBase3.Controls.Add(this.lblBase2);
            this.grbBase3.Controls.Add(this.cboTipoEntidad);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.ForeColor = System.Drawing.Color.Navy;
            this.grbBase3.Location = new System.Drawing.Point(9, 72);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(330, 92);
            this.grbBase3.TabIndex = 1;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos Origen ";
            // 
            // cboMonOrigen
            // 
            this.cboMonOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonOrigen.FormattingEnabled = true;
            this.cboMonOrigen.Location = new System.Drawing.Point(93, 17);
            this.cboMonOrigen.Name = "cboMonOrigen";
            this.cboMonOrigen.Size = new System.Drawing.Size(150, 21);
            this.cboMonOrigen.TabIndex = 1;
            // 
            // lblBase14
            // 
            this.lblBase14.AutoSize = true;
            this.lblBase14.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase14.ForeColor = System.Drawing.Color.Navy;
            this.lblBase14.Location = new System.Drawing.Point(8, 21);
            this.lblBase14.Name = "lblBase14";
            this.lblBase14.Size = new System.Drawing.Size(56, 13);
            this.lblBase14.TabIndex = 10;
            this.lblBase14.Text = "Moneda:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Navy;
            this.lblEstado.Location = new System.Drawing.Point(156, 22);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 13);
            this.lblEstado.TabIndex = 0;
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(20, 22);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(102, 13);
            this.lblBase13.TabIndex = 7;
            this.lblBase13.Text = "Estado Solicitud:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.ForeColor = System.Drawing.Color.Black;
            this.btnEnviar.Location = new System.Drawing.Point(517, 647);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(641, 647);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Location = new System.Drawing.Point(703, 647);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Location = new System.Drawing.Point(579, 647);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chcNuevaSolicitud
            // 
            this.chcNuevaSolicitud.AutoSize = true;
            this.chcNuevaSolicitud.Location = new System.Drawing.Point(16, 648);
            this.chcNuevaSolicitud.Name = "chcNuevaSolicitud";
            this.chcNuevaSolicitud.Size = new System.Drawing.Size(132, 17);
            this.chcNuevaSolicitud.TabIndex = 2;
            this.chcNuevaSolicitud.Text = "Enviar nueva Solicitud";
            this.chcNuevaSolicitud.UseVisualStyleBackColor = true;
            this.chcNuevaSolicitud.Visible = false;
            this.chcNuevaSolicitud.CheckedChanged += new System.EventHandler(this.CBNewSol_CheckedChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblUsuario.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuario.Location = new System.Drawing.Point(20, 43);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(131, 13);
            this.lblUsuario.TabIndex = 19;
            this.lblUsuario.Text = "Personal que Solicitó:";
            this.lblUsuario.Visible = false;
            // 
            // lblFecSol
            // 
            this.lblFecSol.AutoSize = true;
            this.lblFecSol.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblFecSol.ForeColor = System.Drawing.Color.Navy;
            this.lblFecSol.Location = new System.Drawing.Point(386, 22);
            this.lblFecSol.Name = "lblFecSol";
            this.lblFecSol.Size = new System.Drawing.Size(97, 13);
            this.lblFecSol.TabIndex = 23;
            this.lblFecSol.Text = "Fecha Solicitud:";
            this.lblFecSol.Visible = false;
            // 
            // tbcBase1
            // 
            this.tbcBase1.Controls.Add(this.tabPage1);
            this.tbcBase1.Location = new System.Drawing.Point(19, 297);
            this.tbcBase1.Name = "tbcBase1";
            this.tbcBase1.SelectedIndex = 0;
            this.tbcBase1.Size = new System.Drawing.Size(718, 189);
            this.tbcBase1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.conBusCliEmpleador);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(710, 163);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // conBusCliEmpleador
            // 
            this.conBusCliEmpleador.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliEmpleador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliEmpleador.idCli = 0;
            this.conBusCliEmpleador.Location = new System.Drawing.Point(88, 24);
            this.conBusCliEmpleador.Name = "conBusCliEmpleador";
            this.conBusCliEmpleador.Size = new System.Drawing.Size(534, 115);
            this.conBusCliEmpleador.TabIndex = 6;
            this.conBusCliEmpleador.ClicBuscar += new System.EventHandler(this.conBusCliEmpleador_ClicBuscar);
            // 
            // conBusCliente
            // 
            this.conBusCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCliente.ForeColor = System.Drawing.Color.Black;
            this.conBusCliente.idCli = 0;
            this.conBusCliente.Location = new System.Drawing.Point(8, 6);
            this.conBusCliente.Name = "conBusCliente";
            this.conBusCliente.Size = new System.Drawing.Size(537, 110);
            this.conBusCliente.TabIndex = 0;
            this.conBusCliente.ClicBuscar += new System.EventHandler(this.conBusCliente_ClicBuscar_1);
            // 
            // lblTipPago
            // 
            this.lblTipPago.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblTipPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipPago.Location = new System.Drawing.Point(19, 295);
            this.lblTipPago.Name = "lblTipPago";
            this.lblTipPago.Size = new System.Drawing.Size(716, 24);
            this.lblTipPago.TabIndex = 134;
            this.lblTipPago.Text = "CENTRO LABORAL - EMPLEADOR";
            this.lblTipPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblFecha);
            this.grbBase1.Controls.Add(this.lblUsuarioSol);
            this.grbBase1.Controls.Add(this.lblBase13);
            this.grbBase1.Controls.Add(this.lblEstado);
            this.grbBase1.Controls.Add(this.lblTipPago);
            this.grbBase1.Controls.Add(this.tbcBase1);
            this.grbBase1.Controls.Add(this.lblUsuario);
            this.grbBase1.Controls.Add(this.lblFecSol);
            this.grbBase1.Controls.Add(this.grbBase2);
            this.grbBase1.Controls.Add(this.grbBase3);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(7, 122);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(756, 512);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Solicitud";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Navy;
            this.lblFecha.Location = new System.Drawing.Point(491, 22);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 2;
            // 
            // lblUsuarioSol
            // 
            this.lblUsuarioSol.AutoSize = true;
            this.lblUsuarioSol.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioSol.ForeColor = System.Drawing.Color.Navy;
            this.lblUsuarioSol.Location = new System.Drawing.Point(156, 43);
            this.lblUsuarioSol.Name = "lblUsuarioSol";
            this.lblUsuarioSol.Size = new System.Drawing.Size(0, 13);
            this.lblUsuarioSol.TabIndex = 1;
            // 
            // frmSolicitudTrasladoCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 723);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.conBusCliente);
            this.Controls.Add(this.chcNuevaSolicitud);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEnviar);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "frmSolicitudTrasladoCTS";
            this.Text = "Solicitud de Traslado de CTS-Ingreso";
            this.Load += new System.EventHandler(this.frmSolicitudTrasladoCTS_Load);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.chcNuevaSolicitud, 0);
            this.Controls.SetChildIndex(this.conBusCliente, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.tbcBase1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboEntidad cboEntidad;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntidad;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.Label lblEstado;
        private GEN.ControlesBase.lblBase lblBase13;
        private GEN.ControlesBase.cboMoneda cboMonOrigen;
        private GEN.ControlesBase.lblBase lblBase14;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.cboMoneda cboMonDestino;
        private GEN.ControlesBase.lblBase lblBase15;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.chcBase chcNuevaSolicitud;
        private GEN.ControlesBase.lblBase lblUsuario;
        private GEN.ControlesBase.lblBase lblFecSol;
        private GEN.ControlesBase.tbcBase tbcBase1;
        private System.Windows.Forms.TabPage tabPage1;
        private GEN.ControlesBase.ConBusCli conBusCliente;
        private GEN.ControlesBase.ConBusCli conBusCliEmpleador;
        private System.Windows.Forms.Label lblTipPago;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.Label lblUsuarioSol;
        private System.Windows.Forms.Label lblFecha;
        private GEN.ControlesBase.ConBusCol conBusCol;
        private GEN.ControlesBase.cboEntidad cboEntida;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboTipoEntidad cboTipoEntida;
        private GEN.ControlesBase.lblBase lblBase5;
    }
}