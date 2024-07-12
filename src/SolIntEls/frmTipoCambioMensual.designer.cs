namespace SolIntEls
{
    partial class frmTipoCambioMensual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCambioMensual));
            this.dtpFecFin = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase7 = new GEN.ControlesBase.lblBase();
            this.dtpFecIni = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.txtTipCamProVen = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTipCamProCom = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.txtTipCamVen = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtTipCamCom = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTipCamFij = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.btnProcesar = new GEN.BotonesBase.btnProcesar();
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecFin
            // 
            this.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecFin.Location = new System.Drawing.Point(391, 16);
            this.dtpFecFin.Name = "dtpFecFin";
            this.dtpFecFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFecFin.TabIndex = 106;
            // 
            // lblBase7
            // 
            this.lblBase7.AutoSize = true;
            this.lblBase7.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase7.ForeColor = System.Drawing.Color.Navy;
            this.lblBase7.Location = new System.Drawing.Point(298, 18);
            this.lblBase7.Name = "lblBase7";
            this.lblBase7.Size = new System.Drawing.Size(87, 13);
            this.lblBase7.TabIndex = 107;
            this.lblBase7.Text = "FECHA FINAL:";
            // 
            // dtpFecIni
            // 
            this.dtpFecIni.Enabled = false;
            this.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecIni.Location = new System.Drawing.Point(107, 16);
            this.dtpFecIni.Name = "dtpFecIni";
            this.dtpFecIni.Size = new System.Drawing.Size(100, 20);
            this.dtpFecIni.TabIndex = 104;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(4, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(100, 13);
            this.lblBase8.TabIndex = 105;
            this.lblBase8.Text = "FECHA INICIAL:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFecFin);
            this.grbBase3.Controls.Add(this.lblBase7);
            this.grbBase3.Controls.Add(this.dtpFecIni);
            this.grbBase3.Controls.Add(this.lblBase8);
            this.grbBase3.Location = new System.Drawing.Point(4, 3);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(566, 42);
            this.grbBase3.TabIndex = 108;
            this.grbBase3.TabStop = false;
            this.grbBase3.Text = "Rango Fechas";
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(510, 162);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 117;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtTipCamProVen
            // 
            this.txtTipCamProVen.FormatoDecimal = false;
            this.txtTipCamProVen.Location = new System.Drawing.Point(491, 40);
            this.txtTipCamProVen.Name = "txtTipCamProVen";
            this.txtTipCamProVen.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamProVen.nNumDecimales = 4;
            this.txtTipCamProVen.nvalor = 0D;
            this.txtTipCamProVen.Size = new System.Drawing.Size(71, 20);
            this.txtTipCamProVen.TabIndex = 151;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(305, 132);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(173, 13);
            this.lblBase3.TabIndex = 150;
            this.lblBase3.Text = "Tipo Cambio Venta - SUNAT:";
            // 
            // txtTipCamProCom
            // 
            this.txtTipCamProCom.FormatoDecimal = false;
            this.txtTipCamProCom.Location = new System.Drawing.Point(211, 40);
            this.txtTipCamProCom.Name = "txtTipCamProCom";
            this.txtTipCamProCom.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamProCom.nNumDecimales = 4;
            this.txtTipCamProCom.nvalor = 0D;
            this.txtTipCamProCom.Size = new System.Drawing.Size(79, 20);
            this.txtTipCamProCom.TabIndex = 149;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(8, 130);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(186, 13);
            this.lblBase4.TabIndex = 148;
            this.lblBase4.Text = "Tipo Cambio Compra - SUNAT:";
            // 
            // txtTipCamVen
            // 
            this.txtTipCamVen.FormatoDecimal = false;
            this.txtTipCamVen.Location = new System.Drawing.Point(492, 14);
            this.txtTipCamVen.Name = "txtTipCamVen";
            this.txtTipCamVen.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamVen.nNumDecimales = 4;
            this.txtTipCamVen.nvalor = 0D;
            this.txtTipCamVen.Size = new System.Drawing.Size(70, 20);
            this.txtTipCamVen.TabIndex = 147;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(305, 104);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(190, 13);
            this.lblBase9.TabIndex = 146;
            this.lblBase9.Text = "Tipo Cambio Venta - Operativo:";
            // 
            // txtTipCamCom
            // 
            this.txtTipCamCom.FormatoDecimal = false;
            this.txtTipCamCom.Location = new System.Drawing.Point(211, 14);
            this.txtTipCamCom.Name = "txtTipCamCom";
            this.txtTipCamCom.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamCom.nNumDecimales = 4;
            this.txtTipCamCom.nvalor = 0D;
            this.txtTipCamCom.Size = new System.Drawing.Size(79, 20);
            this.txtTipCamCom.TabIndex = 145;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(8, 104);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(203, 13);
            this.lblBase1.TabIndex = 144;
            this.lblBase1.Text = "Tipo Cambio Compra - Operativo:";
            // 
            // txtTipCamFij
            // 
            this.txtTipCamFij.FormatoDecimal = false;
            this.txtTipCamFij.Location = new System.Drawing.Point(211, 16);
            this.txtTipCamFij.Name = "txtTipCamFij";
            this.txtTipCamFij.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamFij.nNumDecimales = 4;
            this.txtTipCamFij.nvalor = 0D;
            this.txtTipCamFij.Size = new System.Drawing.Size(104, 20);
            this.txtTipCamFij.TabIndex = 143;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(8, 65);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(207, 13);
            this.lblBase2.TabIndex = 142;
            this.lblBase2.Text = "TIPO DE CAMBIO FIJO CONTABLE:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.txtTipCamFij);
            this.grbBase1.Location = new System.Drawing.Point(3, 47);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(568, 42);
            this.grbBase1.TabIndex = 152;
            this.grbBase1.TabStop = false;
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTipCamProCom);
            this.grbBase2.Controls.Add(this.txtTipCamProVen);
            this.grbBase2.Controls.Add(this.txtTipCamVen);
            this.grbBase2.Controls.Add(this.txtTipCamCom);
            this.grbBase2.Location = new System.Drawing.Point(3, 87);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(568, 69);
            this.grbBase2.TabIndex = 153;
            this.grbBase2.TabStop = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.BackgroundImage")));
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProcesar.Location = new System.Drawing.Point(444, 162);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(60, 50);
            this.btnProcesar.TabIndex = 154;
            this.btnProcesar.Text = "&Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // frmTipoCambioMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 238);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblBase3);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase9);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grbBase3);
            this.Name = "frmTipoCambioMensual";
            this.Text = "Tipo de Cambio Mensual";
            this.Load += new System.EventHandler(this.frmTipoCambioMensual_Load);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase9, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.Controls.SetChildIndex(this.lblBase3, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase3.PerformLayout();
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GEN.ControlesBase.dtpCorto dtpFecFin;
        private GEN.ControlesBase.lblBase lblBase7;
        public GEN.ControlesBase.dtpCorto dtpFecIni;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.ControlesBase.txtNumRea txtTipCamProVen;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtTipCamProCom;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.txtNumRea txtTipCamVen;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtTipCamCom;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtTipCamFij;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.BotonesBase.btnProcesar btnProcesar;
    }
}