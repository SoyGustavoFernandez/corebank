namespace DEP.Presentacion
{
    partial class frmRptCompraVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptCompraVenta));
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnImprimir = new GEN.BotonesBase.btnImprimir();
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.lblBase5 = new GEN.ControlesBase.lblBase();
            this.cboAgencias = new GEN.ControlesBase.cboAgencia(this.components);
            this.cboEstadoComVenta = new GEN.ControlesBase.cboBase(this.components);
            this.cboTipoComVenta = new GEN.ControlesBase.cboBase(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(273, 124);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFecFin.TabIndex = 122;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(73, 124);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(100, 20);
            this.dtpFecIni.TabIndex = 121;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(17, 22);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(57, 13);
            this.lblBase3.TabIndex = 117;
            this.lblBase3.Text = "Agencia:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(343, 165);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 116;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Location = new System.Drawing.Point(277, 165);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 50);
            this.btnImprimir.TabIndex = 115;
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
            this.lblBase2.Location = new System.Drawing.Point(225, 128);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(44, 13);
            this.lblBase2.TabIndex = 114;
            this.lblBase2.Text = "Hasta:";
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(17, 128);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(48, 13);
            this.lblBase1.TabIndex = 113;
            this.lblBase1.Text = "Desde:";
            // 
            // grbBase3
            // 
            this.grbBase3.Location = new System.Drawing.Point(9, 110);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(395, 42);
            this.grbBase3.TabIndex = 123;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Rango Fechas";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.lblBase5);
            this.grbBase1.Controls.Add(this.cboAgencias);
            this.grbBase1.Controls.Add(this.cboEstadoComVenta);
            this.grbBase1.Controls.Add(this.cboTipoComVenta);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Location = new System.Drawing.Point(6, 2);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(398, 102);
            this.grbBase1.TabIndex = 124;
            this.grbBase1.TabStop = false;
            // 
            // lblBase5
            // 
            this.lblBase5.AutoSize = true;
            this.lblBase5.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase5.ForeColor = System.Drawing.Color.Navy;
            this.lblBase5.Location = new System.Drawing.Point(90, 73);
            this.lblBase5.Name = "lblBase5";
            this.lblBase5.Size = new System.Drawing.Size(50, 13);
            this.lblBase5.TabIndex = 132;
            this.lblBase5.Text = "Estado:";
            // 
            // cboAgencias
            // 
            this.cboAgencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgencias.FormattingEnabled = true;
            this.cboAgencias.Location = new System.Drawing.Point(73, 16);
            this.cboAgencias.Name = "cboAgencias";
            this.cboAgencias.Size = new System.Drawing.Size(300, 21);
            this.cboAgencias.TabIndex = 125;
            // 
            // cboEstadoComVenta
            // 
            this.cboEstadoComVenta.FormattingEnabled = true;
            this.cboEstadoComVenta.Location = new System.Drawing.Point(146, 70);
            this.cboEstadoComVenta.Name = "cboEstadoComVenta";
            this.cboEstadoComVenta.Size = new System.Drawing.Size(227, 21);
            this.cboEstadoComVenta.TabIndex = 131;
            // 
            // cboTipoComVenta
            // 
            this.cboTipoComVenta.FormattingEnabled = true;
            this.cboTipoComVenta.Location = new System.Drawing.Point(146, 43);
            this.cboTipoComVenta.Name = "cboTipoComVenta";
            this.cboTipoComVenta.Size = new System.Drawing.Size(227, 21);
            this.cboTipoComVenta.TabIndex = 129;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(24, 46);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(116, 13);
            this.lblBase4.TabIndex = 130;
            this.lblBase4.Text = "Tipo de Operación:";
            // 
            // frmRptCompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 253);
            this.Controls.Add(this.dtpFecFin);
            this.Controls.Add(this.dtpFecIni);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase1);
            this.Name = "frmRptCompraVenta";
            this.Text = "Reporte de Compra Venta";
            this.Load += new System.EventHandler(this.RptCompraVenta_Load);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.btnImprimir, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.dtpFecIni, 0);
            this.Controls.SetChildIndex(this.dtpFecFin, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.dtpCorto dtpFecFin;
        public GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnImprimir btnImprimir;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.cboAgencia cboAgencias;
        private GEN.ControlesBase.lblBase lblBase5;
        private GEN.ControlesBase.cboBase cboEstadoComVenta;
        private GEN.ControlesBase.cboBase cboTipoComVenta;
        private GEN.ControlesBase.lblBase lblBase4;
    }
}