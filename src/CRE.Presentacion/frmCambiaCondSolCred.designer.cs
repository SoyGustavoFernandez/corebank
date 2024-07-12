namespace CRE.Presentacion
{
    partial class frmCambiaCondSolCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiaCondSolCred));
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbDato_Solicitud = new GEN.ControlesBase.grbBase(this.components);
            this.chcVerificacion = new GEN.ControlesBase.chcBase(this.components);
            this.conCreditoTasa = new GEN.ControlesBase.ConCreditoTasa();
            this.lblBase24 = new GEN.ControlesBase.lblBase();
            this.txtComentAproba = new GEN.ControlesBase.txtBase(this.components);
            this.lblEvaluacion = new GEN.ControlesBase.lblBase();
            this.cboAsesor = new GEN.ControlesBase.cboPersonalCreditos(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNumEva = new GEN.ControlesBase.txtBase(this.components);
            this.cboOperacionCre = new GEN.ControlesBase.cboOperacionCre(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbBase7 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgExcepciones = new GEN.ControlesBase.dtgBase(this.components);
            this.nNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUsuReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipOpeExc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSustento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecSolici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgHistoricoPropuesta = new GEN.ControlesBase.dtgBase(this.components);
            this.nNumProp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOrigenCredProp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNivelAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCuotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescripTipoPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nPlazoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCuotasGracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDiasGracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaDesembolso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTasaCompensatoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cComentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbDato_Solicitud.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepciones)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistoricoPropuesta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(870, 436);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 80;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbDato_Solicitud
            // 
            this.grbDato_Solicitud.Controls.Add(this.chcVerificacion);
            this.grbDato_Solicitud.Controls.Add(this.conCreditoTasa);
            this.grbDato_Solicitud.Controls.Add(this.lblBase24);
            this.grbDato_Solicitud.Controls.Add(this.txtComentAproba);
            this.grbDato_Solicitud.Location = new System.Drawing.Point(538, 106);
            this.grbDato_Solicitud.Name = "grbDato_Solicitud";
            this.grbDato_Solicitud.Size = new System.Drawing.Size(396, 325);
            this.grbDato_Solicitud.TabIndex = 81;
            this.grbDato_Solicitud.TabStop = false;
            this.grbDato_Solicitud.Text = "DATOS  A MODIFICAR";
            // 
            // chcVerificacion
            // 
            this.chcVerificacion.AutoSize = true;
            this.chcVerificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcVerificacion.ForeColor = System.Drawing.Color.Navy;
            this.chcVerificacion.Location = new System.Drawing.Point(6, 299);
            this.chcVerificacion.Name = "chcVerificacion";
            this.chcVerificacion.Size = new System.Drawing.Size(152, 17);
            this.chcVerificacion.TabIndex = 100;
            this.chcVerificacion.Text = "Visita de verificación?";
            this.chcVerificacion.UseVisualStyleBackColor = true;
            // 
            // conCreditoTasa
            // 
            this.conCreditoTasa.AutoSize = true;
            this.conCreditoTasa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conCreditoTasa.CuotasEnabled = true;
            this.conCreditoTasa.DiasGraciaEnabled = true;
            this.conCreditoTasa.FechaDesembolsoEnabled = true;
            this.conCreditoTasa.lMostrarTodosNivCred = false;
            this.conCreditoTasa.Location = new System.Drawing.Point(9, 19);
            this.conCreditoTasa.Margin = new System.Windows.Forms.Padding(4);
            this.conCreditoTasa.MonedaEnabled = false;
            this.conCreditoTasa.MontoEnabled = true;
            this.conCreditoTasa.Name = "conCreditoTasa";
            this.conCreditoTasa.NivelesProductoEnabled = true;
            this.conCreditoTasa.PlazoCuotaEnabled = true;
            this.conCreditoTasa.Size = new System.Drawing.Size(325, 203);
            this.conCreditoTasa.TabIndex = 99;
            this.conCreditoTasa.TEAEnabled = true;
            this.conCreditoTasa.TipoPeriodoEnabled = true;
            this.conCreditoTasa.TipoTasaCreditoEnabled = true;
            // 
            // lblBase24
            // 
            this.lblBase24.AutoSize = true;
            this.lblBase24.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase24.ForeColor = System.Drawing.Color.Navy;
            this.lblBase24.Location = new System.Drawing.Point(6, 226);
            this.lblBase24.Name = "lblBase24";
            this.lblBase24.Size = new System.Drawing.Size(162, 13);
            this.lblBase24.TabIndex = 98;
            this.lblBase24.Text = "Observaciones del cambio:";
            // 
            // txtComentAproba
            // 
            this.txtComentAproba.Location = new System.Drawing.Point(6, 242);
            this.txtComentAproba.Multiline = true;
            this.txtComentAproba.Name = "txtComentAproba";
            this.txtComentAproba.Size = new System.Drawing.Size(385, 51);
            this.txtComentAproba.TabIndex = 97;
            // 
            // lblEvaluacion
            // 
            this.lblEvaluacion.AutoSize = true;
            this.lblEvaluacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblEvaluacion.ForeColor = System.Drawing.Color.Navy;
            this.lblEvaluacion.Location = new System.Drawing.Point(20, 21);
            this.lblEvaluacion.Name = "lblEvaluacion";
            this.lblEvaluacion.Size = new System.Drawing.Size(97, 13);
            this.lblEvaluacion.TabIndex = 99;
            this.lblEvaluacion.Text = "Evaluación Nro:";
            // 
            // cboAsesor
            // 
            this.cboAsesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesor.Enabled = false;
            this.cboAsesor.FormattingEnabled = true;
            this.cboAsesor.Location = new System.Drawing.Point(114, 41);
            this.cboAsesor.Name = "cboAsesor";
            this.cboAsesor.Size = new System.Drawing.Size(277, 21);
            this.cboAsesor.TabIndex = 7;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(61, 45);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(51, 13);
            this.lblBase10.TabIndex = 2;
            this.lblBase10.Text = "Asesor:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtNumEva);
            this.grbBase2.Controls.Add(this.lblEvaluacion);
            this.grbBase2.Controls.Add(this.cboOperacionCre);
            this.grbBase2.Controls.Add(this.lblBase8);
            this.grbBase2.Controls.Add(this.cboAsesor);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Location = new System.Drawing.Point(538, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(396, 89);
            this.grbBase2.TabIndex = 87;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "DATOS GENERALES";
            // 
            // txtNumEva
            // 
            this.txtNumEva.Enabled = false;
            this.txtNumEva.Location = new System.Drawing.Point(114, 19);
            this.txtNumEva.Name = "txtNumEva";
            this.txtNumEva.Size = new System.Drawing.Size(100, 20);
            this.txtNumEva.TabIndex = 100;
            // 
            // cboOperacionCre
            // 
            this.cboOperacionCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperacionCre.Enabled = false;
            this.cboOperacionCre.FormattingEnabled = true;
            this.cboOperacionCre.Location = new System.Drawing.Point(114, 66);
            this.cboOperacionCre.Name = "cboOperacionCre";
            this.cboOperacionCre.Size = new System.Drawing.Size(277, 21);
            this.cboOperacionCre.TabIndex = 89;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(45, 69);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(70, 13);
            this.lblBase8.TabIndex = 90;
            this.lblBase8.Text = "Operación:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(805, 436);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 88;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbBase7
            // 
            this.grbBase7.Controls.Add(this.dtgExcepciones);
            this.grbBase7.Location = new System.Drawing.Point(12, 12);
            this.grbBase7.Name = "grbBase7";
            this.grbBase7.Size = new System.Drawing.Size(520, 202);
            this.grbBase7.TabIndex = 89;
            this.grbBase7.TabStop = false;
            this.grbBase7.Text = "Excepciones";
            // 
            // dtgExcepciones
            // 
            this.dtgExcepciones.AllowUserToAddRows = false;
            this.dtgExcepciones.AllowUserToDeleteRows = false;
            this.dtgExcepciones.AllowUserToResizeColumns = false;
            this.dtgExcepciones.AllowUserToResizeRows = false;
            this.dtgExcepciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgExcepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgExcepciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nNum,
            this.idSolAproba,
            this.cUsuReg,
            this.cTipOpeExc,
            this.cValida,
            this.cSustento,
            this.dFecSolici});
            this.dtgExcepciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgExcepciones.Location = new System.Drawing.Point(3, 16);
            this.dtgExcepciones.MultiSelect = false;
            this.dtgExcepciones.Name = "dtgExcepciones";
            this.dtgExcepciones.ReadOnly = true;
            this.dtgExcepciones.RowHeadersVisible = false;
            this.dtgExcepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgExcepciones.Size = new System.Drawing.Size(514, 183);
            this.dtgExcepciones.TabIndex = 0;
            // 
            // nNum
            // 
            this.nNum.DataPropertyName = "nNum";
            this.nNum.HeaderText = "N°";
            this.nNum.Name = "nNum";
            this.nNum.ReadOnly = true;
            this.nNum.Width = 44;
            // 
            // idSolAproba
            // 
            this.idSolAproba.DataPropertyName = "idSolAproba";
            this.idSolAproba.HeaderText = "Sol. aprobación";
            this.idSolAproba.Name = "idSolAproba";
            this.idSolAproba.ReadOnly = true;
            this.idSolAproba.Width = 97;
            // 
            // cUsuReg
            // 
            this.cUsuReg.DataPropertyName = "cUsuReg";
            this.cUsuReg.HeaderText = "Usuario solicita";
            this.cUsuReg.Name = "cUsuReg";
            this.cUsuReg.ReadOnly = true;
            this.cUsuReg.Width = 95;
            // 
            // cTipOpeExc
            // 
            this.cTipOpeExc.DataPropertyName = "cTipOpeExc";
            this.cTipOpeExc.HeaderText = "Excepción";
            this.cTipOpeExc.Name = "cTipOpeExc";
            this.cTipOpeExc.ReadOnly = true;
            this.cTipOpeExc.Width = 82;
            // 
            // cValida
            // 
            this.cValida.DataPropertyName = "cValida";
            this.cValida.HeaderText = "Validación";
            this.cValida.Name = "cValida";
            this.cValida.ReadOnly = true;
            this.cValida.Width = 81;
            // 
            // cSustento
            // 
            this.cSustento.DataPropertyName = "cSustento";
            this.cSustento.HeaderText = "Sustento solicita";
            this.cSustento.Name = "cSustento";
            this.cSustento.ReadOnly = true;
            // 
            // dFecSolici
            // 
            this.dFecSolici.DataPropertyName = "dFecSolici";
            this.dFecSolici.HeaderText = "Fec. solicita";
            this.dFecSolici.Name = "dFecSolici";
            this.dFecSolici.ReadOnly = true;
            this.dFecSolici.Width = 81;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgHistoricoPropuesta);
            this.grbBase1.Location = new System.Drawing.Point(12, 220);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(520, 210);
            this.grbBase1.TabIndex = 90;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Historial propuestas";
            // 
            // dtgHistoricoPropuesta
            // 
            this.dtgHistoricoPropuesta.AllowUserToAddRows = false;
            this.dtgHistoricoPropuesta.AllowUserToDeleteRows = false;
            this.dtgHistoricoPropuesta.AllowUserToResizeColumns = false;
            this.dtgHistoricoPropuesta.AllowUserToResizeRows = false;
            this.dtgHistoricoPropuesta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgHistoricoPropuesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistoricoPropuesta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nNumProp,
            this.cOrigenCredProp,
            this.cNivelAproba,
            this.cNombre,
            this.nMonto,
            this.nCuotas,
            this.cDescripTipoPeriodo,
            this.nPlazoCuota,
            this.nCuotasGracia,
            this.nDiasGracia,
            this.dFechaDesembolso,
            this.nTasaCompensatoria,
            this.cComentarios,
            this.dFecReg});
            this.dtgHistoricoPropuesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHistoricoPropuesta.Location = new System.Drawing.Point(3, 16);
            this.dtgHistoricoPropuesta.MultiSelect = false;
            this.dtgHistoricoPropuesta.Name = "dtgHistoricoPropuesta";
            this.dtgHistoricoPropuesta.ReadOnly = true;
            this.dtgHistoricoPropuesta.RowHeadersVisible = false;
            this.dtgHistoricoPropuesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHistoricoPropuesta.Size = new System.Drawing.Size(514, 191);
            this.dtgHistoricoPropuesta.TabIndex = 0;
            // 
            // nNumProp
            // 
            this.nNumProp.DataPropertyName = "nNum";
            this.nNumProp.HeaderText = "N°";
            this.nNumProp.Name = "nNumProp";
            this.nNumProp.ReadOnly = true;
            this.nNumProp.Width = 44;
            // 
            // cOrigenCredProp
            // 
            this.cOrigenCredProp.DataPropertyName = "cOrigenCredProp";
            this.cOrigenCredProp.HeaderText = "Origen";
            this.cOrigenCredProp.Name = "cOrigenCredProp";
            this.cOrigenCredProp.ReadOnly = true;
            this.cOrigenCredProp.Width = 63;
            // 
            // cNivelAproba
            // 
            this.cNivelAproba.DataPropertyName = "cNivelAproba";
            this.cNivelAproba.HeaderText = "Nivel";
            this.cNivelAproba.Name = "cNivelAproba";
            this.cNivelAproba.ReadOnly = true;
            this.cNivelAproba.Width = 56;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.HeaderText = "Usuario registro";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 96;
            // 
            // nMonto
            // 
            this.nMonto.DataPropertyName = "nMonto";
            this.nMonto.HeaderText = "Monto";
            this.nMonto.Name = "nMonto";
            this.nMonto.ReadOnly = true;
            this.nMonto.Width = 62;
            // 
            // nCuotas
            // 
            this.nCuotas.DataPropertyName = "nCuotas";
            this.nCuotas.HeaderText = "Cuotas";
            this.nCuotas.Name = "nCuotas";
            this.nCuotas.ReadOnly = true;
            this.nCuotas.Width = 65;
            // 
            // cDescripTipoPeriodo
            // 
            this.cDescripTipoPeriodo.DataPropertyName = "cDescripTipoPeriodo";
            this.cDescripTipoPeriodo.HeaderText = "Tipo periodo";
            this.cDescripTipoPeriodo.Name = "cDescripTipoPeriodo";
            this.cDescripTipoPeriodo.ReadOnly = true;
            this.cDescripTipoPeriodo.Width = 84;
            // 
            // nPlazoCuota
            // 
            this.nPlazoCuota.DataPropertyName = "nPlazoCuota";
            this.nPlazoCuota.HeaderText = "Plazo cuota";
            this.nPlazoCuota.Name = "nPlazoCuota";
            this.nPlazoCuota.ReadOnly = true;
            this.nPlazoCuota.Width = 81;
            // 
            // nCuotasGracia
            // 
            this.nCuotasGracia.DataPropertyName = "nCuotasGracia";
            this.nCuotasGracia.HeaderText = "Periodos gracia";
            this.nCuotasGracia.Name = "nCuotasGracia";
            this.nCuotasGracia.ReadOnly = true;
            this.nCuotasGracia.Width = 96;
            // 
            // nDiasGracia
            // 
            this.nDiasGracia.DataPropertyName = "nDiasGracia";
            this.nDiasGracia.HeaderText = "Dias gracia";
            this.nDiasGracia.Name = "nDiasGracia";
            this.nDiasGracia.ReadOnly = true;
            this.nDiasGracia.Visible = false;
            this.nDiasGracia.Width = 78;
            // 
            // dFechaDesembolso
            // 
            this.dFechaDesembolso.DataPropertyName = "dFechaDesembolso";
            this.dFechaDesembolso.HeaderText = "Fecha desembolso";
            this.dFechaDesembolso.Name = "dFechaDesembolso";
            this.dFechaDesembolso.ReadOnly = true;
            this.dFechaDesembolso.Width = 111;
            // 
            // nTasaCompensatoria
            // 
            this.nTasaCompensatoria.DataPropertyName = "nTasaCompensatoria";
            this.nTasaCompensatoria.HeaderText = "Tasa";
            this.nTasaCompensatoria.Name = "nTasaCompensatoria";
            this.nTasaCompensatoria.ReadOnly = true;
            this.nTasaCompensatoria.Width = 56;
            // 
            // cComentarios
            // 
            this.cComentarios.DataPropertyName = "cComentarios";
            this.cComentarios.HeaderText = "Comentarios";
            this.cComentarios.Name = "cComentarios";
            this.cComentarios.ReadOnly = true;
            this.cComentarios.Width = 90;
            // 
            // dFecReg
            // 
            this.dFecReg.DataPropertyName = "dFecReg";
            this.dFecReg.HeaderText = "Fecha Registro";
            this.dFecReg.Name = "dFecReg";
            this.dFecReg.ReadOnly = true;
            this.dFecReg.Width = 96;
            // 
            // frmCambiaCondSolCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 510);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase7);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbDato_Solicitud);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCambiaCondSolCred";
            this.Text = "Cambiar condiciones de solicitudes de créditos";
            this.Load += new System.EventHandler(this.frmCambiaCondSolCred_Load);
            this.Controls.SetChildIndex(this.grbDato_Solicitud, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.grbBase7, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbDato_Solicitud.ResumeLayout(false);
            this.grbDato_Solicitud.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgExcepciones)).EndInit();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistoricoPropuesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbDato_Solicitud;
        private GEN.ControlesBase.lblBase lblBase24;
        private GEN.ControlesBase.txtBase txtComentAproba;
        private GEN.ControlesBase.lblBase lblEvaluacion;
        private GEN.ControlesBase.cboPersonalCreditos cboAsesor;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtNumEva;
        private GEN.ControlesBase.cboOperacionCre cboOperacionCre;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.ConCreditoTasa conCreditoTasa;
        private GEN.ControlesBase.chcBase chcVerificacion;
        private GEN.ControlesBase.grbBase grbBase7;
        private GEN.ControlesBase.dtgBase dtgExcepciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolAproba;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUsuReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipOpeExc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSustento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecSolici;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgHistoricoPropuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNumProp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOrigenCredProp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNivelAproba;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCuotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescripTipoPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nPlazoCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCuotasGracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDiasGracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaDesembolso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTasaCompensatoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cComentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecReg;

    }
}

