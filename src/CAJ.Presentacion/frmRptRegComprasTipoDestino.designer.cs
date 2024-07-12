namespace CAJ.Presentacion
{
    partial class frmRptRegComprasTipoDestino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRegComprasTipoDestino));
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboDestino = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.dtpFecFinal = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecInicial = new GEN.ControlesBase.dtpCorto(this.components);
            this.cboAgencia = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtFecEmi = new System.Windows.Forms.RadioButton();
            this.rbtFecPago = new System.Windows.Forms.RadioButton();
            this.grbBase1.SuspendLayout();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboDestino);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpFecFinal);
            this.grbBase1.Controls.Add(this.dtpFecInicial);
            this.grbBase1.Controls.Add(this.cboAgencia);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Location = new System.Drawing.Point(12, 102);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(381, 128);
            this.grbBase1.TabIndex = 5;
            this.grbBase1.TabStop = false;
            // 
            // cboDestino
            // 
            this.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(112, 17);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(254, 21);
            this.cboDestino.TabIndex = 11;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(23, 20);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(83, 13);
            this.lblBase4.TabIndex = 6;
            this.lblBase4.Text = "Tipo Destino:";
            // 
            // dtpFecFinal
            // 
            this.dtpFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFinal.Location = new System.Drawing.Point(112, 96);
            this.dtpFecFinal.Name = "dtpFecFinal";
            this.dtpFecFinal.Size = new System.Drawing.Size(182, 20);
            this.dtpFecFinal.TabIndex = 5;
            // 
            // dtpFecInicial
            // 
            this.dtpFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInicial.Location = new System.Drawing.Point(112, 70);
            this.dtpFecInicial.Name = "dtpFecInicial";
            this.dtpFecInicial.Size = new System.Drawing.Size(182, 20);
            this.dtpFecInicial.TabIndex = 4;
            // 
            // cboAgencia
            // 
            this.cboAgencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia.FormattingEnabled = true;
            this.cboAgencia.Location = new System.Drawing.Point(112, 43);
            this.cboAgencia.Name = "cboAgencia";
            this.cboAgencia.Size = new System.Drawing.Size(254, 21);
            this.cboAgencia.TabIndex = 3;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(23, 46);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 2;
            this.lblBase3.Text = "Agencia:";
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(23, 102);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(75, 13);
            this.lblBase2.TabIndex = 1;
            this.lblBase2.Text = "Fecha Final:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(23, 76);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(83, 13);
            this.lblBase1.TabIndex = 0;
            this.lblBase1.Text = "Fecha Inicial:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(152, 236);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(218, 236);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.rbtFecEmi);
            this.grbBase3.Controls.Add(this.rbtFecPago);
            this.grbBase3.Location = new System.Drawing.Point(12, 7);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(380, 89);
            this.grbBase3.TabIndex = 81;
            this.grbBase3.TabStop = false;
            // 
            // rbtFecEmi
            // 
            this.rbtFecEmi.AutoSize = true;
            this.rbtFecEmi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbtFecEmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFecEmi.Location = new System.Drawing.Point(35, 57);
            this.rbtFecEmi.Name = "rbtFecEmi";
            this.rbtFecEmi.Size = new System.Drawing.Size(263, 17);
            this.rbtFecEmi.TabIndex = 76;
            this.rbtFecEmi.Text = "Comprobantes por Fecha de Emisión (Registrados)";
            this.rbtFecEmi.UseVisualStyleBackColor = false;
            // 
            // rbtFecPago
            // 
            this.rbtFecPago.AutoSize = true;
            this.rbtFecPago.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbtFecPago.Checked = true;
            this.rbtFecPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFecPago.Location = new System.Drawing.Point(35, 12);
            this.rbtFecPago.Name = "rbtFecPago";
            this.rbtFecPago.Size = new System.Drawing.Size(238, 17);
            this.rbtFecPago.TabIndex = 75;
            this.rbtFecPago.TabStop = true;
            this.rbtFecPago.Text = "Comporbantes por Fecha de Pago (Pagados)";
            this.rbtFecPago.UseVisualStyleBackColor = false;
            // 
            // frmRptRegComprasTipoDestino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 314);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptRegComprasTipoDestino";
            this.Text = "Reporte de Registro de Compras por Tipo Destino";
            this.Load += new System.EventHandler(this.frmRptRegComprasTipoDestino_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.dtpCorto dtpFecFinal;
        private GEN.ControlesBase.dtpCorto dtpFecInicial;
        private GEN.ControlesBase.cboAgencia cboAgencia;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.cboBase cboDestino;
        private GEN.ControlesBase.grbBase grbBase3;
        private System.Windows.Forms.RadioButton rbtFecEmi;
        private System.Windows.Forms.RadioButton rbtFecPago;
    }
}