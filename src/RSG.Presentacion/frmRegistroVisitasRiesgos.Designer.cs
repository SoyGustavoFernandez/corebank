namespace RSG.Presentacion
{
    partial class frmRegistroVisitasRiesgos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroVisitasRiesgos));
            this.grbBase = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniDetalle1 = new GEN.BotonesBase.btnMiniDetalle(this.components);
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.dtgVisitas = new GEN.ControlesBase.dtgBase(this.components);
            this.dtpPeriodoVisitaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpPeriodoVisitaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblPeriodo = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniEditar1 = new GEN.BotonesBase.btnMiniEditar();
            this.btnMiniQuitar1 = new GEN.BotonesBase.btnMiniQuitar();
            this.btnMiniAgregar1 = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgVisitasClientes = new GEN.ControlesBase.dtgBase(this.components);
            this.cboZona1 = new GEN.ControlesBase.cboZona(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias1 = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.dtpVisitaPerFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpVisitaPerInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnImprimir1 = new GEN.BotonesBase.btnImprimir();
            this.btnMiniQuitar2 = new GEN.BotonesBase.btnMiniQuitar();
            this.grbBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisitas)).BeginInit();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisitasClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase
            // 
            this.grbBase.Controls.Add(this.btnMiniQuitar2);
            this.grbBase.Controls.Add(this.btnMiniDetalle1);
            this.grbBase.Controls.Add(this.btnMiniBusq1);
            this.grbBase.Controls.Add(this.dtgVisitas);
            this.grbBase.Controls.Add(this.dtpPeriodoVisitaFin);
            this.grbBase.Controls.Add(this.dtpPeriodoVisitaInicio);
            this.grbBase.Controls.Add(this.lblBase6);
            this.grbBase.Controls.Add(this.lblPeriodo);
            this.grbBase.Location = new System.Drawing.Point(8, 4);
            this.grbBase.Name = "grbBase";
            this.grbBase.Size = new System.Drawing.Size(657, 164);
            this.grbBase.TabIndex = 0;
            this.grbBase.TabStop = false;
            this.grbBase.Text = "Filtros";
            // 
            // btnMiniDetalle1
            // 
            this.btnMiniDetalle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniDetalle1.BackgroundImage")));
            this.btnMiniDetalle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniDetalle1.Location = new System.Drawing.Point(618, 43);
            this.btnMiniDetalle1.Name = "btnMiniDetalle1";
            this.btnMiniDetalle1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniDetalle1.TabIndex = 3;
            this.btnMiniDetalle1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniDetalle1.UseVisualStyleBackColor = true;
            this.btnMiniDetalle1.Click += new System.EventHandler(this.btnMiniDetalle1_Click);
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(504, 12);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 2;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // dtgVisitas
            // 
            this.dtgVisitas.AllowUserToAddRows = false;
            this.dtgVisitas.AllowUserToDeleteRows = false;
            this.dtgVisitas.AllowUserToResizeColumns = false;
            this.dtgVisitas.AllowUserToResizeRows = false;
            this.dtgVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVisitas.Location = new System.Drawing.Point(6, 43);
            this.dtgVisitas.MultiSelect = false;
            this.dtgVisitas.Name = "dtgVisitas";
            this.dtgVisitas.ReadOnly = true;
            this.dtgVisitas.RowHeadersVisible = false;
            this.dtgVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVisitas.Size = new System.Drawing.Size(605, 113);
            this.dtgVisitas.TabIndex = 16;
            // 
            // dtpPeriodoVisitaFin
            // 
            this.dtpPeriodoVisitaFin.Location = new System.Drawing.Point(342, 17);
            this.dtpPeriodoVisitaFin.Name = "dtpPeriodoVisitaFin";
            this.dtpPeriodoVisitaFin.Size = new System.Drawing.Size(150, 20);
            this.dtpPeriodoVisitaFin.TabIndex = 1;
            // 
            // dtpPeriodoVisitaInicio
            // 
            this.dtpPeriodoVisitaInicio.Location = new System.Drawing.Point(158, 17);
            this.dtpPeriodoVisitaInicio.Name = "dtpPeriodoVisitaInicio";
            this.dtpPeriodoVisitaInicio.Size = new System.Drawing.Size(150, 20);
            this.dtpPeriodoVisitaInicio.TabIndex = 0;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(317, 20);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(23, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Al:";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.Navy;
            this.lblPeriodo.Location = new System.Drawing.Point(8, 20);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(146, 13);
            this.lblPeriodo.TabIndex = 13;
            this.lblPeriodo.Text = "Periodo de Visita desde:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniEditar1);
            this.grbBase1.Controls.Add(this.btnMiniQuitar1);
            this.grbBase1.Controls.Add(this.btnMiniAgregar1);
            this.grbBase1.Controls.Add(this.dtgVisitasClientes);
            this.grbBase1.Controls.Add(this.cboZona1);
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboAgencias1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpVisitaPerFin);
            this.grbBase1.Controls.Add(this.dtpVisitaPerInicio);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(8, 171);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(657, 297);
            this.grbBase1.TabIndex = 1;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Visita";
            // 
            // btnMiniEditar1
            // 
            this.btnMiniEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniEditar1.BackgroundImage")));
            this.btnMiniEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniEditar1.Location = new System.Drawing.Point(616, 168);
            this.btnMiniEditar1.Name = "btnMiniEditar1";
            this.btnMiniEditar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniEditar1.TabIndex = 27;
            this.btnMiniEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniEditar1.UseVisualStyleBackColor = true;
            this.btnMiniEditar1.Click += new System.EventHandler(this.btnMiniEditar1_Click);
            // 
            // btnMiniQuitar1
            // 
            this.btnMiniQuitar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar1.BackgroundImage")));
            this.btnMiniQuitar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar1.Location = new System.Drawing.Point(616, 134);
            this.btnMiniQuitar1.Name = "btnMiniQuitar1";
            this.btnMiniQuitar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar1.TabIndex = 5;
            this.btnMiniQuitar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar1.UseVisualStyleBackColor = true;
            this.btnMiniQuitar1.Click += new System.EventHandler(this.btnMiniQuitar1_Click);
            // 
            // btnMiniAgregar1
            // 
            this.btnMiniAgregar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar1.BackgroundImage")));
            this.btnMiniAgregar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar1.Location = new System.Drawing.Point(616, 100);
            this.btnMiniAgregar1.Name = "btnMiniAgregar1";
            this.btnMiniAgregar1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar1.TabIndex = 4;
            this.btnMiniAgregar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar1.UseVisualStyleBackColor = true;
            this.btnMiniAgregar1.Click += new System.EventHandler(this.btnMiniAgregar1_Click);
            // 
            // dtgVisitasClientes
            // 
            this.dtgVisitasClientes.AllowUserToAddRows = false;
            this.dtgVisitasClientes.AllowUserToDeleteRows = false;
            this.dtgVisitasClientes.AllowUserToResizeColumns = false;
            this.dtgVisitasClientes.AllowUserToResizeRows = false;
            this.dtgVisitasClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgVisitasClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVisitasClientes.Location = new System.Drawing.Point(11, 100);
            this.dtgVisitasClientes.MultiSelect = false;
            this.dtgVisitasClientes.Name = "dtgVisitasClientes";
            this.dtgVisitasClientes.ReadOnly = true;
            this.dtgVisitasClientes.RowHeadersVisible = false;
            this.dtgVisitasClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVisitasClientes.Size = new System.Drawing.Size(600, 187);
            this.dtgVisitasClientes.TabIndex = 26;
            // 
            // cboZona1
            // 
            this.cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona1.FormattingEnabled = true;
            this.cboZona1.Location = new System.Drawing.Point(155, 48);
            this.cboZona1.Name = "cboZona1";
            this.cboZona1.Size = new System.Drawing.Size(238, 21);
            this.cboZona1.TabIndex = 2;
            this.cboZona1.SelectedIndexChanged += new System.EventHandler(this.cboZona1_SelectedIndexChanged);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(97, 78);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(57, 13);
            this.lblBase5.TabIndex = 24;
            this.lblBase5.Text = "Agencia:";
            // 
            // cboAgencias1
            // 
            this.cboAgencias1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias1.FormattingEnabled = true;
            this.cboAgencias1.Location = new System.Drawing.Point(155, 75);
            this.cboAgencias1.Name = "cboAgencias1";
            this.cboAgencias1.Size = new System.Drawing.Size(238, 21);
            this.cboAgencias1.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(113, 51);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(41, 13);
            this.lblBase3.TabIndex = 20;
            this.lblBase3.Text = "Zona:";
            // 
            // dtpVisitaPerFin
            // 
            this.dtpVisitaPerFin.Location = new System.Drawing.Point(339, 19);
            this.dtpVisitaPerFin.Name = "dtpVisitaPerFin";
            this.dtpVisitaPerFin.Size = new System.Drawing.Size(164, 20);
            this.dtpVisitaPerFin.TabIndex = 1;
            // 
            // dtpVisitaPerInicio
            // 
            this.dtpVisitaPerInicio.Location = new System.Drawing.Point(155, 19);
            this.dtpVisitaPerInicio.Name = "dtpVisitaPerInicio";
            this.dtpVisitaPerInicio.Size = new System.Drawing.Size(150, 20);
            this.dtpVisitaPerInicio.TabIndex = 0;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(314, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(23, 13);
            this.lblBase1.TabIndex = 16;
            this.lblBase1.Text = "Al:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(145, 13);
            this.lblBase2.TabIndex = 17;
            this.lblBase2.Text = "Periodo de visita desde:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(602, 474);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 7;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(339, 474);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 3;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(537, 474);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(471, 474);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 5;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(405, 474);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 4;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnImprimir1
            // 
            this.btnImprimir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir1.BackgroundImage")));
            this.btnImprimir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir1.Location = new System.Drawing.Point(273, 474);
            this.btnImprimir1.Name = "btnImprimir1";
            this.btnImprimir1.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir1.TabIndex = 2;
            this.btnImprimir1.Text = "Imprimir";
            this.btnImprimir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir1.UseVisualStyleBackColor = true;
            this.btnImprimir1.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // btnMiniQuitar2
            // 
            this.btnMiniQuitar2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar2.BackgroundImage")));
            this.btnMiniQuitar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar2.Location = new System.Drawing.Point(617, 77);
            this.btnMiniQuitar2.Name = "btnMiniQuitar2";
            this.btnMiniQuitar2.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar2.TabIndex = 17;
            this.btnMiniQuitar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar2.UseVisualStyleBackColor = true;
            this.btnMiniQuitar2.Click += new System.EventHandler(this.btnMiniQuitar2_Click);
            // 
            // frmRegistroVisitasRiesgos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 552);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase);
            this.Controls.Add(this.btnImprimir1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmRegistroVisitasRiesgos";
            this.Text = "Registro de visitas";
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnImprimir1, 0);
            this.Controls.SetChildIndex(this.grbBase, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase.ResumeLayout(false);
            this.grbBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisitas)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVisitasClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase;
        private GEN.BotonesBase.btnMiniDetalle btnMiniDetalle1;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
        private GEN.ControlesBase.dtgBase dtgVisitas;
        private GEN.ControlesBase.dtpCorto dtpPeriodoVisitaFin;
        private GEN.ControlesBase.dtpCorto dtpPeriodoVisitaInicio;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblPeriodo;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.dtpCorto dtpVisitaPerFin;
        private GEN.ControlesBase.dtpCorto dtpVisitaPerInicio;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboAgencias cboAgencias1;
        private GEN.ControlesBase.dtgBase dtgVisitasClientes;
        private GEN.ControlesBase.cboZona cboZona1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar1;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnImprimir btnImprimir1;
        private GEN.BotonesBase.btnMiniEditar btnMiniEditar1;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar2;
    }
}

