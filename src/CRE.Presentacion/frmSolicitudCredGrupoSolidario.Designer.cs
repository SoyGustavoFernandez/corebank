namespace CRE.Presentacion
{
    partial class frmSolicitudCredGrupoSolidario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitudCredGrupoSolidario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblClicloAmpliacion = new GEN.ControlesBase.lblBase();
            this.cboCicloAmpliacion = new GEN.ControlesBase.CboGrupoSolidarioCiclo(this.components);
            this.conBusGrupoSol = new GEN.ControlesBase.ConBusGrupoSol();
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboOperacionCre = new GEN.ControlesBase.cboOperacionCredito(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAsesorNegociosGrupoSolidario = new GEN.ControlesBase.cboAsesorNegociosGrupoSolidario(this.components);
            this.conCondiCreditoGrupoSol = new GEN.ControlesBase.ConCondiCreditoGrupoSol();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgIntegrantes = new System.Windows.Forms.DataGridView();
            this.bsSolicitudIntegrante = new System.Windows.Forms.BindingSource(this.components);
            this.txtMontoSuma = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnEditCondiIntegrante = new GEN.BotonesBase.btnMiniEditar();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnExcepciones = new GEN.BotonesBase.btnBlanco();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEnviar = new GEN.BotonesBase.btnEnviar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboModalidadCredito = new GEN.ControlesBase.cboModalidadCredito(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboModDesemb = new GEN.ControlesBase.cboModDesemb(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnVincularVisita1 = new GEN.ControlesBase.btnVincularVisita(this.components);
            this.btnExpediente = new System.Windows.Forms.Button();
            this.lSolicitudActiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nNroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolicitudDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoCancelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoAmpliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTasaMoratoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTeaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cActividadInternaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDestinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSolicitudIntegrante)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblClicloAmpliacion);
            this.grbBase1.Controls.Add(this.cboCicloAmpliacion);
            this.grbBase1.Controls.Add(this.conBusGrupoSol);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(690, 92);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Información del Grupo";
            // 
            // lblClicloAmpliacion
            // 
            this.lblClicloAmpliacion.AutoSize = true;
            this.lblClicloAmpliacion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblClicloAmpliacion.ForeColor = System.Drawing.Color.Navy;
            this.lblClicloAmpliacion.Location = new System.Drawing.Point(426, 66);
            this.lblClicloAmpliacion.Name = "lblClicloAmpliacion";
            this.lblClicloAmpliacion.Size = new System.Drawing.Size(106, 13);
            this.lblClicloAmpliacion.TabIndex = 2;
            this.lblClicloAmpliacion.Text = "Ciclo Ampliación:";
            this.lblClicloAmpliacion.Visible = false;
            // 
            // cboCicloAmpliacion
            // 
            this.cboCicloAmpliacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCicloAmpliacion.Enabled = false;
            this.cboCicloAmpliacion.FormattingEnabled = true;
            this.cboCicloAmpliacion.Location = new System.Drawing.Point(538, 63);
            this.cboCicloAmpliacion.Name = "cboCicloAmpliacion";
            this.cboCicloAmpliacion.Size = new System.Drawing.Size(121, 21);
            this.cboCicloAmpliacion.TabIndex = 1;
            this.cboCicloAmpliacion.Visible = false;
            // 
            // conBusGrupoSol
            // 
            this.conBusGrupoSol.Location = new System.Drawing.Point(25, 13);
            this.conBusGrupoSol.Name = "conBusGrupoSol";
            this.conBusGrupoSol.Size = new System.Drawing.Size(613, 73);
            this.conBusGrupoSol.TabIndex = 0;
            this.conBusGrupoSol.ClicBuscar += new System.EventHandler(this.conBusGrupoSol_ClicBuscar);
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(101, 110);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(71, 20);
            this.txtBase1.TabIndex = 2;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(26, 113);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(73, 13);
            this.lblBase6.TabIndex = 1;
            this.lblBase6.Text = "N° Solicitud";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboOperacionCre);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.cboAsesorNegociosGrupoSolidario);
            this.grbBase2.Controls.Add(this.conCondiCreditoGrupoSol);
            this.grbBase2.Location = new System.Drawing.Point(12, 138);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(690, 236);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Condiciones de Crédito";
            // 
            // cboOperacionCre
            // 
            this.cboOperacionCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperacionCre.FormattingEnabled = true;
            this.cboOperacionCre.Location = new System.Drawing.Point(123, 22);
            this.cboOperacionCre.Name = "cboOperacionCre";
            this.cboOperacionCre.Size = new System.Drawing.Size(151, 21);
            this.cboOperacionCre.TabIndex = 5;
            this.cboOperacionCre.SelectedIndexChanged += new System.EventHandler(this.cboOperacionCre_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(58, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Operacion";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(334, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(46, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Asesor";
            // 
            // cboAsesorNegociosGrupoSolidario
            // 
            this.cboAsesorNegociosGrupoSolidario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsesorNegociosGrupoSolidario.FormattingEnabled = true;
            this.cboAsesorNegociosGrupoSolidario.Location = new System.Drawing.Point(382, 22);
            this.cboAsesorNegociosGrupoSolidario.Name = "cboAsesorNegociosGrupoSolidario";
            this.cboAsesorNegociosGrupoSolidario.Size = new System.Drawing.Size(262, 21);
            this.cboAsesorNegociosGrupoSolidario.TabIndex = 3;
            // 
            // conCondiCreditoGrupoSol
            // 
            this.conCondiCreditoGrupoSol.Location = new System.Drawing.Point(7, 49);
            this.conCondiCreditoGrupoSol.MonedaEnabled = false;
            this.conCondiCreditoGrupoSol.Name = "conCondiCreditoGrupoSol";
            this.conCondiCreditoGrupoSol.NivelesProductoEnabled = true;
            this.conCondiCreditoGrupoSol.PeriodoEnabled = true;
            this.conCondiCreditoGrupoSol.Size = new System.Drawing.Size(595, 183);
            this.conCondiCreditoGrupoSol.TabIndex = 4;
            this.conCondiCreditoGrupoSol.ChangeCondiCredito += new System.EventHandler(this.conCondiCreditoGrupoSol_ChangeCondiCredito);
            this.conCondiCreditoGrupoSol.ChangeProducto += new System.EventHandler(this.conCondiCreditoGrupoSol_ChangeProducto);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgIntegrantes);
            this.grbBase3.Controls.Add(this.txtMontoSuma);
            this.grbBase3.Controls.Add(this.lblBase5);
            this.grbBase3.Controls.Add(this.btnEditCondiIntegrante);
            this.grbBase3.Location = new System.Drawing.Point(12, 380);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(748, 238);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Integrantes del Grupo";
            // 
            // dtgIntegrantes
            // 
            this.dtgIntegrantes.AllowUserToAddRows = false;
            this.dtgIntegrantes.AllowUserToDeleteRows = false;
            this.dtgIntegrantes.AllowUserToResizeColumns = false;
            this.dtgIntegrantes.AllowUserToResizeRows = false;
            this.dtgIntegrantes.AutoGenerateColumns = false;
            this.dtgIntegrantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntegrantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lSolicitudActiva,
            this.nNroDataGridViewTextBoxColumn,
            this.idSolicitudDataGridViewTextBoxColumn,
            this.cNombreDataGridViewTextBoxColumn,
            this.nMontoCancelacion,
            this.nMontoAmpliado,
            this.nMontoDataGridViewTextBoxColumn,
            this.nTasaMoratoriaDataGridViewTextBoxColumn,
            this.nTeaDataGridViewTextBoxColumn,
            this.cActividadInternaDataGridViewTextBoxColumn,
            this.cDestinoDataGridViewTextBoxColumn});
            this.dtgIntegrantes.DataSource = this.bsSolicitudIntegrante;
            this.dtgIntegrantes.Location = new System.Drawing.Point(7, 46);
            this.dtgIntegrantes.Name = "dtgIntegrantes";
            this.dtgIntegrantes.RowHeadersVisible = false;
            this.dtgIntegrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntegrantes.Size = new System.Drawing.Size(735, 187);
            this.dtgIntegrantes.TabIndex = 4;
            this.dtgIntegrantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIntegrantes_CellContentClick);
            this.dtgIntegrantes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgIntegrantes_CellValidating);
            this.dtgIntegrantes.SelectionChanged += new System.EventHandler(this.dtgIntegrantes_SelectionChanged);
            // 
            // bsSolicitudIntegrante
            // 
            this.bsSolicitudIntegrante.DataSource = typeof(EntityLayer.clsCreditoGrupoSolInt);
            // 
            // txtMontoSuma
            // 
            this.txtMontoSuma.BackColor = System.Drawing.SystemColors.Info;
            this.txtMontoSuma.FormatoDecimal = true;
            this.txtMontoSuma.Location = new System.Drawing.Point(416, 18);
            this.txtMontoSuma.Name = "txtMontoSuma";
            this.txtMontoSuma.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMontoSuma.nNumDecimales = 2;
            this.txtMontoSuma.nvalor = 0D;
            this.txtMontoSuma.ReadOnly = true;
            this.txtMontoSuma.Size = new System.Drawing.Size(139, 20);
            this.txtMontoSuma.TabIndex = 2;
            this.txtMontoSuma.Text = "00.00";
            this.txtMontoSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(332, 21);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(77, 13);
            this.lblBase5.TabIndex = 3;
            this.lblBase5.Text = "Monto Total:";
            // 
            // btnEditCondiIntegrante
            // 
            this.btnEditCondiIntegrante.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditCondiIntegrante.BackgroundImage")));
            this.btnEditCondiIntegrante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditCondiIntegrante.Location = new System.Drawing.Point(612, 12);
            this.btnEditCondiIntegrante.Name = "btnEditCondiIntegrante";
            this.btnEditCondiIntegrante.Size = new System.Drawing.Size(36, 28);
            this.btnEditCondiIntegrante.TabIndex = 1;
            this.btnEditCondiIntegrante.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditCondiIntegrante.UseVisualStyleBackColor = true;
            this.btnEditCondiIntegrante.Click += new System.EventHandler(this.btnEditCondiIntegrante_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(346, 625);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExcepciones
            // 
            this.btnExcepciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcepciones.Location = new System.Drawing.Point(406, 625);
            this.btnExcepciones.Name = "btnExcepciones";
            this.btnExcepciones.Size = new System.Drawing.Size(60, 50);
            this.btnExcepciones.TabIndex = 8;
            this.btnExcepciones.Text = "Excepciones";
            this.btnExcepciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcepciones.UseVisualStyleBackColor = true;
            this.btnExcepciones.Click += new System.EventHandler(this.btnExcepciones_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(466, 625);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(526, 625);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(586, 625);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnviar.BackgroundImage")));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Location = new System.Drawing.Point(646, 625);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 50);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(706, 625);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboModalidadCredito
            // 
            this.cboModalidadCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadCredito.FormattingEnabled = true;
            this.cboModalidadCredito.Location = new System.Drawing.Point(101, 625);
            this.cboModalidadCredito.Name = "cboModalidadCredito";
            this.cboModalidadCredito.Size = new System.Drawing.Size(121, 21);
            this.cboModalidadCredito.TabIndex = 10;
            this.cboModalidadCredito.SelectedIndexChanged += new System.EventHandler(this.cboModalidadCredito_SelectedIndexChanged);
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 633);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(84, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "M. de Credito";
            // 
            // cboModDesemb
            // 
            this.cboModDesemb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModDesemb.FormattingEnabled = true;
            this.cboModDesemb.Location = new System.Drawing.Point(101, 652);
            this.cboModDesemb.Name = "cboModDesemb";
            this.cboModDesemb.Size = new System.Drawing.Size(121, 21);
            this.cboModDesemb.TabIndex = 11;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 654);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(94, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "M. Desembolso";
            // 
            // btnVincularVisita1
            // 
            this.btnVincularVisita1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVincularVisita1.BackgroundImage")));
            this.btnVincularVisita1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVincularVisita1.idCli = 0;
            this.btnVincularVisita1.idGrupoSolidario = 0;
            this.btnVincularVisita1.idSolicitud = 0;
            this.btnVincularVisita1.idSolicitudGrupoSol = 0;
            this.btnVincularVisita1.lIndividual = false;
            this.btnVincularVisita1.lLectura = false;
            this.btnVincularVisita1.Location = new System.Drawing.Point(286, 625);
            this.btnVincularVisita1.Name = "btnVincularVisita1";
            this.btnVincularVisita1.Size = new System.Drawing.Size(60, 50);
            this.btnVincularVisita1.TabIndex = 14;
            this.btnVincularVisita1.Text = "Vincular Visita";
            this.btnVincularVisita1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVincularVisita1.UseVisualStyleBackColor = true;
            // 
            // btnExpediente
            // 
            this.btnExpediente.BackgroundImage = global::CRE.Presentacion.Properties.Resources.btnTrasladar;
            this.btnExpediente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExpediente.Location = new System.Drawing.Point(226, 625);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Size = new System.Drawing.Size(60, 50);
            this.btnExpediente.TabIndex = 15;
            this.btnExpediente.Text = "Expdte";
            this.btnExpediente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpediente.UseVisualStyleBackColor = true;
            this.btnExpediente.Click += new System.EventHandler(this.btnExpediente_Click);
            // 
            // lSolicitudActiva
            // 
            this.lSolicitudActiva.DataPropertyName = "lSolicitudActiva";
            this.lSolicitudActiva.FillWeight = 5F;
            this.lSolicitudActiva.HeaderText = "Sel.";
            this.lSolicitudActiva.Name = "lSolicitudActiva";
            this.lSolicitudActiva.Visible = false;
            // 
            // nNroDataGridViewTextBoxColumn
            // 
            this.nNroDataGridViewTextBoxColumn.DataPropertyName = "nNro";
            this.nNroDataGridViewTextBoxColumn.FillWeight = 5F;
            this.nNroDataGridViewTextBoxColumn.HeaderText = "nNro";
            this.nNroDataGridViewTextBoxColumn.Name = "nNroDataGridViewTextBoxColumn";
            this.nNroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idSolicitudDataGridViewTextBoxColumn
            // 
            this.idSolicitudDataGridViewTextBoxColumn.DataPropertyName = "idSolicitud";
            this.idSolicitudDataGridViewTextBoxColumn.FillWeight = 10F;
            this.idSolicitudDataGridViewTextBoxColumn.HeaderText = "Solicitud";
            this.idSolicitudDataGridViewTextBoxColumn.Name = "idSolicitudDataGridViewTextBoxColumn";
            this.idSolicitudDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNombreDataGridViewTextBoxColumn
            // 
            this.cNombreDataGridViewTextBoxColumn.DataPropertyName = "cNombre";
            this.cNombreDataGridViewTextBoxColumn.FillWeight = 25F;
            this.cNombreDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.cNombreDataGridViewTextBoxColumn.Name = "cNombreDataGridViewTextBoxColumn";
            this.cNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMontoCancelacion
            // 
            this.nMontoCancelacion.DataPropertyName = "nMontoCancelacion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "###,###,##0.00";
            this.nMontoCancelacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.nMontoCancelacion.HeaderText = "Monto Cancelación";
            this.nMontoCancelacion.Name = "nMontoCancelacion";
            this.nMontoCancelacion.ReadOnly = true;
            this.nMontoCancelacion.Visible = false;
            // 
            // nMontoAmpliado
            // 
            this.nMontoAmpliado.DataPropertyName = "nMontoAmpliado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "###,###,##0.00";
            this.nMontoAmpliado.DefaultCellStyle = dataGridViewCellStyle2;
            this.nMontoAmpliado.HeaderText = "Monto Ampliado";
            this.nMontoAmpliado.Name = "nMontoAmpliado";
            this.nMontoAmpliado.ReadOnly = true;
            this.nMontoAmpliado.Visible = false;
            // 
            // nMontoDataGridViewTextBoxColumn
            // 
            this.nMontoDataGridViewTextBoxColumn.DataPropertyName = "nMonto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "###,###,##0.00";
            this.nMontoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nMontoDataGridViewTextBoxColumn.FillWeight = 10F;
            this.nMontoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.nMontoDataGridViewTextBoxColumn.Name = "nMontoDataGridViewTextBoxColumn";
            this.nMontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nTasaMoratoriaDataGridViewTextBoxColumn
            // 
            this.nTasaMoratoriaDataGridViewTextBoxColumn.DataPropertyName = "nTasaMoratoria";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "###,###,##0.0000";
            this.nTasaMoratoriaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.nTasaMoratoriaDataGridViewTextBoxColumn.FillWeight = 6F;
            this.nTasaMoratoriaDataGridViewTextBoxColumn.HeaderText = "TIM";
            this.nTasaMoratoriaDataGridViewTextBoxColumn.Name = "nTasaMoratoriaDataGridViewTextBoxColumn";
            this.nTasaMoratoriaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nTeaDataGridViewTextBoxColumn
            // 
            this.nTeaDataGridViewTextBoxColumn.DataPropertyName = "nTea";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "###,###,##0.0000";
            this.nTeaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.nTeaDataGridViewTextBoxColumn.FillWeight = 6F;
            this.nTeaDataGridViewTextBoxColumn.HeaderText = "TEA";
            this.nTeaDataGridViewTextBoxColumn.Name = "nTeaDataGridViewTextBoxColumn";
            this.nTeaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cActividadInternaDataGridViewTextBoxColumn
            // 
            this.cActividadInternaDataGridViewTextBoxColumn.DataPropertyName = "cActividadInterna";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cActividadInternaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.cActividadInternaDataGridViewTextBoxColumn.FillWeight = 17F;
            this.cActividadInternaDataGridViewTextBoxColumn.HeaderText = "Actividad Interna";
            this.cActividadInternaDataGridViewTextBoxColumn.Name = "cActividadInternaDataGridViewTextBoxColumn";
            this.cActividadInternaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cDestinoDataGridViewTextBoxColumn
            // 
            this.cDestinoDataGridViewTextBoxColumn.DataPropertyName = "cDestino";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cDestinoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cDestinoDataGridViewTextBoxColumn.FillWeight = 18F;
            this.cDestinoDataGridViewTextBoxColumn.HeaderText = "Destino";
            this.cDestinoDataGridViewTextBoxColumn.Name = "cDestinoDataGridViewTextBoxColumn";
            this.cDestinoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmSolicitudCredGrupoSolidario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(772, 699);
            this.Controls.Add(this.btnExpediente);
            this.Controls.Add(this.btnVincularVisita1);
            this.Controls.Add(this.txtBase1);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboModDesemb);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.cboModalidadCredito);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExcepciones);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmSolicitudCredGrupoSolidario";
            this.Text = "Registro Solicitud Credito Grupo Solidario";
            this.Load += new System.EventHandler(this.frmSolicitudCredGrupoSolidario_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnExcepciones, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cboModalidadCredito, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboModDesemb, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.txtBase1, 0);
            this.Controls.SetChildIndex(this.btnVincularVisita1, 0);
            this.Controls.SetChildIndex(this.btnExpediente, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntegrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSolicitudIntegrante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnBlanco btnExcepciones;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEnviar btnEnviar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.ConCondiCreditoGrupoSol conCondiCreditoGrupoSol;
        private GEN.ControlesBase.ConBusGrupoSol conBusGrupoSol;
        private GEN.BotonesBase.btnMiniEditar btnEditCondiIntegrante;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAsesorNegociosGrupoSolidario cboAsesorNegociosGrupoSolidario;
        private GEN.ControlesBase.cboModalidadCredito cboModalidadCredito;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboModDesemb cboModDesemb;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtMontoSuma;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.btnVincularVisita btnVincularVisita1;
        private System.Windows.Forms.Button btnExpediente;
        private GEN.ControlesBase.cboOperacionCredito cboOperacionCre;
        private System.Windows.Forms.DataGridView dtgIntegrantes;
        private System.Windows.Forms.BindingSource bsSolicitudIntegrante;
        private GEN.ControlesBase.lblBase lblClicloAmpliacion;
        private GEN.ControlesBase.CboGrupoSolidarioCiclo cboCicloAmpliacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lSolicitudActiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitudDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoCancelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoAmpliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTasaMoratoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTeaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cActividadInternaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDestinoDataGridViewTextBoxColumn;

    }
}