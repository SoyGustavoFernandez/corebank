namespace CAJ.Presentacion
{
    partial class frmRptComprobantesDetraccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptComprobantesDetraccion));
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.dtpFechaIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.dtpFechaFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.cboTipoComprobantePago1 = new GEN.ControlesBase.cboTipoComprobantePago(this.components);
            this.cboAgencia1 = new GEN.ControlesBase.cboAgencia(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.rbtFecEmi = new System.Windows.Forms.RadioButton();
            this.rbtFecPago = new System.Windows.Forms.RadioButton();
            this.grbBase3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(16, 157);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(43, 13);
            this.lblBase1.TabIndex = 4;
            this.lblBase1.Text = "Desde";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(112, 154);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(128, 20);
            this.dtpFechaIni.TabIndex = 5;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(114, 209);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(16, 183);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(39, 13);
            this.lblBase2.TabIndex = 6;
            this.lblBase2.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(112, 179);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(128, 20);
            this.dtpFechaFin.TabIndex = 7;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(16, 105);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(90, 13);
            this.lblBase3.TabIndex = 0;
            this.lblBase3.Text = "Comprobante:";
            // 
            // cboTipoComprobantePago1
            // 
            this.cboTipoComprobantePago1.FormattingEnabled = true;
            this.cboTipoComprobantePago1.Location = new System.Drawing.Point(112, 102);
            this.cboTipoComprobantePago1.Name = "cboTipoComprobantePago1";
            this.cboTipoComprobantePago1.Size = new System.Drawing.Size(267, 21);
            this.cboTipoComprobantePago1.TabIndex = 1;
            // 
            // cboAgencia1
            // 
            this.cboAgencia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencia1.FormattingEnabled = true;
            this.cboAgencia1.Location = new System.Drawing.Point(112, 128);
            this.cboAgencia1.Name = "cboAgencia1";
            this.cboAgencia1.Size = new System.Drawing.Size(267, 21);
            this.cboAgencia1.TabIndex = 3;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(16, 131);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(57, 13);
            this.lblBase4.TabIndex = 2;
            this.lblBase4.Text = "Agencia:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(180, 209);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.rbtFecEmi);
            this.grbBase3.Controls.Add(this.rbtFecPago);
            this.grbBase3.Location = new System.Drawing.Point(4, 5);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(377, 89);
            this.grbBase3.TabIndex = 81;
            this.grbBase3.TabStop = false;
            // 
            // rbtFecEmi
            // 
            this.rbtFecEmi.AutoSize = true;
            this.rbtFecEmi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rbtFecEmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFecEmi.Location = new System.Drawing.Point(35, 56);
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
            this.rbtFecPago.Location = new System.Drawing.Point(35, 18);
            this.rbtFecPago.Name = "rbtFecPago";
            this.rbtFecPago.Size = new System.Drawing.Size(238, 17);
            this.rbtFecPago.TabIndex = 75;
            this.rbtFecPago.TabStop = true;
            this.rbtFecPago.Text = "Comporbantes por Fecha de Pago (Pagados)";
            this.rbtFecPago.UseVisualStyleBackColor = false;
            // 
            // frmRptComprobantesDetraccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 287);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.cboAgencia1);
            this.Controls.Add(this.cboTipoComprobantePago1);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.dtpFechaIni);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmRptComprobantesDetraccion";
            this.Text = "Reporte de Comprobantes Con Detracción";
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.dtpFechaIni, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.cboTipoComprobantePago1, 0);
            this.Controls.SetChildIndex(this.cboAgencia1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.dtpCorto dtpFechaIni;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.dtpCorto dtpFechaFin;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.cboTipoComprobantePago cboTipoComprobantePago1;
        private GEN.ControlesBase.cboAgencia cboAgencia1;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.grbBase grbBase3;
        private System.Windows.Forms.RadioButton rbtFecEmi;
        private System.Windows.Forms.RadioButton rbtFecPago;
    }
}