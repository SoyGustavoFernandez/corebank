namespace CRE.Presentacion
{
    partial class frmMantMargenGanaciaActividadInt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantMargenGanaciaActividadInt));
            this.dtgActividadConfiguracion = new GEN.ControlesBase.dtgBase(this.components);
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.conActividadCIIU = new GEN.ControlesBase.conActividadCIIU();
            this.cboSectorCliente = new GEN.ControlesBase.cboSector(this.components);
            this.txtMargenGanancia = new GEN.ControlesBase.txtNumRea(this.components);
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.cboSectorEconomico = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadConfiguracion)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgActividadConfiguracion
            // 
            this.dtgActividadConfiguracion.AllowUserToAddRows = false;
            this.dtgActividadConfiguracion.AllowUserToDeleteRows = false;
            this.dtgActividadConfiguracion.AllowUserToResizeColumns = false;
            this.dtgActividadConfiguracion.AllowUserToResizeRows = false;
            this.dtgActividadConfiguracion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgActividadConfiguracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActividadConfiguracion.Location = new System.Drawing.Point(7, 144);
            this.dtgActividadConfiguracion.MultiSelect = false;
            this.dtgActividadConfiguracion.Name = "dtgActividadConfiguracion";
            this.dtgActividadConfiguracion.ReadOnly = true;
            this.dtgActividadConfiguracion.RowHeadersVisible = false;
            this.dtgActividadConfiguracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActividadConfiguracion.Size = new System.Drawing.Size(570, 150);
            this.dtgActividadConfiguracion.TabIndex = 2;
            this.dtgActividadConfiguracion.SelectionChanged += new System.EventHandler(this.dtgActividadConfiguracion_SelectionChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Location = new System.Drawing.Point(337, 304);
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
            this.btnCancelar.Location = new System.Drawing.Point(457, 304);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(397, 304);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(517, 304);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // conActividadCIIU
            // 
            this.conActividadCIIU.AutoSize = true;
            this.conActividadCIIU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.conActividadCIIU.Location = new System.Drawing.Point(119, 19);
            this.conActividadCIIU.Name = "conActividadCIIU";
            this.conActividadCIIU.Size = new System.Drawing.Size(388, 28);
            this.conActividadCIIU.TabIndex = 7;
            // 
            // cboSectorCliente
            // 
            this.cboSectorCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSectorCliente.FormattingEnabled = true;
            this.cboSectorCliente.Location = new System.Drawing.Point(214, 70);
            this.cboSectorCliente.Name = "cboSectorCliente";
            this.cboSectorCliente.Size = new System.Drawing.Size(240, 21);
            this.cboSectorCliente.TabIndex = 9;
            // 
            // txtMargenGanancia
            // 
            this.txtMargenGanancia.FormatoDecimal = false;
            this.txtMargenGanancia.Location = new System.Drawing.Point(214, 94);
            this.txtMargenGanancia.Name = "txtMargenGanancia";
            this.txtMargenGanancia.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMargenGanancia.nNumDecimales = 4;
            this.txtMargenGanancia.nvalor = 0D;
            this.txtMargenGanancia.Size = new System.Drawing.Size(241, 20);
            this.txtMargenGanancia.TabIndex = 10;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(277, 304);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cboSectorEconomico
            // 
            this.cboSectorEconomico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSectorEconomico.FormattingEnabled = true;
            this.cboSectorEconomico.Location = new System.Drawing.Point(214, 46);
            this.cboSectorEconomico.Name = "cboSectorEconomico";
            this.cboSectorEconomico.Size = new System.Drawing.Size(240, 21);
            this.cboSectorEconomico.TabIndex = 12;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(116, 50);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(84, 13);
            this.lblBase1.TabIndex = 13;
            this.lblBase1.Text = "Sector Econ.:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(116, 98);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(54, 13);
            this.lblBase2.TabIndex = 14;
            this.lblBase2.Text = "Margen:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(116, 74);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(49, 13);
            this.lblBase3.TabIndex = 15;
            this.lblBase3.Text = "Sector:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.cboSectorCliente);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.txtMargenGanancia);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboSectorEconomico);
            this.grbBase1.Controls.Add(this.conActividadCIIU);
            this.grbBase1.Location = new System.Drawing.Point(7, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(570, 132);
            this.grbBase1.TabIndex = 16;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle Configuración";
            // 
            // frmMantMargenGanaciaActividadInt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 391);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dtgActividadConfiguracion);
            this.Name = "frmMantMargenGanaciaActividadInt";
            this.Text = "Margen de Ganancia - Actividad Interna";
            this.Controls.SetChildIndex(this.dtgActividadConfiguracion, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActividadConfiguracion)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.dtgBase dtgActividadConfiguracion;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnEditar btnEditar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.conActividadCIIU conActividadCIIU;
        private GEN.ControlesBase.cboSector cboSectorCliente;
        private GEN.ControlesBase.txtNumRea txtMargenGanancia;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.ControlesBase.cboBase cboSectorEconomico;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.grbBase grbBase1;
    }
}