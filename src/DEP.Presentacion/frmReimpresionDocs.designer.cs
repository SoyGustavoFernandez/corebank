namespace DEP.Presentacion
{
    partial class frmReimpresionDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReimpresionDocs));
            this.conBusCtaAho = new GEN.ControlesBase.conBusCtaAho();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroImpresiones = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase10 = new GEN.ControlesBase.lblBase();
            this.txtCodCertificado = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtNroFolio = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.dtgFormatos = new GEN.ControlesBase.dtgBase(this.components);
            this.btnMiniAceptar = new GEN.BotonesBase.btnMiniAceptar();
            this.cboTipoCuenta = new GEN.ControlesBase.cboTipoCuenta(this.components);
            this.txtCBNumRecibo = new GEN.ControlesBase.txtCBNumerosEnteros(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpFecApe = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtProducto = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.chcExoner = new GEN.ControlesBase.chcBase(this.components);
            this.btnSolAprobadas = new GEN.BotonesBase.btnSolAprobadas();
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.grbBase2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFormatos)).BeginInit();
            this.SuspendLayout();
            // 
            // conBusCtaAho
            // 
            this.conBusCtaAho.Location = new System.Drawing.Point(7, 7);
            this.conBusCtaAho.Name = "conBusCtaAho";
            this.conBusCtaAho.Size = new System.Drawing.Size(563, 114);
            this.conBusCtaAho.TabIndex = 1;
            this.conBusCtaAho.ClicBusCta += new System.EventHandler(this.conBusCtaAho1_ClicBusCta);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(627, 398);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir1_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(500, 398);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtNroImpresiones);
            this.grbBase2.Controls.Add(this.lblBase10);
            this.grbBase2.Controls.Add(this.txtCodCertificado);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.txtNroFolio);
            this.grbBase2.Controls.Add(this.dtgFormatos);
            this.grbBase2.Controls.Add(this.btnMiniAceptar);
            this.grbBase2.Controls.Add(this.cboTipoCuenta);
            this.grbBase2.Controls.Add(this.txtCBNumRecibo);
            this.grbBase2.Controls.Add(this.cboMoneda);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.dtpFecApe);
            this.grbBase2.Controls.Add(this.lblBase5);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.txtProducto);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase1);
            this.grbBase2.Controls.Add(this.grbBase1);
            this.grbBase2.Location = new System.Drawing.Point(12, 124);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(688, 213);
            this.grbBase2.TabIndex = 9;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de Cuenta:";
            // 
            // txtNroImpresiones
            // 
            this.txtNroImpresiones.Enabled = false;
            this.txtNroImpresiones.Location = new System.Drawing.Point(516, 78);
            this.txtNroImpresiones.Name = "txtNroImpresiones";
            this.txtNroImpresiones.Size = new System.Drawing.Size(105, 20);
            this.txtNroImpresiones.TabIndex = 37;
            // 
            // lblBase10
            // 
            this.lblBase10.AutoSize = true;
            this.lblBase10.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase10.ForeColor = System.Drawing.Color.Navy;
            this.lblBase10.Location = new System.Drawing.Point(398, 81);
            this.lblBase10.Name = "lblBase10";
            this.lblBase10.Size = new System.Drawing.Size(107, 13);
            this.lblBase10.TabIndex = 36;
            this.lblBase10.Text = "Nro Impresiones:";
            // 
            // txtCodCertificado
            // 
            this.txtCodCertificado.Enabled = false;
            this.txtCodCertificado.Location = new System.Drawing.Point(570, 124);
            this.txtCodCertificado.Name = "txtCodCertificado";
            this.txtCodCertificado.Size = new System.Drawing.Size(105, 20);
            this.txtCodCertificado.TabIndex = 35;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(428, 127);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(139, 13);
            this.lblBase9.TabIndex = 34;
            this.lblBase9.Text = "Código del Certificado:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(419, 152);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(149, 13);
            this.lblBase6.TabIndex = 32;
            this.lblBase6.Text = "Nro Folio del Certificado:";
            // 
            // txtNroFolio
            // 
            this.txtNroFolio.Enabled = false;
            this.txtNroFolio.Location = new System.Drawing.Point(570, 149);
            this.txtNroFolio.MaxLength = 8;
            this.txtNroFolio.Name = "txtNroFolio";
            this.txtNroFolio.Size = new System.Drawing.Size(105, 20);
            this.txtNroFolio.TabIndex = 33;
            // 
            // dtgFormatos
            // 
            this.dtgFormatos.AllowUserToAddRows = false;
            this.dtgFormatos.AllowUserToDeleteRows = false;
            this.dtgFormatos.AllowUserToResizeColumns = false;
            this.dtgFormatos.AllowUserToResizeRows = false;
            this.dtgFormatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgFormatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFormatos.Location = new System.Drawing.Point(9, 111);
            this.dtgFormatos.MultiSelect = false;
            this.dtgFormatos.Name = "dtgFormatos";
            this.dtgFormatos.ReadOnly = true;
            this.dtgFormatos.RowHeadersVisible = false;
            this.dtgFormatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgFormatos.Size = new System.Drawing.Size(380, 93);
            this.dtgFormatos.TabIndex = 29;
            // 
            // btnMiniAceptar
            // 
            this.btnMiniAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMiniAceptar.BackgroundImage")));
            this.btnMiniAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiniAceptar.Enabled = false;
            this.btnMiniAceptar.Location = new System.Drawing.Point(649, 174);
            this.btnMiniAceptar.Name = "btnMiniAceptar";
            this.btnMiniAceptar.Size = new System.Drawing.Size(24, 22);
            this.btnMiniAceptar.TabIndex = 11;
            this.btnMiniAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMiniAceptar.UseVisualStyleBackColor = true;
            this.btnMiniAceptar.Visible = false;
            this.btnMiniAceptar.Click += new System.EventHandler(this.btnMiniAceptar1_Click);
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCuenta.Enabled = false;
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(517, 26);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(149, 21);
            this.cboTipoCuenta.TabIndex = 21;
            // 
            // txtCBNumRecibo
            // 
            this.txtCBNumRecibo.Enabled = false;
            this.txtCBNumRecibo.Location = new System.Drawing.Point(524, 176);
            this.txtCBNumRecibo.MaxLength = 15;
            this.txtCBNumRecibo.Name = "txtCBNumRecibo";
            this.txtCBNumRecibo.Size = new System.Drawing.Size(120, 20);
            this.txtCBNumRecibo.TabIndex = 23;
            this.txtCBNumRecibo.Visible = false;
            this.txtCBNumRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCBNumRecibo_KeyPress);
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(516, 52);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(149, 21);
            this.cboMoneda.TabIndex = 11;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(431, 179);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(89, 13);
            this.lblBase7.TabIndex = 22;
            this.lblBase7.Text = "Nro de recibo:";
            this.lblBase7.Visible = false;
            // 
            // lblBase4
            // 
            this.lblBase4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblBase4.Location = new System.Drawing.Point(9, 93);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(379, 17);
            this.lblBase4.TabIndex = 20;
            this.lblBase4.Text = "Documentos para Reimpresión";
            this.lblBase4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFecApe
            // 
            this.dtpFecApe.Enabled = false;
            this.dtpFecApe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecApe.Location = new System.Drawing.Point(240, 50);
            this.dtpFecApe.Name = "dtpFecApe";
            this.dtpFecApe.Size = new System.Drawing.Size(149, 20);
            this.dtpFecApe.TabIndex = 19;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(122, 52);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(99, 13);
            this.lblBase5.TabIndex = 18;
            this.lblBase5.Text = "Fecha Apertura:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(442, 55);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(56, 13);
            this.lblBase3.TabIndex = 14;
            this.lblBase3.Text = "Moneda:";
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.SystemColors.Control;
            this.txtProducto.Enabled = false;
            this.txtProducto.Location = new System.Drawing.Point(75, 24);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(316, 20);
            this.txtProducto.TabIndex = 11;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(399, 28);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(99, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Tipo de Cuenta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(9, 25);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(62, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Producto:";
            // 
            // grbBase1
            // 
            this.grbBase1.Location = new System.Drawing.Point(402, 111);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(280, 93);
            this.grbBase1.TabIndex = 29;
            this.grbBase1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(564, 398);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(63, 343);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(343, 47);
            this.txtMotivo.TabIndex = 25;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 346);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(49, 13);
            this.lblBase8.TabIndex = 26;
            this.lblBase8.Text = "Motivo:";
            // 
            // chcExoner
            // 
            this.chcExoner.AutoSize = true;
            this.chcExoner.Enabled = false;
            this.chcExoner.Location = new System.Drawing.Point(7, 424);
            this.chcExoner.Name = "chcExoner";
            this.chcExoner.Size = new System.Drawing.Size(99, 17);
            this.chcExoner.TabIndex = 27;
            this.chcExoner.Text = "Exonerar Cobro";
            this.chcExoner.UseVisualStyleBackColor = true;
            this.chcExoner.Visible = false;
            this.chcExoner.CheckedChanged += new System.EventHandler(this.chcExoner_CheckedChanged);
            // 
            // btnSolAprobadas
            // 
            this.btnSolAprobadas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolAprobadas.BackgroundImage")));
            this.btnSolAprobadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolAprobadas.Location = new System.Drawing.Point(600, 37);
            this.btnSolAprobadas.Name = "btnSolAprobadas";
            this.btnSolAprobadas.Size = new System.Drawing.Size(60, 50);
            this.btnSolAprobadas.TabIndex = 28;
            this.btnSolAprobadas.Text = "&S. Aprob.";
            this.btnSolAprobadas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolAprobadas.UseVisualStyleBackColor = true;
            this.btnSolAprobadas.Click += new System.EventHandler(this.btnSolAprobadas_Click);
            // 
            // lblBase11
            // 
            this.lblBase11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblBase11.Location = new System.Drawing.Point(410, 344);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(280, 47);
            this.lblBase11.TabIndex = 38;
            this.lblBase11.Text = "La reimpresión, puede tener algún costo, por favor debe proceder de acuerdo a su " +
    "procedimiento.";
            this.lblBase11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmReimpresionDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 474);
            this.Controls.Add(this.lblBase11);
            this.Controls.Add(this.btnSolAprobadas);
            this.Controls.Add(this.chcExoner);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.conBusCtaAho);
            this.Name = "frmReimpresionDocs";
            this.Text = "Reimpresión Formatos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReimpresionDocs_FormClosed);
            this.Load += new System.EventHandler(this.frmReimpresionCertificado_Load);
            this.Controls.SetChildIndex(this.conBusCtaAho, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.chcExoner, 0);
            this.Controls.SetChildIndex(this.btnSolAprobadas, 0);
            this.Controls.SetChildIndex(this.lblBase11, 0);
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFormatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.conBusCtaAho conBusCtaAho;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtBase txtProducto;
        private GEN.ControlesBase.dtpCorto dtpFecApe;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.cboTipoCuenta cboTipoCuenta;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCBNumRecibo;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.BotonesBase.btnMiniAceptar btnMiniAceptar;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.chcBase chcExoner;
        private GEN.BotonesBase.btnSolAprobadas btnSolAprobadas;
        private GEN.ControlesBase.dtgBase dtgFormatos;
        private GEN.ControlesBase.txtCBNumerosEnteros txtCodCertificado;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroFolio;
        private GEN.ControlesBase.txtCBNumerosEnteros txtNroImpresiones;
        private GEN.ControlesBase.lblBase lblBase10;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.lblBase lblBase11;
    }
}