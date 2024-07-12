namespace GRH.Presentacion
{
    partial class frmCompenHorasExtras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompenHorasExtras));
            this.conBusColaborador = new GEN.ControlesBase.ConBusCol();
            this.dtgSolAprobadas = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtMinutosExtras = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.RBTurnos = new System.Windows.Forms.RadioButton();
            this.RBHoras = new System.Windows.Forms.RadioButton();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.dtHoraFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtHoraInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTurnoUsuario = new GEN.ControlesBase.cboTurnoUsuario(this.components);
            this.dtFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.dtgCompensaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.txtMinCompen = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtFaltaCompensar = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolAprobadas)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCompensaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusColaborador
            // 
            this.conBusColaborador.Location = new System.Drawing.Point(12, 10);
            this.conBusColaborador.Name = "conBusColaborador";
            this.conBusColaborador.Size = new System.Drawing.Size(390, 86);
            this.conBusColaborador.TabIndex = 2;
            this.conBusColaborador.BuscarUsuario += new System.EventHandler(this.conBusCol1_BuscarUsuario);
            // 
            // dtgSolAprobadas
            // 
            this.dtgSolAprobadas.AllowUserToAddRows = false;
            this.dtgSolAprobadas.AllowUserToDeleteRows = false;
            this.dtgSolAprobadas.AllowUserToResizeColumns = false;
            this.dtgSolAprobadas.AllowUserToResizeRows = false;
            this.dtgSolAprobadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolAprobadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolAprobadas.Location = new System.Drawing.Point(12, 134);
            this.dtgSolAprobadas.MultiSelect = false;
            this.dtgSolAprobadas.Name = "dtgSolAprobadas";
            this.dtgSolAprobadas.ReadOnly = true;
            this.dtgSolAprobadas.RowHeadersVisible = false;
            this.dtgSolAprobadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolAprobadas.Size = new System.Drawing.Size(601, 146);
            this.dtgSolAprobadas.TabIndex = 3;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(406, 286);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(145, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Total de Minutos Extras:";
            // 
            // txtMinutosExtras
            // 
            this.txtMinutosExtras.Enabled = false;
            this.txtMinutosExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutosExtras.Location = new System.Drawing.Point(551, 282);
            this.txtMinutosExtras.Name = "txtMinutosExtras";
            this.txtMinutosExtras.Size = new System.Drawing.Size(62, 20);
            this.txtMinutosExtras.TabIndex = 5;
            this.txtMinutosExtras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.RBTurnos);
            this.grbBase1.Controls.Add(this.RBHoras);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.dtHoraFin);
            this.grbBase1.Controls.Add(this.dtHoraInicio);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboTurnoUsuario);
            this.grbBase1.Controls.Add(this.dtFechaFin);
            this.grbBase1.Controls.Add(this.dtFechaInicio);
            this.grbBase1.ForeColor = System.Drawing.Color.Navy;
            this.grbBase1.Location = new System.Drawing.Point(345, 314);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(268, 239);
            this.grbBase1.TabIndex = 6;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos para la Compensación:";
            // 
            // RBTurnos
            // 
            this.RBTurnos.AutoSize = true;
            this.RBTurnos.ForeColor = System.Drawing.Color.Navy;
            this.RBTurnos.Location = new System.Drawing.Point(47, 88);
            this.RBTurnos.Name = "RBTurnos";
            this.RBTurnos.Size = new System.Drawing.Size(80, 17);
            this.RBTurnos.TabIndex = 42;
            this.RBTurnos.TabStop = true;
            this.RBTurnos.Text = "Por Turnos:";
            this.RBTurnos.UseVisualStyleBackColor = true;
            this.RBTurnos.CheckedChanged += new System.EventHandler(this.RBTurnos_CheckedChanged);
            // 
            // RBHoras
            // 
            this.RBHoras.AutoSize = true;
            this.RBHoras.ForeColor = System.Drawing.Color.Navy;
            this.RBHoras.Location = new System.Drawing.Point(47, 143);
            this.RBHoras.Name = "RBHoras";
            this.RBHoras.Size = new System.Drawing.Size(75, 17);
            this.RBHoras.TabIndex = 41;
            this.RBHoras.TabStop = true;
            this.RBHoras.Text = "Por Horas:";
            this.RBHoras.UseVisualStyleBackColor = true;
            this.RBHoras.CheckedChanged += new System.EventHandler(this.RBHoras_CheckedChanged);
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(68, 200);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(59, 13);
            this.lblBase7.TabIndex = 40;
            this.lblBase7.Text = "Hora Fin:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(68, 176);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(74, 13);
            this.lblBase6.TabIndex = 39;
            this.lblBase6.Text = "Hora Inicio:";
            // 
            // dtHoraFin
            // 
            this.dtHoraFin.CustomFormat = "hh:mm tt";
            this.dtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraFin.Location = new System.Drawing.Point(148, 196);
            this.dtHoraFin.Name = "dtHoraFin";
            this.dtHoraFin.ShowUpDown = true;
            this.dtHoraFin.Size = new System.Drawing.Size(88, 20);
            this.dtHoraFin.TabIndex = 38;
            this.dtHoraFin.Value = new System.DateTime(2013, 7, 22, 22, 48, 0, 0);
            // 
            // dtHoraInicio
            // 
            this.dtHoraInicio.CustomFormat = "hh:mm tt";
            this.dtHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraInicio.Location = new System.Drawing.Point(148, 172);
            this.dtHoraInicio.Name = "dtHoraInicio";
            this.dtHoraInicio.ShowUpDown = true;
            this.dtHoraInicio.Size = new System.Drawing.Size(88, 20);
            this.dtHoraInicio.TabIndex = 37;
            this.dtHoraInicio.Value = new System.DateTime(2013, 7, 22, 22, 17, 0, 0);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(27, 61);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 35;
            this.lblBase4.Text = "Fecha Fin:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(26, 37);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 34;
            this.lblBase3.Text = "Fecha Inicio:";
            // 
            // cboTurnoUsuario
            // 
            this.cboTurnoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnoUsuario.FormattingEnabled = true;
            this.cboTurnoUsuario.Location = new System.Drawing.Point(71, 111);
            this.cboTurnoUsuario.Name = "cboTurnoUsuario";
            this.cboTurnoUsuario.Size = new System.Drawing.Size(165, 21);
            this.cboTurnoUsuario.TabIndex = 30;
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(115, 58);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(121, 20);
            this.dtFechaFin.TabIndex = 28;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicio.Location = new System.Drawing.Point(115, 32);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(121, 20);
            this.dtFechaInicio.TabIndex = 27;
            this.dtFechaInicio.Validating += new System.ComponentModel.CancelEventHandler(this.dtFechaInicio_Validating);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(553, 560);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Enabled = false;
            this.btnCancelar1.Location = new System.Drawing.Point(487, 560);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 8;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Enabled = false;
            this.btnNuevo1.Location = new System.Drawing.Point(355, 560);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 10;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Enabled = false;
            this.btnGrabar1.Location = new System.Drawing.Point(421, 560);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 11;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnEnviar1_Click);
            // 
            // dtgCompensaciones
            // 
            this.dtgCompensaciones.AllowUserToAddRows = false;
            this.dtgCompensaciones.AllowUserToDeleteRows = false;
            this.dtgCompensaciones.AllowUserToResizeColumns = false;
            this.dtgCompensaciones.AllowUserToResizeRows = false;
            this.dtgCompensaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgCompensaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCompensaciones.Location = new System.Drawing.Point(12, 335);
            this.dtgCompensaciones.MultiSelect = false;
            this.dtgCompensaciones.Name = "dtgCompensaciones";
            this.dtgCompensaciones.ReadOnly = true;
            this.dtgCompensaciones.RowHeadersVisible = false;
            this.dtgCompensaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCompensaciones.Size = new System.Drawing.Size(316, 171);
            this.dtgCompensaciones.TabIndex = 12;
            // 
            // txtMinCompen
            // 
            this.txtMinCompen.Enabled = false;
            this.txtMinCompen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinCompen.Location = new System.Drawing.Point(274, 507);
            this.txtMinCompen.Name = "txtMinCompen";
            this.txtMinCompen.Size = new System.Drawing.Size(54, 20);
            this.txtMinCompen.TabIndex = 14;
            this.txtMinCompen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(80, 510);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(190, 13);
            this.lblBase5.TabIndex = 15;
            this.lblBase5.Text = "Total de Minutos Compensados:";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(9, 536);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(261, 13);
            this.lblBase8.TabIndex = 17;
            this.lblBase8.Text = "Minutos Disponibles para ser Compensados:";
            // 
            // txtFaltaCompensar
            // 
            this.txtFaltaCompensar.Enabled = false;
            this.txtFaltaCompensar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaltaCompensar.Location = new System.Drawing.Point(274, 533);
            this.txtFaltaCompensar.Name = "txtFaltaCompensar";
            this.txtFaltaCompensar.Size = new System.Drawing.Size(54, 20);
            this.txtFaltaCompensar.TabIndex = 16;
            this.txtFaltaCompensar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase2
            // 
            this.lblBase2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(12, 113);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(601, 19);
            this.lblBase2.TabIndex = 80;
            this.lblBase2.Text = "SOLICITUDES DE HORAS EXTRAS APROBADAS";
            this.lblBase2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBase9
            // 
            this.lblBase9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(12, 314);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(316, 19);
            this.lblBase9.TabIndex = 81;
            this.lblBase9.Text = "COMPENSACIONES ";
            this.lblBase9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(289, 560);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 82;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // frmCompenHorasExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 641);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtFaltaCompensar);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtMinCompen);
            this.Controls.Add(this.dtgCompensaciones);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.txtMinutosExtras);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtgSolAprobadas);
            this.Controls.Add(this.conBusColaborador);
            this.Name = "frmCompenHorasExtras";
            this.Text = "Compensación de Horas Extras";
            this.Load += new System.EventHandler(this.frmCompenHorasExtras_Load);
            this.Controls.SetChildIndex(this.conBusColaborador, 0);
            this.Controls.SetChildIndex(this.dtgSolAprobadas, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.txtMinutosExtras, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.dtgCompensaciones, 0);
            this.Controls.SetChildIndex(this.txtMinCompen, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.txtFaltaCompensar, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolAprobadas)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCompensaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusColaborador;
        private GEN.ControlesBase.dtgBase dtgSolAprobadas;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtMinutosExtras;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.dtpCorto dtHoraFin;
        private GEN.ControlesBase.dtpCorto dtHoraInicio;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTurnoUsuario cboTurnoUsuario;
        private GEN.ControlesBase.dtpCorto dtFechaFin;
        private GEN.ControlesBase.dtpCorto dtFechaInicio;
        private System.Windows.Forms.RadioButton RBTurnos;
        private System.Windows.Forms.RadioButton RBHoras;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.dtgBase dtgCompensaciones;
        private GEN.ControlesBase.txtBase txtMinCompen;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtFaltaCompensar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
    }
}