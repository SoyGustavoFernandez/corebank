namespace ADM.Presentacion
{
    partial class frmAprobacionSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAprobacionSolicitud));
            this.dtgLisSoliciAproba = new GEN.ControlesBase.dtgBase(this.components);
            this.idSolAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idNivelAprRanOpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuRegist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomUsuReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSimbolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nValAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSustento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecSolici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cWinUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecVenSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOpinion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lAprob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lSoloComent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOrdenAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new GEN.BotonesBase.btnActualizar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnRechazar = new GEN.BotonesBase.btnRechazar();
            this.btnAprobar = new GEN.BotonesBase.btnAprobar();
            this.txtNomCliente = new GEN.ControlesBase.txtBase(this.components);
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.txtIdSolAproba = new GEN.ControlesBase.txtBase(this.components);
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.txtValAproba = new GEN.ControlesBase.txtBase(this.components);
            this.txtDocument = new GEN.ControlesBase.txtBase(this.components);
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.txtSustento = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtOpinion = new GEN.ControlesBase.txtBase(this.components);
            this.txtTipoOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.txtFecSolici = new GEN.ControlesBase.txtBase(this.components);
            this.chcAprob = new GEN.ControlesBase.chcBase(this.components);
            this.btnDevolver = new GEN.BotonesBase.btnDevolver(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSubsanar = new GEN.BotonesBase.btnMiniAcept(this.components);
            this.btnEditObs = new GEN.BotonesBase.btnMiniEditar();
            this.btnQuitObs = new GEN.BotonesBase.btnMiniQuitar();
            this.btnAddObs = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgObservaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.cTipObsSol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lSubsanado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.tlpDecision = new System.Windows.Forms.TableLayoutPanel();
            this.pnlOpinion = new System.Windows.Forms.Panel();
            this.pnlRechazoCred = new System.Windows.Forms.Panel();
            this.cboMotRechazo = new GEN.ControlesBase.cboMotRechazoSolCreEval(this.components);
            this.lblMotRechazo = new GEN.ControlesBase.lblBase();
            this.conImpFormatEval = new GEN.ControlesBase.ConImpFormatEval();
            this.btnImpActAprob = new GEN.BotonesBase.btnImprimir();
            this.btnConsultarSolCondonacion = new GEN.BotonesBase.btnConsultar();
            this.cboTipoOperacion = new System.Windows.Forms.ComboBox();
            this.lblBase12 = new GEN.ControlesBase.lblBase();
            this.lblBase13 = new GEN.ControlesBase.lblBase();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerAdjuntos = new GEN.BotonesBase.btnAdjuntarFile(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisSoliciAproba)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).BeginInit();
            this.tlpDecision.SuspendLayout();
            this.pnlOpinion.SuspendLayout();
            this.pnlRechazoCred.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgLisSoliciAproba
            // 
            this.dtgLisSoliciAproba.AllowUserToAddRows = false;
            this.dtgLisSoliciAproba.AllowUserToDeleteRows = false;
            this.dtgLisSoliciAproba.AllowUserToResizeColumns = false;
            this.dtgLisSoliciAproba.AllowUserToResizeRows = false;
            this.dtgLisSoliciAproba.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLisSoliciAproba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLisSoliciAproba.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSolAproba,
            this.idNivelAprRanOpe,
            this.idAgencia,
            this.cNombreAge,
            this.idUsuRegist,
            this.cNomUsuReg,
            this.idTipoOperacion,
            this.cTipoOperacion,
            this.idCliente,
            this.cNomCliente,
            this.idProducto,
            this.cProducto,
            this.idMoneda,
            this.cMoneda,
            this.cSimbolo,
            this.nValAproba,
            this.idDocument,
            this.idMotivo,
            this.cMotivo,
            this.cSustento,
            this.dFecSolici,
            this.cWinUser,
            this.dFecVenSol,
            this.cOpinion,
            this.lAprob,
            this.lSoloComent,
            this.nOrdenAprobacion});
            this.dtgLisSoliciAproba.Location = new System.Drawing.Point(8, 43);
            this.dtgLisSoliciAproba.MultiSelect = false;
            this.dtgLisSoliciAproba.Name = "dtgLisSoliciAproba";
            this.dtgLisSoliciAproba.ReadOnly = true;
            this.dtgLisSoliciAproba.RowHeadersVisible = false;
            this.dtgLisSoliciAproba.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLisSoliciAproba.Size = new System.Drawing.Size(668, 203);
            this.dtgLisSoliciAproba.TabIndex = 2;
            this.dtgLisSoliciAproba.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgLisSoliciAproba_CellMouseUp);
            this.dtgLisSoliciAproba.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLisSoliciAproba_RowEnter);
            this.dtgLisSoliciAproba.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dtgLisSoliciAproba_RowPrePaint);
            // 
            // idSolAproba
            // 
            this.idSolAproba.DataPropertyName = "idSolAproba";
            this.idSolAproba.FillWeight = 53.91773F;
            this.idSolAproba.HeaderText = "Nro Sol.";
            this.idSolAproba.Name = "idSolAproba";
            this.idSolAproba.ReadOnly = true;
            // 
            // idNivelAprRanOpe
            // 
            this.idNivelAprRanOpe.DataPropertyName = "idNivelAprRanOpe";
            this.idNivelAprRanOpe.HeaderText = "Nivel Aprobación";
            this.idNivelAprRanOpe.Name = "idNivelAprRanOpe";
            this.idNivelAprRanOpe.ReadOnly = true;
            this.idNivelAprRanOpe.Visible = false;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "Id Agencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // cNombreAge
            // 
            this.cNombreAge.DataPropertyName = "cNombreAge";
            this.cNombreAge.FillWeight = 114.7846F;
            this.cNombreAge.HeaderText = "Agencia";
            this.cNombreAge.Name = "cNombreAge";
            this.cNombreAge.ReadOnly = true;
            // 
            // idUsuRegist
            // 
            this.idUsuRegist.DataPropertyName = "idUsuRegist";
            this.idUsuRegist.HeaderText = "Id Usuario Solicitante";
            this.idUsuRegist.Name = "idUsuRegist";
            this.idUsuRegist.ReadOnly = true;
            this.idUsuRegist.Visible = false;
            // 
            // cNomUsuReg
            // 
            this.cNomUsuReg.DataPropertyName = "cNomUsuReg";
            this.cNomUsuReg.FillWeight = 156.8431F;
            this.cNomUsuReg.HeaderText = "Usuario Solicitante";
            this.cNomUsuReg.Name = "cNomUsuReg";
            this.cNomUsuReg.ReadOnly = true;
            // 
            // idTipoOperacion
            // 
            this.idTipoOperacion.DataPropertyName = "idTipoOperacion";
            this.idTipoOperacion.HeaderText = "Id Tipo Operacion";
            this.idTipoOperacion.Name = "idTipoOperacion";
            this.idTipoOperacion.ReadOnly = true;
            this.idTipoOperacion.Visible = false;
            // 
            // cTipoOperacion
            // 
            this.cTipoOperacion.DataPropertyName = "cTipoOperacion";
            this.cTipoOperacion.FillWeight = 114.7321F;
            this.cTipoOperacion.HeaderText = "Operación";
            this.cTipoOperacion.Name = "cTipoOperacion";
            this.cTipoOperacion.ReadOnly = true;
            // 
            // idCliente
            // 
            this.idCliente.DataPropertyName = "idCliente";
            this.idCliente.HeaderText = "Id Cliente";
            this.idCliente.Name = "idCliente";
            this.idCliente.ReadOnly = true;
            this.idCliente.Visible = false;
            // 
            // cNomCliente
            // 
            this.cNomCliente.DataPropertyName = "cNomCliente";
            this.cNomCliente.HeaderText = "Cliente";
            this.cNomCliente.Name = "cNomCliente";
            this.cNomCliente.ReadOnly = true;
            this.cNomCliente.Visible = false;
            // 
            // idProducto
            // 
            this.idProducto.DataPropertyName = "idProducto";
            this.idProducto.HeaderText = "Id Producto";
            this.idProducto.Name = "idProducto";
            this.idProducto.ReadOnly = true;
            this.idProducto.Visible = false;
            // 
            // cProducto
            // 
            this.cProducto.DataPropertyName = "cProducto";
            this.cProducto.HeaderText = "Producto";
            this.cProducto.Name = "cProducto";
            this.cProducto.ReadOnly = true;
            this.cProducto.Visible = false;
            // 
            // idMoneda
            // 
            this.idMoneda.DataPropertyName = "idMoneda";
            this.idMoneda.HeaderText = "Id Moneda";
            this.idMoneda.Name = "idMoneda";
            this.idMoneda.ReadOnly = true;
            this.idMoneda.Visible = false;
            // 
            // cMoneda
            // 
            this.cMoneda.DataPropertyName = "cMoneda";
            this.cMoneda.FillWeight = 100.3944F;
            this.cMoneda.HeaderText = "Moneda";
            this.cMoneda.Name = "cMoneda";
            this.cMoneda.ReadOnly = true;
            // 
            // cSimbolo
            // 
            this.cSimbolo.DataPropertyName = "cSimbolo";
            this.cSimbolo.FillWeight = 20F;
            this.cSimbolo.HeaderText = "Simbolo";
            this.cSimbolo.Name = "cSimbolo";
            this.cSimbolo.ReadOnly = true;
            this.cSimbolo.Visible = false;
            // 
            // nValAproba
            // 
            this.nValAproba.DataPropertyName = "nValAproba";
            this.nValAproba.FillWeight = 70.49564F;
            this.nValAproba.HeaderText = "Monto/Valor";
            this.nValAproba.Name = "nValAproba";
            this.nValAproba.ReadOnly = true;
            // 
            // idDocument
            // 
            this.idDocument.DataPropertyName = "idDocument";
            this.idDocument.HeaderText = "Nro Documento";
            this.idDocument.Name = "idDocument";
            this.idDocument.ReadOnly = true;
            this.idDocument.Visible = false;
            // 
            // idMotivo
            // 
            this.idMotivo.DataPropertyName = "idMotivo";
            this.idMotivo.HeaderText = "Id Motivo";
            this.idMotivo.Name = "idMotivo";
            this.idMotivo.ReadOnly = true;
            this.idMotivo.Visible = false;
            // 
            // cMotivo
            // 
            this.cMotivo.DataPropertyName = "cMotivo";
            this.cMotivo.HeaderText = "Motivo";
            this.cMotivo.Name = "cMotivo";
            this.cMotivo.ReadOnly = true;
            this.cMotivo.Visible = false;
            // 
            // cSustento
            // 
            this.cSustento.DataPropertyName = "cSustento";
            this.cSustento.HeaderText = "Sustento";
            this.cSustento.Name = "cSustento";
            this.cSustento.ReadOnly = true;
            this.cSustento.Visible = false;
            // 
            // dFecSolici
            // 
            this.dFecSolici.DataPropertyName = "dFecSolici";
            this.dFecSolici.FillWeight = 88.83247F;
            this.dFecSolici.HeaderText = "Fecha Solicitud";
            this.dFecSolici.Name = "dFecSolici";
            this.dFecSolici.ReadOnly = true;
            // 
            // cWinUser
            // 
            this.cWinUser.DataPropertyName = "cWinUser";
            this.cWinUser.HeaderText = "Usu. Reg.";
            this.cWinUser.Name = "cWinUser";
            this.cWinUser.ReadOnly = true;
            this.cWinUser.Visible = false;
            // 
            // dFecVenSol
            // 
            this.dFecVenSol.DataPropertyName = "dFecVenSol";
            this.dFecVenSol.HeaderText = "Fecha Vencimiento";
            this.dFecVenSol.Name = "dFecVenSol";
            this.dFecVenSol.ReadOnly = true;
            this.dFecVenSol.Visible = false;
            // 
            // cOpinion
            // 
            this.cOpinion.DataPropertyName = "cOpinion";
            this.cOpinion.HeaderText = "cOpinion";
            this.cOpinion.Name = "cOpinion";
            this.cOpinion.ReadOnly = true;
            this.cOpinion.Visible = false;
            // 
            // lAprob
            // 
            this.lAprob.DataPropertyName = "lAprob";
            this.lAprob.HeaderText = "lAprob";
            this.lAprob.Name = "lAprob";
            this.lAprob.ReadOnly = true;
            this.lAprob.Visible = false;
            // 
            // lSoloComent
            // 
            this.lSoloComent.DataPropertyName = "lSoloComent";
            this.lSoloComent.HeaderText = "lSoloComent";
            this.lSoloComent.Name = "lSoloComent";
            this.lSoloComent.ReadOnly = true;
            this.lSoloComent.Visible = false;
            // 
            // nOrdenAprobacion
            // 
            this.nOrdenAprobacion.DataPropertyName = "nOrdenAprobacion";
            this.nOrdenAprobacion.HeaderText = "nOrdenAprobacion";
            this.nOrdenAprobacion.Name = "nOrdenAprobacion";
            this.nOrdenAprobacion.ReadOnly = true;
            this.nOrdenAprobacion.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.BackgroundImage")));
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(906, 481);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(60, 50);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Act&ualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.texto = "Act&ualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(967, 481);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.SystemColors.Control;
            this.btnRechazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRechazar.BackgroundImage")));
            this.btnRechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechazar.Location = new System.Drawing.Point(845, 481);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(60, 50);
            this.btnRechazar.TabIndex = 5;
            this.btnRechazar.Text = "&Rechaza";
            this.btnRechazar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.AprobarRechazar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackColor = System.Drawing.SystemColors.Control;
            this.btnAprobar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAprobar.BackgroundImage")));
            this.btnAprobar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAprobar.Location = new System.Drawing.Point(784, 481);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(60, 50);
            this.btnAprobar.TabIndex = 10;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.AprobarRechazar_Click);
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.Enabled = false;
            this.txtNomCliente.Location = new System.Drawing.Point(121, 276);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.Size = new System.Drawing.Size(295, 20);
            this.txtNomCliente.TabIndex = 11;
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(823, 314);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(204, 20);
            this.txtProducto.TabIndex = 12;
            // 
            // txtIdSolAproba
            // 
            this.txtIdSolAproba.Enabled = false;
            this.txtIdSolAproba.Location = new System.Drawing.Point(8, 276);
            this.txtIdSolAproba.Name = "txtIdSolAproba";
            this.txtIdSolAproba.Size = new System.Drawing.Size(107, 20);
            this.txtIdSolAproba.TabIndex = 13;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Location = new System.Drawing.Point(706, 276);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(204, 20);
            this.txtMoneda.TabIndex = 14;
            // 
            // txtValAproba
            // 
            this.txtValAproba.Enabled = false;
            this.txtValAproba.Location = new System.Drawing.Point(916, 276);
            this.txtValAproba.Name = "txtValAproba";
            this.txtValAproba.Size = new System.Drawing.Size(111, 20);
            this.txtValAproba.TabIndex = 15;
            // 
            // txtDocument
            // 
            this.txtDocument.Enabled = false;
            this.txtDocument.Location = new System.Drawing.Point(8, 314);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(107, 20);
            this.txtDocument.TabIndex = 16;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(120, 314);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(521, 20);
            this.txtMotivo.TabIndex = 17;
            // 
            // txtSustento
            // 
            this.txtSustento.Enabled = false;
            this.txtSustento.Location = new System.Drawing.Point(8, 351);
            this.txtSustento.Multiline = true;
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(1019, 40);
            this.txtSustento.TabIndex = 18;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 261);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(79, 13);
            this.lblBase1.TabIndex = 19;
            this.lblBase1.Text = "Nro Solicitud";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(126, 261);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(47, 13);
            this.lblBase2.TabIndex = 20;
            this.lblBase2.Text = "Cliente";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(824, 299);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 21;
            this.lblBase3.Text = "Producto";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(706, 261);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(51, 13);
            this.lblBase4.TabIndex = 22;
            this.lblBase4.Text = "Moneda";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(916, 261);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(75, 13);
            this.lblBase5.TabIndex = 23;
            this.lblBase5.Text = "Monto/Valor";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(8, 299);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(96, 13);
            this.lblBase6.TabIndex = 24;
            this.lblBase6.Text = "Nro Documento";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(121, 299);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(44, 13);
            this.lblBase7.TabIndex = 25;
            this.lblBase7.Text = "Motivo";
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(8, 336);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(57, 13);
            this.lblBase8.TabIndex = 26;
            this.lblBase8.Text = "Sustento";
            // 
            // txtOpinion
            // 
            this.txtOpinion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpinion.Location = new System.Drawing.Point(8, 21);
            this.txtOpinion.Multiline = true;
            this.txtOpinion.Name = "txtOpinion";
            this.txtOpinion.Size = new System.Drawing.Size(703, 60);
            this.txtOpinion.TabIndex = 28;
            // 
            // txtTipoOperacion
            // 
            this.txtTipoOperacion.Enabled = false;
            this.txtTipoOperacion.Location = new System.Drawing.Point(421, 276);
            this.txtTipoOperacion.Name = "txtTipoOperacion";
            this.txtTipoOperacion.Size = new System.Drawing.Size(279, 20);
            this.txtTipoOperacion.TabIndex = 29;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(418, 261);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(65, 13);
            this.lblBase10.TabIndex = 32;
            this.lblBase10.Text = "Operación";
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(648, 299);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(92, 13);
            this.lblBase11.TabIndex = 33;
            this.lblBase11.Text = "Fecha Solicitud";
            // 
            // txtFecSolici
            // 
            this.txtFecSolici.Enabled = false;
            this.txtFecSolici.Location = new System.Drawing.Point(647, 314);
            this.txtFecSolici.Name = "txtFecSolici";
            this.txtFecSolici.Size = new System.Drawing.Size(170, 20);
            this.txtFecSolici.TabIndex = 31;
            // 
            // chcAprob
            // 
            this.chcAprob.AutoSize = true;
            this.chcAprob.Location = new System.Drawing.Point(580, 2);
            this.chcAprob.Name = "chcAprob";
            this.chcAprob.Size = new System.Drawing.Size(96, 17);
            this.chcAprob.TabIndex = 34;
            this.chcAprob.Text = "Ver Aprobadas";
            this.chcAprob.UseVisualStyleBackColor = true;
            this.chcAprob.CheckedChanged += new System.EventHandler(this.chcAprob_CheckedChanged);
            // 
            // btnDevolver
            // 
            this.btnDevolver.BackColor = System.Drawing.SystemColors.Control;
            this.btnDevolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDevolver.BackgroundImage")));
            this.btnDevolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDevolver.Location = new System.Drawing.Point(723, 481);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(60, 50);
            this.btnDevolver.TabIndex = 35;
            this.btnDevolver.Text = "&Devolver";
            this.btnDevolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDevolver.UseVisualStyleBackColor = false;
            this.btnDevolver.Visible = false;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnSubsanar);
            this.grbBase1.Controls.Add(this.btnEditObs);
            this.grbBase1.Controls.Add(this.btnQuitObs);
            this.grbBase1.Controls.Add(this.btnAddObs);
            this.grbBase1.Controls.Add(this.dtgObservaciones);
            this.grbBase1.Location = new System.Drawing.Point(682, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(351, 252);
            this.grbBase1.TabIndex = 36;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Observaciones";
            // 
            // btnSubsanar
            // 
            this.btnSubsanar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubsanar.BackgroundImage")));
            this.btnSubsanar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubsanar.Location = new System.Drawing.Point(309, 14);
            this.btnSubsanar.Name = "btnSubsanar";
            this.btnSubsanar.Size = new System.Drawing.Size(36, 28);
            this.btnSubsanar.TabIndex = 4;
            this.btnSubsanar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSubsanar.UseVisualStyleBackColor = true;
            this.btnSubsanar.Click += new System.EventHandler(this.btnSubsanar_Click);
            // 
            // btnEditObs
            // 
            this.btnEditObs.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditObs.BackgroundImage")));
            this.btnEditObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditObs.Enabled = false;
            this.btnEditObs.Location = new System.Drawing.Point(86, 14);
            this.btnEditObs.Name = "btnEditObs";
            this.btnEditObs.Size = new System.Drawing.Size(36, 28);
            this.btnEditObs.TabIndex = 3;
            this.btnEditObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditObs.UseVisualStyleBackColor = false;
            this.btnEditObs.Click += new System.EventHandler(this.btnEditObs_Click);
            // 
            // btnQuitObs
            // 
            this.btnQuitObs.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuitObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitObs.BackgroundImage")));
            this.btnQuitObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitObs.Enabled = false;
            this.btnQuitObs.Location = new System.Drawing.Point(46, 14);
            this.btnQuitObs.Name = "btnQuitObs";
            this.btnQuitObs.Size = new System.Drawing.Size(36, 28);
            this.btnQuitObs.TabIndex = 2;
            this.btnQuitObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitObs.UseVisualStyleBackColor = false;
            this.btnQuitObs.Click += new System.EventHandler(this.btnQuitObs_Click);
            // 
            // btnAddObs
            // 
            this.btnAddObs.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddObs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddObs.BackgroundImage")));
            this.btnAddObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddObs.Enabled = false;
            this.btnAddObs.Location = new System.Drawing.Point(6, 14);
            this.btnAddObs.Name = "btnAddObs";
            this.btnAddObs.Size = new System.Drawing.Size(36, 28);
            this.btnAddObs.TabIndex = 1;
            this.btnAddObs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddObs.UseVisualStyleBackColor = false;
            this.btnAddObs.Click += new System.EventHandler(this.btnAddObs_Click);
            // 
            // dtgObservaciones
            // 
            this.dtgObservaciones.AllowUserToAddRows = false;
            this.dtgObservaciones.AllowUserToDeleteRows = false;
            this.dtgObservaciones.AllowUserToResizeColumns = false;
            this.dtgObservaciones.AllowUserToResizeRows = false;
            this.dtgObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObservaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTipObsSol,
            this.cObservacion,
            this.lSubsanado});
            this.dtgObservaciones.Location = new System.Drawing.Point(6, 43);
            this.dtgObservaciones.MultiSelect = false;
            this.dtgObservaciones.Name = "dtgObservaciones";
            this.dtgObservaciones.ReadOnly = true;
            this.dtgObservaciones.RowHeadersVisible = false;
            this.dtgObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.Size = new System.Drawing.Size(339, 203);
            this.dtgObservaciones.TabIndex = 0;
            // 
            // cTipObsSol
            // 
            this.cTipObsSol.DataPropertyName = "cTipObs";
            this.cTipObsSol.FillWeight = 20F;
            this.cTipObsSol.HeaderText = "Tipo Obs.";
            this.cTipObsSol.Name = "cTipObsSol";
            this.cTipObsSol.ReadOnly = true;
            this.cTipObsSol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cTipObsSol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cObservacion
            // 
            this.cObservacion.DataPropertyName = "cObservacion";
            this.cObservacion.FillWeight = 60F;
            this.cObservacion.HeaderText = "Observación";
            this.cObservacion.Name = "cObservacion";
            this.cObservacion.ReadOnly = true;
            // 
            // lSubsanado
            // 
            this.lSubsanado.DataPropertyName = "lSubsanado";
            this.lSubsanado.FillWeight = 20F;
            this.lSubsanado.HeaderText = "Subsanado";
            this.lSubsanado.IndeterminateValue = "False";
            this.lSubsanado.Name = "lSubsanado";
            this.lSubsanado.ReadOnly = true;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(8, 5);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(50, 13);
            this.lblBase9.TabIndex = 29;
            this.lblBase9.Text = "Opinion";
            // 
            // tlpDecision
            // 
            this.tlpDecision.ColumnCount = 2;
            this.tlpDecision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDecision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDecision.Controls.Add(this.pnlOpinion, 0, 0);
            this.tlpDecision.Controls.Add(this.pnlRechazoCred, 1, 0);
            this.tlpDecision.Location = new System.Drawing.Point(0, 391);
            this.tlpDecision.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDecision.Name = "tlpDecision";
            this.tlpDecision.RowCount = 1;
            this.tlpDecision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDecision.Size = new System.Drawing.Size(1033, 84);
            this.tlpDecision.TabIndex = 37;
            // 
            // pnlOpinion
            // 
            this.pnlOpinion.Controls.Add(this.lblBase9);
            this.pnlOpinion.Controls.Add(this.txtOpinion);
            this.pnlOpinion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOpinion.Location = new System.Drawing.Point(0, 0);
            this.pnlOpinion.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOpinion.Name = "pnlOpinion";
            this.pnlOpinion.Size = new System.Drawing.Size(719, 84);
            this.pnlOpinion.TabIndex = 1;
            // 
            // pnlRechazoCred
            // 
            this.pnlRechazoCred.Controls.Add(this.cboMotRechazo);
            this.pnlRechazoCred.Controls.Add(this.lblMotRechazo);
            this.pnlRechazoCred.Location = new System.Drawing.Point(719, 0);
            this.pnlRechazoCred.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRechazoCred.Name = "pnlRechazoCred";
            this.pnlRechazoCred.Size = new System.Drawing.Size(314, 84);
            this.pnlRechazoCred.TabIndex = 0;
            // 
            // cboMotRechazo
            // 
            this.cboMotRechazo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotRechazo.FormattingEnabled = true;
            this.cboMotRechazo.Location = new System.Drawing.Point(9, 22);
            this.cboMotRechazo.Name = "cboMotRechazo";
            this.cboMotRechazo.Size = new System.Drawing.Size(292, 21);
            this.cboMotRechazo.TabIndex = 14;
            // 
            // lblMotRechazo
            // 
            this.lblMotRechazo.AutoSize = true;
            this.lblMotRechazo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMotRechazo.ForeColor = System.Drawing.Color.Navy;
            this.lblMotRechazo.Location = new System.Drawing.Point(6, 5);
            this.lblMotRechazo.Name = "lblMotRechazo";
            this.lblMotRechazo.Size = new System.Drawing.Size(98, 13);
            this.lblMotRechazo.TabIndex = 13;
            this.lblMotRechazo.Text = "Motivo rechazo:";
            // 
            // conImpFormatEval
            // 
            this.conImpFormatEval.AutoSize = true;
            this.conImpFormatEval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conImpFormatEval.lCascada = false;
            this.conImpFormatEval.Location = new System.Drawing.Point(8, 37);
            this.conImpFormatEval.Margin = new System.Windows.Forms.Padding(4);
            this.conImpFormatEval.Name = "conImpFormatEval";
            this.conImpFormatEval.Size = new System.Drawing.Size(67, 57);
            this.conImpFormatEval.TabIndex = 38;
            // 
            // btnImpActAprob
            // 
            this.btnImpActAprob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpActAprob.BackgroundImage")));
            this.btnImpActAprob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpActAprob.Location = new System.Drawing.Point(8, 478);
            this.btnImpActAprob.Name = "btnImpActAprob";
            this.btnImpActAprob.Size = new System.Drawing.Size(60, 50);
            this.btnImpActAprob.TabIndex = 39;
            this.btnImpActAprob.Text = "Imprimir Acta Aprob.";
            this.btnImpActAprob.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpActAprob.UseVisualStyleBackColor = true;
            this.btnImpActAprob.Click += new System.EventHandler(this.btnImpActAprob_Click);
            // 
            // btnConsultarSolCondonacion
            // 
            this.btnConsultarSolCondonacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultarSolCondonacion.BackgroundImage")));
            this.btnConsultarSolCondonacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultarSolCondonacion.Location = new System.Drawing.Point(74, 478);
            this.btnConsultarSolCondonacion.Name = "btnConsultarSolCondonacion";
            this.btnConsultarSolCondonacion.Size = new System.Drawing.Size(60, 50);
            this.btnConsultarSolCondonacion.TabIndex = 40;
            this.btnConsultarSolCondonacion.Text = "&Consultar";
            this.btnConsultarSolCondonacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultarSolCondonacion.UseVisualStyleBackColor = true;
            this.btnConsultarSolCondonacion.Visible = false;
            this.btnConsultarSolCondonacion.Click += new System.EventHandler(this.btnConsultarSolCondonacion_Click);
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOperacion.FormattingEnabled = true;
            this.cboTipoOperacion.Location = new System.Drawing.Point(116, 10);
            this.cboTipoOperacion.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Size = new System.Drawing.Size(300, 21);
            this.cboTipoOperacion.TabIndex = 41;
            this.cboTipoOperacion.SelectionChangeCommitted += new System.EventHandler(this.cboTipoOperacion_SelectionChangeCommitted);
            // 
            // lblBase12
            // 
            this.lblBase12.AutoSize = true;
            this.lblBase12.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase12.ForeColor = System.Drawing.Color.Navy;
            this.lblBase12.Location = new System.Drawing.Point(10, 12);
            this.lblBase12.Name = "lblBase12";
            this.lblBase12.Size = new System.Drawing.Size(102, 13);
            this.lblBase12.TabIndex = 42;
            this.lblBase12.Text = "Tipo Operacion :";
            // 
            // lblBase13
            // 
            this.lblBase13.AutoSize = true;
            this.lblBase13.BackColor = System.Drawing.Color.Beige;
            this.lblBase13.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase13.ForeColor = System.Drawing.Color.Navy;
            this.lblBase13.Location = new System.Drawing.Point(501, 22);
            this.lblBase13.Name = "lblBase13";
            this.lblBase13.Size = new System.Drawing.Size(15, 13);
            this.lblBase13.TabIndex = 42;
            this.lblBase13.Text = "  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Solicictudes solo se visualizan";
            // 
            // btnVerAdjuntos
            // 
            this.btnVerAdjuntos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerAdjuntos.BackgroundImage")));
            this.btnVerAdjuntos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerAdjuntos.Location = new System.Drawing.Point(142, 478);
            this.btnVerAdjuntos.Name = "btnVerAdjuntos";
            this.btnVerAdjuntos.Size = new System.Drawing.Size(60, 50);
            this.btnVerAdjuntos.TabIndex = 44;
            this.btnVerAdjuntos.Text = "Ver Adjunto";
            this.btnVerAdjuntos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerAdjuntos.UseVisualStyleBackColor = true;
            this.btnVerAdjuntos.Visible = false;
            this.btnVerAdjuntos.Click += new System.EventHandler(this.btnVerAdjuntos_Click);
            // 
            // frmAprobacionSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 556);
            this.Controls.Add(this.btnVerAdjuntos);
            this.Controls.Add(this.lblBase12);
            this.Controls.Add(this.cboTipoOperacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBase13);
            this.Controls.Add(this.btnConsultarSolCondonacion);
            this.Controls.Add(this.btnImpActAprob);
            this.Controls.Add(this.tlpDecision);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.txtValAproba);
            this.Controls.Add(this.chcAprob);
            this.Controls.Add(this.txtDocument);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase10);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.txtFecSolici);
            this.Controls.Add(this.txtTipoOperacion);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.txtSustento);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtIdSolAproba);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.txtNomCliente);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dtgLisSoliciAproba);
            this.Controls.Add(this.conImpFormatEval);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAprobacionSolicitud";
            this.Text = "Aprobación de Solicitudes";
            this.Load += new System.EventHandler(this.frmAprobacionSolicitud_Load);
            this.Controls.SetChildIndex(this.conImpFormatEval, 0);
            this.Controls.SetChildIndex(this.dtgLisSoliciAproba, 0);
            this.Controls.SetChildIndex(this.btnActualizar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnRechazar, 0);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.txtNomCliente, 0);
            this.Controls.SetChildIndex(this.txtProducto, 0);
            this.Controls.SetChildIndex(this.txtIdSolAproba, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.txtSustento, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.txtTipoOperacion, 0);
            this.Controls.SetChildIndex(this.txtFecSolici, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase10, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.Controls.SetChildIndex(this.txtDocument, 0);
            this.Controls.SetChildIndex(this.chcAprob, 0);
            this.Controls.SetChildIndex(this.txtValAproba, 0);
            this.Controls.SetChildIndex(this.btnDevolver, 0);
            this.Controls.SetChildIndex(this.txtMoneda, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.tlpDecision, 0);
            this.Controls.SetChildIndex(this.btnImpActAprob, 0);
            this.Controls.SetChildIndex(this.btnConsultarSolCondonacion, 0);
            this.Controls.SetChildIndex(this.cboTipoOperacion, 0);
            this.Controls.SetChildIndex(this.lblBase12, 0);
            this.Controls.SetChildIndex(this.lblBase13, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnVerAdjuntos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLisSoliciAproba)).EndInit();
            this.grbBase1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgObservaciones)).EndInit();
            this.tlpDecision.ResumeLayout(false);
            this.pnlOpinion.ResumeLayout(false);
            this.pnlOpinion.PerformLayout();
            this.pnlRechazoCred.ResumeLayout(false);
            this.pnlRechazoCred.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgLisSoliciAproba;
        private GEN.BotonesBase.btnActualizar btnActualizar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnRechazar btnRechazar;
        private GEN.BotonesBase.btnAprobar btnAprobar;
        private GEN.ControlesBase.txtBase txtNomCliente;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.txtBase txtIdSolAproba;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.txtBase txtValAproba;
        private GEN.ControlesBase.txtBase txtDocument;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.txtBase txtSustento;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtOpinion;
        private GEN.ControlesBase.txtBase txtTipoOperacion;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.txtBase txtFecSolici;
        private GEN.ControlesBase.chcBase chcAprob;
        private GEN.BotonesBase.btnDevolver btnDevolver;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtgBase dtgObservaciones;
        private GEN.BotonesBase.btnMiniQuitar btnQuitObs;
        private GEN.BotonesBase.btnMiniAgregar btnAddObs;
        private GEN.BotonesBase.btnMiniEditar btnEditObs;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipObsSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cObservacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lSubsanado;
        private GEN.BotonesBase.btnMiniAcept btnSubsanar;
        private GEN.ControlesBase.lblBase lblBase9;
        private System.Windows.Forms.TableLayoutPanel tlpDecision;
        private System.Windows.Forms.Panel pnlRechazoCred;
        private GEN.ControlesBase.cboMotRechazoSolCreEval cboMotRechazo;
        private GEN.ControlesBase.lblBase lblMotRechazo;
        private System.Windows.Forms.Panel pnlOpinion;
        private GEN.ControlesBase.ConImpFormatEval conImpFormatEval;
        private GEN.BotonesBase.btnImprimir btnImpActAprob;
        private GEN.BotonesBase.btnConsultar btnConsultarSolCondonacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolAproba;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNivelAprRanOpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuRegist;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomUsuReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTipoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSimbolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nValAproba;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSustento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecSolici;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWinUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecVenSol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOpinion;
        private System.Windows.Forms.DataGridViewTextBoxColumn lAprob;
        private System.Windows.Forms.DataGridViewTextBoxColumn lSoloComent;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOrdenAprobacion;
        private System.Windows.Forms.ComboBox cboTipoOperacion;
        private GEN.ControlesBase.lblBase lblBase12;
        private GEN.ControlesBase.lblBase lblBase13;
        private System.Windows.Forms.Label label1;
        private GEN.BotonesBase.btnAdjuntarFile btnVerAdjuntos;
    }
}

