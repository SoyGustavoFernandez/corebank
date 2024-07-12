namespace SolIntEls
{
    partial class frmTipoCambio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCambio));
            this.btnCancelar = new GEN.BotonesBase.btnCancelar();
            this.btnSalir = new GEN.BotonesBase.btnSalir();
            this.btnGrabar = new GEN.BotonesBase.btnGrabar();
            this.btnEditar = new GEN.BotonesBase.btnEditar();
            this.dtpFecTipCam = new GEN.ControlesBase.dtpCorto(this.components);
            this.lblBase8 = new GEN.ControlesBase.lblBase();
            this.grbBase3 = new GEN.ControlesBase.grbBase(this.components);
            this.txtTipCamVen = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase9 = new GEN.ControlesBase.lblBase();
            this.txtTipCamCom = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase1 = new GEN.ControlesBase.lblBase();
            this.txtTipCamFij = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase2 = new GEN.ControlesBase.lblBase();
            this.txtTipCamProVen = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase3 = new GEN.ControlesBase.lblBase();
            this.txtTipCamProCom = new GEN.ControlesBase.txtNumRea(this.components);
            this.lblBase4 = new GEN.ControlesBase.lblBase();
            this.grbBase1 = new GEN.ControlesBase.grbBase(this.components);
            this.chcTipFijo = new GEN.ControlesBase.chcBase(this.components);
            this.grbBase2 = new GEN.ControlesBase.grbBase(this.components);
            this.grbBase3.SuspendLayout();
            this.grbBase1.SuspendLayout();
            this.grbBase2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(389, 155);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 50);
            this.btnCancelar.TabIndex = 129;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Location = new System.Drawing.Point(511, 155);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 50);
            this.btnSalir.TabIndex = 128;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrabar.BackgroundImage")));
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(450, 155);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(60, 50);
            this.btnGrabar.TabIndex = 127;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.Location = new System.Drawing.Point(328, 155);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(60, 50);
            this.btnEditar.TabIndex = 126;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dtpFecTipCam
            // 
            this.dtpFecTipCam.Enabled = false;
            this.dtpFecTipCam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecTipCam.Location = new System.Drawing.Point(213, 16);
            this.dtpFecTipCam.Name = "dtpFecTipCam";
            this.dtpFecTipCam.Size = new System.Drawing.Size(104, 20);
            this.dtpFecTipCam.TabIndex = 119;
            // 
            // lblBase8
            // 
            this.lblBase8.AutoSize = true;
            this.lblBase8.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase8.ForeColor = System.Drawing.Color.Navy;
            this.lblBase8.Location = new System.Drawing.Point(10, 18);
            this.lblBase8.Name = "lblBase8";
            this.lblBase8.Size = new System.Drawing.Size(180, 13);
            this.lblBase8.TabIndex = 120;
            this.lblBase8.Text = "FECHA DEL TIPO DE CAMBIO:";
            // 
            // grbBase3
            // 
            this.grbBase3.Controls.Add(this.dtpFecTipCam);
            this.grbBase3.Location = new System.Drawing.Point(2, 0);
            this.grbBase3.Name = "grbBase3";
            this.grbBase3.Size = new System.Drawing.Size(569, 42);
            this.grbBase3.TabIndex = 123;
            this.grbBase3.TabStop = false;
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
            this.txtTipCamVen.TabIndex = 135;
            // 
            // lblBase9
            // 
            this.lblBase9.AutoSize = true;
            this.lblBase9.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase9.ForeColor = System.Drawing.Color.Navy;
            this.lblBase9.Location = new System.Drawing.Point(305, 17);
            this.lblBase9.Name = "lblBase9";
            this.lblBase9.Size = new System.Drawing.Size(190, 13);
            this.lblBase9.TabIndex = 134;
            this.lblBase9.Text = "Tipo Cambio Venta - Operativo:";
            // 
            // txtTipCamCom
            // 
            this.txtTipCamCom.FormatoDecimal = false;
            this.txtTipCamCom.Location = new System.Drawing.Point(213, 14);
            this.txtTipCamCom.Name = "txtTipCamCom";
            this.txtTipCamCom.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamCom.nNumDecimales = 4;
            this.txtTipCamCom.nvalor = 0D;
            this.txtTipCamCom.Size = new System.Drawing.Size(74, 20);
            this.txtTipCamCom.TabIndex = 133;
            // 
            // lblBase1
            // 
            this.lblBase1.AutoSize = true;
            this.lblBase1.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase1.ForeColor = System.Drawing.Color.Navy;
            this.lblBase1.Location = new System.Drawing.Point(10, 94);
            this.lblBase1.Name = "lblBase1";
            this.lblBase1.Size = new System.Drawing.Size(203, 13);
            this.lblBase1.TabIndex = 132;
            this.lblBase1.Text = "Tipo Cambio Compra - Operativo:";
            // 
            // txtTipCamFij
            // 
            this.txtTipCamFij.Enabled = false;
            this.txtTipCamFij.FormatoDecimal = false;
            this.txtTipCamFij.Location = new System.Drawing.Point(213, 14);
            this.txtTipCamFij.Name = "txtTipCamFij";
            this.txtTipCamFij.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamFij.nNumDecimales = 4;
            this.txtTipCamFij.nvalor = 0D;
            this.txtTipCamFij.Size = new System.Drawing.Size(98, 20);
            this.txtTipCamFij.TabIndex = 131;
            // 
            // lblBase2
            // 
            this.lblBase2.AutoSize = true;
            this.lblBase2.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase2.ForeColor = System.Drawing.Color.Navy;
            this.lblBase2.Location = new System.Drawing.Point(10, 55);
            this.lblBase2.Name = "lblBase2";
            this.lblBase2.Size = new System.Drawing.Size(207, 13);
            this.lblBase2.TabIndex = 130;
            this.lblBase2.Text = "TIPO DE CAMBIO FIJO CONTABLE:";
            // 
            // txtTipCamProVen
            // 
            this.txtTipCamProVen.FormatoDecimal = false;
            this.txtTipCamProVen.Location = new System.Drawing.Point(491, 41);
            this.txtTipCamProVen.Name = "txtTipCamProVen";
            this.txtTipCamProVen.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamProVen.nNumDecimales = 4;
            this.txtTipCamProVen.nvalor = 0D;
            this.txtTipCamProVen.Size = new System.Drawing.Size(71, 20);
            this.txtTipCamProVen.TabIndex = 139;
            // 
            // lblBase3
            // 
            this.lblBase3.AutoSize = true;
            this.lblBase3.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase3.ForeColor = System.Drawing.Color.Navy;
            this.lblBase3.Location = new System.Drawing.Point(305, 43);
            this.lblBase3.Name = "lblBase3";
            this.lblBase3.Size = new System.Drawing.Size(173, 13);
            this.lblBase3.TabIndex = 138;
            this.lblBase3.Text = "Tipo Cambio Venta - SUNAT:";
            // 
            // txtTipCamProCom
            // 
            this.txtTipCamProCom.FormatoDecimal = false;
            this.txtTipCamProCom.Location = new System.Drawing.Point(213, 41);
            this.txtTipCamProCom.Name = "txtTipCamProCom";
            this.txtTipCamProCom.nDecValor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTipCamProCom.nNumDecimales = 4;
            this.txtTipCamProCom.nvalor = 0D;
            this.txtTipCamProCom.Size = new System.Drawing.Size(75, 20);
            this.txtTipCamProCom.TabIndex = 137;
            // 
            // lblBase4
            // 
            this.lblBase4.AutoSize = true;
            this.lblBase4.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblBase4.ForeColor = System.Drawing.Color.Navy;
            this.lblBase4.Location = new System.Drawing.Point(10, 120);
            this.lblBase4.Name = "lblBase4";
            this.lblBase4.Size = new System.Drawing.Size(186, 13);
            this.lblBase4.TabIndex = 136;
            this.lblBase4.Text = "Tipo Cambio Compra - SUNAT:";
            // 
            // grbBase1
            // 
            this.grbBase1.Controls.Add(this.chcTipFijo);
            this.grbBase1.Controls.Add(this.txtTipCamFij);
            this.grbBase1.Location = new System.Drawing.Point(3, 37);
            this.grbBase1.Name = "grbBase1";
            this.grbBase1.Size = new System.Drawing.Size(568, 42);
            this.grbBase1.TabIndex = 140;
            this.grbBase1.TabStop = false;
            // 
            // chcTipFijo
            // 
            this.chcTipFijo.AutoSize = true;
            this.chcTipFijo.Location = new System.Drawing.Point(407, 16);
            this.chcTipFijo.Name = "chcTipFijo";
            this.chcTipFijo.Size = new System.Drawing.Size(155, 17);
            this.chcTipFijo.TabIndex = 142;
            this.chcTipFijo.Text = "Modificar Tipo cambio Fijo?";
            this.chcTipFijo.UseVisualStyleBackColor = true;
            this.chcTipFijo.CheckedChanged += new System.EventHandler(this.chcTipFijo_CheckedChanged);
            // 
            // grbBase2
            // 
            this.grbBase2.Controls.Add(this.txtTipCamProCom);
            this.grbBase2.Controls.Add(this.txtTipCamProVen);
            this.grbBase2.Controls.Add(this.txtTipCamVen);
            this.grbBase2.Controls.Add(this.txtTipCamCom);
            this.grbBase2.Controls.Add(this.lblBase3);
            this.grbBase2.Controls.Add(this.lblBase9);
            this.grbBase2.Location = new System.Drawing.Point(3, 77);
            this.grbBase2.Name = "grbBase2";
            this.grbBase2.Size = new System.Drawing.Size(568, 72);
            this.grbBase2.TabIndex = 141;
            this.grbBase2.TabStop = false;
            // 
            // frmTipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 232);
            this.Controls.Add(this.lblBase4);
            this.Controls.Add(this.lblBase1);
            this.Controls.Add(this.lblBase2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblBase8);
            this.Controls.Add(this.grbBase3);
            this.Controls.Add(this.grbBase1);
            this.Controls.Add(this.grbBase2);
            this.Name = "frmTipoCambio";
            this.Text = "Tipo de Cambio del Día";
            this.Load += new System.EventHandler(this.frmTipoCambio_Load);
            this.Controls.SetChildIndex(this.grbBase2, 0);
            this.Controls.SetChildIndex(this.grbBase1, 0);
            this.Controls.SetChildIndex(this.grbBase3, 0);
            this.Controls.SetChildIndex(this.lblBase8, 0);
            this.Controls.SetChildIndex(this.btnEditar, 0);
            this.Controls.SetChildIndex(this.btnGrabar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblBase2, 0);
            this.Controls.SetChildIndex(this.lblBase1, 0);
            this.Controls.SetChildIndex(this.lblBase4, 0);
            this.grbBase3.ResumeLayout(false);
            this.grbBase1.ResumeLayout(false);
            this.grbBase1.PerformLayout();
            this.grbBase2.ResumeLayout(false);
            this.grbBase2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEN.BotonesBase.btnCancelar btnCancelar;
        private GEN.BotonesBase.btnSalir btnSalir;
        private GEN.BotonesBase.btnGrabar btnGrabar;
        private GEN.BotonesBase.btnEditar btnEditar;
        public GEN.ControlesBase.dtpCorto dtpFecTipCam;
        private GEN.ControlesBase.lblBase lblBase8;
        private GEN.ControlesBase.grbBase grbBase3;
        private GEN.ControlesBase.txtNumRea txtTipCamVen;
        private GEN.ControlesBase.lblBase lblBase9;
        private GEN.ControlesBase.txtNumRea txtTipCamCom;
        private GEN.ControlesBase.lblBase lblBase1;
        private GEN.ControlesBase.txtNumRea txtTipCamFij;
        private GEN.ControlesBase.lblBase lblBase2;
        private GEN.ControlesBase.txtNumRea txtTipCamProVen;
        private GEN.ControlesBase.lblBase lblBase3;
        private GEN.ControlesBase.txtNumRea txtTipCamProCom;
        private GEN.ControlesBase.lblBase lblBase4;
        private GEN.ControlesBase.grbBase grbBase1;
        private GEN.ControlesBase.grbBase grbBase2;
        private GEN.ControlesBase.chcBase chcTipFijo;

    }
}