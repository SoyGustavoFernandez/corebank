namespace ADM.Presentacion
{
    partial class frmMantenimientoLimiteCoberFSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoLimiteCoberFSD));
            this.grbBuscarFSD = new GEN.ControlesBase.grbBase(this.components);
            this.dtBuscarFechaFinFSD = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtBuscarFechaInicioFSD = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnBusqueda1 = new GEN.BotonesBase.btnBusqueda();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbAsignarFSD = new GEN.ControlesBase.grbBase(this.components);
            this.txtMontoMaxFSD = new GEN.ControlesBase.txtNumRea(this.components);
            this.chcVigencia = new GEN.ControlesBase.chcBase(this.components);
            this.dtFechaInicioFSD = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtgLimiteCoberFSD = new GEN.ControlesBase.dtgBase(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtFechaFinFSD = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBuscarFSD.SuspendLayout();
            this.grbAsignarFSD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLimiteCoberFSD)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBuscarFSD
            // 
            this.grbBuscarFSD.Controls.Add(this.dtBuscarFechaFinFSD);
            this.grbBuscarFSD.Controls.Add(this.dtBuscarFechaInicioFSD);
            this.grbBuscarFSD.Controls.Add(this.btnBusqueda1);
            this.grbBuscarFSD.Controls.Add(this.lblBase2);
            this.grbBuscarFSD.Controls.Add(this.lblBase1);
            this.grbBuscarFSD.Location = new System.Drawing.Point(12, 12);
            this.grbBuscarFSD.Name = "grbBuscarFSD";
            this.grbBuscarFSD.Size = new System.Drawing.Size(366, 99);
            this.grbBuscarFSD.TabIndex = 2;
            this.grbBuscarFSD.TabStop = false;
            this.grbBuscarFSD.Text = "Buscar Limite de Cobertura FSD";
            // 
            // dtBuscarFechaFinFSD
            // 
            this.dtBuscarFechaFinFSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarFechaFinFSD.Location = new System.Drawing.Point(131, 56);
            this.dtBuscarFechaFinFSD.Name = "dtBuscarFechaFinFSD";
            this.dtBuscarFechaFinFSD.Size = new System.Drawing.Size(125, 20);
            this.dtBuscarFechaFinFSD.TabIndex = 7;
            // 
            // dtBuscarFechaInicioFSD
            // 
            this.dtBuscarFechaInicioFSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBuscarFechaInicioFSD.Location = new System.Drawing.Point(131, 30);
            this.dtBuscarFechaInicioFSD.Name = "dtBuscarFechaInicioFSD";
            this.dtBuscarFechaInicioFSD.Size = new System.Drawing.Size(125, 20);
            this.dtBuscarFechaInicioFSD.TabIndex = 6;
            // 
            // btnBusqueda1
            // 
            this.btnBusqueda1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda1.BackgroundImage")));
            this.btnBusqueda1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda1.Location = new System.Drawing.Point(279, 29);
            this.btnBusqueda1.Name = "btnBusqueda1";
            this.btnBusqueda1.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda1.TabIndex = 4;
            this.btnBusqueda1.Text = "&Buscar";
            this.btnBusqueda1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda1.UseVisualStyleBackColor = true;
            this.btnBusqueda1.Click += new System.EventHandler(this.btnBusqueda1_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(42, 56);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 3;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(42, 30);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 2;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // grbAsignarFSD
            // 
            this.grbAsignarFSD.Controls.Add(this.dtFechaFinFSD);
            this.grbAsignarFSD.Controls.Add(this.txtMontoMaxFSD);
            this.grbAsignarFSD.Controls.Add(this.chcVigencia);
            this.grbAsignarFSD.Controls.Add(this.dtFechaInicioFSD);
            this.grbAsignarFSD.Controls.Add(this.lblBase5);
            this.grbAsignarFSD.Controls.Add(this.lblBase3);
            this.grbAsignarFSD.Controls.Add(this.lblBase4);
            this.grbAsignarFSD.Location = new System.Drawing.Point(12, 135);
            this.grbAsignarFSD.Name = "grbAsignarFSD";
            this.grbAsignarFSD.Size = new System.Drawing.Size(366, 117);
            this.grbAsignarFSD.TabIndex = 3;
            this.grbAsignarFSD.TabStop = false;
            this.grbAsignarFSD.Text = "Asignar Limite de Cobertura FSD";
            // 
            // txtMontoMaxFSD
            // 
            this.txtMontoMaxFSD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMontoMaxFSD.FormatoDecimal = false;
            this.txtMontoMaxFSD.Location = new System.Drawing.Point(132, 81);
            this.txtMontoMaxFSD.Name = "txtMontoMaxFSD";
            this.txtMontoMaxFSD.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMontoMaxFSD.nNumDecimales = 4;
            this.txtMontoMaxFSD.nvalor = 0D;
            this.txtMontoMaxFSD.Size = new System.Drawing.Size(124, 20);
            this.txtMontoMaxFSD.TabIndex = 12;
            // 
            // chcVigencia
            // 
            this.chcVigencia.AutoSize = true;
            this.chcVigencia.Font = new System.Drawing.Font("Verdana", 8F);
            this.chcVigencia.ForeColor = System.Drawing.Color.Navy;
            this.chcVigencia.Location = new System.Drawing.Point(279, 57);
            this.chcVigencia.Name = "chcVigencia";
            this.chcVigencia.Size = new System.Drawing.Size(74, 17);
            this.chcVigencia.TabIndex = 11;
            this.chcVigencia.Text = "Vigencia";
            this.chcVigencia.UseVisualStyleBackColor = true;
            // 
            // dtFechaInicioFSD
            // 
            this.dtFechaInicioFSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaInicioFSD.Location = new System.Drawing.Point(131, 28);
            this.dtFechaInicioFSD.Name = "dtFechaInicioFSD";
            this.dtFechaInicioFSD.Size = new System.Drawing.Size(125, 20);
            this.dtFechaInicioFSD.TabIndex = 8;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(31, 81);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(94, 13);
            this.lblBase5.TabIndex = 7;
            this.lblBase5.Text = "Monto Maximo:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(30, 54);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(75, 13);
            this.lblBase3.TabIndex = 6;
            this.lblBase3.Text = "Fecha Final:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(30, 28);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(83, 13);
            this.lblBase4.TabIndex = 5;
            this.lblBase4.Text = "Fecha Inicial:";
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(184, 415);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 7;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(251, 415);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 8;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtgLimiteCoberFSD
            // 
            this.dtgLimiteCoberFSD.AllowUserToAddRows = false;
            this.dtgLimiteCoberFSD.AllowUserToDeleteRows = false;
            this.dtgLimiteCoberFSD.AllowUserToResizeColumns = false;
            this.dtgLimiteCoberFSD.AllowUserToResizeRows = false;
            this.dtgLimiteCoberFSD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLimiteCoberFSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLimiteCoberFSD.Location = new System.Drawing.Point(12, 260);
            this.dtgLimiteCoberFSD.MultiSelect = false;
            this.dtgLimiteCoberFSD.Name = "dtgLimiteCoberFSD";
            this.dtgLimiteCoberFSD.ReadOnly = true;
            this.dtgLimiteCoberFSD.RowHeadersVisible = false;
            this.dtgLimiteCoberFSD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLimiteCoberFSD.Size = new System.Drawing.Size(366, 149);
            this.dtgLimiteCoberFSD.TabIndex = 10;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(13, 416);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 5;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(118, 416);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 11;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(318, 416);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 12;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtFechaFinFSD
            // 
            this.dtFechaFinFSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFinFSD.Location = new System.Drawing.Point(131, 54);
            this.dtFechaFinFSD.Name = "dtFechaFinFSD";
            this.dtFechaFinFSD.Size = new System.Drawing.Size(125, 20);
            this.dtFechaFinFSD.TabIndex = 13;
            // 
            // frmMantenimientoLimiteCoberFSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 499);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.btnGrabar1);
            this.Controls.Add(this.dtgLimiteCoberFSD);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnEditar1);
            this.Controls.Add(this.btnNuevo1);
            this.Controls.Add(this.grbAsignarFSD);
            this.Controls.Add(this.grbBuscarFSD);
            this.Name = "frmMantenimientoLimiteCoberFSD";
            this.Text = "Mantenimiento Limite de Cobertura FSD";
            this.Load += new System.EventHandler(this.frmMantenimientoLimiteCoberFSD_Load);
            this.Controls.SetChildIndex(this.grbBuscarFSD, 0);
            this.Controls.SetChildIndex(this.grbAsignarFSD, 0);
            this.Controls.SetChildIndex(this.btnNuevo1, 0);
            this.Controls.SetChildIndex(this.btnEditar1, 0);
            this.Controls.SetChildIndex(this.btnCancelar1, 0);
            this.Controls.SetChildIndex(this.dtgLimiteCoberFSD, 0);
            this.Controls.SetChildIndex(this.btnGrabar1, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.grbBuscarFSD.ResumeLayout(false);
            this.grbBuscarFSD.PerformLayout();
            this.grbAsignarFSD.ResumeLayout(false);
            this.grbAsignarFSD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLimiteCoberFSD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBuscarFSD;
        private GEN.BotonesBase.btnBusqueda btnBusqueda1;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbAsignarFSD;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgLimiteCoberFSD;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.dtpCorto dtBuscarFechaInicioFSD;
        private GEN.ControlesBase.txtNumRea txtMontoMaxFSD;
        private GEN.ControlesBase.chcBase chcVigencia;
        private GEN.ControlesBase.dtpCorto dtFechaInicioFSD;
        private GEN.ControlesBase.dtpCorto dtBuscarFechaFinFSD;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.dtpCorto dtFechaFinFSD;
    }
}