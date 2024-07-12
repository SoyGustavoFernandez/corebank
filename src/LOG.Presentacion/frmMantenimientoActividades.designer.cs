namespace LOG.Presentacion
{
    partial class frmMantenimientoActividades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoActividades));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnMiniBusq = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.txtCodigoActividad = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.cboTipActLogistica = new GEN.ControlesBase.cboBase(this.components);
            this.chcHabilitarActividad = new GEN.ControlesBase.chcBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtDescripcion = new GEN.ControlesBase.txtBase(this.components);
            this.cboArea = new GEN.ControlesBase.cboArea(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgActividades = new GEN.ControlesBase.dtgBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividades)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.btnMiniBusq);
            this.grbBase1.Controls.Add(this.txtCodigoActividad);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(14, 6);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(699, 44);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar Actividad";
            // 
            // btnMiniBusq
            // 
            this.btnMiniBusq.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq.BackgroundImage")));
            this.btnMiniBusq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq.Location = new System.Drawing.Point(424, 11);
            this.btnMiniBusq.Name = "btnMiniBusq";
            this.btnMiniBusq.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq.TabIndex = 2;
            this.btnMiniBusq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq.UseVisualStyleBackColor = true;
            this.btnMiniBusq.Click += new System.EventHandler(this.btnMiniBusq_Click);
            // 
            // txtCodigoActividad
            // 
            this.txtCodigoActividad.Location = new System.Drawing.Point(322, 14);
            this.txtCodigoActividad.Name = "txtCodigoActividad";
            this.txtCodigoActividad.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoActividad.TabIndex = 1;
            this.txtCodigoActividad.TextChanged += new System.EventHandler(this.txtCodigoActividad_TextChanged);
            this.txtCodigoActividad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoActividad_KeyDown);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(204, 17);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Código Actividad :";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.cboAgencias);
            this.grbBase2.Controls.Add(this.cboTipActLogistica);
            this.grbBase2.Controls.Add(this.chcHabilitarActividad);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.txtDescripcion);
            this.grbBase2.Controls.Add(this.cboArea);
            this.grbBase2.Location = new System.Drawing.Point(12, 53);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(699, 147);
            this.grbBase2.TabIndex = 1;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos Actividad Logística";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(242, 13);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(299, 21);
            this.cboAgencias.TabIndex = 1;
            // 
            // cboTipActLogistica
            // 
            this.cboTipActLogistica.FormattingEnabled = true;
            this.cboTipActLogistica.Location = new System.Drawing.Point(242, 67);
            this.cboTipActLogistica.Name = "cboTipActLogistica";
            this.cboTipActLogistica.Size = new System.Drawing.Size(299, 21);
            this.cboTipActLogistica.TabIndex = 5;
            // 
            // chcHabilitarActividad
            // 
            this.chcHabilitarActividad.AutoSize = true;
            this.chcHabilitarActividad.Location = new System.Drawing.Point(430, 118);
            this.chcHabilitarActividad.Name = "chcHabilitarActividad";
            this.chcHabilitarActividad.Size = new System.Drawing.Size(111, 17);
            this.chcHabilitarActividad.TabIndex = 8;
            this.chcHabilitarActividad.Text = "Habilitar Actividad";
            this.chcHabilitarActividad.UseVisualStyleBackColor = true;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(154, 97);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(82, 13);
            this.lblBase5.TabIndex = 6;
            this.lblBase5.Text = "Descripción :";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(87, 70);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(149, 13);
            this.lblBase4.TabIndex = 4;
            this.lblBase4.Text = "Tipo Actividad Logística :";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(140, 43);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(96, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Área Personal :";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(175, 16);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(61, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Agencia :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(242, 94);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(299, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // cboArea
            // 
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(242, 40);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(299, 21);
            this.cboArea.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(584, 470);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(374, 470);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(514, 470);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(654, 470);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgActividades);
            this.grbBase3.Location = new System.Drawing.Point(12, 205);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(701, 259);
            this.grbBase3.TabIndex = 2;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Cuadro de Actividades";
            // 
            // dtgActividades
            // 
            this.dtgActividades.AllowUserToAddRows = false;
            this.dtgActividades.AllowUserToDeleteRows = false;
            this.dtgActividades.AllowUserToResizeColumns = false;
            this.dtgActividades.AllowUserToResizeRows = false;
            this.dtgActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividades.Location = new System.Drawing.Point(6, 19);
            this.dtgActividades.MultiSelect = false;
            this.dtgActividades.Name = "dtgActividades";
            this.dtgActividades.ReadOnly = true;
            this.dtgActividades.RowHeadersVisible = false;
            this.dtgActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActividades.Size = new System.Drawing.Size(689, 234);
            this.dtgActividades.TabIndex = 0;
            this.dtgActividades.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActividades_CellEnter);
            this.dtgActividades.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgActividades_RowEnter);
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(444, 470);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 4;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // frmMantenimientoActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 545);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmMantenimientoActividades";
            this.Text = "Mantenimiento Actividades";
            this.Load += new System.EventHandler(this.frmMantenimientoActividades_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtDescripcion;
        private GEN.ControlesBase.cboArea cboArea;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigoActividad;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.chcBase chcHabilitarActividad;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboTipActLogistica;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgActividades;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq;
        private GEN.BotonesBase.btnEditar btnEditar1;
    }
}