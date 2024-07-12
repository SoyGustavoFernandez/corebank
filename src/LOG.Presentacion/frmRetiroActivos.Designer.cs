namespace LOG.Presentacion
{
    partial class frmRetiroActivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiroActivos));
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtpFeBaja = new GEN.ControlesBase.dtpCorto(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtBase3 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase2 = new GEN.ControlesBase.txtBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dtgActivoOrigen = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAddActivos = new GEN.BotonesBase.btnAgregar();
            this.btnQuitActivos = new GEN.BotonesBase.btnQuitar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboMotBajaActivo = new GEN.ControlesBase.cboMotBajaActivo(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtDescripBaja = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase3.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(348, 350);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(532, 24);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 26;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFeBaja);
            this.grbBase3.Controls.Add(this.txtUsuario);
            this.grbBase3.Controls.Add(this.lblBase4);
            this.grbBase3.Controls.Add(this.lblBase3);
            this.grbBase3.Location = new System.Drawing.Point(228, 12);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(298, 65);
            this.grbBase3.TabIndex = 25;
            this.grbBase3.TabStop = false;
            // 
            // dtpFeBaja
            // 
            this.dtpFeBaja.Location = new System.Drawing.Point(60, 39);
            this.dtpFeBaja.Name = "dtpFeBaja";
            this.dtpFeBaja.Size = new System.Drawing.Size(130, 20);
            this.dtpFeBaja.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(60, 17);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(232, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 42);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(45, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Fecha:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(6, 20);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(55, 13);
            this.lblBase3.TabIndex = 5;
            this.lblBase3.Text = "Usuario:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtBase3);
            this.grbBase2.Controls.Add(this.txtBase2);
            this.grbBase2.Controls.Add(this.txtBase1);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Location = new System.Drawing.Point(12, 12);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(200, 65);
            this.grbBase2.TabIndex = 24;
            this.grbBase2.TabStop = false;
            // 
            // txtBase3
            // 
            this.txtBase3.Enabled = false;
            this.txtBase3.Location = new System.Drawing.Point(119, 17);
            this.txtBase3.Name = "txtBase3";
            this.txtBase3.Size = new System.Drawing.Size(75, 20);
            this.txtBase3.TabIndex = 4;
            // 
            // txtBase2
            // 
            this.txtBase2.Enabled = false;
            this.txtBase2.Location = new System.Drawing.Point(62, 17);
            this.txtBase2.Name = "txtBase2";
            this.txtBase2.Size = new System.Drawing.Size(55, 20);
            this.txtBase2.TabIndex = 3;
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Location = new System.Drawing.Point(62, 39);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(132, 20);
            this.txtBase1.TabIndex = 2;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 42);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(50, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Estado:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Número:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.label1);
            this.grbBase1.Controls.Add(this.dtgActivoOrigen);
            this.grbBase1.Controls.Add(this.btnAddActivos);
            this.grbBase1.Controls.Add(this.btnQuitActivos);
            this.grbBase1.Location = new System.Drawing.Point(12, 76);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(655, 213);
            this.grbBase1.TabIndex = 23;
            this.grbBase1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ORIGEN DEL ACTIVO:";
            // 
            // dtgActivoOrigen
            // 
            this.dtgActivoOrigen.AllowUserToAddRows = false;
            this.dtgActivoOrigen.AllowUserToDeleteRows = false;
            this.dtgActivoOrigen.AllowUserToResizeColumns = false;
            this.dtgActivoOrigen.AllowUserToResizeRows = false;
            this.dtgActivoOrigen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivoOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivoOrigen.Location = new System.Drawing.Point(6, 32);
            this.dtgActivoOrigen.MultiSelect = false;
            this.dtgActivoOrigen.Name = "dtgActivoOrigen";
            this.dtgActivoOrigen.ReadOnly = true;
            this.dtgActivoOrigen.RowHeadersVisible = false;
            this.dtgActivoOrigen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivoOrigen.Size = new System.Drawing.Size(576, 168);
            this.dtgActivoOrigen.TabIndex = 2;
            // 
            // btnAddActivos
            // 
            this.btnAddActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddActivos.BackgroundImage")));
            this.btnAddActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddActivos.Location = new System.Drawing.Point(589, 32);
            this.btnAddActivos.Name = "btnAddActivos";
            this.btnAddActivos.Size = new System.Drawing.Size(60, 50);
            this.btnAddActivos.TabIndex = 4;
            this.btnAddActivos.Text = "&Agregar";
            this.btnAddActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddActivos.UseVisualStyleBackColor = true;
            this.btnAddActivos.Click += new System.EventHandler(this.btnAddActivos_Click);
            // 
            // btnQuitActivos
            // 
            this.btnQuitActivos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitActivos.BackgroundImage")));
            this.btnQuitActivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitActivos.Location = new System.Drawing.Point(589, 89);
            this.btnQuitActivos.Name = "btnQuitActivos";
            this.btnQuitActivos.Size = new System.Drawing.Size(60, 50);
            this.btnQuitActivos.TabIndex = 6;
            this.btnQuitActivos.Text = "&Quitar";
            this.btnQuitActivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitActivos.UseVisualStyleBackColor = true;
            this.btnQuitActivos.Click += new System.EventHandler(this.btnQuitActivos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(532, 350);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(601, 350);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(471, 350);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 20;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(471, 350);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 19;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(410, 350);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(19, 300);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(66, 13);
            this.lblBase5.TabIndex = 29;
            this.lblBase5.Text = "Tipo Baja:";
            // 
            // cboMotBajaActivo
            // 
            this.cboMotBajaActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotBajaActivo.FormattingEnabled = true;
            this.cboMotBajaActivo.Location = new System.Drawing.Point(91, 297);
            this.cboMotBajaActivo.Name = "cboMotBajaActivo";
            this.cboMotBajaActivo.Size = new System.Drawing.Size(241, 21);
            this.cboMotBajaActivo.TabIndex = 30;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(15, 327);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(79, 13);
            this.lblBase6.TabIndex = 31;
            this.lblBase6.Text = "Motivo Baja:";
            // 
            // txtDescripBaja
            // 
            this.txtDescripBaja.Location = new System.Drawing.Point(18, 343);
            this.txtDescripBaja.MaxLength = 350;
            this.txtDescripBaja.Multiline = true;
            this.txtDescripBaja.Name = "txtDescripBaja";
            this.txtDescripBaja.Size = new System.Drawing.Size(314, 57);
            this.txtDescripBaja.TabIndex = 32;
            // 
            // frmRetiroActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 425);
            this.Controls.Add(this.txtDescripBaja);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboMotBajaActivo);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar1);
            this.Name = "frmRetiroActivos";
            this.Text = "Retiro de Activos";
            this.Load += new System.EventHandler(this.frmRetiroActivos_Load);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnBusqueda, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboMotBajaActivo, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtDescripBaja, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivoOrigen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtpCorto dtpFeBaja;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtBase3;
        private GEN.ControlesBase.txtBase txtBase2;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.dtgBase dtgActivoOrigen;
        private GEN.BotonesBase.btnAgregar btnAddActivos;
        private GEN.BotonesBase.btnQuitar btnQuitActivos;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboMotBajaActivo cboMotBajaActivo;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtDescripBaja;
    }
}