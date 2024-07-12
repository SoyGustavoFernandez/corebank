namespace CRE.Presentacion
{
    partial class frmActaAprobCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActaAprobCred));
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnImpActaCredito = new GEN.BotonesBase.btnImprimir();
            this.btnActaNivAprob = new GEN.BotonesBase.btnImprimir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcNivAprob = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.chcAgencia = new GEN.ControlesBase.chcBase(this.components);
            this.chcZona = new GEN.ControlesBase.chcBase(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboNivelAprobacion1 = new GEN.ControlesBase.cboNivelAprobacion(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnMiniBusq = new GEN.BotonesBase.btnBusqueda();
            this.dtgSolicitudes = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtpActaAprobIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpActaAprobFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).BeginInit();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(494, 409);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 2;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnImpActaCredito
            // 
            this.btnImpActaCredito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImpActaCredito.BackgroundImage")));
            this.btnImpActaCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImpActaCredito.Location = new System.Drawing.Point(471, 19);
            this.btnImpActaCredito.Name = "btnImpActaCredito";
            this.btnImpActaCredito.Size = new System.Drawing.Size(60, 50);
            this.btnImpActaCredito.TabIndex = 7;
            this.btnImpActaCredito.Text = "&Imprimir";
            this.btnImpActaCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImpActaCredito.UseVisualStyleBackColor = true;
            this.btnImpActaCredito.Click += new System.EventHandler(this.btnImpActaCredito_Click);
            // 
            // btnActaNivAprob
            // 
            this.btnActaNivAprob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActaNivAprob.BackgroundImage")));
            this.btnActaNivAprob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActaNivAprob.Location = new System.Drawing.Point(471, 40);
            this.btnActaNivAprob.Name = "btnActaNivAprob";
            this.btnActaNivAprob.Size = new System.Drawing.Size(60, 50);
            this.btnActaNivAprob.TabIndex = 8;
            this.btnActaNivAprob.Text = "&Imprimir";
            this.btnActaNivAprob.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActaNivAprob.UseVisualStyleBackColor = true;
            this.btnActaNivAprob.Click += new System.EventHandler(this.btnActaNivAprob_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.chcNivAprob);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.chcAgencia);
            this.grbBase1.Controls.Add(this.btnActaNivAprob);
            this.grbBase1.Controls.Add(this.chcZona);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboNivelAprobacion1);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.cboZona1);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(542, 120);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Actas de Resolución de Créditos";
            // 
            // chcNivAprob
            // 
            this.chcNivAprob.AutoSize = true;
            this.chcNivAprob.Checked = true;
            this.chcNivAprob.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcNivAprob.Enabled = false;
            this.chcNivAprob.Location = new System.Drawing.Point(373, 40);
            this.chcNivAprob.Name = "chcNivAprob";
            this.chcNivAprob.Size = new System.Drawing.Size(51, 17);
            this.chcNivAprob.TabIndex = 15;
            this.chcNivAprob.Text = "Filtrar";
            this.chcNivAprob.UseVisualStyleBackColor = true;
            this.chcNivAprob.CheckedChanged += new System.EventHandler(this.chcNivAprob_CheckedChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(231, 19);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(39, 13);
            this.lblBase2.TabIndex = 2;
            this.lblBase2.Text = "Hasta";
            // 
            // chcAgencia
            // 
            this.chcAgencia.AutoSize = true;
            this.chcAgencia.Checked = true;
            this.chcAgencia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcAgencia.Location = new System.Drawing.Point(373, 86);
            this.chcAgencia.Name = "chcAgencia";
            this.chcAgencia.Size = new System.Drawing.Size(51, 17);
            this.chcAgencia.TabIndex = 17;
            this.chcAgencia.Text = "Filtrar";
            this.chcAgencia.UseVisualStyleBackColor = true;
            this.chcAgencia.CheckedChanged += new System.EventHandler(this.chcAgencia_CheckedChanged);
            // 
            // chcZona
            // 
            this.chcZona.AutoSize = true;
            this.chcZona.Location = new System.Drawing.Point(373, 63);
            this.chcZona.Name = "chcZona";
            this.chcZona.Size = new System.Drawing.Size(51, 17);
            this.chcZona.TabIndex = 16;
            this.chcZona.Text = "Filtrar";
            this.chcZona.UseVisualStyleBackColor = true;
            this.chcZona.CheckedChanged += new System.EventHandler(this.chcZona_CheckedChanged);
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(134, 15);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(95, 20);
            this.dtpFecIni.TabIndex = 1;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(55, 41);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(77, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Nivel Aprob.";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(106, 19);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(26, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Del";
            // 
            // cboNivelAprobacion1
            // 
            this.cboNivelAprobacion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelAprobacion1.FormattingEnabled = true;
            this.cboNivelAprobacion1.Location = new System.Drawing.Point(134, 37);
            this.cboNivelAprobacion1.Name = "cboNivelAprobacion1";
            this.cboNivelAprobacion1.Size = new System.Drawing.Size(233, 21);
            this.cboNivelAprobacion1.TabIndex = 5;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(272, 15);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(95, 20);
            this.dtpFecFin.TabIndex = 3;
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(134, 60);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(233, 21);
            this.cboZona1.TabIndex = 11;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(96, 64);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(36, 13);
            this.lblBase4.TabIndex = 13;
            this.lblBase4.Text = "Zona";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(80, 87);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(52, 13);
            this.lblBase5.TabIndex = 14;
            this.lblBase5.Text = "Agencia";
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(373, 19);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(60, 50);
            this.btnMiniBusq.TabIndex = 18;
            this.btnMiniBusq.Text = "&Buscar";
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // dtgSolicitudes
            // 
            this.dtgSolicitudes.AllowUserToAddRows = false;
            this.dtgSolicitudes.AllowUserToDeleteRows = false;
            this.dtgSolicitudes.AllowUserToResizeColumns = false;
            this.dtgSolicitudes.AllowUserToResizeRows = false;
            this.dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolicitudes.Location = new System.Drawing.Point(6, 75);
            this.dtgSolicitudes.MultiSelect = false;
            this.dtgSolicitudes.Name = "dtgSolicitudes";
            this.dtgSolicitudes.ReadOnly = true;
            this.dtgSolicitudes.RowHeadersVisible = false;
            this.dtgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolicitudes.Size = new System.Drawing.Size(525, 177);
            this.dtgSolicitudes.TabIndex = 0;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgSolicitudes);
            this.grbBase3.Controls.Add(this.btnMiniBusq);
            this.grbBase3.Controls.Add(this.lblBase6);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.btnImpActaCredito);
            this.grbBase3.Controls.Add(this.dtpActaAprobIni);
            this.grbBase3.Controls.Add(this.dtpActaAprobFin);
            this.grbBase3.Location = new System.Drawing.Point(12, 138);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(542, 265);
            this.grbBase3.TabIndex = 18;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Acta del Crédito";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(231, 36);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(39, 13);
            this.lblBase6.TabIndex = 2;
            this.lblBase6.Text = "Hasta";
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(106, 36);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(26, 13);
            this.lblBase7.TabIndex = 0;
            this.lblBase7.Text = "Del";
            // 
            // dtpActaAprobIni
            // 
            this.dtpActaAprobIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActaAprobIni.Location = new System.Drawing.Point(134, 32);
            this.dtpActaAprobIni.Name = "dtpActaAprobIni";
            this.dtpActaAprobIni.Size = new System.Drawing.Size(95, 20);
            this.dtpActaAprobIni.TabIndex = 1;
            // 
            // dtpActaAprobFin
            // 
            this.dtpActaAprobFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActaAprobFin.Location = new System.Drawing.Point(272, 32);
            this.dtpActaAprobFin.Name = "dtpActaAprobFin";
            this.dtpActaAprobFin.Size = new System.Drawing.Size(95, 20);
            this.dtpActaAprobFin.TabIndex = 3;
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(134, 83);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(233, 21);
            this.cboAgencias.TabIndex = 19;
            // 
            // frmActaAprobCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(564, 487);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmActaAprobCred";
            this.Text = "Impresión de Actas de Créditos";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolicitudes)).EndInit();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnImprimir btnImpActaCredito;
        private GEN.BotonesBase.btnImprimir btnActaNivAprob;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtgBase dtgSolicitudes;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboNivelAprobacion cboNivelAprobacion1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.ControlesBase.chcBase chcAgencia;
        private GEN.ControlesBase.chcBase chcZona;
        private GEN.ControlesBase.chcBase chcNivAprob;
        private GEN.BotonesBase.btnBusqueda btnMiniBusq;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.dtpCorto dtpActaAprobIni;
        private GEN.ControlesBase.dtpCorto dtpActaAprobFin;
        private GEN.ControlesBase.cboAgencias cboAgencias;
    }
}

