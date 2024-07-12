namespace CNT.Presentacion
{
    partial class frmMovCtaCtbEspecifica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovCtaCtbEspecifica));
            this.txtCtaCtb = new GEN.ControlesBase.txtNumRea(this.components);
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.btnSalir1 = new GEN.BotonesBase.btnSalir();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.cboMoneda = new GEN.ControlesBase.cboMoneda(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.btnBusCta = new GEN.BotonesBase.btnMiniBusq(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDetalle = new GEN.BotonesBase.btnBlanco();
            this.btnResumen = new GEN.BotonesBase.btnBlanco();
            this.grbBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCtaCtb
            // 
            this.txtCtaCtb.FormatoDecimal = false;
            this.txtCtaCtb.Location = new System.Drawing.Point(122, 79);
            this.txtCtaCtb.Name = "txtCtaCtb";
            this.txtCtaCtb.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCtaCtb.nNumDecimales = 4;
            this.txtCtaCtb.nvalor = 0D;
            this.txtCtaCtb.Size = new System.Drawing.Size(100, 20);
            this.txtCtaCtb.TabIndex = 2;
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Location = new System.Drawing.Point(122, 24);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(121, 20);
            this.dtpFecIni.TabIndex = 0;
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Location = new System.Drawing.Point(122, 52);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(121, 20);
            this.dtpFecFin.TabIndex = 1;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 83);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(108, 13);
            this.lblBase1.TabIndex = 6;
            this.lblBase1.Text = "Cuenta Contable:";
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(8, 28);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(83, 13);
            this.lblBase3.TabIndex = 8;
            this.lblBase3.Text = "Fecha Inicial:";
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(8, 56);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(75, 13);
            this.lblBase4.TabIndex = 9;
            this.lblBase4.Text = "Fecha Final:";
            // 
            // btnSalir1
            // 
            this.btnSalir1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir1.BackgroundImage")));
            this.btnSalir1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir1.Location = new System.Drawing.Point(195, 155);
            this.btnSalir1.Name = "btnSalir1";
            this.btnSalir1.Size = new System.Drawing.Size(60, 50);
            this.btnSalir1.TabIndex = 3;
            this.btnSalir1.Text = "&Salir";
            this.btnSalir1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir1.UseVisualStyleBackColor = true;
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.cboMoneda);
            this.grbBase1.Controls.Add(this.lblBase2);
            this.grbBase1.Controls.Add(this.btnBusCta);
            this.grbBase1.Controls.Add(this.lblBase1);
            this.grbBase1.Controls.Add(this.txtCtaCtb);
            this.grbBase1.Controls.Add(this.lblBase4);
            this.grbBase1.Controls.Add(this.dtpFecIni);
            this.grbBase1.Controls.Add(this.lblBase3);
            this.grbBase1.Controls.Add(this.dtpFecFin);
            this.grbBase1.Location = new System.Drawing.Point(12, 12);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(290, 137);
            this.grbBase1.TabIndex = 0;
            this.grbBase1.TabStop = false;
            this.grbBase1.Text = "Datos de la Cuenta Contable";
            // 
            // cboMoneda
            // 
            this.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(122, 107);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(142, 21);
            this.cboMoneda.TabIndex = 20;
            this.cboMoneda.SelectedIndexChanged += new System.EventHandler(this.cboMoneda_SelectedIndexChanged);
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 110);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(56, 13);
            this.lblBase2.TabIndex = 10;
            this.lblBase2.Text = "Moneda:";
            // 
            // btnBusCta
            // 
            this.btnBusCta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusCta.BackgroundImage")));
            this.btnBusCta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusCta.Location = new System.Drawing.Point(228, 75);
            this.btnBusCta.Name = "btnBusCta";
            this.btnBusCta.Size = new System.Drawing.Size(36, 28);
            this.btnBusCta.TabIndex = 3;
            this.btnBusCta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusCta.UseVisualStyleBackColor = true;
            this.btnBusCta.Click += new System.EventHandler(this.btnBusCta_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackgroundImage = global::CNT.Presentacion.Properties.Resources.btnImprimir;
            this.btnDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDetalle.Location = new System.Drawing.Point(59, 155);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(60, 50);
            this.btnDetalle.TabIndex = 1;
            this.btnDetalle.Text = "&Detalle";
            this.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnResumen
            // 
            this.btnResumen.BackgroundImage = global::CNT.Presentacion.Properties.Resources.btnImprimir;
            this.btnResumen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnResumen.Location = new System.Drawing.Point(127, 155);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(60, 50);
            this.btnResumen.TabIndex = 2;
            this.btnResumen.Text = "&Resumen";
            this.btnResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // frmMovCtaCtb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 234);
            this.Controls.Add(this.btnResumen);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.btnSalir1);
            this.Name = "frmMovCtaCtb";
            this.Text = "Movimiento Cuenta Contable";
            this.Load += new System.EventHandler(this.frmLibroMayor_Load);
            this.Controls.SetChildIndex(this.btnSalir1, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.btnDetalle, 0);
            this.Controls.SetChildIndex(this.btnResumen, 0);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.ControlesBase.txtNumRea txtCtaCtb;
        private GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.BotonesBase.btnSalir btnSalir1;
        private GEN.ControlesBase.grbBase grbBase1;
        private System.Windows.Forms.ToolTip toolTip1;
        private GEN.BotonesBase.btnMiniBusq btnBusCta;
        private GEN.BotonesBase.btnBlanco btnDetalle;
        private GEN.BotonesBase.btnBlanco btnResumen;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.cboMoneda cboMoneda;
    }
}