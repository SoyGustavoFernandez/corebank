namespace SPL.Presentacion
{
    partial class frmMantenimientoUmbralSplaf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoUmbralSplaf));
            this.grbBase5 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnEditar1 = new GEN.BotonesBase.btnEditar();
            this.btnCancelar1 = new GEN.BotonesBase.btnCancelar();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnGrabar1 = new GEN.BotonesBase.btnGrabar();
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.dtpFechaInicio = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnNuevo1 = new GEN.BotonesBase.btnNuevo();
            this.txtUmbralUSD = new GEN.ControlesBase.txtNumRea(this.components);
            this.cboTipoUmbral = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.dtgUmbrales = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgTipoOperacion = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase5.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUmbrales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoOperacion)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase5
            // 
            this.grbBase5.Controls.Add(this.cboAgencias);
            this.grbBase5.Controls.Add(this.lblBase1);
            this.grbBase5.Location = new System.Drawing.Point(12, 12);
            this.grbBase5.Name = "grbBase5";
            this.grbBase5.Size = new System.Drawing.Size(773, 51);
            this.grbBase5.TabIndex = 3;
            this.grbBase5.TabStop = false;
            this.grbBase5.Text = "Seleccione Agencia";
            // 
            // cboAgencias
            // 
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(74, 19);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(319, 21);
            this.cboAgencias.TabIndex = 5;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(11, 22);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 3;
            this.lblBase1.Text = "Agencia:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.dtgTipoOperacion);
            this.grbBase1.Controls.Add(this.btnEditar1);
            this.grbBase1.Controls.Add(this.btnCancelar1);
            this.grbBase1.Controls.Add(this.dtpFechaFin);
            this.grbBase1.Controls.Add(this.btnGrabar1);
            this.grbBase1.Controls.Add(this.lblBase7);
            this.grbBase1.Controls.Add(this.btnSalir1);
            this.grbBase1.Controls.Add(this.dtpFechaInicio);
            this.grbBase1.Controls.Add(this.btnNuevo1);
            this.grbBase1.Controls.Add(this.txtUmbralUSD);
            this.grbBase1.Controls.Add(this.cboTipoUmbral);
            this.grbBase1.Controls.Add(this.lblBase6);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Location = new System.Drawing.Point(428, 67);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(475, 523);
            this.grbBase1.TabIndex = 3;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Detalle Umbral";
            // 
            // btnEditar1
            // 
            this.btnEditar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar1.BackgroundImage")));
            this.btnEditar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar1.Location = new System.Drawing.Point(152, 467);
            this.btnEditar1.Name = "btnEditar1";
            this.btnEditar1.Size = new System.Drawing.Size(60, 50);
            this.btnEditar1.TabIndex = 8;
            this.btnEditar1.Text = "&Editar";
            this.btnEditar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar1.UseVisualStyleBackColor = true;
            this.btnEditar1.Click += new System.EventHandler(this.btnEditar1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.BackgroundImage")));
            this.btnCancelar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar1.Location = new System.Drawing.Point(348, 467);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar1.TabIndex = 7;
            this.btnCancelar1.Text = "&Cancelar";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(125, 103);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // btnGrabar1
            // 
            this.btnGrabar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar1.BackgroundImage")));
            this.btnGrabar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar1.Location = new System.Drawing.Point(284, 467);
            this.btnGrabar1.Name = "btnGrabar1";
            this.btnGrabar1.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar1.TabIndex = 6;
            this.btnGrabar1.Text = "&Grabar";
            this.btnGrabar1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar1.UseVisualStyleBackColor = true;
            this.btnGrabar1.Click += new System.EventHandler(this.btnGrabar1_Click);
            // 
            // lblBase7
            // 
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(3, 97);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(115, 30);
            this.lblBase7.TabIndex = 5;
            this.lblBase7.Text = "Fecha de vigencia fin:";
            this.lblBase7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(410, 467);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(125, 73);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // btnNuevo1
            // 
            this.btnNuevo1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo1.BackgroundImage")));
            this.btnNuevo1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo1.Location = new System.Drawing.Point(218, 467);
            this.btnNuevo1.Name = "btnNuevo1";
            this.btnNuevo1.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo1.TabIndex = 4;
            this.btnNuevo1.Text = "&Nuevo";
            this.btnNuevo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo1.UseVisualStyleBackColor = true;
            this.btnNuevo1.Click += new System.EventHandler(this.btnNuevo1_Click);
            // 
            // txtUmbralUSD
            // 
            this.txtUmbralUSD.FormatoDecimal = false;
            this.txtUmbralUSD.Location = new System.Drawing.Point(125, 45);
            this.txtUmbralUSD.Name = "txtUmbralUSD";
            this.txtUmbralUSD.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUmbralUSD.nNumDecimales = 4;
            this.txtUmbralUSD.nvalor = 0D;
            this.txtUmbralUSD.Size = new System.Drawing.Size(170, 20);
            this.txtUmbralUSD.TabIndex = 2;
            // 
            // cboTipoUmbral
            // 
            this.cboTipoUmbral.FormattingEnabled = true;
            this.cboTipoUmbral.Location = new System.Drawing.Point(125, 17);
            this.cboTipoUmbral.Name = "cboTipoUmbral";
            this.cboTipoUmbral.Size = new System.Drawing.Size(221, 21);
            this.cboTipoUmbral.TabIndex = 1;
            // 
            // lblBase6
            // 
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 70);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(112, 26);
            this.lblBase6.TabIndex = 0;
            this.lblBase6.Text = "Fecha de vigencia inicio:";
            this.lblBase6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(7, 48);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(117, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Umbral en dólares:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 20);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(80, 13);
            this.lblBase2.TabIndex = 0;
            this.lblBase2.Text = "Tipo umbral:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.dtgUmbrales);
            this.grbBase2.Location = new System.Drawing.Point(12, 67);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(410, 358);
            this.grbBase2.TabIndex = 4;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Historial Umbral";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(11, 18);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(61, 13);
            this.lblBase5.TabIndex = 1;
            this.lblBase5.Text = "Umbrales";
            // 
            // dtgUmbrales
            // 
            this.dtgUmbrales.AllowUserToAddRows = false;
            this.dtgUmbrales.AllowUserToDeleteRows = false;
            this.dtgUmbrales.AllowUserToResizeColumns = false;
            this.dtgUmbrales.AllowUserToResizeRows = false;
            this.dtgUmbrales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgUmbrales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUmbrales.Location = new System.Drawing.Point(14, 36);
            this.dtgUmbrales.MultiSelect = false;
            this.dtgUmbrales.Name = "dtgUmbrales";
            this.dtgUmbrales.ReadOnly = true;
            this.dtgUmbrales.RowHeadersVisible = false;
            this.dtgUmbrales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUmbrales.Size = new System.Drawing.Size(379, 311);
            this.dtgUmbrales.TabIndex = 0;
            this.dtgUmbrales.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgUmbrales_CellEnter);
            // 
            // dtgTipoOperacion
            // 
            this.dtgTipoOperacion.AllowUserToAddRows = false;
            this.dtgTipoOperacion.AllowUserToDeleteRows = false;
            this.dtgTipoOperacion.AllowUserToResizeColumns = false;
            this.dtgTipoOperacion.AllowUserToResizeRows = false;
            this.dtgTipoOperacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgTipoOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTipoOperacion.Location = new System.Drawing.Point(0, 129);
            this.dtgTipoOperacion.MultiSelect = false;
            this.dtgTipoOperacion.Name = "dtgTipoOperacion";
            this.dtgTipoOperacion.ReadOnly = true;
            this.dtgTipoOperacion.RowHeadersVisible = false;
            this.dtgTipoOperacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTipoOperacion.Size = new System.Drawing.Size(469, 332);
            this.dtgTipoOperacion.TabIndex = 2;
            // 
            // frmMantenimientoUmbralSplaf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 615);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase5);
            this.Name = "frmMantenimientoUmbralSplaf";
            this.Text = "Mantenimiento Umbral SPLAF";
            this.Controls.SetChildIndex(this.grbBase5, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbBase5.ResumeLayout(false);
            this.grbBase5.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUmbrales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTipoOperacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase5;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtNumRea txtUmbralUSD;
        private GEN.ControlesBase.cboBase cboTipoUmbral;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.dtgBase dtgUmbrales;
        private GEN.BotonesBase.btnNuevo btnNuevo1;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnGrabar btnGrabar1;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.dtpCorto dtpFechaInicio;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.BotonesBase.btnCancelar btnCancelar1;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnEditar btnEditar1;
        private GEN.ControlesBase.dtgBase dtgTipoOperacion;
    }
}