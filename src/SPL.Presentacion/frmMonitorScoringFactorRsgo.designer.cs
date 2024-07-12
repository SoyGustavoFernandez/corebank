namespace SPL.Presentacion
{
    partial class frmMonitorScoringFactorRsgo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitorScoringFactorRsgo));
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtgLista = new GEN.ControlesBase.dtgBase(this.components);
            this.cboRiesgo = new GEN.ControlesBase.cboCalifScoring(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnConsultar = new GEN.BotonesBase.btnConsultar();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.chcSoloNuevos = new GEN.ControlesBase.chcBase(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnDetalle = new GEN.BotonesBase.btnDetalle();
            this.dtgEvaluaciones = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnImprirCli = new GEN.BotonesBase.btnImprimir();
            this.chcSoloRecurrentes = new GEN.ControlesBase.chcBase(this.components);
            this.cboRegimenScoring = new GEN.ControlesBase.cboRegimenScoring(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.chcTodos = new GEN.ControlesBase.chcBase(this.components);
            this.lblBaseCustom1 = new GEN.ControlesBase.lblBaseCustom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluaciones)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(278, 44);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(44, 13);
            this.lblBase4.TabIndex = 30;
            this.lblBase4.Text = "Hasta:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(274, 17);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(48, 13);
            this.lblBase3.TabIndex = 30;
            this.lblBase3.Text = "Desde:";
            // 
            // dtgLista
            // 
            this.dtgLista.AllowUserToAddRows = false;
            this.dtgLista.AllowUserToDeleteRows = false;
            this.dtgLista.AllowUserToResizeColumns = false;
            this.dtgLista.AllowUserToResizeRows = false;
            this.dtgLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLista.Location = new System.Drawing.Point(7, 100);
            this.dtgLista.MultiSelect = false;
            this.dtgLista.Name = "dtgLista";
            this.dtgLista.ReadOnly = true;
            this.dtgLista.RowHeadersVisible = false;
            this.dtgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLista.Size = new System.Drawing.Size(770, 271);
            this.dtgLista.TabIndex = 31;
            this.dtgLista.SelectionChanged += new System.EventHandler(this.dtgLista_SelectionChanged);
            // 
            // cboRiesgo
            // 
            this.cboRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRiesgo.FormattingEnabled = true;
            this.cboRiesgo.lAgregarTodos = true;
            this.cboRiesgo.Location = new System.Drawing.Point(75, 13);
            this.cboRiesgo.Name = "cboRiesgo";
            this.cboRiesgo.Size = new System.Drawing.Size(134, 21);
            this.cboRiesgo.TabIndex = 34;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(22, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(50, 13);
            this.lblBase1.TabIndex = 35;
            this.lblBase1.Text = "Riesgo:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(712, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(60, 50);
            this.btnConsultar.TabIndex = 36;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(15, 44);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(57, 13);
            this.lblBase2.TabIndex = 38;
            this.lblBase2.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(75, 40);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(134, 21);
            this.cboAgencia.TabIndex = 37;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(712, 616);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(328, 13);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(102, 20);
            this.dtpFecIni.TabIndex = 41;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(328, 40);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(102, 20);
            this.dtpFecFin.TabIndex = 42;
            // 
            // chcSoloNuevos
            // 
            this.chcSoloNuevos.AutoSize = true;
            this.chcSoloNuevos.Checked = true;
            this.chcSoloNuevos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcSoloNuevos.Location = new System.Drawing.Point(492, 25);
            this.chcSoloNuevos.Name = "chcSoloNuevos";
            this.chcSoloNuevos.Size = new System.Drawing.Size(124, 17);
            this.chcSoloNuevos.TabIndex = 43;
            this.chcSoloNuevos.Text = "Solo clientes nuevos";
            this.chcSoloNuevos.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(646, 616);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 44;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetalle.BackgroundImage")));
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle.Location = new System.Drawing.Point(580, 616);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle.TabIndex = 45;
            this.btnDetalle.Text = "&Detallar";
            this.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle.texto = "&Detallar";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle1_Click);
            // 
            // dtgEvaluaciones
            // 
            this.dtgEvaluaciones.AllowUserToAddRows = false;
            this.dtgEvaluaciones.AllowUserToDeleteRows = false;
            this.dtgEvaluaciones.AllowUserToResizeColumns = false;
            this.dtgEvaluaciones.AllowUserToResizeRows = false;
            this.dtgEvaluaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgEvaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaluaciones.Location = new System.Drawing.Point(6, 19);
            this.dtgEvaluaciones.MultiSelect = false;
            this.dtgEvaluaciones.Name = "dtgEvaluaciones";
            this.dtgEvaluaciones.ReadOnly = true;
            this.dtgEvaluaciones.RowHeadersVisible = false;
            this.dtgEvaluaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaluaciones.Size = new System.Drawing.Size(758, 208);
            this.dtgEvaluaciones.TabIndex = 46;
            this.dtgEvaluaciones.SelectionChanged += new System.EventHandler(this.dtgEvaluaciones_SelectionChanged);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgEvaluaciones);
            this.grbBase1.Location = new System.Drawing.Point(7, 377);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(770, 230);
            this.grbBase1.TabIndex = 47;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Evaluaciones";
            // 
            // btnImprirCli
            // 
            this.btnImprirCli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprirCli.BackgroundImage")));
            this.btnImprirCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprirCli.Location = new System.Drawing.Point(7, 616);
            this.btnImprirCli.Name = "btnImprirCli";
            this.btnImprirCli.Size = new System.Drawing.Size(60, 50);
            this.btnImprirCli.TabIndex = 49;
            this.btnImprirCli.Text = "Imprimir Clientes";
            this.btnImprirCli.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprirCli.UseVisualStyleBackColor = true;
            this.btnImprirCli.Click += new System.EventHandler(this.btnImprirCli_Click);
            // 
            // chcSoloRecurrentes
            // 
            this.chcSoloRecurrentes.AutoSize = true;
            this.chcSoloRecurrentes.Checked = true;
            this.chcSoloRecurrentes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcSoloRecurrentes.Location = new System.Drawing.Point(492, 46);
            this.chcSoloRecurrentes.Name = "chcSoloRecurrentes";
            this.chcSoloRecurrentes.Size = new System.Drawing.Size(142, 17);
            this.chcSoloRecurrentes.TabIndex = 43;
            this.chcSoloRecurrentes.Text = "Solo clientes recurrentes";
            this.chcSoloRecurrentes.UseVisualStyleBackColor = true;
            // 
            // cboRegimenScoring
            // 
            this.cboRegimenScoring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegimenScoring.FormattingEnabled = true;
            this.cboRegimenScoring.lAgregarTodos = true;
            this.cboRegimenScoring.Location = new System.Drawing.Point(75, 67);
            this.cboRegimenScoring.Name = "cboRegimenScoring";
            this.cboRegimenScoring.Size = new System.Drawing.Size(134, 21);
            this.cboRegimenScoring.TabIndex = 50;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(10, 71);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(62, 13);
            this.lblBase5.TabIndex = 51;
            this.lblBase5.Text = "Régimen:";
            // 
            // chcTodos
            // 
            this.chcTodos.AutoSize = true;
            this.chcTodos.Checked = true;
            this.chcTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcTodos.Location = new System.Drawing.Point(492, 67);
            this.chcTodos.Name = "chcTodos";
            this.chcTodos.Size = new System.Drawing.Size(56, 17);
            this.chcTodos.TabIndex = 52;
            this.chcTodos.Text = "Todos";
            this.chcTodos.UseVisualStyleBackColor = true;
            // 
            // lblBaseCustom1
            // 
            this.lblBaseCustom1.AutoSize = true;
            this.lblBaseCustom1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lblBaseCustom1.ForeColor = System.Drawing.Color.Navy;
            this.lblBaseCustom1.Location = new System.Drawing.Point(489, 6);
            this.lblBaseCustom1.Name = "lblBaseCustom1";
            this.lblBaseCustom1.Size = new System.Drawing.Size(120, 13);
            this.lblBaseCustom1.TabIndex = 53;
            this.lblBaseCustom1.Text = "CONSULTA BATCH";
            // 
            // frmMonitorScoringFactorRsgo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 694);
            this.Controls.Add(this.lblBaseCustom1);
            this.Controls.Add(this.chcTodos);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.cboRegimenScoring);
            this.Controls.Add(this.btnImprirCli);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.chcSoloRecurrentes);
            this.Controls.Add(this.chcSoloNuevos);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.cboAgencia);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.cboRiesgo);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtgLista);
            this.Name = "frmMonitorScoringFactorRsgo";
            this.Text = "Monitor por Factor de Riesgo";
            this.Load += new System.EventHandler(this.frmMonitorScoringFactorRsgo_Load);
            this.Controls.SetChildIndex(this.dtgLista, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.cboRiesgo, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.btnConsultar, 0);
            this.Controls.SetChildIndex(this.cboAgencia, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.Controls.SetChildIndex(this.chcSoloNuevos, 0);
            this.Controls.SetChildIndex(this.chcSoloRecurrentes, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnDetalle, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnImprirCli, 0);
            this.Controls.SetChildIndex(this.cboRegimenScoring, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.chcTodos, 0);
            this.Controls.SetChildIndex(this.lblBaseCustom1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvaluaciones)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtgBase dtgLista;
        private GEN.ControlesBase.cboCalifScoring cboRiesgo;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnConsultar btnConsultar;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.chcBase chcSoloNuevos;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnDetalle btnDetalle;
        private GEN.ControlesBase.dtgBase dtgEvaluaciones;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.BotonesBase.btnImprimir btnImprirCli;
        private GEN.ControlesBase.chcBase chcSoloRecurrentes;
        private GEN.ControlesBase.cboRegimenScoring cboRegimenScoring;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.chcBase chcTodos;
        private GEN.ControlesBase.lblBaseCustom lblBaseCustom1;
    }
}