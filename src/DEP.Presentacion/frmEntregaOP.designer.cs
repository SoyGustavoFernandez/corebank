namespace DEP.Presentacion
{
    partial class frmEntregaOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaOP));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.txtNombre = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtBase1 = new GEN.ControlesBase.txtBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dtgSolOP = new GEN.ControlesBase.dtgBase(this.components);
            this.grbBase6 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNumFirmas = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.ptbFirma = new System.Windows.Forms.PictureBox();
            this.dtgIntervinientes = new System.Windows.Forms.DataGridView();
            this.idSolicitudOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCorto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDocumentoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAgencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNomCortoAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.conBusCtaAho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).BeginInit();
            this.grbBase6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Controls.Add(this.txtNombre);
            this.conBusCtaAho.Controls.Add(this.grbBase1);
            this.conBusCtaAho.Controls.Add(this.txtBase1);
            this.conBusCtaAho.Controls.Add(this.grbBase2);
            this.conBusCtaAho.Location = new System.Drawing.Point(9, 11);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(580, 114);
            this.conBusCtaAho.TabIndex = 4;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho_ClicBusCta);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(158, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(395, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(3, -1);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(556, 112);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos del Cliente";
            // 
            // txtBase1
            // 
            this.txtBase1.Enabled = false;
            this.txtBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase1.Location = new System.Drawing.Point(158, 82);
            this.txtBase1.Name = "txtBase1";
            this.txtBase1.Size = new System.Drawing.Size(395, 20);
            this.txtBase1.TabIndex = 15;
            // 
            // grbBase2
            // 
            this.grbBase2.Location = new System.Drawing.Point(3, -1);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(556, 112);
            this.grbBase2.TabIndex = 0;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos del Cliente";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(5, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(819, 21);
            this.label1.TabIndex = 139;
            this.label1.Text = "Listado de Talonarios a Entregar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgSolOP
            // 
            this.dtgSolOP.AllowUserToAddRows = false;
            this.dtgSolOP.AllowUserToDeleteRows = false;
            this.dtgSolOP.AllowUserToResizeColumns = false;
            this.dtgSolOP.AllowUserToResizeRows = false;
            this.dtgSolOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSolOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolOP.Location = new System.Drawing.Point(5, 389);
            this.dtgSolOP.MultiSelect = false;
            this.dtgSolOP.Name = "dtgSolOP";
            this.dtgSolOP.ReadOnly = true;
            this.dtgSolOP.RowHeadersVisible = false;
            this.dtgSolOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolOP.Size = new System.Drawing.Size(819, 114);
            this.dtgSolOP.TabIndex = 138;
            // 
            // grbBase6
            // 
            this.grbBase6.Controls.Add(this.txtNumFirmas);
            this.grbBase6.Controls.Add(this.lblBase2);
            this.grbBase6.Controls.Add(this.ptbFirma);
            this.grbBase6.Controls.Add(this.dtgIntervinientes);
            this.grbBase6.Location = new System.Drawing.Point(3, 166);
            this.grbBase6.Name = "grbBase6";
            this.grbBase6.Size = new System.Drawing.Size(821, 192);
            this.grbBase6.TabIndex = 140;
            this.grbBase6.TabStop = false;
            this.grbBase6.Text = "Firmas Requeridas";
            // 
            // txtNumFirmas
            // 
            this.txtNumFirmas.Enabled = false;
            this.txtNumFirmas.Location = new System.Drawing.Point(745, 19);
            this.txtNumFirmas.Name = "txtNumFirmas";
            this.txtNumFirmas.Size = new System.Drawing.Size(69, 20);
            this.txtNumFirmas.TabIndex = 92;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(595, 22);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(142, 13);
            this.lblBase2.TabIndex = 93;
            this.lblBase2.Text = "Nro Firmas Requeridos:";
            // 
            // ptbFirma
            // 
            this.ptbFirma.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbFirma.Location = new System.Drawing.Point(592, 41);
            this.ptbFirma.Name = "ptbFirma";
            this.ptbFirma.Size = new System.Drawing.Size(222, 137);
            this.ptbFirma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbFirma.TabIndex = 50;
            this.ptbFirma.TabStop = false;
            // 
            // dtgIntervinientes
            // 
            this.dtgIntervinientes.AllowUserToAddRows = false;
            this.dtgIntervinientes.AllowUserToDeleteRows = false;
            this.dtgIntervinientes.AllowUserToResizeColumns = false;
            this.dtgIntervinientes.AllowUserToResizeRows = false;
            this.dtgIntervinientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgIntervinientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSolicitudOP,
            this.idCuenta,
            this.IdCli,
            this.cNomCorto,
            this.cDocumentoID,
            this.cNombre,
            this.idAgencia,
            this.cNomCortoAge});
            this.dtgIntervinientes.Location = new System.Drawing.Point(10, 21);
            this.dtgIntervinientes.MultiSelect = false;
            this.dtgIntervinientes.Name = "dtgIntervinientes";
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.RowHeadersVisible = false;
            this.dtgIntervinientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgIntervinientes.Size = new System.Drawing.Size(573, 157);
            this.dtgIntervinientes.TabIndex = 3;
            this.dtgIntervinientes.SelectionChanged += new System.EventHandler(this.dtgIntervinientes_SelectionChanged);
            // 
            // idSolicitudOP
            // 
            this.idSolicitudOP.DataPropertyName = "idSolicitudOP";
            this.idSolicitudOP.FillWeight = 148.4772F;
            this.idSolicitudOP.HeaderText = "Solicitud";
            this.idSolicitudOP.Name = "idSolicitudOP";
            this.idSolicitudOP.ReadOnly = true;
            this.idSolicitudOP.Width = 70;
            // 
            // idCuenta
            // 
            this.idCuenta.DataPropertyName = "idCuenta";
            this.idCuenta.FillWeight = 136.3388F;
            this.idCuenta.HeaderText = "Cuenta";
            this.idCuenta.Name = "idCuenta";
            this.idCuenta.ReadOnly = true;
            this.idCuenta.Width = 90;
            // 
            // IdCli
            // 
            this.IdCli.DataPropertyName = "IdCli";
            this.IdCli.FillWeight = 80F;
            this.IdCli.HeaderText = "IdCli";
            this.IdCli.Name = "IdCli";
            this.IdCli.ReadOnly = true;
            this.IdCli.Visible = false;
            this.IdCli.Width = 10;
            // 
            // cNomCorto
            // 
            this.cNomCorto.DataPropertyName = "cNomCorto";
            this.cNomCorto.FillWeight = 90.50516F;
            this.cNomCorto.HeaderText = "Tipo Doc";
            this.cNomCorto.Name = "cNomCorto";
            this.cNomCorto.ReadOnly = true;
            this.cNomCorto.Width = 60;
            // 
            // cDocumentoID
            // 
            this.cDocumentoID.DataPropertyName = "cDocumentoID";
            this.cDocumentoID.FillWeight = 106.8301F;
            this.cDocumentoID.HeaderText = "Nro Documento";
            this.cDocumentoID.Name = "cDocumentoID";
            this.cDocumentoID.ReadOnly = true;
            // 
            // cNombre
            // 
            this.cNombre.DataPropertyName = "cNombre";
            this.cNombre.FillWeight = 167.8488F;
            this.cNombre.HeaderText = "Nombre del Cliente";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Width = 250;
            // 
            // idAgencia
            // 
            this.idAgencia.DataPropertyName = "idAgencia";
            this.idAgencia.HeaderText = "idAgencia";
            this.idAgencia.Name = "idAgencia";
            this.idAgencia.ReadOnly = true;
            this.idAgencia.Visible = false;
            // 
            // cNomCortoAge
            // 
            this.cNomCortoAge.DataPropertyName = "cNomCortoAge";
            this.cNomCortoAge.HeaderText = "cNomCortoAge";
            this.cNomCortoAge.Name = "cNomCortoAge";
            this.cNomCortoAge.ReadOnly = true;
            this.cNomCortoAge.Visible = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(639, 509);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 141;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Location = new System.Drawing.Point(698, 509);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 142;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(764, 509);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 143;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(638, 137);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(171, 21);
            this.cboTipoCuenta.TabIndex = 149;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(536, 140);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 148;
            this.lblBase5.Text = "Tipo de Cuenta:";
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(81, 137);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(240, 20);
            this.txtProducto.TabIndex = 144;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(18, 140);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(62, 13);
            this.lblBase6.TabIndex = 147;
            this.lblBase6.Text = "Producto:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(388, 137);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(130, 21);
            this.cboMoneda.TabIndex = 145;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(328, 140);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 146;
            this.lblBase7.Text = "Moneda:";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(13, 123);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(811, 43);
            this.grbBase3.TabIndex = 150;
            this.grbBase3.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(573, 509);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 151;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmEntregaOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 585);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.cboTipoCuenta);
            this.Controls.Add(this.lblBase5);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.lblBase6);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.lblBase7);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbBase6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgSolOP);
            this.Controls.Add(this.conBusCtaAho);
            this.Name = "frmEntregaOP";
            this.Text = "Entrega de Órdenes de Pago";
            this.Load += new System.EventHandler(this.frmEntregaOP_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.dtgSolOP, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.grbBase6, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.lblBase7, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.lblBase6, 0);
            this.Controls.SetChildIndex(this.txtProducto, 0);
            this.Controls.SetChildIndex(this.lblBase5, 0);
            this.Controls.SetChildIndex(this.cboTipoCuenta, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.conBusCtaAho.ResumeLayout(false);
            this.conBusCtaAho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolOP)).EndInit();
            this.grbBase6.ResumeLayout(false);
            this.grbBase6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIntervinientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.ControlesBase.txtBase txtNombre;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private System.Windows.Forms.Label label1;
        private GEN.ControlesBase.dtgBase dtgSolOP;
        private GEN.ControlesBase.grbBase grbBase6;
        private GEN.ControlesBase.txtBase txtNumFirmas;
        private GEN.ControlesBase.lblBase lblBase2;
        private System.Windows.Forms.PictureBox ptbFirma;
        private System.Windows.Forms.DataGridView dtgIntervinientes;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolicitudOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCorto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDocumentoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAgencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNomCortoAge;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnImprimir btnImprimir;
    }
}