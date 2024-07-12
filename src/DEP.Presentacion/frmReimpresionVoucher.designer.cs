namespace DEP.Presentacion
{
    partial class frmReimpresionVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReimpresionVoucher));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.txtNroKardex = new GEN.ControlesBase.txtBase(this.components);
            this.txtEstadoOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase32 = new GEN.ControlesBase.lblBase();
            this.txtModulo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase11 = new GEN.ControlesBase.lblBase();
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.txtMonOpe = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipoOperacion = new GEN.ControlesBase.txtBase(this.components);
            this.txtFechaOpe = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.txtMotivo = new GEN.ControlesBase.txtBase(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblNroImpresion = new GEN.ControlesBase.lblBase();
            this.chcSaldo = new GEN.ControlesBase.chcBase(this.components);
            this.btnSolAprobadas = new GEN.BotonesBase.btnSolAprobadas();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtNroKardex);
            this.grbBase1.Controls.Add(this.txtEstadoOpe);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.lblBase32);
            this.grbBase1.Location = new System.Drawing.Point(6, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(317, 72);
            this.grbBase1.TabIndex = 134;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Buscar Operación";
            // 
            // txtNroKardex
            // 
            this.txtNroKardex.Enabled = false;
            this.txtNroKardex.Location = new System.Drawing.Point(142, 17);
            this.txtNroKardex.MaxLength = 15;
            this.txtNroKardex.Name = "txtNroKardex";
            this.txtNroKardex.Size = new System.Drawing.Size(154, 20);
            this.txtNroKardex.TabIndex = 1;
            this.txtNroKardex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroKardex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroKardex_KeyPress);
            // 
            // txtEstadoOpe
            // 
            this.txtEstadoOpe.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstadoOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstadoOpe.Enabled = false;
            this.txtEstadoOpe.Location = new System.Drawing.Point(142, 45);
            this.txtEstadoOpe.Name = "txtEstadoOpe";
            this.txtEstadoOpe.Size = new System.Drawing.Size(154, 20);
            this.txtEstadoOpe.TabIndex = 141;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(6, 48);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(112, 13);
            this.lblBase1.TabIndex = 167;
            this.lblBase1.Text = "Estado Operación:";
            // 
            // lblBase32
            // 
            this.lblBase32.AutoSize = true;
            this.lblBase32.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase32.ForeColor = System.Drawing.Color.Navy;
            this.lblBase32.Location = new System.Drawing.Point(4, 20);
            this.lblBase32.Name = "lblBase32";
            this.lblBase32.Size = new System.Drawing.Size(137, 13);
            this.lblBase32.TabIndex = 132;
            this.lblBase32.Text = "Número de Operación:";
            // 
            // txtModulo
            // 
            this.txtModulo.BackColor = System.Drawing.SystemColors.Control;
            this.txtModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(141, 123);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(246, 20);
            this.txtModulo.TabIndex = 186;
            // 
            // lblBase11
            // 
            this.lblBase11.AutoSize = true;
            this.lblBase11.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase11.ForeColor = System.Drawing.Color.Navy;
            this.lblBase11.Location = new System.Drawing.Point(18, 41);
            this.lblBase11.Name = "lblBase11";
            this.lblBase11.Size = new System.Drawing.Size(52, 13);
            this.lblBase11.TabIndex = 187;
            this.lblBase11.Text = "Módulo:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.Enabled = false;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(141, 175);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(246, 21);
            this.cboMoneda.TabIndex = 184;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(18, 93);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(56, 13);
            this.lblBase7.TabIndex = 183;
            this.lblBase7.Text = "Moneda:";
            // 
            // txtMonOpe
            // 
            this.txtMonOpe.BackColor = System.Drawing.SystemColors.Control;
            this.txtMonOpe.Enabled = false;
            this.txtMonOpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonOpe.FormatoDecimal = false;
            this.txtMonOpe.Location = new System.Drawing.Point(141, 201);
            this.txtMonOpe.Name = "txtMonOpe";
            this.txtMonOpe.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtMonOpe.nNumDecimales = 4;
            this.txtMonOpe.nvalor = 0D;
            this.txtMonOpe.Size = new System.Drawing.Size(246, 20);
            this.txtMonOpe.TabIndex = 181;
            this.txtMonOpe.Text = "0.00";
            this.txtMonOpe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(18, 119);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(108, 13);
            this.lblBase6.TabIndex = 180;
            this.lblBase6.Text = "Monto Operación:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(18, 67);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(98, 13);
            this.lblBase2.TabIndex = 179;
            this.lblBase2.Text = "Tipo Operación:";
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTipoOperacion);
            this.grbBase2.Controls.Add(this.txtFechaOpe);
            this.grbBase2.Controls.Add(this.lblBase4);
            this.grbBase2.Controls.Add(this.grbBase3);
            this.grbBase2.Controls.Add(this.lblBase11);
            this.grbBase2.Controls.Add(this.lblBase2);
            this.grbBase2.Controls.Add(this.lblBase6);
            this.grbBase2.Controls.Add(this.lblBase7);
            this.grbBase2.Location = new System.Drawing.Point(8, 84);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(388, 145);
            this.grbBase2.TabIndex = 182;
            this.grbBase2.TabStop = false;
            this.grbBase2.Text = "Datos de la Operación";
            // 
            // txtTipoOperacion
            // 
            this.txtTipoOperacion.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipoOperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoOperacion.Enabled = false;
            this.txtTipoOperacion.Location = new System.Drawing.Point(133, 63);
            this.txtTipoOperacion.Name = "txtTipoOperacion";
            this.txtTipoOperacion.Size = new System.Drawing.Size(246, 20);
            this.txtTipoOperacion.TabIndex = 197;
            // 
            // txtFechaOpe
            // 
            this.txtFechaOpe.BackColor = System.Drawing.SystemColors.Control;
            this.txtFechaOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaOpe.Enabled = false;
            this.txtFechaOpe.Location = new System.Drawing.Point(133, 14);
            this.txtFechaOpe.Name = "txtFechaOpe";
            this.txtFechaOpe.Size = new System.Drawing.Size(246, 20);
            this.txtFechaOpe.TabIndex = 168;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(18, 17);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(107, 13);
            this.lblBase4.TabIndex = 169;
            this.lblBase4.Text = "Fecha Operación:";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(1, -69);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(461, 64);
            this.grbBase3.TabIndex = 146;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Datos de la Operación";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(267, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 189;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(332, 321);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 188;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(201, 321);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 190;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir1_Click);
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(12, 238);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(49, 13);
            this.lblBase8.TabIndex = 192;
            this.lblBase8.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Enabled = false;
            this.txtMotivo.Location = new System.Drawing.Point(91, 235);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(294, 47);
            this.txtMotivo.TabIndex = 191;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(12, 288);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(68, 13);
            this.lblBase3.TabIndex = 193;
            this.lblBase3.Text = "Nro. Impr:";
            // 
            // lblNroImpresion
            // 
            this.lblNroImpresion.AutoSize = true;
            this.lblNroImpresion.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblNroImpresion.ForeColor = System.Drawing.Color.Navy;
            this.lblNroImpresion.Location = new System.Drawing.Point(88, 288);
            this.lblNroImpresion.Name = "lblNroImpresion";
            this.lblNroImpresion.Size = new System.Drawing.Size(14, 13);
            this.lblNroImpresion.TabIndex = 194;
            this.lblNroImpresion.Text = "0";
            // 
            // chcSaldo
            // 
            this.chcSaldo.AutoSize = true;
            this.chcSaldo.Location = new System.Drawing.Point(249, 288);
            this.chcSaldo.Name = "chcSaldo";
            this.chcSaldo.Size = new System.Drawing.Size(72, 17);
            this.chcSaldo.TabIndex = 195;
            this.chcSaldo.Text = "Ver Saldo";
            this.chcSaldo.UseVisualStyleBackColor = true;
            this.chcSaldo.Visible = false;
            // 
            // btnSolAprobadas
            // 
            this.btnSolAprobadas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSolAprobadas.BackgroundImage")));
            this.btnSolAprobadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSolAprobadas.Location = new System.Drawing.Point(336, 17);
            this.btnSolAprobadas.Name = "btnSolAprobadas";
            this.btnSolAprobadas.Size = new System.Drawing.Size(60, 50);
            this.btnSolAprobadas.TabIndex = 196;
            this.btnSolAprobadas.Text = "&S. Aprob.";
            this.btnSolAprobadas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSolAprobadas.UseVisualStyleBackColor = true;
            this.btnSolAprobadas.Click += new System.EventHandler(this.btnSolAprobadas_Click);
            // 
            // frmReimpresionVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 396);
            this.Controls.Add(this.btnSolAprobadas);
            this.Controls.Add(this.chcSaldo);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblNroImpresion);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtModulo);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.txtMonOpe);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmReimpresionVoucher";
            this.Text = "Reimpresión Voucher";
            this.Load += new System.EventHandler(this.frmReimpresionVoucher_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.txtMonOpe, 0);
            this.Controls.SetChildIndex(this.cboMoneda, 0);
            this.Controls.SetChildIndex(this.txtModulo, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.txtMotivo, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.lblNroImpresion, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.chcSaldo, 0);
            this.Controls.SetChildIndex(this.btnSolAprobadas, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.txtBase txtEstadoOpe;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase32;
        private GEN.ControlesBase.txtBase txtModulo;
        private GEN.ControlesBase.lblBase lblBase11;
        private GEN.ControlesBase.cboMoneda cboMoneda;
        private GEN.ControlesBase.lblBase lblBase7;
        private GEN.ControlesBase.txtNumRea txtMonOpe;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.txtBase txtFechaOpe;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.txtBase txtMotivo;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblNroImpresion;
        private GEN.ControlesBase.txtBase txtNroKardex;
        private GEN.ControlesBase.chcBase chcSaldo;
        private GEN.BotonesBase.btnSolAprobadas btnSolAprobadas;
        private GEN.ControlesBase.txtBase txtTipoOperacion;
    }
}