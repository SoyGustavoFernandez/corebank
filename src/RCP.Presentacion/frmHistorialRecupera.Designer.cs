namespace RCP.Presentacion
{
    partial class frmHistorialRecupera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialRecupera));
            this.conBusCli1 = new GEN.ControlesBase.ConBusCli();
            this.dtgEventos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnRegEvento = new GEN.BotonesBase.Boton();
            this.btnDatCli = new GEN.BotonesBase.Boton();
            this.btnDirRecupera = new GEN.BotonesBase.Boton();
            this.btnPosCli = new GEN.BotonesBase.Boton();
            this.btnCartas = new GEN.BotonesBase.Boton();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgCreditos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnPosIntegral = new GEN.BotonesBase.Boton();
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.btnFiltrar1 = new GEN.BotonesBase.btnFiltrar();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cboActividad = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblBaseNegativa = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEventos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.grbFiltros.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // conBusCli1
            // 
            this.conBusCli1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conBusCli1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conBusCli1.idCli = 0;
            this.conBusCli1.Location = new System.Drawing.Point(18, 12);
            this.conBusCli1.Name = "conBusCli1";
            this.conBusCli1.Size = new System.Drawing.Size(532, 105);
            this.conBusCli1.TabIndex = 0;
            this.conBusCli1.ClicBuscar += new System.EventHandler(this.conBusCli1_ClicBuscar);
            // 
            // dtgEventos
            // 
            this.dtgEventos.AllowUserToAddRows = false;
            this.dtgEventos.AllowUserToDeleteRows = false;
            this.dtgEventos.AllowUserToResizeColumns = false;
            this.dtgEventos.AllowUserToResizeRows = false;
            this.dtgEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEventos.Location = new System.Drawing.Point(3, 16);
            this.dtgEventos.MultiSelect = false;
            this.dtgEventos.Name = "dtgEventos";
            this.dtgEventos.ReadOnly = true;
            this.dtgEventos.RowHeadersVisible = false;
            this.dtgEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEventos.Size = new System.Drawing.Size(972, 207);
            this.dtgEventos.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(945, 623);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 11;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(813, 623);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 9;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnRegEvento
            // 
            this.btnRegEvento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegEvento.Location = new System.Drawing.Point(681, 623);
            this.btnRegEvento.Name = "btnRegEvento";
            this.btnRegEvento.Size = new System.Drawing.Size(60, 50);
            this.btnRegEvento.TabIndex = 7;
            this.btnRegEvento.Text = "Reg. Evento";
            this.btnRegEvento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegEvento.UseVisualStyleBackColor = true;
            this.btnRegEvento.Click += new System.EventHandler(this.btnRegEvento_Click);
            // 
            // btnDatCli
            // 
            this.btnDatCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDatCli.Location = new System.Drawing.Point(483, 623);
            this.btnDatCli.Name = "btnDatCli";
            this.btnDatCli.Size = new System.Drawing.Size(60, 50);
            this.btnDatCli.TabIndex = 4;
            this.btnDatCli.Text = "Datos del Cliente";
            this.btnDatCli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDatCli.UseVisualStyleBackColor = true;
            this.btnDatCli.Click += new System.EventHandler(this.btnDatCli_Click);
            // 
            // btnDirRecupera
            // 
            this.btnDirRecupera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDirRecupera.Location = new System.Drawing.Point(549, 623);
            this.btnDirRecupera.Name = "btnDirRecupera";
            this.btnDirRecupera.Size = new System.Drawing.Size(60, 50);
            this.btnDirRecupera.TabIndex = 5;
            this.btnDirRecupera.Text = "Dirección Recuperaciones";
            this.btnDirRecupera.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDirRecupera.UseVisualStyleBackColor = true;
            this.btnDirRecupera.Click += new System.EventHandler(this.btnDirRecupera_Click);
            // 
            // btnPosCli
            // 
            this.btnPosCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPosCli.Location = new System.Drawing.Point(615, 623);
            this.btnPosCli.Name = "btnPosCli";
            this.btnPosCli.Size = new System.Drawing.Size(60, 50);
            this.btnPosCli.TabIndex = 6;
            this.btnPosCli.Text = "Posición de Cliente";
            this.btnPosCli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPosCli.UseVisualStyleBackColor = true;
            this.btnPosCli.Click += new System.EventHandler(this.btnPosCli_Click);
            // 
            // btnCartas
            // 
            this.btnCartas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCartas.Location = new System.Drawing.Point(747, 623);
            this.btnCartas.Name = "btnCartas";
            this.btnCartas.Size = new System.Drawing.Size(60, 50);
            this.btnCartas.TabIndex = 8;
            this.btnCartas.Text = "Notificaciones Enviadas";
            this.btnCartas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCartas.UseVisualStyleBackColor = true;
            this.btnCartas.Click += new System.EventHandler(this.btnCartas_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(879, 623);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 10;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgEventos);
            this.groupBox1.Location = new System.Drawing.Point(9, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 226);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgCreditos);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(996, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Créditos";
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.AllowUserToResizeColumns = false;
            this.dtgCreditos.AllowUserToResizeRows = false;
            this.dtgCreditos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCreditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditos.Location = new System.Drawing.Point(3, 16);
            this.dtgCreditos.MultiSelect = false;
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.ReadOnly = true;
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(990, 121);
            this.dtgCreditos.TabIndex = 0;
            this.dtgCreditos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCreditos_CellEnter);
            // 
            // btnPosIntegral
            // 
            this.btnPosIntegral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPosIntegral.Location = new System.Drawing.Point(417, 623);
            this.btnPosIntegral.Name = "btnPosIntegral";
            this.btnPosIntegral.Size = new System.Drawing.Size(60, 50);
            this.btnPosIntegral.TabIndex = 3;
            this.btnPosIntegral.Text = "Posición integral";
            this.btnPosIntegral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPosIntegral.UseVisualStyleBackColor = true;
            this.btnPosIntegral.Click += new System.EventHandler(this.btnPosIntegral_Click);
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.btnFiltrar1);
            this.grbFiltros.Controls.Add(this.dtpFechaFin);
            this.grbFiltros.Controls.Add(this.dtpFechaInicio);
            this.grbFiltros.Controls.Add(this.cboActividad);
            this.grbFiltros.Controls.Add(this.lblBase4);
            this.grbFiltros.Controls.Add(this.lblBase3);
            this.grbFiltros.Controls.Add(this.lblBase1);
            this.grbFiltros.Location = new System.Drawing.Point(6, 19);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(981, 83);
            this.grbFiltros.TabIndex = 0;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros";
            // 
            // btnFiltrar1
            // 
            this.btnFiltrar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiltrar1.BackgroundImage")));
            this.btnFiltrar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFiltrar1.Location = new System.Drawing.Point(580, 22);
            this.btnFiltrar1.Name = "btnFiltrar1";
            this.btnFiltrar1.Size = new System.Drawing.Size(60, 50);
            this.btnFiltrar1.TabIndex = 3;
            this.btnFiltrar1.Text = "Filtrar";
            this.btnFiltrar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltrar1.UseVisualStyleBackColor = true;
            this.btnFiltrar1.Click += new System.EventHandler(this.btnFiltrar1_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(374, 49);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 2;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(100, 49);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // cboActividad
            // 
            this.cboActividad.FormattingEnabled = true;
            this.cboActividad.Location = new System.Drawing.Point(100, 22);
            this.cboActividad.Name = "cboActividad";
            this.cboActividad.Size = new System.Drawing.Size(474, 21);
            this.cboActividad.TabIndex = 0;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(305, 52);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(63, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Fecha fin:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(14, 53);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Fecha Inicio:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(30, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(64, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Actividad:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grbFiltros);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(993, 348);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gesitones, Eventos y operaciones";
            // 
            // lblBaseNegativa
            // 
            this.lblBaseNegativa.AutoSize = true;
            this.lblBaseNegativa.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblBaseNegativa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBaseNegativa.Location = new System.Drawing.Point(18, 627);
            this.lblBaseNegativa.Name = "lblBaseNegativa";
            this.lblBaseNegativa.Size = new System.Drawing.Size(0, 17);
            this.lblBaseNegativa.TabIndex = 13;
            // 
            // frmHistorialRecupera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.Controls.Add(this.lblBaseNegativa);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnPosIntegral);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnCartas);
            this.Controls.Add(this.btnPosCli);
            this.Controls.Add(this.btnDirRecupera);
            this.Controls.Add(this.btnDatCli);
            this.Controls.Add(this.btnRegEvento);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.conBusCli1);
            this.Name = "frmHistorialRecupera";
            this.Text = "Historial de Recuperaciones de Cliente";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.conBusCli1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.btnRegEvento, 0);
            this.Controls.SetChildIndex(this.btnDatCli, 0);
            this.Controls.SetChildIndex(this.btnDirRecupera, 0);
            this.Controls.SetChildIndex(this.btnPosCli, 0);
            this.Controls.SetChildIndex(this.btnCartas, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnPosIntegral, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.lblBaseNegativa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEventos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCli conBusCli1;
        private GEN.ControlesBase.dtgBase dtgEventos;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.Boton btnRegEvento;
        private GEN.BotonesBase.Boton btnDatCli;
        private GEN.BotonesBase.Boton btnDirRecupera;
        private GEN.BotonesBase.Boton btnPosCli;
        private GEN.BotonesBase.Boton btnCartas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgCreditos;
        private GEN.BotonesBase.Boton btnPosIntegral;
        private System.Windows.Forms.GroupBox grbFiltros;
        private GEN.ControlesBase.cboBase cboActividad;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        public GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnFiltrar btnFiltrar1;
        private GEN.ControlesBase.lblBaseCustom lblBaseNegativa;
    }
}

