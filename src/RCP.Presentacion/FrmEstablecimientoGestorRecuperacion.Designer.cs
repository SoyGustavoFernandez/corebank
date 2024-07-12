namespace RCP.Presentacion
{
    partial class FrmEstablecimientoGestorRecuperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstablecimientoGestorRecuperacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxEstabAsignado = new System.Windows.Forms.GroupBox();
            this.btnMiniQuitar = new GEN.BotonesBase.btnMiniQuitar();
            this.dtgEstabAgenciaAsignado = new GEN.ControlesBase.dtgBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgGestorRecuperacion = new GEN.ControlesBase.dtgBase(this.components);
            this.gbxEstabDisponible = new System.Windows.Forms.GroupBox();
            this.btnMiniAgregar = new GEN.BotonesBase.btnMiniAgregar();
            this.dtgEstablecimientoAgencia = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboRegion = new GEN.ControlesBase.cboZona(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.panel1.SuspendLayout();
            this.gbxEstabAsignado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstabAgenciaAsignado)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGestorRecuperacion)).BeginInit();
            this.gbxEstabDisponible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstablecimientoAgencia)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gbxEstabAsignado);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.gbxEstabDisponible);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 498);
            this.panel1.TabIndex = 2;
            // 
            // gbxEstabAsignado
            // 
            this.gbxEstabAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEstabAsignado.Controls.Add(this.btnMiniQuitar);
            this.gbxEstabAsignado.Controls.Add(this.dtgEstabAgenciaAsignado);
            this.gbxEstabAsignado.Location = new System.Drawing.Point(358, 322);
            this.gbxEstabAsignado.Name = "gbxEstabAsignado";
            this.gbxEstabAsignado.Size = new System.Drawing.Size(363, 173);
            this.gbxEstabAsignado.TabIndex = 3;
            this.gbxEstabAsignado.TabStop = false;
            this.gbxEstabAsignado.Text = "Establecimientos Asignados";
            // 
            // btnMiniQuitar
            // 
            this.btnMiniQuitar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniQuitar.BackgroundImage")));
            this.btnMiniQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniQuitar.Location = new System.Drawing.Point(322, 13);
            this.btnMiniQuitar.Name = "btnMiniQuitar";
            this.btnMiniQuitar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniQuitar.TabIndex = 3;
            this.btnMiniQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniQuitar.UseVisualStyleBackColor = true;
            this.btnMiniQuitar.Click += new System.EventHandler(this.btnMiniQuitar_Click);
            // 
            // dtgEstabAgenciaAsignado
            // 
            this.dtgEstabAgenciaAsignado.AllowUserToAddRows = false;
            this.dtgEstabAgenciaAsignado.AllowUserToDeleteRows = false;
            this.dtgEstabAgenciaAsignado.AllowUserToResizeColumns = false;
            this.dtgEstabAgenciaAsignado.AllowUserToResizeRows = false;
            this.dtgEstabAgenciaAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEstabAgenciaAsignado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEstabAgenciaAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstabAgenciaAsignado.Location = new System.Drawing.Point(11, 43);
            this.dtgEstabAgenciaAsignado.MultiSelect = false;
            this.dtgEstabAgenciaAsignado.Name = "dtgEstabAgenciaAsignado";
            this.dtgEstabAgenciaAsignado.ReadOnly = true;
            this.dtgEstabAgenciaAsignado.RowHeadersVisible = false;
            this.dtgEstabAgenciaAsignado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEstabAgenciaAsignado.Size = new System.Drawing.Size(346, 124);
            this.dtgEstabAgenciaAsignado.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgGestorRecuperacion);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 313);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestores de Recuperacion";
            // 
            // dtgGestorRecuperacion
            // 
            this.dtgGestorRecuperacion.AllowUserToAddRows = false;
            this.dtgGestorRecuperacion.AllowUserToDeleteRows = false;
            this.dtgGestorRecuperacion.AllowUserToResizeColumns = false;
            this.dtgGestorRecuperacion.AllowUserToResizeRows = false;
            this.dtgGestorRecuperacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGestorRecuperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGestorRecuperacion.Location = new System.Drawing.Point(9, 19);
            this.dtgGestorRecuperacion.MultiSelect = false;
            this.dtgGestorRecuperacion.Name = "dtgGestorRecuperacion";
            this.dtgGestorRecuperacion.ReadOnly = true;
            this.dtgGestorRecuperacion.RowHeadersVisible = false;
            this.dtgGestorRecuperacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgGestorRecuperacion.Size = new System.Drawing.Size(703, 288);
            this.dtgGestorRecuperacion.TabIndex = 0;
            this.dtgGestorRecuperacion.SelectionChanged += new System.EventHandler(this.dtgGestorRecuperacion_SelectionChanged);
            // 
            // gbxEstabDisponible
            // 
            this.gbxEstabDisponible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEstabDisponible.Controls.Add(this.btnMiniAgregar);
            this.gbxEstabDisponible.Controls.Add(this.dtgEstablecimientoAgencia);
            this.gbxEstabDisponible.Controls.Add(this.lblBase1);
            this.gbxEstabDisponible.Controls.Add(this.cboRegion);
            this.gbxEstabDisponible.Location = new System.Drawing.Point(1, 322);
            this.gbxEstabDisponible.Name = "gbxEstabDisponible";
            this.gbxEstabDisponible.Size = new System.Drawing.Size(357, 173);
            this.gbxEstabDisponible.TabIndex = 0;
            this.gbxEstabDisponible.TabStop = false;
            this.gbxEstabDisponible.Text = "Establecimientos Disponibles";
            // 
            // btnMiniAgregar
            // 
            this.btnMiniAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAgregar.BackgroundImage")));
            this.btnMiniAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAgregar.Location = new System.Drawing.Point(316, 13);
            this.btnMiniAgregar.Name = "btnMiniAgregar";
            this.btnMiniAgregar.Size = new System.Drawing.Size(36, 28);
            this.btnMiniAgregar.TabIndex = 4;
            this.btnMiniAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAgregar.UseVisualStyleBackColor = true;
            this.btnMiniAgregar.Click += new System.EventHandler(this.btnMiniAgregar_Click);
            // 
            // dtgEstablecimientoAgencia
            // 
            this.dtgEstablecimientoAgencia.AllowUserToAddRows = false;
            this.dtgEstablecimientoAgencia.AllowUserToDeleteRows = false;
            this.dtgEstablecimientoAgencia.AllowUserToResizeColumns = false;
            this.dtgEstablecimientoAgencia.AllowUserToResizeRows = false;
            this.dtgEstablecimientoAgencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEstablecimientoAgencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEstablecimientoAgencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstablecimientoAgencia.Location = new System.Drawing.Point(11, 43);
            this.dtgEstablecimientoAgencia.MultiSelect = false;
            this.dtgEstablecimientoAgencia.Name = "dtgEstablecimientoAgencia";
            this.dtgEstablecimientoAgencia.ReadOnly = true;
            this.dtgEstablecimientoAgencia.RowHeadersVisible = false;
            this.dtgEstablecimientoAgencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEstablecimientoAgencia.Size = new System.Drawing.Size(340, 124);
            this.dtgEstablecimientoAgencia.TabIndex = 2;
            this.dtgEstablecimientoAgencia.SelectionChanged += new System.EventHandler(this.dtgEstablecimientoAgencia_SelectionChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(14, 21);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(51, 13);
            this.lblBase1.TabIndex = 1;
            this.lblBase1.Text = "Region:";
            // 
            // cboRegion
            // 
            this.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Location = new System.Drawing.Point(81, 17);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(169, 21);
            this.cboRegion.TabIndex = 0;
            this.cboRegion.SelectionChangeCommitted += new System.EventHandler(this.cboRegion_SelectionChangeCommitted);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.btnGrabar);
            this.panel2.Location = new System.Drawing.Point(0, 496);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(726, 60);
            this.panel2.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(595, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(661, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(529, 5);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // FrmEstablecimientoGestorRecuperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEstablecimientoGestorRecuperacion";
            this.Text = "Asignacion de Establecimiento a Gestor de Recuperacion";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.gbxEstabAsignado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstabAgenciaAsignado)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGestorRecuperacion)).EndInit();
            this.gbxEstabDisponible.ResumeLayout(false);
            this.gbxEstabDisponible.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstablecimientoAgencia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.dtgBase dtgGestorRecuperacion;
        private System.Windows.Forms.GroupBox gbxEstabDisponible;
        private GEN.ControlesBase.dtgBase dtgEstablecimientoAgencia;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboZona cboRegion;
        private System.Windows.Forms.GroupBox gbxEstabAsignado;
        private GEN.ControlesBase.dtgBase dtgEstabAgenciaAsignado;
        private GEN.BotonesBase.btnMiniQuitar btnMiniQuitar;
        private GEN.BotonesBase.btnMiniAgregar btnMiniAgregar;
    }
}