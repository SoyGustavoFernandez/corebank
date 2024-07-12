namespace LOG.Presentacion
{
    partial class frmTransferenciaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferenciaAlmacen));
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgTransferencias = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgActivos = new GEN.ControlesBase.dtgBase(this.components);
            this.dtgDetalleTransferencia = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnAnular = new GEN.BotonesBase.btnAnular();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboAlmacen = new GEN.ControlesBase.cboAlmacen(this.components);
            this.cboAgencias = new GEN.ControlesBase.cboAgencias(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboMoneda1 = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransferencias)).BeginInit();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleTransferencia)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.dtgTransferencias);
            this.grbBase2.Location = new System.Drawing.Point(12, 87);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(766, 198);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Transferencias Registradas";
            // 
            // dtgTransferencias
            // 
            this.dtgTransferencias.AllowUserToAddRows = false;
            this.dtgTransferencias.AllowUserToDeleteRows = false;
            this.dtgTransferencias.AllowUserToResizeColumns = false;
            this.dtgTransferencias.AllowUserToResizeRows = false;
            this.dtgTransferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTransferencias.Location = new System.Drawing.Point(6, 16);
            this.dtgTransferencias.MultiSelect = false;
            this.dtgTransferencias.Name = "dtgTransferencias";
            this.dtgTransferencias.ReadOnly = true;
            this.dtgTransferencias.RowHeadersVisible = false;
            this.dtgTransferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTransferencias.Size = new System.Drawing.Size(754, 176);
            this.dtgTransferencias.TabIndex = 0;
            this.dtgTransferencias.SelectionChanged += new System.EventHandler(this.dtgTransferencias_SelectionChanged);
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgActivos);
            this.grbBase3.Controls.Add(this.dtgDetalleTransferencia);
            this.grbBase3.Location = new System.Drawing.Point(12, 316);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(766, 222);
            this.grbBase3.TabIndex = 4;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Detalle de Transferencias Registradas";
            // 
            // dtgActivos
            // 
            this.dtgActivos.AllowUserToAddRows = false;
            this.dtgActivos.AllowUserToDeleteRows = false;
            this.dtgActivos.AllowUserToResizeColumns = false;
            this.dtgActivos.AllowUserToResizeRows = false;
            this.dtgActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgActivos.Location = new System.Drawing.Point(437, 14);
            this.dtgActivos.MultiSelect = false;
            this.dtgActivos.Name = "dtgActivos";
            this.dtgActivos.ReadOnly = true;
            this.dtgActivos.RowHeadersVisible = false;
            this.dtgActivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgActivos.Size = new System.Drawing.Size(323, 202);
            this.dtgActivos.TabIndex = 20;
            // 
            // dtgDetalleTransferencia
            // 
            this.dtgDetalleTransferencia.AllowUserToAddRows = false;
            this.dtgDetalleTransferencia.AllowUserToDeleteRows = false;
            this.dtgDetalleTransferencia.AllowUserToResizeColumns = false;
            this.dtgDetalleTransferencia.AllowUserToResizeRows = false;
            this.dtgDetalleTransferencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetalleTransferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalleTransferencia.Location = new System.Drawing.Point(6, 14);
            this.dtgDetalleTransferencia.MultiSelect = false;
            this.dtgDetalleTransferencia.Name = "dtgDetalleTransferencia";
            this.dtgDetalleTransferencia.ReadOnly = true;
            this.dtgDetalleTransferencia.RowHeadersVisible = false;
            this.dtgDetalleTransferencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetalleTransferencia.Size = new System.Drawing.Size(417, 202);
            this.dtgDetalleTransferencia.TabIndex = 0;
            this.dtgDetalleTransferencia.SelectionChanged += new System.EventHandler(this.dtgDetalleTransferencia_SelectionChanged_1);
            this.dtgDetalleTransferencia.Enter += new System.EventHandler(this.dtgDetalleTransferencia_Enter);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(712, 539);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(640, 539);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnular.BackgroundImage")));
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Location = new System.Drawing.Point(579, 539);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(60, 50);
            this.btnAnular.TabIndex = 9;
            this.btnAnular.Text = "Anu&lar";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboAlmacen);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(766, 69);
            this.grbBase1.TabIndex = 10;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacen.FormattingEnabled = true;
            this.cboAlmacen.Location = new System.Drawing.Point(395, 40);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Size = new System.Drawing.Size(252, 21);
            this.cboAlmacen.TabIndex = 16;
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(395, 13);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(252, 21);
            this.cboAgencias.TabIndex = 15;
            this.cboAgencias.SelectedIndexChanged += new System.EventHandler(this.cboAgencias_SelectedIndexChanged);
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(330, 43);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(61, 13);
            this.lblBase4.TabIndex = 14;
            this.lblBase4.Text = "Almacen:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(334, 16);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 13;
            this.lblBase1.Text = "Agencia:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(150, 36);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(44, 13);
            this.lblBase3.TabIndex = 12;
            this.lblBase3.Text = "Hasta:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(6, 36);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(28, 13);
            this.lblBase2.TabIndex = 11;
            this.lblBase2.Text = "De:";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(679, 13);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 10;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(200, 30);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFecFin.TabIndex = 9;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(40, 30);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(104, 20);
            this.dtpFecIni.TabIndex = 8;
            // 
            // cboMoneda1
            // 
            this.cboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda1.Enabled = false;
            this.cboMoneda1.FormattingEnabled = true;
            this.cboMoneda1.Location = new System.Drawing.Point(165, 289);
            this.cboMoneda1.Name = "cboMoneda1";
            this.cboMoneda1.Size = new System.Drawing.Size(138, 21);
            this.cboMoneda1.TabIndex = 21;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(18, 292);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(148, 13);
            this.lblBase6.TabIndex = 20;
            this.lblBase6.Text = "Moneda de transferencia";
            // 
            // frmTransferenciaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 614);
            this.Controls.Add(this.cboMoneda1);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmTransferenciaAlmacen";
            this.Text = "Transferencia a Almacén";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.cboMoneda1, 0);
            this.grbBase2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransferencias)).EndInit();
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgActivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalleTransferencia)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnAnular btnAnular;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboAlmacen cboAlmacen;
        private GEN.ControlesBase.cboAgencias cboAgencias;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtgBase dtgTransferencias;
        private GEN.ControlesBase.dtgBase dtgDetalleTransferencia;
        private GEN.ControlesBase.dtgBase dtgActivos;
        private GEN.ControlesBase.cboMoneda cboMoneda1;
        private GEN.ControlesBase.lblBase lblBase6;
    }
}

