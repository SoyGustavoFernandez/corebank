namespace CAJ.Presentacion
{
    partial class frmBuscarComprPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarComprPago));
            this.lblTipoComprPago = new GEN.ControlesBase.lblBase();
            this.cboTipoComprobantePago = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.grbBusqGeneral = new GEN.ControlesBase.grbBase(this.components);
            this.txtSerie = new GEN.ControlesBase.txtBase(this.components);
            this.dtpFecInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.btnBusqueda = new GEN.BotonesBase.btnBusqueda();
            this.cboEstadoComprobante = new GEN.ControlesBase.cboEstadoComprobante(this.components);
            this.lblNumero = new GEN.ControlesBase.lblBase();
            this.txtNumero = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblSerie = new GEN.ControlesBase.lblBase();
            this.grbResultados = new GEN.ControlesBase.grbBase(this.components);
            this.dtgComprobantes = new GEN.ControlesBase.dtgBase(this.components);
            this.btnAceptar = new GEN.BotonesBase.BtnAceptar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcCajChic = new GEN.ControlesBase.chcBase(this.components);
            this.chcTieneComprobante = new GEN.ControlesBase.chcBase(this.components);
            this.grbBusqEspecifica = new GEN.ControlesBase.grbBase(this.components);
            this.txtCodigoComprobante = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.btnMiniBusq1 = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtBusqGeneral = new GEN.ControlesBase.rbtBase(this.components);
            this.rbtBusqEspecifica = new GEN.ControlesBase.rbtBase(this.components);
            this.grbBusqGeneral.SuspendLayout();
            this.grbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgComprobantes)).BeginInit();
            this.grbBase1.SuspendLayout();
            this.grbBusqEspecifica.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTipoComprPago
            // 
            this.lblTipoComprPago.AutoSize = true;
            this.lblTipoComprPago.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblTipoComprPago.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoComprPago.Location = new System.Drawing.Point(20, 21);
            this.lblTipoComprPago.Name = "lblTipoComprPago";
            this.lblTipoComprPago.Size = new System.Drawing.Size(118, 13);
            this.lblTipoComprPago.TabIndex = 3;
            this.lblTipoComprPago.Text = "Tipo Comprobante:";
            // 
            // cboTipoComprobantePago
            // 
            this.cboTipoComprobantePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobantePago.FormattingEnabled = true;
            this.cboTipoComprobantePago.Location = new System.Drawing.Point(144, 18);
            this.cboTipoComprobantePago.Name = "cboTipoComprobantePago";
            this.cboTipoComprobantePago.Size = new System.Drawing.Size(341, 21);
            this.cboTipoComprobantePago.TabIndex = 4;
            // 
            // grbBusqGeneral
            // 
            this.grbBusqGeneral.Controls.Add(this.txtSerie);
            this.grbBusqGeneral.Controls.Add(this.dtpFecInicial);
            this.grbBusqGeneral.Controls.Add(this.dtpFecFinal);
            this.grbBusqGeneral.Controls.Add(this.lblBase2);
            this.grbBusqGeneral.Controls.Add(this.lblBase3);
            this.grbBusqGeneral.Controls.Add(this.lblBase5);
            this.grbBusqGeneral.Controls.Add(this.btnBusqueda);
            this.grbBusqGeneral.Controls.Add(this.cboEstadoComprobante);
            this.grbBusqGeneral.Controls.Add(this.lblNumero);
            this.grbBusqGeneral.Controls.Add(this.cboTipoComprobantePago);
            this.grbBusqGeneral.Controls.Add(this.lblTipoComprPago);
            this.grbBusqGeneral.Controls.Add(this.txtNumero);
            this.grbBusqGeneral.Controls.Add(this.lblSerie);
            this.grbBusqGeneral.Enabled = false;
            this.grbBusqGeneral.Location = new System.Drawing.Point(14, 151);
            this.grbBusqGeneral.Name = "grbBusqGeneral";
            this.grbBusqGeneral.Size = new System.Drawing.Size(555, 122);
            this.grbBusqGeneral.TabIndex = 5;
            this.grbBusqGeneral.TabStop = false;
            this.grbBusqGeneral.Text = "Búsqueda genérica de comprbantes";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(144, 96);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(103, 20);
            this.txtSerie.TabIndex = 88;
            // 
            // dtpFecInicial
            // 
            this.dtpFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicial.Location = new System.Drawing.Point(144, 71);
            this.dtpFecInicial.Name = "dtpFecInicial";
            this.dtpFecInicial.Size = new System.Drawing.Size(103, 20);
            this.dtpFecInicial.TabIndex = 86;
            // 
            // dtpFecFinal
            // 
            this.dtpFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinal.Location = new System.Drawing.Point(329, 70);
            this.dtpFecFinal.Name = "dtpFecFinal";
            this.dtpFecFinal.Size = new System.Drawing.Size(103, 20);
            this.dtpFecFinal.TabIndex = 87;
            this.dtpFecFinal.ValueChanged += new System.EventHandler(this.dtpFecFinal_ValueChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(258, 77);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(65, 13);
            this.lblBase2.TabIndex = 85;
            this.lblBase2.Text = "Fecha Fin:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(55, 77);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 84;
            this.lblBase3.Text = "Fecha Inicial:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(6, 51);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(132, 13);
            this.lblBase5.TabIndex = 83;
            this.lblBase5.Text = "Estado Comprobante:";
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
            // cboEstadoComprobante
            // 
            this.cboEstadoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoComprobante.FormattingEnabled = true;
            this.cboEstadoComprobante.Location = new System.Drawing.Point(144, 44);
            this.cboEstadoComprobante.Name = "cboEstadoComprobante";
            this.cboEstadoComprobante.Size = new System.Drawing.Size(288, 21);
            this.cboEstadoComprobante.TabIndex = 82;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNumero.ForeColor = System.Drawing.Color.Navy;
            this.lblNumero.Location = new System.Drawing.Point(266, 99);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(57, 13);
            this.lblNumero.TabIndex = 8;
            this.lblNumero.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(329, 96);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(103, 20);
            this.txtNumero.TabIndex = 7;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblSerie.ForeColor = System.Drawing.Color.Navy;
            this.lblSerie.Location = new System.Drawing.Point(96, 99);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(42, 13);
            this.lblSerie.TabIndex = 5;
            this.lblSerie.Text = "Serie:";
            // 
            // grbResultados
            // 
            this.grbResultados.Controls.Add(this.dtgComprobantes);
            this.grbResultados.Location = new System.Drawing.Point(14, 292);
            this.grbResultados.Name = "grbResultados";
            this.grbResultados.Size = new System.Drawing.Size(555, 145);
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
            this.dtgComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComprobantes.Location = new System.Drawing.Point(6, 19);
            this.dtgComprobantes.MultiSelect = false;
            this.dtgComprobantes.Name = "dtgComprobantes";
            this.dtgComprobantes.ReadOnly = true;
            this.dtgComprobantes.RowHeadersVisible = false;
            this.dtgComprobantes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgComprobantes.RowTemplate.Height = 18;
            this.dtgComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgComprobantes.Size = new System.Drawing.Size(543, 119);
            this.dtgComprobantes.TabIndex = 0;
            this.dtgComprobantes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgComprobantes_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.Location = new System.Drawing.Point(443, 443);
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
            this.btnSalir.Location = new System.Drawing.Point(509, 443);
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
            this.grbBase1.Size = new System.Drawing.Size(555, 40);
            this.grbBase1.TabIndex = 9;
            this.grbBase1.TabStop = false;
            // 
            // chcCajChic
            // 
            this.chcCajChic.AutoSize = true;
            this.chcCajChic.Enabled = false;
            this.chcCajChic.Location = new System.Drawing.Point(310, 14);
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
            this.chcTieneComprobante.Location = new System.Drawing.Point(162, 14);
            this.chcTieneComprobante.Name = "chcTieneComprobante";
            this.chcTieneComprobante.Size = new System.Drawing.Size(125, 17);
            this.chcTieneComprobante.TabIndex = 12;
            this.chcTieneComprobante.Text = "Tiene Comprobante?";
            this.chcTieneComprobante.UseVisualStyleBackColor = true;
            // 
            // grbBusqEspecifica
            // 
            this.grbBusqEspecifica.Controls.Add(this.txtCodigoComprobante);
            this.grbBusqEspecifica.Controls.Add(this.btnMiniBusq1);
            this.grbBusqEspecifica.Controls.Add(this.lblBase1);
            this.grbBusqEspecifica.Location = new System.Drawing.Point(14, 97);
            this.grbBusqEspecifica.Name = "grbBusqEspecifica";
            this.grbBusqEspecifica.Size = new System.Drawing.Size(555, 48);
            this.grbBusqEspecifica.TabIndex = 10;
            this.grbBusqEspecifica.TabStop = false;
            this.grbBusqEspecifica.Text = "Búsqueda por código de comprobante";
            // 
            // txtCodigoComprobante
            // 
            this.txtCodigoComprobante.Location = new System.Drawing.Point(159, 22);
            this.txtCodigoComprobante.Name = "txtCodigoComprobante";
            this.txtCodigoComprobante.Size = new System.Drawing.Size(164, 20);
            this.txtCodigoComprobante.TabIndex = 3;
            this.txtCodigoComprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoComprobante_KeyPress);
            // 
            // btnMiniBusq1
            // 
            this.btnMiniBusq1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniBusq1.BackgroundImage")));
            this.btnMiniBusq1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniBusq1.Location = new System.Drawing.Point(329, 15);
            this.btnMiniBusq1.Name = "btnMiniBusq1";
            this.btnMiniBusq1.Size = new System.Drawing.Size(36, 28);
            this.btnMiniBusq1.TabIndex = 2;
            this.btnMiniBusq1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniBusq1.UseVisualStyleBackColor = true;
            this.btnMiniBusq1.Click += new System.EventHandler(this.btnMiniBusq1_Click);
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(101, 26);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(52, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Código:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.rbtBusqGeneral);
            this.grbBase3.Controls.Add(this.rbtBusqEspecifica);
            this.grbBase3.Location = new System.Drawing.Point(14, 49);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(555, 42);
            this.grbBase3.TabIndex = 11;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Activar Tipo de Búsqueda";
            // 
            // rbtBusqGeneral
            // 
            this.rbtBusqGeneral.AutoSize = true;
            this.rbtBusqGeneral.ForeColor = System.Drawing.Color.Navy;
            this.rbtBusqGeneral.Location = new System.Drawing.Point(310, 19);
            this.rbtBusqGeneral.Name = "rbtBusqGeneral";
            this.rbtBusqGeneral.Size = new System.Drawing.Size(113, 17);
            this.rbtBusqGeneral.TabIndex = 1;
            this.rbtBusqGeneral.TabStop = true;
            this.rbtBusqGeneral.Text = "Busqueda General";
            this.rbtBusqGeneral.UseVisualStyleBackColor = true;
            this.rbtBusqGeneral.CheckedChanged += new System.EventHandler(this.rbtBusqGeneral_CheckedChanged);
            // 
            // rbtBusqEspecifica
            // 
            this.rbtBusqEspecifica.AutoSize = true;
            this.rbtBusqEspecifica.Checked = true;
            this.rbtBusqEspecifica.ForeColor = System.Drawing.Color.Navy;
            this.rbtBusqEspecifica.Location = new System.Drawing.Point(162, 19);
            this.rbtBusqEspecifica.Name = "rbtBusqEspecifica";
            this.rbtBusqEspecifica.Size = new System.Drawing.Size(127, 17);
            this.rbtBusqEspecifica.TabIndex = 0;
            this.rbtBusqEspecifica.TabStop = true;
            this.rbtBusqEspecifica.Text = "Busqueda por Código";
            this.rbtBusqEspecifica.UseVisualStyleBackColor = true;
            this.rbtBusqEspecifica.CheckedChanged += new System.EventHandler(this.rbtBusqEspecifica_CheckedChanged);
            // 
            // frmBuscarComprPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 555);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBusqEspecifica);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBusqGeneral);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbResultados);
            this.Name = "frmBuscarComprPago";
            this.Text = "Buscar Comprobante";
            this.Load += new System.EventHandler(this.frmBuscarComprPago_Load);
            this.Controls.SetChildIndex(this.grbResultados, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBusqGeneral, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBusqEspecifica, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBusqGeneral.ResumeLayout(false);
            this.grbBusqGeneral.PerformLayout();
            this.grbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgComprobantes)).EndInit();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBusqEspecifica.ResumeLayout(false);
            this.grbBusqEspecifica.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblTipoComprPago;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago;
        private GEN.ControlesBase.grbBase grbBusqGeneral;
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
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboEstadoComprobante cboEstadoComprobante;
        private GEN.ControlesBase.grbBase grbBusqEspecifica;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.rbtBase rbtBusqGeneral;
        private GEN.ControlesBase.rbtBase rbtBusqEspecifica;
        private GEN.BotonesBase.btnMiniBusq btnMiniBusq1;
        private GEN.ControlesBase.dtpCorto dtpFecInicial;
        private GEN.ControlesBase.dtpCorto dtpFecFinal;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodigoComprobante;
        private GEN.ControlesBase.txtBase txtSerie;

    }
}