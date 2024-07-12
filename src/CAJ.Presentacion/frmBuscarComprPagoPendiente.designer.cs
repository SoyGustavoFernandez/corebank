namespace CAJ.Presentacion
{
    partial class frmBuscarComprPagoPendiente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarComprPagoPendiente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTipoComprPago = new GEN.ControlesBase.lblBase();
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.grbDatosBusqueda = new GEN.ControlesBase.grbBase(this.components);
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.lblNumero = new GEN.ControlesBase.lblBase();
            this.txtNumero = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.txtSerie = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblSerie = new GEN.ControlesBase.lblBase();
            this.grbResultados = new GEN.ControlesBase.grbBase(this.components);
            this.dtgComprobantes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcCajChic = new GEN.ControlesBase.chcBase(this.components);
            this.chcTieneComprobante = new GEN.ControlesBase.chcBase(this.components);
            this.grbDatosBusqueda.SuspendLayout();
            this.grbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComprobantes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTipoComprPago
            // 
            this.lblTipoComprPago.AutoSize = true;
            this.lblTipoComprPago.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoComprPago.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoComprPago.Location = new System.Drawing.Point(12, 22);
            this.lblTipoComprPago.Name = "lblTipoComprPago";
            this.lblTipoComprPago.Size = new System.Drawing.Size(118, 13);
            this.lblTipoComprPago.TabIndex = 3;
            this.lblTipoComprPago.Text = "Tipo Comprobante:";
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
            // grbDatosBusqueda
            // 
            this.grbDatosBusqueda.Controls.Add(this.btnBusqueda);
            this.grbDatosBusqueda.Controls.Add(this.lblNumero);
            this.grbDatosBusqueda.Controls.Add(this.txtNumero);
            this.grbDatosBusqueda.Controls.Add(this.txtSerie);
            this.grbDatosBusqueda.Controls.Add(this.lblSerie);
            this.grbDatosBusqueda.Controls.Add(this.cboTipoComprobantePago);
            this.grbDatosBusqueda.Controls.Add(this.lblTipoComprPago);
            this.grbDatosBusqueda.Location = new System.Drawing.Point(14, 43);
            this.grbDatosBusqueda.Name = "grbDatosBusqueda";
            this.grbDatosBusqueda.Size = new System.Drawing.Size(584, 99);
            this.grbDatosBusqueda.TabIndex = 5;
            this.grbDatosBusqueda.TabStop = false;
            this.grbDatosBusqueda.Text = "Datos Búsqueda";
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.BackgroundImage")));
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusqueda.Location = new System.Drawing.Point(488, 18);
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
            this.lblNumero.Location = new System.Drawing.Point(12, 71);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(57, 13);
            this.lblNumero.TabIndex = 8;
            this.lblNumero.Text = "Número:";
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
            this.lblSerie.Location = new System.Drawing.Point(12, 47);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(42, 13);
            this.lblSerie.TabIndex = 5;
            this.lblSerie.Text = "Serie:";
            // 
            // grbResultados
            // 
            this.grbResultados.Controls.Add(this.dtgComprobantes);
            this.grbResultados.Location = new System.Drawing.Point(14, 148);
            this.grbResultados.Name = "grbResultados";
            this.grbResultados.Size = new System.Drawing.Size(584, 145);
            this.grbResultados.TabIndex = 6;
            this.grbResultados.TabStop = false;
            this.grbResultados.Text = "Resultados";
            // 
            // dtgComprobantes
            // 
            this.dtgComprobantes.AllowUserToAddRows = false;
            this.dtgComprobantes.AllowUserToDeleteRows = false;
            this.dtgComprobantes.AllowUserToResizeColumns = false;
            this.dtgComprobantes.AllowUserToResizeRows = false;
            this.dtgComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgComprobantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComprobantes.Location = new System.Drawing.Point(6, 19);
            this.dtgComprobantes.MultiSelect = false;
            this.dtgComprobantes.Name = "dtgComprobantes";
            this.dtgComprobantes.ReadOnly = true;
            this.dtgComprobantes.RowHeadersVisible = false;
            this.dtgComprobantes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgComprobantes.RowTemplate.Height = 18;
            this.dtgComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComprobantes.Size = new System.Drawing.Size(572, 119);
            this.dtgComprobantes.TabIndex = 0;
            this.dtgComprobantes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgComprobantes_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(472, 299);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 50);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(538, 299);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcCajChic);
            this.grbBase1.Controls.Add(this.chcTieneComprobante);
            this.grbBase1.Location = new System.Drawing.Point(14, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(584, 40);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            // 
            // chcCajChic
            // 
            this.chcCajChic.AutoSize = true;
            this.chcCajChic.Enabled = false;
            this.chcCajChic.Location = new System.Drawing.Point(345, 14);
            this.chcCajChic.Name = "chcCajChic";
            this.chcCajChic.Size = new System.Drawing.Size(83, 17);
            this.chcCajChic.TabIndex = 13;
            this.chcCajChic.Text = "Caja Chica?";
            this.chcCajChic.UseVisualStyleBackColor = true;
            // 
            // chcTieneComprobante
            // 
            this.chcTieneComprobante.AutoSize = true;
            this.chcTieneComprobante.Enabled = false;
            this.chcTieneComprobante.Location = new System.Drawing.Point(141, 14);
            this.chcTieneComprobante.Name = "chcTieneComprobante";
            this.chcTieneComprobante.Size = new System.Drawing.Size(125, 17);
            this.chcTieneComprobante.TabIndex = 12;
            this.chcTieneComprobante.Text = "Tiene Comprobante?";
            this.chcTieneComprobante.UseVisualStyleBackColor = true;
            // 
            // frmBuscarComprPagoPendiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 377);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbDatosBusqueda);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbResultados);
            this.Name = "frmBuscarComprPagoPendiente";
            this.Text = "Buscar Comprobante";
            this.Load += new System.EventHandler(this.frmBuscarComprPagoPendiente_Load);
            this.Controls.SetChildIndex(this.grbResultados, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbDatosBusqueda, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.grbDatosBusqueda.ResumeLayout(false);
            this.grbDatosBusqueda.PerformLayout();
            this.grbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgComprobantes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblTipoComprPago;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.grbBase grbDatosBusqueda;
        private GEN.ControlesBase.txtCBNumerosEnteros txtSerie;
        private GEN.ControlesBase.lblBase lblSerie;
        private GEN.BotonesBase.btnBusqueda btnBusqueda;
        private GEN.ControlesBase.lblBase lblNumero;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNumero;
        private GEN.ControlesBase.grbBase grbResultados;
        private GEN.ControlesBase.dtgBase dtgComprobantes;
        private GEN.BotonesBase.BtnAceptar btnAceptar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        public GEN.ControlesBase.chcBase chcTieneComprobante;
        public GEN.ControlesBase.chcBase chcCajChic;

    }
}