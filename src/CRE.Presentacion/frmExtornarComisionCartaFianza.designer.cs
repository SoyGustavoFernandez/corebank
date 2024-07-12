namespace CRE.Presentacion
{
    partial class frmExtornarComisionCartaFianza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtornarComisionCartaFianza));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtKardex = new GEN.ControlesBase.txtBase(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.lblBase6 = new GEN.ControlesBase.lblBase();
            this.txtTipoDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.txtNumeroDocumento = new GEN.ControlesBase.txtBase(this.components);
            this.txtMoneda = new GEN.ControlesBase.txtBase(this.components);
            this.txtMonto = new GEN.ControlesBase.txtBase(this.components);
            this.txtFecha = new GEN.ControlesBase.txtBase(this.components);
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.btnListaAprob1 = new GEN.BotonesBase.btnListaAprob();
            this.btnExtorno1 = new GEN.BotonesBase.btnExtorno();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKardex);
            this.groupBox1.Controls.Add(this.lblBase1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos entrada";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 20);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(119, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Numero Operación:";
            // 
            // txtKardex
            // 
            this.txtKardex.Enabled = false;
            this.txtKardex.Location = new System.Drawing.Point(142, 17);
            this.txtKardex.Name = "txtKardex";
            this.txtKardex.Size = new System.Drawing.Size(196, 20);
            this.txtKardex.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFecha);
            this.groupBox2.Controls.Add(this.txtMonto);
            this.groupBox2.Controls.Add(this.txtMoneda);
            this.groupBox2.Controls.Add(this.txtNumeroDocumento);
            this.groupBox2.Controls.Add(this.txtTipoDocumento);
            this.groupBox2.Controls.Add(this.lblBase6);
            this.groupBox2.Controls.Add(this.lblBase5);
            this.groupBox2.Controls.Add(this.lblBase4);
            this.groupBox2.Controls.Add(this.lblBase3);
            this.groupBox2.Controls.Add(this.lblBase2);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 154);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle del movimiento";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(39, 26);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(105, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Tipo Documento:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(18, 50);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(126, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Numero Documento:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(88, 74);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(56, 13);
            this.lblBase4.TabIndex = 3;
            this.lblBase4.Text = "Moneda:";
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(98, 98);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(46, 13);
            this.lblBase5.TabIndex = 4;
            this.lblBase5.Text = "Monto:";
            // 
            // lblBase6
            // 
            this.lblBase6.AutoSize = true;
            this.lblBase6.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase6.ForeColor = System.Drawing.Color.Navy;
            this.lblBase6.Location = new System.Drawing.Point(57, 123);
            this.lblBase6.Name = "lblBase6";
            this.lblBase6.Size = new System.Drawing.Size(86, 13);
            this.lblBase6.TabIndex = 5;
            this.lblBase6.Text = "Fecha y hora:";
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Enabled = false;
            this.txtTipoDocumento.Location = new System.Drawing.Point(150, 23);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.Size = new System.Drawing.Size(246, 20);
            this.txtTipoDocumento.TabIndex = 7;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Enabled = false;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(150, 47);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(246, 20);
            this.txtNumeroDocumento.TabIndex = 8;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Location = new System.Drawing.Point(150, 71);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(246, 20);
            this.txtMoneda.TabIndex = 9;
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(150, 95);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(246, 20);
            this.txtMonto.TabIndex = 10;
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(150, 120);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(246, 20);
            this.txtFecha.TabIndex = 11;
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(362, 228);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 5;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // btnListaAprob1
            // 
            this.btnListaAprob1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnListaAprob1.BackgroundImage")));
            this.btnListaAprob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListaAprob1.Location = new System.Drawing.Point(362, 12);
            this.btnListaAprob1.Name = "btnListaAprob1";
            this.btnListaAprob1.Size = new System.Drawing.Size(60, 50);
            this.btnListaAprob1.TabIndex = 3;
            this.btnListaAprob1.Text = "&Lista Aprob.";
            this.btnListaAprob1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaAprob1.UseVisualStyleBackColor = true;
            this.btnListaAprob1.Click += new System.EventHandler(this.btnListaAprob1_Click);
            // 
            // btnExtorno1
            // 
            this.btnExtorno1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtorno1.BackgroundImage")));
            this.btnExtorno1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtorno1.Location = new System.Drawing.Point(296, 228);
            this.btnExtorno1.Name = "btnExtorno1";
            this.btnExtorno1.Size = new System.Drawing.Size(60, 50);
            this.btnExtorno1.TabIndex = 6;
            this.btnExtorno1.Text = "&Extornar";
            this.btnExtorno1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExtorno1.UseVisualStyleBackColor = true;
            this.btnExtorno1.Click += new System.EventHandler(this.btnExtorno1_Click);
            // 
            // frmExtornarComisionCartaFianza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 310);
            this.Controls.Add(this.btnExtorno1);
            this.Controls.Add(this.btnSalir1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnListaAprob1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmExtornarComisionCartaFianza";
            this.Text = "Extornar Comision Carta Fianza";
            this.Load += new System.EventHandler(this.frmExtornarComisionCartaFianza_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnListaAprob1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.btnExtorno1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtBase txtKardex;
        private GEN.BotonesBase.btnListaAprob btnListaAprob1;
        private System.Windows.Forms.GroupBox groupBox2;
        private GEN.ControlesBase.txtBase txtFecha;
        private GEN.ControlesBase.txtBase txtMonto;
        private GEN.ControlesBase.txtBase txtMoneda;
        private GEN.ControlesBase.txtBase txtNumeroDocumento;
        private GEN.ControlesBase.txtBase txtTipoDocumento;
        private GEN.ControlesBase.lblBase lblBase6;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.BotonesBase.btnExtorno btnExtorno1;
    }
}