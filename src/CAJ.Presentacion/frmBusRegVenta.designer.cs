namespace CAJ.Presentacion
{
    partial class frmBusRegVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusRegVenta));
            this.grbDatosBusqueda = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblNumero = new GEN.ControlesBase.lblBase();
            this.txtNumero = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblSerie = new GEN.ControlesBase.lblBase();
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.lblTipoComprPago = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.grbResultados = new GEN.ControlesBase.grbBase(this.components);
            this.dtgRegVentas = new GEN.ControlesBase.dtgBase(this.components);
            this.grbDatosBusqueda.SuspendLayout();
            this.grbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDatosBusqueda
            // 
            this.grbDatosBusqueda.Controls.Add(this.btnBusqueda);
            this.grbDatosBusqueda.Controls.Add(this.lblNumero);
            this.grbDatosBusqueda.Controls.Add(this.txtNumero);
            this.grbDatosBusqueda.Controls.Add(this.txtSerie);
            this.grbDatosBusqueda.Controls.Add(this.lblSerie);
            this.grbDatosBusqueda.Controls.Add(this.cboTipoComprobantePago);
            this.grbDatosBusqueda.Controls.Add(this.lblTipoComprPago);
            this.grbDatosBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grbDatosBusqueda.Name = "grbDatosBusqueda";
            this.grbDatosBusqueda.Size = new System.Drawing.Size(555, 99);
            this.grbDatosBusqueda.TabIndex = 10;
            this.grbDatosBusqueda.TabStop = false;
            this.grbDatosBusqueda.Text = "Datos Busqueda";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(489, 24);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(60, 50);
            this.btnBusqueda.TabIndex = 9;
            this.btnBusqueda.Text = "&Buscar";
            this.btnBusqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumero.ForeColor = System.Drawing.Color.Navy;
            this.lblNumero.Location = new System.Drawing.Point(80, 71);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(57, 13);
            this.lblNumero.TabIndex = 8;
            this.lblNumero.Text = "Numero:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(141, 67);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(103, 20);
            this.txtNumero.TabIndex = 7;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero.Leave += new System.EventHandler(this.txtNumero_Leave);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(141, 43);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(103, 20);
            this.txtSerie.TabIndex = 6;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            this.txtSerie.Leave += new System.EventHandler(this.txtSerie_Leave);
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSerie.ForeColor = System.Drawing.Color.Navy;
            this.lblSerie.Location = new System.Drawing.Point(95, 47);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(42, 13);
            this.lblSerie.TabIndex = 5;
            this.lblSerie.Text = "Serie:";
            // 
            // cboTipoComprobantePago
            // 
            this.cboTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobantePago.FormattingEnabled = true;
            this.cboTipoComprobantePago.Location = new System.Drawing.Point(141, 18);
            this.cboTipoComprobantePago.Name = "cboTipoComprobantePago";
            this.cboTipoComprobantePago.Size = new System.Drawing.Size(341, 21);
            this.cboTipoComprobantePago.TabIndex = 4;
            this.cboTipoComprobantePago.SelectedIndexChanged += new System.EventHandler(this.cboTipoComprobantePago_SelectedIndexChanged);
            // 
            // lblTipoComprPago
            // 
            this.lblTipoComprPago.AutoSize = true;
            this.lblTipoComprPago.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoComprPago.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoComprPago.Location = new System.Drawing.Point(19, 22);
            this.lblTipoComprPago.Name = "lblTipoComprPago";
            this.lblTipoComprPago.Size = new System.Drawing.Size(118, 13);
            this.lblTipoComprPago.TabIndex = 3;
            this.lblTipoComprPago.Text = "Tipo Comprobante:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(507, 268);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(441, 268);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grbResultados
            // 
            this.grbResultados.Controls.Add(this.dtgRegVentas);
            this.grbResultados.Location = new System.Drawing.Point(12, 117);
            this.grbResultados.Name = "grbResultados";
            this.grbResultados.Size = new System.Drawing.Size(555, 145);
            this.grbResultados.TabIndex = 11;
            this.grbResultados.TabStop = false;
            this.grbResultados.Text = "Resultados";
            // 
            // dtgRegVentas
            // 
            this.dtgRegVentas.AllowUserToAddRows = false;
            this.dtgRegVentas.AllowUserToDeleteRows = false;
            this.dtgRegVentas.AllowUserToResizeColumns = false;
            this.dtgRegVentas.AllowUserToResizeRows = false;
            this.dtgRegVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgRegVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRegVentas.Location = new System.Drawing.Point(6, 19);
            this.dtgRegVentas.MultiSelect = false;
            this.dtgRegVentas.Name = "dtgRegVentas";
            this.dtgRegVentas.ReadOnly = true;
            this.dtgRegVentas.RowHeadersVisible = false;
            this.dtgRegVentas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgRegVentas.RowTemplate.Height = 18;
            this.dtgRegVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegVentas.Size = new System.Drawing.Size(543, 119);
            this.dtgRegVentas.TabIndex = 0;
            this.dtgRegVentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgRegVentas_KeyDown);
            // 
            // frmBusRegVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 351);
            this.Controls.Add(this.grbDatosBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbResultados);
            this.Name = "frmBusRegVenta";
            this.Text = "Buscar Registro de Venta";
            this.Load += new System.EventHandler(this.frmBusRegVenta_Load);
            this.Controls.SetChildIndex(this.grbResultados, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbDatosBusqueda, 0);
            this.grbDatosBusqueda.ResumeLayout(false);
            this.grbDatosBusqueda.PerformLayout();
            this.grbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbDatosBusqueda;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.lblBase lblNumero;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumero;
        private GEN.ControlesBase.txtCBNumerosEnteros txtSerie;
        private GEN.ControlesBase.lblBase lblSerie;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.lblBase lblTipoComprPago;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.ControlesBase.grbBase grbResultados;
        private GEN.ControlesBase.dtgBase dtgRegVentas;
    }
}