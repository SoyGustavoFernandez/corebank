namespace GRH.Presentacion
{
    partial class frmSolicitudPermiso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudPermiso));
            this.conBusPersonal = new GEN.ControlesBase.ConBusCol();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFechaFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboTipoPermiso = new GEN.ControlesBase.cboTipoPermiso(this.components);
            this.cboTurnoUsuario = new GEN.ControlesBase.cboTurnoUsuario(this.components);
            this.cboMotivoInasistencia = new GEN.ControlesBase.cboMotivoInasistencia(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgPermisosUsuario = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgtxtIdPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdTipoPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtTipoPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdDetalleHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtIdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgtxtEstadoSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEliminar = new GEN.BotonesBase.btnEliminar();
            this.dtpHoraInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpHoraFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.conBusPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPermisosUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusPersonal
            // 
            this.conBusPersonal.Controls.Add(this.grbBase1);
            this.conBusPersonal.Location = new System.Drawing.Point(47, 4);
            this.conBusPersonal.Name = "conBusPersonal";
            this.conBusPersonal.Size = new System.Drawing.Size(390, 86);
            this.conBusPersonal.TabIndex = 3;
            // 
            // grbBase1
            // 
            this.grbBase1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbBase1.Location = new System.Drawing.Point(0, 0);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(387, 86);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Colaborador";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(100, 299);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaInicio.TabIndex = 5;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(100, 323);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpFechaFinal.TabIndex = 6;
            this.dtpFechaFinal.ValueChanged += new System.EventHandler(this.dtpFechaFinal_ValueChanged);
            // 
            // cboTipoPermiso
            // 
            this.cboTipoPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPermiso.FormattingEnabled = true;
            this.cboTipoPermiso.Location = new System.Drawing.Point(100, 275);
            this.cboTipoPermiso.Name = "cboTipoPermiso";
            this.cboTipoPermiso.Size = new System.Drawing.Size(95, 21);
            this.cboTipoPermiso.TabIndex = 7;
            this.cboTipoPermiso.SelectedIndexChanged += new System.EventHandler(this.cboTipoPermiso_SelectedIndexChanged);
            // 
            // cboTurnoUsuario
            // 
            this.cboTurnoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnoUsuario.FormattingEnabled = true;
            this.cboTurnoUsuario.Location = new System.Drawing.Point(263, 299);
            this.cboTurnoUsuario.Name = "cboTurnoUsuario";
            this.cboTurnoUsuario.Size = new System.Drawing.Size(212, 21);
            this.cboTurnoUsuario.TabIndex = 8;
            this.cboTurnoUsuario.SelectedIndexChanged += new System.EventHandler(this.cboTurnoUsuario_SelectedIndexChanged);
            // 
            // cboMotivoInasistencia
            // 
            this.cboMotivoInasistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivoInasistencia.FormattingEnabled = true;
            this.cboMotivoInasistencia.Location = new System.Drawing.Point(263, 275);
            this.cboMotivoInasistencia.Name = "cboMotivoInasistencia";
            this.cboMotivoInasistencia.Size = new System.Drawing.Size(212, 21);
            this.cboMotivoInasistencia.TabIndex = 9;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 278);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(86, 13);
            this.lblBase1.TabIndex = 10;
            this.lblBase1.Text = "Tipo Permiso:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(209, 278);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(49, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "Motivo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(10, 303);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(80, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Fecha Inicio:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 327);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(65, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Fecha Fin:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(209, 303);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(45, 13);
            this.lblBase5.TabIndex = 14;
            this.lblBase5.Text = "Turno:";
            // 
            // dtgPermisosUsuario
            // 
            this.dtgPermisosUsuario.AllowUserToAddRows = false;
            this.dtgPermisosUsuario.AllowUserToDeleteRows = false;
            this.dtgPermisosUsuario.AllowUserToResizeColumns = false;
            this.dtgPermisosUsuario.AllowUserToResizeRows = false;
            this.dtgPermisosUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPermisosUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPermisosUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPermisosUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgtxtIdPermiso,
            this.dtgtxtIdUsuario,
            this.dtgtxtIdTipoPermiso,
            this.dtgtxtTipoPermiso,
            this.dtgtxtIdMotivo,
            this.dtgtxtMotivo,
            this.dtgtxtFechaInicio,
            this.dtgtxtFechaFin,
            this.dtgtxtIdDetalleHorario,
            this.dtgtxtHoraInicio,
            this.dtgtxtHoraFin,
            this.dtgtxtIdEstado,
            this.dtgtxtEstadoSol});
            this.dtgPermisosUsuario.Location = new System.Drawing.Point(10, 99);
            this.dtgPermisosUsuario.MultiSelect = false;
            this.dtgPermisosUsuario.Name = "dtgPermisosUsuario";
            this.dtgPermisosUsuario.ReadOnly = true;
            this.dtgPermisosUsuario.RowHeadersVisible = false;
            this.dtgPermisosUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPermisosUsuario.Size = new System.Drawing.Size(465, 167);
            this.dtgPermisosUsuario.TabIndex = 15;
            this.dtgPermisosUsuario.SelectionChanged += new System.EventHandler(this.dtgPermisosUsuario_SelectionChanged);
            // 
            // dtgtxtIdPermiso
            // 
            this.dtgtxtIdPermiso.DataPropertyName = "idPermiso";
            this.dtgtxtIdPermiso.HeaderText = "idPermiso";
            this.dtgtxtIdPermiso.Name = "dtgtxtIdPermiso";
            this.dtgtxtIdPermiso.ReadOnly = true;
            this.dtgtxtIdPermiso.Visible = false;
            // 
            // dtgtxtIdUsuario
            // 
            this.dtgtxtIdUsuario.DataPropertyName = "idUsuario";
            this.dtgtxtIdUsuario.HeaderText = "idUsuario";
            this.dtgtxtIdUsuario.Name = "dtgtxtIdUsuario";
            this.dtgtxtIdUsuario.ReadOnly = true;
            this.dtgtxtIdUsuario.Visible = false;
            // 
            // dtgtxtIdTipoPermiso
            // 
            this.dtgtxtIdTipoPermiso.DataPropertyName = "idTipoPermiso";
            this.dtgtxtIdTipoPermiso.HeaderText = "idTipoPermiso";
            this.dtgtxtIdTipoPermiso.Name = "dtgtxtIdTipoPermiso";
            this.dtgtxtIdTipoPermiso.ReadOnly = true;
            this.dtgtxtIdTipoPermiso.Visible = false;
            // 
            // dtgtxtTipoPermiso
            // 
            this.dtgtxtTipoPermiso.DataPropertyName = "cTipoPermiso";
            this.dtgtxtTipoPermiso.FillWeight = 75.08636F;
            this.dtgtxtTipoPermiso.HeaderText = "Tipo de Permiso";
            this.dtgtxtTipoPermiso.Name = "dtgtxtTipoPermiso";
            this.dtgtxtTipoPermiso.ReadOnly = true;
            // 
            // dtgtxtIdMotivo
            // 
            this.dtgtxtIdMotivo.DataPropertyName = "idMotivo";
            this.dtgtxtIdMotivo.HeaderText = "idMotivo";
            this.dtgtxtIdMotivo.Name = "dtgtxtIdMotivo";
            this.dtgtxtIdMotivo.ReadOnly = true;
            this.dtgtxtIdMotivo.Visible = false;
            // 
            // dtgtxtMotivo
            // 
            this.dtgtxtMotivo.DataPropertyName = "cMotivo";
            this.dtgtxtMotivo.FillWeight = 156.0802F;
            this.dtgtxtMotivo.HeaderText = "Motivo";
            this.dtgtxtMotivo.Name = "dtgtxtMotivo";
            this.dtgtxtMotivo.ReadOnly = true;
            // 
            // dtgtxtFechaInicio
            // 
            this.dtgtxtFechaInicio.DataPropertyName = "dFechaInicio";
            this.dtgtxtFechaInicio.FillWeight = 95.79164F;
            this.dtgtxtFechaInicio.HeaderText = "Fecha Inicio";
            this.dtgtxtFechaInicio.Name = "dtgtxtFechaInicio";
            this.dtgtxtFechaInicio.ReadOnly = true;
            // 
            // dtgtxtFechaFin
            // 
            this.dtgtxtFechaFin.DataPropertyName = "dFechaFin";
            this.dtgtxtFechaFin.FillWeight = 95.14371F;
            this.dtgtxtFechaFin.HeaderText = "Fecha Fin";
            this.dtgtxtFechaFin.Name = "dtgtxtFechaFin";
            this.dtgtxtFechaFin.ReadOnly = true;
            // 
            // dtgtxtIdDetalleHorario
            // 
            this.dtgtxtIdDetalleHorario.DataPropertyName = "idDetalleHorario";
            this.dtgtxtIdDetalleHorario.HeaderText = "idDetalleHorario";
            this.dtgtxtIdDetalleHorario.Name = "dtgtxtIdDetalleHorario";
            this.dtgtxtIdDetalleHorario.ReadOnly = true;
            this.dtgtxtIdDetalleHorario.Visible = false;
            // 
            // dtgtxtHoraInicio
            // 
            this.dtgtxtHoraInicio.DataPropertyName = "cHoraInicio";
            this.dtgtxtHoraInicio.FillWeight = 55.37761F;
            this.dtgtxtHoraInicio.HeaderText = "Hora Inicio";
            this.dtgtxtHoraInicio.Name = "dtgtxtHoraInicio";
            this.dtgtxtHoraInicio.ReadOnly = true;
            // 
            // dtgtxtHoraFin
            // 
            this.dtgtxtHoraFin.DataPropertyName = "cHoraFin";
            this.dtgtxtHoraFin.FillWeight = 55.37761F;
            this.dtgtxtHoraFin.HeaderText = "Hora Fin";
            this.dtgtxtHoraFin.Name = "dtgtxtHoraFin";
            this.dtgtxtHoraFin.ReadOnly = true;
            this.dtgtxtHoraFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgtxtHoraFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dtgtxtIdEstado
            // 
            this.dtgtxtIdEstado.DataPropertyName = "idEstado";
            this.dtgtxtIdEstado.HeaderText = "idEstado";
            this.dtgtxtIdEstado.Name = "dtgtxtIdEstado";
            this.dtgtxtIdEstado.ReadOnly = true;
            this.dtgtxtIdEstado.Visible = false;
            // 
            // dtgtxtEstadoSol
            // 
            this.dtgtxtEstadoSol.DataPropertyName = "cEstadoSol";
            this.dtgtxtEstadoSol.FillWeight = 110.274F;
            this.dtgtxtEstadoSol.HeaderText = "Estado Solicitud";
            this.dtgtxtEstadoSol.Name = "dtgtxtEstadoSol";
            this.dtgtxtEstadoSol.ReadOnly = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(175, 360);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(295, 360);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 18;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(355, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(415, 360);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Location = new System.Drawing.Point(235, 360);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 50);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm";
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(287, 323);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(58, 20);
            this.dtpHoraInicio.TabIndex = 23;
            this.dtpHoraInicio.Value = new System.DateTime(2013, 7, 22, 22, 17, 0, 0);
            // 
            // dtpHoraFinal
            // 
            this.dtpHoraFinal.CustomFormat = "HH:mm";
            this.dtpHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFinal.Location = new System.Drawing.Point(417, 323);
            this.dtpHoraFinal.Name = "dtpHoraFinal";
            this.dtpHoraFinal.ShowUpDown = true;
            this.dtpHoraFinal.Size = new System.Drawing.Size(58, 20);
            this.dtpHoraFinal.TabIndex = 24;
            this.dtpHoraFinal.Value = new System.DateTime(2013, 7, 22, 22, 48, 0, 0);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(209, 327);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(74, 13);
            this.lblBase6.TabIndex = 25;
            this.lblBase6.Text = "Hora Inicio:";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(355, 327);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(59, 13);
            this.lblBase7.TabIndex = 26;
            this.lblBase7.Text = "Hora Fin:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(115, 360);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmSolicitudPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 435);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.dtpHoraFinal);
            this.Controls.Add(this.dtpHoraInicio);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtgPermisosUsuario);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboMotivoInasistencia);
            this.Controls.Add(this.cboTurnoUsuario);
            this.Controls.Add(this.cboTipoPermiso);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.conBusPersonal);
            this.Name = "frmSolicitudPermiso";
            this.Text = "Solicitud de Permiso";
            this.Load += new System.EventHandler(this.frmSolicitudPermiso_Load);
            this.Controls.SetChildIndex(this.conBusPersonal, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtpFechaFinal, 0);
            this.Controls.SetChildIndex(this.cboTipoPermiso, 0);
            this.Controls.SetChildIndex(this.cboTurnoUsuario, 0);
            this.Controls.SetChildIndex(this.cboMotivoInasistencia, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.dtgPermisosUsuario, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.dtpHoraInicio, 0);
            this.Controls.SetChildIndex(this.dtpHoraFinal, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.conBusPersonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPermisosUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.ConBusCol conBusPersonal;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.dtpCorto dtpFechaFinal;
        private GEN.ControlesBase.cboTipoPermiso cboTipoPermiso;
        private GEN.ControlesBase.cboTurnoUsuario cboTurnoUsuario;
        private GEN.ControlesBase.cboMotivoInasistencia cboMotivoInasistencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgPermisosUsuario;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnEliminar btnEliminar;
        private GEN.ControlesBase.dtpCorto dtpHoraFinal;
        private GEN.ControlesBase.dtpCorto dtpHoraInicio;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdTipoPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtTipoPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdDetalleHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtHoraFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtIdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgtxtEstadoSol;
        private GEN.BotonesBase.btnImprimir btnImprimir;
    }
}

