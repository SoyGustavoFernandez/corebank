namespace LOG.Presentacion
{
    partial class frmIngresosAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresosAlmacen));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtgNotaEntrada = new GEN.ControlesBase.dtgBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtUsuario = new GEN.ControlesBase.txtBase(this.components);
            this.cboAlmacenes = new GEN.ControlesBase.cboAlmacenes(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.dtgDetNotaEntrada = new GEN.ControlesBase.dtgBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnNuevo = new GEN.BotonesBase.btnNuevo();
            this.btnActa = new GEN.BotonesBase.btnDetalle();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtProveedor = new GEN.ControlesBase.txtBase(this.components);
            this.txtTotalNotaEntrada = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotaEntrada)).BeginInit();
            this.grbBase2.SuspendLayout();
            this.grbBase3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetNotaEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.dtgNotaEntrada);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.btnBusqueda);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Location = new System.Drawing.Point(3, 3);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(292, 419);
            this.grbBase1.TabIndex = 2;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Búsqueda";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(113, 12);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(44, 13);
            this.lblBase3.TabIndex = 7;
            this.lblBase3.Text = "Hasta:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(7, 12);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(28, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "De:";
            // 
            // dtgNotaEntrada
            // 
            this.dtgNotaEntrada.AllowUserToAddRows = false;
            this.dtgNotaEntrada.AllowUserToDeleteRows = false;
            this.dtgNotaEntrada.AllowUserToResizeColumns = false;
            this.dtgNotaEntrada.AllowUserToResizeRows = false;
            this.dtgNotaEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgNotaEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotaEntrada.Location = new System.Drawing.Point(6, 100);
            this.dtgNotaEntrada.MultiSelect = false;
            this.dtgNotaEntrada.Name = "dtgNotaEntrada";
            this.dtgNotaEntrada.ReadOnly = true;
            this.dtgNotaEntrada.RowHeadersVisible = false;
            this.dtgNotaEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotaEntrada.Size = new System.Drawing.Size(280, 313);
            this.dtgNotaEntrada.TabIndex = 5;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(7, 76);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(57, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Agencia:";
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(65, 73);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(155, 21);
            this.cboAgencia.TabIndex = 3;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(226, 19);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 2;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(116, 28);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(104, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(6, 28);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(104, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtUsuario);
            this.grbBase2.Controls.Add(this.cboAlmacenes);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Location = new System.Drawing.Point(301, 3);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(576, 69);
            this.grbBase2.TabIndex = 3;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(74, 45);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(388, 20);
            this.txtUsuario.TabIndex = 11;
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlmacenes.Enabled = false;
            this.cboAlmacenes.FormattingEnabled = true;
            this.cboAlmacenes.Location = new System.Drawing.Point(73, 18);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(389, 21);
            this.cboAlmacenes.TabIndex = 16;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 48);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(55, 13);
            this.lblBase5.TabIndex = 9;
            this.lblBase5.Text = "Usuario:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(6, 22);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(61, 13);
            this.lblBase4.TabIndex = 8;
            this.lblBase4.Text = "Almacén:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtgDetNotaEntrada);
            this.grbBase3.Location = new System.Drawing.Point(301, 79);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(576, 343);
            this.grbBase3.TabIndex = 4;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Detalle de Nota de Entrada";
            // 
            // dtgDetNotaEntrada
            // 
            this.dtgDetNotaEntrada.AllowUserToAddRows = false;
            this.dtgDetNotaEntrada.AllowUserToDeleteRows = false;
            this.dtgDetNotaEntrada.AllowUserToResizeColumns = false;
            this.dtgDetNotaEntrada.AllowUserToResizeRows = false;
            this.dtgDetNotaEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgDetNotaEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetNotaEntrada.Location = new System.Drawing.Point(9, 24);
            this.dtgDetNotaEntrada.MultiSelect = false;
            this.dtgDetNotaEntrada.Name = "dtgDetNotaEntrada";
            this.dtgDetNotaEntrada.ReadOnly = true;
            this.dtgDetNotaEntrada.RowHeadersVisible = false;
            this.dtgDetNotaEntrada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDetNotaEntrada.Size = new System.Drawing.Size(561, 313);
            this.dtgDetNotaEntrada.TabIndex = 0;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(817, 462);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuevo.Location = new System.Drawing.Point(726, 462);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 50);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnActa
            // 
            this.btnActa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActa.BackgroundImage")));
            this.btnActa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActa.Location = new System.Drawing.Point(665, 462);
            this.btnActa.Name = "btnActa";
            this.btnActa.Size = new System.Drawing.Size(60, 50);
            this.btnActa.TabIndex = 7;
            this.btnActa.Text = "&Detallar";
            this.btnActa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActa.texto = "&Detallar";
            this.btnActa.UseVisualStyleBackColor = true;
            this.btnActa.Click += new System.EventHandler(this.btnActa_Click);
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(6, 435);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(71, 13);
            this.lblBase6.TabIndex = 12;
            this.lblBase6.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Location = new System.Drawing.Point(83, 432);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(276, 20);
            this.txtProveedor.TabIndex = 12;
            // 
            // txtTotalNotaEntrada
            // 
            this.txtTotalNotaEntrada.Location = new System.Drawing.Point(780, 432);
            this.txtTotalNotaEntrada.Name = "txtTotalNotaEntrada";
            this.txtTotalNotaEntrada.ReadOnly = true;
            this.txtTotalNotaEntrada.Size = new System.Drawing.Size(91, 20);
            this.txtTotalNotaEntrada.TabIndex = 15;
            // 
            // frmIngresosAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 537);
            this.Controls.Add(this.txtTotalNotaEntrada);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.btnActa);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmIngresosAlmacen";
            this.Text = "Ingresos a Almacén";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnActa, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtProveedor, 0);
            this.Controls.SetChildIndex(this.txtTotalNotaEntrada, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotaEntrada)).EndInit();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetNotaEntrada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtgBase dtgNotaEntrada;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtBase txtUsuario;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.dtgBase dtgDetNotaEntrada;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnNuevo btnNuevo;
        private GEN.BotonesBase.btnDetalle btnActa;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtBase txtProveedor;
        private GEN.ControlesBase.txtBase txtTotalNotaEntrada;
        private GEN.ControlesBase.cboAlmacenes cboAlmacenes;
    }
}

